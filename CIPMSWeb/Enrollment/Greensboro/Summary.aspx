<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Summary" %>

<asp:Content ID="Greenboro_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="logo" src="../../images/Greensboro_Logo.jpg" width="270" /></td> 
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify">Good news! You may be eligible for an incentive.</p>
                </asp:Label>
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">To determine if you are eligible continue reading and if your camper meets the eligibility criteria, 
						please proceed by clicking the "next" button below.</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<b>The Greensboro One Happy Camper Program, sponsored by the Greensboro Jewish Federation, Beth David Synagogue, Temple Emanuel, and 
						the Foundation for Jewish Camp, provides financial incentives of $1,000 to first-time campers who attend a nonprofit Jewish overnight summer camp 
						for at least 19 days. $700 is offered to first-time campers attending URJ Six Points Sports Academy.</b>
					</p>                
					<p style="text-align:justify">
						Eligible campers must be entering grades 3-12 (after camp), live in Greensboro or its environs, and be attending a camp listed on the Foundation for 
						Jewish Camp’s website (www.jewishcamp.org/camps). Multiple children from a single family are eligible to receive separate grants. 
						At least one parent or guardian must be a member in good standing and contribute to the Greensboro Jewish Federation in the year the grant is awarded. 
						Members of Beth David Synagogue and Temple Emanuel are eligible to receive full incentives. Unaffiliated members may apply to the Federation and will 
						be reviewed on a case-by-case basis.
					</p>
					<p style="text-align:justify">
						If you do not think that you are eligible for this program, and/or are interested in learning about camp scholarship opportunities, 
						please visit <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a>, your camp, or
                        visit <a href='http://www.shalomgreensboro.org/camp'>www.shalomgreensboro.org/camp</a> to learn about local scholarships available. 
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
                           <td align="right"><asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" />
                                </td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>


</asp:Content>
