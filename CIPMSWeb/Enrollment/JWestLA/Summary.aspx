<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs"
    Inherits="Enrollment_Summary" %>

<asp:Content ID="JWest_summary" ContentPlaceHolderID="Content" runat="Server">
    <table id="tblSummary" runat="server" width="100%" cellpadding="5" cellspacing="0">
          <tr>
            <td align="center">
                <img id="logo2" src="../../images/JJF.JPG" width="310" />
                <img id="Img1" src="../../images/jwest.JPG" />
                </td>
                <td colspan="2">
            <asp:Label ID="Label4" CssClass="SummaryHeading" runat="server">Welcome back JWest camper!</asp:Label>
                 <asp:Label ID="Label1" CssClass="infotext3" runat="server">
                     <p style="text-align:justify"> 
                     The JWest Campership Program, administered by the Foundation for Jewish Camp through generous support from the <b>Jim Joseph Foundation</b>, 
                     provides financial incentives to returning JWest campers who will attend a nonprofit Jewish overnight summer camp for at least 12 days in summer 2013. </p>
                     </asp:Label></td>
            </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="Label3" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">
						Campers who attended a minimum 12-day session for the first time in 2011 and the second time in 2012, may now qualify for $500 in 2013.
                  </p>
                    </asp:Label></td>
        </tr>
        
        <tr>
            <td class="QuestionText" colspan="3">
                <p style="text-align: justify">
                <u>JWest Camps</u>:<br /><br />
                
                    <a href="http://www.bbcamp.org/" target="_blank">B'nai B’rith Camp</a>, <a href="http://www.alonim.com/"
                        target="_blank">Camp Alonim</a>, <a href="http://www.campcharlespearlstein.com/"
                            target="_blank">Camp Daisy and Harry Stein</a>, <a href="http://www.wbtcamps.org/"
                                    target="_blank">Camp Hess Kramer</a>, <a href="http://www.campjcashalom.com/" target="_blank">
                                        Camp JCA Shalom</a>, <a href="http://www.mountainchai.org/" target="_blank">Camp Mountain
                Chai</a>, <a href="http://www.ramah.org/" target="_blank">Camp Ramah in California</a>, <a href="http://www.campschechter.org/" target="_blank">
                Camp Solomon Schechter</a>, <a href="http://www.tawonga.org/" target="_blank">Camp Tawonga</a>, <a href="http://www.jccoc.org/camp_yofi.html"
                        target="_blank">Camp Yofi</a>, <a href="http://www.campgilboa.org/" target="_blank">
                            Habonim Dror Camp Gilboa</a>, <a href="http://www.wbtcamps.org/" target="_blank">Gindling
       Hilltop Camp</a>, <a href="http://www.ranchcamp.org/" target="_blank">JCC Ranch Camp</a>, <a href="http://www.ramahoutdoors.org/" target="_blank">Ramah Outdoor 
       Adventure Camp</a>, <a href="http://www.sephardicadventurecamp.org/" target="_blank">Sephardic Adventure
                        Camp</a>, <a href="http://www.shwayder.com/" target="_blank">Shwayder Camp</a>, <a href="http://kalsman.urjcamps.org/" target="_blank">
                        URJ Camp Kalsman</a>, <a href="http://newmanswig.urjcamps.org/" target="_blank">URJ Camp Newman</a>,
                         <a href="http://www.campmiriam.org/" target="_blank">Camp Miriam</a>, <a href="http://bechollashon.org/camp/camp_about.php"
                        target="_blank">Camp Be'chol Lashon</a>, <a href="http://www.machanehmamosh.com/gan"
                            target="_blank">Gan Israel Ranch Camp</a>, <a href="http://www.nageelawest.org"
                            target="_blank">Camp Nageela West</a> and <a href="http://www.campakiba.org"
                                target="_blank">Camp Akiba</a>.</p>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lbl" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">
                       If you’d like to discuss other camp options, please call the number below. For a full list of the camps that the Foundation for Jewish Camp works with, 
                       please visit our website (<a href="www.OneHappyCamper.org/FindaCamp" target="_blank">www.OneHappyCamper.org/FindaCamp</a>).</p>
                    <p style="text-align:justify">
                        If you are not eligible for the JWest Campership Program, and/or are interested in learning about scholarship opportunities, 
                        please visit <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a>
                        or contact your camp or Federation directly.</p></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">
                        If you need additional assistance or would like to speak with someone directly, please call the Foundation for Jewish Camp at 888-888-4819, 
                        <a href="mailto:jwest@jewishcamp.org">jwest@jewishcamp.org</a>.</p></asp:Label>
            </td>
        </tr>
    </table>
    <table visible="false" id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">
		<tr>
            <td align="center">
                <img id="Img2" src="../../images/JJF.JPG" width="310" />
                <img id="Img3" src="../../images/jwest.JPG" />
            </td>
            <td colspan="2">
				<asp:Label ID="Label2" CssClass="SummaryHeading" runat="server">Welcome back JWest camper!</asp:Label>
                <asp:Label ID="Label5" CssClass="infotext3" runat="server">
					<p style="text-align:justify">
						We are thrilled that you will be returning to camp this summer. 
						The JWest application is not yet available for 2013. 
						Please <asp:HyperLink ID="hyl" NavigateUrl="~/CamperHolding.aspx?fed=JwestLA" runat="server" Text="click here"></asp:HyperLink> to enter your contact information. We will notify you as soon as the application becomes available.
					</p>
                </asp:Label>
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
                                    CssClass="submitbtn1" /></td>
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
