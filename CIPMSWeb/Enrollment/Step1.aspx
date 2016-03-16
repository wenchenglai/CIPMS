<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Step1.aspx.cs" MasterPageFile="~/Common.master"
    Title="Camper Enrollment Step I" Inherits="Step1" validateRequest="false"  %>

<%@ MasterType VirtualPath="~/Common.master" %>
<%@ Register Src="~/CamperFooter.ascx" TagName="CamperFooter" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">

<script language="javascript" type="text/javascript">
	document.forms[0].setAttribute("autocomplete", "off");

	//loading popup with jQuery magic!
	function loadPopup() {
		//loads popup only if it is disabled
		var popupStatus = 0;		
		if (popupStatus == 0) {
			$("#popupContact").fadeIn();
			popupStatus = 1;
		}
	}

	//disabling popup with jQuery magic!
	function disablePopup() {
		//disables popup only if it is enabled
		var popupStatus = 1;
		if (popupStatus == 1) {
			$("#popupContact").fadeOut();
			popupStatus = 0;
		}
	}

	function SetTitle(popupTitle) {
		var titleSpan = $('#hdrSpan');
		if (popupTitle != "")
			titleSpan.text(popupTitle);
	}	

	//centering popup
	function centerPopup() {
		//request data for centering
		var windowWidth = $(window).width(); //document.documentElement.clientWidth;
		var windowHeight = $(window).height(); //document.documentElement.clientHeight;
		var popupHeight = $("#popupContact").height();
		var popupWidth = $("#popupContact").width();
		//centering	
		$("#popupContact").css({
			"position": "absolute",
			"top": windowHeight / 2 - popupHeight / 2,
			"left": windowWidth / 2 - popupWidth / 2
		});
	}

	function popupCall(invokedObj, messageSpanID, popupTitle, isPnl8ToBeDisabled, pageName) {
		if (1 == 1) {
			debugger;
			//centering with css
			centerPopup();
			//load Popup
			loadPopup();
			//Set Title
			SetTitle(popupTitle);

		} else {
			disablePopup();
		}
	}

