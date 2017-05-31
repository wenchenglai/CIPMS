<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_NNJ_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr> 
            <td>
                <img id="imgLogo" src="../../images/jewish nnj.jpg" alt="" runat="server" />
            </td>
            <td>
                <p>
					Good news! You may be eligible for an incentive.
				</p>
                <p>
					To determine if you are eligible continue reading and if your camper meets the eligibility criteria, 
					please proceed by clicking the "next" button below.
				</p>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <p>
                    The Jewish Federation of Northern New Jersey’s One Happy Camper program is made possible by the Jewish Federation of Northern New Jersey and the Foundation for Jewish Camp. The program provides a limited number of grants to encourage children to attend overnight Jewish camp for the first-time.                     
                </p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 3-12 (after camp).</li>
                        <li>Attending one of the 155+ non-profit, Jewish, overnight camps listed on the Foundation for Jewish Camp’s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).</li>
                    </ul>
				</p> 
                <p>
                    This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. As such, children who attend Jewish Day School or yeshiva are not eligible for this incentive program.
                </p>
                <p>
                    If you do not think that you are eligible for this program, but are interested in learning about camp scholarship opportunities, please visit (<a href="http://www.jewishcamp.org/scholarships" target="_blank">www.jewishcamp.org/scholarships</a>) or contact your camp directly.
                </p>
                <p>
                    If you are interested in learning more about the services of the Jewish Federation of Northern New Jersey, please visit (<a href="http://www.jfnnj.org" target="_blank">www.jfnnj.org</a>).
                </p>
                <p>
                    For more information, please contact the person listed at the bottom of this page.
                </p>
			</td>
        </tr>
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr> 
            <td>
                <img id="img1" src="../../images/jewish nnj.jpg" alt="" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
				<asp:Label ID="Label4" runat="server" CssClass="infotext3">
					<p style="text-align:justify">

The  Jewish Federation of Northern New Jersey One Happy Camper program is now closed for summer 2017 and is no longer accepting grant applications. For more information, please contact Sarah David at SarahD@jfnnj.org.  To see if your camp sponsors the One Happy Camper program please click the "next" button at the bottom of the screen. Keep the logo as is.

					</p>
				</asp:Label>
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
                                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary"
                                    CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous"
                                    CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later"
                                    CssClass="submitbtn1" Visible="true" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> "
                                    CssClass="submitbtn" OnClick="btnNext_Click" Visible="true" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
