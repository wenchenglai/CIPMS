<%@ Page Language="C#" AutoEventWireup="true" Title="Camper Section Step 3" CodeFile="Step3_Parentinformation.aspx.cs" 
	MasterPageFile="~/Common.master" ValidateRequest="false" Inherits="Step3_Parentinformation" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<%@ Register Src="~/CamperFooter.ascx" TagName="CamperFooter" TagPrefix="uc1" %>
<asp:Content ID="ContentStep1" ContentPlaceHolderID="Content" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">
            <tr>
                <td colspan="2"><asp:Label ID="Label10" CssClass="headertext" runat="server" Text="Section VI:  Parent Contact Information"></asp:Label><br /><br /></td>
                
            </tr>
            <tr>
                <td colspan="2" align="center">
                     <!--to display the validation summary (error messages)-->
                    <table width="65%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                                <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="true" CssClass="InfoText" />
                                <!--this summary will be used only for Comments field (only for Admin user)-->
                                <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
                                <asp:CustomValidator ID="CusValComments" ValidationGroup="CommentsGroup" runat="server" Display="None" CssClass="InfoText" ErrorMessage = "Please enter the Comments" EnableClientScript="false"></asp:CustomValidator>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2"><asp:Label ID="Label11" CssClass="headertext1" runat="server" Text="Primary Parent/Guardian Information:"></asp:Label></td>
            </tr>
            <tr>
                <td width="22%"><asp:Label ID="Label26" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label1" CssClass="text" runat="server" Text="First Name"></asp:Label></td>
                <td><asp:TextBox CssClass="txtbox" ID="txtFirstName1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqvalFirstName" runat="server" ControlToValidate="txtFirstName1" Display="None" ErrorMessage="Please enter the First Name"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regexpFirstName" runat="server"  ValidationExpression="^[a-zA-Z'\s-]{1,50}$" ControlToValidate="txtFirstName1" Display="None" ErrorMessage="Please enter a valid First Name" />
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="Label27" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label2" CssClass="text" runat="server" Text="Last Name"></asp:Label></td>
                <td><asp:TextBox ID="txtLastName1" runat="server" CssClass="txtbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqvalLastName" runat="server" ControlToValidate="txtLastName1" Display="None" ErrorMessage="Please enter the Last Name"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexpLastName" runat="server"  ValidationExpression="^[a-zA-Z'\s-]{1,50}$" ControlToValidate="txtLastName1" Display="None" ErrorMessage="Please enter a valid Last Name" />
                </td>
            </tr>

            <tr>
                <td><asp:Label ID="Label28" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label4" CssClass="text" runat="server" Text="Street Address"></asp:Label></td>
                <td><asp:TextBox ID="txtAddress1" runat="server" CssClass="txtbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqvalAddress" runat="server" ControlToValidate="txtAddress1" Display="None" ErrorMessage="Please enter the Street Address"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="Label29" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label24" CssClass="text" runat="server" Text="Country"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlCountry1" runat="server" CssClass="txtbox" OnSelectedIndexChanged="ddlCountry1_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Text="USA" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Canada" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="Label30" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="lblState" CssClass="text" runat="server" Text="State"></asp:Label></td>
                <td><asp:DropDownList ID="ddlState1" runat="server" CssClass="txtbox"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqvalState" runat="server" ControlToValidate="ddlState1" InitialValue="0" Display="None" ErrorMessage="Please select the State"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="Label31" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label5" CssClass="text" runat="server" Text="City"></asp:Label></td>
                <td><asp:TextBox ID="txtCity1" runat="server" CssClass="txtbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqvalCity" runat="server" ControlToValidate="txtCity1" Display="None" ErrorMessage="Please enter the City"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <td><asp:Label ID="Label32" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="lblZip" CssClass="text" runat="server" Text="Zip Code"></asp:Label></td>
                <td><asp:TextBox ID="txtZipCode1" runat="server" CssClass="txtbox" AutoPostBack="True" OnTextChanged="txtZipCode1_TextChanged"></asp:TextBox>
                    <asp:Label ID="lblZipMask" runat="server" CssClass="text" Text="(12345)" Visible="False"></asp:Label>
                    <asp:RequiredFieldValidator ID="reqvalZipCode" runat="server" ControlToValidate="txtZipCode1" Display="None" ErrorMessage="Please enter a valid Zip Code following this sample: 12345"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regExpZipCode" runat="server" ControlToValidate="txtZipCode1" ValidationExpression="^(\d{5}(?:\-\d{4})?)$" Display="None" ErrorMessage="Please enter a valid Zip Code following this sample: 12345"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="Label33" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label8" CssClass="text" runat="server" Text="Home Phone"></asp:Label></td>
                <td><asp:TextBox ID="txtHomePhone1" runat="server" CssClass="txtbox"></asp:TextBox><asp:Label ID="Label37" CssClass="text" runat="server" Text=" (xxx-xxx-xxxx)"></asp:Label>
                <asp:RequiredFieldValidator ID="reqvalHomePhone" runat="server" ControlToValidate="txtHomePhone1" Display="None" ErrorMessage="Please enter the Home Phone"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexpHomePhone" runat="server" ControlToValidate="txtHomePhone1" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Display="None" ErrorMessage="Please enter a valid Home Phone"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
            <td colspan="2" style="padding-top:20px">
            <asp:Label ID="Label3" CssClass="InfoText3" runat="server"><b>Please enter a valid email address - we will use this information to contact you about your grant.</b></asp:Label>
            </td>
            </tr>
            <tr>
                <td><asp:Label ID="Label34" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label7" CssClass="text" runat="server" Text="Personal E-mail"></asp:Label></td>
                <td><asp:TextBox ID="txtPersonalEmail1" runat="server" CssClass="txtbox"></asp:TextBox><asp:Label ID="Label39" CssClass="text" runat="server" Text=" (e.g. xxx@yahoo.com)"></asp:Label>
                <asp:RequiredFieldValidator ID="reqvalEmail" runat="server" ControlToValidate="txtPersonalEmail1" Display="None" ErrorMessage="Please enter your Email ID"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regExpEmail" runat="server" ControlToValidate="txtPersonalEmail1" ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$" Display="None" ErrorMessage="Please enter a valid Personal Email ID"></asp:RegularExpressionValidator>
                </td>
            </tr>
             <tr>
                <td><asp:Label ID="Label41" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label42" CssClass="text" runat="server" Text="Confirm E-mail"></asp:Label></td>
                <td><asp:TextBox ID="txtPersonalEmail1Confirm" runat="server" CssClass="txtbox"></asp:TextBox><asp:Label ID="Label43" CssClass="text" runat="server" Text=" (e.g. xxx@yahoo.com)"></asp:Label>
                <asp:RequiredFieldValidator ID="reqvalEmail1" runat="server" ControlToValidate="txtPersonalEmail1Confirm" Display="None" ErrorMessage="Please re-enter your personal Email ID to confirm"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regExpEmail1" runat="server" ControlToValidate="txtPersonalEmail1Confirm" ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$" Display="None" ErrorMessage="Please enter a valid Personal Email ID to confirm"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="CompValEmail" runat="server" ControlToCompare="txtPersonalEmail1" ControlToValidate="txtPersonalEmail1Confirm" Type="String" Display="none" ErrorMessage="Personal Email and the Confirm Email should match"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;<asp:Label ID="Label9" CssClass="text" runat="server" Text="Work Phone"></asp:Label></td>
                <td><asp:TextBox ID="txtWorkPhone1" runat="server" CssClass="txtbox"></asp:TextBox><asp:Label ID="Label38" CssClass="text" runat="server" Text=" (xxx-xxx-xxxx)"></asp:Label>
                    <asp:RegularExpressionValidator ID="regWorkPhone1" runat="server" ControlToValidate="txtWorkPhone1" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Display="None" ErrorMessage="Please enter a valid Work Phone" /></td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;<asp:Label ID="Label12" CssClass="text" runat="server" Text="Work E-mail"></asp:Label></td>
                <td><asp:TextBox ID="txtWorkEmail1" runat="server" CssClass="txtbox"></asp:TextBox><asp:Label ID="Label40" CssClass="text" runat="server" Text=" (e.g. xxx@yahoo.com)"></asp:Label>
                    
                </td>
            </tr>
              <tr>
                <td colspan="2" style="padding-top:20px"><asp:Label ID="Label13" CssClass="headertext1" runat="server" Text="Secondary Parent/Guardian Information:"></asp:Label></td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;<asp:Label ID="Label14" CssClass="text" runat="server" Text="First Name"></asp:Label></td>
                <td><asp:TextBox CssClass="txtbox" ID="txtFirstName2" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regP2FirstName" runat="server"  ValidationExpression="^[a-zA-Z'\s-]{1,50}$" ControlToValidate="txtFirstName2" Display="None" ErrorMessage="Please enter a valid First Name" /></td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;<asp:Label ID="Label15" CssClass="text" runat="server" Text="Last Name"></asp:Label></td>
                <td><asp:TextBox ID="txtLastName2" runat="server" CssClass="txtbox"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regP2LastName" runat="server"  ValidationExpression="^[a-zA-Z'\s-]{1,50}$" ControlToValidate="txtLastName2" Display="None" ErrorMessage="Please enter a valid Last Name" /></td>
            </tr>

            <tr>
                <td>&nbsp;&nbsp;<asp:Label ID="Label16" CssClass="text" runat="server" Text="Street Address"></asp:Label></td>
                <td><asp:TextBox ID="txtAddress2" runat="server" CssClass="txtbox"></asp:TextBox></td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;<asp:Label ID="Label25" CssClass="text" runat="server" Text="Country"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlCountry2" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry2_SelectedIndexChanged">
                        <asp:ListItem Text="USA" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Canada" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;<asp:Label ID="lblState2" CssClass="text" runat="server" Text="State"></asp:Label></td>
                <td><asp:DropDownList ID="ddlState2" runat="server" CssClass="txtbox"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;<asp:Label ID="Label17" CssClass="text" runat="server" Text="City"></asp:Label></td>
                <td><asp:TextBox ID="txtCity2" runat="server" CssClass="txtbox"></asp:TextBox></td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;<asp:Label ID="lblZip2" CssClass="text" runat="server" Text="Zip Code"></asp:Label></td>
                <td><asp:TextBox ID="txtZipCode2" runat="server" CssClass="txtbox" AutoPostBack="True" OnTextChanged="txtZipCode2_TextChanged"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regP2Zip" runat="server" ControlToValidate="txtZipCode2" ValidationExpression="^(\d{5}(?:\-\d{4})?)$" Display="None" ErrorMessage="Please enter a valid Zip Code following this sample: 12345" /></td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;<asp:Label ID="Label20" CssClass="text" runat="server" Text="Home Phone"></asp:Label></td>
                <td><asp:TextBox ID="txtHomePhone2" runat="server" CssClass="txtbox"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regP2HomePhone" runat="server" ControlToValidate="txtHomePhone2" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Display="None" ErrorMessage="Please enter a valid Home Phone" /></td>
            </tr>
            <tr>
                <td>&nbsp;<asp:Label ID="Label21" CssClass="text" runat="server" Text=" Personal E-mail"></asp:Label></td>
                <td><asp:TextBox ID="txtPersonalEmail2" runat="server" CssClass="txtbox"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regP2PersonalEmail" runat="server" ControlToValidate="txtPersonalEmail2" ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$" Display="None" ErrorMessage="Please enter a valid Personal Email ID" /></td>
            </tr>

            <tr>
                <td>&nbsp;&nbsp;<asp:Label ID="Label22" CssClass="text" runat="server" Text="Work Phone"></asp:Label></td>
                <td><asp:TextBox ID="txtWorkPhone2" runat="server" CssClass="txtbox"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regP2WorkPhone" runat="server" ControlToValidate="txtWorkPhone2" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Display="None" ErrorMessage="Please enter a valid Work Phone" /></td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;<asp:Label ID="Label23" CssClass="text" runat="server" Text="Work E-mail"></asp:Label></td>
                <td><asp:TextBox ID="txtWorkEmail2" runat="server" CssClass="txtbox"></asp:TextBox>
               </td>
            </tr>
            <!-- Admin Panel-->
            <tr>
                <td colspan="2" align="center">
                    <asp:Panel ID="PnlAdmin" runat="server" Visible="false">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td width="22%"><asp:Label ID="Label36" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label35" CssClass="text" runat="server" Text="Comments"></asp:Label></td>
                                <td><asp:TextBox ID="txtComments" runat="server" CssClass="txtbox2" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:CustomValidator ID="CusValComments1" runat="server" Display="None" CssClass="InfoText" ErrorMessage = "Please enter the Comments" EnableClientScript="false"></asp:CustomValidator>
                </td>
            </tr>
            <!--end of admin panel-->
            <tr>
                <td colspan="2">
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td  align="left" style="height: 20px"><asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" /></td>
                            <td style="height: 20px" ><asp:Button ID="btnPrevious" ValidationGroup="CommentsGroup" runat="server" Text=" << Previous" CssClass="submitbtn" /></td>
                            <td style="height: 20px" >
                                <asp:Button ID="btnSaveandExit" ValidationGroup="CommentsGroup" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                            </td>
                            <td style="height: 20px" ><asp:Button ID="btnNext" runat="server"  Text="Next >>" CssClass="submitbtn" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:HiddenField ID="hdnFJCID_ParentInfo" runat="server" />
    <asp:HiddenField ID="hdnPerformAction" runat="server" />
</asp:Content>
