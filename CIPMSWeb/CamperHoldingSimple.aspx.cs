using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CIPMSBC;

public partial class CamperHoldingSimple : System.Web.UI.Page
{
    CamperApplication CamperAppl = new CamperApplication();

    protected void Page_Init(object sender, EventArgs e)
    {
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

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
    void btnSaveandExit_Click(object sender, EventArgs e)
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