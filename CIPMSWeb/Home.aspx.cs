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
using System.Net;
using CIPMSBC;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //txtEmail.Focus();
        if (ConfigurationManager.AppSettings["OpenFederations"] == "All")
        {
            Response.Redirect("~/CamperHolding.aspx");        
        }

        //Just incase the user did not hit the logout button.
        if (!IsPostBack)
        {
            // if it's localhost (developer machine)
            if (Request.Url.Host == "localhost")
            {
                lblUAT.Visible = true;
                lblUAT.Text = "This is developer's local machine";


                Email.Text = "wenchenglai@gmail.com";
                Password.Text = "wayne";
                Password.TextMode = TextBoxMode.SingleLine;

                //txtEmail.Text = "scharfn@gmail.com";
                //txtPwd.Text = "fufu4u";

                //txtEmail.Text = "ikl1232003@yahoo.com";
                //txtPwd.Text = "myaX*6";
            }
			// compare requester (client)'s IP with UATIP
			else if (Dns.GetHostAddresses(Request.Url.Host)[0].ToString() == ConfigurationManager.AppSettings["UATIP"])
			{
                lblUAT.Visible = true;
				lblUAT.Text = "This is UAT";
			}

            Session.Abandon();

            if (Request.QueryString["RedirectURL"] != null)
                if (Request.QueryString["RedirectURL"].Contains("TrackMyStatus"))
                {
                    hdnRedirectURL.Value = Request.QueryString["RedirectURL"].ToString();
                }
                else
                    hdnRedirectURL.Value = string.Empty;

            FormsAuthentication.SignOut();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
		string strEmail = Email.Text.Trim();
		string isTestMode = ConfigurationManager.AppSettings["TestingMode"];
		if (isTestMode == "Yes")
		{
			if (strEmail != "wenchenglai@gmail.com" && strEmail != "valentina@jewishcamp.org" && strEmail != "seth@jewishcamp.org")
			{
				lblErr.Text = "The registration system is closed for testing until 11 AM EST on Tuesday, Oct 16th, 2012.";
				return;
			}
		}

        Administration objAdmin = new Administration();

        string strPwd = Password.Text;
        DataSet ds;
        bool blnIsUsrAuthorized = objAdmin.ValidateCamper(strEmail, strPwd, out ds);
        if (blnIsUsrAuthorized == true)
        {
            lblErr.Text = "";
            Session["UsrID"] = null;
            Session["CamperLoginID"] = ds.Tables[0].Rows[0]["CamperId"].ToString();

            //Set a cookie for authenticated user
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket((string)Session["CamperLoginID"], true, 5000);
            String encTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            authCookie.Expires = ticket.Expiration;
            Response.Cookies.Add(authCookie);
            if (hdnRedirectURL.Value.Equals(string.Empty))
                Response.Redirect("~/CamperOptions.aspx");
            else
                Response.Redirect(hdnRedirectURL.Value);
        }
        else
            lblErr.Text = "Invalid UserID or Password. Please check and re-enter again.";
    }

    protected void btnForgot_Click(object sender, EventArgs e)
    {
        Administration objAdmin = new Administration();
        string strToEmail = Email.Text.Trim();
        string FromEmail = ConfigurationManager.AppSettings["EmailFrom"].ToString();
        string ReplyAddress = ConfigurationManager.AppSettings["ReplyTo"].ToString();
        string FromName = ConfigurationManager.AppSettings["FromName"].ToString();
        string Subject = ConfigurationManager.AppSettings["Subject"].ToString();
        string sBody;

        DataSet CamperCredentials;
        DataRow drEmail;
        CamperCredentials = objAdmin.GetCamperCredentials(strToEmail);

        if (CamperCredentials.Tables[0].Rows.Count > 0)
        {
            drEmail = CamperCredentials.Tables[0].Rows[0];
            sBody = "Your Password is: " + drEmail["Password"].ToString();
        }
        else
        {
            sBody = "UserId not found";
        }

        cService.SendMail(strToEmail, null, FromName, FromEmail, ReplyAddress, Subject, sBody);
        lblErr.Text = "Password sent to your email address";
    }
    protected void btnSubmit1_Click(object sender, EventArgs e)
    {
		string strEmail = txtEmail1.Text.Trim();
		string isTestMode = ConfigurationManager.AppSettings["TestingMode"];
		if (isTestMode == "Yes")
		{
			if (strEmail != "wenchenglai@gmail.com" && strEmail != "valentina@jewishcamp.org" && strEmail != "seth@jewishcamp.org")
			{
				lblErr.Text = "The registration system is closed for testing until 11 AM EST on Tuesday, Oct 16th, 2012.";
				return;
			}
		}

        Administration objAdmin = new Administration();

        //string strCfrmEmail = txtCfrmEmail.Text.Trim();
        string strPwd = txtPwd1.Text.Trim();
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
