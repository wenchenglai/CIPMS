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
using System.Collections.Generic;

public partial class Enrollment_NNJ_Summary : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			int FedID = Convert.ToInt32(FederationEnum.NNJ);
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
				}
			}
			else
			{
				tblDisable.Visible = false;
				tblRegular.Visible = true;
			}
		}

        int resultCampId = 0; //long resultFedID;
        if (Session["CampID"] != null)
        {            
            Int32.TryParse(Session["CampID"].ToString(), out resultCampId);            
        }
        else if(Session["FJCID"] != null)
        {
            DataSet ds = new CamperApplication().getCamperAnswers(Session["FJCID"].ToString(), "10", "10", "N");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                Int32.TryParse(dr["Answer"].ToString(), out resultCampId);
            }
        }

        switch (resultCampId)
        {
            case 1029: imgLogo.Src = "../../images/Camp Galil.jpg";
                //tdtext1.Visible = false;
                //tdtext2.Visible = true;
                break;
            case 1036: imgLogo.Src = "../../images/Camp Gesher.jpg";
                //tdtext1.Visible = true;
                //tdtext2.Visible = false;
                break;
            case 1037: imgLogo.Src = "../../images/Camp Gilboa.jpg";
                //tdtext1.Visible = false;
                //tdtext2.Visible = true;
                break;
            case 1057: imgLogo.Src = "../../images/Camp Miriam.JPG";
                //tdtext1.Visible = true;
                //tdtext2.Visible = false;
                break;
            case 1060: imgLogo.Src = "../../images/Camp Moshava.jpg";
                //tdtext1.Visible = true;
                //tdtext2.Visible = false;
                break;
            case 1066: imgLogo.Src = "../../images/Camp Na'aleh.jpg";
                //tdtext1.Visible = false;
                //tdtext2.Visible = true;
                break;
            case 1095: imgLogo.Src = "../../images/Camp Tavor.jpg";
                //tdtext1.Visible = false;
                //tdtext2.Visible = true;
                break;             
        }
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
			// camp is closed
			// Check if PJ code is used.  If not, we go to the last option NL.
			if (Session["codeValue"] != null)
			{
				if (Session["codeValue"].ToString() == "1")
				{
					CamperApplication CamperAppl = new CamperApplication();
					Session["FEDID"] = ConfigurationManager.AppSettings["PJL"].ToString();
					CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), "63");
					Response.Redirect("../PJL/Summary.aspx");
				}
			}
			Response.Redirect("../Step1_NL.aspx");
		}
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
