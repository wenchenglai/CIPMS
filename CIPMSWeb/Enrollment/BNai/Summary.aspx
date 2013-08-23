<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_URJ_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img src="../../images/Bnai.jpg" />
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
							The Dor l’ Dor incentive grant, administered by B'nai B'rith Camp (Lincoln City, Oregon), 
							provides financial incentives of $1,000 to first-time campers who attend B'nai B'rith Camp 
							for at least 19 consecutive days. Eligible campers must be entering grades 3-11 (after camp). 
							If you do not think that you are eligible for this program, but are interested in learning 
							about camp scholarship opportunities, please contact our Camp Registrar at 503-452-3429.
						</b>
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						B’nai B’rith Camp, located on a lakeside campus of the scenic Oregon coast, is the premier Jewish resident camp in the Pacific Northwest. 
						Since 1921, B.B. Camp has been dedicated to providing the finest summer experience for today’s campers while preparing them to be 
						tomorrow’s community leaders. We strive to teach the values and ethics of Jewish living by example, experience, and creative expression. 
						B’nai B’rith Camp has consistently proven to be a great place for youth to learn about themselves, their Jewish identity, their environment, 
						and how to relate to others. B’nai B’rith Camp offers a wide range of activities, including: arts & crafts, Jewish enrichment, athletics, 
						water skiing, sailing, canoeing, hydro tubing, swimming in our outdoor heated pool, dancing, nature, singing, high-ropes challenge course, 
						leadership, community service, drama, creative writing, Shabbat celebrations, overnights, and trips. 
					</p>
				</asp:Label>
			</td>
        </tr> 
		<tr>
			<td colspan="2">
				<asp:Label ID="Label3" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<b>For more information on B’nai B’rith Camp and/or to access a camp application, 
						visit </b> <a href="http://www.bbcamp.org" target="_blank">www.bbcamp.org</a> 
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

