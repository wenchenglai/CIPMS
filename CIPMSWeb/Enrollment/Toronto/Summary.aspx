<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Admah_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" class="infotext3" style="text-align:justify">
		<tr>
			<td>
				<img src="Toronto OHC Logo.jpg" height="81" width="371" /> 
				<img src="logo2.jpg" height="144" width="240" />                             
			</td>
		</tr>
        <tr>
            <td>
                <p>
                    Good news! You may be eligible for an incentive grant of up to $1,000.
                </p>
                <p>
                    Thank you for choosing Jewish overnight camp and helping us to be One Happy Camper closer to achieving our goal. UJA’s Silber Family Centre for Jewish Camping is committed to promoting the importance of Jewish Camping in our community. Through our partnership with Foundation for Jewish Camp, OHC Toronto is an outreach initiative for families who might otherwise choose to send their campers to a non-Jewish/private overnight camp. 
                </p>
                <p>
                    Along with our partner camps, UJA Federation of Greater Toronto is proud to offer the One Happy Camper incentive grant to all campers who meet the following criteria. 
                </p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>Currently residing in the Greater Toronto Area (GTA).</li>
                        <li>First time camper must be entering grades 1-12 (after camp).</li>
                        <li>Enrolled with one of the OHC Toronto partner camps.</li>
                        <li>$1,000 incentive grants awarded to first-time campers attending camp for at least 19+ consecutive days.</li>
                        <li>Siblings of campers who (previously) received a $1,000 grant are eligible to receive a $500 incentive grant when they attend camp for the first time for at least 19+ consecutive days.</li>
                    </ul>
				</p> 
                <p>
                    Campers enrolled in a 'Taste of Camp' session (less than 19 days, with the option to extend to an eligible session) can have a grant reserved by proceeding with this application. 

                </p>
                <p>
                    Grants will be awarded on a first-come, first-serve basis. If you are not eligible for this program and/or you have questions about the One Happy Camper Toronto program, please contact your camp and/or Ricci Postan at UJA's Silber Family Centre for Jewish Camping at OHCToronto@ujafed.org.
                </p>  
                <p>
                    If you have determined that your camper is eligible, based on the criteria above, proceed by clicking on the "Next" button. 
                </p>            
            </td>
        </tr>            
	</table>

	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="../../images/SanFrancisco.jpg" width="280" alt=""  />
			</td>
			<td>
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						The program is now closed.	Please click “Next?to see if you are eligible for a different One Happy Camper program
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

