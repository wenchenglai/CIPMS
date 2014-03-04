<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Admah_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="../../images/Colorado Logo.jpg" alt=""  />
			</td>
			<td>
				<asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
					<p style="text-align:justify" class="lblPopup1">Good news! You may be eligible for an incentive.</p>
				</asp:Label>
				<asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
					</p>
				</asp:Label>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
			 The Jewish Community Foundation’s (JCF) One Happy Camper Program, a partnership with the Foundation for Jewish Camp provides Jewish children the opportunity to 
			 experience the incredible gift of Jewish overnight summer camp for the first time. Subsidies of $1,000 per child (minimum 19 days) 
			 or $700 (minimum 12 days) will be provided to Jewish children currently in grades 1 through 12 grade who are residents of Colorado, 
			 who have not previously attended an overnight Jewish summer camp (for at least 12 days), and who do not currently attend a Jewish Day School. 
			 Eligible participants may choose from one of the 150+ non-profit, Jewish, overnight summer camp listed on the Foundation for Jewish Camp’s website 
			 (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).
					</p>
				</asp:Label>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						In Colorado, JCC Ranch Camp, Ramah of the Rockies, and Shwayder Camp provide needs-based scholarship and we encourage you to speak directly with the camps 
						if you are in need of greater financial assistance. Outside of Colorado, 
						please visit <a href="http://www.JewishCamp.org/Scholarships " target="_blank">www.JewishCamp.org/Scholarships</a> to 
						learn more about other financial aid opportunities. 
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
	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="../../images/Colorado Logo.jpg" alt=""  />
			</td>
			<td>
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						For further information on how to apply for the Colorado One Happy Camper program, please contact the professional listed at the bottom of the screen.
						<br /><br />
						
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
								<asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" />
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

