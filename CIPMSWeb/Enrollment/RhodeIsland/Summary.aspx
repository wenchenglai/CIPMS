<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Memphis_Summary" %>

<asp:Content ID="Memphis_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="logo" src="logo.jpg" alt="" width="270" /></td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify">Good news! You may be eligible for an incentive.</p>
                </asp:Label>
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below. 
                    </p>
                </asp:Label>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						The Rhode Island One Happy Camper Program, sponsored by the Jewish Alliance of Greater Rhode Island and the Foundation for Jewish Camp, 
						is offering funding to non-day school, first-time campers who attend a non-profit Jewish overnight summer camp for at least 19 consecutive days 
                        to qualify for a $1,000 incentive grant.  A participant in two-week specialty camp may qualify for a $700 incentive grant.</p>            
				</asp:Label>
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Eligible campers must be entering grades 1-12 (in the school year after camp) and be attending one of the 150+ non-profit, Jewish, overnight summer 
						camps listed on the Foundation for Jewish Camp’s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).
					</p>            
				</asp:Label>
            </td>
        </tr>     
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">
						Note: This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. 
						As such, children who attended Jewish day school or Yeshiva in the academic year before camp or who will attend in the academic year following 
						camp are not eligible for this grant program.
					</p>
                </asp:Label>
                <asp:Label ID="Label4" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">
						If your child is not eligible and/or you are interested in learning about needs-based grants or other camper funding opportunities, 
						contact Camp JORI, greater Rhode Island’s overnight Jewish camp, at campjori@hotmail.com or visit 
						<a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a>.
					</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label3" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call your community professional listed at the bottom of this page.</p>
                </asp:Label>
            </td>
        </tr>       
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="Img1" src="../../images/Rhode_Island_logo.jpg" alt="" />
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
The Rhode Island One Happy Camper program has a limited number of grants remaining for summer of 2014. For more information on how to apply, please contact Elanah Chassen at 401-562-0979 or echassen@jewishallianceri.org.
                    </p>
                </asp:Label>
            </td>
		</tr>               
    </table>    
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">            
            <tr>
                <td valign="top" style="width:5                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                %"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2"><br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                            <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                                </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn"  OnClick="btnNext_Click" /></td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>
</asp:Content>
