<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Capital_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
     <table width="100%" cellpadding="5" cellspacing="0">
		<tr>
            <td>
                <img src="../../images/Capital Camps.jpg" alt="" />
            </td>
            <td>
				<asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
					<p style="text-align:justify">Good news! You may be eligible for an incentive grant.</p>
				</asp:Label>
                <asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
					</p> 
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblLable" CssClass="infotext3" runat="server">
                    <p style="text-align:justify">
						The Capital Camps One Happy Camper program, sponsored by Capital Camps offers grants of $1,000 to first time campers who will be attending 
						Capital Camps for the first time for at least 19 consecutive days. If you are unsure of your eligibility, 
						please contact our Camp Team at <a href="mailto:info@capitalcamps.org" target="_blank">info@capitalcamps.org</a> or 866-430-2267.
					</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Capital Camps is the Jewish Community Overnight Camp of the mid-Atlantic region. We have provided quality Jewish camping in a warm nurturing environment 
						for the past 25 years. We are located just over one hour from both Washington and Baltimore. Capital Camps is for campers entering grades 3 through 10. 
						Options include a 2-week “introductory” program for grades 3-5. We also offer a fully-mainstreamed Special Needs program. Scholarship Assistance is also 
						available.
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Our facilities are exceptional and include cabins with bathrooms, aquatics complex (heated with two 40ft water flumes, beach entry and more), 
						arts & theatre building, ropes challenge course (with 2 challenge towers and zip lines), tennis, volleyball and basketball courts, two large 
						indoor pavilions, softball field, gaga pit, lake, and much more. Activities include sports (softball, soccer, basketball, volleyball, flag football, 
						and more), swimming, fishing, boating, archery, radio, video, drama, arts & crafts, ceramics, Jewish environmental education, outdoor adventure programs, 
						trips and more. Judaic themes and programming are balanced with outstanding recreational activities. Our staff members are chosen for their love and 
						enthusiasm as well as their appropriateness as Jewish role models.</p>
				</asp:Label>
			</td>
        </tr> 
        <tr>
			<td colspan="2">
				<asp:Label ID="Label3" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Our campers are immersed in a nurturing community which is committed to providing them with experiences that build their independence, 
						strengthen their Jewish identity and create memories that will last a lifetime. 
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

