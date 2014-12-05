<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Calgary_Summary" %>

<asp:Content ID="Pittsburgh_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
			<td>
				<img id="Img1" src="logo.jpg" alt=""/>
				<a href="http://www.federationcja.org/jewishcamp" target="_blank"></a>
			</td>
			<td>
				<p><strong>Good news! You may be eligible for a One Happy Camper grant.</strong></p>    
				<p>
					To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below. One Happy Camper grants now open to Montreal children attending both Jewish and non-Jewish day schools!
				</p>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<p>
                    Federation CJA's Generations Fund Camp Initiative, One Happy Camper program, funded by the Schwartz and Segel families and the Foundation for Jewish Camp, is offering a one-time grant of up to $1,000 to eligible Montreal children.
				</p>
				<p>
					The following outlines the eligibility criteria for this program:
					<ul style="font-weight: bold">
						<li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
						<li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
						<li>First time camper must be entering grades 1-12 (after camp).</li>
						<li>If camper attended camp in the summer of 2014 for 12-18 days as a first time camper s/he is still eligible for the grant if attending camp in 2015 for 19 or more consecutive days.</li>
						<li>Attending one of our eligible Montreal area non-profit Jewish overnight camps.</li>
                        <li>Before your child can qualify for a grant, s/he must first be enrolled at one of our eligible camps.</li>
                        <li>One Happy Camper for Jewish day school students is currently open only to campers registered at the following camps: Camp B’nai Brith Montreal, Harry Bronfman Y Country Camp, Camp Kinneret-Biluim, and Camp Massad.</li>
                        <li>This is not a scholarship program. Grants are not based on financial need.</li>
					</ul>
				</p>  
			</td>
		</tr> 
	</table>
	<asp:Panel ID="Panel1" runat="server">
		<table width="100%" cellpadding="1" cellspacing="0" border="0">            
			<tr>
				<td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
				<td valign="top" colspan="2"><br />
					<table width="100%" cellspacing="0" cellpadding="0" border="0">
						<tr>
							<td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
							<td>
								<asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
							<td align="center">
							<asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
								</td>
							<td align="right">
								<asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn"  OnClick="btnNext_Click" /></td>                            
						</tr>
					 </table>
				</td>
			</tr>
		</table>        
	</asp:Panel>
</asp:Content>