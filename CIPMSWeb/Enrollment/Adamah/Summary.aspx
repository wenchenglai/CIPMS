<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Admah_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
            <td>
                <img src="../../images/AdamahAdv_Logo_Color_Trans.png" alt=""  />
            </td>
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
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<b>
							The Adamah Adventures One Happy Camper, sponsored by the Foundation for Jewish Camp and Adamah Adventures, 
							program provides financial incentives of $1,000 to first-time campers who have never been to a Jewish overnight 
							camp for 18 consecutive days or more. Campers from anywhere in the US, Canada or Mexico are eligible. Adamah Adventures 
							18 days programs are open to teens entering grades 8-12 (after camp). 
						</b>
					</p>
				</asp:Label>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Adamah Adventures is a unique summer camp program that invites Jewish teens to take on some of the country’s most thrilling, 
						awe-inspiring outdoor adventures. Teens can select from five treks: Blue Ridge Mountains, North Carolina Peaks and Paddles, 
						Southern Utah, Oregon Service Adventure, and the Pacific Northwest. Campers travel in small groups alongside highly trained 
						staff members. For 18 days, they hike together, paddle together, eat around a nightly campfire and get to know other teens that 
						share their sense of adventure and their willingness to get a little dirty to see a gorgeous view.
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
        <tr>
			<td colspan="2">
				<asp:Label ID="Label3" CssClass="infotext3" runat="server">
					<p style="text-align:justify; color:Red;">
						<b>
							Please note, Adamah Adventures also has 7 and 14 day sessions for teens and tweens entering grades 6-12 (after camp).  
							These programs are NOT eligible for the One Happy Camper incentives.
						</b>
					</p>
				</asp:Label>
            </td>
        </tr>        
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
            <td>
                <img src="../../images/AdamahAdv_Logo_Color_Trans.png" alt=""  />
            </td>
            <td>
                <asp:Label ID="Label5" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify"></p>
                </asp:Label>
                <asp:Label ID="Label6" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						Adamah Adventures has a limited number of One Happy Camper grants - please contact the camp professional listed at the bottom of this page for more information and to receive an access code.
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

