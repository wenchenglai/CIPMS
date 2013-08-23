<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Chi_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
     <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img src="../../images/bima-large.jpg" /></td>
            <td>
				<asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
					<p style="text-align:justify">Good news! You may be eligible for an incentive.</p>
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
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<b>The BIMA/Genesis at Brandeis University One Happy Camper Program, sponsored by BIMA/Genesis at Brandeis University and the Foundation for 
						Jewish Camp provides financial incentives of $1,000 to first-time campers who attend one of our nonprofit Jewish overnight summer camps for 
						at least 19 consecutive days. Eligible campers must be entering grades 10-college (after camp) and attending one of our programs and must not 
						currently attend a Jewish day school.  Students who receive BIMA/Genesis scholarships for Russian speaking Jews may not be eligible for this 
						grant (call us for details).</b>
					</p>
				</asp:Label>
			</td>
        </tr> 
        <tr>
			<td colspan="2">
				<asp:Label ID="Label3" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						If you are interested in learning more about our camps and available grants, please visit us at: 
						<a href="http://www.brandeis.edu/highschool/apply/onehappycamper.html" target="_blank">http://www.brandeis.edu/highschool/apply/onehappycamper.html</a> 
						or visit our website <a href="http:\\www.brandeis.edu/highschool" target="_blank">www.brandeis.edu/highschool</a>
					</p>
				</asp:Label>
            </td>
        </tr>
    </table>
     <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img src="../../images/bima-large.jpg" /></td>
            <td>
				<asp:Label ID="Label6" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						The BIMA/Genesis at Brandeis University One Happy Camper program is now closed for summer 2013. For more information, please contact the camp professional listed at the bottom of this page.
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

