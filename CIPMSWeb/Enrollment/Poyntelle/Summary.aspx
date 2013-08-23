<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Chi_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
     <table width="100%" cellpadding="5" cellspacing="0">
            <tr>
            <td style="width: 147px">
                <img src="../../images/CPLV LOGO BLACK .jpg" />
                <img src="../../images/UJA_NYLogo1.JPG" />
                </td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify"><b>Good news! You may be eligible for an incentive.</b></p>   
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
						<b>The Camp Poyntelle Lewis Village One Happy Camper program, sponsored by CPLV, 
						the UJA Federation of New York and the Foundation for Jewish Camp provides financial incentives of $1,000 to first-time campers 
						who attend first session, second session, or the full summer. For any further questions, feel free to contact 
						Sarah Raful Whinston, Executive Director, at <a href="mailto:sarah@poyntelle.com" target="_blank">sarah@poyntelle.com</a>.</b>
					</p>
				</asp:Label>
			</td>
        </tr> 
        <tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						At Camp Poyntelle Lewis Village (CPLV), we pride ourselves on providing a warm, friendly, fun and safe Jewish environment for your child. 
						Children leave for camp looking to have a good time, and return home from camp with a sense of independence, a greater respect towards others, 
						a healthy attitude towards competition, and a lifetime full of memories and friendships. Located in Wayne County, 
						PA we are less than 150 miles from New York City. The camp features a 70 acre private lake that separates the camp into two sections; 
						Poyntelle for boys and girls entering second grade through seventh grade, and Lewis Village for teens entering eighth grade through eleventh grade. 
						Our motto is to smile, laugh, and most importantly, have FUN! 
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

