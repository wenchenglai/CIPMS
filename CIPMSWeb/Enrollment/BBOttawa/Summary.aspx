<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_BBOttawa_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
            <td>
                <img src="../../images/BBOtawa_logo.jpg" alt="" />
            </td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server">
                    <p style="text-align:justify" class="lblPopup1">Good news! You may be eligible for an incentive.</p>
                 </asp:Label>
                     <asp:Label ID="Label4" CssClass="infotext3" runat="server">
                     <p style="text-align:justify"> 
                     To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.</p>
                     </asp:Label>
            </td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label1" CssClass="infotext3" runat="server">
                <p style="text-align:justify"><b>The Camp B地ai Brith of Ottawa One Happy Camper program, sponsored by Camp B地ai Brith of Ottawa and the Foundation for Jewish Camp provides grants of $1000 to first-time campers who attend Camp B'nai Brith of Ottawa for a minimum session of 19 consecutive days. Eligible campers must have completed grade 1 before camp begins and not be attending a Jewish Day School at that time. If you are interested in learning more about Camp B'nai Brith of Ottawa, please visit us at   
                <a href="http://www.cbbottawa.com" target="_blank">www.cbbottawa.com</a>.</b>
                </p>
            </asp:Label></td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label2" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                Located on the edge of the Gatineau Hills, 45 from Ottawa, CBB Ottawa is a privately owned, not-for-profit overnight camp. Our camp prides itself in welcoming children from all over the world, attracting many campers from Ottawa, Montreal, Toronto, United States, Israel and other locations worldwide.
            </p>
            <p style="text-align:justify">B地ai Brith of Ottawa痴 program is balanced between athletics and the arts offering a number of different activities such as drama, dance, arts & crafts, music, many sports and a variety of long-standing all camp programs such as Grey Cup/Super Bowl, World Cup and Colour War. Being located on the Ottawa River, water sports are the pride and joy of our program. They include: waterskiing (4 waterski boats), wakeboarding, kayaking, canoeing, sailing and a canoe-tripping program that takes place amidst the beauty and diversity of western Quebec and Algonquin Park. Campers receive swim instruction in the Olympic-sized heated pool from qualified swim instructors using the curriculum of the Lifesaving Society. Our facilities include an indoor gym, dance studio, recreation hall, 4 lighted tennis courts, 2 outdoor basketball courts, 3 playing fields, and an on-site health center which has fully qualified medical staff. Meals are prepared in a kosher kitchen (Ottawa VAAD Kashruth) and the camp is PEANUT and NUT SENSITIVE. In addition, there is a Judaica program that includes weekly Shabbat Services that is fun yet traditional. If you are interested in giving your child an active, stimulating and exciting summer camp experience, then Camp B地ai Brith of Ottawa is the place to be. </p>
            </asp:Label>
            <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">If you need additional assistance, please call the camp professional listed at the bottom of this page.</p></asp:Label>
            </td>
        </tr> 
      
    </table>
	<table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
                <img src="../../images/BBOtawa_logo.jpg" alt="" />
            </td>
			<td>
				<asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify"> 
						Camp B'nai Brith One Happy CAmper application is not yet available for summer 2013.  
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

