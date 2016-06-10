using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CIPMSBC;
using CIPMSBC.Eligibility;

public partial class Step2_Adamah_3 : Page
{
    private CamperApplication CamperAppl;
    private General objGeneral;
    private Boolean bPerformUpdate;
    private RadioButton RadioButtonQ7Option1;
    private RadioButton RadioButtonQ7Option2;
    protected void Page_Init(object sender, EventArgs e)
    {
        if (ConfigurationManager.AppSettings["DisableOnSummaryPageFederations"].Split(',').Any(id => id == ((int)FederationEnum.Atlanta).ToString()))
            Response.Redirect("~/Enrollment/Step1_NL.aspx");

        btnChkEligibility.Click += new EventHandler(btnChkEligibility_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
    }

    void btnReturnAdmin_Click(object sender, EventArgs e)
    {
        string strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"].ToString();
        InsertCamperAnswers();
        Response.Redirect(strRedirURL);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        RadioButtonQ7Option1 = (RadioButton)RegControls1.FindControl("RadioButtonQ7Option1");
        RadioButtonQ7Option2 = (RadioButton)RegControls1.FindControl("RadioButtonQ7Option2"); 
        CamperAppl = new CamperApplication();
        objGeneral = new General();
        imgbtnCalStartDt.Attributes.Add("onclick", "return ShowCalendar('" + txtStartDate.ClientID + "');");
        imgbtnCalEndDt.Attributes.Add("onclick", "return ShowCalendar('" + txtEndDate.ClientID + "');");
        if (Session["STATUS"] != null)
        {
            if (Convert.ToInt32(Session["STATUS"].ToString()) == Convert.ToInt32(StatusInfo.SystemInEligible))
            {
                lblEligibility.Visible = false;
            }
            else
            {
                lblEligibility.Visible = true;
            }

        }
        if (!(Page.IsPostBack))
        {
            getCamps("0"); //to get all the camps and fill in
            //to get the FJCID which is stored in session
            if (Session["FJCID"] != null)
            {
                hdnFJCIDStep2_3.Value = (string)Session["FJCID"];
                getCamperAnswers();
            } 
        }
                      
        RadioButtonQ7Option1.Attributes.Add("onclick", "JavaScript:popupCall(this,'noCampRegistrationMsg','',true);");
        RadioButtonQ7Option2.Attributes.Add("onclick", "JavaScript:popupCall(this,'noCampRegistrationMsg','',true);");
            
        //to enable / disable the panel states based on the radio button selected
        SetPanelStates();
    }

    //page unload
    protected void Page_Unload(object sender, EventArgs e)
    {
        CamperAppl = null;
        objGeneral = null;
    }

    void btnSaveandExit_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        strRedirURL = Master.SaveandExitURL;
        if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_3.Value, Master.CamperUserId))
        {
            InsertCamperAnswers();
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
        if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_3.Value, Master.CamperUserId))
        {
            InsertCamperAnswers();
        }
        Session["FJCID"] = hdnFJCIDStep2_3.Value;
        Session["STATUS"] = null;
        Response.Redirect("Step2_2.aspx");
    }

    void btnChkEligibility_Click(object sender, EventArgs e)
    {
        string strStartDate = txtStartDate.Text.Trim();

        try
        {
            DateTime.Parse(strStartDate);
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Error in start session date.  The accepted format is mm/dd/yyyy.";
            lblMsg.Visible = true;
            return;
        }

        string strEndDate = txtEndDate.Text.Trim();

        try
        {
            DateTime.Parse(strEndDate);
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Error in end session date.  The accepted format is mm/dd/yyyy.";
            lblMsg.Visible = true;
            return;
        }

        string strModifiedBy = Master.UserId;
        int iCampId = Convert.ToInt32(ddlCamp.SelectedValue);
        string strFJCID = hdnFJCIDStep2_3.Value;
        string strComments = txtComments.Text.Trim();

        bool isReadOnly = objGeneral.IsApplicationReadOnly(strFJCID, Master.CamperUserId);
        if (!isReadOnly)
        {
            var startDate = Convert.ToDateTime(txtStartDate.Text);
            var endDate = Convert.ToDateTime(txtEndDate.Text);

            if (startDate > endDate)
            {
                lblMsg.Text = "Error: Start date must be earlier than end date.";
                return;
            }
            InsertCamperAnswers();
        }

        if (strFJCID != "" && strModifiedBy != "")
        {
            int iStatus;
            if (isReadOnly)
            {
                DataSet dsApp = CamperAppl.getCamperApplication(strFJCID);
                iStatus = Convert.ToInt32(dsApp.Tables[0].Rows[0]["Status"]);
            }
            else
            {
                //to update the camp value to the database (to be used for search functionality)
                CamperAppl.updateCamp(strFJCID, iCampId, strComments, Convert.ToInt32(Master.CamperUserId));

                //to check whether the camper is eligible 
                EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.Atlanta);
                objEligibility.checkEligibility(strFJCID, out iStatus);
            }

            var checkStatus = Convert.ToInt32(Session["STATUS"]);
            if (checkStatus == (int)StatusInfo.SystemInEligible)
                iStatus = checkStatus;
            else
                Session["STATUS"] = iStatus;

            if (iStatus == Convert.ToInt32(StatusInfo.SystemInEligible))
            {
                string strRedirURL;
                if (Master.UserId != Master.CamperUserId) //then the user is admin
                    strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"];
                else //the user is Camper
                    strRedirURL = "../ThankYou.aspx";
                //to update the status to the database
                if (!isReadOnly)
                {
                    CamperAppl.submitCamperApplication(strFJCID, strComments, Convert.ToInt32(strModifiedBy), iStatus);
                }
                Response.Redirect(strRedirURL, false);
            }
            else //if he/she is eligible
            {
                Session["FJCID"] = hdnFJCIDStep2_3.Value;
                CamperAppl.UpdateTimeInCampInApplication(strFJCID);                       
                Response.Redirect("../Step2_1.aspx");
            }
        }
    }


    //to insert the Camper Answers
    protected void InsertCamperAnswers()
    {
        string strFJCID, strComments;
        int RowsAffected;
        string strModifiedBy, strCamperAnswers;

        strFJCID = hdnFJCIDStep2_3.Value;

        //Modified by id taken from the common.master
        strModifiedBy = Master.UserId;

        //comments (used only by the Admin user)
        strComments = txtComments.Text.Trim();

        strCamperAnswers = ConstructCamperAnswers();

        if (strFJCID != "" && strCamperAnswers != "" && strModifiedBy != "" && bPerformUpdate)
            RowsAffected = CamperAppl.InsertCamperAnswers(strFJCID, strCamperAnswers, strModifiedBy, strComments);

    }

    //to get the camper answers from the database
    void getCamperAnswers()
    {
        string strFJCID;
        DataSet dsAnswers;
        int iCount;
        DataView dv;
        RadioButton rb;
        string strFilter;

        strFJCID = hdnFJCIDStep2_3.Value;
        if (!strFJCID.Equals(string.Empty))
        {
            dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "9", "12", "N");
            if (dsAnswers.Tables[0].Rows.Count > 0) //if there are records for the current FJCID
            {
                dv = dsAnswers.Tables[0].DefaultView;
                //to display answers for the QuestionId from 1001 - 1004 in Other info page
                for (int i = 9; i <= 12; i++)
                {
                    strFilter = "QuestionId = '" + i.ToString() + "'";
                    iCount = dsAnswers.Tables[0].Rows.Count;

                    switch (i)
                    {
                        case 9:  //assigning the answer for question 9
                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["OptionID"].Equals(DBNull.Value))
                                {
                                   
                                    rb = (RadioButton)RegControls1.FindControl("RadioButtonQ7Option" + dr["OptionID"].ToString());
                                    rb.Checked = true;
                                }
                            }
                            break;
                        case 10:// assigning the answer for question 10
                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["OptionID"].Equals(DBNull.Value))
                                {
                                    switch (dr["OptionID"].ToString())
                                    {
                                        case "2": //for camp
                                            ddlCamp.SelectedValue = dr["Answer"].Equals(DBNull.Value) ? "" : dr["Answer"].ToString();
                                            break;
                                    }
                                }
                            }
                            break;
                        case 11:// assigning the answer for question 11
                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["Answer"].Equals(DBNull.Value))
                                {
                                    //ddlCampSession.SelectedValue = dr["Answer"].ToString();
                                    txtCampSession.Text = dr["Answer"].ToString();
                                }
                            }
                            break;
                        case 12: // assigning the answer for question 12
                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["OptionID"].Equals(DBNull.Value))
                                {
                                    switch (dr["OptionID"].ToString())
                                    {
                                        case "1":  //for Start Date
                                            txtStartDate.Text = dr["Answer"].Equals(DBNull.Value) ? "" : dr["Answer"].ToString();
                                            break;
                                        case "2": //for End Date
                                            txtEndDate.Text = dr["Answer"].Equals(DBNull.Value) ? "" : dr["Answer"].ToString();
                                            break;
                                    }
                                }
                            }
                            break;
                    }
                }
            }
        } //end if for null check of fjcid
    }


    //to enable or disable the question panels based on the radio button selected
    protected void SetPanelStates()
    {
        if (RadioButtonQ7Option1.Checked == true)
        {
            PnlQ9.Enabled = false;
            txtCampSession.Text = "";
            PnlQ10.Enabled = false;
            txtStartDate.Text = "";
            txtEndDate.Text = "";
        }
        else
        {
            PnlQ9.Enabled = true;
            PnlQ10.Enabled = true;
        }
    }

    //to get the camps based on the state selected
    //if state is not selected then all the camps are populated
    private void getCamps(string StateId)
    {
        DataSet dsCamps = objGeneral.get_AllCamps(Master.CampYear);
        
        ddlCamp.DataSource = dsCamps;
        ddlCamp.DataTextField = "Camp";
        ddlCamp.DataValueField = "ID";
        ddlCamp.DataBind();
    }

    private string ConstructCamperAnswers()
    {
        string strQuestionId = "";
        string strTablevalues = "";
        string strFSeparator;
        string strQSeparator;
        string strRadioOption;
        string strCamp, strCampSession, strStartDate, strEndDate; //-1 for Camper (User id will be passed for Admin user)

        //to get the Question separator from Web.config
        strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
        //to get the Field separator from Web.config
        strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();

        //for question 7
       
        strRadioOption = Convert.ToString(RadioButtonQ7Option1.Checked ? "1" : RadioButtonQ7Option2.Checked ? "2" : "");
        strCamp = ddlCamp.SelectedValue;
       
        strCampSession = txtCampSession.Text.Trim();
        strStartDate = txtStartDate.Text.Trim();
        strEndDate = txtEndDate.Text.Trim();

        strQuestionId = hdnQ7Id.Value;
        strTablevalues += strQuestionId + strFSeparator + strRadioOption + strFSeparator + strQSeparator;

        //for question 8
        strQuestionId = hdnQ8Id.Value;
        //value - 1 for state and 2 for Camp
        strTablevalues += strQuestionId + strFSeparator + "2" + strFSeparator + strCamp + strQSeparator;

        //for question 9
        strQuestionId = hdnQ9Id.Value;
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strCampSession + strQSeparator;

        //for question 10
        strQuestionId = hdnQ10Id.Value;
        //value - 1 for start date and 2 for end date
        strTablevalues += strQuestionId + strFSeparator + "1" + strFSeparator + strStartDate + strQSeparator;
        strTablevalues += strQuestionId + strFSeparator + "2" + strFSeparator + strEndDate + strQSeparator;

        //to remove the extra character at the end of the string, if any
        char[] chartoRemove = { Convert.ToChar(strQSeparator) };
        strTablevalues = strTablevalues.TrimEnd(chartoRemove);

        return strTablevalues;
    }

    void CusValComments_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string strCamperAnswers, strUserId, strCamperUserId, strComments, strFJCID;
        Boolean bArgsValid, bPerform;
        strUserId = Master.UserId;
        strCamperUserId = Master.CamperUserId;
        strComments = txtComments.Text.Trim();
        strFJCID = hdnFJCIDStep2_3.Value;
        strCamperAnswers = ConstructCamperAnswers();
        CamperAppl.CamperAnswersServerValidation(strCamperAnswers, strComments, strFJCID, strUserId,(Convert.ToInt32(Redirection_Logic.PageNames.Step2_3)).ToString(),  strCamperUserId, out bArgsValid, out bPerform);
        args.IsValid = bArgsValid;
        bPerformUpdate = bPerform;
    }

    protected void imgbtnCalStartDt_Click(object sender, ImageClickEventArgs e)
    {
        int iDisplayYear = 0;
        int iDisplayMonth = 6;//June
        pnlCalStartDt.Style.Add("position", "absolute");
        pnlCalStartDt.Style.Add("top", "420px");
        pnlCalStartDt.Style.Add("left", "400px");
        pnlCalStartDt.Visible = true;

        if (DateTime.Now.Month > iDisplayMonth) //if it is July
            iDisplayYear = DateTime.Now.Year + 1;
        else
            iDisplayYear = DateTime.Now.Year;

        calStartDt.VisibleDate = new DateTime(iDisplayYear, iDisplayMonth, 1);
    }

    protected void imgbtnCalEndDt_Click(object sender, ImageClickEventArgs e)
    {
        pnlCalEndDt.Style.Add("position", "absolute");
        pnlCalEndDt.Style.Add("top", "420px");
        pnlCalEndDt.Style.Add("left", "610px");
        pnlCalEndDt.Visible = true;
    }

    protected void calStartDt_SelectionChanged(object sender, EventArgs e)
    {
        txtStartDate.Text = calStartDt.SelectedDate.ToString("MM/dd/yyyy");
        pnlCalStartDt.Visible = false;
    }

    protected void calEndDt_SelectionChanged(object sender, EventArgs e)
    {
        txtEndDate.Text = calEndDt.SelectedDate.ToString("MM/dd/yyyy");
        pnlCalEndDt.Visible = false;
    }
}
