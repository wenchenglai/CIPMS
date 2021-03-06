<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Philadelphia_Summary" %>

<asp:Content ID="Philadelphia_Summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img id="logo" src="../../images/Philadelphia Logo.jpg" alt="" />
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
The One Happy Camper program sponsored by the Neubauer Family Foundation, the Jewish Federation of Greater Philadelphia and the Foundation for Jewish Camp, provides financial incentives of up to $1,000 to first-time campers who attend a nonprofit Jewish overnight summer camp for at least 12 consecutive days.                 </p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 1-12 (after camp).</li>
                        <li>If camper attended camp in the summer of 2016 for 12-18 days as a first time camper s/he is still eligible for the grant if attending camp in 2017 for 19 or more consecutive days.</li>
                        <li>Live in Bucks, Chester, Delaware, Montgomery or Philadelphia counties.</li>
                        <li>Attending one of the 155+ non-profit, Jewish, overnight camps listed on the Foundation for Jewish Camp�s website  (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).</li>
                    </ul>
				</p>
                <p>
                    This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. As such, children who attend Jewish Day School are not eligible for this incentive program.
                </p>
                <p>
                    If you do not think that you are eligible for this program, but are interested in learning about camp scholarship opportunities, 
                    please visit <a href="https://www.jewishphilly.org/programs-services/jewish-camping/camp-scholarships" target="_blank">https://www.jewishphilly.org/programs-services/jewish-camping/camp-scholarships</a>.
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
                <img id="Img1" src="../../images/Philadelphia Logo.jpg" /></td>
            <td>
                <asp:Label ID="Label5" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
						The  The Jewish Federation of Greater Philadelphia One Happy Camper program is now closed for the summer of 2014. For more information, please contact the professional listed at the bottom of the screen.
                        <br /><br />
                        Click �NEXT?to see if your camp is sponsoring its own One Happy Camper program.
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
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" /></td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>


</asp:Content>
