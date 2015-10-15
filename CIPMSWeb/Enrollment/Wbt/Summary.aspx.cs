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
