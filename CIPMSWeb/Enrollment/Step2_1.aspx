<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true"
    CodeFile="Step2_1.aspx.cs" Inherits="Step2_1" Title="Camper Enrollment Step 2" %>

<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_CN_1" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="Label4" CssClass="headertext" runat="server">Section V:  How Did You Hear About One Happy Camper & Jewish Camp</asp:Label><br />
                <br />
            </td>
        </tr>
    </table>
    <!--Panel 1 - Questions displayed on page 1 of Step 2-->
    <asp:Panel ID="Panel1" runat="server">
        <!--to display the validation summary (error messages)-->
        <table width="75%" cellpadding="0" cellspacing="0" border="0" align="center">
            <tr>
                <td>
                    <asp:CustomValidator ID="CusVal" runat="server" ClientValidationFunction="ValidateHowDidYouHearUsPage"
                        Display="Dynamic" CssClass="InfoText"></asp:CustomValidator>
                    <!--this summary will be used only for Comments field (only for Admin user)-->
                    <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server"
                        ShowSummary="true" CssClass="InfoText" />
                    <asp:CustomValidator ID="CusValComments" runat="server" Display="Dynamic" CssClass="InfoText"
                        ErrorMessage="<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
                </td>
            </tr>
        </table>
        <table width="100%" cellpadding="10" cellspacing="0" border="0">
            <tr style="display: none;">
                <td valign="top" style="padding-top: 5px;">
                    <asp:Label ID="Label5" Text="*" runat="server" CssClass="InfoText" />
                    <asp:Label ID="lbl" runat="server" Text="1" CssClass="QuestionText"></asp:Label>
                </td>
                <td valign="top">
                    <asp:Label ID="Label1" runat="server" CssClass="QuestionText">How Did You Hear About One Happy Camper and Jewish Camp?</asp:Label>
                    <div id="divQ1">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk1" Text="Word of Mouth" CssClass="QuestionText" runat="server" /></td>
                                <td>
                                    <asp:TextBox ID="txt1" runat="server" Text="How did you hear about it?" CssClass="txtbox" /></td>
                            </tr>
                            <tr>
                                <td height="1">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk2" Text="Jewish Organization (i.e. Synagogue, &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Federation, Jewish&nbsp;Community&nbsp;Center)"
                                        CssClass="QuestionText" runat="server" /><br />
                                </td>
                                <td>
                                    <asp:TextBox ID="txt2" runat="server" Text="Which organization, city, state?" CssClass="txtbox" /></td>
                            </tr>
                            <tr>
                                <td height="1">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk3" Text="Website/received email" CssClass="QuestionText" runat="server" /></td>
                                <td>
                                    <asp:TextBox ID="txt3" runat="server" Text="Which website/Email from whom?" CssClass="txtbox" /></td>
                            </tr>
                            <!-- TV: 10/2009 - added new question chk7 abd txt7 -->
                            <tr>
                                <td height="1">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk7" Text="Print advertisement" CssClass="QuestionText" runat="server" /></td>
                                <td>
                                    <asp:TextBox ID="txt7" runat="server" Text="Which publication?" CssClass="txtbox" /></td>
                            </tr>
                            <tr>
                                <td height="1">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk4" Text="Brochure/flyer/poster" CssClass="QuestionText" runat="server" /></td>
                                <td>
                                    <asp:TextBox ID="txt4" runat="server" Text="From where?" CssClass="txtbox" /></td>
                            </tr>
                            <tr>
                                <td height="1">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk5" Text="Camp" CssClass="QuestionText" runat="server" /></td>
                                <td>
                                    <asp:TextBox ID="txt5" runat="server" Text="Which camp?" CssClass="txtbox" /></td>
                            </tr>
                            <tr>
                                <td height="1">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk8" Text="Radio" CssClass="QuestionText" runat="server" /></td>
                                <td>
                                    <asp:TextBox ID="txt8" runat="server" Text="What station?" CssClass="txtbox" /></td>
                            </tr>
                            <tr>
                                <td height="1">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk9" Text="TV" CssClass="QuestionText" runat="server" /></td>
                                <td>
                                    <asp:TextBox ID="txt9" runat="server" Text="What station?" CssClass="txtbox" /></td>
                            </tr>
                            <asp:panel ID="pnlHanukkah" runat="server">
                             <tr>
                                <td height="1">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk15" Text="Hanukkah Workbook" CssClass="QuestionText" runat="server" /></td>
                            </tr>
                            </asp:panel>
                            <tr>
                                <td height="1">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk10" Text="Facebook ad" CssClass="QuestionText" runat="server" /></td>
                            </tr>
                            <tr>
                                <td height="1">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk11" Text="Google" CssClass="QuestionText" runat="server" /></td>
                            </tr>
                            <tr>
                                <td height="1">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk12" Text="Yahoo" CssClass="QuestionText" runat="server" /></td>
                            </tr>
                            <tr>
                                <td height="1">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk13" Text="Bing" CssClass="QuestionText" runat="server" /></td>
                            </tr>
                            <tr>
                                <td height="1">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk14" Text="Twitter" CssClass="QuestionText" runat="server" /></td>
                            </tr>
                            <tr>
                                <td height="1">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk6" Text="Other" CssClass="QuestionText" runat="server" /></td>
                                <td>
                                    <asp:TextBox ID="txt6" runat="server" Text="Please specify" CssClass="txtbox" /></td>
                            </tr>
                        </table>
                    </div>
                    <br />
                </td>
            </tr>
            <tr>
				<td style"width:40px" valign="top" >
                    <asp:Label ID="Label3" runat="server" Text="<span style='color:red;'>*</span>1" CssClass="QuestionText"></asp:Label>				
				</td>
				<td>
					<span class="QuestionText">At approximately what point in the year did you begin considering overnight camp?</span>
					<div>
						<asp:DropDownList ID="ddlWhatYear" runat="server">
							<asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>
							<asp:ListItem Text="Before this past summer (prior to June 2012)" Value="1"></asp:ListItem>
							<asp:ListItem Text="Last Summer (Jun - Aug of 2012)" Value="2"></asp:ListItem>
							<asp:ListItem Text="This past Fall (Sep - Dec 2012)" Value="3"></asp:ListItem>
							<asp:ListItem Text="This past Winter (Jan Mar 2013)" Value="4"></asp:ListItem>
							<asp:ListItem Text="This Spring (Apr - May 2013)" Value="5"></asp:ListItem>
							<asp:ListItem Text="This Summer (Jun Aug 2013)" Value="6"></asp:ListItem>
							<asp:ListItem Text="Don't know/Not sure" Value="7"></asp:ListItem>																																										
						</asp:DropDownList>
					</div>
				</td>
            </tr>
            <tr>
				<td valign="top">
                    <asp:Label ID="Label7" runat="server" Text="<span style='color:red;'>*</span>2" CssClass="QuestionText"></asp:Label>				
				</td>
				<td>
					<span class="QuestionText">How did you start your search for information regarding Jewish overnight camp?</span>
					<div>
						<asp:DropDownList ID="ddlResearch" runat="server">
							<asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>						
							<asp:ListItem Text="Contacted a Jewish camp recruiter (Jewish camp lady)" Value="1"></asp:ListItem>
							<asp:ListItem Text="Contacted a secular camp recruiter/referral agency (camp lady)" Value="2"></asp:ListItem>
							<asp:ListItem Text="Contacted camps directly (website, email, phone, etc.)" Value="3"></asp:ListItem>
							<asp:ListItem Text="Did a general web search" Value="4"></asp:ListItem>
							<asp:ListItem Text="Contacted the camp that a family member attended" Value="5"></asp:ListItem>
							<asp:ListItem Text="Contacted a synagogue" Value="6"></asp:ListItem>
							<asp:ListItem Text="Recommendation from family and/or friends" Value="7"></asp:ListItem>							
							<asp:ListItem Text="Don't know/Not sure" Value="8"></asp:ListItem>																																										
						</asp:DropDownList>
					</div>
				</td>
            </tr>    
            <tr>
				<td valign="top">
                    <asp:Label ID="Label9" runat="server" Text="<span style='color:red;'>*</span>3" CssClass="QuestionText"></asp:Label>				
				</td>
				<td>
					<span class="QuestionText">How did you hear about the One Happy Camper incentive program? Check all that apply.</span>
					<div>
						<ul style="list-style-type: none;" class="QuestionText">
							<li>
								<asp:CheckBox ID="chkStaff1" runat="server" AutoPostBack="true" 
									Text="Jewish Federation/agency staff member or communication (i.e. e-mail)" 
									oncheckedchanged="chkStaff_CheckedChanged" />
							</li>
							<li>
								<asp:CheckBox ID="chkStaff2" runat="server" Text="Jewish camp recruiter" AutoPostBack="true"
									oncheckedchanged="chkStaff_CheckedChanged" />
							</li>		
							<li>
								<asp:CheckBox ID="chkStaff3" runat="server" AutoPostBack="true" 
									Text="Jewish Community Center (JCC) staff member" 
									oncheckedchanged="chkStaff_CheckedChanged" />
							</li>	
							<li>
								<asp:CheckBox ID="chk16" runat="server" Text="Someone within your temple/synagogue" />
							</li>	
							<li>
								<asp:CheckBox ID="chk17" runat="server" Text="PJ Library" />
							</li>	
							<li>
								<asp:CheckBox ID="chk18" runat="server" Text="Another child in our family previously received a grant" />
							</li>	
							<li>
								<asp:CheckBox ID="chk19" runat="server" Text="Friend or family" />
							</li>	
							<li>
								<asp:CheckBox ID="chk20" runat="server" Text="Directly from a camp" />
							</li>	
							<li>
								<asp:CheckBox ID="chkHearFromAd" runat="server" AutoPostBack="true" 
									Text="Directly from an ad, news article, media, or Facebook" 
									oncheckedchanged="chkHearFromAd_CheckedChanged" />
							</li>	
							<li>
								<asp:CheckBox ID="chk21" runat="server" Text="Other/Don't remember" />
							</li>																																																													
						</ul>											
					</div>
				</td>
            </tr> 
            <tr id="trNames" runat="server" visible="false">
				<td valign="top">
                    <asp:Label ID="Label11" runat="server" Text="<span style='color:red;'>*</span>3a" CssClass="QuestionText"></asp:Label>				
				</td>
				<td>
					<span class="QuestionText">Can you remember who that was?</span>
					<div>
						<asp:DropDownList ID="ddlStaffNames" runat="server" AutoPostBack="true" 
							onselectedindexchanged="ddlStaffNames_SelectedIndexChanged">
							<asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>							
							<asp:ListItem Text="Dirk Bird" Value="1"></asp:ListItem>
							<asp:ListItem Text="Nancy Frankel" Value="2"></asp:ListItem>
							<asp:ListItem Text="Sam Friedman" Value="3"></asp:ListItem>
							<asp:ListItem Text="Larry Katz" Value="4"></asp:ListItem>							
							<asp:ListItem Text="Veronica Klein" Value="4"></asp:ListItem>
							<asp:ListItem Text="Beth Koritz" Value="4"></asp:ListItem>		
							<asp:ListItem Text="Francine Koszer" Value="4"></asp:ListItem>												
							<asp:ListItem Text="Tracy Levine" Value="5"></asp:ListItem>
							<asp:ListItem Text="Roberta Matz" Value="4"></asp:ListItem>	
							<asp:ListItem Text="Hannah Mendelsohn" Value="4"></asp:ListItem>	
							<asp:ListItem Text="Lisa Pavlovsky" Value="4"></asp:ListItem>																			
							<asp:ListItem Text="Alyssa Russell" Value="6"></asp:ListItem>
							<asp:ListItem Text="Judy Shapiro" Value="4"></asp:ListItem>							
							<asp:ListItem Text="Brenda Silvers" Value="7"></asp:ListItem>
							<asp:ListItem Text="Eddie Simon" Value="4"></asp:ListItem>														
							<asp:ListItem Text="Sally Stein" Value="8"></asp:ListItem>
							<asp:ListItem Text="Natasha Vojdany" Value="9"></asp:ListItem>
							<asp:ListItem Text="Rachel Wolf" Value="10"></asp:ListItem>								
							<asp:ListItem Text="Don't know/Not sure" Value="11"></asp:ListItem>																																										
							<asp:ListItem Text="Other" Value="12"></asp:ListItem>							
						</asp:DropDownList>
						<asp:TextBox ID="txtOtherName" runat="server" Visible="false"></asp:TextBox>
					</div>
				</td>
            </tr>
            <tr id="trAds" runat="server" visible="false">
				<td valign="top">
                    <asp:Label ID="Label14" runat="server" Text="<span style='color:red;'>*</span>3b" CssClass="QuestionText"></asp:Label>				
				</td>
				<td>
					<span class="QuestionText">What kind of 'ad'? Check all that apply.</span>
					<div>
						<ul style="list-style-type: none;" class="QuestionText">
							<li>
								<asp:CheckBox ID="chk22" runat="server" Text="A Jewish publication" />
							</li>
							<li>
								<asp:CheckBox ID="chk23" runat="server" Text="A parenting publication" />
							</li>		
							<li>
								<asp:CheckBox ID="chk24" runat="server" Text="Your local newspapers" />
							</li>	
							<li>
								<asp:CheckBox ID="chk25" runat="server" Text="Facebook ad" />
							</li>	
							<li>
								<asp:CheckBox ID="chk26" runat="server" Text="Online ad (not Facebook)" />
							</li>	
							<li>
								<asp:CheckBox ID="chk27" runat="server" Text="Poster in public space (e.g. coffee shop, grocery store)" />
							</li>	
							<li>
								<asp:CheckBox ID="chk28" runat="server" Text="Other" />
							</li>																																																													
						</ul>											
					</div>
				</td>
            </tr>                                            
            <!--admin panel-->
            <tr>
                <td colspan="2" align="center">
                    <asp:Panel ID="PnlAdmin" runat="server" Visible="false" CssClass="PnlAdmin">
                        <table width="90%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td width="35%">
                                    <asp:Label ID="Label21" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label
                                        ID="Label20" CssClass="text" runat="server" Text="Comments"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtComments" runat="server" CssClass="txtbox2" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:CustomValidator ID="CusValComments1" ValidationGroup="CommentsGroup" runat="server"
                        Display="None" CssClass="InfoText" ErrorMessage="<li>Please enter the Comments</li>"
                        EnableClientScript="false"></asp:CustomValidator>
                </td>
            </tr>
            <!--end of admin panel-->
            <tr>
                <td valign="top" width="5%">
                    <asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2">
                    <br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td align="left">
                                <asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server"
                                    Text="<<Exit To Camper Summary" CssClass="submitbtn1" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" ValidationGroup="CommentsGroup" runat="server" Text=" << Previous"
                                    CssClass="submitbtn" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnSaveandExit" ValidationGroup="CommentsGroup" runat="server" Text="Save & Continue Later"
                                    CssClass="submitbtn1" />
                            </td>
                            <td align="center">
                                <asp:Button ID="btnNext" runat="server" Text="Next >>" CssClass="submitbtn" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <!--End of Panel 1 -->
    <input type="hidden" runat="server" id="hdnQ1Id" value="1" />
    <input type="hidden" runat="server" id="hdnQ1035WhenToConsider" value="1035" />
    <input type="hidden" runat="server" id="hdnQ1036Research" value="1036" />
    <input type="hidden" runat="server" id="hdnQ1037HowDidYouHearUs" value="1037" /> 
    <input type="hidden" runat="server" id="hdnQ1038HowDidYouHearUSA" value="1038" />
    <input type="hidden" runat="server" id="hdnQ1038HowDidYouHearUSB" value="1039" />                
    <!-- TV: 10/2009 - removed Marketing Referral Code question 
    <input type="hidden" runat="server" id="hdnQ2Id" value="2" />
    -->
    <asp:HiddenField ID="hdnFJCIDStep2_1" runat="server" />
    <!--Previous next buttons-->

    <script type="text/javascript">
        function windowopen()
        {
            //alert(document.getElementById("ctl00_Content_RadioButtonQ8_0").getAttribute("value").value);
            window.open("../CampSearch.aspx",'test')
        }
        
        
    </script>

</asp:Content>
