<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Chi_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
			<td>
                <img src="../../images/NageelaEast.jpg" width="250px" height="150px"/>
            </td>
            <td>
                <p>
					Good news! You may be eligible for a One Happy Camper grant. 
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
                    The Camp Nageela One Happy Camper program, sponsored by Camp Nageela and the Foundation for Jewish Camp offers incentives.
                </p>
		        <p>
			        The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>First time camper must be entering grades 3-11 (after camp).</li>
                    </ul>
		        </p>                
		        <p>
                    At Camp Nageela, children not only make great friends, they develop critical skills needed to navigate lasting relationships. 
                    Judaism has much to teach us about relationships, and our staff model responsible, caring and compassionate relationships with our campers.
		        </p>
                <p>
                    We believe that Judaism asks of us to live our lives to the fullest. In fact, Nageela means rejoice, and that is the spirit of our camp. 
                    Our sports are challenging, our activities are creative, our specialties are life enhancing and our Jewish pride is contagious. 
                    Our campus is new and full of amenities. Our staff is chosen for their positive and growth oriented attitudes. 
                    Our campers love to have fun and appreciate meaningful experiences. Add it all up and you have 4 weeks of exhilaration that will last a lifetime.
                </p>
                <p>
                    Now that we told you our philosophy, please see our website for how we put it into action. <a href="http://www.Campnageela.org" target="_blank">Campnageela.org</a>.                
                </p>
                <p>
If you are interested in learning more about our camps and other available grants, and our many and varied year-round programs, 
                    please contact Rabbi David Shenker at (516) 374-1528 Ext 103 or rds@campnageela.org.                 

                </p>
			</td>
        </tr>
	</table>
	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img src="../../images/NageelaEast.jpg" width="250px" height="150px"/>
            </td>
			<td>
				<asp:Label ID="Label7" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						The Camp Nageela One Happy Camper application is not yet available for summer 2013.  
						Please contact the person listed at the bottom of this page for more information.
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

