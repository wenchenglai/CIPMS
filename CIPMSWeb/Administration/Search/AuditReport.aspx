<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AuditReport.aspx.cs" Inherits="Administration_Search_Audit" EnableEventValidation="false"%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <script type="text/javascript">
        function submitmyform(f) {
            f.target = 'foo'
            window.open('',f.target,'menubar=no,scrollbars=no, width=800,height=800');
            f.submit();
            return false;
        }
    </script>

    <asp:ScriptManager ID="scriptManager" runat="server" />
        <table class="text" width="100%">
            <tr class="InfoText">
                <td>
                    <asp:Label ID="lblMsg" runat="server" /></td></tr>
        </table>
    
        <rsweb:ReportViewer ID="rv" runat="server" Height="600px" Width="100%" ProcessingMode="Remote" />
    <br />
</asp:Content>

