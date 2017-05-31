<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Indianapolis_Summary" %>

<asp:Content ID="Indianapolis_Summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
            <td>
                <img id="logo" src="../../images/Indianapolis.jpg" />
            </td>
			<td>
                <p>Good news! You may be eligible for a One Happy Camper grant.</p>
                <p>
                    To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
                </p>
             </td>
        </tr>
        <tr>
			<td colspan="2">

                <p>
                    The Indianapolis One Happy Camper program, sponsored by the Jewish Federation of Greater Indianapolis and the Foundation for Jewish Camp, provides financial incentives of up to $1,000 to first time campers from the Greater Indianapolis area.
                </p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 3-11 (after camp).</li>
                        <li>Attending one of the 155+ non-profit, Jewish, overnight camps listed on the Foundation for Jewish Camp’s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).</li>
                        <li>Parents of participants must have contributed to the Jewish Federation of Greater Indianapolis Annual Campaign in the year that they apply for the program. </li>
                    </ul>
				</p> 
                <p>
                    <span style="color:red; font-weight:bold">Attention Jewish Day School families</span>:  
                    If the camper currently attends Jewish Day School, please do not proceed with this application and instead, please call Pamela Eicher at 317-715-6981.
                </p>  
                <p>
                    Multiple children from a single family are eligible to receive separate grants and will be considered separate grantees. At least one parent/guardian must be a member in good standing and contribute to the Jewish Federation of Greater Indianapolis in the year the grant is awarded. If you do not think you are eligible for this program, but are interested in other camp scholarship opportunities, please visit www.JewishCamp.org/Scholarships or contact the Federation directly.
                </p>
                <p>
                    If you need additional assistance, please call your community professional listed at the bottom of this page.
                </p>   
            </td>
        </tr>
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
            <td>
                <img id="Img1" src="../../images/Indianapolis.jpg" />
            </td>
</tr>
<tr>
            <td>
                <asp:Label ID="Label9" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
The Jewish Federation of Greater Indianapolis One Happy Camper program is now closed for summer 2017. For more information, please contact Pamela Eicher at peicher@jfgi.org.  To see if your camp sponsors the One Happy Camper program please click the "next" button at the bottom of the screen.
                    </p>
                </asp:Label>
			</td>
        </tr>
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
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" /></td>
                            <td align="right">
                            <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" />
                                </td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>


</asp:Content>
