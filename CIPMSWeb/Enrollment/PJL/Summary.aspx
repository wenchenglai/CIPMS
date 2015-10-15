<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Washington_Summary" %>

<asp:Content ID="Washington_Summary" ContentPlaceHolderID="Content" runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
	            <img id="Img1" src="../../images/PJlogo.jpg" width="300" onclick="return Img1_onclick()" />
            </td>
            <td>
                <p>Good news! You may be eligible for a PJ Goes to Camp grant.</p>
			    <p>To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.</p>
            </td>
        </tr>
        <tr>
			<td colspan="2">
			    <p>
			        The Foundation for Jewish Camp, in partnership with the PJ Library Program, brings PJ Goes to Camp, a funding partner of FJC’s One Happy Camper program, to first-time campers who live anywhere in North America. PJ Goes to Camp offers One Happy Camper incentive grants of up to $1,000 to offset camp tuition for PJ Library participants, siblings, and alumni. 
			    </p>
				<p>
                    A total of 350 GRANTS are available on a first-come, first-serve basis through PJ Goes to Camp. These grants of up to $1,000 will help subscribing families of The <a href="http://www.pjlibrary.org" target="_blank">PJ Library</a> to pay for summer camp tuition for first-time campers at nonprofit Jewish overnight camps.
				</p>                
				<p>
				    <span style="font-weight: bold; color:red;">ATTENTION JEWISH DAY SCHOOL FAMILIES:</span> 
                    All PJ Goes To Camp Incentive Grants for students currently enrolled in day school for the summer of 2016 will be distributed through a lottery that will take place on November 10, 2015. To place your name in this lottery you MUST be a PJ Library recipient family (or alumnus) prior to September 1, 2015. To apply for the PJ Library day school lottery referral code, complete an application at: 
                    <a href="http://www.pjlibrary.org/pjgtc/referralcode" target="_blank">www.pjlibrary.org/pjgtc/referralcode</a> AFTER August 15, 2015 but prior to November 8, 2015 to pjgtc@hgf.org. See 
                    <a href="http://www.pjlibrary.org/pjgtc" target="_blank">www.pjlibrary.org/pjgtc</a> for full details and eligibility.
				</p>
                <p>
                    Families of campers who do not attend a Jewish day school should request a PJ Goes to Camp referral code by completing the referral code application at the website:  www.pjlibrary.org/pjgtc/referralcode         AFTER October 1, 2015.  
				</p>  
                <p>
                    In case of dispute, the Harold Grinspoon Foundation reserves the right to resolve issues about PJ Goes to Camp incentive awards and the day school camper lottery. 
                </p>
			    <p>
			        <span style="font-weight: bold">WHO IS ELIGIBLE?</span><br />
                    First-time campers at nonprofit Jewish overnight camps are those that are: 
                    <ul>
                        <li>Current PJ Library subscribers (enrolled in the program on or before Sept. 1, 2015)</li>
                        <li>Siblings of currently eligible PJ Library subscribers (enrolled in the program on or before Sept. 1, 2015) </li>
                        <li>PJ Library alumni</li>
                    </ul>

			    </p>
				<p>
                    <span style="font-weight: bold">FOR WHAT TIME PERIOD?</span> <br />
                    These opportunities apply only to Summer 2016 experiences.

				</p>                
				<p>
				    <span style="font-weight: bold">FOR WHAT AMOUNTS? </span>
                    The PJ Goes to Camp grants will be awarded as follows: 
                    <ul>
                        <li>$1,000 for a session of at least 19 consecutive days (for all included camps</li>
                        <li>$700 for a session of at least 12 consecutive days</li>
                    </ul>				    
				</p>
                <p>
                    <span style="font-weight: bold">WHICH CAMPS ARE INCLUDED?</span> <br />
                    All 155+ nonprofit overnight Jewish camps in North America listed on the <a href="http://www.jewishcamp.org/camps" target="_blank">Foundation for Jewish Camp</a>  are included.

				</p>  
			    <p>
			        <span style="font-weight: bold">ADDITIONAL NOTES</span><br />
                    If you have already received (or plan to receive) a grant through another One Happy Camper program (such as your community’s own camp incentive) or any other incentive program via this website or the Harold Grinspoon Foundation, you cannot combine that grant with PJ Goes to Camp funds.

			    </p>
			    <p>
			        Families living in Western Massachusetts (Berkshire, Franklin, Hampden, and Hampshire Counties) or designated towns in Southern Vermont and Northern Connecticut are not eligible for PJ Goes to Camp. 
                    Instead, these families are eligible for an incentive grant through the Harold Grinspoon Foundation’s Campership Initiative (<a href="http://www.HGF.org" target="_blank">www.HGF.org</a>) 
                    See the attached list of zip codes for locating residents who are are eligible for these incentive grants.
			    </p>
			    <p>
			        For answers to questions regarding PJ Goes to Camp or its online process, please e-mail the PJ Goes to Camp administrator at <a href='mailto:pjgtc@hgf.org'>pjgtc@hgf.org</a>
			    </p>
			    <p>
			        To learn more about the PJ Library or the Harold Grinspoon Foundation, please visit <a href="http://www.pjlibrary.org" target=_blank>www.pjlibrary.org</a>
			    </p>
			</td>
        </tr>
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
	            <img id="Img3" src="../../images/PJlogo.jpg" width="300" onclick="return Img1_onclick()" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label10" runat="server" CssClass="infotext3">
                <p style="text-align:justify; color:Red;">
					At this time all of the PJ Goes To Camp / One Happy Camper incentive grants for the 2014 camp session have been awarded both for Non ?Day School & Day School Families
				</p>	                
                <p style="text-align:justify">
					If your child does not attend camp this summer and you would like to be notified of opening times of the 2015 One Happy Camper program registration, send an email to pjgtc@hgf.org in August of 2014 to be placed on the email distribution list that will contain all the information needed to apply for the 2015 camp session. 
				</p>
                 <p style="text-align:justify">
					Thank you for a successful 2014 PJ Goes To Camp season. Enjoys your camp experience!
				</p>					
				</asp:Label>
            </td>
        </tr>
    </table>       
    <table id="tblDisableOld" runat="server" width="100%" cellpadding="5" cellspacing="0" visible="false">
        <tr>
            <td>
	            <img id="Img2" src="../../images/PJlogo.jpg" width="300" onclick="return Img1_onclick()" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label13" runat="server" CssClass="infotext3">
                <p style="text-align:justify; color:Red;">
					If you have already received a PJ Library code and have reached this page, please contact Madeline Ramos at pjgtc@hgf.org.
				</p>	                
                <p style="text-align:justify">
					At this time all of the PJ Goes To Camp / One Happy Camper incentive grants for the 2014 camp session have been awarded.  
					We are accepting non-day school campers to a waiting list in the event that funding becomes available for additional campers.  
					To be placed on this waiting list, please email your child’s first & last name, parent’s first & last name & email address you would like to be contacted at, 
					in the event additional funding becomes available, to: pjgtc@hgf.org. 
				</p>
                 <p style="text-align:justify">
					Our waiting list for Jewish Day School Families is now CLOSED.  
					We do not anticipate any additional funding for grants to Jewish day school children for the 2014 Camp Session. 
				</p>					
                <p style="text-align:justify">
					If your child does not go to camp this summer and you would like to be notified of opening times of the 
					2015 One Happy Camper program registration, send an email to pjgtc@hgf.org in August of 2014 to be placed on the email distribution list 
					that will contain all the information needed to apply for the 2015 camp session. 
				</p>					
                <p style="text-align:justify">
					Thank you for a successful 2014 PJ Goes To Camp season. Enjoys your camp experience!
				</p>
				</asp:Label>
            </td>
        </tr>
    </table>    
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
                                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary"
                                    CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous"
                                    CssClass="submitbtn" OnClick="btnPrevious_Click" />
                            </td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later"
                                    CssClass="submitbtn1" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> "
                                    CssClass="submitbtn" OnClick="btnNext_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
