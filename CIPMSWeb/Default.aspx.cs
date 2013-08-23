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

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Just incase the user did not hit the logout button.
        if (!IsPostBack)
        {
            Session.Abandon();

            //**********************************
            //TV: 01/20/2009 - Issue 4-004, fixed problem of session expiring in Admin section that
            //required users to login twice... this was done by putting the two lines below 
            //inside the "if (!IsPostBack)" block
            Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
            Response.Cookies.Clear();
            //**********************************
        }

        AdminMenu menu = (AdminMenu)(this.Master.FindControl("AdminMenu1"));
        menu.IsMenuVisible = false;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Eligibility oEli = new Eligibility();       
        //int Status;
        //Boolean retVal;
        //retVal = oEli.checkCincinnatiEligibility("200809300057", out Status);
        //retVal=oEli.checkJwestEligibility("200811050001", out Status);

        Administration objAdmin = new Administration();
        string strUID = txtUsrId.Text.Trim();
        string strPwd = txtPwd.Text.Trim();
        DataSet ds;
        bool blnIsUsrAuthorized = objAdmin.validate_Login(strUID, strPwd, out ds);
        if (blnIsUsrAuthorized == true)
        {
            lblErr.Text = "";
            Session["UsrID"] = ds.Tables[0].Rows[0]["ID"].ToString();
            Session["RoleID"] = ds.Tables[0].Rows[0]["UserRole"].ToString();
            Session["FirstName"] = ds.Tables[0].Rows[0]["FirstName"].ToString();
            Session["LastName"] = ds.Tables[0].Rows[0]["LastName"].ToString();
            Session["FedID"] = ds.Tables[0].Rows[0]["Federation"].ToString();
            Session["FedName"] = ds.Tables[0].Rows[0]["FedName"].ToString();
            
            //Set a cookie for authenticated user
            /*HttpCookie authCookie = FormsAuthentication.GetAuthCookie((string)Session["UsrId"], false);
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            FormsAuthenticationTicket newticket = new FormsAuthenticationTicket(ticket.Name, false, 5000);
            String encTicket = FormsAuthentication.Encrypt(newticket);
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));*/

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,(string)Session["UsrId"], DateTime.Now, DateTime.Now.AddMinutes(5000.0), false, (string)Session["UsrId"]);
            String encTicket = FormsAuthentication.Encrypt(ticket);
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

            Response.Redirect("~/Administration/Search/WorkQueue.aspx");
        }
        else
            lblErr.Text = "Invalid UserID or Password. Please check and re-enter again.";
    }
}
