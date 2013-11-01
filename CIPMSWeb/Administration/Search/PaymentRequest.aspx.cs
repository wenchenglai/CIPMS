using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CIPMSBC;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using System.Net;
using System.Security.Principal;

public partial class Administration_Search_PaymentRequest : System.Web.UI.Page
{
    private General _objGen;
    public const string NULL = "-1";

    protected void Page_Load(object sender, EventArgs e)
    {
        Label lbl = (Label)this.Master.FindControl("lblPageHeading");
        lbl.Text = "Payment processing";

        if (!Page.IsPostBack)
        {
            PopulateFederations();
            getCampYears();
        }
        
        SetFinalAlert();
    }

    private void PopulateFederations()
    {
        _objGen = new General();
        DataSet dsFed = _objGen.get_AllFederations();

		// 2013-01-03 Temporarily allow Philly and Boston admin to do payment processing
		string FedID = (string)Session["FedID"];
		if (FedID == "35" || FedID == "5")
		{
			Dictionary<string, string> dict = new Dictionary<string, string>();
			DataRow[] drs = dsFed.Tables[0].Select("ID = " + FedID);
			if (FedID == "35")
			{
				dict.Add("35", drs[0]["Federation"].ToString());
			}
			else
			{
				dict.Add("5", drs[0]["Federation"].ToString());
			}

			lstFederations.DataSource = dict;
			lstFederations.DataTextField = "Value";
			lstFederations.DataValueField = "Key";
			lstFederations.DataBind();
		}
		else
		{
			lstFederations.DataSource = dsFed;
			lstFederations.DataTextField = "Federation";
			lstFederations.DataValueField = "ID";

			lstFederations.DataBind();
			if ((lstFederations.Items.Count != 0))
				lstFederations.Items.Insert(0, new ListItem("--Select--", "-1"));
		}
    }

    private void getCampYears()
    {
		_objGen = new General();
		DataSet dsYears = _objGen.GetAllCampYears();
		lstYear.DataSource = dsYears;
		lstYear.DataTextField = "CampYear";
		lstYear.DataValueField = "CampYear";
		lstYear.DataBind();
		if (lstYear.Items.Count != 0)
			lstYear.Items.Insert(0, new ListItem("--Select--", "-1"));

		lstYear.ClearSelection();
		lstYear.Items.FindByText(DateTime.Now.Year.ToString()).Selected = true;
    }

    private void SetFinalAlert()
    {
        if (radPreliminary.Checked)
            pnlFinal.Visible = false;
        else
            pnlFinal.Visible = true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int FederationID = int.Parse(lstFederations.SelectedItem.Value);
        string FederationName = lstFederations.SelectedItem.Text;
        int UserID = int.Parse(Session["UsrID"].ToString());
        int CampYear = int.Parse(lstYear.SelectedItem.Text);
        string campID = string.Empty;

		string PaymentID = NULL;
        bool isFinal = false;
        if (radFinal.Checked)
        {
            PaymentID = GeneratePaymentRequest(FederationID, UserID, CampYear);
            isFinal = true;
        }
        RenderReport(FederationID.ToString(), CampYear.ToString(), PaymentID,FederationName);
        pnlSelections.Visible = false;
    }

