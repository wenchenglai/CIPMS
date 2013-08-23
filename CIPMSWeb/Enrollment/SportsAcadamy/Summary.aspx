<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Sportsacadamy_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
     <table width="100%" cellpadding="5" cellspacing="0">
            <tr>
            <td>
                <img src="../../images/URJ.jpg" alt=""/></td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="infotext3"><b>The Foundation for Jewish Camp, 
                    in partnership with the Union for Reform Judaism, is offering $1,000 first-time campership awards for campers 
                    who attend any URJ camp </b></p>
                 </asp:Label>
                     <asp:Label ID="Label4" CssClass="infotext3" runat="server">
                     <p style="text-align:justify">
                     </p>
                     </asp:Label>
            </td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label1" CssClass="infotext3" runat="server">
                <p style="text-align:justify">At 6 Points Sports Academy, the award is available to any camp-age child in grades 3-12 who registers at one of the 
                     listed URJ Camps, and who is attending a non-profit Jewish sleep-away camp for at least 12 days for the first time. 
                     If the camper attends a session that is 19 days or longer, he/she is eligible for a grant of $1,000. If the camper 
                     attends a session that is 12-18 days, he she is eligible for a prorated grant of $700. Siblings from a single family 
                     are eligible to receive separate grants. The award is available regardless of need or whether the camper or camper’s 
                     family has received other scholarship or financial aid.
                  
                 </p>
            </asp:Label></td>
        </tr>
        
        <!--<tr>
          <td colspan="2"><asp:Label ID="Label3" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                 To learn more about these URJ camps, please visit the camp websites by clicking on the camp names below. If you are ready to 
                 continue your application, please press the “next” button.</p>
            </asp:Label></td>
        </tr> -->    
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call the camp 
                    professional listed at the bottom of this page.</p>
                </asp:Label></td></tr>
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

