<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_CMART_Summary" %>

<asp:Content ID="CMART_summary" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
         <td>
                <img src="../../images/MIIP.png" alt=""  /></td>
            <td>
                <asp:Label ID="Label1" CssClass="QuestionText" runat="server">
                  <p style="text-align:justify">The <b>Midwest Interfaith Incentive Program (MIIP)</b>, 
                  an initiative of the Foundation for Jewish Camp, seeks to increase the number of Jewish children from interfaith families enjoying transformative experiences at select Jewish overnight summer camps in the Midwest. </p>            
                </asp:Label>
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">This program offers <u>returning</u> MIIP campers an incentive grant of $750 if they choose to attend the same camp again for a second consecutive summer.</p>
                </asp:Label>
                </td>
        </tr>
        <%--<tr >
            <td colspan="2">
                </td>
        </tr>--%>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify"><b>In order to be eligible for a Midwest Interfaith Incentive Program incentive grant:</b></p>
                </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" runat="server" CssClass="QuestionText" Style="text-align: justify">
                    <ol>
                    <li> Campers must have received a MIIP grant in summer 2011 and be attending a nonprofit Jewish overnight camp (listed below) for 19 consecutive days or longer in 2012</li>
                    <li> Campers must not be currently enrolled in a daily immersive Jewish experience, such as day school or yeshiva.</li>
                    <li> Campers must identify as Jewish and come from a family where one parent is Jewish and the other is not.</li>
                    <li> Campers must not be receiving any additional incentive funds through another incentive program co-sponsored by the Foundation for Jewish Camp.</li>
                </ol>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label4" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify"><b>Participating camps:</b> Camp Sabra, B’nai B’rith Beber Camp, Habonim Dror Camp Tavor, JCC Camp Chi, Camp Young Judaea Midwest, Camp Interlaken JCC, JCC Camp Wise, Camp Nageela Midwest, URJ Olin-Sang-Ruby Union Institute, Camp Livingston, Camp Ramah Wisconsin</p>
                </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label5" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please contact your camp or the Foundation for Jewish Camp professional listed at the bottom of this page.</p>
                </asp:Label></td>
        </tr>
        <%--<tr>
            <td>
            <asp:Label ID="Label6" runat="server" CssClass="QuestionText">
                <p style="text-align:justify; font-weight:bold; color:Red;">To continue with your Midwest Interfaith Incentive 
                Program application, please click the "next" button below.</p>
                </asp:Label>
            </td>
        </tr>--%>
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">
            <tr>
                <td valign="top" style="width: 5%">
                    <asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2">
                    <br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td align="left">
                                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary"
                                    CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous"
                                    CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later"
                                    CssClass="submitbtn1" OnClick="btnSaveandExit_Click" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> "
                                    CssClass="submitbtn" OnClick="btnNext_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
