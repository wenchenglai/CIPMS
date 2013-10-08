<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_NJY_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
     <table width="100%" cellpadding="5" cellspacing="0">      
        <tr>
            <td colspan="2">
				<asp:Panel ID="PnlCampNah" runat="server" CssClass="QuestionText" Visible="false">
					<table width="100%" cellpadding="5" cellspacing="0">
						<tr>
							<td>
								<img id="Img3" src="../../images/NahJeeWah1.jpg" alt="" height="100" width="150" />
							</td>
							<td>
								<asp:Label ID="Label14" CssClass="SummaryHeading" runat="server">
									<p style="text-align:justify" class="lblPopup1">
										Great news!  The Foundation for Jewish Camp, in partnership with NJY Camps offers an incentive program that is open to campers who live anywhere in United States, Canada and Mexico!
									</p>
								</asp:Label>
							</td>
						</tr>
						<tr>
							<td colspan="2">
								<asp:Label ID="Label16" runat="server" CssClass="infotext3">
									<p style="text-align:justify">
										Integrating Jewish culture into a fun and active experience, camp Nah-Jee-Wah (NJW), along with Cedar Lake Camp (CLC), and Teen Camp (TAC) 
										are located on over 1250 acres in the Pocono Mountains in Milford, PA.  Camp facilities include 2 Olympic-sized pools and private lakes with 
										complete waterfront equipment, athletic facilities for baseball, soccer, basketball, hockey, lacrosse and skating, high and low rope courses, 
										2 zip lines and mountain bike trails.  All camps offer arts and crafts including ceramics and pottery wheels, woodshop, painting, photography, 
										jewelry-making, as well as advanced science programs in physics, astronomy, kinesiology, chemistry, biology and rocketry.  Teen Campers work 
										with local community service agencies and receive leadership training (multiple certifications available). Teen Campers also enjoy opportunities 
										to travel to Costa Rica, New Orleans, and Israel.
									</p>
									<p style="text-align:justify">
										<b>NJY Camps is offering this incentive program for Camp Nah-Jee-Wah (entering - 1st – 6th grade), Cedar Lake Camp (entering - 7th through 9th grade), 
										Teen Camp (entering - 10th grade), and Round Lake Camp. The One Happy Camper program is for Jewish campers who attend one of our non-profit Jewish 
										overnight summer camps for at least 3 consecutive weeks.</b>
									</p>
								</asp:Label>
							</td>
						</tr>       
						<tr>
							<td colspan="2">
								<asp:Label ID="Label17" runat="server" CssClass="infotext3">
									<p style="text-align:justify;color:Red">
										If you are currently enrolled in Jewish day school or yeshiva, please contact New Jersey Y Camps directly to learn about incentive grant opportunities.  Please do not proceed with this application.
									</p>
								</asp:Label>
							</td>
						</tr>
						<tr>
							<td colspan="2">
								<asp:Label ID="Label18" runat="server" CssClass="QuestionText">
									<p style="text-align:justify">If you need additional assistance, please call the camp professional listed at the bottom of this page.</p>
								</asp:Label></td>
						</tr>
					</table>
				</asp:Panel>
				<asp:Panel ID="PnlCedar" runat="server" CssClass="QuestionText" Visible="false">
					<table width="100%" cellpadding="5" cellspacing="0">
						<tr>
							<td>
								<img id="Img1" src="../../images/CedarLake.jpg" alt="" height="100" width="150" /></td>
							<td>
								<asp:Label ID="Label3" CssClass="SummaryHeading" runat="server">
									<p style="text-align:justify" class="lblPopup1">Great news!  The Foundation for Jewish Camp, in partnership with NJY Camps offers an incentive program that is open to campers who live anywhere in United States, Canada and Mexico!</p></asp:Label>
								<asp:Label ID="Label4" runat="server" CssClass="infotext3">
								   </asp:Label>
							</td>
						</tr>
						<tr>
							<td colspan="2">
								<asp:Label ID="Label5" runat="server" CssClass="infotext3">
									<p style="text-align:justify">
										Integrating Jewish culture into a fun and active experience, Cedar Lake Camp (CLC), along with Camp Nah-Jee-Wah (NJW), and Teen Camp (TAC) are located on over 1250 acres in the Pocono Mountains in Milford, PA.  Camp facilities include 2 Olympic-sized pools and private lakes with complete waterfront equipment, athletic facilities for baseball, soccer, basketball, hockey, lacrosse and skating, high and low rope courses, 2 zip lines and mountain bike trails.  All camps offer arts and crafts including ceramics and pottery wheels, woodshop, painting, photography, jewelry-making, as well as advanced science programs in physics, astronomy, kinesiology, chemistry, biology and rocketry.  Teen Campers work with local community service agencies and receive leadership training (multiple certifications available). Teen Campers also enjoy opportunities to travel to Costa Rica, New Orleans, and Israel.
									</p>
									<p style="text-align:justify"><b>NJY Camps is offering this incentive program for Camp Nah-Jee-Wah (entering - 1st – 6th grade), Cedar Lake Camp (entering - 7th through 9th grade), Teen Camp (entering - 10th grade), and Round Lake Camp. The One Happy Camper program is for Jewish campers who attend one of our non-profit Jewish overnight summer camps for at least 3 consecutive weeks.</b></p>
								</asp:Label>
							</td>
						</tr>				        
						<tr>
							<td colspan="2">
								<asp:Label ID="Label6" runat="server" CssClass="infotext3">
									<p style="text-align:justify;color:Red">
										If you are currently enrolled in Jewish day school or yeshiva, please contact New Jersey Y Camps directly to learn about incentive grant opportunities.  Please do not proceed with this application.
									</p>
								</asp:Label>
							</td>
						</tr>
						<tr>
							<td colspan="2">
								<asp:Label ID="Label7" runat="server" CssClass="QuestionText">
									<p style="text-align:justify">If you need additional assistance, please call the camp professional listed at the bottom of this page.</p>
								</asp:Label>
							</td>
						</tr>
					</table>
				</asp:Panel>
				<asp:Panel ID="PnlTeen" runat="server" CssClass="QuestionText" Visible="false">
					<table width="100%" cellpadding="5" cellspacing="0">
						<tr>
							<td>
								<img id="Img2" src="../../images/TeenCamp.jpg" alt="" height="100" width="150" /></td>
							<td>
								<asp:Label ID="Label8" CssClass="SummaryHeading" runat="server">
									<p style="text-align:justify" class="lblPopup1">
										Great news!  The Foundation for Jewish Camp, in partnership with NJY Camps offers an incentive program that is open to campers who live anywhere in United States, Canada and Mexico!
									</p>
								</asp:Label>
								<asp:Label ID="Label9" runat="server" CssClass="infotext3">
								   </asp:Label>
							</td>
						</tr>
						<tr>
							<td colspan="2">
								<asp:Label ID="Label10" runat="server" CssClass="infotext3">
									<p style="text-align:justify">
				Integrating Jewish culture into a fun and active experience, Teen Camp (TAC) along with Cedar Lake Camp (CLC), and Camp Nah-Jee-Wah (NJW) are located on over 1250 acres in the Pocono Mountains in Milford, PA.  Camp facilities include 2 Olympic-sized pools and private lakes with complete waterfront equipment, athletic facilities for baseball, soccer, basketball, hockey, lacrosse and skating, high and low rope courses, 2 zip lines and mountain bike trails.  All camps offer arts and crafts including ceramics and pottery wheels, woodshop, painting, photography, jewelry-making, as well as advanced science programs in physics, astronomy, kinesiology, chemistry, biology and rocketry.  Teen Campers work with local community service agencies and receive leadership training (multiple certifications available). Teen Campers also enjoy opportunities to travel to Costa Rica, New Orleans, and Israel.                    </p>
									<p style="text-align:justify"><b>NJY Camps is offering this incentive program for Camp Nah-Jee-Wah (entering - 1st – 6th grade), Cedar Lake Camp (entering - 7th through 9th grade), Teen Camp (entering - 10th grade), and Round Lake Camp. The One Happy Camper program is for Jewish campers who attend one of our non-profit Jewish overnight summer camps for at least 3 consecutive weeks.</b></p>
								</asp:Label>
							</td>
						</tr>
				        
						<tr>
							<td colspan="2">
								<asp:Label ID="Label11" runat="server" CssClass="infotext3">
									<p style="text-align:justify;color:Red">
										If you are currently enrolled in Jewish day school or yeshiva, please contact New Jersey Y Camps directly to learn about incentive grant opportunities.  Please do not proceed with this application.
									</p>
								</asp:Label>
							</td>
						</tr>
						<tr>
							<td colspan="2">
								<asp:Label ID="Label13" runat="server" CssClass="QuestionText">
									<p style="text-align:justify">If you need additional assistance, please call the camp professional listed at the bottom of this page.</p>
								</asp:Label></td>
						</tr>
					</table>
				</asp:Panel>
				<asp:Panel ID="PnlRoundLake" runat="server" CssClass="QuestionText" Visible="false">
					<table width="100%" cellpadding="5" cellspacing="0">
						<tr>
							<td>
								<img id="logo" src="../../images/RoundLakeCamp.jpg" alt="" height="100" width="150" /></td>
							<td>
								<asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
									<p style="text-align:justify" class="lblPopup1">Great news!  The Foundation for Jewish Camp, in partnership with NJY Camps offers an incentive program that is open to campers who live anywhere in United States, Canada and Mexico!</p></asp:Label>
								<asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
								   </asp:Label>
							</td>
						</tr>
						<tr>
							<td colspan="2">
								<asp:Label ID="lblLable2" runat="server" CssClass="infotext3">
									<p style="text-align:justify">
										Round Lake Camp, a unique coed residential summer camp for children with learning differences and social communication disorders.  Programs are planned to meet the capabilities of each child.  Educational activities are combined with recreation and socialization.  Facilities include a 40- acre natural spring fed lake, perfect for swimming and boating.  Campers also enjoy performing and fine arts.
									</p>
								</asp:Label>
							</td>
						</tr>
						<tr>
							<td colspan="2">
								<asp:Label ID="Label1" CssClass="infotext3" runat="server">
								<p style="text-align:justify"><b>NJY Camps is offering this incentive program for Camp Nah-Jee-Wah (entering - 1st – 6th grade), Cedar Lake Camp (entering - 7th through 9th grade), Teen Camp (entering - 10th grade), and Round Lake Camp. The One Happy Camper program is for Jewish campers who attend one of our non-profit Jewish overnight summer camps for at least 3 consecutive weeks.
								 </b></p>
								</asp:Label>
							 </td>
						</tr>
						<tr>
							<td colspan="2">
								<asp:Label ID="lblLable3" runat="server" CssClass="infotext3">
									<p style="text-align:justify;color:Red">
										If you are currently enrolled in Jewish day school or yeshiva, please contact New Jersey Y Camps directly to learn about incentive grant opportunities.  Please do not proceed with this application.
									</p>
								</asp:Label>
							</td>
						</tr>
						<tr>
							<td colspan="2">
								<asp:Label ID="Label2" runat="server" CssClass="QuestionText">
									<p style="text-align:justify">If you need additional assistance, please call the camp professional listed at the bottom of this page.</p>
								</asp:Label></td>
						</tr>
					</table>
				</asp:Panel>
				<asp:Panel ID="pnlShowContactInfo" runat="server" CssClass="QuestionText" Visible="false">
					<table>
						<tr>
							<td>
								<asp:Label ID="Label15" CssClass="infotext3" runat="server">
									<p style="text-align:justify"><b>							
										Thank you for your interest in the New Jersey Y Camps One Happy Camper Program.  
										For more information on how to apply, please contact Janet Fligelman
										at <a href="mailto:janet@njycamps.org">janet@njycamps.org</a> or (973) 575-3333 x121.
										</b>
									</p>
								</asp:Label>									
							</td>
						</tr>
					</table>					
				</asp:Panel>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">            
            <tr>
                <td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" ><br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                            <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                                </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" /></td>
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>
</asp:Content>

