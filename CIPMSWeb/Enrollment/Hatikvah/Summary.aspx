<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Habonim_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="imgLogo" src="../../images/CampHatikvahLogo.jpg" alt="" runat="server" />
            </td>
			<td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="lblPopup1">
						Good news! You may be eligible for an incentive.
                    </p>
                </asp:Label>
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, 
						please proceed by clicking the "next" button below.
					</p>
				</asp:Label>
            </td>
        </tr>    
        <tr>
			<td colspan="2">
				<asp:Label ID="Label1" runat="server" CssClass="infotext3">
					<p style="text-align:justify"><b>The Camp Hatikvah One Happy Camper Program, sponsored by Camp Hatikvah and the Foundation for Jewish Camp provides financial incentives of up to $1,000 to first-time campers who attend one of our nonprofit Jewish overnight summer camps for at least 12 consecutive days. Eligible campers must have completed grades 1-9. If you are currently enrolled in Jewish day school or yeshiva, please contact the Camp Hatikvah office directly to learn about incentive grant opportunities. Please do not proceed with this application.</b></p>
					<p style="text-align:justify">Camp Hatikvah is located in sunny Oyama, B.C. on beautiful Lake Kalamalka. Camp Hatikvah is the largest Jewish camp in Western Canada, is affiliated with the Young Judaea Youth Movement, and consistently operates at full capacity each summer. It not only attracts campers from the Vancouver Lower Mainland and other parts of British Columbia, but also from Alberta, Ontario, Washington, California, Oregon and even as far as Mexico and Switzerland. Approximately 400 Jewish children attend Camp Hatikvah each summer. Camp Hatikvah specializes in incorporating a traditional Jewish environment while offering the best in watersport activities; swimming, waterskiing, wake boarding, canoeing, kayaking, sailing and much more!</p>
					<p style="text-align:justify">If you need additional assistance, please call the camp professional listed at the bottom of this page.</p>
				</asp:Label>
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
						The Camp Hatikvah One Happy Camper application is not yet available for summer 2013.  
						Please contact the person listed at the bottom of this page for more information.
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
