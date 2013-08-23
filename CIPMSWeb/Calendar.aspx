<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Calendar.aspx.cs" Inherits="Calendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Calendar</title>
    <link rel="Stylesheet" href="Style/CIPStyle.css" />
</head>
<body style="margin:0px,0px,0px,0px" onblur="window.focus();" >
    <form id="form1" runat="server">
        
                    
                        <asp:Calendar Width="100%" ID="calStartDt" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4"
                            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"
                            OnSelectionChanged="calStartDt_SelectionChanged"  OnVisibleMonthChanged="OnCalendar_VisibleMonthChanged">
                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        </asp:Calendar>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center">
                        
                            <a href="javascript:self.close();" style="font-family:Verdana; font-size:10pt;">Close</a>
                        </td>
                    </tr>
                </table>   
                
           
     <asp:Literal ID="ltlJavascript" runat="server"></asp:Literal>
    </form>
</body>
</html>
