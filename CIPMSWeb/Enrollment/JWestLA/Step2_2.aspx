<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_2.aspx.cs" Inherits="Step2_JWestLA_2" Title="Camper Enrollment Step 2" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_CN_1" ContentPlaceHolderID="Content" Runat="Server">
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
                    <asp:CustomValidator ValidationGroup="OtherValidation" ID="CusVal" CssClass="InfoText" runat="server" Display="Dynamic"  ClientValidationFunction="ValidatePage2Step2_JWestLA"></asp:CustomValidator>
                    <!--to vaidate the comments text box for admin user-->
                    <asp:CustomValidator ID="CusValComments1" ValidationGroup="OtherValidation" runat="server" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
                    <asp:ValidationSummary ID="valSummary" CssClass="InfoText" runat="server" ShowSummary="true" ValidationGroup="GroupAddMore" />
                    <!--this summary will be used only for Comments field (only for Admin user)-->
                    <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
                </td>
            </tr>
        </table>
        <table width="100%" cellpadding="5" cellspacing="0" border="0">
        <asp:Panel ID="pnl9grade" runat="server">
            <tr>
                <td valign="top"><asp:Label ID="Label4" runat="server" Text="1" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="Label5" runat="server" CssClass="QuestionText">Will this be the camper's first time attending a nonprofit <u><b>Jewish overnight summer camp?</b></u> ( If you have only attended  winter camp  and/or family camp  in the past, you should answer yes )</asp:Label><br />
                    <asp:RadioButtonList AutoPostBack="true" ID="RadioBtnQ3" runat="server" CssClass="QuestionText" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            </asp:Panel>
           <tr>
                <td valign="top"><asp:Label ID="Label6" runat="server" Text="2" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Panel ID="PnlQ4" runat="server">
                        <asp:Label ID="lblQ4" runat="server" CssClass="QuestionText">Did the camper receive a JWest Campership incentive grant last summer?</asp:Label><br />
                        <asp:RadioButtonList ID="RadioBtnQ4" runat="server" CssClass="QuestionText" RepeatDirection="Vertical">
                            <asp:ListItem Text="Yes, the camper received a JWest Campership Incentive grant last summer for the <u><b>second</b></u> time" Value="2"></asp:ListItem>
                            <asp:ListItem Text="No, the camper never previously received a JWest Campership incentive grant" Value="3"></asp:ListItem>
                        </asp:RadioButtonList>
                    </asp:Panel>
                </td>
            </tr>
<%--            <tr>
                <td valign="top"><asp:Label ID="Label35" runat="server" Text="3" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Panel ID="PnlQ5" runat="server" Enabled="false">
                        <asp:Label ID="Label1" runat="server" CssClass="QuestionText">How many days did you attend a camp without your family?</asp:Label><br />
                        <asp:Label ID="Label37" runat="server" CssClass="QuestionText">Year</asp:Label>&nbsp;&nbsp;<asp:TextBox ID="txtYear" MaxLength="4" runat="server" CssClass="txtbox1"></asp:TextBox>&nbsp;&nbsp;
                        <asp:Label ID="Label38" runat="server" CssClass="QuestionText">No of Days</asp:Label>&nbsp;&nbsp;<asp:TextBox ID="txtNoofDays" MaxLength="3" runat="server" CssClass="txtbox1"></asp:TextBox>
                    </asp:Panel>
                </td>
            </tr>--%>
            
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
                                <asp:Button ID="btnPrevious" ValidationGroup="CommentsGroup" runat="server" Text=" << Previous" CssClass="submitbtn" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnSaveandExit" ValidationGroup="CommentsGroup" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
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
        <asp:HiddenField ID="hdnQ4Id" runat="server" Value="18" />
        <asp:HiddenField ID="hdnQ5Id" runat="server" Value="19" />
    </asp:Panel>
 </asp:Content>

