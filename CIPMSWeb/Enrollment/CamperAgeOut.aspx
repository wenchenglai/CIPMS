<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="CamperAgeOut.aspx.cs" Inherits="Enrollment_CamperAgeOut" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
<table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <br /><p style="text-align:justify"> 
                     Hello Camper Family!
                   <p style="text-align:justify">
                   Thank you for your continued interest in Jewish overnight summer camp. Our records indicate that your camper has already received two summers of funding through the JWest Campership Program. We are thrilled to have provided this funding toward Jewish summer camp for your child, however, as your child has received the maximum grant amount, we regret that we will not be able to offer your child additional funding this summer.
                   </p>
                   <p style="text-align:justify">
                   To explore other funding opportunities, we encourage you to reach out to your local synagogue or camp and inquire if funding is available. 
                   Additionally, the Foundation for Jewish Camp hosts an online scholarship directory of over 80 scholarships that can be viewed at 
                   <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a>.
                   </p>
                   <p style="text-align:justify">
                   We hope that the camper enjoys another wonderful, fun-filled summer at Jewish camp!
                   </p>
                   <p style="text-align:justify">
                Sincerely, 
               </p>
                    </asp:Label>
            </td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label1" CssClass="infotext3" runat="server">
                
                <p style="text-align:justify">
                Your friends at the Foundation for Jewish Camp <br />
                888-888-4819
               </p>
               
            </asp:Label></td>
        </tr>
     </table>        
</asp:Content>

