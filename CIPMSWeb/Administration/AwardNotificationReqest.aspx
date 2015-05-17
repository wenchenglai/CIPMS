<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AwardNotificationReqest.aspx.cs" Inherits="AwardNotificationReqest" MasterPageFile="~/AdminMaster.master" %>

<asp:Content ContentPlaceHolderID="content" runat="server" ID="Content1">

    <script type="text/javascript" language="javascript"> 
    function EmptyCheck(sender, args) 
    {
        if(document.getElementById('<%= chkFinal.ClientID %>').checked==false) 
        args.IsValid = false;
        else
        args.IsValid = true; 
    }
    </script>  

    <table class="text" width="100%" cellpadding="0" cellspacing="0" style="border-right: thin solid;
        border-top: thin solid; border-left: thin solid; border-bottom: thin solid">
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td>
                <table class="text" width="100%" style="font-weight: bold">
                    <tr>
                        <td colspan="3" align="left" style="width:100%">
                            No of Records:
                            <asp:DropDownList ID="ddlRecCount" runat="Server" CssClass="text">
                                <asp:ListItem Text="100 Records" Value="100"></asp:ListItem>
								<asp:ListItem Text="250 Records" Value="250"></asp:ListItem>
                                <asp:ListItem Text="500 Records" Value="500"></asp:ListItem>
                                <asp:ListItem Text="1000 Records" Value="1000"></asp:ListItem>
                                <asp:ListItem Text="All Records" Value="0"></asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="3" align="left" style="width:100%">
                        <asp:RadioButton ID="rdoFirstTime" runat="server" GroupName="type" Text="First Time Campers" />
                        <asp:RadioButton ID="rdoSecondTime" runat="server" GroupName="type" Text="Second Time Campers" />
                        </td>
                    </tr>
                    <tr style="width:100%">
                        <td>
                            Mode:
                            <asp:RadioButtonList ID="rdbtnlstMode" runat="server" CssClass="text" RepeatDirection="Horizontal"
                                RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="rdbtnlstMode_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">Preliminary</asp:ListItem>
                                <asp:ListItem Value="1">Final</asp:ListItem>
                            </asp:RadioButtonList></td>
                        <td>

                        </td>
                        <td align="center">
                            &nbsp;<asp:Button ID="btnFinal" runat="server" CssClass="submitbtn" OnClick="btnSubmit_Click"
                                Text="Submit" CausesValidation="true" /></td>
                    </tr>
                    <tr style="width:100%">
                        <td colspan="3">
                            <asp:Panel ID="pnlFinal" runat="server" Width="100%" Visible="False">
                                <table class="text" border="1" cellpadding="0" cellspacing="0" style="border-color: Gray" width="99%"> 
                                    <tr>
                                        <td>
                                            <table style="background-color: silver">
                                                <tr>
                                                    <td style="background-color: silver" class="text">
                                                        You have selected a Final Mode for AN report. Clicking SUBMIT will cause the system to update camper data records
                                                        with award notification staus information, and you will not be able to undo these updates without technical
                                                        assistance. If you are sure that this is what you want to do, click the checkbox
                                                        below, and then click SUBMIT.</td>
                                                </tr>
                                                <tr>
                                                    <td style="background-color: silver">
                                                        <asp:CheckBox ID="chkFinal" runat="server" CssClass="text" Text="I am sure" />
                                                        <asp:CustomValidator EnableClientScript="true" ID="CustomValidator1" ClientValidationFunction="EmptyCheck"
                                                            runat="server" Display="Dynamic" ErrorMessage="Check I am sure checkbox." CssClass="InfoText"/>                                                       

                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td style="">
                <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td>
                <table class="text" width="100%" style="font-weight: bold; border-right: black 1px solid;
                    border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;"
                    id="tblReportDetails" runat="server">
                    <tr>
                        <td align="left" style="width: 32%">
                            Report Mode:
                        </td>
                        <td>
                            <asp:Label ID="lblMode" runat="server" Text="Preliminary"></asp:Label></td>
                        <td align="right">
                            Request Time:
                            <asp:Label ID="lblReqTime" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 32%">
                            No of Records in the report:
                        </td>
                        <td>
                            <asp:Label ID="lblNoOfRecords" runat="server" Text="0"></asp:Label></td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="grdANReport" runat="server" CssClass="NewGrid" AutoGenerateColumns="False"
                     BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="1" ForeColor="Black" GridLines="Vertical" AllowPaging="True" PageSize="20"
                    OnPageIndexChanging="OnPaging" Visible="False" Width="100%">                    
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                    <Columns>
                        <asp:TemplateField HeaderText="FJCID">
                            <ItemTemplate>
                                <div>
                                <asp:Label ID="lblFJCID" runat="server" Width="100px" Text='<%#Eval("FJCID")%>'></asp:Label></div>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="Camper Last Name">
                            <ItemTemplate>
                                <div style="word-wrap: break-word;">
                                    <asp:Label ID="lblCamperName" runat="server" Text='<%#Eval("Last Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Camper First Name">
                            <ItemTemplate>
                                <div style="word-wrap: break-word;">
                                    <asp:Label ID="lblCamperName" runat="server" Text='<%#Eval("First Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="Parent Email">
                            <ItemTemplate>
                                <div style="word-wrap: break-word;">
                                <asp:Label ID="lblParentEmail" runat="server" Text='<%#Eval("Email")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Camp Name">
                            <ItemTemplate>
                            <div style="word-wrap: break-word;">
                                <asp:Label ID="lblCampName" runat="server" Text='<%#Eval("Camp Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Program">
                            <ItemTemplate>
                            <div style="word-wrap: break-word;">
                                <asp:Label ID="lblFedName" runat="server" Text='<%#Eval("Federation Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="Silver" ForeColor="Blue" HorizontalAlign="Right" Font-Names="Trebuchet MS" Font-Bold="True" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />                    
                    <PagerSettings Position="Top" />                    
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
