<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Admah_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
			<td>
				<img src="../../images/SanFrancisco.jpg" width="280" alt=""  />
			</td>
			<td>
                <p>Good news! You may be eligible for a One Happy Camper grant.</p>    
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<p>
                    The Jewish Community Federation of San Francisco, the Peninsula, Marin and Sonoma Counties, in partnership with the Foundation for Jewish Camp, 
                    offers funding to children in our community who wish to attend Jewish overnight camp for the first-time.
				</p>
                <p>
                    To determine if you are eligible for this special One Happy Camper grant, please read below. 
                    If you believe that your camper meets the criteria, please proceed with the application by clicking the next button below.                    
                </p>
                <p>
                    <span style="font-weight: bold;">The San Francisco-based Jewish Community Federation & Endowment Fund�s One Happy Camper program provides grants to encourage children 
                    to attend Jewish overnight camp for the first-time. <span style="text-decoration: underline">It is not a scholarship fund and is not needs-based</span>. 
                    Our goal is to engage families 
                    who are considering sending their children to camp and, in effect, to give them up to $1,000 off their camp fee 
                    (depending on the length of session) to try a Jewish one. </span>
                </p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 1-12 (after camp).</li>
                        <li>Not previously attended Jewish overnight camp for more than 5 days.</li>
                        <li>Attending one of the 155+ non-profit, Jewish, overnight camps listed on the Foundation for Jewish Camp�s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).</li>
                    </ul>
				</p>
                <p>
                    <span style="color:red; font-weight:bold" >Attention Jewish Day School families: </span>
                    Children currently enrolled in a Jewish Day School are now eligible for the San Francisco One Happy Camper program. There are a limited number of grants available and they are first-come, first-serve. Please continue with this application by clicking NEXT.
                </p>  
                <p>
                    If your child is not eligible and/or you are interested in learning about financial need-based grants or other camper funding opportunities please visit
                     <a href="http://www.jewishfed.org/how-we-help/scholarships/overnight-camp-scholarships-and-grants" target="_blank">www.jewishfed.org/how-we-help/scholarships/overnight-camp-scholarships-and-grants</a>, 
                     or contact your community professional listed at the bottom of this page.              
                </p>
			</td>
		</tr>		
	</table>

	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="../../images/SanFrancisco.jpg" width="280" alt=""  />
			</td>
        </tr>
        <tr>
			<td>
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
                        The Jewish Community Federation of San Francisco, the Peninsula, Marin and Sonoma Counties One Happy Camper program is now closed for summer 2017. For more information, please contact Aiko-Sophie Morrissette-Ezaki at Aiko-SophieM@sfjcf.org. To see if your camp sponsors the One Happy Camper program please click the "next" button at the bottom of the screen.
					</p>
				</asp:Label>
			</td>
		</tr>
	</table>
    
	<asp:Panel ID="Panel1" runat="server">
		<table width="100%" cellpadding="1" cellspacing="0" border="0">            
			<tr>
				<td valign="top" style="width:5%">
					<asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label>
				</td>
				<td valign="top" ><br />
					<table width="100%" cellspacing="0" cellpadding="0" border="0">
						<tr>
							<td  align="left">
								<asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" />
							</td>
							<td>
								<asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" />
							</td>
							<td align="center">
								<asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
							</td>
							<td align="right">
								<asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" />
							</td>                            
						</tr>
					</table>
				</td>
			</tr>
		</table>        
	</asp:Panel>
</asp:Content>

