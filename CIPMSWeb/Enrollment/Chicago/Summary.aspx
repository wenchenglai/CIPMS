<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Chicago_Summary" %>

<asp:Content ID="Chicago_Summary" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
			<td>
				<img id="Img2" src="../../images/chicago.jpg" alt="" />
			</td>
			<td >
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify">Good news!  You may be eligible for an incentive.</p>
                </asp:Label>
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
					</p>
				</asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						The JUF Chicago One Happy Camper program, sponsored by the Foundation for Jewish Camp and JUF Chicago, offers financial incentives of up to 
						$1,000 to first-time campers who attend a nonprofit Jewish overnight summer camp for at least 19 consecutive days. Eligible campers must 
						be entering grades 3-9 (after camp) and live in the six-county Illinois area served by JUF. Siblings of campers who previously received a 
						$1,000 grant are eligible to receive $500 when they attend camp for the first time for at least 19 consecutive days.
					</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
					Campers must also attend a Jewish overnight camp listed on the Foundation for Jewish Camp’s website 
					(<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>). 
                        This program is an outreach initiative for families who might otherwise choose to send their children to a non-Jewish overnight camp. 
                        As such, children who attend Orthodox Jewish day school are generally 
					not eligible for this incentive program, although exceptions do exist.
					</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<span style="color:Red;"><b>Students at Orthodox Day Schools</b></span> who are ineligible for a One Happy Camper grant may be 
						eligible to receive a Camp Coupon grant through JUF/JF. Please email <a href="mailto:JewishCamp@juf.org">JewishCamp@juf.org</a> to find out more.
					</p>
                </asp:Label>
            </td>
        </tr>        
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call your community professional listed at the bottom of this page.</p>
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
