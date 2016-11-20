<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Memphis_Summary" %>

<asp:Content ID="Memphis_summary" ContentPlaceHolderID="Content" Runat="Server">
    <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img src="logo.jpg" alt="logo" />
            </td>
            <td>
                <p>
					Good News! You may be eligible for an incentive grant from the Farash Institute for Jewish Education for your first experience at Jewish overnight camp. 
                    Second year financial assistance grants are also available.
				</p>
                <p>
					To determine if you are eligible, continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "Next" button below.
				</p>
                
			    <p>
			        The One Happy Camper-Rochester grant program, sponsored by the Farash Institute for Jewish Education and the Foundation for Jewish Camp,
                    offers incentive grants of up to $1800 to all first-time campers attending a Jewish not-for-profit overnight camp. We also offer financial assistance
                    grants of up to $1000 for second year campers based on family income level.
			    </p>

				The following are the eligibility criteria for this program:
                <ul style="font-weight: bold; list-style-type: disc ">
                    <li>Camper must be Jewish.</li>
                    <li>Camper must reside in one of the following New York counties: Monroe, Wayne, Ontario, Yates, Seneca, Livingston, Wyoming, Genesee, Orleans.</li>
                    <li>Camper must be attending Jewish overnight camp for the first or second time.</li>
                    <li>Camper must attend Jewish overnight camp for 12 days or more.</li>
                    <li>Camper must choose a camp from the Foundation for Jewish Camp approved camp list which includes over 155+ non-profit, Jewish overnight camps.  
                        This can be found at <a href="http://www.farashinstitute.org/findacamp" target="_blank">www.farashinstitute.org/findacamp</a>.</li>
                </ul>
            </td>
        </tr>        
        <tr>
			<td colspan="2">

              
				<p>
				    If you meet the above criteria, and you are a <span style="font-weight:bold">first time camper</span>, you may be eligible for:
				</p>
                <p>
                    $1800 grants if first time camper is attending Jewish overnight camp for 19 or more consecutive days.<br/>
                    $1000 grants if first time camper is attending Jewish overnight camp for 12-18 days.
				</p>
                <p>
                    If you meet the above criteria, and you are a <span style="font-weight:bold">second year camper</span> whose family has an income of 
$100,000 or less, and you received an OHC grant in 2016, you may be eligible for an affordability grant of up to $1000 for 19+ days and $500 for 12-18 days.
                </p>
                <p>
                    If you need additional assistance or have further questions, please contact Sharon at sgray@farashinstitute.org or 585-434-2700 x-203.
                </p>
			</td>
        </tr>     
    </table>
    <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
        <tr>
            <td>
                <img src="logo.jpg" alt="logo" />
            </td>
            <td>

			</td>
        </tr>
        <tr>
			<td colspan="2">
				<asp:Label ID="Label6" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
                        The Jewish Foundation of Rochester is closed for this year.  Please click the "Next" button to proceed.
					</p>            
				</asp:Label>
			</td>
        </tr>          
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">            
            <tr>
                <td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" colspan="2"><br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                            <td align="center">
                            <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                                </td>
                            <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn"  OnClick="btnNext_Click" /></td>                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>
</asp:Content>
