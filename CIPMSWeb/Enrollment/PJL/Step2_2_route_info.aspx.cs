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
        if (Request.QueryString["prevJPL"] != null)
        {
            url = Request.QueryString["prevJPL"];
        }

        Response.Redirect(url);
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        var camperApp = new CamperApplication();
        camperApp.UpdateFederationId(Session["FJCID"].ToString(), ((int)FederationEnum.PJL).ToString());
        Session["FedId"] = (int) FederationEnum.PJL;
        Response.Redirect("Step2_2.aspx");
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