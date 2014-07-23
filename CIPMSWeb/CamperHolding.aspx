<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CamperHolding.aspx.cs" Inherits="CamperHolding"
    Title="Camper Holding Page" %>

<%@ Register Src="CamperFooter.ascx" TagName="CamperFooter" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Foundation for Jewish Camp</title>
    <link rel="stylesheet" href="Style/CIPStyle.css" />
</head>
<body> 
    <form id="form1" runat="server">
        <table width="800px" cellpadding="0" cellspacing="0" border="0" style="height: 100%">
            <tr>
                <td colspan="2" align="right">
                    <img src="/CIPMS/images/fjc.jpg" />
                </td>
            </tr>
            <tr style="height: 100%">
                <td style="width: 23%">
                    &nbsp;
                </td>
                <td style="width: 77%" valign="top">
                    <table class="text">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" CssClass="QuestionText" runat="server">
                                    <p style="text-align: justify">
                                        <b>Welcome!  Thank you for your interest in the Foundation for Jewish Camp’s One Happy Camper program. </b>
                                    </p>
                                     <p style="text-align: justify; font=Verdana">
                                        <b>If you are seeing this message, your One Happy Camper application is not yet available for summer 2015.  Applications will start being available the week of October 20th, 2014.  Fill in your information below and you will be contacted once there is a program open that may be right for you.</b>
                                    </p>
                                    <br />
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table border="1" cellpadding="0" cellspacing="0" style="border-color: Red">
                                    <tr>
                                        <td>
                                            <table class="text">
                                                <tr>
                                                    <td colspan="4" style="height: 5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:ValidationSummary ValidationGroup="Submit" ID="vldsumErr" runat="server" />
                                                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="height: 5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 5px">
                                                    </td>
                                                    <td class="headertext1">
                                                        First Name *</td>
                                                    <td>
                                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="txtbox1" Width="150px" MaxLength="150" /></td>
                                                    <td style="width: 5px">
                                                        <asp:RequiredFieldValidator ValidationGroup="Submit" ID="rfvFirstName" runat="server"
                                                            ControlToValidate="txtFirstName" Display="None" ErrorMessage="Please enter First Name" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 5px">
                                                    </td>
                                                    <td class="headertext1">
                                                        Last Name *</td>
                                                    <td>
                                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="txtbox1" Width="150px" MaxLength="150" /></td>
                                                    <td style="width: 5px">
                                                        <asp:RequiredFieldValidator ValidationGroup="Submit" ID="rfvPwd" runat="server" ControlToValidate="txtLastName"
                                                            Display="None" ErrorMessage="Please enter Last Name" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 5px">
                                                    </td>
                                                    <td class="headertext1">
                                                        Email Address *</td>
                                                    <td>
                                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="txtbox1" Width="150px" MaxLength="150" /></td>
                                                    <td style="width: 5px">
                                                        <asp:RequiredFieldValidator ValidationGroup="Submit" ID="rfvEmail" runat="server"
                                                            ControlToValidate="txtEmail" Display="None" ErrorMessage="Please enter Email Address" />
                                                        <asp:RegularExpressionValidator ValidationGroup="Submit" ID="revEmail" runat="server"
                                                            ControlToValidate="txtEmail" Display="None" ErrorMessage="Please enter a valid e-mail address"
                                                            ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 5px">
                                                    </td>
                                                    <td class="headertext1">
                                                        Zip Code *</td>
                                                    <td>
                                                        <asp:TextBox ID="txtZipCode" runat="server" CssClass="txtbox1" Width="150px" MaxLength="150" /></td>
                                                    <td style="width: 5px">
                                                        <asp:RequiredFieldValidator ValidationGroup="Submit" ID="rfvZipCode" runat="server"
                                                            ControlToValidate="txtZipCode" Display="None" ErrorMessage="Please enter Zip Code" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 5px">
                                                    </td>
                                                    <td class="headertext1">
                                                        School Type *</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSchoolType" runat="server" CssClass="txtbox1" DataTextField="Name" DataValueField="ID"></asp:DropDownList><br />
                                                    </td>
                                                    <td style="width: 5px">
                                                    </td>
                                                </tr>    
                                                <tr>
                                                    <td style="height: 10px" colspan="4">
                                                    </td>
                                                </tr>                                                
                                                <tr>
                                                    <td style="width: 5px">
                                                    </td>
                                                    <td class="headertext1" style="vertical-align:top">
                                                        Camp Name *</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlCamp" runat="server" CssClass="txtbox1" Width="350px"></asp:DropDownList><br />
                                                        <asp:CheckBox ID="chkNoCamp" runat="server" AutoPostBack="true" 
                                                            Text="My camp is not listed above" 
                                                            oncheckedchanged="chkNoCamp_CheckedChanged" />
                                                        <asp:TextBox ID="txtCamp" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 5px">
                                                    </td>
                                                </tr>    
                                                <tr>
                                                    <td style="height: 10px" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 5px">
                                                    </td>
                                                    <td colspan="2" class="headertext1">
                                                        <asp:CheckBox ID="chkPJL" runat="server" Text="Check if applicant is or sibling of the applicant is a member or alumni of the PJ Library program as of September 1st, 2014." />
                                                        
                                                    </td>
                                                    <td style="width: 5px">
                                                    </td>
                                                </tr>                                                                                              
                                                <tr>
                                                    <td style="height: 10px" colspan="4">
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td colspan="4" align="center">
                                                        <asp:Button ID="btnSubmit" ValidationGroup="Submit" runat="server" Text="Submit"
                                                            CssClass="submitbtn" Width="100px" OnClick="btnSubmit_Click" />
                                                    </td>
                                                </tr>
                                             
                                                <tr>
                                                    <td style="height: 5px" colspan="4">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                        <tr>
                                             <td align="center"><asp:Label ID="lblThankYou" runat="server" Visible="false">Thank you for visiting <a href="http://www.onehappycamper.org" target= "_blank">www.onehappycamper.org</a>, you will be notified once your application is available</asp:Label> </td>
                                        </tr>
                                </table>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            <br />
                                <asp:Label ID="Label2" CssClass="QuestionText" runat="server"> <p style="text-align: justify">
                                        <b><font face="Verdana">Visit <a href="http://www.onehappycamper.org" target= "_blank">www.onehappycamper.org</a> to learn more about <a href="http://www.jewishcamp.org/happy-camper-eligibility" target= "_blank">eligibility</a> or to contact your One Happy Camper <a href="http://www.jewishcamp.org/contact-us" target= "_blank">Program administrator</a>.</font></b></p></asp:Label><br />
                                
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 10px" valign="bottom">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <uc1:CamperFooter ID="CamperFooter1" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 10px">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
