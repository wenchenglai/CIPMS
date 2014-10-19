using System;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using CIPMSBC;
using CIPMSBC.Eligibility;
using System.Web;

public partial class Step2_URJ_2 : System.Web.UI.Page
{
    private CamperApplication CamperAppl;
    private General objGeneral;
    private Boolean bPerformUpdate;

    protected void Page_Init(object sender, EventArgs e)
    {
        btnNext.Click += new EventHandler(btnNext_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click+=new EventHandler(btnReturnAdmin_Click);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CamperAppl = new CamperApplication();
        objGeneral = new General();

        if (!Page.IsPostBack)
        {
            //to fill the grades in the dropdown
            getGrades();
            //to get the FJCID which is stored in session
            if (Session["FJCID"] != null)
            {
                hdnFJCIDStep2_2.Value = (string)Session["FJCID"];
                PopulateAnswers();
            }

            string strCampID = "";
            if (Session["CampID"] != null)
            {
                strCampID = Session["CampID"].ToString();
            }
            else if (Session["FJCID"] != null)
            {
                DataSet ds = new CamperApplication().getCamperAnswers(Session["FJCID"].ToString(), "10", "10", "N");
                int resultCampId = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow drRow = ds.Tables[0].Rows[0];
                    Int32.TryParse(drRow["Answer"].ToString(), out resultCampId);
                }
                strCampID = resultCampId.ToString();
            }

            string campIDLast3Digits = strCampID.Substring(strCampID.Length - 3);
            if (campIDLast3Digits == "132" || campIDLast3Digits == "133" || campIDLast3Digits == "146" || campIDLast3Digits == "190")
            {
                rdoFirstTimerYes.Attributes.Remove("onclick");
                rdoFirstTimerNo.Attributes.Remove("onclick");
            }
        }
    }

    void btnReturnAdmin_Click(object sender, EventArgs e)
    {
        string strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"];
        ProcessCamperAnswers();
        Response.Redirect(strRedirURL);
    }
   
    //page unload
    void Page_Unload(object sender, EventArgs e)
    {
        CamperAppl = null;
        objGeneral = null;
    }

