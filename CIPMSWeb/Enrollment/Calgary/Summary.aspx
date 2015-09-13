<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Calgary_Summary" %>

<asp:Content ID="Pittsburgh_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img id="Img2" width="320" height="100" src="../../images/calgary.jpg" alt=""/>
            </td>
            <td>
                <p>
                    Good news! You may be eligible for a One Happy Camper grant.
                </p>
                <p>
                    To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
                </p>
            </td>
        </tr>
        <tr>
            <td colspan="2">
				<p>
				    Please pay attention to the following eligibility criteria:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>First time camper must be entering grades 2-12 (after camp).</li>
                        <li>Attending a Canadian Jewish overnight camp listed on the Foundation for Jewish Camp’s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).
                            If you are interested in attending a US based Jewish summer camp, please contact the Calgary Jewish Federation at 403-444-3153.
                        </li>
                    </ul>
				</p> 
                <p>
                    <strong>Note:</strong> This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. As such, children who attend <span style="text-decoration: underline">Jewish day school or yeshiva are not eligible</span> for this incentive program.
                </p>  
                <p>
                    If you do not think that you are eligible for this program and are in need of financial assistance to attend the Federation affiliated camp (Camp BB-Riback), please contact the Calgary Jewish Federation directly at 403-444-3153 or visit the website at <a href="http://www.jewishcalgary.org" target="_blank">www.jewishcalgary.org</a> to learn about / apply for the Integrated Bursary Program.            
                </p>
                <p>
                    If you need additional assistance, please call your community professional listed at the bottom of this page.
                </p>            
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
