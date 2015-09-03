<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_2.aspx.cs" Inherits="Step2_Columbus_2" Title="Camper Enrollment Step 2" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_CN_1" ContentPlaceHolderID="Content" Runat="Server">
    <script type="text/javascript" src="../CommonValidate.js"></script>
    <script type="text/javascript" src="Validate.js"></script>
    <div>
        <asp:CustomValidator ValidationGroup="OtherValidation" ID="CusVal" CssClass="InfoText" runat="server" Display="Dynamic" ClientValidationFunction="PageValidator.OnSubmitClick" />
        <asp:CustomValidator ID="CusValComments1" ValidationGroup="OtherValidation" runat="server" Display="dynamic" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false" />
        <asp:ValidationSummary Enabled="false" ID="valSummary" CssClass="InfoText" runat="server" ShowSummary="true" ValidationGroup="GroupAddMore" />
        <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
    </div>
    <table width="100%">
        <tbody class="QuestionText">
        <tr>
            <td valign="top"><span class="InfoText">*</span>1</td>
            <td valign="top">
                Will this be the camper’s first-time attending a nonprofit Jewish overnight camp for 12 consecutive days or longer?
                <div>
                    <asp:RadioButton ID="rdoFirstTimerYes" value="1" runat="server" GroupName="RadiobuttonQ3" Text="Yes" />
                    <asp:RadioButton ID="rdoFirstTimerNo" value="2" GroupName="RadiobuttonQ3" runat="server" Text="No" />                    
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>2</td>
            <td valign="top">
                <asp:Label ID="lblSynagogueQuestionText" runat="server">Are you a member of any of the following? Membership <u>not</u> required for this grant. (Check all that apply)</asp:Label>
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
                                            <input type="checkbox" value="1" runat="server" id="chkSynagogue" onclick="SJValidator.OnSynagogueCheckboxChange(this);" />&nbsp;<span>Synagogue</span>
                                        </td>
                                        <td style="width: 82%">
                                            <table width="100%" cellpadding="0" cellspacing="0" id="tblSynagogue" runat="server">
                                                <tr>
                                                    <td style="width: 51%">
                                                        <asp:DropDownList ID="ddlSynagogue" runat="server" CssClass="dropdown" Width="240px" onChange="SJValidator.OnSynagogueDropDownChange(this);">
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
                                            <input type="checkbox" value="3" runat="server" id="chkJCC" onclick="SJValidator.OnJCCChekboxChange(this);" />&nbsp;<span>JCC</span>
                                        </td>
                                        <td style="width: 82%">
                                            <table width="100%" cellpadding="0" cellspacing="0"  id="tblJCC" runat="server">
                                                <tr>
                                                    <td style="width: 51%" id="tdDDLJCC" runat="server">
                                                        <asp:DropDownList ID="ddlJCC" runat="server" CssClass="dropdown" Width="240px" onChange="SJValidator.OnJCCDropDownChange(this);">
                                                        </asp:DropDownList></td>
                                                    <td style="width: 49%"  align="right" id="tdJCCOther" runat="server">
                                                        <asp:Label ID="lblJCC" CssClass="QuestionText" runat="server" Enabled="false">If "Other":</asp:Label>
                                                        <asp:TextBox ID="txtOtherJCC" runat="server" CssClass="txtbox" Enabled="false" MaxLength="200"
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
                                            <input type="checkbox" value="2" runat="server" id="chkNo" onclick="SJValidator.OnOtherChekboxChange(this);" />&nbsp;<span>None
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
            <td valign="top"><span class="InfoText">*</span>2a</td>
            <td valign="top" style="padding-bottom:20px;">
                <div>Who, if anyone, from your synagogue, did you speak to about Jewish overnight camp?</div>
                <div>
                    <asp:RadioButton ID="rdoCongregant" runat="server" Text="A professional or fellow congregant" GroupName="WhoType" onclick="SJValidator.OnWhoRadioChange(this);" />
                    <span id="divWhoInSynagogue" runat="server">
                        <asp:DropDownList ID="ddlWho" DataTextField="Name" CssClass="dropdown" DataValueField="ID" Width="140px" runat="server" onChange="SJValidator.OnWhoInSynagogueDropDownChange(this);" />
                        If "Other":
                        <asp:TextBox ID="txtWhoInSynagogue" Width="130px" CssClass="txtbox" runat="server" />
                    </span>   
                </div>
                <div>
                    <asp:RadioButton ID="rdoNoOne" runat="server" Text="No one from my synagogue" GroupName="WhoType" onclick="SJValidator.OnWhoRadioChange(this);" />
                </div>
            </td>
        </tr>     
        <tr>
            <td valign="top"><span class="InfoText">*</span>3</td>
            <td valign="top">
                What grade will the camper enter AFTER camp?
                <div class="QuestionsLeaveSomeUpperSpace">
                    <asp:DropDownList ID="ddlGrade" runat="server" CssClass="dropdown" />
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>4</td>
            <td valign="top">
                What kind of school does the camper <b><u>CURRENTLY</u></b> attend?
                <asp:RadioButtonList ID="rdoSchoolType" onclick="SchoolValidator.OnSchoolDropDownChange(this);" runat="server" RepeatDirection="Horizontal" CssClass="QuestionText">
                    <asp:ListItem Text="Public" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Jewish day School" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Private (secular) School" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Home School" Value="3"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>5</td>
            <td valign="top" colspan="2">
                Please enter the name of the school that the camper <b><u>CURRENTLY</u></b> attends:
                <div class="QuestionsLeaveSomeUpperSpace">
                    <asp:TextBox ID="txtSchoolName" runat="server" CssClass="txtbox" MaxLength="200" />
                </div> 
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
        </tbody>
    </table>
        
    <asp:HiddenField ID="hdnFJCIDStep2_2" runat="server" />
    <asp:HiddenField ID="hdnAddMoreYearCount" runat="server" />
    <asp:HiddenField ID="hdnQ3Id" runat="server" Value="3" />
    <asp:HiddenField ID="hdnQ4Id" runat="server" Value="6" />
    <asp:HiddenField ID="hdnQ5Id" runat="server" Value="7" />
    <asp:HiddenField ID="hdnQ6Id" runat="server" Value="8" />
    <asp:HiddenField ID="hdnQ25Id" runat="server" Value="30" />
    <asp:HiddenField ID="hdnQ26Id" runat="server" Value="31" />
    <asp:HiddenField ID="hdnQ2Id" runat="server" Value="1002" />
</asp:Content>

