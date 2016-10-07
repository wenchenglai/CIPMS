<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_JCC_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
            <td colspan="2">
                <img src="logo.jpg" alt="" />
            </td>
        </tr>
        <tr>
			<td colspan="2">
                <p>
					Good news! You may be eligible for a One Happy Camper grant.
				</p>
                <p>
					The Foundation for Jewish Camp, in partnership with Camp Daisy and Harry Stein offers an incentive program that is open to campers who live anywhere in North America!
				</p>
		        <p>
			        The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 1-12 (after camp).</li>
                    </ul>
		        </p>                
		        <p>
		            If you are interested in learning more about our camps and other available grants, please email camp@cbiaz.org or call (480) 951-0323. 
		        </p>
                <p>
                    Camp Stein has been the premier Jewish summer camp in the Southwestern United States for over 40 magical summers.  Located in the Prescott National Forest, and owned and operated by Congregation Beth Israel in Scottsdale, AZ, campers are able to experience living Judaism, a Summer of Fun, and a Lifetime of memories.
                </p>

			</td>
        </tr>    
	</table>
	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="logo.jpg" />
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

                                    <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" />

								
							</td>                            
						</tr>
					 </table>
				</td>
			</tr>
		</table>        
	</asp:Panel>
</asp:Content>

