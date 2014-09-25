<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Nageela_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
            <td>
                <img src="../../images/Camp_Nageela_Logo.JPG" />
            </td>
            <td>
                <p>
					Good news! You may be eligible for a One Happy Camper grant.
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
                    The Camp Nageela One Happy Camper program, sponsored by Camp Nageela and the Foundation for Jewish Camp offers incentives.
				</p>
		        <p>
			        The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>First time camper must be entering grades 3-11 (after camp).</li>
                    </ul>
		        </p>                
		        <p>
		            Situated on our campus of 500+ breathtaking acres in rural Indiana, Camp Nageela Midwest is an extraordinary three-week experience of fun and unforgettable memories. Our extensive daily schedule is a camper’s dream and includes both traditional and specialty camp activities and surprises. Camp Nageela is ACA accredited, with separate gender sessions giving every child the opportunity to thrive in a low-pressure environment. Campers in Camp Nageela come from over 25 states and identify with all Jewish affiliations. Staff members practice traditional Jewish observance and are selected for their passion to live by its values of caring, warmth, and joy of living. Be sure to check out our first-time camper incentive grant opportunities! Additional scholarships are available as well.
		        </p>
                <p>
                   Learn More: <a href="http://campnageelamidwest.org" target="_blank">camp website</a>  • dates & rates 
                </p>
                <p>
                    If you are interested in learning more about our camps and other available grants, and our many and varied year-round programs, please call Rabbi David Shenker at (516) 374-1528 Ext 103.
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

