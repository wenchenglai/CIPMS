<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="BulkStatusUpdate.aspx.cs" Inherits="Administration_BulkStatusUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
                    &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>

            <script type="text/javascript">
                var flag = false;
                $(function() {
                    $("#dialog-modal").dialog({
                        autoOpen: false,
                        width: 800,
                        buttons: [
                            {
                                text: "Ok",
                                click: function () {
                                    
                                    if ($('#initial').val() !== "") {
                                        $(this).dialog("close");
                                        SimulateClick("ctl00_Content_btnUpdate");
                                        return true;
                                    }
                                    if (!$('#warning').length) {
                                        $('#confirm').append("<p id='warning' style='color:red;font-size:small'>You must enter your initials, or cancel the process</p>");
                                    }
                                    return false;
                                }
                            },
                            {
                                text: "Cancel",
                                click: function () {
                                    $(this).dialog("close");
                                    debugger;
                                    return false;
                                }
                            }
                        ]
                    });

                });

                function update_click() {

                    if (flag) {
                        return true;
                    } else {
                        $("#dialog-modal").dialog("open");
                        return false;
                    }
                };

                function SimulateClick(buttonId) {
                    flag = true;
                    var button = document.getElementById(buttonId);
                    if (button) {
                        if (button.click) {
                            button.click();
                        }
                        else if (button.onclick) {
                            button.onclick();
                        }
                        else {
                            alert("DEBUG: button '" + buttonId + "' is not clickable");
                        }
                    } else {
                        alert("DEBUG: button with ID '" + buttonId + "' does not exist");
                    }
                }
            </script>
            <div id="dialog-modal" class="ui-dialog-content ui-widget-content" title="Basic modal dialog">
                <p>Are you sure you want to go ahead and change?</p>
                <p id="confirm">Please enter your initials to confirm: <input type="text" id="initial" /></p>
            </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>    
            <div>
                <h3>Mass updates from Payment Requested to Camper Attended Camp.</h3>
                <strong>Summer:</strong>&nbsp;&nbsp;
                <asp:DropDownList ID="ddlCampYear" DataValueField="id" DataTextField="text" AutoPostBack="true" runat="server" Enabled="false" />
                <br /><br /> 
                <asp:DropDownList runat="server" ID="ddlFed" AutoPostBack="True" DataSourceID="odsFed" DataValueField="ID" DataTextField="Name" Visible="True" />
                <asp:ObjectDataSource ID="odsFed" runat="server" TypeName="FederationsDA" SelectMethod="GetAllFederations">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlCampYear" Name="CampYearID" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>     
                </asp:ObjectDataSource>
                <br/><br />
                <asp:DropDownList runat="server" ID="ddlCamp" DataSourceID="odsCamp" DataTextField="Name" DataValueField="ID"/>
                <asp:ObjectDataSource ID="odsCamp" runat="server" TypeName="CampsDA" SelectMethod="GetAllCampsByFedID">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlCampYear" PropertyName="SelectedValue" Type="Int32" Name="CampYearID" />
                        <asp:ControlParameter ControlID="ddlFed" PropertyName="SelectedValue" Type="Int32" Name="FedID" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
            <div>
                <br/>
                <p class="text" style="color:red;">Have you cancelled all applications within this camp that need to be cancelled?</p>
                <p class="text" style="color:red;">If not please exit this process and complete the Cancellation process.</p>
                <asp:Button runat="server" ID="btnUpdate" Text="Update" OnClientClick="return update_click()" OnClick="btnUpdate_Click"/>
                <br/>
                <br/>
                <div><asp:Label runat="server" ID="lblMsg" ForeColor="Red"></asp:Label></div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

