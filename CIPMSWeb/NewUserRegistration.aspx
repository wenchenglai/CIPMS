<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewUserRegistration.aspx.cs"
    Inherits="NewUserRegistration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en"> 
<%
    //Response.Buffer = true;
    //Response.Expires = -1;
    //Response.ExpiresAbsolute = DateTime.Now.AddDays( -1 );
    //Response.CacheControl = "no-cache";
%>
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="Content-type:text/html; charset=utf-8" />	
<meta http-equiv="imagetoolbar" content="no" />
<meta name="Classification" content="" /> 
<meta name="revisit-after" content="30 days" />
<meta name="copyright" content="Copyright 2011 jewishcamp.org" />
<meta name="distribution" content="global" />
<meta name="language" content="English" />
<meta name="robots" content="ALL" />
<meta name="google-site-verification" content="mwWSyx26YY5pk1Gzue_atEkq3muwftMv-46wW1uuOoY" />

<link rel="shortcut icon" type="image/x-icon"  href='<%= this.ResolveClientUrl("~/img/favicon/favicon.ico") %>' />

<link rel="stylesheet" type="text/css" href="Style/reset.css" media="screen, projection, tty" />
<link rel="stylesheet" type="text/css" href="Style/base.css" media="screen, projection, tty" />
<link rel="stylesheet" type="text/css" href="Style/print.css" media="print" />
<link rel="stylesheet" type="text/css" href="Style/interior.css" media="screen, projection, tty" />
<link rel="stylesheet" type="text/css" href="Style/ohc.css" media="screen, projection, tty" />				

<title>Apply | One Happy Camper | Foundation for Jewish Camp</title>
<link rel="stylesheet" href="Style/mainHome.css" />
<script type="text/javascript">
		var meta_bold = { src: '../img/meta_bold.swf' };
</script>
    <%--<title>One Happy Camper - Grants for Jewish Summer Camp - Apply Now</title>
    <link rel="stylesheet" href="Style/main.css" />--%>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>

    <script type="text/javascript" language="javascript">
	javascript:window.history.forward(1);
    </script>

    <script src='<%= this.ResolveClientUrl("~/CIPMS_JScript.js") %>' language="javascript"
        type="text/javascript"></script>

  <%--  <script type="text/javascript" src='<%= this.ResolveClientUrl("~/JQuery/popup.js") %>'></script>--%>

    <script type="text/javascript" language="javascript">
    function onSubmit()
    {
        var lblErr = document.getElementById("lblErr");
        //lblErr.innerText ="";
    }
    </script>
    
    <script type="text/javascript">
     
      var _gaq = _gaq || [];
      _gaq.push(['_setAccount', 'UA-6958336-1']);
      _gaq.push(['_setDomainName', '.onehappycamper.org']);
      _gaq.push(['_trackPageview']);
     
      (function() {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
      })();
     
    </script>

