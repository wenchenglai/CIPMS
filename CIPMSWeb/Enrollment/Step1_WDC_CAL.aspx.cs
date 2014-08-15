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

public partial class Step1_WDC_CAL : System.Web.UI.Page
{
    private string strNLURL = "Step1_NL.aspx";
    private string strWashingtonCampAiryLouiseURL = "Washington/Summary.aspx";
    private CamperApplication CamperAppl;
    private General objGeneral;
    private string strWashingtonDCId = ConfigurationManager.AppSettings["WashingtonDC"];
    private string strCampsAiryLouiseId = ConfigurationManager.AppSettings["CampsAiryLouise"];
    private bool bPerformUpdate = false;
    private string strFEDID = string.Empty;
    protected void Page_Init(object sender, EventArgs e)
    {
        btnNext.Click += new EventHandler(btnNext_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        lnkBtnNL.Click += new EventHandler(lnkBtnNL_Click);
        //CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        //CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CamperAppl = new CamperApplication();
        objGeneral = new General();
        SetSubmittedAdminUserFlags();
        if (!Page.IsPostBack)
        {
            /*if (Session["ZIPCODE"] != null)
                hdnZIPCODE.Value = Session["ZIPCODE"].ToString();*/
            if (Session["FJCID"] != null)
                hdnFJCID.Value = Session["FJCID"].ToString();
        }
    }

    void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            CheckFederationNavigation("Next");            
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    private void CheckFederationNavigation(string eventType)
    {
        string strURL, strComments, strModifiedBy, strFJCID;
        
        DataRow drFedDetails;
        strModifiedBy = Master.UserId;
        strURL = strFJCID = string.Empty;
        int RowsAffected = 0;
        if (Session["FJCID"] != null)
        {
            strFJCID = Session["FJCID"].ToString();
            drFedDetails = SubmittedApplicationRedirection();
            if (objGeneral.IsApplicationSubmitted(Session["FJCID"].ToString()) && drFedDetails != null)
                Response.Redirect(drFedDetails["NavigationURL"].ToString());
        }
        if (strModifiedBy != "")
            checkNationalProgramRedirection();

        //strComments = txtComments.Text.Trim();
        strModifiedBy = Master.UserId;        
        
        if (eventType == "National")
        {
            strURL = strNLURL;
            if (strFEDID != strCampsAiryLouiseId)
            {
                strFEDID = strCampsAiryLouiseId;
                bPerformUpdate = true;
            }
        }
        else if (eventType == "Next")
        {
            strURL = strWashingtonCampAiryLouiseURL;
            if (strFEDID != strWashingtonDCId)
            {
                strFEDID = strWashingtonDCId;
                bPerformUpdate = true;
            }
        }

        //to update the Federation Id for the particular FJCID
        //this will take care of federation changes for a particular application
        //(Fed Id which were not be identified in step1.aspx will be identified here and updated
        if (strFEDID != string.Empty && bPerformUpdate)
        {
            CamperAppl.UpdateFederationId(strFJCID, strFEDID);
            Session["FedId"] = strFEDID;
        }

        /*if (strFJCID != "" && strModifiedBy != "" && bPerformUpdate)
            RowsAffected = CamperAppl.InsertCamperAnswers(strFJCID, "~~", strModifiedBy, strComments);*/

        if (strURL.Equals(string.Empty))  //then no federation exists for the grade entered
        {
            lblMessage.Visible = true;
            lblMessage.Text = "No Federation exists for the entered Grade";
        }
        else
        {
            Response.Redirect(strURL, false);
        }
    }

    void btnSaveandExit_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        try
        {            
                strRedirURL = Master.SaveandExitURL;
               // Session.Abandon();
                //Response.Redirect(strRedirURL);
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
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    void btnPrevious_Click(object sender, EventArgs e)
    {
        try
        {            
                if (hdnFJCID.Value != string.Empty)
                    Session["FJCID"] = hdnFJCID.Value;
                Response.Redirect("Step1.aspx", false);            
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
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
                Response.Redirect(strRedirURL, false);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    void lnkBtnNL_Click(object sender, EventArgs e)
    {
        CheckFederationNavigation("National");        
    }

    private DataRow SubmittedApplicationRedirection()
    {
        string strFJCID = Session["FJCID"].ToString();
        DataSet dsFedDetails;
        DataRow drFedDetails = null;
        dsFedDetails = objGeneral.GetFedDetailsForFJCID(strFJCID);
        if (dsFedDetails.Tables[0].Rows.Count == 1)
        {
            drFedDetails = dsFedDetails.Tables[0].Rows[0];
            Session["FedId"] = strFEDID = drFedDetails["FederationID"].ToString();
        }
        return drFedDetails;        
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
            if (drCA["AppType"].ToString() == "C")
            {
                Response.Redirect("Step1_NL.aspx");
            }
        }
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

    /*//to validate the comments for Admin user
    void CusValComments_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            string strUserId, strCamperUserId, strComments, strFJCID;
            Boolean bArgsValid = true;
            strUserId = Master.UserId;
            strCamperUserId = Master.CamperUserId;
            strComments = txtComments.Text.Trim();
            strFJCID = hdnFJCID.Value;

            if (Session["FJCID"] != null)
            {
                strFJCID = Session["FJCID"].ToString();
                SubmittedApplicationRedirection();
            }

            string controlName = Request.Params.Get("__EVENTTARGET");

            if (Request.Form["ctl00$Content$btnNext"]!=null)
            {
                if (strFEDID != strWashingtonDCId)
                    bPerformUpdate = true;                
            }
            else if (controlName.IndexOf("lnkBtnNL")>0)
            {
                if (strFEDID != strCampsAiryLouiseId)
                    bPerformUpdate = true;
            }

            if (strUserId != strCamperUserId) //then the user is admin user
            {
                switch (bPerformUpdate)
                {
                    case true: //data has been modified
                        if (strComments == "")
                        {
                            bArgsValid = false;
                        }                        
                        break;             
                }
            }            
            args.IsValid = bArgsValid;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }*/
}
