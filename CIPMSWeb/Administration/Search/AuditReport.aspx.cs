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
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;

public partial class Administration_Search_Audit : System.Web.UI.Page
{
    private General _objGen;
    public const string NULL = "-1";

    protected void Page_Load(object sender, EventArgs e)
    {
        Label lbl = (Label)this.Master.FindControl("lblPageHeading");
        lbl.Text = "Audit Report";

        RenderReport();
    }

    private void RenderReport()
    {
        string strRpt = "/CIPMSReports/Audit";
        //string strRpt = "/wenreport/Feds";
        string strReportServerURL = ConfigurationManager.AppSettings["ReportServerURL"];

        rv.ServerReport.ReportServerUrl = new Uri(strReportServerURL);
        rv.ServerReport.ReportPath = strRpt;
        rv.ShowParameterPrompts = true;
        rv.ShowDocumentMapButton = true;
        rv.ShowPrintButton = true;
        rv.ZoomMode = ZoomMode.PageWidth;
    }
}
