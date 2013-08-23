<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="CamperOptions.aspx.cs" Inherits="CamperOptions" %>
<asp:Content ID="ContentCamperOptions" ContentPlaceHolderID="Content" Runat="Server">
    <asp:Label ID="lblPageTitle" runat="server" CssClass="headertext" Text="Application(s) In Process" />
    <table class="text" width="100%">
        <tr>
            <td style="height:5px"></td></tr>
        <tr>
            <td>
                <p style="text-align:justify">
                    You can either create a new application or continue an existing application. If you are 
                    applying for grants for more than one child, please submit separate applications for each. 
                    You may use the same login email and password for all applications in your family. Your 
                    application will be automatically saved as you complete each page and click the "Next" 
                    button. If you would like to exit the application, remember to click "Save & Continue Later" before 
                    closing the application browser.</p></td></tr>
        <tr>
            <td style="height:10px"></td></tr>
        <tr>
            <td>
                <asp:LinkButton ID="lbtnNewApp" Text="New Application" runat="server" OnClick="lbtnNewApp_Click" /></td></tr>              
        <tr>
            <td style="height:10px"></td></tr>
        <tr>
            <td>
                <asp:GridView ID="gvApplications" runat="server" CssClass="text" BackColor="White" BorderColor="#999999"
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" 
                    AutoGenerateColumns="False" Width="100%" OnRowCommand="gvApplications_RowCommand" OnRowDataBound="gvApplications_RowDataBound">
                    <FooterStyle BackColor="#CCCCCC" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:TemplateField HeaderText="FJCID">
                            <ItemTemplate>
                                    <%--<asp:LinkButton ID="lnkFJCID" CommandName="FJCID" CommandArgument='<%# Eval("FJCID") %>' runat="server" Text='<%# Eval("FJCID") %>' />--%>
                                    <asp:Label ID="txtFJCID" runat="server" Text='<%# Eval("FJCID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                        <asp:TemplateField HeaderText="Clone Application">
                            <ItemTemplate>
                                    <asp:LinkButton ID="lnkClone" CommandName="CLONE_FJCID" CommandArgument='<%# Eval("FJCID") %>' runat="server" Text="Clone Application" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CurrentYear" Visible="false">
                            <ItemTemplate>
                                    <asp:Label ID="lblYear" Text='<%# Eval("CurrentYear") %>' runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="View Status / Application" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                    <asp:LinkButton ID="lnkBtnChkStatus" Text="check application status" runat="server" CommandName="CheckStatus" CommandArgument='<%# Eval("FJCID") %>'></asp:LinkButton>
                                    / <asp:LinkButton ID="lnkBtnViewApplication" Text="view application" runat="server" CommandName="ViewApplication" CommandArgument='<%# Eval("FJCID") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView></td></tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td style="height:10px">
                <asp:LinkButton ID="lnkExit" Text="Exit Application" runat="server" OnClick="lnkExit_Click" /></td></tr>        
    </table>
</asp:Content>

