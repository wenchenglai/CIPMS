<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="CampMessage.aspx.cs" Inherits="Enrollment_Adamah_CampMessage" %>

<asp:Content ID="Adamah_CampMessage" ContentPlaceHolderID="Content" Runat="Server">
     <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <br /><p style="text-align:justify"> 
                     <b><font color="red">You must register for Eden Village Camp to be eligible for the Incentive grant.</font></b> 
                    </p></asp:Label>
            </td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label1" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                <b><font color="red">Visit <a href="http://www.edenvillagecamp.org" target="_blank">www.edenvillagecamp.org</a> to register now! Before you go, 
                be sure to click “save and exit” at the bottom of your screen so your information is saved. 
                After your registration at camp confirmed, please come back to complete and submit your application.
                </font></b>                 
               </p>
            </asp:Label></td>
        </tr>
     </table>        

</asp:Content>
