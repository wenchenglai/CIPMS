<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Columbus_Summary" %>

<asp:Content ID="Columbus_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img id="logo" src="logo.jpg" width="270" /></td>
            <td>
                Good news! You may be eligible for an incentive.
			</td>
        </tr>
        <tr>
			<td colspan="2">
                <p>
                    The Kansas City One Happy Camper Program, sponsored by The Jewish Federation of Greater Kansas City and the Foundation for Jewish Camp and generously funded by The Lowenstein Brothers Foundation of The Jewish Community Foundation, provides financial incentives of $1,000 to first-time campers who attend a nonprofit Jewish overnight summer camp for at least 19 consecutive days. Eligible campers must attend a camp listed on the Foundation for Jewish Camp’s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>)and be entering grades 2-12 (after camp). 
                </p>
                <p>
                    The program is available to the first ten first-time campers who apply. 
                </p>
                <p>
                    To learn more about the Jewish Federation's First Time Campers fund contact Alan Edelman at (913) 327-8104 or alane@jewishkc.org
                </p>
			</td>
        </tr>
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0" Visible="false">
        <tr>
            <td>
                <img id="Img1" src="logo.jpg" width="270" /></td>
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
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                            <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                                </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" Visible="True"  OnClick="btnNext_Click" /></td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>
</asp:Content>
