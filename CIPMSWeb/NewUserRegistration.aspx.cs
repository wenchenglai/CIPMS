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

public partial class NewUserRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("~/Home.aspx");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Administration objAdmin = new Administration();
        string strEmail = txtEmail.Text.Trim();
        string strPwd = txtPwd.Text.Trim();
        string CamperLoginID;
        int retValue;

        DataSet CamperCredentials;
        CamperCredentials = objAdmin.GetCamperCredentials(strEmail);

        if (CamperCredentials.Tables[0].Rows.Count > 0)
        {
            lblErr.Text = "UserID already exists";
        }
        else
        {
            retValue = objAdmin.UserRegistration(strEmail, strPwd, out CamperLoginID);
            Session["CamperLoginID"] = CamperLoginID;
            Session["UsrID"] = null;
            // Redirect to the basic camper info page
            string strRedirURL;
            strRedirURL = ConfigurationManager.AppSettings["CamperBasicInfo"].ToString();
            Server.Transfer(strRedirURL);  
        }


    }
}
