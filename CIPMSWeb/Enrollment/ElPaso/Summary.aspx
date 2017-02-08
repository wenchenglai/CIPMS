<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Admah_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
			<td>
				<img src="logo.jpg" width="280" alt=""  />
			</td>
			<td>
                <p>
					Good news! You may be eligible for an incentive.
				</p>
                <p>
					The Foundation for Jewish Camp, in partnership with Jewish Federation Greater of El Paso, offers funding to children in our community who wish to attended Jewish overnight camp for the first-time. 
				</p>
			</td>
		</tr>
        <tr>
			<td colspan="2">
				<p>
                    To determine if you are eligible for a One Happy Camper grant please read the paragraph below. If you believe that your camper meets the criteria please proceed with the application by clicking the next button below. The El Paso One Happy Camper Program provides grants to encourage children to attend overnight Jewish camp for the first-time. It is not a scholarship fund and is not needs-based. Our goal is to engage families who are considering sending their children to camp and, in effect, to give them up to 1,000 off their camp fee to try a Jewish one. 				    
				</p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 3 - 12 (after camp).</li>
                        <li>Attending one of the 155+ non-profit, Jewish, overnight camps listed on the Foundation for Jewish Camp’s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).</li>
                    </ul>
				</p>   
                <p>
                    <span style="font-weight: bold; color: red;">Attention Jewish Day School families:</span> 
                    The mission of the OHC program is exclusively an outreach initiative for children who are 
                    not currently receiving an immersive, daily Jewish experience. As such, children who attend Jewish Day School are 
                    not eligible for the OHC matching program, but they may be eligible for funds made directly available by the Jewish Federation. 
                    Campers in this category should not apply through the FJC website, but rather contact the Jewish Federation of Greater El Paso directly.                 
                </p> 
                <p>
                    For questions please contact the professional listed at the bottom of this page.
                </p>        
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

