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

public partial class Administration_Reports_Rpt_FedQuestionnaire : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strFJCID = (string)Session["FJCID"];
        string strReportServerURL = ConfigurationManager.AppSettings["ReportServerURL"];

        MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MyReportViewer.ServerReport.ReportServerUrl = new Uri(strReportServerURL); // Report Server URL
        MyReportViewer.ServerReport.ReportPath = "/CIPMS_Reports/rpt_CamperApplicationDetails"; // Report Name
        MyReportViewer.ShowParameterPrompts = false;
        MyReportViewer.ShowDocumentMapButton = true;
        MyReportViewer.ShowPrintButton = true;

        // Pass FJCID parameter to report
        Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[1];
        reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter();
        reportParameterCollection[0].Name = "FJCID";
        reportParameterCollection[0].Values.Add(strFJCID);
        MyReportViewer.ServerReport.SetParameters(reportParameterCollection);

        MyReportViewer.ServerReport.Refresh();
    }
}
