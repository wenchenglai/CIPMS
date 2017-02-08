<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_NY_Summary" %>

<asp:Content ID="NY_Summary" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="logo" src="../../images/NY.gif" /></td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="lblPopup1">The Foundation for Jewish 
                    Camp, in partnership with the UJA Federation of New York, offers an incentive program in 
                    your community!</p></asp:Label>
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p style="text-align:justify"><b>To determine if you are eligible for this grant, please read the 
                        paragraph below.</b> If you believe that your camper meets the eligibility criteria, 
                        please proceed with the application process by clicking the "next" button below.</p></asp:Label></td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label1" CssClass="infotext3" runat="server">
                <p style="text-align:justify"><b>The Campership Incentive Program, supported by the 
                UJA-Federation of New York, the Foundation for Jewish Camp, and the Jewish Communal Fund, 
                provides incentive grants of $1000 to first-time campers, ages 8-16, to attend Jewish 
                overnight camp for a session of 19 days or more. </b>
                Campers must register for camp after November 15, 2009, and attend any camp listed on the 
                Foundation for Jewish Camp website (www.jewishcamp.org). Eligible campers must also be a 
                permanent resident of New York City, Long Island, or Westchester. </p>                
                <p style="text-align:justify"><b>Campership seeks to provide children who do not have an 
                immersive Jewish experience a chance to strengthen and build their Jewish identity, 
                and therefore children who attend Jewish Day School or Yeshiva are not eligible.</b></p>
                <p style="text-align:justify"><b>In order to apply, campers will need to meet with a local synagogue or JCC to obtain a referral 
                code</b> (a complete list of synagogues and JCC’s can be found at <a href="http://www.ujafedny.org" target= "_blank" >www.ujafedny.org</a> ). 
                If you do not think you qualify for Campership, please visit <a href="http://www.JewishCamp.org/Scholarships" target= "_blank" >www.JewishCamp.org/Scholarships</a> 
                or contact the camp you wish to attend directly. </p>
            </asp:Label></td>
        </tr>        
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call your community 
                        professional listed at the bottom of this page</p>
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
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" /></td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>


</asp:Content>
