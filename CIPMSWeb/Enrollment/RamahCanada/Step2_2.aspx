<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_2.aspx.cs" Inherits="Step2_Ramah_2" Title="Camper Enrollment Step 2" %>

<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_Chicago_1" ContentPlaceHolderID="Content" runat="Server">
    <script type="text/javascript" src="../CommonValidate.js"></script>
    <script type="text/javascript" src="Validate.js"></script>

    <div>
        <asp:CustomValidator ValidationGroup="OtherValidation" ID="CusVal" CssClass="InfoText" runat="server" Display="Dynamic" ClientValidationFunction="PageValidator.OnSubmitClick"></asp:CustomValidator>
        <!--to vaidate the comments text box for admin user-->
        <asp:CustomValidator ID="CusValComments1" ValidationGroup="OtherValidation" runat="server" Display="Dynamic" CssClass="InfoText" ErrorMessage="<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
        <asp:ValidationSummary ID="valSummary" CssClass="InfoText" runat="server" ShowSummary="true" ValidationGroup="GroupAddMore" />
        <!--this summary will be used only for Comments field (only for Admin user)-->
        <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
    </div>

    <table>
        <tbody class="QuestionText">
            <tr>
                <td valign="top"><span class="InfoText">*</span>1</td>
                <td valign="top">Will this be the camper�s first-time attending a nonprofit Jewish overnight camp for 19 consecutive days or longer?
                <div>
                    <asp:RadioButton ID="rdoFirstTimerYes" value="1" runat="server" GroupName="RadiobuttonQ3" Text="Yes" />
                    <asp:RadioButton ID="rdoFirstTimerNo" value="2" GroupName="RadiobuttonQ3" runat="server" Text="No" />
                </div>
                </td>
            </tr>
            <tr>
                <td valign="top"><span class="InfoText">*</span>2</td>
                <td valign="top">
    			    Did the camper�s sibling previously receive an incentive grant through the Camp Ramah Canada One Happy Camper Program ?
                    <asp:RadioButtonList ID="rdolistSiblingAttended" runat="server" CssClass="QuestionText" onclick="PageValidator.OnSiblingRadioChanged(this);" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Not Sure" Value="3"></asp:ListItem>
                    </asp:RadioButtonList>
                    <span id="siblingContact" style="color:red;">

                    </span>
                </td>
            </tr>
            <tr>
                <td valign="top"><span class="InfoText">*</span>3</td>
                <td valign="top">
                    Name of Sibling
                    <div class="QuestionsLeaveSomeUpperSpace">
					    <span>First Name:</span> <asp:TextBox ID="txtSiblingFirstName" runat="server" CssClass="txtbox" MaxLength="200" />
					    <br />
					    <span>Last Name:</span>  <asp:TextBox ID="txtSiblingLastName" runat="server" CssClass="txtbox" MaxLength="200" />
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
                    <asp:ListItem Text="Public" Value="2" />
                    <asp:ListItem Text="Jewish day School" Value="4" />
                    <asp:ListItem Text="Private (secular) School" Value="1" />
                    <asp:ListItem Text="Home School" Value="3" />
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
                                <td width="35%">
                                    <asp:Label ID="Label21" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label20" CssClass="text" runat="server" Text="Comments"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtComments" runat="server" CssClass="txtbox2" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:CustomValidator ID="CusValComments" ValidationGroup="CommentsGroup" runat="server" Display="None" CssClass="InfoText" ErrorMessage="Please enter the Comments" EnableClientScript="false"></asp:CustomValidator>

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
                            <td>
                                <asp:Button ID="btnPrevious" ValidationGroup="CommentsGroup" runat="server" Text=" << Previous" CssClass="submitbtn" />
                            </td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" ValidationGroup="CommentsGroup" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
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


    <!--End of Panel 2 -->
    <asp:Panel ID="PnlHidden" runat="server">
        <asp:HiddenField ID="hdnFJCID" runat="server" />
        <asp:HiddenField ID="hdnQ3Id" runat="server" Value="3" />
        <asp:HiddenField ID="hdnQ4Id" runat="server" Value="13" />
        <asp:HiddenField ID="hdnQ5Id" runat="server" Value="33" />
        <asp:HiddenField ID="hdnQ6Id" runat="server" Value="6" />
        <asp:HiddenField ID="hdnQ7Id" runat="server" Value="7" />
        <asp:HiddenField ID="hdnQ8Id" runat="server" Value="17" />
        <asp:HiddenField ID="hdnQ9Id" runat="server" Value="8" />
        <asp:HiddenField ID="hdnQNoIncrement" runat="server" Value="0" />
        <asp:HiddenField ID="hdnCampId" runat="server" />
    </asp:Panel>
</asp:Content>

