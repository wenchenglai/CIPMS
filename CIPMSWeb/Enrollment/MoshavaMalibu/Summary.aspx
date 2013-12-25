<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_JCC_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img src="../../images/Moshava Malibu.jpg" /></td>
            <td>
				<asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="infotext3">
						<b>Good news!  <br /><br />
                            The Foundation for Jewish Camp, in partnership with Moshava Malibu, offers an incentive program that is open to first-time campers who live anywhere in North America!</b>
					</p>
                </asp:Label>
                <asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						
					</p>
                </asp:Label>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label6" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
                        Moshava Malibu is an Orthodox coed overnight camp for children completing grades 2 through 9 and a proud member of Bnei Akiva’s Camp Moshava family. 
                        We are located on 220 acres in the beautiful mountains of Malibu, just 45 minutes from Los Angeles. Our mission is to inspire and empower Jewish 
                        youth with a deep commitment to our people (Am Yisrael), our land (Eretz Yisrael), and our Torah (Torat Yisrael). We have the unique opportunity 
                        of partnering with The Shalom Institute to leverage their 61 years of camping experience, professionalism, facilities and faculty specialists to 
                        ensure our success. We offer horseback riding, surfing, animal education, sports, archery, ocean kayaking, rope courses, climbing wall, organic 
                        farming, Israel Discovery Center, hiking trails directly to the beach and much more.
					</p>
				</asp:Label>
			</td>
		</tr> 
		<tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<strong>The Moshava Malibu One Happy Camper program provides financial incentives of up to $1,000 to all first-time campers </strong>
						who have never attended a non-profit Jewish overnight camp, including those who currently attend Jewish Day Schools.  This incentive 
                        cannot be combined with other discounts or promotions offered by Moshava Malibu.  These funds are limited and may run out at any time without notice.
					</p>
				</asp:Label>
			</td>
        </tr>      
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">
						If you are interested in learning more about our camp, please visit us at: <a href="http://www.moshavamalibu.org" target="_blank">www.moshavamalibu.org</a> 
						or send us an email at <a href="mailto:info@moshavamalibu.org">info@moshavamalibu.org</a>.  You may also call us at 1.855.MOSHAVA.
					</p>
                </asp:Label>
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

