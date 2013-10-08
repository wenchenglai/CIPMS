<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="ClosedFedRedirection.aspx.cs" Inherits="Enrollment_ClosedFedRedirection" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
<asp:Panel ID="pnlColumbusRedirect" runat="server" Visible="true" Width="100%" >
<table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="logo" src="../images/Columbus.jpg" /></td>
            
            <td>
                <asp:Label ID="lblHead" CssClass="lblPopup2" runat="server">
                    <p style="text-align:justify"><b>Columbus Jewish Federation’s One Happy Camper Program Deadline was April 1st</b></p></asp:Label>
                <asp:Label ID="lblInstructions" runat="server" CssClass="infotext3">
                    <p style="text-align:justify">Contact Marla Davis at <a href= "mdavis@tcjf.org">mdavis@tcjf.org</a> order to discuss other possible funding opportunities from the Columbus Jewish Federation for summer 2011.</p></asp:Label></td>
        </tr>
        <tr>
          <td colspan="2">
                  <p style="text-align:justify;font-family:verdana;font-size:11">We want to encourage families to send children to Jewish overnight summer camp because we know that it is a foundational experience in building young Jewish identities and creating positive Jewish memories. 
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="clickherelink" runat="server" CssClass="infotext3" 
                          onclick="clickherelink_Click">Click Here</asp:LinkButton>  &nbsp;to see if you’re eligible for a One Happy Camper grant with one of the camp partners.</p>                
                  </td>
        </tr>        
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAdditionalInfo" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">We know that you make many decisions for your child and we are very happy that you have decided to send your child to Jewish overnight summer camp. Camp is a wonderful way for your child to mature, gain independence, learn social skills, and explore personal interests.  Jewish camp provides for all of these in an environment that also gives children Jewish memories and experiences, teachings about Jewish values and culture, and often Jewish friendships that can last a lifetime.</p>
                </asp:Label></td></tr>
    </table>
    </asp:Panel>
    
    <asp:Panel ID="pnlPalmBeachRedirect" runat="server" Visible="true" Width="100%" >
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
           <td>
                <img id="Logo1" src="../images/PalmBeach_Logo.jpg" alt=""/></td>
            
            <td>
                <asp:Label ID="Label1" CssClass="lblPopup2" runat="server">
                    <p style="text-align:justify"><b>The Palm Beach One Happy Camper Program has reached its capacity for the year and is now closed. </b></p></asp:Label>
                </td>
        </tr>
        <tr>
          <td colspan="2">
                  <p style="text-align:justify;font-family:verdana;font-size:11"><b>Please click “Next” to see if you are eligible for a different One Happy Camper program.</b>
                      <%--<asp:LinkButton ID="palmBeachClickHere" runat="server" CssClass="infotext3" 
                          onclick="clickherelink1_Click">click here</asp:LinkButton> <b> to see if you are eligible for a different One Happy Camper program such as the PJ (Library) Goes to Camp program, your camp’s own incentive program or many others.</b></p> --%>               
                  </td>
        </tr>        
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify"><b>If you have any questions or would like to inquire about needs-based scholarships, please be in touch with Sam Friedman at <a href="mailto:Sam.Friedman@jewishpalmbeach.org" target="_blank">Sam.Friedman@jewishpalmbeach.org</a> or 561-615-4953.</b></p>
                </asp:Label></td></tr>
                <%--<tr>
            <td colspan="2">
                <asp:Label ID="Label2" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">Should you require financial aid or scholarship assistance to send your child to Jewish camp this summer, we encourage you to speak directly with your local camp director, synagogue, Jewish federation, and/or visit the Foundation for Jewish Camp’s scholarship listing at <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a>.</p>
                </asp:Label></td></tr>--%>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlWashingtonRedirect" runat="server" Visible="true" Width="100%" >
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
           <td>
                <img id="Img3" src="../images/DC logo.jpg" alt="" height="100" width="320" /></td>
            
            <td>
                <asp:Label ID="Label2" CssClass="lblPopup2" runat="server">
                    <p style="text-align:justify"><b>The Greater Washington DC area One Happy Camper Program has reached its capacity for the year and is now closed.  </b></p></asp:Label>
                </td>
        </tr>
        <tr>
          <td colspan="2">
                  <p style="text-align:justify;font-family:verdana;font-size:11"><b>Please click “Next” to see if you are eligible for a different One Happy Camper program. </b>
                           
                  </td>
        </tr>      
      
               
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlMiamiRedirect" runat="server" Visible="true" Width="100%" >
<table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="Img1" src="../images/Miami Logo.jpg"  alt="" height="100" width="220" /></td>
                    <td>
                <asp:Label ID="Label4" CssClass="lblPopup2" runat="server">
                    <p style="text-align:justify"><b>We regret to inform you that the Miami One Happy Camper program, administered by the Greater Miami Jewish Federation in partnership with the Foundation for Jewish Camp has reached its capacity for this year and is now closed.</b></p></asp:Label>
                </td>
        </tr>
        <tr>
          <td colspan="2">
                  <p style="text-align:justify;font-family:verdana;font-size:11"><b>Please</b>
                      <asp:LinkButton ID="LinkButton1" runat="server" CssClass="infotext3" 
                          onclick="clickheremiami_Click">click here</asp:LinkButton> &nbsp;<b> to see if you are eligible for a different One Happy Camper program such as the PJ (Library) Goes to Camp program, your camp’s own incentive program or many others.</b></p>                
                  </td>
        </tr>        
        <tr>
            <td colspan="2">
                <asp:Label ID="Label5" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">For additional information, please contact Ellen Goldberg at <a href="mailto:egoldberg@gmjf.org" target="_blank">egoldberg@gmjf.org</a>.</p>
                </asp:Label></td></tr>
                <tr>
            <td colspan="2">
                <asp:Label ID="Label6" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">Should you require financial aid or scholarship assistance to send your child to Jewish camp this summer, we encourage you to speak directly with your local camp director, synagogue, Jewish federation, and/or visit the Foundation for Jewish Camp’s scholarship listing at <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a>.</p>
                </asp:Label></td> 
           </tr>
    </table>
    </asp:Panel>
    
       <asp:Panel ID="pnlIndianapolis" runat="server" Visible="true" Width="100%" >
