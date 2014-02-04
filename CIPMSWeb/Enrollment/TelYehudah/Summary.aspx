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
                         Good news!  The Foundation for Jewish Camp, in partnership with Havurah at Camp Tel Yehudah offers an incentive program that is open to campers who live anywhere in North America!                         
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label6" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
                        <strong>Havurah at Camp Tel Yehudah</strong> is a program for teens from the Russian-speaking Jewish (RSJ) community of North America.  It offers participants a unique opportunity to spend the 
                        summer with other teens from a similar background to their own and learn about their commonalities; simultaneously it offers a welcoming approach to the diverse Jewish 
                        community of North America where they discover similarities as well.  The Havurah model is distinctive in its ability to create an open and safe dialogue between the RSJ 
                        community and the broader American Jewish community.  Havurah is a three and a half week immersive Jewish experience which balances friendship, community, connection to 
                        Israel, and [Russian]-Jewish heritage on a daily basis.
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
                        <strong>
                        The Havurah at Tel Yehudah One Happy Camper program provides financial incentives of $1,000 to first-time campers from the Russian-speaking community who attend Havurah 
                        Jewish overnight summer camp for at least 19 consecutive days.  Eligible campers must be entering grades 9-12 (after camp) and attending Havurah at Camp Tel Yehudah.
                        </strong>
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label3" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
                        <strong><u>Note:</u></strong> Teens who currently attend a Jewish day school or Yeshiva are eligible for program.
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
                        If you are interested in learning more about Havurah and other available grants, please visit us at: <a href="http://www.havurahcamp.org">www.havurahcamp.org</a>.
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

