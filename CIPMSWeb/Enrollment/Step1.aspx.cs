using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using CIPMSBC;

public partial class Step1 : System.Web.UI.Page
{
    private CamperApplication CamperAppl;
    private UserDetails UserInfo;
    private General objGeneral;
    private SrchCamperDetails _objCamperDet = new SrchCamperDetails();
    private bool bPerformUpdate;

	const int CodeNLP = 3;
	const int CodeWashinngton = 5;

    private string strJWestFedId = ConfigurationManager.AppSettings["JWest"];
    private string strOrangeFedId = ConfigurationManager.AppSettings["Orange"];
    private string strJWestLAId = ConfigurationManager.AppSettings["JWestLA"];
    private string strSanDiegoFedId = ConfigurationManager.AppSettings["SanDiego"];
    private string strPJLFedId = ConfigurationManager.AppSettings["PJL"];
    private string strCMARTFedId = ConfigurationManager.AppSettings["CMART"];
    private string strStep1QuestionsURL = "Step1_Questions.aspx";
    private string strWashingtonCampAiryLouiseURL = "Step1_WDC_CAL.aspx";
    private string strNationalURL = "Step1_NL.aspx";
    private string strWashingtonDCId = ConfigurationManager.AppSettings["WashingtonDC"];
    DataSet dsPJLCodes = new DataSet();
	private string strSplURL;

    private enum SpecialCodeType 
    { 
        PJL = 1,
        NLP = 3,
        Washington = 5,
        Other = 99
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        btnNext.Click += new EventHandler(btnNext_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
        txtZipCode.TextChanged += new EventHandler(txtZipCode_TextChanged);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValSplCode.ServerValidate += new ServerValidateEventHandler(CusValSplCode_ServerValidate);
        txtSplCode.TextChanged += new EventHandler(txtSplCode_TextChanged);
    }

	void Page_Load(object sender, EventArgs e)
	{
		hylLearnMore.Attributes.Add("href", "JavaScript:popupCall(this,'RamahDoromSecondTimerWarning','Message',false,'step1');");

		CamperAppl = new CamperApplication();
		objGeneral = new General();

		if (Session["CampYear"] == null)
		{
			var _objGen = new General();
			DataSet dsCampYear = _objGen.GetCurrentYear();
			if (dsCampYear.Tables[0].Rows.Count > 0)
			{
				Session["CampYear"] = dsCampYear.Tables[0].Rows[0]["CampYear"].ToString();
			}
			else
			{
                Session["CampYear"] = Application["CampYear"].ToString();
			}
		}

		var strPrevPage = Request.QueryString["check"];

		if (!Page.IsPostBack)
		{
			reqvalCityOther.Enabled = false;

			//to set the range for the dob validator
			rangeDOB.MinimumValue = "01/01/" + Convert.ToString(DateTime.Now.Year - 50);
			rangeDOB.MaximumValue = DateTime.Now.ToShortDateString();
			rangeDOB.ErrorMessage = "Please enter a valid Date of Birth between " + rangeDOB.MinimumValue + " and " + rangeDOB.MaximumValue;

			if (Session["FJCID"] != null)
			{
				hdnFJCID.Value = Session["FJCID"].ToString();

				//to get the User Info from the database if the user is a returning user
				getUserInfo();

				//added by sreevani to get if any special code is given by camper
				var dsSplCode = new DataSet();
				var dsForCampIDandURL = new DataSet();
				var dsForFedIDandURL = new DataSet();
				string CampID = "", fedID = "";

				dsForCampIDandURL = CamperAppl.getCamperAnswers(Session["FJCID"].ToString(), "10", "10", "N");

				if (dsForCampIDandURL.Tables[0].Rows.Count > 0)
					CampID = dsForCampIDandURL.Tables[0].Rows[0]["Answer"].ToString();

				Session["CampID"] = CampID;
				
				dsForFedIDandURL = CamperAppl.getCamperApplication(Session["FJCID"].ToString());

				// 2012-11-29 Status ID is used to determine if curretn app status is 42 (Eligible, Contact camper again), 
				//then we have to route this page to Section V, HOw did you hear me (Step2_1.aspx)
				int StatusID = 0; 

				if (dsForFedIDandURL.Tables[0].Rows.Count > 0)
				{
					fedID = dsForFedIDandURL.Tables[0].Rows[0]["FederationID"].ToString();
					StatusID = Convert.ToInt16(dsForFedIDandURL.Tables[0].Rows[0]["Status"]);
				}
				Session["FedId"] = fedID;

				// 2012-11-29 Status ID is used to determine if curretn app status is 42 (Eligible, Contact camper again), 
				//then we have to route this page to Section V, HOw did you hear me (Step2_1.aspx)
				if (StatusID == (int)StatusInfo.EligibleContactParentsAagain)
				{
					Session["STATUS"] = StatusID;
					Response.Redirect("Step2_1.aspx");
				}

				if ((Session["CampID"] != null && Session["CampID"].ToString() != "") || (Session["FedId"] != null && Session["FedId"].ToString() != ""))
				{

					if (Session["CampID"].ToString() == "3037")
						dsSplCode = CamperAppl.getCamperAnswers(Session["FJCID"].ToString(), "1027", "1027", "N");
					else if (Session["CampID"].ToString() == "3079")
						dsSplCode = CamperAppl.getCamperAnswers(Session["FJCID"].ToString(), "1028", "1028", "N");
					else if (Session["CampID"].ToString() == "3078")
						dsSplCode = CamperAppl.getCamperAnswers(Session["FJCID"].ToString(), "1029", "1029", "N");
					else if (Session["CampID"].ToString() == "3009")
						dsSplCode = CamperAppl.getCamperAnswers(Session["FJCID"].ToString(), "1030", "1030", "N");
					else if (Session["FedId"].ToString() == "49")
						dsSplCode = CamperAppl.getCamperAnswers(Session["FJCID"].ToString(), "1031", "1031", "N");
					if (((System.Data.InternalDataCollectionBase)(dsSplCode.Tables)).Count > 0)
					{
						if (dsSplCode.Tables[0].Rows.Count > 0)
						{
							txtSplCode.Text = dsSplCode.Tables[0].Rows[0][3].ToString();
							txtSplCode.Enabled = false;
						}
					}
				}

				string dallasCode = CamperAppl.validateFJCID(hdnFJCID.Value);
				if (dallasCode != null)
				{
					txtSplCode.Text = dallasCode;
					txtSplCode.Enabled = false;
				}
				DifferentiateCodes();
				get_CountryStates(int.Parse(UserInfo.Country));
			}
			else  //new user insert
			{
				hdnPerformAction.Value = "INSERT";
				getGenders(string.Empty, string.Empty);
				get_CountryStates(int.Parse(ddlCountry.SelectedValue));
			}

			PopulateStateCityForZIP(false);
			txtAge.Attributes.Add("readonly", "readonly");

			dsPJLCodes = objGeneral.GetPJLCodes(Session["CampYear"] != null ? Session["CampYear"].ToString() : DBNull.Value.ToString());

			for (int i = 0; i < dsPJLCodes.Tables[0].Rows.Count; i++)
			{
				hdnPJLCodes.Value = hdnPJLCodes.Value + "," + dsPJLCodes.Tables[0].Rows[i][0].ToString();
			}

			hdnPJLCodes.Value.TrimStart(',');
		}

		if (strPrevPage == "popup")
		{
			if (Session["FJCID"] != null)
			{
				string fjcid = Session["FJCID"].ToString();
				string newfjcid;
				CamperAppl.CloneCamperApplication(fjcid, out newfjcid);
				Session["FJCID"] = newfjcid;
				General oGen = new General();
				hdnFJCID.Value = Session["FJCID"].ToString();
				if (oGen.IsApplicationSubmitted(Session["FJCID"].ToString()))
				{

					getUserInfo();
					SubmittedApplicationRedirection();
				}
				else
				{
					UserDetails Info;
					Info = getUserInfoStructwithValues();
					NewCamper(Info);
				}
			}
		}
	}

