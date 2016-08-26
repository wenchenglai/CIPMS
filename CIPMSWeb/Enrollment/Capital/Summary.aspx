<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Capital_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
     <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
            <td colspan="2">
                <img src="../../images/Capital Camps.jpg" alt="" />
            </td>
        </tr>
        <tr>
			<td colspan="2">
                <p>
					Good news! You may be eligible for a One Happy Camper grant.
				</p>
                <p>
					To determine if you are eligible continue reading and if your camper meets the eligibility criteria, 
					please proceed by clicking the "next" button below.
				</p>
		        <p>
			        The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 3-10 (after camp).</li>
                    </ul>
		        </p>                
		        <p>
		            If you are unsure of your eligibility, please contact our Camp Team at info@capitalcamps.org or 301-468-2267. 
		        </p>
                <p>
Capital Camps is the Jewish Community Overnight Camp of the Mid-Atlantic region. We have provided quality Jewish camping in a warm nurturing environment for 29 years. 
                    We are located just over one hour from both Washington DC and Baltimore. 
                    Capital Camps is for campers entering grades 3 through 10. Options include a 2-week ¡§introductory¡¨ program for grades 3-5. We also offer a fully-mainstreamed Special Needs program. Financial aid is also available.
                </p>
                <p>
Our facilities and include cabins with bathrooms, aquatics complex (heated with two 40ft water flumes, beach entry and more), arts and theatre building, ropes challenge course 
                    (with two challenge towers and zip lines), tennis, volleyball and basketball courts, two large indoor pavilions, softball field, gaga pit, lake, and much more. Activities include sports (softball, soccer, basketball, volleyball, flag football, and more), swimming, boating, archery, mud obstacle course, drama, arts & crafts, ceramics, Jewish environmental education, outdoor adventure programs, trips and more. Judaic themes and programming are balanced with outstanding recreational activities. Our staff members are chosen for their love and enthusiasm as well as their appropriateness as Jewish role models.
                </p>
                <p>
Our campers are immersed in a nurturing community which is committed to providing them with experiences that build their independence, 
                    strengthen their Jewish identity and create memories that will last a lifetime.                </p>
                <p>
If you need additional assistance, please call the camp professional listed at the bottom of this page.

                </p>
			</td>
        </tr>
    </table>
     <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
            <td colspan="2">
                <img src="../../images/Capital Camps.jpg" alt="" />
            </td>
        </tr>
        <tr>
			<td colspan="2">
                <p>
					The Capital Camps One Happy Camper program is now closed for summer 2016. For more information, please contact Erin Reich at Erin@capitalcamps.org.
				</p>
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

