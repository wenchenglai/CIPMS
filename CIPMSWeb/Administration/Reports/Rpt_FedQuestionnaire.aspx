<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rpt_FedQuestionnaire.aspx.cs" Inherits="Administration_Reports_Rpt_FedQuestionnaire" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Federation Questionnaire Report</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <rsweb:ReportViewer runat="server" ID="MyReportViewer" Width="100%" Height="700px">                
            </rsweb:ReportViewer>        
        </div>
    </form>
</body>
</html>
