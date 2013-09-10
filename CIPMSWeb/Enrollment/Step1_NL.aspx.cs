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

public partial class Step1_NL : System.Web.UI.Page
{
    //private UserDetails UserInfo;
    private CamperApplication CamperAppl;
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

        if (!Page.IsPostBack)
        {
			if (Session["codeValue"] != null)
			{
				if (Session["codeValue"].ToString() == "1")
				{
					Session["FEDID"] = ConfigurationManager.AppSettings["PJL"].ToString();
					CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), "63");
					Response.Redirect("PJL/Summary.aspx");
				}
			}

            getCamps();

            if (Session["FJCID"] != null)
            {
                hdnFJCIDStep1_NL.Value = (string)Session["FJCID"];
                getCamperAnswers();
            }
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
				InsertCamperAnswers();
				Response.Redirect(strRedirURL);
			}
		}
		catch (Exception ex)
		{
			Response.Write(ex.Message);
		}
	}

    void Page_Unload(object sender, EventArgs e)
    {
        CamperAppl = null;
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
                InsertCamperAnswers();
                //Session["FJCID"] = null;
                //Session["ZIPCODE"] = null;
                //Session.Abandon();
               // Response.Redirect(strRedirURL);
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

    void btnPrevious_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                InsertCamperAnswers();
                Session["FJCID"] = hdnFJCIDStep1_NL.Value;

                DataSet ds;
                int iCount;
                General objGeneral = new General();

                //Ram 8 Nov'10
                string strZipCode = Session["ZIPCODE"].ToString();
                ds = objGeneral.GetFederationForZipCode(strZipCode);
                iCount = ds.Tables[0].Rows.Count;
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

                if (iCount > 1 && (strAppType != string.Empty && strAppType != "c"))
                    Response.Redirect("Step1_Questions.aspx");
                else if (ddlCamp.SelectedItem.Text.ToLower().Contains("camps airy louise"))
                {
                    Response.Redirect("Step1_WDC_CAL.aspx");                    
                }
                else
                {     
                    Response.Redirect("Step1.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {

                string strURL;
                string strFJCID;
                string strFEDID;

                if (Session["FJCID"] != null)
                {
                    General oGen = new General();
                    if (oGen.IsApplicationSubmitted(Session["FJCID"].ToString()))
                    {
                        SubmittedApplicationRedirection();
                    }

                }

                strURL = GetNationalProgramForCamp();

                //Added By Ram
                Session["CampID"] = ddlCamp.SelectedValue;
                //fed id will be set to hidden variable in CheckFederation() method
                strFEDID = hdnFEDID.Value;
                strFJCID = hdnFJCIDStep1_NL.Value;

                //to update the Federation Id for the particular FJCID
                //this will take care of federation changes for a particular application
                //(Fed Id which were not be identified in step1.aspx will be identified here and updated
                if (strFEDID != string.Empty)
                    CamperAppl.UpdateFederationId(strFJCID, strFEDID);

                //added by sreevani for checking if code is entered for specific camps
                DataSet dsForCodeEntered = new DataSet();
                String codeEntered = "";
                string questionID = "";
                if (ddlCamp.SelectedValue == "3079")
                    questionID = "1028";
                else if (ddlCamp.SelectedValue == "3037")
                    questionID = "1027";
                else if (ddlCamp.SelectedValue == "3078")
                    questionID = "1029";
                else if (ddlCamp.SelectedValue == "3009")
                    questionID = "1030";
                dsForCodeEntered = CamperAppl.getCamperAnswers(Session["FJCID"].ToString(), questionID, questionID, "N");
                if (dsForCodeEntered.Tables[0].Rows.Count > 0)
                    codeEntered = dsForCodeEntered.Tables[0].Rows[0]["Answer"].ToString();
                InsertCamperAnswers();
                string DisabledFed = ConfigurationManager.AppSettings["OpenFederations"];
                if (DisabledFed != "")
                {
                    bool navToCamperHolding = true;
                    string[] DisabledFeds = DisabledFed.Split(',');
                    for (int i = 0; i < DisabledFeds.Length; i++)
                    {
                        if (DisabledFeds[i] == strFEDID)
                        {
                            navToCamperHolding = false;
                        }
                    }

                    if (navToCamperHolding)
                    {
                        Response.Redirect("~/NLIntermediate.aspx");
                    }
                }

                Session["FJCID"] = strFJCID;
                if (ddlCamp.SelectedValue == "1146" || ddlCamp.SelectedItem.Text == "URJ Six Points Sports Academy")
                {
                    if (strURL.ToUpper().Contains("URJ/"))
                        strURL = strURL.Replace("URJ/", "URJ/Acadamy");
                }

                if (strFEDID != "37")
                {
                    if (Session["PJCode"] != null)
                    {
                        if (Session["PJCode"].ToString() == "PJGTC20111R")
                        {
                            int iStatus = 3;
                            Session["STATUS"] = iStatus.ToString();
                            Response.Redirect("Thankyou.aspx");
                        }
                    }
                }
                
                if((ddlCamp.SelectedValue == "3013"))//|| (ddlCamp.SelectedValue == "3082"))
                    Response.Redirect("~/NYCampRedirect.aspx");

                if (strFEDID == "46")
                {

                    if ((ddlCamp.SelectedValue == "3072") || (ddlCamp.SelectedValue == "3152") || (ddlCamp.SelectedValue == "3069") || (ddlCamp.SelectedValue == "3110") || (ddlCamp.SelectedValue == "3123") || (ddlCamp.SelectedValue == "3159"))
                    {
                        Response.Redirect("~/NYCampRedirect.aspx");
                    }
                    else
                    {
                        Response.Redirect(strURL, false);
                    }

                }
                else
                {
                    Response.Redirect(strURL, false);               
                }
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void InsertCamperAnswers()
    {
        string strFJCID, strComments;
        int RowsAffected;
        string strCamperAnswers, strModifiedBy; //-1 for Camper (User id will be passed for Admin user)

        strFJCID = hdnFJCIDStep1_NL.Value;

        //Modified by id taken from the common.master
        strModifiedBy = Master.UserId;

        //to get the comments (used by the Admin user)
        strComments = txtComments.Text.Trim();

        strCamperAnswers = ConstructCamperAnswers();

        if (strFJCID != "" && strCamperAnswers != "" && strModifiedBy != "" && bPerformUpdate)
            RowsAffected = CamperAppl.InsertCamperAnswers(strFJCID, strCamperAnswers, strModifiedBy, strComments);
    }

    //to get the camper answers from the database
    void getCamperAnswers()
    {
        string strFJCID;
        strFJCID = hdnFJCIDStep1_NL.Value;
        if (!strFJCID.Equals(string.Empty))
        {
            CamperApplication oCA = new CamperApplication();
            DataSet dsCamp;
            dsCamp = oCA.getCamperAnswers(strFJCID, "10", "10", "N");
            DataRow drCamp;

            if (dsCamp.Tables[0].Rows.Count > 0)
            {
                drCamp = dsCamp.Tables[0].Rows[0];
                if (!string.IsNullOrEmpty(drCamp["Answer"].ToString()))
                {
                    ddlCamp.SelectedValue = drCamp["Answer"].ToString();
                }
                else
                {
                    ddlCamp.SelectedValue = "-1";
                }
            }
            else if (Request.UrlReferrer.AbsolutePath.Contains("Step1_WDC_CAL.aspx"))                
            {
				ddlCamp.SelectedValue = ddlCamp.Items.FindByText("Camps Airy & Louise").Value;
            }
        } //end if for null check of fjcid
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

        strTablevalues += strQuestionId + strFSeparator + "2" + strFSeparator + ddlCamp.SelectedValue + strQSeparator;

        //to remove the extra character at the end of the string, if any
        char[] chartoRemove = { Convert.ToChar(strQSeparator) };
        strTablevalues = strTablevalues.TrimEnd(chartoRemove);

        return strTablevalues;
    }

    //to validate the comments for Admin user
    void CusValComments_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            string strCamperAnswers, strUserId, strCamperUserId, strComments, strFJCID;
            Boolean bArgsValid, bPerform;
            strUserId = Master.UserId;
            strCamperUserId = Master.CamperUserId;
            strComments = txtComments.Text.Trim();
            strFJCID = hdnFJCIDStep1_NL.Value;
            strCamperAnswers = ConstructCamperAnswers();
            CamperAppl.CamperAnswersServerValidation(strCamperAnswers, strComments, strFJCID, strUserId, (Convert.ToInt32(Redirection_Logic.PageNames.Step1_NL)).ToString(), strCamperUserId, out bArgsValid, out bPerform);
            args.IsValid = bArgsValid;
            bPerformUpdate = bPerform;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    
    private void getCamps()
    {
        DataSet dsCamps;
        General objGeneral= new General() ;
        dsCamps = objGeneral.GetNationalCamps(Master.CampYear);
        ddlCamp.DataSource = dsCamps;
        ddlCamp.DataTextField = "Camp";
        ddlCamp.DataValueField = "ID";
        ddlCamp.DataBind();
        ddlCamp.Items.Insert(0, new ListItem("-- Select --", "0"));
        int ZipCodeCount = new General().ValidateNYZipCode(Session["ZIPCODE"].ToString());
        if (ZipCodeCount == 0)
        {
            ddlCamp.Items.Remove(ddlCamp.Items.FindByText("Camp Poyntelle-Lewis Village"));
        }
    }
    
    private string GetNationalProgramForCamp()
    {
        DataSet dsNationalProgram;
        string strURL="";
        DataRow drNationalProgram;
        General objGeneral= new General() ;
        dsNationalProgram = objGeneral.GetNationalProgram(Convert.ToInt32(ddlCamp.SelectedValue));
        if (dsNationalProgram.Tables[0].Rows.Count > 0)
        {
            drNationalProgram = dsNationalProgram.Tables[0].Rows[0];
            strURL = drNationalProgram["NavigationURL"].ToString();
            hdnFEDID.Value = drNationalProgram["Federation"].ToString();
            Session["FEDID"] = drNationalProgram["Federation"].ToString();
        }
        else
            strURL = "";
        return strURL;
    }

    void SubmittedApplicationRedirection()
    {
        General oGen = new General();
        string strFJCID;
        strFJCID = Session["FJCID"].ToString();
        DataSet dsFedDetails;
        DataRow drFedDetails;
        dsFedDetails = oGen.GetFedDetailsForFJCID(strFJCID);
        drFedDetails = dsFedDetails.Tables[0].Rows[0];

        InsertCamperAnswers();
       
        Session["FEDID"] = drFedDetails["FederationID"].ToString();
        string strURL = drFedDetails["NavigationURL"].ToString();
        if (ddlCamp.SelectedValue == "1146" || ddlCamp.SelectedItem.Text == "URJ Six Points Sports Academy")
        {
            if (strURL.ToUpper().Contains("URJ/"))
                strURL = strURL.Replace("URJ/", "URJ/Acadamy");
        }
        else if (Session["FEDID"].ToString() == "66")
        {

        }
        else
            Response.Redirect(strURL);
    }

    protected void btnNext_Click1(object sender, EventArgs e)
    {

    }
}
