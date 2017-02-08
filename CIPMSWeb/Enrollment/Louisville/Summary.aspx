<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Columbus_Summary" %>

<asp:Content ID="Columbus_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img id="logo" src="../../images/Louisville.jpg" />
            </td>
            <td>
                <p>Good news! You may be eligible for a One Happy Camper grant.</p>    
                <p>
				    To determine if you are eligible continue reading and if your camper meets the eligibility criteria, 
					please proceed by clicking the "next" button below.
			    </p>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<p>
                    The Louisville One Happy Camper program, sponsored by the Jewish Community of Louisville and the Foundation for Jewish Camp, provides 
                    <span style="text-decoration: underline">limited</span> grants to encourage 
                    children to attend overnight Jewish camp for the first time. It is not a scholarship fund and is not needs-based.  Our goal is to engage families 
                    who are considering sending their children to camp and, in effect, to give them up to $1,000 off their camp fee to try a Jewish one. 
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
                    This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. 
                    As such, children who attend Jewish Day School or yeshiva are not eligible for this incentive program.                
                </p>
                <p>
                    If your child is not eligible and/or are interested in learning about financial-needs based grants or other camper funding opportunities 
                    please visit <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a>, 
                    contact your camp, or the contact person listed at the bottom of this page.                     
                </p>
                <p>
                    If you need additional assistance, please contact Betsy J. Schwartz at 502-238-2708 or BSchwartz@jewishlouisville.org.
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
