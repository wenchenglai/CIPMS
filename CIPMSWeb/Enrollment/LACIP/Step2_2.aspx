<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_2.aspx.cs" Inherits="Step2_LACIP_2" Title="Camper Enrollment Step 2" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_LACIP_1" ContentPlaceHolderID="Content" Runat="Server">
    <script type="text/javascript" src="../CommonValidate.js"></script>
    <script type="text/javascript" src="Validate.js"></script>    
    <div>
        <asp:CustomValidator ValidationGroup="OtherValidation" ID="CusVal" CssClass="InfoText" runat="server" Display="Dynamic"  ClientValidationFunction="PageValidator.OnSubmitClick"></asp:CustomValidator>
        <asp:CustomValidator ID="CusValComments1" ValidationGroup="OtherValidation" Display="Dynamic" runat="server" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
        <asp:ValidationSummary ID="valSummary" CssClass="InfoText" runat="server" ShowSummary="true" ValidationGroup="GroupAddMore" />
        <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />        
    </div>

    <table width="100%" cellpadding="5" cellspacing="0" border="0">
        <tbody class="QuestionText">   
            <tr>
                <td valign="top"><span class="InfoText">*</span>1</td>
                <td valign="top">Will this be the camper's first time attending a nonprofit <b>Jewish overnight summer camp</b>? (If you have only attended winter camp and/or family camp in the past, you should answer yes)
                <div>
                    <asp:RadioButton ID="rdoFirstTimerYes" value="1" runat="server" GroupName="RadiobuttonQ3" Text="Yes" />
                    <asp:RadioButton ID="rdoFirstTimerNo" value="2" GroupName="RadiobuttonQ3" runat="server" Text="No" />
                </div>
                </td>
            </tr>
            <tr>
                <td valign="top"><span class="InfoText">*</span>2</td>
                <td valign="top" style="padding-bottom: 20px;">What grade will the camper enter AFTER camp?
                <div class="QuestionsLeaveSomeUpperSpace">
                    <asp:DropDownList ID="ddlGrade" runat="server" CssClass="dropdown" />
                </div>
                </td>
            </tr>
            <tr>
                <td valign="top"><span class="InfoText">*</span>3</td>
                <td valign="top" style="padding-bottom: 20px;">What kind of school does the camper <b><u>CURRENTLY</u></b> attend?
                <asp:RadioButtonList ID="rdoSchoolType" onclick="SchoolValidator.OnSchoolDropDownChange(this);" runat="server" RepeatDirection="Horizontal" CssClass="QuestionText">
                    <asp:ListItem Text="Public" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Jewish Day School" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Private (secular) School" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Home School" Value="3"></asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td valign="top"><span class="InfoText">*</span>4</td>
                <td valign="top" style="padding-bottom: 20px;">Please enter the name of the school that the camper <b><u>CURRENTLY</u></b> attends:
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
    </table>

    <asp:Panel ID="PnlHidden" runat="server">
        <asp:HiddenField ID="hdnFJCID" runat="server" />
		<asp:HiddenField ID="hdnGradeId" runat="server" Value="6" />
		<asp:HiddenField ID="hdnSchoolTypeId" runat="server" Value="7" />
		<asp:HiddenField ID="hdnSchoolNameId" runat="server" Value="8" />        
        <asp:HiddenField ID="hdnQ3Id" runat="server" Value="23" />
        <asp:HiddenField ID="hdnQ4Id" runat="server" Value="24" />
        <asp:HiddenField ID="hdnQ5Id" runat="server" Value="21" />
        <asp:HiddenField ID="hdnQ6Id" runat="server" Value="22" />
    </asp:Panel>
 </asp:Content>

