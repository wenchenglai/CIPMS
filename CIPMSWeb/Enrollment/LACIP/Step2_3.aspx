 <%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true"
    CodeFile="Step2_3.aspx.cs" Inherits="Step2_LACIP_3" Title="Camper Enrollment Step 2" %>

<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_LACIP_1" ContentPlaceHolderID="Content" runat="Server">

    <script type="text/javascript">
        var flag = false;
        $(function () {
            $("#dialog-modal").dialog({
                autoOpen: false,
                width: 400,
                title: "Warning",
                modal: true,
                buttons: [
                    {
                        text: "Yes",
                        click: function () {
                            $(this).dialog("close");
                            SimulateClick("ctl00_Content_btnChkEligibility");
                            return true;
                        }
                    },
                    {
                        text: "No",
                        click: function () {
                            $(this).dialog("close");
                            return false;
                        }
                    }
                ]
            });

        });

        // This function will bypass VaildatePage3Step2_LACIP, thus making client side validation inactivated.  Need FIX.
        function update_click() {
            if (flag) {
                return true;
            } else {
                if ($('#ctl00_Content_ddlCamp>option:selected').val() === "-1" || !$('#ctl00_Content_ddlCamp>option:selected').val()) {
                    $("#dialog-modal").dialog("open");
                    return false;
                } else {
                    return true;
                }
            }
        };

        // Simulate a button click on asp.net form from Javascript
        function SimulateClick(buttonId) {
            flag = true;
            var button = document.getElementById(buttonId);
            if (button) {
                if (button.click) {
                    button.click();
                }
                else if (button.onclick) {
                    button.onclick();
                }
                else {
                    alert("DEBUG: button '" + buttonId + "' is not clickable");
                }
            } else {
                alert("DEBUG: button with ID '" + buttonId + "' does not exist");
            }
        }
    </script>
    <div id="dialog-modal" title="Basic modal dialog">
        <p>Are you sure your camp is not on the list?</p>
        <p>If your camp is not listed, that means it is not eligible for your community's One Happy Camper program.</p>
        <p>Before you click YES to continue to see a list of camp-sponsored One Happy Camper programs, we recommend double checking.</p>
    </div>

    <script type="text/javascript" language="javascript">
        function windowopener(){
        	window.open('Jewish Federation Los Angeles  Release 2015 (Summer Camp).pdf', 'LACIPRelease2009', 'titlebar=no,width=650,height=450,left=250,top=150');           
        }
    </script>

    <!--Panel 2 - Questions displayed on page 2 of Step 2-->
    <asp:Panel ID="Panel2" runat="server" Width="100%">
        <!--to display the validation summary (error messages)-->
        <table width="60%" cellpadding="0" cellspacing="0" align="center" border="0">
            <tr>
                <td>
                    <asp:CustomValidator ID="CusVal" CssClass="InfoText" runat="server" Display="Dynamic" ClientValidationFunction="VaildatePage3Step2_LACIP"></asp:CustomValidator>
                    <!--this summary will be used only for Comments field (only for Admin user)-->
                    <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
                    <!--to vaidate the comments text box for admin user-->
                    <asp:CustomValidator ID="CusValComments1" runat="server" Display="dynamic" CssClass="InfoText" ErrorMessage="<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
                    <asp:Label ID="lblMsgCA" runat="server" Visible="false" CssClass="QuestionText"><p style="text-align: justify; color:Red;"><b>PLEASE NOTE: In order to proceed with this application, the camper MUST BE REGISTERED at a California-based camp. Please SAVE AND EXIT your application, and get in touch with a camp in your area to register the camper for summer 2010. Once you have registered, please return here to submit your completed application.</b> If you have additional questions, please contact Yael Green at 323-761-8320 or <a href='mailto:ygreen@jewishla.org'>ygreen@jewishla.org</a></p></asp:Label>
                    
                </td>
            </tr>
        </table>
        <table width="100%" cellpadding="5" cellspacing="0" border="0">
        <tr>
        <td colspan="3">
        <asp:Label ID="lblEligibility" runat="server" CssClass="InfoText2">
                        <p style="text-align:justify"><b>
                           Based on your responses thus far, you appear to be eligible for this program’s grant! All we need now is the camp and session information to confirm the camper is attending a camp that is eligible for this program.</b></p></asp:Label>                    
                   
        </td>
        </tr>
            <tr>
                <td valign="top" style="width: 5%">
                    <asp:Label ID="Label1" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label14"
                        runat="server" Text="5" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2">
                    <asp:Label ID="Label15" runat="server" CssClass="QuestionText">Have you registered for camp yet?</asp:Label><br />
                    <br />
                    <asp:Label ID="Label24" runat="server" CssClass="QuestionText">
                        <p style="text-align:justify">
                            The camper must be registered at a non-profit Jewish overnight summer camp in order to be considered for this grant.  If you have not done so, please contact the camp of your choice to register for camp.  For further assistance, please contact your local program administrator listed at the bottom of this page.  Need help finding a <a href="http://www.JewishCamp.org/camps" id="A2" runat="server" target="_blank">camp</a>?</p></asp:Label>                    
                    <asp:RadioButtonList ID="RadioBtnQ7" runat="server" CssClass="mylist" RepeatDirection="Vertical">
                         <asp:ListItem Text="Yes, I have registered for camp (and have either been accepted, my child is on the waiting list, or I do not know the status of my camp application)"
                            Value="2"></asp:ListItem>
                        <asp:ListItem Text="No, I have not yet registered for camp" Value="1"></asp:ListItem>
                       
                        <%--<asp:ListItem Text="I have registered for camp, but I am on the waiting list" Value="3"></asp:ListItem>
                        <asp:ListItem Text="I have registered for camp, but I do not know the status of my application"
                            Value="4"></asp:ListItem>--%>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label2" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label18"
                        runat="server" Text="6" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2">
                    <asp:Panel ID="PnlQ7" runat="server" Width="100%">
                        <div id="msg" visible="false" runat="server">
                            <asp:Label ID="Label7" runat="server" CssClass="InfoText">Due to the U.S./Canadian dollar exchange rate, JWest campers who attend Camp Miriam may receive less than the specified grant amount.  Please contact the Foundation for Jewish Camp with further questions.</asp:Label>
                        </div>
                        <asp:Label ID="Label19" runat="server" CssClass="QuestionText">Select the camp that the camper wishes to attend this summer:</asp:Label><br />
                        <asp:DropDownList ID="ddlCamp" runat="server" CssClass="dropdown" >
                        </asp:DropDownList>
                    </asp:Panel>
                </td>
            </tr>
            <%--<tr>
                <td valign="top">
                    <asp:Label ID="Label7" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label22"
                        runat="server" Text="8" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2">
                    <asp:Panel ID="PnlQ9" runat="server" Width="100%">
                        <asp:Label ID="Label23" runat="server" CssClass="QuestionText">Please write the name(s) of the session(s) that the camper will be attending this summer. If you do not know the name of the session, write "unknown."</asp:Label><br />
                        <asp:TextBox ID="txtCampSession" runat="server" CssClass="txtbox"></asp:TextBox>
                    </asp:Panel>
                </td>
            </tr>--%>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label6" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label3"
                        runat="server" Text="7" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2">
                    <%--<asp:Panel ID="PnlQ8" runat="server">
                        <asp:Label ID="Label8" runat="server" CssClass="QuestionText">Please select the session that the camper wishes to attend:</asp:Label><br />
                        <asp:DropDownList ID="ddlCampSession" AutoPostBack="true" runat="server" CssClass="dropdown">
                        </asp:DropDownList>
                    </asp:Panel>--%>
                    <asp:Panel ID="PnlQ8" runat="server">
                        <asp:Label ID="Label10" runat="server" CssClass="QuestionText">Please write the name(s) of the session(s) that the camper will be attending this summer. If you do not know the name of the session, write "unknown."</asp:Label><br />
                       
                         <asp:TextBox ID="txtCampSession" runat="server" CssClass="txtbox" MaxLength="100"></asp:TextBox>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label9" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label25" runat="server" Text="9" CssClass="QuestionText"></asp:Label></td>
                <td valign="top"  colspan="2">
                    <asp:Panel ID="PnlQ10" runat="server" Width="100%">
                        <p class="InfoText">
					        In order to be eligible for an incentive grant, the camper must attend camp for at least 12 consecutive days. 
                        </p>
                        <p class="QuestionText">Please use the calendar icon to select dates or input dates as MM/DD/YYYY.</p>
                                                                       
                        <asp:Label ID="Label27" runat="server" CssClass="QuestionText">Start Date</asp:Label>&nbsp;&nbsp;<asp:TextBox ID="txtStartDate" MaxLength="10" runat="server" CssClass="txtbox1"  />
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
                        <asp:Label ID="Label28" runat="server" CssClass="QuestionText">End Date</asp:Label>&nbsp;&nbsp;<asp:TextBox ID="txtEndDate" MaxLength="10" runat="server" CssClass="txtbox1" />
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
                            </asp:Calendar></asp:Panel><br />                        
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblCert" runat="server" CssClass="headertext1">
                        <p style="text-align:justify">
							All grant recipients of the One Happy Camper Program are required to sign a release form provided by the 
							Jewish Federation of Greater Los Angeles. 
							To review this release form, <a href="javascript:windowopener()">click here</a>.
                        </p>
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top" style="width: 1%">
                    <asp:CheckBox ID="chkAcknowledgement" CssClass="text" runat="server" />
                </td>
                <td colspan="2">
					<asp:Label ID="lblChkText" CssClass="headertext1" runat="server">
						<p style="text-align:justify">
                            I have read the Jewish Federation of Greater Los Angeles release form for the One Happy Camper Program 2015. 
                            By filling in this box, I acknowledge agreement with the aforementioned release form. Furthermore, 
                            the box I fill in represents my signature on all signature lines in the One Happy Camper Program 2015 release.
                        </p>
                    </asp:Label>
					<asp:CustomValidator Enabled="false" ID="CusVal2" ErrorMessage="testing" CssClass="InfoText"
                        runat="server" Display="Dynamic" ClientValidationFunction="VaildateAcknowledgement_LACIP"></asp:CustomValidator>
                </td>
            </tr>
            <!-- Admin Panel-->
            <tr>
                <td colspan="3" align="center">
                    <asp:Panel ID="PnlAdmin" runat="server" Visible="false">
                        <table width="90%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 35%">
                                    <asp:Label ID="Label5" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label
                                        ID="Label4" CssClass="text" runat="server" Text="Comments"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtComments" runat="server" CssClass="txtbox2" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:CustomValidator ID="CusValComments" ValidationGroup="CommentsGroup" runat="server"
                        Display="None" CssClass="InfoText" ErrorMessage="Please enter the Comments" EnableClientScript="false"></asp:CustomValidator>
                </td>
            </tr>
            <!--end of admin panel-->
            <tr>
                <td valign="top">
                    <asp:Label ID="Label16" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2">
                    <table width="100%" cellspacing="0" cellpadding="5" border="0">
                        <tr>
                            <td align="left">
                                <asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server"
                                    Text="Exit To Camper Summary" CssClass="submitbtn1" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" ValidationGroup="CommentsGroup" runat="server" Text=" << Previous"
                                    CssClass="submitbtn" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnSaveandExit" ValidationGroup="CommentsGroup" runat="server" Text="Save & Continue Later"
                                    CssClass="submitbtn1" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnChkEligibility" Text="Next >>" CssClass="submitbtn" OnClientClick="return update_click()" runat="server" />
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
        </table>
    </asp:Panel>
    <!--End of Panel 2 -->
    <asp:Panel ID="PnlHidden" runat="server">
        <asp:HiddenField ID="hdnFJCID" runat="Server" />
        <asp:HiddenField ID="hdnQ7Id" runat="server" Value="9" />
        <asp:HiddenField ID="hdnQ8Id" runat="server" Value="10" />
        <asp:HiddenField ID="hdnQ9Id" runat="server" Value="11" />
        <asp:HiddenField ID="hdnQ10Id" runat="server" Value="12" />
    </asp:Panel>

    <script language="javascript" type="text/javascript">
        //this is not being used currently
        function VaildateAcknowledgement_LACIP(sender, args)
        {
            var inputobjs = document.getElementsByTagName("input");
            var chkAcknowledge;
            for (var i = 0; i <= inputobjs.length-1; i++)
            {
                if (inputobjs[i].id.indexOf("chkAcknowledgement")>=0)
                {
                    chkAcknowledge = inputobjs[i];
                    break;
                }
            }
            
            if (chkAcknowledge.checked==false)
            {
                args.IsValid=false;
                return;
            }
            args.IsValid = true;
            return;
        }
    
    </script>

</asp:Content>
