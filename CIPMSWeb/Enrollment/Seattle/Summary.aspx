<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Admah_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
			<td>
				<img src="logo.jpg" width="280" alt=""  />
			</td>
			<td>
                <p>Good news! You may be eligible for a One Happy Camper grant.</p>
			</td>
		</tr>
		<tr>
			<td colspan="2">
                <p>
                    The Jewish Federation of Greater Seattle (JFGS) in partnership with the Foundation for Jewish Camp is now offering the One Happy Camper first-time camper incentive program for all Washington State residents. This program will offer substantial funding to campers in our community looking to attend Jewish overnight camp for the first time. This is not a scholarship, but a grant program to encourage families to consider Jewish overnight camp.
                </p>
                <p>
                    Through this grant and other community initiatives and programs, the Federation hopes to increase by 25%, over three years, the number of children from Washington State attending Jewish summer camps, with a preference for Washington State camps.
                </p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 2-10 (after camp).</li>
                        <li>Attending one of the 155+ non-profit, Jewish, overnight camps listed on the Foundation for Jewish Camp’s website  
                            (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).</li>
                    </ul>
				</p> 
                <p>
                    This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. As such, children who attend Jewish Day School or yeshiva are not eligible for this incentive program.
                </p>
                <p>
                    JFGS continues to offer its Jewish overnight camp needs-based scholarship program. Information about this program can be 
                    found at <a href="http://www.jewishinseattle.org/campscholarships" target="_blank">www.jewishinseattle.org/campscholarships</a>. 
                    If you have any questions or need any additional assistance, please contact our camping staff at Camp@JewishInSeattle.org or call 206-443-5400.
                </p>
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
The Seattle One Happy Camper program is now closed for summer 2016. For more information, please contact taryno@jewishinseattle.org.  To see if your camp sponsors the One Happy Camper program please click the “next” button at the bottom of the screen.
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

