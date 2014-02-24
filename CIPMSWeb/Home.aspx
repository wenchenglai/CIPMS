<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" class="blog_html js" lang="en">
<head>
        <link rel="shortcut icon" href="http://www.jewishcamp.org/sites/all/themes/FJC/favicon.ico" type="image/x-icon">
        <title>One Happy Camper | FJC</title>
        <link type="text/css" rel="stylesheet" media="all" href="FJC_files/css_9c3e26234a81a9d4b9acf79abdc51004.css">
        <script type="text/javascript" src="FJC_files/js_a5af4da379b61574b974ddfbaceb68c2.js"></script>
        <script type="text/javascript" src="FJC_files/jquery.colorbox.js"></script>

<%--<link type="text/css" rel="stylesheet" media="all" href="css/reset.css">
<link type="text/css" rel="stylesheet" media="all" href="css/style.css">
<link type="text/css" rel="stylesheet" media="all" href="css/blog_styles.css">
<link type="text/css" rel="stylesheet" media="all" href="css/base.css">
<link type="text/css" rel="stylesheet" media="all" href="css/print.css">
<link type="text/css" rel="stylesheet" media="all" href="css/common.css">
<link type="text/css" rel="stylesheet" media="all" href="css/home.css">--%>
<link type="text/css" rel="stylesheet" media="all" href="css/interior.css">

  <link rel="stylesheet" type="text/css" href="Style/mainHome.css" />	
</head>

