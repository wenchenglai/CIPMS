<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Dallas_Summary" %>

<asp:Content ID="Dallas_Summary" ContentPlaceHolderID="Content" Runat="Server">
  <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
  <table id="tblRegular" runat="server" width="100%" cellpadding="5" cellspacing="0">         
    <tr>         
      <td>
        <img id="Img1" src="../../images/Dallas_logo.jpg" style="width:275px; height:300px;" alt="" />
      </td>
      <td>
        <asp:Label ID="Label2" CssClass="infotext3" runat="server">
          <p style="text-align:justify;">
            Great news!  The Foundation for Jewish Camp, in partnership with the Center for Jewish Education of the Jewish Federation of Greater Dallas, 
            the Schultz/Romaner Families and Camps Nageela, Ramah Darom, Young Judaea, Greene Family Camp and Sabra offers funding to children in our community 
            who wish to attended Jewish overnight camp for the first-time. To determine if you are eligible for a One Happy Camper grant please read the paragraph below. 
            If you believe that your camper meets the criteria please proceed with the application by clicking the next button below.
          </p>
        </asp:Label>     
      </td>
    </tr>        
    <tr>
      <td colspan="2">
        <asp:Label ID="Label5" CssClass="infotext3" runat="server">
          <p style="text-align:justify; font-weight:bold; ">
            The Dallas One Happy Camper Program provides grants to encourage children to attend overnight Jewish camp for the first-time.  
            It is not a scholarship fund and is not needs-based.  Our goal is to engage families who are considering sending their children to camp and, 
            in effect, to give them $1,000 off their camp fee to try a Jewish one.
          </p>
        </asp:Label>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label6" CssClass="infotext3" runat="server">      
          <p style="text-align:justify;" >
            <span style="font-weight:bold; text-decoration:underline;">Note:</span>
            This program is an outreach initiative for children who are not currently receiving an immersive, daily Jewish experience. 
            As such, children who attend Jewish day school or Yeshiva are not eligible for program. If your child is not eligible and/or are 
            interested in learning about financial-needs based grants or other camper funding opportunities please visit 
            <a href="http://www.JewishCamp.org/Scholarships">www.JewishCamp.org/Scholarships</a>, 
            contact your camp, or the contact person listed at the bottom of this page.
          </p>
        </asp:Label>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label7" runat="server" CssClass="QuestionText">
          <p style="text-align:justify">If you need additional assistance, please call your community professional listed at the bottom of this page.</p>
        </asp:Label>
      </td>
    </tr>
  </table>  
  <table id="tblDisable" runat="server" width="100%" cellpadding="5" cellspacing="0">         
    <tr>         
      <td>
        <img id="logo" src="../../images/Dallas_logo.jpg" style="width:275px; height:300px;" alt="" />
      </td>
      <td>
        <asp:Label ID="Label3" CssClass="infotext3" runat="server">
          <p style="text-align:justify;">
            The Jewish Federation of Greater Dallas One Happy Camper Program has reached its capacity for the year and is now closed.<br /><br />
			Please click “Next” to see if you are eligible for a different One Happy Camper program.<br /><br />
			If you have any questions or would like to inquire about needs-based scholarships, please be in touch with Melissa Bernstein at <a href="mailto:mbernstein@jfgd.org">mbernstein@jfgd.org</a>  or (214) 239-7134.
          </p>
        </asp:Label>     
      </td>
    </tr>
  </table>
  <asp:Panel ID="Panel1" runat="server" style="margin-bottom: 0px">
     <table width="100%" cellpadding="1" cellspacing="0" border="0">            
         <tr>
             <td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
             <td valign="top"><br />
                 <table width="100%" cellspacing="0" cellpadding="0" border="0">
                     <tr>
                         <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="<< Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click" /></td>
                         <td>
                             <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" /></td>
                         <td align="center">
                         <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" CssClass="submitbtn1" />
                             </td>
                             
                         <td align="right"><asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" Visible="true"/>
                             </td>                            
                     </tr>
                  </table>
             </td>
         </tr>
     </table>        
  </asp:Panel>
</asp:Content>
