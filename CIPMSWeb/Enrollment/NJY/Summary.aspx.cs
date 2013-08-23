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

public partial class Enrollment_NJY_Summary : System.Web.UI.Page
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
        else if(Session["FJCID"] != null)
        {
            DataSet ds = new CamperApplication().getCamperAnswers(Session["FJCID"].ToString(), "10", "10", "N");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                Int32.TryParse(dr["Answer"].ToString(), out resultCampId);
            }
        }
        if(resultCampId != 0)
        if (resultCampId == 3069)
        {
            PnlCampNah.Visible = true;   
        }
        else if (resultCampId == 3110)
        {
            PnlCedar.Visible = true;
        }
        else if (resultCampId == 3159)
        {
            PnlTeen.Visible = true;
        }
		else if (resultCampId == 3123)
		{
			PnlRoundLake.Visible = true;
		}
		else
		{
			pnlShowContactInfo.Visible = true;
			btnNext.Visible = false;
		}
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Step1_NL.aspx");
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("Step2_2.aspx");
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
