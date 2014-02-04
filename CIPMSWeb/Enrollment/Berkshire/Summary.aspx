<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Admah_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
     <table width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img src="logo.jpg" alt=""  /></td>
            <td>
				<asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify">Good news! You may be eligible for an incentive.</p>
                </asp:Label>
                <asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, 
						please proceed by clicking the "next" button below.</p>
				</asp:Label>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Berkshire Hills is a coed, Jewish sleep away camp for children ages 7-16.  Set in the beautiful Berkshires, our camp provides 
						an idyllic setting for your child’s summer of growth and fun. At Berkshire Hills, your child will find a strong community of 
						friends, be supported by loyal and deeply committed staff, try fun and challenging activities, and become more independent. 
						We offer two, four and seven and a half week sessions to fit every families’ summer schedule.
					</p>
					<p style="text-align:justify">
                        At Berkshire Hills, we use the lens of Jewish teaching and the experience of group living to build a strong community that 
                        reflects traditional Jewish values. While we use Jewish language to talk about these values, we believe strongly that every 
                        child - regardless of their religion or background - benefits from learning about Integrity (Yosher), Respect (Kavod), 
                        Repairing the World (TikunOlam), Joy (Simcha), Acts of Loving Kindness (GemiluteChasadim), Nature (Teva), Spirit (Ruach), 
                        and Connection to Friends (Divikute Chaverim). Therefore, we welcome all children - Jewish and non-Jewish with open arms. 
					</p>
					<p style="text-align:justify">
                        Like all learning at camp, these values are not taught in a classroom - but on the ball field, in a dance class, and around 
                        campfires. In this way, campers not only learn about these values but they live them. Our top priority is to create a safe, 
                        supportive and loving environment for every child and our Berkshire Hills campers thrive as a result. 
					</p>					
				</asp:Label>
             </td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label2" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                 If you are interested in learning more about our camp and available grants, please visit us at   
                 <a href="http://www.bhecamps.com/" target="_blank">www.bhecamps.com</a>
                 or contact Adam Weinstein at <a href="mailto:info@bhecamps.com" target="_blank">info@bhecamps.com</a>.
                 </p>
            </asp:Label></td>
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

