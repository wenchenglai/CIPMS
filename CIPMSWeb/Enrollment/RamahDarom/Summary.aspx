<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
	Inherits="Enrollment_JCC_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
			<td>
			    <img id="logo" src="../../images/Ramah_Logo.jpg" alt="" height="65" width="250" />	
            </td>
			<td>
				<p>

				</p>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<p>
                    At this time, Camp Ramah Darom is not providing One Happy Camper incentive grants for summer 2017. First-time camper families needing financial assistance may contact Holly Barlow, (Hfortson@ramahdarom.org), to explore applying for financial aid from Ramah Darom.
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
									CssClass="submitbtn" OnClick="btnNext_Click" Visible="false" /></td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</asp:Panel>
</asp:Content>
