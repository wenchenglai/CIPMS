<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_CAiryLouise_Summary" %>

<asp:Content ID="CAityLouise_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
            <td>
                <img src="../../images/Airy Louise Logo.bmp" alt="" />
            </td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify">Good news! You may be eligible for an incentive.</p>
                </asp:Label>
                <asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, 
						please proceed by clicking the "next" button below.
					</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblLable" CssClass="infotext3" runat="server">
                    <p style="text-align:justify">
						Camps Airy and Louise are residential brother-sister camps dedicated to introducing and enhancing the Jewish experience for Jewish children. 
						Both camps are situated in the mountains of MD about 10 miles apart, with Camp Airy in Thurmont and Camp Louise in Cascade. 
						For over 90 years, camps have offered a pluralistic Jewish experience, highlighted by Shabbat dinner, Saturday morning services, 
						Israeli folk-dancing and kosher-style meals. Spanning grades 2-12, campers enjoy a wide variety of activities at each camp while gaining new skills. 
						Airy's programming includes sports teams and clinics, go-kart, outdoor adventure, paintball, instrumental music and arts & crafts. 
						Camp Louise includes activities in dance, music, theater, outdoor adventure, athletics, photography and digital video production. 
						Friendships are made and built around the pool, on the court, and by the campfire. Our program includes special trips and activities with both camps. 
						As campers enter high school, training to become counselors is considered a priority as campers are given more responsibility within the camping environment.
					</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
			<td colspan="2"><asp:Label ID="Label1" CssClass="infotext3" runat="server">
				<p style="text-align:justify">
					<b>The Camps Airy & Louise One Happy Camper program is for first-time campers enrolled in a FULL session (19 days or more) at Camps Airy & Louise. 
					These $1,000 grants will be given to campers for summer 2014 tuition who have never before attended Airy or Louise or any other non-profit Jewish overnight 
					camp for 19 days or more. The incentive grants are non-need-based and the program cannot be combined with any other camper incentive program, 
                        however it can be combined with our Early Bird rates. Campers that currently attend a Jewish Day School 
					are not eligible for this grant. Campers must consider themselves to be Jewish to be eligible. Funding is limited.</b>           
                 </p>
            </asp:Label></td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Funding and support for this program has been provided by the Aaron & Lillie Straus Foundation, private donors, and the Foundation for Jewish Camp. 
						All monies are refundable up to April 1, 2014. After April 1, there will be a $200 cancellation fee. 
						Check out our website for further information about Camps Airy and Louise and available grants 
						at <a href="http://www.airylouise.org" target="_blank">www.airylouise.org</a>. 
						Have any questions or concerns? Email us at <a href="mailto:airlou@airylouise.org" target= "_blank" >airlou@airylouise.org</a> for more information.
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call the camp professional listed at the bottom of this page.</p>
                </asp:Label>
            </td>
        </tr>
    </table>
	<table id="tblOffline" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
            <td>
                <img src="../../images/Airy Louise Logo.bmp" alt="" />
            </td>
        </tr>
        <tr>
            <td>
                <p>
                    Thank you for your interest in Camp Airy & Camp Louise's One Happy Camper Program. 
                </p>
				<p>
				    For more information, please contact Stacy Schwartz Frazier at stacy@airylouise.org or visit the Incentive page on our website:
				</p> 
                <p>
                    <a href="http://airylouise.org/general-information/one-happy-camper-tuition-incentive" target="_blank">airylouise.org/general-information/one-happy-camper-tuition-incentive</a>
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

