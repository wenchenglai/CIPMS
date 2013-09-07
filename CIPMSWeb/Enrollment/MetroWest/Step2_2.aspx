<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_2.aspx.cs" Inherits="Step2_MetroWest_2" Title="Camper Enrollment Step 2" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_MetroWest_1" ContentPlaceHolderID="Content" Runat="Server">
    <script type="text/javascript" src="../CommonValidate.js"></script>
    <script type="text/javascript" src="Validate.js"></script>
    
    <table width="50%" align="center">
        <tr>
            <td>
                <asp:CustomValidator ValidationGroup="OtherValidation" ID="CusVal" CssClass="InfoText" runat="server" Display="Dynamic" ClientValidationFunction="ValidatePage2Step2_MetroWest"></asp:CustomValidator>
                <!--to vaidate the comments text box for admin user-->
                <asp:CustomValidator ID="CusValComments1" ValidationGroup="OtherValidation" runat="server" Display="dynamic" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
                <asp:ValidationSummary Enabled="false" ID="valSummary" CssClass="InfoText" runat="server" ShowSummary="true" ValidationGroup="GroupAddMore" />
                <!--this summary will be used only for Comments field (only for Admin user)-->
                <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
            </td>
        </tr>
    </table>

    <table width="100%">
        <tbody class="QuestionText">
        <tr>
            <td valign="top"><span class="InfoText">*</span>1</td>
            <td valign="top">
                <asp:Label ID="Label5" runat="server" CssClass="QuestionText">Will this be the camper�s first time attending nonprofit Jewish overnight summer camp for 19 days or longer? </asp:Label><br />
                <asp:RadioButtonList AutoPostBack="true" ID="RadioBtnQ3" runat="server" CssClass="QuestionText" RepeatDirection="Horizontal" >
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                    <asp:ListItem Text="No" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>2</td>
            <td valign="top">
                <asp:Label ID="lblSynagogueQuestionText" runat="server" CssClass="QuestionText">Are you a member of any of the following? Membership not required for this grant. (Check all that apply)</asp:Label>
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
                                                    <td style="width: 49%" align="right" id="tdJCCOther" runat="server">
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
                            <asp:Panel ID="pnl11Q" runat="server" Width="100%">
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
                <asp:Panel id="PnlQ6" runat="server">
                    <asp:Label ID="Label9" runat="server" CssClass="QuestionText">What grade will the camper enter AFTER camp?</asp:Label><br />
                    <asp:DropDownList ID="ddlGrade" runat="server" CssClass="dropdown"></asp:DropDownList>
                    <asp:RequiredFieldValidator Enabled="false" ID="reqvalgrade" ControlToValidate="ddlGrade" runat="server" ErrorMessage="Please enter the Grade" Display="none"></asp:RequiredFieldValidator>
                    <asp:RangeValidator Enabled="false" runat="server" ID="rangeValGrade" ErrorMessage="Please enter a valid Grade"  Display="none" ControlToValidate="ddlGrade" Type="Integer" MaximumValue="100" MinimumValue="0"></asp:RangeValidator>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>4</td>
            <td valign="top">
                <asp:Label ID="Label11" runat="server" CssClass="QuestionText">What kind of school does the camper <b><u>CURRENTLY</u></b> attend?</asp:Label><br />
                <asp:RadioButtonList AutoPostBack="true" CssClass="QuestionText" ID="RadioBtnQ7" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Private (secular) School" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Public" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Home School" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Jewish day School" Value="4"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="reqval" ControlToValidate="RadioBtnQ7" runat="server"  Display="none" ErrorMessage="Please select the type of School"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>5</td>
            <td valign="top" colspan="2">
                <asp:Panel ID="PnlQ8" runat="server">
                    <asp:Label ID="Label15" runat="server" CssClass="QuestionText">Please enter the name of the school that the camper <b><u>CURRENTLY</u></b> attends:</asp:Label><br />
                    <asp:TextBox ID="txtCamperSchool" runat="server" CssClass="txtbox" MaxLength="200"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqvalSchool"  Display="none" ControlToValidate="txtCamperSchool" runat="server" ErrorMessage="Please enter the Name of the School"></asp:RequiredFieldValidator>
                </asp:Panel>
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
        
    <asp:HiddenField ID="hdnFJCIDStep2_2" runat="server" />
    <asp:HiddenField ID="hdnAddMoreYearCount" runat="server" />
    <asp:HiddenField ID="hdnQ3Id" runat="server" Value="3" />
    <asp:HiddenField ID="hdnQ4Id" runat="server" Value="30" />
    <asp:HiddenField ID="hdnQ5Id" runat="server" Value="31" />
    <asp:HiddenField ID="hdnQ6Id" runat="server" Value="6" />
    <asp:HiddenField ID="hdnQ7Id" runat="server" Value="7" />
    <asp:HiddenField ID="hdnQ8Id" runat="server" Value="8" />
    <asp:HiddenField ID="hdnQ2Id" runat="server" Value="1002" />
</asp:Content>

