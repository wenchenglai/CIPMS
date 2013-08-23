<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminSearch.aspx.cs" MasterPageFile="~/AdminMaster.master"
    Inherits="AdminSearch" %>
<%@ MasterType VirtualPath="~/AdminMaster.master" %>

<asp:Content ID="ContentStep1" ContentPlaceHolderID="Content" runat="server">

    <script language="javascript" type="text/javascript">
        function ShowHide(val){
            var dv = document.getElementById('dvSrchCriteria');            
            dv.style.display = val;
        }
        
        function ShowZip(){
            var dvZ = document.getElementById('<%=dvZipCd.ClientID %>'); 
            var dvZR = document.getElementById('<%=dvZipRange.ClientID %>');
            var rbZ = document.getElementById('<%=rbZipCode.ClientID %>');
            var rbZR = document.getElementById('<%=rbZipRange.ClientID %>');
            var txtZip = document.getElementById('<%=txtZip.ClientID %>');
            var txtZRFrm = document.getElementById('<%=txtZipFrom.ClientID %>');
            var txtZRTo = document.getElementById('<%=txtZipTo.ClientID %>');
            
            if (rbZR.checked == true){
                dvZ.style.display = 'none';
                dvZR.style.display = 'block';
                txtZip.value = '';
            }
            else if (rbZ.checked == true){            
                dvZ.style.display = 'block';
                dvZR.style.display = 'none';
                txtZRFrm.value = '';
                txtZRTo.value = '';
            }
        }
        
        function ValidateRange(){
            var blnIsValid=new Boolean(ValidateSrch());
            var txtHid = document.getElementById('<%=txtHidValidPg.ClientID %>');
            txtHid.value = '';
            
            var ZipFRM = document.getElementById('<%=txtZipFrom.ClientID %>');
            var ZipTO = document.getElementById('<%=txtZipTo.ClientID %>');
            var CreatedFRM = document.getElementById('<%=txtCreatedFrom.ClientID %>');
            var CreatedTO = document.getElementById('<%=txtCreatedTo.ClientID %>');
            var SubmittedFRM = document.getElementById('<%=txtSubmittedFrom.ClientID %>');
            var SubmittedTO = document.getElementById('<%=txtSubmittedTo.ClientID %>');
            var UpdatedFRM = document.getElementById('<%=txtUpdatedFrom.ClientID %>');
            var UpdatedTO = document.getElementById('<%=txtUpdatedTo.ClientID %>');
            var valZipFRM = document.getElementById('<%=rfvZipFrm.ClientID %>');
            var valZipTO = document.getElementById('<%=rfvZipTo.ClientID %>');
            var valCreatedFRM = document.getElementById('<%=rfvDtCreatedFrm.ClientID %>');
            var valCreatedTO = document.getElementById('<%=rfvDtCreatedTo.ClientID %>');
            var valSubmittedFRM = document.getElementById('<%=rfvDtSubmittedFrm.ClientID %>');
            var valSubmittedTO = document.getElementById('<%=rfvDtSubmittedTo.ClientID %>');
            var valUpdatedFRM = document.getElementById('<%=rfvDtUpdatedFrm.ClientID %>');
            var valUpdatedTO = document.getElementById('<%=rfvDtUpdatedTo.ClientID %>');

            if (blnIsValid == true){
                txtHid.value = '1';

                if (ZipFRM.value != "")
                    valZipTO.enabled = true;
                else 
                    valZipTO.enabled = false;
                    
                if (ZipTO.value != "")
                    valZipFRM.enabled = true;
                else 
                    valZipFRM.enabled = false;
                
                if (CreatedFRM.value != "")
                    valCreatedTO.enabled = true;
                else 
                    valCreatedTO.enabled = false;
                    
                if (CreatedTO.value != "")
                    valCreatedFRM.enabled = true;
                else 
                    valCreatedFRM.enabled = false;
                 
                if (SubmittedFRM.value != "")
                    valSubmittedTO.enabled = true;
                else 
                    valSubmittedTO.enabled = false;
                    
                if (SubmittedTO.value != "")
                    valSubmittedFRM.enabled = true;
                else 
                    valSubmittedFRM.enabled = false;
                    
                if (UpdatedFRM.value != "")
                    valUpdatedTO.enabled = true;
                else 
                    valUpdatedTO.enabled = false;
                    
                if (UpdatedTO.value != "")
                    valUpdatedFRM.enabled = true;
                else 
                    valUpdatedFRM.enabled = false;
            }
        }
        
        function ValidateSrch(){
            var Name = document.getElementById('<%=txtCamperNm.ClientID %>');
            var LastName = document.getElementById('<%=txtCamperLNm.ClientID %>');
            var Email = document.getElementById('<%=txtEmail.ClientID %>');
            var FJCID = document.getElementById('<%=txtFJCID.ClientID %>');
            
            //***********
            //TV: 02/2009 - Issue # 4-002: changed Federation from DropDownList to multi-select ListBox
            var fedList = document.getElementById('<%=lstFederations.ClientID %>');
            //***********
            
            var Camps = document.getElementById('<%=txtHidCamps.ClientID %>');
            var Age = document.getElementById('<%=txtAge.ClientID %>');
            var Grade = document.getElementById('<%=txtGrade.ClientID %>');
            var Zip = document.getElementById('<%=txtZip.ClientID %>');
            var ModBy = document.getElementById('<%=ddlModifiedBy.ClientID %>');
            var Status = document.getElementById('<%=txtHidStatus.ClientID %>');       
            var ZipFRM = document.getElementById('<%=txtZipFrom.ClientID %>');
            var ZipTO = document.getElementById('<%=txtZipTo.ClientID %>');
            var CreatedFRM = document.getElementById('<%=txtCreatedFrom.ClientID %>');
            var CreatedTO = document.getElementById('<%=txtCreatedTo.ClientID %>');
            var SubmittedFRM = document.getElementById('<%=txtSubmittedFrom.ClientID %>');
            var SubmittedTO = document.getElementById('<%=txtSubmittedTo.ClientID %>');
            var UpdatedFRM = document.getElementById('<%=txtUpdatedFrom.ClientID %>');
            var UpdatedTO = document.getElementById('<%=txtUpdatedTo.ClientID %>');

            
            var campList = document.getElementById('<%=lstCamps.ClientID %>');
            var statusList = document.getElementById('<%=lstStatus.ClientID %>');
            var iCamp;
            var iStatus;
            
            //***********
            //TV: 02/2009 - Issue # 4-002: changed Federation from DropDownList to multi-select ListBox
            var iFederation;
            if (fedList.value != '' && fedList.value != '-1')
            {
                iFederation = 1;
            }
            else
            {
                iFederation = 0;
            }
            //***********
            
            if (campList.value != '' && campList.value != '-1')
                iCamp = 1;
            else
                iCamp = 0;
                
            if (statusList.value != '' && statusList.value != '-1')
                iStatus = 1;
            else
                iStatus = 0;

            //***********
            //TV: 02/2009 - Issue # 4-002: changed Federation from DropDownList to multi-select ListBox, so
            //the use of the iFederation variable below is similar to the iCamp variable since both the Camps and Federations
            //share similar approaches
            if (Name.value != '' || LastName.value != '' || Email.value != '' || FJCID.value != '' || iFederation != 0 || iCamp != 0 || Age.value != '' || Grade.value != '' || Zip.value != '' || ModBy.value != '-1' || iStatus != 0 || ZipFRM.value != '' || ZipTO.value != '' || CreatedFRM.value != '' || CreatedTO.value != '' || SubmittedFRM.value != '' || SubmittedTO.value != '' || UpdatedFRM.value != '' || UpdatedTO.value != '')
                return true;
            else
                return false;
            //***********
        }
        
        function EnableDisableSort(){
            var chk = document.getElementById('<%=chkSort.ClientID %>');
            var ddlCol = document.getElementById('<%=ddlColums.ClientID %>');
            var ddlOrder = document.getElementById('<%=ddlSortOrder.ClientID %>');
            
            ddlCol.disabled = false;
            ddlOrder.disabled = false;
                
            if (!chk.checked){
                ddlCol.value = "-1";
                ddlCol.disabled = true;
                ddlOrder.value = "-1";
                ddlOrder.disabled = true; 
            }                
        }
    </script>

    <table width="100%">
        <tr class="infotext1">
            <td>
                Please click
                <img src="/CIPMS/images/plus.jpg" width="12" height="10" />
                to see the search criteria,
                <img width="12" height="10" src="/CIPMS/images/minus.jpg" />
                to hide the search criteria</td>
        </tr>
        <tr class="text">
            <td style="width: 10%" valign="bottom">
                <img src="/CIPMS/images/plus.jpg" onclick="javascript:ShowHide('block');" width="20"
                    height="17" />
                <img src="/CIPMS/images/minus.jpg" onclick="javascript:ShowHide('none');" width="20"
                    height="17" /></td>
        </tr>
        <tr style="height: 5px">
            <td>
                &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td class="InfoText">
                <asp:UpdatePanel ID="upMessagesPanel" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrMsg" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <div id="dvSrchCriteria" style="display: block; width: 100%">
                    <table class="text" border="1" cellpadding="0" cellspacing="0" style="border-color: Red"
                        width="100%">
                        <tr>
                            <td>
                                <table class="text" border="0" cellpadding="0" cellspacing="0">
                                    <tr style="height: 5px">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td colspan="9">
                                            <asp:ValidationSummary ID="vldsumErr" runat="server" />
                                        </td>
                                    </tr>
                                    <tr valign="bottom">
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            Camper Name</td>
                                        <td>
                                            &nbsp;&nbsp;&nbsp;</td>
                                        <td>
                                            Camper Last Name</td>
                                        <td>
                                            &nbsp;&nbsp;&nbsp;</td>
                                        <td>
                                            Camper Email ID</td>
                                        <td>
                                            &nbsp;&nbsp;&nbsp;</td>
                                        <td>
                                            FJCID</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr valign="top">
                                        <td>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCamperNm" runat="server" CssClass="txtbox" Width="150px" MaxLength="50" /></td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCamperLNm" runat="server" CssClass="txtbox" Width="150px" MaxLength="50" /></td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="txtbox" Width="150px" MaxLength="150" /></td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFJCID" runat="server" CssClass="txtbox" Width="150px" MaxLength="50" /></td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="height: 5px">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                    <tr valign="bottom">
                                        <td>
                                        </td>
                                        <td>
                                            Age</td>
                                        <td>
                                        </td>
                                        <td>
                                            Grade</td>
                                        <td>
                                        </td>
                                        <td colspan="3">
                                            Modified By</td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAge" runat="server" CssClass="txtbox" Width="150px" MaxLength="3" /></td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGrade" runat="server" CssClass="txtbox" Width="150px" MaxLength="3" /></td>
                                        <td>
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlModifiedBy" runat="server" Width="250px" CssClass="text" /></td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="height: 5px">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td>
                                        </td>
                                        <td colspan="4">
                                            <asp:RadioButton ID="rbZipCode" runat="server" GroupName="Zip" Text="Zip Code" Checked="True" />&nbsp;
                                            <asp:RadioButton ID="rbZipRange" runat="server" GroupName="Zip" Text="Zip Code Range" /></td>
                                        <td colspan="3">
                                            <div id="dvZipCd" runat="server" style="width: 100%; display: block">
                                                <asp:TextBox ID="txtZip" runat="server" CssClass="txtbox" Width="150px" /></div>
                                            <div id="dvZipRange" runat="server" style="width: 100%; display: none">
                                                From:&nbsp;<asp:TextBox ID="txtZipFrom" runat="server" Width="90px" CssClass="txtbox"
                                                    MaxLength="10" />
                                                &nbsp;To:&nbsp;<asp:TextBox ID="txtZipTo" runat="server" Width="90px" CssClass="txtbox"
                                                    MaxLength="10" />
                                            </div>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="height: 5px">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                    <tr>
                                   
                                        <td  colspan="9">
                                            CampYear:&nbsp;<asp:DropDownList ID="ddlCampYear" runat="server" Width="231px" AutoPostBack="true" OnSelectedIndexChanged="ddlCampYear_SelectedIndexChanged"></asp:DropDownList>
                                             &nbsp;</td>
                                    </tr>
                                    <tr style="height: 10px">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                    <tr valign="bottom">
                                        <td>
                                        </td>
                                        <td colspan="4">
                                            Federation</td>
                                        <td colspan="3">
                                            Date Created (MM/DD/YYYY)</td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td rowspan="7">
                                        </td>
                                        <td colspan="4" rowspan="7">
                                            <asp:ListBox ID="lstFederations" runat="server" SelectionMode="Multiple" Height="140px"
                                                Width="315px" CssClass="text" OnSelectedIndexChanged="lstFederations_SelectedIndexChanged"
                                                AutoPostBack="True" /></td>
                                        <td colspan="3">
                                            From:&nbsp;<asp:TextBox ID="txtCreatedFrom" runat="server" Width="90px" CssClass="txtbox"
                                                MaxLength="10" />
                                            &nbsp;To:&nbsp;<asp:TextBox ID="txtCreatedTo" runat="server" Width="90px" CssClass="txtbox"
                                                MaxLength="10" /></td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="height: 10px">
                                        <td colspan="4">
                                        </td>
                                    </tr>
                                    <tr valign="bottom">
                                        <td colspan="3">
                                            Date Submitted (MM/DD/YYYY)</td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td colspan="3">
                                            From:&nbsp;<asp:TextBox ID="txtSubmittedFrom" runat="server" Width="90px" CssClass="txtbox"
                                                MaxLength="10" />
                                            &nbsp;To:&nbsp;<asp:TextBox ID="txtSubmittedTo" runat="server" Width="90px" CssClass="txtbox"
                                                MaxLength="10" /></td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="height: 10px">
                                        <td colspan="4">
                                        </td>
                                    </tr>
                                    <tr valign="bottom">
                                        <td colspan="3">
                                            Last Updated Date (MM/DD/YYYY)</td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td colspan="3">
                                            From:&nbsp;<asp:TextBox ID="txtUpdatedFrom" runat="server" CssClass="txtbox" Width="90px"
                                                MaxLength="10" />
                                            &nbsp;To:&nbsp;<asp:TextBox ID="txtUpdatedTo" runat="server" CssClass="txtbox" Width="90px"
                                                MaxLength="10" /></td>
                                        <td>
                                        </td>
                                    </tr>
                                    
                                    <tr style="height: 10px">
                                        <td colspan="9">
                                            &nbsp;</td>
                                    </tr>
                                    <tr valign="top">
                                        <td>
                                        </td>
                                        <td colspan="4">
                                            Status</td>
                                        <td colspan="4">
                                            Camp List</td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td>
                                        </td>
                                        <td colspan="4">
                                            <asp:ListBox ID="lstStatus" runat="server" SelectionMode="Multiple" Height="140px"
                                                Width="315px" CssClass="text" /></td>
                                        <td colspan="4">
                                            <asp:UpdatePanel ID="upCampsPanel" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:ListBox ID="lstCamps" runat="server" SelectionMode="Multiple" Height="140px"
                                                        Width="310px" CssClass="text" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="lstFederations" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="height: 10px">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="center">
                                            <asp:CheckBox ID="chkSort" runat="server" Text="Order By" /></td>
                                        <td>
                                        </td>
                                        <td>
                                            Column Name<br />
                                            <asp:DropDownList ID="ddlColums" runat="server" Width="150px" CssClass="text" /></td>
                                        <td>
                                        </td>
                                        <td>
                                            Sort Order<br />
                                            <asp:DropDownList ID="ddlSortOrder" runat="server" Width="150px" CssClass="text" /></td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <asp:RequiredFieldValidator ID="rfvZipFrm" runat="server" ControlToValidate="txtZipFrom"
                                                Enabled="False" ErrorMessage="Please enter Zip Code Range From" Display="None" />
                                            <asp:RequiredFieldValidator ID="rfvZipTo" runat="server" ControlToValidate="txtZipTo"
                                                Enabled="False" ErrorMessage="Please enter Zip Code Range To" Display="None" />
                                            <asp:RequiredFieldValidator ID="rfvDtCreatedFrm" runat="server" ControlToValidate="txtCreatedFrom"
                                                Enabled="False" ErrorMessage="Please enter Date Created From" Display="None" />
                                            <asp:RequiredFieldValidator ID="rfvDtCreatedTo" runat="server" ControlToValidate="txtCreatedTo"
                                                Enabled="False" ErrorMessage="Please enter Date Created To" Display="None" />
                                            <asp:RequiredFieldValidator ID="rfvDtSubmittedFrm" runat="server" ControlToValidate="txtSubmittedFrom"
                                                Enabled="False" ErrorMessage="Please enter Date Submitted From" Display="None" />
                                            <asp:RequiredFieldValidator ID="rfvDtSubmittedTo" runat="server" ControlToValidate="txtSubmittedTo"
                                                Enabled="False" ErrorMessage="Please enter Date Submitted To" Display="None" />
                                            <asp:CompareValidator ID="cmpZip" runat="server" ControlToCompare="txtZipFrom" ControlToValidate="txtZipTo"
                                                Display="None" ErrorMessage="Please enter TO greater than FROM" Operator="GreaterThan" />
                                            <asp:RequiredFieldValidator ID="rfvDtUpdatedFrm" runat="server" ControlToValidate="txtUpdatedFrom"
                                                Enabled="False" ErrorMessage="Please enter Date Submitted From" Display="None" />
                                            <asp:RequiredFieldValidator ID="rfvDtUpdatedTo" runat="server" ControlToValidate="txtUpdatedTo"
                                                Enabled="False" ErrorMessage="Please enter Date  Updated To" Display="None" />
                                            <asp:RangeValidator ID="rgvAge" runat="server" ControlToValidate="txtAge" Display="None"
                                                ErrorMessage="Please enter a valid Age." MaximumValue="100" MinimumValue="1"
                                                Type="Integer" />
                                            <asp:RangeValidator ID="rgvGrade" runat="server" ControlToValidate="txtGrade" Display="None"
                                                ErrorMessage="Please enter a valid Grade" MaximumValue="100" MinimumValue="1"
                                                Type="Integer" />
                                            <asp:CompareValidator ID="cmpCreatedDt" runat="server" ControlToCompare="txtCreatedFrom"
                                                ControlToValidate="txtCreatedTo" Display="None" ErrorMessage="Please enter TO date greater than FROM date"
                                                Type="Date" Operator="GreaterThan" />
                                            <asp:CompareValidator ID="cmpSubmittedDt" runat="server" ControlToCompare="txtSubmittedFrom"
                                                ControlToValidate="txtSubmittedTo" Display="None" ErrorMessage="Please enter TO date greater than FROM date"
                                                Type="Date" Operator="GreaterThan" />
                                            <asp:CompareValidator ID="cmpUpdatedDt" runat="server" ControlToCompare="txtUpdatedFrom"
                                                ControlToValidate="txtUpdatedTo" Display="None" ErrorMessage="Please enter TO date greater than FROM date"
                                                Type="Date" Operator="GreaterThan" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="7" valign="bottom" align="right">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="submitbtn1" Width="100px"
                                                OnClick="btnSearch_Click" /></td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                                Display="None" ErrorMessage="Please enter a valid e-mail ID" ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$" />
                                            <asp:RegularExpressionValidator ID="revCreatedFRM" runat="server" ControlToValidate="txtCreatedFrom"
                                                Display="None" ErrorMessage="Please enter a valid date in MM/DD/YYYY format"
                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$" />
                                            <asp:RegularExpressionValidator ID="revCreatedTO" runat="server" ControlToValidate="txtCreatedTo"
                                                Display="None" ErrorMessage="Please enter a valid date in MM/DD/YYYY format"
                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$" />
                                            <asp:RegularExpressionValidator ID="revSubmittedFRM" runat="server" ControlToValidate="txtSubmittedFrom"
                                                Display="None" ErrorMessage="Please enter a valid date in MM/DD/YYYY format"
                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$" />
                                            <asp:RegularExpressionValidator ID="revSubmittedTO" runat="server" Display="None"
                                                ErrorMessage="Please enter a valid date in MM/DD/YYYY format" ControlToValidate="txtSubmittedTo"
                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$" />
                                            <asp:RegularExpressionValidator ID="revUpdatedFRM" runat="server" Display="None"
                                                ErrorMessage="Please enter a valid date in MM/DD/YYYY format" ControlToValidate="txtUpdatedFrom"
                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$" />
                                            <asp:RegularExpressionValidator ID="revUpdatedTO" runat="server" Display="None" ErrorMessage="Please enter a valid date in MM/DD/YYYY format"
                                                ControlToValidate="txtUpdatedTo" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$" />
                                            <asp:TextBox ID="txtHidValidPg" runat="server" Width="0px" />
                                            <asp:RequiredFieldValidator ID="rfvValidatePg" runat="server" ControlToValidate="txtHidValidPg"
                                                ErrorMessage="Please select or enter at least one search criteria" Display="None" />
                                            <asp:TextBox ID="txtHidFederations" runat="server" Width="0px" />
                                            <asp:TextBox ID="txtHidCamps" runat="server" Width="0px" />
                                            <asp:TextBox ID="txtHidStatus" runat="server" Width="0px" />
                                            <asp:RegularExpressionValidator ID="revZip" runat="server" ControlToValidate="txtZip"
                                                Display="None" ErrorMessage="Please enter a valid Zip Code" ValidationExpression="^(\d{5}(?:\-\d{4})?)$" />
                                            <asp:RegularExpressionValidator ID="revZipFRM" runat="server" ControlToValidate="txtZipFrom"
                                                Display="None" ErrorMessage="Please enter a valid Zip Code" ValidationExpression="^(\d{5}(?:\-\d{4})?)$" />
                                            <asp:RegularExpressionValidator ID="revZipTO" runat="server" ControlToValidate="txtZipTo"
                                                Display="None" ErrorMessage="Please enter a valid Zip Code" ValidationExpression="^(\d{5}(?:\-\d{4})?)$" />
                                            <asp:RegularExpressionValidator ID="revFirstNm" runat="server" ControlToValidate="txtCamperNm"
                                                Display="None" ErrorMessage="Please use letters A-Z (') and (-) for Camper Name"
                                                ValidationExpression="^[a-zA-Z'\s-]{1,50}$" />
                                            <asp:RegularExpressionValidator ID="revLastName" runat="server" ControlToValidate="txtCamperLNm"
                                                Display="None" ErrorMessage="Please use letters A-Z (') and (-) for Last Name"
                                                ValidationExpression="^[a-zA-Z'\s-]{1,50}$" />
                                            <asp:RegularExpressionValidator ID="revFJCID" runat="server" ControlToValidate="txtFJCID"
                                                Display="None" ErrorMessage="Please enter a valid FJCID" ValidationExpression="^[a-zA-Z0-9]{1,50}$" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td style="word-wrap: break-word">
                <asp:UpdatePanel ID="upResultsPanel" runat="server">
                    <ContentTemplate>
                        <div id="dvCamperDetails" style="width: 100%">
                            <asp:GridView ID="gvCamperDetails" runat="server" CssClass="text" AutoGenerateColumns="False"
                                Width="100%" AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSorting="gvCamperDetails_OnSort"
                                OnRowCommand="gvCamperDetails_RowCommand" AllowPaging="True" OnPageIndexChanging="gvCamperDetails_PageIndexChange"
                                PageSize="20" OnRowDataBound="gvCamperDetails_RowDataBound">
                                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField HeaderText="FJCID" SortExpression="FJCID">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkFJCID" CommandName="FJCID" CommandArgument='<%# Eval("FedFJCID") %>'
                                                runat="server" Text='<%# Eval("FJCID") %>' CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CamperName" HeaderText="Camper Name" SortExpression="CamperName" />
                                    <asp:BoundField DataField="Zip" HeaderText="Zip Code" SortExpression="Zip" />
                                    <asp:BoundField DataField="Federation" HeaderText="Federation" SortExpression="Federation" />
                                    <asp:BoundField DataField="Camp" HeaderText="Camp" SortExpression="Camp" />
                                    <asp:BoundField DataField="Admin" HeaderText="Admin" SortExpression="Admin" />
                                    <asp:BoundField DataField="SubmittedDate" HeaderText="Submit Date" SortExpression="SubmittedDate" />
                                    <asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="ModifiedDate" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="Silver" ForeColor="Blue" HorizontalAlign="Right" Font-Names="Trebuchet MS"
                                    Font-Size="Smaller" Font-Bold="True" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerSettings Position="Top" />
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
