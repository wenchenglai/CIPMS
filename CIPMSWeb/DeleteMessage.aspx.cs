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

public partial class DeleteMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //protected void btnSaveandExit_Click(object sender, EventArgs e)
    //{
    //    string strRedirURL;
    //    try
    //    {
    //        if (Page.IsValid)
    //        {
    //            strRedirURL = Master.SaveandExitURL;                
    //            Session.Abandon();
    //            Response.Redirect(strRedirURL);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);
    //    }
    //}
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("CamperOptions.aspx");
    }
}
