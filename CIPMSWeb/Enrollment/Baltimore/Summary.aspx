<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Dallas_Summary" %>

<asp:Content ID="Dallas_Summary" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
            <tr>
            <td>
                <img id="logo" src="../../images/Baltimore.jpg" />
            </td>
             <td>
               
               
                <asp:Label ID="Label4" runat="server" CssClass="infotext3">
                    <p style="text-align:justify"><b>To determine if you are eligible for this grant, please read the paragraph below.</b> If you believe that your camper meets the eligibility criteria, please proceed with the application process. If the camper does not meet these criteria, please contact your camp or Federation to inquire about other opportunities in your area.
                    </p></asp:Label>
             </td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label2" CssClass="infotext3" runat="server">
                <p style="text-align:justify"><b>The Baltimore Jewish Overnight Campership Program, administered by the THE: ASSOCIATED: Jewish Community Federation of Baltimore, provides financial incentives of $1,000 to eligible first-time campers who attend a not-for-profit Jewish overnight summer camp listed on the program’s website (<a href="http://www.associated.org/page.aspx?id=183043" target="_blank">www.associated.org/page.aspx?id=183043</a>) for at least 19 consecutive days. (Note: first-time campers are children/teens in grades 2 – 12 who have never attended Jewish Overnight camp before for 19 consecutive days or more).  To be eligible, the camper must reside in Baltimore County or Baltimore City.  Students who are paid to work at camp are not eligible.  Participants in Israel programs or other overseas travel are not eligible.</b>
                </p>
            </asp:Label></td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label1" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                Campers who received a $1,000 incentive grant from the Baltimore Jewish Overnight Campership Program in 2009 are eligible to apply for a $750 returning camper grant if they plan to attend camp for 19 consecutive days during summer 2010. <b>(Note: second year grants will be discontinued after summer 2010).</b>  
                </p>
            </asp:Label></td>
        </tr> 
        <tr>
          <td colspan="2"><asp:Label ID="Label3" CssClass="infotext3" runat="server">
                <p style="text-align:justify">       
        As the Campership Incentive Program is intended by the Foundation for Jewish Camp to be an outreach initiative, campers who attend Jewish Day School are not eligible for the program.  The incentive program is aimed at increasing attendance at nonprofit Jewish overnight camp by Jewish children who might otherwise select a secular summer experience. The program is not to be looked upon as financial assistance, but as an incentive to choose the richness and warmth of a summer at Jewish overnight camp.
                </p>
            </asp:Label></td>
        </tr> 
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">For more information, please contact Renee Dain at THE ASSOCIATED at 410-369-9235 or <a href="mailto:rdain@associated.org" target="_blank">rdain@associated.org</a>.</p>
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
                                
                            <td align="right"><asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" />
                                </td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>


</asp:Content>
