<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Admah_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="logo.jpg" width="380" alt=""  />
			</td>
			<td>
				<asp:Label ID="lblHeading" CssClass="infotext3" runat="server" ForeColor="Black">
					<p style="text-align:justify">
                        Great News! The Foundation for Jewish Camp, in partnership with the Jewish Federation of Nashville and Middle Tennessee, 
                        offers funding to children in our community who wish to attend Jewish overnight camp for the first time.
					</p>
				</asp:Label>
				<asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
                        To determine if you are eligible for a One Happy Camper grant please read the paragraph below. 
                        If you believe that your camper meets the criteria please proceed with the application by clicking the next button below.
					</p>
				</asp:Label>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify; font-weight:bold;">
					<b>
                        The Jewish Federation of Nashville and Middle Tennessee One Happy Camper Program provides 
                        grants to encourage children to attend overnight Jewish camp for the first-time. It is not 
                        a scholarship fund and is not needs-based. Our goal is to engage families who are considering 
                        sending their children to camp, and in effect, giving them $1,000 off their camp fee to try a Jewish one.
					</b>
					</p>
				</asp:Label>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
                        Middle Tennessee One Happy Camper grants are awarded to first-time campers who attend a nonprofit Jewish overnight 
                        summer camp for at least 19 consecutive days. Eligible campers must be entering 1-12 grades (after camp) 
                        and be attending one of the 150+ nonprofit, Jewish, overnight summer camps listed on the Foundation for 
                        Jewish Camp�s website (<a href="http://www.JewishCamp.org/Find-Camp" target="_blank">www.JewishCamp.org/Find-Camp</a>) .   
					</p>
				</asp:Label>
			</td>
		</tr> 
		<tr>
			<td colspan="2">
				<asp:Label ID="Label3" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<b>Note:</b> This program is an outreach initiative for children who are not currently receiving an immersive, 
                        daily Jewish experience. As such, children who attend Jewish day school or Yeshiva are not eligible for the program. 
                        If your child is not eligible and/or you are interested in learning about financial-needs based grants or other 
                        needs based funding options please visit <a href="http://www.jewishcamp.org/scholarships" target="_blank">www.jewishcamp.org/scholarships</a> contact your camp, and contact 
                        Kristi Pearson, Jewish Federation of Nashville and Middle Tennessee, Controller, <a href="mailto:Michelle@jewishnashville.org">Michelle@jewishnashville.org</a>.
					</p>
				</asp:Label>
			</td>
		</tr>
	</table>

	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="logo.jpg" width="380" alt=""  />
			</td>
			<td>
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						The program is now closed.	Please click �Next� to see if you are eligible for a different One Happy Camper program
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
