<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Ramah_Summary" %>

<asp:Content ID="Ramah_Summary" ContentPlaceHolderID="Content" runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img id="logo" src="logo.jpg" alt="" />
            </td>
            <td>
                <p>
					Shalom! The One Happy Camper grant may be available to you! The Foundation for Jewish Camp, in partnership with Wilshire Boulevard Temple Camps, has an incentive program that financially helps campers from all over North America attend Jewish overnight camp!
				</p>
            </td>
        </tr>
        <tr>          
			<td colspan="2">
				<p>
				    The following outlines the eligibility criteria for Wilshire Boulvard Temple Camps’ One Happy Camper program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 3-10 (after camp).</li>
                        <li>Camper must not have attended a Jewish overnight camp for 12 or more days</li>
                        <li>Campers enrolled in Jewish day schools are eligible</li>
                    </ul>
				</p>                
				<p>
The day your family becomes a part of Wilshire Boulevard Temple Camps is the beginning of a lifelong connection to our extraordinary community. Campers step off the bus among the spectacular hills and canyons of the Malibu coast and are immediately embraced by our camp family. In this matchless setting, they are offered a wealth of programming options—top-notch sports, theatre, music, dance, swimming, arts and crafts, social, spiritual and educational activities, all designed to create a magical environment in which campers can stretch their limits, build meaningful relationships, develop a profound connection to Judaism and have the time of their lives.

				</p>
                <p>
                    The experience is nothing short of transformative. We have more than 60 years' worth of evidence to prove it. Many of our staff grew up at Camp, and we are all deeply committed to your child's experience and inclusion in our community. We also bring in staff from Israel to expand our perspectives and enhance our culture. Each of us understands the privilege and responsibility of being a positive Jewish role model.
                </p>
                <p>
If you would like to learn more about our camps, in addition to other scholarship opportunities, visit us online at wbtcamps.org, or contact our Registrar, Janine Regal (213) 835-2128.

                </p>  
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
                                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" />
                            </td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
