<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Ramah_Summary" %>

<asp:Content ID="Ramah_Summary" ContentPlaceHolderID="Content" runat="Server">
  <table id="tblRegister" runat="server" width="100%" cellpadding="5" cellspacing="0">
    <tr>
      <td>
        <img id="logo" src="../../images/Ramah_Logo.jpg" alt="" height="65" width="250" />
      </td>
      <td>
        <asp:Label ID="lblHeading" CssClass="SummaryHeading" runat="server" ForeColor="Black">
          <p style="text-align:justify">Good news! You may be eligible for an incentive.</p>
        </asp:Label>
        <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
          <p style="text-align:justify">
            To determine if you are eligible continue reading and if your camper meets the eligibility criteria, 
            please proceed by clicking the "next" button below.
          </p>
        </asp:Label>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="lblLable2" runat="server" CssClass="infotext3">
          <p style="text-align:justify">
            Ramah is the camping arm of Conservative Judaism. With seven overnight camps, three day camps, one specialty camp and Ramah Programs in Israel, 
            Ramah impacts over 9,000 campers and staff every summer. A summer at Ramah is spent immersed in Jewish living - highlighted by dynamic and innovative programming. 
            Traditional camp and outdoor activities, including swimming, sports, dance and art, are enhanced by Ramah's dedication to excellence in informal Jewish education. 
            Combining a love for camping with meaningful Jewish experiences, Ramah instills in its campers and staff a love of Judaism, the Jewish people, Israel and the outdoors. 
            The Ramah Camping Movement is guided by seven core values: self-esteem of every individual; character development; Jewish learning; Jewish identity and community; 
            Jewish observance; Zionism; and Hebrew.
          </p>
        </asp:Label>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label1" CssClass="infotext3" runat="server">
          <p style="text-align:justify;"><b>
            The Ramah One Happy Camper Program, sponsored by the National Ramah Commission and the Foundation for Jewish Camp, provides financial incentives of $1,000 
            to first-time campers who attend one of our nonprofit Jewish overnight summer camps for at least 19 consecutive days (or $700 for 12-18 day sessions at camps 
            in the West). Eligible campers must be entering grades 3-11 (after camp) and attending one of our camps:</b>
            Camp Ramah in the Berkshires, Camp Ramah in California, Camp Ramah in Canada, Camp Ramah Darom (Georgia), Camp Ramah in New England, 
            Camp Ramah in the Poconos, Camp Ramah in Wisconsin, and Ramah Outdoor Adventure (Colorado). 
            <b>Second-year incentive grants of $750 for summer 2013 (or $500 for 12-18 day sessions at camps in the West) are 
            ONLY available to campers who received first-year grants for summer 2012. After summer 2013, there will be no second-year grants.</b>
            Eligibility and program details may vary by camp. 
            Please contact your camp for details after completing the application. 
          </p>                 
        </asp:Label>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label2" CssClass="infotext3" runat="server">
          <p style="text-align:justify;">
				<asp:Label ID="sadf" runat="server" ForeColor="Red">PLEASE NOTE:</asp:Label> If you live in the Los Angeles area and received a 1st year OHC grant for summer 2012 your grant 
				was provided through your local Federation and NOT from the Ramah OHC Rishon program. Unfortunately, it is NOT possible to switch programs between 
				the 1st and 2nd year. 
          </p>                 
        </asp:Label>
      </td>
    </tr>    
    <tr>
      <td colspan="2">
        <asp:Label ID="lblLable3" runat="server" CssClass="infotext3">
          <p style="text-align:justify">
            If you are interested in learning more about our camps and available grants, please visit us at <a href="http://www.campramah.org" target= "_blank">www.campramah.org</a>.
          </p>
        </asp:Label>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
          <p style="text-align:justify">
            If you need additional assistance, please call your community professional listed at the bottom of this page.
          </p>
        </asp:Label>
      </td>
    </tr>
  </table>
  <table id="tblNoRegister" runat="server" width="100%" cellpadding="5" cellspacing="0">
    <tr>
      <td>
        <img id="Img1" src="../../images/Ramah_Logo.jpg" alt="" height="65" width="250" />
      </td>  
      <td>
        <asp:Label ID="lblRamahDarom" runat="server" CssClass="infotext3" >
          The Camp Ramah Darom One Happy Camper program is now closed for summer 2013. For more information, please contact the professional listed at the bottom of this page.
        </asp:Label>
        <asp:Label ID="lblRamahCal" runat="server" CssClass="infotext3" >
          While there are no more grants at this time, funding may become available at a later date. Please email Karmi Monsher for more information at karmi@ramah.org or call 818-668-2931.
        </asp:Label>
        <div id="divDisableBerkshire" runat="server" class="infotext3">
			 The Camp Ramah in the Berkshires One Happy Camper application for summer 2013 is now closed. Please contact the camp professional listed at the bottom of this page for more information.
        </div>      
      </td>
    </tr>
  </table>

  <asp:Panel ID="Panel1" runat="server">
    <table width="100%" cellpadding="1" cellspacing="0" border="0">
      <tr>
        <td valign="top" style="width: 5%">
            <asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label>
        </td>
        <td valign="top">
          <br />
          <table width="100%" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td align="left">
                  <asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" />
              </td>
              <td>
                  <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" />
              </td>
              <td align="center">
                  <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
              </td>
              <td align="right">
                  <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" />
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </asp:Panel>
</asp:Content>
