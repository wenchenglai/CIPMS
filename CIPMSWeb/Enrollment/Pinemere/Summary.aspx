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
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<p>
                    The Foundation for Jewish Camp, in partnership with Pinemere Camp, offers an incentive program that is open to campers who live anywhere in North America!
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
                    Thank you for your interest in Pinemere Camp! Each summer we create a safe space for children where they can leave behind the hectic pace, pressure, and technology of the “real world” and just be kids. We are a dynamic community made up of campers, families, staff, and alumni from around the world. We set ourselves apart with our fun and welcoming environment, intimate cabin size, rustic setting, innovative programs, inclusive Jewish programming, and by hiring and developing the best staff in camping. Our goal is to assist campers in building friendships, acquiring new skills, fostering their Jewish identity, and to have the BEST SUMMER, EVERY SUMMER!
                </p> 
                <p>
                    We love to talk about camp and we’re happy to meet with you and your family. While the process of choosing and signing up for a camp might feel overwhelming, please know we are here to answer your questions and help you on your journey to an amazing Jewish overnight camp experience.
                </p>
                <p>
                    To learn more about Pinemere Camp, please visit us at: <a href="http://www.pinemere.com" target="_blank">www.pinemere.com</a> or call our Executive Director, Mitch Morgan, at 215-487-2267.
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