    public string GeneratePaymentRequest(int FederationID, int UserID, int CampYear)
    {
        CIPDataAccess dal = new CIPDataAccess();
        try
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@FederationID", FederationID);
            param[1] = new SqlParameter("@UserID", UserID);
            param[2] = new SqlParameter("@CampYear", CampYear);
            param[3] = new SqlParameter("@PaymentID", SqlDbType.Int);
            param[3].Direction = ParameterDirection.Output;
            dal.ExecuteNonQuery("[usp_GeneratePaymentControl]", param);

            return param[3].Value.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dal = null;
        }
    }

    private void RenderReport(string FederationID, string CampYear, string PaymentID, string FederationName)
    {
        CamperApplication oCA = new CamperApplication();

        //************************
        //Update TimeInCamp
        //************************
            
        //oCA.UpdateTimeInCamp_PaymentReport(Convert.ToInt32(FederationID),Convert.ToInt32(CampYear));


        string strRpt = "/CIPMSReports/PaymentRequest";
		//string strRpt = "/CIPMS_Reports/Report1";
        string strReportServerURL = ConfigurationManager.AppSettings["ReportServerURL"];
        string strParamValue = "";

        //*****************************
        //Set general report properties
        //*****************************
        ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new Uri(strReportServerURL);   // Report Server URL
        ReportViewer1.ServerReport.ReportPath = strRpt;                             // Report Name
        ReportViewer1.ShowParameterPrompts = false;
        ReportViewer1.ShowDocumentMapButton = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.ZoomMode = ZoomMode.PageWidth;

        //*************************
        // Create report parameters
        //*************************

        //Report mode parameter
        ReportParameter reportMode = new ReportParameter();
        reportMode.Name = "Report_Parameter_Mode";
        if (radFinal.Checked)
            strParamValue = "Final";
        else
            strParamValue = "Preliminary";
        reportMode.Values.Add(strParamValue);

        //Federation Name parameter
        ReportParameter reportFederation = new ReportParameter();
        reportFederation.Name = "Report_Parameter_Federation";
        strParamValue = lstFederations.SelectedItem.Text;
        reportFederation.Values.Add(strParamValue);

        //Report_Parameter_FederationID parameter
        ReportParameter reportFederationID = new ReportParameter();
        reportFederationID.Name = "FederationID";
        strParamValue = FederationID;
        reportFederationID.Values.Add(strParamValue);

        //Report_Parameter_PaymentID
        ReportParameter reportPaymentID = new ReportParameter();
        reportPaymentID.Name = "PaymentID";
        if (PaymentID != NULL)
        {
            strParamValue = PaymentID;
        }
        else
        {
            strParamValue = null;
        }
        reportPaymentID.Values.Add(strParamValue);

        //Report_Parameter_CampYear
        ReportParameter reportCampYear = new ReportParameter();
        reportCampYear.Name = "CampYear";
        strParamValue = CampYear;
        reportCampYear.Values.Add(strParamValue);


        //*************************
        //new paarameters
        //*************************
        structThresholdInfo ThresholdInfo;
        string strThresholdInfo = "";
        string strRequestedPaymentInfo = "";
        ThresholdInfo = oCA.GetFedThresholdInfo(Convert.ToUInt16(FederationID));

        switch (ThresholdInfo.ThresholdType)
        {
            case "A":
                strThresholdInfo = ThresholdInfo.Threshold1 + " for all campers";
                strRequestedPaymentInfo = ThresholdInfo.NbrOfPmtRequested1.ToString() + " of 1st time and " + ThresholdInfo.NbrOfPmtRequested2.ToString() + " of 2nd time campers";
                break;
            case "F":
                strThresholdInfo = ThresholdInfo.Threshold1.ToString() + " for first time campers";
                strRequestedPaymentInfo = ThresholdInfo.NbrOfPmtRequested1.ToString() + " of first time campers";
                break;
            case "FS":
                strThresholdInfo = ThresholdInfo.Threshold1.ToString() + " for first time campers and " + ThresholdInfo.Threshold2.ToString() + " for second time campers";
                strRequestedPaymentInfo = ThresholdInfo.NbrOfPmtRequested1.ToString() + " of 1st time and " + ThresholdInfo.NbrOfPmtRequested2.ToString() + " of 2nd time campers" ;
                break;
            default:
                strThresholdInfo = "No community incentive thresholds";
                strRequestedPaymentInfo = "N/A";
                break;
        }
            
        //ThresholdInfo
        ReportParameter reportThresholdInfo = new ReportParameter();
        reportThresholdInfo.Name = "ThresholdInfo";
        strParamValue = strThresholdInfo;
        reportThresholdInfo.Values.Add(strParamValue);

        //RequestedPaymentInfo
        ReportParameter reportRequestedPaymentInfo = new ReportParameter();
        reportRequestedPaymentInfo.Name = "RequestedPaymentInfo";
        strParamValue = strRequestedPaymentInfo;
        reportRequestedPaymentInfo.Values.Add(strParamValue);
        //*************************

        //Added by Ram for running the report locally
        //IReportServerCredentials irsc = new CustomReportCredentials("trajesh", "ness@123456", "Innovahyd");
        //ReportViewer1.ServerReport.ReportServerCredentials = irsc;
		//IReportServerCredentials irsc = new CustomReportCredentials("ness", "wayne@1234", "FILE");
		//ReportViewer1.ServerReport.ReportServerCredentials = irsc;


        // Set the report parameters for the report
        ReportViewer1.ServerReport.SetParameters(
            new ReportParameter[] { reportMode, reportFederation, reportFederationID, reportPaymentID, reportCampYear, reportThresholdInfo, reportRequestedPaymentInfo });

        if (radFinal.Checked)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            string deviceInfo;

            deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";

            byte[] bytes = ReportViewer1.ServerReport.Render(
                "PDF", null, out mimeType, out encoding, out extension,
                out streamids, out warnings);
            string datetime = Convert.ToString(DateTime.Now);
            datetime=datetime.Replace('/', '_');
            datetime=datetime.Replace(':', '_');
            string strPaymentReportURL = ConfigurationManager.AppSettings["PaymentReportPath"];
            strPaymentReportURL = strPaymentReportURL + FederationName + "_" + datetime + ".pdf";
            //FederationID + "_" + Convert.ToString(DateTime.Now) +
            //ConfigurationManager.AppSettings["PaymentReportPath"] + FederationID + DateTime.Now
            FileStream fs =
                new FileStream(@strPaymentReportURL, FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
        }
    }

    protected void radFinal_CheckedChanged(object sender, EventArgs e)
    {
        SetFinalAlert();
    }
    protected void radPreliminary_CheckedChanged(object sender, EventArgs e)
    {
        SetFinalAlert();
    }
    protected void lstFederations_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstFederations.SelectedIndex != -1 || lstFederations.SelectedValue != "0")
        {
           
        }
    }
}

public class CustomReportCredentials : IReportServerCredentials
{
    // local variable for network credential.

    private string _UserName;
    private string _PassWord;
    private string _DomainName;

    public CustomReportCredentials(string UserName, string PassWord, string DomainName)
    {
        _UserName = UserName;
        _PassWord = PassWord;
        _DomainName = DomainName;
    }

    public WindowsIdentity ImpersonationUser
    {
        get
        {
            return null; // not use ImpersonationUser
        }
    }

    public ICredentials NetworkCredentials
    {
        get
        {
            // use NetworkCredentials
            return new NetworkCredential(_UserName, _PassWord, _DomainName);
        }
    }

    public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
    {
        // not use FormsCredentials unless you have implements a custom autentication.
        authCookie = null;
        user = password = authority = null;
        return false;
    }
}
