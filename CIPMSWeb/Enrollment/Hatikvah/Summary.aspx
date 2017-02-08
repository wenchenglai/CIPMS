<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Habonim_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img id="imgLogo" src="../../images/CampHatikvahLogo.jpg" alt="" runat="server" />
            </td>
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
				    The Camp Hatikvah One Happy Camper Program, sponsored by Camp Hatikvah and the Foundation for Jewish Camp provides financial incentives of up to $1,000 to first-time campers.
				</p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 2-10 (after camp).</li>
                    </ul>
				</p>   
                <p>
                    <span style="font-weight: bold; color: red;">Attention Jewish Day School families:</span> If you are currently enrolled in Jewish Day School or yeshiva, please contact the Camp Hatikvah office directly to learn about incentive grant opportunities. Please do not proceed with this application.
                </p> 
                <p>
                    Camp Hatikvah is located in sunny Oyama, B.C. on beautiful Lake Kalamalka. Camp Hatikvah is the largest Jewish camp in Western Canada, is affiliated with the Young Judaea Youth Movement, and consistently operates at full capacity each summer. It not only attracts campers from the Vancouver Lower Mainland and other parts of British Columbia, but also from Alberta, Ontario, Washington, California, Oregon and even as far as Mexico and Switzerland. Approximately 400 Jewish children attend Camp Hatikvah each summer. Camp Hatikvah specializes in incorporating a traditional Jewish environment while offering the best in watersport activities; swimming, waterskiing, wake boarding, canoeing, kayaking, sailing and much more!
                </p>
                <p>
                    If you need additional assistance, please call the camp professional listed at the bottom of this page.
                </p>           
            </td>
        </tr>   
    </table>
	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img id="img1" src="../../images/CampHatikvahLogo.jpg" alt="" runat="server" />
            </td>
			<td>
				<asp:Label ID="Label7" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						The  Camp Hatikvah One Happy Camper program is now closed for 2016. For more information, please contact Liza Rozen-Delman at liza@camphatikvah.com.
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
