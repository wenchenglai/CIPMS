<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_JCC_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="logo" src="../../images/HGF.png" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Thank you for visiting One Happy Camper.
						<br />
						<br />
						Because you live in the Western Massachusetts area, you might be eligible for a grant sponsored by the Harold Grinspoon Foundation!.</p>
						<br />
						Jewish Overnight Summer Camping grants are available for first-time campers who are current residents of 
						<br />Western Massachusetts, Southern Vermont or Northern Connecticut who are attending a qualifying 
						<a href='http://www.jewishcamp.org/camps' target="_blank">Jewish Overnight Camp</a>
						<br />
                </asp:Label>
				<p class="infotext3" style="text-align:center"> 
					<font color="red">
						To learn more and apply for this grant, 
						<asp:LinkButton ID="hgflink" runat="server" OnClick="hgflink_Click" Text="CLICK HERE" ></asp:LinkButton>
					</font>.  
					(You will leave this website)</p>
                <p class="infotext3" style="text-align:center">
					You may only receive one first-time incentive grant from one of these programs
					<br />
					For more information about the Harold Grinspoon Foundation incentive program 
					<br />
					please contact the Harold Grinspoon Foundation at <a href="mailto:gti@hgf.org" target="_blank">gti@hgf.org.</a> 
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
                                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary"
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
                                    CssClass="submitbtn" OnClick="btnNext_Click" Visible="false" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
