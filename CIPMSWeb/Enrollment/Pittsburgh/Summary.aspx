<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Pittsburgh_Summary" %>

<asp:Content ID="Pittsburgh_summary" ContentPlaceHolderID="Content" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function logo_onclick() {

}

// ]]>
</script>
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="logo" src="../../images/Pittsburgh_Logo_New.JPG" alt="" onclick="return logo_onclick()" />
            </td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify">Good news! You may be eligible for an incentive.</p>
                </asp:Label>    
                <asp:Label ID="Label3" runat="server" CssClass="infotext3">
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
						The Pittsburgh One Happy Camper Program, sponsored by the Jewish Federation of Greater Pittsburgh's Centennial Fund for a Jewish Future and the 
						Foundation for Jewish Camp, provides financial incentives of $1,000 to campers who are attending a nonprofit Jewish overnight summer camp for at 
						least 19 consecutive days for the first time. Campers must be attending a camp listed on the Foundation for Jewish Camp’s website 
						(<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>) 
						in order to be eligible for an incentive. 
					</p>            
				</asp:Label>
			</td>
        </tr>
			<tr>
				<td colspan="2">
					<asp:Label ID="Label4" runat="server" CssClass="infotext3">
						<p style="text-align:justify">
							<b>Important Note: Please be advised that ALL Happy Camper grant recipients will be required to complete a survey.</b>
						</p>
					</asp:Label>
				</td>
			</tr> 
        <tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify; color:Red">
						<b><u>If the camper currently attends Jewish day school</u>, please do not proceed with this application and instead, call Sally Stein 412-992-5243.</b>
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
