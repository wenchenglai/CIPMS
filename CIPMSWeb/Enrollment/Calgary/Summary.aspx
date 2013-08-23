<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Calgary_Summary" %>

<asp:Content ID="Pittsburgh_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="Img2" width="250" height="100" src="../../images/calgary.jpg" alt=""/>
            </td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="lblPopup1">Good news! You may be eligible for an incentive.</p>
                </asp:Label>    
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
                    </p>
                </asp:Label>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
                    The Calgary One Happy Camper Program, sponsored by the Calgary Jewish Federation and the Foundation for Jewish Camp, 
                    provides financial incentives of $1,000 to first-time campers who attend a non-profit Jewish overnight summer camp for at least 19 days. 
                    Eligible campers must be entering grades 2-12 (after summer camp) and attending a Canadian camp listed on the Foundation for Jewish Camp’s website at 
                    <a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>. 
                    If you are interested in attending a US based Jewish summer camp, please contact the Calgary Jewish Federation at 403-444-3153.
					</p>
				</asp:Label> 
			</td>
        </tr>
        <tr>
			<td colspan="2"><asp:Label ID="Label2" CssClass="infotext3" runat="server">
                  <p style="text-align:justify">The One Happy Camper Program is an outreach initiative for children who are not currently receiving an immersive, 
                  daily Jewish experience. As such, children who attend Jewish day school or Yeshiva are not eligible for this incentive program. 
                  If you do not think that you are eligible for this program and are in need of financial assistance to attend the 
                  Federation affiliated camp (Camp BB-Riback), please contact the Calgary Jewish Federation directly at 403-444-3153 
                  or visit the website at <a href="http://www.jewishcalgary.org" target="_blank">www.jewishcalgary.org </a> 
                  to learn about / apply for the Integrated Bursary Program. </p>            
            </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
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
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
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
