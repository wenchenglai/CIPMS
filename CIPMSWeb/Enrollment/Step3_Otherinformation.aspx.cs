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
using System.IO;
using CIPMSBC;
using System.Net;

public partial class Questionaire_Step3_Otherinformation : System.Web.UI.Page
{
    private CamperApplication CamperAppl;
    private General objGeneral;
    //private Eligibility objEligibility;
    private Boolean bPerformUpdate;
    private const string EMAIL_NAME = "\"Friend Email Invite\"";

    protected void Page_Init(object sender, EventArgs e)
    {
        btnSubmitApplication.Click += new EventHandler(btnSubmitApplication_Click);
        btnInviteMoreFriends.Click += new EventHandler(btnInviteMoreFriends_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
        RadioBtnQ1.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        RadioBtnQ5.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        RadioBtnQ4.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
    }

    void RadioBtn_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            setPanelStatus();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

    }

    // to set the panel status based on the radio button selected
    void setPanelStatus()
    {
        //for Question 1
        if (RadioBtnQ1.SelectedIndex == 1) //No is selected
        {
            PnlQ2.Enabled = false;
            txtSynagogue.Text = "";
            reqvalSynagogue.Enabled = false;
        }
        else if (RadioBtnQ1.SelectedIndex == 0) //Yes is selected
        {
            PnlQ2.Enabled = true;
            reqvalSynagogue.Enabled = true;
        }
        if (RadioBtnQ4.SelectedIndex == 1) //No is selected
        {
            pnlJcc.Enabled = false;
            txtJCC.Text = "";
            reqvalJCC.Enabled = false;
        }
        else if (RadioBtnQ4.SelectedIndex == 0) //Yes is selected
        {
            pnlJcc.Enabled = true;
            reqvalJCC.Enabled = true;
        }
       
    }

