<%@ Page Title="" Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_2_route_info.aspx.cs" Inherits="Enrollment_PJL_Step2_2_route_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <div class="QuestionText" style="margin: 30px;">
        <p>You are being re-routed to the PJ Goes to Camp One Happy Camper program.</p>
        <p>PJ Goes to Camp has a limited number of grants for children currently enrolled in a Jewish day school.  Grants are awarded by lottery.  To enter the lottery we need to know a bit more about your first-time camper.</p>  
        <p>The lottery will take place the week of November 10th.  You will be notified via the email aaddress that you used to complete this application.</p>
        <p>Questions, please contact:  PJGTC@HGF.org.</p>
        <p>Please click “Next” button to continue the application process. </p>

    </div>
    <table width="100%">
        <tr>
            <td align="left">
                <asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" />
            </td>
            <td >
                <asp:Button ID="btnPrevious"  ValidationGroup="CommentsGroup" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click1" />
            </td>
            <td align="center">
                <asp:Button ID="btnSaveandExit"  ValidationGroup="CommentsGroup" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" OnClick="btnSaveandExit_Click" />
            </td>
            <td align="right">
                <asp:Button ID="btnNext" ValidationGroup="OtherValidation" Text="Next >>" CssClass="submitbtn" runat="server" OnClick="btnNext_Click" />
            </td>
        </tr>
    </table>    
</asp:Content>

