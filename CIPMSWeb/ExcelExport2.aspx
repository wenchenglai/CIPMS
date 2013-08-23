<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExcelExport2.aspx.cs" Inherits="ExcelExport2" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Data Extract to Excel</title>
</head>
<body>
<div id="gridDiv" style="position:absolute; top: 0px; left: 0px; ">
    <form id="form1" runat="server">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="600px" ProcessingMode="Remote"
        Width="100%">
    </rsweb:ReportViewer>
    </form>
 </div>
</body>
</html>
