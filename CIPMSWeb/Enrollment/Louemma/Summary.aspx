<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Louemma_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
     <table width="100%" cellpadding="5" cellspacing="0">
		<tr>
            <td>
                <img src="../../images/Loumea.JPG" alt="" /></td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="infotext3"><b>Good news! You may be eligible for an incentive.</b></p>
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
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						The Camp Louemma One Happy Camper program, sponsored by Camp Louemma and the Foundation for Jewish Camp offers $1,000 to each first time camper 
						who attends Camp Louemma for at least 19 consecutive days. This grant is open to campers ages 7-15 (entering grades 2-10 after the summer) 
						and is NOT NEED BASED. Where need is demonstrated, this grant may be combined with other tuition incentives and scholarship.
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						We offer an exciting and dynamic program with a wide variety of elective and scheduled activities. Our incredibly friendly, 
						nurturing and talented staff members give each camper the opportunity to explore his or her interests, 
						enhance existing talents and learn new skills. Whether it’s on our athletic fields, tennis or basketball courts, 
						private lake, swimming pool, at our theatre, mini golf course; atop our climbing tower and zip line, ropes courses, 
						or at arts & crafts/ceramics, the game room, bake shop, or radio station, our instructors focus on each camper’s personal achievement 
						while offering encouragement at the same time.
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label6" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Evenings are also a blast with pool parties (in our brand new swimming pool), Hawaiian Luaus, treasure and scavenger hunts, game show nights, talent shows, theater productions, 
						concerts and so much more!! Most of all, while we are not a religious camp, Jewish culture and identity are integrated into the program in a 
						manner that is fun, creative and entertaining. 
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label7" CssClass="infotext3" runat="server">
                <p style="text-align:justify">Through special events such as our Israel Day celebration, hands on activities including challah baking and shofar making, and guest performances by Klezmer bands, Israeli dancers and Jewish rock bands, we celebrate old and new traditions and explore our Jewish heritage. This is done in an informal and creative manner that is inclusive, comfortable and appealing to campers from various backgrounds and affiliations. We also serve delicious kosher meals in our dining room.</p>
            </asp:Label></td>
        </tr>
         <tr>
          <td colspan="2"><asp:Label ID="Label8" CssClass="infotext3" runat="server">
                <p style="text-align:justify">WE MAKE SLEEP-AWAY CAMP AFFORDABLE!! Our already reasonable tuition rates, combined with the new camper incentive program, will ensure that the costs of camp will not be a barrier to your child having the summer of his or her life.</p>
            </asp:Label></td>
        </tr>
         <tr>
          <td colspan="2"><asp:Label ID="Label9" CssClass="infotext3" runat="server" ForeColor="Red">
                <p style="text-align:justify" >If the camper currently attends Jewish day school, please do NOT continue with this application and instead, contact the camp directly at 973-287-7264.</p>
            </asp:Label></td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label2" CssClass="infotext3" runat="server">
                <p style="text-align:justify">To learn more about Camp Louemma and how we make camping affordable, visit us at 
                <a href="http://www.camplouemma.com" target="_blank">www.camplouemma.com </a> or, better yet, call us at 973-287-7264. We love to “talk camp”.
                </p>
            </asp:Label></td>
        </tr> 
        <tr>
          <td colspan="2"><asp:Label ID="Label3" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                 </p>
            </asp:Label></td>
        </tr>     
        <!--<tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call the camp 
                    professional listed at the bottom of this page.</p>
                </asp:Label></td></tr>-->
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

