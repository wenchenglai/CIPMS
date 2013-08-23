<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="StatisticsReportGeneration.aspx.cs" Inherits="Administration_StatisticsReportGeneration" Title="JWest Upgraded Sessions Report" %>
<%@ MasterType VirtualPath="~/AdminMaster.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
	<div>
		<asp:CheckBox ID="chk2011" runat="server" Text="Show 2011 data" AutoPostBack="true" 
			oncheckedchanged="chk2011_CheckedChanged" />
	</div>
	<div>
		<asp:Label ID="Label4" runat="server">  
			<p style="text-align:justify" class="infotext3">
				The Upgraded Sessions Report provides a snapshot of two years of JWest. It was designed to show how session length attendance varies between the first and second years of the grant.
			</p>
		</asp:Label>
	</div>
	
	<div id="div2012" runat="server">
		<table border="1" style="border-spacing:0px; width:650px">
			<thead>
				<tr>
					<th colspan="6">
						<strong style="font-size:large">2012</strong>					
					</th>
				</tr>
			</thead>
			<tr align="center">
				<td colspan="3">
					<asp:Label ID="Label5" runat="server" Text="2011" Font-Bold="True" 
						Font-Underline="True"></asp:Label>
					</td>
				<td colspan="4"><asp:Label ID="Label7" runat="server" Text="2012"  Font-Bold="True" 
						Font-Underline="True"></asp:Label></td>    
			</tr>  
			<tr align="center">
				<td><asp:Label ID="Label10" runat="server" Text="Total 1st time Campers"   Font-Bold="True" 
						Font-Underline="True"></asp:Label></td>
				<td>&nbsp</td>
				<td>&nbsp</td>
				<td><asp:Label ID="Label12" runat="server" Text="Total 2nd time Campers"  Font-Bold="True" 
						Font-Underline="True"></asp:Label></td>
			   <%-- <td><asp:Label ID="Label7" runat="server" Text="Not Returning"  Font-Bold="True" 
						Font-Underline="True"></asp:Label></td>--%>
				<td><asp:Label ID="Label14" runat="server" Text="12-17 days"  Font-Bold="True" 
						Font-Underline="True"></asp:Label></td>
				<td><asp:Label ID="Label15" runat="server" Text="18+"  Font-Bold="True" 
						Font-Underline="True"></asp:Label></td>
			</tr> 
			<tr align="center">
				<td rowspan="2"><asp:Label ID="lbl1" runat="server" Font-Bold="True"></asp:Label></td>
				<td><asp:Label ID="Label17" runat="server" Text="12-17 days"  Font-Bold="True" Font-Underline="True"></asp:Label></td>
				<td><asp:Label ID="lbl2" runat="server" Font-Bold="True" text="null"></asp:Label></td>
				<td rowspan="2"><asp:Label ID="lbl4" runat="server" Font-Bold="True"></asp:Label></td>
				<td><asp:Label ID="lbl5" runat="server" text="null" Font-Bold="True"></asp:Label></td>
				<td><asp:Label ID="lbl7" runat="server" text="null" Font-Bold="True"></asp:Label></td>
			</tr>
			<tr align="center">
				<td><asp:Label ID="Label22" runat="server" Text="18+"  Font-Bold="True" Font-Underline="True"></asp:Label></td>
				<td><asp:Label ID="lbl3" runat="server" Font-Bold="True" text="null"></asp:Label></td>
				<td><asp:Label ID="lbl6" runat="server" text="null" Font-Bold="True"></asp:Label></td>
				<td><asp:Label ID="lbl8" runat="server" text="null" Font-Bold="True"></asp:Label></td>
			</tr>
		</table>		
	</div>
	<br /><br />
	<div id="div2011" visible="false" runat="server">
		<table border="1" style="border-spacing:0px; width:650px">
			<thead>
				<tr>
					<th colspan="6">
						<strong style="font-size:large">2011</strong>					
					</th>
				</tr>
			</thead>
			<tr align="center">
				<td colspan="3">
					<asp:Label ID="Label1" runat="server" Text="2010" Font-Bold="True" 
						Font-Underline="True"></asp:Label>
					</td>
				<td colspan="4"><asp:Label ID="Label2" runat="server" Text="2011"  Font-Bold="True" 
						Font-Underline="True"></asp:Label></td>    
			</tr>  
			<tr align="center">
				<td><asp:Label ID="Label3" runat="server" Text="Total 1st time Campers"   Font-Bold="True" 
						Font-Underline="True"></asp:Label></td>
				<td>&nbsp</td>
				<td>&nbsp</td>
				<td><asp:Label ID="Label6" runat="server" Text="Total 2nd time Campers"  Font-Bold="True" 
						Font-Underline="True"></asp:Label></td>
			   <%-- <td><asp:Label ID="Label7" runat="server" Text="Not Returning"  Font-Bold="True" 
						Font-Underline="True"></asp:Label></td>--%>
				<td><asp:Label ID="Label8" runat="server" Text="12-17 days"  Font-Bold="True" 
						Font-Underline="True"></asp:Label></td>
				<td><asp:Label ID="Label9" runat="server" Text="18+"  Font-Bold="True" 
						Font-Underline="True"></asp:Label></td>
			</tr> 
			<tr align="center">
				<td rowspan="2"><asp:Label ID="lblTotalCampers" runat="server" Font-Bold="True" 
						></asp:Label></td>
				<td>
			   <asp:Label ID="Label11" runat="server" Text="12-17 days"  Font-Bold="True" 
						Font-Underline="True"></asp:Label></td>
			   <td><asp:Label ID="lblBelow17" runat="server" Font-Bold="True" text="null"
						></asp:Label></td>
			    
				   <td rowspan="2"><asp:Label ID="lblNxtyrTotCampers" runat="server" Font-Bold="True" 
						></asp:Label></td>
			  <%--  <td rowspan="2"><asp:Label ID="lblNotreturning" runat="server" Font-Bold="True" 
						></asp:Label></td>   --%> 
				<td><asp:Label ID="lblReturned201112to12" runat="server" text="null" Font-Bold="True" 
						></asp:Label></td>
				<td><asp:Label ID="lblReturned201112to18" runat="server" text="null" Font-Bold="True" 
						></asp:Label></td>
			</tr>
			<tr align="center">
				<td><asp:Label ID="Label13" runat="server" Text="18+"  Font-Bold="True" 
						Font-Underline="True"></asp:Label></td>
				<td><asp:Label ID="lblAbove18" runat="server" Font-Bold="True" text="null"
						></asp:Label></td>
				 <td><asp:Label ID="lblReturned201118to12" runat="server" text="null" Font-Bold="True" 
					   ></asp:Label></td>
				<td><asp:Label ID="lblReturned201118to18" runat="server" text="null" Font-Bold="True" 
						></asp:Label></td>
			</tr>
		</table>	
	</div>    
    <div>
		<asp:Label ID="lblNote" runat="server">  
			<p style="text-align:justify" class="infotext3">
				<b>NOTE: Statuses used to calculate the above chart are 'Campership approved; payment pending', 'Payment requested', 'Camper Attended Camp' and 'Payment Requested Manual'. </b>
			</p>
		</asp:Label>    
    </div>
</asp:Content>

