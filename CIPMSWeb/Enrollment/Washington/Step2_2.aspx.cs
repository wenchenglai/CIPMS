using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using CIPMSBC;
using CIPMSBC.ApplicationQuestions;
using CIPMSBC.Eligibility;



public partial class Step2_Washington_2 : System.Web.UI.Page
{

    private CamperApplication CamperAppl;
    private General objGeneral;
    private Boolean bPerformUpdate;

    protected void Page_Init(object sender, EventArgs e)
    {
        CheckForRedirect();

        btnNext.Click += new EventHandler(btnNext_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CamperAppl = new CamperApplication();
            objGeneral = new General();
            if (!Page.IsPostBack)
            {
                //to fill the grades in the dropdown
                getGrades();
                // to fill the Synagogues names in the dropdown.
                getSynagogues();
                getJCCList(Master.CampYear);
                //to get the FJCID which is stored in session
                if (Session["FJCID"] != null)
                {
                    hdnFJCID.Value = (string)Session["FJCID"]; ;
                    PopulateAnswers();
                }
            }
            if (chkSynagogue.Checked == false) ddlSynagogue.Enabled = lblOtherSynogogueQues.Enabled = txtOtherSynagogue.Enabled = false;
            if (chkJCC.Checked == false) ddlJCC.Enabled = lblJCC.Enabled = txtJCC.Enabled = false;
            if (ddlJCC.Visible == false) tdJCCOther.Attributes.Remove("align");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    void CheckForRedirect()
    {
        if (PageUtility.RedirectToNL((int)FederationEnum.WashingtonDC, Session["isGrantAvailable"] != null, Master.isAdminUser))
        {
            Response.Redirect("~/NLIntermediate.aspx");
        }
    }

    void btnNext_Click(object sender, EventArgs e)
    {
        CheckForRedirect();

        bool isReadOnly = objGeneral.IsApplicationReadOnly(hdnFJCID.Value, Master.CamperUserId);
        if (!isReadOnly)
        {
            ProcessCamperAnswers();
        }

        //Modified by id taken from the Master Id
        string strModifiedBy = Master.UserId;
        string strFJCID = hdnFJCID.Value;
        int iStatus = Convert.ToInt32(StatusInfo.SystemInEligible);
        if (strFJCID != "" && strModifiedBy != "")
        {
            if (isReadOnly)
            {
                DataSet dsApp = CamperAppl.getCamperApplication(strFJCID);
                iStatus = Convert.ToInt32(dsApp.Tables[0].Rows[0]["Status"]);
            }
            else
            {
                var objEligibility = EligibilityFactory.GetEligibility(FederationEnum.WashingtonDC);
                EligibilityBase.EligibilityResult result = objEligibility.checkEligibilityforStep2(strFJCID, out iStatus, SessionSpecialCode.GetPJLotterySpecialCode());

                if (result.SchoolType == StatusInfo.EligiblePJLottery)
                    iStatus = (int)StatusInfo.EligiblePJLottery;
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
        Session["FJCID"] = hdnFJCID.Value;

        var status = (StatusInfo)iStatus;
        Response.Redirect(AppRouteManager.GetNextRouteBasedOnStatus(status, HttpContext.Current.Request.Url.AbsolutePath));
    }

    void btnReturnAdmin_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        try
        {
            if (Page.IsValid)
            {
                strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"].ToString();
                ProcessCamperAnswers();
                Response.Redirect(strRedirURL);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    void btnSaveandExit_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        try
        {
            if (Page.IsValid)
            {
                //strRedirURL = ConfigurationManager.AppSettings["SaveExitRedirURL"].ToString();
                strRedirURL = Master.SaveandExitURL;
                if (!objGeneral.IsApplicationReadOnly(hdnFJCID.Value, Master.CamperUserId))
                {
                    ProcessCamperAnswers();
                }
                // Session.Abandon();
                // Response.Redirect(strRedirURL);

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
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    void btnPrevious_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                if (!objGeneral.IsApplicationReadOnly(hdnFJCID.Value, Master.CamperUserId))
                {
                    ProcessCamperAnswers();
                }
                Session["FJCID"] = hdnFJCID.Value;
                //Response.Redirect("../Step2_1.aspx");
                Response.Redirect("Summary.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    private void ProcessCamperAnswers()
    {
        string strComments, strFJCID, strModifiedBy;
        int iGrade, iResult;
        int iRowsAffected;
        string strGrade;

        InsertCamperAnswers();

        ////to update the grade to the database - to be used by the search

        strComments = "";
        strFJCID = hdnFJCID.Value;
        strModifiedBy = Master.UserId;
        if (strFJCID != "" & strModifiedBy != "" && bPerformUpdate)
        {
            strGrade = ddlGrade.SelectedValue;
            int.TryParse(strGrade, out iResult);
            if (iResult == 0 || strGrade.Equals(string.Empty))
                iGrade = 0;
            else
                iGrade = iResult;

            iRowsAffected = CamperAppl.updateGrade(strFJCID, iGrade, strComments, Convert.ToInt32(strModifiedBy));
        }
    }

    protected void InsertCamperAnswers()
    {
        string strFJCID, strModifiedBy, strComments, strCamperAnswers;
        int RowsAffected;

        //to get the Comments text (used by the Admin user)
        strComments = txtComments.Text.Trim();

        strFJCID = hdnFJCID.Value;
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
        DataSet dsAnswers = CamperAppl.getCamperAnswers(hdnFJCID.Value, "", "", "3,6,7,8,30,31,1016,1017,1044,1045,1063");

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
            else if (qID == QuestionId.Q1016_AttendedDayCamp)
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                if (dr["OptionID"].ToString() == "1")
                {
                    rboYesDayCamp.Checked = true;
                }
                else
                {
                    rboNoDayCamp.Checked = true;
                }
            }
            else if (qID == QuestionId.Q1017_DayCampName) // Name of the day school
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                {
                    txtDayCamp.Text = dr["Answer"].ToString();
                }
            }
            else if (qID == QuestionId.Q30_ReferredBySynagogueOrJCC) //Were you referred to this application through a synagogue or JCC liaison?
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                var value = (SynagogueJCCOther)Convert.ToInt32(dr["OptionID"]);
                switch (value)
                {
                    case SynagogueJCCOther.Synagogue:
                        chkSynagogue.Checked = true;
                        break;

                    case SynagogueJCCOther.JCC:
                        chkJCC.Checked = true;
                        break;

                    case SynagogueJCCOther.Other:
                        chkNo.Checked = true;
                        break;

                    default:
                        chkNo.Checked = false;
                        break;
                }
            }
            else if (qID == QuestionId.Q31_SelectYourSynagogueOrJCC) // Please select your synagogue or JCC
            {
                if (dr["OptionID"].Equals(DBNull.Value) || dr["Answer"].Equals(DBNull.Value))
                    continue;

                if (dr["OptionID"].ToString() == "1")
                {
                    chkSynagogue.Checked = true;
                    ddlSynagogue.SelectedValue = dr["Answer"].ToString();
                    if (ddlSynagogue.SelectedItem.Text != "Other (please specify)")
                        txtOtherSynagogue.Enabled = false;
                }
                else if (dr["OptionID"].ToString() == "2")
                {
                    txtOtherSynagogue.Text = dr["Answer"].ToString();
                }
                else if (dr["OptionID"].ToString().Equals("3"))
                {
                    chkJCC.Checked = true;
                    ddlJCC.SelectedValue = dr["Answer"].ToString();
                    if (ddlJCC.SelectedItem.Text != "Other (please specify)")
                        ddlJCC.Enabled = false;
                }
                else if (dr["OptionID"].ToString().Equals("4"))
                {
                    txtJCC.Text = dr["Answer"].ToString();
                }
            }
        }
    }

    private string ConstructCamperAnswers()
    {
        var strQId = "";
        string strQuestionId = "";
        string strTablevalues = "";

        //to get the Question separator from Web.config
        var strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"];
        //to get the Field separator from Web.config
        var strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"];

        //for question FirstTimerOrNot
        strQId = ((int)QuestionId.FirstTime).ToString();
        strTablevalues += strQId + strFSeparator + Convert.ToString(rdoFirstTimerYes.Checked ? "1" : rdoFirstTimerNo.Checked ? "2" : "") + strFSeparator + strQSeparator;

        if (chkNo.Checked)
        {
            strQuestionId = "30";
            strTablevalues += strQuestionId + strFSeparator + chkNo.Value + strFSeparator + chkNo.Value + strQSeparator;
            strQuestionId = "31";
            strTablevalues += strQuestionId + strFSeparator + "" + strFSeparator + "" + strQSeparator;
        }
        else
        {
            if (chkSynagogue.Checked)
            {
                strQuestionId = "30";
                strTablevalues += strQuestionId + strFSeparator + chkSynagogue.Value + strFSeparator + chkSynagogue.Value + strQSeparator;
            }
            if (chkJCC.Checked)
            {
                strQuestionId = "30";
                strTablevalues += strQuestionId + strFSeparator + chkJCC.Value + strFSeparator + chkJCC.Value + strQSeparator;
            }

            //This redundant condition is used to insert records in questionid sequence
            strQuestionId = "31";
            if (chkSynagogue.Checked)
            {
                if (ddlSynagogue.SelectedValue != "0")
                {

                    strTablevalues += strQuestionId + strFSeparator + "1" + strFSeparator + ddlSynagogue.SelectedValue + strQSeparator;
                    if (txtOtherSynagogue.Text.Trim() != String.Empty)
                        strTablevalues += strQuestionId + strFSeparator + "2" + strFSeparator + txtOtherSynagogue.Text.Trim() + strQSeparator;
                    if (txtOtherSynagogue.Text.Trim() != String.Empty)
                    {
                        strTablevalues += hdnQ2Id.Value + strFSeparator + strFSeparator + txtOtherSynagogue.Text.Trim() + strQSeparator;
                    }
                    else
                    {
                        strTablevalues += hdnQ2Id.Value + strFSeparator + strFSeparator + ddlSynagogue.SelectedItem.Text + strQSeparator;
                    }
                }
            }
            else
            {
                strTablevalues += strQuestionId + strFSeparator + "1" + strFSeparator + "" + strQSeparator;
                strTablevalues += strQuestionId + strFSeparator + "2" + strFSeparator + "" + strQSeparator;
            }
            if (chkJCC.Checked)
            {
                if (ddlJCC.Items.Count > 0)
                {
                    if (ddlJCC.SelectedValue != "0")
                    {
                        strTablevalues += strQuestionId + strFSeparator + "3" + strFSeparator + ddlJCC.SelectedValue + strQSeparator;
                        if (txtJCC.Text.Trim() != String.Empty)
                            strTablevalues += strQuestionId + strFSeparator + "4" + strFSeparator + txtJCC.Text.Trim() + strQSeparator;
                    }
                }
                else
                    strTablevalues += strQuestionId + strFSeparator + "4" + strFSeparator + txtJCC.Text.Trim() + strQSeparator;
            }
            else
            {
                strTablevalues += strQuestionId + strFSeparator + "3" + strFSeparator + "" + strQSeparator;
                strTablevalues += strQuestionId + strFSeparator + "4" + strFSeparator + "" + strQSeparator;
            }
        }

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

        //for question DayCamp
        strQuestionId = hdnQ12Id.Value;
        strTablevalues += strQuestionId + strFSeparator + Convert.ToString(rboYesDayCamp.Checked ? "1" : rboNoDayCamp.Checked ? "2" : "") + strFSeparator + strQSeparator;

        //for question DayCamp
        strQuestionId = hdnQ13Id.Value;
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + txtDayCamp.Text.Trim() + strQSeparator;

        //to remove the extra character at the end of the string, if any
        char[] chartoRemove = { Convert.ToChar(strQSeparator) };
        strTablevalues = strTablevalues.TrimEnd(chartoRemove);

        return strTablevalues;
    }    

    //to validate the comments field for Admin
    void CusValComments_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            string strCamperAnswers, strUserId, strCamperUserId, strComments, strFJCID;
            Boolean bArgsValid, bPerform;
            strUserId = Master.UserId;
            strCamperUserId = Master.CamperUserId;
            strComments = txtComments.Text.Trim();
            strFJCID = hdnFJCID.Value;
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

    //to fill the grade values to the grade dropdown
    private void getSynagogues()
    {
        DataSet dsSynagogue;
        DataView dvSynagogue = new DataView();
        int FedID;
        FedID = Convert.ToInt32(Session["FEDID"].ToString());
        dsSynagogue = objGeneral.GetSynagogueListByFederation(FedID, Master.CampYear);
        //dvSynagogue = dsSynagogue.Tables[0].DefaultView;
        //dvSynagogue.Sort = "Name ASC";
        ddlSynagogue.DataSource = dsSynagogue.Tables[0];
        ddlSynagogue.DataTextField = "Name";
        ddlSynagogue.DataValueField = "ID";
        ddlSynagogue.DataBind();
        ddlSynagogue.Items.Insert(0, new ListItem("-- Select --", "0"));
        ListItem otherListItem = new ListItem();
        foreach (ListItem item in ddlSynagogue.Items)
        {
            item.Attributes.Add("title", item.Text);
            if (item.Text.ToLower().Contains("other (please specify)") && ddlSynagogue.Items.IndexOf(item) < ddlSynagogue.Items.Count)
            {
                otherListItem = item;
            }
        }
        if (otherListItem != null && otherListItem.Text != string.Empty)
        {
            ddlSynagogue.Items.Remove(otherListItem);
            ddlSynagogue.Items.Insert(ddlSynagogue.Items.Count, otherListItem);
        }
    }

    private void getJCCList(string CampYear)
    {
        DataSet dsJCC;
        DataView dvJCC = new DataView();
        int FedID;
        FedID = Convert.ToInt32(Session["FEDID"].ToString());
        dsJCC = objGeneral.GetJCCListByFederation(FedID, CampYear);
        if (dsJCC.Tables[0].Rows.Count > 0)
        {
            //dvJCC = dsJCC.Tables[0].DefaultView;
            //dvJCC.Sort = "ID ASC";
            ddlJCC.DataSource = dsJCC.Tables[0];
            ddlJCC.DataTextField = "Name";
            ddlJCC.DataValueField = "ID";
            ddlJCC.DataBind();
            ddlJCC.Items.Insert(0, new ListItem("-- Select --", "0"));
            ListItem otherListItem = new ListItem();
            foreach (ListItem item in ddlJCC.Items)
            {
                item.Attributes.Add("title", item.Text);
                if (item.Text.ToLower().Contains("other (please specify)") && ddlJCC.Items.IndexOf(item) < ddlJCC.Items.Count)
                {
                    otherListItem = item;
                }
            }
            if (otherListItem != null && otherListItem.Text != string.Empty)
            {
                ddlJCC.Items.Remove(otherListItem);
                ddlJCC.Items.Insert(ddlJCC.Items.Count, otherListItem);
            }
            ddlJCC.SelectedValue = "0";
            tdDDLJCC.Visible = true;
            lblJCC.Visible = true;
            txtJCC.Width = Unit.Pixel(160);
            txtJCC.Enabled = true;
        }
        else
        {
            tdDDLJCC.Visible = false;
            lblJCC.Visible = false;
            txtJCC.Width = Unit.Pixel(240); ;
            txtJCC.Enabled = true;
            tdJCCOther.Attributes.Remove("align");
        }
    }
}
