<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Washington_Summary" %>

<asp:Content ID="Washington_Summary" ContentPlaceHolderID="Content" runat="Server">

    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function Img1_onclick() {

        }

        // ]]>
    </script>

    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
	            <img id="Img1" src="../../images/PJlogo.jpg" width="300" onclick="return Img1_onclick()" />
            </td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify;color:Black" class="lblPopup1">Good news! You may be eligible for a PJ Goes to Camp grant.</p>
                </asp:Label>
                <asp:Label ID="Label8" CssClass="infotext3" runat="server">
					<p style="text-align:justify">To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                <p style="text-align:justify">
					The Foundation for Jewish Camp, in partnership with the PJ Library Program, brings PJ Goes to Camp, a funding partner of FJC’s One Happy Camper program, 
					to first-time campers who live anywhere in North America. PJ Goes to Camp offers One Happy Camper incentive grants of up to $1,000 to offset camp tuition 
					for PJ Library participants, siblings, and alumni.
				</p>
                <p style="text-align:justify">
					A total of 350 GRANTS are available on a first-come, first-serve basis through PJ Goes to Camp. These grants of up to $1,000 will help subscribing 
					families of <a href="http://www.pjlibrary.org" target="_blank">The PJ Library</a> to pay for summer camp tuition for first-time campers at 
					nonprofit Jewish overnight camps.
				</p>
				</asp:Label>
            </td>
        </tr>  
        <tr>
            <td colspan="2">
                <asp:Label ID="Label9" runat="server" CssClass="infotext3">
					<p style="text-align:justify">
						<b><span style="color:red">ATTENTION JEWISH DAY SCHOOL FAMILIES:</span></b> 
                        All PJ Goes To Camp Incentive Grants for day school students for the summer of 2014 have been distributed through a lottery that was 
                        completed on November 8, 2013.  Due to overwhelming demand we are unable to place additional names on the 2014 waiting list.  
                        If you do not send your child to camp in 2014 and would like to be informed about the 
                        day-school student lottery for first-time campers for the summer of 2015, please e-mail your name and camper information 
                        AFTER August 15, 2014 to <a href="mailto:PJGTC@hgf.org">PJGTC@hgf.org</a>.  
					</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
				<p style="text-align:justify" class="infotext3">
                    In case of dispute, the Harold Grinspoon Foundation reserves the right to resolve issues about PJ Goes to Camp incentive awards and the day school camper lottery.
				</p>
            </td>
        </tr>                                                                      
        <tr>
            <td colspan="2">
                <asp:Label ID="Label15" runat="server" CssClass="infotext3">
                <p style="text-align:justify" >
                    <b>WHO IS ELIGIBLE?</b> <br />
                    First-time campers at nonprofit Jewish overnight camps are those that are: 
                </p>                
                <ul>
                    <li>
                       	Current PJ Library subscribers (enrolled in the program on or before Sept. 1, 2013)                
                    </li>
                    <li>
                       	Siblings of currently eligible PJ Library subscribers (enrolled in the program on or before Sept. 1, 2013) 
                    </li>
                    <li>
                        PJ Library alumni                    
                    </li>
                </ul>

                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" runat="server" CssClass="infotext3">
                <p style="text-align:justify" >
                    <b>FOR WHAT TIME PERIOD?</b> <br />
                    These opportunities apply only to Summer 2014 experiences. 
                </p>
                
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label4" runat="server" CssClass="infotext3">
                <p style="text-align:justify" >
                    <b>FOR WHAT AMOUNTS?</b> <br />
                    The PJ Goes to Camp grants will be awarded as follows: 
                </p>                
                <ul>
                    <li>
                       	$1,000 for a session of at least 19 consecutive days (for all included camps)
                    </li>
                    <li>
                        $700 for a session of at least 12 consecutive days<br />
                        (this applies ONLY to camps in Western States, which include AK, AZ, CA, CO, HI, ID, MT, NM, NV, OR, UT, WA, and WY) 
                    </li>                    
                </ul>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label5" runat="server" CssClass="infotext3">
                <p style="text-align:justify" >
                    <b>WHICH CAMPS ARE INCLUDED?</b> <br />
                    All 155+ nonprofit overnight Jewish camps in North America <a href="http://www.jewishcamp.org/camps" target="_blank">listed on the Foundation 
                        for Jewish Camp</a>  are included.
                </p>                
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label6" runat="server" CssClass="infotext3">
            <p style="text-align:justify"><b>ADDITIONAL NOTES</b><br />
                If you have already received (or plan to receive) a grant through another One Happy Camper program 
                (such as your community’s own camp incentive) or any other incentive program via this website or the Harold Grinspoon Foundation, 
                you cannot combine that grant with PJ Goes to Camp funds. 
            </p>
            </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" CssClass="infotext3">
                <p style="text-align:justify">Families living in Western Massachusetts (Berkshire, Franklin, Hampden, and Hampshire Counties) 
                or designated towns in Southern Vermont and Northern Connecticut are not eligible for PJ Goes to Camp. 
                Instead, these families are eligible for an incentive grant through the 
                <font color="Black">Harold Grinspoon Foundation’s Campership Initiative</font> (<a href="http://www.HGF.org" target="_blank">www.HGF.org</a>) 
                See the attached list of zip codes for locating residents who are are eligible for these incentive grants.</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                For answers to questions regarding PJ Goes to Camp or its online process, please e-mail Maddie Ramos at  
                <a href='mailto:maddie@hgf.org'>maddie@hgf.org</a></p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label7" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						To learn more about the PJ Library or the Harold Grinspoon Foundation, 
						please visit <a href="http://www.pjlibrary.org" target=_blank>www.pjlibrary.org</a>
					</p>
                </asp:Label>
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
					At this time all of the PJ Goes To Camp / One Happy Camper incentive grants for the 2014 camp session have been awarded both for Non – Day School & Day School Families
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
