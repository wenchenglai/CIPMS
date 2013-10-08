<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Admah_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="../../images/El Paso.jpg" width="280" alt=""  />
			</td>
			<td>
				<asp:Label ID="lblHeading" CssClass="infotext3" runat="server" ForeColor="Black">
					<p style="text-align:justify">
						Great news!  The Foundation for Jewish Camp, in partnership with Jewish Federation of El Paso, offers funding to children in our 
						community who wish to attended Jewish overnight camp for the first-time.
					</p>
				</asp:Label>
				<asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						To determine if you are eligible for a One Happy Camper grant please read the paragraph below. If you believe that your camper meets 
						the criteria please proceed with the application by clicking the next button below. 
					</p>
				</asp:Label>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify;">
						The El Paso One Happy Camper Program provides grants to encourage children to attend overnight Jewish camp for the first-time.  
						It is not a scholarship fund and is not needs-based.  Our goal is to engage families who are considering sending their children 
						to camp and, in effect, to give them $700-$1,000 off their camp fee to try a Jewish one.
					</p>
				</asp:Label>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						El Paso One Happy Camper grants are awarded to first-time campers who attend a nonprofit Jewish overnight summer camp for at least 
						19 consecutive day until available funding is exhausted.. For some camps the minimum  attendance  is 12 days.   Eligible campers 
						must be entering grades 1-12 (after camp) and be attending one of the 150+ non-profit, Jewish, overnight summer camp listed on the 
						Foundation for Jewish Camp’s website (<a href="http://www.jewishcamp.org" target="_blank">www.jewishcamp.org</a>). 
					</p>
				</asp:Label>
			</td>
		</tr> 
		<tr>
			<td colspan="2">
				<asp:Label ID="Label3" CssClass="infotext3" runat="server">
					<p style="text-align:justify; color:Red;">
						<b>Note:</b> The mission of the OHC program is exclusively an outreach initiative for children who are not currently receiving an immersive, 
						daily Jewish experience. As such, children who attend Jewish day school not eligible for the OHC matching program, but they are 
						eligible for funds made directly available by the El Paso Jewish Federation.  Campers in this category should not apply through 
						the FJC website, but rather contact the El Paso Jewish Federation directly. 
						<span style="color:Black">For questions please contact the professional listed at the bottom of this page.</span>
					</p>
				</asp:Label>
			</td>
		</tr> 		
		<tr>
			<td colspan="2">
				<asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
					<p style="text-align:justify">
						For additional assistance, please contact your community professional:  Megan Kennedy, Manager of JCF Scholarship Programs, megank@sfjcf.org.
					</p>
				</asp:Label>
			</td>
		</tr>
	</table>

	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="../../images/El Paso.jpg" width="280" alt=""  />
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

