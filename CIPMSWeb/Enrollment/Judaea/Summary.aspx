<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Judaea_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img src="../../images/judaeacamp.jpg" /></td>
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
                    The Young Judaea One Happy Camper Program, awards incentive grants up to $1,000 to first time campers.
                </p>
		        <p>
			        The following outlines the eligibility criteria for this One Happy Camper program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days. </li>
                        <li>First-time campers must be entering grades 2-12 (after camp).</li>
                        <li>Attending one of our camps, including Camp Judaea (Hendersonville, NC), Camp Young Judaea Midwest (Waupaca, WI), Camp Young Judaea Sprout Lake (Verbank, NY), Camp Young Judaea Texas (Wimberley, TX), and our senior leadership camp, Camp Tel Yehudah (Barryville, NY).</li>
                    </ul>
		        </p>                
		        <p>
                    At Young Judaea camps, young people can count on having an experience that develops independence, strong connections with Israel, and lifelong Jewish identity. Young Judaea camps provide an environment of informal Jewish education where both learning and having fun are high on the agenda. In addition to engaging in Israeli song and dance, pluralistic prayer, conversational Hebrew and delicious kosher meals, Young Judaeans enjoy activities such as swimming, basketball, hiking, climbing and ropes course. Campers begin their experience in second or third grade at one of Young Judaea’s four regional camps. Teens attending high school are eligible to attend Camp Tel Yehudah, Young Judaea’s National Senior Leadership camp in Barryville, NY, where generations of Jewish activists, educators and leaders got their start while making friendships that last a lifetime. Young Judaea is the oldest Zionist Youth Movement in the United States and has been running quality Jewish camping programs since 1948.
		        </p>
                <p>
                    This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. As such, children who attend Jewish day school or Yeshiva are not eligible for this incentive program.                </p>
                <p>
                    If you are interested in learning more about our camps and available grants, please visit the camp websites by clicking on the camp names below:
                </p>
                <p>
                    <b><a href="http://www.cyjmid.org" target="_blank">Camp Young Judaea Midwest</a></b>  (Waupaca,Wisconsin)<br />
                    <b><a href="http://www.cyjtexas.org" target="_blank">Camp Young Judaea Texas</a></b>  (Wimberley, TX)<br />
                    <b><a href="http://www.campjudaea.org" target="_blank">Camp Judaea</a></b> (Hendersonville, North Carolina)<br />
                    <b><a href="http://www.cyjsproutlake.org" target="_blank">Camp Young Judaea Sprout Lake</a></b> (Verbank, New York)<br />
                    <b><a href="http://www.campty.com" target="_blank">Camp Tel Yehudah</a></b>(Barryville, New York)<br />
                </p>
            </td>
        </tr>
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img src="../../images/judaeacamp.jpg" /></td>
            <td>
                
			</td>
        </tr>
        <tr>
           <td colspan="2">
               <br />
               <asp:Label ID="lblDisable" runat="server" CssClass="infotext3" Font-Bold="true" Font-Size="Small" />
           </td> 
        </tr>        
    </table>    
    
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">
            <tr>
                <td valign="top" style="width: 5%">
                    <asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top">
                    <br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td align="left">
                                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary"
                                    CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous"
                                    CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later"
                                    CssClass="submitbtn1" /></td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> "
                                    CssClass="submitbtn" OnClick="btnNext_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
