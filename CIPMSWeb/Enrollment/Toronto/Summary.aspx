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
                    UJA’s Silber Family Centre for Jewish Camping promotes the importance of Jewish Camping as a key ingredient in building strong Jewish identities amongst our community’s youth. Through our partnership with the Foundation for Jewish Camp and over a dozen local camps, the One Happy Camper program helps families choose to enroll their children in Jewish overnight camps. 
                </p>
				<p>
				    In order to be eligible for a Toronto One Happy Camper Grant, a camper must
                    <ul style="font-weight: bold">
                        <li>Currently residing in the Greater Toronto Area (GTA);</li>
                        <li>Be entering grades 1-12 in September after camp;</li>
                        <li>Attend one of the OHC Toronto partner camps for a session of at least 18 consecutive days.</li>
                    </ul>
				</p> 
				<p>
				    One Happy Camper offers a grant of:
                    <ul style="font-weight: bold">
                        <li>$1,000 for the first child in a family to attend Jewish overnight camp (for 18+ days);</li>
                        <li>$500 for siblings of campers who received a $1,000 grant.</li>
                    </ul>
				</p> 
                <p>
                    Campers enrolled in a 'Taste of Camp' session (fewer than 19 days, with the option to extend to an eligible session) can have a grant reserved by completing this application before beginning the ‘Taste of’ session.
                </p>
                <p>
                    Grants will be awarded on a first-come, first-serve basis. If you have questions about the One Happy Camper program please contact your camp who would be happy to answer questions. 
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