	void btnNext_Click(object sender, EventArgs e)
	{
        // There are currently two places that could route to Camper Holding Page.  
        // 1. When the CIPM is shut-down, typically from July to September
        // 2. When CIPMS is open for registration, typically in mid-October
        // The code below fulfill scenario 2 above, for which we still want potentinal campers' data before we tell them the camps are still closed
        if (ZipCodeHasClosedProgram())
        {
            // if the code executes to this point, it means the system is open for registration, but this particular zip/associated fed is still closed
            // 2014-02-7 Add new logic that if this user applies the Direct Pass for PJL, then instead of going to the camper holding page, we go to PJL
            var passFlag = false;
            if ((SpecialCodeType)Convert.ToInt32(Session["codeValue"]) == SpecialCodeType.PJL)
            {
                var directPassPJLCode = Session["SpecialCodeValue"].ToString();
                bool isDirectPass = SpecialCodeManager.IsValidDirectPassCode(Convert.ToInt32(Application["CampYearID"]), FederationEnum.PJL, directPassPJLCode);
                if (isDirectPass)
                {
                    passFlag = true;
                }
            }
            
            if (!passFlag)
                Response.Redirect("~/CamperHolding.aspx");
        }

        if (!bPerformUpdate)
            return;

		string strNextURL = string.Empty, strCheckUpdate, strFedId = string.Empty;
		
		int iCount = 0;
		int check = 0;
		int fedCheck = 0;

		// 2012-01-24 If special code is empty, make sure we clean up the session variables
		if (txtSplCode.Text == "")
		{
			Session["SpecialCodeValue"] = null;
			Session["codeValue"] = 0;
		}

		string strFJCID = hdnFJCID.Value;

		// What is this?
		if ((Session["CamperLoginID"] != null) && (string.IsNullOrEmpty(strFJCID)))
		{
			if (rdbJewish.Items[0].Selected == false && rdbJewish.Items[1].Selected == false)
			{
				lblJ.Visible = true; // Prompt the message "please answer the question - identify as Jewish?
				return;
			}
		}

		// Siva - 12/03/2008 - start change to fix the age calculation problem when enter key is pressed 
		DateTime CamperBirthDate = Convert.ToDateTime(txtDOB.Text);
		txtAge.Text = calculateAge(CamperBirthDate).ToString();
		// Siva - 12/03/2008 - end change

		//to get the user input values as struct object
        UserDetails Info = getUserInfoStructwithValues();
		string strAction = hdnPerformAction.Value;
		string strCamperUserId = Master.CamperUserId;

		Session["ZIPCODE"] = Info.ZipCode;

		if (Session["FJCID"] != null)
		{
			var oGen = new General();
			if (oGen.IsApplicationSubmitted(Session["FJCID"].ToString()))
			{
				SubmittedApplicationRedirection();
			}
		}

        // 2014-02-10 To bring sanity back, we put all special special-code routing logic here (e.g if use this code, we do xxxx)
		int codeValue = Convert.ToInt32(Session["codeValue"]);
		
		// NLP code redirection
		if (codeValue == CodeWashinngton || codeValue == CodeNLP)
			validateNLCodeRedirection();

        // 2014-02-06 PJL Direct Pass allows user to go to PJL summary page directly 
        if (IsDirectPass(FederationEnum.PJL))
            Response.Redirect("~/Enrollment/PJL/Summary.aspx");

        // 2014-02-06 
        if (IsDirectPass(FederationEnum.MetroWest))
            Response.Redirect("~/Enrollment/MetroWest/Summary.aspx");

        var dsFed = new DataSet();

		if (IsFromCanada())
		{
			if (objGeneral.GetCanadianZipCode(Info.ZipCode).Trim() != "")
			{
				iCount = 1;
			}
		}
		else
		{
			dsFed = objGeneral.GetFederationForZipCode(Info.ZipCode);
		}

		if (dsFed.Tables.Count > 0)
		{
			if (dsFed.Tables[0].Rows.Count > 0)
			{
				iCount = dsFed.Tables[0].Rows.Count;
				Session["FedId"] = dsFed.Tables[0].Rows[0][0];
			}
		}

		var redirectionLogic = new Redirection_Logic();
		redirectionLogic.GetNextFederationDetails(Session["FJCID"] != null ? Session["FJCID"].ToString() : "");

		// if iCount == 0, it means the zip code has no federation associated
		if (iCount > 0)
		{
			//added by sandhya 
			if (dsFed.Tables.Count > 0)
			{
				for (int i = 0; dsFed.Tables[0].Rows.Count > i; i++)
				{
					if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "3" || dsFed.Tables[0].Rows[i]["Federation"].ToString() == "4")
					{
						check = 1;
					}

					if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "72")
					{
						fedCheck = 2;
					}

					if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "22")
					{
						fedCheck = 3;
					}

					if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "23")
					{
						fedCheck = 4;
					}
				}
			}

			DataSet dsCamper = _objCamperDet.getReturningCamperDetails(Info.FirstName, Info.LastName, Info.DateofBirth);

			if (txtSplCode.Text != "")
			{
				if (Convert.ToInt32(Session["codeValue"]) == 5)
				{
					if (dsCamper.Tables[0].Rows.Count > 0)
					{

					}
					else //If camper is not returning camper
					{
						bool isexceededcount = numbercapCheck();
						//If count exceeded the limit
						if (!isexceededcount)
						{
							//Sandiego and ORange counts
							string SDCode = txtSplCode.Text.ToUpper();
							string OCCode = txtSplCode.Text.ToUpper();
							string LACode = txtSplCode.Text.ToUpper();
							string ConfigLACode = ConfigurationManager.AppSettings["LACode"];
							string ConfigSDCode = ConfigurationManager.AppSettings["SDCode"];
							string ConfigOCCode = ConfigurationManager.AppSettings["OCCode"];
							if (SDCode == ConfigSDCode && fedCheck == 2)
							{
								ProcessCamperInfo(Info);
								Session["SDCode"] = SDCode;
								Session["FJCID"] = hdnFJCID.Value;
								Session["FedId"] = 72;
								Response.Redirect("Step1_Questions.aspx");
							}
							else if (OCCode == ConfigOCCode && fedCheck == 3)
							{
								ProcessCamperInfo(Info);
								Session["OCCode"] = OCCode;
								Session["FJCID"] = hdnFJCID.Value;
								Session["FedId"] = 22;
								Response.Redirect("Step1_Questions.aspx");
							}
							else if (LACode == ConfigLACode && fedCheck == 4)
							{
								ProcessCamperInfo(Info);
								Session["LACode"] = LACode;
								Session["FJCID"] = hdnFJCID.Value;
								Session["FedId"] = 23;
								Response.Redirect("Step1_Questions.aspx");
							}
						}
					}
				}
			}
			NewCamper(Info);
		}
		else if (txtSplCode.Text != string.Empty && Convert.ToInt32(Session["codeValue"]) == 1)
		{
            // 2014-02-06 The zip code entered here doesn't have any federations associated, so we need to check if there is PJL code applied so we can go to PJL directly
			//added by sreevani to check redirection to pjl based on day school codes.
			if (!redirectionLogic.BeenToPJL)
			{
				dsPJLCodes = objGeneral.GetPJLCodes(Session["CampYear"] != null ? Session["CampYear"].ToString() : DBNull.Value.ToString());
				for (int i = 0; i < dsPJLCodes.Tables[0].Rows.Count; i++)
				{
					if (txtSplCode.Text.Trim().ToUpper() == dsPJLCodes.Tables[0].Rows[i][0].ToString())
					{
						strNextURL = "~/Enrollment/PJL/Summary.aspx";
						Session["FedId"] = ConfigurationManager.AppSettings["PJL"].ToString();
						strFedId = ConfigurationManager.AppSettings["PJL"].ToString();
						break;
					}
					else
					{
						strNextURL = strNationalURL; // "~/Enrollment/Step1.aspx";
					}
				}
			}
		}
		else if (strNextURL.Trim() == "")
		{
			strNextURL = strNationalURL;
		}

		if (Info.ModifiedBy == strCamperUserId && Session["FJCID"] != null && String.IsNullOrEmpty(strNextURL.Trim()))
		{
			checkNationalProgramRedirection();
		}

		if (check != 1)
		{
			if (strAction == "INSERT")
			{
				ProcessCamperInfo(Info);
				if (Convert.ToInt32(Session["codeValue"]) == 6)
					InsertCamperAnswers();
				hdnPerformAction.Value = "UPDATE";
			}
			else if (strAction == "UPDATE")
			{
				strCheckUpdate = CheckforUpdate();
				if ((Info.ModifiedBy == strCamperUserId) && (strCheckUpdate == "0")) //some modification done and user is not admin
					ProcessCamperInfo(Info);
			}

            //PJL Day School code verification.
            if (codeValue == 1)
                validatePJLDaySchoolCodeRedirection();

			//to update the Federation Id for the particular FJCID
			//this will take care of federation changes for a particular application
			if (strFedId != string.Empty && strNextURL != strStep1QuestionsURL)
				CamperAppl.UpdateFederationId(hdnFJCID.Value, strFedId);

			if (UserInfo.IsJewish == "2")
			{
				Session["STATUS"] = StatusInfo.NonJewish;
				strNextURL = "ThankYou.aspx";
			}

			if (strNextURL == "" || dsFed.Tables.Count == 0)
			{
				lblMessage.Visible = true;
				lblMessage.Text = "No Federation exists for the given Zip Code";
			}
			else
			{
				Session["FJCID"] = hdnFJCID.Value;
				//added by sreevani for closed federations redirection                        

				if ((dsFed.Tables[0].Rows.Count > 0) && (dsFed.Tables[0].Rows[0]["Federation"].ToString() != ""))
				{
					if (dsFed.Tables[0].Rows[0]["Federation"].ToString() == "39" || dsFed.Tables[0].Rows[0]["Federation"].ToString() == "49")//|| dsFed.Tables[0].Rows[0]["Federation"].ToString() == "40")//dsFed.Tables[0].Rows[0]["Federation"].ToString() == "24" ||  || dsFed.Tables[0].Rows[0]["Federation"].ToString() == "12"
						Response.Redirect("ClosedFedRedirection.aspx");
					else
						Response.Redirect(strNextURL);
				}
				else
				{
					Response.Redirect(strNextURL);
				}
			}
		}
	}

    void btnReturnAdmin_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        string strCheckUpdate;
        string strCamperUserId = Master.CamperUserId;
        UserDetails Info;

        if (Page.IsValid)
        {
            strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"].ToString();
            //to get the user input values as struct object
            Info = getUserInfoStructwithValues();

            strCheckUpdate = CheckforUpdate();
            if ((Info.ModifiedBy == strCamperUserId) && (strCheckUpdate == "0")) //some modification done and user is not admin
                ProcessCamperInfo(Info);

            Response.Redirect(strRedirURL);
        }
    }

    void btnSaveandExit_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        UserDetails Info;

        Page.Validate();
        if (Page.IsValid)
        {

            strRedirURL = Master.SaveandExitURL;
            //to get the user input values as struct object
            Info = getUserInfoStructwithValues();
            ProcessCamperInfo(Info);

            if (Master.CheckCamperUser == "Yes")
            {
                General oGen = new General();
                if (Session["FJCID"] != null)
                {
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

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCityOthers.Text = string.Empty;

        SetCountryValidationRules(ddlCountry.SelectedItem.Value);
        get_CountryStates(int.Parse(ddlCountry.SelectedValue));

        string strFJCID = hdnFJCID.Value;
        if (!strFJCID.Equals(string.Empty))
        {
            UserInfo = CamperAppl.getCamperInfo(strFJCID);

            if (ddlCountry.SelectedValue == UserInfo.Country)
            {
                txtZipCode.Text = UserInfo.ZipCode;
                getCities(UserInfo.ZipCode, UserInfo.City);
            }
            else
            {
                txtZipCode.Text = string.Empty;

            }

        }
        else
        {
            txtZipCode.Text = string.Empty;
        }

        PopulateStateCityForZIP(false);

        if (ddlState.SelectedIndex == 0)
        {
            try // it may not exist when changing the country
            {
                ddlState.SelectedValue = UserInfo.State;
            }
            catch { }
        }
        txtZipCode.Focus();
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Check if OTHERS is selected - make textbox required fiels 
        //for another selections - city combobox has to be required control
        if (ddlCity.SelectedItem.Text == "OTHERS")
        {
            reqvalCity.Enabled = false;
            reqvalCityOther.Enabled = true;
            txtCityOthers.Enabled = true;
        }
        else
        {
            reqvalCity.Enabled = true;
            reqvalCityOther.Enabled = false;
            txtCityOthers.Enabled = false;
            txtCityOthers.Text = string.Empty;
        }
    }

    void txtSplCode_TextChanged(object sender, EventArgs e)
    {
        DifferentiateCodes();
    }

    void txtZipCode_TextChanged(object sender, EventArgs e)
    {
        txtZipCode.Text = txtZipCode.Text.ToUpper();
        var strZip = txtZipCode.Text.Trim();
        string feds = ConfigurationManager.AppSettings["OpenFederations"];

        if (feds != "")
        {
            if (objGeneral.ValidateZipCode(strZip, feds))
            {
                if (ddlCountry.SelectedItem.Value == "1")
                {
                    if (strZip.Length > 5)
                    {
                        txtZipCode.Text = strZip.Substring(0, 5);
                    }
                }
                else
                {
                    if (strZip.Length > 7)
                    {
                        txtZipCode.Text = strZip.Substring(0, 7);
                    }
                }
            }
            else
            {
                //Response.Redirect("~/CamperHolding.aspx");
            }
        }

        ddlState.SelectedIndex = -1;

        PopulateStateCityForZIP(true);
    }

    public void CusValSplCode_ServerValidate(object source, ServerValidateEventArgs args)
    {
        var code = txtSplCode.Text.Trim();

        if (code == "")
            return;

        // PJ uses a generic code + dynamic code formats.  In system, we just need to know if the code has the generic part or not
        if (code.Contains("PJGTC"))
            code = code.Substring(0, 9);

        if (!SpecialCodeManager.IsValidCode(Convert.ToInt32(Application["CampYearID"]), -1, code))
        {
            CusValSplCode.ErrorMessage = "Invalid Code";
            args.IsValid = false;
            bPerformUpdate = args.IsValid;            
        }
    }

    public void CusValSplCode_ServerValidate_old(object source, ServerValidateEventArgs args)
    {
        var oCA = new CamperApplication();
        DifferentiateCodes();
        //if (Master.UserId == Master.CamperUserId)
        //{
        if (txtSplCode.Text != "")
        {
            string LACode = txtSplCode.Text.ToUpper();
            string ConfigLACode = ConfigurationManager.AppSettings["LACode"];
            string SDCode = txtSplCode.Text.ToUpper();
            string OCCode = txtSplCode.Text.ToUpper();
            string ConfigSDCode = ConfigurationManager.AppSettings["SDCode"];
            string ConfigOCCode = ConfigurationManager.AppSettings["OCCode"];
            string GilboaCode = txtSplCode.Text.ToUpper();
            string RDCode = txtSplCode.Text.ToUpper();
            string RCCode = txtSplCode.Text.ToUpper();
            string ALCode = txtSplCode.Text.ToUpper();
            string DCCode = txtSplCode.Text.ToUpper();
            string ConfigGilboaCode = ConfigurationManager.AppSettings["GilboaCode"];
            string ConfigRDCode = ConfigurationManager.AppSettings["RDCode"];
            string ConfigRCCode = ConfigurationManager.AppSettings["RCCode"];
            string ConfigALCode = ConfigurationManager.AppSettings["ALCode"];
            string ConfigDCCode = ConfigurationManager.AppSettings["DCCode"];
            string ConfigSpecialPJLCode = ConfigurationManager.AppSettings["SpecialPJLCode"];
            string ConfigSpecialPJLCapitalCode = ConfigurationManager.AppSettings["SpecialPJLCapitalCode"];
            bool isexceededcount = numbercapCheck();
            UserDetails Info;
            DataSet dsCamper = new DataSet();
            //to get the user input values as struct object
            Info = getUserInfoStructwithValues();
            dsCamper = _objCamperDet.getReturningCamperDetails(Info.FirstName, Info.LastName, Info.DateofBirth);

            if (dsCamper.Tables[0].Rows.Count > 0)
            {

            }
            else //If camper is not returning camper 
            {
                //If number cap count exceeded the limit
                if (!isexceededcount)
                {
                    //Sandiego and ORange counts                           
                    int check = getzipcodefederations();
                    if (SDCode == ConfigSDCode)
                    {
                        if (check != 2)
                        {
                            CusValSplCode.ErrorMessage = "This code is not valid. Please contact Roni Ogin at 303-669-5418.";
                            args.IsValid = false;
                            bPerformUpdate = args.IsValid;
                        }
                    }
                    if (OCCode == ConfigOCCode)
                    {
                        if (check != 3)
                        {
                            CusValSplCode.ErrorMessage = "This code is not valid. Please contact Roni Ogin at 303-669-5418.";
                            args.IsValid = false;
                            bPerformUpdate = args.IsValid;
                        }
                    }
                    if (LACode == ConfigLACode)
                    {
                        if (check != 4)
                        {
                            CusValSplCode.ErrorMessage = "This code is not valid. Please contact Roni Ogin at 303-669-5418.";
                            args.IsValid = false;
                            bPerformUpdate = args.IsValid;
                        }
                    }
                }
            }

            if (txtSplCode.Enabled == true)
            {
                if (LACode != ConfigLACode || OCCode != ConfigOCCode || SDCode != ConfigSDCode || GilboaCode != ConfigGilboaCode || RDCode != ConfigRDCode || RCCode != ConfigRCCode || ALCode != ConfigALCode || DCCode != ConfigDCCode)
                {
                    if (txtSplCode.Text.Trim().ToLower().Contains("nlp"))
                    {
                        if (!SpecialCodeManager.IsValidCode(Convert.ToInt32(Application["CampYearID"]), 0, txtSplCode.Text))
                        {
                            CusValSplCode.ErrorMessage = "This code is no longer valid. Please contact your program administrator for support.";
                            args.IsValid = false;
                            bPerformUpdate = args.IsValid;
                        }
                        else
                        {
                            args.IsValid = true;
                            bPerformUpdate = args.IsValid;
                        }
                    }
                    else if (txtSplCode.Text.Trim().ToLower().Contains("pjgtc"))
                    {
                        int validPJL = 0;
                        dsPJLCodes = objGeneral.GetPJLCodes(Session["CampYear"] != null ? Session["CampYear"].ToString() : DBNull.Value.ToString());
                        //2012-05-07 Make sure pjCode is valid, so I can use the session variable again on every program's summary page
                        string pjCode = txtSplCode.Text.Trim().ToUpper();
                        for (int i = 0; i < dsPJLCodes.Tables[0].Rows.Count; i++)
                        {
                            if (pjCode.Equals(dsPJLCodes.Tables[0].Rows[i].ItemArray[0]))
                            {
                                validPJL = 1;
                                Session["SpecialCodeValue"] = pjCode;
                                break;
                            }
                        }

                        //added by sreevani to validate pjl day school codes
                        if (validPJL != 1)
                        {
                            //added by sandhya to validate the special pjl codes
                            if (txtSplCode.Text.ToUpper() == ConfigSpecialPJLCode || txtSplCode.Text.ToUpper() == ConfigSpecialPJLCapitalCode)
                            {
                                validPJL = 1;
                            }
                            else if (oCA.validatePJLDSCode(txtSplCode.Text.Trim().ToLower()) == 2 || oCA.validatePJLDSCode(txtSplCode.Text.Trim().ToLower()) == 1)
                            {
                                validPJL = 0;
                            }
                            else
                            {
                                args.IsValid = true;
                                validPJL = 1;
                                bPerformUpdate = args.IsValid;
                            }

                            // 2013-03-22 PJL uses tlbSpecialCode table now
                            string currentCode = Session["SpecialCodeValue"].ToString();
                            int CampYearID = Convert.ToInt32(Application["CampYearID"]);
                            int FedID = Convert.ToInt32(FederationEnum.PJL);
                            List<string> specialCodes = SpecialCodeManager.GetAvailableCodes(CampYearID, FedID);

                            // when moved to .NET 3.5 or above, remember to use lamda expression
                            foreach (string code in specialCodes)
                            {
                                if (code == currentCode)
                                {
                                    validPJL = 1;
                                    break;
                                }
                            }
                        }

                        if (validPJL == 1)
                        {
                            args.IsValid = true;
                            bPerformUpdate = args.IsValid;
                        }
                        else
                        {
                            Session["codeValue"] = null;
                            CusValSplCode.ErrorMessage = "INVALID CODE";
                            args.IsValid = false;
                            bPerformUpdate = args.IsValid;
                        }
                    }
                    else if (Convert.ToInt32(Session["codeValue"]) == 0)
                    {
                        CusValSplCode.ErrorMessage = "INVALID CODE";
                        args.IsValid = false;
                        bPerformUpdate = args.IsValid;
                    }
                }
            }
        }
        //}
    }

    void CusValComments_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (Master.UserId != Master.CamperUserId)
        {
            if ((txtComments.Text.Trim().Length > 0) || CheckforUpdate().Equals("1"))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        else
        {
            args.IsValid = true;
        }
        bPerformUpdate = args.IsValid;
    }

    #region "Private functions"

    bool IsFromCanada()
    {
        return ddlCountry.SelectedItem.Text.ToLower() == "canada" && 
            (txtZipCode.Text.StartsWith("A") || 
             txtZipCode.Text.StartsWith("B") || 
             txtZipCode.Text.StartsWith("C") || 
             txtZipCode.Text.StartsWith("E") || 
             txtZipCode.Text.StartsWith("G") || 
             txtZipCode.Text.StartsWith("H") || 
             txtZipCode.Text.StartsWith("J") || 
             txtZipCode.Text.StartsWith("L") || 
             txtZipCode.Text.StartsWith("M") || 
             txtZipCode.Text.StartsWith("N"));
    }

    bool ZipCodeHasClosedProgram()
    {
        string strZip = txtZipCode.Text.Trim();
        string feds = ConfigurationManager.AppSettings["OpenFederations"];

        if (feds == "" || feds == "None") return true;
        if (!objGeneral.ValidateZipCode(strZip, feds)) return true;
        return false;
    }

    private void getGenders(string strFJCID, string Gender)
    {
        DataSet dtGenders;
        dtGenders = CamperAppl.get_Genders();
        ddlGender.DataSource = dtGenders;
        ddlGender.DataTextField = "Description";
        ddlGender.DataValueField = "ID";
        ddlGender.DataBind();

        MasterPage x = Page.Master; ;

        if (Session["CamperLoginID"] == null)//admin user
        {
            if (Gender.Equals(string.Empty)) //gender was not selected
            {
                ddlGender.Items.Insert(0, new ListItem("", "-1"));
                lblStarGender.Text = "&nbsp;&nbsp;";
            }
            else //gender was selected
            {
                ddlGender.Items.Insert(0, new ListItem("", "-1"));
                ddlGender.SelectedValue = Gender;
                lblStarGender.Text = "&nbsp;&nbsp;";
            }
        }
        else // camper
        {
            if (string.IsNullOrEmpty(strFJCID)) //new camper
            {
                ddlGender.Items.Insert(0, new ListItem("-- Select --", "0"));
                lblStarGender.Text = "*";
            }
            else if (Gender.Equals(string.Empty)) //gender was not selected
            {
                CamperApplication objCamperAppl = new CamperApplication();
                DataSet dsApplSubmitInfo = objCamperAppl.GetApplicationSubmittedInfo(strFJCID);

                if (dsApplSubmitInfo.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsApplSubmitInfo.Tables[0].Rows[0];

                    //get submitted date
                    string strSubmittedDate = string.Empty; ;
                    if (!dr["SUBMITTEDDATE"].Equals(DBNull.Value))
                        strSubmittedDate = dr["SUBMITTEDDATE"].ToString();

                    //to get the modified by user6
                    int iModifiedBy;
                    string CamperUserId = ConfigurationManager.AppSettings["CamperModifiedBy"].ToString();
                    iModifiedBy = Convert.ToInt16(CamperUserId);

                    if (!dr["MODIFIEDUSER"].Equals(DBNull.Value))
                        iModifiedBy = Convert.ToInt16(dr["MODIFIEDUSER"]);

                    //if true, Camper Application has been submitted (or) the Application has been modified by a Admin
                    if (!string.IsNullOrEmpty(strSubmittedDate) || (iModifiedBy != Convert.ToInt16(CamperUserId) && iModifiedBy > 0))
                    {
                        ddlGender.Items.Insert(0, new ListItem("", "-1"));
                        lblStarGender.Text = "&nbsp;&nbsp;";
                    }
                    else
                    {
                        ddlGender.Items.Insert(0, new ListItem("-- Select --", "0"));
                        lblStarGender.Text = "*";
                    }
                }
                else //should not happen
                {
                    ddlGender.Items.Insert(0, new ListItem("-- Select --", "0"));
                    lblStarGender.Text = "*";
                }
            }
            else //gender was selected
            {
                ddlGender.SelectedValue = Gender;
                lblStarGender.Text = "*";
            }
        }
    }

    void PopulateStateCityForZIP(Boolean PopulateCity)
    {
        string strZip, strCountry;

        //to populate the state and city automatically for the zip
        strZip = txtZipCode.Text.Trim();
        if ((strZip.Length >= 6) && (!strZip.Contains(" ")))
        {
            strZip = strZip.Substring(0, 3) + " " + strZip.Substring(3, 3);
            txtZipCode.Text = strZip;
        }
        strCountry = ddlCountry.SelectedItem.Value;
        DataSet dsCityState;
        DataRow drCityState;

        if (strZip != "")
        {
            dsCityState = objGeneral.get_CityState(strZip, strCountry);
            if (dsCityState.Tables[0].Rows.Count > 0)
            {
                drCityState = dsCityState.Tables[0].Rows[0];

                if (PopulateCity)
                {
                    ddlCity.DataSource = dsCityState;
                    ddlCity.DataTextField = "City";
                    ddlCity.DataValueField = "ID";
                    ddlCity.DataBind();

                    int index = dsCityState.Tables[0].Rows.Count;
                    ddlCity.Items.Insert(index, new ListItem("OTHERS", "0"));

                    txtCityOthers.Text = string.Empty;
                    if (index == 0) //no cities in the list
                    {
                        txtCityOthers.Enabled = true;
                        reqvalCityOther.Enabled = true;
                        reqvalCity.Enabled = false;
                    }
                    else //some cities are populated
                    {
                        txtCityOthers.Enabled = false;
                        reqvalCityOther.Enabled = false;
                        reqvalCity.Enabled = true;
                    }

                }

                try
                {
                    ddlState.SelectedValue = drCityState["State"].ToString();
                    ddlState.Enabled = false;
                }
                catch { ddlState.Enabled = true; }
            }
            else
            {

                ddlState.Enabled = true;

                if (PopulateCity)
                {
                    ddlCity.Items.Clear();

                    ddlCity.Items.Insert(0, new ListItem("OTHERS", "0"));
                    reqvalCity.Enabled = false;
                    reqvalCityOther.Enabled = true;
                    txtCityOthers.Enabled = true;
                    txtCityOthers.Text = string.Empty;
                }

            }

        }
        else
        {
            ddlState.Enabled = true;

            ddlCity.Items.Clear();
            ddlCity.Items.Insert(0, new ListItem("OTHERS", "0"));
        }
        if (IsPostBack)
            txtAddress.Focus();
    }

    protected int getzipcodefederations()
    {
        General oGen = new General();
        DataSet dsFed = new DataSet();
        UserDetails Info;
        //to get the user input values as struct object
        Info = getUserInfoStructwithValues();
        dsFed = oGen.GetFederationForZipCode(Info.ZipCode);
        int check = 0;
        if (dsFed.Tables.Count > 0)
        {
            if (dsFed.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; dsFed.Tables[0].Rows.Count > i; i++)
                {
                    if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "72")
                    {
                        check = 2;
                    }
                    if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "22")
                    {
                        check = 3;
                    }
                    if (dsFed.Tables[0].Rows[i]["Federation"].ToString() == "23")
                    {
                        check = 4;
                    }
                }
            }
        }
        return check;
    }

    protected bool numbercapCheck()
    {
        int jwestnumbercapConfigCount = Convert.ToInt32(ConfigurationManager.AppSettings["jwestnumbercapcount"].ToString());
        bool isexceededcount = false;
        int jwestnumbercapCount = CamperAppl.GetJWestFirsttimersCountBasedonStatus();
        if (jwestnumbercapCount <= jwestnumbercapConfigCount)
        {
            isexceededcount = true;
        }
        return isexceededcount;
    }

    protected void NewCamper(UserDetails Info)
    {
        string strNextURL = string.Empty, strAction, strCamperUserId, strCheckUpdate, strFedId = string.Empty;
        DataSet dsFed = null;
        DataRow dr;
        int iCount;
        DataSet dsMiiPReferalCodeDetails = new DataSet();
        string ConfigSpecialPJLCode = ConfigurationManager.AppSettings["SpecialPJLCode"];
        string ConfigRamahDarom = ConfigurationManager.AppSettings["2012CRD6481"];
        string ConfigSpecialPJLCapitalCode = "PJGTC2014B";
        strAction = hdnPerformAction.Value;
        strCamperUserId = Master.CamperUserId;

        // BY Rajesh - Checks if ZipCode is Alphanumeric

        int Isnumber;

        if (ddlCountry.SelectedItem.Text.ToLower() == "canada" &&
            (txtZipCode.Text.StartsWith("A")
            || txtZipCode.Text.StartsWith("B")
            || txtZipCode.Text.StartsWith("C")
            || txtZipCode.Text.StartsWith("E")
            || txtZipCode.Text.StartsWith("G")
            || txtZipCode.Text.StartsWith("H")
            || txtZipCode.Text.StartsWith("J")
            || txtZipCode.Text.StartsWith("L")
            || txtZipCode.Text.StartsWith("M")
            || txtZipCode.Text.StartsWith("N")
            ))
        {
            iCount = 1;
        }
        else
        {
            dsFed = objGeneral.GetFederationForZipCode(Info.ZipCode);
            iCount = dsFed.Tables[0].Rows.Count;
        }

        if (iCount > 0)
        {

            string strFJCID, strAppType, strFJCIDFedId;
            strFJCID = Session["FJCID"] != null ? Session["FJCID"].ToString() : string.Empty;
            strAppType = strFJCIDFedId = string.Empty;

            if (strFJCID != string.Empty)
            {
                CamperApplication oCA = new CamperApplication();
                DataSet dsCamperApplication = oCA.getCamperApplication(strFJCID);
                DataRow drCA = dsCamperApplication.Tables[0].Rows[0];
                strFJCIDFedId = drCA["FederationId"] != null ? drCA["FederationId"].ToString().ToLower() : string.Empty;
                strAppType = drCA["AppType"] != null ? drCA["AppType"].ToString().ToLower() : string.Empty;
            }
            if (iCount == 1)
            {
                if (dsFed == null)
                {
                    strFedId = objGeneral.GetCanadianZipCode(Info.ZipCode);
                }
                else if (dsFed.Tables.Count > 0)
                {
                    dr = dsFed.Tables[0].Rows[0];
                    strFedId = dr["Federation"].ToString();
                }
                //to check if the FedId is in the FedIds array declared above
                if (doStep1questions(strFedId) && strAppType != "c")
                {
                    strNextURL = strStep1QuestionsURL;
                    Session["ZIPCODE"] = Info.ZipCode; //zip code will be used in step1_questions.aspx

                }
                else if (doStep1_WD_CAL_Page(strFedId) && strAppType != "c")
                {
                    strNextURL = strWashingtonCampAiryLouiseURL;
                    Session["ZIPCODE"] = Info.ZipCode;
                    if (txtSplCode.Text.ToUpper() == ConfigSpecialPJLCode || txtSplCode.Text.ToUpper() == ConfigSpecialPJLCapitalCode)
                    {
                        DataSet ds;
                        if (strFJCIDFedId != "" && strFJCIDFedId != "0")
                        {
                            strFedId = strFJCIDFedId;
                            ds = objGeneral.GetFederationDetails(strFJCIDFedId);
                        }
                        else
                        {
                            ds = objGeneral.GetFederationDetails(strFedId);
                        }
                    }
                }
                else //it is not jwest/orange/jwest la / la cip
                {
                    //to get the navigation url for the federation based on the federation id
                    DataSet ds;
                    if (strAppType != string.Empty && strAppType == "c")
                    {
                        getIntermediateRedirection(strFJCIDFedId, strFedId);
                        strFedId = strFJCIDFedId;
                        ds = objGeneral.GetFederationDetails(strFJCIDFedId);
                    }
                    else if (txtSplCode.Text.ToUpper() == ConfigSpecialPJLCode || txtSplCode.Text.ToUpper() == ConfigSpecialPJLCapitalCode)
                    {
                        if (strFJCIDFedId != "" && strFJCIDFedId != "0")
                        {
                            strFedId = strFJCIDFedId;
                            ds = objGeneral.GetFederationDetails(strFJCIDFedId);
                        }
                        else
                        {
                            ds = objGeneral.GetFederationDetails(strFedId);
                        }
                    }
                    else
                    {
                        ds = objGeneral.GetFederationDetails(strFedId);
                    }

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        strNextURL = ds.Tables[0].Rows[0]["NavigationURL"].ToString();
                        //sesion[fedid] will be set only if it is not jwest or orange county
                        //for jwest and orange county it will be set in step1_questions.aspx
                        Session["FedId"] = strFedId;
                    }
                    else
                    {
                        // 2014-02-06 If come here, it means the FederationID field of CamperApplication is NULL.  This will have catastrophic consequence because the redirect will fail
                        strNextURL = "";
                    }
                }
            }
            else if (iCount > 1)  //the zip code is applicable for both Jwest /Orange/jwest la / la cip
            {
                //Ram 8 Nov'10

                dr = dsFed.Tables[0].Rows[0];
                string federationID = dr["Federation"].ToString();
                strFedId = federationID;
                //Ram
                DataSet ds;
                ds = objGeneral.GetFederationDetails(strFJCIDFedId);
                if (strFJCIDFedId == strSanDiegoFedId && (strAppType != string.Empty && strAppType == "c"))
                {
                    strNextURL = ds.Tables[0].Rows[0]["NavigationURL"].ToString();
                }
                else if (strFJCIDFedId == "93" && (strAppType != string.Empty && strAppType == "c"))
                {
                    strNextURL = ds.Tables[0].Rows[0]["NavigationURL"].ToString();
                }
                else if (strFJCIDFedId == strPJLFedId && (strAppType != string.Empty && strAppType == "c"))
                {
                    strNextURL = ds.Tables[0].Rows[0]["NavigationURL"].ToString();
                }
                else if (strFJCIDFedId == strCMARTFedId && (strAppType != string.Empty && strAppType == "c"))
                {
                    strNextURL = ds.Tables[0].Rows[0]["NavigationURL"].ToString();
                }
                else if (doStep1_WD_CAL_Page(federationID))
                {
                    strNextURL = strWashingtonCampAiryLouiseURL;
                }
                else
                {
                    strNextURL = strStep1QuestionsURL;

                }
                Session["ZIPCODE"] = Info.ZipCode; //zip code will be used in step1_questions.aspx 

            }


        }

        int codeValue = Convert.ToInt32(Session["codeValue"]);
        if (strAction == "INSERT")
        {
            ProcessCamperInfo(Info);
            if (codeValue == 6)
                InsertCamperAnswers();
            hdnPerformAction.Value = "UPDATE";
        }
        else if (strAction == "UPDATE")
        {
            strCheckUpdate = CheckforUpdate();
            if ((Info.ModifiedBy == strCamperUserId) && (strCheckUpdate == "0")) //some modification done and user is not admin
                ProcessCamperInfo(Info);
        }

        //PJL Day School code verification.
        if (codeValue == 1)
            validatePJLDaySchoolCodeRedirection();

        //to update the Federation Id for the particular FJCID
        //this will take care of federation changes for a particular application
        if (strFedId != string.Empty && strNextURL != strStep1QuestionsURL)
            CamperAppl.UpdateFederationId(hdnFJCID.Value, strFedId);
        //added by sreevani as because when fedid is updated camper answers are cleared and even special codes are cleared from tblcamperanswers.
        if (txtSplCode.Text != "" && Convert.ToInt32(Session["codeValue"]) == 6)
            InsertCamperAnswers();
        if (UserInfo.IsJewish == "2")
        {
            Session["STATUS"] = StatusInfo.NonJewish;
            strNextURL = "ThankYou.aspx";
        }
        if (strNextURL == "" && strFedId == "" && strSplURL != "")
        {
            strNextURL = strSplURL;
            Session["splCode"] = txtSplCode.Text;
        }

        if (strNextURL == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "No Federation exists for the given Zip Code";
        }
        else
        {
            Session["FJCID"] = hdnFJCID.Value;

            if (txtSplCode.Text.ToUpper() == ConfigSpecialPJLCode || txtSplCode.Text.ToUpper() == ConfigSpecialPJLCapitalCode || txtSplCode.Text.ToUpper() == ConfigRamahDarom)
                Response.Redirect(strNationalURL);
            else
            {
                Response.Redirect(strNextURL);
            }

        }
    }

    //to redirect to nycamp redirect page for special camps by sreevani.
    protected string getIntermediateRedirection(string strFJCIDFedId, string strFedId)
    {
        if (strFJCIDFedId != "" && strFJCIDFedId != "0")
        {

            if (Session["FJCID"] != null)
            {
                DataSet dsForCampIDandURL = new DataSet();
                string strNextURL = "";
                string CampID = "";
                dsForCampIDandURL = CamperAppl.getCamperAnswers(Session["FJCID"].ToString(), "10", "10", "N");
                if (dsForCampIDandURL.Tables[0].Rows.Count > 0)
                    CampID = dsForCampIDandURL.Tables[0].Rows[0]["Answer"].ToString();
                if (CampID != "")
                {
                    //UAT movement check in, if we move it to PROD need to comment 2117, 2093 camps as they are not yet moved to PROD
                    if ((strFJCIDFedId == "46") || (CampID == "3037") || (CampID == "3079") || (CampID == "3078") || (CampID == "3013") || (CampID == "3009"))//|| (CampID == "2117") || (CampID == "2093")) //|| (CampID == "2158") 
                    {
                        Session["CampID"] = CampID;
                        dsForCampIDandURL = objGeneral.GetFederationDetails(strFJCIDFedId);
                        if (dsForCampIDandURL.Tables[0].Rows.Count > 0)
                        {
                            strNextURL = dsForCampIDandURL.Tables[0].Rows[0]["NavigationURL"].ToString();
                        }
                        Session["nxtURL"] = strNextURL;
                        if (txtSplCode.Text == "")
                            Response.Redirect("~/NYCampRedirect.aspx");
                        else
                        {
                            Session["splCode"] = txtSplCode.Text;
                            strFedId = strFJCIDFedId;
                        }
                    }
                    else
                        strFedId = strFJCIDFedId;
                }
                else
                    strFedId = strFJCIDFedId;

            }
            else
                strFedId = strFJCIDFedId;
        }
        return strFedId;
    }

    //to insert the Camper Info to the database
    protected void ProcessCamperInfo(UserDetails UInfo)
    {
        int Rowsaffected;
        string strCamperLoginId = "", strFJCID, Action;
        Administration objAdmin = new Administration();
        Action = hdnPerformAction.Value;

        //*********************************
        //for backward comarability purpose
        //*********************************
        if (UInfo.Gender != null)
        {
            if (Convert.ToInt32(UInfo.Gender) <= 0)
                UInfo.Gender = null;
        }
        else
            UInfo.Gender = null;

        if (UInfo.CMART_MiiP_ReferalCode == string.Empty)
            UInfo.CMART_MiiP_ReferalCode = null;


        try
        {
            if ((UInfo.FirstName != "" || UInfo.LastName != "") && bPerformUpdate)
            {
                if (Action == "INSERT")
                {
                    if (!string.IsNullOrEmpty(UInfo.ModifiedBy))
                    {
                        Rowsaffected = CamperAppl.InsertCamperInfo(UInfo, out strFJCID);
                        if (Session["CamperLoginID"] != null)
                            strCamperLoginId = Session["CamperLoginID"].ToString();

                        //to set the Camper Id with the FederationId
                        if (strCamperLoginId != "" && strFJCID != "")
                            objAdmin.LinkFJCIDsCamper(Convert.ToInt32(strCamperLoginId), strFJCID);

                        //getting the FJCID from the table after performing insert
                        hdnFJCID.Value = strFJCID;
                    }
                }
                else if (Action == "UPDATE" && !string.IsNullOrEmpty(UInfo.FJCID) && !string.IsNullOrEmpty(UInfo.ModifiedBy))
                {
                    Rowsaffected = CamperAppl.UpdateCamperInfo(UInfo);
                }
            }
        }
        finally
        {
            objAdmin = null;
        }
    }

    // to check whether the 
    private string CheckforUpdate()
    {
        string retval = string.Empty;
        if ((UserInfo.FirstName == null) && (UserInfo.LastName == null))
        {
            UserInfo = getUserInfoStructwithValues();
        }
        CamperAppl.IsCamperBasicInfoUpdated(UserInfo, out retval);
        return retval;
    }

    //to get the struct with the User info values
    public UserDetails getUserInfoStructwithValues()
    {
        UserInfo = new UserDetails();
        string strDOB, strAge;
        strDOB = txtDOB.Text.Trim();
        strAge = txtAge.Text.Trim();
        //to pass in the null value to the database if the date is not a valid one
        if (!objGeneral.IsDate(strDOB))
        {
            strDOB = UserInfo.DateofBirth; //null value
            strAge = UserInfo.Age; //null value
        }
        //setting the user input values to the struct 'UserInfo'
        UserInfo.FirstName = txtFirstName.Text.Trim();
        UserInfo.LastName = txtLastName.Text.Trim();
        UserInfo.Address = txtAddress.Text.Trim();
        UserInfo.Country = ddlCountry.SelectedValue;
        UserInfo.State = ddlState.SelectedValue;

        if (!ddlCity.SelectedItem.Text.Equals("OTHERS"))
            UserInfo.City = ddlCity.SelectedItem.Text;
        else
            UserInfo.City = txtCityOthers.Text;

        //UserInfo.City = txtCity.Text.Trim();

        //change by siva to truncate the zip code to first five digits.
        string strZip = txtZipCode.Text.Trim();
        if (ddlCountry.SelectedValue == "1")
        {
            if (strZip.Length > 5)
            {
                txtZipCode.Text = strZip.Substring(0, 5);
            }
        }
        else
        {
            if (strZip.Length > 7)
            {
                txtZipCode.Text = strZip.Substring(0, 7);
            }
        }
        // end change.


        UserInfo.ZipCode = txtZipCode.Text.Trim();
        //commented by sreevani as part of removing email field.
        UserInfo.PersonalEmail = "";//txtEmail.Text.Trim();
        UserInfo.DateofBirth = strDOB;
        UserInfo.Age = strAge;
        UserInfo.Comments = txtComments.Text.Trim();
        UserInfo.ModifiedBy = Master.UserId;
        UserInfo.FJCID = hdnFJCID.Value;
        UserInfo.Gender = ddlGender.SelectedValue;

        //AG 10/15/2009
        UserInfo.HomePhone = txtHomePhone1.Text;
        if (rdbJewish.Items[0].Selected == true)
            UserInfo.IsJewish = "1";
        else if (rdbJewish.Items[1].Selected == true)
            UserInfo.IsJewish = "2";
        else
            UserInfo.IsJewish = "0";

        if (txtSplCode.Text.Trim().Equals(string.Empty))
            UserInfo.CMART_MiiP_ReferalCode = DBNull.Value.ToString();
        else if (Convert.ToInt32(Session["codeValue"]) == 2)
            UserInfo.CMART_MiiP_ReferalCode = txtSplCode.Text.Trim();

        if (txtSplCode.Text.Trim().Equals(string.Empty))
            UserInfo.PJLCode = DBNull.Value.ToString();
        else if (Convert.ToInt32(Session["codeValue"]) == 1)
            UserInfo.PJLCode = txtSplCode.Text.Trim();
        //by sandhya
        if (txtSplCode.Text.Trim().Equals(string.Empty))
            UserInfo.NLCode = DBNull.Value.ToString();
        else if (Convert.ToInt32(Session["codeValue"]) == 3 || (Convert.ToInt32(Session["codeValue"]) == 5))
            UserInfo.NLCode = txtSplCode.Text.Trim();

        return UserInfo;
    }

    //to get the Camper Info from the database
    protected void getUserInfo()
    {
        string strFJCID = hdnFJCID.Value;
        string strDOB, strAge;

        hdnPerformAction.Value = "INSERT";

        if (strFJCID != "")
        {
            UserInfo = CamperAppl.getCamperInfo(strFJCID);
            if (UserInfo.FirstName != null || UserInfo.LastName != null)
            {
                //update action has to be performed
                hdnPerformAction.Value = "UPDATE";
                strDOB = UserInfo.DateofBirth;
                strAge = UserInfo.Age;
                if (objGeneral.IsDate(strDOB))
                {
                    strDOB = Convert.ToDateTime(strDOB).ToShortDateString();
                }
                else
                {
                    strDOB = string.Empty;
                    strAge = string.Empty;
                }
                //setting the user input values to the struct 'UserInfo'
                txtFirstName.Text = UserInfo.FirstName;
                txtLastName.Text = UserInfo.LastName;
                txtAddress.Text = UserInfo.Address;
                ddlCountry.SelectedValue = UserInfo.Country;
                ddlState.SelectedValue = UserInfo.State;
                //txtCity.Text = UserInfo.City;
                txtZipCode.Text = UserInfo.ZipCode;
                //commented by sreevani to remove email field
                //txtEmail.Text = UserInfo.PersonalEmail;
                txtDOB.Text = strDOB;
                txtAge.Text = strAge;
                if (!(UserInfo.CMART_MiiP_ReferalCode).Equals(string.Empty))
                    txtSplCode.Text = UserInfo.CMART_MiiP_ReferalCode;
                if (!(UserInfo.PJLCode).Equals(string.Empty))
                    txtSplCode.Text = UserInfo.PJLCode;
                if (!(UserInfo.NLCode).Equals(string.Empty))
                    txtSplCode.Text = UserInfo.NLCode;
                //AG: 10/15/2009
                txtHomePhone1.Text = UserInfo.HomePhone;
                if (UserInfo.IsJewish == "2")
                    rdbJewish.Items[1].Selected = true;
                else if (UserInfo.IsJewish == "1")
                    rdbJewish.Items[0].Selected = true;

                //populate city combo and select the value
                getCities(UserInfo.ZipCode, UserInfo.City);

                getGenders(strFJCID, UserInfo.Gender);

                SetCountryValidationRules(UserInfo.Country);
            }
        }
    }

    private void getCities(string strZip, string strCity)
    {
        DataSet dsCityState;
        string strCountry = ddlCountry.SelectedItem.Value;
        dsCityState = objGeneral.get_CityState(strZip, strCountry);

        ddlCity.DataSource = dsCityState;
        ddlCity.DataTextField = "City";
        ddlCity.DataValueField = "ID";
        ddlCity.DataBind();

        bool cityExists = false;
        foreach (DataRow row in dsCityState.Tables[0].Rows)
        {
            if (row["City"].ToString().Equals(strCity))
                cityExists = true;
        }

        if (!cityExists && !(strCity == string.Empty))
            ddlCity.Items.Insert(0, new ListItem(strCity, "-1"));


        ddlCity.Items.Insert(ddlCity.Items.Count, new ListItem("OTHERS", "0"));

        if (!strCity.Equals(string.Empty))
        {
            int index = 0;
            foreach (ListItem item in ddlCity.Items)
            {
                if (item.Text == strCity)
                    ddlCity.SelectedIndex = index;
                index++;
            }
        }

        reqvalCity.Enabled = true;
        reqvalCityOther.Enabled = false;
        txtCityOthers.Enabled = false;
    }

    //to get all the states and bind it to the dropdownlist
    protected void get_States()
    {
        DataSet dsStates = new DataSet();
        try
        {
            dsStates = CamperAppl.get_States();
            ddlState.DataSource = dsStates;
            ddlState.DataTextField = "Name";
            ddlState.DataValueField = "ID";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        finally
        {
            dsStates.Clear();
            dsStates.Dispose();
            dsStates = null;
        }
    }

    //to get states of the selected country and bind it to the dropdownlist
    protected void get_CountryStates(int countryID)
    {
        DataSet dsStates = new DataSet();
        try
        {
            dsStates = CamperAppl.get_CountryStates(countryID);
            ddlState.DataSource = dsStates;
            ddlState.DataTextField = "Name";
            ddlState.DataValueField = "ID";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        finally
        {
            dsStates.Clear();
            dsStates.Dispose();
            dsStates = null;
        }
    }

    // Siva - 12/03/2008 - start change to fix the age calculation problem when enter key is pressed 
    // to calculate age of the camper
    private int calculateAgeOld(DateTime Birthdate)
    {
        int iAge;
        if (DateTime.Now.Month < 6)
        {
            iAge = (DateTime.Now.Year - Birthdate.Year) - 1;
            return iAge;
        }
        else
        {
            iAge = (DateTime.Now.Year - Birthdate.Year);
            return iAge;
        }
    }

    // age calculation leap year is not considered.
    private int calculateAge(DateTime birthDate)
    {
        // cache the current time
        DateTime now = DateTime.Today; // today is fine, don't need the timestamp from now
        // get the difference in years
        int years = now.Year - birthDate.Year;
        // subtract another year if we're before the
        // birth day in the current year
        if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
            --years;

        return years;
    }

    //2014-07-28 NLP special codes are used, we go to the NLP directly instead of going through the whole routing from community to PJL to NLP
    protected void validateNLCodeRedirection()
    {
        UserDetails Info;
        Info = getUserInfoStructwithValues();
        Session["ZIPCODE"] = Info.ZipCode;

        if (txtSplCode.Enabled)
        {
            if (txtSplCode.Text != "")
            {
                string currentCode = txtSplCode.Text.Trim().ToUpper();

                if (IsCodeInWashingtonCodes(currentCode))
                {
                    Session["FedId"] = 49;
                    Session["CampID"] = null;
                    InsertCamperAnswers();
                    strSplURL = "Washington/Summary.aspx";
                }
                else
                {
                    int CampYearID = Convert.ToInt32(Application["CampYearID"]);
                    if (SpecialCodeManager.IsValidCode(CampYearID, 0, currentCode))
                    {
                        ProcessCamperInfo(Info);
                        Session["FJCID"] = hdnFJCID.Value;
                        Response.Redirect(strNationalURL);
                    }
                }
            }
        }
        else
        {
            string splCode = txtSplCode.Text.ToUpper();

            ProcessCamperInfo(Info);

            if (!IsCodeInWashingtonCodes(splCode))
            {
                Response.Redirect(strNationalURL);
            }
        }
    }

    private bool IsCodeInWashingtonCodes(string currentCode)
    {
        //2012-01-16 Added Washington's special codes - please note that there exists DCCode, it might be previous requirement for Washington as well
        //string[] WashingtonCodes = ConfigurationManager.AppSettings["WashingtonCodes"].Split(new char[] { ',' });
        List<string> WashingtonCodes = SpecialCodeManager.GetAvailableCodes(Convert.ToInt32(Application["CampYearID"]), Convert.ToInt32(FederationEnum.WashingtonDC));

        // when moved to .NET 3.5 or above, remember to use lamda expression
        foreach (string code in WashingtonCodes)
        {
            if (code == currentCode)
                return true;
        }

        return false;
    }

    // 2012-11-13 This function check of there the code is day school code.  Note that it'll redirect to PJL summary page directly, bad design
    //added by sreevani for pjl day school code redirection 
    public void validatePJLDaySchoolCodeRedirection()
    {
        UserDetails Info;
        Info = getUserInfoStructwithValues();
        Session["ZIPCODE"] = Info.ZipCode;

        var oCA = new CamperApplication();
        int validate = oCA.validatePJLDSCode(txtSplCode.Text);
        if (validate == 0 || validate == 2)
        {
            //ProcessCamperInfo(Info);
            //InsertCamperAnswers();
            //oCA.updatePJLDSCode(txtSplCode.Text, hdnFJCID.Value);
            Session["FJCID"] = hdnFJCID.Value;
            //Session["FedId"] = ConfigurationManager.AppSettings["PJL"].ToString();
            //CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), "63");
            //Response.Redirect("~/Enrollment/PJL/Summary.aspx");
        }
    }

    // 2014-02-06 This function will check if user use "direct pass" code - this means this code will bring the user directly to the fed, even there is matching federation, or zip codes don't match
    public bool IsDirectPass(FederationEnum fed)
    {
        bool isDirectPass = SpecialCodeManager.IsValidDirectPassCode(Convert.ToInt32(Application["CampYearID"]), fed, txtSplCode.Text);
        if (isDirectPass)
        {
            UserDetails info = getUserInfoStructwithValues();
            Session["ZIPCODE"] = info.ZipCode;
            ProcessCamperInfo(info);
            InsertCamperAnswers();
            Session["FJCID"] = hdnFJCID.Value;

            var fedId = Convert.ToInt32(fed).ToString();
            Session["FedId"] = fedId;
            CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), fedId);
            return true;
        }
        return false;
    }

    // check for national program redirection.
    void checkNationalProgramRedirection()
    {
        CamperApplication oCA = new CamperApplication();
        string strFJCID;
        strFJCID = Session["FJCID"].ToString();
        DataSet dsCamperApplication;
        DataRow drCA;
        dsCamperApplication = oCA.getCamperApplication(strFJCID);
        drCA = dsCamperApplication.Tables[0].Rows[0];

        //string strNextURL = string.Empty, strAction, strCamperUserId, strCheckUpdate, strFedId = string.Empty;
        UserDetails Info;
        string strCheckUpdate;

        if (!string.IsNullOrEmpty(drCA["AppType"].ToString()))
        {
            if (drCA["AppType"].ToString() == "C" && (String.IsNullOrEmpty(drCA["Federationid"].ToString()) || (drCA["Federationid"].ToString() != "48" && drCA["Federationid"].ToString() != "63" && drCA["Federationid"].ToString() != "72")))
            {
                Info = getUserInfoStructwithValues();

                strCheckUpdate = CheckforUpdate();
                //values has been changed and comments field is empty (only for Admin)

                if (strCheckUpdate == "0") //some modification done and user is not admin
                    ProcessCamperInfo(Info);

                Response.Redirect("Step1_NL.aspx");
            }
        }
    }

    // check for the submit camper application status
    void SubmittedApplicationRedirection()
    {
        General oGen = new General();
        string strFJCID;
        strFJCID = Session["FJCID"].ToString();
        DataSet dsFedDetails;
        DataRow drFedDetails;
        dsFedDetails = oGen.GetFedDetailsForFJCID(strFJCID);
        drFedDetails = dsFedDetails.Tables[0].Rows[0];

        UserDetails Info;
        string strCheckUpdate;

        Info = getUserInfoStructwithValues();

        strCheckUpdate = CheckforUpdate();
        //values has been changed and comments field is empty (only for Admin)

        if (strCheckUpdate == "0") //some modification done and user is not admin
            ProcessCamperInfo(Info);

        Session["FedId"] = drFedDetails["FederationID"].ToString();

        string federationID = drFedDetails["FederationID"].ToString();

        //AG: 10/15/2009
        if (Info.IsJewish == "2")
        {
            Session["STATUS"] = StatusInfo.NonJewish;
            Response.Redirect(ConfigurationManager.AppSettings["AdminRedirURL"].ToString());
        }
        string strURL = drFedDetails["NavigationURL"].ToString();
        if (drFedDetails["CampID"].ToString() == "1146")
            strURL = strURL.Replace("URJ/", "URJ/Acadamy");

        if (doStep1questions(federationID))
            Response.Redirect(strStep1QuestionsURL);
        else if (Session["FedId"].ToString() == "66")
        {
            strURL = GetNationalProgramForCamp(drFedDetails["CampID"].ToString());
            Response.Redirect(strURL);
        }
        else
        {
            //2012-02-27 temporary code for new hemshpere fed, if querystring exsits, we allow it to pass through
            if (Request.QueryString["a"] == null)
                Response.Redirect(strURL);
            else
                Response.Redirect(strURL + "?a=a");
        }
    }
    //added by sandhya
    private string GetNationalProgramForCamp(string campid)
    {
        DataSet dsNationalProgram;
        string strURL = "";
        DataRow drNationalProgram;
        General objGeneral = new General();
        dsNationalProgram = objGeneral.GetNationalProgram(Convert.ToInt32(campid));
        if (dsNationalProgram.Tables[0].Rows.Count > 0)
        {
            drNationalProgram = dsNationalProgram.Tables[0].Rows[0];
            strURL = drNationalProgram["NavigationURL"].ToString();
        }
        else
            strURL = "";
        return strURL;
    }

    private bool doStep1questions(string strFedId)
    {
        string[] FedIds = new string[] { strJWestFedId, strOrangeFedId, strJWestLAId };
        if (Array.IndexOf(FedIds, strFedId) >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool doStep1_WD_CAL_Page(string strFedId)
    {
        string[] fedIds = new string[] { strWashingtonDCId };
        if (Array.IndexOf(fedIds, strFedId) >= 0)
        {
            return true;
        }
        else
            return false;
    }

    private void SetCountryValidationRules(string CountryCode)
    {
        //Change validation rule and max lenth of ZIP text box
        //regExpZipCode
        switch (CountryCode)
        {
            case "2":
                regExpZipCode.ValidationExpression = "[A-Z]\\d[A-Z] \\d[A-Z]\\d";
                regExpZipCode.ErrorMessage = "Please enter a valid Postal Code following this sample: K1A 0B1";
                reqvalState.ErrorMessage = "Please select the Province";
                txtZipCode.MaxLength = 7;
                lblState.Text = "Camper Province";
                lblZip.Text = "Camper Postal Code";
                lblZipMask.Text = "(K1A 0B1)";
                reqvalZipCode.ErrorMessage = "Please enter a valid Postal Code following this sample: K1A 0B1";
                Label25.Text = "(K1A 0B1)";
                break;
            case "1":
                regExpZipCode.ValidationExpression = "\\d{5}(-\\d{4})?";
                regExpZipCode.ErrorMessage = "Please enter a valid Zip Code following this sample: 12345";
                reqvalState.ErrorMessage = "Please select the State";
                txtZipCode.MaxLength = 5;
                lblState.Text = "Camper State";
                lblZip.Text = "Camper Zip Code";
                lblZipMask.Text = "(12345)";
                reqvalZipCode.ErrorMessage = "Please enter a valid Zip Code following this sample: 12345";
                Label25.Text = "(XXXXX)";
                break;
            case "3":
                regExpZipCode.ValidationExpression = "\\d{5}(-\\d{4})?";
                regExpZipCode.ErrorMessage = "Please enter a valid Zip Code following this sample: 12345";
                reqvalState.ErrorMessage = "Please select the State";
                txtZipCode.MaxLength = 5;
                lblState.Text = "Camper State";
                lblZip.Text = "Camper Zip Code";
                lblZipMask.Text = "(12345)";
                reqvalZipCode.ErrorMessage = "Please enter a valid Zip Code following this sample: 12345";
                Label25.Text = "(XXXXX)";
                break;

        }
    }

    protected void InsertCamperAnswers()
    {
        string strFJCID, strComments;
        int RowsAffected;
        string strCamperAnswers, strModifiedBy; //-1 for Camper (User id will be passed for Admin user)

        strFJCID = hdnFJCID.Value;

        //Modified by id taken from the common.master
        strModifiedBy = Master.UserId;

        //to get the comments (used by the Admin user)
        strComments = txtComments.Text.Trim();

        strCamperAnswers = ConstructCamperAnswers();

        if (strFJCID != "" && strCamperAnswers != "" && strModifiedBy != "" && bPerformUpdate)
            RowsAffected = CamperAppl.InsertCamperAnswers(strFJCID, strCamperAnswers, strModifiedBy, strComments);
        //added by sreevani for inserting camper answers if special codes are entered.
        if (txtSplCode.Text != "" && Convert.ToInt32(Session["codeValue"]) == 6)
        {
            if (Session["CampID"] != null && Session["CampID"] != "")
            {
                //strFJCID = hdnFJCID.Value;               
                string strQuestionId, strTablevalues = "", strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();

                //for question 1027
                if ((Session["CampID"]).ToString() == "3037")
                {
                    strQuestionId = "1027";
                    strTablevalues += strQuestionId + strFSeparator + strFSeparator + txtSplCode.Text;
                }
                else if ((Session["CampID"]).ToString() == "3079")
                {
                    strQuestionId = "1028";
                    strTablevalues += strQuestionId + strFSeparator + strFSeparator + txtSplCode.Text;
                }
                else if ((Session["CampID"]).ToString() == "3078")
                {
                    strQuestionId = "1029";
                    strTablevalues += strQuestionId + strFSeparator + strFSeparator + txtSplCode.Text;
                }
                else if ((Session["CampID"]).ToString() == "3009")
                {
                    strQuestionId = "1030";
                    strTablevalues += strQuestionId + strFSeparator + strFSeparator + txtSplCode.Text;
                }

                if (strFJCID != "" && strTablevalues != "" && strModifiedBy != "")
                    RowsAffected = CamperAppl.InsertCamperAnswers(strFJCID, strTablevalues, strModifiedBy, "");
            }
            if (Session["FedId"] != null && Session["FedId"] != "")
            {
                //strFJCID = hdnFJCID.Value;               
                string strQuestionId, strTablevalues = "", strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();

                //for question 1031
                if ((Session["FedId"]).ToString() == "49")
                {
                    strQuestionId = "1031";
                    strTablevalues += strQuestionId + strFSeparator + strFSeparator + txtSplCode.Text;
                }
                if (strFJCID != "" && strTablevalues != "" && strModifiedBy != "")
                    RowsAffected = CamperAppl.InsertCamperAnswers(strFJCID, strTablevalues, strModifiedBy, "");
            }
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

        strQuestionId = hdnQ1Id.Value;
        if (Session["CampID"] != null)
            strTablevalues += strQuestionId + strFSeparator + "2" + strFSeparator + Session["CampID"].ToString() + strQSeparator;

        //to remove the extra character at the end of the string, if any
        char[] chartoRemove = { Convert.ToChar(strQSeparator) };
        strTablevalues = strTablevalues.TrimEnd(chartoRemove);

        return strTablevalues;
    }

    void DifferentiateCodes()
    {
        Session["codeValue"] = 0;

        var currentCode = txtSplCode.Text.Trim().ToUpper();
        if (currentCode == "")
            return;

        if (currentCode.ToUpper().Contains("PJGTC"))//PJLCode
        {
            Session["codeValue"] = 1;
            Session["SpecialCodeValue"] = currentCode;
        }
        else if (currentCode.ToUpper().Contains("NLP"))//NL code
        {
            Session["codeValue"] = CodeNLP;
        }
        else if (IsCodeInWashingtonCodes(currentCode))
        {
            Session["codeValue"] = CodeWashinngton;
            Session["SpecialCodeValue"] = currentCode;
        }
        else
        {
            Session["codeValue"] = 99;  // an arbitrary number, so that code valication could pass
            Session["SpecialCodeValue"] = currentCode;
        }
    }

    #endregion
}
