using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CIPMSBC;

public partial class Enrollment_Columbus_Summary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			// 2013-02-13 Two possible scenarios - either the regular summary page, or then camp is full, show the close message
			int FedID = Convert.ToInt32(FederationEnum.Kansas);
			string FED_ID = FedID.ToString();
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

				if (Session["UsedCode"] != null)
				{
					string currentCode = Session["UsedCode"].ToString();
					int CampYearID = Convert.ToInt32(Application["CampYearID"]);

					List<string> specialCodes = SpecialCodeManager.GetAvailableCodes(CampYearID, FedID);

					// when moved to .NET 3.5 or above, remember to use lamda expression
					foreach (string code in specialCodes)
					{
						if (code == currentCode)
						{
							tblDisable.Visible = false;
							tblRegular.Visible = true;
							SpecialCodeManager.UseCode(CampYearID, FedID, code, Session["FJCID"].ToString());
							break;
						}
					}
				}
			}
			else
			{
				tblDisable.Visible = false;
				tblRegular.Visible = true;
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
		if (tblDisable.Visible)
			Response.Redirect("../Step1_NL.aspx");
		else
			Response.Redirect("Step2_2.aspx");
    }
}
