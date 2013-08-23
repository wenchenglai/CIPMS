<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="NYCampRedirect.aspx.cs"
    Inherits="NYCampRedirect" Title="NYCampRedirect" %>

<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
    <table width="75%" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="true" CssClass="InfoText" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Label ID="msgDisplay" CssClass="InfoText" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td valign="middle">
                <br />
                <asp:Panel ID="PanelPassportNYC" runat="server" Visible="true" Width="100%">
                    <table cellpadding="10" cellspacing="0">
                        <tr>
                            <td>
                                <img src="images/REAL passport_Logo.jpg" width="250px" height="120px" />
                            </td>
                            <td>
                                <asp:Label ID="Label15" runat="server" CssClass="infotext3">
                        <p class="infotext3">
                         <b> The Passport NYC One Happy Camper program has met their Incentive quota of 15 participants and is now closed.  For more information please contact Molly Hott at <a href="mailto:PassportNYC@92Y.org"
                        target="_blank">PassportNYC@92Y.org</a>.
                        </b>
                        </p>
                          
                                </asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlNYCampRedirect" runat="server" Visible="true" Width="100%">
                    <asp:Label ID="Label4" runat="server" CssClass="infotext3">
                        <p class="infotext3"><b>
                           "Thank you for your interest in the New Jersey Y Camps One Happy Camper Program. For more information on how to apply, please contact Janet Fligelman at <a href="mailto:janet@njycamps.org"
                        target="_blank">janet@njycamps.org</a> or (973) 575-3333 x121."
                        </b>
                        </p>
                          
                    </asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnlCampBarney" runat="server" Visible="true" Width="100%">
                    <table width="100%" cellpadding="5" cellspacing="0">
                        <tr>
                            <td>
                                <img id="Logo1" src="images/CBMlogo.jpg" alt="" />
                            </td>
                            <td>
                                <asp:Label ID="Label10" runat="server" CssClass="infotext3">
                        <p class="infotext3">
                        <b>The Camp Barney Medintz One Happy Camper grant is now closed.  Please call Barbara Vahaba at 678-812-4142 for information on other incentive grants for which you may be eligible for Summer 2012.</b> </p>
                                </asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlCampJRFRedirect" runat="server" Visible="true" Width="100%">
                    <asp:Label ID="Label1" runat="server" CssClass="infotext3">
                        <p class="infotext3"><b>
                           For information about the Camp JRF One Happy Camper program, please contact Joshua Sternburg at                             
                        <a href="mailto:jsternburg@jrf.org"
                        target="_blank">jsternburg@jrf.org</a> or 215-885-5601 x10.
                        </b>
                        </p>
                          
                    </asp:Label>
                </asp:Panel>
                <asp:Panel ID="PanelHabonimDrorCampGilboa" runat="server" Visible="true" Width="100%">
                    <asp:Label ID="Label2" runat="server" CssClass="infotext3">
                        <p class="infotext3"><b>
                           Thank you for applying for a One Happy Camper Grant.  In order to continue the application process and make sure your camper is eligible, please contact Habonim Dror Camp Gilboa directly. You may either email 
                         <a href="mailto:business@campgilboa.org"
                        target="_blank">business@campgilboa.org</a> or call 323-653-6772.
                        </b>
                        </p>
                          
                    </asp:Label>
                </asp:Panel>
                <asp:Panel ID="PanelCampRamahCalifornia" runat="server" Visible="true" Width="100%">
                    <asp:Label ID="Label3" runat="server" CssClass="infotext3">
                        <p class="infotext3"><b>
                           Thank you for your interest in a Camp Ramah in California One Happy Camper Grant. PLEASE NOTE: At this time all first-time camper grants have been distributed. You may join a waitlist by emailing Karmi Monsher at:
                         <a href="mailto:karmi@ramah.org"
                        target="_blank">karmi@ramah.org</a>.
                        </b>
                        </p>
                          
                    </asp:Label>
                </asp:Panel>
                <asp:Panel ID="PanelCampRamahDarom" runat="server" Visible="true" Width="100%">
                    <asp:Label ID="Label7" runat="server" CssClass="infotext3">
                        <p class="infotext3"><b>
                          Thank you for your interest in a Camp Ramah Darom One Happy Camper grant. PLEASE NOTE: At this time all first-time camper grants have been distributed. You may join a waitlist by emailing Holly Fortson at
                         <a href="mailto:hfortson@ramahdarom.org"
                        target="_blank">hfortson@ramahdarom.org</a>.
                        </b>
                        </p>
                          
                    </asp:Label>
                </asp:Panel>
                <asp:Panel ID="PanelCampAiryLouise" runat="server" Visible="true" Width="100%">
                    <table cellpadding="5" cellspacing="0">
                        <tr>
                            <td>
                                <img src="images/Airy Louise Logo.bmp" alt="" />
                            </td>
                            <td>
                                <asp:Label ID="Label11" runat="server" CssClass="infotext3">
                        <p class="infotext3"><b>
                        If you are applying for funding for summer 2012, the official application will be released in late September. At that time, all parents whose camp applications have indicated their eligibility for the One Happy Camper Program will be emailed the code. This code will allow you to continue with the application process.  In order to apply for the program, you must be enrolled in the 2012 season for camp. The funding is first-come first-served once released. There is no further need to contact the camp until that time.
                        </b></p>
                        <p><b>For campers applying for summer 2011 funding, please contact Shira at <a href="mailto:shira@airylouise.org" target="_blank">shira@airylouise.org</a> or 410.466.9010 in order to obtain the code.
                        </b> </p>                          
                                </asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                </asp:Panel>
                <asp:Panel ID="PanelJCCRanch" runat="server" Visible="true" Width="100%">
                    <table cellpadding="10" cellspacing="0">
                        <tr>
                            <td>
                                <img src="images/JCC_Ranch_logo.jpeg" alt="" />
                            </td>
                            <td>
                                <asp:Label ID="Label16" runat="server" CssClass="infotext3">
                        <p class="infotext3">
                         <b>  Dear JCC Ranch Camp and One Happy Camper applicant, you are getting this message as our grant funds for 2011 were used up by dozens of Happy Campers.  Please contact us at <a href="mailto:gilads@jccdenver.org"
                        target="_blank">gilads@jccdenver.org</a> so we will be able to accommodate your needs for this coming summer.  We will have more funds available for summer 2012.  Thank you for taking part in Jewish Camping.</b>
                        
                        </p>
                          
                                </asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="PanelSolomon" runat="server" Visible="true" Width="100%">
                    <table cellpadding="10" cellspacing="0">
                        <tr>
                            <td>
                                <img src="images/Solomon Schechter Logo.jpg" alt="" />
                            </td>
                            <td>
                                <asp:Label ID="Label17" runat="server" CssClass="infotext3">
                        <p class="infotext3">
                         <b>  Thank you for interest in the Camp Solomon Schechter One Happy Camper program.  Unfortunately, there were a limited number of incentive grants available, and they have all been awarded.  Please feel free to contact the Camp Solomon Schechter office to work out a payment plan. We can be reached at 206-447-1967, or at <a href="mailto:registrar@campschechter.org"
                        target="_blank">registrar@campschechter.org</a>. </b>
                        
                        </p>
                          
                                </asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlCampRamahBerkshires" runat="server" Visible="true" Width="100%">
        <table cellpadding="10" cellspacing="0">
            <tr>
                <td>
                    <img src="images/Ramah_Logo.jpg" alt="" height="65" width="250" />
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" CssClass="infotext3">
                        
                            <p class="infotext3"><b>
                               We are sorry, but there are no more One Happy Camper grants available for Camp Ramah in the Berkshires. For questions, or for more information about financial assistance for Camp Ramah in the Berkshires, please be in touch with Shari Brodsky at 
                             <a href="mailto:sbrodsky@ramahberkshires.org"
                            target="_blank">sbrodsky@ramahberkshires.org</a> or (201) 871-7262.
                            </b>
                            </p>
                            
                    </asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">
            <tr>
                <td valign="top" style="width: 5%">
                    <asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label>
                </td>
                <td valign="top">
                    <br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td align="left">
                                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary"
                                    CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous"
                                    CssClass="submitbtn" OnClick="btnPrevious_Click" />
                            </td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later"
                                    OnClick="btnSaveandExit_Click" CssClass="submitbtn1" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> "
                                    CssClass="submitbtn" OnClick="btnNext_Click" Enabled="false" Visible="false" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
