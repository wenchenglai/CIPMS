<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step1_Questions.aspx.cs" Inherits="Step1_Questions" Title="Camper Enrollment Step 2" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_CN_1" ContentPlaceHolderID="Content" Runat="Server">
    <asp:Panel ID="Panel2" runat="server">
        <table width="100%" cellpadding="5" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="Label2" CssClass="headertext" runat="server">Basic Camper Information: Section II </asp:Label><br /><br />
                </td>
            </tr>
        </table>
        <!--to display the validation summary (error messages)-->
        <table width="50%" cellpadding="0" cellspacing="0" align="center" border="0">
            <tr>
                <td>
                    <asp:CustomValidator ValidationGroup="OtherValidation" ID="CusVal" CssClass="InfoText" runat="server" Display="Dynamic" ClientValidationFunction="ValidateStep1_Questions"></asp:CustomValidator>
                    <!--to vaidate the comments text box for admin user-->
                    <asp:CustomValidator ID="CusValComments1" ValidationGroup="OtherValidation" runat="server" Display="dynamic" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
                    <asp:ValidationSummary Enabled="false" ID="valSummary" CssClass="InfoText" runat="server" ShowSummary="true" ValidationGroup="GroupAddMore" />
                    <!--this summary will be used only for Comments field (only for Admin user)-->
                    <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblPriorCamperMessag" runat="server" class="InfoText" Text="Label"></asp:Label><span class="InfoText" id="spanPriorCamperMessag" runat="server"></span>
        <table width="100%" cellpadding="5" cellspacing="0" border="0">
             <asp:Panel ID="PnlJWest" runat="server">
            <tr><td valign="top"><asp:Label ID="Label6" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label7" runat="server" Text="1" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="Label12" runat="server" CssClass="QuestionText">Has the camper previously received a grant through the JWest Program?</asp:Label><br />
                        <asp:RadioButtonList ID="RadioBtnQ1" AutoPostBack="true" runat="server" CssClass="QuestionText" RepeatDirection="Horizontal" >
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                            <asp:ListItem Text="I don’t know" Value="3"></asp:ListItem>
                        </asp:RadioButtonList> 
                        <asp:Label ID="lblMsg" runat="server" CssClass="InfoText" ForeColor="Red"></asp:Label>                       
                </td>
            </tr>   
            </asp:Panel> 
            <tr>
                <td valign="top">
                    <asp:Label ID="Label5" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label8" runat="server" Text="2" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Panel id="PnlQ1" runat="server">
                        <asp:Label ID="Label9" runat="server" CssClass="QuestionText">What grade will the camper enter <b><u>AFTER</u></b> camp?</asp:Label><br />
                        <asp:DropDownList AutoPostBack="true" ID="ddlGrade" runat="server" CssClass="dropdown"></asp:DropDownList>
                    </asp:Panel>
                </td>
            </tr>
            
           <%-- <asp:Panel ID="PnlQ1b" runat="server" Visible="false">
            <tr><td valign="top"><asp:Label ID="Label13" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label17" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="Label18" runat="server" CssClass="QuestionText">Will this be the camper's first time attending a nonprofit Jewish overnight summer camp for any length of time?</asp:Label><br />
                        <asp:RadioButtonList ID="RadioBtnQftc" runat="server" CssClass="QuestionText" RepeatDirection="Horizontal" >
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>                        
                </td>
            </tr>   
            </asp:Panel> --%>
            
           <%-- <asp:Panel ID="PnlQ4" runat="server" Visible="false">
            <tr><td valign="top"><asp:Label ID="Label27" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label35" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
            <td valign="top">
                <asp:Label ID="Label126" runat="server" CssClass="QuestionText">Did the camper receive a JWest Campership incentive grant last summer?</asp:Label><br />
                    <asp:RadioButtonList AutoPostBack="true" ID="RadioBtnQ5" runat="server" CssClass="QuestionText" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioBtnQ5_SelectedIndexChanged">
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                    </asp:RadioButtonList></td>                    
            </tr> 
            </asp:Panel>         --%>   
      
           
            <tr>
                <td valign="top">
                    <asp:Label ID="Label3" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label10" runat="server" Text="3" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <asp:Panel ID="PnlQ2" runat="server">
                    <asp:Label ID="Label11" runat="server" CssClass="QuestionText">What kind of school does the camper <b><u>CURRENTLY</u></b> attend?</asp:Label><br />
                        <asp:RadioButtonList AutoPostBack="true" CssClass="QuestionText" ID="RadioBtnQ2" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Private (secular) School" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Public" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Home School" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Jewish day School" Value="4"></asp:ListItem>
                        </asp:RadioButtonList>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td valign="top" style="width:5%">
                    <asp:Label ID="Label4" Text="*" runat="server" CssClass="InfoText" /><asp:Label ID="Label14" runat="server" Text="4" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2">
                    <asp:Panel ID="PnlQ3" runat="server">
                        <asp:Label Visible="false" ID="Label15" runat="server" CssClass="QuestionText">Please select the school that the camper <b><u>CURRENTLY</u></b> attends. 
							<font color="red"><b>If the school is not on this list, please select "OTHER" (at the top) and then type in the name of the school below.</b></font>
						</asp:Label>
                         <table width="100%" cellpadding="0" cellspacing="0" border="0" id="tblControls">
                            <tr>
                                <td colspan="2" style="display:none">
                                    <asp:DropDownList ID="ddlCamperSchool" runat="server" CssClass="dropdown">
                                    </asp:DropDownList>
                                </td>

                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label1" runat="server" CssClass="QuestionText">School Name</asp:Label>
                                    <asp:TextBox ID="txtCamperSchoolOthers" runat="server" CssClass="txtbox4"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>          

            <tr>
                <td colspan="2">
                    <asp:Label Height="30" ID="lblMessage" runat="server" CssClass="InfoText" Visible="false"></asp:Label>
                </td>
            </tr>
            <!-- Admin Panel-->
            <tr>
                <td colspan="2" align="center">
                    <asp:Panel ID="PnlAdmin" runat="server" Visible="false">
                        <table width="90%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width:35%"><asp:Label ID="Label21" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label20" CssClass="text" runat="server" Text="Comments"></asp:Label></td>
                                <td><asp:TextBox ID="txtComments" runat="server" CssClass="txtbox2" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:CustomValidator ID="CusValComments" ValidationGroup="CommentsGroup" runat="server" Display="None" CssClass="InfoText" ErrorMessage = "Please enter the Comments" EnableClientScript="false"></asp:CustomValidator>
                </td>
            </tr>
            <!--end of admin panel-->
            <tr >
                <td valign="top"><asp:Label ID="Label16" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top"  colspan="2">
                    <table width="100%" cellspacing="0" cellpadding="5" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary" CssClass="submitbtn1" /></td>
                            <td >
                                <asp:Button ID="btnPrevious"  ValidationGroup="CommentsGroup" runat="server" Text=" << Previous" CssClass="submitbtn" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnSaveandExit" ValidationGroup="CommentsGroup" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                            </td>
                            <td align="left">
                                <asp:Button ID="btnNext" ValidationGroup="OtherValidation" Text="Next >>" CssClass="submitbtn" runat="server" />
                            </td>
                        </tr>
                     </table>
                </td>
            </tr>
        </table>       
        
    </asp:Panel>
