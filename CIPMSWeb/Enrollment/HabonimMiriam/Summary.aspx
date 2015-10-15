<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Habonim_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img id="imgLogo" src="logo.jpg" alt="" runat="server" />
            </td>
            <td>
                <p>
                    Good news! You may be eligible for an incentive.
                </p>
                <p>
                    To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
                </p>
            </td>
        </tr>
        <tr>
			<td colspan="2">
				<p>
                    The Habonim Dror One Happy Camper Program, sponsored by the Habonim Dror Camp Association, the Foundation for Jewish Camp and Camp Miriam, provides grants of up to a $1,000 to first-time campers attending Habonim Dror Camp Miriam in the summer of 2016. 				    
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 4-10 (after camp).</li>
                    </ul>
				</p>   
                <p>
At our 7 Habonim Dror camps young people learn the values and skills needed for community building and leadership, independent thinking, a strong connection to Israel, and lifelong Jewish identity. Campers are embedded in a 24/7 experiential Jewish education environment that blurs the boundary between learning and having fun so that both can occur simultaneously.                 

                </p>        
                <p>
Habonim Dror campers become legendary Israeli dancers and revel in singing Israeli songs from every generation. We have creative Shabbat observances, conversational Hebrew and delicious kosher meals (supplemented by camper-grown food from each camp's organic gardens). Habonim Dror campers are known for their daily avodah (work periods) in maintenance chores such as tending to the chickens and veggie gardens, as well as such traditional camp activities as swimming, music, arts and crafts, boating, hiking, gaga and other sports.                       
                </p>     
                <p>
Campers may begin attending camp following second or third grade. Habonim Dror is the Zionist Youth Movement affiliated with the Hanoar Haoved and Dror Israel movements in Israel.  Habonim Dror campers come from all streams of the Jewish community - Conservative, Reform, Reconstructionist, Jewish Renewal, secular, and unaffiliated.                     
                </p>     
                <p>
If you are interested in learning more about our camps and available grants at a specific camp, please visit the individual camp websites by clicking on the camp names above.                     
                </p>     
                <p>
If you need additional assistance, please call the camp professional listed at the bottom of this page.                     
                </p>                                                                               
            </td>
        </tr>
    </table>

    <table id="tblDisable" runat="server" visible="false" width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="ImgLogoDisable" runat="server" /></td>
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
                                    CssClass="submitbtn1" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> "
                                    CssClass="submitbtn" OnClick="btnNext_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
