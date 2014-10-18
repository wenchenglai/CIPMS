<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_JCC_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="../../images/CampCharles.JPG" />
			</td>
			<td>
				<asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
					<p style="text-align:justify" class="infotext3">
						<b>The Foundation for Jewish Camp, in partnership with Camp Daisy and Harry Stein, offers an incentive program that is open to campers who live anywhere in North America!</b>
					</p>
				</asp:Label>
				<asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						<b>To determine if you are eligible for this grant, please read the paragraph below.</b>
						If you believe that your camper meets the eligibility criteria, please proceed with the application process by pressing the “next” button below.
					</p>
				</asp:Label>
			</td> 
		</tr>
		<tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<b>Camp Daisy and Harry Stein</b> is a unique and exciting place. Nestled in the majestic Bradshaw Mountains of Prescott, Arizona, campers have the opportunity to discover more about themselves, their abilities, and their Judaism. At Camp Stein, we strive to create a community from which young people derive a greater sense of self-esteem and an enhanced pride in their Jewish identity. Our camp is more than a community, it’s a family.
					</p>
					<p style="text-align:justify">
						At Camp Stein, campers are immersed in a Jewish environment with peers. Here, seeds are planted and roots strengthened for lifelong Jewish learning. The moment their camp experiences begin, campers and staff know that they are forever a part of something bigger. Under the direction of Congregation Beth Israel’s Rabbis Stephen Kahn and Rony Keller, as well as Cantor Jaime Shpall, and with input from clergy throughout the region, we work all year to develop cutting-edge curricula, focused on active participation. We aim to provide everyone at Camp Stein with memorable moments and a true sense of connection to Judaism. Through our Judaic programming the four walls of the classroom disappear and are replaced with creative, hands-on learning that is never average and always fun! Every Shabbat, our majestic outdoor chapel provides the ideal backdrop for spiritual exploration unique to the Camp Stein experience. Connect, learn, grow and be a part of something bigger.
					</p>
				</asp:Label>
			</td>
		</tr>        
		<tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<b>The Camp Daisy and Harry Stein One Happy Camper program provides financial incentives of up to $1,000 toward camp tuition for first-time campers. Eligible campers must be entering grades 2-8. </b>
					</p>
				</asp:Label>
			</td>
		</tr> 
		<tr>
			<td colspan="2">
				<asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
					<p style="text-align:justify">
						If you are interested in learning more about our camp and available grants, please visit us at: 
						<a href="http://www.CampStein.com" target="_blank">www.CampStein.com</a>.
					</p>
				</asp:Label>
			</td>
		</tr>
	</table>
	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="../../images/CampCharles.JPG" />
			</td>
			<td>
				<asp:Label ID="Label3" CssClass="SummaryHeading" runat="server">
					<p style="text-align:justify" class="infotext3">
						Thank you for your interest in the Camp Daisy and Harry Stein’s One Happy Camper Program. For more information on how to apply, please visit <a href="http://campstein.org/about-camp/for-first-timers" target="_blank">campstein.org/about-camp/for-first-timers</a> or contact Brian Mitchell at campdirector@cbiaz.org or (480) 951-0323.
					</p>
				</asp:Label>
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 

					</p>
				</asp:Label>
			</td> 
		</tr>
	</table>
	<asp:Panel ID="Panel1" runat="server">
		<table width="100%" cellpadding="1" cellspacing="0" border="0">            
			<tr>
				<td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
				<td valign="top" ><br />
					<table width="100%" cellspacing="0" cellpadding="0" border="0">
						<tr>
							<td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
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

