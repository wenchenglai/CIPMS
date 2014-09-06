<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Admah_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
			<td>
				<img src="../../images/EVClogo_arch_2C.jpg" alt=""  /></td>
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
			        The Eden Village One Happy Camper program sponsored by Eden Village Camp and the Foundation for Jewish Camp.
			    </p>
		        <p>
			        The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 3-12 (after camp).</li>
                        <li>If camper attended camp in the summer of 2014 for 12-18 days as a first time camper s/he is still eligible for the grant if attending camp in 2015 for 19 or more consecutive days.</li>
                    </ul>
		        </p>                
		        <p>
		            Eden Village Camp: a first-of-its-kind Jewish environmental sleep-away camp for a healthy, sustainable world! Located 50 miles north of NYC on 248 gorgeous acres touching the Appalachian Trail, Eden Village Camp is a compassionate non-profit community that supports our 3rd - 12th graders in gaining leadership and outdoor living skills, and awakening their sense of connectedness, purpose and joy. 
Eden Village Camp brings an innovative environmental program to the best of traditional camp. The experience includes organic farming, outstanding organic Kosher food, animal care, wilderness adventure, natural science, a zero-waste goal, pool & lake, climbing, music, arts, sports, service projects, amazing staff in a 3:1 camper:counselor ratio... all in a vibrant and diverse Jewish community! 
Our campers have fun while deepening their understanding and appreciation for themselves, their communities, and the natural systems that sustain us. 

		        </p>
                <p>
                    If you are interested in learning more about our camp, please go to <a href="http://www.edenvillagecamp.org" target="_blank">EdenVillageCamp.org</a>
                </p>
                <p>
                    If you need additional assistance, please call the camp professional listed at the bottom of this page.
                </p>
			</td>
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
						The Eden Village One Happy Camper program is now closed for the summer of 2014. For more information, please contact the camp professional listed at the bottom of the screen.
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
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" /></td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>
</asp:Content>