</head>
<body class="body ohc">
    <form id="form1" runat="server">
   <%--<div id="wrapper">
            <div id="main" class="shadow">
                <div id="topimg">
                    <a id="imgmap" href="https://www.onehappycamper.org/index.html"></a>
                </div>
                <div id="topnav">
                    <div id="nav-menu">
                        <ul>
                            <li><a href="https://www.onehappycamper.org/index.html" target="_blank">Home</a></li>
                            <li><a href="https://www.onehappycamper.org/about.html" target="_blank">About</a></li>
                            <li><a href="http://www.jewishcamp.org/one-happy-camper/eligibility" target="_blank">Eligibility</a></li>
                            <li><a href="https://www.onehappycamper.org/contact.html" target="_blank">Contact</a></li>
                            <li><a class="active" href="home.aspx" target="_blank">Apply Now!</a></li>
                        </ul>
                    </div>
                </div>
                <div id="bgsub">
                    <img src='<%= this.ResolveClientUrl("~/images/parchment_bg_sm.jpg") %>' />
                </div>--%>
                <!-- #container -->
	<div id="container" class="container">
			
		<!-- #wrapper -->
		<div id="wrapper">
			
		<!-- #header -->
		<div id="header" class="clear">
			<a href="/" title="Foundation for Jewish Camp Home" id="logo">
				<img src='<%= this.ResolveClientUrl("~/img/logo/logo.png") %>' width="137" height="180" alt="Foundation for Jewish Camp" />
			</a>
			<a href="/" title="Foundation for Jewish Camp Home" id="logo_ie6">
				<img src='<%= this.ResolveClientUrl("~/img/logo/logo_8bit.png") %>' width="137" height="180" alt="Foundation for Jewish Camp" />
			</a>
		
			<!-- #nav_ohc -->
			<div id="nav_ohc">
				<a href="http://www.jewishcamp.org/one-happy-camper/" title="One Happy Camper">One Happy Camper</a>
			</div>
			<!-- /#nav_ohc -->

			<!-- #nav_social -->
			<div id="nav_social">
				<ul>
					<li id="nav_twitter"><a href="http://twitter.com/fdnjewishcamp" title="Follow us on Twitter!">Twitter</a></li>
					<li id="nav_facebook"><a href="http://www.facebook.com/foundationforjewishcamp?ref=ts" title="Become a Fan on Facebook!">Facebook</a></li>
				</ul>
			</div>
			<!-- /#nav_social -->

			<!-- #nav_utility -->
			<div id="nav_utility" class="clear">
				<ul class="clear">
					<li id="nav_donate"><a href="http://www.jewishcamp.org/get-involved/donate" title="Donate">Donate &raquo;</a></li>
					<li id="nav_contact"><a href="http://www.jewishcamp.org/contact-us" title="Contact Us">Contact Us</a></li>
					<li id="nav_faq"><a href="http://www.jewishcamp.org/frequently-asked-questions" title="FAQs">Faqs</a></li>
				</ul>
			</div>
			<!-- /#nav_utility -->					

			<!-- #nav_main -->
			<div id="nav_main">
				<ul class="clear">
					<li id="nav_experience" class="menu">
						<a href="http://www.jewishcamp.org/experience">Experience Jewish Camp</a>
						<!-- .overlay -->
						<div class="overlay" style="display: none;">
							<div class="overlay_content">
								<ul>
									<li><a href="http://www.jewishcamp.org/experience/why-jewish-camp">Why Jewish Camp?</a></li>
									<li><a href="http://www.jewishcamp.org/experience/summer-of-fun">A Summer of Fun</a></li>
									<li><a href="http://www.jewishcamp.org/experience/types-of-camps">Types of Camps</a></li>
									<li class="last"><a href="http://www.jewishcamp.org/experience/planning-and-preparation">Planning &amp; Preparation</a></li>
								</ul>
							</div>
						</div>
						<!-- /.overlay -->
					</li>
					<li class="menu" id="nav_help">
						<a href="http://www.jewishcamp.org/how-we-help">How We Help</a>
						<!-- .overlay -->
						<div class="overlay" style="display: none;">
								<div class="overlay_content">
									<ul>
										<li><a href="http://www.jewishcamp.org/how-we-help/grants-and-scholarships">Camper Grants &amp; Scholarships</a></li>
										<li><a href="http://www.jewishcamp.org/how-we-help/developing-professionals">Developing Professionals</a></li>
										<li><a href="http://www.jewishcamp.org/how-we-help/strengthening-camp">Strengthening Camp</a></li>
										<li><a href="http://www.jewishcamp.org/how-we-help/research">Research</a></li>
										<li><a href="http://www.jewishcamp.org/how-we-help/leaders-assembly">Leaders Assembly</a></li>
										<li class="last"><a href="http://www.jewishcamp.org/how-we-help/resource-library">Resource Library</a></li>
									</ul>
								</div>
						</div>
						<!-- /.overlay -->
					</li>
					<li id="nav_involved" class="menu">
						<a href="http://www.jewishcamp.org/get-involved">Get Involved</a>
						<!-- .overlay -->
						<div class="overlay" style="display: none;">
							<div class="overlay_content">
								<ul>
									<li><a href="http://www.jewishcamp.org/get-involved/donate">Donate</a></li>
									<li><a href="http://www.jewishcamp.org/get-involved/advocate">Advocate</a></li>
									<li><a href="http://www.jewishcamp.org/get-involved/work-at-camp">Work at Camp</a></li>
									<li class="last"><a href="http://www.jewishcamp.org/get-involved/camp-alumni">Camp Alumni</a></li>
								</ul>
							</div>
						</div>
						<!-- /.overlay -->
					</li>
					<li id="nav_about" class="menu">
						<a href="http://www.jewishcamp.org/foundation">The Foundation</a>
						<!-- .overlay -->
						<div class="overlay" style="display: none;">
							<div class="overlay_content">
								<ul>
									<li><a href="http://www.jewishcamp.org/foundation/mission-and-vision">Mission &amp; Vision</a></li>
									<li><a href="http://www.jewishcamp.org/foundation/fjc-story">The FJC Story</a></li>
									<li><a href="http://www.jewishcamp.org/foundation/our-team">Our Team</a></li>
									<li><a href="http://www.jewishcamp.org/foundation/news-and-media">News &amp; Media</a></li>
									<li><a href="http://www.jewishcamp.org/foundation/events">Events</a></li>
									<li class="last"><a href="/blog">Blog</a></li>
								</ul>
							</div>
						</div>
						<!-- /.overlay -->
					</li>
					<li id="nav_find"><a href="http://www.jewishcamp.org/camps" title="Find a Camp">Find a Camp</a></li>
				</ul>
			</div>
			<!-- /#nav_main -->
		
		</div>
		<!-- /#header -->
				
		<!-- #content -->
		<div id="content" class="apply_ohc clear">

			<!-- #sidebar -->
			<div id="sidebar">
				<div class="sidebar_content">
					<h2 class="ohc"><a href="http://www.jewishcamp.org//one-happy-camper/">One Happy Camper</a></h2>
					<ul>
						<li><a href="http://www.jewishcamp.org/one-happy-camper/about">About</a></li>
						<li><a href="http://www.jewishcamp.org/one-happy-camper/what-makes-a-camp-a-jewish-camp">What Makes a Camp<br />&nbsp;&nbsp;&nbsp;a Jewish Camp</a></li>	
						<li><a href="http://www.jewishcamp.org/camps">Find A Camp</a></li>
						<li><a href="http://www.jewishcamp.org/one-happy-camper/eligibility">Eligibility</a></li>
						<li><a href="http://www.jewishcamp.org/one-happy-camper/faqs">FAQs</a></li>
						<li><a href="http://www.jewishcamp.org/one-happy-camper/contact">Contact</a></li>
						<li class="active"><a href="http://www.jewishcamp.org/one-happy-camper/apply" target="_blank">Apply Today</a><br /></li>
						<li><a href="http://www.jewishcamp.org/blog/">Campfire Blog</a></li>
					</ul>
				</div>
			</div>
			<!-- /#sidebar -->

			<!-- #content_main -->
			<div id="content_main">

				<!-- .content_head -->
				<div class="content_head" id="ohc_apply">
					<h1 class="sifr">Apply Today</h1>		
				</div>
				<!-- /.content_head -->

				<!-- .content_belly -->
				<div class="content_belly clear">

				<!-- .block -->
				<div class="block">

					<!-- //////////////////////////////// BEGIN CONTENT HERE //////////////////////////////// -->
                 <div id="main" class="shadow">
                <div id="subcontent">
                   <%-- <h2>
                        Welcome to The Foundation for Jewish Camp's<br />
                        One Happy Camper Application.</h2>--%>
                    <p>
                        First time users - please select "New User". If you are returning to the system
                        - sign in as an "Existing User".</p>
                    <div id="application_col1">
                        <h4>
                            Tips before you begin:</h4>
                        <ol class="olBullets">
                            <li>Be sure you have carefully reviewed the <a class="aColor" href="http://www.jewishcamp.org/one-happy-camper/eligibility">eligibility</a>
                                criteria.</li>
                            <li>Have your camp and session information readily available as you will need both to
                                complete your application.</li>
                            <li>Need help selecting a camp? <a class="aColor" href="http://www.jewishcamp.org/camps"
                                    target="_blank">Find a camp</a> that's right for you.</li>
                        </ol>
                        <p class="pTips">
                            Russian-speakers please call:<br />
                            646-278-4572 for assistance in Russian.</p>
                    </div>
                    <div id="application_col2">
                        <p>
                            <asp:HyperLink ID="hpl" CssClass="aColor" Text="Existing User" runat="server" NavigateUrl="~/Home.aspx"></asp:HyperLink>
                        </p>
                        <p>
                            <asp:Label ID="lblErr" runat="server" CssClass="InfoText"></asp:Label>
                        </p>
                        
                        <p>
                            New User
                        </p>
                        <asp:ValidationSummary ID="vldsumErr" runat="server" CssClass="vldsumErr"></asp:ValidationSummary>
                        <div id="formbg">
                            <div id="formnames">
                                <br />  <p>
                                  Enter  Email:</p> <br /> 
                                <p>
                                  Create Password:</p>
                            </div>
                            <div id="formfields">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="txtbox1" Width="150px" MaxLength="150" />
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                    Display="None" ErrorMessage="Please enter Email ID" />
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                    Display="None" ErrorMessage="Please enter a valid e-mail ID" ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$" />
                                <br />
                                <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" CssClass="txtbox1" Width="150px"
                                    MaxLength="50" />
                                <asp:RequiredFieldValidator ID="rfvPwd" runat="server" ControlToValidate="txtPwd"
                                    Display="None" ErrorMessage="Please enter Password" />
                                <br />
                                <asp:Button ID="btnSubmit" runat="server" Text="Register" Width="100px" OnClick="btnSubmit_Click" />
                            </div>
                            <p class="clear">
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <!-- //////////////////////////////// END CONTENT HERE //////////////////////////////// -->

				</div>
				<!-- /.block -->

				</div>
				<!-- /.content_belly -->	

			</div>
			<!-- /#content_main -->

		</div>
		<!-- /#content -->
				
		</div>
		<!-- /#wrapper -->
		
	</div>
	<!-- #container -->
		
		<!-- #footer -->
			<div id="footer">
			<div class="footer_content clear">
				<div class="col_a">
					<ul class="clear">
						<li><a href="http://www.jewishcamp.org//experience">Experience Jewish Camp</a></li>
						<li><a href="http://www.jewishcamp.org//how-we-help">How We Help</a></li>
						<li><a href="http://www.jewishcamp.org//get-involved">Get Involved</a></li>
						<li><a href="http://www.jewishcamp.org//foundation">The Foundation</a></li>
						<li><a href="http://www.jewishcamp.org//camps">Find a Camp</a></li>
						<li><a href="http://www.jewishcamp.org//contact-us">Contact Us</a></li>
						<li><a href="http://www.jewishcamp.org//frequently-asked-questions">FAQs</a></li>
						<li class="last"><a href="http://www.jewishcamp.org//get-involved/donate">Donate</a></li>
					</ul>
					<ul id="social_links" class="clear">
						<li class="twitter"><a href="http://twitter.com/fdnjewishcamp" target="_blank">Follow us on Twitter!</a></li>
						<li class="facebook"><a href="http://www.facebook.com/foundationforjewishcamp?ref=ts" target="_blank">Become a Fan on Facebook!</a></li>
					</ul>
				</div>
				<div class="col_b ">
					<div class="clear">
						<ul class="clear">
							<li><a href="http://www.jewishcamp.org//sitemap">Sitemap</a></li>
							<li><a href="http://fjc.webfactional.com/blog/">Blog</a></li>
							<li><a href="http://www.jewishcamp.org//terms-of-use">Terms of Use</a></li>
							<li><a href="http://www.jewishcamp.org//privacy-policy">Privacy Policy</a></li>
						</ul>
					</div>
					<p>
						<a title="Website Design by Alexander Interactive" target="_blank" href="http://www.alexanderinteractive.com/">Website Design</a>
						<a title="Click to Visit Alexander Interactive" target="_blank" href="http://www.alexanderinteractive.com/">by Alexander Interactive</a>
					</p>
				</div>
			</div>
		</div>
		<!-- /#footer -->
		
           <%-- <div id="footer_sub">
                <div id="copyright">
                    &copy; 2010 Foundation for Jewish Camp. All rights reserved.</div>
                <div id="footer2_sub">
                    <a class="footer" href="http://www.jewishcamp.org/" target="_blank">Foundation for Jewish
                        Camp site</a> | <a class="footer" href="https://www.onehappycamper.org/contact.html"
                            target="_blank">Contact us</a> | <a class="footer" href="https://www.onehappycamper.org/terms.html"
                                target="_blank">Terms</a> | <a class="footer" href='<% = this.ResolveClientUrl("home.aspx")%>'
                                    target="_blank">Apply Now</a></div>
                <div id="footer3_sub">
                    <a href="http://twitter.com/JewishCamp" target="_blank">
                        <img style="border: none;" src='<% = this.ResolveClientUrl("images/twitter_logo.gif") %>' /></a>
                    <a href="http://www.facebook.com/foundationforjewishcamp" target="_blank">
                        <img style="border: none;" src='<%= this.ResolveClientUrl("images/facebook_logo.gif") %>' /></a></div>
            </div>--%>
       <div id="modal_overlay" style="display: none;"><!-- --></div>
	
		<script type="text/javascript" src='<%= this.ResolveClientUrl("~/js/lib/prototype/prototype.js") %>'></script>
		<script type="text/javascript" src='<%= this.ResolveClientUrl("~/js/lib/scriptaculous/scriptaculous.js") %>'></script>
		<script type="text/javascript" src='<%= this.ResolveClientUrl("~/js/lib/sifr/sifr.js") %>'></script>
		<script type="text/javascript" src='<%= this.ResolveClientUrl("~/js/lib/sifr/sifr-config.js") %>'></script>
		<script type="text/javascript" src='<%= this.ResolveClientUrl("~/js/base.js") %>'></script>
		<script type="text/javascript" src='<%= this.ResolveClientUrl("~/js/elements.js") %>'></script>
		<script type="text/javascript" src='<%= this.ResolveClientUrl("~/js/toggle.js") %>'></script>
    </form>
    <!-- Google Code for begin registration Conversion Page -->
<script type="text/javascript">
/* <![CDATA[ */
var google_conversion_id = 1033664268;
var google_conversion_language = "en";
var google_conversion_format = "1";
var google_conversion_color = "ffffff";
var google_conversion_label = "O1L0CMKlqgEQjO7x7AM";
var google_conversion_value = 0;
/* ]]> */
</script>
<script type="text/javascript" src="https://www.googleadservices.com/pagead/conversion.js">
</script>
<noscript>
<div style="display:inline;">
<img height="1" width="1" style="border-style:none;" alt="" src="https://www.googleadservices.com/pagead/conversion/1033664268/?label=O1L0CMKlqgEQjO7x7AM&amp;guid=ON&amp;script=0"/>
</div>
</noscript>


</body>
</html>
