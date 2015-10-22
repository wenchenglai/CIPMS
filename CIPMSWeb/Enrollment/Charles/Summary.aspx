<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_JCC_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
			<td>
                <p>
                    Thank you for your interest in the Camp Daisy and Harry Stein's One Happy Camper Program. For more information on how to apply, 
                    please visit <a href="http://campstein.org/about-camp/for-first-timers/" target="_blank">http://campstein.org/about-camp/for-first-timers</a> or contact Brian Mitchell at campdirector@cbiaz.org or (480) 951-0323.
                </p>
			</td>
		</tr>        
	</table>
	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="../../images/CampCharles.JPG" />
			</td>
			<td>
				<asp:Label ID="Label3" CssClass="SummaryHeading" runat="server">
					<p style="text-align:justify" class="infotext3">
						Thank you for your interest in the Camp Daisy and Harry Stein’s One Happy Camper Program. For more information on how to apply, please visit <a href="http://campstein.org/about-camp/for-first-timers" target="_blank">campstein.org/about-camp/for-first-timers</a> or contact Brian Mitchell at campdirector@cbiaz.org or (480) 951-0323.
					</p>
				</asp:Label>
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 

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
                                <div style="visibility:collapse">
                                    <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " Visible="false" CssClass="submitbtn" OnClick="btnNext_Click" />
                                </div>
								
							</td>                            
						</tr>
					 </table>
				</td>
			</tr>
		</table>        
	</asp:Panel>
</asp:Content>

