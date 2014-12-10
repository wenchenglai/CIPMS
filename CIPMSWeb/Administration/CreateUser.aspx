<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" MasterPageFile="~/AdminMaster.master" Inherits="Administration_CreateUser" %>
<%@ MasterType VirtualPath="~/AdminMaster.master" %>
<asp:Content ID="CreateUsr" ContentPlaceHolderID="Content" runat="server" >
    <script type="text/javascript" language="javascript">
        function ValidateControls(){
            var Role = document.getElementById('<%=ddlRole.ClientID %>');
            var reqRole = document.getElementById('<%=rfvRole.ClientID %>');
            var FedLst = document.getElementById('<%=lstFed.ClientID %>');
            var reqFed = document.getElementById('<%=rfvFed.ClientID %>');
            var MovementsLst = document.getElementById('<%=lstMovements.ClientID %>');

            if (Role.value == '-1') // Nothing
            {
                FedLst.value = '';
                reqRole.enabled = true;
                reqRole.enabled = true;
                FedLst.disabled = false;
                reqFed.enabled = true;

                MovementsLst.disabled = false;
            }

            if (Role.value == '1' || Role.value == '5') //FJC Admin
            {
                FedLst.value = '';
                FedLst.disabled = true;
                reqFed.enabled = false;
                MovementsLst.value = '';
                MovementsLst.disabled = true;
            }
            
            if (Role.value == '2') //Federation Admin
            {

                FedLst.disabled = false;
                reqFed.enabled = true;
                MovementsLst.value = '';
                MovementsLst.disabled = true;
            }
            
            // Movements Admin
            if (Role.value == '6') {

                FedLst.disabled = true;
                reqFed.enabled = true;

                MovementsLst.disabled = false;
            }                        
        }
    </script>  
    <table class="text" width="100%">
        <tr class="infotext1">
            <td>
                <asp:Label ID="lblMsg" runat="server" /></td></tr>
    </table>      
    <table class="text" border="1" cellpadding="0" cellspacing="0" style="border-color:Red" width="100%">
        <tr>
            <td>
                <table class="text" width="100%">
                    <tr>
                        <td colspan="7" style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <asp:ValidationSummary ID="vldsumErr" runat="server" />
                        </td></tr>
                    <tr>
                        <td colspan="7" style="height: 10px"></td></tr>
                    <tr>
                        <td class="headertext1">First Name</td>
                        <td style="width:5px"></td>
                        <td>
                            <asp:TextBox ID="txtFirstNm" runat="server" CssClass="txtbox1" MaxLength="50" Width="150px" /></td>
                        <td style="width:10px"></td>
                        <td class="headertext1">Last Name</td>
                        <td style="width:5px"></td>
                        <td>
                            <asp:TextBox ID="txtLastNm" runat="server" CssClass="txtbox1" MaxLength="50" Width="150px" /></td></tr>
                    <tr>
                        <td colspan="2"></td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvFNm" runat="server" ControlToValidate="txtFirstNm"
                                Display="None" ErrorMessage="Please enter the First Name" />
                            <asp:RegularExpressionValidator ID="revFNm" runat="server" ControlToValidate="txtFirstNm"
                                Display="None" ErrorMessage="Please use letters A-Z (') and (-) for First Name"
                                ValidationExpression="^[a-zA-Z'\s-]{1,50}$" /></td>
                        <td colspan="3"></td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvLNm" runat="server" ControlToValidate="txtLastNm"
                                Display="None" ErrorMessage="Please enter the Last Name" />
                            <asp:RegularExpressionValidator ID="revLNm" runat="server" ControlToValidate="txtLastNm"
                                Display="None" ErrorMessage="Please use letters A-Z (') and (-) for First Name"
                                ValidationExpression="^[a-zA-Z'\s-]{1,50}$" /></td></tr>
                    <tr>
                        <td class="headertext1" rowspan="2">Phone Number</td>
                        <td style="width:5px" rowspan="2"></td>
                        <td rowspan="2">
                            <asp:TextBox ID="txtPhNo" runat="server" CssClass="txtbox1" MaxLength="12" Width="150px" /></td>
                        <td style="width:10px" rowspan="2"></td>
                        <td class="headertext1" rowspan="2">Email ID</td>
                        <td style="width:5px" rowspan="2"></td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="txtbox1" MaxLength="150" Width="150px" /></td></tr>
                    <tr>
                        <td class="infotext1">(This is also the Login ID)</td></tr>
                    <tr>
                        <td colspan="2"></td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhNo"
                                Display="None" ErrorMessage="Please enter the Phone Number" />
                            <asp:RegularExpressionValidator ID="revPhNo" runat="server" ControlToValidate="txtPhNo"
                                Display="None" ErrorMessage="Please enter valid phone number" 
                                ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" /></td>
                        <td colspan="3"></td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                Display="None" ErrorMessage="Please enter Email ID" />
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                Display="None" ErrorMessage="Please enter the Email ID in correct format" 
                                ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$" /></td></tr>
                    <tr>
                        <td class="headertext1">Password</td>
                        <td style="width:5px"></td>
                        <td>
                            <asp:TextBox ID="txtPwd" runat="server" CssClass="txtbox1" MaxLength="50" TextMode="Password" Width="150px" /></td>
                        <td style="width:10px"></td>
                        <td class="headertext1">Role</td>
                        <td style="width:5px"></td>
                        <td>
                            <asp:DropDownList ID="ddlRole" runat="server" Width="150px" CssClass="dropdown" /></td></tr>
                    <tr>
                        <td colspan="2"></td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvPwd" runat="server" ControlToValidate="txtPwd"
                                Display="None" ErrorMessage="Please enter the Password" /></td>
                        <td colspan="3"></td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvRole" runat="server" ControlToValidate="ddlRole"
                                Display="None" ErrorMessage="Please select a Role" Enabled="False" /></td></tr>
                    <tr>
                        <td class="headertext1">Camp Movements</td>
                        <td style="width:5px"></td>
                        <td colspan="5">
                            <asp:ListBox ID="lstMovements" runat="server" SelectionMode="Multiple" CssClass="text" Width="500px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="headertext1">Federation</td>
                        <td style="width:5px"></td>
                        <td colspan="5">
                            <asp:ListBox ID="lstFed" runat="server" Width="500px" CssClass="text" /></td></tr> 
                    <tr>
                        <td colspan="7" style="height: 10px"></td></tr>
                 <!--   <tr>
                        <td class="headertext1">Camps</td>
                        <td style="width:5px"></td>
                        <td colspan="5">
                            <asp:ListBox ID="lstCamps" runat="server" SelectionMode="Multiple" CssClass="text" Width="500px" />
                        </td>
                    </tr>-->
                    <tr>
                        <td colspan="2"></td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvFed" runat="server" ControlToValidate="lstFed"
                                Display="None" ErrorMessage="Please select a Federation" Enabled="False" /></td>
                        <td colspan="3"></td>
                        <td>
                            <asp:TextBox ID="txtHidCamps" runat="server" Height="0px" Width="0px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCamps" runat="server" ControlToValidate="lstCamps"
                                Display="None" ErrorMessage="Please select at least one Camp" Enabled="False" /></td></tr>
                    <tr>
                        <td colspan="3">
                       <td align="right" colspan="4">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="submitbtn" OnClick="btnSubmit_Click" /></td></tr>
                    <tr>
                        <td colspan="7" style="height:10px"></td></tr>
                </table></td></tr>
    </table>

</asp:Content>