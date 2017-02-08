<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Nageela_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
            <td>
                <img src="logo.jpg" />
            </td>
            <td>
                <p>
                    Good news! You may be eligible for a One Happy Camper grant.
                </p>
                <p>
                    To determine if you are eligible for a One Happy Camper grant please read below. If you believe that your camper meets the criteria please proceed with the application by clicking the next button below.
				</p>
            </td>
        </tr>
        <tr>
			<td colspan="2">
		        <p>
			        The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 4-11 (after camp).</li>
                        <li>Children currently enrolled in a Jewish Day School <span style="text-decoration: underline">are</span> eligible for the JCC Maccabi Sports Camp One Happy Camper program.</li>
                    </ul>
		        </p>                
		        <p>
                    JCC Maccabi Sports Camp is an overnight Jewish sports summer camp located just outside of San Francisco in Atherton, California. Our camp welcomes kids and teens in grades 4 through 11 from around the world. During our two-week camp sessions, campers learn more about their favorite sport of choice baseball, basketball, soccer, or tennis. There are also plenty of other sports and activities mixed in with the core values of a Jewish summer camp experience. 		            
		        </p>
                <p>
                    JCC Maccabi Sports Camp is the newest addition to the JCC Movement’s immensely successful programs for teens and youth - JCC Maccabi Games, JCC Maccabi ArtsFest, and JCC Maccabi Israel. Now your young athlete can enjoy all the excitement, community, and character building of the Games in a two-week summer camp where they get serious, individual instruction in their core sport plus all the fun and friendship they love about overnight camp.
                </p>
                <p>
                    Campers compete in games daily, but instead of a tournament-style program, we focus on developing athletic skills and improving as teammates. Anyone who enjoys sports and sincerely wants to advance their abilities is going to be very excited about our camp.
                </p>
                <p>
                    Like all JCC Maccabi experiences, our camp culture is guided by Jewish values. Which is also why we place a lot of emphasis on sportsmanship, ethics, and community. In fact, when you add the community-building nature of team play, we find that sports and Jewish values go hand in hand.
                </p>
                <p>
                    If you are interested in learning more about our camp and other available financial assistance, please visit us at: <a href="http://www.maccabisportscamp.org/about-camp/dates-rates/" target="_blank">www.maccabisportscamp.org/about-camp/dates-rates/</a>.
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

