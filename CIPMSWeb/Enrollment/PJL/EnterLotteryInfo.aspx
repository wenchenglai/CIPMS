<%@ Page Title="" Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="EnterLotteryInfo.aspx.cs" Inherits="Enrollment_PJL_EnterLotteryInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <div class="QuestionText">
        <p style="text-align:justify; color:red">
            <b>You’ve been entered into the PJ GOES TO CAMP OHC LOTTERY.</b>
        </p>
        <p class="QuestionText" style="text-align:justify">
            The lottery will be drawn by XXX DATE and you will be notified whether or not your child’s name has been drawn via email.
        </p>
        <p class="QuestionText" style="text-align:justify">
            If your child’s name is selected, YOU WILL RECEIVE AN email with instructions on how to complete the application. 
            There will be a deadline of when the application must be completed. If not completed by that date, you will automatically forfeit the grant.
        </p>
        <p class="QuestionText" style="text-align:justify">
            If you have any questions about the lottery process, please be in touch with Madeline Ramos at the PJ Goes to Camp at PJGTC@HGF.org.
        </p>        
    </div>

    
    <div class="QuestionText">
        <br />
        <a href="../../CamperOptions.aspx">Click here</a> to create another application
    </div>
</asp:Content>

