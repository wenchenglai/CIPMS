<%@ Page Title="" Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_camp_coupon_holding.aspx.cs" Inherits="Enrollment_Chicago_Step2_camp_coupon_holding" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <div class="QuestionText">
        <p class="headertext">
            It appears that you are not eligible for the One Happy Camper first time incentive grant.
        </p>
        <p>
             
            However you may be eligible for a Camp Coupon, a program of the Jewish United Fund of Chicago and administered through the One Happy Camper registration system.        </p>
        <p>
            The Camp Coupon program application will launch in January 2017.
        </p>
        <p>
            To be notified when the application launches, please contact JUF at JewishCamp@juf.org.  Be sure to include your name, email address, 
            age of your child and name of the school they attend.
        </p>
    </div>

    <table width="100%">
        <tr>
            <td align="left">
                <asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" />
            </td>
            <td >
                <asp:Button ID="btnPrevious"  ValidationGroup="CommentsGroup" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" />
            </td>
            <td align="center">
                <asp:Button ID="btnSaveandExit"  ValidationGroup="CommentsGroup" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" OnClick="btnSaveandExit_Click" />
            </td>
            <td align="right">
                <asp:Button ID="btnNext" ValidationGroup="OtherValidation" Visible="false" Text="Next >>" CssClass="submitbtn" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

