﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="BulkStatusUpdate.aspx.cs" Inherits="Administration_BulkStatusUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <script type="text/javascript">
                var flag = false;
                $(function() {
                    $("#dialog-modal").dialog({
                        autoOpen: false,
                        width: 800,
                        buttons: [
                            {
                                text: "Yes",
                                click: function () {
                                    $(this).dialog("close");
                                    SimulateClick("ctl00_Content_btnUpdate");
                                    return true;
                                }
                            },
                            {
                                text: "No",
                                click: function () {
                                    $(this).dialog("close");
                                    return false;
                                }
                            }
                        ]
                    });

                });

                function update_click() {
                    $('#ctl00_Content_lblMsg').text("");
                    // Error Checking
                    if (!$('#ctl00_Content_chkboxYes').is(':checked')) {
                        $('#ctl00_Content_lblMsg').text("Please check the confirmation box before you proceed.");
                        return false;
                    }

                    if ($('#ctl00_Content_txtInitials').val() === "") {
                        $('#ctl00_Content_lblMsg').text("Please enter your initials before you proceed.");
                        return false;
                    }

                    if ($('#ctl00_Content_ddlStatusTransition>option:selected').val() === "25") {
                        $('#fromStatus').text('Payment Requested');
                        $('#toStatus').text('Camper Attended Camp');
                    } else if ($('#ctl00_Content_ddlStatusTransition>option:selected').val() === "7") {
                        $('#fromStatus').text('Eligible by Staff');
                        $('#toStatus').text('Enrollment Confirmed; Payment Pending');
                    }

                    if (flag) {
                        return true;
                    } else {
                        $("#dialog-modal").dialog("open");
                        return false;
                    }
                };

                // Simulate a button click on asp.net form from Javascript
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
                <p>Are you sure you would like to update all "<span id="fromStatus"></span>" records for the camps selected to the status of "<span id="toStatus"></span>"?</p>
            </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>    
            <div style="margin-left: 20px;">
                <h3>Mass updates from Payment Requested to Camper Attended Camp.</h3>
                <strong>Summer:</strong>&nbsp;&nbsp;
                <asp:DropDownList ID="ddlCampYear" DataValueField="id" DataTextField="text" AutoPostBack="true" runat="server" Enabled="false" />
                <br /><br /> 
                <strong>Status Transitions:</strong>&nbsp;&nbsp;
                <asp:DropDownList ID="ddlStatusTransition" DataValueField="id" DataTextField="text" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlStatusTransition_SelectedIndexChanged" OnDataBound="ddlStatusTransition_DataBound">
                    <asp:ListItem Text="Eligible: Admin Approved -> Enrollment Confirmed; Payment Pending" Value="7"></asp:ListItem>                    
                    <asp:ListItem Text="Payment Requested -> Camper Attended Camp" Value="25"></asp:ListItem>
                </asp:DropDownList>
                <br /><br/>
                <asp:DropDownList runat="server" ID="ddlFed" AutoPostBack="True" DataSourceID="odsFed" DataValueField="ID" DataTextField="Name" Visible="True" />
                <asp:ObjectDataSource ID="odsFed" runat="server" TypeName="FederationsDA" SelectMethod="GetAllFederationsByUserRole">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlCampYear" Name="CampYearID" PropertyName="SelectedValue" Type="Int32" />
                        <asp:SessionParameter SessionField="RoleID" Name="UserRole" Type="Int32" />
                        <asp:SessionParameter SessionField="FedID" Name="FedID" Type="Int32" />
                    </SelectParameters>     
                </asp:ObjectDataSource>
                <br /><br />

                    <asp:RadioButtonList ID="rdolistCamp" DataSourceID="odsCamp" DataTextField="Name" DataValueField="ID" RepeatDirection="Vertical" 
                        RepeatColumns="2"  runat="server" ondatabound="chkrdoCamp_DataBound" />


                <asp:ObjectDataSource ID="odsCamp" runat="server" TypeName="CampsDA" SelectMethod="GetAllCampsFilterByStatusMinimumOneCamper">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlCampYear" PropertyName="SelectedValue" Type="Int32" Name="CampYearID" />
                        <asp:ControlParameter ControlID="ddlFed" PropertyName="SelectedValue" Type="Int32" Name="FedID" />
                        <asp:ControlParameter ControlID="ddlStatusTransition" DefaultValue="25" Type="Int32" Name="StatusID" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
            <div style="margin-left: 20px;">
                <br/>
                <div style="border-width: 2px; border-style: solid; width: 350px; padding: 8px">
                    <asp:CheckBox runat="server" ID="chkboxYes" Text="Yes, I have confirmed all the campers in “Eligible; Admin Approved” are registered at the camp indicated above for the indicated session length." />
                    <br />
                    <asp:TextBox ID="txtInitials" Width="35" runat="server"></asp:TextBox> Enter initials here
                </div>
                <br />
                <asp:Button runat="server" ID="btnUpdate" Text="Update" OnClientClick="return update_click()" OnClick="btnUpdate_Click"/>
                <br/>
                <br/>
                <div><asp:Label runat="server" ID="lblMsg" ForeColor="Red"></asp:Label></div>
                <div><asp:Label runat="server" ID="lbl" ForeColor="Red"></asp:Label></div>
            </div>
            <div style="margin-left: 20px;">
                <asp:GridView ID="gv" Visible="False" runat="server"></asp:GridView>
                <asp:ObjectDataSource ID="odsGv" runat="server" TypeName="BulkStatusUpdateRecordDA" SelectMethod="GetAll">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlCampYear" PropertyName="SelectedValue" Type="Int32" Name="CampYearID" />
                        <asp:ControlParameter ControlID="ddlFed" PropertyName="SelectedValue" Type="Int32" Name="FedID" />
                    </SelectParameters>                    
                </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

