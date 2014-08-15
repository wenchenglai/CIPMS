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

public partial class Enrollment_Ramah_Information : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
    }
    
    protected void btnReturnAdmin_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"].ToString();
        Response.Redirect(strRedirURL);
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("Step1_NL.aspx");
    }   

    protected void btnSaveandExit_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        try
        {
            strRedirURL = Master.SaveandExitURL;
            //Session.Abandon();
            //Response.Redirect(strRedirURL);
            if (Master.IsCamperUser == "Yes")
            {

                string strScript = "<script language=javascript>openThis(); window.location='" + strRedirURL + "';</script>";
                if (!ClientScript.IsStartupScriptRegistered("clientScript"))
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strScript);
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
}
