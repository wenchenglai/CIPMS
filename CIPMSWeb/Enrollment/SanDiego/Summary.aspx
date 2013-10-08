<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Memphis_Summary" %>

<asp:Content ID="Memphis_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="logo" src="../../images/San Diego Logo.jpg" alt="" /></td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify">Good news! You may be eligible for an incentive.</p></asp:Label>
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
                    </p>
                </asp:Label>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						The San Diego One Happy Camper Program, sponsored by the Jewish Federation of San Diego County and the Foundation for Jewish Camp, 
						provides grants to encourage children to attend overnight Jewish camp for the first-time.
					</p>            
				</asp:Label>
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						This is not a scholarship fund and is not needs-based. Our goal is to engage families who are considering sending their children to camp and, 
						in effect, to give them up to $1,000 off their camp fee to try a Jewish one.
					</p>            
				</asp:Label>
			</td>
        </tr> 
        <tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						San Diego One Happy Camper grants are awarded to first-time campers who attend a nonprofit Jewish overnight summer camp for at least 12 consecutive days. 
						Eligible campers must be entering grades 1-12 (after camp) and be attending one of the 150+ non-profit, Jewish, overnight summer camp listed on the 
						Foundation for Jewish Camp�s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target= "_blank">www.OneHappyCamper.org/FindaCamp</a>). 
					</p>            
				</asp:Label>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Who is a First Time Camper? First time campers are defined as any camper who is attending nonprofit Jewish overnight camp for the first time for 2 
						consecutive weeks (12 days) or longer. <u>If the camper has previously attended a Jewish overnight camp for less than 2 weeks (12 days) 
						he/she is still eligible.</u> 
					</p>            
				</asp:Label>
			</td>
        </tr>      
        <tr>
			<td colspan="2">
				<asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
					<p style="text-align:justify">
						Note: This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. 
						As such, children who attend Jewish day school or Yeshiva are not eligible for this program.
					</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label3" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call your community professional listed at the bottom of this page.</p>
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
