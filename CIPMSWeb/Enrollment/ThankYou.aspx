<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="ThankYou.aspx.cs" Inherits="Enrollment_ThankYou" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <table id="maintbl" width="100%">
        <tr>
            <td>
                <asp:Panel ID="pnlEligible" runat="server" Visible="false" Width="100%">
                    <table width="100%">
                        <tr class="QuestionText">
                            <td><asp:Panel ID="pnlCommon" runat="server" Visible="false" Width="100%">
                            
                                <asp:Label ID="lblThankYou" runat="server" CssClass="QuestionText">
                                    <p style="text-align:justify">
                                        <b>Congratulations! Based on your answers, and pending review by your One Happy Camper administrator, your camper appears to be eligible 
                                        for an incentive grant <%=strAmt %>.</b> To track the status of your grant, 
                                        you can return to www.onehappycamper.org, sign in, and click the “Check Application Status” link. 
                                    </p> 
                                    <p runat="server" id="pTempleIsrael" class="text-align:justify;" visible="false">
                                    <!--Temple Israel is awarding an additional $250 to their members! Therefore, the camper appears to be eligible for a $1250 grant!-->
                                    </p>                                                                     
									<asp:Label ID="Label2" runat="server" CssClass="lblPopup1">
										<p style="text-align:justify">
											Your application has now been submitted and any changes or edits can only be made by your One Happy Camper administrator.
										</p>
									</asp:Label>
                                <p style="text-align:justify;">
									<u>Your One Happy Camper administrator is:</u>
								</p>
								</asp:Label>
                                <asp:Label ID="lblContactPerson1" runat="server" CssClass="QuestionText" /><br />
                                <asp:Label ID="lblFed1" runat="server" CssClass="QuestionText" />
                                <asp:Label ID="lblPhone1" runat="server" CssClass="QuestionText" /><br />
                                <a id="Email" runat="server" target="_blank">
                                <asp:Label ID="lblEmail1" runat="server" CssClass="QuestionText"></asp:Label></a>
                                <br /><br /></asp:Panel>
                                
                                <asp:Panel ID="pnlRamah" runat="server" Visible="false" Width="100%">
                                <asp:Label ID="lblThankYouRamah" runat="server" CssClass="QuestionText">
                                    <p style="text-align:justify">
                                        <b>Congratulations! Based on your answers, the camper appears to be eligible 
                                        for an incentive grant <%=strAmt %>.</b> To track the status of your grant, 
                                        you can return to www.onehappycamper.org, sign in, and click the “Check Application Status” link. </p>
                                     <asp:Label ID="Label6" runat="server" CssClass="lblPopup1">
                                        <p style="text-align:justify">
                                            Please note that your application has now been submitted and any changes or edits can only be made 
                                        by a staff person from <%=strRenameOrganisation%> that you have selected.</p></asp:Label>
                                    <p style="text-align:justify">
                                        If you have any questions or need to edit your application in any way, please contact the camp professional listed below.</p></asp:Label>
                                    <asp:Label ID="lblContacrPersionSelected" runat="server" CssClass="QuestionText" /><br />
                                    <asp:Label ID="lblFedSelected" runat="server" CssClass="QuestionText" /><asp:Label ID="lblDesignationSelected" runat="server" CssClass="QuestionText" /><br />
                                    <asp:Label ID="lblPhoneSelected" runat="server" CssClass="QuestionText" /><br />
                                     <a id="Email1Selected" runat="server" target="_blank">
                                    <asp:Label ID="lblEmail1Selected" runat="server" CssClass="QuestionText" /></a><br /><br />
                                </asp:Panel>
                             </td>
                             
                        </tr>                     
                        <tr>
                            <td>
                                <asp:Panel ID="pnlStatus1A" runat="server" Visible="false" Width="100%">
                                    <asp:Label ID="lblTxt1A" runat="server" CssClass="lblPopup1">
                                        <p style="text-align:justify">
                                            PLEASE NOTE: If the camper’s acceptance at camp has not yet been 
                                            confirmed, be in touch with your camp directly 
                                            to make certain that the camper has a spot at camp this summer. 
                                            Incentive grants will only be disbursed (to the camp) after the camper’s 
                                            attendance at camp has been confirmed.    
										</p>
									</asp:Label>
                                </asp:Panel>
                                <asp:Panel ID="pnlStatus1B" runat="server" Visible="false" Width="100%">
                                    <asp:Label ID="lblTxt1B" runat="server" CssClass="lblPopup1">
                                        <p style="text-align:justify">
                                            PLEASE NOTE: the camper’s <u>eligibility cannot be confirmed</u> 
                                            until he/she has registered at camp.</p></asp:Label>
                                </asp:Panel>
                                <asp:Panel ID="pnlStatus1F" runat="server" Visible="false" Width="100%">
                                    <asp:Label ID="Label1" runat="server" CssClass="lblPopup1">
                                        <p style="text-align:justify">
                                                                                      
                                            </p></asp:Label>
                                </asp:Panel>
                                 <asp:Panel ID="PnlPJL" runat="server" Visible="false" Width="100%" CssClass="QuestionText">
                                     <asp:Label ID="Label5" runat="server" CssClass="QuestionText"/>
                                        <p style="text-align:justify" >
                                            <b>Thank you. Your PJ Goes to Camp incentive grant application has been successfully submitted. </b>
                                            </p>
                                          
                                          <p style="text-align:justify">
                                             Your application may take up to six weeks to be reviewed as 
                                             your eligibility and registration at camp is verified. At any time, please feel free to log back onto 
                                             <a id="lnkohc" href="http:\\www.OneHappyCamper.org" target= "_blank" runat="server">www.OneHappyCamper.org</a>
                                              to ‘track your grant’ throughout the approval process.
                                            
                                            
                                          </p>
                                          
                                           <p style="text-align:justify">
                                                Any changes or edits to your application can only be made by a 
                                                staff person from PJ Goes to Camp. If you have any questions or 
                                                need to edit your application in any way, please contact:<br />
                                                Kirstin Gadiel <br />
                                                (413)-439-1968<br />
                                                <a href="mailto:kirstin@hgf.org" target="_blank">kirstin@hgf.org</a>
                                                
                                           </p>
                                           
                                          <p>
                                                PLEASE NOTE: Your camper must be registered at camp before the grant will be approved.
                                                Remember you can only get one One Happy Camper incentive grant.
                                          </p>
                                          <p>
                                                Thank you and we hope your camper enjoys a wonderful summer at camp! 
                                          </p>
                                         
                                 </asp:Panel>
                                 
                                <asp:Panel ID="pnlStatus1G" runat="server" Visible="false" Width="100%">
                                    <asp:Label ID="Label3" runat="server" CssClass="lblPopup1">
                                        <p style="text-align:justify">
                                            PLEASE NOTE:  The camper appears to be eligible based on the information provided.  
                                            The eligibility rules require that we confirm your school for campership eligibility. 
                                            A Foundation for Jewish Camp professional will be in touch with you by phone or email within two 
                                            weeks of your submission to confirm your school's eligibility.</p>
                                         <p style="text-align:justify">
                                             Additionally, the camper's eligibility cannot be confirmed until he/she has registered at camp. 
                                             Once you have registered for camp, please contact the Foundation for Jewish Camp so that your 
                                             application can be confirmed and processed.</p>
                                         </asp:Label>
                                </asp:Panel>
                                
                          </td></tr>                        
                    </table>                    
                </asp:Panel >
                
                <asp:Panel ID="pnlInEligibleNonJewish" runat="server" Visible="false" Width="100%">
                    <asp:Label ID="Label4" runat="server" CssClass="QuestionText">
                        <p style="text-align:justify">
                            Thank you for your interest in Jewish overnight camp! 
                            It appears that the camper does not qualify for an incentive program. 
                            If you feel that you have made a mistake, 
                            please click the link below to create a new application or contact the professional below for more information.</p>
                    </asp:Label>
                </asp:Panel>
                
                <asp:Panel ID="pnlInEligible" runat="server" Visible="false" Width="100%">
                    <asp:Label ID="lblTxtInEligible" runat="server" CssClass="QuestionText">
                        <p style="text-align:justify">
                            While it appears that your camper does not qualify for the program initially selected, s/he may still be eligible for one of our other One Happy Camper programs. <b>While you may feel like you are filling out the same application – don’t give up.</b> There are many different One Happy Camper programs – hopefully one will be right for you.<br /><br />
                            <br />
                            
                            </p>
                        <p style="text-align:justify; font-weight:bold">
                            <asp:LinkButton ID="lnkCopyApp" runat="server" CssClass="QuestionText" OnClick="lnkCopyApp_Click" Font-Size="12px">Click Here</asp:LinkButton> to continue as we check your eligibility against various other One Happy Camper programs such as:</p>
                            <p style="text-align:justify">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            PJ Library One Happy Camper (PJ Goes to Camp)
                            <br /><br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            Or a camp co-sponsored program <br /><br />
                            <br /><br />
                                                     
                            </p>
                            </asp:Label>
                    <asp:Label ID="lblContactinfo" runat="server" CssClass="QuestionText">
                     <p style="text-align:justify">
                     If you think you received this message in error please contact your local partner - information below – or contact your camp directly.</p>
                        <p style="text-align:justify">
                            If you prefer to speak to someone about this incentive application, please contact:</p></asp:Label>
                    <asp:Label ID="lblContactPerson2" runat="server" CssClass="QuestionText" /><br />
                    <asp:Label ID="lblFed2" runat="server" CssClass="QuestionText" /><asp:Label ID="lblDesignation2" 
                    runat="server" CssClass="QuestionText" /><br />
                    <asp:Label ID="lblPhone2" runat="server" CssClass="QuestionText" /><br />
                      <a id="Email2" runat="server" target="_blank">
                    <asp:Label ID="lblEmail2" runat="server" CssClass="QuestionText" /></a>
                </asp:Panel><br />
                
                 <asp:Panel ID="PanelInEligiblePJL" runat="server" Visible="false" Width="100%">
                    <asp:Label ID="Label7" runat="server" CssClass="QuestionText">
                        <p style="text-align:justify">
                           Thank you for your interest in Jewish overnight summer camp! 
                           While it appears that the camper does not qualify for an incentive program in 
                           your community, he/she could be eligible for one of our national incentive programs.</p>
                        <p style="text-align:justify; font-weight:bold">
                            Please <asp:LinkButton ID="LinkButton1" runat="server" CssClass="QuestionText" 
                            OnClick="lnkCopyApp_Click">click here</asp:LinkButton> to see if you are eligible for 
                            one of these national programs.</p></asp:Label>
                    <asp:Label ID="Label8" runat="server" CssClass="QuestionText">
                        <p style="text-align:justify">
                            If you prefer to speak to someone about this incentive application, please contact:<br />
                            For more information on your local incentive program</p>
                            </asp:Label>
                            <asp:Label ID="Label9" runat="server" CssClass="QuestionText" /><br />
                            <asp:Label ID="Label10" runat="server" CssClass="QuestionText" /><br />
                            <asp:Label ID="Label11" runat="server" CssClass="QuestionText" /><br />
                            <asp:Label ID="Label12" runat="server" CssClass="QuestionText" /><br />
                            <asp:Label ID="Label13" runat="server" CssClass="QuestionText" />
                </asp:Panel><br />
            </td></tr>
        <tr class="text">
            <td style="height: 7px">
                <a href="../CamperOptions.aspx">Click here</a> to create another application</td></tr>
    </table>
    
  <!-- Google Code for complete registration Conversion Page -->
<script type="text/javascript">
/* <![CDATA[ */
var google_conversion_id = 1033664268;
var google_conversion_language = "en";
var google_conversion_format = "1";
var google_conversion_color = "ffffff";
var google_conversion_label = "eKd3CJymqgEQjO7x7AM";
var google_conversion_value = 0;
/* ]]> */
</script>
<script type="text/javascript" src="https://www.googleadservices.com/pagead/conversion.js">
</script>
<noscript>
<div style="display:inline;">
<img height="1" width="1" style="border-style:none;" alt="" src="https://www.googleadservices.com/pagead/conversion/1033664268/?label=eKd3CJymqgEQjO7x7AM&amp;guid=ON&amp;script=0"/>
</div>
</noscript>



</asp:Content>

