<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Nageela_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0" class="infotext3" style="text-align:justify">
		<tr>
            <td>
                <img src="../../images/Camp_Nageela_Logo.JPG" />
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
                    The Camp Nageela Midwest One Happy Camper program, sponsored by Camp Nageela Midwest and the Foundation for Jewish Camp provides financial incentives.
				</p>
		        <p>
			        The following outlines the eligibility criteria for this program:
                    <ul style="font-weight: bold">
                        <li>$1,000 grants awarded to first-time campers attending camp for 19 or more consecutive days.</li>
                        <li>$700 grants awarded to first-time campers attending camp for 12-18 consecutive days.</li>
                        <li>First time camper must be entering grades 3-12 (after camp).</li>
                        <li>If camper attended camp in the summer of 2014 for 12-18 days as a first time camper s/he is still eligible for the grant if attending camp in 2015 for 19 or more consecutive days.</li>
                    </ul>
		        </p>                
		        <p>
		            Camp Nageela Midwest is a premier Jewish camping experience that is dedicated to providing a Located on 550 wooded acres in Marshall, Indiana, Camp Nageela Midwest features miles of undisturbed nature trails and waterfalls. Our campus boasts a heated outdoor pool, low & high ropes challenge courses complete with a five-story climbing wall and zip line. The arts center will delight the creative, while our professional sports fields, state-of-the-art gym, tennis courts and six outdoor covered basketball courts are sure to impress the most competitive sports enthusiast. Warm, caring, and professional staff are at the core of Nageela, ensuring safe unforgettable summers year after year. Camp Nageela Midwest is accredited by the American Camping Association. First time campers can attend for as low as $995.
		        </p>
                <p>
                    CNM = Fun, CNM = Friends, CNM = Jewish Identity
                </p>
                <p>
                    If you need additional assistance, please call the camp professional listed at the bottom of this page.
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