    void btnReturnAdmin_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        try
        {
            if (Page.IsValid)
            {
                strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"].ToString();
                InsertStep4Answers();
                Response.Redirect(strRedirURL, false);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CamperAppl = new CamperApplication();
        objGeneral = new General();
        chkAgreement.Items[0].Attributes.Add("style", "display:none");
        if (!Page.IsPostBack)
        {
            PopulateDropdowns();
            Panel1.Visible = true;
            Panel2.Visible = false;
            // pnlJcc.Enabled = false;   
            div_dtlist.Visible = false;
            if (Session["FJCID"] != null)
            {
                hdnFJCID_OtherInfo.Value = (string)Session["FJCID"];
                getCamperAnswers();                   
            }
            div_dtlist.Attributes.Add("class", "div-dtlist_noheight");

            if (Session["FedId"] != null)
            {
                string[] SynagogueList;
                string SynagogueFedIds = ConfigurationManager.AppSettings["SynagogueFedId"];
                string FedId = Session["FedId"].ToString();
                SynagogueList = SynagogueFedIds.Split(',');
                for (int i = 0; i < SynagogueList.Length; i++)
                {
                    if (SynagogueList[i].ToString() == FedId)
                    {
                        RequiredFieldValidator3.Enabled = false;
                        reqvalJCC.Enabled = false;
                        PnlQ2.Enabled = false;
                        pnlJcc.Enabled = false;
                        PnlQ1.Enabled = false;
                        RadioBtnQ4.Enabled = false;
                        Label7.Enabled = false;
                        break;
                    }
                }
            }

            foreach (ListItem li in chkQ9.Items)
            {
                li.Attributes.Add("onclick", "JavaScript:Q8AndQ9CheckBoxSelection(this,\"" + li.Text + "\",\"" + li.Value + "\");");
            }
            foreach (ListItem li in chkQ10.Items)
            {
                li.Attributes.Add("onclick", "JavaScript:Q8AndQ9CheckBoxSelection(this,\"" + li.Text + "\",\"" + li.Value + "\");");
            }
        }          
    }

    //*********************************************************************************************
    // Name:            OnPreRender
    // Description:     MS Page event that fires just before page rendering. Will address
    //                  enable/disabling certain controls here so it happens after the Master
    //                  Page load event.
    //
    // Parameters:      e - Microsoft standard parameter
    // Returns:         None.
    // History:         02/2009 - TV: Initial coding - Issue # 4-006
    //*********************************************************************************************
    protected override void OnPreRender(EventArgs e)
    {
        //Master.setUserId();... not needed since this OnPreRender event fires after the Master Page_Load event

        //if camper
        if (Master.UserId == Master.CamperUserId)
        {
            //need to make sure that the btnInviteMoreFriends control is disabled if the application should be disabled
            //(the code in the Master page that disables the other controls unfortunately also enables the Button controls, so this code
            //needs disable the btnInviteMoreFriends control separately)
            General oGen = new General();
            string sFJCID = "";
            if (Session["FJCID"] != null)
            {
                sFJCID = (string)Session["FJCID"];
                if (oGen.IsApplicationReadOnly(sFJCID, Master.CamperUserId) == true)
                {
                    btnInviteMoreFriends.Enabled = false;
                    btnInviteMoreFriends.CssClass = "submitbtn1-DISABLED";
                }
            }
        }
        else //if Admin
        {
            //the user is the Admin, so make sure all of the Invite Friends related controls are disabled
            Label10.Enabled = false;
            Label15.Enabled = false;
            btnInviteMoreFriends.Enabled = false;
            btnInviteMoreFriends.CssClass = "submitbtn1-DISABLED";
            txtFriendsEmail.Enabled = false;
            dlInviteFriends.Enabled = false;
        }
    }

    void Page_Unload(object sender, EventArgs e)
    {
        CamperAppl = null;
        objGeneral = null;
        //objEligibility = null;
    }
    //To bind the countries data to dropdown lists
    private void PopulateDropdowns()
    {
        DataSet dsCountries;
        objGeneral = new General();
        dsCountries = objGeneral.get_AllCountries();

        ddlCountry1.DataSource = dsCountries;
        ddlCountry1.DataTextField = "Country_Name";
        ddlCountry1.DataValueField = "Country_ID";      
        ddlCountry1.DataBind(); 
        if ((ddlCountry1.Items.Count != 0))

            ddlCountry1.Items.Insert(0, new ListItem("-- Select --", "0"));
        string valueToRemove = "132"; 
        this.ddlCountry1.Items.Remove(this.ddlCountry1.Items.FindByValue(valueToRemove));

        ddlCountry1.Items.Insert(3, new ListItem("Mexico", "132"));
        valueToRemove = "99";
        this.ddlCountry1.Items.Remove(this.ddlCountry1.Items.FindByValue(valueToRemove));
        ddlCountry1.Items.Insert(4, new ListItem("Israel", "99"));
        valueToRemove = "173";
        this.ddlCountry1.Items.Remove(this.ddlCountry1.Items.FindByValue(valueToRemove));
        ddlCountry1.Items.Insert(5, new ListItem("Russia", "173"));

        valueToRemove = "193";
        this.ddlCountry1.Items.Remove(this.ddlCountry1.Items.FindByValue(valueToRemove));
        ddlCountry1.Items.Insert(6, new ListItem("South Africa", "193"));        

        valueToRemove = "220";
        this.ddlCountry1.Items.Remove(this.ddlCountry1.Items.FindByValue(valueToRemove));
        ddlCountry1.Items.Insert(7, new ListItem("Ukraine", "220"));


            ddlCountry1.Items.Insert(7, new ListItem("--------------", "-1"));
        ddlCountry2.DataSource = dsCountries;
        ddlCountry2.DataTextField = "Country_Name";
        ddlCountry2.DataValueField = "Country_ID";      
        ddlCountry2.DataBind();
        if ((ddlCountry2.Items.Count != 0))
            //ddlCountry2.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlCountry2.Items.Insert(0, new ListItem("-- Select --", "0"));
        valueToRemove = "132";
        this.ddlCountry2.Items.Remove(this.ddlCountry1.Items.FindByValue(valueToRemove));

        ddlCountry2.Items.Insert(3, new ListItem("Mexico", "132"));
        valueToRemove = "99";
        this.ddlCountry2.Items.Remove(this.ddlCountry1.Items.FindByValue(valueToRemove));
        ddlCountry2.Items.Insert(4, new ListItem("Israel", "99"));
        valueToRemove = "173";
        this.ddlCountry2.Items.Remove(this.ddlCountry1.Items.FindByValue(valueToRemove));
        ddlCountry2.Items.Insert(5, new ListItem("Russia", "173"));

        valueToRemove = "193";
        this.ddlCountry1.Items.Remove(this.ddlCountry1.Items.FindByValue(valueToRemove));
        ddlCountry1.Items.Insert(6, new ListItem("South Africa", "193")); 
        
        valueToRemove = "220";
        this.ddlCountry2.Items.Remove(this.ddlCountry1.Items.FindByValue(valueToRemove));
        ddlCountry2.Items.Insert(7, new ListItem("Ukraine", "220"));


        ddlCountry2.Items.Insert(7, new ListItem("--------------", "-1"));

    }

    void btnPrevious_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                if (!objGeneral.IsApplicationReadOnly(hdnFJCID_OtherInfo.Value, Master.CamperUserId))
                {
                    InsertStep4Answers();
                }
                Session["FJCID"] = hdnFJCID_OtherInfo.Value;
                Response.Redirect("Step3_Parentinformation.aspx", false);
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
                //ProcessCamperAnswers();
                if (!objGeneral.IsApplicationReadOnly(hdnFJCID_OtherInfo.Value, Master.CamperUserId))
                {
                    InsertStep4Answers();
                }

                if (Master.CheckCamperUser == "Yes")
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

    void btnInviteMoreFriends_Click(object sender, EventArgs e)
    {
        DataTable dt;
        DataRow dr;
        dt = new DataTable();
        Label l;
        CheckBox cb;
        try
        {
            dt.Columns.Add(new DataColumn("Answer"));
            dr = dt.NewRow();
            dr["Answer"] = txtFriendsEmail.Text.Trim();

            dt.Rows.Add(dr);

            //to get the email ids list which is already there in the datalist
            foreach (DataListItem dlitem in dlInviteFriends.Items)
            {
                l = (Label)dlitem.FindControl("lblEmail");
                cb = (CheckBox)dlitem.FindControl("chkEmail");
                if (string.Compare(l.Text, txtFriendsEmail.Text.Trim()) != 0 && cb.Checked != false)
                {
                    dr = dt.NewRow();
                    dr["Answer"] = l.Text;
                    cb.Checked = true;
                    dt.Rows.Add(dr);
                }
            }
            txtFriendsEmail.Text = "";
            dlInviteFriends.DataSource = dt;
            dlInviteFriends.DataBind();
            div_dtlist.Attributes["class"] = "div-dtlist";
            div_dtlist.Visible = true;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            dt.Clear();
            dt = null;
        }
    }

    void btnSubmitApplication_Click(object sender, EventArgs e)
    {
        if (!chkAgreement.Items[2].Selected)
        {
			lblErrorMsg.Text = "Please Select Agreement Checkbox before submitting the application";
			lblErrorMsg.Visible = true;
			return;
        }

		if (!objGeneral.IsApplicationReadOnly(hdnFJCID_OtherInfo.Value, Master.CamperUserId))
		{
			ProcessCamperAnswers();
			//Send Email to Parent one of the camper.
			//SendEmailNotification();
			//ProcessPJLFile();

            if ((Request.Url.Host != "localhost") && (Dns.GetHostAddresses(Request.Url.Host)[0].ToString() == ConfigurationManager.AppSettings["UATIP"]))
            {
			    string strFolder;
			    strFolder = ConfigurationManager.AppSettings["EmailNotificationFolderPath"];
			    if (Directory.Exists(strFolder))
			    {
				    ProcessFile(strFolder);
			    }
			    else
			    {
				    Directory.CreateDirectory(strFolder);
				    ProcessFile(strFolder);
			    }
            }
		}

		string strRedirURL;
		if (Master.UserId != Master.CamperUserId) //then the user is admin
			strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"];
		else //the user is Camper
			strRedirURL = "ThankYou.aspx";

		Response.Redirect(strRedirURL, false);

    }

    private void ProcessPJLFile()
    {
        string strFileName = string.Empty;
        string strFilePath = string.Empty;
        string strFileExtension = string.Empty;
        string strFolderPath = string.Empty;

        try
        {
            strFolderPath = ConfigurationManager.AppSettings["PJLNotificationFolderPath"];
            strFileName = ConfigurationManager.AppSettings["PJLNotificationFileName"];
            strFileExtension = ConfigurationManager.AppSettings["PJLNotificationFileExtension"];
            strFilePath = strFolderPath + "/" + DateTime.Now.Date.ToString("MMM-dd-yyyy") + "_" + strFileName + strFileExtension;
            DataSet dsPJLNotification = new DataSet();
            dsPJLNotification = objGeneral.GetPJLNotification((string)Session["FJCID"]);
 
            if (dsPJLNotification.Tables.Count > 0)
            {
                if (File.Exists(strFilePath))
                {
                    StreamWriter strmWriterFile = new StreamWriter(strFilePath, true);  //true defines append to the file if exists
                    //if file does not exists creates new and header (true) if file exists writeheader to be set as false
                    objGeneral.ProduceCSV(dsPJLNotification.Tables[0], strmWriterFile, false,1);
                }
                else
                {
                    //File.Create(strFilePath);
                    StreamWriter strmWriterFile = new StreamWriter(strFilePath, true); //true defines append to the file if exists
                    //if file does not exists creates new and header (true) if file exists writeheader to be set as false
                    objGeneral.ProduceCSV(dsPJLNotification.Tables[0], strmWriterFile, true,1);
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            throw ex;
        }
    }

    private void ProcessFile(string strFolderPath)
    {
        string strFileName = string.Empty;
        string strFilePath = string.Empty;
        string strFileExtension = string.Empty;
        try
        {
            strFileName = ConfigurationManager.AppSettings["EmailNotificationFileName"];
            strFileExtension = ConfigurationManager.AppSettings["EmailNotificationFileExtension"];
            strFilePath = strFolderPath + "/" + DateTime.Now.Date.ToString("MMM-dd-yyyy") + "_" + strFileName + strFileExtension;
            DataSet dsEmailNotification = new DataSet();
            dsEmailNotification = objGeneral.GetEmailNotification((string)Session["FJCID"]);
            if (dsEmailNotification.Tables.Count > 0)
            {
                if (File.Exists(strFilePath))
                {
                    StreamWriter strmWriterFile = new StreamWriter(strFilePath, true);  //true defines append to the file if exists
                    //if file does not exists creates new and header (true) if file exists writeheader to be set as false
                    objGeneral.ProduceCSV(dsEmailNotification.Tables[0], strmWriterFile, false,0);
                }
                else
                {
                    //File.Create(strFilePath);
                    StreamWriter strmWriterFile = new StreamWriter(strFilePath, true); //true defines append to the file if exists
                    //if file does not exists creates new and header (true) if file exists writeheader to be set as false
                    objGeneral.ProduceCSV(dsEmailNotification.Tables[0], strmWriterFile, true,0);
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            throw ex;
        }
    }
    
    void ProcessCamperAnswers()
    {
        string strComments, strModifiedBy, strFJCID;
        //Boolean bAcceptOption1 = false, bAcceptOption2 = false, bAcceptOption3 = false;
        int iStatus = 0;

        //to get the comments (used only by the Admin user)
        strComments = txtComments.Text.Trim();
        strModifiedBy = Master.UserId;
        strFJCID = hdnFJCID_OtherInfo.Value;
        InsertStep4Answers();

        //the status value will be set in session once btncheckeligibility_click is fired in step2_3.aspx for any questionnaire
        if (Session["STATUS"] != null)
            iStatus = Convert.ToInt16(Session["STATUS"]);

        if (strFJCID != "" && strModifiedBy != "" && chkAgreement.Enabled)
        {
			// 2012-11-07 Added new status ID = 42 (Eligile;Contact Parents to resubmit application), so we have to check here and mark it as eligible
			if (iStatus == (int)StatusInfo.EligibleContactParentsAagain)
			{
				iStatus = (int)StatusInfo.EligibleByStaff;
				Session["STATUS"] = iStatus;
			}

            //to submit the application
            CamperAppl.submitCamperApplication(strFJCID, strComments, Convert.ToInt16(strModifiedBy), iStatus);
            //this will be called only if the logged in user is admin
            if (strModifiedBy != Master.CamperUserId) //session values are not cleared if the user is admin
            {
                if (!CamperAppl.CamperStatusDetectived(strFJCID, (int)StatusInfo.SecondApproval))
                    CamperAppl.SetSecondApproval(strFJCID); //To avoid setting if second approval approved already
            }
        }

        //***********
        //TV: 02/2009 - Issue # 4-006: Add actual email functionality for each email address
        //of "friends" that the applicant wants to "invite" to the FJC community (but only do this if the user 
        //is the camper, and if the email textbox is enabled)
        if (Master.UserId == Master.CamperUserId && txtFriendsEmail.Enabled == true)
        {
            //one last check - make sure the EmailInvite feature has been enabled in the config file
            string sEnableEmailInvite = ConfigurationManager.AppSettings["EnableEmailInvite"];
            if (sEnableEmailInvite != null && sEnableEmailInvite.ToUpper() == "Y")
            {
                //send email invite to the camper's friend(s)
                try
                {
                    SendEmailInvite();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message +
                        "<br />\"Email Invite\" errors are isolated and they should not affect the rest of the application.");
                }
            }
        }
        //***********
    }

    protected void InsertStep4Answers()
    {
        string strTablevalues = "";
        string strComments, strModifiedBy, strFJCID;
        Boolean bAcceptOption1 = false, bAcceptOption2 = false, bAcceptOption3 = false;
        int RowsAffected, iStatus = 0;

        strTablevalues = ConstructCamperAnswers();
        strModifiedBy = Master.UserId;
        strFJCID = hdnFJCID_OtherInfo.Value;
        strComments = txtComments.Text.Trim(); //Used by the Admin user

        //the status value will be set in session once btncheckeligibility_click is fired in step2_3.aspx for any questionnaire
        if (Session["STATUS"] != null)
            iStatus = Convert.ToInt16(Session["STATUS"]);

        foreach (ListItem li in chkAgreement.Items)
        {
            if (li.Selected)
            {
                switch (li.Value)
                {
                    case "1":
                        bAcceptOption1 = true;
                        break;
                    case "2":
                        bAcceptOption2 = true;
                        break;
                    case "3":
                        bAcceptOption3 = true;
                        break;
                }
            }
        }

        //if the user has declined the status to be set to decline
		//if (!bAcceptOption1)
		//    Session["STATUS"] = ((int)StatusInfo.CamperDeclined).ToString();

        if (strFJCID != "" && strTablevalues != "" && strModifiedBy != "" && bPerformUpdate)
            RowsAffected = CamperAppl.InsertCamperAnswers(strFJCID, strTablevalues, strModifiedBy, strComments);
        //to set whether the user has accpeted/decline the terms and conditions
        if (strFJCID != "")
            CamperAppl.SetTermsandConditionsAcceptance(strFJCID, bAcceptOption1, bAcceptOption2, bAcceptOption3);
    }

    //to get the camper answers from the database
    void getCamperAnswers()
    {
        int iCount;
        DataView dv;
        HiddenField hdnval;
        DataRow[] drows;
        DataRow dr;
        TextBox tb;
        RadioButtonList rb;
        DropDownList ddl;
        CheckBoxList cb;
        string strFilter, strFJCID;
        strFJCID = hdnFJCID_OtherInfo.Value;

        DataSet dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "30", "1026", "N");

        if (dsAnswers.Tables[0].Rows.Count == 0) //if there are records for the current FJCID
            return;

        dv = dsAnswers.Tables[0].DefaultView;
        //to display answers for the QuestionId from 1001 - 1004 in Other info page
        for (int i = 1; i <= 15; i++)
        {
            //to get the QuestionId for the Questions
            hdnval = (HiddenField)PnlHidden.FindControl("hdnQ" + i.ToString() + "Id");
            strFilter = "QuestionId = '" + hdnval.Value + "'";
            rb = null;
            tb = null;
            ddl = null;
            iCount = dsAnswers.Tables[0].Rows.Count;

            switch (i)
            {
                case 1:  //assigning the answer for question 1
                    rb = RadioBtnQ1;
                    goto default;
                case 2: //assigning the answer for question 2
                    tb = txtSynagogue;
                    goto default;
                case 3: //assigning the answer for question 3
                    rb = RadioBtnQ3;
                    goto default;
                case 4: //assigning the answer for question 4
                    rb = RadioBtnQ4;
                    goto default;
                case 5: //assigning the answer for question 5
                    rb = RadioBtnQ5;
                    goto default;
                case 6: //assigning the answer for question 6
                    foreach (DataRow dr1 in dv.Table.Select(strFilter))
                    {
                        if (!dr1["OptionID"].Equals(DBNull.Value))
                        {
                            switch (dr1["OptionID"].ToString())
                            {
                                case "1":  //for Parent 1 Country
                                    //txtCountry1.Text = dr1["Answer"].Equals(DBNull.Value) ? "" : dr1["Answer"].ToString();
                                    if (!dr1["Answer"].Equals(DBNull.Value))
                                        ddlCountry1.SelectedValue = dr1["Answer"].ToString();
                                    break;
                                case "2": //for End Date
                                    //txtCountry2.Text = dr1["Answer"].Equals(DBNull.Value) ? "" : dr1["Answer"].ToString();
                                    if (!dr1["Answer"].Equals(DBNull.Value))
                                        ddlCountry2.SelectedValue = dr1["Answer"].ToString();
                                    break;
                            }
                        }
                    }
                    break;
                case 7: //assigning the answer for question 7
                //    rb = RadioBtnQ7;
                //    goto default;
                case 8: //assigning the answer for question 8
                    ddl = ddlQ8;
                    goto default;
                case 9: //assigning the answer for question 9
                    //ddl = ddlQ9;
                    //goto default;
                    foreach (DataRow dr1 in dv.Table.Select(strFilter))
                    {
                        if (!dr1["OptionID"].Equals(DBNull.Value))
                        {                               
                            int value=Convert.ToInt32(dr1["OptionID"].ToString());
                            if (value > 0)
                            {
                                chkQ9.Items.FindByValue(value.ToString()).Selected = true;
                            }
                        }
                    }
                    break;
                case 10: //assigning the answer for question 10
                    foreach (DataRow dr1 in dv.Table.Select(strFilter))
                    {
                        if (!dr1["OptionID"].Equals(DBNull.Value))
                        {
                                int value=Convert.ToInt32(dr1["OptionID"].ToString());
                                if (value > 0)
                                {
                                    chkQ10.Items.FindByValue(value.ToString()).Selected = true;
                                }
                        }
                    }
                    break;
                case 11: //assigning the answer for question 11
                //    rb = RadioBtnQ11;
                //    goto default;
                case 12: //assigning the answer for question 12
                //    rb = RadioBtnQ12;
                //    goto default;
                case 13: //assigning the answer for question 13
                    dv.RowFilter = strFilter;
                    if (dv.Table.Select(strFilter).Length > 0)
                    {
                        div_dtlist.Visible = true;
                        dlInviteFriends.Visible = true;
                        dlInviteFriends.DataSource = dv;
                        dlInviteFriends.DataBind();
                    }
                    break;
                case 14: //assigning the answer for question 2
                    foreach (DataRow dr1 in dv.Table.Select(strFilter))
                    {
                        //if (!dr1["OptionID"].Equals(DBNull.Value))
                        //{
                            //if (dr1["OptionID"].ToString().Equals("4"))
                            //{
                                if (!dr1["Answer"].Equals(DBNull.Value))
                                    txtJCC.Text = dr1["Answer"].ToString();

                            //}
                        //}
                    }
                    break;
                case 15: //assigning the answer for question 5
                    rb = RadioBtnQ6;
                    goto default;
                default:
                    drows = dv.Table.Select(strFilter);
                    if (drows.Length > 0) //if there are rows for the filter
                    {
                        dr = (DataRow)drows.GetValue(0);
                        //for dropdownlist
                        if (ddl != null)
                        {
                            if (!dr["OptionID"].Equals(DBNull.Value))
                                ddl.SelectedValue = dr["OptionID"].ToString();
                        }
                        //for text box
                        if (tb != null)
                        {
                            if (!dr["Answer"].Equals(DBNull.Value))
                                tb.Text = dr["Answer"].ToString();
                        }
                        //for radio buttonlist
                        if (rb != null)
                        {
                            if (!dr["OptionID"].Equals(DBNull.Value))
                                rb.SelectedValue = dr["OptionID"].ToString();
                        }
                    }
                    break;
            }
        }

        DataSet dsSynagogues = new DataSet();
        DataSet DsJcc = new DataSet();
        for (int i = 0; i < dsAnswers.Tables[0].Rows.Count; i++)
        {
            if (dsAnswers.Tables[0].Rows[i][1].ToString() != null)
            {
                if ((dsAnswers.Tables[0].Rows[i][1].ToString() == "30"))
                {
                    if (RadioBtnQ1.SelectedValue == "")
                    {
                        RadioBtnQ1.SelectedValue = "2";
                    }
                    if (RadioBtnQ4.SelectedValue == "")
                    {
                        RadioBtnQ4.SelectedValue = "2";
                    }

                }
                if ((dsAnswers.Tables[0].Rows[i][1].ToString() == "30") && (dsAnswers.Tables[0].Rows[i][2].ToString() == "2"))
                {
                    RadioBtnQ1.SelectedValue = "2";
                    RadioBtnQ4.SelectedValue = "2";
                    RadioBtnQ1.Enabled = false;
                    RadioBtnQ4.Enabled = false;
                    txtSynagogue.Enabled = false;
                    txtJCC.Enabled = false;
                    txtSynagogue.Text = "";
                    txtJCC.Text = "";
                    break;
                }
                else if ((dsAnswers.Tables[0].Rows[i][1].ToString() == "30") && (dsAnswers.Tables[0].Rows[i][2].ToString() == "1"))
                {
                    RadioBtnQ1.SelectedValue = "1";
                    RadioBtnQ1.Enabled = false;
                    txtJCC.Enabled = false;
                }
                else if ((dsAnswers.Tables[0].Rows[i][1].ToString() == "30") && (dsAnswers.Tables[0].Rows[i][2].ToString() == "3"))
                {
                    RadioBtnQ4.SelectedValue = "1";
                    RadioBtnQ4.Enabled = false;
                    txtSynagogue.Enabled = false;
                }
                    
                if (dsAnswers.Tables[0].Rows[i][1].ToString() == "31")
                {
                    if ((dsAnswers.Tables[0].Rows[i][2].ToString() == "1"))
                    {
                        if ((dsAnswers.Tables[0].Rows[i][3].ToString() != null)&&(dsAnswers.Tables[0].Rows[i][3].ToString().Trim() != ""))
                        {
                            int federationID = Convert.ToInt32(Session["FedId"].ToString());
                            dsSynagogues = objGeneral.GetSynagogueByID(dsAnswers.Tables[0].Rows[i][3].ToString(), federationID);
                            txtSynagogue.Text = dsSynagogues.Tables[0].Rows[0][1].ToString();
                            txtSynagogue.Enabled = false;
                        }
                    }

                    if ((dsAnswers.Tables[0].Rows[i][2].ToString() == "2"))
                    {
                        if ((dsAnswers.Tables[0].Rows[i][3].ToString() != null) && (dsAnswers.Tables[0].Rows[i][3].ToString().Trim() != ""))
                        {
                            txtSynagogue.Text = dsAnswers.Tables[0].Rows[i][3].ToString();
                            txtSynagogue.Enabled = false; 
                        }
                    }

                    if ((dsAnswers.Tables[0].Rows[i][2].ToString() == "3"))
                    {
                        if ((dsAnswers.Tables[0].Rows[i][3].ToString() != null) && (dsAnswers.Tables[0].Rows[i][3].ToString().Trim() != ""))
                        {
                            DsJcc = objGeneral.GetJCCByID(dsAnswers.Tables[0].Rows[i][3].ToString());
                            txtJCC.Text = DsJcc.Tables[0].Rows[0][1].ToString();
                            txtJCC.Enabled = false;
                        }
                    }

                    if ((dsAnswers.Tables[0].Rows[i][2].ToString() == "4"))
                    {
                        if ((dsAnswers.Tables[0].Rows[i][3].ToString() != null) && (dsAnswers.Tables[0].Rows[i][3].ToString().Trim() != ""))
                        {
                            txtJCC.Text = dsAnswers.Tables[0].Rows[i][3].ToString();
                            txtJCC.Enabled = false;
                        }
                    }
                }
            }
        }

        DataSet dsTerms = CamperAppl.getCamperApplication(strFJCID);
        if (dsTerms.Tables[0].Rows.Count > 0)
        {
            dr = dsTerms.Tables[0].Rows[0];
            if (!dr["ConfirmAcceptance"].Equals(DBNull.Value))
                chkAgreement.Items[0].Selected = (Boolean)dr["confirm2"] ? true : false;
            if (!dr["confirm2"].Equals(DBNull.Value))
                chkAgreement.Items[1].Selected = (Boolean)dr["confirm3"] ? true : false;
            if (!dr["confirm3"].Equals(DBNull.Value))
                chkAgreement.Items[2].Selected = (Boolean)dr["ConfirmAcceptance"] ? true : false;
        }

        //to set the panel status based on the radio button selected
        setPanelStatus();
        if (dsTerms.Tables[0].Rows.Count > 0)
        {
            dr = dsTerms.Tables[0].Rows[0];
            if (dr["Amount"] != null)
                Session["Amount"] = dr["Amount"];
        }
    }


    void CusValComments_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string strCamperAnswers, strUserId, strCamperUserId, strComments, strFJCID;
        Boolean bArgsValid, bPerform;
        strUserId = Master.UserId;
        strCamperUserId = Master.CamperUserId;
        strComments = txtComments.Text.Trim();
        strFJCID = hdnFJCID_OtherInfo.Value;
        strCamperAnswers = ConstructCamperAnswers();
        CamperAppl.CamperAnswersServerValidation(strCamperAnswers, strComments, strFJCID, strUserId, (Convert.ToInt32(Redirection_Logic.PageNames.Step3_OtherInfo).ToString()), strCamperUserId, out bArgsValid, out bPerform);
        args.IsValid = bArgsValid;
        bPerformUpdate = bPerform;
    }

    //to construct the camper answers to be inserted to the database
    private string ConstructCamperAnswers()
    {
        string strTablevalues = "";
        string strQSeparator;
        string strFSeparator;
        Label lb;
        CheckBox cb;
        int iQ13OptionId;

        //to get the Question separator from Web.config
        strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
        //to get the Field separator from Web.config
        strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();
        //for question 1
        // since there are no option text to be entered two (field separator has been given) is being put
        strTablevalues += hdnQ1Id.Value + strFSeparator + RadioBtnQ1.SelectedValue + strFSeparator + strQSeparator;

        //for question 2
        strTablevalues += hdnQ2Id.Value + strFSeparator + strFSeparator + txtSynagogue.Text.Trim() + strQSeparator;

        //for question 3
        strTablevalues += hdnQ3Id.Value + strFSeparator + RadioBtnQ3.SelectedValue + strFSeparator + strQSeparator;

        //for question 4
        strTablevalues += hdnQ4Id.Value + strFSeparator + RadioBtnQ4.SelectedValue + strFSeparator + strQSeparator;

        //for question 5
        strTablevalues += hdnQ5Id.Value + strFSeparator + RadioBtnQ5.SelectedValue + strFSeparator + strQSeparator;
        strTablevalues += hdnQ14Id.Value + strFSeparator + strFSeparator + txtJCC.Text.Trim() + strQSeparator;

        //for question 6
        strTablevalues += hdnQ15Id.Value + strFSeparator + RadioBtnQ6.SelectedValue + strFSeparator + strQSeparator;

        //for question 6 now updated as question 5
        //strTablevalues += hdnQ6Id.Value + strFSeparator + "1" + strFSeparator + txtCountry1.Text.Trim() + strQSeparator;
        //strTablevalues += hdnQ6Id.Value + strFSeparator + "2" + strFSeparator + txtCountry2.Text.Trim() + strQSeparator;
        strTablevalues += hdnQ6Id.Value + strFSeparator + "1" + strFSeparator + ddlCountry1.SelectedValue + strQSeparator;
        strTablevalues += hdnQ6Id.Value + strFSeparator + "2" + strFSeparator + ddlCountry2.SelectedValue + strQSeparator;


        //for question 7
        //strTablevalues += hdnQ7Id.Value + strFSeparator + RadioBtnQ7.SelectedValue + strFSeparator + strQSeparator;
       

        //for question 8
        strTablevalues += hdnQ8Id.Value + strFSeparator + ddlQ8.SelectedValue + strFSeparator + strQSeparator;

        //for question 9
        //strTablevalues += hdnQ9Id.Value + strFSeparator + ddlQ9.SelectedValue + strFSeparator + strQSeparator;
        for (int i = 0; i < 4; i++)
        {
            int k = i + 1;
            if (chkQ9.Items[i].Selected == true)
                strTablevalues += hdnQ9Id.Value + strFSeparator + k.ToString() + strFSeparator + chkQ9.Items[i].Value + strQSeparator;

        }
        //for question 10
        //strTablevalues += hdnQ10Id.Value + strFSeparator + ddlQ10.SelectedValue + strFSeparator + strQSeparator;
        for (int i = 0; i < 4; i++)
        {
            int k = i + 1;
            if(chkQ10.Items[i].Selected == true)
                strTablevalues += hdnQ10Id.Value + strFSeparator + k.ToString() + strFSeparator + chkQ10.Items[i].Value + strQSeparator;
            
        }
        //for question 11
       // strTablevalues += hdnQ11Id.Value + strFSeparator + RadioBtnQ11.SelectedValue + strFSeparator + strQSeparator;

        //for question 12
       // strTablevalues += hdnQ12Id.Value + strFSeparator + RadioBtnQ12.SelectedValue + strFSeparator + strQSeparator;

        //for question 13 
        iQ13OptionId = 100000; //this option value is used only to insert the values in the database
        if (txtFriendsEmail.Text.Trim() != "")
        {
            strTablevalues += hdnQ13Id.Value + strFSeparator + iQ13OptionId.ToString() + strFSeparator + txtFriendsEmail.Text.Trim() + strQSeparator;
            iQ13OptionId += 1;
        }
        foreach (DataListItem dlitem in dlInviteFriends.Items)
        {
            cb = (CheckBox)dlitem.FindControl("chkEmail");
            if (cb != null)
            {
                //if the checkbox is checked
                if (cb.Checked)
                {
                    lb = (Label)dlitem.FindControl("lblEmail");
                    strTablevalues += hdnQ13Id.Value + strFSeparator + iQ13OptionId.ToString() + strFSeparator + lb.Text.Trim() + strQSeparator;
                    iQ13OptionId += 1;
                }
            }
        }
        //to remove the extra character at the end of the string, if any
        char[] chartoRemove = { Convert.ToChar(strQSeparator) };
        strTablevalues = strTablevalues.TrimEnd(chartoRemove);
        return strTablevalues;

    }

    //*********************************************************************************************
    // Name:            SendEmailInvite
    // Description:     Will send "friends invite email" to the email address(es) specified by
    //                  the user on the screen.
    //
    // Parameters:      None.
    // Returns:         None.
    // History:         02/2009 - TV: Initial coding - Issue # 4-006: Add actual email 
    //                  functionality for each email address of "friends" that the applicant 
    //                  wants to "invite"
    //*********************************************************************************************
    private void SendEmailInvite()
    {
        try
        {
            ArrayList alEmailList = new ArrayList();

            //first get friend's email in text box
            if (txtFriendsEmail.Text.Trim().Length > 0)
            {
                alEmailList.Add((string)txtFriendsEmail.Text.Trim());
            }

            CheckBox chkEmail;
            Label lblEmail;

            //get additional friend's emails in in the DataList control
            foreach (DataListItem dlitem in dlInviteFriends.Items)
            {
                chkEmail = (CheckBox)dlitem.FindControl("chkEmail");
                if (chkEmail != null)
                {
                    //if the checkbox is checked, then consider the email address by
                    //adding it to the ArrayList object alEmailList
                    if (chkEmail.Checked)
                    {
                        lblEmail = (Label)dlitem.FindControl("lblEmail");
                        alEmailList.Add((string)lblEmail.Text.Trim());
                    }
                }
            }

            //only continue if there were emails detected
            if (alEmailList.Count > 0)
            {
                //get email configuration settings
                string sFromEmail = ConfigurationManager.AppSettings["EmailFrom"].ToString();
                string sReplyAddress = ConfigurationManager.AppSettings["ReplyTo"].ToString();
                string sFromName = ConfigurationManager.AppSettings["FromName"].ToString();
                string sSubject = ConfigurationManager.AppSettings["EmailInviteSubject"].ToString();
                string sEmailInviteFilename = ConfigurationManager.AppSettings["EmailInviteFile"].ToString();

                string sBody = "";

                //get actual physical path to file on the server
                string sEmailInviteFilenameMapped = Server.MapPath(sEmailInviteFilename);

                if (File.Exists(sEmailInviteFilenameMapped) == true)
                {
                    //get file contents for usage as the email "body"
                    sBody = File.ReadAllText(sEmailInviteFilenameMapped);

                    if (sBody.Length > 0)
                    {
                        foreach (string sToEmailAddress in alEmailList)
                        {
                            //send email
                            cService.SendMail(sToEmailAddress, null, sFromName, sFromEmail, sReplyAddress, sSubject, sBody);
                        }
                    }
                    else
                    {
                        //empty email body content error
                        throw new Exception("Unable find content inside the " + EMAIL_NAME + " file.");
                    }
                }
                else
                {
                    //missing email content file error
                    throw new Exception("Missing " + EMAIL_NAME + " file on web server.");
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error detected while trying send the " + EMAIL_NAME + ".\n" + ex.Message);
        }
    }

    //public enum StatusInfo { Incomplete = 1, SystemEligible, SystemInEligible, EligibleNoCamp, EligiblePendingSchool, CamperDeclined }

    //private void SendEmailNotification()
    //{
    //    try
    //    {
    //        string strFJCID = string.Empty;
    //        string strFederationID = string.Empty;
    //        string strCampID = string.Empty;
    //        strFJCID = (string)Session["FJCID"];
    //        strFederationID = (string)Session["FederationID"];
    //        strCampID= (string)Session["CampID"];
    //        DataSet dsEmailNotification = new DataSet();
    //        if (!string.IsNullOrEmpty(strFJCID))
    //            dsEmailNotification = objGeneral.GetEmailNotification(strFJCID, strFederationID, strCampID);
    //        if (dsEmailNotification.Tables.Count > 0)
    //        {
    //            //get email configuration settings   
    //            string sFromEmail = ConfigurationManager.AppSettings["EmailFrom"].ToString();
    //            string sFromName = ConfigurationManager.AppSettings["FromName"].ToString();
    //            string sSubject = ConfigurationManager.AppSettings["EmailNotificationSubject"].ToString();
    //            string sEmailInviteFilename = ConfigurationManager.AppSettings["EmailNotificationFile"].ToString();
    //            string sBody = "";

    //            //get actual physical path to file on the server
    //            string sEmailInviteFilenameMapped = Server.MapPath(sEmailInviteFilename);
    //            if (File.Exists(sEmailInviteFilenameMapped) == true)
    //            {
    //                //get file contents for usage as the email "body"
    //                sBody = File.ReadAllText(sEmailInviteFilenameMapped);
    //                if (sBody.Length > 0)
    //                {
    //                    if(dsEmailNotification.Tables[0].Rows.Count>0)
    //                    {
    //                        if(dsEmailNotification.Tables[0].Rows[0]["FederationName"].ToString().Contains("JWest Campership Program"))
    //                        {
    //                            sBody = string.Format(sBody,dsEmailNotification.Tables[0].Rows[0]["FirstName"] + " " + dsEmailNotification.Tables[0].Rows[0]["LastName"],"the",dsEmailNotification.Tables[0].Rows[0]["FederationName"].ToString(),"The JWest Campership Program is an initiative of the Foundation for Jewish Camp",string.Empty,"Jwest@jewishcamp.org");
    //                        }
    //                        else
    //                            sBody = string.Format(sBody,dsEmailNotification.Tables[0].Rows[0]["FirstName"] + " " + dsEmailNotification.Tables[0].Rows[0]["LastName"],string.Empty,dsEmailNotification.Tables[0].Rows[0]["FederationName"].ToString(),"The Campership Incentive Program is a program of the Foundation for Jewish Camp in partnership with " + dsEmailNotification.Tables[0].Rows[0]["FederationName"].ToString() );
    //                    }

    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception("Error detected while trying send the " + EMAIL_NAME + ".\n" + ex.Message);
    //    }
    //}

}
