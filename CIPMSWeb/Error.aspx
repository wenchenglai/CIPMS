<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" Title="Foundation for Jewish Camp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head></head>
    <body>
        <form id="frmErr" runat="server">
            <table border="0" cellpadding="0" cellspacing="0" style="position:absolute; top:100px" width="800px">
                <tr>
                    <td align="center">
                        <asp:Label ID="lbl" runat="server" Text="Your session has expired." CssClass="InfoBigText" Font-Names="Verdana" Font-Size="XX-Large" ForeColor="Red" /></td></tr>
                <tr>
                    <td style="height:50px">
                        </td></tr>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="lnkBackToLogin" runat="server" CssClass="text" Text="Please click here to login again" Font-Names="Verdana" Font-Size="11pt" OnClick="lnkBackToLogin_Click" /></td></tr>
            </table>
        </form>
    </body>
</html>
