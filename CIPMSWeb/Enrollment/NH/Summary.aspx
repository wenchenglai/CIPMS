<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_NH_Summary" %>

<asp:Content ID="NH_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="logo" src="../../images/NewHampshire_Logo.jpg" alt = "" /></td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify">Good news! You may be eligible for an incentive.</p>
                </asp:Label>
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						The One Happy Camper Program, sponsored by the Jewish Federation of New Hampshire and the Foundation for Jewish Camp, provides incentives of up to $1,000 
						to first-time campers who attend a nonprofit Jewish overnight summer camp for at least 19 consecutive days. Eligible camps are listed on the 
						Foundation for Jewish Camp’s website ( <a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>). 
					</p>            
				</asp:Label>
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						One Happy Camper grants are not based on financial need and are designed to encourage families to send children to Jewish camps. 
						Families must participate in the current JFNH Annual Campaign at a minimum level of $100.00. Camper must reside in New Hampshire or family must 
						belong to a NH Jewish congregation. Recipient campers must write a short letter or article for publication in the NH Jewish Reporter. 
						Applications will be accepted as long as money is available. 
					</p>            
				</asp:Label>
            </td>
        </tr>        
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">
						For more information, please contact the JFNH Camp Grant Chair listed below:<br /><br />
						Nancy Frankel (<a href="mailto:corkyatcf@aol.com">corkyatcf@aol.com</a>) 603 472-3983
                    </p>
                </asp:Label>
            </td>
        </tr>
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="Img1" src="../../images/NewHampshire_Logo.jpg" alt = "" /></td>
            <td>                
                <asp:Label ID="Label4" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
					The New Hampshire One Happy Camper program is now closed for the summer of 2013. For more information, please contact the professional listed at the bottom of the screen.                
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
