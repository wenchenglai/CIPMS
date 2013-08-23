<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="ReturningCamper.aspx.cs" Inherits="Enrollment_ReturningCamper" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
 <table class="text" width="100%">
        <tr>
            <td style="height:10px"></td></tr>
        <tr>
            <td style="word-wrap: break-word">         
                <asp:GridView ID="gvReturningCamper" runat="server" CssClass="Grid" AutoGenerateColumns="False" Width="100%" 
                        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                        ForeColor="Black" GridLines="Vertical" OnRowCommand="gvReturningCamper_RowCommand">
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                    <Columns>
                        <asp:TemplateField HeaderText="FJCID" SortExpression="FJCID">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFJCID" CommandName="FJCID" CommandArgument='<%# Eval("FJCID") %>' runat="server" Text='<%# Eval("FJCID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="firstname" HeaderText="First Name"  />
                        <asp:BoundField DataField="lastname" HeaderText="Last Name" />
                        <asp:BoundField DataField="dateofbirth" HeaderText="Date of Birth" />
                        <asp:BoundField DataField="personalemail" HeaderText="Personal Email" />
                        <asp:BoundField DataField="street" HeaderText="Street" />                        
                        <asp:BoundField DataField="city" HeaderText="City" />
                        <asp:BoundField DataField="state" HeaderText="State"/>
                        <asp:BoundField DataField="country" HeaderText="Country" />
                        <asp:BoundField DataField="zip" HeaderText="Zip Code"  />                        
                        <asp:BoundField DataField="gender" HeaderText="Gender"  />
                        <asp:BoundField DataField="parent1name" HeaderText="Parent1 Name"  />
                        <asp:BoundField DataField="parent2name" HeaderText="Parent2 Name"  />
                    </Columns>                        
                    <FooterStyle BackColor="#CCCCCC" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="Silver" ForeColor="Blue" HorizontalAlign="Right" Font-Names="Trebuchet MS" Font-Size="Smaller" Font-Bold="True" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Position="Top" />
                </asp:GridView>        
            </td>   
        </tr>
         <tr>
            <td style="height:10px"></td></tr>
        <tr>
        <td colspan="2" ><asp:Label ID="Label2" CssClass="QuestionText" runat="server">
            <b><font color="red" >Welcome back JWest Camper Family! Our records indicate that your child received a first-time JWest grant last summer. Please complete this application to qualify for your child’s second-year grant. If this information is inaccurate, please contact us at jwest@jewishcamp.org or 888-888-4819.</font></b></asp:Label></td>
        </tr>
    </table>
</asp:Content>

