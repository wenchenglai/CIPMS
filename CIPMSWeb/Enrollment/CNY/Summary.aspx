<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Chi_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img src="../../images/CNY Logo.jpg" /></td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="infotext3">
                        <b>Great news! The Foundation for Jewish Camp, continues to partner with the Jewish Federation of CNY.  
                            We offer funding to children in our community who wish to attend Jewish overnight camp for the first-time.</b>
                    </p>
                </asp:Label>
                <asp:Label ID="Label4" CssClass="infotext3" runat="server">
                     <p style="text-align:justify"> 
                        To determine if you are eligible for a One Happy Camper grant please read the paragraph below.  
                         If you believe that your camper meets the criteria please proceed with the application by clicking the “next” button below.
                     </p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                    The One Happy Camper program, administered by the Jewish Federation of CNY, 
                    provides <b>joint</b> financial incentives <b>totaling</b> $1,000 to first-time campers who attend a 
                    nonprofit Jewish overnight summer camp for at least 19 consecutive days. 
                    Eligible campers must be entering grades 1-12 and attending a camp listed on the 
                    Foundation for Jewish Camp website (<a href="http://www.jewishcamp.org" target="_blank">www.jewishcamp.org</a>).                 
                </p>
                </asp:Label></td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                 <b>Funds that are awarded will be paid directly to the camp.</b></p>
                </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label6" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                If your child is not eligible for this particular program and you are interested in learning about financial-needs based grants 
                    or other camper funding opportunities please visit <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a> or contact your camp.</p>
                </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                 For information about <b>SYRACUSE AND CENTRAL NEW YORK INCENTIVES ONLY</b>, contact Judith Stander at <a href="mailto:jstander@jewishfederationcny.com">jstander@jewishfederationcny.com</a>. </p>
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

