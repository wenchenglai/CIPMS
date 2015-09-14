<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Step2_1.aspx.cs" Inherits="Step2_1" Title="Camper Enrollment Step 2" %>

<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="ContentStep2_CN_1" ContentPlaceHolderID="Content" runat="Server">
    <script type="text/javascript" src="Step2_1.js"></script>
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="Label4" CssClass="headertext" runat="server">Section V:  How Did You Hear About One Happy Camper & Jewish Camp</asp:Label><br />
                <br />
            </td>
        </tr>
    </table>

    <div>
        <asp:CustomValidator ID="CusVal" runat="server" ClientValidationFunction="HowDidYouHearUsValidator.OnSubmitClick" Display="Dynamic" CssClass="InfoText" />
        <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
        <asp:CustomValidator ID="CusValComments" runat="server" Display="Dynamic" CssClass="InfoText" ErrorMessage="<li>Please enter the Comments</li>" EnableClientScript="false" />
    </div>

    <table width="100%" cellpadding="10" cellspacing="0" border="0">
        <tr>
			<td style"width:40px" valign="top" >
                <asp:Label ID="Label3" runat="server" Text="<span style='color:red;'>*</span>1" CssClass="QuestionText"></asp:Label>				
			</td>
			<td>
				<span class="QuestionText">At approximately what point in the year did you begin considering overnight camp?</span>
				<div>
					<asp:DropDownList ID="ddlWhatYear" runat="server">
						<asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>
						<asp:ListItem Text="Before this past summer (prior to June 2015)" Value="1"></asp:ListItem>
						<asp:ListItem Text="Last Summer (Jun - Aug of 2015)" Value="2"></asp:ListItem>
						<asp:ListItem Text="This past Fall (Sep - Dec 2015)" Value="3"></asp:ListItem>
						<asp:ListItem Text="This past Winter (Jan - Mar 2016)" Value="4"></asp:ListItem>
						<asp:ListItem Text="This Spring (Apr - May 2016)" Value="5"></asp:ListItem>
						<asp:ListItem Text="This Summer (Jun - Aug 2016)" Value="6"></asp:ListItem>
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
					<asp:DropDownList ID="ddlStaffNames" runat="server" onChange="HowDidYouHearUsValidator.OnMemberDropDownChange(this);" >
						<asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>							
						<asp:ListItem Text="Larry Katz" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Samantha Tanenbaum" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Claire Wintrop" Value="5"></asp:ListItem>
						<asp:ListItem Text="Rochelle Baltuch" Value="6"></asp:ListItem>
						<asp:ListItem Text="Judy Shapiro" Value="7"></asp:ListItem>
                        <asp:ListItem Text="Judith Stander" Value="8"></asp:ListItem>
						<asp:ListItem Text="Rachel White" Value="9"></asp:ListItem>							
						<asp:ListItem Text="Helen Wolf" Value="10"></asp:ListItem>													
						<asp:ListItem Text="Hannah Mendelsohn" Value="11"></asp:ListItem>
						<asp:ListItem Text="Dirk Bird" Value="12"></asp:ListItem>
						<asp:ListItem Text="Alyssa Russell" Value="13"></asp:ListItem>	
						<asp:ListItem Text="Steffanie Jackson" Value="14"></asp:ListItem>	
						<asp:ListItem Text="Sue Bendalin" Value="15"></asp:ListItem>		
						<asp:ListItem Text="Tracy Levine" Value="16"></asp:ListItem>                                                																		
						<asp:ListItem Text="Carrie Berman" Value="17"></asp:ListItem>
                        <asp:ListItem Text="Sheree Boone" Value="18"></asp:ListItem>
						<asp:ListItem Text="Renee Lovitt" Value="19"></asp:ListItem>							
                        <asp:ListItem Text="Inna Kolesnikova-Shmukler" Value="20"></asp:ListItem>
						<asp:ListItem Text="Rebecca Weiner" Value="21"></asp:ListItem>													
						<asp:ListItem Text="Sarah Klein Wagner" Value="22"></asp:ListItem>
						<asp:ListItem Text="Ellen Weismar" Value="23"></asp:ListItem>	
						<asp:ListItem Text="Jake Velleman" Value="24"></asp:ListItem>
						<asp:ListItem Text="Gabrielle Abergel" Value="25"></asp:ListItem>	
						<asp:ListItem Text="Harriet Schiftan" Value="26"></asp:ListItem>								
                        <asp:ListItem Text="Nancy Frankel" Value="27"></asp:ListItem>
                        <asp:ListItem Text="Melissa Levine" Value="28"></asp:ListItem>	
                        <asp:ListItem Text="Warren Hoffman " Value="29"></asp:ListItem>	
                        <asp:ListItem Text="Sally Stein " Value="30"></asp:ListItem>	
                        <asp:ListItem Text="Rachel Halupowski" Value="31"></asp:ListItem>
                        <asp:ListItem Text="Sharon Gray" Value="32"></asp:ListItem>	
                        <asp:ListItem Text="Lisa Pavlovsky" Value="33"></asp:ListItem>	
                        <asp:ListItem Text="Brenda Silvers" Value="34"></asp:ListItem>	
                        <asp:ListItem Text="Beth Koritz" Value="35"></asp:ListItem>
                        <asp:ListItem Text="Ricci Postan " Value="36"></asp:ListItem>	
						<asp:ListItem Text="Don't know/Not sure" Value="2"></asp:ListItem>																																										
						<asp:ListItem Text="Other" Value="1"></asp:ListItem>							
					</asp:DropDownList>
					<asp:TextBox ID="txtOtherName" runat="server"></asp:TextBox>
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
							<asp:CheckBox ID="chk22" runat="server" Text="A Jewish publication" onclick="HowDidYouHearUsValidator.OnPubName(this);" />
						</li>
						<li>
							<asp:CheckBox ID="chk23" runat="server" Text="A parenting publication" onclick="HowDidYouHearUsValidator.OnPubName(this);" />
						</li>		
						<li>
							<asp:CheckBox ID="chk24" runat="server" Text="Your local newspapers" onclick="HowDidYouHearUsValidator.OnPubName(this);" />
						</li>	
						<li>
							<asp:CheckBox ID="chk25" runat="server" Text="Facebook ad" />
						</li>	
						<li>
							<asp:CheckBox ID="chk26" runat="server" Text="Online ad (not Facebook)" onclick="HowDidYouHearUsValidator.OnPubName(this);" />
						</li>	
						<li>
							<asp:CheckBox ID="chk27" runat="server" Text="Poster in public space (e.g. coffee shop, grocery store)" onclick="HowDidYouHearUsValidator.OnPubName(this);" />
						</li>	
						<li>
							<asp:CheckBox ID="chk28" runat="server" onclick="HowDidYouHearUsValidator.On3bOther(this);" Text="Other" />
						</li>
                        <li id="liPubName">
                            Do you remember the name of the publication/location of the ad? <asp:TextBox runat="server" ID="txtPubName"></asp:TextBox>
                        </li>
                        <li id="liOtherAd">
                            Other Ad: <asp:TextBox runat="server" ID="txtOtherAd"></asp:TextBox>
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
                                Text="Exit To Camper Summary" CssClass="submitbtn1" /></td>
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
