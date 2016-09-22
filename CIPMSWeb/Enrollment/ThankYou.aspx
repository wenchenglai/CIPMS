<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="ThankYou.aspx.cs" Inherits="Enrollment_ThankYou" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <div>
		<asp:Panel ID="pnlEligible" runat="server" Visible="false" Width="100%">
			<table width="100%">
				<tr class="QuestionText">
					<td>
						<asp:Panel ID="pnlCommon" runat="server" CssClass="QuestionText" Visible="false" Width="100%">
						    <asp:Label ID="lblThankYou" runat="server" CssClass="QuestionText">
							    <p style="text-align:justify">
								    <b>Congratulations! Based on your answers, and pending review by your One Happy Camper administrator, your camper appears to be eligible 
								    for <asp:Label ID="lblCouponSub" runat="server" Text="an incentive grant" /> <%=strAmt %>.</b> To track the status of your grant, 
								    you can return to www.onehappycamper.org, sign in, and click the “Check Application Status” link.
                                    <br /><br />
                                    <asp:Label ID="lblCouponText" runat="server" Visible="false" Text="Please note, Camp Coupons is a program of the Jewish United Fund of Chicago and administered through the One Happy Camper registration system." />
							    </p> 
							    <p runat="server" id="pToronto" class="text-align:justify;" visible="false">
							        Please contact your camp for any questions regarding registration or tuition.
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
						    <asp:Label ID="lblFed1" runat="server" CssClass="QuestionText" /><br />
						    <asp:Label ID="lblPhone1" runat="server" CssClass="QuestionText" /><br />
						    <a id="Email" runat="server" target="_blank">
						        <asp:Label ID="lblEmail1" runat="server" CssClass="QuestionText"></asp:Label>
						    </a>
						    <br /><br />
						</asp:Panel>
								
						<asp:Panel ID="pnlRamah" runat="server" Visible="false" Width="100%">
						    <asp:Label ID="lblThankYouRamah" runat="server" CssClass="QuestionText">
							    <p style="text-align:justify">
								    <b>Congratulations! Based on your answers, the camper appears to be eligible 
								    for an incentive grant <%=strAmt %>.</b> To track the status of your grant, 
								    you can return to www.onehappycamper.org, sign in, and click the “Check Application Status” link. 
							    </p>

							    <asp:Label ID="Label6" runat="server" CssClass="lblPopup1">
							        <p style="text-align:justify">
								        Please note that your application has now been submitted and any changes or edits can only be made 
							            by a staff person from <%=strRenameOrganisation%> that you have selected.
							        </p>
							    </asp:Label>
             
							    <p style="text-align:justify">
								    If you have any questions or need to edit your application in any way, please contact the camp professional listed below.
							    </p>
						    </asp:Label>
							<asp:Label ID="lblContacrPersionSelected" runat="server" CssClass="QuestionText" /><br />
							<asp:Label ID="lblFedSelected" runat="server" CssClass="QuestionText" />
                            <asp:Label ID="lblDesignationSelected" runat="server" CssClass="QuestionText" /><br />
							<asp:Label ID="lblPhoneSelected" runat="server" CssClass="QuestionText" /><br />
							<a id="Email1Selected" runat="server" target="_blank">
							    <asp:Label ID="lblEmail1Selected" runat="server" CssClass="QuestionText" />
							</a>
                            <br /><br />
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
                    While it appears that your camper does not qualify for the program initially selected, he/she may still be eligible for one of our other One Happy Camper programs. 
				</p>
                <p>
                    <strong>While you may feel like you are filling out the same application – don’t give up.</strong> There are many different One Happy Camper programs – hopefully one will be right for you.
                </p>
				<p style="text-align:justify; font-weight:bold">
					<asp:LinkButton ID="lnkCopyApp" runat="server" CssClass="QuestionText" OnClick="lnkCopyApp_Click" Font-Size="12px">
                        Click Here</asp:LinkButton> to check your eligibility against our other One Happy Camper programs.

				</p>
                <ul style="list-style-type: none; display:none;">
                    <li>
                        PJ Library One Happy Camper (PJ Goes to Camp)
                        <br />
                        <span style="color:red; display:none;">Please note: the PJ Library One Happy Camper application is scheduled to launch in mid-November. <a href="http://www.pjlibrary.org/about-pj-library/pj-goes-to-camp.aspx" target="_blank">Click here</a> for more information</span>
                        <br /><br />
                    </li>
                    <li>Or a camp co-sponsored program</li>
                </ul>
			</asp:Label>
			<asp:Label ID="lblContactinfo" runat="server" CssClass="QuestionText">
				<p style="text-align:justify">
				    If you think you received this message in error please contact your local partner - information below – or contact your camp directly.
				</p>
            </asp:Label>
			<asp:Label ID="lblContactPerson2" runat="server" CssClass="QuestionText" /><br />
			<asp:Label ID="lblFed2" runat="server" CssClass="QuestionText" /><asp:Label ID="lblDesignation2" 
			runat="server" CssClass="QuestionText" /><br />
			<asp:Label ID="lblPhone2" runat="server" CssClass="QuestionText" /><br />
				<a id="Email2" runat="server" target="_blank">
			<asp:Label ID="lblEmail2" runat="server" CssClass="QuestionText" /></a>
		</asp:Panel>
				
		<asp:Panel ID="PanelInEligiblePJL" runat="server" Visible="false" Width="100%">
			<asp:Label ID="Label7" runat="server" CssClass="QuestionText">
				<p style="text-align:justify">
					Thank you for your interest in Jewish overnight summer camp! While it appears that the camper does not qualify for a community sponsored One Happy Camper grant, he/she could be eligible for one of our other programs.
				</p>
				<p style="text-align:justify; font-weight:bold">
					Please <asp:LinkButton ID="LinkButton1" runat="server" CssClass="QuestionText" 
					OnClick="lnkCopyApp_Click">click here</asp:LinkButton> to see if you are eligible for a different One Happy Camper program.</p></asp:Label>
			<asp:Label ID="Label8" runat="server" CssClass="QuestionText">
				<p style="text-align:justify">
				    If you think you received this message in error please contact your local partner - information below – or contact your camp directly.	
                </p>
					</asp:Label>
					<asp:Label ID="Label9" runat="server" CssClass="QuestionText" /><br />
					<asp:Label ID="Label10" runat="server" CssClass="QuestionText" /><br />
					<asp:Label ID="Label11" runat="server" CssClass="QuestionText" /><br />
					<asp:Label ID="Label12" runat="server" CssClass="QuestionText" /><br />
					<asp:Label ID="Label13" runat="server" CssClass="QuestionText" />
		</asp:Panel>
    
        <asp:Panel ID="pnlEligiblePendingNumberOfDays" CssClass="QuestionText" Visible="false" runat="server">
            <p style="text-align:justify">
                <b>Based on your answers, and pending further review by your One Happy Camper administrator, your camper may be eligible for an incentive grant.</b>
            </p>
            <p class="QuestionText" style="text-align:justify">
                Please note that if your camper meets all the eligibility requirements EXCEPT for the minimum session requirement, we will RESERVE a One Happy Camper incentive grant for your camper. Should your camper choose to extended his/her camp session to meet the 19+ day requirement, the camp will notify us of this extension. At that time, we will activate the grant towards your camper’s first-time Jewish overnight camp experience. If at a later date we find evidence of falsified information, we reserve the right to rescind this award.
            </p>
			<p style="text-align:justify;">
				<span style="color:red; font-weight:bold;">Your application has now been submitted and any changes or edits can only be made by your One Happy Camper administrator.</span>
                <br />
                <br />
                <u>Your One Happy Camper administrator is:</u><br />
				<asp:Label ID="lblContactPerson3" runat="server" /><br />
				<asp:Label ID="lblFed3" runat="server" /><br />
				<asp:Label ID="lblPhone3" runat="server" /><br />
				<a id="Email3" runat="server" target="_blank">
					<asp:Label ID="lblEmail3" runat="server"></asp:Label>
				</a>
			</p>
            <p style="color:red; font-weight:bold;">
                PLEASE NOTE: If the camper’s acceptance at camp has not yet been confirmed, be in touch with your camp directly to make certain that the camper has a spot at camp this summer. Incentive grants will only be disbursed (to the camp) after the camper’s attendance at camp has been confirmed.
            </p>
        </asp:Panel>

    </div>

    <div class="QuestionText">
        <br />
        <a href="../CamperOptions.aspx">Click here</a> to create another application
    </div>
	
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
    <script type="text/javascript" src="https://www.googleadservices.com/pagead/conversion.js"></script>
    <noscript>
        <div style="display:inline;">
        <img height="1" width="1" style="border-style:none;" alt="" src="https://www.googleadservices.com/pagead/conversion/1033664268/?label=eKd3CJymqgEQjO7x7AM&amp;guid=ON&amp;script=0"/>
        </div>
    </noscript>
</asp:Content>

