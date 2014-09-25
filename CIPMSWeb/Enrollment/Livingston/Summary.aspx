<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Chi_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img src="../../images/Livingston.png" alt="" /></td>
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
                    The Camp Livingston One Happy Camper program, sponsored by Camp Livingston and the Foundation for Jewish Camp provides financial incentives.
				</p>
		        <p>
			        The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 to campers who attend camp for at least 19 consecutive days for the first time.</li>
                        <li>$700 to campers who attend camp for 12-18 consecutive days for the first time.</li>
                        <li>Eligible campers must be entering grades 3-12 (after camp).</li>
                        <li>You must be already signed up for Mini Session 1, Mini Session 2Session 1, Session 2, Adventures Unlimited, Hadracha or Yisrael programs.</li>
                        <li>If your child attended camp in the summer of 2014 for 12-18 days as a first time camper s/he is still eligible for the grant if attending camp in 2015 for 19 or more consecutive days.</li>
                    </ul>
		        </p>                
		        <p>
		            Camp Livingston has been serving campers from all over for 95 years. Campers enjoy sports, arts, aquatics, ropes courses, rock climbing, nature, Judaics and much more. Campers can choose 1, 2, 4, 6 or 8 week session lengths. Teen wilderness trips and Israel trips available. We provide a safe and nurturing environment where campers gain self-esteem confidence, and form lasting friendships with their cabin and unit friends, all within a fun and exciting Jewish atmosphere. Campers return year after year because Livingston offers activities and a feeling of kinship that are difficult to find anywhere else. Within this unique environment, campers come to know and love our Jewish heritage through the singing of Hebrew songs, experiencing cultural arts, observing Kashrut and celebrating a meaningful Shabbat as a camp community and family.
		        </p>
                <p>
                    If you are interested in learning more about our camps and available grants, please visit our website at <a href="http://www.camplivingston.com" target="_blank">www.camplivingston.com</a>.
                </p>
                <p>
                    If you need additional assistance, please call the camp office at 513-793-5554.
                </p>
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
                                <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
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

