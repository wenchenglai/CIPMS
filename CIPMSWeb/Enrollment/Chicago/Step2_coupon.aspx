<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_coupon.aspx.cs" Inherits="Step2_Chicago_2_coupon" Title="Camper Enrollment Step 2" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_Chicago_1" ContentPlaceHolderID="Content" Runat="Server">
    <script type="text/javascript" src="../CommonValidate.js"></script>
    <script type="text/javascript" src="Validate.js"></script>   

    <div>
        <asp:CustomValidator ValidationGroup="OtherValidation" ID="CusVal" CssClass="InfoText" runat="server" Display="Dynamic" ClientValidationFunction="PageValidator.OnSubmitChicagoCouponPageClick"></asp:CustomValidator>
        <!--to vaidate the comments text box for admin user-->
        <asp:CustomValidator ID="CusValComments1" ValidationGroup="OtherValidation" runat="server" Display="Dynamic" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
        <asp:ValidationSummary ID="valSummary" CssClass="InfoText" runat="server" ShowSummary="true" ValidationGroup="GroupAddMore" />
        <!--this summary will be used only for Comments field (only for Admin user)-->
        <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
    </div>
    <table>
        <tbody class="QuestionText">
        <tr>
            <td colspan="2">
                <span style="color:red">It appears that you are not eligible for the One Happy Camper first time incentive grant. However you may be eligible for a Camp Coupon, a program of the Jewish United Fund of Chicago and administered through the One Happy Camper registration system. Please continue with the application to see if see if you are eligible.</span>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>1</td>
            <td valign="top">
    			Did the camper attend a Jewish pre-school?
                <div>
                    <asp:RadioButton ID="rdoYes1" Text="Yes" runat="server" GroupName="one" />
                    <asp:RadioButton ID="rdoNo1" Text="No" runat="server" GroupName="one" />
                </div>
                <div style="margin-top:5px">
                    <div>
                        <span style="width:170px;display:inline-block;">Name of Pre-School</span>
                        <span><asp:TextBox ID="txtCampName1" class="QuestionText" Width="300" runat="server" /></span>
                    </div>
                    <div>
                        <span style="width:170px;display:inline-block;">Street Address</span>
                        <span><asp:TextBox ID="txtAddress1" class="QuestionText" Width="300" runat="server" /></span>
                    </div>
                    <div>
                        <span style="width:170px;display:inline-block;">Country</span>
                        <span>
                            <asp:DropDownList ID="ddlCountry1" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry1_SelectedIndexChanged">
                                <asp:ListItem Text="USA" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Canada" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </span>
                    </div>
                    <div>
                        <span style="width:170px;display:inline-block;">City</span>
                        <span><asp:TextBox ID="txtCity1" Width="300" class="QuestionText" runat="server" /></span>
                    </div>
                    <div>
                        <span style="width:170px;display:inline-block;">State</span>
                        <span><asp:DropDownList CssClass="txtbox" ID="ddlState1" runat="server" /></span>
                    </div>
                    <div>
                        <span style="width:170px;display:inline-block;">Zip Code</span>
                        <span><asp:TextBox ID="txtZipCode1" class="QuestionText" Width="300" runat="server" /></span>
                    </div>
                    <div>
                        <span style="width:170px;display:inline-block;">Last Year Attended</span>
                        <span>
                            <asp:DropDownList ID="ddlYearAttended1" CssClass="QuestionText"  style="height:20; margin-left:0" runat="server">
                                <asp:ListItem Text="--Select--" Value="" />
                                <asp:ListItem Text="2014" Value="2014" />
                                <asp:ListItem Text="2013" Value="2013" />
                                <asp:ListItem Text="2012" Value="2012" />
                                <asp:ListItem Text="2011" Value="2011" />
                                <asp:ListItem Text="2010" Value="2010" />
                                <asp:ListItem Text="2009" Value="2009" />
                                <asp:ListItem Text="2008" Value="2008" />
                                <asp:ListItem Text="2007" Value="2007" />
                                <asp:ListItem Text="2006" Value="2006" />
                                <asp:ListItem Text="2005" Value="2005" />
                                <asp:ListItem Text="2004" Value="2004" />
                                <asp:ListItem Text="2003" Value="2003" />
                                <asp:ListItem Text="2002" Value="2002" />
                                <asp:ListItem Text="2001" Value="2001" />
                                <asp:ListItem Text="2000" Value="2000" />
                            </asp:DropDownList>
                        </span>
                    </div>
                </div>
                <br />
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="InfoText">*</span>2</td>
            <td valign="top">
    			Did the camper attend a Jewish day camp?
                <div>
                    <asp:RadioButton ID="rdoYes2" Text="Yes" runat="server" GroupName="two" />
                    <asp:RadioButton ID="rdoNo2" Text="No" runat="server" GroupName="two" />
                </div>
                <div style="margin-top:5px">
                    <div>
                        <span style="width:170px;display:inline-block;">Name of Day Camp</span>
                        <span><asp:TextBox Width="300" class="QuestionText" ID="txtCampName2" runat="server" /></span>
                    </div>
                    <div>
                        <span style="width:170px;display:inline-block;">Street Address</span>
                        <span><asp:TextBox ID="txtAddress2" class="QuestionText" Width="300" runat="server" /></span>
                    </div>
                    <div>
                        <span style="width:170px;display:inline-block;">Country</span>
                        <span>
                            <asp:DropDownList ID="ddlCountry2" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry2_SelectedIndexChanged">
                                <asp:ListItem Text="USA" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Canada" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </span>
                    </div>
                    <div>
                        <span style="width:170px;display:inline-block;">City</span>
                        <span><asp:TextBox ID="txtCity2" class="QuestionText" Width="300" runat="server" /></span>
                    </div>
                    <div>
                        <span style="width:170px;display:inline-block;">State</span>
                        <span><asp:DropDownList ID="ddlState2" CssClass="txtbox" runat="server" /></span>
                    </div>
                    <div>
                        <span style="width:170px;display:inline-block;">Zip Code</span>
                        <span><asp:TextBox ID="txtZipCode2" class="QuestionText" Width="300" runat="server" /></span>
                    </div>
                    <div>
                        <span style="width:170px;display:inline-block;">Last Year Attended</span>
                        <span>
                            <asp:DropDownList ID="ddlYearAttended2" CssClass="QuestionText" style="height:20; margin-left:0" runat="server">
                                <asp:ListItem Text="--Select--" Value="" />
                                <asp:ListItem Text="2014" Value="2014" />
                                <asp:ListItem Text="2013" Value="2013" />
                                <asp:ListItem Text="2012" Value="2012" />
                                <asp:ListItem Text="2011" Value="2011" />
                                <asp:ListItem Text="2010" Value="2010" />
                                <asp:ListItem Text="2009" Value="2009" />
                                <asp:ListItem Text="2008" Value="2008" />
                                <asp:ListItem Text="2007" Value="2007" />
                                <asp:ListItem Text="2006" Value="2006" />
                                <asp:ListItem Text="2005" Value="2005" />
                                <asp:ListItem Text="2004" Value="2004" />
                                <asp:ListItem Text="2003" Value="2003" />
                                <asp:ListItem Text="2002" Value="2002" />
                                <asp:ListItem Text="2001" Value="2001" />
                                <asp:ListItem Text="2000" Value="2000" />
                            </asp:DropDownList>
                        </span>
                    </div>
                </div>
            </td>
        </tr>      
        <!-- Admin Panel-->
        <tr>
            <td colspan="2" align="center">
                <asp:Panel ID="PnlAdmin" runat="server" Visible="false">
                    <table width="90%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td width="35%"><asp:Label ID="Label21" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label20" CssClass="text" runat="server" Text="Comments"></asp:Label></td>
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
                <table width="100%">
                    <tr>
                        <td align="left">
                            <asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" />
                        </td>
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

    <asp:HiddenField ID="hdnFJCID" runat="server" />
    <asp:HiddenField ID="hdnQ3Id" runat="server" Value="3" />
    <asp:HiddenField ID="hdnQ6Id" runat="server" Value="6" />
    <asp:HiddenField ID="hdnQ7Id" runat="server" Value="7" />
    <asp:HiddenField ID="hdnQ8Id" runat="server" Value="17" />
    <asp:HiddenField ID="hdnQ9Id" runat="server" Value="8" />
	<asp:HiddenField ID="hdnQ30WereYouReferredBySynOrJccId" runat="server" Value="30" />
	<asp:HiddenField ID="hdnQ31SelectSynaJccId" runat="server" Value="31" /> 
	<asp:HiddenField ID="hdnQ1002NameOfSynagogueId" runat="server" Value="1002" />  		        
    <asp:HiddenField ID="hdnQ1032Id" runat="server" Value="1032" />
    <asp:HiddenField ID="hdnQFirstNameOfSibling" runat="server" Value="1033" />
    <asp:HiddenField ID="hdnQLastNameOfSibling" runat="server" Value="1034" />        
 </asp:Content>

