<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_JCC_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img src="../../images/CMC Logo.JPG" /></td>
            <td>
				<asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="infotext3"><b>Good news! You may be eligible for an incentive.</b></p>
                </asp:Label>
                <asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label6" CssClass="infotext3" runat="server">
				<p style="text-align:justify"><b>
					The Camp Mountain Chai One Happy Camper Program, sponsored by Camp Mountain Chai and the Foundation for Jewish Camp provides financial 
					incentives of $700 for a 12 day session, or $1000 for a 19 day +session, for first-time campers entering grades 2-11 who attend Camp Mountain Chai.
					</b>
				</p>
				</asp:Label>
			</td>
        </tr> 
       <tr>
          <td colspan="2"><asp:Label ID="Label2" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                 Camp Mountain Chai expands and enriches Jewish identity by establishing an atmosphere of knowledge and love for Jewish culture, traditions and religion. Through sports, arts, outdoor adventure and aquatics, campers build life-long friendships, independence and self worth.</p>
            </asp:Label></td>
        </tr> 
        <tr>
          <td colspan="2"><asp:Label ID="Label5" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
               We provide a unique summer experience with an emphasis on excellence. Judaism is woven into the fabric of Camp Mountain Chai life as we appreciate the importance of connecting our campers to their rich Jewish heritage while understanding our collective responsibility to make the world a better place. We are proud of our well-rounded program which combines required cabin and elective activities with extensive outdoor opportunities.
                </p>
            </asp:Label></td>
        </tr> 
         <tr>
          <td colspan="2"><asp:Label ID="Label1" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                With warm days and cool nights, the weather in the San Bernardino National Forest is ideal for summer activities. Your child can comfortably participate in all our outdoor activities, and the fresh mountain air and low humidity enhance indoor activities such as cabin life, theater, creative arts and dining. 
                </p>
            </asp:Label></td>
        </tr> 
          <tr>
          <td colspan="2"><asp:Label ID="Label3" CssClass="infotext3" runat="server" >
                <p style="text-align:justify" >
            If you are currently enrolled in Jewish day school or yeshiva, please contact the Camp Mountain Chai office directly to learn about incentive grant opportunities. Please do not proceed with this application. </p>
            </asp:Label></td>
        </tr> 
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you are interested in learning more about Camp Mountain Chai and available grants, please visit us at: <a href="http://www.campmountainchai.com" target="_blank">www.campmountainchai.com</a> or call our office at 858-499-1330.</p>
                </asp:Label></td></tr>
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

