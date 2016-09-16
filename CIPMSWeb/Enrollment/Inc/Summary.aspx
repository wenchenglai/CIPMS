<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Nageela_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
            <td>
                <img src="logo.jpg" />
            </td>
            <td>
                <p>
					Good news! You may be eligible for an incentive.
				</p>
                <p>
					To determine if you are eligible continue reading and if your camper meets the eligibility criteria, 
					please proceed by clicking the "next" button below.
				</p>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<p>
				    Camp Inc. Business Academy is proud to partner with the Foundation for Jewish Camp and offer One Happy Camper incentive grants to campers anywhere in North America. 
				</p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 6-12 (after camp).</li>
                    </ul>
				</p>   
                <p>
                    Camp Inc. Business Academy. is a Jewish overnight camp in Steamboat Springs, CO where 6th-12th graders from around the world join together to explore business, entrepreneurship and technology. Campers choose a track to focus on from either CEO/CFO (leadership and finance), CTO (coding and technology), or CMO (marketing and design). They spend part of their day developing skills in their core track, and part of the day coming together to launch a startup in teams of 3-5 campers. Camp Inc. campers develop community, confidence, leadership, and Jewish identity through these hands-on experiences, interactions with professional business mentors, exciting company tours, and daily recreation in rock climbing, boating, swimming, hiking, gaga, volleyball, arts and crafts, music and more.
                </p> 
                <p>
                    Camp Inc. offers sessions for entering 6th through 12th grade campers. 
                </p>
                <p>
                    If you are interested in learning more about Camp Inc. and other discounts and scholarships, please visit us at: 
                    <a href="http://www.CampInc.com" target="_blank">www.CampInc.com</a> or call 303-500-3020.
                </p>           
            </td>
        </tr>  
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">            
            <tr>
                <td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" ><br />
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

