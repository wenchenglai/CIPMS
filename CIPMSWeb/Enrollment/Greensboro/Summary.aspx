<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Summary" %>

<asp:Content ID="Greenboro_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img id="logo" src="../../images/Greensboro_Logo.jpg" width="270" /></td> 
            <td>
                <p>Good news! You may be eligible for a One Happy Camper grant.</p>    
                <p>
				    To determine if you are eligible continue reading and if your camper meets the eligibility criteria, 
					please proceed by clicking the "next" button below.
			    </p>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<p>
				    The Greensboro One Happy Camper program, sponsored by the Greensboro Jewish Federation, Beth David Synagogue, Temple Emanuel, and the Foundation for Jewish Camp, provides financial incentives of up to $1,000 to first-time campers. 
				</p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 3-12 (after camp).</li>
                        <li>Attending one of the 155+ non-profit, Jewish, overnight camps listed on the Foundation for Jewish Camp’s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).</li>
                    </ul>
				</p>   
                <p>
                    <span style="font-weight: bold">Note:</span> 
                    Multiple children from a single family are eligible to receive separate grants. At least one parent or guardian must be a member in good standing and contribute to the Greensboro Jewish Federation in the year the grant is awarded. Members of Beth David Synagogue and Temple Emanuel are eligible to receive full incentives. Unaffiliated members may apply to the Federation and will be reviewed on a case-by-case basis.                 

                </p>
                <p>
                    If you do not think that you are eligible for this program, and/or are interested in learning about camp scholarship opportunities, 
                    please visit <a href="http://www.shalomgreensboro.org/jewish-family-services/camp-grants-and-scholarships" target="_blank">www.shalomgreensboro.org/jewish-family-services/camp-grants-and-scholarships</a> to learn about local scholarship opportunities, 
                    contact your camp or visit <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a>.
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
                <td valign="top" colspan="2"><br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                            <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                                </td>
                           <td align="right"><asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" />
                                </td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>


</asp:Content>
