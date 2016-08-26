<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_JCC_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
			<td>
                <img src="../../images/Camp JCA Shalom.jpg" /></td>
            <td>
                <p>
                    Good news! You may be eligible for a One Happy Camper grant. 
                </p>
                <p>
                    The Foundation for Jewish Camp, in partnership with Camp JCA Shalom offers an incentive program that is open to campers who live anywhere in North America!
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
                        <li>First time camper must be entering grades 2-12 (after camp).</li>
                    </ul>
		        </p>                
		        <p>
		            If you are interested in learning more about our camps and other available grants, 
                    please visit us at: <a href="http://www.campjcashalom.com" target="_blank">www.campjcashalom.com</a>. Or call our registrar at (818) 889-5500 ext. 102.
		        </p>
                <p>
                    For over 60 years, Camp JCA Shalom has been the “Camp for All Seasons.” Winter, Spring, Summer and Fall, 
                    thousands of campers and staff experience the magic of Camp JCA Shalom. Camp’s vision of Tikkun Olam - 
                    creating a better world is fulfilled through a positive Jewish living experience in the natural setting of the Shalom Institute. 
                    In our warm and supportive environment, campers experience living, learning and playing in a group setting that encourages personal growth and self-discovery.
                </p>
                <p>
                    Campers also have fun! They participate in a variety of programs and activities daily, they make new and lasting friendships, and develop 
                    a wealth of new skills and interests. Our campers go home with a lifetime of cherished memories, new skills, and a positive self-image. 
                    It is truly an unforgettable experience for all!
                </p>
                <p>
                    <span style="font-weight: bold;">Summers are for kids!</span><br /><br /> 
                    Something special happens when children spend a few weeks away from home at Camp JCA Shalom. Every child feels a part of a very special family. 
                    Learning to share, making decisions, and experiencing independence are all part of a magical Camp JCA Shalom summer.
                </p>
                <p>
                    	We offer a two week session for children entering grades 2-8, three-week sessions for children entering grades 5-8, 
						a one week end-of-the summer “bonus” session for children entering grades 2-8, special one-week mini-camps for 
						children entering grades 2-6, and a variety of programs for teens entering grades 9-12. Check out our schedule, 
						programs, and teen programs at <a href="http://www.campjcashalom.com" target="_blank">www.campjcashalom.com</a>. 
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

