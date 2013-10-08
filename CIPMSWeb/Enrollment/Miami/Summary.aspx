<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Miami_Summary" %>

<asp:Content ID="Miami_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="logo" src="../../images/Miami Logo.jpg" alt="" height="100" width="220" /></td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="infotext3">The Foundation for Jewish Camp, in partnership with the Greater Miami Jewish Federation, offers an incentive program in your community.</p></asp:Label>
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p style="text-align:justify"><b>To determine if you are eligible for this grant, please read the paragraph below. </b> If you believe that your camper meets the eligibility criteria, please proceed with the application process by clicking the next button below.</p></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" CssClass="infotext3" runat="server">
                  <p style="text-align:justify"><b>SEEKING HAPPY CAMPERS (ONE AT A TIME)!</b></p></asp:Label>
            </td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label1" CssClass="infotext3" runat="server">
                  <p style="text-align:justify"><b>The Miami One Happy Camper program provides incentives of $1,000 to first-time campers who are residents of Miami-Dade County. This program enables children grades 3-12 (after camp) to attend a nonprofit Jewish overnight summer camp listed on the Foundation for Jewish Camp’s website  (<a href="http://www.jewishcamp.org/" target="_blank">www.jewishcamp.org</a> ).
                  These grants are for first-time campers only who are attending a residential program that runs at least 19 consecutive days.</b></p>            
            </asp:Label></td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label3" CssClass="infotext3" runat="server">
                  <p style="text-align:justify">Multiple children from a single family are eligible to receive separate grants and will be considered separate grantees. The One Happy Camper program is an outreach initiative for children who do not currently receive an immersive, daily Jewish experience. As such, Jewish day school students are not eligible for this incentive program. If you do not think you are eligible for this program, but are interested in learning about camp scholarship opportunities, please visit the Foundation for Jewish Camp website noted above, or your camp.</p>            
            </asp:Label></td>
        </tr> 
        <tr>
          <td colspan="2"><asp:Label ID="Label4" CssClass="infotext3" runat="server">
                  <p style="text-align:justify"><b>The Greater Miami Jewish Federation also offers Need-Based Assistance </b> for qualified children ages 8-17 who reside in Miami-Dade County. For an application and more information, contact Federation at 305-576-4000, or by clicking on: <a href="http://www.jewishmiami.org/" target="_blank">www.JewishMiami.org</a></p>            
            </asp:Label></td>
        </tr>        
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call your community professional listed at the bottom of this page.</p>
                </asp:Label></td></tr>
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
