<%@ Page Title="" Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="EnterLotteryInfo.aspx.cs" Inherits="Enrollment_PJL_EnterLotteryInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <div class="QuestionText">
         <img id="Img1" style="float: left;" src="../../images/PJlogo.jpg" width="300" onclick="return Img1_onclick()" />
        <p style="color:red">
            Congratulations, you’ve been entered in the PJ Goes to Camp One Happy Camper lottery for campers currently enrolled in Jewish Day School.
        </p>
        <p>
            The lottery will be drawn the week of November 14th.  
            If selected you will notified via the email address that you used to complete this application with instructions on how to proceed. 
            If you are NOT selected, you will receive an email notifying you about next steps and other opportunities.
        </p>
        <p>
           If you have any questions about the lottery process, please contact PJ Goes to Camp at PJGTC@HGF.ORG.
        </p>
        <p>
            Please do not enter the lottery more than one time per child.
        </p>        
    </div>

    
    <div class="QuestionText">
        <br />
        <a href="../../CamperOptions.aspx">Click here</a> to complete an application for another child.
    </div>
</asp:Content>

