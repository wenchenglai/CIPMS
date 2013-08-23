<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Chi_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img src="../../images/JRF.jpg" height="150px" width="150px" />
            </td>
            <td>
				<asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify" class="infotext3">
						Good news!  The Foundation for Jewish Camp, in partnership with Camp JRF, offers an incentive program that is 
						open to campers who live anywhere in North America!                    
                    </p>
				</asp:Label>
                <asp:Label ID="Label4" CssClass="infotext3" runat="server">
                     <p style="text-align:justify"> 
						
                     </p>     
                </asp:Label>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Camp JRF fills the summer with fun, friendships, and Jewish living. Our summer camp is a joyful, creative, and inclusive 
						Reconstructionist community. Campers swim, play soccer, basketball, baseball, volleyball, and other sports. They sing and explore 
						other arts. They learn from visiting artists, scholars, and rabbis, as well from talented specialists and dedicated college-age 
						counselors. Our campers make lasting friendships, experience a safe and fun summer, explore Jewish tradition, forge their own 
						Jewish identity, and participate in creating a Jewish culture in which our values are lived each day.						
					</p>
				</asp:Label>
			</td>
        </tr> 
        <tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify"><b>
						The Camp JRF One Happy Camper program provides financial incentives of $1,000 to first-time campers who attend our camp for at least 
						19 consecutive days.  Eligible campers must be entering grades 4-12 (after camp). </b>						
					</p>
				</asp:Label>
			</td>
        </tr>    
        <tr>
			<td colspan="2">
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<strong>Note:</strong> This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. 
						As such, children who attend a Jewish day school are not eligible for program. Please contact the camp office directly to learn 
						more about opportunities for your child. 						
					</p>
				</asp:Label>
			</td>
        </tr>                
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">
						If you are interested in learning more about our camp, please visit us at: <a href="http://www.campjrf.org" target="_blank">www.campjrf.org</a>.
					</p>
                </asp:Label>
            </td>
		</tr>
    </table>
	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0" visible="false">
		<tr>
			<td>
                <img src="../../images/camp_shomria.png" height="150px" width="150px" />
            </td>
            <td>
                <asp:Label ID="Label3" CssClass="infotext3" runat="server">
                     <p style="text-align:justify"> 
						<b>Please contact Shaked Angel at 212-627-2830 ext. 1 or <a href="mailto:Info@CampShomria.org">Info@CampShomria.org</a> for more information.</b>
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
                            <td  align="left">
								<asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" />
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

