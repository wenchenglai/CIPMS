<%@ Page Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="CampMessage.aspx.cs"
    Inherits="Enrollment_CMART_CampMessage" %>

<asp:Content ID="CMART_CampMessage" ContentPlaceHolderID="Content" runat="Server">
<%--    <table width="100%" cellpadding="5" cellspacing="0" class="QuestionText">
        <tr>
            <td colspan="2" class="QuestionText" style="text-decoration: underline;text-align: center; font-weight: bold; font-size: 15px; vertical-align: middle;">
                Midwest Interfaith Incentive Program</td>
        </tr>
        <tr>
            <td colspan="2">
                <strong>What is the Midwest Interfaith Incentive Program (MIIP)?</strong>
                <br />
                The Midwest Interfaith Incentive Program seeks to increase the number of Jewish
                children from interfaith families enjoying transformative experiences at select
                Jewish overnight summer camps in the Midwest. We do this by providing financial
                incentives of $1,000 to first time campers who attend participating camps (list
                below). The program also offers returning MIIP campers an incentive grant of $750
                if they choose to attend the same camp again for a second consecutive summer.
                <br />
                <br />
                Campers who are eligible for both the MIIP and a local incentive program in their
                community will only receive a grant through their local community program, and not
                MIIP. Campers are not able to receive two incentive grants in the same summer.
                <br />
                <br />
                <strong>Participating in the 2010 MIIP program:</strong>
                <br />
                <br />
                <table border="1" cellpadding="3" cellspacing="0" class="QuestionText" style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;">
                    <tr style="font-weight: bold;">
                        <td style="width: 210px; background-color: darkgray;">
                            Camp</td>
                        <td style="width: 210px; background-color: darkgray;">
                            Contact Person</td>
                        <td style="width: 210px; background-color: darkgray">
                            Email</td>
                    </tr>
                    <tr>
                        <td style="width: 210px">
                            Camp Sabra
                        </td>
                        <td style="width: 131px">
                            Terri Grossman
                        </td>
                        <td>
                            <a href="mailto:tgrossman@jccstl.org" target="_blank">tgrossman@jccstl.org</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 210px" >
                            B’nai Brith Beber
                        </td>
                        <td style="width: 131px" >
                            Joel Bennet</td>
                        <td >
                            <a href="mailto:joel@bebercamp.com" title="_blank">joel@bebercamp.com</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 210px">
                            Habonim Dror Camp Tavor</td>
                        <td style="width: 131px">
                            Kate Sandler</td>
                        <td>
                            <a href="mailto:registrar@camptavor.org" target="_blank">registrar@camptavor.org</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 210px">
                            JCC Camp Chi
                        </td>
                        <td style="width: 131px">
                            Shayne Berkow</td>
                        <td>
                            <a href="mailto:sberkow@gojcc.org" target="_blank">sberkow@gojcc.org</a></td>
                    </tr>
                    <tr>
                        <td style="width: 210px">
                            Camp Young Judaea Midwest
                        </td>
                        <td style="width: 131px">
                            Robin Anderson</td>
                        <td>
                            <a href="mailto:randerson@youngjudaea.org" target="_blank">randerson@youngjudaea.org</a></td>
                    </tr>
                    <tr>
                        <td style="width: 210px">
                            Camp Interlaken JCC</td>
                        <td style="width: 131px">
                            Beth Alling</td>
                        <td>
                            <a href="mailto:balling@jccmilwaukee.org" target="_blank">balling@jccmilwaukee.org</a></td>
                    </tr>
                    <tr>
                        <td style="width: 210px">
                            JCC Camp Wise</td>
                        <td style="width: 131px">
                            Cathy Becker</td>
                        <td>
                            <a href="mailto:cbecker@clevejcc.org" target="_blank">cbecker@clevejcc.org</a></td>
                    </tr>
                    <tr>
                        <td style="width: 210px">
                            Nageela Midwest</td>
                        <td style="width: 131px">
                            Yitzchok Ehrman</td>
                        <td>
                            <a href="mailto:YEhrman@agudathisrael-il.org" target="_blank">YEhrman@agudathisrael-il.org</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 210px">
                            URJ Olin-Sang-Ruby Union Institute</td>
                        <td style="width: 131px">
                            Denise Heimlich</td>
                        <td>
                            <a href="mailto:dheimlich@urj.org" target="_blank">dheimlich@urj.org</a></td>
                    </tr>
                    <tr>
                        <td style="width: 210px">
                            Camp Livingston
                        </td>
                        <td style="width: 131px">
                            Ben Davis</td>
                        <td>
                            <a href="mailto:ben@camplivingston.com" target="_blank">ben@camplivingston.com</a></td>
                    </tr>
                    <tr>
                        <td style="width: 210px">
                            Camp Ramah in Wisconsin
                        </td>
                        <td style="width: 131px">
                            Angela Goldstein</td>
                        <td>
                            <a href="mailto:agoldstein@ramahwisconsin.com" target="_blank">agoldstein@ramahwisconsin.com</a>
                        </td>
                    </tr>
                </table>
                <br />
                <strong>Eligibility requirements for applicants:<br />
                </strong>These eligibility requirements are adhered to by all MIIP participating
                camps. Please be in touch with the camp directly to inquire about additional eligibility
                requirements:
                <br />
                <ol>
                    <li>Campers must have never previously attended a nonprofit Jewish overnight camp for
                        19 consecutive days or longer before applying for the grant</li><li>Campers must be
                            attending a participating camp (listed above)</li><li>Campers must be attending a camp
                                session that is at least 19 consecutive days or longer</li><li>Campers must not be currently
                                    enrolled in a daily immersive Jewish experience, such as day school or yeshiva.</li><li>
                                        Campers must identify as Jewish and come from a family where one parent is Jewish
                                        and the other is not.</li><li>Campers must not be receiving any additional incentive
                                            funds through another incentive program co-sponsored by the Foundation for Jewish
                                            Camp (details below). </li>
                </ol>
                <br />
                <br />
                <strong>The application process:<br />
                </strong>The first step is to register your camper at one of the participating camps
                listed above. In order to be eligible for the incentive, the camper must be registered
                at a camp.
                <br />
                <br />
                Once campers are registered for camp, parents should <span style="color: red; text-decoration: underline">
                    consult with their camp to receive an application access code.</span> Campers
                who do not receive a code will be unable to successfully submit an MIIP application.
                Once parents have received an access code, they should go to <a href="http://www.onehappycamper.org"
                    target="_blank">www.onehappycamper.org</a> to apply for the grant. They will
                be asked to submit their access code on the first page of the application.<br />
                <br />
                <strong>If you still have more questions, please contact your camp directly. If you
                    are not attending a camp listed above and still have questions, please contact Marissa
                    D’Amato (<a href="mailto:marissa@jewishcamp.org" target="_blank">marissa@jewishcamp.org</a>)
                    at the Foundation for Jewish Camp.</strong></td>
        </tr>
    </table>
--%>
<table width="100%" cellpadding="5" cellspacing="0" class="QuestionText">
        <tr>
        <td>
        <asp:Label ID="lblHeading" CssClass="infotext3" runat="server">
                    <p style="text-align:justify" >
<font color="blue">Midwest Interfaith Incentive Program referral code: </font>If you believe you may be eligible for this program, please contact your camp to obtain a referral code to proceed with the grant application. Additional Questions? Contact Marissa D’Amato, (646)-278-4521 or <a href="mailto:marissa@jewishcamp.org" target="_blank">marissa@jewishcamp.org</a> for more information.
 </p></asp:Label>
</td>
</tr>
    </table>
</asp:Content>
