<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Indianapolis_Summary" %>

<asp:Content ID="Indianapolis_Summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
            <td>
                <img id="logo" src="../../images/Indianapolis.jpg" />
            </td>
			<td>
                <asp:Label ID="Label3" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify">Good news! You may be eligible for an incentive.</p></asp:Label>
                <asp:Label ID="Label4" runat="server" CssClass="infotext3">
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
						<b>The Indianapolis One Happy Camper Program, sponsored by the Jewish Federation of Greater Indianapolis and the Foundation for Jewish Camp, 
						provides financial incentives of $1,000 to first time campers from the Greater Indianapolis area who attend a nonprofit Jewish overnight summer 
						camp for at least 19 consecutive days or longer.</b>
					</p>
				</asp:Label>
            <asp:Label ID="Label6" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
					<b>The program also offers $750 to returning campers who received $1,000 for their first year at camp through the Indianapolis One Happy Camper Program, 
					and who attend camp for the second time for at least 19 consecutive days.</b>
                 </p>
            </asp:Label>
            <asp:Label ID="Label5" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
					<b>In order to be eligible, parents of participants must have contributed to the Jewish Federation of Greater Indianapolis Annual Campaign in the year 
					that they apply for the program.</b>
                 </p>
            </asp:Label>
            <asp:Label ID="Label7" CssClass="infotext3" runat="server">
                <p style="text-align:justify"><b>Grants are available to children from grades 3-11.</b>
                 </p>
            </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
				<asp:Label ID="lblJdaySchool" runat="server" CssClass="infotext3" ForeColor="Red">
					<p style="text-align:justify">
						If the camper currently attends Jewish day school, please do not proceed with this application and instead, please call Carolyn Leeds at 317-715-9274. 
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Multiple children from a single family are eligible to receive separate grants and will be considered separate grantees. 
						At least one parent/guardian must be a member in good standing and contribute to the Jewish Federation of Greater Indianapolis in the 
						year the grant is awarded. If you do not think you are eligible for this program, but are interested in other camp scholarship opportunities, 
						please visit <a href="http:\\www.JewishCamp.org/Scholarships" target="_blank">
						www.JewishCamp.org/Scholarships</a> or contact the Federation directly. 
					</p>
				</asp:Label>
			</td>
        </tr>        
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call your community professional listed at the bottom of this page.</p>
                </asp:Label>
            </td>
        </tr>
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
            <td>
                <img id="Img1" src="../../images/Indianapolis.jpg" />
            </td>
            <td>
                <asp:Label ID="Label9" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
						The Indianapolis One Happy Camper program is now closed for the summer of 2013. For more information, 
						please contact the professional listed at the bottom of the screen..
						<br /><br />
						Click ‘NEXT’ to see if your camp is sponsoring its own One Happy Camper program.
 
                    </p>
                </asp:Label>
			</td>
        </tr>
    </table>    
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">            
            <tr>
                <td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2"><br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" /></td>
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
