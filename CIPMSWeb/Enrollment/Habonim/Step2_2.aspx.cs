using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CIPMSBC;
using CIPMSBC.ApplicationQuestions;
using CIPMSBC.Eligibility;

public partial class Step2_Habonim_2 : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            //to fill the grades in the dropdown
            getGrades();
            //to get the FJCID which is stored in session
            if (Session["FJCID"] != null)
            {
                hdnFJCIDStep2_2.Value = (string)Session["FJCID"];
                getCamperAnswers();
            }

            int resultCampId = 0; //long resultFedID;
            if (Session["CampID"] != null)
            {
                Int32.TryParse(Session["CampID"].ToString(), out resultCampId);
            }
            string campID = resultCampId.ToString();
            string last3digits = campID.Substring(campID.Length - 3);

            if (Request.QueryString["camp"] == "tavor" || last3digits == "029")
            {
                trSibling2.Visible = true;
                trSibling3.Visible = true;
                lblGrade.Text = "4";
                lblSchoolType.Text = "5";
                lblSchoolName.Text = "6";
            }
            else
            {
                trSibling2.Visible = false;
                trSibling3.Visible = false;
                lblGrade.Text = "2";
                lblSchoolType.Text = "3";
                lblSchoolName.Text = "4";
            }
        }
        if (Session["CampID"] != null)
            if (Session["CampID"].ToString() == "1037" || Session["CampID"].ToString() == "1057" || Session["CampID"].ToString() == "4037" || Session["CampID"].ToString() == "4057")
                Label5.Text = " Will this be the camper's first time attending Jewish overnight summer camp for 12 days or more (if the camper attended for 12 days last summer, please answer yes)?";
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
                //Session["FJCID"] = null;
                //Session["ZIPCODE"] = null;
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
        string strRedirURL = Master.SaveandExitURL;
        if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_2.Value, Master.CamperUserId))
        {
            ProcessCamperAnswers();
        }

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
        if (Request.QueryString["camp"] == "tavor")
            Response.Redirect("SummaryTavor.aspx");
        else
            Response.Redirect("Summary.aspx");
    }

    void btnNext_Click(object sender, EventArgs e)
    {
        int iStatus;
        string strModifiedBy, strFJCID;

        if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_2.Value, Master.CamperUserId))
        {
            ProcessCamperAnswers();
        }
        bool isReadOnly = objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_2.Value, Master.CamperUserId);
        //Modified by id taken from the Master Id
        strModifiedBy = Master.UserId;
        strFJCID = hdnFJCIDStep2_2.Value;
        if (strFJCID != "" && strModifiedBy != "")
        {
            if (isReadOnly)
            {
                DataSet dsApp = CamperAppl.getCamperApplication(strFJCID);
                iStatus = Convert.ToInt16(dsApp.Tables[0].Rows[0]["Status"]);
            }
            else
            {
                EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.Habonim);
                objEligibility.checkEligibilityforStep2(strFJCID, out iStatus);
            }

            Session["STATUS"] = iStatus.ToString();
        }
        Session["FJCID"] = hdnFJCIDStep2_2.Value;
        if (Request.QueryString["camp"] == "tavor")
            Response.Redirect("Step2_3.aspx?camp=tavor");
        else
            Response.Redirect("Step2_3.aspx");
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

    //to get the camper answers from the database
    void getCamperAnswers()
    {
        string strFJCID = hdnFJCIDStep2_2.Value;

        DataSet dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "", "", "3,6,7,8,1032,1033,1034");

        foreach (DataRow dr in dsAnswers.Tables[0].Rows)
        {
            int qID = Convert.ToInt32(dr["QuestionId"]);

            if (qID == 3) // Is this your first time to attend a Non-profit Jewish overnight camp, for 3 weeks or longer:
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                if (dr["OptionID"].ToString() == "1")
                    rdoFirstTimerYes.Checked = true;
                else
                    rdoFirstTimerNo.Checked = true;
            }
            else if (qID == 6) // Grade
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                {
                    ddlGrade.SelectedValue = dr["Answer"].ToString();
                }
            }
            else if (qID == 7) //What kind of the school the camper go to
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                rdoSchoolType.SelectedValue = dr["OptionID"].ToString();
                if (dr["OptionID"].ToString() == "3")
                    txtSchoolName.Enabled = false;
            }
            else if (qID == 8) // Name of the school Camper attends:
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                {
                    txtSchoolName.Text = dr["Answer"].ToString();
                }
            }
            else if (qID == 1032) // Did the camper’s sibling  previously receive an incentive grant through the Chicago One Happy Camper Program?
            {
                if (!dr["OptionID"].Equals(DBNull.Value))
                    rdolistSiblingAttended.SelectedValue = dr["OptionID"].ToString();
            }
            else if (qID == 1033) // First Name of Sibling
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                    txtSiblingFirstName.Text = dr["Answer"].ToString();
            }
            else if (qID == 1034) // Last Name of Sibling
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                    txtSiblingLastName.Text = dr["Answer"].ToString();
            }
        }
      }

    private string ConstructCamperAnswers()
    {
        string strQID = "";
        string strTablevalues = "";

        string strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
        string strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();
        
        //for question 3
        strQID = hdnQ3Id.Value;
        strTablevalues += strQID + strFSeparator + Convert.ToString(rdoFirstTimerYes.Checked ? "1" : rdoFirstTimerNo.Checked ? "2" : "") + strFSeparator + strQSeparator;

        if (rdolistSiblingAttended.Visible)
        {
            //Did sibling attend before?
            strQID = ((int)Questions.Q1032SiblingAttended).ToString();
            strTablevalues += strQID + strFSeparator + rdolistSiblingAttended.SelectedValue + strFSeparator + strQSeparator;

            //Sibling First Name
            strQID = ((int)Questions.Q1033SiblingFirstName).ToString();
            strTablevalues += strQID + strFSeparator + strFSeparator + txtSiblingFirstName.Text + strQSeparator;

            //Sibling Last Name
            strQID = ((int)Questions.Q1034SiblingLastName).ToString();
            strTablevalues += strQID + strFSeparator + strFSeparator + txtSiblingLastName.Text + strQSeparator;
        }
        // Grade
        strQID = hdnQ4Id.Value;
        strTablevalues += strQID + strFSeparator + strFSeparator + ddlGrade.SelectedValue + strQSeparator;

        // SchoolType
        strQID = hdnQ5Id.Value;
        strTablevalues += strQID + strFSeparator + rdoSchoolType.SelectedValue + strFSeparator + strQSeparator;

        // SchoolName
        strQID = hdnQ6Id.Value;
        strTablevalues += strQID + strFSeparator + strFSeparator + txtSchoolName.Text.Trim();

        return strTablevalues;
    }

    void CusValComments_ServerValidate(object source, ServerValidateEventArgs args)
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


}
