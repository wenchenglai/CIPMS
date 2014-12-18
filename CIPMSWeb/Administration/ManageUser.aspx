<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageUser.aspx.cs" MasterPageFile="~/AdminMaster.master" Inherits="Administration_ManageUser" %>
<%@ MasterType VirtualPath="~/AdminMaster.master" %>
<asp:Content ID="CreateUsr" ContentPlaceHolderID="Content" runat="server">
    <script type="text/javascript" language="javascript">
        //*********************************************************************************************
        // Name:            ConfirmDelete
        // Description:     Will confirm with the user if they want to proceed with deleting a record.
        //
        // Parameters:      sFirstName - the first name of the user
        //                  sLastName  - the last name of the user
        // Returns:         true  - user wants to proceed
        //                  false - user does NOT want to proceed
        // History:         04/2009 - TV: Initial coding. 
        //*********************************************************************************************
        function ConfirmDelete(sFirstName, sLastName)
        {
            return confirm('Are you sure that you want to delete this record for\n' + 
                           sFirstName + ' ' + sLastName + ' ?\n\n' + 
                           'Click OK to proceed, or Cancel.');
        }
    </script>
    <table class="text" width="100%">
        <tr><td><asp:Label ID="lblMsg" runat="server" CssClass="infotext1" /></td></tr>
        <tr><td><asp:Label ID="lblErrMsg" runat="server" CssClass="InfoText" /></td></tr>
    </table>
    <table class="text" border="1" cellpadding="0" cellspacing="0" style="border-color:Red" width="100%">
        <tr>
            <td>
                <table class="text" width="100%">
                    <tr>
                        <td colspan="11" style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="11" style="height: 10px">
                            <asp:ValidationSummary ID="vldsumErrMsg" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="11" style="height:10px"></td></tr>
                    <tr>
                        <td class="headertext1">First Name</td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="txtFirstNm" runat="server" CssClass="txtbox" MaxLength="50" Width="120px" /></td>
                        <td></td>
                        <td class="headertext1">Last Name</td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="txtLastNm" runat="server" CssClass="txtbox" MaxLength="50" Width="120px" /></td>
                        <td></td>
                        <td class="headertext1">Email</td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="txtbox" MaxLength="150" Width="120px" /></td></tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>
                            <asp:RegularExpressionValidator ID="revFirstNm" runat="server" ControlToValidate="txtFirstNm" 
                                Display="None" ErrorMessage="Please use letters A-Z (') and (-) for First Name"
                                ValidationExpression="^[a-zA-Z'\s-]{1,50}$" /></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>
                            <asp:RegularExpressionValidator ID="revLastNm" runat="server" ControlToValidate="txtLastNm" 
                                Display="None" ErrorMessage="Please use letters A-Z (') and (-) for Last Name"
                                ValidationExpression="^[a-zA-Z'\s-]{1,50}$" /></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" 
                                Display="None" ErrorMessage="Please enter a valid Email ID"
                                ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$" /></td></tr>
                    <tr>
                        <td colspan="11" style="height:10px"></td></tr>
                    <tr>
                       <td class="headertext1">Federation</td>
                       <td></td>
                       <td colspan="5">
                            <asp:DropDownList ID="ddlFed" runat="server" CssClass="dropdown" Width="300px" /></td>
                        <td colspan="4"></td>
                        </tr>
                       <tr>
                            <td colspan="11" style="height:10px"></td>
                       </tr> 
                       <tr>
                        <td class="headertext1">Movement</td>
                        <td></td>
                        <td colspan="5">
                            <asp:DropDownList ID="ddlMovement" runat="server" DataTextField="name" DataValueField="id" CssClass="dropdown" Width="300px" /></td>
                        <td colspan="4"></td>
                        </tr>
                    <tr align="right">
                        <td colspan="11" style="height:10px">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="submitbtn" OnClick="btnSearch_Click" /></td></tr>
                    <tr>
                        <td colspan="11" style="height:10px"></td></tr></table>    
            </td>
        </tr></table>
    <br />
    <table class="text" width="100%">
        <tr>
            <td colspan="11">
                <asp:GridView ID="gvUsrDetails" runat="server" CssClass="text" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black"
                    GridLines="Vertical" Width="100%" OnRowCommand="gvUsrDetails_RowCommand" OnRowDeleting="gvUsrDetails_DeleteCommand">
                    <FooterStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField HeaderText="First Name" DataField="FirstName" />
                        <asp:BoundField HeaderText="Last Name" DataField="LastName" />
                        <asp:BoundField HeaderText="Phone Number" DataField="PhoneNumber" />
                        <asp:BoundField HeaderText="Email ID" DataField="Email" />
                        <asp:BoundField HeaderText="Movement" DataField="Movement" /> 
                        <asp:BoundField HeaderText="Federation" DataField="FedName" />                        
                        <asp:BoundField HeaderText="Role" DataField="RoleName" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit User" CommandName="Edit" CommandArgument='<%# Eval("UserID") %>' CssClass="gridbtn" Width="58px" />
                                <br />
                                <br />
                                <asp:Button ID="btnDelete" OnClientClick=<%# "return ConfirmDelete('" + DataBinder.Eval(Container.DataItem, "FirstName").ToString().Replace("'", "\\'") + "','" + DataBinder.Eval(Container.DataItem, "LastName").ToString().Replace("'", "\\'") + "');" %> runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("UserID") %>' CssClass="gridbtn" Width="45px" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
<%--                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>--%>
                    </Columns>
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                </asp:GridView>
                </td></tr>
    </table>
</asp:Content>
