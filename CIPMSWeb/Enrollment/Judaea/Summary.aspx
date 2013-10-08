<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Judaea_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img src="../../images/judaeacamp.jpg" /></td>
            <td>
				<asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify" class="infotext3"><b>Good news! You may be eligible for an incentive.</b></p>
				</asp:Label>
                <asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
					</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext4">
                    <p style="text-align:justify"> 
						<b>The Young Judaea One Happy Camper Program, sponsored by Young Judaea with funding from the Foundation for 
						Jewish Camp offers incentives of $1,000 to first-time campers who attend one of our nonprofit Jewish overnight summer camps 
						for at least 19 consecutive days. Eligible campers must be entering grades 2-11 (after camp) and attending one of our camps, 
						including Camp Judaea (Hendersonville, NC), Camp Young Judaea Midwest (Waupaca, WI), Camp Young Judaea Sprout Lake (Verbank, NY), 
						Camp Young Judaea Texas (Wimberley, TX), and our senior leadership camp, Camp Tel Yehudah (Barryville, NY).</b> 
                    </p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label4" runat="server" CssClass="infotext4">
                    <p style="text-align:justify" >
						At Young Judaea camps, young people can count on having an experience that develops independence, strong connections with Israel, 
						and lifelong Jewish identity. Young Judaea camps provide an environment of informal Jewish education where both learning and having 
						fun are high on the agenda. In addition to engaging in Israeli song and dance, pluralistic prayer, conversational Hebrew and delicious 
						kosher meals, Young Judaeans enjoy activities such as swimming, basketball, hiking, climbing and ropes course. 
						Campers begin their experience in second or third grade at one of Young Judaea’s four regional camps. Teens attending high school 
						are eligible to attend Camp Tel Yehudah, Young Judaea’s National Senior Leadership camp in Barryville, NY, where generations of 
						Jewish activists, educators and leaders got their start while making friendships that last a lifetime. Young Judaea is the oldest
						Zionist Youth Movement in the United States and has been running quality Jewish camping programs since 1948.</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" runat="server" CssClass="infotext4">
                    <p style="text-align:justify" >
						This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. 
						As such, children who attend Jewish day school or Yeshiva are not eligible for this incentive program.</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" CssClass="infotext4" runat="server">
                <p style="text-align:justify">If you are interested in learning more about our camps and available grants, please visit us at: 
                <a href="http://www.youngjudaea.org/cip" target="_blank">www.youngjudaea.org/cip</a> 
                or visit the camp websites by clicking on the camp names below: </p>
                </asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" runat="server" CssClass="infotext4">
                    <p style="text-align:justify">
                        <b><a href="http://www.cyjmid.org" target="_blank">Camp Young Judaea Midwest</a></b>  (Waupaca,Wisconsin)<br />
                        <b><a href="http://www.cyjtexas.org" target="_blank">Camp Young Judaea Texas</a></b>  (Wimberley, TX)<br />
                        <b><a href="http://www.campjudaea.org" target="_blank">Camp Judaea</a></b> (Hendersonville, North Carolina)<br />
                        <b><a href="http://www.cyjsl.org" target="_blank">Camp Young Judaea Sprout Lake</a></b> (Verbank, New York)<br />
                        <b><a href="http://www.campty.com" target="_blank">Camp Tel Yehudah</a></b>(Barryville, New York)<br />
                </p></asp:Label>
            </td>
        </tr>
        <%--<tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText" Visible="false"><br />
                    <p style="text-align:justify">If you need immediate assistance, please contact:<br />
                    <br />Blair Gershenson 
                    <br />Young Judaea                      
                    <br /><a href="mailto:bgershenson@youngjudaea.org">bgershenson@youngjudaea.org.</a>
                    <br />212-303-4566
                    </p>
                </asp:Label>
                <asp:Repeater ID="rptCampContact" runat="server" OnItemDataBound="rptCampContact_ItemDataBound">
                    <HeaderTemplate>
                        <p class="QuestionText" style="text-align: justify">
                            If you need immediate assistance, please contact:<br />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <br />
                        <asp:Label runat="server" ID="lblFederationName"></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="lblContactName"></asp:Label>
                        <br />
                        <asp:HyperLink ID="hprLnkContactEmail" runat="server"></asp:HyperLink>
                        <br />
                        <asp:Label runat="server" ID="lblContactNo"></asp:Label>                        
                    </ItemTemplate>
                    <FooterTemplate>
                        </p>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>--%>
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img src="../../images/judaeacamp.jpg" /></td>
            <td>
				<asp:Label ID="Label6" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify" class="infotext3"><b>The Young Judaea One Happy Camper program is now closed for summer 2013. For more information, please contact the camp professional listed at the bottom of this page.</b></p>
				</asp:Label>
                <asp:Label ID="Label7" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						
					</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label8" runat="server" CssClass="infotext4">
                    <p style="text-align:justify"> 
If you are interested in learning more about our camps and available grants, please visit us at: www.youngjudaea.org/cip or visit the camp websites by clicking on the camp names below:
<br /><br />
<a href="http://www.cyjmid.org/" target="_blank">Camp Young Judaea Midwest</a> (Waupaca,Wisconsin)<br />
<a href="http://www.cyjtexas.org/" target="_blank">Camp Young Judaea Texas</a> (Wimberley, TX)<br />
<a href="http://www.campjudaea.org/" target="_blank">Camp Judaea</a> (Hendersonville, North Carolina)<br />
<a href="http://www.cyjsproutlake.org/" target="_blank">Camp Young Judaea Sprout Lake</a> (Verbank, New York)<br />
<a href="http://telyehudah.wordpress.com/" target="_blank">Camp Tel Yehudah</a> (Barryville, New York)<br />       
                    </p>                    
                </asp:Label>
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
                                    CssClass="submitbtn1" /></td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> "
                                    CssClass="submitbtn" OnClick="btnNext_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
