<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_3.aspx.cs" Inherits="Step2_Adamah_3" Title="Camper Enrollment Step 2" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<%@ Register Src="~/Enrollment/RegisterControls.ascx" TagName="RegControls" TagPrefix="uc1" %>

<asp:Content ID="ContentStep2_CN_1" ContentPlaceHolderID="Content" Runat="Server">
    <table>
        <tbody class="QuestionText">

        <tr>
            <td></td>
            <td style="padding-bottom:20px;">
                <div ID="lblEligibility" runat="server" class="InfoText">
                    Based on your responses thus far, you appear to be eligible for this program's grant! 
                    All we need now is the camp and session information to confirm the camper is attending a camp that is eligible for this program.
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>6</td>
            <td valign="top" style="padding-bottom:20px;">
                <p>Have you registered for camp yet?</p>
                <p>
                    The camper must be registered at a non-profit Jewish overnight summer camp in order to be considered for this grant.  
                    If you have not done so, please contact the camp of your choice to register for camp.  
                    For further assistance, please contact your local program administrator listed at the bottom of this page.  
                    Need help finding a <a href="#" onclick="javascript:window.open('http://www.JewishCamp.org/camps','search','toolbar=no,status=no,scrollbars=yes,width=800,height=400,resizable=yes')">camp</a>?
                </p>
                <uc1:RegControls ID="RegControls1" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>7</td>
            <td valign="top" style="padding-bottom:20px;">
                Select the camp that the camper wishes to attend this summer:
                <div class="QuestionsLeaveSomeUpperSpace">
                    <asp:DropDownList ID="ddlCamp" DataTextField="Camp" DataValueField="CampID" AppendDataBoundItems="true" Enabled="true" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>8</td>
            <td valign="top" style="padding-bottom:20px;">
                Please write the name(s) of the session(s) that the camper will be attending this summer. If you do not know the name of the session, write "unknown".
                <asp:Panel ID="PnlQ9" runat="server" width="100%" CssClass="QuestionsLeaveSomeUpperSpace">
                    <asp:TextBox ID="txtCampSession" runat="server" CssClass="txtbox1" />
                </asp:Panel>    
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>9</td>
            <td valign="top" style="padding-bottom:20px;">
                <asp:Panel ID="PnlQ10" runat="server" Width="100%">
                    <p class="InfoText">
					    In order to be eligible for an incentive grant, the camper must attend camp for at least 12 consecutive days. 
                    </p>
                    <p class="QuestionText">Please use the calendar icon to select dates or input dates as MM/DD/YYYY.</p>
                    <asp:Label ID="Label27" runat="server" CssClass="QuestionText">Start Date</asp:Label>&nbsp;&nbsp;<asp:TextBox ID="txtStartDate" runat="server" CssClass="txtbox1" MaxLength="10" />
                    <asp:ImageButton ID="imgbtnCalStartDt" runat="server" CausesValidation="false" ImageUrl="~/images/calendar.gif" OnClick="imgbtnCalStartDt_Click" />
                    <asp:Panel ID="pnlCalStartDt" runat="server" Visible="false">
                        <asp:Calendar ID="calStartDt" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4"
                            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"
                            Height="50px" Width="200px" OnSelectionChanged="calStartDt_SelectionChanged">
                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        </asp:Calendar>
                    </asp:Panel>
                    &nbsp;&nbsp;
                    <asp:Label ID="Label28" runat="server" CssClass="QuestionText">End Date</asp:Label>&nbsp;&nbsp;
                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="txtbox1" MaxLength="10" />
                    <asp:ImageButton ID="imgbtnCalEndDt" CausesValidation="false" runat="server" ImageUrl="~/images/calendar.gif" OnClick="imgbtnCalEndDt_Click" />
                    <asp:Panel ID="pnlCalEndDt" runat="server" Visible="false">
                        <asp:Calendar ID="calEndDt" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4"
                            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"
                            Height="50px" Width="200px" OnSelectionChanged="calEndDt_SelectionChanged">
                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        </asp:Calendar>
                    </asp:Panel>
                </asp:Panel>
            </td>
        </tr>
        <!-- Admin Panel-->
        <tr>
            <td colspan="2" align="center">
                <asp:Panel ID="PnlAdmin" runat="server" Visible="false">
                    <table width="90%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td style="width: 35%">
                                <asp:Label ID="Label5" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label4" CssClass="text" runat="server" Text="Comments"></asp:Label></td>
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
                <td colspan="3">
                        <asp:CustomValidator ID="CusVal" CssClass="InfoText" Font-Size="15px" runat="server" ClientValidationFunction="ValidateStep4" Display="Dynamic" OnServerValidate="ValidateDataInput" />
                        <!--this summary will be used only for Comments field (only for Admin user)-->
                        <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
                        <!--to vaidate the comments text box for admin user-->
                        <asp:CustomValidator ID="CusValComments1" runat="server" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false" />

                </td>
            </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label16" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
            <td valign="top">
                <table width="100%" cellspacing="0" cellpadding="5" border="0">
                    <tr>
                        <td align="left">
                            <asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" /></td>
                        <td>
                            <asp:Button ID="btnPrevious" ValidationGroup="CommentsGroup" runat="server" Text=" << Previous" CssClass="submitbtn" />
                        </td>
                        <td align="Center">
                            <asp:Button ID="btnSaveandExit" ValidationGroup="CommentsGroup" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                        </td>
                        <td align="right">
                            <asp:Button ID="btnChkEligibility" Text="Next >>" CssClass="submitbtn" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
            <tr>
                <td colspan="2">
                    <asp:Label runat="server" ID="lblMsg" CssClass="QuestionText" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </tbody>
    </table>

    <asp:HiddenField ID="hdnFJCIDStep2_3" runat="server" />
    <asp:HiddenField ID="hdnQ7Id" runat="server" Value="9" />
    <asp:HiddenField ID="hdnQ8Id" runat="server" Value="10" />
    <asp:HiddenField ID="hdnQ9Id" runat="server" Value="11" />
    <asp:HiddenField ID="hdnQ10Id" runat="server" Value="12" />    
</asp:Content>

