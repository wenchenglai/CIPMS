<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Chi_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img src="logo.jpg" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <p>
                    Great news!  The Jewish Federation of Madison (JFM) is thrilled to announce that we have partnered with the Foundation for Jewish Camp to bring the One Happy Camper program to Madison.  If you have a camper in grades 2nd-12th they may be eligible for a grant to attend Jewish overnight camp for the first time.
                </p>
                <p>
                    To determine if you are eligible for the One Happy Camper grant please read below.  If you believe that your camper meets the criteria please proceed with the application by clicking the next button below.
                </p>
                <p>
                    The JFM One Happy Camper Program provides grants to encourage children to attend overnight Jewish camp for the first-time.  It is not a scholarship fund and is not need-based.  Our goal is to engage families who are considering sending their children to Jewish overnight camp and, in effect, to give them up to $1,000 off their camp fees to try a Jewish one.
                </p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12 or more consecutive days</li>
                        <li>First time camper must be entering grades 2-12 (after camp).</li>
                        <li>Attending one of the 155+ non-profit, Jewish, overnight camps listed on the Foundation for Jewish Camp’s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).</li>
                    </ul>
				</p> 
                <p>
                    <strong>Note:</strong> 
                    This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. As such, children who attend Jewish day school or Yeshiva are not eligible for program. If your child is not eligible and/or are interested in learning about financial-needs based grants or other camper funding opportunities please visit 
                    <a href="http://JewishCamp.org/Scholarships" target="_blank">JewishCamp.org/Scholarships</a>, contact your camp, or the contact person listed at the bottom of this page.
                </p>  
                <p>
                    We have a limited number of OHC Grants to give to Madison area campers.  Grants are distributed on a first-come-first-serve basis.  Applicants MUST register for camp before filling out the One Happy Camper application.
                </p>
                <p>
                    If you need additional assistance, please call Ellen Weismer (608)278-1808.
                </p>            
            </td>
        </tr>
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" class="infotext3" cellspacing="0">
        <tr>
            <td>
                <img src="logo.jpg" />
            </td>
            </tr><tr>
            <td>
The Jewish Federation of Madison One Happy Camper program is now closed for summer 2017 For more information, please contact Ellen Weismer at program@jewishmadison.org.  To see if your camp sponsors the One Happy Camper program please click the "next" button at the bottom of the screen.
			</td>
        </tr>
    </table> 
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">
            <tr>
                <td valign="top" style="width: 5%">
                    <asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td align="left">
                                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
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

