using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CIPMSBC;

public partial class Step1_Can : System.Web.UI.Page
{
    private CamperApplication CamperAppl;
    private UserDetails UserInfo;
    private General objGeneral;
    private bool bPerformUpdate;

    private string strJWestFedId        = ConfigurationManager.AppSettings["JWest"];
    private string strOrangeFedId       = ConfigurationManager.AppSettings["Orange"];
    private string strNationalFedId     = ConfigurationManager.AppSettings["NationalLanding"];
    private string strLACIPId           = ConfigurationManager.AppSettings["LACIP"];
    private string strJWestLAId         = ConfigurationManager.AppSettings["JWestLA"];
    private string strStep1QuestionsURL = "Step1_Questions.aspx";
    private string strNationalURL       = "Step1_NL.aspx";
    
    protected void Page_Init(object sender, EventArgs e)
    {
        btnNext.Click += new EventHandler(btnNext_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
        txtZipCode.TextChanged += new EventHandler(txtZipCode_TextChanged);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
    }

    void txtZipCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //change by siva to truncate the zip code to first five digits.
            string strZip = txtZipCode.Text.Trim();
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
            // end change.

            PopulateStateCityForZIP(true);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    void btnReturnAdmin_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        string strCheckUpdate;
        string strCamperUserId = Master.CamperUserId;
        UserDetails Info;
        try
        {
            if (Page.IsValid)
            {
                strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"].ToString();
                //to get the user input values as struct object
                Info = getUserInfoStructwithValues();

                strCheckUpdate = CheckforUpdate();
                if ((Info.ModifiedBy == strCamperUserId)&&(strCheckUpdate == "0")) //some modification done and user is not admin
                    ProcessCamperInfo(Info);

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
        UserDetails Info;
        
        try
        {
            Page.Validate();
            if (Page.IsValid)
            {
                //strRedirURL = ConfigurationManager.AppSettings["SaveExitRedirURL"].ToString();
                strRedirURL = Master.SaveandExitURL;
                //to get the user input values as struct object
                Info = getUserInfoStructwithValues();
                ProcessCamperInfo(Info);
                //Session["FJCID"] = null;
                //Session["ZIPCODE"] = null;
               // Session.Abandon();
                //Response.Redirect(strRedirURL);
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
    
    void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CamperAppl = new CamperApplication();
            objGeneral = new General();
            
            if (!(Page.IsPostBack))
            {
                //temp
                reqvalCityOther.Enabled = false;

                //to set the range for the dob validator
                rangeDOB.MinimumValue = "01/01/" + Convert.ToString(DateTime.Now.Year - 50);
                rangeDOB.MaximumValue = DateTime.Now.ToShortDateString();
                rangeDOB.ErrorMessage = "Please enter a valid Date of Birth between " + rangeDOB.MinimumValue + " and " + rangeDOB.MaximumValue;
                get_States();

                if (Session["FJCID"] != null)
                {
                    hdnFJCID.Value = Session["FJCID"].ToString();
                    //to get the User Info from the database if the user is a returning user
                    getUserInfo();
                }
                else  //new user insert
                {
                    hdnPerformAction.Value = "INSERT";
                    getGenders(string.Empty, string.Empty); 
                }

                PopulateStateCityForZIP(false);
                txtAge.Attributes.Add("readonly", "readonly");
            }
            //PopulateStateCityForZIP();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    private void getGenders(string strFJCID, string Gender)
    {
        DataSet dtGenders;
        dtGenders = CamperAppl.get_Genders();
        ddlGender.DataSource = dtGenders;
        ddlGender.DataTextField = "Description";
        ddlGender.DataValueField = "ID";
        ddlGender.DataBind();

        //Site x = Page.Master as Site;
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
                    string strSubmittedDate = string.Empty;;
                    if (!dr["SUBMITTEDDATE"].Equals(DBNull.Value))
                        strSubmittedDate = dr["SUBMITTEDDATE"].ToString();

                    //to get the modified by user6
                    int iModifiedBy;
                    string CamperUserId = ConfigurationManager.AppSettings["CamperModifiedBy"].ToString();
                    iModifiedBy = Convert.ToInt16(CamperUserId);
                    if (!dr["MODIFIEDUSER"].Equals(DBNull.Value))
                        iModifiedBy = Convert.ToInt16(dr["MODIFIEDUSER"]);
                    
                    //Camper Application has been submitted (or) the Application has been modified by a Admin
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
        string strZip;
        string strCountry = ddlCountry.SelectedItem.Value;
        //to populate the state and city automatically for the zip
        strZip = txtZipCode.Text.Trim();
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


                ddlState.SelectedValue = drCityState["State"].ToString();
                ddlState.Enabled=false;
                //txtCity.Attributes.Add("readonly", "true");
            }
            else
            {
                
                ddlState.Enabled=true;
                //txtCity.Attributes.Remove("readonly");

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
            //txtCity.Attributes.Remove("readonly");
        }
        if (IsPostBack)
            txtAddress.Focus();
    }

    void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                string strNextURL = string.Empty, strAction, strCamperUserId, strCheckUpdate, strFedId = string.Empty;
                UserDetails Info;
                DataSet dsFed;
                DataRow dr;
                int iCount;

                // Siva - 12/03/2008 - start change to fix the age calculation problem when enter key is pressed 
                DateTime CamperBirthDate = Convert.ToDateTime(txtDOB.Text);
                txtAge.Text = calculateAge(CamperBirthDate).ToString();
                // Siva - 12/03/2008 - end change

                //to get the user input values as struct object
                Info = getUserInfoStructwithValues();
                strAction = hdnPerformAction.Value;
                strCamperUserId = Master.CamperUserId;

                Session["ZIPCODE"] = Info.ZipCode;

                if (Session["FJCID"] != null)
                {
                    General oGen = new General();
                    if (oGen.IsApplicationSubmitted(Session["FJCID"].ToString()))
                    {
                        SubmittedApplicationRedirection();
                    }

                }

                if (Info.ModifiedBy == strCamperUserId && Session["FJCID"] != null)
                    checkNationalProgramRedirection();

                dsFed = objGeneral.GetFederationForZipCode(Info.ZipCode);
                iCount = dsFed.Tables[0].Rows.Count;
                if (iCount > 0)
                {
                    if (iCount == 1)
                    {
                        dr = dsFed.Tables[0].Rows[0];
                        strFedId = dr["Federation"].ToString();
                        //to check if the FedId is in the FedIds array declared above
                        if (doStep1questions(strFedId))
                        {
                            strNextURL = strStep1QuestionsURL;
                            Session["ZIPCODE"] = Info.ZipCode; //zip code will be used in step1_questions.aspx
                        }
                        else //it is not jwest/orange/jwest la / la cip
                        {
                            //to get the navigation url for the federation based on the federation id
                            DataSet ds;
                            ds = objGeneral.GetFederationDetails(strFedId);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                strNextURL = ds.Tables[0].Rows[0]["NavigationURL"].ToString();
                                //sesion[fedid] will be set only if it is not jwest or orange county
                                //for jwest and orange county it will be set in step1_questions.aspx
                                Session["FEDID"] = strFedId;
                            }
                            else
                                strNextURL = "";
                        }
                    }
                    else if (iCount > 1)  //the zip code is applicable for both Jwest /Orange/jwest la / la cip
                    {
                        strFedId = string.Empty;
                        strNextURL = strStep1QuestionsURL;
                        Session["ZIPCODE"] = Info.ZipCode; //zip code will be used in step1_questions.aspx

                        //Ageks Grinberg
                        dr = dsFed.Tables[0].Rows[0];
                        string federationID = dr["Federation"].ToString();
                    }
                }
                else
                {
                    strFedId = string.Empty;
                    strNextURL = strNationalURL;  //to be redirected to National Landing page
                }

                if (strAction == "INSERT")
                {
                    ProcessCamperInfo(Info);
                    hdnPerformAction.Value = "UPDATE";
                }
                else if (strAction == "UPDATE")
                {
                    strCheckUpdate = CheckforUpdate();
                    if ((Info.ModifiedBy == strCamperUserId)&&(strCheckUpdate == "0")) //some modification done and user is not admin
                        ProcessCamperInfo(Info);
                }

                //to update the Federation Id for the particular FJCID
                //this will take care of federation changes for a particular application
                if (strFedId != string.Empty && strNextURL != strStep1QuestionsURL)
                    CamperAppl.UpdateFederationId(hdnFJCID.Value, strFedId);

                if (strNextURL == "")
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "No Federation exists for the given Zip Code";
                }
                else
                {
                    Session["FJCID"] = hdnFJCID.Value;
                    Response.Redirect(strNextURL);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    //to insert the Camper Info to the database
    protected void ProcessCamperInfo(UserDetails UInfo)
    {
        int Rowsaffected;
        string strCamperLoginId="", strFJCID, Action;
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


        try
        {
            if ((UInfo.FirstName != "" || UInfo.LastName != "")&&bPerformUpdate)
            {
                if (Action=="INSERT")
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
                else if (Action =="UPDATE" && !string.IsNullOrEmpty(UInfo.FJCID) && !string.IsNullOrEmpty(UInfo.ModifiedBy))
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
        string retval;
        if ((UserInfo.FirstName == null) && (UserInfo.LastName == null))
        {
            UserInfo = getUserInfoStructwithValues();
        }
        CamperAppl.IsCamperBasicInfoUpdated(UserInfo, out retval);
        return retval;
    }

    //to get the struct with the User info values
    private UserDetails getUserInfoStructwithValues()
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
        UserInfo.PersonalEmail = txtEmail.Text.Trim();
        UserInfo.DateofBirth = strDOB;
        UserInfo.Age = strAge;
        UserInfo.Comments = txtComments.Text.Trim();
        UserInfo.ModifiedBy = Master.UserId;
        UserInfo.FJCID = hdnFJCID.Value;
        UserInfo.Gender = ddlGender.SelectedValue;
        return UserInfo;
        
    }

    //to get the Camper Info from the database
    protected void getUserInfo()
    {
        string strFJCID = hdnFJCID.Value;
        string strDOB, strAge;
        
        if (!strFJCID.Equals(string.Empty))
        {   
            UserInfo = CamperAppl.getCamperInfo(strFJCID);
            if (UserInfo.FirstName != null || UserInfo.LastName!=null)
            {
                //update action has to be performed
                hdnPerformAction.Value = "UPDATE";
                strDOB = UserInfo.DateofBirth;
                strAge = UserInfo.Age;
                if (objGeneral.IsDate(strDOB))
                    strDOB = Convert.ToDateTime(strDOB).ToShortDateString();
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
                txtEmail.Text = UserInfo.PersonalEmail;
                txtDOB.Text = strDOB;
                txtAge.Text = strAge;

                //populate city combo and select the value
                getCities(UserInfo.ZipCode, UserInfo.City);

                getGenders(strFJCID, UserInfo.Gender);
                //ddlGender.SelectedValue = UserInfo.Gender;
                SetCountryValidationRules(UserInfo.Country);


            }
            else //new user - perform insert
                hdnPerformAction.Value = "INSERT";
        }
        else //new application
            hdnPerformAction.Value = "INSERT";
    }
    
    private void getCities(string strZip, string strCity)
    {
        DataSet dsCityState;
        string strCountry = ddlCountry.SelectedItem.Value;
        dsCityState = objGeneral.get_CityState(strZip,strCountry);
        
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

        //int index = dsCityState.Tables[0].Rows.Count;

        ddlCity.Items.Insert(ddlCity.Items.Count, new ListItem("OTHERS", "0"));

        if (!strCity.Equals(string.Empty))
        {
            int index = 0;
            foreach(ListItem item in ddlCity.Items)
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
            ddlState.Items.Insert(0,new ListItem("-- Select --","0"));
        }
        finally
        {
            dsStates.Clear();
            dsStates.Dispose();
            dsStates = null;
        }
    }

    //page unload
    void Page_Unload(object sender, EventArgs e)
    {
        CamperAppl = null;
        objGeneral = null;
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

    //to validate the comments for Admin user
    void CusValComments_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
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
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    // Siva - 12/03/2008 - end change
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
            if (drCA["AppType"].ToString() == "C")
            {
                Info = getUserInfoStructwithValues();
                //strAction = hdnPerformAction.Value;
                //strCamperUserId = Master.CamperUserId;

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

        //string strNextURL = string.Empty, strAction, strCamperUserId, strCheckUpdate, strFedId = string.Empty;
        UserDetails Info;
        string strCheckUpdate;

        Info = getUserInfoStructwithValues();
 
        strCheckUpdate = CheckforUpdate();
        //values has been changed and comments field is empty (only for Admin)

        if (strCheckUpdate == "0") //some modification done and user is not admin
            ProcessCamperInfo(Info);

        Session["FEDID"] = drFedDetails["FederationID"].ToString();

        string federationID = drFedDetails["FederationID"].ToString();
        if (doStep1questions(federationID))
            Response.Redirect(strStep1QuestionsURL);
        else
            Response.Redirect(drFedDetails["NavigationURL"].ToString());
    }

    private bool doStep1questions(string strFedId)
    {
        string[] FedIds = new string[] { strJWestFedId, strOrangeFedId, strLACIPId, strJWestLAId };
        if (Array.IndexOf(FedIds, strFedId) >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetCountryValidationRules(ddlCountry.SelectedItem.Value);
    }

    private void SetCountryValidationRules(string CountryCode)
    {
        //Change validation rule and max lenth of ZIP text box
        //regExpZipCode
        switch (CountryCode)
        {
            case "2":
                regExpZipCode.ValidationExpression = "[A-Z]\\d[A-Z] \\d[A-Z]\\d";
                txtZipCode.MaxLength = 7;
                break;
            case "1":
                regExpZipCode.ValidationExpression = "\\d{5}(-\\d{4})?";
                txtZipCode.MaxLength = 5;
                break;
        }
    }
}
