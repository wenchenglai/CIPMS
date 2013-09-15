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

public partial class Enrollment_Habonim_Tavor_Summary : System.Web.UI.Page
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

                    break;
                case "036": 
                    imgLogo.Src = "../../images/Camp Gesher.jpg";

                    break;
                case "037": 
                    imgLogo.Src = "../../images/Camp Gilboa.jpg";

                    break;
                case "057": 
                    imgLogo.Src = "../../images/Camp Miriam.JPG";

                    break;
                case "060": 
                    imgLogo.Src = "../../images/Camp Moshava.jpg";

                    break;
                case "066": 
                    imgLogo.Src = "../../images/Camp Na'aleh.jpg";

                    break;
                case "095": 
                    imgLogo.Src = "../../images/Camp Tavor.jpg";

                    break;
            }

            if (resultCampId != 0 && resultCampId == 1133)
            {
                /*DataSet ds = new DataSet();
                ds = new General().GetFederationCampContactDetails(resultFedID.ToString(), resultCampId.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    spnCampName.InnerText = "At " + dr["Name"].ToString().Trim().Replace('-',' ') + ", t";
                }*/
                //spnCampName.InnerText = "At URJ Camp Newman Swig, the award is available to any camp-age child in grades 3-12 who registers at one of the listed URJ Camps, and who is attending a non-profit Jewish sleep-away camp for at least 12 days for the first time. If the camper attends a session that is 19 days or longer, he/she is eligible for a grant of $1,000. If the camper attends a session that is 12-18 days, he she is eligible for a prorated grant of $700.  Siblings from a single family are eligible to receive separate grants. The award is available regardless of need or whether the camper or camper’s family has received other scholarship or financial aid.";
            }
            else if (resultCampId != 0 && resultCampId == 1132)
            {
                // spnCampName.InnerText = "At URJ Camp Kalsman, the award is available to any camp-age child in grades 3-12 who registers at one of the listed URJ Camps, and who is attending a non-profit Jewish sleep-away camp for at least 12 days for the first time. If the camper attends a session that is 19 days or longer, he/she is eligible for a grant of $1,000. If the camper attends a session that is 12-18 days, he she is eligible for a prorated grant of $700.  Siblings from a single family are eligible to receive separate grants. The award is available regardless of need or whether the camper or camper’s family has received other scholarship or financial aid.";
            }
        }
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Step1_NL.aspx");
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("Step2_2.aspx?camp=tavor");
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
