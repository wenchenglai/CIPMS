using System;
using System.Configuration;
using System.Linq;
using CIPMSBC;
using System.Collections.Generic;

public partial class Enrollment_Admah_Summary : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			int FedID = Convert.ToInt32(FederationEnum.Adamahadventures);
			string FED_ID = FedID.ToString();
            bool isDisabled = ConfigurationManager.AppSettings["DisableOnSummaryPageFederations"].Split(',').Any(x => x == FED_ID);

			if (isDisabled)
			{
				tblDisable.Visible = true;
				tblRegular.Visible = false;
				btnNext.Visible = false;

				if (Session["UsedCode"] != null)
				{
					// 2013-03-15 Now Adamah use tblSpecialCodes table
					string currentCode = Session["UsedCode"].ToString();
					int CampYearID = Convert.ToInt32(Application["CampYearID"]);

                    if (SpecialCodeManager.GetAvailableCodes(CampYearID, FedID).Any(x => x == currentCode))
                    {
                        tblDisable.Visible = false;
                        tblRegular.Visible = true;
                        SpecialCodeManager.UseCode(CampYearID, FedID, currentCode, Session["FJCID"].ToString());
                    }
				}
			}
			else
			{
				tblDisable.Visible = false;
				tblRegular.Visible = true;
				btnNext.Visible = true;
			}
		}
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Step1_NL.aspx");
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
