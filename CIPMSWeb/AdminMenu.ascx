<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminMenu.ascx.cs" Inherits="AdminMenu" %>
<br />

<script type="text/javascript">   
    function windowopener2(){
        window.open('/ExcelExport.aspx' ,'EXcelExport','titlebar=no,width=650,height=450,left=250,top=150,resizable');           
    }
    function AlertMessage()
    {
        window.alert('The Data Extract has relocated to the OHC Reporting System (click the above “OHC Reporting System?link for access). Please note, you will soon no longer be able to access it here in its current location.'); 
    }
</script>

<table class="text" border="1" style="border-color: Red">
    <tr>
        <td>
            <table class="text">
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkWrkQ" runat="server" Text="Work Queue" OnClick="lnkWrkQ_Click"
                            CausesValidation="false" /></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkSearch" runat="server" Text="Search" OnClick="lnkSearch_Click"
                            CausesValidation="false" /></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
						<asp:HyperLink ID="hylCIPRS" runat="server" Text="Reports" Target="_blank"></asp:HyperLink>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <div id="dvRpts" runat="server">
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblRpts" runat="server" CssClass="text" Text="Reports" ForeColor="Blue" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;&nbsp;</td>
                                    <td>
                                        <asp:LinkButton ID="lnkSummary" runat="server" Text="Executive Summary" CssClass="text"
                                            OnClick="lnkSummary_Click" CausesValidation="false" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;&nbsp;</td>
                                    <td>
                                        <asp:LinkButton ID="lnkSumByCamps" runat="server" Text="Summary By Camps" CssClass="text"
                                            OnClick="lnkSumByCamps_Click" CausesValidation="false" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;&nbsp;</td>
                                    <td>
                                        <asp:LinkButton ID="lnkSumByStatus" runat="server" Text="Summary By Status" CssClass="text"
                                            OnClick="lnkSumByStatus_Click" CausesValidation="false" /></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <div id="divCheckRequest" runat="server">
                            <asp:LinkButton ID="lnkPayment" runat="server" Text="Payment - FJC" CausesValidation="false"
                                OnClick="lnkPayment_Click" />
                        </div>
                        <div id="disSelfFunding" runat="server">
                            <asp:HyperLink ID="hylSelfFunding" runat="server" Text="Payment - Self Funding" Target="_blank"></asp:HyperLink>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <div id="divAudit" runat="server">
                            <asp:LinkButton ID="lnkAudit" runat="server" Text="Audit Report" CausesValidation="false"
                                OnClick="lnkAudit_Click" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <div id="divExcel" runat="server" visible="false">
                            <asp:LinkButton ID="lnkExcel" runat="server" Text="Data Extract" CausesValidation="false"
                                OnClick="lnkExcel_Click" />
                            <%--<br />
                            <asp:LinkButton ID="lnkExcel2" runat="server" Text="2009 data extract" CausesValidation="false"
                                OnClick="lnkExcel2_Click" />--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <div id="divUpload" runat="server" visible="false">
                            <asp:LinkButton ID="lnkUpload" runat="server" Text="Upload Data" CausesValidation="false"
                                OnClick="lnkUpload_Click" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <div id="divANReport" runat="server" visible="true">
                            <asp:LinkButton ID="lnkANReprot" runat="server" Text="Award Notification Request" CausesValidation="false" OnClick="lnkANReprot_Click" />
                        </div>                       
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <div id="divPPIReport" runat="server" visible="true">
                            <asp:LinkButton ID="lnkBtnPPIReport" runat="server" Text="Program Profile Information Report" CausesValidation="false" OnClick="lnkPPIReport_Click" />
                        </div>                       
                    </td>
                </tr>
                 <tr>
                    <td>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkStatsReport" runat="server" Text="JWest Upgraded Sessions Report" OnClick="lnkStatsReport_Click"
                            CausesValidation="false" /></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkBulkStatusUpdate" Visible="false" runat="server" Text="Mass Update" OnClick="lnkBulkStatusUpdate_Click" CausesValidation="false" />

                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <div id="divProgramFinder" runat="server" Visible="false">
                            <asp:LinkButton ID="lnkProgramFinder" runat="server" Text="Program Finder" OnClick="lnkProgramFinder_Click" CausesValidation="false" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <div id="dvAdmin" runat="server">
                            <table class="text">
                                <tr>
                                    <td colspan="2">
                                        <asp:LinkButton ID="lnkAdmin" runat="server" Text="Administration" OnClick="lnkAdmin_Click"
                                            CausesValidation="false" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;&nbsp;</td>
                                    <td>
                                        <asp:LinkButton ID="lnkCreateUsr" runat="server" Text="Create User" OnClick="lnkCreateUsr_Click"
                                            CausesValidation="false" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;&nbsp;</td>
                                    <td>
                                        <asp:LinkButton ID="lnkManageUsr" runat="server" Text="Manage User" OnClick="lnkManageUsr_Click"
                                            CausesValidation="false" /></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkChangePwd" runat="server" Text="Change Password" OnClick="lnkChangePwd_Click"
                            CausesValidation="false" /></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkLogOut" runat="server" Text="Log Out" OnClick="lnkLogOut_Click"
                            CausesValidation="false" /></td>
                </tr>
                
            </table>
        </td>
    </tr>
</table>
