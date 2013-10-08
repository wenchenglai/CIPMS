<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_NNJ_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
           <td>
                <img id="imgLogo" src="../../images/CNJ_Logo.JPG" width="250" alt="" runat="server" /></td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="infotext3"><b>Great news!  The Foundation for Jewish Camp, in partnership with Jewish Federation of Central New Jersey, 
                    offers funding to children in our community who wish to attend Jewish overnight camp for the first-time.</b></p>
                    <br/>
                </asp:Label>
                <asp:Label ID="Label2" CssClass="SummaryHeading" runat="server" ForeColor="red">
                    <p style="text-align:justify" class="infotext3"><b>Note: Central New Jersey is now part of Jewish Federation of Greater MetroWest New Jersey.</b></p>
                    <br/>
                </asp:Label>                    
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3" >
				   <p style="text-align:justify" >To determine if you are eligible for a One Happy Camper grant please read the paragraph below.  
				   If you believe that your camper meets the criteria please proceed with the application by clicking the “next” button below.</p>
				   <br />
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
				<asp:Label ID="Label1" runat="server" CssClass="infotext3">
					<p style="text-align:justify">
						The Greater MetroWest New Jersey One Happy Camper Program provides grants to encourage children to attend overnight Jewish 
						camp for the first-time. It is not a scholarship fund and is not needs-based. Our goal is to engage families who are considering sending their children 
						to camp and, in effect, give them $1000 off their camp fee to try a Jewish one.
					</p>
					<p style="text-align:justify">
						<b>Greater MetroWest New Jersey One Happy Camper grants are awarded to first-time campers who attend a nonprofit Jewish overnight summer 
						camp for at least 19 consecutive days. Eligible campers must be entering grades 1-12 (after camp) and be attending one of the 150+ non-profit, 
						Jewish, overnight summer camps listed on the Foundation for Jewish Camp’s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).</b>
					</p>
				</asp:Label>
				<asp:Label ID="lblAdditionalInfo" runat="server" CssClass="infotext3">
					<p style="text-align:justify">
						Note: This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience.  
						As such, children who attend Jewish Day School or Yeshiva are not eligible for the program.  
						If your child is not eligible and/or is interested in learning about financial-needs based grants or other campers funding opportunities, 
						please visit <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a>, 
						contact your camp, or contact the person listed at the bottom of this page.
					</p>
					<p style="text-align:justify">
						If you need additional assistance, please call your community professional listed at the bottom of this page.
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
                                    CssClass="submitbtn1" />
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
