<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="ProgramContact.aspx.cs" Inherits="Administration_ProgramContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    
<script type="text/javascript">
    function showEditBox() {
        $('ctl00_Content_lblMsg').text('');
        $('#divShow').hide();
        $('#divEdit').show();
    }

    $(function () {
        $('#divShow').show();
        $('#divEdit').hide();
    });
</script>
    <h2>Program Admin Contact</h2>
<asp:DropDownList runat="server" ID="ddlFed" CssClass="fed-ddl" AutoPostBack="True" DataSourceID="odsFed" DataValueField="ID" DataTextField="Name" Visible="True" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlFed_SelectedIndexChanged">
    <asp:ListItem Value="0" Text="Please select a program"></asp:ListItem>
</asp:DropDownList>
<asp:ObjectDataSource ID="odsFed" runat="server" TypeName="FederationsDA" SelectMethod="GetAllActiveFederations">
    <SelectParameters>
        <asp:SessionParameter SessionField="RoleID" Name="UserRole" Type="Int32" />
        <asp:SessionParameter SessionField="FedID" Name="FedID" Type="Int32" />
    </SelectParameters>     
</asp:ObjectDataSource>

<asp:Panel runat="server" ID="pnlData">
    <div id="divShow" style="width: 200px; padding: 20px; margin:20px; background-color:gainsboro; border-radius: 10px">
        <asp:Label runat="server" ID="lblName"></asp:Label><br/><br/>
        <asp:Label runat="server" ID="lblPhone"></asp:Label><br/><br/>
        <asp:Label runat="server" ID="lblEmail"></asp:Label>
    </div>
    
    <button onclick="showEditBox(); return false;" >Edit</button>
    <br /><br />
    <asp:Label runat="server" ID="lblMsg" ForeColor="Red"></asp:Label> 
    <div id="divEdit" style="padding: 20px;">
        <table>
            <tbody>
                <tr>
                    <td>Name</td>
                    <td><asp:TextBox runat="server" ID="txtName" Width="200"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Phone</td>
                    <td><asp:TextBox runat="server" ID="txtPhone" Width="200"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td><asp:TextBox runat="server" ID="txtEmail" Width="200"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click"/></td>
                </tr>
            </tbody>
        </table>  
    </div>

</asp:Panel>
</asp:Content>

