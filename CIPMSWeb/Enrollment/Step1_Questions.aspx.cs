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

public partial class Step1_Questions : System.Web.UI.Page
{
    private CamperApplication CamperAppl;
    private SrchCamperDetails _objCamperDet = new SrchCamperDetails();
    private General objGeneral;
    private Boolean bPerformUpdate;
    private UserDetails userInfo;
    private string strFedId = null;
    private bool isinLACIP = false;
    private bool isinLALookup = false;
    private bool isinOC = false;
    private bool isinOCLookup = false;
    private string nextFedUrl = null;
    private int camperReturnCount = 0;
    private bool isinJWestLA = false;
    private bool isinJWestLALookup = false;
    private bool isinJWest = false;
    private bool isinJWestLookup = false;

    private string _strJWestFedId;
    private string _strJWestLAFedId;
    private string _strOrangeFedId;
    private string _strNationalFedId;
    private string _strLACIPFedId;
    private string _strSanDiegoFedId;

    private string strJWestURL = "~/Enrollment/JWest/Summary.aspx";
    private string strJWestLAURL = "~/Enrollment/JWestLA/Summary.aspx";
    private string strOrangeURL = "~/Enrollment/Orange/Summary.aspx";
    private string strNationalURL = "~/Enrollment/Step1_NL.aspx";
    private string strLACIPURL = "~/Enrollment/LACIP/Summary.aspx";
    private string strSanDiegoURL = "~/Enrollment/SanDiego/Summary.aspx";
    private string strJewishSchoolValue = "4";
    
