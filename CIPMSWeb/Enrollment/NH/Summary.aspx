<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_NH_Summary" %>

<asp:Content ID="NH_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img id="logo" src="../../images/NewHampshire_Logo.jpg" alt = "" /></td>
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
                    The One Happy Camper Program, sponsored by the Jewish Federation of New Hampshire and the Foundation for Jewish Camp, provides incentives of up to $1,000 to first-time campers who attend a nonprofit Jewish overnight summer camp for at least 12 consecutive days.
				</p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 1-12 (after camp).</li>
                        <li>Attending one of the 155+ non-profit, Jewish, overnight camps listed on the Foundation for Jewish Camp’s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).</li>
                    </ul>
				</p>   
                <p>
                    <span style="color:red">* Note: Families residing in towns served by the Seacoast UJA are not eligible for a Jewish Federation of NH grant.</span>
                </p>
                <p>
                    This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. As such, children who attend Jewish day school or yeshiva are not eligible for this incentive program.
                </p> 
                <p>
                    <strong>Note:</strong> 
                    One Happy Camper grants are not based on financial need and are designed to encourage families to send children to Jewish camps. Families must participate in the current JFNH Annual Campaign at a minimum level of $100.00. Camper must reside in New Hampshire or family must belong to a NH Jewish congregation. Recipient campers must write a short letter or article for publication in the NH Jewish Reporter. Applications will be considered on a rolling basis as long as funds are available.
                </p>
                <p>
                    For more information, please contact the JFNH Camp Grant Chair listed below:
                </p>    
                <p>
                    Nancy Frankel (<a href="mailto:corkyatcf@aol.com">corkyatcf@aol.com</a>) 603 472-3983
                </p>       
            </td>
        </tr>       
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="Img1" src="../../images/NewHampshire_Logo.jpg" alt = "" /></td>
            <td>                
                <asp:Label ID="Label4" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
					The New Hampshire One Happy Camper program is now closed for summer 2016. For information please contact Nancy Frankel at corkyatcf@aol.com.<br />
To see if your camp sponsors a One Happy Camper grant, please click next.
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
