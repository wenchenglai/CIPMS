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

public partial class Enrollment_Middlesex_Summary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			// 2012-04-01 Two possible scenarios - either the regular summary page, or then camp is full, show the close message
			const string FED_ID = "2";
			bool isDisabled = false;
			string[] FedIDs = ConfigurationManager.AppSettings["DisableOnSummaryPageFederations"].Split(',');
			for (int i = 0; i < FedIDs.Length; i++)
			{
				if (FedIDs[i] == FED_ID)
				{
					isDisabled = true;
					break;
				}
			}

			if (isDisabled)
			{
				tblDisable.Visible = true;
				tblRegular.Visible = false;
				btnSaveandExit.Visible = false;
			}
			else
			{
				tblDisable.Visible = false;
				tblRegular.Visible = true;
				btnSaveandExit.Visible = true;
			}
		}
    }

    protected void btnReturnAdmin_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"].ToString();
        Response.Redirect(strRedirURL);
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Step1.aspx");
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
		if (btnSaveandExit.Visible)
			Response.Redirect("Step2_2.aspx");
		else
		{
			// camp is closed
			// Check if PJ code is used.  If not, we go to the last option NL.
			if (Session["codeValue"] != null)
			{
				if (Session["codeValue"].ToString() == "1")
				{
					CamperApplication CamperAppl = new CamperApplication();
					Session["FedId"] = ConfigurationManager.AppSettings["PJL"].ToString();
					CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), "63");
					Response.Redirect("../PJL/Summary.aspx");
				}
			}
			Response.Redirect("../Step1_NL.aspx");
		}
    }
}
