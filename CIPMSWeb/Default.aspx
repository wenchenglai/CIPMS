<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" MasterPageFile="~/AdminMaster.master" Inherits="_Default" %>
<%@ Register Src="AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc1"  %>

<asp:Content ID="LoginPg" ContentPlaceHolderID="Content" runat="server">
    <table style="LEFT: 280px; POSITION: absolute; TOP: 210px">
        <tr>
            <td>
                <asp:Label ID="lblErr" runat="server" CssClass="InfoText" /></td></tr>
    </table>
    <table class="text" border="0" style="LEFT: 350px; POSITION: absolute; TOP: 240px">
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Administration Maintenance" CssClass="headertext1" /></td></tr>
        <tr>
            <td colspan="2" style="height:10px"></td></tr>
        <tr>
            <td>User ID:&nbsp;</td>
            <td>
                <asp:TextBox ID="txtUsrId" runat="server" Width="200px" cssClass="text" /></td></tr>
        <tr style="height:10px"><td colspan="2"></td></tr>
        <tr>
            <td>Password:&nbsp;</td>
            <td>
                <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="200px" cssClass="text" /></td></tr>
        <tr style="height:10px"><td colspan="2"></td></tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSubmit" Text="Submit" runat="server" Width="100px" cssClass="text" OnClick="btnSubmit_Click" />
            </td></tr>
    </table>
</asp:Content>
