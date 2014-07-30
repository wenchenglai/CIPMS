using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

    }
}