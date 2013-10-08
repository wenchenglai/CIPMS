<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CamperSummary.aspx.cs" MasterPageFile="~/AdminMaster.master"
    Inherits="Administration_Search_CamperSummary" %>

<%@ MasterType VirtualPath="~/AdminMaster.master" %>
<asp:Content ID="CamperSummary" ContentPlaceHolderID="Content" runat="Server">
    <script type="text/javascript" language="javascript">
        function ValidateDays(UsrRole,ddlselectedvalue){
            var ddl = document.getElementById('<%=ddlStatus.ClientID %>'); 
            if (UsrRole == 1) {
                if(ddl.value == 15) {
                    var resp = window.confirm ('Are you sure you want to put this applicant into the status of 2nd Approval?');
                    if (resp == true) {
                        ddl.value=15
                    } else {
                       ddl.value=ddlselectedvalue
                    }
                }
            }

            if(UsrRole == 1 || UsrRole == 2 || UsrRole == 5) {
                if (ddl.value == 24) {
                    var resp = window.confirm ('Are you sure you want to put this applicant in the status of Deleted?');
                    if (resp == true) {
                        ddl.value=24
                    } else {
                        ddl.value=ddlselectedvalue
                    }
                }
            }
        }
        
        function windowopener(){
            window.open('../Reports/Rpt_FedQuestionnaire.aspx' ,'FJCReport','titlebar=no,width=650,height=450,left=250,top=150,resizable');           
        }
        
        function CheckBeforeUpdate() {
			var ddlStatus = document.getElementById('ctl00_Content_ddlStatus');
			var is7 = false;
			for (var i = 0; i < ddlStatus.children.length; i++) {
				if (ddlStatus.children[i].selected ) {
					if (ddlStatus.children[i].value === '8') {
						is7 = true;
						break;
					}
				}
			}
			
			if (is7) {
				if(confirm('Are you sure you want to mark this applicant as ineligible?')) {
					return true;
				} else {
					return false;
				}
			}
			return true;
        }
        
        function ProcessCancelChangeForm()
        {   
			debugger;
            var ddl = document.getElementById('ctl00_Content_ddlAdjustmentType'),
				url = '../../Administration/CancellationOrChangeForm.aspx',
				Cancellation_Request = "1";
			
            if (ddl) {                
               if(ddl.options[ddl.selectedIndex].value === "0") {
                    alert("Please select Cancel Or Session Change");
                    return false;
               } else if(ddl.options[ddl.selectedIndex].value === Cancellation_Request) {
                   if( <%=isPaymentDone%> == "0") {
                        return true;
                   }
               }
            }
            
            if (ddl.options[ddl.selectedIndex].value != "0") {
                url = url + "?RequestType=" + ddl.options[ddl.selectedIndex].value;
            }
            return OpenCancelChangeForm(url);         
        }
              
        function OpenCancelChangeForm(url)
        {
            var width  = 800;
            var height = 500;
            var left   = (screen.width  - width)/2;
            var top    = (screen.height - height)/2;
            var params = 'width='+width+', height='+height;
            params += ', top='+top+', left='+left;
            params += ', directories=no';
            params += ', location=no';
            params += ', menubar=no';
            params += ', resizable=no';
            params += ', scrollbars=Yes';
            params += ', status=Yes';
            params += ', toolbar=no';
            var newwin=window.open(url,'CancellationOrChangeForm', params);
            
            debugger;
            
            if (window.focus) {newwin.focus();}
                return false;
        }
        
        function ConfirmUpdateAmt(strRole, strApprover,campyear)
        {   
			if (CheckBeforeUpdate()) {
				var ddl = document.getElementById('<%=ddlCampYear.ClientID %>'); 
				var txt = document.getElementById('<%=txtAmt.ClientID %>'); 
				var hdn = document.getElementById('<%=hdnAmt.ClientID %>'); 
				var hdnCampYr = document.getElementById('<%=hdnCampYear.ClientID %>'); 
				var hdnConfirm = document.getElementById('<%=hdnConfirm.ClientID %>'); 
	            
				if(strRole == strApprover)
				{
					//debugger;
					if(campyear < ddl.value)
					{
						if(campyear == "1")
						{
							campyear="1st year"
	                    
						}
						else if(campyear == "2")
						{
							campyear="2nd year"
						}
	                
						var responce= window.confirm ('Current Program will support '+campyear+' , if you want to continue please click ok or cancel to quit.');                
						if (responce == true)
						{
							hdnConfirm.value=true
						}
						else
						{
							for(i=0;i<ddl.length;i++)
							{
								if(ddl.options[i].value==hdnCampYr.value)
								{
									ddl.selectedIndex=i
								}
							}
							txt.value=hdn.value
							hdnConfirm.value = false
						}
					}
					else if(ddl.value != hdnCampYr.value || txt.value != hdn.value)
					{   
						var responce= window.confirm ('Are you sure to change this applicant\'s grant amount. (if you change the Year of grant it will update the grant amount)');                
						if (responce == true) {
							hdnConfirm.value=true
						} else {
							for(i=0;i<ddl.length;i++) {
								if(ddl.options[i].value==hdnCampYr.value) {
									ddl.selectedIndex=i
								}
							}
							txt.value=hdn.value
							hdnConfirm.value=false
						}
					} else {
						hdnConfirm.value=true
					}
				} else {
					hdnConfirm.value=true
				}
            } else {
				return false;
            }
        }
        
    </script>

    <table class="text" border="1" cellpadding="0" cellspacing="0" style="border-color: Red" width="100%">
        <tr>
            <td>
                <table class="text" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr class="InfoText">
                        <td>
                        </td>
                        <td colspan="11" style="height: 13px">
                            <asp:ValidationSummary ID="vldsumErr" runat="server" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr class="InfoText">
                        <td>
                        </td>
                        <td colspan="11">
                            <asp:Label ID="lblErr" runat="server" /></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px" colspan="13">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5px">
                        </td>
                        <td class="headertext1">
                            FJCID</td>
                        <td style="width: 10px" align="center">
                        </td>
                        <td>
                            <asp:Label ID="lblFJCID" runat="server" /></td>
                        <td style="width: 20px">
                        </td>
                        <td class="headertext1">
                            Program</td>
                        <td style="width: 10px" align="center">
                        </td>
                        <td>
                            <asp:Label ID="lblFed" runat="server" Width="120px" CssClass="text" /></td>
                        <td style="width: 20px">
                        </td>
                        <td class="headertext1">
                            # of days</td>
                        <td align="center" style="width: 10px">
                        </td>
                        <td>
                            <asp:Label ID="lblNoofDays" runat="server"></asp:Label></td>
                        <td style="width: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px" colspan="13">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5px">
                        </td>
                        <td class="headertext1">
                            Camper Name</td>
                        <td style="width: 10px" align="center">
                        </td>
                        <td>
                            <asp:Label ID="lblCamperNm" runat="server" /></td>
                        <td style="width: 20px">
                        </td>
                        <td class="headertext1">
                            Zip</td>
                        <td style="width: 10px" align="center">
                        </td>
                        <td>
                            <asp:Label ID="lblZip" runat="server" /></td>
                        <td style="width: 20px">
                        </td>
                        <td class="headertext1">
                            Session date range</td>
                        <td align="center" style="width: 10px">
                        </td>
                        <td>
                            <asp:TextBox ID="txtSessionDateRange" runat="server" CssClass="txtbox4" Width="150px"
                                Enabled="false" /></td>
                        <td style="width: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px" colspan="13">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5px">
                        </td>
                        <td class="headertext1">
                            Yr of Grant</td>
                        <td align="center" style="width: 10px">
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCampYear" runat="server" CssClass="text" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlCampYear_SelectedIndexChanged">
                                <asp:ListItem Text="N/A" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="1styear" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2ndyear" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3rdyear" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 20px">
                        </td>
                        <td class="headertext1">
                            Grant</td>
                        <td align="center" style="width: 10px">
                        </td>
                        <td>
                            $<asp:TextBox ID="txtAmt" runat="server" CssClass="txtbox1" Width="70px" MaxLength="7"
                                Enabled="false" /></td>
                        <td style="width: 20px">
                        </td>
                        <td class="headertext1">
                            School Type</td>
                        <td align="center" style="width: 10px">
                        </td>
                        <td>
                            <asp:Label ID="lblSchoolType" runat="server"></asp:Label></td>
                        <td style="width: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px" colspan="13">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5px">
                        </td>
                        <td class="headertext1">
                            DOB</td>
                        <td align="center" style="width: 10px">
                        </td>
                        <td>
                            <asp:Label ID="lblDoB" runat="server"></asp:Label></td>
                        <td style="width: 20px">
                        </td>
                        <td class="headertext1">
                            Log-In</td>
                        <td style="width: 10px" align="center">
                        </td>
                        <td style="word-wrap:break-word;width:100px">
                            <asp:Label ID="lblLogin" runat="server"></asp:Label></td>
                        <td style="width: 20px">
                        </td>
                        <td class="headertext1">
                            School Name</td>
                        <td align="center" style="width: 10px">
                        </td>
                        <td>
                            <asp:Label ID="lblSchoolName" runat="server"></asp:Label></td>
                        <td style="width: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style="height: 13px">
                        </td>
                        <td colspan="2" style="height: 13px">
                            <asp:RegularExpressionValidator ID="revAmt" runat="server" Display="None" ControlToValidate="txtAmt"
                                ErrorMessage="Amount can only have maximum of four number and/or two digits after decimal"
                                ValidationExpression="^\d{0,4}(\.\d{1,2})?$" />
                            <asp:RangeValidator ID="rgvAmt" runat="server" Display="None" ControlToValidate="txtAmt"
                                Type="Double" /></td>
                        <td colspan="2" style="height: 13px">
                        </td>
                        <%--<td colspan="4" style="height: 13px">
                            <asp:RangeValidator ID="rgvDays" runat="server" ControlToValidate="txtDays" Display="None"
                                ErrorMessage="Please enter numbers for days" MinimumValue="1" MaximumValue="999"
                                Type="Integer" />
                            <asp:RequiredFieldValidator ID="rfvDays" runat="server" ControlToValidate="txtDays"
                                Display="None" Enabled="False" ErrorMessage="Please enter number of days"></asp:RequiredFieldValidator></td>--%>
                    </tr>
                    <tr>
                        <td style="height: 10px" colspan="13">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5px">
                        </td>
                        <td class="headertext1">
                            Grade</td>
                        <td style="width: 10px" align="center">
                        </td>
                        <td>
                            <asp:Label ID="lblGrade" runat="server" /></td>
                        <td style="width: 20px">
                        </td>
                        <td class="headertext1">
                            Primary Email</td>
                        <td style="width: 10px" align="center">
                        </td>
                        <td style="word-wrap:break-word;width:100px">
                            <asp:Label ID="lblEmail" runat="server" /></td>
                        <td style="width: 20px">
                        </td>
                        <td class="headertext1">
                            Phone Number</td>
                        <td align="center" style="width: 10px">
                        </td>
                        <td>
                            <asp:Label ID="lblCamperPhoneNumber" runat="server"></asp:Label></td>
                        <td style="width: 5px">
                        </td>
                    </tr>
                     <tr>
                        <td style="height: 10px" colspan="13">
                        </td>
                    </tr>
                    <tr>
						<td style="width: 5px">
                        </td>
                        <td class="headertext1">
                            Parent Name</td>
                        <td style="width: 10px" align="center">
                        </td>
                        <td>
                            <asp:Label ID="lblParentName" runat="server"></asp:Label>
                        </td>
						<td style="width: 5px">
                        </td>                        
                        <td colspan="9">
							<strong>Contact Permission:</strong> 
							<asp:Label ID="lblPermissionMsgYes" runat="server" Text="Yes, OK to send additional non OHC info." Visible="false" />
							<asp:Label ID="lblPermissionMsgNo" runat="server" Text="<span style='color:Red;'>No</span> - if not related to OHC" Visible="false" />
                        </td>             
                    </tr>
                     
                    <tr>
                        <td style="height: 10px" colspan="13">
                        </td>
                    </tr>
                 <!--   <tr>
                        <td colspan="5">
                        </td>
                        <td class="headertext1">
                            Email Delivered</td>
                        <td style="width: 10px" align="center">
                        </td>
                        <td>
                            <asp:Label ID="lblEmailDelivered" runat="server"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtDays" runat="server" CssClass="txtbox1" Width="70px" MaxLength="3"
                                Enabled="false" Visible="false" /></td>
                        <td colspan="4">
                        </td>
                    </tr> -->
                    <tr>
                        <td colspan="13" style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="13" style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5px; height: 19px;">
                        </td>
                        <td class="headertext1" style="height: 19px">
                            Camp</td>
                        <td style="width: 10px; height: 19px;" align="center">
                        </td>
                        <td colspan="9" style="height: 19px">
                            <asp:DropDownList ID="ddlCamp" runat="server" Width="500px" CssClass="text" /></td>
                        <td style="width: 5px; height: 19px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="13" style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5px">
                        </td>
                        <td class="headertext1">
                            Status</td>
                        <td align="center" style="width: 10px">
                        </td>
                        <td colspan="9">
                            <asp:DropDownList ID="ddlStatus" runat="server" Width="500px" CssClass="text" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" ondatabound="ddlStatus_DataBound" /></td>
                        <td style="width: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="13" style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="13">
                            <asp:CheckBox ID="chkRemoveFrmWrkQ" runat="server" Text="Remove from Work Queue"
                                Visible="False" /></td>
                    </tr>
                    <tr>
                        <td colspan="13" style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5px">
                        </td>
                        <td class="headertext1">
                            Reason</td>
                        <td>
                        </td>
                        <td colspan="9">
                            <asp:TextBox ID="txtReason" runat="server" Width="100%" TextMode="MultiLine" CssClass="text"
                                Height="50px" /></td>
                        <td style="width: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px" colspan="13">
                        </td>
                    </tr>
                    <tr align="left">
                        <td style="width: 5px; height: 39px;">
                        </td>
                        <td colspan="5">
                            <table>
                                <tr>
                                    <td colspan="" style="height: 39px">
                                        <asp:DropDownList ID="ddlAdjustmentType" runat="server" CssClass="text" Visible="False">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Cancellation" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Session Change" Value="2"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td colspan="4" style="height: 39px">
                                        <input type="submit" id="btnCancelChangeRequest" runat="server" class="submitbtn"
                                            visible="false" value="Change / Cancel Request" onclick="JavaScript:return ProcessCancelChangeForm();"
                                            style="width: 175px" onserverclick="btnCancelChangeRequest_ServerClick" />
                                        <input type="button" id="btnViewCancelChangeRequest" runat="server" class="submitbtn"
                                            visible="false" value="Change / Cancel Request" onclick="JavaScript:return OpenCancelChangeForm('../CancellationOrChangeForm.aspx');"
                                            style="width: 175px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 5px; height: 39px;">
                        </td>
                        <td colspan="5" align="right" style="height: 39px">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="submitbtn" OnClick="btnUpdate_Click" /></td>
                        <td style="width: 5px; height: 39px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px" colspan="13">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table class="text" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="height: 20px" colspan="2">
            </td>
        </tr>
        <tr>
            <td style="width: 35%">
                <asp:LinkButton ID="lnkFedQuestionnaire" runat="server" Text="View Application" OnClick="lnkFedQuestionnaire_Click" />
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <asp:GridView ID="gvAppChangeHistroy" runat="server" CssClass="text" AutoGenerateColumns="False"
                    Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="Description" HeaderText="Action" />
                        <asp:BoundField DataField="OldValue" HeaderText="Previous Status" />
                        <asp:BoundField DataField="NewValue" HeaderText="Current Status" />
                        <asp:BoundField DataField="UserID" HeaderText="UserID" />
                        <asp:BoundField DataField="Date" HeaderText="Date" />
                        <asp:BoundField DataField="Reason" HeaderText="Reason" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>

    <asp:HiddenField ID="hdnCampYear" runat="server" />
    <asp:HiddenField ID="hdnConfirm" runat="server" />
    <asp:HiddenField ID="hdnCamp" runat="server" />
    <asp:HiddenField ID="hdnStatus" runat="server" />
    <asp:HiddenField ID="hdnAmt" runat="server" />
    <asp:HiddenField ID="hdnDays" runat="server" />
    <asp:HiddenField ID="hdnWrkQ" runat="server" />
    <asp:HiddenField ID="hdnMaxTimeInCamp4Fed" runat="server" />
</asp:Content>
