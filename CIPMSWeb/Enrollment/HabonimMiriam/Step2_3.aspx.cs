using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using CIPMSBC;
using CIPMSBC.Eligibility;

public partial class Step2_Habonim_3 : Page
{
    private CamperApplication CamperAppl;
    private General objGeneral;
    private Boolean bPerformUpdate;
    private RadioButton RadioButtonQ7Option1;
    private RadioButton RadioButtonQ7Option2;
    protected void Page_Init(object sender, EventArgs e)
    {
        btnChkEligibility.Click += new EventHandler(btnChkEligibility_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click+=new EventHandler(btnReturnAdmin_Click);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
    }

    void btnReturnAdmin_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        try
        {
            if (Page.IsValid)
            {
                strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"].ToString();
                InsertCamperAnswers();
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

    protected void Page_Load(object sender, EventArgs e)
    {
        RadioButtonQ7Option1 = (RadioButton)RegControls1.FindControl("RadioButtonQ7Option1");
        RadioButtonQ7Option2 = (RadioButton)RegControls1.FindControl("RadioButtonQ7Option2"); 
        CamperAppl = new CamperApplication();
        objGeneral = new General();
        imgbtnCalStartDt.Attributes.Add("onclick","return ShowCalendar('" + txtStartDate.ClientID + "');");
        imgbtnCalEndDt.Attributes.Add("onclick", "return ShowCalendar('" + txtEndDate.ClientID + "');");
        if (Session["STATUS"] != null)
        {
            if (Convert.ToInt16(Session["STATUS"].ToString()) == Convert.ToInt16(StatusInfo.SystemInEligible))
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
            //Added by Ram
            if (Session["FedId"] != null)
            {
                getCamps((string)Session["FedId"], Master.CampYear);//to get all camps for this federation                
            }
            else
            {
                getCamps("0", Master.CampYear); //to get all the camps and fill in
            }

            //getCamps("0"); //to get all the camps and fill in
            //to get the FJCID which is stored in session
            if (Session["FJCID"] != null)
            {
                hdnFJCIDStep2_3.Value = (string)Session["FJCID"];
                getCamperAnswers();
                //Session["FJCID"] = null;  
               

            }                
        }
        RadioButtonQ7Option1.Attributes.Add("onclick", "JavaScript:popupCall(this,'noCampRegistrationMsg','',true);");
        RadioButtonQ7Option2.Attributes.Add("onclick", "JavaScript:popupCall(this,'noCampRegistrationMsg','',true);");
        //RadioButtonQ7Option3.Attributes.Add("onclick", "windowURJopen(this,'PnlQ8','PnlQ9','PnlQ10');");
        //RadioButtonQ7Option4.Attributes.Add("onclick", "windowURJopen(this,'PnlQ8','PnlQ9','PnlQ10');");
        //to enable / disable the panel states based on the radio button selected
        SetPanelStates();

		string strCampID = Session["CampID"].ToString();
        string last3digits = strCampID.Substring(strCampID.Length - 3);

        //if (last3digits == "057") // Miriam
        //    lblSessionDays.Text = "In order to be eligible for the incentive grant, camper must attend camp for at least 12 consecutive days.";
    }

    //page unload
    protected void Page_Unload(object sender, EventArgs e)
    {
        CamperAppl = null;
        objGeneral = null;
    }

    void btnSaveandExit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                string strRedirURL;
                //strRedirURL = ConfigurationManager.AppSettings["SaveExitRedirURL"].ToString();
                strRedirURL = Master.SaveandExitURL;
                if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_3.Value, Master.CamperUserId))
                {
                    InsertCamperAnswers();
                }
                //Session["FJCID"] = null;
                //Session["ZIPCODE"] = null;
                //Session["STATUS"] = null;
                //Session.Abandon();
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
        if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_3.Value, Master.CamperUserId))
        {
            InsertCamperAnswers();
        }
        Session["FJCID"] = hdnFJCIDStep2_3.Value;
        Session["STATUS"] = null;
        if(ddlCamp.SelectedIndex > 0)
            Session["CampID"] = ddlCamp.SelectedValue;
        if (Request.QueryString["camp"] == "tavor")
            Response.Redirect("Step2_2.aspx?camp=tavor");
        else
            Response.Redirect("Step2_2.aspx");
    }

    void btnChkEligibility_Click(object sender, EventArgs e)
    {
        General objGeneral = new General();
        bool isReadOnly = objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_3.Value, Master.CamperUserId);
        //Modified by id taken from the Master Id
        string strModifiedBy = Master.UserId;
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
        int iCampId = Int32.Parse(ddlCamp.SelectedValue);
        Session["CampID"] = iCampId;
        string strFJCID = hdnFJCIDStep2_3.Value;
        //comments used only by the Admin user
        string strComments = txtComments.Text.Trim();

        int iStatus;
        if (strFJCID != "" && strModifiedBy != "")
        {
            if (isReadOnly)
            {
                DataSet dsApp = CamperAppl.getCamperApplication(strFJCID);
                iStatus = Convert.ToInt16(dsApp.Tables[0].Rows[0]["Status"]);
            }
            else
            {
                //to update the camp value to the database (to be used for search functionality)
                CamperAppl.updateCamp(strFJCID, iCampId, strComments, Convert.ToInt16(Master.CamperUserId));

                EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.Habonim, iCampId);
                objEligibility.checkEligibility(strFJCID, out iStatus);
            }

            var checkStatus = Convert.ToInt32(Session["STATUS"]);
            if (checkStatus == (int)StatusInfo.SystemInEligible)
                iStatus = checkStatus;
            else
                Session["STATUS"] = iStatus;

            if (iStatus == Convert.ToInt16(StatusInfo.SystemInEligible))
            {
                string strRedirURL;
                if (Master.UserId != Master.CamperUserId) //then the user is admin
                    strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"];
                else //the user is Camper
                    strRedirURL = "../ThankYou.aspx";
                //to update the status to the database   
                if (!isReadOnly)
                {
                    CamperAppl.submitCamperApplication(strFJCID, strComments, Convert.ToInt16(strModifiedBy), iStatus);
                }
                Response.Redirect(strRedirURL, false);
            }
            else //if he/she is eligible
            {
                Session["FJCID"] = hdnFJCIDStep2_3.Value;

                if (Request.QueryString["camp"] == "tavor")
                    Response.Redirect("../Step2_1.aspx?camp=tavor");
                else
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
        if (! strFJCID.Equals(string.Empty))
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
            //PnlQ8.Enabled = false;
            //PnlQ8_2_1.Enabled = false;
            //PnlQ8_2_2.Enabled = false;
            //ddlCamp.SelectedIndex = 0;
            PnlQ9.Enabled = false;
            txtCampSession.Text = "";
            PnlQ10.Enabled = false;
            txtStartDate.Text = "";
            txtEndDate.Text = "";
        }
        else
        {
            //PnlQ8.Enabled = true;
            //PnlQ8_2_1.Enabled = true;
            //PnlQ8_2_2.Enabled = true;
            PnlQ9.Enabled = true;
            PnlQ10.Enabled = true;
        }
    }

    /*Commented by Ram to change the logic from state to federation
    //to get the camps based on the state selected
    //if state is not selected then all the camps are populated
    private void getCamps(string StateId)
    {
       DataSet dsCamps;

       if (StateId == "0")
        {
            dsCamps = objGeneral.get_AllCamps();
        }
        else
        {
            dsCamps = objGeneral.get_CampsForState(StateId);
        }

        ddlCamp.DataSource = dsCamps;
        ddlCamp.DataTextField = "Camp";
        ddlCamp.DataValueField = "ID";
        ddlCamp.DataBind();
        ddlCamp.Items.Insert(0, new ListItem("-- Select --", "0"));
       
    }*/

    //to get the camps based on the Federation selected
    //if federation is not availble then all the camps are populated
    private void getCamps(string fedId,string CampYear)
    {
        DataSet dsCamps;

        if (fedId == "0")
        {
            dsCamps = objGeneral.get_AllCamps(CampYear);
        }
        else
        {
            dsCamps = objGeneral.GetFedCamps(fedId,CampYear);
        }

        ddlCamp.DataSource = dsCamps;
        ddlCamp.DataTextField = "Camp";
        ddlCamp.DataValueField = "CampID";
        ddlCamp.DataBind();
        ddlCamp.Items.Insert(0, new ListItem("-- Select --", "0"));

    }

    private string ConstructCamperAnswers()
    {
        string strQuestionId = "";
        string strTablevalues = "";
        string strFSeparator;
        string strQSeparator;
        string strRadioOption;
        string  strCamp, strCampSession, strStartDate, strEndDate; //-1 for Camper (User id will be passed for Admin user)

        //to get the Question separator from Web.config
        strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
        //to get the Field separator from Web.config
        strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();
        
        //for question 7
        strRadioOption = Convert.ToString(RadioButtonQ7Option1.Checked ? "1" : RadioButtonQ7Option2.Checked ? "2" :  "");
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
        try
        {
            string strCamperAnswers, strUserId, strCamperUserId, strComments, strFJCID;
            Boolean bArgsValid, bPerform;
            strUserId = Master.UserId;
            strCamperUserId = Master.CamperUserId;
            strComments = txtComments.Text.Trim();
            strFJCID = hdnFJCIDStep2_3.Value;
            strCamperAnswers = ConstructCamperAnswers();
            CamperAppl.CamperAnswersServerValidation(strCamperAnswers, strComments, strFJCID, strUserId, (Convert.ToInt32(Redirection_Logic.PageNames.Step2_3)).ToString(), strCamperUserId, out bArgsValid, out bPerform);
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
}
