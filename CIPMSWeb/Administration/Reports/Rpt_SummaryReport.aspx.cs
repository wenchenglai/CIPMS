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

public partial class Administration_Reports_Rpt_SummaryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRpt;
        string qstr = Request.QueryString["rpt"];

        if (qstr == "camps")
            strRpt = "/CIPMS_Reports/StatusByCamps";
        else
            strRpt = "/CIPMS_Reports/rpt_StatusByFederation";

        string strReportServerURL = ConfigurationManager.AppSettings["ReportServerURL"];

        MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MyReportViewer.ServerReport.ReportServerUrl = new Uri(strReportServerURL); // Report Server URL
        MyReportViewer.ServerReport.ReportPath = strRpt; // Report Name
        MyReportViewer.ShowParameterPrompts = true;
        MyReportViewer.ShowDocumentMapButton = true;
        MyReportViewer.ShowPrintButton = true;
       
        //MyReportViewer.ServerReport.Refresh();
    }
}
