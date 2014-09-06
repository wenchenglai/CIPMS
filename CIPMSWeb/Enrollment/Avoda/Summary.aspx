<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Chi_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img src="../../images/Camp_Avoda_RGB_logo.jpg" /></td>
            <td>
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
                    The Camp Avoda One Happy Camper program, sponsored by Camp Avoda and the Foundation for Jewish Camp provides financial incentives.
                </p>
		        <p>
			        The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 2-12 (after camp).</li>
                        <li>If camper attended camp in the summer of 2014 for 12-18 days as a first time camper s/he is still eligible for the grant if attending camp in 2015 for 19 or more consecutive days.</li>
                    </ul>
		        </p>                
		        <p>
		            Camp Avoda aims to maintain Jewish spirituality infused in day to day living at camp throughout the summer. We have Friday night and Saturday morning services at our outdoor Chapel Site, we wear kipot to all meals, keep Shabbat programming separate from the rest of the week, and end each Saturday with Havdallah. Our goal is to provide campers with cultural reminders that fit the overall camp culture and are in line with our camp’s mission of fostering values of teamwork, leadership, self-confidence and respect for one another based on shared experiences that value our Jewish culture and traditions. Being brought up at Camp Avoda lends itself to maintaining and fostering Jewish identity as boys grow up to become men and leaders.
		        </p>
                <p>
                    We are a non-profit resident camp for Jewish boys ages 7 through 15 in Middleboro, MA. Our program includes: Sports, Swimming and Boating, Arts, Judaica, Ropes Course & Climbing Wall, Field Trips, Evening Activities, Overnight Camp-outs, Color War, Intercamp teams, Intracamp competition, and more!
                </p>
                <p>
                    If you are interested in learning more about our camp and available grants, please visit us at: 
                    <a href="http://www.campavoda.org" target="_blank">www.campavoda.org</a> or call Ken Shifman at 781-433-0131.
                </p>
                <p>
                    If you need additional assistance, please call the camp professional listed at the bottom of this page.
                </p>                
            </td>
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
                                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

