<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Chi_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img src="../../images/Camp_Avoda_RGB_logo.jpg" /></td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="infotext3"><b>Good news! You may be eligible for an incentive.</b></p>
                </asp:Label>
                <asp:Label ID="Label4" CssClass="infotext3" runat="server">
                     <p style="text-align:justify"> 
                     To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.</p>
                     
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label6" CssClass="infotext3" runat="server">
          <p style="text-align:justify">
          Brotherhood &nbsp;&nbsp;&nbsp;&nbsp; * &nbsp;&nbsp;&nbsp;&nbsp; Leadership &nbsp;&nbsp;&nbsp;&nbsp; *  &nbsp;&nbsp;&nbsp;&nbsp; Spirit  &nbsp;&nbsp;&nbsp;&nbsp;*  &nbsp;&nbsp;&nbsp;&nbsp;Tradition 
          </p>
                <p style="text-align:justify">
               <b> Camp Avoda: </b>Established 1927
                     </p>
                </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" CssClass="infotext3" runat="server">
                <p style="text-align:justify"><b>
                  The Camp Avoda One Happy Camper program, sponsored by Camp Avoda and the Foundation for Jewish Camp provides financial incentives 
                    of $1,000 to first-time campers who attend Camp Avoda for at least 19 consecutive days. 
                    Eligible campers must be entering grades 2-10 (after camp).
                 </b></p>
                </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label5" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                 Camp Avoda aims to maintain Jewish spirituality infused in day to day living at camp throughout the summer. We have Friday night and Saturday morning services at our outdoor Chapel Site, we wear kipot to all meals, keep Shabbat programming separate from the rest of the week, and end each Saturday with Havdallah. Our goal is to provide campers with cultural reminders that fit the overall camp culture and are in line with our camp’s mission of fostering values of teamwork, leadership, self-confidence and respect for one another based on shared experiences that value our Jewish culture and traditions. Being brought up at Camp Avoda lends itself to maintaining and fostering Jewish identity as boys grow up to become men and leaders. 
                 </p>
                </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                 We are a non-profit resident camp for Jewish boys ages 7 through 15 in Middleboro, MA. Our program includes: Sports, Swimming and Boating, Arts, Judaica, Ropes Course & Climbing Wall, Field Trips, Evening Activities, Overnight Camp-outs, Color War, Intercamp teams, Intracamp competiton, and more! </p>
                </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                 If you are interested in learning more about our camp and available grants, please visit us at: <a href="http://www.campavoda.org" target="_blank">www.campavoda.org</a> or call Ken Shifman at 781-433-0131.</p>
                </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call the camp professional listed at the bottom of this page.</p>
                </asp:Label></td>
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
                                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

