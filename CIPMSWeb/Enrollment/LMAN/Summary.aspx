<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Lman_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
     <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
            <tr>
            <td>
                <img src="../../images/color logo.gif" /></td>
            <td>
                <p>
					Good news! You may be eligible for an incentive.
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
                    The Camp L'man Achai One Happy Camper program, sponsored by Camp L’man Achai and the Foundation for Jewish Camp provides financial incentives of up to $1,000 to first-time campers.
				</p>
		        <p>
			        The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 3-11 (after camp).</li>
                    </ul>
		        </p>                
		        <p>
		            <span style="font-weight: bold; color:red">ATTENTION JEWISH DAY SCHOOL FAMILIES:</span> If the camper currently attends Jewish day school, please DO NOT continue with this application and instead, be in touch with the camp directly: 718-436-8255 x107.
		        </p>
                <p>
                    Camp L’man Achai is a Jewish overnight camp that combines an enriched Jewish atmosphere with the best recreation programs. Our camp’s breathtaking panoramic view of the Pepacton Reservoir Valley and the surrounding mountains offers an opportune oasis for children to experience the warmth and beauty of their heritage in a safe, friendly, and warm environment. CLA is about making people feel welcome and at home in a traditional Jewish setting. It strives to let every camper take part in traditions they might not practice outside of camp and give them an opportunity to build meaningful and lifelong friendships, enjoy outdoor adventure and deepen their love of Judaism. We pride ourselves with A Heritage of Happy Campers.
                </p>
                <p>
                    If you are interested in learning more about our camp and available grants, please visit us at: <a href="http://www.camplmanachai.com" target="_blank">www.camplmanachai.com</a> or give us a call at 718-436-8255 x107. 
                </p>
			</td>
        </tr> 
    </table>

    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img id="img1" src="../../images/color logo.gif" alt="" runat="server" />
            </td>
            <td>
                <p>
                    Your camp's One Happy Camper Application is not yet available for summer 2016. Please call the camp professional listed at the bottom of this page for more information.

                </p>
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

