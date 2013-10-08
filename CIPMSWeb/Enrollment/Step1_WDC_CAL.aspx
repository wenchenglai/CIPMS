<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step1_WDC_CAL.aspx.cs" Inherits="Step1_WDC_CAL" Title="Camper Enrollment Step 2" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_WDCAL_1"  ContentPlaceHolderID="Content" Runat="Server">
    <asp:Panel ID="Panel2" runat="server">
        <table width="100%" cellpadding="5" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="Label2" CssClass="headertext" runat="server">Basic Camper Information: Section II </asp:Label><br /><br />
                </td>
            </tr>
        </table>
            
        
        
        <table width="100%" cellpadding="5" cellspacing="0" border="0">
            <tr>
                <td valign="top">
                    <asp:Label ID="Label5" Text="" runat="server" CssClass="InfoText" /><asp:Label ID="Label8" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Panel id="PnlQ1" runat="server">
                        <asp:Label ID="Label9" runat="server" CssClass="QuestionText"><font style="font-weight:bold; color:Red;"> If the camper will be attending Camps Airy and Louise this summer, please <asp:LinkButton ID="lnkBtnNL" runat="server" Text="click here" ></asp:LinkButton></font>. This will take you to a page where you are able to select Camps Airy and Louise from a list of camps and continue the camper’s incentive application through the Camps Airy and Louise Incentive Program. </asp:Label><br />
                        &nbsp;</asp:Panel>
                </td>
            </tr>
            
            <tr>
                <td valign="top">
                    <asp:Label ID="Label1" Text="" runat="server" CssClass="InfoText" /><asp:Label ID="Label3" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Panel id="Panel1" runat="server">
                        <asp:Label ID="Label4" runat="server" CssClass="QuestionText"><font style="font-weight:bold; color:Red;"> If the camper wishes to attend a different camp this summer, please continue your application </font>through The Jewish Federation of Greater Washington by pressing the “next” button below.</asp:Label><br />
                        &nbsp;</asp:Panel>
                </td>
            </tr>
            

            <tr>
                <td colspan="2">
                    <asp:Label Height="30" ID="lblMessage" runat="server" CssClass="InfoText" Visible="false"></asp:Label>
                </td>
            </tr>
            
            <tr >
                <td valign="top"><asp:Label ID="Label16" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top"  colspan="2">
                    <table width="100%" cellspacing="0" cellpadding="5" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" /></td>
                            <td >
                                <asp:Button ID="btnPrevious"  runat="server" Text=" << Previous" CssClass="submitbtn" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnSaveandExit" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                            </td>
                            <td align="left">
                                <asp:Button ID="btnNext" Text="Next >>" CssClass="submitbtn" runat="server" />
                            </td>
                        </tr>
                     </table>
                </td>
            </tr>
        </table>       
        
    </asp:Panel>

    <asp:HiddenField ID="hdnFJCID" runat="server" />
   <%-- <asp:HiddenField ID="hdnFEDID" runat="server" />
    <asp:HiddenField ID="hdnZIPCODE" runat="server" />--%>
    <asp:HiddenField ID="hdnIsAdmin" runat="server" />
    <asp:HiddenField ID="hdnPerformAction" runat="server" />
    <asp:HiddenField ID="hdnIsSubmitted" runat="server" />
</asp:Content>

