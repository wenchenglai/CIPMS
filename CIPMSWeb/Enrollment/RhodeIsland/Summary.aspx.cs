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

public partial class Enrollment_Memphis_Summary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			// 2012-04-01 Two possible scenarios - either the regular summary page, or then camp is full, show the close message
			int FedID = Convert.ToInt32(FederationEnum.RhodeIsland);
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

			// 2013-04-17 special code, for 02762 zip, we only allow them if they have special codes
			bool pass = true;
			if (Session["ZIPCODE"].ToString() == "02762")
			{
				pass = false;
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
							pass = true;
						}
					}
				}
			}

			if (!pass)
				Response.Redirect("../Step1_NL.aspx");
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
		if (tblRegular.Visible)
			Response.Redirect("Step2_2.aspx");
		else
		{
			Response.Redirect("../Step1_NL.aspx");
		}
    }
}
