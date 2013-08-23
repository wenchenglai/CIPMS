<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
	<meta http-equiv="content-type" content="text/html; charset=iso-8859-1" >
	<title>Camp Grants</title>
	<link rel="stylesheet" type="text/css" href="./style/main.css" media="screen" />
</head>
<body>
<div id="container">
	
	<div id="content">
		<!-- Start Content  -->
		<form id="Form1" action="welcome.aspx" runat="server">
		<h3>Welcome Camper Family!</h3>

		<p>Thank you for your interest in Jewish overnight camp and the Foundation for Jewish Camp's incentive grant!</p>

		<p>The summer 2010 incentive application is not yet available.  Please stay tuned to <a href="http://www.onehappycamper.org">www.onehappycamper.org</a> as we will launch the 2010 incentive season this fall.</p>
		
		<asp:Panel id="comformationInfo" runat="server" Visible="false">
		<p><asp:Label ID="lblComf" CssClass="confmessage" Text="Thank you for submitting your email address. We will notify you when the registration system re-opens up for the next camp season." runat="server" ></asp:Label></p>
		</asp:Panel>
		
		<asp:Panel ID="submitemail" runat="server" Visible="true"> 
		<p>If you would like us to email you when the registration system opens, please type your email address in the box below:</p>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="email" Display="None"
        ErrorMessage="Please type your email address." Font-Bold="True"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" Display="None"
        ErrorMessage="Please enter a valid email address." Font-Bold="True" ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$"></asp:RegularExpressionValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" Font-Bold="true" />
		<asp:TextBox ID="email" runat="server" size="30" maxlength="100"></asp:TextBox><br/>
		<asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
		</asp:Panel>
		</form>  
                   
         <p>If you have any questions, please feel free to contact us at <a href="mailto:campgrants@jewishcamp.org">campgrants@jewishcamp.org</a> or 888-888-4819.</p>
         
         <p>Many thanks for your continued patience!</p>
         
         <p>Sincerly,</p>
         
         <p>Your friends at the Foundation for Jewish Camp<br/><a href="http://www.jewishcamp.org">www.jewishcamp.org</a></p>
         
		<!-- End Content -->
	</div>
	
</div>

</body>
</html>
