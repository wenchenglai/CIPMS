<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Summary" %>

<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="Orange_summary" ContentPlaceHolderID="Content" runat="Server">
    <table  cellpadding="2" cellspacing="0">
        <tr>
            <td align="center" >
                <img id="logo2" src="../../images/JFOC stacked logo.jpg" /></td>
            <td>
                <asp:Label ID="Label4" CssClass="SummaryHeading" runat="server"><b>The Foundation for Jewish Camp, in partnership with Jewish Federation & Family Services, Orange County (CA), offers an incentive program in your community! </b></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" CssClass="QuestionText" runat="server">
                  <p style="text-align:justify">
                     Read below to find out if the camper meets the eligibility criteria. If so, please continue with the application by pressing the next button below.</p>  
                  <p style="text-align:justify">
                    <b>The One Happy Camper program, administered by the Passport to Jewish Life® 
                    program of Jewish Federation & Family Services, Orange County (JFFS), provides 
                    financial incentives of up to $1,000 to first-time campers who attend a nonprofit 
                    Jewish overnight summer camp for at least 12 consecutive days. Eligible campers must 
                    be entering grades 4-9 (after camp) and attending a camp listed on the Foundation for 
                    Jewish Camp's website <a href="http://www.jewishcamp.org" target="_blank">(www.jewishcamp.org)</a>. First time campers are eligible for grants of $1,000 if 
                    they attend camp for at least 19 days, and $700 if they attend camp for 12-18 days. Campers who have 
                    had any prior experience at Jewish overnight summer camp, excluding family and weekend camps, are 
                    ineligible for this grant.                    
                    </b></p>  
                    <p style="text-align:justify">
                    <b>The program also offers up to $750 to returning campers in grades 5-9 who received 
                    an incentive grant through JFFS in 2010 and are attending a camp session for at least 19 consecutive 
                    days. </b>
                    </p>
                    
                </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <%--<asp:Label ID="lblCIP" runat="server" CssClass="headertext1">Campership Incentive Program:</asp:Label>--%>
                <asp:Label ID="PROGRAMBLURB2" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">
                        This program is an outreach initiative for children who are not currently receiving an immersive, 
                        daily Jewish experience. As such, children who attend Jewish day school or yeshiva are not eligible 
                        for this incentive program. 
                        <b>All applications must be received at JFFS by June 1, 2011.</b> 
                        
                        </p>
                </asp:Label>
            </td>
        </tr>
        <%--<tr>
            <td colspan="2">
                <asp:Label ID="PROGRAMBLURB2Contd" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
                        entering grades 3,4,5, or 9 and attending a camp listed on the 
                        Foundation for Jewish Camp's website <a href="http://www.jewishcamp.org" target="_blank">(www.jewishcamp.org)</a>. If you are in grades 10-11, please 
                        call the Federation before applying for the incentive grant This program is an outreach initiative for children who 
                        are not currently receiving an immersive, daily Jewish experience. As such, children 
                        who attend Jewish day school or yeshiva are not eligible for this incentive program. If you 
                        believe you are ineligible for this program, but would like to know about other camp support 
                        opportunities, visit <a href="http://www.JewishOrangeCounty.org/Passport" target="_blank">www.JewishOrangeCounty.org/Passport</a>.</p></asp:Label></td></tr>        --%>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">
                       If you believe you are ineligible for this program, but would like to know about other camp support opportunities or need additional assistance, please email <a href="mailto:Kathleen@jfoc.org" target="_blank">Kathleen@jfoc.org</a> or call 949-435-3484.</p>
                        
                </asp:Label></td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">
            <tr>
                <td valign="top" style="width: 5%">
                    <asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2">
                    <br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td align="left">
                                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary"
                                    CssClass="submitbtn1" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous"
                                    CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later"
                                    CssClass="submitbtn1" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> "
                                    CssClass="submitbtn" OnClick="btnNext_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
