using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CIPMSBC;
using CIPMSBC.Eligibility;

public partial class Step2_LACIP_3 : Page
{
    //private UserDetails UserInfo;
    private CamperApplication CamperAppl;
    private General objGeneral;
    private Boolean bPerformUpdate;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (ConfigurationManager.AppSettings["DisableOnSummaryPageFederations"].Split(',').Any(id => id == ((int)FederationEnum.LACIP).ToString()))
            Response.Redirect("~/NLIntermediate.aspx");

        btnChkEligibility.Click += new EventHandler(btnChkEligibility_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);

        //ddlCamp.SelectedIndexChanged += new EventHandler(ddlCamp_SelectedIndexChanged);
        //ddlCampSession.SelectedIndexChanged += new EventHandler(ddlCampSession_SelectedIndexChanged);
    }

    void btnReturnAdmin_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        try
        {
            if (Page.IsValid)
            {
                lblMsg.Text = "";
                strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"].ToString();
                InsertCamperAnswers();
                //Session["FJCID"] = null;
                //Session["ZIPCODE"] = null;
                //Session["STATUS"] = null;
                Response.Redirect(strRedirURL, false);
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
                lblMsg.Text = "";
                //strRedirURL = ConfigurationManager.AppSettings["SaveExitRedirURL"].ToString();
                strRedirURL = Master.SaveandExitURL;
                if (!objGeneral.IsApplicationReadOnly(hdnFJCID.Value, Master.CamperUserId))
                {
                    InsertCamperAnswers();
                }
                //Session["FJCID"] = null;
                //Session["ZIPCODE"] = null;
                //Session["STATUS"] = null;
               // Session.Abandon();
                //Response.Redirect(strRedirURL, false);
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
                lblMsg.Text = "";
                if (!objGeneral.IsApplicationReadOnly(hdnFJCID.Value, Master.CamperUserId))
                {
                    InsertCamperAnswers();
                }
                Session["FJCID"] = hdnFJCID.Value;
                Session["STATUS"] = null;
                Response.Redirect("Step2_2.aspx", false);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    void btnChkEligibility_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        if (ddlCamp.SelectedValue == "-1")
        {
            Response.Redirect("../Step1_NL.aspx");
        }

        int iStatus, iCampId;
        string strComments, strFJCID, strModifiedBy;
        
        if (Page.IsValid)
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

            bool isReadOnly = objGeneral.IsApplicationReadOnly(hdnFJCID.Value, Master.CamperUserId);
            if (!isReadOnly)
            {
                DateTime startDate, endDate;
                try
                {
                    startDate = Convert.ToDateTime(txtStartDate.Text);
                    endDate = Convert.ToDateTime(txtEndDate.Text);
                }
                catch (Exception)
                {
                    lblMsg.Text = "Error: The dates are wrong format.";
                    return;
                }

                if (startDate > endDate)
                {
                    lblMsg.Text = "Error: Start date must be earlier than end date.";
                    return;
                }

                txtStartDate.Text = startDate.ToShortDateString();
                txtEndDate.Text = endDate.ToShortDateString();

                InsertCamperAnswers();
            }
            if (RadioBtnQ7.Items[1].Selected)
            {
                lblMsgCA.Visible = true;
                return;
            }
            else
                lblMsgCA.Visible = false;
            iCampId = Convert.ToInt32(ddlCamp.SelectedValue);

            //to get the comments (used only by the Admin user);
            strComments = txtComments.Text.Trim();

            strFJCID = hdnFJCID.Value;
            strModifiedBy = Master.UserId;

            if (strFJCID != "" & strModifiedBy != "")
            {
                if (isReadOnly)
                {
                    DataSet dsApp = CamperAppl.getCamperApplication(strFJCID);
                    iStatus = Convert.ToInt32(dsApp.Tables[0].Rows[0]["Status"]);
                }
                else
                {
                    //to update the camp value to the database (to be used for search functionality)
                    CamperAppl.updateCamp(strFJCID, iCampId, strComments, Convert.ToInt32(Master.CamperUserId));
                    var objEligibility = EligibilityFactory.GetEligibility(FederationEnum.LACIP); 
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
                    Session["FJCID"] = strFJCID;
                    Response.Redirect("../Step2_1.aspx");
                }
            }
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CamperAppl = new CamperApplication();
            objGeneral = new General();

            imgbtnCalStartDt.Attributes.Add("onclick", "return ShowCalendar('" + txtStartDate.ClientID + "');");
            imgbtnCalEndDt.Attributes.Add("onclick", "return ShowCalendar('" + txtEndDate.ClientID + "');");

            //Session["FJCID"] = "200810130000";
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
                getCamps(); //to get the camps for the fed id
                //getCampSession("0");
                //to get the FJCID which is stored in session
                if (Session["FJCID"] != null)
                {
                    hdnFJCID.Value = (string)Session["FJCID"];
                    getCamperAnswers();
                    //if (RadioBtnQ7.SelectedValue == "1")
                    //{
                    //    btnChkEligibility.Enabled = false;
                    //}
                }
            }
            if (Session["FJCID"] != null)
            {
                int timeInCamp = new CamperApplication().getTimeInCamp(Session["FJCID"].ToString());
                if (timeInCamp == 1)
                {
                    //pNote.InnerHtml = "<font color='red'><b>In order to be eligible</b></font> for the incentive grant, the camper must attend camp for at least 12 consecutive days.";
                }
            }
            foreach (ListItem li in RadioBtnQ7.Items)
            {
                li.Attributes.Add("onclick", "JavaScript:popupCall(this,'noCampRegistrationMsg');");
                //if (li.Value == "1") li.Attributes.Add("onclick", "JavaScript:popupCall('noCampRegistrationMsg');");
                //else if (li.Value == "2") li.Attributes.Add("onClick", "JavaScript:disablePopup();");
            }
            //to enable / disable the panel states based on the radio button selected
            SetPanelStates();
            lblMsgCA.Visible = false;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    //page unload
    protected void Page_Unload(object sender, EventArgs e)
    {
        objGeneral = null;
        CamperAppl = null;
    }

    //to insert the Camper Answers
    protected void InsertCamperAnswers()
    {
        string strComments, strFJCID, strModifiedBy, strCamperAnswers;
        int RowsAffected;

        strFJCID = hdnFJCID.Value;
        strModifiedBy = Master.UserId;
        //to get the comments (used only by the Admin user)
        strComments = txtComments.Text.Trim();

        strCamperAnswers = ConstructCamperAnswers();

        if (strFJCID != "" && strCamperAnswers != "" && strModifiedBy != "" && bPerformUpdate)
            RowsAffected = CamperAppl.InsertCamperAnswers(strFJCID, strCamperAnswers, strModifiedBy, strComments);
        if (strFJCID != "" && strModifiedBy != "")
            CamperAppl.SetAcknowledgeFlag(strFJCID, chkAcknowledgement.Checked);
    }

    //to get the camper answers from the database
    void getCamperAnswers()
    {
        DataSet dsAnswers, dsAcknowledge;
        int iCount;
        DataView dv;
        RadioButtonList rb;
        TextBox tb;
        DropDownList ddl;
        HiddenField hdnval;
        DataRow dr1;
        DataRow[] drows;
        string strFilter, strFJCID, strModifiedBy;
        strFJCID = hdnFJCID.Value;
        strModifiedBy = Master.UserId;
        if (!strFJCID.Equals(string.Empty))
        {
            dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "9", "12", "N");
            //to set the acknowledgement flag by getting the value from the database
            dsAcknowledge = CamperAppl.getCamperApplication(strFJCID);
            if (dsAcknowledge.Tables[0].Rows.Count > 0)
            {
                if (!dsAcknowledge.Tables[0].Rows[0]["confirm4"].Equals(DBNull.Value))
                    chkAcknowledgement.Checked = (Boolean)dsAcknowledge.Tables[0].Rows[0]["confirm4"];
            }
            //end of setting the acknowledgement flag
            if (dsAnswers.Tables[0].Rows.Count > 0) //if there are records for the current FJCID
            {
                dv = dsAnswers.Tables[0].DefaultView;
                //to display answers for the QuestionId from 6 - 9 
                for (int i = 7; i <= 10; i++)
                {
                    //to get the QuestionId for the Questions
                    hdnval = (HiddenField)PnlHidden.FindControl("hdnQ" + i.ToString() + "Id");
                    strFilter = "QuestionId = '" + hdnval.Value + "'";
                    iCount = dsAnswers.Tables[0].Rows.Count;
                    tb = null;
                    rb = null;
                    ddl = null;

                    switch (i)
                    {
                        case 7:  //assigning the answer for question 7
                            rb = RadioBtnQ7;
                            goto default;
                        case 8:// assigning the answer for question 8
                            ddl = ddlCamp;
                            goto default;
                        case 9:// assigning the answer for question 9
                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["Answer"].Equals(DBNull.Value))
                                {
                                    txtCampSession.Text = dr["Answer"].ToString();
                                }

                            }
                            break;
                            //ddl = ddlCampSession;
                            //getCampSession(ddlCamp.SelectedValue);
                            //goto default;
                        case 10: // assigning the answer for question 10
                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["OptionID"].Equals(DBNull.Value))
                                {
                                    switch (dr["OptionID"].ToString())
                                    {
                                        case "1":  //for Start Date
                                            //lblStartDate.Text = dr["Answer"].Equals(DBNull.Value) ? "" : dr["Answer"].ToString();
                                            txtStartDate.Text = dr["Answer"].Equals(DBNull.Value) ? "" : dr["Answer"].ToString();
                                            break;
                                        case "2": //for End Date
                                            //lblEndDate.Text = dr["Answer"].Equals(DBNull.Value) ? "" : dr["Answer"].ToString();
                                            txtEndDate.Text = dr["Answer"].Equals(DBNull.Value) ? "" : dr["Answer"].ToString();
                                            break;
                                    }
                                }
                                /*if (!dr["OptionID"].Equals(DBNull.Value))
                                {
                                    switch (dr["OptionID"].ToString())
                                    {
                                        case "1":  //for Start Date
                                            //txtStartDate.Text = dr["Answer"].Equals(DBNull.Value) ? "" : dr["Answer"].ToString();
                                            break;
                                        case "2": //for End Date
                                            //txtEndDate.Text = dr["Answer"].Equals(DBNull.Value) ? "" : dr["Answer"].ToString();
                                            break;
                                    }
                                }*/
                            }
                            break;
                        default:  //to implement the common logic
                            drows = dv.Table.Select(strFilter);
                            if (drows.Length > 0) //if there are rows for the filter
                            {
                                dr1 = (DataRow)drows.GetValue(0);
                                if (rb != null)
                                {
                                    if (!dr1["OptionID"].Equals(DBNull.Value))
                                        rb.SelectedValue = dr1["OptionID"].ToString();
                                }
                                if (ddl != null)
                                {
                                    if (!dr1["OptionID"].Equals(DBNull.Value))
                                        ddl.SelectedValue = dr1["OptionID"].ToString();
                                }
                                /*if (tb != null)
                                {
                                    if (!dr1["Answer"].Equals(DBNull.Value))
                                        tb.Text = dr1["Answer"].ToString();
                                }*/
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
        if (RadioBtnQ7.SelectedValue == "1")  //if first option is selected for Q7
        {
            PnlQ7.Enabled = false;
            ddlCamp.SelectedIndex = 0;
            PnlQ8.Enabled = false;
            //ddlCampSession.SelectedIndex = 0;
            //PnlQ9.Enabled = false;
            //lblStartDate.Text = "";
            //lblEndDate.Text = "";

            txtCampSession.Text = "";
            PnlQ10.Enabled = false;
            txtStartDate.Text = "";
            txtEndDate.Text = "";
        }
        else
        {
           
            PnlQ10.Enabled = true;
            PnlQ7.Enabled = true;
            PnlQ8.Enabled = true;
        }
    }

    //to get the camps based on the state selected
    //if state is not selected then all the camps are populated
    private void getCamps()
    {
        DataSet dsCamps;
        string strFedId;

        //to get the LA CIP fed id from the web.config
        strFedId = ConfigurationManager.AppSettings["LACIP"];

        dsCamps = objGeneral.GetFedCamps(Convert.ToInt32(strFedId), Master.CampYear);

        ddlCamp.DataSource = dsCamps;
        ddlCamp.DataTextField = "Camp";
        ddlCamp.DataValueField = "CampID";
        ddlCamp.DataBind();
        ddlCamp.Items.Insert(0, new ListItem("-- Select --", "0"));
        ddlCamp.Items.Insert(ddlCamp.Items.Count, new ListItem("Other", "-1"));
    }

    private string ConstructCamperAnswers()
    {
        string strQuestionId = "";
        string strTablevalues = "";
        string strFSeparator;
        string strQSeparator;
        string strRadioOption;
        string strCamp, strCampSession, strStartDate, strEndDate;

        strStartDate = strEndDate = string.Empty;

        //to get the Question separator from Web.config
        strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
        //to get the Field separator from Web.config
        strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();

        //for question 7
        strQuestionId = hdnQ7Id.Value;
        strRadioOption = RadioBtnQ7.SelectedValue;

        strCamp = ddlCamp.SelectedValue;
        strCampSession = string.Empty;// txtCampSession.Text.Trim();
        //strStartDate = txtStartDate.Text.Trim();
        //strEndDate = txtEndDate.Text.Trim();

        strCamp = ddlCamp.SelectedValue;
        //strCampSession = ddlCampSession.SelectedValue;
        //strStartDate = lblStartDate.Text.Trim();
        //strEndDate = lblEndDate.Text.Trim();

        strCampSession = txtCampSession.Text.Trim();
        strStartDate = txtStartDate.Text.Trim();
        strEndDate = txtEndDate.Text.Trim();

        strTablevalues += strQuestionId + strFSeparator + strRadioOption + strFSeparator + strQSeparator;

        //for question 8
        strQuestionId = hdnQ8Id.Value;
        //for Camp
        strTablevalues += strQuestionId + strFSeparator + strCamp + strFSeparator + strQSeparator;

        //for question 9
        strQuestionId = hdnQ9Id.Value;
        //strTablevalues += strQuestionId + strFSeparator + strCampSession + strFSeparator + strQSeparator;
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strCampSession + strQSeparator;

        //for question 10
        strQuestionId = hdnQ10Id.Value;
        //value -1 for start date and 2 for end date
        strTablevalues += strQuestionId + strFSeparator + "1" + strFSeparator + strStartDate + strQSeparator;
        strTablevalues += strQuestionId + strFSeparator + "2" + strFSeparator + strEndDate + strQSeparator;

        //to remove the extra character at the end of the string, if any
        char[] chartoRemove = { Convert.ToChar(strQSeparator) };
        strTablevalues = strTablevalues.TrimEnd(chartoRemove);

        return strTablevalues;
    }

    //to validate the comments text box for the Admin user
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

    //to get the camp session based on the camp selected
    //private void getCampSession(string CampId)
    //{
    //    DataSet dsCampSession;

    //    if (!CampId.Equals("0"))
    //    {
    //        dsCampSession = objGeneral.GetCampSessionsForCamp(Convert.ToInt32(CampId));

    //        ddlCampSession.DataSource = dsCampSession;
    //        ddlCampSession.DataTextField = "Name";
    //        ddlCampSession.DataValueField = "ID";
    //        ddlCampSession.DataBind();
    //    }
    //    else
    //        ddlCampSession.Items.Clear();

    //    ddlCampSession.Items.Insert(0, new ListItem("-- Select --", "0"));
    //}

    //protected void ddlCamp_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        getCampSession(ddlCamp.SelectedValue);
    //        lblStartDate.Text = "";
    //        lblEndDate.Text = "";

    //        if (ddlCamp.SelectedValue == "57")
    //            msg.Visible = true;
    //        else
    //            msg.Visible = false;
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);
    //    }
    //}

    //protected void ddlCampSession_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        getCampSessionDates(ddlCampSession.SelectedValue);
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);
    //    }
    //}

    //to get the start date and the end date for the camp session
    //private void getCampSessionDates(string CampSessionId)
    //{
    //    DataSet dsCampSessionDates;
    //    DataRow dr;

    //    if (!CampSessionId.Equals("0"))
    //    {
    //        dsCampSessionDates = objGeneral.GetCampSessionDetail(Convert.ToInt32(CampSessionId));
    //        if (dsCampSessionDates.Tables[0].Rows.Count > 0)
    //        {
    //            dr = dsCampSessionDates.Tables[0].Rows[0];
    //            lblStartDate.Text = dr["StartDate"].ToString();
    //            lblEndDate.Text = dr["EndDate"].ToString();
    //            lblStartDate.Text = lblStartDate.Text == "" ? "" : Convert.ToDateTime(lblStartDate.Text).ToShortDateString();
    //            lblEndDate.Text = lblEndDate.Text == "" ? "" : Convert.ToDateTime(lblEndDate.Text).ToShortDateString();
    //        }
    //        else
    //        {
    //            lblStartDate.Text = "";
    //            lblEndDate.Text = "";
    //        }
    //    }
    //    else
    //    {
    //        lblStartDate.Text = "";
    //        lblEndDate.Text = "";
    //    }
    //}
}
