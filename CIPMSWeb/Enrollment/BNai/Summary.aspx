<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_URJ_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
			<td>
                <img src="../../images/Bnai.jpg" />
            </td>
            <td>
                <p>
					Good news! You may be eligible for a One Happy Camper grant.
				</p>
                <p>
					To determine if you are eligible continue reading and if your camper meets the eligibility criteria, 
					please proceed by clicking the "next" button below.
				</p>
            </td>
		</tr>
        <tr>
			<td colspan="2">
			    <p>
			        The Dor l’ Dor incentive grant, administered by B'nai B'rith Camp (Lincoln City, Oregon), provides financial incentives of up to $1,000 to first-time campers who attend B'nai B'rith Camp. 
			    </p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>First-time campers must be entering grades 1-12 (after camp).</li>
                    </ul>
				</p>                
				<p>
				    If you do not think that you are eligible for this program, but are interested in learning about camp scholarship opportunities, please contact our Camp Registrar at 503-452-3429.
				</p>
                <p>
                    For more information on B’nai B’rith Camp and/or to access a camp application, visit <a href="http://www.bbcamp.org" target="_blank">www.bbcamp.org</a>.  If you need additional assistance, please call the camp professional listed at the bottom of this page.

				</p>  
			</td>
        </tr>
    </table>
	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img src="../../images/Bnai.jpg" />
            </td>
			<td>
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						Camp B'nai Brith One Happy CAmper application is not yet available for summer 2013.  
						Please contact the person listed at the bottom of this page for more information.
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

