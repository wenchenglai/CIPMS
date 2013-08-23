<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Summary" %>

<asp:Content ID="LACIP_summary" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td colspan="2">
                <asp:Label ID="Label4" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    Good news! You may be eligible for an incentive.
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" CssClass="QuestionText" runat="server">
					<p style="text-align:justify">
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
					</p>
				</asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 20%">
                <img id="logo1" width="230px" height="200px" src="../../images/la.jpg" />
            </td>
            <td>
                <asp:Label ID="PROGRAMBLURB2" runat="server" CssClass="infotext4">
                    <p style="text-align:justify">
                        The Los Angeles One Happy Camper Program, sponsored by the Jewish Federation of Greater Los Angeles and the Foundation for Jewish Camp, 
                        provides financial incentives for children attending Jewish overnight summer camp for the first time for at least 12 consecutive days.
                    </p>
					<p style="text-align:justify; font-weight:bold">
						Eligibility requirements include:
					</p>  
                    <ul style="text-align:justify; font-weight:bold">
						<li>Campers must be residents of Greater Los Angeles.</li>
						<li>Campers must be entering grades 2-12 (after camp) and must attend a Jewish residential camp in California as listed on the application list for at least 12 consecutive days.</li>
						<li>Campers must have never previously attended Jewish overnight camp for any length of time (not including weekend and family camps).</li>
                    </ul>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblOtherInfo" runat="server" CssClass="QuestionText">
					<p style="text-align:justify">
                        The One Happy Camper Program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. As such, 
                        children who attend Jewish day school or yeshiva are not eligible for this incentive program. If you do not think that you are eligible for this program, 
                        but are interested in learning about camp scholarship opportunities, please visit 
                        <a href="http://www.jewishcamp.org/scholarships" target="_blank">www.JewishCamp.org/Scholarships</a> or directly contact your camp or Federation.
                    </p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
					<p style="text-align:justify">
						If you need additional assistance, please call your community professional listed at the bottom of this page. 
                    </p>
                </asp:Label>
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
                                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary"
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
