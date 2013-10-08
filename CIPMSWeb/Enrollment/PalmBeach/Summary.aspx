<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_PalmBeach_Summary" %>

<asp:Content ID="PalmBeach_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="logo" src="../../images/palmbeach.png" alt="" />
            </td>
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
						The Palm Beach One Happy Camper Program, sponsored by the Jewish Federation of Palm Beach County and the Foundation for Jewish Camp, 
						provides financial incentives of $1,000 to first-time campers who attend a nonprofit Jewish overnight summer camp for at least 19 consecutive days. 
						Eligible campers must be entering grades 2-11 (after camp) and attending a camp listed on the Foundation for Jewish Camp’s website  
						(<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).
					</p>            
				</asp:Label>
			</td>
        </tr> 
        <tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						If you do not think that you are eligible for this program, there are more scholarship opportunities available through the Jewish Federation of 
						Palm Beach County. Feel free to contact Sam Friedman, Program Coordinator, for more information on how your child can experience camp this summer.
					</p>            
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
                <img id="Img1" src="../../images/palmbeach.png" alt="" />
            </td>
            <td>

			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						The Palm Beach One Happy Camper Program is now closed for Summer 2013. 
						For additional information, please contact Sam Friedman at 561-615-4953 or <a href="mailto:Sam.Friedman@jewishpalmbeach.org">Sam.Friedman@jewishpalmbeach.org</a>.
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
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn"  OnClick="btnNext_Click" /></td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>
</asp:Content>
