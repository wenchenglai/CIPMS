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
                <p>
                    The Foundation for Jewish Camp, in partnership with Jewish Federation of Greater Atlanta, offers funding to children in our community who wish to attend Jewish overnight camp for the first time.
				</p>  
			</td>
		</tr>
        <tr>
            <td colspan="2">
                <p>
                    It is not a scholarship fund and is not needs-based. Our goal is to engage families who are considering sending their children to camp and, in effect, to give them up to $1,000 off their camp fee to try a Jewish one.
                </p>
                <p>
                    To determine if you are eligible for a One Happy Camper grant please read below. If you believe that your camper meets the criteria please proceed with the application by clicking the "next" button below.
                </p>
		        <p>
			        The following outlines the eligibility criteria for this One Happy Camper program:
                    <ul style="font-weight: bold; list-style-type: disc">
                        <li>$1,000 grants awarded to first-time campers attending a Jewish overnight camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending a Jewish overnight camp for 12-18 consecutive days.</li>
                        <li>Eligible campers must be entering grades 1-12 (after camp).</li>
                        <li>Attend one of the 155+ non-profit, Jewish, overnight summer camps listed on the Foundation for Jewish Camp�s website (<a href="http://www.JewishCamp.org/Find-Camp" target="_blank">www.JewishCamp.org/Find-Camp</a>).</li>
                    </ul>
		        </p>
                <p>
                    <strong>
                        Second year grants are available!  If a camper attended a Jewish overnight camp in summer 2015 and s/he received a grant from the Jewish Federation of Greater Atlanta, and will be attending a Jewish overnight camp for at least 12 consecutive days in summer 2016, they may be eligible for a second year grant.  Grants are valued at $350 for 12-18 days or $500 for 19 or more days.  Eligibility is dependent on combined house hold income of less than $160,000. 
                    </strong>
                </p>             
		        <p>
		            Note: This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. 
                    As such, children who attend Jewish day school or Yeshiva are not eligible for the program. 
                    If your child is not eligible and/or are interested in learning about financial-needs based grants or other camper funding opportunities 
                    please visit <a href="http://www.JewishCamp.org/Scholarships" target= "_blank">www.jewishcamp.org/scholarships</a>, 
                    contact your camp, or the contact person listed at the bottom of this page.
		        </p>
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
						For further information on how to apply for the Jewish Federation of Greater Atlanta One Happy Camper program, please contact Samantha Tanenbaum, stanenbaum@jewishatlanta.org.
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

