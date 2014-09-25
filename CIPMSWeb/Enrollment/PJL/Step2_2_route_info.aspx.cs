using System;
using CIPMSBC;

public partial class Enrollment_PJL_Step2_2_route_info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPrevious_Click1(object sender, EventArgs e)
    {
        var url = "../Step1.aspx";
        if (Request.QueryString["prev"] != null)
        {
            url = Request.QueryString["prev"];

            if (Request.QueryString["prevfedid"] != null)
            {
                Session["FedId"] = Request.QueryString["prevfedid"];
            }

            //// delete Q3 because number of days are different
            //var fjcid = Session["FJCID"].ToString();
            //var camperApp = new CamperApplication();
            //camperApp.InsertCamperAnswers(fjcid, "3~3~", Master.UserId, "PJL Lottery - delete Q1");
        }

        Response.Redirect(url);
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        var fjcid = Session["FJCID"].ToString();
        var camperApp = new CamperApplication();
        camperApp.UpdateFederationId(fjcid, ((int)FederationEnum.PJL).ToString());
        var previousFedID = Session["FedId"].ToString();
        Session["FedId"] = (int) FederationEnum.PJL;

        camperApp.InsertCamperAnswers(fjcid, "3~3~", Master.UserId, "PJL Lottery - delete Q1");

        var nextUrl = "Step2_2.aspx";
        if (Request.QueryString["prev"] != null)
        {
            nextUrl += "?prev=" + Request.QueryString["prev"] + "&prevfedid=" + previousFedID;
        }
        Response.Redirect(nextUrl);
    }
    protected void btnSaveandExit_Click(object sender, EventArgs e)
    {
        var strRedirUrl = Master.SaveandExitURL;

        if (Master.IsCamperUser == "Yes")
        {
            var oGen = new General();
            if (oGen.IsApplicationSubmitted(Session["FJCID"].ToString()))
            {
                Response.Redirect(strRedirUrl);
            }
            else
            {
                string strScript = "<script language=javascript>openThis(); window.location='" + strRedirUrl + "';</script>";
                if (!ClientScript.IsStartupScriptRegistered("clientScript"))
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strScript);
                }
            }
        }
        else
        {
            Response.Redirect(strRedirUrl);
        }
    }
}