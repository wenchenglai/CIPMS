<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="BulkStatusUpdate.aspx.cs" Inherits="Administration_BulkStatusUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
                    &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>    
            <script type="text/javascript">


                function update_click() {
                    $("#dialog-modal").dialog({
                        height: 140,
                        modal: true
                    });
                };
            </script>
            <div id="dialog-modal" title="Basic modal dialog">
                <p>Adding the modal overlay screen makes the dialog look more prominent because it dims out the page content.</p>
            </div>
            <div>
                <h3>Mass updates from Payment Requested to Camper Attended Camp.</h3>
                <asp:Label runat="server" ID="lblMsg" ForeColor="Red"></asp:Label>
                <strong>Summer:</strong>&nbsp;&nbsp;
                <asp:DropDownList ID="ddlCampYear" DataValueField="id" DataTextField="text" AutoPostBack="true" runat="server">
                    
                </asp:DropDownList>
                <br /><br /> 
                <asp:DropDownList runat="server" ID="ddlFed" AutoPostBack="True" OnSelectedIndexChanged="ddlFed_SelectedIndexChanged" />
                <br/><br/>
                <asp:DropDownList runat="server" ID="ddlCamp" DataSourceID="odsCamp" DataTextField="Name" DataValueField="ID"/>
                <asp:ObjectDataSource ID="odsCamp" runat="server" TypeName="CampsDA" SelectMethod="GetAllCampsByFedID">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlCampYear" PropertyName="SelectedValue" Type="Int32" Name="CampYearID" />
                        <asp:ControlParameter ControlID="ddlFed" PropertyName="SelectedValue" Type="Int32" Name="FedID" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
            <div>
                <asp:Button runat="server" ID="btnUpdate" Text="Update" OnClientClick="return update_click()" OnClick="btnUpdate_Click"/>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