<table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <img id="Img2" src="../images/Indianapolis.jpg"  alt="" height="100" width="220" /></td>
                    <td>
                <asp:Label ID="Label7" CssClass="lblPopup2" runat="server">
                    <p style="text-align:justify"><b>We regret to information you that the Indianapolis One Happy Camper program, administered by the Jewish Federation of Greater Indianapolis in partnership with the Foundation for Jewish Camp has reached its capacity for this year and is now closed.</b></p></asp:Label>
                </td>
        </tr>
        <tr>
          <td colspan="2">
                  <p style="text-align:justify;font-family:verdana;font-size:11"><b>Please</b>
                      <asp:LinkButton ID="Indianaclick" runat="server" CssClass="infotext3" 
                          onclick="clickhereIndiana_Click">click here</asp:LinkButton> &nbsp;<b> to see if you are eligible for a different One Happy Camper program such as the PJ (Library) Goes to Camp program, your camp’s own incentive program or many others.</b></p>                
                  </td>
        </tr>        
        <tr>
            <td colspan="2">
                <asp:Label ID="Label8" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">For additional information, please contact Carolyn Leeds at <a href="mailto:cleeds@jfgi.org" target="_blank">cleeds@jfgi.org</a>.</p>
                </asp:Label></td></tr>
                <tr>
            <td colspan="2">
                <asp:Label ID="Label9" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">Should you require financial aid or scholarship assistance to send your child to Jewish camp this summer, we encourage you to speak directly with your local camp director, synagogue, Jewish federation, and/or visit the Foundation for Jewish Camp’s scholarship listing at <a href="http://www.JewishCamp.org/Scholarships" target="_blank">www.JewishCamp.org/Scholarships</a>.</p>
                </asp:Label></td> 
           </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" cellpadding="1" cellspacing="0" border="0">            
            <tr>
                <td valign="top" style="width:5%"><asp:Label ID="Label12" runat="server" Text="" CssClass="QuestionText"></asp:Label></td>
                <td valign="top" ><br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ID="btnReturnAdmin" runat="server" Text="Exit To Camper Summary" CssClass="submitbtn1" OnClick="btnReturnAdmin_Click"/></td>
                            <td>
                                <asp:Button ID="btnPrevious" CausesValidation="false" runat="server" Text=" << Previous" CssClass="submitbtn" OnClick="btnPrevious_Click" visible="false"/></td>
                            <td align="center">
                                <asp:Button ID="btnSaveandExit" CausesValidation="false" runat="server" Text="Save & Continue Later" OnClick="btnSaveandExit_Click"
                                    CssClass="submitbtn1" visible="false"/></td>
                           <td align="right">
                                <asp:Button ID="btnNext" CausesValidation="false" runat="server" Text="Next >> " CssClass="submitbtn" OnClick="btnNext_Click" Visible="false"/></td>                          
                        </tr>
                       
                     </table>
                </td>
            </tr>
        </table>        
    </asp:Panel>
</asp:Content>

