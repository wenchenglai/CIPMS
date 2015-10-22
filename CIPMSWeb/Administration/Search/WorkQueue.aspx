<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="WorkQueue.aspx.cs" Inherits="Administration_Search_WorkQueue" %>
<asp:Content ID="WrkQueue" ContentPlaceHolderID="Content" Runat="Server">
  <table class="text" width="100%">
    <tr>
      <td>
        <asp:Label ID="lblWrkQueue" CssClass="headertext" runat="server" Text="Work Queue:"></asp:Label>&nbsp;&nbsp;
        <asp:LinkButton ID="lnkWhatToDO" runat="server" onclick="lnkWhatToDO_Click">What do I do?</asp:LinkButton>
      </td>
    </tr>
    <tr>
      <td>
          <p>
                Welcome to One Happy Camper 2016.  Please remember to review applications thoroughly and contact us with any questions. 
              If you would like to make changes to your application please fill out this <a href="https://docs.google.com/forms/d/1yygKMK-CRZi_F_WzeLKb1aojcbWglFD_2npi32pDGxU/viewform" target="_blank">form</a> and the OHC Team will be in contact with you within two business days.
          </p>

      </td>
    </tr>
    <tr>
      <td style="height:10px">
      </td>
    </tr>
    <tr>
            <td style="word-wrap: break-word">         
                <asp:GridView ID="gvWrkQ" runat="server" CssClass="Grid" AutoGenerateColumns="False" Width="100%" 
                        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                        ForeColor="Black" GridLines="Vertical" OnRowCommand="gvWrkQ_RowCommand" AllowPaging="True" AllowSorting="True" 
                        PageSize="20" OnPageIndexChanging="gvWrkQ_PageIndexChange" OnRowDataBound="gvWrkQ_RowDataBound" OnSorting="gvWrkQ_OnSort">
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                    <Columns>
                        <asp:TemplateField HeaderText="FJCID" SortExpression="FJCID">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFJCID" CommandName="FJCID" CommandArgument='<%# Eval("FedFJCID") %>' runat="server" Text='<%# Eval("FJCID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CamperName" HeaderText="Camper Name" SortExpression="CamperName" />
                        <asp:BoundField DataField="Zip" HeaderText="Zip" SortExpression="Zip" />
                        <asp:BoundField DataField="Federation" HeaderText="Federation" SortExpression="Federation" />
                        <%--<asp:BoundField DataField="Camp" HeaderText="Camp" SortExpression="Camp" />--%>
                       <%-- newly added functionality for keeping camp as dropdown list--%>
                         <asp:TemplateField HeaderText="Camp" SortExpression="Camp">
                            <HeaderTemplate>
                            Camps :
                            <asp:DropDownList ID="lnkCampList" runat="server" OnSelectedIndexChanged="lnkCampList_SelectedIndexChanged" AutoPostBack="True" CssClass="ddl_workaround" >
                            </asp:DropDownList>
                            </HeaderTemplate>
                           <ItemTemplate> 
                           <asp:Label ID="lnkCampName" runat="server" Text='<%# Bind("Camp") %>'></asp:Label> 
                          </ItemTemplate> 

                        </asp:TemplateField>
                       
                        <asp:BoundField DataField="Admin" HeaderText="Admin" SortExpression="Admin" />
                        <asp:BoundField DataField="SubmittedDate" HeaderText="Submit Date" SortExpression="SubmittedDate" />
                        <asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="ModifiedDate" />
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
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
       
        <td>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblWrkQueueMsg" CssClass="lblpopup1" runat="server" Text="No Records Found">                
                    </asp:Label>
        </td>
        </tr>
        <tr>
        <td>
        
            <asp:GridView ID="exgrid" runat="server" CssClass="Grid" AutoGenerateColumns="False" Width="100%" 
                        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                        ForeColor="Black" GridLines="Vertical" OnRowCommand="gvWrkQ_RowCommand" AllowPaging="True" AllowSorting="True" 
                        PageSize="20" OnPageIndexChanging="gvWrkQ_PageIndexChange" OnRowDataBound="gvWrkQ_RowDataBound" OnSorting="gvWrkQ_OnSort">
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                    <Columns>
                        <asp:TemplateField HeaderText="FJCID" SortExpression="FJCID">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFJCID" CommandName="FJCID" CommandArgument='<%# Eval("FedFJCID") %>' runat="server" Text='<%# Eval("FJCID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CamperName" HeaderText="Camper Name" SortExpression="CamperName" />
                        <asp:BoundField DataField="Zip" HeaderText="Zip" SortExpression="Zip" />
                        <asp:BoundField DataField="Federation" HeaderText="Federation" SortExpression="Federation" />
                        <asp:BoundField DataField="Camp" HeaderText="Camp" SortExpression="Camp" />                        
                        <asp:BoundField DataField="Admin" HeaderText="Admin" SortExpression="Admin" />
                        <asp:BoundField DataField="SubmittedDate" HeaderText="Submit Date" SortExpression="SubmittedDate" />
                        <asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="ModifiedDate" />
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    </Columns>                        
                    <FooterStyle BackColor="#CCCCCC" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="Silver" ForeColor="Blue" HorizontalAlign="Right" Font-Names="Trebuchet MS" Font-Size="Smaller" Font-Bold="True" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Position="Top" />
                </asp:GridView>
        
        </td>
        </tr>
    </table>

</asp:Content>

