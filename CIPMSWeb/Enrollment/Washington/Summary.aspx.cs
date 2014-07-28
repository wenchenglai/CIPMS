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

			bool isDisabled = false;
			string[] FedIDs = ConfigurationManager.AppSettings["DisableOnSummaryPageFederations"].Split(',');
			for (int i = 0; i < FedIDs.Length; i++)
			{
				if (FedIDs[i] == FED_ID)
				{
					isDisabled = true;
					break;
				}
			}

			if (isDisabled)
			{
				tblDisable.Visible = true;
				tblRegular.Visible = false;
				btnSaveandExit.Visible = false;

                if (Session["UsedCode"] != null)
                {
                    // 2013-03-15 Now Adamah use tblSpecialCodes table
                    string currentCode = Session["UsedCode"].ToString();
                    int CampYearID = Convert.ToInt32(Application["CampYearID"]);
                    List<string> specialCodes = SpecialCodeManager.GetAvailableCodes(CampYearID, FedID);

                    // when moved to .NET 3.5 or above, remember to use lamda expression
                    foreach (string code in specialCodes)
                    {
                        if (code == currentCode)
                        {
                            tblDisable.Visible = false;
                            tblRegular.Visible = true;
                            btnNext.Visible = true;
                            break;
                        }
                    }
                }
			}
			else
			{
				tblDisable.Visible = false;
				tblRegular.Visible = true;
				btnSaveandExit.Visible = true;
			}
		}


		//if (Session["FedID"] != null && Session["FJCID"]!= null)
		//{
		//    if (Session["FedID"].ToString() == "49")
		//    {
		//        DataSet dsForCodeEntered = new DataSet();
		//        CamperAppl = new CamperApplication();
		//        string questionID = "", codeEntered = "";
		//        questionID = "1031";
		//        dsForCodeEntered = CamperAppl.getCamperAnswers(Session["FJCID"].ToString(), questionID, questionID, "N");
		//        string ConfigDCCode = ConfigurationManager.AppSettings["DCCode"];
		//        if (dsForCodeEntered.Tables[0].Rows.Count > 0)
		//        {
		//            codeEntered = dsForCodeEntered.Tables[0].Rows[0]["Answer"].ToString();
		//            codeEntered = codeEntered.ToUpper();
		//            if (codeEntered == ConfigDCCode)
		//                btnNext.Enabled = true;
		//        }
		//        else
		//        {
		//            //btnNext.Enabled = false;
		//        }
		//    }    
		//}
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
		string Next_URL = "Step2_2.aspx";

		if (tblDisable.Visible)
			Next_URL = "../Step1_NL.aspx";

		Response.Redirect(Next_URL);
    }
}
