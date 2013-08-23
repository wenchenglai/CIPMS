<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Chi_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
	<table width="100%" cellpadding="5" cellspacing="0">
		<tr>
			<td>
				<img src="../../images/Surprise lake.jpg" /><br />
				<img src="../../images/UJA_NYLogo1.JPG" />
			</td>
            <td>
                <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
                    <p style="text-align:justify"><b>Good news! You may be eligible for an incentive.</b></p>
				</asp:Label>
				<asp:Label ID="Label1" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						To determine if you are eligible continue reading and if your camper meets the eligibility criteria, please proceed by clicking the "next" button below.
					</p>
				</asp:Label>
				<asp:Label ID="Label4" CssClass="infotext3" runat="server">
					<p style="text-align:justify"><b>
						The Surprise Lake One Happy Camper Program, sponsored by Surprise Lake Camp and the Foundation for Jewish Camp is offering an incentive program for first time campers from anywhere in North America. In New York City, Westchester and Long Island the One Happy Camper program is offered in collaboration with the UJA Federation of NY and the Foundation for Jewish Camp.</b>
					</p>
				</asp:Label>
				<asp:Label ID="Label6" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						Surprise Lake Camp is a co-ed sleepaway camp located just 60 miles from New York City. SLC stands for more than just great fun. Since 1902, we have helped young people to grow and develop. Our campers come away with better skills for getting along with others, greater independence, enhanced self-esteem, stronger Jewish identities, heightened environmental awareness, and a fuller sense of their creative potential. 
					</p>
				</asp:Label>   
            </td>
        </tr>
       <%-- <tr>
          <td colspan="2">
               
           </td>
        </tr>--%>
               
        <tr>
          <td colspan="2"><asp:Label ID="Label2" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                 Surprise Lake Camp has a sliding fee scale based on family size and income and is proud of its long history of providing <a href="http://surpriselake.org/parents/scholarships.php" target="_blank">scholarships</a> to families in need.</p>
            </asp:Label></td>
        </tr> 
         <tr>
          <td colspan="2"><asp:Label ID="Label5" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                 <font style="color:Red">If you are currently enrolled in Jewish day school or yeshiva, please contact the Surprise Lake Camp office directly to learn about incentive grant opportunities. Please do not proceed with this application. 
                 </font></p>
            </asp:Label></td>
        </tr>
        <tr>
          <td colspan="2"><asp:Label ID="Label3" CssClass="infotext3" runat="server">
                <p style="text-align:justify">
                If you are interested in learning more about our camps and other available grants, please visit us at: <a href="http://www.surpriselake.org/" target="_blank">                      
                www.surpriselake.org</a> or call us at 212 924 3131 and someone on staff will be happy to assist you.</p>
            </asp:Label></td>
        </tr>     
        <%--<tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">If you need additional assistance, please call the camp professional listed at the bottom of this page.</p>
                </asp:Label></td></tr>--%>
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

