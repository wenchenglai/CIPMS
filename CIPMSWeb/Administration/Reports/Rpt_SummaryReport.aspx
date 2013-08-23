<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Rpt_SummaryReport.aspx.cs" Inherits="Administration_Reports_Rpt_SummaryReport" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <div>
        <rsweb:ReportViewer runat="server"></rsweb:ReportViewer>
        <rsweb:ReportViewer runat="server" ID="MyReportViewer" Width="100%" Height="700px">                
        </rsweb:ReportViewer>        
    </div>
</asp:Content>

