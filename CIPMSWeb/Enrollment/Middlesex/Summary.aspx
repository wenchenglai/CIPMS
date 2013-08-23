<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Middlesex_Summary" %>

<asp:Content ID="MiddleSex_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="logo" src="../../images/middlesex.jpg" /></td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="lblPopup1">Good news! You may be eligible for an incentive.</p></asp:Label>
                    
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p>To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.</p></asp:Label></td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label1" CssClass="infotext3" runat="server">
                  <p style="text-align:justify">The Middlesex One Happy Camper program, sponsored by the Dave and Ceil Pavlovsky Endowment Fund for Jewish Education of the Jewish Federation of Greater Middlesex County and the Foundation for Jewish Camp, provides grants of up to $1,000 to any first-time Jewish overnight camper residing in Greater Middlesex County, as defined by The Jewish Federation service area. </p>    
                              
                <p style="text-align:justify">Current day school students are NOT eligible for these grants.</p>  
                 <p style="text-align:justify">Eligible camp sessions must be a minimum of 19 consecutive days. A first-time camper is defined as a camper entering grades 3-11 (after camp), who has not previously spent more than two consecutive weeks as an overnight camper at a Jewish camp.</p>
                  <p style="text-align:justify">Multiple campers (siblings) from a single family are eligible to receive separate grants. This grant is NOT based on financial need. The grant is available whether or not the camper or camper’s family has received other partial scholarships or other partial financial aid. Those in receipt of full scholarships from other sources are NOT eligible.</p> 
                
                <p style="text-align:justify">Applicants will be informed of their grant approval and will subsequently need to provide the Federation with their camp enrollment letter. No funds will be disbursed to any camp until verification of acceptance is submitted to the Federation. The Federation will make grant payments for camp tuition directly to the applicable Jewish camp as listed on the Foundation for Jewish Camp’s website (<a href="http:\\www.jewishcamp.org/camps" target= "_blank">www.jewishcamp.org/camps</a>).</p> 
                             
                <p style="text-align:justify">All One Happy Camper related questions should be directed to the Jewish Federation of Greater Middlesex County at 732-588-1810 or via email at <a href="mailto:mharris@jf-gmc.org">mharris@jf-gmc.org</a>.</p>
                                
            </asp:Label></td>
        </tr>        
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call your community professional listed at the bottom of this page.</p>
                </asp:Label></td></tr>
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img id="Img1" src="../../images/middlesex.jpg" />
            </td>
            <td>                  
                <asp:Label ID="Label3" runat="server" CssClass="infotext3">
                    <p>
						The Jewish Federation of Greater Middlesex County One Happy Camper Program is closed for Summer 2012. Have a happy camp season.<br /><br />
						Please click “Next” to see if you are eligible for a different One Happy Camper program.
                    </p>
                </asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">            
            <tr>
                <td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top"><br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                                </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >>" CssClass="submitbtn" OnClick="btnNext_Click" /></td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>
</asp:Content>
