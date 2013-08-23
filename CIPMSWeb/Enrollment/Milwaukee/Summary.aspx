<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Admah_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="../../images/milwaukee.jpg" width="280" alt=""  />
			</td>
			<td>
				<asp:Label ID="lblHeading" CssClass="infotext3" runat="server" ForeColor="Black">
					<p style="text-align:justify">
						Great news!  You may be eligible for an incentive grant for Jewish camp.  To determine if you are eligible for a Milwaukee One Happy Camper grant 
						please read the information below.   If you believe your camper meets the criteria please proceed with the application by clicking the next button. 
					</p>
				</asp:Label>
				<asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 

					</p>
				</asp:Label>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify; font-weight:bold;">
						The Milwaukee One Happy Camper Program, sponsored by the Milwaukee Jewish Federation and the Foundation for Jewish Camp, 
						offers funding to encourage children in our community to attend Jewish overnight camp for the first time.  It is not a 
						scholarship fund and is not based on need.  Our goal is to engage families who are considering sending their children to camp and, 
						in effect, to give them $1,000 off their camp fee to try a Jewish one.
					</p>
				</asp:Label>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Milwaukee One Happy Camper grants are awarded to first-time campers who attend a nonprofit Jewish overnight summer camp for at least 19 consecutive days. 
						Eligible campers must be entering grades 1-12 (after camp) and be attending one of the 150+ non-profit, Jewish, overnight summer camps listed on the 
						Foundation for Jewish Camp’s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">http://www.OneHappyCamper.org/FindaCamp</a>).
					</p>
				</asp:Label>
			</td>
		</tr> 
		<tr>
			<td colspan="2">
				<asp:Label ID="Label3" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Note: This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. 
						As such, children who attend Jewish day school or Yeshiva are not eligible for the program. If your child is not eligible and/or are interested 
						in learning about financial need-based grants or other camper funding opportunities please visit <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a> contact your camp, 
						or the contact Joshua Sofian at joshuas@milwaukeejewish.org.
					</p>
				</asp:Label>
			</td>
		</tr>
	</table>

	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="../../images/milwaukee.jpg" width="280" alt=""  />
			</td>
			<td>
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						The Milwaukee Jewish Federation is now closed for the summer of 2013.  For more information, please contact the professional listed at the bottom of the screen.
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