<%--    <asp:Panel ID="LACIPWarningPanel" runat="server" Visible="false">
           <table width="100%" cellpadding="5" cellspacing="0">
             <tr>
              <td><asp:Label ID="Label6" CssClass="QuestionText" runat="server">
                      <br /><p style="text-align:justify">
                         <font color="red"><b>1) If the camper received an incentive grant through the Jewish Federation of 
                         Greater Los Angeles last summer for the <u>FIRST</u> time,</b></font> please <u>save and exit this 
                         application</u> and call Yael Green at the Jewish Federation of Greater Los Angeles 
                         at 323-761-8320. <b>Please do not proceed with this application until you speak 
                         to Yael, as we are experiencing a technical error and your child may be 
                         processed incorrectly if you continue.</b></p>  
                      <p style="text-align:justify">
                        <font color="red"><b>2) If the camper did NOT receive an incentive grant through the Jewish Federation 
                        of Greater Los Angeles last summer, but HAS previously attended nonprofit 
                        Jewish overnight summer camp for 14 days or less,</b></font> please also <u>save and exit 
                        this application</u> and call Yael Green at the Jewish Federation of Greater Los 
                        Angeles at 323-761-8320.</p><br /> 
                    </asp:Label></td>
               </tr>
            <tr>
                <td>
                     <asp:Label ID="Lable2" runat="server" CssClass="Warning2">
                        <p style="text-align:justify">
                            If the camper does not fall into either of the two categories listed above, 
                            please continue with the application. </p>
                    </asp:Label>
                </td>                
            </tr>
            <tr>
            <td><asp:Button ID="btnLACIPClose"  Text="return to application >>" CssClass="submitbtn1" runat="server" OnClick="btnLACIPClose_Click" /></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="OrangeWarningPanel" runat="server" Visible="false">
            <table width="100%" cellpadding="5" cellspacing="0">
             <tr>
              <td><asp:Label ID="Label7" CssClass="QuestionText" runat="server">
                      <br /><p style="text-align:justify">
                         <font color="red"><b>1) If the camper received an incentive grant through the Jewish Federation of Orange County
                          last summer for the <u>FIRST</u> time,</b></font> please <u>save and exit this 
                         application</u> and call Chelle Friedman at the Jewish Federation of Orange County 
                         at 949-435-3484. <b>Please do not proceed with this application until you speak 
                         to Chelle, as we are experiencing a technical error and your child may be 
                         processed incorrectly if you continue.</b></p>  
                      <p style="text-align:justify">
                        <font color="red"><b>2) If the camper did NOT receive an incentive grant through the Jewish Federation of Orange County
                         last summer, but HAS previously attended nonprofit 
                        Jewish overnight summer camp for 20 days or less,</b></font> please also <u>save and exit 
                        this application</u> and call Chelle Friedman at the Jewish Federation of Orange County at 949-435-3484.</p><br /> 
                    </asp:Label></td>
                    </tr>
            <tr>
                <td>
                     <asp:Label ID="Label12" runat="server" CssClass="Warning2">
                        <p style="text-align:justify">
                            If the camper does not fall into either of the two categories listed above, 
                            please continue with the application. </p>
                    </asp:Label>
                </td>                
            </tr>
            <tr>
            <td><asp:Button ID="btnOCClose"  Text="return to application >>" CssClass="submitbtn1" runat="server" OnClick="btnOCClose_Click" /></td>
            </tr>
        </table>
    </asp:Panel>--%>
    
    <!--End of Panel 2 -->
    <asp:HiddenField ID="hdnFJCID" runat="server" />
    <asp:HiddenField ID="hdnZIPCODE" runat="server" />
    <asp:HiddenField ID="hdnFEDID" runat="server" />
    <asp:HiddenField ID="hdnQ1Id" runat="server" Value="6" />
    <asp:HiddenField ID="hdnQ2Id" runat="server" Value="7" />
    <asp:HiddenField ID="hdnQ3Id" runat="server" Value="8" />
    <asp:HiddenField ID="hdnQ1bId" runat="server" Value="3" />
    <asp:HiddenField ID="hdnQ1aId" runat="server" Value="100" />
    <asp:HiddenField ID="hdnQ4Id" runat="server" Value="101" />
    <asp:HiddenField ID="hdnIsLACIP" runat="server" />
    <asp:HiddenField ID="hdnIsOC" runat="server" />
    <asp:HiddenField ID="hdnIsAdmin" runat="server" />
    <asp:HiddenField ID="hdnIsSubmitted" runat="server" />
   
    
    <script language="javascript" type="text/javascript">
            function ValidateStep1_Questions(sender, args)
            {
                var inputobjs = document.getElementsByTagName("input");
                var selectobjs = document.getElementsByTagName("select");
                var schooltype_0, schooltype_1, schooltype_2, schooltype_3, ddlSchool, ddlGrade;
                var firsttimecamper_0,firsttimecamper_1;
                var secondtimecamper_0,secondtimecamper_1;
                var school,MessageObj;
                var IsLacIP,IsOC,IsAdmin,IsSubmitted;
                var jwestfirsttimer_0,jwestfirsttimer_1,jwestfirsttimer_2;
             
                MessageObj = document.getElementById(sender.id);
                IsLacIP=document.getElementById('<%= hdnIsLACIP.ClientID %>').value;
                IsOC=document.getElementById('<%= hdnIsOC.ClientID %>').value;
                
                IsAdmin=document.getElementById('<%= hdnIsAdmin.ClientID %>').value;
                IsSubmitted=document.getElementById('<%= hdnIsSubmitted.ClientID %>').value;
                //to get the school type radio button objects
                for (var i =0; i<=inputobjs.length-1; i++)
                {
                    if (inputobjs[i].type=="radio")
                    {
                        if (inputobjs[i].id.indexOf("RadioBtnQ2_0")>=0)
                            schooltype_0 = inputobjs[i];
                        if (inputobjs[i].id.indexOf("RadioBtnQ2_1")>=0)
                            schooltype_1 = inputobjs[i];
                        if (inputobjs[i].id.indexOf("RadioBtnQ2_2")>=0)
                            schooltype_2 = inputobjs[i];
                        if (inputobjs[i].id.indexOf("RadioBtnQ2_3")>=0)
                            schooltype_3 = inputobjs[i];
                        if (inputobjs[i].id.indexOf("RadioBtnQ5_0")>=0)
                            secondtimecamper_0 = inputobjs[i];
                        if (inputobjs[i].id.indexOf("RadioBtnQ5_1")>=0)
                            secondtimecamper_1 = inputobjs[i];  
                            
                        if (inputobjs[i].id.indexOf("RadioBtnQ1_0")>=0)
                            jwestfirsttimer_0 = inputobjs[i];
                        if (inputobjs[i].id.indexOf("RadioBtnQ1_1")>=0)
                            jwestfirsttimer_1 = inputobjs[i];
                        if (inputobjs[i].id.indexOf("RadioBtnQ1_2")>=0)
                            jwestfirsttimer_2 = inputobjs[i];  
////                                                    
////                        if  (IsLacIP=="Y" || IsOC=="Y")
////                        {
////                            if (inputobjs[i].id.indexOf("RadioBtnQftc_0")>=0)
////                                firsttimecamper_0 = inputobjs[i]; 
////                            if (inputobjs[i].id.indexOf("RadioBtnQftc_1")>=0)
////                                firsttimecamper_1 = inputobjs[i]; 
////                        }    
                          
                            
                    }
                    //to get the camper school value if the user has selected others
                    if (inputobjs[i].type=="text" && inputobjs[i].id.indexOf("txtCamperSchoolOthers")>=0)
                    {
                        school = inputobjs[i];
                    }
                }
                
                //to get the ddlcamperschool
                for (var j=0; j<=selectobjs.length-1; j++)
                {
                   //to get the the camper school 
                   if (selectobjs[j].id.indexOf("ddlCamperSchool")>=0)
                        ddlSchool = selectobjs[j];
                   //to get the grade                         
                   if (selectobjs[j].id.indexOf("ddlGrade")>=0)
                        ddlGrade = selectobjs[j]; 
                }             
                if (jwestfirsttimer_0.checked==false && jwestfirsttimer_1.checked==false && jwestfirsttimer_2.checked==false)
                {
                    MessageObj.innerHTML = "<li>Please check JWest grant Question</li>";
                    args.IsValid = false;
                    return;
                }
                //if grade is not selected
                if (ddlGrade.selectedIndex==0)
                {
                    MessageObj.innerHTML = "<li>Please select the Grade</li>";
                    args.IsValid = false;
                    return;
                }
//                else
//                {                    
//                    if (ddlGrade.options[ddlGrade.selectedIndex].value==9)
//                    {                        
//                        if (secondtimecamper_0.checked==false && secondtimecamper_1.checked==false)
//                        {
//                            MessageObj.innerHTML = "<li>Please check grant Question</li>";
//                            args.IsValid = false;
//                            return;
//                        }
//                    }
//                    if  ((IsLacIP=="Y" ||IsOC=="Y") && (IsSubmitted=="N") && (IsAdmin=="N"))
//                    {
//                        if (firsttimecamper_0.checked==false && firsttimecamper_1.checked==false)
//                        {
//                            MessageObj.innerHTML = "<li>Please check first time camper Question</li>";
//                            args.IsValid = false;
//                            return;
//                        }
//                    
//                    }
                    
//                    if ((ddlGrade.options[ddlGrade.selectedIndex].value == 6) || (ddlGrade.options[ddlGrade.selectedIndex].value == 7) || (ddlGrade.options[ddlGrade.selectedIndex].value == 8))
//                    {                        
//                        if ((IsJWest=="Y") && (IsSubmitted=="N") && (IsAdmin=="N"))
//                        {
//                            if (jwestfirsttimer_0.checked==false && jwestfirsttimer_1.checked==false && jwestfirsttimer_2.checked==false)
//                            {
//                                MessageObj.innerHTML = "<li>Please check JWest grant Question</li>";
//                                args.IsValid = false;
//                                return;
//                            }
//                        }
//                    }
//                }
                
                if (schooltype_0.checked==false && schooltype_1.checked==false && schooltype_2.checked==false && schooltype_3.checked==false)
                {
                    MessageObj.innerHTML = "<li>Please select the School type</li>";
                    args.IsValid = false;
                    return;
                   
                }
                else if (schooltype_2.checked==false && (schooltype_0.checked || schooltype_1.checked || schooltype_3.checked))
                {
                    if (ddlSchool !=null)
                    {
                        if (ddlSchool.selectedIndex==0)
                        {
                            MessageObj.innerHTML = "<li>Please select the Name of the School</li>";
                            args.IsValid=false;
                            return;
                        }
                        else if (ddlSchool.options[ddlSchool.selectedIndex].value==-1)  //others is selected
                        {
                            //schoolothers textbox
                            if (school!=null)
                            {
                                if (trim(school.value)=="")
                                {
                                    MessageObj.innerHTML = "<li>Please type in the Name of the school</li>";
                                    school.focus();
                                    args.IsValid=false;
                                    return;
                                }
                            }
                        }
                    }
                    
                }
                args.IsValid = true;
                return;
            }
