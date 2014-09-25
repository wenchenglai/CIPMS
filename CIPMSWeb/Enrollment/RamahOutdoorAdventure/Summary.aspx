<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Ramah_Summary" %>

<asp:Content ID="Ramah_Summary" ContentPlaceHolderID="Content" runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img id="logo" src="../../images/Ramah_Logo.jpg" alt="" height="65" width="250" />
            </td>
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
			        Ramah is the camping arm of Conservative Judaism. With seven overnight camps, three day camps, one specialty camp and Ramah Programs in Israel, Ramah impacts over 10,000 campers and staff every summer. A summer at Ramah is spent immersed in Jewish living - highlighted by dynamic and innovative programming. Traditional camp and outdoor activities, including swimming, sports, dance and art, are enhanced by Ramah's dedication to excellence in informal Jewish education. Combining a love for camping with meaningful Jewish experiences, Ramah instills in its campers and staff a love of Judaism, the Jewish people, Israel and the outdoors. The Ramah Camping Movement is guided by seven core values: self-esteem of every individual; character development; Jewish learning; Jewish identity and community; Jewish observance; Zionism; and Hebrew.
			    </p>
                <p>
                    The Ramah One Happy Camper Program, sponsored by the National Ramah Commission and Camp Ramah Outdoor Adventure, awards incentive grants up to $1,000 to first time campers.
                </p>
				<p>
				    The following outlines the eligibility criteria for this One Happy Camper program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 3-11 (after camp).</li>
                    </ul>
				</p>                
				<p>
				    If you are interested in learning more about our camps and available grants, please visit us at www.campramah.org. 
				</p>
                <p>
                    If you need additional assistance, please call your community professional listed at the bottom of this page. 
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
