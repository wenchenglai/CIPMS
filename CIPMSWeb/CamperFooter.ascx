<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CamperFooter.ascx.cs" Inherits="CamperFooter" %>
<table class="text" width="100%">
    <tr align="right">
        <td>
            <asp:Label ID="lblFederationName" runat="server" Text="Foundation for Jewish Camp" CssClass="headertext1"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblContactText" runat="server" Text="Contact: " CssClass="headertext"></asp:Label>
            <asp:Label ID="lblContact" runat="server" Text="" CssClass="headertext1"></asp:Label>
        </td>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Phone: " CssClass="headertext"></asp:Label>
            <asp:Label ID="lblPhone" runat="server" Text="888-888-4819" CssClass="headertext1"></asp:Label>
        </td>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Email: " CssClass="headertext"></asp:Label>
            <asp:Label ID="lblEmail" runat="server" Text="OneHappyCamper@JewishCamp.org" CssClass="headertext1"></asp:Label>
        </td>
    </tr>
</table>
<asp:Label ID="lblRedirUrl" runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblParentInfoPreviousURL" runat="server" Visible="false"></asp:Label>