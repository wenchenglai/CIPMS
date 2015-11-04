<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrackMyStatus.aspx.cs" MasterPageFile="~/Common.master" Inherits="TrackMyStatus" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentTrackMyStatus" ContentPlaceHolderID="Content" Runat="Server">
<table class="text" border="0" cellpadding="0" cellspacing="0"  width="100%">
    <tr>
        <td>
            <table class="text" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr class="InfoText">
                    <td></td>
                    <td colspan="11">
                        <asp:Label ID="lblErr" runat="server" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="height:10px" colspan="13"></td></tr>
                <tr>
                    <td colspan="11">
                        <p class="headertext">Track My Grant</p>
                    </td>
                </tr>
                <tr style="height:20px"><td></td></tr>
                <tr><td></td></tr>
                <tr>
                    <td colspan="11">
                        <p class="lblPopup1" style="text-align:justify">Welcome parent! This page will allow you to track the status of your camper's application. If you have questions at any point, please contact the staff member listed below. Thank you!</p>
                    </td>
                </tr>
                <tr height="20px"><td></td></tr>
                <tr height="15px">
                    <td style="width:5px"></td>
                    <td class="headertext1">FJCID:</td>
                    <td style="width: 10px" align="center"></td>
                    <td>
                        <asp:Label ID="lblFJCID" runat="server" /></td>
                </tr>
                <tr style="height:10px"><td></td></tr>
                <tr height="15px">
                    <td style="width:5px"></td>
                    <td class="headertext1" nowrap>Camper Name:</td>
                    <td style="width: 10px" align="center"></td>
                    <td>
                        <asp:Label ID="lblCamperName" runat="server" /></td>
                </tr>
                <tr style="height:10px"><td></td></tr>
                <tr height="15px">
                    <td style="width:5px"></td>
                    <td class="headertext1" nowrap>Camp:</td>
                    <td style="width: 10px" align="center"></td>
                    <td>
                        <asp:Label ID="lblCamp" runat="server" /></td>
                </tr>
                <tr style="height:10px"><td></td></tr>
                <tr height="15px">
                    <td style="width:5px"></td>
                    <td class="headertext1" nowrap>Pending Grant Amount:</td>
                    <td style="width: 10px" align="center"></td>
                    <td>
                        <asp:Label ID="lblGrnatAmount" runat="server" /></td>
                </tr>
                <tr style="height:10px"><td></td></tr>
                <tr height="15px">
                    <td style="width:5px"></td>
                    <td class="headertext1" nowrap valign="top">Application Status:</td>
                    <td style="width: 10px" align="center"></td>
                    <td valign="top">
                        <asp:Label ID="lblAppicationStatus" runat="server" /></td>
                </tr>
                <tr style="height:10px"><td></td></tr>
                <tr height="15px" style="visibility:collapse">
                    <td style="width:5px"></td>
                    <td class="headertext1" nowrap valign="top">Contact Information:</td>
                    <td style="width: 10px" align="center"></td>
                    <td valign="top">
                        <asp:Label ID="lblContactInfo" runat="server" />
                        <a id="lnkcamper" href="https://www.onehappycamper.org/eligibility_jwest.html" target="_blank" visible="false" runat="server">here</a>
                        <br />
                        <asp:Label ID="lblPhone" runat="server" Visible="false" />
                        <br />
                        <asp:Label ID="lblEmail" Visible="false" runat="server" />
                    </td>
                </tr>
                <tr height="20px"><td></td></tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="submitbtn" Width="100px" OnClick="btnBack_Click"  />
                        <asp:Button ID="btnViewapplication" runat="server" Text="View Application" CssClass="submitbtn" Width="100px" OnClick="btnViewapplication_Click"  />
                        <asp:Button ID="btnSaveandExit" runat="server" Text="Save & Continue Later" CssClass="submitbtn1"  OnClick="btnSaveandExit_Click"  Visible="false"/>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>    
</asp:Content>