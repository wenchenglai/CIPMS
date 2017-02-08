<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_JCC_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
			<td>
                <img src="logo.png" />
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
                    The JCC Ranch Camp One Happy Camper Program Sponsored by JCC Ranch Camp and the Foundation for Jewish Camp awards incentive grants up to $1,000 to first time campers.
				</p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 2-10 (after camp).</li>
                    </ul>
				</p>   
                <p>
                    This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. 
                    As such, children who attend Jewish Day School or yeshiva should contact us at 303-316-6384 for additional scholarship and grant opportunities.
                </p> 
                <p>
                    Since 1953, the Ranch Camp has served thousands of campers. The camp, which is owned and operated by the Robert E. Loup Jewish Community Center in Denver, 
                    CO, is open to children entering grades 2 through 10 with special programs designed for each age. Campers reside in log cabins in groups of ten to twelve with three to four counselors. All buildings are within a central area surrounded by hundreds of pine-shaded spots for hiking, climbing, camping, and exploring. The facility includes a corral that houses over 40 horses during the summer, providing for one of the best equestrian programs to be found in a Jewish camp setting nationwide. JCC Ranch Camp also offers a heated outdoor swimming pool, a technical rock climbing wall, a low-elements ropes course, a high-elements challenge course and zip line, a sports field and basketball court, nature and crafts center, and miles and miles of beautiful trails on a 400-acre ranch.
                </p>
                <p>
                    Campers come from more than 25 states and several foreign countries to attend this camp in a unique Colorado ranch setting. Staff also comes 
                    from throughout the United States and countries throughout the world. All staff members are selected based on their experience with children and their 
                    commitment to making a positive difference in the lives of campers. Strict background screening policies are followed in the selection process as well. 
                    The JCC Ranch Camp connects children - mind, body, and spirit - to their Jewish heritage, Jewish friends, and the natural world around them.
                </p>
                <p>
                    If you need additional assistance, please call the camp professional listed at the bottom of this page.
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

