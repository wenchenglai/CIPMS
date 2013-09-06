<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_2.aspx.cs" Inherits="Step2_Chicago_2" Title="Camper Enrollment Step 2" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_Chicago_1" ContentPlaceHolderID="Content" Runat="Server">
    <table width="50%" cellpadding="0" cellspacing="0" align="center">

        <tr>
            <td>
                <asp:CustomValidator ValidationGroup="OtherValidation" ID="CusVal" CssClass="InfoText" runat="server" Display="Dynamic"  ClientValidationFunction="ValidatePage2Step2_Chicago"></asp:CustomValidator>
                <!--to vaidate the comments text box for admin user-->
                <asp:CustomValidator ID="CusValComments1" ValidationGroup="OtherValidation" runat="server" Display="Dynamic" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
                <asp:ValidationSummary ID="valSummary" CssClass="InfoText" runat="server" ShowSummary="true" ValidationGroup="GroupAddMore" />
                <!--this summary will be used only for Comments field (only for Admin user)-->
                <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
            </td>
        </tr>
    </table>
    <table>
        <tbody class="QuestionText">
        <tr>
            <td valign="top"><span class="InfoText">*</span>1</td>
            <td valign="top">
    			Will this be the camper�s first time attending a nonprofit Jewish overnight summer camp for 19 days or longer?
                <div>
                    <asp:RadioButton ID="rdoFirstTimerYes" value="1" runat="server" GroupName="FirstTimeCamperGroup" Text="Yes" />
                    <asp:RadioButton ID="rdoFirstTimerNo" value="2" GroupName="FirstTimeCamperGroup" runat="server" Text="No" />
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>2</td>
            <td valign="top">
                <asp:Panel ID="PnlQ4" runat="server">
    				Did the camper�s sibling previously receive an incentive grant through the Chicago One Happy Camper Program?
					<br />
                    <asp:RadioButtonList AutoPostBack="true" ID="rdolistSiblingAttended" runat="server" CssClass="QuestionText" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Not Sure" Value="3"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Label ID="lblNotSureSibling" ForeColor="Red" runat="server" CssClass="QuestionText"></asp:Label>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>3</td>
            <td valign="top">
                <asp:Panel ID="PnlQ5" runat="server" >
                    Name of Sibling
                    <div class="QuestionsLeaveSomeUpperSpace">
					    <span>First Name:</span> <asp:TextBox ID="txtSiblingFirstName" runat="server" CssClass="txtbox" MaxLength="200"></asp:TextBox>
					    <br />
					    <span>Last Name:</span>  <asp:TextBox ID="txtSiblingLastName" runat="server" CssClass="txtbox" MaxLength="200"></asp:TextBox>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>4</td>
            <td valign="top">
                <asp:Panel id="PnlQ6" runat="server">
                    What grade will the camper enter AFTER camp?<br />
                    <asp:DropDownList ID="ddlGrade" runat="server" CssClass="dropdown"></asp:DropDownList>
                    <asp:RequiredFieldValidator Enabled="false" ID="reqvalgrade" ControlToValidate="ddlGrade" runat="server" ErrorMessage="Please enter the Grade" Display="none"></asp:RequiredFieldValidator>
                    <asp:RangeValidator Enabled="false" runat="server" ID="rangeValGrade" ErrorMessage="Please enter a valid Grade"  Display="none" ControlToValidate="ddlGrade" Type="Integer" MaximumValue="100" MinimumValue="0"></asp:RangeValidator>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>5</td>
            <td valign="top">
                What kind of school does the camper <u><b>CURRENTLY</b></u> attend?<br />
                <asp:RadioButtonList AutoPostBack="true" CssClass="QuestionText" ID="RadioBtnQ9" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Private (secular) school" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Public" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Home school" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Jewish day school" Value="4"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:Label ID="lblJewishDaySchool" ForeColor="Red" runat="server" CssClass="QuestionText"></asp:Label>
                <asp:RequiredFieldValidator ID="reqval" ControlToValidate="RadioBtnQ9" runat="server"  Display="none" ErrorMessage="Please select the type of School" />
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>6</td>
            <td valign="top">
                <asp:Panel ID="PnlQ10" runat="server">
                    Please select the Jewish day school that the camper <u><b>CURRENTLY</b></u>attends:<br />
                    <asp:DropDownList AutoPostBack="true" ID="ddlQ10" runat="server" CssClass="dropdown" OnSelectedIndexChanged="ddlQ10_SelectedIndexChanged">
                        <asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>                            
                        <asp:ListItem Text="Bernard Zell Anshe Emet Day School" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Akiba Schechter Jewish Day School" Value="5"></asp:ListItem>
                        <asp:ListItem Text="Chicago Jewish Day School" Value="9"></asp:ListItem>
                        <asp:ListItem Text="Chicagoland Jewish High School" Value="6"></asp:ListItem>                            
                        <asp:ListItem Text="Solomon Schechter Jewish Day School" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </asp:Panel>
            </td>
        </tr>
		<tr>
			<td valign="top">
				<asp:Label ID="Label17" runat="server" Text="" CssClass="QuestionText"></asp:Label>
			</td>  
			<td valign="top" >
				<asp:Panel ID="pnlJewishSchool" runat="server"> 
					If other, enter the name of the Jewish day school the camper currently attends: 
					<asp:TextBox ID="txtJewishSchool" runat="server" CssClass="txtbox" />
				</asp:Panel>
            </td>
        </tr> 
        <asp:Panel ID="pnlCamperSchool" runat="server">
        <tr>
            <td valign="top"><span class="InfoText">*</span>7</td>
            <td valign="top">
                Name of the school camper attends:
                <asp:TextBox ID="txtCamperSchool" runat="server" CssClass="txtbox" MaxLength="200"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqvalSchool"  Display="none" ControlToValidate="txtCamperSchool" runat="server" ErrorMessage="Please enter the Name of the School"></asp:RequiredFieldValidator>
            </td>
        </tr>
        </asp:Panel>
        <tr>
            <td valign="top"><span class="InfoText">*</span>8</td>
            <td valign="top">
                Are you a member of any of the following? Membership not required for this grant. (Check all that apply)
            </td>
        </tr>            
        <tr>
            <td valign="top">              
            </td>
            <td valign="top">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top">
                            <asp:Panel ID="Pnl9a" runat="server" Width="100%">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 18%" class="QuestionText">
                                            <input type="checkbox" value="1" runat="server" id="chkSynagogue" onclick="JavaScript:CheckSynagogue(this);" />&nbsp;<span>Synagogue</span>
                                        </td>
                                        <td style="width: 82%">
                                            <table width="100%" cellpadding="0" cellspacing="0" id="tblSynagogue" runat="server">
                                                <tr>
                                                    <td style="width: 51%">
                                                        <asp:DropDownList ID="ddlSynagogue" runat="server" CssClass="dropdown" Width="240px" onChange="JavaScript:SynagogueJCCDDLChange(this);">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 49%" align="right">
                                                        <asp:Label ID="lblOtherSynogogueQues" CssClass="QuestionText" runat="server" Enabled="false">If "Other":</asp:Label>
                                                        <asp:TextBox ID="txtOtherSynagogue" runat="server" CssClass="txtbox" Enabled="false"
                                                            MaxLength="200" Width="160px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Panel ID="Pnl10a" runat="server" Width="100%">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 18%" class="QuestionText">
                                            <input type="checkbox" value="3" runat="server" id="chkJCC" onclick="JavaScript:CheckSynagogue(this);" />&nbsp;<span>JCC</span>
                                        </td>
                                        <td style="width: 82%">
                                            <table width="100%" cellpadding="0" cellspacing="0"  id="tblJCC" runat="server">
                                                <tr>
                                                    <td style="width: 51%" id="tdDDLJCC" runat="server">
                                                        <asp:DropDownList ID="ddlJCC" runat="server" CssClass="dropdown" Width="240px" onChange="JavaScript:SynagogueJCCDDLChange(this);">
                                                        </asp:DropDownList></td>
                                                    <td style="width: 49%"  align="right" id="tdJCCOther" runat="server">
                                                        <asp:Label ID="lblJCC" CssClass="QuestionText" runat="server" Enabled="false">If "Other":</asp:Label>
                                                        <asp:TextBox ID="txtJCC" runat="server" CssClass="txtbox" Enabled="false" MaxLength="200"
                                                            Width="160px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Panel ID="pnl11Q" runat="server" Width="100%">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td colspan="2" class="QuestionText">
                                            <input type="checkbox" value="2" runat="server" id="chkNoneOfAboveSynJcc" onclick="JavaScript:CheckSynagogue(this);" />&nbsp;<span>None
                                                of the Above</span>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>             
        <!-- Admin Panel-->
        <tr>
            <td colspan="2" align="center">
                <asp:Panel ID="PnlAdmin" runat="server" Visible="false">
                    <table width="90%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td width="35%"><asp:Label ID="Label21" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label20" CssClass="text" runat="server" Text="Comments"></asp:Label></td>
                            <td><asp:TextBox ID="txtComments" runat="server" CssClass="txtbox2" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:CustomValidator ID="CusValComments" ValidationGroup="CommentsGroup" runat="server" Display="None" CssClass="InfoText" ErrorMessage = "Please enter the Comments" EnableClientScript="false"></asp:CustomValidator>
                    
            </td>
        </tr>
        <!--end of admin panel-->
        <tr >
            <td valign="top"><asp:Label ID="Label16" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
            <td valign="top"  colspan="2">
                <table width="100%" cellspacing="0" cellpadding="5" border="0">
                    <tr>
                        <td  align="left"><asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary" CssClass="submitbtn1" /></td>
                        <td >
                            <asp:Button ID="btnPrevious"  ValidationGroup="CommentsGroup" runat="server" Text=" << Previous" CssClass="submitbtn" />
                        </td>
                        <td align="right">
                            <asp:Button ID="btnSaveandExit"  ValidationGroup="CommentsGroup" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                        </td>
                        <td align="left">
                            <asp:Button ID="btnNext" ValidationGroup="OtherValidation" Text="Next >>" CssClass="submitbtn" runat="server" />
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        </tbody>
    </table>

    <asp:HiddenField ID="hdnFJCID" runat="server" />
    <asp:HiddenField ID="hdnQ3Id" runat="server" Value="3" />
    <asp:HiddenField ID="hdnQ6Id" runat="server" Value="6" />
    <asp:HiddenField ID="hdnQ7Id" runat="server" Value="7" />
    <asp:HiddenField ID="hdnQ8Id" runat="server" Value="17" />
    <asp:HiddenField ID="hdnQ9Id" runat="server" Value="8" />
	<asp:HiddenField ID="hdnQ30WereYouReferredBySynOrJccId" runat="server" Value="30" />
	<asp:HiddenField ID="hdnQ31SelectSynaJccId" runat="server" Value="31" /> 
	<asp:HiddenField ID="hdnQ1002NameOfSynagogueId" runat="server" Value="1002" />  		        
    <asp:HiddenField ID="hdnQ1032Id" runat="server" Value="1032" />
    <asp:HiddenField ID="hdnQFirstNameOfSibling" runat="server" Value="1033" />
    <asp:HiddenField ID="hdnQLastNameOfSibling" runat="server" Value="1034" />        
 </asp:Content>

