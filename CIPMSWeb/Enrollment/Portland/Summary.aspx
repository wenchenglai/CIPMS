<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Admah_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
			<td>
				<img src="logo.png" width="380" alt=""  />
			</td>
			<td>
                <p>Good news! You may be eligible for a One Happy Camper grant.</p>
                <p>
                    To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
                </p>
			</td>
		</tr>
		<tr>
			<td colspan="2">
                <p>
                    The Portland One Happy Camper program provides grants to encourage children to attend overnight Jewish camp for the first-time. 
                    It is not a scholarship fund and is not needs-based. Our goal is to engage families who are considering sending their children to camp and, 
                    in effect, to give them up to $1,000 off their camp tuition to try a Jewish one.
                </p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 1-12 (after camp).</li>
                        <li>Attending one of the 155+ non-profit, Jewish, overnight camps listed on the Foundation for Jewish Camp�s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).</li>
                    </ul>
				</p> 
                <p>
                    <span style="color:red;">Attention Jewish Day School families:</span> 
                    Currently there is a wait list for camp incentive grants for Jewish Day School campers. Please send an email to Rachel Halupowski (rachel@jewishportland.org) indicating your interest and you will be added to the list. Funding decisions will be made in late May of 2017. Federation will do its best to provide a grant.
                </p>  
                <p>
                    If you do not think that you are eligible for this program, but are interested in learning about camp scholarship opportunities, please visit 
                    <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a>, or contact your camp directly.                                 
                </p>
                <p>
                    If you need additional assistance with registration, please call Rachel Halupowski at 503-892-7413. 
                    For eligibility requirement questions, please call Bob Horenstein, Federation Director of Community Relations and Allocations, at 503-245-6496.
                </p>   
			</td>
		</tr>
	</table>

	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="logo.png" width="380" alt=""  />
			</td>
</tr>
<tr>
			<td>
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						The Jewish Federation of Greater Portland One Happy Camper program is closed for summer 2017.

For more information please contact Rachel Halupowski at rachel@jewishportland.org.

					</p>
<p>
Please click the "next" button to see if other grants are available.
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

