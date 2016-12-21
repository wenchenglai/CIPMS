<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Washington_Summary" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="Washington_Summary" ContentPlaceHolderID="Content" runat="Server">
	<script language="javascript" type="text/javascript">
	    function replacePageHeaderText() {
	        $('#ctl00_lblHeading').text('PJ Lottery Routing');
	    }

	    function check() {
	        $('#errorspan').text("")
	        if ($('#ctl00_lblHeading').text() != "Section II:  Program Description" && !$('#ctl00_Content_rdoYes').is(':checked') && !$('#ctl00_Content_rdoNo').is(':checked')) {
	            $('#errorspan').text("Please answer Question No. 1");
	            return false;
	        }
	        else
	            return true;
	    }
	</script>
	
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
				<img id="logo" src="logo.jpg" alt="" />
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
                    The Greater Washington DC area One Happy Camper Program, sponsored by The Jewish Federation of Greater Washington and the Foundation for Jewish Camp, provides grants to encourage children to attend overnight Jewish camp for the first-time.
                </p>
                <p>
                    This is not a scholarship fund and is not needs-based. Our goal is to encourage families who are considering sending their children to camp and provide $1,000 or $700 incentive grant toward their camp tuition to try a Jewish one.
                </p>
		        <p>
			        The following outlines the eligibility criteria for this program:
                </p>
                <ul style="font-weight: bold">
                    <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days. </li>
                    <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                    <li>First-time campers must be entering grades 1-12 (after camp).</li>
                </ul>             
		        <p>
		            This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. As such, children who attend Jewish day school or yeshiva are not eligible for this incentive program.
		        </p>
                <p>
                    <u>Note:</u> 
                    The number of One Happy Camper Grants are limited, so we encourage you to apply early. If your child is not eligible and/or you are interested in learning about financial-needs based grants or other camper funding opportunities please visit
                    <a href="http://www.JewishCamp.org/Scholarships" target= "_blank">www.JewishCamp.org/Scholarships</a>,  or contact your camp. 
                </p>
                <p>
                    If you need additional assistance, please call your community professional listed at the bottom of this page.
                </p>
            </td>
        </tr>
    </table>
    <table id="tblDisable" runat="server"  width="100%" cellpadding="5" cellspacing="0" class="infotext3">
        <tr>
            <td>
				<img id="logo" src="logo.jpg" alt="" />
            </td>
        </tr>
        <tr>
			<td>
                    <p>
                        The Jewish Federation of Greater Washington’s One Happy Camper program is no longer accepting OHC grant applications for Summer 2017. For more information please contact Steffanie Jackson at Steffanie.Jackson@ShalomDC.org.
                    </p>		
			</td>
        </tr>
    </table>
    <table id="tblPJLottery" runat="server" width="100%" cellpadding="5" cellspacing="0" visible="false" class="infotext3">
        <tbody class="QuestionText">
            <tr>
                <td>
                    <span style="color:red" id="errorspan"></span>
                </td>
            </tr>
        <tr>
            <td valign="top">1. Does the camper attend Jewish day school?
                <div>
                    <asp:RadioButton ID="rdoYes" value="1" runat="server" GroupName="g" Text="Yes" CssClass="QuestionText" />
                    <asp:RadioButton ID="rdoNo" value="2" GroupName="g" runat="server" Text="No" CssClass="QuestionText" />
                </div>
                
            </td>
        </tr>
        </tbody>
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
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " OnClientClick="return check();" CssClass="submitbtn" OnClick="btnNext_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
