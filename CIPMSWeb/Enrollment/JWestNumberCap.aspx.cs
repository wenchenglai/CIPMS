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


public partial class Enrollment_JWestNumberCap : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {       
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
      
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSaveandExit_Click(object sender, EventArgs e)
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
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("Step1_Questions.aspx");
    }
}
