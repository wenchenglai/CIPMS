using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CIPMSBC;

public partial class Enrollment_Washington_Summary : System.Web.UI.Page
{
    private CamperApplication CamperAppl;

    protected void Page_Init(object sender, EventArgs e)
    {
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
            int FedID = Convert.ToInt32(FederationEnum.WashingtonDC);
            string FED_ID = FedID.ToString();
            bool isDisabled = ConfigurationManager.AppSettings["DisableOnSummaryPageFederations"].Split(',').Any(x => x == FED_ID);

            // Session UserID == null means current logged user is regular camper, not admin.  We don't want to block admins from accessing the application even if the program is in closed state.
            if (isDisabled && Session["UsrID"] == null)
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
                    else if (SessionSpecialCode.GetPJLotterySpecialCode() == "PJGTC2015")
                    {
                        tblDisable.Visible = false;
                        tblRegular.Visible = false;
                        tblPJLottery.Visible = true;

                        ScriptManager.RegisterStartupScript(this, GetType(), "replacePageHeaderText", "replacePageHeaderText();", true);
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
        Response.Redirect("../Step1_WDC_CAL.aspx");
        //Response.Redirect("../Step1.aspx");
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (tblPJLottery.Visible)
        {
            if (rdoYes.Checked)
            {
                Session["STATUS"] = (int)StatusInfo.PendingPJLottery;
                var url = "../PJL/Step2_2_route_info.aspx?prev=" + HttpContext.Current.Request.Url.AbsolutePath;
                Response.Redirect(url);
            }
            else
            {
                tblDisable.Visible = true;
                tblRegular.Visible = false;
                tblPJLottery.Visible = false;
            }
        }
        else 
            Response.Redirect(tblRegular.Visible ? "Step2_2.aspx" : "../Step1_NL.aspx");
    }
}
