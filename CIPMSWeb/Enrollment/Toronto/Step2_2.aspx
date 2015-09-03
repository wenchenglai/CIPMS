<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_2.aspx.cs" Inherits="TorontoPage2" Title="Camper Enrollment Step 2" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_CN_1" ContentPlaceHolderID="Content" Runat="Server">
    <script type="text/javascript" src="../CommonValidate.js"></script>
    <script type="text/javascript" src="Validate.js"></script>
    <div>
        <asp:CustomValidator ValidationGroup="OtherValidation" ID="CusVal" CssClass="InfoText" runat="server" Display="Dynamic" ClientValidationFunction="PageValidator.OnSubmitClick"></asp:CustomValidator>
        <!--to vaidate the comments text box for admin user-->
        <asp:CustomValidator ID="CusValComments1" ValidationGroup="OtherValidation" runat="server" Display="dynamic" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
        <asp:ValidationSummary Enabled="false" ID="valSummary" CssClass="InfoText" runat="server" ShowSummary="true" ValidationGroup="GroupAddMore" />
        <!--this summary will be used only for Comments field (only for Admin user)-->
        <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
    </div>

    <table>
        <tbody class="QuestionText">
        <tr>
            <td valign="top"><span class="InfoText">*</span>1</td>
            <td valign="top" style="padding-bottom:20px;">
                Will this be the camper’s first-time attending a nonprofit Jewish overnight camp for 19 consecutive days or longer?
                <div>
                    <asp:RadioButton ID="rdoFirstTimerYes" value="1" runat="server" GroupName="FirstTimeCamperGroup" Text="Yes" onclick="PageValidator.OnFirstTimerChange(this);" />
                    <asp:RadioButton ID="rdoFirstTimerNo" value="2" GroupName="FirstTimeCamperGroup" runat="server" Text="No" onclick="PageValidator.OnFirstTimerChange(this);" />
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>1a</td>
            <td valign="top" style="padding-bottom:20px;">
                Is the first-time camper attending a "Taste of Camp" session?
                <div id="divTaste" runat="server">
                    <asp:RadioButton ID="rdoTasteOfCampYes" value="1" runat="server" GroupName="TasteGroup" Text="Yes" />
                    <asp:RadioButton ID="rdoTasteOfCampNo" value="2" GroupName="TasteGroup" runat="server" Text="No" />
                </div>    
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>2</td>
            <td valign="top" style="padding-bottom:20px;">
                What grade will the camper enter AFTER camp?
                <div class="QuestionsLeaveSomeUpperSpace">
                    <asp:DropDownList ID="ddlGrade" runat="server" CssClass="dropdown" />
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>3</td>
            <td valign="top" style="padding-bottom:20px;">
                What kind of school does the camper <b><u>CURRENTLY</u></b> attend?
                <asp:RadioButtonList ID="rdoSchoolType" onclick="SchoolValidator.OnSchoolDropDownChange(this);" runat="server" RepeatDirection="Horizontal" CssClass="QuestionText">
                    <asp:ListItem Text="Public" Value="2" />
                    <asp:ListItem Text="Jewish day School" Value="4" />
                    <asp:ListItem Text="Private (secular) School" Value="1" />
                    <asp:ListItem Text="Home School" Value="3" />
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>4</td>
            <td valign="top" style="padding-bottom:20px;">
                Please enter the name of the school that the camper <b><u>CURRENTLY</u></b> attends:
                <div class="QuestionsLeaveSomeUpperSpace">
                    <asp:TextBox ID="txtSchoolName" runat="server" CssClass="txtbox" MaxLength="200" />
                </div> 
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>5</td>
            <td valign="top" style="padding-bottom:20px;">
                Are you a member of any of the following? Membership not required for this grant. (Check all that apply)
                <div ID="pnlSynagogue" class="questionrows" runat="server">
                    <div class="column1" style="float:left; width: 100px;">
                        <input type="checkbox" value="1" runat="server" id="chkSynagogue" onclick="SJValidator.OnSynagogueCheckboxChange(this);" />&nbsp;Synagogue
                    </div> 
                    <div class="column1" style="float:left; width: 200px;">
                        <asp:DropDownList ID="ddlSynagogue" runat="server" CssClass="dropdown" Width="180px" onChange="PageValidator.OnSynagogueDropDownChange(this);" />
                    </div> 
                    <div class="column1" style="float:left; width: 250px;">
                        If "Other": <asp:TextBox ID="txtOtherSynagogue" runat="server" MaxLength="200" Width="160px" CssClass="txtbox" />
                    </div> 
                </div>
                <div id="pnlJCC" class="questionrows" runat="server" Width="100%">
                    <div class="column1" style="float:left; width: 100px;">
                        <input type="checkbox" value="3" runat="server" id="chkJCC" onclick="SJValidator.OnJCCChekboxChange(this);" />&nbsp;<span>JCC</span>
                    </div>
                    <div class="column1" style="float:left; width: 200px;">
                        <asp:DropDownList ID="ddlJCC" runat="server" CssClass="dropdown" Width="180px" onChange="SJValidator.OnJCCDropDownChange(this);" />
                    </div>
                    <div class="column1" style="float:left; width: 250px;">
                        If "Other": <asp:TextBox ID="txtOtherJCC" runat="server" MaxLength="200" CssClass="txtbox" Width="160px" />
                    </div>
                </div>
                <div class="questionrows">
                    <input type="checkbox" value="2" runat="server" id="chkNo" onclick="SJValidator.OnOtherChekboxChange(this);" />&nbsp;None of the Above
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>5a</td>
            <td valign="top" style="padding-bottom:20px;">
                <div>Who, if anyone, from your synagogue, did you speak to about Jewish overnight camp?</div>
                <div>
                    <asp:RadioButton ID="rdoCongregant" runat="server" Text="A professional or fellow congregant" GroupName="WhoType" onclick="SJValidator.OnWhoRadioChange(this);" />
                    <span id="divWhoInSynagogue" runat="server">
                        <asp:DropDownList ID="ddlWho" DataTextField="Name" CssClass="dropdown" DataValueField="ID" Width="140px" runat="server" onChange="SJValidator.OnWhoInSynagogueDropDownChange(this);" />
                        If "Other":
                        <asp:TextBox ID="txtWhoInSynagogue" Width="130px" CssClass="txtbox" runat="server" />
                    </span>   
                </div>
                <div>
                    <asp:RadioButton ID="rdoNoOne" runat="server" Text="No one from my synagogue" GroupName="WhoType" onclick="PageValidator.OnWhoRadioChange(this);" />
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>6</td>
            <td valign="top" style="padding-bottom:20px;">
                <div>Is the camper currently enrolled in a congregational or religious school? (Enrollment not required for this grant)</div>
                <div>
                    <asp:RadioButton ID="rdoSecondarySchoolYes" value="1" GroupName="Secondary" runat="server" Text="Yes" onclick="PageValidator.OnSecondarySchoolRadioChange(this);" />
                    <asp:RadioButton ID="rdoSecondarySchoolNo" value="2" GroupName="Secondary" runat="server" Text="No" onclick="PageValidator.OnSecondarySchoolRadioChange(this);" />
                </div>
            </td>
        </tr>
        <tr id="6a">
            <td valign="top"><span class="InfoText">*</span>6a</td>
            <td valign="top" style="padding-bottom:20px;">
                <div>Please select the secondary school:</div>
                <div>
                    <asp:DropDownList ID="ddlSecondarySchool" CssClass="dropdown" Width="300px" runat="server" onChange="PageValidator.OnSecondarySchoolDropDownChange(this);">
                        <asp:ListItem Value="-- Select --"></asp:ListItem>
                        <asp:ListItem Value="Adath Israel Congregational School" />
                        <asp:ListItem Value="Ahavat Yisrael Hebrew Schools" />
                        <asp:ListItem Value="Beit Rayim Hebrew School" />
                        <asp:ListItem Value="Bet Sefer Solel" />
                        <asp:ListItem Value="Beth Radom Congregation Hebrew School" />
                        <asp:ListItem Value="Beth Sholom Hebrew School" />
                        <asp:ListItem Value="Beth Torah Hebrews' Cool" />
                        <asp:ListItem Value="Beth Tzedec Congregational School" />
                        <asp:ListItem Value="CCCS Congregational High School / Adath Israel" />
                        <asp:ListItem Value="Chabad Hebrew School (Green Lane)" />
                        <asp:ListItem Value="Chabad of Richmond Hill Hebrew School (Chabad Romano)" />
                        <asp:ListItem Value="CHAI School: Toronto" />
                        <asp:ListItem Value="Danforth Jewish Circle - Children's Jewish" />
                        <asp:ListItem Value="Darchei Noam Hebrew School" />
                        <asp:ListItem Value="Downtown Jewish Community School" />
                        <asp:ListItem Value="EdToronto" />
                        <asp:ListItem Value="Hebrew Academy Of North York" />
                        <asp:ListItem Value="Holy Blossom Temple Religious School" />
                        <asp:ListItem Value="Jewish Heritage School at Beth Habonim" />
                        <asp:ListItem Value="JRCC Hebrew School" />
                        <asp:ListItem Value="J. Roots Supplementary Jewish School" />
                        <asp:ListItem Value="Kachol Lavan/The Centre for Hebrew & Israel Studies" />
                        <asp:ListItem Value="Kol Ami Religious School " />
                        <asp:ListItem Value="Morris Winchevsky School: Toronto’s Secular Jewish Community School" />
                        <asp:ListItem Value="Neshamah Congregation of York Reigion" />
                        <asp:ListItem Value="Oraynu Children's School" />
                        <asp:ListItem Value="Or Hadash" />
                        <asp:ListItem Value="PJ Plus" />
                        <asp:ListItem Value="Shaarei-Beth El Religious School" />
                        <asp:ListItem Value="Temple Har Zion Religious School" />
                        <asp:ListItem Value="Temple Sinai Religious School" />
                        <asp:ListItem Value="The Centre for Jewish Living and Learning @ Temple Emanu-EL" />
                        <asp:ListItem Value="The City Shul Nightingale School" />
                        <asp:ListItem Value="Torah High" />
                        <asp:ListItem Value="Other" />
                    </asp:DropDownList>
                     If "Other": <asp:TextBox ID="txtSecondarySchool" runat="server" MaxLength="200" Width="160px" CssClass="txtbox" />
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>7</td>
            <td valign="top" style="padding-bottom:20px;">
                <div>Are any members of your family members or alumni of a youth movement? If Yes, which one?</div>
                <div>
                    <asp:RadioButton ID="rdoMemberOfYouthYes" value="1" GroupName="MemberOfYouth" runat="server" Text="Yes" onclick="PageValidator.OnYouthMovementRadioChange(this);" />
                    <asp:RadioButton ID="rdoMemberOfYouthNo" value="2" GroupName="MemberOfYouth" runat="server" Text="No" onclick="PageValidator.OnYouthMovementRadioChange(this);" />
                    &nbsp;&nbsp;If Yes ->  <asp:TextBox ID="txtMemberOfYouth" CssClass="txtbox" runat="server" MaxLength="200" />
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>8</td>
            <td valign="top" style="padding-bottom:20px;">
                Has anyone in your family participated in March of the Living?"
                <asp:CheckBoxList ID="rdolistParticipateMarchLiving" runat="server" RepeatDirection="Vertical" CssClass="QuestionText">
                    <asp:ListItem Text="One of the camper's parents/guardians" Value="1" onclick="PageValidator.OnParticipateMarchLivingCheckboxChange(this);" ></asp:ListItem>
                    <asp:ListItem Text="Both of the camper's parents/guardians" Value="2" onclick="PageValidator.OnParticipateMarchLivingCheckboxChange(this);" ></asp:ListItem>
                    <asp:ListItem Text="Camper's Sibling(s)" Value="3" onclick="PageValidator.OnParticipateMarchLivingCheckboxChange(this);" ></asp:ListItem>
                    <asp:ListItem Text="Nobody" Value="4" onclick="PageValidator.OnParticipateMarchLivingCheckboxChange(this);" ></asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>9</td>
            <td valign="top" style="padding-bottom:20px;">
                Has anyone in your family participated in Taglit-Birthright Israel?
                <asp:CheckBoxList ID="rdolistParticipateTaglit" runat="server" RepeatDirection="Vertical" CssClass="QuestionText">
                    <asp:ListItem Text="One of the camper's parents/guardians" onclick="PageValidator.OnParticipateTaglitCheckboxChange(this);" Value="1" ></asp:ListItem>
                    <asp:ListItem Text="Both of the camper's parents/guardians" Value="2" onclick="PageValidator.OnParticipateTaglitCheckboxChange(this);" ></asp:ListItem>
                    <asp:ListItem Text="Camper's Sibling(s)" Value="3" onclick="PageValidator.OnParticipateTaglitCheckboxChange(this);" ></asp:ListItem>
                    <asp:ListItem Text="Nobody" Value="4" onclick="PageValidator.OnParticipateTaglitCheckboxChange(this);" ></asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>10</td>
            <td valign="top" style="padding-bottom:20px;">
                <div>
                    Has anyone in your family been to Israel? If yes, how many times collectively?
                </div>
                <div>
                    <asp:RadioButton ID="rdoBeenToIsraelYes" value="1" GroupName="BeenToIsrael" runat="server" Text="Yes" onclick="PageValidator.OnBeenToIsraelRadioChange(this);" />
                    <asp:RadioButton ID="rdoBeenToIsraelNo" value="2" GroupName="BeenToIsrael" runat="server" Text="No" onclick="PageValidator.OnBeenToIsraelRadioChange(this);" />
                    &nbsp;&nbsp;If Yes -> <asp:TextBox ID="txtBeenToIsrael" runat="server" CssClass="txtbox" MaxLength="200" />
                </div>

            </td>
        </tr>
        <!-- Admin Panel-->
        <tr>
            <td colspan="2" align="center">
                <asp:Panel ID="PnlAdmin" runat="server" Visible="false" CssClass="QuestionText">
                    <table width="90%" cellpadding="0" cellspacing="0" border="0" class="QuestionText">
                        <tr>
                            <td><span class="InfoText">*</span>Comments</td>
                            <td><asp:TextBox ID="txtComments" runat="server" CssClass="txtbox2" TextMode="MultiLine" /></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:CustomValidator ID="CusValComments" ValidationGroup="CommentsGroup" runat="server" Display="None" CssClass="InfoText" ErrorMessage = "Please enter the Comments" EnableClientScript="false"></asp:CustomValidator>
            </td>
        </tr>
        <!--end of admin panel-->
        <tr >
                <td valign="top"  colspan="2">
                    <table width="100%" cellspacing="0" cellpadding="5" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" /></td>
                            <td >
                                <asp:Button ID="btnPrevious"  ValidationGroup="CommentsGroup" runat="server" Text=" << Previous" CssClass="submitbtn" />
                            </td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit"  ValidationGroup="CommentsGroup" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnNext" ValidationGroup="OtherValidation" Text="Next >>" CssClass="submitbtn" runat="server" />
                            </td>
                        </tr>
                     </table>
                </td>
        </tr>
        </tbody>
    </table>

    <asp:HiddenField ID="hdnFJCIDStep2_2" runat="server" />                         
</asp:Content>

