<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_3.aspx.cs" Inherits="Step2_JWestLA_3" Title="Camper Enrollment Step 2" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_CN_1" ContentPlaceHolderID="Content" Runat="Server">
    
    
    <!--Panel 2 - Questions displayed on page 2 of Step 2-->
    <asp:Panel ID="Panel2" runat="server" Width="100%">

        <table width="100%" cellpadding="5" cellspacing="0" border="0">
        <tr>
        <td colspan="3">
        <asp:Label ID="lblEligibility" runat="server" CssClass="InfoText2">
                        <p style="text-align:justify"><b>
                           Based on your responses thus far, you appear to be eligible for this program’s grant! All we need now is the camp and session information to confirm the camper is attending a camp that is eligible for this program.</b></p></asp:Label>                    
                   
        </td>
        </tr>
            <tr>
                <td valign="top" width="5%"><asp:Label ID="Label14" runat="server" Text="4" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2">
                    <asp:Label ID="Label15" runat="server" CssClass="QuestionText">Have you registered for camp yet?</asp:Label>
                    <asp:Label ID="Label24" runat="server" CssClass="QuestionText">
                        <p style="text-align:justify">
                           The camper must be registered at a non-profit Jewish overnight summer camp in order to be considered for this grant.  If you have not done so, please contact the camp of your choice to register for camp.  For further assistance, please contact your local program administrator listed at the bottom of this page.  Need help finding a <a href="http://www.JewishCamp.org/camps" id="A2" runat="server" target="_blank">camp</a>?</p></asp:Label>                    
                    <asp:RadioButtonList ID="RadioBtnQ6" runat="server" CssClass="mylist" RepeatDirection="Vertical">
                        <asp:ListItem Text="Yes, I have registered for camp (and have either been accepted, my child is on the waiting list, or I do not know the status of my camp application)" Value="2"></asp:ListItem>
                        <asp:ListItem Text="No, I have not yet registered for camp" Value="1"></asp:ListItem>
                        
                       <%-- <asp:ListItem Text="I have registered for camp, but I am on the waiting list" Value="3"></asp:ListItem>
                        <asp:ListItem Text="I have registered for camp, but I do not know the status of my application" Value="4"></asp:ListItem>--%>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td valign="top"><asp:Label ID="Label18" runat="server" Text="5" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2">
                    <asp:Panel ID="PnlQ7" runat="server" Width="100%">
                        <div id = "msg" visible="false" runat="server">
                            <asp:Label ID="Label3" runat="server" CssClass="InfoText">Due to the U.S./Canadian dollar exchange rate, JWest campers who attend Camp Miriam may receive less than the specified grant amount.  Please contact the Foundation for Jewish Camp with further questions.</asp:Label>
                        </div>
                        <asp:Label ID="Label19" runat="server" CssClass="QuestionText">Select the camp that the camper wishes to attend</asp:Label><br />
                        <asp:DropDownList ID="ddlCamp" AutoPostBack="true" runat="server" CssClass="dropdown"></asp:DropDownList>
                         <br /><br />
                         <div id="campmsg" visible="false" runat="server">
                            <asp:Label ID="Label11" runat="server" CssClass="InfoText">If your child plans on attending a camp that is not on this list, please contact us at <a href="http://jwest@jewishcamp.org" target="_blank">jwest@jewishcamp.org</a> with your child’s first and last name and the camp they wish to attend.</asp:Label>
                        </div>
                    </asp:Panel>
                </td>
             </tr>
            
            <tr>
                <td valign="top"><asp:Label ID="Label22" runat="server" Text="6" CssClass="QuestionText"></asp:Label></td>
                <td valign="top"  colspan="2">
                    <%--<asp:Panel ID="PnlQ8" runat="server" Width="100%">
                        <asp:Label ID="Label23" runat="server" CssClass="QuestionText">Select the camp session(s) that the camper will be attending</asp:Label><br />
                        <asp:DropDownList ID="ddlCampSession" AutoPostBack="true" runat="server" CssClass="dropdown"></asp:DropDownList>
                    </asp:Panel>--%>
                    <asp:Panel ID="PnlQ8" runat="server">
                        <asp:Label ID="Label10" runat="server" CssClass="QuestionText">Please write the name(s) of the session(s) that the camper will be attending this summer. If you do not know the name of the session, write "unknown."</asp:Label><br />
                       
                         <asp:TextBox ID="txtCampSession" runat="server" CssClass="txtbox" MaxLength="100"></asp:TextBox>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Panel ID="PnlNote" runat="server">
                    <asp:Label ID="lblNote" runat="server" CssClass="QuestionText">
                        <p style="text-align:justify" id="pNote" runat="server">
                            <font color="red">In order to be eligible for the incentive grant, the camper must attend camp for at least 12 consecutive days.</p></asp:Label></asp:Panel></td></tr>
            <tr>
                <td valign="top"><asp:Label ID="Label25" runat="server" Text="7" CssClass="QuestionText"></asp:Label></td>
                <td valign="top"  colspan=2>

                     <asp:Panel ID="PnlQ10" runat="server" Width="100%">
                        <p class="InfoText">
					        In order to be eligible for an incentive grant, the camper must attend camp for at least 12 consecutive days. 
                        </p>
                        <p class="QuestionText">Please use the calendar icon to select dates or input dates as MM/DD/YYYY.</p>

                        <asp:Label ID="Label8" runat="server" CssClass="QuestionText">Start Date</asp:Label>&nbsp;&nbsp;<asp:TextBox ID="txtStartDate" runat="server" CssClass="txtbox1" MaxLength="10" />
                        <asp:Imagebutton ID="imgbtnCalStartDt" runat="server" CausesValidation="false" ImageUrl="~/images/calendar.gif" OnClick="imgbtnCalStartDt_Click" />
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
                            </asp:Calendar></asp:Panel>&nbsp;&nbsp;
                        <asp:Label ID="Label9" runat="server" CssClass="QuestionText">End Date</asp:Label>&nbsp;&nbsp;
                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="txtbox1" MaxLength="10" />
                        <asp:Imagebutton ID="imgbtnCalEndDt" CausesValidation="false" runat="server" ImageUrl="~/images/calendar.gif" OnClick="imgbtnCalEndDt_Click" />
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
                            </asp:Calendar></asp:Panel>                        
                    </asp:Panel>
                </td>
            </tr>
            <!-- Admin Panel-->
            <tr>
                <td colspan="3" align="center">
                    <asp:Panel ID="PnlAdmin" runat="server" Visible="false">
                        <table width="90%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td width="35%"><asp:Label ID="Label5" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label4" CssClass="text" runat="server" Text="Comments"></asp:Label></td>
                                <td><asp:TextBox ID="txtComments" runat="server" CssClass="txtbox2" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:CustomValidator ID="CusValComments" ValidationGroup="CommentsGroup" runat="server" Display="None" CssClass="InfoText" ErrorMessage = "Please enter the Comments" EnableClientScript="false"></asp:CustomValidator>
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
            <tr >
                <td valign="top"><asp:Label ID="Label16" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top"  colspan="2">
                    <table width="100%" cellspacing="0" cellpadding="5" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" /></td>
                            <td >
                                <asp:Button ID="btnPrevious" ValidationGroup="CommentsGroup" runat="server" Text=" << Previous" CssClass="submitbtn" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnSaveandExit" ValidationGroup="CommentsGroup" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnChkEligibility" Text="Next >>" CssClass="submitbtn" runat="server" />
                            </td>
                        </tr>
                     </table>
                </td>
            </tr>
            
        </table>
    </asp:Panel>
    <!--End of Panel 2 -->
    <asp:Panel ID="PnlHidden" runat="server">
        <asp:HiddenField ID="hdnFJCID" runat="Server" />
        <asp:HiddenField ID="hdnQ6Id" runat="server" Value="9" />
        <asp:HiddenField ID="hdnQ7Id" runat="server" Value="10" />
        <asp:HiddenField ID="hdnQ8Id" runat="server" Value="11" />
        <asp:HiddenField ID="hdnQ9Id" runat="server" Value="12" />
    </asp:Panel>
</asp:Content>

