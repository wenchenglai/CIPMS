<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Nageela_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
            <td>
                <img src="logo.png" />
            </td>
        </tr>
        <tr>
			<td>
                <p>
					Good news! You may be eligible for a One Happy Camper grant.
				</p>
				<p>
				    The Foundation for Jewish Camp, in partnership with Camp Shomria offers an incentive program that is open to campers who live anywhere in North America! 
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
                    If you are interested in learning more about our Camp Shomria and our scholarship program, please visit us at: www.campshomria.org. Or call us at 212-627-2830
                </p> 
                <p>
                    Camp Shomria is our kibbutz-style camp located in the Catskills. We play games, we grow vegetables, we swim, we build fires, and create art projects, but what makes our camp unique is our culture. At Camp Shomria campers get to create their own world and become empowered over their lives and education. Whether it’s drama games or interactive discussions about social issues in Israel or in the U.S., our programming lets the youth grow into independent and critical thinking people. We believe that learning should be hands-on, youth-centered, and cooperative; and at Camp Shomria we strive to provide that kind of experience. 
                </p>
                <p>
                    <span style="font-weight:bold">Not Just a Summer Camp</span>
                    <br />
                    We believe that education is not just a summer thing.
Meet your friends and madrichim at your local “Ken”. The Ken is our year round activities taking place in NYC, NJ, Philadelphia and DC. It gives Hashomer Hatzair and Camp Shomria an opportunity to run our creative ‘youth-leading-youth’ programs and activities not just during the summer, but also during year and close to home! We also have short weekend camps in the fall, winter and spring.

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

