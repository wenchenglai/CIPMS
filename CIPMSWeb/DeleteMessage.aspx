<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common.master" CodeFile="DeleteMessage.aspx.cs" Inherits="DeleteMessage" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="DeleteMessage_1" ContentPlaceHolderID="Content" Runat="Server">
     <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td colspan="2" >
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3" >
                    <br /><br />
                    <p style="text-align:justify"> 
                        Thank you for applying for a One Happy Camper grant.
                    </p>
                    <p style="text-align:justify">
                        Our records indicate that you have begun an application for a camp-sponsored program after being informed that the camper is ineligible for a community-sponsored one.
                    </p>
                    <p>
                        Because the camper is ineligible for a community program, your initial application is no longer accessible. A new one has been created for the camp-sponsored program you have now selected.
                    </p>
                    <p>
                        The new application can be accessed by clicking on the FJC ID. (Example:  201510150060)
                    </p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" >
            <table width="100%" cellspacing="0" cellpadding="5" border="0">
                <tr>
                    <td style="width:25%"><asp:Button ID="btnPrevious"  Text=" << Previous" CssClass="submitbtn" runat="server" OnClick="btnPrevious_Click" /></td>
                    <td style="width:25%"></td>
                    <td style="width:25%" align="left"></td>
                    <%--<td style="width:25%" align="right"><asp:Button ID="btnSaveandExit"  Text="Save & Exit" CssClass="submitbtn" runat="server" OnClick="btnSaveandExit_Click" /></td>--%>
                </tr>
            </table>            
            </td>
        </tr>
     </table>     
</asp:Content>
