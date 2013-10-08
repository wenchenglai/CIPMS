<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_JCC_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img src="../../images/Camp JCA Shalom.jpg" /></td>
            <td>
				<asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="infotext3">
						<b>Good news!  The Foundation for Jewish Camp, in partnership with Camp JCA Shalom offers an incentive program that is open to campers 
						who live anywhere in North America!</b>
					</p>
                </asp:Label>
                <asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						
					</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label6" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						For over 60 years, Camp JCA Shalom has been the “Camp for All Seasons.” Winter, Spring, Summer and Fall, thousands of campers and staff 
						experience the magic of Camp JCA Shalom. Camp’s vision of Tikkun Olam – creating a better world – is fulfilled through a positive 
						Jewish living experience in the natural setting of the Shalom Institute. In our warm and supportive environment, campers experience living, 
						learning and playing in a group setting that encourages personal growth and self-discovery.
					</p>
				</asp:Label>
			</td>
		</tr> 
		<tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Campers also have fun! They participate in a variety of programs and activities daily, they make new and lasting friendships, 
						and develop a wealth of new skills and interests. Our campers go home with a lifetime of cherished memories, new skills, 
						and a positive self-image. It is truly an unforgettable experience for all!
					</p>
				</asp:Label>
			</td>
        </tr> 
        <tr>
			<td colspan="2">
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<strong>Summers are for kids!</strong>
					</p>
				</asp:Label>
			</td>
        </tr> 
		<tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Something special happens when children spend a few weeks away from home at Camp JCA Shalom. 
						Every child feels a part of a very special family. Learning to share, making decisions, and experiencing independence 
						are all part of a magical Camp JCA Shalom summer.
					</p>
				</asp:Label>
			</td>
        </tr> 
		<tr>
			<td colspan="2">
				<asp:Label ID="Label3" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						We offer a two week session for children entering grades 2-8, three-week sessions for children entering grades 5-8, 
						a one week end-of-the summer “bonus” session for children entering grades 2-8, special one-week mini-camps for 
						children entering grades 2-6, and a variety of programs for teens entering grades 9-12. Check out our schedule, 
						programs, and teen programs at <a href="http://www.campjcashalom.com" target="_blank">www.campjcashalom.com</a>. 
					</p>
				</asp:Label>
			</td>
        </tr> 
		<tr>
			<td colspan="2">
				<asp:Label ID="Label7" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<strong>
						The Camp JCA Shalom One Happy Camper program provides financial incentives of $700- $1,000 to first-time campers 
						who attend our Jewish overnight summer camp for our 2 or 3-week programs (12-19 days).  Eligible campers must be entering grades 3-12 (after camp).						
						</strong>
					</p>
				</asp:Label>
			</td>
        </tr>         
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">
						If you are interested in learning more about our camps and other available grants, please visit us at:  
						<a href="http://www.campjcashalom.com" target="_blank">www.campjcashalom.com</a>. Or call our registrar at (818) 889-5500 ext. 102.						
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

