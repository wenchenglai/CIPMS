<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Chi_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
     <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img src="../../images/bima-large.jpg" /></td>
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
                    BIMA/Genesis at Brandeis University One Happy Camper Program, sponsored by BIMA/Genesis at Brandeis University and the Foundation for Jewish Camp. 

                </p>
		        <p>
			        The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 10-12 (after camp).</li>
                        <li>Students who receive BGI Fellowships for Russian Speaking Jews may not be eligible for this grant (call us for details). </li>
                    </ul>
		        </p>                
		        <p>
		            This program is an outreach initiative for children who are not currently receiving an immersive, 
                    daily Jewish experience. As such, children who attend Jewish day school or yeshiva are not eligible for this incentive program.
		        </p>
                <p>
                    If you are interested in learning more about our camps and available grants, please visit us at: 
                    <a href="http://www.brandeis.edu/highschool/apply/financialaid-bimagen.html" target="_blank">www.brandeis.edu/highschool/apply/financialaid-bimagen.html</a> or 
                    visit our website 
                    <a href="http://www.brandeis.edu/highschool" target="_blank">www.brandeis.edu/highschool</a>.
                </p>
			</td>
        </tr>
    </table>
     <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img src="../../images/bima-large.jpg" /></td>
            <td>
				<asp:Label ID="Label6" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
                    The BIMA/Genesis at Brandeis University One Happy Camper program is now closed for the summer of 2016. For more information, please contact Michael Golitsyn at golitsyn@brandeis.edu.
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

