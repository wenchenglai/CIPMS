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
using CIPMSBC.Eligibility;

public partial class NYCampRedirect : System.Web.UI.Page
{
    CamperApplication CamperAppl = new CamperApplication();

    protected void Page_Init(object sender, EventArgs e)
    {
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["FedId"] != null)
            {
                if (Session["FedId"].ToString() == "46")
                {
                    pnlCampBarney.Visible = false;
                    pnlNYCampRedirect.Visible = true;
                    pnlCampJRFRedirect.Visible = false;
                    PanelHabonimDrorCampGilboa.Visible = false;
                    PanelCampRamahCalifornia.Visible = false;
                    PanelCampRamahDarom.Visible = false;
                    btnNext.Visible = false;
                    PanelCampAiryLouise.Visible = false;
                    PanelPassportNYC.Visible = false;
                    PanelJCCRanch.Visible = false;
                    PanelSolomon.Visible = false;
                    pnlCampRamahBerkshires.Visible = false;
                }
                else if (Session["CampID"].ToString() == "3037")
                {

                    pnlCampBarney.Visible = false;
                    PanelHabonimDrorCampGilboa.Visible = true;
                    pnlNYCampRedirect.Visible = false;
                    pnlCampJRFRedirect.Visible = false;
                    PanelCampRamahCalifornia.Visible = false;
                    PanelCampRamahDarom.Visible = false;
                    PanelCampAiryLouise.Visible = false;
                    PanelPassportNYC.Visible = false;
                    PanelJCCRanch.Visible = false;
                    PanelSolomon.Visible = false;
                    pnlCampRamahBerkshires.Visible = false;
                }
                else if (Session["CampID"].ToString() == "3079")
                {
                    pnlCampBarney.Visible = false;
                    PanelCampRamahCalifornia.Visible = true;
                    pnlNYCampRedirect.Visible = false;
                    pnlCampJRFRedirect.Visible = false;
                    PanelHabonimDrorCampGilboa.Visible = false;
                    PanelCampRamahDarom.Visible = false;
                    PanelCampAiryLouise.Visible = false;
                    PanelPassportNYC.Visible = false;
                    PanelJCCRanch.Visible = false;
                    PanelSolomon.Visible = false;
                    pnlCampRamahBerkshires.Visible = false;
                }
                //added by sreevani for camp darom
                else if (Session["CampID"].ToString() == "3078")
                {
                    pnlCampBarney.Visible = false;
                    PanelCampRamahDarom.Visible = true;
                    PanelCampRamahCalifornia.Visible = false;
                    pnlNYCampRedirect.Visible = false;
                    pnlCampJRFRedirect.Visible = false;
                    PanelHabonimDrorCampGilboa.Visible = false;
                    PanelCampAiryLouise.Visible = false;
                    PanelPassportNYC.Visible = false;
                    PanelJCCRanch.Visible = false;
                    PanelSolomon.Visible = false;
                    pnlCampRamahBerkshires.Visible = false;
                }
                else if (Session["CampID"].ToString() == "3013")
                {
                    pnlCampBarney.Visible = true;
                    PanelCampRamahCalifornia.Visible = false;
                    pnlNYCampRedirect.Visible = false;
                    pnlCampJRFRedirect.Visible = false;
                    PanelHabonimDrorCampGilboa.Visible = false;
                    PanelCampRamahDarom.Visible = false;
                    PanelCampAiryLouise.Visible = false;
                    PanelPassportNYC.Visible = false;
                    PanelJCCRanch.Visible = false;
                    PanelSolomon.Visible = false;
                    pnlCampRamahBerkshires.Visible = false;
                }
                else if (Session["CampID"].ToString() == "3009")
                {
                  
                    pnlCampBarney.Visible = false;
                    PanelCampRamahCalifornia.Visible = false;
                    pnlNYCampRedirect.Visible = false;
                    pnlCampJRFRedirect.Visible = false;
                    PanelHabonimDrorCampGilboa.Visible = false;
                    PanelCampRamahDarom.Visible = false;
                    PanelCampAiryLouise.Visible = true;
                    PanelPassportNYC.Visible = false;
                    PanelJCCRanch.Visible = false;
                    PanelSolomon.Visible = false;
                    pnlCampRamahBerkshires.Visible = false;
                }
                else if (Session["CampID"].ToString() == "3158")
                {
                    PanelPassportNYC.Visible = true;
                    pnlCampBarney.Visible = false;
                    PanelCampRamahCalifornia.Visible = false;
                    pnlNYCampRedirect.Visible = false;
                    pnlCampJRFRedirect.Visible = false;
                    PanelHabonimDrorCampGilboa.Visible = false;
                    btnNext.Visible = false;
                    PanelCampRamahDarom.Visible = false;
                    PanelCampAiryLouise.Visible = false;
                    PanelJCCRanch.Visible = false;
                    PanelSolomon.Visible = false;
                    pnlCampRamahBerkshires.Visible = false;
                }
                else if (Session["CampID"].ToString() == "3117")
                {
                    PanelPassportNYC.Visible = false;
                    pnlCampBarney.Visible = false;
                    PanelCampRamahCalifornia.Visible = false;
                    pnlNYCampRedirect.Visible = false;
                    pnlCampJRFRedirect.Visible = false;
                    PanelHabonimDrorCampGilboa.Visible = false;
                    btnNext.Visible = false;
                    PanelCampRamahDarom.Visible = false;
                    PanelCampAiryLouise.Visible = false;
                    PanelJCCRanch.Visible = true;
                    PanelSolomon.Visible = false;
                    pnlCampRamahBerkshires.Visible = false;
                }
                else if (Session["CampID"].ToString() == "3093")
                { 
                    PanelPassportNYC.Visible = false;
                    pnlCampBarney.Visible = false;
                    PanelCampRamahCalifornia.Visible = false;
                    pnlNYCampRedirect.Visible = false;
                    pnlCampJRFRedirect.Visible = false;
                    PanelHabonimDrorCampGilboa.Visible = false;
                    btnNext.Visible = false;
                    PanelCampRamahDarom.Visible = false;
                    PanelCampAiryLouise.Visible = false;
                    PanelJCCRanch.Visible = false;
                    PanelSolomon.Visible = true;
                    pnlCampRamahBerkshires.Visible = false;
                }
                else if (Session["CampID"].ToString() == "3082")
                {
                    PanelPassportNYC.Visible = false;
                    pnlCampBarney.Visible = false;
                    PanelCampRamahCalifornia.Visible = false;
                    pnlNYCampRedirect.Visible = false;
                    pnlCampJRFRedirect.Visible = false;
                    PanelHabonimDrorCampGilboa.Visible = false;
                    btnNext.Visible = false;
                    PanelCampRamahDarom.Visible = false;
                    PanelCampAiryLouise.Visible = false;
                    PanelJCCRanch.Visible = false;
                    PanelSolomon.Visible = false;
                    pnlCampRamahBerkshires.Visible = true;
                }
                else
                {
                    pnlCampBarney.Visible = false;
                    pnlCampJRFRedirect.Visible = true;
                    pnlNYCampRedirect.Visible = false;
                    PanelHabonimDrorCampGilboa.Visible = false;
                    PanelCampRamahCalifornia.Visible = false;
                    PanelCampRamahDarom.Visible = false;
                    btnNext.Visible = false;
                    PanelCampAiryLouise.Visible = false;
                    PanelPassportNYC.Visible = false;
                    PanelJCCRanch.Visible = false;
                    PanelSolomon.Visible = false;
                    pnlCampRamahBerkshires.Visible = false;
                }
            }
        }
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Enrollment/Step1_NL.aspx");
    }


    protected void btnReturnAdmin_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        try
        {
            strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"].ToString();
            Response.Redirect(strRedirURL);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void btnSaveandExit_Click(object sender, EventArgs e)
    {
        try
        {
            string strRedirURL;
            strRedirURL = Master.SaveandExitURL;
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

    protected void btnNext_Click(object sender, EventArgs e)
    {
        string url = (string)Session["nxtUrl"];
        Response.Redirect(url);
    }

  
}
