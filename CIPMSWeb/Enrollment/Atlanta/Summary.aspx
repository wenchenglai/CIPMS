<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Admah_Summary" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
			<td>
				<img src="logo.jpg" width="380" alt=""  />
			</td>
			<td>
                <p>
					Great news! You may be eligible for an incentive grant!
				</p>
 
			</td>
		</tr>
        <tr>
            <td colspan="2">
                <p>
                    The Foundation for Jewish Camp, in partnership with Jewish Federation of Greater Atlanta, offers funding to children in our community who wish to attend Jewish overnight camp for the first time.
				</p> 
                <p>
                    Our goal is to engage families who are considering sending their children to camp and, in effect, to give them up to $1,000 off their camp fee to try a Jewish one. Please note that first year grants are needs-blind while second year grants are needs based.
                </p>
                <p>
                    To determine if you are eligible for a One Happy Camper grant please read below. If you believe that your camper meets the criteria please proceed with the application by clicking the "next" button below.
                </p>
		        <p>
			        The following outlines the eligibility criteria for this One Happy Camper program:
                </p>

                <ul style="font-weight: bold; list-style-type: disc">
                    <li>$1,000 grants awarded to first-time campers attending a Jewish overnight camp for 19 or more consecutive days.</li>
                    <li>$700 grants awarded to first-time campers attending a Jewish overnight camp for 11-18 consecutive days.<span style="color:red">(If you are attending Camp Judaea’s Taste of Session you are eligible for a $700 grant)</span></li>
                    <li>$500 grant awarded to second-time campers attending a Jewish overnight camp for 19+ consecutive days (for those that make under $160,000 a year)</li>
                    <li>$350 grant awarded to second-time campers attending a Jewish overnight camp for 11-18 consecutive days (for those that make under $160,000 a year)</li>
                    <li>Eligible campers must be entering grades 1-12 (after camp).</li>
                    <li>Attend one of the 155+ non-profit, Jewish, overnight summer camps listed on the Foundation for Jewish Camp's website (<a href="http://www.JewishCamp.org/Find-Camp" target="_blank">www.JewishCamp.org/Find-Camp</a>).</li>
                </ul>
		                  
               <p>
                    If you need additional assistance, please call your community professional listed at the bottom of this page.
                </p>
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
                        The Atlanta One Happy Camper program is has a limited number of grants for summer  2016. For more information please contact Samantha Tanenbaum at stanenbaum@jewishatlanta.org
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

