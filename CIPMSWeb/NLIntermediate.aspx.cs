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
using CIPMSBC.Eligibility;

public partial class NLIntermediate : System.Web.UI.Page
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

        string url = (string)Session["nxtUrl"];
        Response.Redirect(url);
    }
}
