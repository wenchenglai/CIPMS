<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Nageela_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0">
		<tr>
            <td>
                <img src="logo.jpg" />
            </td>
            <td>

            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
                        Camp Inc. is proud to partner with the Foundation for Jewish Camp and offer incentive grants to campers anywhere in North America.
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label6" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
                        Camp Inc. is a Jewish overnight camp in Boulder, CO where 7th-12th graders from around the world join together to explore what it 
                        means to be an entrepreneur. Camp Inc. campers develop community, confidence, leadership, and Jewish identity through hands-on 
                        experience in entrepreneurship and business. Under the direction of Camp Inc.'s program specialists, campers work in small teams 
                        to turn an idea into a reality and receive the skills to become leaders and innovators in business, philanthropy, and the Jewish community.
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
                        Camp Inc. offers a two-week program for entering 7th and 8th grade campers that is housed at the University of Colorado in Boulder. 
                        In our three-week program, our 9th-12th grade campers spend one week at our mountain facility, living in cabins and enjoying the 
                        benefits of a traditional camp experience. They spend their second and third weeks living in the dorms at the University of Colorado.
					</p>
				</asp:Label>
			</td>
        </tr> 
        <tr>
			<td colspan="2">
				<asp:Label ID="Label3" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
                        The Camp Inc. One Happy Camper program provides financial incentives to first time campers. To be eligible, this must be the first 
                        time the camper has attended a Jewish overnight camp for 12 or more days.
					</p>
				</asp:Label>
			</td>
        </tr> 
        <tr>
			<td colspan="2">
				<asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
                        Incentive amounts are based on session length. Therefore, 7th-8th grade campers are eligible for a $700 grant, and 9th-12th grade 
                        campers are eligible for a $1,000 grant. 
					</p>
				</asp:Label>
			</td>
        </tr> 
        <tr>
			<td colspan="2">
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
                        If you are interested in learning more about Camp Inc. and other discounts and scholarships, please visit us at:  
                        <a href="http://www.CampInc.com" target="_blank">www.CampInc.com</a> or call 303-998-1900 x117.
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

