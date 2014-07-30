using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CIPMSBC;
//added by sreevani for closed federations.
public partial class Enrollment_ClosedFedRedirection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["FedId"] != null)
            {
                if (Session["FedId"].ToString() == "24")
                {
                    pnlColumbusRedirect.Visible = true;
                    pnlPalmBeachRedirect.Visible = false;
                    pnlMiamiRedirect.Visible = false;
                    pnlIndianapolis.Visible = false;
                }
                else if (Session["FedId"].ToString() == "39")
                {
                    pnlColumbusRedirect.Visible = false;
                    pnlPalmBeachRedirect.Visible = true;
                    pnlMiamiRedirect.Visible = false;
                    pnlIndianapolis.Visible = false;
                    btnNext.Visible = true;
                    btnPrevious.Visible = true;
                    pnlWashingtonRedirect.Visible = false;
                    btnSaveandExit.Visible = true;
                }
                else if (Session["FedId"].ToString() == "49")
                {
                    pnlWashingtonRedirect.Visible = true;
                    pnlColumbusRedirect.Visible = false;
                    pnlPalmBeachRedirect.Visible = false;
                    pnlMiamiRedirect.Visible = false;
                    pnlIndianapolis.Visible = false;
                    btnNext.Visible = true;
                    btnPrevious.Visible = true;
                    btnSaveandExit.Visible = true;
                }
                else if (Session["FedId"].ToString() == "40")
                {
                    pnlColumbusRedirect.Visible = false;
                    pnlPalmBeachRedirect.Visible = false;
                    pnlMiamiRedirect.Visible = true;
                    pnlIndianapolis.Visible = false;
                }
                else if (Session["FedId"].ToString() == "12")
                {
                    pnlColumbusRedirect.Visible = false;
                    pnlPalmBeachRedirect.Visible = false;
                    pnlMiamiRedirect.Visible = false;
                    pnlIndianapolis.Visible = true;
                }
            }
        }
    }
   //added by sreevani for redirecting to miip or pjl or NL page
    protected void RedirectToNextFed()
    {
        CamperApplication CamperAppl = new CamperApplication();

        if (Session["FJCID"] != null)
        {
            string strFJCID = Session["FJCID"].ToString();
            int nextfederationid;
            Redirection_Logic _objRedirectionLogic = new Redirection_Logic();
            _objRedirectionLogic.GetNextFederationDetails(strFJCID);
            nextfederationid = _objRedirectionLogic.NextFederationId;
            CamperAppl.UpdateFederationId(strFJCID, nextfederationid.ToString());
            Session["FedId"] = nextfederationid.ToString();
            if (nextfederationid == 48 || nextfederationid == 63)
                Response.Redirect(_objRedirectionLogic.NextFederationURL);
            else
                Response.Redirect("Step1_NL.aspx");

        }
    }
    protected void clickherelink_Click(object sender, EventArgs e)
    {
        RedirectToNextFed();
        
    }
    protected void clickherelink1_Click(object sender, EventArgs e)
    {
        RedirectToNextFed();
        
    }
    protected void clickheremiami_Click(object sender, EventArgs e)
    {
        RedirectToNextFed();
    }
    protected void clickhereIndiana_Click(object sender, EventArgs e)
    {
        RedirectToNextFed();
    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("Step1.aspx");
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
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        RedirectToNextFed();
        //string url = (string)Session["nxtUrl"];
        //Response.Redirect(url);
       
    }

}