</script>
    
    <div id="popupContact" class="text" style="overflow: auto; padding:10px; height:180px;">
		An access code is only required for the following reasons:
        <ul style="list-style: disc outside none;">
            <li style="">
                You are a PJ library member and have received a PJ library access code.  To learn more about the PJ Goes to Camp One Happy Camper program and how to apply for an access code, click <a href="http://pjlibrary.org/about-pj-library/pj-goes-to-camp.aspx" target="_blank">here</a>.
            </li>
            <li>
                An OHC partner has provided you with a code with specific instruction to enter it here, in order to access the application. 
            </li>
        </ul>
		<a href="Javascript:disablePopup();" style="float:right">Close</a>
    </div>
    
    <table width="100%" cellpadding="0" cellspacing="0">
     <tr style="height: 5px">
            <td>
               <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>--%>
            </td>
        </tr>
        <tr>
            <td>
                <p class="headertext">
                    Section I:  Basic Camper Information</p>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblInfo" runat="server" CssClass="headertext1">Please note that your screen may flash as you enter application information. This is a normal feature.</asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" class="text" cellpadding="1" cellspacing="0" border="0">
            <tr>
                <td colspan="2" align="center">
                    <!--to display the validation summary (error messages)-->
                    <table width="75%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                                <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="true" CssClass="InfoText" />
                                <!--this summary will be used only for Comments field (only for Admin user)-->
                                <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server"
                                    ShowSummary="true" CssClass="InfoText" />
                                <asp:CustomValidator ID="CusValComments" runat="server" Display="None" CssClass="InfoText"
                                    ErrorMessage="Please enter the Comments" EnableClientScript="false"></asp:CustomValidator>
                                <%--<asp:CustomValidator ID="CusVal" ErrorMessage="Please enter valid Code." CssClass="InfoText" runat="server" Display="None" ClientValidationFunction="ValidatePJL"></asp:CustomValidator>--%>
                              <asp:CustomValidator ID="CusValSplCode" runat="server" Display="None" CssClass="InfoText" EnableClientScript="false" ></asp:CustomValidator>
                               <%-- <asp:CustomValidator ID="CusValNLCode" CssClass="InfoText" runat="server" Display="None" ClientValidationFunction="ValidateNLCode" ErrorMessage="please enter valid nl code"></asp:CustomValidator>--%>
                            <%-- <asp:Label ID="lblNLCodeErrMsg" runat="server" CssClass="infotext" Visible="False"></asp:Label>--%>
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="lblJ" runat="server" CssClass="infotext" Text='Please, answer the question: "Does the camper identify as being Jewish?"' Visible="False"></asp:Label>

                </td>
            </tr>
            <tr>
                <td width="25%" nowrap="nowrap">
                    <asp:Label ID="Label11" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label
                        ID="Label1" CssClass="text" runat="server" Text="Camper First Name"></asp:Label></td>
                <td>
                    <asp:TextBox CssClass="txtbox" ID="txtFirstName" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqvalFirstName" runat="server" ControlToValidate="txtFirstName"
                        Display="None" ErrorMessage="Please enter the First Name"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regexpFirstName" runat="server" ValidationExpression="^[a-zA-Z'\s-]{1,50}$"
                        ControlToValidate="txtFirstName" Display="None" ErrorMessage="Please enter a valid First Name" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label12" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label
                        ID="Label2" CssClass="text" runat="server" Text="Camper Last Name"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="txtbox" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqvalLastName" runat="server" ControlToValidate="txtLastName"
                        Display="None" ErrorMessage="Please enter the Last Name"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regexpLastName" runat="server" ValidationExpression="^[a-zA-Z'\s-]{1,50}$"
                        ControlToValidate="txtLastName" Display="None" ErrorMessage="Please enter a valid Last Name" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label15" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label
                        ID="Label10" CssClass="text" runat="server" Text="Camper Country"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" CssClass="txtbox"
                        OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                        <asp:ListItem Text="USA" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Canada" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Mexico" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label13" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label
                        ID="lblZip" CssClass="text" runat="server" Text="Camper Zip Code"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtZipCode" runat="server" CssClass="txtbox" MaxLength="5" AutoPostBack="true" AutoCompleteType="Disabled"></asp:TextBox>
                    <asp:Label ID="Label25" CssClass="InfoText" runat="server" Text="(XXXXX)"></asp:Label>
                    <asp:RequiredFieldValidator ID="reqvalZipCode" runat="server" ControlToValidate="txtZipCode"
                        Display="None" ErrorMessage="Please enter a valid Zip Code following this sample: 12345"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regExpZipCode" runat="server" ControlToValidate="txtZipCode"
                        ValidationExpression="^(\d{5}(?:\-\d{4})?)$" Display="None" ErrorMessage="Please enter a valid Zip Code following this sample: 12345"></asp:RegularExpressionValidator>
                    <asp:Label ID="lblZipMask" runat="server" CssClass="infotext" Text="(XXXXX)" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label14" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label
                        ID="Label4" CssClass="text" runat="server" Text="Camper Street Address"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="txtbox" MaxLength="200"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqvalAddress" runat="server" ControlToValidate="txtAddress"
                        Display="None" ErrorMessage="Please enter the Street Address"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="middle">
                    <asp:Label ID="Label17" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label
                        ID="Label5" CssClass="text" runat="server" Text="Camper City"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="txtbox" Width="300px" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqvalCity" runat="server" ControlToValidate="ddlCity"
                        InitialValue="0" Display="None" ErrorMessage="Please select the City"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="Label24" runat="server" CssClass="QuestionText">Others (type in)</asp:Label>
                    <asp:TextBox ID="txtCityOthers" runat="server" CssClass="txtbox4" Width="205px" MaxLength="40"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqvalCityOther" runat="server" ControlToValidate="txtCityOthers"
                        Display="None" ErrorMessage="Please type in the Name of the City"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label16" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label
                        ID="lblState" CssClass="text" runat="server" Text="Camper State"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server" CssClass="txtbox">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqvalState" runat="server" ControlToValidate="ddlState"
                        InitialValue="0" Display="None" ErrorMessage="Please select the State"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label19" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label
                        ID="Label8" CssClass="text" runat="server" Text="Camper Date of Birth"></asp:Label></td>
                <td>
                    <asp:TextBox onblur="getAge(this);" ID="txtDOB" runat="server" MaxLength="10" CssClass="txtbox" AutoCompleteType="Disabled"></asp:TextBox><asp:Label
                        ID="lblDateFormat" runat="server" CssClass="infotext" Text="(MM/DD/YYYY)"></asp:Label>
                    <asp:RequiredFieldValidator ID="reqvalDOB" runat="server" ControlToValidate="txtDOB"
                        Display="None" ErrorMessage="Please enter your Date of Birth"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator Enabled="false" ID="regExpDOB" runat="server" ControlToValidate="txtDOB"
                        ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                        Display="None" ErrorMessage="Please enter a valid Date of Birth"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator Enabled="true" ID="regExpDOB1" runat="server" ControlToValidate="txtDOB"
                        ValidationExpression="^\d{1,2}\/\d{1,2}\/\d{4}$" Display="None" ErrorMessage="Please enter a valid Date of Birth in (MM/DD/YYYY) format"></asp:RegularExpressionValidator>
                    <asp:RangeValidator ID="rangeDOB" runat="server" ControlToValidate="txtDOB" Type="Date"
                        Display="none"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label23" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label
                        ID="Label9" CssClass="text" runat="server" Text="Camper Age"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtAge" runat="server" CssClass="txtbox"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblStarGender" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label
                        ID="Label22" CssClass="text" runat="server" Text="Camper Gender"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlGender" runat="server" Width="126px" CssClass="txtbox">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" ControlToValidate="ddlGender"
                        InitialValue="0" Display="None" ErrorMessage="Please select the Gender"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="InfoText">*</span>
                    <asp:Label ID="Label3" CssClass="text" runat="server" Text="Home Phone"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtHomePhone1" runat="server" CssClass="txtbox"></asp:TextBox><asp:Label
                        ID="Label37" CssClass="infotext" runat="server" Text="(xxx-xxx-xxxx)"></asp:Label>
                    <asp:RequiredFieldValidator ID="reqvalHomePhone" runat="server" ControlToValidate="txtHomePhone1"
                        Display="None" ErrorMessage="Please enter the Home Phone"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regexpHomePhone" runat="server" ControlToValidate="txtHomePhone1"
                        ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Display="None" ErrorMessage="Please enter a valid Home Phone"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="InfoText">*</span>
                    Does the camper identify as being Jewish?"
                </td>
                <td>
                    <asp:RadioButtonList CssClass="QuestionText" ID="rdbJewish" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Enter PJ Library or other access code here:

                    <asp:TextBox ID="txtSplCode" runat="server" Width="100px" CssClass="txtbox" AutoPostBack="true" AutoCompleteType="Disabled" />
                    &nbsp;&nbsp;
                    <asp:LinkButton ID="hylLearnMore" runat="server" Text="Learn More" />
                    <br />
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text="INVALID CODE" Visible="false" />
				</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel ID="PnlAdmin" runat="server" Visible="false">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td width="25%">
                                    <asp:Label ID="Label21" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label
                                        ID="Label20" CssClass="text" runat="server" Text="Comments"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtComments" runat="server" CssClass="txtbox2" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:CustomValidator ID="CusValComments1" ValidationGroup="CommentsGroup" runat="server"
                        Display="None" CssClass="InfoText" ErrorMessage="<li>Please enter the Comments</li>"
                        EnableClientScript="false"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label Height="30" ID="lblMessage" runat="server" CssClass="InfoText" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
            <td>

            </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table width="85%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                                <asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server"
                                    Text="Exit To Camper Summary" CssClass="submitbtn1" /></td>
                            <td align="left">
                                <asp:Button CausesValidation="false" ValidationGroup="CommentsGroup" ID="btnSaveandExit"
                                    runat="server" Text="Save & Continue Later" CssClass="submitbtn1"/></td>
                            <td>
                                <asp:Button ID="btnNext" runat="server" Text="Next >>" CssClass="submitbtn" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:HiddenField ID="hdnFJCID" runat="server" />
    <asp:HiddenField ID="hdnPerformAction" runat="server" />
    <asp:HiddenField ID="hdnPJLCodes" runat="server" />
    <input type="hidden" runat="server" id="hdnQ1Id" value="10" />
</asp:Content>
