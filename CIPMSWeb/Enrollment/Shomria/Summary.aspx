<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Chi_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img src="../../images/camp_shomria.png" height="150px" width="150px" />
            </td>
            <td>
				<asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="infotext3"><b>Good news! You may be eligible for an incentive.</b></p>
				</asp:Label>
                <asp:Label ID="Label4" CssClass="infotext3" runat="server">
                     <p style="text-align:justify"> 
						<b>To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.</b>
                     </p>     
                </asp:Label>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify"><b>
						The Camp Shomria One Happy Camper program provides financial incentives of $1,000 to first-time campers who are attending camp for at least 19 consecutive days.  </b>
						Since the early 1930s Camp Shomria has been connecting youth to Jewish values and culture. Our education focuses on youth empowerment, leadership, responsibility and environmental sustainability. Our 117 acres of beautiful protected forest and watershed habitat are located in Liberty, New York. We host campers from grades three to ten, and special programs include our B’nei Mitzvah Program, our CIT program, and our Eco Education program. Campers of all ages may eligible for the One Happy Camper incentive grant.
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
	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0" visible="false">
		<tr>
			<td>
                <img src="../../images/camp_shomria.png" height="150px" width="150px" />
            </td>
            <td>
                <asp:Label ID="Label3" CssClass="infotext3" runat="server">
                     <p style="text-align:justify"> 
						<b>Please contact Shaked Angel at 212-627-2830 ext. 1 or <a href="mailto:Info@CampShomria.org">Info@CampShomria.org</a> for more information.</b>
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
                            <td  align="left">
								<asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" />
							</td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" />
                            </td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" />
                            </td>
						</tr>
					</table>
                </td>
            </tr>
        </table>        
    </asp:Panel>
</asp:Content>

