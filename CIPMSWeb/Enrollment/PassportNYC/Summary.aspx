<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Chi_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img src="../../images/PassportNYC.jpg" width="250px" height="120px"/>
            </td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="lblPopup1">Good news! You may be eligible for an incentive.</p>
                </asp:Label>
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
					<p style="text-align:justify">
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, 
						please proceed by clicking the "next" button below.
					</p>
				</asp:Label>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<b>The Passport NYC One Happy Camper Program, sponsored by Passport NYC and the Foundation for Jewish Camp provides financial 
						incentives of $1,000 to first-time campers who attend Passport NYC, a nonprofit Jewish overnight camp for at least 19 consecutive days. 
						Eligible campers must be entering grades 9-12 (after camp).</b>
					</p>
				</asp:Label>
			</td>
        </tr>          
        <tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Passport NYC is the most unique and extraordinary three week, residential, Jewish, socially conscious, 
						specialty summer camp program located in the heart of New York City.  Teens entering 9th through 12th 
						grades have the opportunity to live in the dorms of 92Y, the city’s leading cultural organization and 
						follow their passion in one of five specialty camp programs; Fashion, Film, Culinary Arts, the 
						Music Industry or Musical Theater.  Our Passport NYC community engages teens in specialty areas that they are 
						interested in and provides professional opportunities to meet with exciting partners from all walks of NYC life- chefs, 
						editors, designers, music moguls and performers.  Passport NYC participants have a chance to live in NYC,  
						explore Jewish values, develop their creative self and give back through our Jewish service learning program.  
						Our Passport NYC community gives back by doing not-so-random acts of kindness while gaining real world experience 
						with hands on opportunities to interact with the community around us.  Each teen can earn up to 30 hours of 
						Community Service credit over the course of 3 weeks at Passport NYC.   Teens learn new skills, enhance their 
						spiritual growth and express themselves, their way.  We provide 3 Kosher meals a day, 7 days a week.  
						Passport NYC offers two, 3-week sessions (July and August).  Passport NYC is A Summer.  A City.  A Camp Like No Other.
					</p>
				</asp:Label>
			</td>
        </tr> 
        <tr>
          <td colspan="2"><asp:Label ID="Label3" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                If you are interested in learning more about our camps and available grants, please visit us at <a href="http://www.92YPassportNYC.org" target="_blank">www.92YPassportNYC.org</a>.</p>
            </asp:Label></td>
        </tr>     
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call the camp professional listed at the bottom of this page.</p>
                </asp:Label></td></tr>
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

