using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CIPMSBC;

public partial class Enrollment_Sabra_Summary : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    if (Session["SpecialCodeValue"] != null)
        //    {
        //        int CampID = Convert.ToInt32(Session["CampID"]);
        //        int FedID = Convert.ToInt32(Session["FedId"]);
        //        string Code = Session["SpecialCodeValue"].ToString();
        //        string FJCID = Session["FJCID"].ToString();

        //        int UsedTimes = ValidateCode(FedID, CampID, Code, FJCID);
        //        if ( UsedTimes == 0)
        //        {
        //            UpdateCode(FedID, CampID, Code, FJCID);
        //            EnableRegistration();
        //        }
        //        else if (UsedTimes == 1)
        //        {
        //            EnableRegistration();
        //        }
        //        else
        //        {
        //            DisableRegistration();
        //        }
        //    }
        //    else
        //        DisableRegistration();
        //}
    }

    private void EnableRegistration()
    {
        tblNoRegister.Visible = false;
        tblRegister.Visible = true;
        btnNext.Visible = true;
    }

    private void DisableRegistration()
    {
        tblNoRegister.Visible = true;
        tblRegister.Visible = false;
        btnNext.Visible = false;
    }

    private int ValidateCode(int FedID, int CampID, string Code, string FJCID)
    {
        CIPDataAccess dal = new CIPDataAccess();
        try
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@FedID", FedID);
            param[1] = new SqlParameter("@CampID", CampID);
            param[2] = new SqlParameter("@Code", Code);
            param[3] = new SqlParameter("@FJCID", FJCID);

            DataSet ds = dal.getDataset("[usp_RegistrationCodes_Validate]", param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            return -1;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dal = null;
        }
    }

    private void UpdateCode(int FedID, int CampID, string Code, string FJCID)
    {
        CIPDataAccess dal = new CIPDataAccess();
        try
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@FedID", FedID);
            param[1] = new SqlParameter("@CampID", CampID);
            param[2] = new SqlParameter("@Code", Code);
            param[3] = new SqlParameter("@FJCID", FJCID);
            dal.ExecuteNonQuery("[usp_RegistrationCodes_Update]", param);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dal = null;
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
