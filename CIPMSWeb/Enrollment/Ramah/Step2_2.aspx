<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_2.aspx.cs" Inherits="Step2_Ramah_2" Title="Camper Enrollment Step 2" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_Chicago_1" ContentPlaceHolderID="Content" Runat="Server">
    <asp:Panel ID="Panel2" runat="server">
        <!--to display the validation summary (error messages)-->
        <table width="50%" cellpadding="0" cellspacing="0" align="center">
            <tr>
                <td>
                    <asp:CustomValidator ValidationGroup="OtherValidation" ID="CusVal" CssClass="InfoText" runat="server" Display="Dynamic"  ClientValidationFunction="ValidatePage2Step2_Ramah"></asp:CustomValidator>
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
                <td valign="top">
					<span class="InfoText">*</span>
					<asp:Label ID="Label4" runat="server" Text="1" />
				</td>
                <td valign="top">
                    <asp:Label ID="Label5" runat="server" CssClass="QuestionText">
						Will this be the camper�s first time attending a nonprofit Jewish overnight summer camp for 
					</asp:Label> 
					<asp:Label ID="lblMinimunDays1" runat="server" Text="19" CssClass="QuestionText" /> 
					<asp:Label ID="lblLabledays" runat="server" CssClass="QuestionText">  days or longer?</asp:Label>  
					<br />
                    <asp:RadioButtonList AutoPostBack="true" ID="RadioBtnQ3" runat="server" CssClass="QuestionText" RepeatDirection="Horizontal" >
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <asp:panel id="pnlSecondTimer" runat="server" Visible="true">
            <tr>
                <td valign="top">
					<span class="InfoText">*</span>
					<asp:Label ID="Label6" runat="server" Text="2" />
				</td>
                <td valign="top">
                    <asp:Panel ID="PnlQ4" runat="server">
                        <asp:Label ID="lblQ4" runat="server" CssClass="QuestionText">Will this be the camper�s second time attending a nonprofit Jewish overnight summer camp for </asp:Label> <asp:Label ID="lblMinimunDays2" runat="server" Text="19" CssClass="QuestionText"></asp:Label> <asp:Label ID="Label26" runat="server" CssClass="QuestionText">  days or longer?</asp:Label><br />
                        <asp:RadioButtonList AutoPostBack="true" ID="RadioBtnQ4" runat="server" CssClass="QuestionText" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td valign="top">
					<span class="InfoText">*</span>
					<asp:Label ID="Label35" runat="server" Text="3" />
				</td>
                <td valign="top">
                    <asp:Panel ID="PnlQ5" runat="server">
                        <asp:Label ID="Label1" runat="server" CssClass="QuestionText">Did the camper receive an incentive grant through the Ramah One Happy Camper program last summer?</asp:Label><br />
                        <asp:RadioButtonList ID="RadioBtnQ5" runat="server" CssClass="QuestionText" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </asp:Panel>
                </td>
            </tr>
            </asp:panel>
            <tr>
                <td valign="top">
					<span class="InfoText">*</span>
					<asp:Label ID="lblGrade" runat="server" Text="4" />
				</td>
                <td valign="top">
                    <asp:Panel id="PnlQ6" runat="server">
                        <asp:Label ID="Label9" runat="server" CssClass="QuestionText">What grade will the camper enter AFTER camp?</asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlGrade" runat="server" CssClass="dropdown"></asp:DropDownList>
                        <asp:RequiredFieldValidator Enabled="false" ID="reqvalgrade" ControlToValidate="ddlGrade" runat="server" ErrorMessage="Please enter the Grade" Display="none"></asp:RequiredFieldValidator>
                        <asp:RangeValidator Enabled="false" runat="server" ID="rangeValGrade" ErrorMessage="Please enter a valid Grade"  Display="none" ControlToValidate="ddlGrade" Type="Integer" MaximumValue="100" MinimumValue="0"></asp:RangeValidator>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td valign="top">
					<span class="InfoText">*</span>
					<asp:Label ID="lblSchoolType" runat="server" Text="5" />
				</td>
                <td valign="top">
                    <asp:Label ID="Label11" runat="server" CssClass="QuestionText">What kind of school does the camper <u><b>CURRENTLY</b></u> attend?</asp:Label><br />
                    <asp:RadioButtonList AutoPostBack="true" CssClass="QuestionText" ID="RadioBtnQ9" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Public" Value="2" />
                    <asp:ListItem Text="Jewish Day School" Value="4" />
                    <asp:ListItem Text="Private (secular) School" Value="1" />
                    <asp:ListItem Text="Home School" Value="3" />
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="reqval" ControlToValidate="RadioBtnQ9" runat="server"  Display="none" ErrorMessage="Please select the type of School"></asp:RequiredFieldValidator>
                </td>
            </tr>
                         
            <asp:Panel ID="pnlCamperSchool" runat="server">
            <tr>
                <td width="5%">
					<span class="InfoText">*</span>
					<asp:Label ID="lblSchoolName" runat="server" Text="6" />
				</td>
                <td valign="top" colspan="2">
                    <asp:Label ID="Label15" runat="server" CssClass="QuestionText">Name of the school camper attends:</asp:Label>
                    <asp:TextBox ID="txtCamperSchool" runat="server" CssClass="txtbox" MaxLength="200"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqvalSchool"  Display="none" ControlToValidate="txtCamperSchool" runat="server" ErrorMessage="Please enter the Name of the School"></asp:RequiredFieldValidator>
                </td>
            </tr>
            </asp:Panel>
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
        
    </asp:Panel>
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
        <asp:HiddenField ID="hdnCampId" runat="server"/>
    </asp:Panel>
 </asp:Content>

