<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_JCC_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
			<td>
                <img src="logo.png" /></td>
            <td>
                <p>
					Good news! You may be eligible for an incentive.
				</p>
                <p>
The Foundation for Jewish Camp, in partnership with Moshava California, offers incentive grants through the One Happy Camper program that is open to first-time campers who live anywhere in North America! 				</p>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<p>
				    The Moshava California One Happy Camper program provides financial incentives of up to $1,000 to all eligible first-time campers. 
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
This incentive cannot be combined with other discounts or promotions offered by Moshava California. 
                    It is only available to children who do not attend Jewish day school. These funds are limited and may run out at any time without notice. 

                </p> 
                <p>
                    Moshava California is a Modern Orthodox and religious Zionist coed overnight camp for children entering grades 3 through 10. As a proud member of Bnei Akiva's Camp Moshava family, our mission is to inspire and empower Jewish youth with a deep commitment to our people, Am Yisrael; our land, Eretz Yisrael; and our Torah, Torat Yisrael. 
                </p>
                <p>
                    In a warm, caring, and safe environment, we offer a rich program of sports, arts, swimming, and nature infused with Jewish identity development and learning. Our home is located in Running Springs, California, on 78 beautiful acres in the mountains of San Bernardino County, less than 2 hours from Los Angeles. 
                </p>
                <p>
                    To learn more about our camp, please visit our website: 
                    <a href="http://www.moshavaCalifornia.org" target="_blank">www.moshavaCalifornia.org</a>, or contact our office by emailing to office@moshavacalifornia.org. You may also call us at (855) MOSHAVA.
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

