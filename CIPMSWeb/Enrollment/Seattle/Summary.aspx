<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Admah_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="../../images/Seattle.gif" width="280" alt=""  />
			</td>
			<td>
				<asp:Label ID="lblHeading" CssClass="infotext3" runat="server" ForeColor="Black">
					<p style="text-align:justify">
						The Jewish Federation of Greater Seattle (JFGS) in partnership with the Foundation for Jewish Camp is now offering the One Happy Camper first-time 
						camper incentive program for all Washington State residents. This program will offer substantial funding to campers in our community looking to 
						attend Jewish overnight camp for the first time. This is not a scholarship, but a grant program to encourage families to consider Jewish 
						overnight camp offering a $700 reduction in the camp fee for a 12-18 day session and a $1,000 reduction in the camp fee for a 19+ day session.
					</p>
				</asp:Label>
				<asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						Through this grant and other community initiatives and programs, the Federation hopes to increase by 25%, over three years, 
						the number of children from Washington State attending Jewish summer camps, with a preference for Washington State camps.
					</p>
				</asp:Label>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify; font-weight:bold;">
						JFGS One Happy Camper grants are awarded to first-time campers who attend a nonprofit Jewish overnight summer camp for at least 12 consecutive days. 
						Grants will be in the amount of $700 for a 12-18 consecutive day session and $1,000 for 19+ consecutive day session. Eligible campers must be entering grades 2-10 (after camp) 
						and be attending one of the 150+ nonprofit, Jewish overnight summer camps listed on the Foundation for 
						Jewish Camp’s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>). Length of sessions must be at least 12 days for camps in the west and 19 days for all 
						other camp programs.
					</p>
				</asp:Label>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						At this time, campers who currently attend Jewish day school or Yeshiva are not eligible for the OHC program. The program is an outreach initiative for 
						children who are not currently receiving and immersive, daily Jewish experience. 
					</p>
				</asp:Label>
			</td>
		</tr> 
		<tr>
			<td colspan="2">
				<asp:Label ID="Label3" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						JFGS continues to offer its Jewish overnight camp needs-based scholarship program. Information about this program can be found at 
						<a href="http://www.jewishinseattle.org/campscholarships" target="_blank">www.jewishinseattle.org/campscholarships</a>. If you have any questions or need any additional assistance, 
						please contact Annie Jacobson at <a href="mailto:AnnieJ@jewishinseattle.org">AnnieJ@jewishinseattle.org</a> or call 206-774-2243.
					</p>
				</asp:Label>
			</td>
		</tr>
	</table>

	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="../../images/Seattle.gif" width="280" alt=""  />
			</td>
			<td>
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
The program is now closed.	Please click “Next” to see if you are eligible for a different One Happy Camper program
					</p>
				</asp:Label>
			</td>
		</tr>
	</table>
    
	<asp:Panel ID="Panel1" runat="server">
		<table width="100%" cellpadding="1" cellspacing="0" border="0">            
			<tr>
				<td valign="top" style="width:5%">
					<asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label>
				</td>
				<td valign="top" ><br />
					<table width="100%" cellspacing="0" cellpadding="0" border="0">
						<tr>
							<td  align="left">
								<asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" />
							</td>
							<td>
								<asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" />
							</td>
							<td align="center">
								<asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
							</td>
							<td align="right">
								<asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" />
							</td>                            
						</tr>
					</table>
				</td>
			</tr>
		</table>        
	</asp:Panel>
</asp:Content>

