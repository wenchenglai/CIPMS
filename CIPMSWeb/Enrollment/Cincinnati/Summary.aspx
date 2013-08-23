<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_JCC_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
           <%-- <td>
                <img id="logo" src="" /></td>--%>
            <td colspan="2">
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="infotext3"><b>Send your child to camp this summer for the first time through an exciting program underwritten by your local Jewish community, in partnership with the Foundation for Jewish Camp’s One Happy Camper program.</b></p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                <br />
                 If you live in Cincinnati and your child is attending camp for the first time this coming summer, s/he may be eligible to receive a grant of up to $1000 through the Cincinnati Jewish Overnight Camping Program.</p>
                 
                </asp:Label>
                <p class="infotext3">To learn more about the program and to obtain an application please <asp:LinkButton ID="goldringlink" runat="server" OnClick="cincinnatilink_Click" Text="[CLICK HERE]" ></asp:LinkButton>.
                 </p>
            </td>
        </tr>        
                
        <tr>
            <td colspan="2">
                <asp:Label ID="Label4" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">For more information on this program please contact Prof. Getzel Cohen at <a href="mailto:getzel.cohen@uc.edu" target="_blank">getzel.cohen@uc.edu</a>, (513) 556-1951. </p>
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
                                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary"
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
                                    CssClass="submitbtn" OnClick="btnNext_Click" Visible="false" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
