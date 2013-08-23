<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Enrollment_Upload"
    MasterPageFile="~/AdminMaster.master" Title="Upload" %>

<asp:Content ContentPlaceHolderID="Content" ID="ContentStep2_CN_1" runat="server">
    <table style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; BORDER-LEFT: black thin solid; WIDTH: 540px; BORDER-BOTTOM: black thin solid">
        <tr>
            <td align="left">
                <asp:Label ID="lblUploadType" runat="server" CssClass="QuestionText" Text="Type of data :"
                    Width="111px"></asp:Label>
                <asp:DropDownList ID="ddlUploadType" runat="server" CssClass="dropdown" Width="133px">
                     <asp:ListItem Text="Award Notification" Value="2"></asp:ListItem>
                     <asp:ListItem Text="PJLibrary" Value="1"></asp:ListItem>
                   
                 </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="left">
                <asp:FileUpload ID="fileUpload" runat="server" CssClass="textbox1" Width="331px" /></td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button runat="server" Text="Submit" ID="btnSubmit" CssClass="submitbtn" OnClick="btnSubmit_Click" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblConfirmationText" runat="server" CssClass="lblPopup3" Visible="false"></asp:Label>
                <asp:Label ID="ErrorText" runat="server" CssClass="InfoText" ForeColor="Red" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
        </tr>
    </table>
    <br />
    <div style="overflow:auto;width:540px;">
    <asp:GridView ID="grdviewUploadeData" runat="Server" Visible="false" CssClass="Grid"
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
        CellPadding="3" ForeColor="Black" GridLines="Vertical" AllowPaging="false" PageSize="1"
        Width="40%">
        <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
        <PagerStyle Font-Size="Small" />
    </asp:GridView>
    </div>
</asp:Content>
