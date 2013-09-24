<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_MetroWest_Summary" %>

<asp:Content ID="MetroWest_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td style="width: 200px">
                <img id="Img2" alt="MetroWest" src="../../images/MetroWest.jpg" />                                             
            </td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify">Good news! You may be eligible for an incentive.</p>
                </asp:Label>
                <asp:Label ID="Label2" CssClass="infotext3" runat="server">
                    <p style="text-align:justify">
						To determine if you are eligible, continue reading and if your camper meets the eligibility criteria, 
						please proceed by clicking the "next" button below.
					</p>
                </asp:Label>
            </td>
        </tr>
        <tr>          
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">              
					<p style="text-align:justify"> 
						<b>The Greater MetroWest One Happy Camper Grant Program, sponsored by the Jewish Federation of Greater MetroWest NJ and the Foundation for Jewish Camp, 
                            offers incentive grants of $1,000 to first-time campers. 
						The child must be enrolled for a minimum of 19 consecutive days at one of the 150+ non-profit, Jewish camps listed on the Foundation for Jewish Camp’s 
						website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>)</b>.
					</p> 
					<p style="text-align:justify">
						<b>Note: This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. 
						As such, children who attend a Jewish day school are not eligible for the program.</b> If your child is currently a Jewish Day School student, 
						please contact the community professional listed at the bottom of the page for information about potential grant opportunities that may be available.
					</p>
					<p style="text-align:justify">
						If you are interested in learning about additional financial resources for camp, 
						please visit <a href="http://www.JewishCamp.org/Scholarships" target= "_blank">www.JewishCamp.org/Scholarships</a> for 
						needs-based scholarship opportunities or contact your camp or synagogue directly.
					</p>
				</asp:Label>
			</td>
        </tr>        
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">
						If you need additional assistance, including free guidance on finding a camp, please call your community professional listed at the bottom of this page.
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
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                            <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                                </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" /></td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>
</asp:Content>