//            function openalert(Radio1Obj)
//            {
//                if (Radio1Obj.value=="3") 
//                  window.open('../JWestInfo.aspx','search','toolbar=no,status=no,scroll=no,width=500,height=100')
//    
//                   // window.alert('If you’re unsure which grant the camper received previously, contact us at campgrants@jewishcamp.org and make sure to include your camper’s full name. In the meantime, feel free to save your application now, you can log back on and complete it later.');
//            }
            
            //to enable the school
            function enableSchool(RadioObj, DivId, txtId, ddlId)
            {
               
                var SchoolDiv = document.getElementById(DivId);
                var SchoolOther = document.getElementById(txtId);
                var ddlSchool = document.getElementById(ddlId);
                var divchild = new Array();
                var iSchoolCount;
                var bDisable;
                divchild = SchoolDiv.childNodes;
                iSchoolCount = ddlSchool.options.length;
                if (RadioObj.value=="3")
                    bDisable=true;
                else
                {
                    bDisable = false;
                }
                //to enable/disable the school div
                SchoolDiv.disabled = bDisable;
                //to enable/disable the ddl school
                if (iSchoolCount==2 && bDisable==false)
                {
                    ddlSchool.disabled= true;
                    ddlSchool.selectedIndex=1;
                    SchoolOther.value="";
                    SchoolOther.disabled=false;
                }
                else if (iSchoolCount > 2 && bDisable==false)
                {
                    ddlSchool.disabled= false;
                    ddlSchool.selectedIndex=0;
                    SchoolOther.value="";
                    SchoolOther.disabled=true;
                }
                else if (bDisable)
                {
                    ddlSchool.disabled= bDisable;
                    ddlSchool.selectedIndex=0;
                    SchoolOther.value="";
                    SchoolOther.disabled=bDisable;
                }
                
                //to enable/disable the labels with in the school div
                for (var i = 0; i<=divchild.length-1; i++)
                {
                    if (divchild[i].id != undefined)
                    {
                        divchild[i].disabled = bDisable;
                    }
                }
                
            }
            
            //to enable the camper schools others text box based on the dropdown value
            function EnableSchoolTextbox(ddl, txtId)
            {
                
                var SchooltxtObj = document.getElementById(txtId);
                if (SchooltxtObj!=null)
                {
                    if (ddl.options[ddl.selectedIndex].value=="-1")  //then others is selected
                    {
                        SchooltxtObj.disabled=false;
                        SchooltxtObj.focus();
                    }
                    else
                    {
                        SchooltxtObj.disabled=true;
                        SchooltxtObj.value = "";
                    }
                }
            }
        
        </script>
</asp:Content>

