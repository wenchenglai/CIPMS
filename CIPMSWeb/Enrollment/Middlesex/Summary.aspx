<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Middlesex_Summary" %>

<asp:Content ID="MiddleSex_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img id="logo" src="logo.jpg" /></td>
            <td>
                <p>Good news! You may be eligible for a One Happy Camper grant.</p>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <p>
                    The One Happy Camper program, funded by The Jewish Federation in the Heart of New Jersey and the Foundation for Jewish Camp, provides grants of up to $1,000 to any first-time Jewish overnight camper residing in Monmouth or Greater Middlesex County, as defined by the Jewish Federation service area. 
                </p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 3-11 (after camp).</li>
                        <li>Attending one of the 155+ non-profit, Jewish, overnight camps listed on the Foundation for Jewish Camp�s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).</li>
                    </ul>
				</p> 
                <p>
                    This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. 
                    As such, children who attend Jewish Day School or yeshiva are not eligible for this incentive program.
                </p>
                <p>
                    Multiple campers (siblings) from a single family are eligible to receive separate grants. This grant is NOT based on financial need. 
                    The grant is available whether or not the camper or camper�s family has received other partial scholarships or other partial financial aid. 
                    Those in receipt of full scholarships from other sources are NOT eligible.
                </p>
                <p>
                    All One Happy Camper related questions should be directed to the Jewish Federation in the Heart of New Jersey.   
                    Please find contact information at the bottom of this page.
                </p>            
            </td>
        </tr>
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img id="Img1" src="logo.jpg" />
            </td>
            </tr><tr>
            <td>                  
                <asp:Label ID="Label3" runat="server" CssClass="infotext3">
                    <p>
						The Jewish Federation in the Heart of New Jersey One Happy Camper program is now closed for summer 2017. For more information or to be put on a waitlist, please contact Laura Safran at lauras@jewishheartnj.org .  To see if your camp sponsors the One Happy Camper program please click the �next� button at the bottom of the screen.
 
                    </p>
                </asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">            
            <tr>
                <td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top"><br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                                </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >>" CssClass="submitbtn" OnClick="btnNext_Click" /></td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>
</asp:Content>
