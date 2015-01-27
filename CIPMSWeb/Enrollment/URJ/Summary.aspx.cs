using System;
using System.Configuration;
using System.Data;
using System.Linq;
using CIPMSBC;

public partial class Enrollment_URJ_Summary : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int resultCampId = 0; //long resultFedID;
        if (Session["CampID"] != null)
        {
            Int32.TryParse(Session["CampID"].ToString(), out resultCampId);
        }
        else if (Session["FJCID"] != null)
        {
            DataSet ds = new CamperApplication().getCamperAnswers(Session["FJCID"].ToString(), "10", "10", "N");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                Int32.TryParse(dr["Answer"].ToString(), out resultCampId);
            }
        }

        string campID = resultCampId.ToString();
        string last3digits = campID.Substring(campID.Length - 3);

        // Olin-Sang-Ruby Union Institute (OSRUI)
        if (last3digits == "141")
        {
            tblDisable.Visible = true;
            lblDisabledMessage.Text = "For further information on how to apply for the URJ OSRUI One Happy Camper program, please contact the professional listed at the bottom of the screen.";
            tblRegular.Visible = false;

            if (Session["SpecialCodeValue"] != null)
            {
                var currentCode = Session["SpecialCodeValue"].ToString();
                var campYearId = Convert.ToInt32(Application["CampYearID"]);
                var fedId = Convert.ToInt32(FederationEnum.URJ);

                if (SpecialCodeManager.GetAvailableCodesPerCamp(campYearId, fedId, Int32.Parse(campID)).Any(x => x == currentCode))
                {
                    tblDisable.Visible = false;
                    tblRegular.Visible = true;
                }
            }
        }
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
        {
            Response.Redirect("../Step1_NL.aspx");
        }
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
