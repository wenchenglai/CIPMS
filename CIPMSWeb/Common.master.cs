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

public partial class Common : System.Web.UI.MasterPage
{
    private string _sUserId="";
    private string _sCamperUserId="";
    private string _sSaveandExitURL = "";
    private string _sCamperRedirURL = "";
    private string _sCheckUser = "";
    private string _campYear = "";
    //Added by Ram
    public string CampStartDate = string.Empty;
    public string CampEndDate = string.Empty;

    protected void Page_Init(object sender, EventArgs e)
    {
        string strCurrentURL;
        Button btnSaveandExit;
        Button btnDefault;
        strCurrentURL = Request.Path.ToUpper();
        if (strCurrentURL.IndexOf("SUMMARY.ASPX") >= 0)
        {
            btnSaveandExit = ((Button)Content.FindControl("btnSaveandExit"));
            if (btnSaveandExit!=null)
                btnSaveandExit.Click += new EventHandler(SummarySaveandExit_Click);
        }
        //to make the default button of the pages to invoke the button next event of "enter" from any text box in the page
        btnDefault = (Button)Content.FindControl("btnNext");
        if (btnDefault!=null)
            form1.DefaultButton = btnDefault.UniqueID;

        //Added by Ram
        CampStartDate = ConfigurationManager.AppSettings["CampSessionStartMonth"] + "/01/" + Application["CampYear"].ToString();
        hdnCampSessionStartDate.Value = DateTime.Parse(CampStartDate).AddDays(-1.0).ToShortDateString();
        CampEndDate = ConfigurationManager.AppSettings["CampSessionEndMonth"] + "/01/" + Application["CampYear"].ToString();
        hdnCampSessionEndDate.Value = DateTime.Parse(CampEndDate).AddMonths(1).ToShortDateString();
        hdncampSeasonErrorMessage.Value = "Choose camp session between " + DateTime.Parse(CampStartDate).ToShortDateString() + " and " + DateTime.Parse(CampEndDate).AddMonths(1).AddDays(-1.0).ToShortDateString();
    }

    void SummarySaveandExit_Click(object sender, EventArgs e)
    {
        try
        {
            string strRedirURL;
            strRedirURL = SaveandExitURL;
            
            if (CheckCamperUser == "Yes")
            {

                General oGen = new General();
                if (oGen.IsApplicationSubmitted(Session["FJCID"].ToString()))
                {
                    Response.Redirect(strRedirURL);
                }
                else
                {
                    string strScript = "<script language=javascript>openThis(); window.location='" + strRedirURL + "';</script>";
                    if (!Page.ClientScript.IsStartupScriptRegistered("clientScript"))
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strScript);
                    }
                }
            }
            else
            {
                Response.Redirect(strRedirURL);
            }
            //Response.Redirect(strRedirURL, false);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        string strFilePath = Request.Path.ToUpper();
        string strAdminUserId = "", strCamperLoginId = "";
        string strSSL = ConfigurationManager.AppSettings["SSLFlag"].ToUpper();

