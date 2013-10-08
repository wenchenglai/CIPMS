<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Cleveland_Summary" %>

<asp:Content ID="Cleveland_Summary" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td align="center">
                <img id="logo" src="../../images/JFC_logo.jpg" alt="" />
                <img id="Img1" src="../../images/JECCBLKS.jpg" alt="" height="85" width="90" />
            </td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="lblPopup1"><b>Good news! You may be eligible for an incentive.</b> </p>
                </asp:Label>
                <asp:Label ID="Labelnew" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.</p>
                </asp:Label>
	        </td>
        </tr>   
        <tr>
			<td colspan="2">
				<asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						The Cleveland One Happy Camper Program, administered by the Jewish Education Center of Cleveland (JECC) and the Foundation for Jewish Camp, 
						supported by the Endowment Fund of the Jewish Federation of Cleveland, Madav IX Foundation, a supporting foundation of the Jewish Federation of Cleveland, 
						Congregations and several anonymous donors, awards up to $1000 to first-time campers.
					</p>
				</asp:Label>
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Eligible campers must attend one of the Cleveland-approved non-profit Jewish overnight camps for a minimum of 19 consecutive days. 
						Eligible campers must be entering grades 4-12 (after camp). Multiple children from a single family are eligible to receive funds.
					</p>
				</asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify" >
						If the camper currently attends Jewish day school, please do NOT proceed with this application and instead click here: 
						<a href="http://www.jecc.org/YouthOpportunities/CampFundingl.htm" target="_blank">http://www.jecc.org/YouthOpportunities/CampFundingl.htm</a>  
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
            <td colspan="2">
				<asp:Label ID="Label3" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						If you do not think that you are eligible for this program, but are interested in learning about camp funding opportunities, please visit   
						<a href="http://www.JewishCamp.org/Scholarships" target= "_blank" >www.JewishCamp.org/Scholarships</a>, 
						or contact the camp of your choice.
					</p>
				</asp:Label></td>
        </tr>        
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call your community professional listed at the bottom of this page.</p>
                </asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">            
            <tr>
                <td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top"><br />
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
