<%@ Page Title="" Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_GanIsrael_Summary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
  <asp:Label ID="Label5" CssClass="infotext3" runat="server">
    <p style="text-align:justify">
      Thank you for your interest in Camp Gan Israel's Bat-Mitzvah Experience incentive opportunities. 
      For more information on how to apply, please contact Gershon Sandler at <a href="mailto:gsandler@cgibme.org" target="_blank">gsandler@cgibme.org</a> or (845) 425-0903.
    </p>
  </asp:Label>
  
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">            
            <tr>
                <td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" ><br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td  align="left"></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                                
                                </td>
                            <td align="right">
                                </td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel> 
</asp:Content>