    void btnSaveandExit_Click(object sender, EventArgs e)
    {
        //strRedirURL = ConfigurationManager.AppSettings["SaveExitRedirURL"].ToString();
        string strRedirURL = Master.SaveandExitURL;
        if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_2.Value, Master.CamperUserId))
        {
            ProcessCamperAnswers();
        }
        //Session["FJCID"] = null;
        //Session["ZIPCODE"] = null;
        // Session.Abandon();
        //Response.Redirect(strRedirURL);
        if (Master.IsCamperUser == "Yes")
        {

            General oGen = new General();
            if (oGen.IsApplicationSubmitted(Session["FJCID"].ToString()))
            {
                Response.Redirect(strRedirURL);
            }
            else
            {
                string strScript = "<script language=javascript>openThis(); window.location='" + strRedirURL + "';</script>";
                if (!ClientScript.IsStartupScriptRegistered("clientScript"))
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strScript);
                }
            }
        }
        else
        {
            Response.Redirect(strRedirURL);
        }
    }

    void btnPrevious_Click(object sender, EventArgs e)
    {
        if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_2.Value, Master.CamperUserId))
        {
            ProcessCamperAnswers();
        }
        Session["FJCID"] = hdnFJCIDStep2_2.Value;
        Response.Redirect("Summary.aspx");
    }

    void btnNext_Click(object sender, EventArgs e)
    {
        bool isReadOnly = objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_2.Value, Master.CamperUserId);
        if (!isReadOnly)
        {
            ProcessCamperAnswers();
        }

        //Modified by id taken from the Master Id
        string strModifiedBy = Master.UserId;
        string strFJCID = hdnFJCIDStep2_2.Value;
        int iStatus = Convert.ToInt32(StatusInfo.SystemInEligible);
        if (strFJCID != "" && strModifiedBy != "")
        {
            if (isReadOnly)
            {
                DataSet dsApp = CamperAppl.getCamperApplication(strFJCID);
                iStatus = Convert.ToInt16(dsApp.Tables[0].Rows[0]["Status"]);
            }
            else
            {
                var objEligibility = EligibilityFactory.GetEligibility(FederationEnum.URJ);
                EligibilityBase.EligibilityResult result = objEligibility.checkEligibilityforStep2(strFJCID, out iStatus, SessionSpecialCode.GetPJLotterySpecialCode());

                if (result.SchoolType == StatusInfo.PendingPJLottery)
                    iStatus = (int)StatusInfo.PendingPJLottery;
                else if (result.CurrentUserStatusFromDB == StatusInfo.SystemInEligible ||
                    result.Grade == StatusInfo.SystemInEligible ||
                    result.SchoolType == StatusInfo.SystemInEligible ||
                    result.TimeInCamp == StatusInfo.SystemInEligible)
                {
                    iStatus = (int)StatusInfo.SystemInEligible;
                }
                else
                {
                    iStatus = (int)StatusInfo.SystemEligible;
                }
            }
            Session["STATUS"] = iStatus.ToString();
        }
        Session["FJCID"] = hdnFJCIDStep2_2.Value;

        var status = (StatusInfo)iStatus;
        Response.Redirect(AppRouteManager.GetNextRouteBasedOnStatus(status, HttpContext.Current.Request.Url.AbsolutePath));
    }
    private void ProcessCamperAnswers()
    {
        string strFJCID;
        string strComments;
        int iGrade, iResult;
        int iRowsAffected;
        string strModifiedBy, strGrade;

        //Modified by id taken from the common.master
        strModifiedBy = Master.UserId;

        InsertCamperAnswers();

        //to update the grade to the database - to be used by the search
        strFJCID = hdnFJCIDStep2_2.Value;
        //used only by the Admin user
        strComments = txtComments.Text.Trim();
        if (strFJCID != "" && strModifiedBy!="" && bPerformUpdate)
        {
            strGrade = ddlGrade.SelectedValue;
            int.TryParse(strGrade,out iResult);
            if (iResult==0 || strGrade.Equals(string.Empty))
                iGrade=0;
            else
                iGrade = iResult;

            iRowsAffected = CamperAppl.updateGrade(strFJCID, iGrade, strComments, Convert.ToInt16(strModifiedBy));
        }
    }

    protected void InsertCamperAnswers()
    {
        string strFJCID, strComments;
        int RowsAffected;
        string strModifiedBy, strCamperAnswers; //-1 for Camper (User id will be passed for Admin user)
        
        strFJCID = hdnFJCIDStep2_2.Value;
        
        //to get the comments text (used only by the Admin user)
        strComments = txtComments.Text.Trim();

        //Modified by id taken from the common.master
        strModifiedBy = Master.UserId;

        strCamperAnswers = ConstructCamperAnswers();

        if (strFJCID != "" && strCamperAnswers != "" && strModifiedBy != "" && bPerformUpdate)
            RowsAffected = CamperAppl.InsertCamperAnswers(strFJCID, strCamperAnswers, strModifiedBy, strComments);
        CamperAppl = new CamperApplication();
       CamperAppl.UpdateTimeInCampInApplication(strFJCID);
    }

    //to fill the grade values to the grade dropdown
    private void getGrades()
    {
        DataTable dtGrade;
        dtGrade = objGeneral.getGrades(Session["FedId"].ToString(), Master.CampYear);
        ddlGrade.DataSource = dtGrade;
        ddlGrade.DataTextField = "EligibleGrade";
        ddlGrade.DataValueField = "EligibleGrade";
        ddlGrade.DataBind();
        ddlGrade.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    void PopulateAnswers()
    {
        DataSet dsAnswers = CamperAppl.getCamperAnswers(hdnFJCIDStep2_2.Value, "", "", "3,6,7,8,1063");

        foreach (DataRow dr in dsAnswers.Tables[0].Rows)
        {
            var qID = (QuestionId)dr["QuestionId"];

            if (qID == QuestionId.FirstTime) // Is this your first time to attend a Non-profit Jewish overnight camp, for 3 weeks or longer:
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                if (dr["OptionID"].ToString() == "1")
                {
                    rdoFirstTimerYes.Checked = true;
                }
                else
                {
                    rdoFirstTimerNo.Checked = true;
                }
            }
            else if (qID == QuestionId.Grade) // Grade (Mention the grade of the camper after he/she attends the camp session):
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                {
                    ddlGrade.SelectedValue = dr["Answer"].ToString();
                }
            }
            else if (qID == QuestionId.SchoolType) // What kind of the school the camper go to
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                rdoSchoolType.SelectedValue = dr["OptionID"].ToString();
                if (dr["OptionID"].ToString() == "3")
                    txtSchoolName.Enabled = false;
            }
            else if (qID == QuestionId.SchoolName) // Name of the school Camper attends:
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                {
                    txtSchoolName.Text = dr["Answer"].ToString();
                }
            }
            else if (qID == QuestionId.GrandfatherPolicySessionLength) // If a professional or fellow congregant is selected, offer this list as a check all that apply
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                if (dr["OptionID"].ToString() == "1")
                    rdoDays12.Checked = true;
                else
                    rdoDays19.Checked = true;
            }


        }
    }

    private string ConstructCamperAnswers()
    {
        var strQId = "";
        string strTablevalues = "";

        //to get the Question separator from Web.config
        var strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"];
        //to get the Field separator from Web.config
        var strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"];

        //for question FirstTimerOrNot
        strQId = ((int)QuestionId.FirstTime).ToString();
        strTablevalues += strQId + strFSeparator + Convert.ToString(rdoFirstTimerYes.Checked ? "1" : rdoFirstTimerNo.Checked ? "2" : "") + strFSeparator + strQSeparator;

        //Grandfaother question
        strQId = ((int)QuestionId.GrandfatherPolicySessionLength).ToString();
        strTablevalues += strQId + strFSeparator + (rdoDays12.Checked ? "1" : rdoDays19.Checked ? "2" : "") + strFSeparator + strQSeparator;

        //for question Grade
        strQId = ((int)QuestionId.Grade).ToString();
        strTablevalues += strQId + strFSeparator + strFSeparator + ddlGrade.SelectedValue + strQSeparator;

        //for question School Type
        if (rdoSchoolType.SelectedValue != "")
        {
            strQId = ((int)QuestionId.SchoolType).ToString();
            strTablevalues += strQId + strFSeparator + rdoSchoolType.SelectedValue + strFSeparator + rdoSchoolType.SelectedItem.Text + strQSeparator;
        }

        //for question School Name
        strQId = ((int)QuestionId.SchoolName).ToString();
        strTablevalues += strQId + strFSeparator + strFSeparator + txtSchoolName.Text + strQSeparator;

        //to remove the extra character at the end of the string, if any
        char[] chartoRemove = { Convert.ToChar(strQSeparator) };
        strTablevalues = strTablevalues.TrimEnd(chartoRemove);

        return strTablevalues;
    }

    void CusValComments_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            string strCamperAnswers, strUserId, strCamperUserId, strComments, strFJCID;
            Boolean bArgsValid, bPerform;
            strUserId = Master.UserId;
            strCamperUserId = Master.CamperUserId;
            strComments = txtComments.Text.Trim();
            strFJCID = hdnFJCIDStep2_2.Value;
            strCamperAnswers = ConstructCamperAnswers();
            CamperAppl.CamperAnswersServerValidation(strCamperAnswers, strComments, strFJCID, strUserId, (Convert.ToInt32(Redirection_Logic.PageNames.Step2_2)).ToString(), strCamperUserId, out bArgsValid, out bPerform);
            args.IsValid = bArgsValid;
            bPerformUpdate = bPerform;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }


}
