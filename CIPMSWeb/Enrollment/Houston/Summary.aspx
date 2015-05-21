<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Chi_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img src="logo.gif" width="290" /></td>
            <td>
                <p>
                    Great news!  The Foundation for Jewish Camp, in partnership with the Jewish Federation of Greater Houston offers funding to children in our community who wish to attended Jewish overnight camp for the first-time.
                </p>
                <p>
                    To determine if you are eligible for a One Happy Camper grant please read below. If you believe that your camper meets the criteria please proceed with the application by clicking the next button below. 
                </p>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <p>
                    The Jewish Federation of Greater Houston’s One Happy Camper Program provides grants to encourage children to attend overnight Jewish camp for the first-time.  It is not a scholarship fund and is not needs-based.  Our goal is to engage families who are considering sending their children to camp and, in effect, to give them up to $1,000 off their camp fee to try a Jewish one.
                </p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 1-12 (after camp).</li>
                        <li>If camper attended camp in the summer of 2014 for 12-18 days as a first time camper s/he is still eligible for the grant if attending camp in 2015 for 19 or more consecutive days.</li>
                        <li>Attending one of the 150+ non-profit, Jewish, overnight camps listed on the Foundation for Jewish Camp’s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).</li>
                    </ul>
				</p> 
                <p>
                    <span style="font-weight:bold;">Note:</span> If your child is not eligible and/or you are interested in learning about financial-needs based grants or other camper funding opportunities, please contact The Jewish Federation of Greater Houston at pwalden@houstonjewish.org or 713-729-7000 ext. 309.
                </p>         
            </td>
        </tr>
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img src="logo.gif" width="290" />
            </td>
        </tr>
        <tr>
            <td>
                <p>
                    For further information on how to apply for the Jewish Federation of Greater Houston One Happy Camper program, please contact the professional listed at the bottom of the screen.
                </p>
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

