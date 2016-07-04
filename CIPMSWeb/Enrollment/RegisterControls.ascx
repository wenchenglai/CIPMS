<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RegisterControls.ascx.cs" Inherits="Enrollment_RegisterControls" %>
<table>
    <tr>
        <td class="rbtest">
            <asp:RadioButton GroupName="RadioButtonQ7" value="2" Text="" ID="RadioButtonQ7Option2" runat="server" />
        </td>
        <td class="testspan">
            Yes, I have registered for camp (and have either been accepted, my child is on the waiting list, or I do not know the status of my camp application)
        </td>
    </tr>
    <tr>
        <td class="rbtest">
            <asp:RadioButton GroupName="RadioButtonQ7" value="1" Text="" ID="RadioButtonQ7Option1" runat="server" />
        </td>
        <td class="testspan">
            No, I have not yet registered for camp
        </td>
    </tr>
    <tr id="trPJOption" runat="server">
        <td class="rbtest">
            <asp:RadioButton GroupName="RadioButtonQ7" value="3" Text="" ID="RadioButtonQ7Option3" runat="server" />
        </td>
        <td class="testspan">
            My Camp’s registration is not open yet, but I plan to send my camper for 12 days or more.
        </td>
    </tr>
</table>
