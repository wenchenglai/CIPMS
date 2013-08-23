<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Barney_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img src="../../images/CBMlogo.jpg" />
            </td>
			<td>
				<asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="lblPopup1">
						Good news! You may be eligible for an incentive.
                    </p>
                </asp:Label>
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
					</p>
				</asp:Label>
            </td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label1" CssClass="infotext3" runat="server">
          <p style="text-align:justify">
                     <b>The Camp Barney Medintz One Happy Camper Program, sponsored by Camp Barney Medintz and the Foundation for Jewish Camp provides financial incentives of $1,000 to first-time campers who attend CBM for at least 19 days. Eligible campers must be entering grades 3-10 (after camp).</b></p>
                <p style="text-align:justify">
                 Camp Barney Medintz (CBM), the resident camp of the Marcus Jewish Community Center of Atlanta (MJCCA), is located on 500 acres in the beautiful North Georgia Blue Ridge Mountains and serves 1,200 boys and girls (8-16) from Atlanta and across the country each summer. The ACA-accredited camp has been the leader in Jewish overnight camping in North America since 1963, offering the most meaningful and culturally Jewish experience (Kosher) under the supervision of a talented, conscientious, enthusiastic, warm, and loving staff. Every imaginable activity is offered including: waterskiing, swimming, rafting, sports, mountain biking, scuba, martial arts, ropes course, wilderness trips, music, dance, theater, crafts, radio studio, movie studio, Israeli culture, and social action programs.
                 </p>
            </asp:Label></td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label2" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                Atlanta residents who are MJCCA members but are ineligible for the incentive grant, may be eligible for financial assistance from the MJCCA to attend camp. For more information about financial assistance, contact: Barbara Vahaba at <a href="mailto:barbara.vahaba@atlantajcc.org" target="_blank">barbara.vahaba@atlantajcc.org</a>. If you are interested in learning more about Camp Barney Medintz, please visit us at: <a href="http://www.campbarney.org" target="_blank">www.campbarney.org</a></p>
            </asp:Label></td>
        </tr> 
        <tr>
          <td colspan="2"><asp:Label ID="Label3" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                If you need additional assistance, please call the camp professional listed at the bottom of this page.</p>
            </asp:Label></td>
        </tr>
    </table>
	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img src="../../images/CBMlogo.jpg" />
            </td>
			<td>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label6" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<b>
							For further information on how to apply for the Camp Barney Medintz One Happy Camper grant,  please contact Barbara Vahaba at 678-812-4142 
							or <a href="mailto:Barbara.Vahaba@atlantajcc.org">Barbara.Vahaba@atlantajcc.org</a>.
						</b>
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
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
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

