<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Sabra_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
  <table id="tblRegister" runat="server" width="100%" cellpadding="5" cellspacing="0">
    <tr>
        <td>
            <img src="../../images/camp-sabra.gif" width="206px" height="209px"/>
        </td>
        <td>
			<asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                <p style="text-align:justify" class="infotext3">
					<b>The Foundation for Jewish Camp, in partnership with Camp Sabra, offers an incentive program that is open to campers 
					who live anywhere in the United States!</b>
				</p>
			</asp:Label> 
            <asp:Label ID="Label4" CssClass="infotext3" runat="server">
                 <p style="text-align:justify"> 
					 <b>To determine if you are eligible for this grant, please read the paragraph below.</b> 
					  If you believe that your camper meets the eligibility criteria, 
					  please proceed with the application process by pressing the ‘next’ button below.
                  </p>
                 <p style="text-align:justify">
					 Camp Sabra is a place where your child can develop a joyous Jewish identity in a unique and personal way. 
					 Located in the beautiful Lake of the Ozarks, Sabra boasts 3.5 miles of private shoreline and over 
					 200 acres of undeveloped forest. We offer a place for our Jewish children to create their own 
					 Jewish community and to make lifelong connections with Jews from all over the country and the world. 
					 Sabra is a place for your child to learn new skills. We offer waterskiing, wakeboarding, tubing, sailing,
					 kayaking, water sliding, swimming in a pool and lake, land sports, extensive challenge ropes course activities,
					 climbing wall, arts and crafts, drama, camping trips out of camp, nature, camp crafts - all flavored with Judaism. 
					 From celebrating Shabbat as a community, to dining together in our kosher facility, our Sabra campers live in a fun, 
					 friend-filled Jewish community during their Sabra experience. A summer of fun, a lifetime of memories. It will be magic!
                 </p>
             </asp:Label>
        </td>
    </tr>
    <tr>
		<td colspan="2">
			<asp:Label ID="Label2" CssClass="infotext3" runat="server">
				<p style="text-align:justify">
					<b>Our One Happy Camper program provides financial incentives of $1000 to campers attending a non-profit Jewish overnight camper for the first 
					time for at least 19 consecutive days. Eligible campers must attend Sabra for a full session and be entering grades 3-9. 
					Campers cannot be enrolled in day school.</b>
				</p>
            </asp:Label>
        </td>
    </tr> 
    <tr>
		<td colspan="2">
			<asp:Label ID="Label3" CssClass="infotext3" runat="server">
				<p style="text-align:justify">
					If you are interesting in learning more about Camp Sabra, visit our website at <a href="http://www.campsabra.com" target="_blank">www.campsabra.com</a> 
					or call us at 314-442-3151. 
				</p>
            </asp:Label>
        </td>
    </tr>     
    <tr>
		<td colspan="2">
			<asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
				<p style="text-align:justify">If you need additional assistance, please call the camp 
                    professional listed at the bottom of this page.</p>
			</asp:Label>
		</td>
	</tr>
</table>
<table id="tblNoRegister" visible="false" runat="server" width="100%" cellpadding="5" cellspacing="0">
    <tr>
      <td>
        <img id="Img1" src="../../images/camp-sabra.gif" alt="" width="206px" height="209px" />
      </td>  
      <td>
        <asp:Label ID="lblRamahCal" runat="server" CssClass="infotext3" >
          Please contact Bebe Morgan at bebe@campsabra.com or (314) 442-3151 for information on how to proceed with the application. Be sure to click save and continue before closing your browser.
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

