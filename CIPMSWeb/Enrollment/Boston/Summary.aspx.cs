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

public partial class Enrollment_Boston_Summary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Two possible scenarios - either the regular summary page, or then camp is full, show the close message
            var FedID = Convert.ToInt32(FederationEnum.Boston);
            var FED_ID = FedID.ToString();
            var isDisabled = ConfigurationManager.AppSettings["DisableOnSummaryPageFederations"].Split(',').Any(x => x == FED_ID);

            if (isDisabled)
            {
                tblDisable.Visible = true;
                tblRegular.Visible = false;

                if (Session["UsedCode"] != null)
                {
                    var currentCode = Session["UsedCode"].ToString();
                    var campYearId = Convert.ToInt32(Application["CampYearID"]);

                    if (SpecialCodeManager.GetAvailableCodes(campYearId, FedID).Any(x => x == currentCode))
                    {
                        tblDisable.Visible = false;
                        tblRegular.Visible = true;
                        SpecialCodeManager.UseCode(campYearId, FedID, currentCode, Session["FJCID"].ToString());
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
        Response.Redirect(tblRegular.Visible ? "Step2_2.aspx" : "../Step1_NL.aspx");
    }
}
