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

public partial class AdminMaster : System.Web.UI.MasterPage
{
    private string _campYear = "";

    public string CampYear
    {
        get
        {
            if (Session["CampYear"] != null)
            {
                _campYear = (string)Session["CampYear"].ToString();
            }
            else
            {
                _campYear = Application["CampYear"].ToString();
            }
            return _campYear;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string strFilePath = Request.Path.ToUpper();        
        string strAdminUserId = Convert.ToString(Session["UsrID"]);
        string strSSL = ConfigurationManager.AppSettings["SSLFlag"].ToUpper();

        // check for SSL
        if (strSSL.Equals("Y"))
        {
            string strURL = Request.Url.ToString();
            if (strURL.IndexOf("https") < 0)
            {
                strURL = strURL.Replace("http", "https");
                Response.Redirect(strURL, false);
            }
        }

        // for session check
        if (string.IsNullOrEmpty(strAdminUserId) && strFilePath.IndexOf("DEFAULT.ASPX") < 0)
        {
            //to redirect the user to Home.aspx
            Server.Transfer("~/Error.aspx?app=admin", false);
        }

        string localIP = Dns.GetHostAddresses(Request.Url.Host)[0].ToString();
        string prodIP = ConfigurationManager.AppSettings["ProductionServerIP"];
        if (localIP != prodIP)
        {
            lblUAT.Visible = true;
        }
        else
        {
            lblUAT.Visible = false;
        }
    }
}
