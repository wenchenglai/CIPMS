using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
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
        // 2014-02-19 Val asked to have special case that make Memphis disappear so user directly go to the NL page
        Response.Redirect("../Step1_NL.aspx");

        if (!IsPostBack)
        {
            // Two possible scenarios - either the regular summary page, or then camp is full, show the close message
            int FedID = Convert.ToInt32(FederationEnum.Memphis);
            string FED_ID = FedID.ToString();
            bool isDisabled = false;

            if (ConfigurationManager.AppSettings["DisableOnSummaryPageFederations"].Split(',').Any(x => x == FED_ID))
                isDisabled = true;

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
        if (tblRegular.Visible)
            Response.Redirect("Step2_2.aspx");
        else
        {
            Response.Redirect("../Step1_NL.aspx");
        }
    }
}
