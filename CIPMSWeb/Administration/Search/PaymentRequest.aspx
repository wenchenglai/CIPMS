<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="PaymentRequest.aspx.cs" Inherits="Administration_Search_PaymentRequest" EnableEventValidation="false"%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <script type="text/javascript">
	    function submitmyform(f) {
		    f.target = 'foo'
		    window.open('',f.target,'menubar=no,scrollbars=no, width=800,height=800');
		    f.submit();
		    return false;
	    }
    </script>
    <asp:ScriptManager ID="scriptManager" runat="server" />
	<table class="text" width="100%">
		<tr class="InfoText">
			<td>
				<asp:Label ID="lblMsg" runat="server" />
			</td>
		</tr>
	</table>
	<asp:Panel ID="pnlSelections" runat="server">
		<table class="text" border="1" cellpadding="0" cellspacing="0" style="border-color:Red" width="100%">
			<tr>
				<td>
					<table class="text">
						<tr>
							<td colspan="3" style="width: 341px">
								<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true" CssClass="InfoText"/>
							</td>
						</tr>            
						<tr>
							<td colspan="3" style="width: 341px">Federations:</td>
						</tr>         
						<tr>
							<td colspan="3" style="width: 341px">
								<asp:DropDownList ID="lstFederations" runat="server" Width="375px" CssClass="text">
									<asp:ListItem>Please select a Federation</asp:ListItem>
								</asp:DropDownList>
								<asp:RequiredFieldValidator ID="reqvalFed" runat="server" ControlToValidate="lstFederations" InitialValue="-1" Display="None" ErrorMessage="Please select the Federation"></asp:RequiredFieldValidator>                       
							</td>
						</tr> 
						<tr>
							<td colspan="3" style="width: 341px">Year:</td>
						</tr>                   
						<tr>
							<td colspan="3" style="width: 341px">
								<asp:DropDownList ID="lstYear" runat="server" Width="58px" CssClass="text"></asp:DropDownList>
							</td>
						</tr>   
						<tr>
							<td colspan="3" style="width: 341px">
								<asp:RadioButtonList ID="radMode" runat="server" RepeatDirection="Horizontal" RepeatColumns="0"></asp:RadioButtonList>
								<asp:RadioButton ID="radPreliminary" runat="server" Text="Preliminary mode" Width="138px" Checked="true" GroupName="radMode" CssClass="text" AutoPostBack="true" OnCheckedChanged="radPreliminary_CheckedChanged" />
								<asp:RadioButton ID="radFinal" runat="server" Text="Final mode" GroupName="radMode" CssClass="text" OnCheckedChanged="radFinal_CheckedChanged" AutoPostBack="true" />
							</td>
						</tr>
						<tr>
							<td colspan="3">
								<asp:Panel ID="pnlFinal" runat="server" width="100%">
									<table class="text" border="1" cellpadding="0" cellspacing="0" style="border-color:Gray" width="100%">
										<tr>
										  <td>
											<table width="100%" style="background-color:Silver">
											  <tr>
												<td style="background-color: Silver" class="text">
												  You have selected a Final Mode payment report. In addition to printing the final payment report, 
												  clicking SUBMIT will also cause the system to update camper data records with payment information, 
												  and you will not be able to undo these updates without technical assistance. 
												  If you are sure that this is what you want to do, click the checkbox below, and then click SUBMIT.
												</td>
											  </tr>
											  <tr>
												<td style="background-color: Silver">
												  <asp:CheckBox ID="chkFinal" runat="server" CssClass="text" Text="I am sure"/>
												  <asp:CustomValidator EnableClientScript="true" ID="CustomValidator1" ClientValidationFunction="EmptyCheck" 
												  runat="server" Display="Dynamic" ErrorMessage="Check I am sure checkbox." CssClass="InfoText" xValidationGroup="ValidGrp" />  

												  <script type="text/javascript" language="javascript"> 
													function EmptyCheck(sender, args) 
													{
													  if(document.getElementById('<%= chkFinal.ClientID %>').checked == false) {
														args.IsValid = false;
													  } else {
														args.IsValid = true; 
													  };
													}
												  </script>
												</td>
											  </tr>
											</table>                        
										  </td>
										</tr>
									</table>
								</asp:Panel>
							</td>
						</tr>               
						<tr>
						  <td colspan="3" align="right" style="width: 341px">
							<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="submitbtn1" Width="100px" OnClick="btnSubmit_Click" />
						  </td>
						</tr>
						<tr>
						  <td colspan="3" style="width: 341px" >
						  </td>
						</tr>
					</table>
				</td>
			</tr>
		</table> 
	</asp:Panel>
    
	<rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="700px" ProcessingMode="Remote" Width="100%"></rsweb:ReportViewer>
</asp:Content>

