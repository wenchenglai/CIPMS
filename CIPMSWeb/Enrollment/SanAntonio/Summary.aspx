<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Memphis_Summary" %>

<asp:Content ID="Memphis_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img src="logo.jpg" alt="logo" />
            </td>
        </tr>        
        <tr>
			<td colspan="2">
			    <p>
			        Good news! You may be eligible for an incentive grant.
			    </p>
                <p>
                    To determine if you are eligible, continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
                </p>
			    <p>
                    The San Antonio One Happy Camper Grant program, sponsored by the Jewish Federation of San Antonio and the Foundation for Jewish Camp, offers incentive grants of up to $1,000 to first-time campers.
			    </p>

				The following outlines the eligibility criteria for this program:
                <ul style="font-weight: bold; list-style-type: disc ">
                    <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                    <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                    <li>First time camper must be entering grades 1-12 (after camp).</li>
                    <li>If camper attended a previous stay of less than 12 days, s/he is still eligible for the grant.</li>
                    <li>Attending one of the 155+ nonprofit, Jewish, overnight camps listed on the Foundation for Jewish Camp’s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).</li>
                </ul>
                <p>
                    If you need additional assistance, including free guidance on finding a camp, please call your community professional listed at the bottom of this page. 
				</p>
			</td>
        </tr>     
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img src="logo.jpg" alt="logo" />
            </td>
        </tr>
        <tr>
			<td>
				<asp:Label ID="Label6" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
                        The Jewish Federation of San Antonio One Happy Camper program is now closed for summer 2017. For more information, please contact Lauren Abraham at abrahaml@jfsatx.org.  To see if your camp sponsors the One Happy Camper program please click the “next” button at the bottom of the screen.
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
