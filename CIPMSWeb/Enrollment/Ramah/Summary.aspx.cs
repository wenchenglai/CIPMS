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
        if (IsPostBack) return;

        var strCampID = Session["CampID"].ToString();
        var last3Digits = strCampID.Substring(strCampID.Length - 3);

        if (ConfigurationManager.AppSettings["ClosedRamah"].Split(',').Any(id => id == last3Digits))
            Response.Redirect("~/NLIntermediate.aspx");

        // Berkshires
        if (last3Digits == Berkshire)
        {
            trBerkshires.Visible = true;
        }
        else if (last3Digits == "079") // California
        {
            trCalifornia1.Visible = true;
            trCalifornia2.Visible = true;
        }
        else if (last3Digits == "080") // Canada
        {
            trCanada.Visible = true;
        }
        else if (last3Digits == "083") // Poconos
        {
            trPoconos.Visible = true;
        }
        else if (last3Digits == "084") // Wisconsin
        {
            trWisconsin.Visible = true;
        }
        else if (last3Digits == "150") // OUtdoor Adventure
        {
            trOutdoor.Visible = true;
        }
        else
        {
            trDefault1.Visible = true;
            trDefault2.Visible = true;
        }


        //if (last3Digits == Berkshire) //Berkshire
        //{
        //    // Camp Ramah in the Berkshires
        //    if (Session["SpecialCodeValue"] != null)
        //    {
        //        if (Session["SpecialCodeValue"].ToString() == "CRB849")
        //        {
        //            EnableRegistration();
        //        }
        //        else
        //        {
        //            DisableRegistration(last3Digits);
        //        }
        //    }
        //    else
        //        DisableRegistration(last3Digits);
        //}
    }

    private void EnableRegistration()
    {
        tblDisable.Visible = false;
        tblRegular.Visible = true;
        btnNext.Visible = true;
    }

    private void DisableRegistration(string last3Digits)
    {
        tblRegular.Visible = false;
		btnNext.Visible = false;

        tblDisable.Visible = true;
        if (last3Digits == "078")
        {
            lblRamahDarom.Visible = true;
            lblRamahCal.Visible = false;
			divDisableBerkshire.Visible = false;
        }
        else if (last3Digits == "079")
        {
            lblRamahDarom.Visible = false;
            lblRamahCal.Visible = true;
			divDisableBerkshire.Visible = false;
        }
        else if (last3Digits == "082")
		{
			lblRamahDarom.Visible = false;
			lblRamahCal.Visible = false;
			divDisableBerkshire.Visible = true;
			btnNext.Visible = true;
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
        var CampID = Convert.ToInt32(Session["CampID"]);
        Response.Redirect(CampID == 5082 ? "../Step1_NL.aspx" : "Step2_2.aspx");
    }
}
