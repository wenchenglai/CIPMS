using System;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using CIPMSBC;

public partial class Step3_Parentinformation : System.Web.UI.Page
{
    private CamperApplication CamperAppl;
    private General objGeneral;
    private UserDetails UserInfo;
    private CamperFooter cFooter;
    private Boolean bPerformUpdate;

    protected void Page_Init(object sender, EventArgs e)
    {
        btnNext.Click += new EventHandler(btnNext_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
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
                ProcessParentInfoValues();
                //Session["FJCID"] = null;
                //Session["ZIPCODE"] = null;
                //Session["FEDNAME"] = null;
                //Session["FedId"] = null;
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
        try
        {
            CamperAppl = new CamperApplication();
            objGeneral = new General();
            cFooter = (CamperFooter)Master.FindControl("CamperFooter1");

            if (!Page.IsPostBack)
            {
                //to fill the state values from the database
                //get_States();

                if (Session["FJCID"] != null)
                {
                    hdnFJCID_ParentInfo.Value = (string)Session["FJCID"];
                    //to get the parent(s) information for the FJCID
                    getParentInfo();
                }
                else
                    hdnPerformAction.Value = "INSERT";

                setURLReferrer();

                //if the camper is filling the application for the first time then take the values
                //entered in step 1 of the application
                if (hdnPerformAction.Value == "INSERT")
                    FillUserDetails();

                SetCountryValidationRules(ddlCountry1.SelectedValue);
                SetCountryValidationRules(ddlCountry2.SelectedValue);
            }
        }
        catch (Exception ex)
        { 
            Response.Write(ex.Message);
        }
    }

    //to set the URL REFERER (to be used in Other Info page)
    void setURLReferrer()
    {
        string strURLReferrer;
        if (Request.UrlReferrer != null)
        {
            strURLReferrer = Request.UrlReferrer.AbsolutePath;
            if (!string.IsNullOrEmpty(strURLReferrer))
            {
                strURLReferrer = strURLReferrer.ToUpper();
                if (strURLReferrer.IndexOf("BOSTON") >= 0)
                    Session["FEDNAME"] = "BOSTON";
                else if (strURLReferrer.IndexOf("GREENSBORO") >= 0)
                    Session["FEDNAME"] = "GREENSBORO";
                else
                    Session["FEDNAME"] = null;
            }
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
                if (!objGeneral.IsApplicationReadOnly(hdnFJCID_ParentInfo.Value, Master.CamperUserId))
                {
                    ProcessParentInfoValues();
                }
                //Session["FJCID"] = null;
                //Session["FEDNAME"] = null;
                //Session["ZIPCODE"] = null;
                //Session["FedId"] = null;
                //Session.Abandon();
               // Response.Redirect(strRedirURL, false);
                
                if (Master.CheckCamperUser == "Yes")
                {

                   // string strScript = "<script language=javascript> window.open('../ThankYouMessage.aspx','Message','toolbar=no,status=no,scroll=no,width=800,height=400'); window.location='" + strRedirURL + "';</script>";
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
        string strPreviousURL, strFedId;
        DataSet ds = new DataSet();
        General objGeneral = new General();

        if (!objGeneral.IsApplicationReadOnly(hdnFJCID_ParentInfo.Value, Master.CamperUserId))
        {
            ProcessParentInfoValues();
        }
        Session["FJCID"] = hdnFJCID_ParentInfo.Value;
        Session["FEDNAME"] = null;

        if (Session["FedId"] != null)
        {
            strFedId = Session["FedId"].ToString();
            //to get the navigation url for the federation based on the federation id

            ds = objGeneral.GetFederationDetails(strFedId);
            if (ds.Tables[0].Rows.Count > 0)
                strPreviousURL = ds.Tables[0].Rows[0]["ParentInfoPreviousClickURL"].ToString();
            else
                strPreviousURL = "";

            if (strPreviousURL != "")
            {
                if (Request.QueryString["camp"] == "tavor")
                    Response.Redirect("Step2_1.aspx?camp=tavor");
                else
                    Response.Redirect("Step2_1.aspx");
            }
        }
    }

    void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                if (!objGeneral.IsApplicationReadOnly(hdnFJCID_ParentInfo.Value, Master.CamperUserId))
                {
                    ProcessParentInfoValues();
                }
                Session["FJCID"] = hdnFJCID_ParentInfo.Value;

                if (Request.QueryString["camp"] == "tavor")
                    Response.Redirect("Step3_Otherinformation.aspx?camp=tavor");
                else
                    Response.Redirect("Step3_Otherinformation.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    //to post the parent info to the database
    protected void ProcessParentInfoValues()
    {
        int Rowsaffected;
        string strActiontobePerformed, strComments;

        //PARENT 1 INFO 

        //to get the comments value 
        strComments = txtComments.Text.Trim();
        strActiontobePerformed = hdnPerformAction.Value;

        //to get the parent 1 info
        UserInfo = new UserDetails();
        UserInfo = ConstructParentInfo("1"); //for parent 1 info
        if (UserInfo.FirstName != "" || UserInfo.LastName != "")
        {
            if (strActiontobePerformed == "INSERT")
            {
                //to insert the parent 1 info to the table
                Rowsaffected = CamperAppl.InsertParentInfo(UserInfo);
            }
            else if (strActiontobePerformed == "UPDATE" && bPerformUpdate) //UPDATE
                Rowsaffected = CamperAppl.UpdateParentInfo(UserInfo);
        }
        //END OF PARENT 1 INFO


        //PARENT 2 INFO

        //to get the parent 2 info
        UserInfo = new UserDetails();
        UserInfo = ConstructParentInfo("2"); //for parent 2 info
        //if (UserInfo.FirstName != "" || UserInfo.LastName != "")
        //{
        if (strActiontobePerformed == "INSERT")
        {
            //to insert the parent 2 info to the table
            Rowsaffected = CamperAppl.InsertParentInfo(UserInfo);
        }
        else if (strActiontobePerformed == "UPDATE" && string.IsNullOrEmpty(UserInfo.Parent2Id))//If Parent2 info is not present, insert the same else update it
            Rowsaffected = CamperAppl.InsertParentInfo(UserInfo);
        else if (strActiontobePerformed == "UPDATE" && bPerformUpdate)
            Rowsaffected = CamperAppl.UpdateParentInfo(UserInfo);
        //END OF PARENT 2 INFO
        //}
    }
    
    //to fill the user details which has been captured in the STep1.aspx
    private void FillUserDetails()
    {
        string strFJCID = hdnFJCID_ParentInfo.Value;

        if (strFJCID != string.Empty)
        {
            UserInfo = CamperAppl.getCamperInfo(strFJCID);
            if (UserInfo.FirstName != null)
            {
                //setting the user input values from the struct 'UserInfo'
                txtAddress1.Text = UserInfo.Address;
                ddlCountry1.SelectedValue = UserInfo.Country;
                //AG
                get_CountryStates(ddlState1, int.Parse(UserInfo.Country));

                ddlState1.SelectedValue = UserInfo.State;
                txtCity1.Text = UserInfo.City;
                txtZipCode1.Text = UserInfo.ZipCode;

                txtHomePhone1.Text = UserInfo.HomePhone;

                //txtAddress2.Text = UserInfo.Address;
                //ddlCountry2.SelectedValue = UserInfo.Country;
                //ddlState2.SelectedValue = UserInfo.State;
                //txtCity2.Text = UserInfo.City;
                //txtZipCode2.Text = UserInfo.ZipCode;

                ddlCountry2.SelectedValue = UserInfo.Country;
                get_CountryStates(ddlState2, int.Parse(UserInfo.Country));
                SetState2Label(UserInfo.Country);
            }
        }
    }
    
    //to get the parent info is there in the database
    private void getParentInfo()
    {
        string strFJCID = hdnFJCID_ParentInfo.Value;
        string strParent1Id;
        string strParent2Id;
        //to get the parent 1 info
        UserInfo = CamperAppl.getParentInfo(strFJCID, "Y");
        if (!string.IsNullOrEmpty(UserInfo.FirstName))
        {
            //set the hidden value (whether to Insert or update the Parent Info)
            hdnPerformAction.Value = "UPDATE";
            //to fill the parent 1 info
            txtFirstName1.Text = UserInfo.FirstName;
            txtLastName1.Text = UserInfo.LastName;
            txtAddress1.Text = UserInfo.Address;
            ddlCountry1.SelectedValue = UserInfo.Country;
            //AG
            get_CountryStates(ddlState1, int.Parse(UserInfo.Country));

            ddlState1.SelectedValue = UserInfo.State;
            txtCity1.Text = UserInfo.City;
            txtZipCode1.Text = UserInfo.ZipCode;
            txtPersonalEmail1.Text = UserInfo.PersonalEmail;
            txtPersonalEmail1Confirm.Text = UserInfo.PersonalEmail;
            txtWorkEmail1.Text = UserInfo.WorkEmail;
            txtHomePhone1.Text = UserInfo.HomePhone;
            txtWorkPhone1.Text = UserInfo.WorkPhone;
            strParent1Id = UserInfo.Parent1Id;

            //to get the Parent 2 info
            UserInfo = CamperAppl.getParentInfo(strFJCID, "N");
            //to fill the parent 2 info
            //if (UserInfo.FirstName != null)  //then parent info 2 exists
            //{
            txtFirstName2.Text = UserInfo.FirstName;
            txtLastName2.Text = UserInfo.LastName;
            txtAddress2.Text = UserInfo.Address;
            ddlCountry2.SelectedValue = UserInfo.Country;
            SetState2Label(UserInfo.Country);
            get_CountryStates(ddlState2, int.Parse(UserInfo.Country));
            if (!string.IsNullOrEmpty(UserInfo.State))
                ddlState2.SelectedValue = UserInfo.State;
            else
                ddlState2.SelectedValue = "0";
            txtCity2.Text = UserInfo.City;
            txtZipCode2.Text = UserInfo.ZipCode;
            txtPersonalEmail2.Text = UserInfo.PersonalEmail;
            txtWorkEmail2.Text = UserInfo.WorkEmail;
            txtHomePhone2.Text = UserInfo.HomePhone;
            txtWorkPhone2.Text = UserInfo.WorkPhone;
            strParent2Id = UserInfo.Parent1Id;
            //}
        }
        else //set the hidden value (whether to Insert or update the Parent Info)
            hdnPerformAction.Value = "INSERT";
    }
    
    //to get all the states and bind it to the dropdownlist
    protected void get_States()
    {
        DataSet dsStates = new DataSet();
        try
        {
            dsStates = CamperAppl.get_States();

            ddlState1.DataSource = dsStates;
            ddlState1.DataTextField = "Name";
            ddlState1.DataValueField = "ID";
            ddlState1.DataBind();
            ddlState1.Items.Insert(0, new ListItem("-- Select --", "0"));

            ddlState2.DataSource = dsStates;
            ddlState2.DataTextField = "Name";
            ddlState2.DataValueField = "ID";
            ddlState2.DataBind();
            ddlState2.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        catch (Exception ex)
        { throw ex; }
        finally
        {
            dsStates.Clear();
            dsStates.Dispose();
            dsStates = null;
        }
    }

    //to validate the comments field for admin users
    void CusValComments_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            string strRetVal, strUserId, strCamperUserId, strComments;
            strUserId = Master.UserId;
            strCamperUserId = Master.CamperUserId;
            strComments = txtComments.Text.Trim();
            UserInfo = ConstructParentInfo("1"); //to get the parent 1 info values

            //to check whether the parent info 1 values has been modified
            CamperAppl.IsParentInfoUpdated(ConstructParentInfo("1"), out strRetVal);

            //to check whether the parent info 2 has modified values
            if (strRetVal.Equals("1")) //the data is not modified for parent info 1
                CamperAppl.IsParentInfoUpdated(ConstructParentInfo("2"), out strRetVal);

            if (strUserId != strCamperUserId) //then the user is admin user
            {
                switch (strRetVal)
                {
                    case "0": //data has been modified
                        if (strComments == "")
                        {
                            args.IsValid = false;
                            bPerformUpdate = false;
                            return;
                        }
                        else
                        {
                            args.IsValid = true;
                            bPerformUpdate = true;
                            return;
                        }

                    case "1": //data is not modified
                        args.IsValid = true;
                        bPerformUpdate = false;
                        return;

                }
            }
            else //the user is camper
            {
                switch (strRetVal)
                {
                    case "0": //data has been modified
                        bPerformUpdate = true;
                        break;
                    case "1": //data is not modified
                        bPerformUpdate = false;
                        break;
                }
                args.IsValid = true;
                return;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    private UserDetails ConstructParentInfo(string ParentId)
    {
        UserInfo = new UserDetails();
        string strFJCID, strModifiedBy, strComments;
        strFJCID = hdnFJCID_ParentInfo.Value;
        strModifiedBy = Master.UserId;
        strComments = txtComments.Text.Trim();
        UserInfo.FJCID = strFJCID;
        UserInfo.ModifiedBy = strModifiedBy;
        UserInfo.Comments = strComments;
        if (ParentId == "1")
        {
            UserInfo.FirstName = txtFirstName1.Text.Trim();
            UserInfo.LastName = txtLastName1.Text.Trim();
            UserInfo.Address = txtAddress1.Text.Trim();
            UserInfo.Country = ddlCountry1.SelectedValue;
            UserInfo.State = ddlState1.SelectedValue;
            UserInfo.City = txtCity1.Text.Trim();
            UserInfo.ZipCode = txtZipCode1.Text.Trim();
            UserInfo.HomePhone = txtHomePhone1.Text.Trim();
            UserInfo.PersonalEmail = txtPersonalEmail1.Text.Trim();
            UserInfo.WorkPhone = txtWorkPhone1.Text.Trim();
            UserInfo.WorkEmail = txtWorkEmail1.Text.Trim();
            UserInfo.ModifiedBy = strModifiedBy;
            UserInfo.Comments = strComments;
            UserInfo.IsParentInfo1 = "Y";
        }
        else if (ParentId == "2")
        {
            UserInfo.FirstName = txtFirstName2.Text.Trim();
            UserInfo.LastName = txtLastName2.Text.Trim();
            UserInfo.Address = txtAddress2.Text.Trim();
            UserInfo.Country = ddlCountry2.SelectedValue;
            UserInfo.State = ddlState2.SelectedValue;
            UserInfo.City = txtCity2.Text.Trim();
            UserInfo.ZipCode = txtZipCode2.Text.Trim();
            UserInfo.HomePhone = txtHomePhone2.Text.Trim();
            UserInfo.PersonalEmail = txtPersonalEmail2.Text.Trim();
            UserInfo.WorkPhone = txtWorkPhone2.Text.Trim();
            UserInfo.WorkEmail = txtWorkEmail2.Text.Trim();
            UserInfo.ModifiedBy = strModifiedBy;
            UserInfo.Comments = strComments;
            UserInfo.IsParentInfo1 = "N";
        }

        return UserInfo;
    }

    private void SetCountryValidationRules(string CountryCode)
    {
        //Change validation rule and max lenth of ZIP text box
        //regExpZipCode
        switch (CountryCode)
        {
            case "2":
                if (ddlCountry1.SelectedValue == CountryCode)
                {
                    regExpZipCode.ValidationExpression = "[A-Z]\\d[A-Z] \\d[A-Z]\\d";
                    regExpZipCode.ErrorMessage = "Please enter a valid Postal Code following this sample: A1A 2B2";
                    reqvalState.ErrorMessage = "Please select the Province";
                    txtZipCode1.MaxLength = 7;
                    lblState.Text = "Camper Province";
                    lblZip.Text = "Camper Postal Code";
                    lblZipMask.Text = "(K1A 0B1)";
                    reqvalZipCode.ErrorMessage = "Please enter a valid Postal Code following this sample: A1A 2B2";
                }
                if (ddlCountry2.SelectedValue == CountryCode)
                {
                    regP2Zip.ValidationExpression = "[A-Z]\\d[A-Z] \\d[A-Z]\\d";
                    regP2Zip.ErrorMessage = "Please enter a valid Postal Code following this sample: A1A 2B2";
                    txtZipCode2.MaxLength = 7;
                }
                break;
            case "1":
                if (ddlCountry1.SelectedValue == CountryCode)
                {
                    regExpZipCode.ValidationExpression = "\\d{5}(-\\d{4})?";
                    //regExpZipCode.ErrorMessage = "Please enter a valid Zip Code";
                    reqvalState.ErrorMessage = "Please select the State";
                    txtZipCode1.MaxLength = 5;
                    lblState.Text = "Camper State";
                    lblZip.Text = "Camper Zip Code";
                    lblZipMask.Text = "(12345)";
                    regExpZipCode.ErrorMessage = "Please enter a valid Zip Code following this sample: 12345";
                    reqvalZipCode.ErrorMessage = "Please enter a valid Zip Code following this sample: 12345";
                }
                if (ddlCountry2.SelectedValue == CountryCode)
                {
                    regP2Zip.ValidationExpression = "\\d{5}(-\\d{4})?";
                    txtZipCode2.MaxLength = 5;
                    regP2Zip.ErrorMessage = "Please enter a valid Zip Code following this sample: 12345";                    
                }
                break;
        }
    }

    protected void ddlCountry1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetCountryValidationRules(ddlCountry1.SelectedItem.Value);
        get_CountryStates(ddlState1, int.Parse(ddlCountry1.SelectedValue));
    }

    //to get states of the selected country and bind it to the dropdownlist
    protected void get_CountryStates(DropDownList ddlState, int countryID)
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
    protected void ddlCountry2_SelectedIndexChanged(object sender, EventArgs e)
    {
        get_CountryStates(ddlState2, int.Parse(ddlCountry2.SelectedValue));
        SetState2Label(ddlCountry2.SelectedValue);
        SetCountryValidationRules(ddlCountry2.SelectedValue);
    }

    private void SetState2Label(string country)
    {
        if (country == "2")
        {
            lblState2.Text = "Province";
            lblZip2.Text = "Postal Code";
        }
        else
        {
            lblState2.Text = "State";
            lblZip2.Text = "Zip Code";
        }
    }
    protected void txtZipCode1_TextChanged(object sender, EventArgs e)
    {
        txtZipCode1.Text = txtZipCode1.Text.ToUpper();
    }
    protected void txtZipCode2_TextChanged(object sender, EventArgs e)
    {
        txtZipCode2.Text = txtZipCode2.Text.ToUpper();
    }
}
