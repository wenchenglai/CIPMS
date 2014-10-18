using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
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

        if (!IsPostBack)
        {
            // 2015-10-15 usng PJGTC code no longer means we route to PJL
            //if (Session["codeValue"] != null)
            //{
            //    if (Session["codeValue"].ToString() == "1")
            //    {
            //        var fedId = Convert.ToInt32(FederationEnum.PJL).ToString();
            //        Session["FedId"] = fedId;
            //        CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), fedId);
            //        Response.Redirect("PJL/Summary.aspx");
            //    }
            //}

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
        if (Session["FJCID"] != null)
        {
            General oGen = new General();
            if (oGen.IsApplicationSubmitted(Session["FJCID"].ToString()))
            {
                SubmittedApplicationRedirection();
            }
        }

        string strURL = GetNationalProgramForCamp(); //2013-09-14 this crazy function will set the hdnFEDID and Session["FedId"] as well, bad programming

        string strFEDID = hdnFEDID.Value;
        string strFJCID = hdnFJCIDStep1_NL.Value;

        //to update the Federation Id for the particular FJCID
        //this will take care of federation changes for a particular application
        //(Fed Id which were not be identified in step1.aspx will be identified here and updated
        if (strFEDID != string.Empty)
            CamperAppl.UpdateFederationId(strFJCID, strFEDID);

        InsertCamperAnswers();

        // 2013-10-08 CampID session must be set here, if we have to redirect to holding page in the next part of code
        string campID = ddlCamp.SelectedValue;
        Session["CampID"] = campID;
        Session["FJCID"] = strFJCID;

        bool isClosed = (from id in ConfigurationManager.AppSettings["OpenFederations"].Split(',')
                      where id == strFEDID
                      select id).Count() < 1;

        if (isClosed)
        {
            Response.Redirect("~/NLIntermediate.aspx");
        }

        if (ddlCamp.SelectedItem.Text == "URJ Six Points Sports Academy")
        {
            if (strURL.ToUpper().Contains("URJ/"))
                strURL = strURL.Replace("URJ/", "URJ/Acadamy");
        }

        Response.Redirect(strURL, false);
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
    }
    
    private string GetNationalProgramForCamp()
    {
        string strURL = "";
        General objGeneral= new General() ;
        DataSet dsNationalProgram = objGeneral.GetNationalProgram(Convert.ToInt32(ddlCamp.SelectedValue));
        
        if (dsNationalProgram.Tables[0].Rows.Count > 0)
        {
            DataRow drNationalProgram = dsNationalProgram.Tables[0].Rows[0];
            strURL = drNationalProgram["NavigationURL"].ToString();
            hdnFEDID.Value = drNationalProgram["Federation"].ToString();
            Session["FedId"] = drNationalProgram["Federation"].ToString();
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
       
        Session["FedId"] = drFedDetails["FederationID"].ToString();
        string strURL = drFedDetails["NavigationURL"].ToString();
        if (ddlCamp.SelectedValue == "1146" || ddlCamp.SelectedItem.Text == "URJ Six Points Sports Academy")
        {
            if (strURL.ToUpper().Contains("URJ/"))
                strURL = strURL.Replace("URJ/", "URJ/Acadamy");
        }
        else if (Session["FedId"].ToString() == "66")
        {

        }
        else
            Response.Redirect(strURL);
    }

    protected void btnNext_Click1(object sender, EventArgs e)
    {

    }
}
