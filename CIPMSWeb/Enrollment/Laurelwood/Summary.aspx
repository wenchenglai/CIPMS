<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Nageela_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
     <table width="100%" cellpadding="5" cellspacing="0">
            <tr>
            <td style="height: 309px">
                <img src="../../images/CampLaurelwood_logo.jpg" /></td>
            <td style="height: 309px">
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="infotext3"><b>Good news! You may be eligible for an incentive.</b></p>
                 </asp:Label>
                     <asp:Label ID="Label4" CssClass="infotext3" runat="server">
                     <p style="text-align:justify"> 
To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.</p>
                     <p style="text-align:justify">
                     </p>
                     
                      <%--<p style="text-align:justify"><b>
                  Camp Laurelwood, CT’s only Jewish Overnight camp established in 1937, 
                  will be offering for its third year, first and second-time One Happy 
                  Camper incentive grants.  All campers grades 1-10th are welcome to apply 
                  as long as it is their first time attending Jewish overnight camp for more
                  than 19 consecutive days.  A camper may apply from any city or state, there 
                  are no limitations.</b>  
                 </p>--%>
                     </asp:Label>
            </td>
        </tr>
      
        <tr>
          <td colspan="2"><asp:Label ID="Label2" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                 <b>The Camp Laurelwood One Happy Camper Program, sponsored by Camp Laurelwood and the Foundation for Jewish Camp will be offering for its third year, first and second-time One Happy Camper incentive grants. All campers grades 1-10th are welcome to apply as long as it is their first time attending Jewish overnight camp for more than 19 consecutive days. A camper may apply from any city or state, there are no limitations.</b></p>
            </asp:Label></td>
        </tr>
          <tr>
          <td colspan="2"><asp:Label ID="Label1" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                Camp Laurelwood, CT’s only Jewish Overnight camp established in 1937, provides traditional Jewish camping to approximately 250 campers a session. The camp program includes nature, art, drama, all land sports, swimming, boating, high and low ropes course, 3 kosher meals a day and two snacks, daily canteen trips, a weekly Shabbat experience and Havdallah experience and Israeli programming. Campers from various Jewish backgrounds are welcome and made feel comfortable to attend. Camp Laurelwood is a place where our mission is fun, friends, forever!
                </p></asp:Label></td>
        </tr>
          
        <tr>
          <td colspan="2"><asp:Label ID="Label5" CssClass="infotext3" runat="server">
                <p style="text-align:justify" >
        If you are currently enrolled in a Jewish day school please do not continue with this application, rather contact Camp Laurelwood directly at (203) 421-3736 or director@camplaurelwood.org.</p>
            </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call the camp professional listed at the bottom of this page.</p>
                </asp:Label></td></tr>
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">            
            <tr>
                <td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" ><br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
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

