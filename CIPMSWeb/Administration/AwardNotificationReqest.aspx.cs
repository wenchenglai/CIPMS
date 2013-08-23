using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using CIPMSBC;

public partial class AwardNotificationReqest : System.Web.UI.Page
{
    private CamperApplication _objCamperApplication = new CamperApplication();
    private General _objGen = new General();
    DataSet dsANReportCampers = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }

        tblReportDetails.Visible = grdANReport.Visible;
		int cntOfRecordsinPreMode = _objCamperApplication.GetExistingCountOfANPremilinaryRecords(Application["CampYear"].ToString());
        if (cntOfRecordsinPreMode > 0 && rdbtnlstMode.SelectedItem.Value != "1") rdbtnlstMode.SelectedItem.Value = "0";
        if (cntOfRecordsinPreMode > 0 && ddlRecCount.Enabled)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Note: There are already " + cntOfRecordsinPreMode.ToString() + " camper applications which are in premiliminary mode, untill these records are run in final mode you cannot change the no. of records you want to view";
            ddlRecCount.Enabled = false;
        }
        else
        {
            lblMessage.Visible = false;
            lblMessage.Text = "";
        }
    }

    private DataSet GetAnReportCampers(string recordCount, string campyear, int ANReportID, string type)
    {
        return _objCamperApplication.usp_GetANReport(Int32.Parse(recordCount), campyear, ANReportID, type);        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strMode = rdbtnlstMode.SelectedItem.Value;
        lblMode.Text = strMode == "1" ? "Final" : "Prelimary";

        // 2013-07-30 Seth asked to generate second time camper's list for survey purpose
        string type = "";
        if (rdoFirstTime.Checked)
            type = "FirstTimer";
        else
            type = "SecondTimer";

        if (strMode == "0") //Preliminary Mode
        {
			dsANReportCampers = GetAnReportCampers(ddlRecCount.SelectedValue, Application["CampYear"].ToString(), 0, type);
            grdANReport.DataSource = UpdateDays(dsANReportCampers.Tables[0]);//Wil calculate no. of days from startdate and enddate columns
            grdANReport.PageIndex = 0;
            grdANReport.DataBind();            
            ddlRecCount.Enabled = false;
            Session["ANReportID"] = "0";
        }
        else if (strMode == "1" && chkFinal.Checked)//Final Mode
        {
			dsANReportCampers = _objCamperApplication.RunFinalMode(Application["CampYear"].ToString(), type);
            grdANReport.DataSource = UpdateDays(dsANReportCampers.Tables[0]);//Wil calculate no. of days from startdate and enddate columns
            grdANReport.PageIndex = 0;
            grdANReport.DataBind();
            ddlRecCount.Enabled = true;
            string strFolder = Request.MapPath(ConfigurationManager.AppSettings["AwardNotificationFolderPath"], Request.ApplicationPath, false);
            string strANReportID = string.Empty;
            if (dsANReportCampers.Tables[1].Rows.Count>0)
            {
                strANReportID = dsANReportCampers.Tables[1].Rows[0]["ANReportID"].ToString();
                Session["ANReportID"] = String.IsNullOrEmpty(strANReportID) ? "0" : strANReportID;
            }
            if (Directory.Exists(strFolder))
            {
                ProcessFile(strFolder, strANReportID);
            }
            else
            {
                Directory.CreateDirectory(strFolder);
                ProcessFile(strFolder, strANReportID);
            }
        }
        
        lblNoOfRecords.Text = dsANReportCampers.Tables[0].Rows.Count.ToString();

		int cntPreANRecords = _objCamperApplication.GetExistingCountOfANPremilinaryRecords(Application["CampYear"].ToString());
        if (cntPreANRecords > 0 && strMode == "0" && ddlRecCount.Enabled)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Note: There are already " + cntPreANRecords.ToString() + " camper applications which are in premiliminary mode, untill these records are run in final mode you cannot change the no. of records you want to view.";
            ddlRecCount.Enabled = false;
        }
        else if (cntPreANRecords == 0 && strMode == "0")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Note: There are no campers with payment request status, please try running the preliminary mode later.";
        }
        else if (cntPreANRecords == 0 && strMode == "1" && dsANReportCampers.Tables[0].Rows.Count<=0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Note: There are no records in preliminary mode, please run the report in preliminary mode by selecting the mode option provided above.";
        }
            
        if (pnlFinal.Visible) pnlFinal.Visible = false;
        lblReqTime.Text = DateTime.Now.ToString();
        tblReportDetails.Visible = grdANReport.Visible = true;

    }

    private DataTable UpdateDays(DataTable dt)
    {
        if (dt.Rows.Count > 0)
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (String.IsNullOrEmpty(dt.Rows[i]["Days"].ToString()))
                {
                    string startDate = dt.Rows[i]["StartDate"].ToString();
                    string endDate = dt.Rows[i]["EndDate"].ToString();
                    if (String.IsNullOrEmpty(startDate) || String.IsNullOrEmpty(endDate))
                        dt.Rows[i]["Days"] = "0";
                    else
                    {
                        DateTime dtStartDate, dtEndDate;
                        TimeSpan ts = new TimeSpan();
                        dtStartDate = dtEndDate = DateTime.Now;
                        if (DateTime.TryParse(startDate, out dtStartDate) && DateTime.TryParse(endDate, out dtEndDate))
                        {
                            if (dtEndDate > dtStartDate)
                            {
                                ts = dtEndDate.Subtract(dtStartDate);
                                dt.Rows[i]["Days"] = (ts.Days + 1).ToString();
                            }
                            else
                                dt.Rows[i]["Days"] = "0";
                        }
                    }
                }
            }
        return dt;
    }
    

    protected void OnPaging(object sender, GridViewPageEventArgs  e)
    {
        // 2013-07-30 Seth asked to generate second time camper's list for survey purpose
        string type = "";
        if (rdoFirstTime.Checked)
            type = "FirstTimer";
        else
            type = "SecondTimer";

		dsANReportCampers = GetAnReportCampers(ddlRecCount.SelectedValue, Application["CampYear"].ToString(), Int32.Parse(Session["ANReportID"].ToString()), type);
        grdANReport.DataSource = UpdateDays(dsANReportCampers.Tables[0]);//Wil calculate no. of days from startdate and enddate columns
        grdANReport.PageIndex = e.NewPageIndex;
        grdANReport.DataBind();
        if (rdbtnlstMode.SelectedItem.Value == "1" && dsANReportCampers.Tables[0].Rows.Count > 0)
        {
            if (Session["url"] != null)
            {
                string url = Session["url"].ToString();
                lblMessage.Text = "Note: Award notification final mode was successful and txt file generated with camper details, please <a href='http://" + url + "' target='_blank'>click here</a> to download it";
                lblMessage.Visible = true;
            }
            
        }
    }
    
    protected void rdbtnlstMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbtnlstMode.SelectedItem != null)
        {
            if (rdbtnlstMode.SelectedItem.Value == "1")
            { pnlFinal.Visible = true; if (chkFinal.Checked) chkFinal.Checked = false; }
            else
                pnlFinal.Visible = false;

            tblReportDetails.Visible = grdANReport.Visible = false;
        }
    }

    private void ProcessFile(string strFolderPath, string strANReportId)
    {
        string strFileName = string.Empty;
        string strFilePath = string.Empty;
        string strFileExtension = string.Empty;
        string strGeneratedFileName = string.Empty;
       try
        {
            strFileName = ConfigurationManager.AppSettings["AwardNotificationFileName"];
            strFileExtension = ConfigurationManager.AppSettings["AwardNotificationFileExtension"];
            strGeneratedFileName = DateTime.Now.Date.ToString("MMM-dd-yyyy") + "_" + strFileName + strFileExtension;
            strFilePath = strFolderPath + strGeneratedFileName;
            DataSet dsANFinalCamperNotificationList = new DataSet();
			dsANFinalCamperNotificationList = _objCamperApplication.GetANFinalModeCampersOnReportID(Application["CampYear"].ToString(), strANReportId);

            if (dsANFinalCamperNotificationList.Tables.Count > 0)
            {
                if (dsANFinalCamperNotificationList.Tables[0].Rows.Count > 0)
                {
                    DataTable dtANFinalCamperNotificationList = UpdateDays(dsANFinalCamperNotificationList.Tables[0]);
                    dtANFinalCamperNotificationList.Columns.Remove("StartDate");
                    dtANFinalCamperNotificationList.Columns.Remove("EndDate");
                    dtANFinalCamperNotificationList.Columns["Days"].ColumnName = "Number of days";
                    for (int i = 0; i < dtANFinalCamperNotificationList.Rows.Count; i++)
                    {
                        if (dtANFinalCamperNotificationList.Rows[i]["ProgramID"].ToString().Length == 1)
                            dtANFinalCamperNotificationList.Rows[i]["ProgramID"] = dtANFinalCamperNotificationList.Rows[i]["ProgramID"].ToString().Insert(0, "00");
                        else if (dtANFinalCamperNotificationList.Rows[i]["ProgramID"].ToString().Length == 2)
                            dtANFinalCamperNotificationList.Rows[i]["ProgramID"] = dtANFinalCamperNotificationList.Rows[i]["ProgramID"].ToString().Insert(0, "0");
                    }
                    if (File.Exists(strFilePath))
                    {
                        StreamWriter strmWriterFile = new StreamWriter(strFilePath, false);  //true defines append to the file if exists
                        //if file does not exists creates new and header (true) if file exists writeheader to be set as false
                        _objGen.ProduceTabDelimitedFile(dtANFinalCamperNotificationList, strmWriterFile, false,0);

                        
                    }
                    else
                    {
                       StreamWriter strmWriterFile = new StreamWriter(strFilePath, false); //true defines append to the file if exists
                        //if file does not exists creates new and header (true) if file exists writeheader to be set as false
                        _objGen.ProduceTabDelimitedFile(dtANFinalCamperNotificationList, strmWriterFile, true, 0);

                    }
                  }
            }
            string localpath = Request.ApplicationPath + "/" + ConfigurationManager.AppSettings["AwardNotificationFolderPath"].Replace('\\', '/');
            string url = Request.ServerVariables["HTTP_HOST"] + localpath + HttpUtility.UrlEncode(strGeneratedFileName);            
            lblMessage.Text = "Note: Award notification final mode was successful and txt file generated with camper details, please <a href='http://"+url+"' target='_blank'>click here</a> to download it";
            lblMessage.Visible = true;
            Session["url"] = url;
        }
        catch (FileNotFoundException ex)
        {
            throw ex;
        }
    }

 }
