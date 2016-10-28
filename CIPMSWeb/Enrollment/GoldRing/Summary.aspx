<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
	Inherits="Enrollment_JCC_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
			<td>
				<img id="logo" src="../../images/goldring.jpg" /></td>
			<td>
				<p>
					<strong>
						Send your child to camp this summer through an exciting program underwritten by the Goldring Family Foundation and administered by the Jewish Endowment Foundation of Louisiana!
					</strong>
				</p>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<p>
                    This wonderful program, established by JEF in 1999, has been funded by the Goldring Family Foundation since 2001. Since the program’s inception, almost 1,300 children have received incentive grants to attend Jewish not-for-profit sleep-away camps. The Goldring Family Foundation wants to make this lifetime experience available to every Jewish child. Each of your children is eligible for a one-time-only incentive grant of up to $1,000* to attend a non-profit Jewish summer camp.
				</p>
				<p>
					To meet the criteria for JEF funding, children must be:
					<ul>
						<li>First-time campers at a non-profit Jewish sleep-away camp. If your child’s camp is not on the approved list, it must provide JEF with proof of its non-profit status.</li>
						<li>Currently in grades 1 through 9</li>
						<li>Residents of <strong>Louisiana, Mississippi, Alabama or northwest Florida Panhandle</strong>. Grants are not based on financial need. Both parents need not be Jewish. Temple or synagogue affiliation is not required.</li>
					</ul>
				</p>                
				<p>
                    <span color="red"><b>To apply for a Goldring Jewish Summer Camp Experience grant and see the list of camps please <asp:LinkButton ID="goldringlink" runat="server" OnClick="goldringlink_Click" Text="CLICK HERE" ></asp:LinkButton></b> </span> 
				    (Please note you will leave this website)
				</p>
				<p>
					While the Foundation for Jewish Camp (FJC) does not administer this program, we salute the work of the Goldring Family Foundation and the Jewish Endowment Foundation of Louisiana. 
                    Typically, first-time campers who receive a grant from the Goldring Family Foundation are not also eligible to get a grant from a One Happy Camper program. 
                    If you feel that you do not qualify for the Golding Family Foundation program please click 
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="goldringcontinue_Click" Text="CONTINUE" Font-Bold="True" ></asp:LinkButton> 
                    to complete your One Happy Camper application.
				</p>
				<p>
					For more information on the Goldring Jewish Summer Camp Experience incentive program please contact Ellen Abrams at 504-524-4559 or ellen@jefno.org.
				</p>
			</td>
		</tr>  
	</table>
	<asp:Panel ID="Panel1" runat="server">
		<table width="100%" cellpadding="1" cellspacing="0" border="0">
			<tr>
				<td valign="top" style="width: 5%">
					<asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
				<td valign="top">
					<br />
					<table width="100%" cellspacing="0" cellpadding="0" border="0">
						<tr>
							<td align="left">
								<asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary"
									CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
							<td>
								<asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous"
									CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
							<td align="center">
								<asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later"
									CssClass="submitbtn1" />
							</td>
							<td align="right">
								<asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> "
									CssClass="submitbtn" OnClick="btnNext_Click" Visible="false" /></td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</asp:Panel>
</asp:Content>
