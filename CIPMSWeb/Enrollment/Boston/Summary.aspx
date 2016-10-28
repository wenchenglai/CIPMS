<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Boston_Summary" %>

<asp:Content ID="MiddleSex_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img id="logo" src="../../images/boston.jpg" /></td>
            <td>
                <p>Good news! You may be eligible for a One Happy Camper grant.</p>    
                <p>
				    To determine if you are eligible continue reading and if your camper meets the eligibility criteria, 
					please proceed by clicking the "next" button below.
			    </p>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<p>
					The Boston One Happy Camper program, sponsored by the Combined Jewish Philanthropies of Greater Boston and the Foundation for Jewish Camp, 
                    provides financial incentives to first-time campers to attend a nonprofit Jewish overnight summer camp for at least 12 consecutive days. 
				</p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 2-11 (after camp).</li>
                        <li>Attending one of the 155+ non-profit, Jewish, overnight camps listed on the Foundation for Jewish Camp’s website (<a href="http://www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).</li>
                    </ul>
				</p>   
                <p>
                    This program has two components, one of which is for participants that belong to a congregation and one for those who don’t.
                    <ul style="font-weight: bold">
                        <li>If you are a member of any of the synagogues listed below, please contact your congregation liaison to inform them that you are applying for
                         a One Happy Camper grant and continue to fill out the following application.</li>
                        <li>If you are not a member of any of the congregations listed below, please begin the application.</li>
                    </ul>
                </p>
                <p>
                    This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. 
                    As such, children who attend Jewish day school or Yeshiva are not eligible for this incentive program. If you do not think that you are eligible for this program, 
                    but are interested in learning about camp scholarship opportunities, please visit 
                    <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a> or contact your camp or Federation directly.
                </p> 

                <p><b>Participating Synagogues:</b></p>                  
                <p>
                    Temple Sinai (Sharon)<br />
                    Temple Beth Shalom (Needham)<br />
                    Temple Emanuel (Newton) <br />
                    Temple Beth Elohim (Wellesley)<br />
                    Temple Aliyah (Needham)<br />
                    Temple Beth Elohim (Acton) <br />
                    Temple Isaiah (Lexington)<br />
                    Temple Shalom (Newton) <br />
                    Temple Israel (Sharon)<br />
                    Temple Israel (Natick)<br />
                    Temple Israel (Boston)<br />
                    Temple Emunah (Lexington)<br />
                    Kehillath Israel (Brookline) <br />
                    Temple Beth Avodah (Newton) <br />
                    Temple Beth Am (Framingham)<br />
                    Temple Beth Sholom (Framingham)<br />
                    Temple Beth Torah (Holliston) <br />
                    Temple Beth David (Westwood)<br />
                    Temple Chayai Shalom (Easton)<br />
                    Beth El Temple Center (Belmont)<br />
                    EtzChaim (Franklin) <br />
                    Temple Beth Emunah (Brockton)<br />
                    Temple Sinai (Brookline)<br />
                    Temple Reyim (Newton)<br />
                </p>            
            </td>
        </tr>        
     <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call your community professional listed at the bottom of this page.</p>
                </asp:Label></td></tr>
    </table>
    
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="Img1" src="../../images/boston.jpg" /></td>
            <td>
                <asp:Label ID="Label4" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
						

Unfortunately, due to a 15% increase in applications, CJP does not currently have available funds for the One Happy Camper grant program. If your child is going to Camp Avoda, BIMA/Genesis or a URJ Camp, 
there may be grant funds available by continuing to apply through the camp at onehappycamper.org.
</p>
<p style="text-align:justify">
Otherwise, please complete this form to be added to the Wait List for our first-time camper grant:
</p>
<p style="text-align:justify">
<a href="http://goo.gl/forms/sleLpQHgia" target="_blank">http://goo.gl/forms/sleLpQHgia</a>
</p>
<p style="text-align:justify">
We hope to secure additional monies and will contact you if we are able to consider your application for a $700 or $1,000 award. Thank you for your understanding and patience.
					</p>
				</asp:Label>
			</td>
        </tr>
    </table>  

    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">            
            <tr>
                <td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2"><br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                            <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                                </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn"  OnClick="btnNext_Click" /></td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>
</asp:Content>
