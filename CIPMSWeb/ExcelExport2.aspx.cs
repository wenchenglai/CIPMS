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
using System.Data.SqlClient;

using Microsoft.Reporting.WebForms;



public partial class ExcelExport2 : System.Web.UI.Page
{
    private SrchCamperDetails _objCamperDet = new SrchCamperDetails();
    private General _objGen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {
       // PopulateGrid();
        RenderReport("23", "2009", "null");
    }

    private void RenderReport(string FederationID, string CampYear, string PaymentID)
    {
        try
        {
 
            string strRpt = "/CIPMS_Reports/ViewDump";
            string strReportServerURL = ConfigurationManager.AppSettings["ReportServerURL"];
            string strParamValue = "";

            //*****************************
            //Set general report properties
            //*****************************
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(strReportServerURL);   // Report Server URL
            ReportViewer1.ServerReport.ReportPath = strRpt;                             // Report Name
            //ReportViewer1.ShowParameterPrompts = false;
            //ReportViewer1.ShowDocumentMapButton = true;
            //ReportViewer1.ShowPrintButton = true;            

            //*************************
            // Create report parameters
            //*************************

            //Report mode parameter
            ReportParameter reportFederationID = new ReportParameter();
            reportFederationID.Name = "FederationID";
            strParamValue = Session["FedID"].ToString();
            reportFederationID.Values.Add(null);

            //Federation Name parameter
            ReportParameter reportFederation = new ReportParameter();
            reportFederation.Name = "FederationName";
            strParamValue = "xxxx";
            reportFederation.Values.Add(strParamValue);


            // Set the report parameters for the report
            ReportViewer1.ServerReport.SetParameters(
                new ReportParameter[] { reportFederationID, reportFederation});

            //convert to excel
            string mimeType;
            string encoding;
            string[] streams;
            string extension;
            Microsoft.Reporting.WebForms.Warning[] warnings;
            byte[] returnValue;

            returnValue = ReportViewer1.ServerReport.Render("Excel", null, out mimeType, out encoding, out extension, out streams, out warnings);

            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment ; filename=filename." + extension);

            Response.BinaryWrite(returnValue);
            Response.Flush();
            Response.End(); 





        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    //private void PopulateGrid()
    //{
    //    string Federation = "Federations: All";

    //    System.IO.StringWriter tw = new System.IO.StringWriter();
    //    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

    //    CIPDataAccess dal = new CIPDataAccess();

    //    DataSet dsExport;

    //    string FederationID = string.Empty;
    //    try
    //    {
    //        FederationID = Session["FedID"].ToString();
    //    }
    //    catch { };


    //    if (FederationID.Trim() == string.Empty)
    //    {
    //        dsExport = dal.getDataset("usp_GetViewDupm", null);
    //    }
    //    else
    //    {
    //        Federation = "Federation: " + Session["FedName"].ToString();
    //        SqlParameter[] param = new SqlParameter[1];
    //        param[0] = new SqlParameter("@FederationID", FederationID);
    //        dsExport = dal.getDataset("[usp_GetViewDupm]", param);
    //    }

    //    string FileName = "CIPMS-Camper-Extract-" + String.Format("{0:M/d/yyyy}", DateTime.Now) + ".xls";

    //    Response.ContentType = "application/vnd.ms-excel";
    //    Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1255");
    //    Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);  

    //    if (dsExport.Tables[0].Rows.Count == 0)
    //    {
    //        this.Controls.Remove(gvExport);
    //        Response.Write("No matching records found.");
    //        Response.End();
    //    }
    //    else
    //    {
    //        gvExport.DataSource = dsExport;
    //        gvExport.DataBind();

    //        hw.WriteLine("<table><tr><td><b><font size='3'>" +
    //           "Campers Data Export" +
    //           "</font></b></td></tr>");

    //        hw.WriteLine("<tr><td><font size='2'>" + Federation +
    //        "</font></td></tr>");

    //        hw.WriteLine("<tr><td><font size='2'>" +
    //        "Export Date: " + String.Format("{0:M/d/yyyy hh:mm tt}", DateTime.Now) +
    //        "</font></td></tr></table>");

    //        form1.Controls.Clear();
    //        form1.Controls.Add(gvExport);
    //        form1.RenderControl(hw);

    //        //gvExport.RenderControl(hw);

    //        this.EnableViewState = false;
    //        Response.Write(tw.ToString());
    //        Response.End();
    //    }
    //}
   

    protected void gvWrkQ_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvExport_DataBound(object sender, EventArgs e)
    {
        
    }
    protected void gvExport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label mylabel = e.Row.FindControl("lblFJCID") as Label;
            mylabel.Text = "=TEXT(" + mylabel.Text + ",\"#\")";
        }
    }
}
