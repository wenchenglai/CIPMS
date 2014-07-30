<%@ Page Title="" Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_2_route_info.aspx.cs" Inherits="Enrollment_PJL_Step2_2_route_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <div class="QuestionText" style="margin: 30px;">
        You are about to enter PJL application process because you don't qualify for the community program you are applying due to Day School constraint.
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

