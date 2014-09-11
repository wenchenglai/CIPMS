<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Chi_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
            <tr>
            <td style="width: 147px">
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
				    The Camp Poyntelle Lewis Village One Happy Camper program, sponsored by CPLV, the UJA Federation of New York and the Foundation for Jewish Camp provides financial incentives of $1,000 to first-time campers who attend first session, second session, or the full summer. 
				</p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 3-10 (after camp).</li>
                    </ul>
				</p>   
                <p>
                    At Camp Poyntelle Lewis Village (CPLV), we pride ourselves on providing a warm, welcoming, fun and safe Jewish environment for your child. Children leave for camp looking to have fun, and return home from camp with a sense of independence, a greater understanding of kindness towards others, advanced skills in their favorite activities, a healthy attitude towards competition, and a lifetime full of memories and friendships. Located in Wayne County, PA, we are less than 150 miles from New York City. The camp features a 70 acre private lake that separates the camp into two sections; Poyntelle for boys and girls entering second grade through seventh grade, and Lewis Village for teens entering eighth grade through eleventh grade - perfect for appropriate programing and staffing. Our campers and staff love to say "we wait 10 months for 2!"
                </p> 
                <p>
                    For any further questions, feel free to contact Sarah Raful Whinston, Executive Director, at sarah@poyntelle.com.
                </p>          
            </td>
        </tr>  
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
            <tr>
            <td style="width: 147px">
                <img src="logo.jpg" />
                </td>
            <td>
                <asp:Label ID="Label3" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify"></p>   
                </asp:Label>
                <asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
                        For further information on how to apply for the Camp Poyntelle Lewis Village One Happy Camper Program, please contact the professional listed at the bottom of the screen.
					</p> 
                </asp:Label>    
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

