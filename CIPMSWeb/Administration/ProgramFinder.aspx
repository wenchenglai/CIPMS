<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="ProgramFinder.aspx.cs" Inherits="Administration_ProgramFinder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>          
            <div style="margin-left: 20px;">
                <h3>Program Finder</h3>
                <div>
                    <asp:TextBox runat="server" ID="txtZipCode" MaxLength="7"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" Text="Find Program" ID="btnFind" OnClick="btnFind_Click"/>
                    <asp:Label runat="server" ID="lblError" ForeColor="Red"></asp:Label>
                </div>
                <asp:Panel runat="server" ID="pnlResult" Visible="false">
                    <ul style="list-style-type: none;">
                        <li><strong>Program:</strong> <asp:Label runat="server" ID="lblProgram"></asp:Label></li>
                        <li><strong>Contact:</strong> <asp:Label runat="server" ID="lblContact"></asp:Label></li>
                        <li><strong>Email:</strong> <asp:Label runat="server" ID="lblEmail"></asp:Label></li>
                        <li><strong>Phone:</strong> <asp:Label runat="server" ID="lblPhone"></asp:Label></li>
                        <li><br /><strong>Status:</strong> <asp:Label runat="server" ID="lblStatus"></asp:Label></li>
                        <li><br /><strong>Availability:</strong> <asp:Label runat="server" ID="lblAvail"></asp:Label></li>
                        <li><strong>General Processing:</strong> <asp:Label runat="server" ID="lblGeneralProcessing"></asp:Label></li>
                        <li><br /><strong>Offers grants for JDS kids:</strong> <asp:Label runat="server" ID="lblJDS"></asp:Label></li>
                        <li><strong>JDS Processing:</strong> <asp:Label runat="server" ID="lblJDSProcessing"></asp:Label></li>
                    </ul>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

