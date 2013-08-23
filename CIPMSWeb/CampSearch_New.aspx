<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="CampSearch_New.aspx.cs"
    Inherits="CampSearch_New" %>

<asp:Content ID="ContentStep1" ContentPlaceHolderID="Content" runat="Server">
    <table>
        <tr>
            <td>
                <div>
                <asp:Label ID="Label3" runat="server" CssClass="lblPopup2">
                You can save your work and continue later after you have registered for camp by logging back onto OneHappyCamper.org using the same log-in email you used to start this session.
                </asp:Label>
                    <%--<asp:Label ID="Label1" runat="server" CssClass="lblPopup1">
            <br />You must register for a camp to be eligible for the Incentive grant <br /><br />          
                    </asp:Label>
                    <asp:Label ID="Label2" runat="server" CssClass="lblPopup2">
            To view a list of 150 eligible camps please click here - <br />
            
            <a href="http://www.jewishcamp.org/camps" target="_blank" id="campSearchLink1" style="display:none;">http://www.jewishcamp.org/camps</a>
            <a href="http://www.onehappycamper.org/faq-western.html" target="_blank" id="campSearchLink2" style="display:none;">http://www.onehappycamper.org/faq-western.html</a>.
            <br /><br />
            <script language="javascript" type="text/javascript">
            var openerurl = new String(opener.location);            
            var indexOf = openerurl.indexOf("JWest");
            
            var campSearchLink1 = document.getElementById("campSearchLink1");
            var campSearchLink2 = document.getElementById("campSearchLink2");
            
            if(indexOf == -1){
                campSearchLink1.style.display = "inline";
                }
            else{
                    campSearchLink2.style.display = "inline";
                }
            </script>
            <%--<a href="http://www.jewishcamp.org/fjc/global/find_a_jewish_camp.asp?section=parents" target="_blank">http://www.jewishcamp.org/fjc/global/find_a_jewish_camp.asp?section=parents</a>.<br /><br />--%>
                      <%--</asp:Label>
                    <asp:Label ID="Label3" runat="server" CssClass="lblPopup2">
            If you already know the camp that the camper wishes to attend, please save your application form, register with the camp directly, and then come back here to complete and submit the camper's incentive application. 
                    </asp:Label>--%>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
