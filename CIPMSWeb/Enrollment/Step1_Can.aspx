<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Step1_Can.aspx.cs" MasterPageFile="~/Common.master" Title="Camper Enrollment Step I" Inherits="Step1_Can" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<%@ Register Src="~/CamperFooter.ascx" TagName="CamperFooter" TagPrefix="uc1" %>

<asp:Content ID="ContentStep1" ContentPlaceHolderID="Content" Runat="Server">    
  
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <p class="headertext">Basic Camper Information: Section I</p>
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td>
                    <asp:Label ID="lblInfo" runat="server" CssClass="headertext1">Please note that your screen may flash as you enter application information. This is a normal feature.</asp:Label>
                </td>
            </tr>
        </table>
        <asp:Panel ID="Panel1" runat="server">
            <table width="100%" cellpadding="1" cellspacing="0" border="0">
                <tr><td colspan="2" align="center">
                    <!--to display the validation summary (error messages)-->
                    <table width="75%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                                <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="true" CssClass="InfoText" />
                                <!--this summary will be used only for Comments field (only for Admin user)-->
                                <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
                                <asp:CustomValidator ID="CusValComments" runat="server" Display="None" CssClass="InfoText" ErrorMessage = "Please enter the Comments" EnableClientScript="false"></asp:CustomValidator>
                            </td>
                        </tr>
                    </table>
                </td></tr>
                <tr>
                    <td width="25%"  nowrap="nowrap">
                        <asp:Label ID="Label11" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label1" CssClass="text" runat="server" Text="Camper First Name"></asp:Label></td>
                    <td ><asp:TextBox CssClass="txtbox" ID="txtFirstName" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqvalFirstName" runat="server" ControlToValidate="txtFirstName" Display="None" ErrorMessage="Please enter the First Name"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regexpFirstName" runat="server"  ValidationExpression="^[a-zA-Z'\s-]{1,50}$" ControlToValidate="txtFirstName" Display="None" ErrorMessage="Please enter a valid First Name" />
                    </td>
                    
                </tr>
                <tr>
                    <td><asp:Label ID="Label12" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label2" CssClass="text" runat="server" Text="Camper Last Name"></asp:Label></td>
                    <td ><asp:TextBox ID="txtLastName" runat="server" CssClass="txtbox" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqvalLastName" runat="server" ControlToValidate="txtLastName" Display="None" ErrorMessage="Please enter the Last Name"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regexpLastName" runat="server"  ValidationExpression="^[a-zA-Z'\s-]{1,50}$" ControlToValidate="txtLastName" Display="None" ErrorMessage="Please enter a valid Last Name" />
                    </td>
                    
                </tr>

                <tr>
                    <td><asp:Label ID="Label15" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label10" CssClass="text" runat="server" Text="Camper Country"></asp:Label></td>
                    <td >
                        <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" CssClass="txtbox" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                            <asp:ListItem Text="USA" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Canada" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    
                </tr>
                <tr>
                    <td><asp:Label ID="Label13" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label3" CssClass="text" runat="server" Text="Camper Zip Code"></asp:Label></td>
                    <td ><asp:TextBox ID="txtZipCode" runat="server" CssClass="txtbox" MaxLength="5" AutoPostBack="true" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqvalZipCode" runat="server" ControlToValidate="txtZipCode" Display="None" ErrorMessage="Please enter the Zip Code"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regExpZipCode" runat="server" ControlToValidate="txtZipCode" ValidationExpression="^(\d{5}(?:\-\d{4})?)$" Display="None" ErrorMessage="Please enter a valid Zip Code"></asp:RegularExpressionValidator>
                    </td>
                    
                </tr>
                <tr>
                    <td><asp:Label ID="Label14" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label4" CssClass="text" runat="server" Text="Camper Street Address"></asp:Label></td>
                    <td ><asp:TextBox ID="txtAddress" runat="server" CssClass="txtbox" MaxLength="200" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqvalAddress" runat="server" ControlToValidate="txtAddress" Display="None" ErrorMessage="Please enter the Street Address"></asp:RequiredFieldValidator>
                    </td>
                    
                </tr>

                <tr>
                    <td valign="middle"><asp:Label ID="Label17" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label5" CssClass="text" runat="server" Text="Camper City"></asp:Label></td>
                    <td >
                        <asp:DropDownList ID="ddlCity" runat="server"  CssClass="txtbox" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqvalCity" runat="server" ControlToValidate="ddlCity" InitialValue="0" Display="None" ErrorMessage="Please select the City"></asp:RequiredFieldValidator>                       
                   
                        <br/><asp:Label ID="Label24" runat="server" CssClass="QuestionText">Others (type in)</asp:Label>
                        <asp:TextBox ID="txtCityOthers" runat="server" CssClass="txtbox4" Width="205px" MaxLength="40"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqvalCityOther" runat="server" ControlToValidate="txtCityOthers" Display="None" ErrorMessage="Please type in the Name of the City"></asp:RequiredFieldValidator>
                   
                    </td>
                    
                   
                   
                </tr>
                <tr>
                    <td><asp:Label ID="Label16" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label6" CssClass="text" runat="server" Text="Camper State"></asp:Label></td>
                    <td >
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="txtbox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqvalState" runat="server" ControlToValidate="ddlState" InitialValue="0" Display="None" ErrorMessage="Please select the State"></asp:RequiredFieldValidator>
                    </td>
                    
                </tr>
                <tr>
                    <td><asp:Label ID="Label18" CssClass="InfoText" Visible="false" runat="server" Text="*"></asp:Label>&nbsp;&nbsp;<asp:Label ID="Label7" CssClass="text" runat="server" Text="Camper E-mail"></asp:Label></td>
                    <td ><asp:TextBox ID="txtEmail" runat="server" CssClass="txtbox" MaxLength="150"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqvalEmail" runat="server" ControlToValidate="txtEmail" Enabled="false" Display="None" ErrorMessage="Please enter your Email ID"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regExpEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$" Display="None" ErrorMessage="Please enter a valid Email ID"></asp:RegularExpressionValidator>
                    </td>
                    
                    
                </tr>
                <tr>
                    <td><asp:Label ID="Label19" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label8" CssClass="text" runat="server" Text="Camper Date of Birth"></asp:Label></td>
                    <td ><asp:TextBox onblur="getAge(this);" ID="txtDOB" runat="server" MaxLength="10" CssClass="txtbox"></asp:TextBox><asp:Label ID="lblDateFormat" runat="server" CssClass="infotext" Text="(MM/DD/YYYY)"></asp:Label>
                    <asp:RequiredFieldValidator ID="reqvalDOB" runat="server" ControlToValidate="txtDOB" Display="None" ErrorMessage="Please enter your Date of Birth"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator Enabled="false" ID="regExpDOB" runat="server" ControlToValidate="txtDOB" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$" Display="None" ErrorMessage="Please enter a valid Date of Birth"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator Enabled="true" ID="regExpDOB1" runat="server" ControlToValidate="txtDOB" ValidationExpression="^\d{1,2}\/\d{1,2}\/\d{4}$" Display="None" ErrorMessage="Please enter a valid Date of Birth in (MM/DD/YYYY) format"></asp:RegularExpressionValidator>
                    <asp:RangeValidator ID="rangeDOB" runat="server" ControlToValidate="txtDOB" Type="Date" Display="none"></asp:RangeValidator>
                    </td>
                    
                </tr>
                
                <tr>
                    <td><asp:Label ID="Label23" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label9" CssClass="text" runat="server" Text="Camper Age"></asp:Label></td>
                    <td ><asp:TextBox ID="txtAge" runat="server" CssClass="txtbox" ></asp:TextBox></td>
                    
                </tr>
 
 
                 <tr>
                    <td><asp:Label ID="lblStarGender" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label22" CssClass="text" runat="server" Text="Camper Gender"></asp:Label></td>
                    <td >                     
                        <asp:DropDownList ID="ddlGender" runat="server" Width="126px" CssClass="txtbox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" ControlToValidate="ddlGender" InitialValue="0" Display="None" ErrorMessage="Please select the Gender"></asp:RequiredFieldValidator>

                    </td>
                    
                </tr>
                
                <tr>
                    <td colspan="3">
                        <asp:Panel ID="PnlAdmin" runat="server" Visible="false">
                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td width="25%"><asp:Label ID="Label21" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label20" CssClass="text" runat="server" Text="Comments"></asp:Label></td>
                                    <td><asp:TextBox ID="txtComments" runat="server" CssClass="txtbox2" TextMode="MultiLine"></asp:TextBox></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:CustomValidator ID="CusValComments1" ValidationGroup="CommentsGroup" runat="server" Display="None" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
                    </td>
                </tr>
                <tr><td colspan="3">&nbsp;</td></tr>
                
                <tr>
                    <td></td>
                    <td  >
                        <asp:Label Height="30" ID="lblMessage" runat="server" CssClass="InfoText" Visible="false"></asp:Label>
                    </td>
                    
                </tr>
                
                <tr>
                    <td colspan="2">
                        <table width="85%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td></td>
                                <td  align="left"><asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary" CssClass="submitbtn1" /></td>
                                <td  align="left"><asp:Button CausesValidation="false" ValidationGroup="CommentsGroup" ID="btnSaveandExit" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" /></td>
                                <td ><asp:Button ID="btnNext" runat="server" Text="Next >>"  CssClass="submitbtn"  /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:HiddenField ID="hdnFJCID" runat="server" />
        <asp:HiddenField ID="hdnPerformAction" runat="server" />
</asp:Content>




