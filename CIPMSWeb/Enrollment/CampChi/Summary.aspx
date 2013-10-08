<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Chi_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img src="../../images/chi_logo.gif" /></td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="lblPopup1">Good news! You may be eligible for an incentive.
                    </p></asp:Label>
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.</p></asp:Label>
               
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                 <b> The JCC Camp Chi One Happy Camper Program, Sponsored by JCC Camp Chi and the Foundation for Jewish Camp provides financial incentives of $1000 to first-time campers in 4th - 11th grades (after camp) attending JCC Camp Chi. Applicants cannot have previously attended a Jewish overnight camp for more than 19 days and cannot attend Jewish day school. Eligible programs include Chi’s 3-week, 4-week, 8-week sessions and Pacific Northwest Teen Adventure Trip.</b>
                 </p>
                </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                 There is no better camp for first time campers than JCC Camp Chi. Girls and boys ages 9 -16 make life-long friendships and form lasting memories under the leadership of nurturing staff. Our programs are tailored to the age-specific needs of campers who thrive and grow in an atmosphere of warmth and fun. Campers choose from over 40 different activities, including waterskiing, horseback riding, high ropes, art, radio broadcasting, sailing and much more. Campers enjoy special Shabbat celebrations, Israel education programs and are exposed to Jewish values, such as kavod (respect) and chesed (kindness). Camp Chi is located on 600 wooded acres with unmatched facilities -- two heated pools, six tennis courts, air-conditioned gym, private lake, lighted athletic field and basketball courts, climbing tower and Israeli village.</p>
                </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                 If you are interested in learning more about JCC Camp Chi, please visit <a href="http://www.campchi.com" target="_blank">www.campchi.com</a> or email <a href="mailto:info@campchi.com" target="_blank">info@campchi.com</a>.</p>
                </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call the camp professional listed at the bottom of this page.</p>
                </asp:Label></td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">
            <tr>
                <td valign="top" style="width: 5%">
                    <asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
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
                                    CssClass="submitbtn1" />
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
