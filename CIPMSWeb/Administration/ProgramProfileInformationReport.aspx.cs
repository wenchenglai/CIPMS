using System;
using System.Configuration;
using System.Web;
using System.Text;
using System.Data;
using System.Windows.Forms;
using CIPMSBC;
using HtmlAgilityPack;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml;
using Break=DocumentFormat.OpenXml.Wordprocessing.Break;
using HtmlDocument=HtmlAgilityPack.HtmlDocument;

public partial class Administration_ProgramProfileInformationReport : System.Web.UI.Page
{
    private DataSet _dataSet;
    
	protected void Page_Init(object sender, EventArgs e)
    {
        _dataSet = new General().get_AllFederations();
    }
    
	[STAThread]
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (_dataSet == null) return;
            if (_dataSet.Tables.Count > 0)
                if (_dataSet.Tables[0].Rows.Count > 0)
                {
                    chkFedLst.DataSource = _dataSet.Tables[0];
                    chkFedLst.DataTextField = "Federation";
                    chkFedLst.DataValueField = "ID";
                    chkFedLst.DataBind();
                    chkFedLst.Items.Remove(chkFedLst.Items.FindByValue("81"));
                }
        }
		lblMsg.Text = "";
        chkFedLst.Attributes.Add("onClick", "JavaScript:HandleOnCheckList();");
    }
   
    protected void BtnGenerateReportClick(object sender, EventArgs e)
    {
        for (int p = 0; p < chkFedLst.Items.Count; p++)
        {
            if (chkFedLst.Items[p].Selected)
            {
				GenerateDocuments(chkFedLst.Items[p].Value);
            }
        }
    }
    
	private void GenerateDocuments(string strSelectedFedList)
    {
        General objGeneral = new General();
        DataSet dsFederationDetails = objGeneral.GetFederationAndQuestionnaireDetails(strSelectedFedList);
		DataSet dsDocData = GenerateExcel(dsFederationDetails);

        StringBuilder strHTMLContent = new StringBuilder();
        strHTMLContent.Replace("{", "");
        strHTMLContent.Replace("{", "");
        string FederationName = "";
        for (int i = 0; i < dsDocData.Tables[0].Rows.Count; i++)
        {
            FederationName = dsDocData.Tables[0].Rows[i][12].ToString();
            strHTMLContent.Append("<table border='1'>");       

            strHTMLContent.Append("<tr width='100%'><td ><b>Contact Name: </b></td><td >" +
                                  dsDocData.Tables[0].Rows[i][1].ToString() + "</td></tr>");
            strHTMLContent.Append("<tr width='100%'><td ><b>Contact Email: </b></td><td >" +
                                  dsDocData.Tables[0].Rows[i][2].ToString() + "</td></tr>");
            strHTMLContent.Append("<tr width='100%'><td ><b>Contact Phone: </b></td><td >" +
                                  dsDocData.Tables[0].Rows[i][3].ToString() + "</td></tr>");
            strHTMLContent.Append("<tr width='100%'><td ><b>Eligible Grade(after camp): </b></td><td >" +
                                  dsDocData.Tables[0].Rows[i][7].ToString() + "</td></tr>");

            string dayschooleligibility = dsDocData.Tables[0].Rows[i][8].ToString();
            if (dayschooleligibility == "true")
            {
                strHTMLContent.Append("<tr width='100%'><td ><b>Day School: </b></td><td > Yes </td></tr>");
               
                 switch (strSelectedFedList)
                 {
                     case "11":
                     {
						strHTMLContent.Append("<tr width='100%'><td colspan='2'><b>Day Schools List</b></td></tr>");
                        strHTMLContent.Append("<tr width='100%'><td>B'Nai Shalom</td></tr>");
                        strHTMLContent.Append("<tr width='100%'><td>Hebrew Academy</td></tr>");
                         break;
                     }
                     case "9":
                     {
                         strHTMLContent.Append("<tr width='100%'><td colspan='2'><b>Day Schools List</b></td></tr>");
                         strHTMLContent.Append("<tr width='100%'><td>Arie Crown Academy</td></tr>");
                         strHTMLContent.Append("<tr width='100%'><td>Anshe Emet</td></tr>");
                         strHTMLContent.Append("<tr width='100%'><td>Akiba Schechter</td></tr>");
                         strHTMLContent.Append("<tr width='100%'><td>Bais Yaakov</td></tr>");
                         strHTMLContent.Append("<tr width='100%'><td>Cheder Lubovich</td></tr>");
                         strHTMLContent.Append("<tr width='100%'><td>Chicago Jewish Day</td></tr>");
                         strHTMLContent.Append("<tr width='100%'><td>Chicagoland Jewish High School</td></tr>");
                         strHTMLContent.Append("<tr width='100%'><td>Hillel Torah</td></tr>");
                         strHTMLContent.Append("<tr width='100%'><td>Solomon Schechter</td></tr>");
                         break;
                     }    
                 }
            }
            else
            {
                strHTMLContent.Append("<tr width='100%'><td ><b>Jewish Day School : </b></td><td ><span style='color: Red;'>Children currently attending a Jewish day school or Yeshiva are not eligible for a camper incentive grant.</span></td></tr>");

            }

            //if (dsDocData.Tables[5].Rows.Count > 0)
            //{
                //strHTMLContent.Append("<tr width='100%'><td>Camps : </td></tr>");
                //for (int p = 0; p < dsDocData.Tables[5].Rows.Count; p++)
                //{
                //    strHTMLContent.Append("<tr width='100%'><td>" + dsDocData.Tables[5].Rows[p][1].ToString() +
                //                          "</td></tr>");
                //}
            //}
            //else
            //{
            //    strHTMLContent.Append("<tr width='100%'><td ><b>Eligible Camps : </b></td><td >All camps FJC supports as listed on <a href='http://www.jewishcamp.org/find-camp'>http://www.jewishcamp.org/find-camp</a> </td></tr>");
            //}

            //strHTMLContent.Append("<tr ><td ><b>First Time Camper Definition : </b></td><td >" + dsDocData.Tables[0].Rows[i][9].ToString() + "</td></tr>");
            strHTMLContent.Append("<tr ><td ><b>First Time Camper Definition : </b></td><td ><span style='color: Red;'>Eligible as long as applicant has not yet attended a non-profit Jewish overnight camp (e.g. on FJC&#39;s list) for at least ____ consecutive days.</span></td></tr>");

            if (dsDocData.Tables[0].Rows[i][10].ToString() != "No")
            {
                //strHTMLContent.Append("<tr ><td ><b>Second Time Camper Definition : </b></td><td >" + dsDocData.Tables[0].Rows[i][10].ToString() + "</td></tr>");
                strHTMLContent.Append("<tr ><td ><b>Second Time Camper Definition : </b></td><td ><span style='color: Red;'>Eligible as long as applicant received a grant through the Jewish Federation of Greater Philadelphia One Happy Camper Program for the first time last year.</span></td></tr>");
            }

            strHTMLContent.Append("<tr ><td ><b>Length of Stay at Camp to be Eligible:</b></td><td><span style='color: Red;'>At least ____ consecutive days</span></td></tr>");
            strHTMLContent.Append("<tr ><td ><b>Grant Amount for &quot;First-Time&quot; Campers:</b></td><td><span style='color: Red;'>$_____ for ____ consecutive days</span></td></tr>");
            strHTMLContent.Append("<tr ><td ><b>Grant Amount for &quot;Second-Time&quot; Campers:</b></td><td><span style='color: Red;'>$_____ for ____ consecutive days</span></td></tr>");
            strHTMLContent.Append("<tr ><td ><b>Eligible Camps:</b></td><td><span style='color: Red;'>All camps FJC supports as listed on <a href='http://www.OneHappyCamper.org/FindaCamp'>http://www.OneHappyCamper.org/FindaCamp</a>. See list on accompanying spread sheet.  (Tab = Camps)</span></td></tr>");
            strHTMLContent.Append("<tr ><td ><b>Exceptions:</b></td><td><span style='color: Red;'>Adamah Adventures &#45; 18+ consecutive days eligible for $1,000 as first time campers and $750 as second time campers.<br /><br />URJ Six Points Sports Academy &#45; 12-18 consecutive days eligible for $700 as first time campers and $500 as second time campers; 19+ consecutive days eligible for $1000 as first time campers and $750 as second time campers.</span></td></tr>");            
            strHTMLContent.Append("<tr ><td ><b>Eligible Zip Codes:</b></td><td><span style='color: Red;'>Review the list of zip codes on the accompanying spread sheet.</span></td></tr>");

            //if (dsDocData.Tables[3].Rows.Count > 0)
            //{
				//strHTMLContent.Append("<tr width='100%'><td> Synagogues </td></tr>");
            //}
            //for (int m = 0; m < dsDocData.Tables[3].Rows.Count; m++)
            //{
            //    strHTMLContent.Append("<tr width='100%'><td>" + dsDocData.Tables[3].Rows[m][1].ToString() + "</td></tr>");
            //}

            strHTMLContent.Append("<tr ><td ><b>Synagogue/JCC list</b></td><td><span style='color: Red;'>See attached spread sheet in tab 2.  If you have revisions to this list, please submit a new spread sheet with ALL synagogues/JCCs to be listed.<br /><br />Learn more about FJC&#39;s work with engaging synagogues in the camp conversation &#45; contact RebeccaK@JewishCamp.org.</span></td></tr>");

			strHTMLContent.Append("</table>");

			strHTMLContent.Append("<br /><br />Program Description:<br />");
			// the summary page
			strHTMLContent.Append("<table border='1'>");
			strHTMLContent.Append("<tr ><td colspan='2'><h1 align='Center'style='font-family: verdana; font-size:16;color: black:width='100%'><u>" + dsDocData.Tables[0].Rows[i][0].ToString() + "</u></h1></td></tr>");
			strHTMLContent.Append("<tr ><td>" + dsDocData.Tables[0].Rows[i][4].ToString() + "</td></tr>");

			strHTMLContent.Append("</table>");
        }

		string header = @"<html><body><h1 align='Center'style='font-family: verdana; font-size:16;color: black'><u>One Happy Camper Program Profile Report</u></h1>
                        <h4 align='Center'style='font-family: verdana; font-size:16;color: black'>" + DateTime.Now.ToShortDateString() + "</h4>";

		string instruction = @"<div><strong>Instructions: <br /><br />The information below (and on the accompanying spread sheet) is how your 
One Happy Camper application is currently configured.  Please use these documents to communicate any changes to your application for the 2014 campaign 
and submit prior to August 1st, 2013.  Revisions received prior to Aug 1st will be ready to be launched the week of October 7th, 2013.
<br /><br /><ul><li>Please make any edits in <span style='color: Red;'>RED</span></li>
<li>Submit form to Valentina at <a href='mailto:Valentina@JewishCamp.org'>Valentina@JewishCamp.org</a></li></ul><br />
<u>Please confirm the following:</u></strong><br /><br />Payee Name (e.g. name of agency that checks should be made out to):  ____________________<br /><br />
Address (where checks should be mailed):  ___________________________________________<br /><br />
Employer Identification Number: __________________________________________________<div><br />";

		string footer = @"<div><strong><br /><u>Select which one applies:</u></strong><br /><br />___ I have made changes to my application 
(on this document or on the accompanying spread sheet).<br /><br />___ No changes need to be made to my application (on this document or on 
the accompanying spread sheet)<br /><br />Name of person submitting these documents:  ____________________<br /><br />Date: __________________________<br /></div>";
		strHTMLContent.Insert(0, header + instruction).Append(footer + "</body></html>");

        //to eliminate the / for word document filename
        if (FederationName.Trim().Equals("BIMA/Genesis at Brandeis University"))
            FederationName = "BIMA Genesis at Brandeis University";

        generatedocxfile(strHTMLContent, FederationName);
        
        lblReportMessage.Visible = true;
        lblReportMessage.Text = "Report was generated successfully";
    }

    private DataSet GenerateExcel(DataSet dsFederationDetails)
    {
        DataSet dsDocTables = new DataSet();
        string FedName = string.Empty;

        if (dsFederationDetails.Tables.Count > 0)
        {
            if (dsFederationDetails.Tables[1] != null)
            {
                DataTable dtBasicFederationDetails = new DataTable();

                dtBasicFederationDetails.Columns.Add("PartnerName");
                dtBasicFederationDetails.Columns.Add("ContactName");
                dtBasicFederationDetails.Columns.Add("ContactEmail");
                dtBasicFederationDetails.Columns.Add("ContactPhone");
                dtBasicFederationDetails.Columns.Add("SummaryPageContent");
                dtBasicFederationDetails.Columns.Add("FirstTimeCamperDefinition");
                dtBasicFederationDetails.Columns.Add("SecondTimeCamperDefinition");
                dtBasicFederationDetails.Columns.Add("GradeEligibility");
                dtBasicFederationDetails.Columns.Add("DaySchoolEligibility");
                dtBasicFederationDetails.Columns.Add("FirstQuestion");
                dtBasicFederationDetails.Columns.Add("SecondQuestion");
                dtBasicFederationDetails.Columns.Add("DaySchoolNames");
                dtBasicFederationDetails.Columns.Add("FederationName");

                foreach (DataRow dr in dsFederationDetails.Tables[1].Rows) //First 5 fields
                {
                    int iFederationId = Int32.Parse(dr["FederationID"].ToString());
                    DataRow drDocData = dtBasicFederationDetails.NewRow();
                    drDocData["PartnerName"] = dr["PartnerName"].ToString();
                    FedName = dr["PartnerName"].ToString();
                    drDocData["ContactName"] = dr["ContactName"].ToString();
                    drDocData["ContactEmail"] = dr["ContactEmail"].ToString();
                    drDocData["ContactPhone"] = dr["ContactPhone"].ToString();
                    if (dr["NavigationURL"].ToString().ToLower().Contains("summary.aspx"))
                    {
                        drDocData["SummaryPageContent"] = GetSummaryPageContent(dr["NavigationURL"].ToString().ToLower(), iFederationId);
                        GetQuestionnaire(dr["NavigationURL"].ToString().ToLower().Replace("Summary.aspx", "Step2_2.aspx"), iFederationId);
                        //added by sandhya
                        string firstquestion = GetfirstQuestionnaire(dr["NavigationURL"].ToString().ToLower().Replace("Summary.aspx", "Step2_2.aspx"), iFederationId);
                        drDocData["FirstQuestion"] = firstquestion;
                        string secondquestion = GetsecondQuestionnaire(dr["NavigationURL"].ToString().ToLower().Replace("Summary.aspx", "Step2_2.aspx"), iFederationId);
                        drDocData["SecondQuestion"] = secondquestion;
                    }
                    General gen = new General();
                    drDocData["GradeEligibility"] = gen.GetGradeEligibilityRange(iFederationId);
                    //FedGradeEligibility fedGradeEligibility = (FedGradeEligibility)iFederationId;
                    //drDocData["GradeEligibility"] = General.GetEnumDescription(fedGradeEligibility);
                    //FedName =((FedGradeEligibility)iFederationId).ToString();

                    FedName = ((FedFolderName)iFederationId).ToString();
                    FedDaySchoolEligibility fedDaySchoolEligibility = (FedDaySchoolEligibility)iFederationId;
                    drDocData["DaySchoolEligibility"] = General.GetEnumDescription(fedDaySchoolEligibility);
                    //string DaySchoolEligibility = drDocData["DaySchoolEligibility"].ToString();
                    //if (DaySchoolEligibility == "true")
                    //{
                    //    if (dr["NavigationURL"].ToString().ToLower().Contains("summary.aspx"))
                    //    {
                    //        drDocData["DaySchoolNames"] = GetDaySchoolNames(dr["NavigationURL"].ToString().ToLower().Replace("summary.aspx", "Step2_2.aspx"), iFederationId);
                    //    }
                    //}
                    drDocData["FederationName"] = FedName.Trim();
                    dtBasicFederationDetails.Rows.Add(drDocData);
                }

                DataTable dtZipCodes = new DataTable();

                dtZipCodes.Columns.Add("FederationID");
                dtZipCodes.Columns.Add("ZipCode");

//                    String FileName = FedName + "" + System.DateTime.Now.Year + "" + System.DateTime.Now.Month+ "" + System.DateTime.Now.Day +".xlsx";
                //String FileName = FedName.Trim() + ".xlsx";
				String FileName = getPPRPath() + FedName.Trim() + ".xlsx";
                FileInfo newFile = new FileInfo(FileName);
                
                if (newFile.Exists) 
                {
                    newFile.Delete(); 
                }
                newFile = new FileInfo(FileName);
                //FileInfo newFile = new FileInfo(@"D:\template.xlsx");

                using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                {
                    ExcelWorksheet worksheet;
                    int i;
					if (dsFederationDetails.Tables[7].Rows.Count > 0)
					{
						worksheet = xlPackage.Workbook.Worksheets.Add("ZipCodes");
						i = 1;
						worksheet.Cell(i, 1).Value = "ZipCodes";
						i = i + 1;
						worksheet.Cell(i, 1).Value = "";
                        if (dsFederationDetails.Tables[7].Rows.Count < 1000) // 2013-06-11 Too many zip codes will crash the server, and excel file cannot handle that much data
                        {
                            foreach (DataRow dr in dsFederationDetails.Tables[7].Rows)
                            {
                                DataRow drZipData = dtZipCodes.NewRow();
                                drZipData["FederationID"] = dr["FederationID"].ToString();
                                drZipData["ZipCode"] = dr["ZipCode"].ToString();
                                worksheet.Cell(i + 1, 1).Value = dr["ZipCode"].ToString(); // tins Carrots sold
                                i++;
                                xlPackage.Save();
                                dtZipCodes.Rows.Add(drZipData);
                            }
                        }
                        else
                        {
                            worksheet.Cell(i + 1, 1).Value = "There are too many zip codes.  Please ask the FJC admin to manual generate the report for you"; // tins Carrots sold
                        }
					}
                    DataTable dtGrantAmount = new DataTable();

                    dtGrantAmount.Columns.Add("FederationID");
                    dtGrantAmount.Columns.Add("CampName");
                    dtGrantAmount.Columns.Add("TimeInCamp");
                    dtGrantAmount.Columns.Add("DaysAtleast");
                    dtGrantAmount.Columns.Add("GrantAmount");

                    //newFile = null;
                   // newFile = new FileInfo("D:\\" + FileName);
                    if (dsFederationDetails.Tables[6].Rows.Count > 0)
                    {
                        //worksheet = xlPackage.Workbook.Worksheets.Add("GrantAmount");
                        //i = 1;

                        //worksheet.Cell(i, 1).Value = "Camp Name";
                        //worksheet.Cell(i, 2).Value = "TimeInCamp";
                        //worksheet.Cell(i, 3).Value = "DaysAtLeast";
                        //worksheet.Cell(i, 4).Value = "Grant Amount";
                        //i = i + 1;
                        //worksheet.Cell(i, 1).Value = "";
                        //worksheet.Cell(i, 2).Value = "";
                        //worksheet.Cell(i, 3).Value = "";
                        //worksheet.Cell(i, 4).Value = "";
                        //foreach (DataRow dr in dsFederationDetails.Tables[6].Rows)
                        //{
                        //    DataRow drGrantAmount = dtGrantAmount.NewRow();
                        //    drGrantAmount["CampName"] = dr["Name"].ToString();
                        //    drGrantAmount["TimeInCamp"] = dr["TimeInCamp"].ToString();
                        //    drGrantAmount["DaysAtleast"] = dr["DaysAtleast"].ToString();
                        //    drGrantAmount["GrantAmount"] = dr["GrantAmount"].ToString();

                        //    worksheet.Cell(i + 1, 1).Value = dr["Name"].ToString().Replace('\'', ' ');
                        //    worksheet.Cell(i + 1, 2).Value = dr["TimeInCamp"].ToString(); 
                        //    worksheet.Cell(i + 1, 3).Value = dr["DaysAtleast"].ToString();
                        //    worksheet.Cell(i + 1, 4).Value = dr["GrantAmount"].ToString();
                        //    i++;
                        //    xlPackage.Save();

                        //    dtGrantAmount.Rows.Add(drGrantAmount);
                        //}
                    }


                    //added by sandhya 08/07

                    DataTable dtSynagogues = new DataTable();

                    dtSynagogues.Columns.Add("FederationID");
                    dtSynagogues.Columns.Add("SynagogueName");

                   // newFile = null;
                    //newFile = new FileInfo("D:\\" + FileName);
                    if (dsFederationDetails.Tables[5].Rows.Count > 0)
                    {
                        worksheet = xlPackage.Workbook.Worksheets.Add("Synagogues");
                        i = 1;
                        worksheet.Cell(i, 1).Value = "Synagogues"; // tins Carrots sold
                        i = i + 1;
                        worksheet.Cell(i, 1).Value = "";
                        foreach (DataRow dr in dsFederationDetails.Tables[5].Rows)
                        {
                            DataRow drSynagogueData = dtSynagogues.NewRow();
                            drSynagogueData["FederationID"] = dr["FederationID"].ToString();
                            drSynagogueData["SynagogueName"] = dr["SynagogueName"].ToString();
                            worksheet.Cell(i + 1, 1).Value = dr["SynagogueName"].ToString().Replace('\'', ' ');
                            i++;
                            xlPackage.Save();
                            dtSynagogues.Rows.Add(drSynagogueData);
                        }
                    }
                
                    DataTable dtReferralCodes = new DataTable();

                        dtReferralCodes.Columns.Add("FederationID");
                        dtReferralCodes.Columns.Add("PromotionalCode");

                        // newFile = null;
                        // newFile = new FileInfo("D:\\" + FileName);
                        if (dsFederationDetails.Tables[4].Rows.Count > 0)
                        {
                            worksheet = xlPackage.Workbook.Worksheets.Add("Referral Codes");
                            i = 1;
                            worksheet.Cell(i, 1).Value = "Referral Codes"; // tins Carrots sold
                            i = i + 1;
                            worksheet.Cell(i, 1).Value = "";
                            foreach (DataRow dr in dsFederationDetails.Tables[4].Rows)
                            {
                                DataRow drReferralCodesData = dtReferralCodes.NewRow();
                                drReferralCodesData["FederationID"] = dr["FederationID"].ToString();
                                drReferralCodesData["PromotionalCode"] = dr["PromotionalCode"].ToString();
                                worksheet.Cell(i + 1, 1).Value = dr["PromotionalCode"].ToString();
                                i++;
                                xlPackage.Save();
                                dtReferralCodes.Rows.Add(drReferralCodesData);
                            }
                        }
                    
                    DataTable dtCamps = new DataTable();

                    dtCamps.Columns.Add("FederationID");
                    dtCamps.Columns.Add("CampName");

                   // newFile = null;
                    //newFile = new FileInfo("D:\\" + FileName);
                    if (dsFederationDetails.Tables[3].Rows.Count > 0)
                    {
                        worksheet = xlPackage.Workbook.Worksheets.Add("Camps");
                        i = 1;
                        worksheet.Cell(i, 1).Value = "Eligible Camps"; 
                        i = i + 1;
                        worksheet.Cell(i, 1).Value = "";
                        foreach (DataRow dr in dsFederationDetails.Tables[3].Rows)
                        {
                            DataRow drCampsData = dtCamps.NewRow();
                            drCampsData["FederationID"] = dr["FederationID"].ToString();
                            drCampsData["CampName"] = dr["CampName"].ToString();
                            worksheet.Cell(i + 1, 1).Value = dr["CampName"].ToString().Replace('\'', ' ');
                            i++;
                            xlPackage.Save();
                            dtCamps.Rows.Add(drCampsData);
                        }
                    }
                    dsDocTables.Tables.Add(dtBasicFederationDetails);
                    dsDocTables.Tables.Add(dtZipCodes);
                    dsDocTables.Tables.Add(dtGrantAmount);
                    dsDocTables.Tables.Add(dtSynagogues);
                    dsDocTables.Tables.Add(dtReferralCodes);
                    dsDocTables.Tables.Add(dtCamps);
                }
                //added by sreevani to delete excel created if records does not exist corresponding to that federation
                if (dsFederationDetails.Tables[3].Rows.Count == 0 && dsFederationDetails.Tables[4].Rows.Count == 0 && dsFederationDetails.Tables[5].Rows.Count == 0 && dsFederationDetails.Tables[7].Rows.Count == 0)
                    newFile.Delete();
            }
        }
        return dsDocTables;
    }

    private string GetSummaryPageContent(string summaryPageUrl, int iFederationId)
    {
        HtmlWeb hw = new HtmlWeb();
        StringBuilder sbHtml = new StringBuilder();
        try
        {
            HtmlDocument htmlDoc = hw.Load(Server.MapPath(summaryPageUrl));
            HtmlNode content = htmlDoc.DocumentNode.ChildNodes[1];
            string imagePath;

            if (content.HasChildNodes)
            {
                HtmlNode table = content.SelectSingleNode("table");
                if (table != null)
                {
                    HtmlNodeCollection trCollection = table.SelectNodes("tr");
                    if (trCollection != null)
                        foreach (HtmlNode tr in trCollection)
                        {
                            HtmlNodeCollection tdCollection = tr.SelectNodes("td");
                            if (tdCollection != null)
                                foreach (HtmlNode td in tdCollection)
                                {
                                    switch (iFederationId)
                                    {
                                        case 63:
                                        case 59:
                                        case 49:
                                            {
                                                HtmlNode internalTable = td.SelectSingleNode("table");
                                                if (internalTable != null)
                                                {
                                                    HtmlNodeCollection trInnerCollection =
                                                        internalTable.SelectNodes("tr");
                                                    if (trInnerCollection != null)
                                                        foreach (HtmlNode trInner in trInnerCollection)
                                                        {
                                                            HtmlNodeCollection tdInnerCollection =
                                                                trInner.SelectNodes("td");
                                                            if (tdInnerCollection != null)
                                                                foreach (HtmlNode tdInner in tdInnerCollection)
                                                                {
                                                                    HtmlNodeCollection imgCollection =
                                                                        tdInner.SelectNodes("img");
                                                                    if (imgCollection != null)
                                                                        foreach (HtmlNode image in imgCollection)
                                                                        {
                                                                            imagePath = image.Attributes["src"].Value;
                                                                            imagePath = Server.MapPath("~/images") +
                                                                                        imagePath.Substring(
                                                                                            imagePath.LastIndexOf(
                                                                                                "images") +
                                                                                            6);
                                                                            image.Attributes["src"].Value = imagePath;
                                                                        }
                                                                }
                                                        }
                                                }
                                            }
                                            break;
                                        default:
                                            {
                                                HtmlNodeCollection imgCollection = td.SelectNodes("img");

                                                if (imgCollection != null)
                                                    foreach (HtmlNode image in imgCollection)
                                                    {
                                                        imagePath = image.Attributes["src"].Value;
                                                        imagePath = "http://12.40.231.186/CIPMS/images" +
                                                                    imagePath.Substring(
                                                                        imagePath.LastIndexOf("images") + 6);
                                                        image.Attributes["src"].Value = imagePath;
                                                    }
                                            }
                                            break;
                                    }
                                }
                        }
                    sbHtml.Append(table.InnerHtml);
                }
            }

            sbHtml.Replace("asp:label", "span").Replace("cssclass", "class").Replace("asp:panel", "div").Replace("<br>", "<br/>");
            if (summaryPageUrl.ToLower().Contains("NJY"))
                sbHtml.Replace("width='100%'", "width='85%'");
            // sbHtml.Insert(0, "<html><body>");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return sbHtml.ToString();
    }

    private string GetQuestionnaire(string summaryPageUrl, int iFederationId)
    {
        HtmlWeb hw = new HtmlWeb();
        summaryPageUrl = "~/enrollment/dallas/Step2_2.aspx";
        StringBuilder sbHtml = new StringBuilder();
        StringBuilder sbQuestion = new StringBuilder();
        try
        {
            HtmlDocument htmlDoc = hw.Load(Server.MapPath(summaryPageUrl));
            HtmlNode content = htmlDoc.DocumentNode.ChildNodes[1];
            // string imagePath;
            string s = htmlDoc.GetElementbyId("Label5").OuterHtml;
            // string test = htmlDoc.GetElementbyId("Label5").InnerHtml; //by sandhya
            //test = htmlDoc.GetElementbyId("Label5").InnerText;
            sbQuestion.Append(s);
            s = htmlDoc.GetElementbyId("RadioBtnQ3").OuterHtml;
            sbQuestion.Append(s);
            sbQuestion.Append("<br>");
            sbQuestion.Append(htmlDoc.GetElementbyId("Label9").OuterHtml.ToString());
            sbQuestion.Append("<br>");
            sbQuestion.Append(htmlDoc.GetElementbyId("Label9").OuterHtml.ToString());

            sbQuestion.Replace("asp:label", "span").Replace("cssclass", "class").Replace("asp:panel", "div").Replace("<br>", "<br/>");
            if (summaryPageUrl.ToLower().Contains("NJY"))
                sbHtml.Replace("width='100%'", "width='85%'");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return sbQuestion.ToString();
    }

    //added by sandhya 
    private string GetfirstQuestionnaire(string summaryPageUrl, int iFederationId)
    {
        HtmlWeb hw = new HtmlWeb();
        //summaryPageUrl="~/enrollment/dallas/Step2_2.aspx";
        string changeUrl = summaryPageUrl.Replace("summary.aspx", "Step2_2.aspx");
        string FirstQuestion;
        try
        {
            HtmlDocument htmlDoc = hw.Load(Server.MapPath(changeUrl));
            HtmlNode content = htmlDoc.DocumentNode.ChildNodes[1];
            FirstQuestion = htmlDoc.GetElementbyId("Label5").InnerHtml;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return FirstQuestion;
    }
   
    private string GetsecondQuestionnaire(string summaryPageUrl, int iFederationId)
    {
        //DataSet dsSecondQues = new DataSet();
        // CamperApplication objCamperAppl = new CamperApplication();
        //  DataRow dr;
        // dsSecondQues = objCamperAppl.CheckSecondQuestion(iFederationId);
        // int iCount = dsSecondQues.Tables[0].Rows.Count;
        string SecondQuestion = "No";
        //if (iCount > 0)
        //{
        // dr = dsSecondQues.Tables[0].Rows[0];

        //int question = Convert.ToInt16(dr["question"]);
        //if (question == 2)
        //{
        if (iFederationId == 27 || iFederationId == 53 || iFederationId == 9 || iFederationId == 11 || iFederationId == 12 || iFederationId == 42 || iFederationId == 23 || iFederationId == 22 || iFederationId == 35 || iFederationId == 37)
        {
            HtmlWeb hw = new HtmlWeb();
            //summaryPageUrl="~/enrollment/dallas/Step2_2.aspx";
            string changeUrl = summaryPageUrl.Replace("summary.aspx", "Step2_2.aspx");

            try
            {
                HtmlDocument htmlDoc = hw.Load(Server.MapPath(changeUrl));
                HtmlNode content = htmlDoc.DocumentNode.ChildNodes[1];

                SecondQuestion = htmlDoc.GetElementbyId("lblQ4").InnerHtml;

            }
            catch (Exception ex)
            {
				SecondQuestion = "Q4 is not available";
            }

        }
        // }

        return SecondQuestion;
    }
    
	private string GetDaySchoolNames(string summaryPageUrl, int iFederationId)
    {
        HtmlWeb hw = new HtmlWeb();
        string DaySchoolNames;
        try
        {
            HtmlDocument htmlDoc = hw.Load(Server.MapPath(summaryPageUrl));
            HtmlNode content = htmlDoc.DocumentNode.ChildNodes[1];
            DaySchoolNames = htmlDoc.GetElementbyId("ddlQ10").InnerHtml;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return DaySchoolNames;
    }
    
	private void generatedocxfile(StringBuilder strHTMLContent, string FederationName)
    {
        /*t create and init a new docx file and
        a WordprocessingDocument object to represent it t*/

		string docPath = getPPRPath();
        //string docPath=GetSavePath();

        DocumentFormat.OpenXml.Packaging.WordprocessingDocument doc = DocumentFormat.OpenXml.Packaging.WordprocessingDocument.Create(docPath + FederationName + ".docx", WordprocessingDocumentType.Document);
        MainDocumentPart mainDocPart = doc.AddMainDocumentPart();
        mainDocPart.Document = new Document();
        Body body = new Body();
        mainDocPart.Document.Append(body);

        // Add an aFChunk part to the package
        string altChunkId = "AltChunkId1";

        AlternativeFormatImportPart chunk = mainDocPart
        .AddAlternativeFormatImportPart(
        AlternativeFormatImportPartType.Xhtml, altChunkId);

        string html = strHTMLContent.ToString();

        using (MemoryStream ms =
        new MemoryStream(Encoding.UTF8.GetBytes(html)))
        {
            chunk.FeedData(ms);
        }

        // Add the aFChunk to the document
        AltChunk altChunk = new AltChunk();
        altChunk.Id = altChunkId;
        mainDocPart.Document.Body.Append(altChunk);

        /*t to save the changes t*/
        doc.MainDocumentPart.Document.Save();
        doc.Dispose();
    }
    
	private string GetSavePath()
    {
        SaveFileDialog sfd = new SaveFileDialog();
        sfd.AddExtension = true;
        //Get only Docx file
        sfd.Filter = "docx|";
        sfd.CheckPathExists = true;
        sfd.DefaultExt = ".docx";
        sfd.ShowDialog();
        return sfd.FileName; // return the filename and the path
    }

	protected void btnClear_Click(object sender, EventArgs e)
	{
		DirectoryInfo di = new DirectoryInfo(getPPRPath());
		int i = 0;
		foreach (FileInfo fi in di.GetFiles())
		{
			fi.Delete();
		}
		lblMsg.Text = "All reports has been deleted.";
	}

	private string getPPRPath()
	{
		return HttpContext.Current.Request.MapPath(HttpContext.Current.Request.ApplicationPath + ConfigurationManager.AppSettings["ProgramProfileReportPath"]);
	}
}
