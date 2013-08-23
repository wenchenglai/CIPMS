<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_2.aspx.cs" Inherits="Step2_Dallas_2" Title="Camper Enrollment Step 2" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_Dallas_1" ContentPlaceHolderID="Content" Runat="Server">
  
    
    <!--Panel 2 - Questions displayed on page 2 of Step 2-->
    <asp:Panel ID="Panel2" runat="server">
        <!--to display the validation summary (error messages)-->
        <table width="50%" cellpadding="0" cellspacing="0" align="center">
            <tr>
                <td>
                    <asp:CustomValidator ValidationGroup="OtherValidation" ID="CusVal" CssClass="InfoText" runat="server" Display="Dynamic"  ClientValidationFunction="ValidatePage2Step2_Dallas"></asp:CustomValidator>
                    <!--to vaidate the comments text box for admin user-->
                    <asp:CustomValidator ID="CusValComments1" ValidationGroup="OtherValidation" runat="server" Display="Dynamic" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
                    <asp:ValidationSummary ID="valSummary" CssClass="InfoText" runat="server" ShowSummary="true" ValidationGroup="GroupAddMore" />
                    <!--this summary will be used only for Comments field (only for Admin user)-->
                    <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
                </td>
            </tr>
        </table>
        <table id="table2"  width="100%" cellpadding="5" cellspacing="0" border="0">
            <tr>
                <td valign="top"><asp:Label ID="Label2" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label4" runat="server" Text="1" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="Label5" runat="server" CssClass="QuestionText">Will this be the camper’s first time attending a nonprofit Jewish overnight summer camp for 19 days or longer?</asp:Label><br />
                    <asp:RadioButtonList ID="RadioBtnQ3" runat="server" CssClass="QuestionText" RepeatDirection="Horizontal" >
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td valign="top"><asp:Label ID="Label12" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label8" runat="server" Text="2" CssClass="QuestionText"></asp:Label></td>
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
                <td valign="top"><asp:Label ID="Label19" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label10" runat="server" Text="3" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="Label11" runat="server" CssClass="QuestionText">What kind of school does the camper <u><b>CURRENTLY</b></u> attend?</asp:Label><br />
                    <asp:RadioButtonList AutoPostBack="true" CssClass="QuestionText" ID="RadioBtnQ9" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Private (secular) school" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Public" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Home school" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Jewish day school" Value="4"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="reqval" ControlToValidate="RadioBtnQ9" runat="server"  Display="none" ErrorMessage="Please select the type of School"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <asp:Panel ID="pnlCamperSchool" runat="server">
            <tr>
                <td width="5%"><asp:Label ID="lblAsterisk" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="lblNumber8" runat="server" Text="4" CssClass="QuestionText"></asp:Label></td>
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
        </table>
        
        
    </asp:Panel>
    <!--End of Panel 2 -->
    <asp:Panel ID="PnlHidden" runat="server">
        <asp:HiddenField ID="hdnFJCID" runat="server" />
        <asp:HiddenField ID="hdnQ3Id" runat="server" Value="3" />
        <asp:HiddenField ID="hdnQ4Id" runat="server" Value="13" />
        <asp:HiddenField ID="hdnQ5Id" runat="server" Value="39" />
        <asp:HiddenField ID="hdnQ6Id" runat="server" Value="6" />
        <asp:HiddenField ID="hdnQ7Id" runat="server" Value="7" />
        <asp:HiddenField ID="hdnQ8Id" runat="server" Value="8" />
    </asp:Panel>
 </asp:Content>

