<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Enrollment_Summary" %>

<asp:Content ID="National_summary" ContentPlaceHolderID="Content" Runat="Server">
   <asp:Panel ID="Panel1" runat="server">
        <!--to display the validation summary (error messages)-->
        <table width="75%" cellpadding="0" cellspacing="0" border="0" align="center">
            <tr>
                <td>
                    <asp:CustomValidator ID="CusVal" runat="server" Display="Dynamic" CssClass="InfoText"></asp:CustomValidator>
                    <!--this summary will be used only for Comments field (only for Admin user)-->
                    <asp:ValidationSummary ID="valSummary1" ValidationGroup="CommentsGroup" runat="server" ShowSummary="true" CssClass="InfoText" />
                    <asp:CustomValidator ID="CusValComments" runat="server" Display="Dynamic" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
                </td>
            </tr>
        </table>
        <table width="100%" cellpadding="1" cellspacing="0" border="0">
            <tr>
                
                <td>
                    <asp:Label ID="Label2" runat="server" CssClass="headertext3">
                    <p style="text-align:center">
                        Welcome camper family!<br />
                        We are thrilled that you are interested in Jewish camp!</p>
                     </asp:Label>
                </td>
            </tr> 
             <tr>                
                <td >&nbsp;                    
                </td>
            </tr>                      
            <tr>            
                <td>
                <asp:Label ID="Label3" runat="server" CssClass="QuestionText">
                    <p style="text-align:justify">
                        The Foundation for Jewish Camp is partnering with dozens of camps and communities through 
                        the Campership Incentive Program to offer incentive grants to first time campers. In 
                        addition to the community-based programs, <b>there are a number of camps which offer national 
                        incentive programs that are open to campers who live anywhere in the United States.</b> 
                    </p>
                </asp:Label>
                </td>
             </tr>
            <tr>            
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="QuestionText">
                    <br /><p style="text-align:justify">
                        While each community partner has its own particular eligibility requirements, the 
                        general eligibility requirements that are adhered to by all partners are as follows:
                    </p>
                    <ol style="list-style:1">
                        <li>Campers must have never previously attended a nonprofit Jewish overnight summer camp for 3 consecutive weeks or longer</li>
                        <li>Campers must attend a camp listed on the Foundation for Jewish Camp’s website (For a full listing of these camps, please visit the <a href="http://www.jewishcamp.org/fjc/global/find_a_jewish_camp.asp?section=grants" target= "_blank">Find a Camp directory</a>)</li>
                        <li>Campers must attend camp for at least 21 consecutive days</li></ol>
                    <p style="text-align:justify" class="headertext1">
                        <u>For full eligibility details or questions about existing programs, please visit the websites or email the contacts listed below.</u></p>
                    <p style="text-align:justify">
                        Please note: Campers who have been accepted to the JWest Campership Program are NOT eligible for the Campership Incentive Program and vice versa.</p>
                </asp:Label><br /></td>
             </tr>
             <tr>                
                <td align="center">
                    <asp:Label ID="Label17" runat="server" CssClass="headertext3">
                    <p style="text-align:center">
                        <font color="red"><u>2010 Campership Incentive Program Partners</u></font></p>
                     </asp:Label><br />
                </td>
            </tr> 
             <tr>
                <td><table width="100%" cellpadding="1" cellspacing="0" border="1">
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label5" runat="server" CssClass="QuestionText"><b>Community/Camp</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label6" runat="server" CssClass="QuestionText"><b>Contact</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label7" runat="server" CssClass="QuestionText"><b>Contact Email</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label8" runat="server" CssClass="QuestionText"><b>Website</b></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label9" runat="server" CssClass="QuestionText"><b>Arkansas</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label10" runat="server" CssClass="QuestionText">Rita Fagan</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label11" runat="server" CssClass="QuestionText"><a href="mailto:ritafagan@att.net" target="_blank">ritafagan@att.net</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label12" runat="server" CssClass="QuestionText">&nbsp;</asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label13" runat="server" CssClass="QuestionText"><b>Baltimore</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label14" runat="server" CssClass="QuestionText">Renee Dain</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label15" runat="server" CssClass="QuestionText"><a href="mailto:rdain@associated.org" target="_blank">rdain@associated.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label16" runat="server" CssClass="QuestionText"><a href="http://www.associated.org/camp" target="_blank">www.associated.org/camp</a></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label18" runat="server" CssClass="QuestionText"><font color="red"><b>B’nai B’rith Camp (OR)*</b></font></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label19" runat="server" CssClass="QuestionText">Michelle Koplan</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label22" runat="server" CssClass="QuestionText"><a href="mailto:mkoplan@oregonjcc.org" target="_blank">mkoplan@oregonjcc.org </a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label23" runat="server" CssClass="QuestionText"><a href="http://www.bbcamp.org" target="_blank">www.bbcamp.org</a></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label24" runat="server" CssClass="QuestionText"><b>Boston</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label25" runat="server" CssClass="QuestionText">Ed Pletman</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label26" runat="server" CssClass="QuestionText"><a href="mailto:edp@cjp.org" target="_blank">edp@cjp.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label27" runat="server" CssClass="QuestionText"><u>Boston Information Site</u></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label28" runat="server" CssClass="QuestionText"><b>Camp JRF (PA)</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label29" runat="server" CssClass="QuestionText">Rabbi Isaac Saposnik</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label30" runat="server" CssClass="QuestionText"><a href="mailto:isaposnik@jrf.org" target="_blank">isaposnik@jrf.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label31" runat="server" CssClass="QuestionText"><a href="http://www.campjrf.org" target="_blank">www.campjrf.org</a></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label32" runat="server" CssClass="QuestionText"><font color="red"><b>Camp Laurelwood (CT)*</b></font></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label33" runat="server" CssClass="QuestionText">Ruth Ann Ornstein</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label34" runat="server" CssClass="QuestionText"><a href="mailto:director@camplaurelwood.com" target="_blank">director@camplaurelwood.com</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label35" runat="server" CssClass="QuestionText"><a href="http://www.camplaurelwood.org " target="_blank">www.camplaurelwood.org</a></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label127" runat="server" CssClass="QuestionText"><font color="red"><b>Camp Nageela Midwest (IN)*</b></font></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label128" runat="server" CssClass="QuestionText">Yitzchok Ehrman</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label129" runat="server" CssClass="QuestionText"><a href="mailto:yehrman@campnageelamidwest.org" target="_blank">yehrman@campnageelamidwest.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label130" runat="server" CssClass="QuestionText"><a href="http://www.campnageelamidwest.org" target="_blank">www.campnageelamidwest.org</a></asp:Label></td>
                </tr>

                <tr>
                    <td style="height: 21px"><asp:Label ID="Label36" runat="server" CssClass="QuestionText"><font color="red"><b>Camp Sabra (MO)*</b></font></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label37" runat="server" CssClass="QuestionText">Terri Grossman</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label38" runat="server" CssClass="QuestionText"><a href="mailto:tgrossman@jccstl.org" target="_blank">tgrossman@jccstl.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label39" runat="server" CssClass="QuestionText"><a href="http://www.campsabra.com" target="_blank">www.campsabra.com</a></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label40" runat="server" CssClass="QuestionText"><b>Capital Camps (MD)</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label41" runat="server" CssClass="QuestionText">Jon Shapiro</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label42" runat="server" CssClass="QuestionText"><a href="mailto:jon@capitalcamps.org" target="_blank">jon@capitalcamps.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label43" runat="server" CssClass="QuestionText"><a href="http://www.capitalcamps.org " target="_blank">www.capitalcamps.org </a></asp:Label></td>
                </tr>                
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label44" runat="server" CssClass="QuestionText"><b>Chicago</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label45" runat="server" CssClass="QuestionText">Todd Bodenstein</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label46" runat="server" CssClass="QuestionText"><a href="mailto:info@campership.net" target="_blank">info@campership.net</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label47" runat="server" CssClass="QuestionText"><a href="http://www.campership.net" target="_blank">www.campership.net </a></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label48" runat="server" CssClass="QuestionText"><b>Cincinnati</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label49" runat="server" CssClass="QuestionText">Jeff Baden</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label50" runat="server" CssClass="QuestionText"><a href="mailto:jbaden@jfedcin.org" target="_blank">info@campership.net</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label51" runat="server" CssClass="QuestionText">&nbsp;</asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label52" runat="server" CssClass="QuestionText"><b>Columbus</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label53" runat="server" CssClass="QuestionText">Nancy Rosen</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label54" runat="server" CssClass="QuestionText"><a href="mailto:nrosen@tcjf.org" target="_blank">nrosen@tcjf.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label55" runat="server" CssClass="QuestionText">&nbsp;</asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label56" runat="server" CssClass="QuestionText"><b>Dallas</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label57" runat="server" CssClass="QuestionText">Miranda Winer</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label58" runat="server" CssClass="QuestionText"><a href="mailto:jewishcamping@jfgd.org" target="_blank">jewishcamping@jfgd.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label59" runat="server" CssClass="QuestionText">&nbsp;</asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label60" runat="server" CssClass="QuestionText"><b>Greensboro</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label61" runat="server" CssClass="QuestionText">Rachel Wolf</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label62" runat="server" CssClass="QuestionText"><a href="mailto:rwolf@shalomgreensboro.org" target="_blank">rwolf@shalomgreensboro.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label63" runat="server" CssClass="QuestionText">&nbsp;</asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label64" runat="server" CssClass="QuestionText"><b>Indianapolis</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label65" runat="server" CssClass="QuestionText">Carolyn Leeds</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label66" runat="server" CssClass="QuestionText"><a href="mailto:cleeds@jfgi.org" target="_blank">cleeds@jfgi.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label67" runat="server" CssClass="QuestionText"><u>Indianapolis Information Site</u></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label131" runat="server" CssClass="QuestionText"><font color="red"><b>JCC Ranch Camp (CO)*</b></font></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label132" runat="server" CssClass="QuestionText">Miriam and Gilad Shwartz</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label133" runat="server" CssClass="QuestionText"><a href="mailto:gshwartz@jccdenver.org" target="_blank">gshwartz@jccdenver.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label134" runat="server" CssClass="QuestionText"><a href="http://www.ranchcamp.org" target="_blank">www.ranchcamp.org</a></asp:Label></td>
                </tr>                                                                     
                                                                     
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label68" runat="server" CssClass="QuestionText"><b>Kansas City</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label69" runat="server" CssClass="QuestionText">Karen Gerson</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label70" runat="server" CssClass="QuestionText"><a href="mailto:kareng@jewishkc.org" target="_blank">kareng@jewishkc.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label71" runat="server" CssClass="QuestionText">&nbsp;</asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label72" runat="server" CssClass="QuestionText"><b>Los Angeles</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label73" runat="server" CssClass="QuestionText">Yael Green</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label74" runat="server" CssClass="QuestionText"><a href="mailto:ygreen@jewishla.org " target="_blank">ygreen@jewishla.org </a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label75" runat="server" CssClass="QuestionText"><a href="http://www.jewishla.org/camp.cfm" target="_blank">www.jewishla.org/camp.cfm</a></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label76" runat="server" CssClass="QuestionText"><b>MetroWest, NJ</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label77" runat="server" CssClass="QuestionText">Robert Lichtman</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label78" runat="server" CssClass="QuestionText"><a href="mailto:Rlichtman@thepartnershipnj.org" target="_blank">Rlichtman@thepartnershipnj.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label79" runat="server" CssClass="QuestionText">&nbsp;</asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label80" runat="server" CssClass="QuestionText"><b>Middlesex, NJ</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label81" runat="server" CssClass="QuestionText">Carolyn Tallman</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label82" runat="server" CssClass="QuestionText"><a href="mailto:ctallman@jf-gmc.org" target="_blank">ctallman@jf-gmc.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label83" runat="server" CssClass="QuestionText">&nbsp;</asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label84" runat="server" CssClass="QuestionText"><b>Montreal</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label85" runat="server" CssClass="QuestionText">Elizabeth Perez</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label86" runat="server" CssClass="QuestionText"><a href="mailto:Elizabeth.perez@federationcja.org" target="_blank">Elizabeth.perez@federationcja.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label87" runat="server" CssClass="QuestionText">&nbsp;</asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label88" runat="server" CssClass="QuestionText"><b>New Hampshire</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label89" runat="server" CssClass="QuestionText">Paula Silver</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label90" runat="server" CssClass="QuestionText"><a href="mailto:paulas@jewishnh.org" target="_blank">paulas@jewishnh.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label91" runat="server" CssClass="QuestionText">&nbsp;</asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label92" runat="server" CssClass="QuestionText"><font color="red"><b>New Jersey Y Camps (NJ)*</b></font></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label93" runat="server" CssClass="QuestionText">Janet Fliegelman</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label94" runat="server" CssClass="QuestionText"><a href="mailto:janet@njycamps.org" target="_blank">janet@njycamps.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label95" runat="server" CssClass="QuestionText">&nbsp;</asp:Label></td>
                </tr>                
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label96" runat="server" CssClass="QuestionText"><b>New York</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label97" runat="server" CssClass="QuestionText">Rachel Kaplan</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label98" runat="server" CssClass="QuestionText"><a href="mailto:campership@ujafedny.org" target="_blank">campership@ujafedny.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label99" runat="server" CssClass="QuestionText"><u>New York Information Site</u></asp:Label></td>
                </tr>                
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label135" runat="server" CssClass="QuestionText"><b>North Shore Teen Initiative</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label136" runat="server" CssClass="QuestionText">Adam Smith</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label137" runat="server" CssClass="QuestionText"><a href="mailto:adam@nsteeninitiative.org" target="_blank">adam@nsteeninitiative.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label138" runat="server" CssClass="QuestionText"><a href="http://www.nsteeninitiative.org" target="_blank">www.nsteeninitiative.org</a></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label100" runat="server" CssClass="QuestionText"><b>Orange County</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label101" runat="server" CssClass="QuestionText">Chelle Friedman</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label102" runat="server" CssClass="QuestionText"><a href="mailto:chelle@jfoc.org" target="_blank">chelle@jfoc.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label103" runat="server" CssClass="QuestionText"><a href="http://www.jewishorangecounty.org/camping" target="_blank">www.jewishorangecounty.org/camping</a></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label104" runat="server" CssClass="QuestionText"><b>Palm Beach</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label105" runat="server" CssClass="QuestionText">Lesley Levin</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label106" runat="server" CssClass="QuestionText"><a href="mailto:Lesley.levin@jewishpalmbeach.org" target="_blank">Lesley.levin@jewishpalmbeach.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label107" runat="server" CssClass="QuestionText">&nbsp;</asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label108" runat="server" CssClass="QuestionText"><b>Philadelphia</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label109" runat="server" CssClass="QuestionText">Brian Mono</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label110" runat="server" CssClass="QuestionText"><a href="mailto:info@philafederation.org" target="_blank">info@philafederation.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label111" runat="server" CssClass="QuestionText"><a href="http://www.jewishphilly.org/campincentive" target="_blank">www.jewishphilly.org/campincentive</a></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label112" runat="server" CssClass="QuestionText"><b>Toronto</b></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label113" runat="server" CssClass="QuestionText">Ron Polster</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label114" runat="server" CssClass="QuestionText"><a href="mailto:rpolster@ujafed.org" target="_blank">rpolster@ujafed.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label115" runat="server" CssClass="QuestionText">&nbsp;</asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label116" runat="server" CssClass="QuestionText"><font color="red"><b>Union for Reform Judaism*</b></font></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label117" runat="server" CssClass="QuestionText">Miriam Chilton</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label118" runat="server" CssClass="QuestionText"><a href="mailto:mchilton@urj.org" target="_blank">mchilton@urj.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label119" runat="server" CssClass="QuestionText">&nbsp;</asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 21px"><asp:Label ID="Label120" runat="server" CssClass="QuestionText"><font color="red"><b>Young Judaea*</b></font></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label121" runat="server" CssClass="QuestionText">Bair Gershenson</asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label122" runat="server" CssClass="QuestionText"><a href="mailto:bgershenson@youngjudaea.org" target="_blank">bgershenson@youngjudaea.org</a></asp:Label></td>
                    <td style="height: 21px"><asp:Label ID="Label123" runat="server" CssClass="QuestionText"><a href="http://www.topbunk.ca" target="_blank">www.topbunk.ca</a></asp:Label></td>
                </tr> 
                <tr>
                <td colspan="4"><asp:Label ID="Label125" runat="server" CssClass="QuestionText"><font color="red"><b>*camp programs open to campers living anywhere in the United States</b></font></asp:Label>
                </td>
                </tr>                                                                                                                
                </table>
                </td>
             </tr>
            <tr>
                <td style="height:10px"></td></tr>
            <tr>
                <td align="center">
                    <asp:Label ID="info" runat="server" CssClass="InfoBigText">Please check back at this site in a few weeks to apply online for an incentive program listed above!</asp:Label>
                    <asp:Label ID="star" runat="server" CssClass="QuestionText" Text="*" /></td></tr>
            <tr>
                <td style="height:10px"></td></tr>
            <tr>
                <td>
                    <asp:Label ID="condition" runat="server" CssClass="QuestionText">
                        <p style="text-align:justify">
                            *The following programs are using their own application system and should be contacted directly to access an application: Baltimore, Kansas City, Montreal, Philadelphia, Toronto</p></asp:Label>
                 </td></tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="Label124" runat="server" CssClass="InfoBigText1">To access an online scholarship directory of over 80 scholarship programs, please <a href="http://www.jewishcamp.org/fjc/parents/directory_of_camp_scholarships.asp" target= "_blank">click here</a></asp:Label>
                        </td></tr>
                
            <!--admin panel-->
            <tr>
                <td align="center">
                    <asp:Panel ID="PnlAdmin" runat="server" Visible="false" CssClass="PnlAdmin">
                        <table width="90%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td width="35%"><asp:Label ID="Label21" CssClass="InfoText" runat="server" Text="*"></asp:Label><asp:Label ID="Label20" CssClass="text" runat="server" Text="Comments"></asp:Label></td>
                                <td><asp:TextBox ID="txtComments" runat="server" CssClass="txtbox2" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:CustomValidator ID="CusValComments1" ValidationGroup="CommentsGroup" runat="server" Display="None" CssClass="InfoText" ErrorMessage = "<li>Please enter the Comments</li>" EnableClientScript="false"></asp:CustomValidator>
                </td>
            </tr>
            <!--end of admin panel-->
            <tr> 
                <td valign="top" ><br />
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td  align="left"><asp:Button Visible="false" ValidationGroup="CommentsGroup" ID="btnReturnAdmin" runat="server" Text="<<Exit To Camper Summary" CssClass="submitbtn1" /></td>
                   <%--         <td >
                                <asp:Button ID="btnPrevious" ValidationGroup="CommentsGroup" runat="server" Text=" << Previous" CssClass="submitbtn" />
                            </td>
                            <td align="center">
                                <asp:Button ID="btnNext" runat="server" Text="CONTINUE APPLICATION" Width="200px" CssClass="submitbtn" Enabled="false"/>
                            </td>--%>
                            <td align="right">
                                <asp:Button ID="btnSaveandExit"  ValidationGroup="CommentsGroup" runat="server" Text="Save & Exit" CssClass="submitbtn" />
                            </td>
                            
                        </tr>
                     </table>
                </td>
            </tr>
        </table>
        
    </asp:Panel>
   </asp:Content>
