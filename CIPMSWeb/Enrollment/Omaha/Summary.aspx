<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Memphis_Summary" %>

<asp:Content ID="Memphis_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td> 
                <img id="logo" src="../../images/Omaha Logo.jpg" alt="" /></td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="lblPopup1">Good news! You may be eligible for an incentive.</p></asp:Label>
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
                    </p><%--<p style="text-align:justify"><b>The Greater Rhode Island One Happy Camper Program provides grants to encourage children to attend overnight Jewish camp for the first time.  It is not a scholarship fund and is not needs-based.  Our goal is to promote a Jewish camping experience with a grant of $1,000.00.</b></p>--%></asp:Label></td>
        </tr>
       <tr>
          <td colspan="2">
              <asp:Label ID="Label1" CssClass="infotext3" runat="server">
                  <p style="text-align:justify">
                      The Omaha One Happy Camper Program, sponsored by the Jewish Federation of Omaha, the Jewish Federation of Lincoln and the Foundation for Jewish Camp, 
                      provides grants to encourage children to attend overnight Jewish camp for the first-time.

                  </p>            
              </asp:Label>

          </td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label2" CssClass="infotext3" runat="server">
          <p style="text-align:justify">It is not a scholarship fund and is not need-based. Our goal is to engage families who are considering sending their children to camp and, in effect, to give them $1,000 off their camp fee to try a Jewish one.</p>
                  <p style="text-align:justify">One Happy Camper grants are awarded to first-time campers who attend a nonprofit Jewish overnight summer camp for at least 19 consecutive days. Eligible campers must be entering grades 3-11 (after camp) and be attending one of the 150+ non-profit, Jewish, overnight summer camp listed on the Foundation for Jewish Camp’s website (<a href="http://www.jewishcamp.org/camps" target= "_blank">www.jewishcamp.org/camps</a>). </b></p>            
            </asp:Label></td>
        </tr>  
        <tr>
          <td colspan="2"><asp:Label ID="Label4" CssClass="infotext3" runat="server">
                  <p style="text-align: center">A NOTE TO JEWISH EXPERIENCE GRANT RECIPIENTS!</p>            
                  <p style="text-align: center">If you have <u>previously</u> received a Jewish Experience Grant from the Jewish Federation of Omaha, do not proceed with this application. Instead, please contact Mary Sue Grossman at 402-334-6445 or <a href="mailto:mgrossman@jewishomaha.org">mgrossman@jewishomaha.org</a></p>   
            </asp:Label></td>
        </tr>           
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you are currently enrolled in Jewish day school or yeshiva, please contact the Jewish Federation of Omaha directly to learn about incentive grant opportunities. Please do not proceed with this application.</p>
                </asp:Label></td></tr>
                 <tr>
                <td colspan="2">
                <asp:Label ID="Label3" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance or are interested in learning about financial-need based scholarship - please call your community professional listed at the bottom of this page.</p>
                </asp:Label></td></tr>
               
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">            
            <tr>
                <td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2"><br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                            <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                                </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn"  OnClick="btnNext_Click" /></td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>
</asp:Content>
