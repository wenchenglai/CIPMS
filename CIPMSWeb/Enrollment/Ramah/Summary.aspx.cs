using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CIPMSBC;

public partial class Enrollment_Ramah_Summary : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        btnReturnAdmin.Click+=new EventHandler(btnReturnAdmin_Click);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int CampID = Convert.ToInt32(Session["CampID"]);
            
            // Camp Ramah Darom, for 2013 calendar year ONLY
            if (CampID == 4078)
            {
                DisableRegistration(CampID);
                if (Session["UsedCode"] != null)
                {
                    // 2013-02-21 Now Camp Ramah Doram use tblSpecialCodes table
                    string currentCode = Session["UsedCode"].ToString();
                    int CampYearID = Convert.ToInt32(Application["CampYearID"]);
                    int FedID = Convert.ToInt32(FederationEnum.Ramah);
                    List<string> specialCodes = SpecialCodeManager.GetAvailableCodesPerCamp(CampYearID, FedID, 4078);

                    // when moved to .NET 3.5 or above, remember to use lamda expression
                    foreach (string code in specialCodes)
                    {
                        if (code == currentCode)
                        {
                            EnableRegistration();
                            SpecialCodeManager.UseCode(CampYearID, FedID, code, Session["FJCID"].ToString());
                            break;
                        }
                    }
                }
            }
			else if (CampID == 4079) //2013-03-21 For Ramah Califonia 
			{
				DisableRegistration(CampID);
				if (Session["UsedCode"] != null)
				{
					string currentCode = Session["UsedCode"].ToString();
					int CampYearID = Convert.ToInt32(Application["CampYearID"]);
					int FedID = Convert.ToInt32(FederationEnum.Ramah);
					List<string> specialCodes = SpecialCodeManager.GetAvailableCodesPerCamp(CampYearID, FedID, 4079);

					// when moved to .NET 3.5 or above, remember to use lamda expression
					foreach (string code in specialCodes)
					{
						if (code == currentCode)
						{
							EnableRegistration();
							SpecialCodeManager.UseCode(CampYearID, FedID, code, Session["FJCID"].ToString());
							break;
						}
					}
				}
			}
			//else if (CampID == 4079)
			//{
			//    // Camp Ramah Califonia
			//    if (Session["UsedCode"] != null)
			//    {
			//        if (Session["UsedCode"].ToString() == ConfigurationManager.AppSettings["2012CRC6481"])
			//        {
			//            EnableRegistration();
			//        }
			//        else
			//        {
			//            DisableRegistration(CampID);
			//        }
			//    }
			//    else
			//        DisableRegistration(CampID);
			//}
			else if (CampID == 3082) //2012-03-28
			{
				// Camp Ramah in the Berkshires
				if (Session["UsedCode"] != null)
				{
					if (Session["UsedCode"].ToString() == "CRB421")
					{
						EnableRegistration();
					}
					else
					{
						Response.Redirect("~/NYCampRedirect.aspx");
					}
				}
				else
					Response.Redirect("~/NYCampRedirect.aspx");
			}
			else if (CampID == 4082) //2013-02-26 Close The camp Ramah in the Berkshire ONLY
			{
				DisableRegistration(CampID);
			}
			else
			{
				// All other Ramah camps
				EnableRegistration();
			}
        }
    }

    private void EnableRegistration()
    {
        tblNoRegister.Visible = false;
        tblRegister.Visible = true;
        btnNext.Visible = true;
    }

    private void DisableRegistration(int CampID)
    {
		tblRegister.Visible = false;
		btnNext.Visible = false;

        tblNoRegister.Visible = true;
        if (CampID == 4078)
        {
            lblRamahDarom.Visible = true;
            lblRamahCal.Visible = false;
			divDisableBerkshire.Visible = false;
        }
        else if (CampID == 4079)
        {
            lblRamahDarom.Visible = false;
            lblRamahCal.Visible = true;
			divDisableBerkshire.Visible = false;
        }
		else if (CampID == 4082)
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
        //if (Session["CampID"] != null)
        //{
        //    if (Session["CampID"].ToString() == "2079" || Session["CampID"].ToString() == "2078")
        //    {
        //        Response.Redirect("~/NYCampRedirect.aspx");
        //    }
        //    else
        //    {
        //        Response.Redirect("../Step1_NL.aspx");
        //    }
        //}
        //else
        //{
            Response.Redirect("../Step1_NL.aspx");
        //}
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
		int CampID = Convert.ToInt32(Session["CampID"]);
		if (CampID == 4082)
		{
			Response.Redirect("../Step1_NL.aspx");
		}
		else
			Response.Redirect("Step2_2.aspx");
    }
}
