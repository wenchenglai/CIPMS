<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_2.aspx.cs" Inherits="Step2_URJ_2" Title="Camper Enrollment Step 2" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_CN_1" ContentPlaceHolderID="Content" Runat="Server">
    <script type="text/javascript" src="Validate.js"></script>
    <div>
        <asp:CustomValidator ValidationGroup="OtherValidation" ID="CusVal" CssClass="InfoText" runat="server" Display="Dynamic" ClientValidationFunction="Validator.OnSubmitClick"></asp:CustomValidator>
        <!--to vaidate the comments text box for admin user-->
        <asp:CustomValidator ID="CusValComments1" ValidationGroup="OtherValidation" runat="server" Display="dynamic" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
        <asp:ValidationSummary Enabled="false" ID="valSummary" CssClass="InfoText" runat="server" ShowSummary="true" ValidationGroup="GroupAddMore" />
        <!--this summary will be used only for Comments field (only for Admin user)-->
        <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
    </div>

    <table class="QuestionText">
        <tr>
            <td><span class="InfoText">*</span>1</td>
            <td>
                Will this be the camper's first time attending a Jewish overnight camp for 3 weeks or longer?<br />
                <asp:RadioButton ID="rdoFirstTimerYes" value="1" runat="server" GroupName="FirstTimeCamperGroup" Text="Yes" onclick="Validator.OnFirstTimerChange(this);" />
                <asp:RadioButton ID="rdoFirstTimerNo" value="2" GroupName="FirstTimeCamperGroup" runat="server" Text="No" onclick="Validator.OnFirstTimerChange(this);" />
                <div id="divTaste" runat="server">
                    Is the first-time camper attending a ¡°Taste of Camp¡± session?
                    <asp:RadioButton ID="rdoTasteOfCampYes" value="1" runat="server" GroupName="TasteGroup" Text="Yes" />
                    <asp:RadioButton ID="rdoTasteOfCampNo" value="2" GroupName="TasteGroup" runat="server" Text="No" />
                </div>        
            </td>
        </tr>
        <tr>
            <td><span class="InfoText">*</span>2</td>
            <td>
                What grade will the camper enter AFTER camp?<br />
                <asp:DropDownList ID="ddlGrade" runat="server" CssClass="dropdown"></asp:DropDownList>
                <asp:RequiredFieldValidator Enabled="false" ID="reqvalgrade" ControlToValidate="ddlGrade" runat="server" ErrorMessage="Please enter the Grade" Display="none" />
            </td>
        </tr>
        <tr>
            <td><span class="InfoText">*</span>3</td>
            <td>
                What kind of school does the camper <b><u>CURRENTLY</u></b> attend?
                <asp:RadioButtonList CssClass="QuestionText" ID="rdoSchoolType" onclick="Validator.OnSchoolDropDownChange(this);" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Private (secular) School" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Public" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Home School" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Jewish day School" Value="4"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="reqval" ControlToValidate="rdoSchoolType" runat="server"  Display="none" ErrorMessage="Please select the type of School"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><span class="InfoText">*</span>4</td>
            <td>
                Please enter the name of the school that the camper <em><u>CURRENTLY</u></em> attends:<br />
                <asp:TextBox ID="txtSchoolName" runat="server" CssClass="txtbox" MaxLength="200" />
                <asp:RequiredFieldValidator ID="reqvalSchool"  Display="none" ControlToValidate="txtSchoolName" runat="server" ErrorMessage="Please enter the Name of the School" />
            </td>
        </tr>
        <tr>
            <td><span class="InfoText">*</span>5</td>
            <td>
                Are you a member of any of the following? Membership not required for this grant. (Check all that apply)

                <div ID="pnlSynagogue" runat="server" class="questionrows">
                    <div style="padding-left:0px;">
                        <input type="checkbox" value="1" runat="server" id="chkSynagogue" onclick="Validator.OnSynagogueCheckboxChange(this);" />&nbsp;Synagogue
                    </div>
                    <div>
                        <asp:DropDownList ID="ddlSynagogue" runat="server" CssClass="dropdown" onChange="Validator.OnSynagogueDropDownChange(this);" />
                        If "Other":
                        <asp:TextBox ID="txtOtherSynagogue" runat="server" CssClass="txtbox" MaxLength="200" Width="160px" />
                    </div>
                    <div>
                        <div id="divReferBy" disabled="true" runat="server">
                            Who, if anyone, from your synagogue, did you speak to about Jewish overnight camp?<br />
                            <asp:RadioButton ID="rdoCongregant" runat="server" Text="A professional or fellow congregant" GroupName="WhoType" onclick="Validator.OnWhoRadioChange(this);" />
                            <asp:RadioButton ID="rdoNoOne" runat="server" Text="No one from my synagogue" GroupName="WhoType" onclick="Validator.OnWhoRadioChange(this);" />
                            <div id="divWhoInSynagogue" disabled="true" runat="server">
                                <asp:DropDownList ID="ddlWho" DataTextField="Name" DataValueField="ID" runat="server" onChange="Validator.OnWhoInSynagogueDropDownChange(this);" />
                                If "Other":
                                <asp:TextBox ID="txtWhoInSynagogue" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
                <div id="pnlJCC" runat="server" Width="100%" class="questionrows">
                    <div style="padding-left:0px;">
                        <input type="checkbox" value="3" runat="server" id="chkJCC" onclick="Validator.OnJCCChekboxChange(this);" />&nbsp;<span>JCC</span>
                    </div>
                    <div>
                        <asp:DropDownList ID="ddlJCC" runat="server" CssClass="dropdown" Width="240px" onChange="Validator.OnJCCDropDownChange(this);" />
                        If "Other":
                        <asp:TextBox ID="txtJCC" runat="server" CssClass="txtbox" Enabled="false" MaxLength="200" Width="160px" />
                    </div>
                </div>
                <div style="padding-top:10px;">
                    <input type="checkbox" value="2" runat="server" id="chkNoneOfAboveSynJcc" onclick="Validator.OnOtherChekboxChange(this);" />&nbsp;None of the Above
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <span class="InfoText">*</span>6
            </td>
            <td>
                Are any members of your family members or alumni of a youth movement? If Yes, which one?<br />
                <asp:RadioButton ID="rdoMemberOfYouthYes" value="1" GroupName="MemberOfYouth" runat="server" Text="Yes" />
                <asp:RadioButton ID="rdoMemberOfYouthNo" value="2" GroupName="MemberOfYouth" runat="server" Text="No" />
                <br />If Yes ->
                <asp:TextBox ID="txtMemberOfYouth" runat="server" MaxLength="200" />
            </td>
        </tr>
        <tr>
            <td>
                <span class="InfoText">*</span>7
            </td>
            <td>
                Has anyone in your family participated in March of the Living?"
                <asp:RadioButtonList ID="rdolistParticipateMarchLiving" runat="server" RepeatDirection="Horizontal" CssClass="QuestionText">
                    <asp:ListItem Text="One of the camper's parents/guardians" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Both of the camper's parents/guardians" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Camper's Sibling(s)" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Nobody" Value="4"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <span class="InfoText">*</span>8
            </td>
            <td>
                Has anyone in your family participated in Taglit-Birthright Israel?
                <asp:RadioButtonList ID="rdolistParticipateTaglit" runat="server" RepeatDirection="Horizontal" CssClass="QuestionText">
                    <asp:ListItem Text="One of the camper's parents/guardians" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Both of the camper's parents/guardians" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Camper's Sibling(s)" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Nobody" Value="4"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <span class="InfoText">*</span>9
            </td>
            <td>
                Has anyone in your family been to Israel? If yes, how many time?
                &nbsp;
                <asp:RadioButton ID="rdoBeenToIsraelYes" value="1" GroupName="BeenToIsrael" runat="server" Text="Yes" />
                <asp:RadioButton ID="rdoBeenToIsraelNo" value="2" GroupName="BeenToIsrael" runat="server" Text="No" />
                <br />If Yes ->
                <asp:TextBox ID="txtBeenToIsrael" runat="server" MaxLength="200" />
            </td>
        </tr>
        <!-- Admin Panel-->
        <tr>
            <td colspan="2">
                <asp:Panel ID="PnlAdmin" runat="server" Visible="false">
                    <table border="0">
                        <tr>
                            <td><span class="InfoText">*</span>Comments</td>
                            <td><asp:TextBox ID="txtComments" runat="server" CssClass="txtbox2" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:CustomValidator ID="CusValComments" ValidationGroup="CommentsGroup" runat="server" Display="None" CssClass="InfoText" ErrorMessage = "Please enter the Comments" EnableClientScript="false"></asp:CustomValidator>
            </td>
        </tr>
        <!--end of admin panel-->
        <tr >
            <td colspan="2">
                <table border="0">
                    <tr>
                        <td>
                            <asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary" CssClass="submitbtn1" />
                        </td>
                        <td >
                            <asp:Button ID="btnPrevious"  ValidationGroup="CommentsGroup" runat="server" Text=" << Previous" CssClass="submitbtn" />
                        </td>
                        <td>
                            <asp:Button ID="btnSaveandExit"  ValidationGroup="CommentsGroup" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                        </td>
                        <td>
                            <asp:Button ID="btnNext" ValidationGroup="OtherValidation" Text="Next >>" CssClass="submitbtn" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <asp:HiddenField ID="hdnFJCIDStep2_2" runat="server" />
    <asp:HiddenField ID="hdnAddMoreYearCount" runat="server" />
    <asp:HiddenField ID="hdnQ3IdIsFirtTimer" runat="server" Value="3" />
    <asp:HiddenField ID="hdnQ6IdGrade" runat="server" Value="6" />
    <asp:HiddenField ID="hdnQ7IdKindofSchool" runat="server" Value="7" />
    <asp:HiddenField ID="hdnQ8IdSchoolName" runat="server" Value="8" />
    <asp:HiddenField ID="hdnQ30IdWereYouReferredBySynOrJcc" runat="server" Value="30" />
    <asp:HiddenField ID="hdnQ31SelectSynaJccId" runat="server" Value="31" /> 
    <asp:HiddenField ID="hdnQ1002SynagogueName" runat="server" Value="1002" /> 
    <asp:HiddenField ID="hdnQ1040MemberOfYouth" runat="server" Value="1040" /> 
    <asp:HiddenField ID="hdnQ1041ParticipateMarchLiving" runat="server" Value="1041" />
    <asp:HiddenField ID="hdnQ1042ParticipateTaglit" runat="server" Value="1042" /> 
    <asp:HiddenField ID="hdnQ1043BeenToIsrael" runat="server" Value="1043" />   
    <asp:HiddenField ID="hdnQ1044ReferByType" runat="server" Value="1044" />   
    <asp:HiddenField ID="hdnQ1045ReferBy" runat="server" Value="1045" />   
    <asp:HiddenField ID="hdnQ1046TasteOfCamp" runat="server" Value="1046" />                             
</asp:Content>