<body class="body not-front logged-in page-node node-type-ohc-navigation one-sidebar sidebar-left  sIFR-active">
    <div id="container" class="clearfix">
        <!-- #wrapper -->
        <div id="wrapper">
            <header role="banner" class="clearfix">
                <!-- #header -->
                <div id="header" class="clear">
                    <a href="/" title="Foundation for Jewish Camp Home" id="logo"> <img src="FJC_files/logo_new.png" alt="Foundation for Jewish Camp" height="213" width="160" /> </a> <a href="http://www.jewishcamp.org/" title="Foundation for Jewish Camp Home" id="logo_ie6"> <img src="FJC_files/logo_8bit.png" alt="Foundation for Jewish Camp" height="180" width="137" /> </a>
                    <!-- #nav_ohc -->
                    <div id="nav_ohc" style="display:none "> <a href="" title="One Happy Camper">One Happy Camper</a> </div>
                    <!-- /#nav_ohc -->
                        <div id="nav_utility" class="display">
                            <ul class="display">
                                <li id="nav_aboutfjc"><a href="http://www.jewishcamp.org/about-fjc" title="About FJC">About FJC</a></li>
                                <li id="nav_blog"><a href="http://www.jewishcamp.org/blog" title="Blog" target="_blank">Blog</a></li>

                                <li><a href="http://www.jewishcamp.org/contact-us" title="Contact Us">Contact Us</a></li>
                                <li id="nav_donate"><a href="http://www.jewishcamp.org/donate" title="Donate">Donate</a></li>
                            </ul>
                        </div>  
                    <!-- /#nav_utility -->
                    <!-- #nav_main -->
                    <div id="nav_main" class="nav_main_ohc">

                        <script>
                            $(document).ready(function () {
                                $('#menu li.menu a').mouseenter(function () {
                                    $(this).next().slideDown("slow");
                                })
                                $('#menu li.menu').mouseleave(function () {
                                    $(this).children().next().slideUp("500");
                                })

                                //                    $('#menu li.menu a').mouseout(function() {
                                //                      $(this).next().toggle("500");
                                //                    })

                            });
                        </script>
                        <style>
                            #menu .overlay_content li div.mm-item-content {
                                display: none;
                            }
                        </style>
                        <div id="menu">
                                <ul class="sf-menu overlay_content last">
                                    <li id="nav_parents_on" class="menu activee"><a href="http://www.jewishcamp.org/one-happy-camper" title="Parents"></a>
                                    </li>
                                    <li id="nav_about" class="menu "> <a href="http://www.jewishcamp.org/find-camp-2" title="Find a Camp">FIND A CAMP<span class="top-nav-info">Learn More</span></a>
                                        <!-- .overlay -->
                                        <div class="mm-item-content overlay"><ul class="overlay_content"><li class=""><a href="http://www.jewishcamp.org/why-camp" title="Why Camp?">Why Camp?</a></li><li class="last"><a href="http://www.jewishcamp.org/types-camp" title="Types of Camp">Types of Camp</a></li></ul> </div>                                                <!-- /.overlay -->
                                    </li>
                                    <li class="menu " id="nav_camps"> <a href="http://www.jewishcamp.org/one-happy-camper-2">ONE HAPPY CAMPER<span class="top-nav-info">First-Time Camper Grants</span></a>
                                        <!-- .overlay -->
                                        <div class="mm-item-content overlay"><ul class="overlay_content"><li class=""><a href="http://www.jewishcamp.org/happy-camper-eligibility" title="Eligibility">Eligibility</a></li><li class=""><a href="http://www.jewishcamp.org/apply-grant-0" title="Apply">Apply</a></li><li class="last"><a href="http://www.jewishcamp.org/one-happy-camper-faqs" title="FAQ">FAQ</a></li></ul> </div>                                                <!-- /.overlay -->
                                    </li>
                                    <li id="nav_communities" class="menu "> <a href="https://bunkconnect.org/ui/Home/Index#start" target="_blank">BUNKCONNECT<span class="top-nav-info">Introductory Rates</span></a>
                                        <!-- .overlay -->
                                        <!-- /.overlay -->
                                    </li>
                                    <li id="nav_support" class="menu "> <a href="http://www.jewishcamp.org/camper-scholarships">SCHOLARSHIP</a>
                                        <!-- .overlay -->
                                        <!-- /.overlay -->
                                    </li>
                                </ul>
                        </div><!-- /#nav_menu -->
                    </div>
                    <!-- /#nav_main -->
                </div>
                <!-- /#header -->


            </header> <!-- /#header -->
            <!-- #content -->

            <div id="content" class="experience clear">
                <section id="" role="main" class="clearfix">
                    <!-- #sidebar -->
                    <div id="sidebar">
                        <div class="sidebar_content"><a href="http://www.jewishcamp.org/one-happy-camper"><img title="One Happy Camper" src="FJC_files/img/ohc-menu-logo.gif" class="OHC_logo_sidebar" /></a><ul><li class="active"><a href="http://www.jewishcamp.org/find-camp-2" title="">Find a Camp  >></a></li><li class="second_links"><a href="http://www.jewishcamp.org/why-camp" title="">Why Camp?</a></li><li class="second_links"><a href="http://www.jewishcamp.org/types-camp" title="">Types of Camp</a></li><li><a href="http://www.jewishcamp.org/one-happy-camper-2" title="">One Happy Camper  >></a></li><li><a href="http://www.jewishcamp.org/bunkconnect" title="">BunkConnect</a></li><li><a href="http://www.jewishcamp.org/camper-scholarships" title="">Camper Scholarships</a></li></ul></div>
                    </div><!-- /#sidebar -->	<!-- #content_main -->
                    <div id="content_main">
                        <div class="message_padding">
                        </div>
                        <a id="main-content"></a>


                        <div class="content">
                            <!-- .SLIDE -->
                            <div class="wrapper" id="OHCslideShow">
                            </div>
                            <!-- .content_belly -->
                            <div class="clear">
                                <!--.modules Landing Page Touts -->
                                <div class="clear ohc_content_main">

                                    <!-- //////////////////////////////// BEGIN CONTENT HERE //////////////////////////////// -->
                                    <form id="formLogin" runat="server" style="display:block">
                                        <div id="Div1">

                                            <!-- .content_head -->
                                            <div class="content_head" id="ohc_apply3">
                                                <h1 class="sifr">Apply Today</h1>
                                            </div>
                                            <!-- /.content_head -->
                                            <!-- .content_belly -->
                                            <div class="content_belly clear">

                                                <!-- .block -->
                                                <div class="block">

                                                    <div id="main" class="shadow">
                                                        <div id="subcontent">

                                                            <script language="javascript" type="text/javascript">
                                                                function RemovePasswordValidation() {
                                                                    var PasswordValidator = document.getElementById('<%=rfvPwd.ClientID %>');
                                                                    alert(PasswordValidator.id)

                                                                }
                                                            </script>

                                                            <div id="application_col1">
                                                                <h4 style="font-weight:normal; margin-top:0em;">
                                                                    Tips before you begin:
                                                                </h4>
                                                                <ol class="olBullets">
                                                                    <li>
                                                                        Be sure you have carefully reviewed the <a class="aColor" href="http://www.jewishcamp.org/one-happy-camper/eligibility"
                                                                                                                    target="_blank">eligibility</a> criteria.
                                                                    </li>
                                                                    <li>
                                                                        Have your camp and session information readily available as you will need both to
                                                                        complete your application.
                                                                    </li>
                                                                    <li>
                                                                        Need help selecting a camp? <a class="aColor" href="http://www.jewishcamp.org/find-camp"
                                                                                                        target="_blank">Find a camp</a> that's right for you.
                                                                    </li>
                                                                </ol>
                                                                <p class="pTips">
                                                                    Russian-speakers please call:<br />
                                                                    646-278-4572 for assistance in Russian.
                                                                </p>
                                                            </div>
                                                            <div id="application_col2">

                                                                <p>
                                                                    <asp:Label ID="lblErr" runat="server" CssClass="InfoText" />
                                                                    <asp:ValidationSummary ID="vldsumErr1" runat="server" CssClass="vldsumErr"></asp:ValidationSummary>
                                                                </p>
                                                                <asp:Label ID="lblUAT" runat="server" ForeColor="Red" Font-Size="Large" Text="CAMPER UAT" Visible="false"></asp:Label>
                                                                <p style="width:500px">New to One Happy Camper? Create an Account:</p>
                                                                <asp:Panel runat="server" DefaultButton="btnSubmit1" ID="pnlRegistration">
                                                                    <div id="formbg">
                                                                        <div id="formnames">
                                                                            <br />  <p style="margin:0 0 6px 0;">
                                                                                Enter  Email:
                                                                            </p>
                                                                            <p style="margin:0 0 6px 0;">
                                                                                Confirm  Email:
                                                                            </p>
                                                                            <p style="margin:0 0 8px 0;">
                                                                                Create Password:
                                                                            </p>
                                                                            <p style="margin:0 0 0 0;">
                                                                                Confirm Password:
                                                                            </p>
                                                                        </div>
                                                                        <div id="formfields">
                                                                            <asp:TextBox ID="txtEmail1" runat="server" CssClass="txtEmail1" Width="150px" MaxLength="150" />
                                                                            <asp:RequiredFieldValidator ID="rfvEmailNew" runat="server" ControlToValidate="txtEmail1" Display="None" ErrorMessage="Please enter Email ID" />
                                                                            <asp:RegularExpressionValidator ID="revEmailNew" runat="server" ControlToValidate="txtEmail1" Display="None" ErrorMessage="Please enter a valid e-mail ID" ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$" />
                                                                            <br />
                                                                            <asp:TextBox ID="txtCfrmEmail" runat="server" CssClass="txtbox1" Width="150px" MaxLength="150" />
                                                                            <asp:RequiredFieldValidator ID="rfvCfrmEmail" runat="server" ControlToValidate="txtCfrmEmail" Display="None" ErrorMessage="Please enter confirm Email ID" />
                                                                            <asp:RegularExpressionValidator ID="revCfrmEmail" runat="server" ControlToValidate="txtCfrmEmail" Display="None" ErrorMessage="Please enter a valid e-mail ID" ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$" />
                                                                            <asp:CompareValidator ID="cmprEmail" runat="server" ErrorMessage="Please confirm Email ID" ControlToValidate="txtCfrmEmail" ControlToCompare="txtEmail1" Display="None" />
                                                                            <br />
                                                                            <asp:TextBox ID="txtPwd1" runat="server" TextMode="Password" CssClass="txtPwd" Width="150px" MaxLength="50" />
                                                                            <asp:RequiredFieldValidator ID="rfvPwd1" runat="server" ControlToValidate="txtPwd1" Display="None" ErrorMessage="Please enter Password" />
                                                                            <br />
                                                                            <asp:TextBox ID="txtPwd2" runat="server" TextMode="Password" CssClass="txtPwd" Width="150px" MaxLength="50" />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPwd2" Display="None" ErrorMessage="Please confirm password" />
                                                                            <asp:CompareValidator ID="adf" runat="server" ControlToCompare="txtPwd1" ControlToValidate="txtPwd2" Display="None" ErrorMessage="Passwords don't match" />
                                                                            <br />
                                                                            <b>  <asp:Button ID="btnSubmit1" runat="server" Text="Register>>" Width="100px" OnClick="btnSubmit1_Click" /></b>

                                                                        </div>
                                                                        <p class="clear">
                                                                        </p>
                                                                    </div>
                                                                </asp:Panel>
                                                                <br /><br />
                                                                <p>
                                                                    <asp:ValidationSummary ValidationGroup="Submit" ID="vldsumErr" runat="server" CssClass="vldsumErr" />
                                                                    <asp:ValidationSummary ValidationGroup="forgot" ID="ValidationSummary1" runat="server" CssClass="vldsumErr" />
                                                                </p>
                                                                <p>Already have an account? Sign in:</p>
                                                                <asp:Panel runat="server" DefaultButton="btnSubmit" ID="pnlLogin">
                                                                    <div id="formbg1">
                                                                        <div id="formnames1">
                                                                            <p style="margin:0 0 0 0;">
                                                                                Email:
                                                                            </p><br />

                                                                            <asp:TextBox MaxLength="150" ID="Email" runat="server" CssClass="txtbox1" />
                                                                            <asp:RequiredFieldValidator ValidationGroup="Submit" ID="rfvEmail" runat="server" ControlToValidate="Email" Display="None" ErrorMessage="Please enter Email ID" />
                                                                            <asp:RegularExpressionValidator ValidationGroup="Submit" ID="revEmail" runat="server"
                                                                                                            ControlToValidate="Email" Display="None" ErrorMessage="Please enter a valid e-mail ID"
                                                                                                            ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$" />
                                                                            <asp:RequiredFieldValidator ValidationGroup="forgot" ID="rfvEmail1" runat="server"
                                                                                                        ControlToValidate="Email" Display="None" ErrorMessage="Please enter Email ID" />
                                                                            <asp:RegularExpressionValidator ValidationGroup="forgot" ID="revEmail1" runat="server"
                                                                                                            ControlToValidate="Email" Display="None" ErrorMessage="Please enter a valid e-mail ID"
                                                                                                            ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$" />


                                                                        </div>
                                                                        <div id="formfields1">
                                                                            <p style="margin:0 0 0 0;">Password:</p>
                                                                            <br />
                                                                            <asp:TextBox TextMode="Password" MaxLength="50" ID="Password" runat="server" CssClass="txtbox1" />
                                                                            <asp:RequiredFieldValidator ValidationGroup="Submit" ID="rfvPwd" runat="server" ControlToValidate="Password" Display="None" ErrorMessage="Please enter Password" />
                                                                            <br />
                                                                            <asp:Button Text="Login >>" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidationGroup="Submit" />
                                                                            <asp:LinkButton Text="Forgot Password >>" ID="btnForgot" runat="server" OnClick="btnForgot_Click" CssClass="forgotButton" ValidationGroup="forgot" />
                                                                        </div>
                                                                        <p class="clear" />
                                                                    </div>
                                                                </asp:Panel>
                                                                <input type="hidden" runat="server" id="hdnRedirectURL" />
                                                            </div>
                                                        </div>
                                                    </div>


                                                </div>
                                                <!-- /.block -->

                                            </div>
                                            <!-- /.content_belly -->

                                        </div>
                                        <!-- /#content_main -->

                                    </form>
                                    <!-- //////////////////////////////// END CONTENT HERE //////////////////////////////// -->

                                </div>
                                <!--/.modules -->
                            </div>
                            <!-- /.content_belly -->
                        </div>
                    </div>
                    <!-- /#content_main -->
                </section> <!-- /#main -->
            </div>
        </div>
        <!-- /#wrapper -->
    </div> <!-- /#container -->

    <div id="footer" role="contentinfo" class="clearfix">
        <div id="footer_inner">
            <div class="footer_content">
                <div id="search_area">
                    <div class="title_search">Can't find something? </div>
                    <form method="post" action="/search/node">
                        <div class="search_box">
                            <div class="search_img">
                                <img src="FJC_files/img/icon-search.gif" alt="Search." width="15" height="13">
                            </div>
                            <input type="text" name="keys" value="Search" title="Search" onfocus="ClearEmailText(this);" onblur="SetEmailText(this);">
                        </div><!-- /search_box -->
                        <div class="submit_box"><input type="submit" value="Submit" src="FJC_files/img/btn-submit.gif"></div>
                    </form>
                </div><!-- /search_area -->
                <div id="footer_navigation">
                    <div class="first_column">
                        <a href="http://www.jewishcamp.org/about-fjc">About</a>
                        <a href="http://www.jewishcamp.org/node/87">Camps</a>
                        <a href="http://www.jewishcamp.org/community">Communities</a>
                        <a href="http://www.jewishcamp.org/donate">Donate</a>
                        <a href="http://www.jewishcamp.org/blog">Blog</a>
                        <a href="http://www.jewishcamp.org/one-happy-camper">Parents: One Happy Camper</a>
                    </div>
                    <div class="second_column">
                        <a href="http://www.jewishcamp.org/camp-jobs">Camp Jobs</a>
                        <a href="http://www.jewishcamp.org/leaders-assembly">Leaders Assembly</a>
                        <a href="http://www.jewishcamp.org/research">Research</a>
                        <a href="http://www.jewishcamp.org/contact-us">Contact Us</a>
                    </div>
                </div><!-- /#footer_Navigation -->
                <div id="social_links">
                    <div class="fb_link"><a href="http://www.facebook.com/foundationforjewishcamp?ref=ts" target="_blank" title="Like us on Facebook"></a></div>
                    <div class="twitter_link"><a href="http://twitter.com/JewishCamp" target="_blank" title="Follow us on Twitter"></a></div>
                    <div class="third_column">
                        <a href="http://www.jewishcamp.org/site-map">Site Map</a>
                        <a href="http://www.jewishcamp.org/terms-use">Terms of Use</a>
                        <a href="http://www.jewishcamp.org/privacy-policy">Privacy Policy</a>

                    </div>
                </div><!-- /#social_links -->
            </div><!-- /.footer_content -->
        </div> <!-- /#footer_inner -->
    </div> <!-- /#footer -->
    
    <!-- google analytics -->
    <script type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>
    <script type="text/javascript">
        try {
            var pageTracker = _gat._getTracker("UA-4980239-1");
            pageTracker._trackPageview();
        } catch (err) {
        }
    </script>
    <!-- /google analytics -->
</body>
</html>
