<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RegisterControls.ascx.cs" Inherits="Enrollment_RegisterControls" %>
<table>
<tr>
<td class="rbtest"> <asp:RadioButton GroupName="RadioButtonQ7" value="2" Text="" ID="RadioButtonQ7Option2" runat="server"/>
</td>
<td class="testspan"><asp:Label ID="Label10" runat="server" Text="Yes, I have registered for camp (and have either been accepted, my child is on the waiting list, or I do not know the status of my camp application)"></asp:Label>
</td>
</tr>
<tr>
<td class="rbtest"><asp:RadioButton GroupName="RadioButtonQ7" value="1" Text="" ID="RadioButtonQ7Option1" runat="server" />
</td>
<td class="testspan">
<asp:Label ID="Label11" runat="server" Text="No, I have not yet registered for camp"></asp:Label> 
</td>
</tr>
</table> 