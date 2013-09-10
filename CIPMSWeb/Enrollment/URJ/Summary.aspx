<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_URJ_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0">
            <tr>
            <td>
                <img src="../../images/URJ.jpg" alt=""/></td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify" class="infotext3">
						<b>The Foundation for Jewish Camp, 
						in partnership with the Union for Reform Judaism, is offering up to $1,000 to first-time 
						campers who attend any URJ camp.</b>
					</p>
				</asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p style="text-align:justify"> 
						<span id="spnCampName" runat="server" >The award is available to any camp-age child
						in grades 3-12 who registers at one of the listed URJ Camps, and who is attending 
						a non-profit Jewish sleep-away camp for 19 consecutive days or-longer for the first 
						time (or 12 days in one of the 13 Western states or Six Points Sports Academy). 
						Siblings from a single family are eligible to receive separate grants. The award 
						is available regardless of need or whether the camper or camper’s family has received
						other scholarship or financial aid.</span>
					</p>
				</asp:Label>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						To learn more about these URJ camps, please visit the camp websites by clicking on the camp names below. 
						If you are ready to continue your application, please press the ‘next’ button.
					</p>
				</asp:Label>
			</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
						<ul>
							<li>URJ 6 Points Sports Academy (Greensboro, NC) - <a href=" http://www.sports.urjcamps.ortg" target="_blank">www.sports.urjcamps.ortg</a></li>
							<li>URJ 6 Points Sci-Tech Academy (Boston, MA) - <a href=" http://www.scitech.urjcamps.org" target="_blank">www.scitech.urjcamps.org</a></li>
							<li>URJ Camp Coleman (Cleveland, GA) - <a href=" http://coleman.urjcamps.org/" target="_blank">www.coleman.urjcamps.org</a></li>
							<li>URJ Camp George (Parry Sound, Ontario) - <a href="http://george.urjcamps.org/" target="_blank">www.george.urjcamps.org</a></li>
							<li>URJ Camp Harlam (Kunkletown, PA) - <a href="http://harlam.urjcamps.org" target="_blank">www.harlam.urjcamps.org</a></li>
							<li>URJ Camp Kalsman (Arlington, WA) - <a href="http://www.kalsman.urjcamps.org" target="_blank">www.kalsman.urjcamps.org</a></li>
							<li>URJ Camp Newman Swig (Santa Rosa, CA) - <a href="http://newman.urjcamps.org/" target="_blank">www.newman.urjcamps.org</a></li>	
							<li>URJ Greene Family Camp (Bruceville, TX) - <a href="http://greene.urjcamps.org/" target="_blank">www.greene.urjcamps.org</a></li>
							<li>URJ Joseph Eisner Camp Institute (Great Barrington, MA) - <a href="http://eisner.urjcamps.org/" target="_blank">www.eisner.urjcamps.org</a></li>
							<li>URJ Crane Lake Camp (West Stockbridge, MA) - <a href="http://www.cranelake.urjcamps.org" target="_blank">www.cranelake.urjcamps.org</a></li>
							<li>URJ Goldman Union Camp Institute (Zionsville, IN) - <a href="http://guci.urjcamps.org/" target="_blank">www.guci.urjcamps.org</a></li>
							<li>URJ Henry S. Jacobs Camp (Utica, MS) - <a href="http://jacobs.urjcamps.org/" target="_blank">www.jacobs.urjcamps.org</a></li>
							<li>URJ Kutz Camp Institute (Warwick, NY) - <a href="http://kutz.urjcamps.org/" target="_blank">www.kutz.urjcamps.org</a></li>	
							<li>URJ Olin-Sang-Ruby Union Institute (Oconomowoc, WI) - <a href="http://osrui.urjcamps.org/" target="_blank">www.osrui.urjcamps.org</a></li>																																															
						</ul>   
					</p>
				</asp:Label>
            </td>
        </tr>        
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need immediate assistance, please contact Anna Blumenfeld  at the Union 
                    for Reform Judaism at 212-650-4133  or <a href="mailto:ablumenfeld@urj.org">ablumenfeld@urj.org</a></p>
                </asp:Label></td></tr>
       <tr>
            <td colspan="2">
                <asp:Label ID="Label3" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call your community professional listed at the bottom of this page.</p>
                </asp:Label></td></tr>         
            
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">            
            <tr>
                <td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" ><br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
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

