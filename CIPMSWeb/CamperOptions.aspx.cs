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

public partial class CamperOptions : System.Web.UI.Page
{
    private SrchCamperDetails _objCamperDet = new SrchCamperDetails();
    General objGeneral = new General();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Populate DataGrid
        if (!IsPostBack)
        {
            DataSet dsCampYear= objGeneral.GetCurrentYear();
            if (dsCampYear.Tables[0].Rows.Count > 0)
            {
                Session["CampYear"] = dsCampYear.Tables[0].Rows[0]["CampYear"].ToString();
            }
            else
            {
                //Session["CampYear"] = DateTime.Now.Year;
                Session["CampYear"] = Application["CampYear"].ToString();
            }
            Session["FEDID"] = null;
        }

        PopulateGrid();
        if (!CouldApplcationsBeCloned())
        {
            gvApplications.Columns[3].Visible = false;
        }
    }

    private bool CouldApplcationsBeCloned()
    {
        string strCampId = (string)Session["CamperLoginID"];
        CamperApplication CamperAppl = new CamperApplication();
        return CamperAppl.CouldApplcationsBeCloned(strCampId);
    }

    private void PopulateGrid()
    {
        string strCampId;
        strCampId = (string)Session["CamperLoginID"];
        DataSet dsCamper;
        dsCamper = _objCamperDet.GetCamperDetails(Convert.ToInt32(strCampId));
        gvApplications.DataSource = dsCamper;
        gvApplications.DataBind();
    }

    protected void gvApplications_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblYear = e.Row.FindControl("lblYear") as Label;
            string sCurrentYear = lblYear.Text;

            if (sCurrentYear.ToLower().Equals("false"))
            {
                //LinkButton lnkFJCID = e.Row.FindControl("lnkFJCID") as LinkButton;
                //lnkFJCID.Enabled = false;
                LinkButton lnkBtnViewApplication = e.Row.FindControl("lnkBtnViewApplication") as LinkButton;
                lnkBtnViewApplication.Enabled = false;

                LinkButton lnkClone = e.Row.FindControl("lnkClone") as LinkButton;
                lnkClone.Visible = true;
            }
            else
            {
                //LinkButton lnkFJCID = e.Row.FindControl("lnkFJCID") as LinkButton;
                //lnkFJCID.Enabled = true;
                LinkButton lnkBtnViewApplication = e.Row.FindControl("lnkBtnViewApplication") as LinkButton;
                lnkBtnViewApplication.Enabled = true;

                LinkButton lnkClone = e.Row.FindControl("lnkClone") as LinkButton;
                lnkClone.Visible = false;
            }
        }
    }

    protected void gvApplications_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "FJCID")
        {
            Session["FJCID"] = e.CommandArgument.ToString();
            //Session["CampYear"] = Session["FJCID"].ToString().Substring(0, 4);
            string strRedirURL = "";

            DataSet dsCamperApplication;
            DataRow drCA;
            CamperApplication oCA = new CamperApplication();
            dsCamperApplication = oCA.getCamperApplication(e.CommandArgument.ToString());
            drCA = dsCamperApplication.Tables[0].Rows[0];

            if (!string.IsNullOrEmpty(drCA["AppType"].ToString()))
            {
                if (drCA["AppType"].ToString() == "D")
                {
                    strRedirURL = "DeleteMessage.aspx";
                }
                else
                    strRedirURL = ConfigurationManager.AppSettings["CamperBasicInfo"].ToString();
            }
            else
            {
                strRedirURL = ConfigurationManager.AppSettings["CamperBasicInfo"].ToString();
            }

            Server.Transfer(strRedirURL);
        }
        else if (e.CommandName == "CLONE_FJCID")
        {
            string strRedirURL = ConfigurationManager.AppSettings["CamperBasicInfo"].ToString();
            string sOldFJCID = e.CommandArgument.ToString();
            CamperApplication CamperAppl = new CamperApplication();
            string newFJCID;
            int retVal;

            retVal = CamperAppl.CopyCamperApplication(sOldFJCID, out newFJCID);

            Session["FJCID"] = newFJCID;
            Session["STATUS"] = 5;

            // reset the session values 
            Session["FEDNAME"] = null;

            Server.Transfer(strRedirURL);
        }
        else if (e.CommandName == "CheckStatus")
        {
            Session["FJCID"] = e.CommandArgument.ToString();
            string strRedirURL = "~/TrackMyStatus.aspx";
            Server.Transfer(strRedirURL);
        }
        else if (e.CommandName == "ViewApplication")
        {
            Session["FJCID"] = e.CommandArgument.ToString();
            string strRedirURL = "";

            DataSet dsCamperApplication;
            DataRow drCA;
            CamperApplication oCA = new CamperApplication();
            dsCamperApplication = oCA.getCamperApplication(e.CommandArgument.ToString());
            drCA = dsCamperApplication.Tables[0].Rows[0];

            if (!string.IsNullOrEmpty(drCA["AppType"].ToString()))
            {
                if (drCA["AppType"].ToString() == "D")
                {
                    strRedirURL = "DeleteMessage.aspx";
                }
                else
                    strRedirURL = ConfigurationManager.AppSettings["CamperBasicInfo"].ToString();
            }
            else
            {
                strRedirURL = ConfigurationManager.AppSettings["CamperBasicInfo"].ToString();
            }

			Response.Redirect(strRedirURL);
            //Server.Transfer(strRedirURL);
        }
    }

    protected void lbtnNewApp_Click(object sender, EventArgs e)
    {
        Session["FJCID"] = null;
        string strRedirURL;
        strRedirURL = ConfigurationManager.AppSettings["CamperBasicInfo"].ToString();
        Server.Transfer(strRedirURL);
    }

    protected void lnkExit_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.RemoveAll();
        Session.Abandon();
        Response.Cookies.Clear();
        Response.CacheControl = "no-cache";
        Response.Expires = -1;
        Response.Redirect("~/Home.aspx");
    }
}
