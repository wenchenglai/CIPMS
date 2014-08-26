<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Summary" %>

<asp:Content ID="LACIP_summary" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td colspan="2">
                <p>Good news! You may be eligible for a One Happy Camper grant.</p>
                <p>
                    To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
                </p>
                <p>
                    The Los Angeles One Happy Camper program, sponsored by the Jewish Federation of Greater Los Angeles and the Foundation for Jewish Camp, 
                    provides financial incentives for children attending Jewish overnight summer camp for the first time for at least 12 consecutive days. 
                </p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>Campers must be residents of Greater Los Angeles.</li>
                        <li>Campers must be entering grades 2-12 (after camp) and must attend a Jewish residential camp in California as listed on the application list for at least 12 consecutive days.</li>
                        <li>Campers must have never previously attended Jewish overnight camp for any length of time (not including weekend and family camps).</li>
                    </ul>
				</p> 
                <p>
                    The One Happy Camper program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. 
                    As such, children who attend Jewish day school or yeshiva are not eligible for this incentive program. 
                </p>  
                <p>
                    If you do not think that you are eligible for this program, but are interested in learning about camp 
                    scholarship opportunities, please visit <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a> or directly contact your camp or Federation.
                </p>
                <p>
                    If you need additional assistance, please call your community professional listed at the bottom of this page.
                </p>   
            </td>
        </tr>
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
                                    CssClass="submitbtn1" /></td>
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
