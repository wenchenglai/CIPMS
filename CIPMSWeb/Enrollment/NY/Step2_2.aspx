<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true"
    CodeFile="Step2_2.aspx.cs" Inherits="Step2_NY_2" Title="Camper Enrollment Step 2" %>

<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_CN_1" ContentPlaceHolderID="Content" runat="Server">
    <%--<table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="Label1" CssClass="headertext" runat="server">Basic Camper Section - II continued..</asp:Label><br /><br />
            </td>
        </tr>
    </table>--%>
    <!--Panel 2 - Questions displayed on page 2 of Step 2-->
    <asp:Panel ID="Panel2" runat="server">
        <!--to display the validation summary (error messages)-->
        <table width="50%" cellpadding="0" cellspacing="0" align="center">
            <tr>
                <td>
                    <asp:CustomValidator ValidationGroup="OtherValidation" ID="CusVal" CssClass="InfoText"
                        runat="server" Display="Dynamic" ClientValidationFunction="ValidatePage2Step2_NY"></asp:CustomValidator>
                    <!--to vaidate the comments text box for admin user-->
                    <asp:CustomValidator ID="CusValComments1" ValidationGroup="OtherValidation" runat="server"
                        Display="Dynamic" CssClass="InfoText" ErrorMessage="<li>Please enter the Comments</li>"
                        EnableClientScript="false"></asp:CustomValidator>
                    <asp:ValidationSummary ID="valSummary" CssClass="InfoText" runat="server" ShowSummary="true"
                        ValidationGroup="GroupAddMore" />
                    <!--this summary will be used only for Comments field (only for Admin user)-->
                    <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server"
                        ShowSummary="true" CssClass="InfoText" />
                </td>
            </tr>
        </table>
        <table width="100%" cellpadding="5" cellspacing="0" border="0">
            <tr>
                <td valign="top">
                    <asp:Label ID="Label13" Text="*" runat="server" CssClass="InfoText" /><asp:Label
                        ID="Label4" runat="server" Text="1" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="Label5" runat="server" CssClass="QuestionText">Will this be the camper�s first time attending a nonprofit Jewish overnight summer camp for 3 weeks or longer?</asp:Label><br />
                    <asp:RadioButtonList ID="RadioBtnQ3" runat="server" CssClass="QuestionText" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label19" Text="*" runat="server" CssClass="InfoText" /><asp:Label
                        ID="Label23" runat="server" Text="2" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="lblSynagogueQuestionText" runat="server" CssClass="QuestionText">Are you a member of any of the following? Membership <u>not</u> required for this grant. (Check all that apply)</asp:Label>
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
                                                        <td style="width: 51%" align="right">
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
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <table width="100%" cellpadding="0" cellspacing="0" id="Table1" runat="server">
                                                    <tr>
                                                        <td style="width: 51%"  align="right">
                                                        <asp:Label ID="LblRefCode" runat="server" CssClass="QuestionText">Referral code: </asp:Label>
                                                            <asp:TextBox ID="txtSynagogueReferral" runat="server" CssClass="txtbox5" MaxLength="4" />
                                                        </td>
                                                        <td style="width: 49%">
                                                            &nbsp;
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
                                                <table width="100%" cellpadding="0" cellspacing="0" id="tblJCC" runat="server">
                                                    <tr>
                                                        <td style="width: 51%" id="tdDDLJCC" runat="server">
                                                            <asp:DropDownList ID="ddlJCC" runat="server" CssClass="dropdown" Width="240px" onChange="JavaScript:SynagogueJCCDDLChange(this);">
                                                            </asp:DropDownList></td>
                                                        <td style="width: 49%"  align="right" id="tdJCCOther" runat="server" >
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
                                <asp:Panel ID="pnl8Q" runat="server" Width="100%">
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td colspan="2" class="QuestionText">
                                                <input type="checkbox" value="2" runat="server" id="chkNo" onclick="JavaScript:CheckSynagogue(this);" />&nbsp;<span>None
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
            <tr>
                <td valign="top">
                    <asp:Label ID="Label24" Text="*" runat="server" CssClass="InfoText" /><asp:Label
                        ID="Label8" runat="server" Text="3" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Panel ID="PnlQ6" runat="server">
                        <asp:Label ID="Label9" runat="server" CssClass="QuestionText">What grade will the camper enter AFTER camp?</asp:Label><br />
                        <asp:DropDownList ID="ddlGrade" runat="server" CssClass="dropdown">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator Enabled="false" ID="reqvalgrade" ControlToValidate="ddlGrade"
                            runat="server" ErrorMessage="Please enter the Grade" Display="none"></asp:RequiredFieldValidator>
                        <asp:RangeValidator Enabled="false" runat="server" ID="rangeValGrade" ErrorMessage="Please enter a valid Grade"
                            Display="none" ControlToValidate="ddlGrade" Type="Integer" MaximumValue="100"
                            MinimumValue="0"></asp:RangeValidator>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label25" Text="*" runat="server" CssClass="InfoText" /><asp:Label
                        ID="Label10" runat="server" Text="4" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="Label11" runat="server" CssClass="QuestionText">What kind of school does the camper <u><b>CURRENTLY</b></u> attend?</asp:Label><br />
                    <asp:RadioButtonList AutoPostBack="true" CssClass="QuestionText" ID="RadioBtnQ9"
                        runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Public" Value="2" />
                    <asp:ListItem Text="Jewish Day School" Value="4" />
                    <asp:ListItem Text="Private (secular) School" Value="1" />
                    <asp:ListItem Text="Home School" Value="3" />
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="reqval" ControlToValidate="RadioBtnQ9" runat="server"
                        Display="none" ErrorMessage="Please select the type of School"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="5%">
                    <asp:Label ID="Label26" Text="*" runat="server" CssClass="InfoText" /><asp:Label
                        ID="Label14" runat="server" Text="5" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2">
                    <asp:Panel ID="PnlCamperSchool" runat="server">
                        <asp:Label ID="Label15" runat="server" CssClass="QuestionText">Name of the school camper attends:</asp:Label>
                        <asp:TextBox ID="txtCamperSchool" runat="server" CssClass="txtbox" MaxLength="200"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqvalSchool" Display="none" ControlToValidate="txtCamperSchool"
                            runat="server" ErrorMessage="Please enter the Name of the School"></asp:RequiredFieldValidator>
                    </asp:Panel>
                </td>
            </tr>
            <!-- Admin Panel-->
            <tr>
                <td colspan="2" align="center">
                    <asp:Panel ID="PnlAdmin" runat="server" Visible="false">
                        <table width="90%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td width="35%">
                                    <asp:Label ID="Label21" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label
                                        ID="Label20" CssClass="text" runat="server" Text="Comments"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtComments" runat="server" CssClass="txtbox2" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:CustomValidator ID="CusValComments" ValidationGroup="CommentsGroup" runat="server"
                        Display="None" CssClass="InfoText" ErrorMessage="Please enter the Comments" EnableClientScript="false"></asp:CustomValidator>
                </td>
            </tr>
            <!--end of admin panel-->
            <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td align="left">
                            <asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" />
                        </td>
                        <td >
                            <asp:Button ID="btnPrevious"  ValidationGroup="CommentsGroup" runat="server" Text=" << Previous" CssClass="submitbtn" />
                        </td>
                        <td align="center">
                            <asp:Button ID="btnSaveandExit"  ValidationGroup="CommentsGroup" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                        </td>
                        <td align="right">
                            <asp:Button ID="btnNext" ValidationGroup="OtherValidation" Text="Next >>" CssClass="submitbtn" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
            </tr>
        </table>
    </asp:Panel>
    <!--End of Panel 2 -->
    <asp:Panel ID="PnlHidden" runat="server">
        <asp:HiddenField ID="hdnFJCID" runat="server" />
        <asp:HiddenField ID="hdnQ3Id" runat="server" Value="3" />
        <asp:HiddenField ID="hdnQ4Id" runat="server" Value="28" />
        <asp:HiddenField ID="hdnQ5Id" runat="server" Value="29" />
        <asp:HiddenField ID="hdnQ6Id" runat="server" Value="6" />
        <asp:HiddenField ID="hdnQ7Id" runat="server" Value="30" />
        <asp:HiddenField ID="hdnQ8Id" runat="server" Value="31" />
        <asp:HiddenField ID="hdnQ9Id" runat="server" Value="32" />
        <asp:HiddenField ID="hdnQ10Id" runat="server" Value="7" />
        <asp:HiddenField ID="hdnQ11Id" runat="server" Value="8" />
         <asp:HiddenField ID="hdnQ2Id" runat="server" Value="1002" />
    </asp:Panel>
</asp:Content>
