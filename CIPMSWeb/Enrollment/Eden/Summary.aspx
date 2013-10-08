<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Admah_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="../../images/EVClogo_arch_2C.jpg" alt=""  /></td>
			<td>
				<asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
					<p style="text-align:justify">Good news! You may be eligible for an incentive.</p>
				</asp:Label>
				<asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
					</p> 
				</asp:Label>
			</td>
		</tr>
		<tr>
			<td colspan="2"><asp:Label ID="Label1" CssClass="infotext3" runat="server">
				<p style="text-align:justify">
				 <b>The Eden Village One Happy Camper program sponsored by Eden Village Camp and the Foundation for Jewish Camp provides financial incentives of $1,000 to first-time campers who attend Eden Village Camp for at least 19 consecutive days. Campers from anywhere in North America are eligible. Eligible campers must be entering grades 3-12 (after camp).</b>
				 </p>
				  <p style="text-align:justify">
				 Eden Village Camp: a first-of-its-kind Jewish environmental sleep-away camp for a healthy, sustainable world! Located 50 miles north of NYC on 248 gorgeous acres touching the Appalachian Trail, Eden Village Camp is a compassionate non-profit community that supports our 3rd - 12th graders in gaining leadership and outdoor living skills, and awakening their sense of connectedness, purpose and joy. 
				  </p>
				  <p style="text-align:justify">
			Eden Village Camp brings an innovative environmental program to the best of traditional camp. The experience includes organic farming, outstanding organic Kosher food, animal care, wilderness adventure, natural science, a zero-waste goal, pool & lake, climbing, music, arts, sports, service projects, amazing staff in a 3:1 camper:counselor ratio... all in a vibrant and diverse Jewish community! </p>
			<p style="text-align:justify">
			Our campers have fun while deepening their understanding and appreciation for themselves, their communities, and the natural systems that sustain us.  
			</p>
			</asp:Label>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						If you are interested in learning more about our camp, please go to <a href="http://www.edenvillagecamp.org" target="_blank">EdenVillageCamp.org</a>
					</p>
				</asp:Label>
			</td>
		</tr> 
		<tr>
			<td colspan="2">
				<asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
					<p style="text-align:justify">If you need additional assistance, please call the camp professional listed at the bottom of this page.</p>
				</asp:Label></td>
		</tr>
	</table>
	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="../../images/EVClogo_arch_2C.jpg" alt=""  />
			</td>
			<td>
				<p class="infotext3">
					<strong>
						The Eden Village One Happy Camper Program is now closed for the summer of 2013. For more information, please contact the professional listed at the bottom of the screen.”
					</strong>
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
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " Visible="false" CssClass="submitbtn" OnClick="btnNext_Click" /></td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>
</asp:Content>

