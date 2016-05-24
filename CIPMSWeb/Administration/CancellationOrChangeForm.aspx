<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CancellationOrChangeForm.aspx.cs"
    Inherits="Administration_CancellationOrChangeForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Cancellation/Session Switch Form</title>
    <link href="../Style/CIPStyle.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="../CIPMS_JScript.js?v1"></script>

    <script type="text/javascript">
    //to open up a calendar
   function SetCanChgValue()
   {
        var ddl=window.opener.document.getElementById('ctl00_Content_ddlAdjustmentType')
        if(ddl!=null)
        {                
           if(ddl.options(ddl.selectedIndex).value != "0")
           {                
                document.getElementById("hdnCancelChg").value=ddl.options(ddl.selectedIndex).value;
           }
        }     
        alert(document.getElementById("hdnCancelChg").value);
   }
   
   
    function ShowCalendar(txtBoxId)
    {
        window.open('../Calendar.aspx?txtBox=' + txtBoxId,'Calendar','toolbar=no,status=no,titlebar=no,scroll=no,width=200,height=190,left=610,top=420');
        return false;
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="textPopUp">
            <table cellpadding="0" cellspacing="0" border="0" style="height: 100%;">
                <tr>
                    <td style="width: 20%">
                    </td>
                    <td style="width: 52%">
                        <table cellpadding="3" cellspacing="3" border="0" style="height: 100%;">
                            <tr>
                                <td align="center">
                                    <img src="../images/fjc.jpg" id="FjcImg" alt="" />
                                </td>
                            </tr>
                            <tr align="center">
                                <td>
                                    <asp:Label ID="lblPageHeading" runat="server" CssClass="headertext" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span id="valobj" class="InfoText" runat="server"></span>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 71px">
                                    <p style="text-align: justify">
                                        <span style="text-decoration: underline"><strong>Note for Administrators:</strong></span>
                                        In order for the Foundation for Jewish Camp to process payment cancellations and
                                        grant amount switches due to session date changes, we need you to provide us with
                                        some basic information. Once we review this information, we will process payment
                                        accordingly to reflect the adjustments. Thank you for your cooperation! If you have
                                        any questions regarding this process, please contact Staci Myer-Klein (staci@jewishcamp.org/
                                        646-278-4572).
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <asp:Panel ID="pnlUpdateStatus" runat="server" Width="327px" HorizontalAlign="Center">
                                                    <p style="text-align: justify;">
                                                        Request Status: &nbsp;&nbsp;<asp:DropDownList ID="ddlRequestStatus" runat="server"
                                                            CssClass="textbox1">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Approve" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Reject" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        &nbsp; &nbsp;<asp:Button ID="btnUpdateStatus" runat="server" CssClass="submitbtn"
                                                            Text="Update" OnClientClick="JavaScript:return confirm('Are you sure?');" OnClick="btnUpdateStatus_OnClick"
                                                            CausesValidation="false" />
                                                    </p>
                                                    <asp:TextBox ID="txtareaUpdateComments" runat="server" CssClass="txtbox1" TextMode="MultiLine"></asp:TextBox>
                                                    <span id="spnComments" visible="false" runat="server" class="InfoText" style="font-weight: bold">
                                                        *</span>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlNewRequest" runat="Server">
                                                    <asp:LinkButton ID="lnkBtnNewRequest" runat="server" OnClick="lnkBtnNewRequest_OnClick"
                                                        Visible="false" Text="Create new cancel/change request"></asp:LinkButton>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <asp:Panel ID="pnlForm" runat="server" Enabled="true" BorderColor="ActiveBorder"
                                BorderWidth="2" BorderStyle="Solid">
                                <tr>
                                    <td style="width: 100%">
                                        <table border="1" cellspacing="1">
                                            <tr>
                                                <th colspan="2" align="left">
                                                    <b>Camper Information :</b></th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Camper First:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCamperFirstName" Style="text-align: right" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Camper Last:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCamperLastName" Style="text-align: right" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    FJCID:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFJCID" Style="text-align: right" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Program:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFederationName" Style="text-align: right" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Camp:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCamp" Style="text-align: right" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    First/Second Time:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFirstSecondTime" Style="text-align: right" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Grant Amount:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblGrant" Style="text-align: right" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Session Dates:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblStartDate" Style="text-align: right" runat="server"></asp:Label>
                                                    to
                                                    <asp:Label ID="lblEndDate" Style="text-align: right" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Number of Days:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDays" Style="text-align: right" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Adjustment Type:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAdjustmentType" Style="text-align: right; color:Red;" runat="server"></asp:Label>
                                                    <asp:RadioButtonList ID="rdBtnLstAdjustmentType" runat="server" RepeatDirection="Horizontal"
                                                        OnSelectedIndexChanged="rdBtnLstAdjustmentType_OnSelectedIndexChanged" AutoPostBack="true" Visible="false">
                                                        <asp:ListItem Text="Cancellation" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Session Change" Value="2"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Request Status:
                                                </td>
                                                <td>
                                                    <asp:Label Style="text-align: right" ID="lblRequestStatus" runat="server" CssClass="txtbox1"
                                                        Text="No_Request_Submitted"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr visible="false" style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblCampID" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblFJCMatch" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblCurrStatus" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblSession" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p style="text-align: justify">
                                            <span style="text-decoration: underline"><strong>Note for Administrators:</strong></span>
                                            If the camper needs to switch incentive programs or switch camps, the original application
                                            will need to be cancelled and the camper will need to re-apply with a new application.
                                            If this is the case, please mark the adjustment type as Cancellation and notify
                                            the parent to submit a new application.
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel runat="server" ID="pnlCancellation" Width="100%" Visible="false">
                                            <p style="text-align: justify">
                                                Please explain the reason why the camper’s incentive application is being cancelled:
                                                <br />
                                                <asp:TextBox ID="txtCancelComments" runat="server" TextMode="MultiLine" MaxLength="1000"
                                                    Width="300px"></asp:TextBox>
                                                <br />
                                            </p>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <asp:Panel runat="server" ID="pnlSessionChange" Width="100%" Visible="false">
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlManualSessionDates" runat="server" Width="100%">
                                                <p style="text-align: justify">
                                                    Please write the name(s) of the session(s) that the camper will be attending this
                                                    summer. If you do not know the name of the session, write "unknown."
                                                    <br />
                                                    <asp:TextBox runat="server" ID="txtCampSession" MaxLength="100" CssClass="txtbox1"></asp:TextBox>
                                                </p>
                                                <p style="text-align: justify">
                                                    Please enter the new session dates:
                                                    <br />
                                                    Start Date:&nbsp;&nbsp;<asp:TextBox ID="txtNewStartDate" runat="server" CssClass="txtbox1"
                                                        MaxLength="10" />
                                                    <asp:ImageButton ID="imgbtnCalStartDt" runat="server" CausesValidation="false" ImageUrl="~/images/calendar.gif" />
                                                    &nbsp;&nbsp; End Date:&nbsp;&nbsp;
                                                    <asp:TextBox ID="txtNewEndDate" runat="server" CssClass="txtbox1" MaxLength="10" />
                                                    <asp:ImageButton ID="imgbtnCalEndDt" CausesValidation="false" runat="server" ImageUrl="~/images/calendar.gif" />
                                                </p>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlSystemSessionDates" runat="server" Width="100%">
                                                <p style="text-align: justify">
                                                    Please select the new session that the camper wishes to attend:
                                                    <asp:DropDownList ID="ddlCampSession" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCampSession_OnSelectedIndexChanged">
                                                    </asp:DropDownList><br />
                                                    Start Date:&nbsp;&nbsp;
                                                    <asp:Label ID="lblSysNewStartDate" runat="server" ForeColor="red"></asp:Label>
                                                    &nbsp;&nbsp; End Date:&nbsp;&nbsp;
                                                    <asp:Label ID="lblSysNewEndDate" runat="server" ForeColor="red"></asp:Label>
                                                </p>
                                            </asp:Panel>
                                            <p style="text-align: justify">
                                                Number of days in new session:
                                                <asp:Label runat="server" ID="lblNewNoOfDays" ForeColor="red"></asp:Label>
                                            </p>
                                            <p style="text-align: justify">
                                                New grant amount:
                                                <asp:Label runat="server" ID="lblNewGrant" ForeColor="red"></asp:Label>
                                            </p>
                                            <p>
                                                <asp:Button ID="btnCalculateDaysGrant" runat="server" OnClick="btnCalculateDaysGrant_Click"
                                                    Text="Calculate" CssClass="submitbtn" CausesValidation="false" />
                                            </p>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <tr>
                                    <td>
                                        <p style="text-align: justify">
                                            <b>Administrator Information:</b>
                                            <br />
                                            Name of admin submitting this form:&nbsp;<asp:Label ID="lblAdminUserName" runat="server"></asp:Label>
                                            <br />
                                            Phone:&nbsp;<asp:Label ID="lblPhone" runat="server"></asp:Label>
                                            <br />
                                            Email:&nbsp;<asp:Label ID="lblEmail" runat="server"></asp:Label>
                                            <br />
                                        </p>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="pnlComments" runat="server" Visible="False">
                                <tr>
                                    <td align="center">
                                        <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvComments" runat="server" ErrorMessage="Please enter comments."
                                            ControlToValidate="txtComments">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td align="center" style="width: 50%">
                                    &nbsp;
                                    <asp:Button runat="server" ID="btnClear" CssClass="submitbtn" Text="Reset" OnClick="btnClear_Click" CausesValidation="false" />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    <asp:Button runat="server" ID="btnSaveExit" CssClass="submitbtn" Text="Save & Exit" OnClick="btnSaveExit_Click1" Visible="false"/>
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    <asp:Button runat="server" ID="btnSubmit" CssClass="submitbtn" Text="Submit Request" OnClick="btnSubmit_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input type="hidden" runat="server" id="hdnCampSessionStartDate" />
                                    <input type="hidden" runat="server" id="hdnCampSessionEndDate" />
                                    <input type="hidden" runat="server" id="hdncampSeasonErrorMessage" />
                                    <input type="hidden" runat="server" id="hdnUserRole" />
                                    <input type="hidden" runat="server" id="hdnRequestStatus" />
                                    <input type="hidden" runat="server" id="hdnRequestID" />
                                    <input type="hidden" runat="server" id="hdnNewRequest" />
                                    <input type="hidden" runat="server" id="hdnCancelChg" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 20%">
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
