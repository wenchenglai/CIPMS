<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_URJ_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img src="../../images/URJ.jpg" alt=""/></td>
            <td>
                <p>Good news! You may be eligible for an incentive.</p>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <p>
                    The Foundation for Jewish Camp, in partnership with the Union for Reform Judaism, offers incentive grants up to $1000 through the One Happy Camper program open to first-time campers who attend any URJ camp.
                </p>
				<p>
				    The following outlines the eligibility criteria for this One Happy Camper program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>If camper attended camp in the summer of 2014 for 12-18 days as a first time camper s/he is still eligible for the grant if attending camp in 2015 for 19 or more consecutive days.</li>
                        <li>First-time campers must be entering grades 1-12  (after camp).</li>
                    </ul>
				</p> 
                <p>
                    This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. As such, children who attend Jewish day school or yeshiva are not eligible for this incentive program.
                </p>
                <p>
                    To learn more about these URJ camps, please visit the camp websites by clicking on the camp names below. If you are ready to continue your application, please press the “next” button. 
                </p>
                <p>
					<ul>
						<li>URJ 6 Points Sports Academy (Greensboro, NC) - <a href=" http://www.sports.urjcamps.ortg" target="_blank">www.sports.urjcamps.org</a></li>
						<li>URJ 6 Points Sci-Tech Academy (Boston, MA) - <a href=" http://www.scitech.urjcamps.org" target="_blank">www.scitech.urjcamps.org</a></li>
						<li>URJ Camp Coleman (Cleveland, GA) - <a href=" http://coleman.urjcamps.org/" target="_blank">www.coleman.urjcamps.org</a></li>
						<li>URJ Camp George (Parry Sound, Ontario) - <a href="http://george.urjcamps.org/" target="_blank">www.george.urjcamps.org</a></li>
						<li>URJ Camp Harlam (Kunkletown, PA) - <a href="http://harlam.urjcamps.org" target="_blank">www.harlam.urjcamps.org</a></li>
						<li>URJ Camp Kalsman (Arlington, WA) - <a href="http://www.kalsman.urjcamps.org" target="_blank">www.kalsman.urjcamps.org</a></li>
						<li>URJ Camp Newman Swig (Santa Rosa, CA) - <a href="http://newman.urjcamps.org/" target="_blank">www.newman.urjcamps.org</a></li>	
						<li>URJ Greene Family Camp (Bruceville, TX) - <a href="http://greene.urjcamps.org/" target="_blank">www.greene.urjcamps.org</a></li>
						<li>URJ Eisner Camp Institute (Great Barrington, MA) - <a href="http://eisner.urjcamps.org/" target="_blank">www.eisner.urjcamps.org</a></li>
						<li>URJ Crane Lake Camp (West Stockbridge, MA) - <a href="http://www.cranelake.urjcamps.org" target="_blank">www.cranelake.urjcamps.org</a></li>
						<li>URJ Goldman Union Camp Institute (Zionsville, IN) - <a href="http://guci.urjcamps.org/" target="_blank">www.guci.urjcamps.org</a></li>
						<li>URJ Henry S. Jacobs Camp (Utica, MS) - <a href="http://jacobs.urjcamps.org/" target="_blank">www.jacobs.urjcamps.org</a></li>
						<li>URJ Kutz Camp Institute (Warwick, NY) - <a href="http://kutz.urjcamps.org/" target="_blank">www.kutz.urjcamps.org</a></li>	
						<li>URJ Olin-Sang-Ruby Union Institute (Oconomowoc, WI) - <a href="http://osrui.urjcamps.org/" target="_blank">www.osrui.urjcamps.org</a></li>																																															
					</ul>                       
                </p>  
            </td>
        </tr>            
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img src="../../images/URJ.jpg" alt=""/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblDisabledMessage"></asp:Label>
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

