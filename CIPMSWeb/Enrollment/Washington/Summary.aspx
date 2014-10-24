<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Washington_Summary" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="Washington_Summary" ContentPlaceHolderID="Content" runat="Server">
	<script language="javascript" type="text/javascript">
// <!CDATA[

function Img1_onclick() {

}

// ]]>
	</script>
	
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
				<img id="logo" src="../../images/DC logo.jpg" alt="" height="100" width="320" />
            </td>
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
                    The Greater Washington DC area One Happy Camper Program, sponsored by The Jewish Federation of Greater Washington and the Foundation for Jewish Camp, provides limited grants to encourage children to attend overnight Jewish camp for the first-time. 
                </p>
                <p>
                    This is not a scholarship fund and is not needs-based. Our goal is to engage families who are considering sending their children to camp and, in effect, to give them $1,000 off their camp fee to try a Jewish one.
                </p>
		        <p>
			        The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days. </li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First-time campers must be entering grades 1-12 (after camp).</li>
                        <li>If camper attended camp in the summer of 2014 for 12-18 days as a first time camper and was NOT eligible for an incentive grant, s/he is still eligible for the grant if attending camp for 19 or more consecutive days.</li>
                    </ul>
		        </p>                
		        <p>
		            This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. As such, children who attend Jewish day school or yeshiva are not eligible for this incentive program.
		        </p>
                <p>
                    <u>Note:</u> If your child is not eligible and/or you are interested in learning about financial-needs based grants or other camper funding opportunities please visit <a href="http://www.JewishCamp.org/Scholarships" target= "_blank">www.JewishCamp.org/Scholarships</a>,  or contact your camp. 
                </p>
                <p>
                    If you need additional assistance, please call your community professional listed at the bottom of this page.
                </p>
            </td>
        </tr>
    </table>
    <table id="tblDisable" runat="server"  width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
				<img id="Img1" src="../../images/DC logo.jpg" alt="" height="100" width="320" />
            </td>
            <td>

            </td>
        </tr>
        <tr>
			<td colspan="2">
                <asp:Label ID="Label2" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
                        Thank you for applying for the One Happy Camper program through The Jewish Federation of Greater Washington.  As a community, we allocated over $45,000 for this program.  As of now, all the incentives have been given out to other families.  Below is a list of other forms of support for parents who would like to send their children to camp: 
												
					</p>
                    <ul style="list-style-type:decimal">
                        <li>Visit <a href="http://www.jewishcamp.org/camper-scholarships" target="_blank">www.jewishcamp.org/camper-scholarships</a> and search for potential scholarships</li>
                        <li>Contact your camp of choice directly to determine if they are offering scholarships</li>
                        <li>If your child is enrolled in PJ Library, please visit the PJ Goes to Camp website for directions on how to apply for a PJ Goes To Camp Incentive <a href="http://www.pjlibrary.org/pjgtc" target="_blank">www.pjlibrary.org/pjgtc</a> </li>
                        <li>Often local congregations offer scholarships for campers so consider speaking with a local rabbi.</li>
                    </ul>
                    <p>
                        Please be in touch with Steffanie Jackson steffanie.jackson@shalomdc.org with additional questions.
                    </p>
				</asp:Label>			
			</td>
        </tr>
    </table>
        
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">
            <tr>
                <td valign="top" style="width: 5%">
                    <asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2">
                    <br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td align="left">
                                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary"
                                    CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous"
                                    CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later"
                                    CssClass="submitbtn1" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> "
                                    CssClass="submitbtn" OnClick="btnNext_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
