<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Nageela_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0">
		<tr>
            <td>
                <img src="../../images/Camp_Nageela_Logo.JPG" />
            </td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="infotext3"><b>Good news! You may be eligible for an incentive.</b></p>
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
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<b>The Camp Nageela Midwest One Happy Camper Program, sponsored by Camp Nageela Midwest and the Foundation for Jewish Camp provides financial 
						incentives of $1,000 to first time campers. Campers must be entering grades 4-11 (after camp) and must be attending a session that is 
						at least 19 consecutive days. As this program is an outreach initiative, campers who currently attend Jewish day school are not eligible 
						for the incentive grant.</b> 
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Camp Nageela Midwest is a premier Jewish camping experience that is dedicated to providing a safe and exciting camp program for campers 
						entering grades 4-11. Located on over 500 breathtaking acres of rolling fields and forest, Camp Nageela Midwest offers three weeks of 
						nonstop fun and adventure in our state-of-the-art facilities including an Olympic size pool, ropes course, paintball course, regulation football fields, 
						indoor and outdoor gyms, air-conditioned cabins, and much more.
					</p>
				</asp:Label>
			</td>
        </tr> 
        <tr>
			<td colspan="2">
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						CNM = Fun, CNM = Friends, CNM = Jewish Identity
					</p>
				</asp:Label>
            </td>
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

