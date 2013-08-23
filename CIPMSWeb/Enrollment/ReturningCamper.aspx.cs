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

public partial class Enrollment_ReturningCamper : System.Web.UI.Page
{

    private SrchCamperDetails _objCamperDet = new SrchCamperDetails();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Populate DataGrid
        if (IsPostBack != true)
        {
            PopulateGrid();
            
        }
    }
    private void PopulateGrid()
    {
        DataSet dsCamper = new DataSet();
        dsCamper =(DataSet)Session["DSCamperDetails"];
        gvReturningCamper.DataSource = dsCamper;
        gvReturningCamper.DataBind();
        
    }
    protected void gvReturningCamper_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "FJCID")
        {
            string strFJCID = e.CommandArgument.ToString();
            Session["FJCID"] = strFJCID;
            string strRedirURL = "Step1.aspx?check=popup";
            string link="Step1.aspx";
            string strScript = "<script language=javascript>window.close();if (window.opener && !window.opener.closed) { window.opener.location.reload( true ); }  window.location='" + strRedirURL + "'; </script>";
            if (!ClientScript.IsStartupScriptRegistered("clientScript"))
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strScript);
            }
           
           
        }
    }
}
