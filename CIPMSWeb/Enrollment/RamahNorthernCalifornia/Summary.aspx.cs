using System;
using System.Configuration;
using System.Linq;
using CIPMSBC;

public partial class Enrollment_Ramah_Summary : System.Web.UI.Page
{
    private string Berkshire = "082";
    protected void Page_Init(object sender, EventArgs e)
    {
        btnReturnAdmin.Click+=new EventHandler(btnReturnAdmin_Click);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int FedID = Convert.ToInt32(FederationEnum.RamahNorthernCalifornia);
            string FED_ID = FedID.ToString();
            bool isDisabled = ConfigurationManager.AppSettings["DisableOnSummaryPageFederations"].Split(',').Any(x => x == FED_ID);

            if (isDisabled)
            {
                tblDisable.Visible = true;
                tblRegular.Visible = false;

                if (Session["SpecialCodeValue"] != null)
                {
                    string currentCode = Session["SpecialCodeValue"].ToString();
                    int CampYearID = Convert.ToInt32(Application["CampYearID"]);

                    if (SpecialCodeManager.GetAvailableCodes(CampYearID, FedID).Any(x => x == currentCode))
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



    protected void btnReturnAdmin_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"].ToString();
        Response.Redirect(strRedirURL);
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Step1_NL.aspx");
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (tblRegular.Visible)
            Response.Redirect("Step2_2.aspx");
        else
            Response.Redirect("../Step1_NL.aspx");
    }
}
