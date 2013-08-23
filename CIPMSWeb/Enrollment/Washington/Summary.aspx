<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Washington_Summary" %>

<asp:Content ID="Washington_Summary" ContentPlaceHolderID="Content" runat="Server">
	<script language="javascript" type="text/javascript">
// <!CDATA[

function Img1_onclick() {

}

// ]]>
	</script>
	
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
				<img id="logo" src="../../images/DC logo.jpg" alt="" height="100" width="320" />
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
                <asp:Label ID="Label6" runat="server" CssClass="infotext3">
					<p style="text-align:justify">
						<b>The Greater Washington DC area One Happy Camper Program, sponsored by The Jewish Federation of Greater Washington and the Foundation for Jewish Camp, 
						provides <u>limited</u> grants to encourage children to attend overnight Jewish camp for the first-time. 
						<font color="red">Please contact Steffanie Jackson directly at 
						<a href="mailto:onehappycamper@shalomdc.org" target="_blank">onehappycamper@shalomdc.org</a> for more information and/or to proceed with the application by clicking the “next” button below.</font></b>
					</p>
					<p style="text-align:justify">
						This is not a scholarship fund and is not needs-based. Our goal is to engage families who are considering sending their children to camp and, in effect, 
						to give them $1,000 off their camp fee to try a Jewish one.</p>
					<p style="text-align:justify">
						Eligible campers must be entering grades 1-12 (after camp) and attending a nonprofit Jewish overnight summer camp for at least 19 consecutive days. 
						Funds will be forwarded directly to the camp and then the camp will reimburse you, if necessary.
					</p>
				</asp:Label>
			</td>
        </tr>        
        <tr>
            <td colspan="2">
                <asp:Label ID="Label7" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<u>Note:</u> This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. As such, 
						children who attend Jewish day school or Yeshiva are not eligible for this program.</p>
					<p style="text-align:justify">
						If your child is not eligible and/or you are interested in learning about financial-needs based grants or other camper funding opportunities please 
						visit <a href="http://www.JewishCamp.org/Scholarships" target= "_blank">www.JewishCamp.org/Scholarships</a>, or contact your camp.
					</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call your community professional listed at the bottom of this page.</p>
                </asp:Label></td>
        </tr>
    </table>
    <table id="tblDisable" runat="server"  width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
				<img id="Img1" src="../../images/DC logo.jpg" alt="" height="100" width="320" />
            </td>
            <td>

            </td>
        </tr>
        <tr>
			<td colspan="2">
                <asp:Label ID="Label2" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
						The Greater Washington DC area One Happy Camper Program has closed for the Summer of 2013. 
						Please contact Steffanie Jackson for more information at  301-230-7254 or Steffanie.Jackson@ShalomDC.org.
						<br />
						If you are interested in learning about financial-needs based grants or other camper funding opportunities 
						please visit <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a>, or contact your camp.
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
                <td valign="top" style="width: 5%">
                    <asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2">
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
