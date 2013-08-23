<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Columbus_Summary" %>

<asp:Content ID="Columbus_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="logo" src="../../images/Kansas City_logo.jpg" width="270" /></td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify">Good news! You may be eligible for an incentive.</p>
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
						<b>The Kansas City One Happy Camper Program, sponsored by The Jewish Federation of Greater Kansas City and the Foundation for Jewish Camp and 
						generously funded by The Lowenstein Brothers Foundation of The Jewish Community Foundation, 
						provides financial incentives of $1,000 to first-time campers who attend a nonprofit Jewish overnight summer camp for at least 19 consecutive days. 
						Eligible campers must attend a camp listed on the Foundation for Jewish Camp’s website 
						(<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>)and be entering grades 2-12 (after camp).</b>
					</p>            
				</asp:Label>
			</td>
        </tr>   
        <tr>
			<td colspan="2">
				<asp:Label ID="Label3" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. 
						As such, children who attend Jewish day school or Yeshiva are not eligible for this incentive program. 
						<b>If the camper currently attends Jewish day school or Yeshiva and will be going on a 19 day or longer 1st Time Camp experience, 
						please contact directly for information (<a href="mailto:kareng@jewishkc.org" target="_blank">kareng@jewishkc.org</a>).</b>
					</p>            
				</asp:Label>
			</td>
        </tr>   
        <tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						If you do not think that you are eligible for this program, but are interested in learning about camp scholarship opportunities, 
						please contact Amy Rosenfeld at 913.327.8145 or <a href="mailto:amyr@jewishkc.org" target="_blank">amyr@jewishkc.org</a> regarding the Gershon Hadas Scholarship Fund which is due in late February 2013.</p>            
				</asp:Label>
			</td>
        </tr>   
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call your community professional listed at the bottom of this page.</p>
                </asp:Label>
            </td>
        </tr>
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="Img1" src="../../images/Kansas City_logo.jpg" width="270" /></td>
            <td>

			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label6" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Please contact Amy Rosenfeld at the Kansas City One Happy Camper program at 913-327-8145 or amyr@jewishkc.org for further information on how to apply.
						<br /><br />
						Click ‘NEXT’ to see if your camp is sponsoring its own One Happy Camper program.						
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
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn"  OnClick="btnNext_Click" /></td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>
</asp:Content>
