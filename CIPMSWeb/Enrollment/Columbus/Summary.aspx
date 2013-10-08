<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Columbus_Summary" %>

<asp:Content ID="Columbus_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="logo" src="../../images/Columbus.jpg" /></td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="lblPopup1">
						Good news! You may be eligible for an incentive.
					</p>
				</asp:Label>
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, 
						please proceed by clicking the "next" button below.
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<b>The Columbus One Happy Camper Program, sponsored by the Jewish Federation of Columbus, 
						the Columbus Jewish Foundation and the Foundation for Jewish Camp, provides financial incentives of $1,000 to first-time campers who attend 
						a nonprofit Jewish overnight summer camp for at least 19 consecutive days. Eligible campers must be entering grades 3-10 (after camp) 
						and attending a camp listed on the Foundation for Jewish Camp’s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).
						</b>
					</p>                
					<p style="text-align:justify">
						This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. 
						As such, children who attend Jewish day school or Yeshiva are not eligible for this incentive program. 
						If you do not think that you are eligible for this program, but are interested in learning about camp scholarship opportunities, 
						please visit:<a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a> 
						or contact your camp or the Columbus Jewish Federation directly.
					</p>            
				</asp:Label>
			</td>
        </tr>        
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">
						If you need additional assistance, please call your community professional listed at the bottom of this page.
					</p>
                </asp:Label>
            </td>
        </tr>
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="Img1" src="../../images/Columbus.jpg" /></td>
            <td>
                <asp:Label ID="Label3" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
						The Jewish Federation of Columbus One Happy Camper program is now closed for the summer of 2013.  For more information, please contact the professional listed at the bottom of the screen.
						<br /><br />
						Click ‘NEXT’ to see if your camp is sponsoring its own One Happy Camper program.
					</p>
				</asp:Label>
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
