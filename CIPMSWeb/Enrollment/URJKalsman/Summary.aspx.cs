using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using CIPMSBC;

public partial class Enrollment_URJ_Summary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			var fedId = Convert.ToInt32(FederationEnum.URJKalsman);
            var isDisabled = ConfigurationManager.AppSettings["DisableOnSummaryPageFederations"].Split(',').Any(x => x == fedId.ToString());

            if (isDisabled && Session["UsrID"] == null)
			{
				tblDisable.Visible = true;
				tblRegular.Visible = false;

				if (Session["SpecialCodeValue"] != null)
				{
					var currentCode = Session["SpecialCodeValue"].ToString();
					var campYearId = Convert.ToInt32(Application["CampYearID"]);

                    if (SpecialCodeManager.GetAvailableCodes(campYearId, fedId).Any(x => x == currentCode))
                    {
                        tblDisable.Visible = false;
                        tblRegular.Visible = true;
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

    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (tblRegular.Visible)
            Response.Redirect("Step2_2.aspx");
        else
        {
            Response.Redirect("../Step1_NL.aspx");
        }
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Step1_NL.aspx");
    }

    protected void btnReturnAdmin_Click(object sender, EventArgs e)
    {
        try
        {
            var strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"];
            Response.Redirect(strRedirURL);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}
