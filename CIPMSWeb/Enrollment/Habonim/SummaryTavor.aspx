<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="SummaryTavor.aspx.cs"
    Inherits="Enrollment_Habonim_Tavor_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
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
						<b>The Habonim Dror Camp Tavor One Happy Camper Program, sponsored by Habonim Dror Camp Tavor $1,000 to first-time campers, 
                            first sibling in the family, who attend Habonim Dror Camp Tavor overnight summer camp for at least (19) consecutive days. 
                            (Other siblings in the same family eligible for $500 incentive). Eligible campers must be entering 3rd thru 10th grade 
                            (after camp) and attend our camp in the summer of 2014. </b>
					</p>
				</asp:Label>
			</td> 
        </tr>                   
        <tr>
            <td colspan="2">
			    <p style="text-align:justify;" class="infotext3">
                    At Habonim Dror Camp Tavor, children ages 9-16 experience a one-of-a-kind Jewish Youth community. Camp Tavor programming allows 
                    campers to build strong relationships while learning about leadership, social justice and stewarding the environment. 
                </p>
            </td>
        </tr>
        <tr>
            <td colspan="2">
			    <p style="text-align:justify;" class="infotext3">
                    Habonim Dror Camp Tavor is located about 2.5 hours from metro Detroit and 3 hours from Chicago in Three Rivers, MI. Facilities 
                    include a private campsite with its shoreline on lovely Lake Kaiser, a swimming pool, multiple sports fields, arts and crafts 
                    facilities, a music studio, and numerous hiking trails.
                </p>
            </td>
        </tr>
        <tr>
            <td colspan="2">
			    <p style="text-align:justify;" class="infotext3">
                    Camp Tavor welcomes campers from a variety of Jewish backgrounds. At Camp Tavor campers learn about Tikkun Olam, the Jewish 
                    value of repairing the world. Camp Tavor hires Israeli staff members to help campers see the beauty and complexity of Israel. 
                    All staff members work to create programs that will encourage campers to have a thoughtful relationship with Israel throughout 
                    their lives. Camp Tavor serves only kosher food and has separate dishes for meat and dairy meals.
                </p>
            </td>
        </tr>
        <tr>
            <td colspan="2">
			    <p style="text-align:justify;" class="infotext3">
                    In addition to serving Kosher food, we are a peanut-free and tree nut sensitive facility. The dining hall staff can also 
                    accommodate gluten free, vegetarian, and vegan diets.
                </p>
            </td>
        </tr>
        <tr>
            <td colspan="2">
			    <p style="text-align:justify;" class="infotext3">
                    With a 4:1 camper-to-counselor ratio, a maximum of 200 campers per session, and activities that bridge the age gap, 
                    Camp Tavor’s community is nurturing and inclusive. Its activities are individualized and aim to build self-confidence.
                </p>
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
