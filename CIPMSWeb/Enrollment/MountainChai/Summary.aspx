<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_JCC_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
			<td>
                <img src="../../images/CMC Logo.JPG" /></td>
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
				    The Camp Mountain Chai - One Happy Camper Program, sponsored in partnership between Camp Mountain Chai and the Foundation for Jewish Camp provides a one-time financial incentive of up to $1000 for first-time campers who attend Camp Mountain Chai.
				</p>
				<p>
				    The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 2-11 (after camp).</li>
                    </ul>
				</p>   
                <p>
                    Camp Mountain Chai expands and enriches Jewish identity by establishing an atmosphere of knowledge and love for Jewish culture, traditions and religion. Through sports, arts, outdoor adventure and aquatics, campers build life-long friendships, independence and self-worth. We provide a unique summer experience with an emphasis on excellence. Judaism is woven into the fabric of Camp Mountain Chai life as we appreciate the importance of connecting our campers to their rich Jewish heritage while understanding our collective responsibility to make the world a better place. We are proud of our well-rounded program which combines required cabin and elective activities with extensive outdoor opportunities.
                </p> 
                <p>
                    With warm days and cool nights, the weather in the San Bernardino National Forest is ideal for summer activities. Your child can comfortably participate in all our outdoor activities, and the fresh mountain air and low humidity enhance indoor activities such as cabin life, theater, creative arts and dining.
                </p>
                <p>
                    If you are interested in learning more about Camp Mountain Chai and available grants, please visit us at: <a href="http://www.campmountainchai.com" target="_blank">www.campmountainchai.com</a> or call our office at 858-499-1330.
                </p>           
            </td>
        </tr>  
    </table>

    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img id="img1" src="../../images/CMC Logo.JPG" alt="" runat="server" />
            </td>
            <td>
                <p>
                    Your camp's One Happy Camper Application is not yet available for summer 2016. Please call the camp professional listed at the bottom of this page for more information.

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

