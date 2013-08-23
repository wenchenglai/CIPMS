<%@ Page Language="C#"  MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_NorthShore_Summary" %>

<asp:Content ID="NorthShore_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="logo" src="../../images/NSTI logo.jpg" alt="" />
            </td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="lblPopup1">The Foundation for Jewish Camp, in partnership with the North Shore Teen Initiative, offers an incentive program in your community!</p></asp:Label>
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p style="text-align:justify"><b>To determine if you are eligible for this grant, please read the paragraph below. If you believe that your camper meets the eligibility criteria, please proceed with the application process by clicking the “next” button below. </b>
                        If the camper does not meet these criteria, please contact your camp or Federation to inquire about other opportunities in your area.</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblPara1" CssClass="infotext3" runat="server">
                  <p style="text-align:justify">North Shore youth who have never before attended overnight Jewish summer camp are invited to apply for incentive grants to help defray the cost of camp. 
                  <b>Thanks to a partnership between the North Shore Teen Initiative (NSTI) and the Foundation for Jewish Camp (FJC), grants of $1,000 per youth for the summer of 2011 will be awarded to the first 50 qualified local campers who apply.</b></p>          
            </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="Label1" CssClass="infotext3" runat="server">
                  <p style="text-align:justify">If the camper currently attends Jewish day school, please DO NOT proceed with this application and instead, call Lajla LeBlanc at 781-244-5544 (<a href="mailto:lajla@nsteeninitiative.org" target="_blank">lajla@nsteeninitiative.org</a>) as there are separate funds available for day school campers.</p>          
            </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblPara2" CssClass="infotext3" runat="server">
                  <p style="text-align:justify">These campership incentive grants are not needs-based, and will be available on a first come, first served basis. To be eligible, applicants must self-identify as Jewish, be entering grades 3-12 (after camp), live within the catchment area of the North Shore towns served and must either have never attended overnight Jewish summer camp before, or have attended a Jewish overnight summer camp for less than three weeks. Grant money can be applied toward any one of 17 overnight non-profit Jewish camps in the New England region, or any camp nationally listed by the Foundation for Jewish Camp. For a list of these camps, visit <a href="http://www.jewishcamp.org" target="_blank">www.jewishcamp.org</a>.
                  </p>      
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


