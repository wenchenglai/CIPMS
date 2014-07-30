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

public partial class Enrollment_JCC_Summary : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Step1.aspx");
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
    protected void nlpageLink_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("~/Enrollment/Step1_NL.aspx");
    }
    protected void goldringlink_Click(object sender, EventArgs e)
    {
        CamperApplication CamperAppl = new CamperApplication();
        CamperAppl.submitCamperApplication(Session["FJCID"].ToString(), string.Empty, 0, 37);
        Response.Redirect("http://www.jefno.org/6_grants_camp.html");
    }
   // added to redirect to either pjl or miip or NL page depending on inputs by sreevani
    protected void goldringcontinue_Click(object sender, EventArgs e)
    {

        CamperApplication CamperAppl = new CamperApplication();

        if (Session["FJCID"] != null)
        {
            string strFJCID = Session["FJCID"].ToString();
            int nextfederationid;
            Redirection_Logic _objRedirectionLogic = new Redirection_Logic();
            _objRedirectionLogic.GetNextFederationDetails(strFJCID);
            nextfederationid = _objRedirectionLogic.NextFederationId;
            CamperAppl.UpdateFederationId(strFJCID, nextfederationid.ToString());
            Session["FedId"] = nextfederationid.ToString();
            if (nextfederationid == 48 || nextfederationid == 63)
                Response.Redirect(_objRedirectionLogic.NextFederationURL);
            else
                Response.Redirect("~/Enrollment/Step1_NL.aspx");

        }
        // Response.Redirect("~/Enrollment/Step1_NL.aspx");
    }
}
