<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="Administration_ChangePwd" %>
<asp:Content ID="ContentChangePwd" ContentPlaceHolderID="Content" Runat="Server">
    <table class="text" width="100%">
        <tr class="InfoText">
            <td>
                <asp:Label ID="lblMsg" runat="server" /></td></tr>
    </table> 
    <table class="text" border="1" cellpadding="0" cellspacing="0" style="border-color:Red" width="100%">
        <tr>
            <td>
                <table class="text">
                    <tr>
                        <td colspan="3" style="height:10px">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                        </td></tr>
                    <tr>
                        <td>Old Password</td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtOldPwd" runat="server" CssClass="txtbox" TextMode="Password" Width="150px" /></td></tr>
                    <tr>
                        <td>New Password</td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" CssClass="txtbox" Width="150px" /></td></tr>
                    <tr>
                        <td>Confirm New Password</td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtConfmNewPwd" runat="server" CssClass="txtbox" TextMode="Password" Width="150px" /></td></tr>
                    <tr>
                        <td colspan="3" style="height:10px">
                            <asp:CompareValidator ID="cmpvld" runat="server" Display="None" Operator="equal"
                                ControlToCompare="txtConfmNewPwd" Type="string"  ControlToValidate="txtNewPwd" 
                                ErrorMessage="New password and confirm password are not same" />
                            <asp:CompareValidator ID="cmpvldPwds" runat="server" ControlToCompare="txtNewPwd"
                                ControlToValidate="txtOldPwd" Display="None" ErrorMessage="Old password and new password are same"
                                Operator="NotEqual" /></td></tr>
                    <tr>
                        <td colspan="3" align="right">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="submitbtn1" Width="100px" OnClick="btnSubmit_Click" /></td></tr>
                    <tr>
                        <td colspan="3" style="height:10px"></td></tr>
                </table></td></tr>
    </table>                                            
</asp:Content>

