<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Lman_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
     <table width="100%" cellpadding="5" cellspacing="0">
            <tr>
            <td>
                <img src="../../images/color logo.gif" /></td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="infotext3"><b>Good news! You may be eligible for an incentive.</b></p>
                 </asp:Label>
                     <asp:Label ID="Label4" CssClass="infotext3" runat="server">
                     <p style="text-align:justify"> 
                     To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.</p>
                     <%--<p style="text-align:justify">
                     Camp L知an Achai is a Jewish overnight camp that combines an enriched Jewish atmosphere
                      with the best recreation programs. Our camp痴 breathtaking panoramic view of the Pepacton Reservoir
                       Valley and the surrounding mountains offers an opportune oasis for children to experience the warmth
                        and beauty of their heritage in a safe, friendly, and warm environment. CLA is about making people feel 
                        welcome and at home in a traditional Jewish setting. It strives to let every camper take part in traditions 
                        they might not practice outside of camp and give them an opportunity to build meaningful and lifelong 
                        friendships, enjoy outdoor adventure and deepen their love of Judaism. 
                     We pride ourselves with A Heritage of Happy Campers.</p>--%>
                     </asp:Label>
            </td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label1" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                    <b>The Camp L知an Achai One Happy Camper program, sponsored by Camp L知an Achai and the Foundation for Jewish Camp provides financial incentives of $1,000 to first-time campers. Eligible campers must be entering grades 3-11 (after camp) and attend Camp L知an Achai for at least 19 consecutive days. </b>
                 </p>
            </asp:Label></td>
        </tr>
         <tr>
          <td colspan="2"><asp:Label ID="Label5" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                   Camp L知an Achai is a Jewish overnight camp that combines an enriched Jewish atmosphere with the best recreation programs. Our camp痴 breathtaking panoramic view of the Pepacton Reservoir Valley and the surrounding mountains offers an opportune oasis for children to experience the warmth and beauty of their heritage in a safe, friendly, and warm environment. CLA is about making people feel welcome and at home in a traditional Jewish setting. It strives to let every camper take part in traditions they might not practice outside of camp and give them an opportunity to build meaningful and lifelong friendships, enjoy outdoor adventure and deepen their love of Judaism. We pride ourselves with A Heritage of Happy Campers.
                 </p>
            </asp:Label></td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label2" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                 <b><font style="color:Red">If the camper currently attends Jewish day school, please DO NOT continue with this application and instead, be in touch with the camp directly: 718-436-8255 x107.</font></b></p>
            </asp:Label></td>
        </tr> 
        <tr>
          <td colspan="2"><asp:Label ID="Label3" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                   If you are interested in learning more about our camp and available grants, please visit us at: 
                    <a href="http://www.camplmanachai.com" target="_blank">www.camplmanachai.com</a> or give us a call at 718-436-8255 x107. 
                 </p>
            </asp:Label></td>
        </tr>     
        
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">            
            <tr>
                <td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" ><br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
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

