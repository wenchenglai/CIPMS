using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CIPMSBC;

public partial class Enrollment_Chicago_Step2_camp_coupon_holding : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPrevious_Click(object sender, EventArgs e)
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