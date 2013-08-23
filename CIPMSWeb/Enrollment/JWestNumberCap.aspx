<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="JWestNumberCap.aspx.cs" Inherits="Enrollment_JWestNumberCap" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
<table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <br />
                   <p style="text-align:justify">
                   <b>Thank you for your interest in the JWest Campership Program. Unfortunately, the program has reached its capacity and is now closed.
                   </b></p>
                   <p style="text-align:justify"><b>
                   There may be another One Happy Camper incentive grant for which your first time camper may qualify. To learn more, please contact Wendy Aronson at 720-242-7482 or <a href="mailto:wendy@jewishcamp.org" target= "_blank" >wendy@jewishcamp.org</a>. Wendy is best reached from 9am-3pm MST. To expedite this process, please be sure to have your child’s camp registration information (camp name, session length etc) nearby.
                   </b></p>
                   <b>
                   <p><b>
                     Should you require financial aid to send your child to camp this summer, we invite you to speak directly with your local camp director, synagogue or Federation. For a list of additional scholarships, please visit <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a>.
                   </b></p>
                  
                    </asp:Label>
            </td>
        </tr>
     <tr>
                <td colspan="2">
                    <table width="85%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                            </td>
                             <td >
                                <asp:Button ID="btnPrevious" runat="server" Text=" << Previous" CssClass="submitbtn" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnSaveandExit" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                            </td>
                           
                        </tr>
                    </table>
                </td>
            </tr>
     </table>        
</asp:Content>

