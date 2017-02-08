<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Cleveland_Summary" %>

<asp:Content ID="Cleveland_Summary" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td align="center">
                <img id="logo" src="../../images/JFC_logo.jpg" alt="" />
                <img id="Img1" src="../../images/JECCBLKS.jpg" alt="" height="85" width="90" />
            </td>
            <td>
                <p>Good news! You may be eligible for a One Happy Camper grant.</p>
	        </td>
        </tr>   
        <tr>
			<td colspan="2">
				<p>
                    <span style="color:red; font-weight:bold">Attention Jewish Day School families:  </span> <span style="font-weight:bold">
                            If the camper currently attends Jewish Day School, please do NOT proceed with this application and instead click    
                            </span><a href="https://goi.jecc.org/CampForm.aspx" target="_blank">here</a>.
				</p>
                <p>
                    All other families, to determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
                </p>
                <p>
                    The Michael and Anita Siegal One Happy Camper program administered by the Jewish Education Center of Cleveland (JECC) and supported 
                    by the Foundation for Jewish Camp and the Endowment Fund of the Jewish Federation of Cleveland, Madav IX Foundation, 
                    a supporting foundation of the Jewish Federation of Cleveland, Congregations and several anonymous donors, awards up to $1000 to first-time campers. 
                </p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>First time camper must be entering grades 4-12 (after camp).</li>
                        <li>Must attend one of the Cleveland-approved non-profit Jewish overnight camps.</li>
                        <li>Multiple children from a single family are eligible to receive funds.</li>
                    </ul>
				</p>   
                <p>
                    If you do not think that you are eligible for this program, but are interested in learning about camp funding opportunities, 
                    please visit <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a>, or contact the camp of your choice.                 
                </p>
                <p>
                    If you need additional assistance, please call your community professional listed at the bottom of this page.
                </p>
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
