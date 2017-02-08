<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_2.aspx.cs" Inherits="HartfordPage2" Title="Camper Enrollment Step 2" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_CN_1" ContentPlaceHolderID="Content" Runat="Server">
    <script type="text/javascript" src="../CommonValidate.js"></script>
    <script type="text/javascript" src="Validate.js"></script>   
    
    <div>
        <asp:CustomValidator ValidationGroup="OtherValidation" ID="CusVal" CssClass="InfoText" runat="server" Display="Dynamic" ClientValidationFunction="PageValidator.OnSubmitClick"></asp:CustomValidator>
        <!--to vaidate the comments text box for admin user-->
        <asp:CustomValidator ID="CusValComments1" ValidationGroup="OtherValidation" runat="server" Display="dynamic" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
        <asp:ValidationSummary Enabled="false" ID="valSummary" CssClass="InfoText" runat="server" ShowSummary="true" ValidationGroup="GroupAddMore" />
        <!--this summary will be used only for Comments field (only for Admin user)-->
        <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
    </div>
    <table>
        <tbody class="QuestionText">
        <tr>
            <td valign="top"><span class="InfoText">*</span>1</td>
            <td valign="top">
                Will this be the camper’s first-time attending a nonprofit Jewish overnight camp for 12 consecutive days or longer?
                <div>
                    <asp:RadioButton ID="rdoFirstTimerYes" value="1" GroupName="RadiobuttonQ3" runat="server" Text="Yes" />
                    <asp:RadioButton ID="rdoFirstTimerNo" value="2" GroupName="RadiobuttonQ3" runat="server" Text="No" />
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>2</td>
            <td valign="top">
                What grade will the camper enter AFTER camp?
                <div>
                    <asp:DropDownList ID="ddlGrade" runat="server" CssClass="dropdown" />
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>3</td>
            <td valign="top">
                What kind of school does the camper <b><u>CURRENTLY</u></b> attend?
                <asp:RadioButtonList CssClass="QuestionText" ID="rdoSchoolType" runat="server" RepeatDirection="Horizontal" onclick="SchoolValidator.OnSchoolDropDownChange(this);" >
                    <asp:ListItem Text="Public" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Jewish Day School" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Private (secular) School" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Home School" Value="3"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>4</td>
            <td valign="top" colspan="2">
                Please enter the name of the school that the camper <b><u>CURRENTLY</u></b> attends:
                <div class="QuestionsLeaveSomeUpperSpace">
                    <asp:TextBox ID="txtSchoolName" runat="server" CssClass="txtbox" MaxLength="200" />
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>5</td>
            <td valign="top">
                Are you a member of any of the following? Membership not required for this grant. (Check all that apply)
                <div ID="pnlSynagogue" class="questionrows" runat="server">
                    <div class="column1" style="float:left; width: 100px;">
                        <input type="checkbox" value="1" runat="server" id="chkSynagogue" onclick="SJValidator.OnSynagogueCheckboxChange(this);" />&nbsp;Synagogue
                    </div> 
                    <div class="column1" style="float:left; width: 200px;">
                        <asp:DropDownList ID="ddlSynagogue" runat="server" CssClass="dropdown" Width="180px" onChange="SJValidator.OnSynagogueDropDownChange(this);" />
                    </div> 
                    <div class="column1" style="float:left; width: 250px;">
                        If "Other": <asp:TextBox ID="txtOtherSynagogue" runat="server" MaxLength="200" Width="160px" CssClass="txtbox" />
                    </div> 
                </div>
                <div id="pnlJCC" class="questionrows" runat="server" Width="100%">
                    <div class="column1" style="float:left; width: 100px;">
                        <input type="checkbox" value="3" runat="server" id="chkJCC" onclick="SJValidator.OnJCCChekboxChange(this);" />&nbsp;<span>JCC</span>
                    </div>
                    <div ID="divDDLJCC" class="column1" style="float:left; width: 200px;" runat="server">
                        <asp:DropDownList ID="ddlJCC" runat="server" CssClass="dropdown" Width="180px" onChange="SJValidator.OnJCCDropDownChange(this);" />
                    </div>
                    <div ID="divOtherJCC" class="column1" style="float:left; width: 250px;" runat="server">
                        If "Other": <asp:TextBox ID="txtOtherJCC" runat="server" MaxLength="200" CssClass="txtbox" Width="160px" />
                    </div>
                </div>
                <div class="questionrows">
                    <input type="checkbox" value="2" runat="server" id="chkNo" onclick="SJValidator.OnOtherChekboxChange(this);" />&nbsp;None of the Above
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>5a</td>
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
        <!-- Admin Panel-->
        <tr>
            <td colspan="2" align="center">
                <asp:Panel ID="PnlAdmin" runat="server" Visible="false">
                    <table width="90%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td><span class="InfoText">*</span>Comments</td>
                            <td><asp:TextBox ID="txtComments" runat="server" CssClass="txtbox2" TextMode="MultiLine" /></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:CustomValidator ID="CusValComments" ValidationGroup="CommentsGroup" runat="server" Display="None" CssClass="InfoText" ErrorMessage = "Please enter the Comments" EnableClientScript="false"></asp:CustomValidator>
            </td>
        </tr>
        <!--end of admin panel-->
        <tr >
            <td valign="top"  colspan="2">
                <table width="100%" cellspacing="0" cellpadding="5" border="0">
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
    <asp:HiddenField ID="hdnQ3Id" runat="server" Value="3" />
    <asp:HiddenField ID="hdnQ4Id" runat="server" Value="6" />
    <asp:HiddenField ID="hdnQ5Id" runat="server" Value="7" />
    <asp:HiddenField ID="hdnQ6Id" runat="server" Value="8" />
    <asp:HiddenField ID="hdnQ25Id" runat="server" Value="30" />
    <asp:HiddenField ID="hdnQ26Id" runat="server" Value="31" /> 
    <asp:HiddenField ID="hdnQ2Id" runat="server" Value="1002" />       
</asp:Content>