        try
        {
            if (Request.Url.AbsoluteUri.Contains("Summary.aspx"))
            {
                lblHeading.Text = "Section II:  Program Description";
            }
            else if (Request.Url.AbsoluteUri.Contains("Step2_2.aspx"))
            {
                lblHeading.Text = "Section III:  Detailed Camper Information";
            }
            else if (Request.Url.AbsoluteUri.Contains("Step2_coupon.aspx"))
            {
                lblHeading.Text = "Section III:  Camp Coupon";
            }
            else if (Request.Url.AbsoluteUri.Contains("Step2_3.aspx"))
            {
                lblHeading.Text = "Section IV: Camp and Session Information";
            }            
            else
            {
                lblHeading.Text = "";
            }
            // check for SSL
            if (strSSL.Equals("Y"))
            {
                string strURL = Request.Url.ToString();
                if (strURL.IndexOf("https") < 0)
                {
                    strURL = strURL.Replace("http", "https");
                    Response.Redirect(strURL, false);
                }
            }

            //check for session
            strCamperLoginId = Convert.ToString(Session["CamperLoginID"]);
            strAdminUserId = Convert.ToString(Session["UsrID"]);

            if (string.IsNullOrEmpty(strCamperLoginId) && string.IsNullOrEmpty(strAdminUserId) && strFilePath.IndexOf("HOME.ASPX") < 0 && strFilePath.IndexOf("NEWUSERREGISTRATION.ASPX") < 0)
            {
                //to redirect the user to Home.aspx
                Response.Redirect("~/Error.aspx?app=camper", false);
            }
            else
            {
                //to get the Logged in UserId
                if (Session["UsrID"] != null)
                    _sUserId = Session["UsrID"].ToString();

                _sCamperUserId = ConfigurationManager.AppSettings["CamperModifiedBy"].ToString();
                
                if (!Page.IsPostBack)
                {
                    //to enable the admin section based on the logged in user
                    EnableAdminSections();
                }
                //to disable the controls if the Camper has submitted the application or the Admin has modified
                //the camper application

				bool isEligibleContactParentsAgain = false;
				if (Session["STATUS"] != null)
					if (Convert.ToInt16(Session["STATUS"]) == (int)StatusInfo.EligibleContactParentsAagain)
						isEligibleContactParentsAgain = true;

				if (!isEligibleContactParentsAgain)
					MakeQuestionnaireReadonly();

                getInfo();
            }


        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    //to get the user id the aspx pages
    public string UserId
    {
        get 
        {
            if (_sUserId == "")
                _sUserId = CamperUserId;
            return _sUserId; 
        }
    }

    //to get the Camper User Id the aspx pages
    public string CamperUserId
    {
        get 
        { return _sCamperUserId; }
    }

    public string CampYear
    {
        get
        {
            if (Session["CampYear"] != null)
            {
                _campYear = (string)Session["CampYear"].ToString();
            }            
            else
            {
                _campYear = Application["CampYear"].ToString();
            }
            return _campYear;
        }

        set 
        {
            General _objGen = new General();
            DataSet dsCampYear = _objGen.GetCurrentYear();
            if (dsCampYear.Tables[0].Rows.Count > 0)
            {
                Session["CampYear"] = dsCampYear.Tables[0].Rows[0]["CampYear"].ToString();
            }
            //if (Session["CampYear"] == null)
            //{
            //    Session["CampYear"] = DateTime.Now.Year;
            //}
        
        }
    }

    //to get the save & exit url for Camper User / Admin
    public string SaveandExitURL
    {
        get
        {
            if (!string.IsNullOrEmpty(UserId) && UserId != CamperUserId)
            {
                string url = Request.Url.GetLeftPart(UriPartial.Authority);
                url = url  + ConfigurationManager.AppSettings["SaveExitAdminRedirURL"].ToString();
                _sSaveandExitURL = url;
            }
            else
            {
                string url = Request.Url.GetLeftPart(UriPartial.Authority);
                url = url + ConfigurationManager.AppSettings["SaveExitRedirURL"].ToString();
                _sSaveandExitURL = url;
            }

            return _sSaveandExitURL;
        }
    }
    public string CheckCamperUser
    {
         get
        {
            if (!string.IsNullOrEmpty(UserId) && UserId != CamperUserId)
            {
                _sCheckUser="No";
            }
            else
            {
                _sCheckUser = "Yes";
            }

            return _sCheckUser;
        }
    }
    
    //to get the save & exit url for Camper User / Admin
    public string CamperRedirURL
    {
        get
        {
            _sCamperRedirURL = ConfigurationManager.AppSettings["SaveExitRedirURL"].ToString();
            return _sCamperRedirURL;
        }
    }

    public void setUserId()
    {
        if (Session["UsrID"] != null)
            _sUserId = Session["UsrID"].ToString();

        _sCamperUserId = ConfigurationManager.AppSettings["CamperModifiedBy"].ToString();
    }

    //to enable the admin panels
    void EnableAdminSections()
    {
        //to enable the admin panel in all the child pages whereever "PnlAdmin" is present
        if (!string.IsNullOrEmpty(UserId))
        {
            if (UserId != CamperUserId)  //then he/she is a admin
            {
               
                Panel adminPanel;
                Button btnAdmin, btnSaveandExit, btnPrevious;
                RequiredFieldValidator reqfld;
                adminPanel = (Panel) Content.FindControl("PnlAdmin");
                btnAdmin = (Button) Content.FindControl("btnReturnAdmin");
                btnSaveandExit = (Button) Content.FindControl("btnSaveandExit");
                btnPrevious = (Button) Content.FindControl("btnPrevious");
                reqfld = (RequiredFieldValidator) Content.FindControl("reqfldComments");

                if (adminPanel != null)
                    adminPanel.Visible = true;
                if (btnAdmin != null)
                    btnAdmin.Visible = true;
                if (btnSaveandExit != null)
                    btnSaveandExit.CausesValidation = true;
                if (btnPrevious != null)
                    btnPrevious.CausesValidation = true;
                //if (reqfld != null)
                //    //reqfld.Enabled = true;

                // Disable validators on normal sectios
                for (int i = 1; i <= 2; i++)
                {
                    Panel PnlQuestion = (Panel) Content.FindControl("Panel" + i.ToString());
                    if (PnlQuestion != null)
                    {
                        //PnlQuestion.Enabled = false;
                        foreach (Control ctl in PnlQuestion.Controls)
                        {
                            if ((ctl.ID != null) && (ctl.ID.CompareTo("CusValComments1") != 0) &&
                                (ctl.ID.CompareTo("CusValComments") != 0))
                            {
                                switch (ctl.GetType().Name.ToUpper())
                                {
                                    case "CUSTOMVALIDATOR":
                                        ((CustomValidator) ctl).Enabled = false;
                                        break;
                                    case "REQUIREDFIELDVALIDATOR":
                                        ((RequiredFieldValidator) ctl).Enabled = false;
                                        break;
                                    case "RANGEVALIDATOR":
                                        ((RangeValidator) ctl).Enabled = false;
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            //added by Sandhya jul 02
            //string strFJCAdmin = ConfigurationManager.AppSettings["FJCADMIN"];

            string strSecondApprover = ConfigurationManager.AppSettings["APPROVER"];
            string strRole = (string)Session["RoleID"];
            if (strRole != strSecondApprover)
            {
                 string strFJCID;
                 DataSet dsApplStatus = new DataSet();
                 CamperApplication objCamperAppl = new CamperApplication();
                 DataRow dr;
                 Panel PnlQuestions;

                 int status;
                 int iCount;
                 try
                 {
                     if (Session["FJCID"] != null)
                     {
                         strFJCID = Session["FJCID"].ToString();

                         //if (UserId != CamperUserId)  //then he/she is a admin
                         //{
                         dsApplStatus = objCamperAppl.getStatus(strFJCID);
                         iCount = dsApplStatus.Tables[0].Rows.Count;
                         if (iCount > 0)
                         {
                             dr = dsApplStatus.Tables[0].Rows[0];
                             //to get the status
                             //if (!dr["STATUS"].Equals(DBNull.Value))
                             status = Convert.ToInt16(dr["STATUS"]);


                             //If Status is 'Payment requested' then disable the questionnaire for Admin
                             if (status == 25)
                             {
                                 //to disable the controls in the panel (Panel1 and Panel2 in all the questionnaire)
                                 for (int i = 1; i <= 2; i++)
                                 {
                                     PnlQuestions = (Panel) Content.FindControl("Panel" + i.ToString());
                                     if (PnlQuestions != null)
                                     {
                                         //PnlQuestion.Enabled = false;
                                         foreach (Control ctl in PnlQuestions.Controls)
                                         {
                                             switch (ctl.GetType().Name.ToUpper())
                                             {
                                                 case "BUTTON": //enable the buttons to navigate
                                                     ((Button) ctl).Enabled = true;
                                                     break;
                                                 case "LABEL":
                                                     ((Label) ctl).Enabled = false;
                                                     break;
                                                 case "TEXTBOX":
                                                     ((TextBox) ctl).Enabled = false;
                                                     break;
                                                 case "RADIOBUTTON":
                                                     ((RadioButton) ctl).Enabled = false;
                                                     break;
                                                 case "RADIOBUTTONLIST":
                                                     ((RadioButtonList) ctl).Enabled = false;
                                                     break;
                                                 case "CHECKBOX":
                                                     ((CheckBox) ctl).Enabled = false;
                                                     break;
                                                 case "CHECKBOXLIST":
                                                     ((CheckBoxList) ctl).Enabled = false;
                                                     break;
                                                 case "DROPDOWNLIST":
                                                     ((DropDownList) ctl).Enabled = false;
                                                     break;
                                                 case "PANEL":
                                                     ((Panel) ctl).Enabled = false;
                                                     break;
                                                 case "CUSTOMVALIDATOR":
                                                     ((CustomValidator) ctl).Enabled = false;
                                                     break;
                                                 case "REQUIREDFIELDVALIDATOR":
                                                     ((RequiredFieldValidator) ctl).Enabled = false;
                                                     break;
                                                 case "RANGEVALIDATOR":
                                                     ((RangeValidator) ctl).Enabled = false;
                                                     break;
                                                 case "ENROLLMENT_REGISTERCONTROLS_ASCX":
                                                     if (ctl.Controls.Count > 1)
                                                     {
                                                         for (int cnt = 0; cnt < ctl.Controls.Count; cnt++)
                                                         {
                                                             if (ctl.Controls[cnt].GetType().Name.ToUpper() == "RADIOBUTTON")
                                                             {
                                                                 ((RadioButton)ctl.Controls[cnt]).Enabled = false;
                                                             }

                                                             if (ctl.Controls[cnt].GetType().Name.ToUpper() == "LABEL")
                                                             {
                                                                 ((Label)ctl.Controls[cnt]).Enabled = false;
                                                             }
                                                         }
                                                     }
                                                     break;
                                             }
                                         }
                                     }
                                 }
                             }
                         }
                         //}
                     }
                 }
                 finally
                 {
                     objCamperAppl = null;
                     dsApplStatus = null;
                 }


             }

        }
    }

    //to make the step1, step2, step 3 of the Questionnaire readonly if the camper has already
    //submitted the application (or) the application has been modified by the Admin
    private void MakeQuestionnaireReadonly()
    {
        string strFJCID;
        DataSet dsApplSubmitInfo = new DataSet();
        CamperApplication objCamperAppl = new CamperApplication();
        DataRow dr;
        Panel PnlQuestion;
        string strSubmittedDate;
        int iModifiedBy;
        int iCount;
        try
        {
            if (Session["FJCID"] != null)
            {
                strFJCID = Session["FJCID"].ToString();
                strSubmittedDate = string.Empty;
                iModifiedBy = Convert.ToInt16(CamperUserId);
                if (!string.IsNullOrEmpty(strFJCID) && UserId == CamperUserId)
                {
                    dsApplSubmitInfo = objCamperAppl.GetApplicationSubmittedInfo(strFJCID);
                    iCount = dsApplSubmitInfo.Tables[0].Rows.Count;
                    if (iCount > 0)
                    {
                        dr = dsApplSubmitInfo.Tables[0].Rows[0];
                        //to get the submitted date
                        if (!dr["SUBMITTEDDATE"].Equals(DBNull.Value))
                            strSubmittedDate = dr["SUBMITTEDDATE"].ToString();

                        //to get the modified by user6
                        if (!dr["MODIFIEDUSER"].Equals(DBNull.Value))
                            iModifiedBy = Convert.ToInt16(dr["MODIFIEDUSER"]);

                        //to get the modified by user6
                        int status = 0;
                        if (!dr["Status"].Equals(DBNull.Value))
                            status = Convert.ToInt32(dr["Status"]);

                        //Camper Application has been submitted (or) the Application has been modified by a Admin
                        if (!string.IsNullOrEmpty(strSubmittedDate) || (iModifiedBy != Convert.ToInt16(CamperUserId) && iModifiedBy > 0 && status != (int)StatusInfo.WinnerPJLottery ))
                        {
                            //to disable the controls in the panel (Panel1 and Panel2 in all the questionnaire)
                            for (int i = 1; i <= 2; i++)
                            {
                                PnlQuestion = (Panel)Content.FindControl("Panel" + i.ToString());
                                if (PnlQuestion != null)
                                {
                                    //PnlQuestion.Enabled = false;
                                    foreach(Control ctl in PnlQuestion.Controls)
                                    {
                                        switch (ctl.GetType().Name.ToUpper())
                                        {
                                            case "BUTTON": //enable the buttons to navigate
                                                ((Button)ctl).Enabled = true;
                                                break;
                                            case "LABEL":
                                                ((Label)ctl).Enabled = false;
                                                break;
                                            case "TEXTBOX":
                                                ((TextBox)ctl).Enabled = false;
                                                break;
                                            case "RADIOBUTTON":
                                                ((RadioButton)ctl).Enabled = false;
                                                break;
                                            case "RADIOBUTTONLIST":
                                                ((RadioButtonList)ctl).Enabled = false;
                                                break;
                                            case "CHECKBOX":
                                                ((CheckBox)ctl).Enabled = false;
                                                break;
                                            case "CHECKBOXLIST":
                                                ((CheckBoxList)ctl).Enabled = false;
                                                break;
                                            case "DROPDOWNLIST":
                                                ((DropDownList)ctl).Enabled = false;
                                                break;
                                            case "PANEL":
                                                ((Panel)ctl).Enabled= false;
                                                break;
                                            case "CUSTOMVALIDATOR":
                                                ((CustomValidator)ctl).Enabled = false;
                                                break;
                                            case "REQUIREDFIELDVALIDATOR":
                                                ((RequiredFieldValidator)ctl).Enabled = false;
                                                break;
                                            case "RANGEVALIDATOR":
                                                ((RangeValidator)ctl).Enabled = false;
                                                break;
                                            case "ENROLLMENT_REGISTERCONTROLS_ASCX":
                                                if (ctl.Controls.Count > 1)
                                                {
                                                    for (int cnt = 0; cnt < ctl.Controls.Count; cnt++)
                                                    {
                                                        if (ctl.Controls[cnt].GetType().Name.ToUpper() == "RADIOBUTTON" )
                                                        {
                                                            ((RadioButton)ctl.Controls[cnt]).Enabled = false;
                                                        }

                                                        if (ctl.Controls[cnt].GetType().Name.ToUpper() == "LABEL")
                                                        {
                                                            ((Label)ctl.Controls[cnt]).Enabled = false;
                                                        }
                                                    }
                                                }
                                                break;
                                           }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        finally
        {
            objCamperAppl = null;
            dsApplSubmitInfo = null;
        }
    }

    //added by sandhya 07/07
     void getInfo()
     {
        
         Panel adminPanel = (Panel)Content.FindControl("PnlAdmin");
         Label lbltext = (Label)Content.FindControl("Label5");
         Label lbltext1 = (Label)Content.FindControl("Label9"); 
     }


}
