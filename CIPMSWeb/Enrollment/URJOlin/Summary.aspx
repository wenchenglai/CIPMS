<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_URJ_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img src="../../images/URJ.jpg" alt=""/></td>
            <td>
                <p>Good news! You may be eligible for a One Happy Camper incentive grant!</p>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <p>
                    The Union for Reform Judaism, in partnership with the Foundation for Jewish Camp, offers incentive grants of up to $1000 through the One Happy Camper program for first-time campers who attend URJ Camp George.                      
                </p>
				<p>
				    The following outlines the eligibility criteria for this One Happy Camper program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>First-time campers must be entering grades 2-12 (after camp).</li>
                    </ul>
				</p> 
                <p>
                    This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. As such, children who attend Jewish day school or yeshiva are not eligible for this incentive program.                    
                </p>
                <p style="font-style: italic">
                    Children who have received a One Happy Camper grant in a previous year for any number of days are not eligible to receive one again.
                </p>
                <p>
                    If your child is not eligible and/or is interested in learning about financial-needs based grants or other camper funding opportunities please visit <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a>, or contact your local Jewish federation, camp or congregation.                    
                </p>
                <p>
                      The Union for Reform Judaism (URJ) is proud to operate a wide variety of camps and programs which provide a year-round, engaging Jewish environment for Pre-K to Post College students.  These programs include regional and specialty summer camps, local year-round activities for teens in grades 6-12 (NFTY), immersive summer and year-round Israel programs and social justice/volunteer experiences in Central America, Israel and beyond (Mitzvah Corps). To learn more and get involved, please visit 
                    <a href="http://www.URJYouth.org" target="_blank">www.URJYouth.org</a>.
                </p>  
            </td>
        </tr>            
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img src="../../images/URJ.jpg" alt=""/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblDisabledMessage"></asp:Label>
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
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" /></td>
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>
</asp:Content>

