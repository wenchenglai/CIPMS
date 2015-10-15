using System;
using System.Configuration;
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
        var camperAppl = new CamperApplication();
        camperAppl.submitCamperApplication(Session["FJCID"].ToString(), string.Empty, 0, 37);
        Response.Redirect("https://jefno.org/youth-camping/goldring-summer-camp/");
    }
   // added to redirect to either pjl or miip or NL page depending on inputs by sreevani
    protected void goldringcontinue_Click(object sender, EventArgs e)
    {
        if (Session["FJCID"] != null)
        {
            var camperAppl = new CamperApplication();
            string strFJCID = Session["FJCID"].ToString();
            var _objRedirectionLogic = new Redirection_Logic();
            _objRedirectionLogic.GetNextFederationDetails(strFJCID);
            int nextfederationid = _objRedirectionLogic.NextFederationId;
            camperAppl.UpdateFederationId(strFJCID, nextfederationid.ToString());
            Session["FedId"] = nextfederationid.ToString();
            if (nextfederationid == 48 || nextfederationid == 63)
                Response.Redirect(_objRedirectionLogic.NextFederationURL);
            else
                Response.Redirect("~/Enrollment/Step1_NL.aspx");
        }
    }
}
