<%@ Page Language="C#" AutoEventWireup="true" Title="Camper Section Step 3" CodeFile="Step3_Otherinformation.aspx.cs" ValidateRequest="false" 
    MasterPageFile="~/Common.master" Inherits="Questionaire_Step3_Otherinformation" %>

<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep3_Others" ContentPlaceHolderID="Content" runat="Server">   
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="5" cellspacing="0">
            <tr>
                <td>
                    <p class="headertext">
                        Section VII: Demographics
                    </p>
                </td>
            </tr>
        </table>
        <!--to display the validation summary (error messages)-->
        <table width="75%" cellpadding="0" cellspacing="0" align="center">
            <tr>
                <td>
                    <asp:ValidationSummary ID="valSummary3" ValidationGroup="OtherValidation" runat="server"
                        ShowSummary="true" CssClass="InfoText" />
                    <asp:ValidationSummary ID="valSummary2" ValidationGroup="FriendInvite" runat="server"
                        ShowSummary="true" CssClass="InfoText" />
                    <!--this summary will be used only for Comments field (only for Admin user)-->
                    <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server"
                        ShowSummary="true" CssClass="InfoText" />
                    <asp:CustomValidator ID="CusValComments" ValidationGroup="OtherValidation" runat="server"
                        Display="None" CssClass="InfoText" ErrorMessage="Please enter the Comments" EnableClientScript="false"></asp:CustomValidator>
                    <asp:Label runat="server" ID="lblErrorMsg" Text="Please select the Verification checkbox before submitting the application" Visible="false" CssClass="QuestionText" forecolor='red'></asp:Label>
                </td>
            </tr>
        </table>
        <table width="100%" cellpadding="5" cellspacing="0" border="0">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblNote" runat="server" CssClass="QuestionText">
                        <p>
                            We know you have answered a lot of questions already—you are nearly done! 
                            Please provide us with some basic demographic information about the camper’s 
                            family so we can better understand the population we are serving. Your answers will have no bearing on your grant application.</p></asp:Label></td>
            </tr>
            <tr>
                <td valign="top" width="5%">
                    <asp:Label ID="Label8" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label29"
                        runat="server" Text="1" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Panel ID="PnlQ1" runat="server">
                        <asp:Label ID="Label30" runat="server" CssClass="QuestionText">Is the camper’s family currently a member of a temple or synagogue?</asp:Label><br />
                        <asp:RadioButtonList AutoPostBack="true" CssClass="QuestionText" ID="RadioBtnQ1"
                            runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="OtherValidation"
                            runat="server" ControlToValidate="RadioBtnQ1" Display="None" ErrorMessage="Please answer Question No. 1"></asp:RequiredFieldValidator>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label11" Text="*" runat="server" CssClass="InfoText" /><asp:Label
                        ID="Label31" runat="server" Text="2" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Panel ID="PnlQ2" runat="server">
                        <asp:Label ID="Label32" runat="server" CssClass="QuestionText">Please enter the Name of the Synagogue</asp:Label>
                        <asp:TextBox ID="txtSynagogue" runat="server" CssClass="txtbox" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqvalSynagogue" ValidationGroup="OtherValidation"
                            runat="server" ControlToValidate="txtSynagogue" Display="None" ErrorMessage="Please answer Question No. 2"></asp:RequiredFieldValidator>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td valign="top" width="5%">
                    <asp:Label ID="Label2" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label4"
                        runat="server" Text="3" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="Label5" runat="server" CssClass="QuestionText">Is the camper currently enrolled in a congregational or religious school?</asp:Label><br />
                    <asp:RadioButtonList CssClass="QuestionText" ID="RadioBtnQ3" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="reqvalReligiousSchool" ValidationGroup="OtherValidation"
                        runat="server" ControlToValidate="RadioBtnQ3" Display="None" ErrorMessage="Please answer Question No. 3"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label12" Text="*" runat="server" CssClass="InfoText" /><asp:Label
                        ID="Label6" runat="server" Text="4" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="Label7" runat="server" CssClass="QuestionText">Is the camper’s family currently a member of a Jewish Community Center (JCC)?</asp:Label><br />
                    <asp:RadioButtonList CssClass="QuestionText" ID="RadioBtnQ4" runat="server" RepeatDirection="Horizontal"
                        AutoPostBack="true">
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="OtherValidation"
                        runat="server" ControlToValidate="RadioBtnQ4" Display="None" ErrorMessage="Please answer Question No. 4"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label13"
                        runat="server" Text="5" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Panel ID="pnlJcc" runat="server">
                        <asp:Label ID="Label25" runat="server" CssClass="QuestionText">Please enter the Name of the JCC</asp:Label>
                        <asp:TextBox ID="txtJCC" runat="server" CssClass="txtbox" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqvalJCC" ValidationGroup="OtherValidation" runat="server"
                            ControlToValidate="txtJCC" Display="None" ErrorMessage="Please answer Question No. 5"></asp:RequiredFieldValidator>
                                                
                    </asp:Panel>
                </td>
            </tr>
             <tr>
                <td valign="top"><asp:Label ID="Label26" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label27" runat="server" Text="6" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="Label28" runat="server" CssClass="QuestionText">Are any children in your family members or alums of The PJ Library Program?</asp:Label><br />
                    <asp:RadioButtonList  CssClass="QuestionText" ID="RadioBtnQ6" runat="server" RepeatDirection="vertical">
                        <asp:ListItem Text="Member" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Alum" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Member & Alum" Value="4"></asp:ListItem>
                        <asp:ListItem Text="No affiliation" Value="3"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="reqvalPJL" ValidationGroup="OtherValidation" runat="server"
                            ControlToValidate="RadioBtnQ6" Display="None" ErrorMessage="Please answer Question No. 6"></asp:RequiredFieldValidator>                            
                </td>
                
            </tr>
           <tr>
                <td valign="top"><asp:Label ID="Label33" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="lblNumber5" runat="server" Text="7" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="lblParentQ" runat="server" CssClass="QuestionText">Were both of the camper's parents born in North America (US, Canada, Mexico)?</asp:Label><br />
                    <asp:RadioButtonList  CssClass="QuestionText" ID="RadioBtnQ5" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                     <asp:RequiredFieldValidator ID="reqvalAmerican" ValidationGroup="OtherValidation" runat="server"
                            ControlToValidate="RadioBtnQ5" Display="None" ErrorMessage="Please answer Question No. 7"></asp:RequiredFieldValidator>   
                </td>
                
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label34" Text="*" runat="server" CssClass="InfoText" /><asp:Label
                        ID="lblNumber6" runat="server" Text="8" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Panel ID="PnlQ6" runat="server">
                        <asp:Label ID="lblParentCountry" runat="server" CssClass="QuestionText">Please indicate the country of origin of the camper’s parents/guardians:</asp:Label><br />
                        <asp:Label ID="lblParentG1" runat="server" CssClass="QuestionText">Parent/guardian 1</asp:Label>&nbsp;
                        <asp:DropDownList ID="ddlCountry1" runat="server" CssClass="QuestionText">
                        </asp:DropDownList><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="OtherValidation"
                            runat="server" ControlToValidate="ddlCountry1" Display="None" ErrorMessage="Please select Parent/guardian 1 Country"
                            InitialValue="0"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="OtherValidation"
                            runat="server" ControlToValidate="ddlCountry1" Display="None" ErrorMessage="Please select Parent/guardian 1 Country"
                            InitialValue="-1"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblParentG2" runat="server" CssClass="QuestionText">Parent/guardian 2</asp:Label>&nbsp;
                        <asp:DropDownList ID="ddlCountry2" runat="server" CssClass="QuestionText" />
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label37" Text="*" runat="server" CssClass="InfoText" /><asp:Label
                        ID="Label14" runat="server" Text="9" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="Label19" runat="server" CssClass="QuestionText">Do either one or both of the camper's parents/guardians identify as being Jewish?</asp:Label><br />
                    <asp:DropDownList ID="ddlQ8" runat="server" CssClass="QuestionText">
                        <asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Yes, one parent/guardian" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Yes, both parents/guardians" Value="2"></asp:ListItem>
                        <asp:ListItem Text="No, neither parent/guardian" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="0" ValidationGroup="OtherValidation"
                        runat="server" ControlToValidate="ddlQ8" Display="None" ErrorMessage="Please answer Question No. 9"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label39" Text="*" runat="server" CssClass="InfoText" /><asp:Label
                        ID="Label20" runat="server" Text="10" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="Label22" runat="server" CssClass="QuestionText">
                        <p align="justify">
                            Who in your family has previously attended a Jewish overnight summer camp? 
                            "Jewish camp" is defined as an overnight camp experience that has significant 
                            Jewish content (e.g. programming and services), in addition to regular camp 
                            programming, and where the bunk counselors are Jewish. (Check all that apply.)</p>
                    </asp:Label>

                    <asp:CheckBoxList CellPadding="0" ID="chkQ9" runat="server" CssClass="QuestionText"
                        RepeatDirection="Vertical">
                        <asp:ListItem Text="One of the camper's parents/guardians" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Both of the camper's parents/guardians" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Camper's Sibling(s)" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Nobody" Value="4"></asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label40" Text="*" runat="server" CssClass="InfoText" /><asp:Label
                        ID="Label23" runat="server" Text="11" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="Label24" runat="server" CssClass="QuestionText">
                        <p align="justify">
                            Who in your family has previously attended a non-sectarian overnight summer camp? 
                            "Non-sectarian camp" is defined as an overnight camp experience without any 
                            specifically Jewish content,  and where counselors do not adhere to any 
                            specific religious affiliation. (Check all that apply.)</p>
                    </asp:Label>
                    <asp:CheckBoxList CellPadding="0" ID="chkQ10" runat="server" CssClass="QuestionText" RepeatDirection="Vertical">
                        <asp:ListItem Text="One of the camper's parents/guardians" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Both of the camper's parents/guardians" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Camper's Sibling(s)" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Nobody" Value="4"></asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td valign="top" height="50">
                </td>
                <td valign="top">
                    <asp:Label ID="Label35" runat="server" CssClass="headertext1">Terms and Conditions:</asp:Label>
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label36" CssClass="InfoText" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkAgreement" runat="server" CssClass="QuestionText"
                                    Text="<font color='red'><b>VERIFICATION STATEMENT: </b></font>I certify that all information in this application is accurate and complete and that I am applying for and receiving only one One Happy Camper grant that the Foundation for Jewish Camp (FJC) is sponsoring/co-sponsoring (this includes PJ Goes to Camp). By accepting this grant, I acknowledge that I may be contacted by FJC and/or my local One Happy Camper sponsor.<font color='red'><b>(REQUIRED TO CHECK)<b></font>" />
                            </td>
                        </tr>
                    </table>
                    <asp:CustomValidator ValidationGroup="OtherValidation" ID="CusVal" CssClass="InfoText"
                        runat="server" Display="None" ErrorMessage="Please certify the Terms and Conditions"
                        ClientValidationFunction="CheckCertify_OtherInfo"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label3" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="Label10" runat="server" CssClass="QuestionText">Invite a friend to this site: </asp:Label><br />
                    <asp:Label ID="Label15" runat="server" CssClass="QuestionText">Type in your friends email address</asp:Label>
                    <asp:TextBox ID="txtFriendsEmail" runat="server" CssClass="txtbox"></asp:TextBox>
                    <asp:Button ID="btnInviteMoreFriends" ValidationGroup="FriendInvite" Text="Invite another friend" runat="server" CssClass="submitbtn1" /><br />
                    <asp:RequiredFieldValidator ID="reqvalZipCode" ValidationGroup="FriendInvite" runat="server"
                        ControlToValidate="txtFriendsEmail" Display="None" ErrorMessage="Please type in your Friend's email address"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ValidationGroup="FriendInvite" ID="regExpEmail" runat="server"
                        ControlToValidate="txtFriendsEmail" ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$"
                        Display="None" ErrorMessage="Please enter a valid Email"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ValidationGroup="OtherValidation" ID="regEmail" runat="server"
                        ControlToValidate="txtFriendsEmail" ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$"
                        Display="None" ErrorMessage="Please enter a valid Email" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Panel ID="div_dtlist" runat="server">
                        <asp:DataList ID="dlInviteFriends" GridLines="None" BorderColor="black" AlternatingItemStyle-BackColor="gainsboro"
                            HeaderStyle-CssClass="lockrow" runat="server" ShowHeader="true" Width="100%"
                            HorizontalAlign="center">
                            <HeaderTemplate>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="65%">
                                            <asp:Label ID="lblEmailtxtHdr" CssClass="headertext2" runat="server" Text="Email"></asp:Label>
                                        </td>
                                        <td width="35%">
                                            <asp:Label ID="lblSelectRemove" CssClass="headertext2" runat="server" Text="Remove"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="65%">
                                            <asp:Label ID="lblEmail" CssClass="QuestionText" runat="server" Text='<% #Eval("Answer") %>'></asp:Label>
                                        </td>
                                        <td width="35%">
                                            <asp:CheckBox CssClass="QuestionText" ID="chkEmail" runat="server" Checked="true" />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </asp:Panel>
                </td>
            </tr>
            <!-- Admin Panel-->
            <tr>
                <td colspan="2" align="center">
                    <asp:Panel ID="PnlAdmin" runat="server" Visible="false">
                        <table width="90%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td width="38%">
                                    <asp:Label ID="Label21" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label
                                        ID="Label1" CssClass="text" runat="server" Text="Comments"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtComments" runat="server" CssClass="txtbox2" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:CustomValidator ID="CusValComments1" ValidationGroup="CommentsGroup" runat="server"
                        Display="None" CssClass="InfoText" ErrorMessage="Please enter the Comments" EnableClientScript="false"></asp:CustomValidator>
                </td>
            </tr>
            <!--end of admin panel-->
            <tr>
                <td valign="top">
                    <asp:Label ID="Label18" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td colspan="4" class="QuestionText">
                                <asp:Label ID="lblRegardingSubmitButton" runat="server" Text="" CssClass="QuestionText"><font color='red'><b>Your application will NOT be submitted until you click the "SUBMIT APPLICATION" button below.</b></font></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server"
                                    Text="Exit To Camper Summary" CssClass="submitbtn1" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" ValidationGroup="CommentsGroup" runat="server" Text=" << Previous"
                                   CssClass="submitbtn" />
                            </td>
                            <td>
                                <asp:Button ID="btnSaveandExit" ValidationGroup="CommentsGroup" runat="server" Text="Save & Continue Later"
                                    CssClass="submitbtn1" />
                            </td>
                            <td align="center">
                                <asp:Button ID="btnSubmitApplication" ValidationGroup="OtherValidation" runat="server"
                                    Text="Submit Application" CssClass="submitbtn1" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>    
    <asp:Panel ID="Panel2" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td valign="top">
                    <asp:Label ID="Label16" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="middle" height="400" align="center">
                    <asp:Label ID="Label17" runat="server" CssClass="headertext1">Thank you for completing our online application form.<br /> <a href="~/CamperOptions.aspx">Click here</a> to create another Application </asp:Label><br />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlHidden" runat="server">
        <asp:HiddenField ID="hdnFJCID_OtherInfo" runat="server" />
        <asp:HiddenField ID="hdnQ1Id" runat="server" Value="1001" />
        <asp:HiddenField ID="hdnQ2Id" runat="server" Value="1002" />
        <asp:HiddenField ID="hdnQ3Id" runat="server" Value="1003" />
        <asp:HiddenField ID="hdnQ4Id" runat="server" Value="1004" />
        <asp:HiddenField ID="hdnQ5Id" runat="server" Value="1005" />
        <asp:HiddenField ID="hdnQ6Id" runat="server" Value="1006" />
        <asp:HiddenField ID="hdnQ7Id" runat="server" Value="1007" />
        <asp:HiddenField ID="hdnQ8Id" runat="server" Value="1008" />
        <asp:HiddenField ID="hdnQ9Id" runat="server" Value="1009" />
        <asp:HiddenField ID="hdnQ10Id" runat="server" Value="1010" />
        <asp:HiddenField ID="hdnQ11Id" runat="server" Value="1011" />
        <asp:HiddenField ID="hdnQ12Id" runat="server" Value="1012" />
        <asp:HiddenField ID="hdnQ13Id" runat="server" Value="1013" />
        <asp:HiddenField ID="hdnQ14Id" runat="server" Value="1023" />
        <asp:HiddenField ID="hdnQ15Id" runat="server" Value="1026" />
    </asp:Panel>

    <script language="javascript" type="text/javascript">
        function CheckCertify_OtherInfo(sender, args)
        {
            var $chk = $('#ctl00_Content_chkAgreement');
            if (!$(chkboxObject).is(':checked')) {
                args.IsValid = false;
                return;
            }

            args.IsValid = false;
            return;
            //var inputobjs = document.getElementsByTagName("input");
            //var chk1, chk2;
            //for (var i = 0; i <= inputobjs.length-1; i++)
            //{
            //    if (inputobjs[i].type=="checkbox")
            //    {
            //        if (inputobjs[i].id.indexOf("chkAgreement_2")>=0 && inputobjs[i].checked)
            //        {
            //            args.IsValid=true;
            //            return;
            //        }
            //    }
            //}
            //args.IsValid = false;
            //return;
        }
        function CheckCertify_ParentInfo2(sender, args)
        {
            debugger;
            var inputobjs = document.getElementsByTagName("input");
            var chk1, chk2;
            for (var i = 0; i <= inputobjs.length-1; i++)
            {
                if (inputobjs[i].type=="checkbox")
                {
                    if (inputobjs[i].id.indexOf("chkQ10")>=0 && inputobjs[i].checked)
                    {
                        args.IsValid=true;
                        return;
                    }
                }
            }
            args.IsValid = false;
            return;
        }
        function CheckCertify_ParentInfo1(sender, args)
        {
            debugger;
            var inputobjs = document.getElementsByTagName("input");
            var chk1, chk2;
            for (var i = 0; i <= inputobjs.length-1; i++)
            {
                if (inputobjs[i].type=="checkbox")
                {
                    if (inputobjs[i].id.indexOf("chkQ9")>=0 && inputobjs[i].checked)
                    {
                        args.IsValid=true;
                        return;
                    }
                }
            }
            args.IsValid = false;
            return;
        }
        
        function chkAgreement(chkobj)
        {
            var inputobjs = document.getElementsByTagName("input");
            var chk1;
            for (var i = 0; i <= inputobjs.length-1; i++)
            {
                if (inputobjs[i].type=="checkbox")
                {
                    if (inputobjs[i].id.indexOf("chkAgreement_0")>=0)
                        chk1 = inputobjs[i];
                }
            }
            
            if (chk1!=null)
            {
                chk1.checked=true;
            }
        }
        function Q8AndQ9CheckBoxSelection(ChkBoxClickedObj,ChkBoxClickedObjText,ChkBoxClickedObjValue)
        {
            var pnl = document.getElementById("ctl00_Content_Panel1");
            var pnlInputObjs = pnl.getElementsByTagName("input");
            var iCount,cnt;
            var chkBoxListId = ChkBoxClickedObj.id.substring(0, ChkBoxClickedObj.id.length-2);
            var chkBoxListObj = document.getElementById(chkBoxListId);
            
            cnt=0;
            for(iCount=0; iCount < pnlInputObjs.length; iCount++)
            {
                if(pnlInputObjs[iCount].type == "checkbox")
                {
                    var chkBox = pnlInputObjs[iCount];
                    if(chkBox.id.indexOf(chkBoxListId) != -1)
                    {    
                        if(chkBox.id != ChkBoxClickedObj.id)
                        {
                            if(ChkBoxClickedObjText.toLowerCase() == "nobody" || ChkBoxClickedObjValue == "4")  //NoBody Option selected in Q8 & Q9
                            {
                                if(cnt == 0 || cnt == 1 || cnt==2)    
                                {
                                    chkBox.disabled = ChkBoxClickedObj.checked;
                                    chkBox.checked = false;
                                }                                
                            }
                            else if(ChkBoxClickedObjText.toLowerCase() == "both of the camper's parents/guardians" || ChkBoxClickedObjValue=="2")  //NoBody Option selected in Q8 & Q9
                            {
                                if(cnt==0 || cnt==3)    
                                {
                                    chkBox.disabled = ChkBoxClickedObj.checked;
                                    chkBox.checked = false;
                                }                                
                            }
                            else if(ChkBoxClickedObjText.toLowerCase() == "one of the camper's parents/guardians" || ChkBoxClickedObjValue=="1")  //NoBody Option selected in Q8 & Q9
                            {
                                if(cnt==1 || cnt==3)    
                                {
                                    chkBox.disabled = ChkBoxClickedObj.checked;
                                    chkBox.checked = false;
                                }
                            }
                        }
                        cnt++;
                        if(cnt == 4) break;                            
                    }
                }
            }
        }
    
        function EnableQ8AndQ9CheckBoxed()
        {
            debugger;
            var chkQ9_0 = document.getElementById("ctl00_Content_chkQ9_0");
            var chkQ9_1 = document.getElementById("ctl00_Content_chkQ9_1");
            var chkQ9_2 = document.getElementById("ctl00_Content_chkQ9_2");
            var chkQ9_3 = document.getElementById("ctl00_Content_chkQ9_3");
            var chkQ10_0 = document.getElementById("ctl00_Content_chkQ10_0");
            var chkQ10_1 = document.getElementById("ctl00_Content_chkQ10_1");
            var chkQ10_2 = document.getElementById("ctl00_Content_chkQ10_2");
            var chkQ10_3 = document.getElementById("ctl00_Content_chkQ10_3");
            if(chkQ9_0.checked)
            {
                chkQ9_1.disabled = chkQ9_3.disabled = true;
            }
            else if(chkQ9_1.checked)
            {
                chkQ9_0.disabled = chkQ9_3.disabled = true;
            }
            else if(chkQ9_3.checked)
            {
                chkQ9_0.disabled = chkQ9_1.disabled = chkQ9_2.disabled = true;
            }
            if(chkQ10_0.checked)
            {
                chkQ10_1.disabled = chkQ10_3.disabled = true;
            }
            else if(chkQ10_1.checked)
            {
                chkQ10_0.disabled = chkQ10_3.disabled = true;
            }
            else if(chkQ10_3.checked)
            {
                chkQ10_0.disabled = chkQ10_1.disabled = chkQ10_2.disabled = true;
            }
        }
        EnableQ8AndQ9CheckBoxed();    
    </script>

</asp:Content>
