<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_NNJ_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr> 
            <td>
                <img id="imgLogo" src="../../images/jewish nnj.jpg" alt="" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
					<p style="text-align:justify"><b>Good news! You may be eligible for an incentive.</b></p><br/>
				</asp:Label>    
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3" >
					<p style="text-align:justify" >
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
					</p>
					<br />
				</asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
				<asp:Label ID="Label1" runat="server" CssClass="infotext3">
					<p style="text-align:justify">
						<b>JFNNJ’s One Happy Camper program is made possible by the Jewish Federation of Northern New Jersey (JFNNJ) and the Foundation for Jewish Camp. 
						The program provides a limited number of grants to encourage children to attend overnight Jewish camp for the first-time.  
						Financial incentives of $1,000 are awarded to first-time campers who attend a nonprofit Jewish overnight summer camp for at least 19 days. 
						Eligible campers must be entering grades 4-12 (after camp) and attending a camp listed on the Foundation for Jewish Camp’s website 
						(<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>). Grants are distributed on a first-come first-serve basis.</b>
					</p>
                </asp:Label>
				<asp:Label ID="lblAdditionalInfo" runat="server" CssClass="infotext3">
					<p style="text-align:justify">
						This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. 
						As such, children who attend Jewish day school or yeshiva are not eligible for this incentive program. If you do not think that you are 
						eligible for this program, but are interested in learning about camp scholarship opportunities, please visit 
						(<a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a>) or contact your camp directly.
					</p>
					<p style="text-align:justify">
						If you are interested in learning more about the services of the Jewish Federation of Northern New Jersey, 
						please visit (<a href="http://www.jfnnj.org" target="_blank">www.jfnnj.org</a>). 
					</p>
					<p style="text-align:justify">For more information, please contact the person listed below.</p>
				</asp:Label>
			</td>
        </tr>
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr> 
            <td>
                <img id="img1" src="../../images/jewish nnj.jpg" alt="" runat="server" />
            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td colspan="2">
				<asp:Label ID="Label4" runat="server" CssClass="infotext3">
					<p style="text-align:justify">
						The Northern New Jersey One Happy Camper grants are limited. 
						For more information or to get on the waiting list, please contact the professional listed at the bottom of the screen.
						<br /><br />
						Click ‘NEXT’ to see if your camp is sponsoring its own One Happy Camper program.						
					</p>
					<br />
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
                                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary"
                                    CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous"
                                    CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later"
                                    CssClass="submitbtn1" Visible="false" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> "
                                    CssClass="submitbtn" OnClick="btnNext_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
