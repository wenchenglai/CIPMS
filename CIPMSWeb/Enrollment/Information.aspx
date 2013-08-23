<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Information.aspx.cs" Inherits="Enrollment_Ramah_Information"
    MasterPageFile="~/Common.master" %>

<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="Ramah_Information" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td style="height: 62px">
                <p class="QuestionText" style="text-align: justify; color: Red;">
                    Camp Ramah California is administering the Rishon incentive program directly through
                    the camp. Please contact the camp directly to inquire about the Rishon grant and
                    to obtain an application for this incentive program.
                </p>
                <p class="QuestionText" style="text-align: justify; color: Red;">
                    <b>Please contact Karmi Monsher (310)-476-8571 / <a href="mailto:karmi@ramah.org"
                        target="_blank">karmi@ramah.org</a>
                        <br />
                        <a href="http://www.ramah.org/" target="_blank">http://www.ramah.org/</a></b>
                </p>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" Width="554px">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">
            <tr>
                <td valign="top" style="width: 5%">
                    <asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2" style="width: 484px">
                    <br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td align="left">
                                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary"
                                    CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous"
                                    CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later"
                                    CssClass="submitbtn1" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
