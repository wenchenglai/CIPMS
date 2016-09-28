<%@ Page Title="" Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="CamperHoldingSimple.aspx.cs" Inherits="CamperHoldingSimple" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
      <table width="100%" cellpadding="5" cellspacing="0">
    <tr>
      <td valign="middle">
        <br />
        <asp:Panel ID="PanelNLIntermediate" runat="server" Visible="true" Width="100%" >
          <table cellpadding="10" cellspacing="0">
            <tr>    
              <td>
                <asp:Label ID="Label15" runat="server" Font-Bold="true" CssClass="infotext3" > 
                  Your community's One Happy Camper Application is not yet available for summer 2017. Please call the professional listed at the bottom of this page for more information.        
                </asp:Label>
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
  <asp:Panel ID="Panel1" runat="server" Visible="false">
    <table width="100%" cellpadding="1" cellspacing="0" border="0">            
      <tr>
        <td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
        <td valign="top" ><br />
          <table width="100%" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td align="left">
                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" />
              </td>
              <td>
                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" />
              </td>
              <td align="center">
                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
              </td>
              <td align="right">
                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" Enabled="false" Visible="false"/>
              </td>                          
            </tr>
          </table>
        </td>
      </tr>
    </table>        
  </asp:Panel>
</asp:Content>

