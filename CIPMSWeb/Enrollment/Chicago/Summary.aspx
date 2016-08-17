<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Chicago_Summary" %>

<asp:Content ID="Chicago_Summary" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
			<td>
				<img id="Img2" src="../../images/chicago.jpg" alt="" />
			</td>
			<td >
                <p>
					Good news! You may be eligible for an incentive.
				</p>
                <p>
					To determine if you are eligible continue reading and if your camper meets the eligibility criteria, 
					please proceed by clicking the "next" button below.
				</p>
            </td>
        </tr>
        <tr>
            <td colspan="2">
			    <p>
                    The JUF Chicago One Happy Camper program, sponsored by the Foundation for Jewish Camp and JUF Chicago, offers financial incentives of up to $1,000 to first-time campers who attend a nonprofit Jewish overnight summer camp for at least 19 consecutive days.
			    </p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>First time camper must be entering grades 3-9 (after camp).</li>
                        <li>Live in the six-county Illinois area served by JUF.</li>
                        <li>Siblings of campers who previously received a $1,000 grant are eligible to receive $500 when they attend camp for the first time for at least 19 consecutive days.</li>
                        <li>Attending one of the 155+ non-profit, Jewish, overnight camps listed on the Foundation for Jewish Camp’s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).</li>
                    </ul>
				</p>                
				<p>
                    This program is an outreach initiative for families who might otherwise choose to send their children to a non-Jewish overnight camp. As such, children who attend Orthodox Jewish day school are generally not eligible for this incentive program, although exceptions do exist.
				</p>
                <p>
                    <span style="font-weight: bold; color:red;">Students at Orthodox Day Schools </span>
                    who are ineligible for a One Happy Camper grant may still be eligible for Camp Coupons. Please email JewishCamp@juf.org, or contact Rachel White at 312-357-4995 for more information.
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