    protected void Page_Init(object sender, EventArgs e)
    {
        btnNext.Click += new EventHandler(btnNext_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click+=new EventHandler(btnReturnAdmin_Click);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        ddlGrade.SelectedIndexChanged += new EventHandler(ddlGrade_SelectedIndexChanged);
        RadioBtnQ2.SelectedIndexChanged += new EventHandler(RadioBtnQ2_SelectedIndexChanged);
		RadioBtnQ1.SelectedIndexChanged += new EventHandler(RadioBtnQ1_SelectedIndexChanged);
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
                Response.Redirect(strRedirURL,false);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CamperAppl = new CamperApplication();
            objGeneral = new General();
            _strJWestFedId = ConfigurationManager.AppSettings["JWest"];
            _strJWestLAFedId = ConfigurationManager.AppSettings["JWestLA"];
            _strOrangeFedId = ConfigurationManager.AppSettings["Orange"];
            _strNationalFedId = ConfigurationManager.AppSettings["NationalLanding"];
            _strLACIPFedId = ConfigurationManager.AppSettings["LACIP"];
            _strSanDiegoFedId = ConfigurationManager.AppSettings["SanDiego"];

            if (!Page.IsPostBack)
            {
                if (Session["ZIPCODE"] != null)
                    hdnZIPCODE.Value = Session["ZIPCODE"].ToString();
            }

            // Get user's federation or probable federation
            if (objGeneral.IsApplicationSubmitted(Session["FJCID"].ToString()))
            {   // federation can't be changed
                strFedId = getFederationId();
            }
            else
            {
                DataSet dsCamper = new DataSet();
                dsCamper = _objCamperDet.getReturningCamperDetails(UserInfo.FirstName, UserInfo.LastName, UserInfo.DateofBirth);

                 bool isexceededcount=numbercapCheck();
                 if (dsCamper.Tables[0].Rows.Count > 0)
                 {
                     strFedId = GetFederationforZIP();
                 }
                 else //If camper is not returning camper --first timer
                 {
                     //If count exceeded the limit
                     if (!isexceededcount)
                     {
                         //if LACode session is not null then setting the federation id as 23(LACIP)
                         if (UserInfo.NLCode != null)
                         {
                             if (UserInfo.NLCode.ToUpper() == "LA5771")
                             {
                                 strFedId = "23";
                             }
                             else if (UserInfo.NLCode.ToUpper() == "SD5771")
                             {
                                 strFedId = "72";
                             }
                             else if (UserInfo.NLCode.ToUpper() == "OC5771")
                             {
                                 strFedId = "22";
                             }
                             else
                                 strFedId = GetFederationforZIP();
                         }
                         else
                         {
                             strFedId = GetFederationforZIP();
                         }
                     }
                     else
                     {
                         strFedId = GetFederationforZIP();
                     }
                 }

            }

            if (strFedId.Equals(_strLACIPFedId))
            {
                isinLACIP = true;
                DataSet dsLAHist = _objCamperDet.getReturningCamperDetails(UserInfo.FirstName, UserInfo.LastName, userInfo.DateofBirth);
                if (dsLAHist.Tables[0].Rows.Count > 0)
                {
                    isinLALookup = true;
                    strFedId = dsLAHist.Tables[0].Rows[0]["federationid"].ToString();
                    camperReturnCount = dsLAHist.Tables[0].Rows.Count;
                    nextFedUrl = dsLAHist.Tables[0].Rows[0]["NavigationURL"].ToString();
                }
            }
            if (strFedId.Equals(_strJWestLAFedId))
            {
                isinJWestLA = true;
                DataSet dsLAHist = _objCamperDet.getReturningCamperDetails(UserInfo.FirstName, UserInfo.LastName, userInfo.DateofBirth);
                if (dsLAHist.Tables[0].Rows.Count > 0)
                {
                    isinJWestLALookup = true;
                    strFedId = dsLAHist.Tables[0].Rows[0]["federationid"].ToString();
                    camperReturnCount = dsLAHist.Tables[0].Rows.Count;
                    nextFedUrl = dsLAHist.Tables[0].Rows[0]["NavigationURL"].ToString();
                }
            }
            if (strFedId.Equals(_strOrangeFedId))
            {
                isinOC = true;
                DataSet dsOCHist = _objCamperDet.getReturningCamperDetails(UserInfo.FirstName, UserInfo.LastName, userInfo.DateofBirth);
                if (dsOCHist.Tables[0].Rows.Count > 0)
                {
                    isinOCLookup = true;
                    strFedId = dsOCHist.Tables[0].Rows[0]["federationid"].ToString();
                    camperReturnCount = dsOCHist.Tables[0].Rows.Count;
                    nextFedUrl = dsOCHist.Tables[0].Rows[0]["NavigationURL"].ToString();
                }
            }
            if (strFedId.Equals(_strJWestFedId))
            {
                //hdnISJWest.Value = "Y";
                isinJWest = true;
                DataSet dsOCHist = _objCamperDet.getReturningCamperDetails(UserInfo.FirstName, UserInfo.LastName, userInfo.DateofBirth);
                if (dsOCHist.Tables[0].Rows.Count > 0)
                {
                    isinJWestLookup = true;
                    strFedId = dsOCHist.Tables[0].Rows[0]["federationid"].ToString();
                    camperReturnCount = dsOCHist.Tables[0].Rows.Count;
                    nextFedUrl = dsOCHist.Tables[0].Rows[0]["NavigationURL"].ToString();
                }
            }
            //else
            //{
            //    hdnISJWest.Value = "N";
            //}
            
            SetSubmittedAdminUserFlags();

           
            if (!Page.IsPostBack)
            {
                // added by siva for LA change -- 02/13/2009
                
                //If the camper entered an LA zip code and was not found in the lookup, then this question will be enabled. 
                //if ((isinLACIP && !isinLALookup) || (isinJWestLA && !isinJWestLALookup) || (isinOC && !isinOCLookup))
                //    PnlQ1b.Visible = true;
                //else
                //    PnlQ1b.Visible = false;
                
                
                //*************************** beg
                //TV: 03/2009 - Issue # A-016 - show message for existing camper who already received grant - if for OC/JWest/JWestLA or LACIP Federations -
                //this includes separate messages if they are "Returning 1st time camper" (aka going to camp 2nd time) or a "Returning 2nd time camper" 
                //(aka - going to camp a 3rd time) The above terms in "quotes" represent terminology from FJC.

                //hide "prior camper message" - this is the default 
                lblPriorCamperMessag.Text = "";
                lblPriorCamperMessag.Visible = false;

                //If the camper entered an LA zip code and was not found in the lookup, then this question will be enabled. 
                if (isinLALookup || isinOCLookup || isinJWestLALookup)
                {
                    string sMessage = "";
                    string sPossibleErrorMessage = "";  

                    DataSet dsData = null;
                    DataRow dr;

                    int isjwestLAEligible = 0;
                    //based on the return count - get the appropriate user message from the database
                    if (camperReturnCount == 1 || camperReturnCount == 2)
                    {
                        if (strFedId == _strJWestFedId)
                        {
                            if (camperReturnCount == 1)
                            {
                                dsData = objGeneral.GetConfigValue("ReturningFirstTime_JWest");
                            }
                            else if (camperReturnCount == 2)
                            {
                                dsData = objGeneral.GetConfigValue("ReturningSecondTime_JWest");
                            }
                        }
                        else if (strFedId == _strJWestLAFedId)
                        {
                            if (camperReturnCount == 1)
                            {
                                dsData = objGeneral.GetConfigValue("ReturningFirstTime_JWestLA");
                            }
                            else if (camperReturnCount == 2)
                            {
                                DataSet dsJwestLAHist = _objCamperDet.getReturningCamperDetails(UserInfo.FirstName, UserInfo.LastName, userInfo.DateofBirth);
                                int days1 = Convert.ToInt32(dsJwestLAHist.Tables[0].Rows[0]["days"].ToString());
                                int days2 = Convert.ToInt32(dsJwestLAHist.Tables[0].Rows[1]["days"].ToString());
                                if ((days1 >= 12) && (days1 < 18) && (days2 >= 12) && (days2 < 18))
                                {
                                    isjwestLAEligible = 1;
                                }
                                else
                                {
                                    dsData = objGeneral.GetConfigValue("ReturningSecondTime_JWestLA");

                                }
                            }
                                
                        }
                        else if (strFedId == _strOrangeFedId)
                        {
                            if (camperReturnCount == 1)
                            {
                                dsData = objGeneral.GetConfigValue("ReturningFirstTime_OrangeCounty");
                            }
                            else if (camperReturnCount == 2)
                            {
                                dsData = objGeneral.GetConfigValue("ReturningSecondTime_OrangeCounty");
                            }
                        }
                        else if (strFedId == _strLACIPFedId)
                        {
                            if (camperReturnCount == 1)
                            {
                                dsData = objGeneral.GetConfigValue("ReturningFirstTime_LACIP");
                            }
                            else if (camperReturnCount == 2)
                            {
                                dsData = objGeneral.GetConfigValue("ReturningSecondTime_LACIP");
                            }
                        }

                        //possible error message, may be needed in more than one place, so capture it now for possible reuse
                        sPossibleErrorMessage = "ERROR: Our records indicate that the camper may have received a grant in the past. " +
                                                "However an unexpected error occurred while trying to retrieve a \"returning camper\" message from our database. " +
                                                "Please notify us of this problem using the contact information found at the bottom of this page."; 

                        //capture the ConfigValue
                        if (dsData != null && dsData.Tables[0].Rows.Count > 0)
                        {
                            dr = dsData.Tables[0].Rows[0];

                            if (DBNull.Value.Equals(dr["ConfigValue"]) == false)
                            {
                                sMessage = dr["ConfigValue"].ToString();
                            }
                            else
                            {
                                //unexpected error or problem
                                sMessage = sPossibleErrorMessage;
                            }
                        }
                        else
                        {
                            //unexpected error or problem
                            sMessage = sPossibleErrorMessage;
                        }
                    }
                    else
                    {
                        sMessage = "ERROR: Our records indicate that the camper may have received a grant in the past. " +
                                   "However a \"return count\" of " + camperReturnCount.ToString() + " is not a valid number in our system. " +
                                   "Please notify us of this problem using the contact information found at the bottom of this page.";
                    }

                    //if a message is defined, then show it to the user
                    if (sMessage.Length > 0)
                    {
                        if (isjwestLAEligible == 1)
                        {
                            lblPriorCamperMessag.Text = "";
                            lblPriorCamperMessag.Visible = false;
                        }
                        else
                        {
                            lblPriorCamperMessag.Text = sMessage;
                            lblPriorCamperMessag.Visible = true;
                        }
                    }
                }
                //*************************** end

                //to get the camper schools in the dropdownlist
                getSchoolList();
                //to fill the grade dropdown with values
                getGrades();
                //to get the FJCID which is stored in session

                if (Session["FJCID"] != null)
                {
                    hdnFJCID.Value = (string)Session["FJCID"];
                    getCamperAnswers();
                    //string strGrade = ddlGrade.SelectedValue;
                    //if (strGrade == "6" || strGrade == "7" || strGrade == "8" || strGrade == "9")
                    //{
                    //    enableWarningMessage();
                    //}
                }
                ddlCamperSchool.Attributes.Add("onchange", "EnableSchoolTextbox(this,'" + txtCamperSchoolOthers.ClientID + "');");
                
                //string strFedId = GetFederationforZIP();
                //if (!string.IsNullOrEmpty(strFedId))
                    //ddlGrade.Attributes.Add("onchange", "windowOCopen('" + strFedId + "');");
                
        }
            if (Panel2.Visible)
            {
                //to set the javascript function for radio onclick for Q2
                foreach (ListItem li in RadioBtnQ2.Items)
                {
                    li.Attributes.Add("onclick", "enableSchool(this,'" + PnlQ3.ClientID + "','" +
                                    txtCamperSchoolOthers.ClientID + "','" + ddlCamperSchool.ClientID + "');");
                }



                //to set the status of the Question panel based on the option selected
                setPanelStatus();
            }
            //foreach (ListItem li in RadioBtnQ1.Items)
            //{
            //    li.Attributes.Add("onclick", "openalert(this);");

            //}
			//foreach (ListItem li in RadioBtnQ1.Items)
			//{                
			//    li.Attributes.Add("OnClick", "JavaScript:popupCall(this,'JWestFirstTimerQuestionMessage','Message',false,'step1_Questions');");
			//}
            
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    
    void Page_Unload(object sender, EventArgs e)
    {
        CamperAppl = null;
        objGeneral = null;
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
                ProcessCamperAnswers();
                //Session["FJCID"] = null;
                //Session["ZIPCODE"] = null;
                //Session["FedId"] = null;
               // Session.Abandon();
                //Response.Redirect(strRedirURL,false);
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
                ProcessCamperAnswers();
                Session["FJCID"] = hdnFJCID.Value;
                Response.Redirect("Step1.aspx", false);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    void btnNext_Click(object sender, EventArgs e)
    {
        string strURL, strFEDID;
        string strFJCID, strComments, strModifiedBy;
        string strSchoolType;
        Boolean bCamperEligibility;       
        
		//try
		//{
            strModifiedBy = Master.UserId;

            if (Session["FJCID"] != null)
            {
                if (objGeneral.IsApplicationSubmitted(Session["FJCID"].ToString()))
                {
                    SubmittedApplicationRedirection();
                }
            }
            //method to redirect based on jwest grant question answer

            JwestGrantEligibility();
            //int check = 0;
            //if (Session["LACode"] != null)
            //{
            //    DataSet dsFed = new DataSet();                    
            //    dsFed = objGeneral.GetFederationForZipCode(Session["ZIPCODE"].ToString());
            //    if (dsFed.Tables.Count > 0)
            //    {
            //        for (int i = 0; dsFed.Tables[0].Rows.Count > i; i++)
            //        {
            //            if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "3" || dsFed.Tables[0].Rows[i]["Federation"].ToString() == "4")
            //            {
            //                check = 1;
            //            }
            //        }
            //    }
            //}
            DataSet dsCamper = new DataSet();
            dsCamper = _objCamperDet.getReturningCamperDetails(UserInfo.FirstName, UserInfo.LastName, UserInfo.DateofBirth);

             bool isexceededcount=numbercapCheck();
           
             if (dsCamper.Tables[0].Rows.Count > 0)
             {

             }
             else //If camper is not returning camper
             {
                 //If count exceeded the limit
                 if (!isexceededcount)
                 {
                     if (UserInfo.NLCode != null)
                     {
                         if (UserInfo.NLCode.ToUpper() == "SD5771")
                         {
                             if (Session["FJCID"] != null && Session["FedId"] != null)
                                 CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), Session["FedId"].ToString());
                             ProcessCamperAnswers();
                             Response.Redirect("Sandiego/Summary.aspx");
                         }
                         else if (UserInfo.NLCode.ToUpper() == "OC5771")
                         {
                             if (Session["FJCID"] != null && Session["FedId"] != null)
                                 CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), Session["FedId"].ToString());
                             ProcessCamperAnswers();
                             Response.Redirect("Orange/Summary.aspx");
                         }
                         else if (UserInfo.NLCode.ToUpper() == "LA5771")
                         {
                             if (Session["FJCID"] != null && Session["FedId"] != null)
                                 CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), Session["FedId"].ToString());
                             ProcessCamperAnswers();
                             Response.Redirect("LACIP/Summary.aspx");

                         }
                     }
                 }
             }

            //if session LACode is not null and the zipcode is not related to JWest/LA 
            //then it has to redirect to the LACIP Summary page regardless of zipcode.
            //if (check != 1 && Session["LACode"] != null)
            //{
            //    if(Session["FJCID"] != null && Session["FedId"] != null)
            //        CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), Session["FedId"].ToString());
            //    ProcessCamperAnswers();
            //    Response.Redirect("LACIP/Summary.aspx");                   

            //}
            //else
            //{

                if (strModifiedBy != "")
                    checkNationalProgramRedirection();

                strURL = CheckFederation(out bCamperEligibility);

                if (strURL == strNationalURL)
                {
                   Redirection_Logic _objRedirectionLogic = new Redirection_Logic();
                    _objRedirectionLogic.GetNextFederationDetails(Session["FJCID"].ToString());
                    strURL = _objRedirectionLogic.NextFederationURL;
                    int nextFedId = _objRedirectionLogic.NextFederationId;
                    hdnFEDID.Value = nextFedId.ToString();
                  
                }


                //fed id will be set to hidden variable in CheckFederation() method
                strFEDID = hdnFEDID.Value;
                strFJCID = hdnFJCID.Value;
                strComments = txtComments.Text.Trim();
                strModifiedBy = Master.UserId;
                strSchoolType = RadioBtnQ2.SelectedValue;

                //to update the Federation Id for the particular FJCID
                //this will take care of federation changes for a particular application
                //(Fed Id which were not be identified in step1.aspx will be identified here and updated
                if ((strFEDID != string.Empty) && (strURL != strNationalURL))
                    CamperAppl.UpdateFederationId(strFJCID, strFEDID);

                ProcessCamperAnswers();
                             


                //added by sandhya for JWest number cap functionality start
                //If federation is JWest/Jwest-LA
                if (strFEDID == "3" || strFEDID == "4")
                {
                    int nextfederationid;                       
                    if (dsCamper.Tables[0].Rows.Count > 0)
                    {

                    }
                    else //If camper is not returning camper
                    {
                        ////count limits from the config file based on status
                        //int jwestCAPPConfigCount = Convert.ToInt32(ConfigurationManager.AppSettings["JWestCampershipApprovedPaymentPending"].ToString());
                        //int jwestEligibilityConfigCount = Convert.ToInt32(ConfigurationManager.AppSettings["JWestEligiblePendingSchool"].ToString());
                        //int jwestnumbercapConfigCount = Convert.ToInt32(ConfigurationManager.AppSettings["jwestnumbercapcount"].ToString());

                        //bool isexceededcount = false;

                        //int status1 = 14;//campership approved; payment pending
                        ////count from DB for campership approved; payment pending status
                        //int JWestCampershipapprovedCount = CamperAppl.GetJWestFirsttimersCountBasedonStatus(status1);
                        
                        //int status2 = 6;//Eligible Pending School  
                        //int JWestEligiblependingschoolCount = CamperAppl.GetJWestFirsttimersCountBasedonStatus(status2);
                        //int status3 = 7;//Eligible by staff
                        //int JWestEligiblebystaffCount = CamperAppl.GetJWestFirsttimersCountBasedonStatus(status3);
                        
                        //if ((JWestCampershipapprovedCount + JWestEligiblependingschoolCount + JWestEligiblebystaffCount) <= jwestnumbercapConfigCount)
                        //{
                        //    isexceededcount = true;
                        //}

                        //bool isexceededcount = numbercapCheck();
                        //If count exceeded the limit
                        if (!isexceededcount)
                        {                                
                            Redirection_Logic _objRedirectionLogic = new Redirection_Logic();
                            _objRedirectionLogic.GetNextFederationDetails(strFJCID);
                            nextfederationid = _objRedirectionLogic.NextFederationId;
                            CamperAppl.UpdateFederationId(strFJCID, nextfederationid.ToString());
                            Session["FedId"] = nextfederationid.ToString();
                            if (nextfederationid == 48 || nextfederationid == 63)
                                Response.Redirect(_objRedirectionLogic.NextFederationURL);
                            else
                                Response.Redirect("JwestNumberCap.aspx");                                
                            
                        }
                    }
                }

                ////added by sandhya for JWest number cap functionality end


                if (strURL.Equals(string.Empty))  //then no federation exists for the grade entered
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "No Federation exists for the entered Grade";
                }
                else
                {
                    Session["FedId"] = strFEDID;
                    if (bCamperEligibility)
                    {
                        Session["FJCID"] = strFJCID;
                        Session["ZIPCODE"] = hdnZIPCODE.Value;
                        Response.Redirect(strURL, false);
                    }
                    else
                    {
                        CamperAppl.submitCamperApplication(strFJCID, strComments, Convert.ToInt32(strModifiedBy), (int)StatusInfo.SystemInEligible);
                        Panel2.Visible = false;
                        Session["STATUS"] = (int)StatusInfo.SystemInEligible;
                        Response.Redirect("ThankYou.aspx", false);
                    }
                }
		//}
		//catch (Exception ex)
		//{
		//    Response.Write(ex.Message);
		//}
    }
    
	protected void JwestGrantEligibility()
    {
        string strFEDID, strURL, strGrade;
        Boolean bCamperEligibility;       
        strURL = CheckFederation(out bCamperEligibility);
        strFEDID = hdnFEDID.Value;
        //strGrade = ddlGrade.SelectedValue;
        DataSet dsFed;
        string strZipCode;
        int iCount, checkJWest = 0, checkJWestLA = 0, checkLACIP = 0, checkOrange = 0, 
			checkSandiego = 0, checkColarado = 0, checkPalmSprings = 0, checkSanFrancisco = 0, checkSeattle = 0;
        strZipCode = hdnZIPCODE.Value;
        dsFed = objGeneral.GetFederationForZipCode(strZipCode);
        iCount = dsFed.Tables[0].Rows.Count;

        if (iCount > 0)
        {
            for (int i = 0; dsFed.Tables[0].Rows.Count > i; i++)
            {
                if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "3")
                {
                    checkJWest = 1;
                }
                else if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "4")
                {
                    checkJWestLA = 1;     
                } 
                else if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "22")
                {
                    checkOrange = 1;
                }
                else if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "23")
                {
                    checkLACIP = 1;
                }
                else if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "72")
                {
                    checkSandiego = 1;
                }
                else if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "93")
                {
                    checkColarado = 1;
                }
                else if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "95")
                {
                    checkPalmSprings = 1;
                }
				else if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "98")
				{
					checkSanFrancisco = 1;
				}
				else if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "99")
				{
					checkSeattle = 1;
				}
            }
        }
                                                    
        if (checkJWest == 1)
        {
            //need to get fedid and to check whether fedid is 23 redirection to LACIP
            //string strFederationId = null;
            //DataSet fedInfo = objGeneral.GetFedDetailsForFJCID(Session["FJCID"].ToString());
            //if (fedInfo.Tables[0].Rows.Count > 0)
            //{
            //    strFederationId = fedInfo.Tables[0].Rows[0]["FederationID"].ToString();
            //}
            string strFJCID, strAppType, strFJCIDFedId;
            strFJCID = Session["FJCID"] != null ? Session["FJCID"].ToString() : string.Empty;
            strAppType = strFJCIDFedId = string.Empty;
            if (strFJCID != string.Empty)
            {
                CamperApplication oCA = new CamperApplication();
                DataSet dsCamperApplication; dsCamperApplication = oCA.getCamperApplication(strFJCID);
                DataRow drCA; drCA = dsCamperApplication.Tables[0].Rows[0];
                strFJCIDFedId = drCA["FederationId"] != null ? drCA["FederationId"].ToString().ToLower() : string.Empty;
                strAppType = drCA["AppType"] != null ? drCA["AppType"].ToString().ToLower() : string.Empty;
            }
            if ((strFJCIDFedId != string.Empty && strFJCIDFedId == "23") && (strAppType != string.Empty && strAppType == "c"))
            {
                CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), "23");
                Session["FedId"] = "23";
                ProcessCamperAnswers();
                Response.Redirect("LACIP/Summary.aspx");
            }
            else
            {
                //if (strFEDID == "3")
                //{
                //if (strGrade == "6" || strGrade == "7" || strGrade == "8")
                //{
                if (RadioBtnQ1.SelectedValue == "1" || RadioBtnQ1.SelectedValue == "3")
                {
                    if (checkJWestLA == 1)
                    {
                        if (Session["FJCID"] != null)
                            CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), "4");
                        Session["FedId"] = "4";
                        ProcessCamperAnswers();
                        Response.Redirect("JWestLA/Summary.aspx");
                    }
                    else
                    {
                        if (Session["FJCID"] != null)
                            CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), "3");
                        Session["FedId"] = "3";
                        ProcessCamperAnswers();
                        Response.Redirect("JWest/Summary.aspx");
                    }
                }
                else if (RadioBtnQ1.SelectedValue == "2") //sandiego or NL or LACIP or JWest-LA based on zipcode sharing
                {
                    if (checkLACIP == 1)
                    {
                        if (Session["FJCID"] != null)
                            CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), "23");
                        Session["FedId"] = "23";
                        ProcessCamperAnswers();
                        Response.Redirect("LACIP/Summary.aspx");
                    }
                    else if (checkJWestLA == 1)
                    {
                        if (Session["FJCID"] != null)
                            CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), "4");
                        Session["FedId"] = "4";
                        ProcessCamperAnswers();
                        Response.Redirect("JWestLA/Summary.aspx");
                    }
                    else if (checkSandiego == 1)
                    {
                        if (Session["FJCID"] != null)
                            CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), "72");
                        Session["FedId"] = "72";
                        ProcessCamperAnswers();
                        Response.Redirect("SanDiego/Summary.aspx");
                    }
                    else if (checkOrange == 1)
                    {
                        if (Session["FJCID"] != null)
                            CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), "22");
                        Session["FedId"] = "22";
                        ProcessCamperAnswers();
                        Response.Redirect("Orange/Summary.aspx");
                    }
                    else if (checkColarado == 1)
                    {
                        if (Session["FJCID"] != null)
                            CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), "93");
                        Session["FedId"] = "93";
                        ProcessCamperAnswers();
                        Response.Redirect("Colorado/Summary.aspx");
                    }
                    else if (checkPalmSprings == 1)
                    {
                        if (Session["FJCID"] != null)
                            CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), "95");
                        Session["FedId"] = "95";
                        ProcessCamperAnswers();
                        Response.Redirect("PalmSprings/Summary.aspx");
                    }
					else if (checkSanFrancisco == 1)
					{
						if (Session["FJCID"] != null)
							CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), "98");
						Session["FedId"] = "98";
						ProcessCamperAnswers();
						Response.Redirect("SanFrancisco/Summary.aspx");
					}
					else if (checkSeattle == 1)
					{
						if (Session["FJCID"] != null)
							CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), "99");
						Session["FedId"] = "99";
						ProcessCamperAnswers();
						Response.Redirect("Seattle/Summary.aspx");
					}
                    else
                    {
                        //ProcessCamperAnswers();
                        //Response.Redirect(strNationalURL);
                        if (Session["FJCID"] != null)
                        {
                            Redirection_Logic _objRedirectionLogic = new Redirection_Logic();
                            _objRedirectionLogic.GetNextFederationDetails(Session["FJCID"].ToString());
                            int nextfederationid = _objRedirectionLogic.NextFederationId;
                            CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), nextfederationid.ToString());
                            Session["FedId"] = nextfederationid.ToString();
                            ProcessCamperAnswers();
                            if (nextfederationid == 48 || nextfederationid == 63)
                                Response.Redirect(_objRedirectionLogic.NextFederationURL);                                
                            else
                                Response.Redirect(strNationalURL);
                        }
                    }



                    //if (Session["FJCID"] != null)
                    //{
                    //    Redirection_Logic _objRedirectionLogic = new Redirection_Logic();
                    //    _objRedirectionLogic.GetNextFederationDetails(Session["FJCID"].ToString());
                    //    int nextfederationid = _objRedirectionLogic.NextFederationId;
                    //    CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), nextfederationid.ToString());
                    //    Session["FedId"] = nextfederationid.ToString();
                    //ProcessCamperAnswers();
                    //if (nextfederationid == 72)
                    //    Response.Redirect(_objRedirectionLogic.NextFederationURL);
                    //else
                    //    Response.Redirect(strNationalURL);
                    //}
                }

                //}
            }
        }       


    }
    
	protected bool numbercapCheck()
    {
        int jwestnumbercapConfigCount = Convert.ToInt32(ConfigurationManager.AppSettings["jwestnumbercapcount"].ToString());
        bool isexceededcount = false;
        //int status1 = 14;//campership approved; payment pending
        ////count from DB for campership approved; payment pending status
        //int JWestCampershipapprovedCount = CamperAppl.GetJWestFirsttimersCountBasedonStatus(status1);
        //int status2 = 6;//Eligible Pending School  
        //int JWestEligiblependingschoolCount = CamperAppl.GetJWestFirsttimersCountBasedonStatus(status2);
        //int status3 = 7;//Eligible by staff
        //int JWestEligiblebystaffCount = CamperAppl.GetJWestFirsttimersCountBasedonStatus(status3);
        //if ((JWestCampershipapprovedCount + JWestEligiblependingschoolCount + JWestEligiblebystaffCount) <= jwestnumbercapConfigCount)
        int jwestnumbercapCount = CamperAppl.GetJWestFirsttimersCountBasedonStatus();
        if (jwestnumbercapCount <= jwestnumbercapConfigCount)
        {
            isexceededcount = true;
        }
        return isexceededcount;
    }
    
	//schooltype radio button click
    void RadioBtnQ2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           getSchoolList();
           setPanelStatus();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
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
        strFJCID = hdnFJCID.Value;
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

            iRowsAffected = CamperAppl.updateGrade(strFJCID, iGrade, strComments, Convert.ToInt32(strModifiedBy));
        }
    }

    //to check for the federation and redirect the 
    private string CheckFederation(out Boolean bCamperEligibility)
    {
        string strRedirURL = string.Empty;

        if (isinLACIP)
        {
            if (isinLALookup)
            {
                strRedirURL = nextFedUrl;
                hdnFEDID.Value = strFedId;
                bCamperEligibility = true;
            }
            else
            {
                strRedirURL = CheckLACIPRules();
                bCamperEligibility = true;
            }
        }
        else if (isinJWestLA)
        {
            if (isinJWestLALookup)
            {
                strRedirURL = nextFedUrl;
                hdnFEDID.Value = strFedId;
                bCamperEligibility = true;
            }
            else
            {
                strRedirURL = CheckFederationOld(out bCamperEligibility);
            }
        }
        else if (isinOC)
        {
            if (isinOCLookup)
            {
                strRedirURL = nextFedUrl;
                hdnFEDID.Value = strFedId;
                bCamperEligibility = true;
            }
            else
            {
                strRedirURL = CheckOCRules();
                bCamperEligibility = true;
            } 
        }
        else if (isinJWest)
        {
            if (isinJWestLookup)
            {
                strRedirURL = nextFedUrl;
                hdnFEDID.Value = strFedId;
                bCamperEligibility = true;
            }
            else
            {
                strRedirURL = CheckFederationOld(out bCamperEligibility);
            }
        }
        else
        {
            strRedirURL = CheckFederationOld(out bCamperEligibility);
        }

        return strRedirURL;
    }

    private string CheckLACIPRules()
    {
        string strRedirURL = string.Empty;
        string strGrade, strSchoolType, strSchool;
        string strFirstTimeCamper;
        strGrade = ddlGrade.SelectedValue;
        strSchoolType = RadioBtnQ2.SelectedValue;
        //strFirstTimeCamper = RadioBtnQftc.SelectedValue;
        strFirstTimeCamper = RadioBtnQ1.SelectedValue;
        strSchool = ddlCamperSchool.SelectedValue;

        if (strGrade == "6" || strGrade == "7" || strGrade == "8")
        {
            if (strSchoolType == "1" || strSchoolType == "2")
            {
                if (strSchool=="-1") 
                {
                    strRedirURL = CheckJewishdaySchoolRules();
                }
                else
                {
                    if (IsNotBadSchool(strSchool))
                    {
                        //if (strFirstTimeCamper == "1")
                        if (strFirstTimeCamper == "2")
                        {
                            // Not bad school -- first time camper -- public/private school
                            strRedirURL = strJWestLAURL;
                            Session["FedId"] = _strJWestLAFedId;
                            hdnFEDID.Value = _strJWestLAFedId;

                        }
                        else
                        {
                            //bad school -- first time camper -- public/private school
                            strRedirURL = strLACIPURL;
                            Session["FedId"] = _strLACIPFedId;
                            hdnFEDID.Value = _strLACIPFedId;

                        }
                    }
                    else
                    {
                        //bad school --  irrespective of first time camper or not -- public/private school
                        strRedirURL = strLACIPURL;
                        Session["FedId"] = _strLACIPFedId;
                        hdnFEDID.Value = _strLACIPFedId;
                    }
                }
            }
            else if (strSchoolType == "3")
            {
                //if (strFirstTimeCamper == "1")
                if (strFirstTimeCamper == "2")
                {
                    // redirect to Jwest LA for first time campers
                    strRedirURL = strJWestLAURL;
                    Session["FedId"] = _strJWestLAFedId;
                    hdnFEDID.Value = _strJWestLAFedId;
                    
                }
                else
                {
                    // redirect to LACIPURL for not first time campers
                    strRedirURL = strLACIPURL;
                    Session["FedId"] = _strLACIPFedId;
                    hdnFEDID.Value = _strLACIPFedId;
                }
            }
            else
            {
                strRedirURL = CheckJewishdaySchoolRules();
            }
        }
        //else if (strGrade == "1" || strGrade == "2")
        else if (strGrade == "1")
        {
            // redirect to national landing page
            strRedirURL = strNationalURL;
            Session["FedId"] = _strNationalFedId;
            hdnFEDID.Value = _strNationalFedId;
        }
        else
        {
            // redirect to LACIPURL for grades 2-5 or 9-12
            strRedirURL = strLACIPURL;
            Session["FedId"] = _strLACIPFedId;
            hdnFEDID.Value = _strLACIPFedId;
        }

        return strRedirURL;
    }
    
	private string CheckOCRules()
    {

        string strRedirURL = string.Empty;
        string strGrade, strSchoolType, strSchool;
        string strFirstTimeCamper;
        strGrade = ddlGrade.SelectedValue;
        strSchoolType = RadioBtnQ2.SelectedValue;
        //strFirstTimeCamper = RadioBtnQftc.SelectedValue;
        strFirstTimeCamper = RadioBtnQ1.SelectedValue;
        strSchool = ddlCamperSchool.SelectedValue;

        if ( strGrade == "6" || strGrade == "7" || strGrade == "8")
        {
            if (strSchoolType == "1" || strSchoolType == "2")
            {
                if (strSchool == "-1")
                {
                    strRedirURL = CheckOCJewishdaySchoolRules();
                }
                else
                {   //private and public schools // first time camper or not
                    if (IsNotBadSchool(strSchool))
                    {
                        // Not bad school 
                       // if (strFirstTimeCamper == "1")
                        if (strFirstTimeCamper == "2")
                        {
                            strRedirURL = strJWestURL;
                            Session["FedId"] = _strJWestFedId;
                            hdnFEDID.Value = _strJWestFedId;
                        }
                        else
                        {
                            strRedirURL = strOrangeURL;
                            Session["FedId"] = _strOrangeFedId;
                            hdnFEDID.Value = _strOrangeFedId; 
                        }

                    }
                    else
                    {   //bad school 
                        strRedirURL = strNationalURL;
                        Session["FedId"] = _strNationalFedId;
                        hdnFEDID.Value = _strNationalFedId;
                    }
                }
            }
            else if (strSchoolType == "3")
            {
               // if (strFirstTimeCamper == "1")
                if (strFirstTimeCamper == "2")
                {
                    strRedirURL = strJWestURL;
                    Session["FedId"] = _strJWestFedId;
                    hdnFEDID.Value = _strJWestFedId;
                }
                else
                {
                    strRedirURL = strOrangeURL;
                    Session["FedId"] = _strOrangeFedId;
                    hdnFEDID.Value = _strOrangeFedId;
                }
            }
            else
            {
                strRedirURL = CheckOCJewishdaySchoolRules();
            }
        }
        //else if (strGrade == "3" || strGrade == "4" || strGrade == "5" || strGrade == "9")
        else if (strGrade == "4" || strGrade == "5" || strGrade == "9")
        {
            if (strSchoolType == "1" || strSchoolType == "2")
            {
                //private and public schools // first time camper or not
                if (IsNotBadSchool(strSchool))
                {
                    // Not bad school 
                    strRedirURL = strOrangeURL;
                    Session["FedId"] = _strOrangeFedId;
                    hdnFEDID.Value = _strOrangeFedId;

                }
                else
                {
                    if (strSchool == "-1")
                    {
                        strRedirURL = strOrangeURL;
                        Session["FedId"] = _strOrangeFedId;
                        hdnFEDID.Value = _strOrangeFedId;                         
                    }
                    else
                    {
                        //bad school 
                        strRedirURL = strNationalURL;
                        Session["FedId"] = _strNationalFedId;
                        hdnFEDID.Value = _strNationalFedId;
                    }

                }
            }
            else if (strSchoolType == "3")
            {
                // home school
                strRedirURL = strOrangeURL;
                Session["FedId"] = _strOrangeFedId;
                hdnFEDID.Value = _strOrangeFedId;
            }
            else
            {
                // jewish day school

                if (IsNotBadSchool(strSchool))
                {
                    // Not bad school 
                    strRedirURL = strOrangeURL;
                    Session["FedId"] = _strOrangeFedId;
                    hdnFEDID.Value = _strOrangeFedId;

                }
                else
                {
                    if (strSchool == "-1")
                    {
                        strRedirURL = strOrangeURL;
                        Session["FedId"] = _strOrangeFedId;
                        hdnFEDID.Value = _strOrangeFedId;
                    }
                    else
                    {
                        //bad school 
                        strRedirURL = strNationalURL;
                        Session["FedId"] = _strNationalFedId;
                        hdnFEDID.Value = _strNationalFedId;
                    }
                }

            }
            

        }
        else
        {
            // redirect to national landing page for grade 1-2 and 10-12
            strRedirURL = strNationalURL;
            Session["FedId"] = _strNationalFedId;
            hdnFEDID.Value = _strNationalFedId;
        }

        return strRedirURL;

    }
    
	private string CheckJewishdaySchoolRules()
    {
        string strRedirURL = string.Empty;
        string strGrade, strSchoolType, strSchool;
        string strFirstTimeCamper;
        strGrade = ddlGrade.SelectedValue;
        strSchoolType = RadioBtnQ2.SelectedValue;
        //strFirstTimeCamper = RadioBtnQftc.SelectedValue;
        strFirstTimeCamper = RadioBtnQ1.SelectedValue;
        strSchool = ddlCamperSchool.SelectedValue;
        // if (strFirstTimeCamper == "1")
        if (strFirstTimeCamper == "2")
        {
            if (strSchool == "-1")
            {
                // first time camper -- status will be pending school 
                strRedirURL = strJWestLAURL;
                Session["FedId"] = _strJWestLAFedId;
                hdnFEDID.Value = _strJWestLAFedId;
            }
            else
            {
                if (IsNotBadSchool(strSchool))
                {
                    // first time camper -- not bad school
                    strRedirURL = strJWestLAURL;
                    Session["FedId"] = _strJWestLAFedId;
                    hdnFEDID.Value = _strJWestLAFedId;
                }
                else
                {
                    // bad school 
                    strRedirURL = strLACIPURL;
                    Session["FedId"] = _strLACIPFedId;
                    hdnFEDID.Value = _strLACIPFedId;
                }
            }
        }
        else
        {
            // not a first time camper -- send him to LACIP
            strRedirURL = strLACIPURL;
            Session["FedId"] = _strLACIPFedId;
            hdnFEDID.Value = _strLACIPFedId;

        }
        return strRedirURL;

    }
    
	private string CheckOCJewishdaySchoolRules()
    {
        string strRedirURL = string.Empty;
        string strGrade, strSchoolType, strSchool;
        string strFirstTimeCamper;
        strGrade = ddlGrade.SelectedValue;
        strSchoolType = RadioBtnQ2.SelectedValue;
        //strFirstTimeCamper = RadioBtnQftc.SelectedValue;
        strFirstTimeCamper = RadioBtnQ1.SelectedValue;
        strSchool = ddlCamperSchool.SelectedValue;
        //if (strFirstTimeCamper == "1")
        if (strFirstTimeCamper == "2")
        {
            if (strSchool == "-1")
            {
                // first time camper -- status will be pending school 
                strRedirURL = strJWestURL;
                Session["FedId"] = _strJWestFedId;
                hdnFEDID.Value = _strJWestFedId;
            }
            else
            {
                if (IsNotBadSchool(strSchool))
                {
                    // first time camper -- not bad school
                    strRedirURL = strJWestURL;
                    Session["FedId"] = _strJWestFedId;
                    hdnFEDID.Value = _strJWestFedId;
                }
                else
                {
                    // bad school 
                    strRedirURL = strNationalURL;
                    Session["FedId"] = _strNationalFedId;
                    hdnFEDID.Value = _strNationalFedId;
                }
            }
        }
        else
        {
            if (strSchool == "-1")
            {
                // first time camper -- status will be pending school 
                strRedirURL = strOrangeURL;
                Session["FedId"] = _strOrangeFedId;
                hdnFEDID.Value = _strOrangeFedId;
            }
            else
            {
                // not a first time camper -- send him to LACIP
                if (IsNotBadSchool(strSchool))
                {
                    // first time camper -- not bad school
                    strRedirURL = strOrangeURL;
                    Session["FedId"] = _strOrangeFedId;
                    hdnFEDID.Value = _strOrangeFedId;
                }
                else
                {
                    // bad school 
                    strRedirURL = strNationalURL;
                    Session["FedId"] = _strNationalFedId;
                    hdnFEDID.Value = _strNationalFedId;
                }
            }

        }
        return strRedirURL;

    }
    
	private Boolean IsNotBadSchool(string strSchool)
    {
        CamperApplication oCA = new CamperApplication();
        DataSet dsSchool;
        dsSchool = oCA.GetSchool(Convert.ToInt32(strSchool));
        DataRow drSchool;
        Boolean Approved = false;

        if (dsSchool.Tables[0].Rows.Count > 0)
        {
            drSchool = dsSchool.Tables[0].Rows[0];
            Approved = Convert.ToBoolean(drSchool["Approved"]);
        }

        return Approved;

    }

    private string CheckFederationOld(out Boolean bCamperEligibility)
    {
        DataSet ds;
        string strZipCode, strFEDID = string.Empty, strGrade, strSchoolType, strOverlapFed;
        int iCount;
        DataRow dr;
        string strRedirURL = string.Empty;
        Boolean bEligible = false;
        Boolean bJWest = false, bOrange = false, bNational = false, bLACIP = false, bJWestLA = false, bSanDiego=false;
        strZipCode = hdnZIPCODE.Value;

        ds = objGeneral.GetFederationForZipCode(strZipCode);
        iCount = ds.Tables[0].Rows.Count;

        //string[] JWest = new string[] { "6", "7", "8", "9" };
        string[] JWestLA = new string[] { "6", "7", "8", "9" };
        //string[] Orange = new string[] { "3", "4", "5" };
        string[] JWest = new string[] { "6", "7", "8" };
        string[] Orange = new string[] { "5" , "9"};
        string[] LACIP = new string[] { "2", "3", "4", "5", "10", "11" };
        string[] SanDiego = new string[] { "1", "2", "3", "4", "5", "10", "11", "12" };

        //string[] NationalLandingOverlap = new string[] {"2","10","11","12"};  //where JWest and Orange share the same zip code
        //string[] NationalLandingJWest = new string[] { "2", "3", "4", "5", "9", "10", "11", "12" };  //for JWest Federation
        //string[] NationalLandingOrange = new string[] { "2", "6", "7", "8", "10", "11", "12" };  //for Orange Federation

        strGrade = ddlGrade.SelectedValue;
        strSchoolType = RadioBtnQ2.SelectedValue; //to get the school type
        if (iCount > 0)
        {
            if (iCount == 1)  //then the zipcode is for either JWEST/ORANGE COUNTY/LA CIP / JWEST LA
            {
                dr = ds.Tables[0].Rows[0];
                strFEDID = dr["Federation"].ToString();

                if (strFEDID.Equals(_strJWestFedId))   //JWEST
                {
                    if ((RadioBtnQ1.SelectedValue.Equals("1")) || (RadioBtnQ1.SelectedValue.Equals("3")))
                    {
                        bJWest = true;
                    }
                    else if (Array.IndexOf(JWest, strGrade) >= 0)
                    {
                        bJWest = true;
                    }
                    else
                        bNational = true;
                }
                else if (strFEDID.Equals(_strOrangeFedId)) //ORANGE
                {
                    if (Array.IndexOf(Orange, strGrade) >= 0)
                    {
                        if ((RadioBtnQ1.SelectedValue.Equals("1")) || (RadioBtnQ1.SelectedValue.Equals("3")))
                        {
                            bJWest = true;
                        }
                        else
                        {
                            if (isinOCLookup)
                                bOrange = true;
                            else
                                bNational = true;
                        }
                    }
                    //bOrange = true;
                    else
                        bNational = true;
                }
                else if (strFEDID.Equals(_strLACIPFedId)) //LACIP
                {
                    if (Array.IndexOf(LACIP, strGrade) >= 0)
                        bLACIP = true;
                    else
                        bNational = true;
                }
                else if (strFEDID.Equals(_strJWestLAFedId)) //JWEST LA
                {
                     if ((RadioBtnQ1.SelectedValue.Equals("1")) || (RadioBtnQ1.SelectedValue.Equals("3")))
                     {
                         if (strSchoolType.Equals(strJewishSchoolValue))
                             bLACIP = true;
                         else
                             bJWestLA = true;
                     }
                     else if (Array.IndexOf(JWest, strGrade) >= 0)
                     {
                         if (strSchoolType.Equals(strJewishSchoolValue))
                             bLACIP = true;
                         else
                             bJWestLA = true;
                     }
                     else
                         bNational = true;
                }
                else
                    bNational = true;
            }
            else if (iCount > 1) //then the jwest and orange county sharing the same zip
            {
                strOverlapFed = getOverlapFederation(ds);

                //based on the overlap federation find the federation based on the grade
                switch (strOverlapFed)
                {
                    case "JWESTORANGE":
                        if (Array.IndexOf(Orange, strGrade) >= 0)
                        {
                            if ((RadioBtnQ1.SelectedValue.Equals("1")) || (RadioBtnQ1.SelectedValue.Equals("3")))
                            {
                                bJWest = true;
                            }
                            else
                            {
                                if (isinOCLookup)
                                    bOrange = true;
                                else
                                    bNational = true;
                            }
                        }
                        else if (Array.IndexOf(JWest, strGrade) >= 0)
                            if ((RadioBtnQ1.SelectedValue.Equals("1")) || (RadioBtnQ1.SelectedValue.Equals("3")))
                            {
                                bJWest = true;
                            }
                            else
                            {
                                bOrange = true;
                            }
                        else
                            bNational = true;
                        break;
                    case "LACIPJWESTLA":
                        if (Array.IndexOf(LACIP, strGrade) >= 0)
                            bLACIP = true;
                        else if (Array.IndexOf(JWestLA, strGrade) >= 0)
                        {
                            if ((RadioBtnQ1.SelectedValue.Equals("1")) || (RadioBtnQ1.SelectedValue.Equals("3")))
                            {
                                if (strSchoolType.Equals(strJewishSchoolValue))
                                    bLACIP = true;
                                else
                                    bJWestLA = true;
                            }
                            else
                            {
                                bLACIP = true;
                            }

                        }
                        else
                            bNational = true;
                        break;
                    case "JWESTSANDIEGO":
                        if (strGrade == "9")
                        {
                            if (RadioBtnQ1.SelectedValue.Equals("2"))
                            {
                                bSanDiego = true;
                            }
                            else
                            {
                                bJWest = true;
                            }

                        }
                        else if (Array.IndexOf(SanDiego, strGrade) >= 0)
                            bSanDiego = true;
                        else if (Array.IndexOf(JWest, strGrade) >= 0)
                            bJWest = true;
                        else
                            bNational = true;
                        break;
                    default:
                        bNational = true;
                        break;
                }
            }

            //to check which federation it is and set the fed id and redir URL accordingly    
            if (bJWest)   //if it is jwest
            {
                strRedirURL = strJWestURL;  //go to Jwest
                strFEDID = _strJWestFedId;
                bEligible = true;
            }
            else if (bOrange) //if it is orange
            {
                strRedirURL = strOrangeURL;  //go to Orange
                strFEDID = _strOrangeFedId;
                //if the user have selected jewish school then he/she is ineligible
                if (!strSchoolType.Equals(strJewishSchoolValue))
                    bEligible = true;
            }
            else if (bLACIP)
            {
                strRedirURL = strLACIPURL;  //go to LA CIP
                strFEDID = _strLACIPFedId;
                //if the user have not selected jewish school then he/she is ineligible
                //if (strSchoolType.Equals(strJewishSchoolValue))

                //USER IS ELIGIBLE IRRESPECTIVE OF THE SCHOOL TYPE SELECTED/////////////////
                bEligible = true;
            }
            else if (bJWestLA)
            {
                strRedirURL = strJWestLAURL;  //go to JWest LA
                strFEDID = _strJWestLAFedId;
                bEligible = true;
            }
            else if (bSanDiego)
            {
                strRedirURL = strSanDiegoURL;  //go to SanDiego
                strFEDID = _strSanDiegoFedId;                
                bEligible = true;
            }
            else if (bNational)
            {
                strRedirURL = strNationalURL;  //go to National
                strFEDID = _strNationalFedId;
                bEligible = true;
            }

            //assigning the federation id to the hidden variable
            hdnFEDID.Value = strFEDID;
        }
        else
        {
            strRedirURL = strNationalURL;  //go to National
            strFEDID = _strNationalFedId;
            bEligible = true;
            hdnFEDID.Value = strFEDID;
        }
        bCamperEligibility = bEligible;
        return strRedirURL;
    }

    //to get the Overlapping Federation for the overlapping zip codes
    private string getOverlapFederation(DataSet dsFed)
    {
        int iCount, i;
        string strFEDID, strOverLapFederation=string.Empty;

        string[] JWestOrangeOverlap = new string[] {_strJWestFedId, _strOrangeFedId};
        string[] LACIPJWestLAOverlap = new string[] { _strLACIPFedId, _strJWestLAFedId };
        string[] JWestSandiegoOverlap = new string[] { _strJWestFedId, _strSanDiegoFedId };
        
        iCount = dsFed.Tables[0].Rows.Count;
        if (iCount > 0)
        {
            for (i = 0; i < iCount; i++)
            {
                strFEDID = dsFed.Tables[0].Rows[i]["Federation"].ToString();
                //if it is Jwest and Orange overlap
                if (Array.IndexOf(JWestOrangeOverlap, strFEDID) >= 0)
                {
                    strOverLapFederation = "JWESTORANGE";
                    break;
                }
                else if (Array.IndexOf(LACIPJWestLAOverlap, strFEDID) >= 0)
                {
                    strOverLapFederation = "LACIPJWESTLA";
                    break;
                }
                else if (Array.IndexOf(JWestSandiegoOverlap, strFEDID) >= 0)
                {
                    strOverLapFederation = "JWESTSANDIEGO";
                    break;
                }
            }
        }
        return strOverLapFederation;
    }

    protected void InsertCamperAnswers()
    {
        string strFJCID, strComments;
        int RowsAffected;
        string strModifiedBy, strCamperAnswers; //-1 for Camper (User id will be passed for Admin user)
        
        strFJCID = hdnFJCID.Value;
        
        //to get the comments text (used only by the Admin user)
        strComments = txtComments.Text.Trim();

        //Modified by id taken from the common.master
        strModifiedBy = Master.UserId;

        strCamperAnswers = ConstructCamperAnswers();

        if (strFJCID != "" && strCamperAnswers != "" && strModifiedBy != "" && bPerformUpdate)
            RowsAffected = CamperAppl.InsertCamperAnswers(strFJCID, strCamperAnswers, strModifiedBy, strComments);
        
    }

    //to get the camper answers from the database
    void getCamperAnswers()
    {
        string strFJCID;
        DataSet dsAnswers;
        DataView dv;
        //RadioButton rb;
        string strFilter;
        
        strFJCID = hdnFJCID.Value;
        if (!strFJCID.Equals(string.Empty))
        {
            dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "6", "8", "N");
            if (dsAnswers.Tables[0].Rows.Count > 0) //if there are records for the current FJCID
            {
                dv = dsAnswers.Tables[0].DefaultView;
                //to display answers for the QuestionId 6,7 and 8 for step 2_2_Midsex
                for (int i = 6; i <= 8; i++)
                {
                    strFilter = "QuestionId = '" + i.ToString() + "'";

                    switch (i)
                    {
                        case 6: // assigning the answer for question 1
                            
                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["Answer"].Equals(DBNull.Value))
                                {
                                    ddlGrade.SelectedValue = dr["Answer"].ToString();
                                }
                            }
                            // if grade is seleted "9" enable the second time camper panel.
                           
                            //if (ddlGrade.SelectedValue == "9")
                            //{
                                //PnlQ4.Visible = true;
                                //SetSecondTimeCamper();
                                //if (Session["FedId"] != null)
                                //{
                                //    if (Session["FedId"].ToString() == "72")
                                //    {
                                //        PnlQ1b.Visible = true;
                                //    }
                                //}
                            //}
                            //else
                            //{
                            //    PnlQ4.Visible = false;
                            //}
                            SetJWestGrantQuestion();  
                            //if (ddlGrade.SelectedValue == "6" || ddlGrade.SelectedValue == "7" || ddlGrade.SelectedValue == "8")
                            //{                              
                            //    SetJWestGrantQuestion();                               
                            //}     
                      
                            //CheckSandiegoJWest();
                            break;

                        case 7:// assigning the answer for question 2
                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["OptionID"].Equals(DBNull.Value))
                                {
                                    RadioBtnQ2.SelectedValue = dr["OptionID"].ToString();
                                }
                            }
                            break;

                        case 8: // assigning the answer for question 3
                            getSchoolList();

                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["OptionID"].Equals(DBNull.Value))
                                {
                                    switch (dr["OptionID"].ToString())
                                    {
                                        case "1":  //for school dropdown
                                            ddlCamperSchool.SelectedValue = dr["Answer"].Equals(DBNull.Value) ? "" : dr["Answer"].ToString();
                                            if (ddlCamperSchool.SelectedValue.Equals("-1"))  //if 'OTHERS' is selected then enable school text box
                                                txtCamperSchoolOthers.Enabled = true;
                                            break;
                                        case "2": //for other school text box
                                            txtCamperSchoolOthers.Text = dr["Answer"].Equals(DBNull.Value) ? "" : dr["Answer"].ToString();
                                            break;
                                    }
                                }
                                else
                                {
                                    if (!dr["Answer"].Equals(DBNull.Value))
                                    {
                                        ddlCamperSchool.SelectedIndex = ddlCamperSchool.Items.IndexOf(ddlCamperSchool.Items.FindByText(dr["Answer"].ToString()));
                                        if (ddlCamperSchool.SelectedValue.Equals("0"))
                                        {
                                            ddlCamperSchool.SelectedValue = "-1";
                                            txtCamperSchoolOthers.Enabled = true;
                                            txtCamperSchoolOthers.Text = dr["Answer"].ToString();
                                        }
                                    }
                                }
                            }
                            break;
                    }
                }
                //if (PnlQ1b.Visible == true)
                //SetFirstTimeCamper();

            }
            else
                getSchoolList();

        } //end if for null check of fjcid
    }
    
	protected void SetJWestGrantQuestion()
    {
        //DataSet dsFed;
        //string strZipCode;
        //int iCount, check = 0;
        //strZipCode = hdnZIPCODE.Value;
        //dsFed = objGeneral.GetFederationForZipCode(strZipCode);
        //iCount = dsFed.Tables[0].Rows.Count;
        //if (iCount > 0)
        //{
        //    for (int i = 0; dsFed.Tables[0].Rows.Count > i; i++)
        //    {
        //        if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "3")
        //        {
        //            check = 1;
        //        }
        //    }
        //}
        //if (check == 1)
        //{
            //PnlJWest.Visible = true;
            CamperApplication oCA = new CamperApplication();
            string strFJCID;
            strFJCID = hdnFJCID.Value;
            DataSet dsJWestGrantQuestion;
            dsJWestGrantQuestion = oCA.getCamperAnswers(strFJCID, "101", "101", "N");
            DataRow drJWestGrantQuestion;

            if (dsJWestGrantQuestion.Tables[0].Rows.Count > 0)
            {
                drJWestGrantQuestion = dsJWestGrantQuestion.Tables[0].Rows[0];
                if (!string.IsNullOrEmpty(drJWestGrantQuestion["OptionID"].ToString()))
                {
                    RadioBtnQ1.SelectedValue = drJWestGrantQuestion["OptionID"].ToString();
                }
                else
                {
                    RadioBtnQ1.SelectedValue = "";
                }
            }
        //}
        //else
        //{
        //    PnlJWest.Visible = false;
        //}
    }
    
	private void setPanelStatus()
    {
        if (RadioBtnQ2.SelectedValue.Equals("3"))  //Home school is selected
        {
            PnlQ3.Enabled = false;
            //ddlCamperSchool.SelectedIndex = 0;
            txtCamperSchoolOthers.Text = "";
        }
        else
        {
            PnlQ3.Enabled = true;
        }
    }

    private string ConstructCamperAnswers()
    {
        string strQuestionId = "";
        string strTablevalues = "";
        string strFSeparator;
        string strQSeparator;

        //to get the Question separator from Web.config
        strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
        //to get the Field separator from Web.config
        strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();

        //for question Grade
		string strGrade = ddlGrade.SelectedValue.ToString();
        strQuestionId = hdnQ1Id.Value;
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strGrade + strQSeparator;

		// Question: Whether attend JWest program last year
        strQuestionId = hdnQ4Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ1.SelectedValue + strFSeparator + strQSeparator;

        //for question Schoo Type
        strQuestionId = hdnQ2Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ2.SelectedValue + strFSeparator + strQSeparator;

        //for question School
		string strSchoolOthers = txtCamperSchoolOthers.Text.Trim();
        strQuestionId = hdnQ3Id.Value;
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strSchoolOthers;

        return strTablevalues;
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

    void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            
            
            string strGrade = ddlGrade.SelectedValue;
            //if (strGrade == "6" || strGrade == "7" || strGrade == "8" || strGrade == "9")
            //{   
                //enableWarningMessage();
            //}
            //else
            //{
                getSchoolList();
                //if (strGrade == "9")
                //{
                //    PnlQ4.Visible = true;
                    //if (Session["FedId"] != null)
                    //{
                    //    if (Session["FedId"].ToString() == "72")
                    //    {
                    //        PnlQ1b.Visible = true;
                    //    }
                       

                    //}
                //}
                //else
                //{
                //    PnlQ4.Visible = false;
                //}
            //added by sandhya for new functionality
                //if (strGrade == "6" || strGrade == "7" || strGrade == "8")// || strGrade == "9" || strGrade == "10")
                //{
                //    SetJWestGrantQuestion();
                //}
                //else
                //{
                //    PnlJWest.Visible = false;
                //}

               
            //CheckSandiegoJWest();


            //}
          
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    private void getSchoolList()
    {
        DataSet dsSchools;
        //Boolean bCamperEligibility;
        Boolean bEnable = false;
        //string strURL, strFedId;
        ddlCamperSchool.Items.Clear();
        
        //if (ddlGrade.SelectedIndex > 0)
        //{
            //this method is being called to get the Federation Id based on the Grade selected
            //the strurl and bcampereligibility will be used only in btn_next click
            //Federation Id will be stored in the hidden variable from this method
            //strURL = CheckFederation(out bCamperEligibility);
            //strFedId = hdnFEDID.Value;
            //if (!string.IsNullOrEmpty(strFedId))
            //{
                //dsSchools = objGeneral.GetSchoolListByFederation(Convert.ToInt32(strFedId));
        dsSchools = objGeneral.GetSchoolListByFederation(Convert.ToInt32(_strJWestFedId), Master.CampYear);                
                if (dsSchools.Tables[0].Rows.Count > 0)
                {
                    ddlCamperSchool.DataSource = dsSchools;
                    ddlCamperSchool.DataTextField = "Name";
                    ddlCamperSchool.DataValueField = "ID";
                    ddlCamperSchool.DataBind();
                    bEnable = true;
                }
            //}
        //}

        ddlCamperSchool.Items.Insert(0, new ListItem("-- Select--", "0"));
        ddlCamperSchool.Items.Insert(1, new ListItem("OTHER", "-1"));
        ddlCamperSchool.Enabled = bEnable;
        if (!bEnable)
        {
            if (RadioBtnQ2.SelectedValue.Equals("3"))
            {
                ddlCamperSchool.SelectedValue = "0"; //to select "SELECT"
            }
            else
            {
                ddlCamperSchool.SelectedValue = "-1"; //to select OTHERS
            }
        }

        //to make the txtotherschool text box readonly if OTHERS is not selected in the dropdown
        if (ddlCamperSchool.SelectedValue != "-1")
        {
            txtCamperSchoolOthers.Text = "";
            txtCamperSchoolOthers.Enabled = false;
        }
        else
            txtCamperSchoolOthers.Enabled = true;
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
            strFJCID = hdnFJCID.Value;
            strCamperAnswers = ConstructCamperAnswers();
            CamperAppl.CamperAnswersServerValidation(strCamperAnswers, strComments, strFJCID, strUserId,  (Convert.ToInt32(Redirection_Logic.PageNames.Step1_Questions)).ToString(), strCamperUserId, out bArgsValid, out bPerform);
            args.IsValid = bArgsValid;
            bPerformUpdate = bPerform;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    //Jwest number cap functionality
    private DataSet GetOverlapFederationsforZIPforNumberCap()
    {
        DataSet ds;
        string strZipCode;
        strZipCode = hdnZIPCODE.Value;
        ds = objGeneral.GetFederationForZipCode(strZipCode);
        return ds;

    }
    
	private string GetFederationforZIP()
    {
        DataSet ds;
        DataRow dr;

        string strZipCode, strFEDID;
        strZipCode = hdnZIPCODE.Value;
        ds = objGeneral.GetFederationForZipCode(strZipCode);

        if (ds.Tables[0].Rows.Count > 0)
        {
            dr = ds.Tables[0].Rows[0];
            strFEDID = dr["Federation"].ToString();
        }
        else
        {
            strFEDID = "";
        }
        return strFEDID;
    }

    private void enableWarningMessage()
    {
        string strFedId = GetFederationforZIP();
        if (strFedId == "22") 
        {
            Panel2.Visible = false;
            //OrangeWarningPanel.Visible = true;
            //LACIPWarningPanel.Visible = false;
        }
        //else if (strFedId == "23")
        //{
        //    Panel2.Visible = false;
        //    OrangeWarningPanel.Visible = false;
        //    LACIPWarningPanel.Visible = true;
        //}
        else
        {
            Panel2.Visible = true;
            //OrangeWarningPanel.Visible = false;
            //LACIPWarningPanel.Visible = false;
            string strGrade = ddlGrade.SelectedValue;
            getSchoolList();
            //if (strGrade == "9")
            //{
            //    PnlQ4.Visible = true;
            //}
            //else
            //{
            //    PnlQ4.Visible = false;
            //}
        }         
        
    }

    private UserDetails UserInfo
    {
        get
        {
            if ((userInfo.FirstName == null) && (userInfo.LastName == null))
            {
                userInfo = CamperAppl.getCamperInfo(Session["FJCID"].ToString());
            }
            return userInfo;
        }
    }

    private string getFederationId()
    {
        strFedId = null;
        DataSet fedInfo = objGeneral.GetFedDetailsForFJCID(Session["FJCID"].ToString());
        if (fedInfo.Tables[0].Rows.Count > 0)
        {
            strFedId = fedInfo.Tables[0].Rows[0]["FederationID"].ToString();
        }
        else
        {
            DataSet fedInfo2 = objGeneral.GetFederationForZipCode(UserInfo.ZipCode);
            strFedId = fedInfo2.Tables[0].Rows[0]["Federation"].ToString();
        }
        return strFedId;   
    }

    private void checkNationalProgramRedirection()
    {
        CamperApplication oCA = new CamperApplication();
        string strFJCID;
        strFJCID = Session["FJCID"].ToString();
        DataSet dsCamperApplication;
        DataRow drCA;
        dsCamperApplication = oCA.getCamperApplication(strFJCID);
        drCA = dsCamperApplication.Tables[0].Rows[0];

        if (!string.IsNullOrEmpty(drCA["AppType"].ToString()))
        {
            if (drCA["AppType"].ToString() == "C" && drCA["Federationid"].ToString() != "72")
            {
                ProcessCamperAnswers();
                Response.Redirect("Step1_NL.aspx");
            }
        }

    }

    private void SubmittedApplicationRedirection()
    {
        string strFJCID;
        strFJCID = Session["FJCID"].ToString();
        DataSet dsFedDetails;
        DataRow drFedDetails;
        dsFedDetails = objGeneral.GetFedDetailsForFJCID(strFJCID);
        drFedDetails = dsFedDetails.Tables[0].Rows[0];

        InsertCamperAnswers();

        Session["FedId"] = drFedDetails["FederationID"].ToString();

        Response.Redirect(drFedDetails["NavigationURL"].ToString());
    }

    private void SetSubmittedAdminUserFlags()
    {
        if (Session["FJCID"] != null)
        {
            General oGen = new General();
            if (oGen.IsApplicationSubmitted(Session["FJCID"].ToString()))
            {
                hdnIsSubmitted.Value = "Y";
            }
            else
                hdnIsSubmitted.Value = "N";

            string AdminUser;

            if (Session["UsrID"] != null)
                AdminUser = Session["UsrID"].ToString();
            else
                AdminUser = "";

            if (AdminUser == "")
                hdnIsAdmin.Value = "N";
            else
                hdnIsAdmin.Value = "Y";

        }
    }

	void RadioBtnQ1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (RadioBtnQ1.SelectedIndex == 2)
		{
			lblMsg.Text = "Please contact <a href='mailto:CampGrants@JewishCamp.org'>CampGrants@JewishCamp.org</a> for more information";
			btnNext.Visible = false;
		}
		else
		{
			btnNext.Visible = true;
			lblMsg.Text = "";
		}
	}
}
