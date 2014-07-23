using System;
using System.Configuration;
using System.Linq;
using CIPMSBC;

public partial class Enrollment_Washington_Summary : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			int FedID = Convert.ToInt32(FederationEnum.PJL);
			string FED_ID = FedID.ToString();
            bool isDisabled = ConfigurationManager.AppSettings["DisableOnSummaryPageFederations"].Split(',').Any(x => x == FED_ID);

			if (isDisabled)
			{
				tblDisable.Visible = true;
				tblRegular.Visible = false;

                if (Session["UsedCode"] != null)
                {
                    string currentCode = Session["UsedCode"].ToString();
                    int CampYearID = Convert.ToInt32(Application["CampYearID"]);

                    if (SpecialCodeManager.GetAvailableCodes(CampYearID, FedID).Any(x => x == currentCode))
                    {
                        tblDisable.Visible = false;
                        tblRegular.Visible = true;
                        SpecialCodeManager.UseCode(CampYearID, FedID, currentCode, Session["FJCID"].ToString());
                    }

                    // 2013-07-11 Currently, tblPJLCodes and tblPJLDSCodes table are still being used in Step1.aspx
                    // DScodes has the special effect of bypassing all the logic and jump directly to the PJL summary page
                    // Val aksed a temporary solution to have super speical code that allows users form LA to jump directly to PJ, this coincides with
                    // the PJL DS codes logic, so I utilize the mechanism here.
                    if (!tblRegular.Visible)
                    {
                        CamperApplication oCA = new CamperApplication();
                        int validate = oCA.validatePJLDSCode(currentCode);
                        if (validate == 0 || validate == 2)
                        {
                            tblDisable.Visible = false;
                            tblRegular.Visible = true;
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
        //Response.Redirect("../Step1.aspx");
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
		string Next_URL = "Step2_2.aspx";

		if (tblDisable.Visible)
		{
			// NL page has a code snippet that would check this value and return to this page, so we need to clear it here to avoid the loop
			if (Session["codeValue"] != null)
			{
				if (Session["codeValue"].ToString() == "1")
				{
					Session["codeValue"] = null;
				}
			}
			Next_URL = "../Step1_NL.aspx";
		}

		Response.Redirect(Next_URL);
    }
}
