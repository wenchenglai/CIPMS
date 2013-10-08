<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_2.aspx.cs" Inherits="Step2_LACIP_2" Title="Camper Enrollment Step 2" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_LACIP_1" ContentPlaceHolderID="Content" Runat="Server">
    <%--<table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <asp:Label CssClass="headertext" runat="server">Basic Camper Information: Section II continued..</asp:Label><br /><br />
            </td>
        </tr>
    </table>--%>
    
    <!--Panel 2 - Questions displayed on page 2 of Step 2-->
    <asp:Panel ID="Panel2" runat="server">
        <!--to display the validation summary (error messages)-->
        <table width="50%" cellpadding="0" cellspacing="0" align="center">
            <tr>
                <td>
                    <asp:CustomValidator ValidationGroup="OtherValidation" ID="CusVal" CssClass="InfoText" runat="server" Display="Dynamic"  ClientValidationFunction="ValidatePage2Step2_LACIP"></asp:CustomValidator>
                    <!--to vaidate the comments text box for admin user-->
                    <asp:CustomValidator ID="CusValComments1" ValidationGroup="OtherValidation" Display="Dynamic" runat="server" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
                    <asp:ValidationSummary ID="valSummary" CssClass="InfoText" runat="server" ShowSummary="true" ValidationGroup="GroupAddMore" />
                    <!--this summary will be used only for Comments field (only for Admin user)-->
                    <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
                </td>
            </tr>
        </table>
        <table width="100%" cellpadding="5" cellspacing="0" border="0">
            <tr>
                <td valign="top">
                    <asp:Label ID="Label7" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label4" runat="server" Text="1" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="Label5" runat="server" CssClass="QuestionText">Will this be the camper's first time attending a nonprofit <b>Jewish overnight summer camp for 12 days or longer</b>? (If you have only attended winter camp and/or family camp in the past, you should answer yes)</asp:Label><br />
                    <asp:RadioButtonList AutoPostBack="true" ID="RadioBtnQ3" runat="server" CssClass="QuestionText" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
<%--            <tr>
                <td valign="top">
                    <asp:Label ID="Label8" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label6" runat="server" Text="2" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Panel ID="PnlQ4" runat="server">
                        <asp:Label ID="lblQ4" runat="server" CssClass="QuestionText">Will this be the camper’s second time attending a nonprofit Jewish overnight summer camp for 2 or more consecutive weeks?</asp:Label><br />
                        <asp:RadioButtonList AutoPostBack="true" ID="RadioBtnQ4" runat="server" CssClass="QuestionText" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label9" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label35" runat="server" Text="3" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Panel ID="PnlQ5" runat="server">
                        <asp:Label ID="Label1" runat="server" CssClass="QuestionText">Did the camper receive an incentive grant through the <b>Jewish Federation of Greater Los Angeles’ Jewish Summer Camp Incentive Program</b> last summer?</asp:Label><br />
                        <asp:RadioButtonList ID="RadioBtnQ5" runat="server" CssClass="QuestionText" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </asp:Panel>
                </td>
            </tr>--%>    
            <tr>
                <td valign="top">
                    <asp:Label ID="Label1" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label8" runat="server" Text="2" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Panel id="PnlQ1" runat="server">
                        <asp:Label ID="Label9" runat="server" CssClass="QuestionText">What grade will the camper enter <b><u>AFTER</u></b> camp?</asp:Label><br />
                        <asp:DropDownList AutoPostBack="true" ID="ddlGrade" runat="server" CssClass="dropdown"></asp:DropDownList>
                    </asp:Panel>
                </td>
            </tr>            
            <tr>
                <td valign="top">
                    <asp:Label ID="Label3" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label10" runat="server" Text="3" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Panel ID="PnlQ2" runat="server">
                    <asp:Label ID="Label11" runat="server" CssClass="QuestionText">What kind of school does the camper <b><u>CURRENTLY</u></b> attend?</asp:Label><br />
                        <asp:RadioButtonList AutoPostBack="true" CssClass="QuestionText" ID="RadioBtnQ2" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Private (secular) School" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Public" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Home School" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Jewish day School" Value="4"></asp:ListItem>
                        </asp:RadioButtonList>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td valign="top" style="width:5%">
                    <asp:Label ID="Label2" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label14" runat="server" Text="4" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2">
                    <asp:Panel ID="PnlQ3" runat="server">
                        <asp:Label Visible="false" ID="Label15" runat="server" CssClass="QuestionText">Please select the school that the camper <b><u>CURRENTLY</u></b> attends. 
							<font color="red"><b>If the school is not on this list, please select "OTHER" (at the top) and then type in the name of the school below.</b></font>
						</asp:Label>
                         <table width="100%" cellpadding="0" cellspacing="0" border="0" id="tblControls">
                            <tr>
                                <td colspan="2" style="display:none">
                                    <asp:DropDownList ID="ddlCamperSchool" runat="server" CssClass="dropdown">
                                    </asp:DropDownList>
                                </td>

                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblSchoolName" runat="server" CssClass="QuestionText">School Name</asp:Label>
                                    <asp:TextBox ID="txtCamperSchoolOthers" runat="server" CssClass="txtbox4"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
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
		<asp:HiddenField ID="hdnGradeId" runat="server" Value="6" />
		<asp:HiddenField ID="hdnSchoolTypeId" runat="server" Value="7" />
		<asp:HiddenField ID="hdnSchoolNameId" runat="server" Value="8" />        
        <asp:HiddenField ID="hdnQ3Id" runat="server" Value="23" />
        <asp:HiddenField ID="hdnQ4Id" runat="server" Value="24" />
        <asp:HiddenField ID="hdnQ5Id" runat="server" Value="21" />
        <asp:HiddenField ID="hdnQ6Id" runat="server" Value="22" />
    </asp:Panel>
 </asp:Content>

