<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step1_NL.aspx.cs" Inherits="Step1_NL" Title="Camper Enrollment Step 1" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_CN_1" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="Label4" CssClass="headertext" runat="server">One Happy Camper Camp Programs</asp:Label><br /><br />
            </td>
        </tr>
    </table>
    <!--Panel 1 - Questions displayed on page 1 of Step 2-->
    <asp:Panel ID="Panel1" runat="server">
        <!--to display the validation summary (error messages)-->
        <table width="75%" cellpadding="0" cellspacing="0" border="0" align="center">
            <tr>
                <td>
                    <asp:CustomValidator ID="CusVal" runat="server" ClientValidationFunction="ValidateNLCamp" Display="Dynamic" CssClass="InfoText"></asp:CustomValidator>
                    <!--this summary will be used only for Comments field (only for Admin user)-->
                    <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
                    <asp:CustomValidator ID="CusValComments" runat="server" Display="Dynamic" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
                </td>
            </tr>
        </table>
        <table width="100%" cellpadding="1" cellspacing="0" border="0" class="QuestionText">
             <tr>            
                <td>
                    <p style="text-align:justify">
                        Your community does not appear to be a sponsor of the One Happy Camper program or you did not meet their eligibility criteria. 
                        If you have questions about your community’s One Happy Camper program and/or want to contact your local program, click <a href="http://www.jewishcamp.org/contact-us" target="_blank">here</a>.
                    </p>
                    <p>
                        Additionally, many camps sponsor a One Happy Camper grant. If you do not see your camp they do not sponsor a One Happy Camper grant. Please select your camp:
                    </p>
                    <div style="margin: auto; width: 60%; border-width: 3px solid">
                        <asp:DropDownList ID="ddlCamp" runat="server" CssClass="dropdown"></asp:DropDownList>
                    </div>
                    <p>
                        We believe that every child deserves an opportunity to go to camp, but recognize that some families might require assistance . Visit our 
                        <a href="http://www.jewishcamp.org/camper-scholarships" target="_blank">scholarship</a>  
                        directory and/or speak to your camp and local organizations to see what resources may be available.
                    </p>
                    <p>
                        Please note: You are only eligible to receive one One Happy Camper grant.
                    </p>
                    <p>
                        Questions?  Give us a call at 1-888-888-4819
                    </p>
                </td>
             </tr>
                
            <!--admin panel-->
            <tr>
                <td align="center">
                    <asp:Panel ID="PnlAdmin" runat="server" Visible="false" CssClass="PnlAdmin">
                        <table width="90%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td width="35%"><asp:Label ID="Label21" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label20" CssClass="text" runat="server" Text="Comments"></asp:Label></td>
                                <td><asp:TextBox ID="txtComments" runat="server" CssClass="txtbox2" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:CustomValidator ID="CusValComments1" ValidationGroup="CommentsGroup" runat="server" Display="None" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
                </td>
            </tr>
            <!--end of admin panel-->
            <tr> 
                <td valign="top" ><br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" /></td>
                            <td >
                                <asp:Button ID="btnPrevious" ValidationGroup="CommentsGroup" runat="server" Text=" << Previous" CssClass="submitbtn" />
                            </td>

                            <td align="right">
                                <asp:Button ID="btnSaveandExit"  ValidationGroup="CommentsGroup" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                            </td>
                            
                             <td align="center">
                                <asp:Button ID="btnNext" runat="server" Text="CONTINUE APPLICATION" Width="200px" CssClass="submitbtn" OnClick="btnNext_Click1"/>
                            </td>
                        </tr>
                     </table>
                </td>
            </tr>
        </table>
        
    </asp:Panel>
    
    <!--End of Panel 1 -->
    <input type="hidden" runat="server" id="hdnQ1Id" value="10" />
    
    <asp:HiddenField ID="hdnFJCIDStep1_NL" runat="server" />
    <asp:HiddenField ID="hdnFEDID" runat="server" />
    <!--Previous next buttons-->    

</asp:Content>

