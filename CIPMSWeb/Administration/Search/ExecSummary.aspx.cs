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

public partial class Administration_Search_PaymentRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lbl = (Label)this.Master.FindControl("lblPageHeading");
        lbl.Text = "Executive Summary";
        RenderReport();
    }

    private void RenderReport()
    {
        try
        {
            string strRpt = "/CIPMS_Reports/Executive Summary";
            string strReportServerURL = ConfigurationManager.AppSettings["ReportServerURL"];

            //*****************************
            //Set general report properties
            //*****************************
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(strReportServerURL);   // Report Server URL
            ReportViewer1.ServerReport.ReportPath = strRpt;                             // Report Name
            ReportViewer1.ShowParameterPrompts = true;
            ReportViewer1.ShowDocumentMapButton = true;
            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.ZoomMode = ZoomMode.PageWidth;
}
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
