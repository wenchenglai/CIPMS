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

public partial class Enrollment_CAiryLouise_Summary : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tblRegular.Visible = false;
            tblOffline.Visible = true;

            if (tblRegular.Visible)
            {
                btnNext.Visible = true;
            }
            else
            {
                btnNext.Visible = false;
            }
        }
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
		Response.Redirect("../Step1_NL.aspx");
		//localhost:1637/CIPMS/Enrollment/Step1_NL.aspx
        //Response.Redirect("~/NYCampRedirect.aspx");
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("Step2_2.aspx");  
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
}
