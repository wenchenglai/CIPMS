<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Habonim_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="imgLogo" src="../../images/Camp Galil.jpg" alt="" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify"><b>Good news! You may be eligible for an incentive.</p>
                </asp:Label>       
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
					<p style="text-align:justify" class="infotext3">
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
					</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label1" runat="server" CssClass="infotext3">
					<p style="text-align:justify">
						<b>The Habomin Dror One Happy Camper Program, sponsored by the Habonim Dror Camp Association and the Foundation for Jewish Camp, 
						provides grants of up to $1,000 to first-time campers who attend any of our seven Habonim Dror overnight summer camps for at least 19 consecutive days. 
						Campers who attend our western camps, Camp Gilboa (CA) or Camp Miriam (BC), are eligible for a $700 grant if they attend camp for 12-<asp:Label ID="lblDaysEnd" Text="18" runat="server" /> consecutive days. 
						Eligible campers must be entering grades <asp:Label id="lblGrade" runat="server" Text="3 - 10" /> (after camp) and attending one of our 7 camps in the summer of 2014, including:</b>
					</p>
				</asp:Label>
			</td> 
        </tr>                   
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" runat="server" CssClass="infotext3">
					<ul>
						<li id="liTriState" runat="server">Greater Philadelphia Tri-State area - <a href="http://www.campgalil.org" target="_blank">Habonim Dror Camp Galil</a></li>
						<li id="liDelaware" runat="server" visible="false">Greater Philadelphia, New Jersey, New York, and Delaware - <a href="http://www.campgalil.org" target="_blank">Habonim Dror Camp Galil</a></li>
						<li>Eastern Canada and upstate New York - <a href="http://www.campgesher.com" target="_blank">Habonim Dror Camp Gesher</a></li>
						<li>California and the Southwest - <a href="http://www.campgilboa.org" target="_blank">Habonim Dror Camp Gilboa</a></li>
						<li>Greater Vancouver, Western Canada and the Northwest U.S. - <a href="http://campmiriam.org" target="_blank">Habonim Dror Camp Miriam</a></li>
						<li>The Baltimore-Washington region and the Southeastern U.S. - <a href="http://campmosh.org/page.php?id=2" target="_blank">Habonim Dror Camp Moshava</a></li>
						<li>The Greater New York region and New England - <a href="http://www.naaleh.org" target="_blank">Habonim Dror Camp Naleeh</a></li>
						<li>Chicago, Detroit and the Greater Midwest - <a href="http://www.camptavor.org" target="_blank">Habonim Dror Camp Tavor</a></li>                                           
					</ul>                        
				</asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="infotext3">
                <p style="text-align:justify">Note: This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish educational experience.  As such, children who attend Jewish Day School or Yeshiva are not eligible for this grant.</p>
                <p style="text-align:justify">At our Habonim Dror camps young people learn the values and skills needed for community building and leadership, independent thinking, a strong connection to Israel, and lifelong Jewish identity.  Our Israeli model embeds campers in an environment of informal Jewish education that blurs the boundary between learning and having fun so that both can occur simultaneously</p>
                <p style="text-align:justify">Habonim Dror campers become legendary Israeli dancers and revel in singing Israeli songs from every generation.  We have creative Shabbat observances, conversational Hebrew and delicious kosher meals (supplemented by camper-grown food from each camp's organic gardens).  Habonim Dror campers are known for their daily avodah (work periods) in their organic gardens and in other camp maintenance chores and they enjoy such traditional camp activities such as swimming, ultimate, basketball, hiking, drama, climbing and ropes course</p>
                <p style="text-align:justify">Campers may begin attending camp following second or third grade at any of Habonim Dror's 7 regional camps spread 
                    across North America.  Habonim Dror is the Zionist Youth Movement affiliated with the <asp:Label ID="lblOrgName" runat="server" Text="United Kibbutz" /> Movement of Israel.  Habonim Dror campers come from all parts of the Jewish community - Conservative, Reform, Reconstructionist, Jewish Renewal, secular, Chabad, modern Orthodox and unaffiliated.</p>
                <p style="text-align:justify">If you are interested in learning more about our camps and available grants at a specific camp, please visit the individual camp websites by clicking on the camp names above.</p>
                
                    <p style="text-align:justify">If you need additional assistance, please call the camp professional listed at the bottom of this page.</p>
                </asp:Label></td>
        </tr>
    </table>

    <table id="tblDisable" runat="server" visible="false" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="ImgLogoDisable" runat="server" /></td>
            <td>
                
			</td>
        </tr>
        <tr>
           <td colspan="2">
               <br />
               <asp:Label ID="lblDisable" runat="server" CssClass="infotext3" Font-Bold="true" Font-Size="Small" />
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
                                    CssClass="submitbtn" OnClick="btnNext_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
