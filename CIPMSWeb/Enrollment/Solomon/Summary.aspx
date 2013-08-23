<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Solomon_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img src="../../images/Solomon Schechter Logo.jpg" alt="" />
            </td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify" class="infotext3"><b>Good news! You may be eligible for an incentive. </b></p>
                </asp:Label>
                <asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
					</p> 
                </asp:Label>
            </td>
        </tr>       
        <tr>
			<td colspan="2">
				<asp:Label ID="Label2" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						<b>The Camp Solomon Schechter One Happy Camper Program, sponsored by Camp Solomon Schechter and the Foundation for Jewish Camp provides a 
						financial incentive of $1,000 to a limited number of campers who are, for the first time, attending Camp for at least 19 consecutive days 
						(sessions Bet or Gimmel, or attending BOTH sessions Aleph I and Aleph II together with the stayover day). A limited number of campers who
						are attending only session Aleph II for the first time may be eligible for a financial incentive of $700. 
						Campers who have previously come to one of our shorter sessions are eligible. Campers who attend Jewish Day School are not eligible. 
						If you are interested in learning more about our camp and available grants, please visit us at 
						<a href="http://www.campschechter.org" target="_blank">www.campschechter.org</a>, 
						email us at <a href="mailto:registrar@campschechter.org" target="_blank">registrar@campschechter.org</a>, 
						or contact us at 206.447.1967 or 604.288.7655.</b>
					</p>
				</asp:Label>
			</td>
        </tr> 
		<tr>
			<td colspan="2">
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Camp Solomon Schechter offers campers an innovative Jewish camping experience for Jewish youth of all denominations. 
						At Camp Solomon Schechter we emphasize the values of integrity, derech eretz (respect) and tikkun olam (repairing the world). 
						We do this through activities and learning based on movement and Teva (nature) to create our ideal Jewish community. 
						We offer campers a wide variety of activities, including a Challenge Course with high and low elements, Dance, Guitar/Band, Digital Photography, 
						Babysitting training, Arts & Crafts, Basketball, Softball, Soccer, Football, Tennis, Ultimate Frisbee, Frisbee Golf, Gaga (Jewish Dodge ball), 
						Fishing, Boating, Swimming, Hiking, and every session has a Maccabiah (Jewish Olympics). We also have interactive and creative Jewish programming. 
						Every day at camp includes some infusion of Hebrew, nature, art, song, dance, and tfilot (prayer) services. Schechter also has Israeli Scouts, 
						who teach about Israel and Israeli life, who infuse Hebrew into camp, and who instill a sense of pride in Israel to our campers and staff.
					</p>
				</asp:Label>
			</td>
        </tr>  
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call the camp professional listed at the bottom of this page.</p>
                </asp:Label>
            </td>
        </tr>
    </table>
	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img src="../../images/Solomon Schechter Logo.jpg" alt="" />
            </td>
            <td>
            </td>
        </tr>       
        <tr>
			<td colspan="2">
				<asp:Label ID="Label6" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						The Solomon Schechter One Happy Camper Program is now closed for Summer 2013. Please contact the person listed at the bottom of this page for more information.
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

