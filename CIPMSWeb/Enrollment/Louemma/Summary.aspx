<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Louemma_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
     <table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
            <td>
                <img src="../../images/Loumea.JPG" alt="" /></td>
            <td>
                <p>
					Good news! You may be eligible for an incentive.
				</p>
                <p>
					To determine if you are eligible continue reading and if your camper meets the eligibility criteria, 
					please proceed by clicking the "next" button below.
				</p>
            </td>
        </tr>
        <tr>
			<td colspan="2">
                <p>
                    The Camp Louemma One Happy Camper program, sponsored by Camp Louemma and the Foundation for Jewish Camp offers $1,000 to first time campers.
                </p>
		        <p>
			        The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>Campers must attend Camp Louemma for at least 19 consecutive days. </li>
                        <li>First-time campers must be entering grades 2-10 (after Camp). </li>
                    </ul>
		        </p>                
		        <p>
		            This grant is NOT NEED BASED. Where need is demonstrated, this grant may be combined with other tuition incentives and scholarship. 
		        </p>
                <p>
                    <span style="font-weight: bold; color:red">ATTENTION JEWISH DAY SCHOOL FAMILIES:</span> If the camper currently attends Jewish day school, please do NOT continue with this application and instead, contact the camp directly at 973-287-7264.
                </p>
                <p>
                    At Camp Louemma we offer an exciting and dynamic program with a wide variety of elective and scheduled activities. Our incredibly friendly, nurturing and talented staff members give each camper the opportunity to explore his or her interests, enhance existing talents and learn new skills. Whether it’s on our athletic fields, tennis or basketball courts, private lake, swimming pool, at our theatre, mini golf course; atop our climbing tower and zip line, ropes courses, or at arts & crafts/ceramics, the game room, bake shop, or radio station, our instructors focus on each camper’s personal achievement while offering encouragement at the same time.
                </p>
                <p>
                    Evenings are also a blast with pool parties (in our new heated swimming pool with water slides), Hawaiian Luaus, treasure and scavenger hunts, game show nights, talent shows, theater productions, concerts and so much more!! 
                </p>
                <p>
                                        Most of all, while we are not a religious camp, Jewish culture and identity are integrated into the program in a manner that is fun, creative and entertaining.

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

