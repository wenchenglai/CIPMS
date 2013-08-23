<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="ThankYouMessage.aspx.cs" Inherits="ThankYouMessage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
 <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <br /><p style="text-align:justify"> 
                     <b><font color="black">Thank you for beginning an incentive application!</font></b> 
                    </p></asp:Label>
            </td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label1" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                <b><font color="red">Please note: Your application is not yet complete, and <b><u>has not been submitted</u></b>. Your information will be saved and is available for you to access in the future. We hope you will return soon to complete and submit your application. Thank You!</font></b>                 
               </p>
            </asp:Label></td>
        </tr>
     </table>        
</asp:Content>

