using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CIPMSBC;

public partial class Enrollment_Habonim_Summary : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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

            switch (last3digits)
            {
                case "029": 
                    imgLogo.Src = "../../images/Camp Galil.jpg";
                    lblGrade.Text = "3 - 8";
                    liTriState.Visible = false;
                    liDelaware.Visible = true;
                    break;

                case "036": 
                    imgLogo.Src = "../../images/Camp Gesher.jpg";
                    break;

                case "037": 
                    imgLogo.Src = "../../images/Camp Gilboa.jpg";
                    break;

                case "057": 
                    imgLogo.Src = "../../images/Camp Miriam.JPG";
                    lblGrade.Text = "4 - 9";
                    lblDaysEnd.Text = "14";
                    lblOrgName.Text = "Hanoar Haoved Youth";
                    break;

                case "060": 
                    imgLogo.Src = "../../images/Camp Moshava.jpg";
                    liTriState.Visible = false;
                    liDelaware.Visible = true;
                    break;

                case "066":                    
                    imgLogo.Src = "../../images/Camp Na'aleh.jpg";
                    break;

                case "095": 
                    imgLogo.Src = "../../images/Camp Tavor.jpg";
                    break;
            }

            // Disable camps will overwrite above code
            switch (last3digits)
            {
                case "066":
                    ImgLogoDisable.Src = "../../images/Camp Na'aleh.jpg";
                    lblDisable.Text = "For more information on scholarship opportunities, please contact Rabbi Eric Wittenstein at  212-229-2700 or rabbieric.naaleh@gmail.com.";
                    tblDisable.Visible = true;
                    tblRegular.Visible = false;
                    break;
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
            Response.Redirect("../Step1_NL.aspx");            
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
