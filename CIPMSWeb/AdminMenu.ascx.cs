using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CIPMSBC;
using CIPMSBC.DAL;


public partial class AdminMenu : System.Web.UI.UserControl
{
    private SrchCamperDetails _objCamperDet = new SrchCamperDetails();
    private bool _IsMenuVisible = true;
    protected string strUserID;

    //Public Property IsMenuVisile
    public bool IsMenuVisible
    {
        get
        {
            return _IsMenuVisible;
        }
        set
        {
            _IsMenuVisible = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
			string localIP = Dns.GetHostAddresses(Request.Url.Host)[0].ToString();
            string prodIP = ConfigurationManager.AppSettings["ProductionServerIP"];

			if ( localIP != prodIP )
			{
                hylCIPRS.NavigateUrl = string.Format("http://uat.onehappycamper.org/CIPRS/Default.aspx", localIP);
			}
			else
			{
				hylCIPRS.NavigateUrl = "https://www.onehappycamper.org/CIPRS/Default.aspx";
			}

            var oCam = new CamperApplication();

            this.Visible = IsMenuVisible;
            
            if ((string)Session["RoleID"] == ConfigurationManager.AppSettings["FJCADMIN"])
            {
                dvRpts.Visible = false;
                lnkStatsReport.Visible = true;
                lnkBulkStatusUpdate.Visible = true;
            }
         
            if ((string)Session["RoleID"] != ConfigurationManager.AppSettings["FJCADMIN"])
            {
                dvAdmin.Visible = false;
                dvRpts.Visible = false;
                divCheckRequest.Visible = false;
                divAudit.Visible = false;
                divANReport.Visible = false;
                divPPIReport.Visible = false;
                lnkStatsReport.Visible = false;
            }

			// 2013-01-03 Temporarily allow Philly and Boston admin to do payment processing
			var fedId = (string)Session["FedID"];
            int allowFedId = SchedulerDA.GetPaymentAccessFedID(DateTime.Now);
            if (fedId == allowFedId.ToString())
			{
				divCheckRequest.Visible = true;
			}

            if ((string)Session["RoleID"] != ConfigurationManager.AppSettings["FJCADMIN"].ToString())
            {
                divExcel.Visible = false;                
            }

            //Added by Ram (03/31/2010) related to upload link (should be available for FJC admin and PJL fedAdmin
            if ((string)Session["RoleID"] == ConfigurationManager.AppSettings["FJCADMIN"].ToString()
                || ((string)Session["RoleID"] == ConfigurationManager.AppSettings["FEDADMIN"].ToString() && (string)Session["FedID"] == ConfigurationManager.AppSettings["PJL"].ToString()))
            {
                divUpload.Visible = true;
            }
            _objCamperDet.UserId = Convert.ToInt16(Session["UsrID"]);
 
            string strUrl = Request.AppRelativeCurrentExecutionFilePath;

            switch (strUrl)
            {
                case ("~/Administration/Search/WorkQueue.aspx"): //if Work Queue link is clicked
                    {
                        lnkWrkQ.ForeColor = System.Drawing.Color.Maroon;
                        lnkSearch.ForeColor = System.Drawing.Color.Blue;
                        lnkSumByCamps.ForeColor = System.Drawing.Color.Blue;
                        lnkSumByStatus.ForeColor = System.Drawing.Color.Blue;
                        lnkAdmin.ForeColor = System.Drawing.Color.Blue;
                        lnkCreateUsr.ForeColor = System.Drawing.Color.Blue;
                        lnkManageUsr.ForeColor = System.Drawing.Color.Blue;
                        lnkChangePwd.ForeColor = System.Drawing.Color.Blue;
                        lnkLogOut.ForeColor = System.Drawing.Color.Blue;
                    }
                    break;

                case ("~/Administration/Search/AdminSearch.aspx"): //if Search link is clicked
                    {
                        lnkWrkQ.ForeColor = System.Drawing.Color.Blue;
                        lnkSearch.ForeColor = System.Drawing.Color.Maroon;
                        lnkSumByCamps.ForeColor = System.Drawing.Color.Blue;
                        lnkSumByStatus.ForeColor = System.Drawing.Color.Blue;
                        lnkAdmin.ForeColor = System.Drawing.Color.Blue;
                        lnkCreateUsr.ForeColor = System.Drawing.Color.Blue;
                        lnkManageUsr.ForeColor = System.Drawing.Color.Blue;
                        lnkChangePwd.ForeColor = System.Drawing.Color.Blue;
                        lnkLogOut.ForeColor = System.Drawing.Color.Blue;
                    }
                    break;

                case ("~/Administration/ManageUser.aspx"): //if Work Administration or Manage User link is clicked
                    {
                        lnkWrkQ.ForeColor = System.Drawing.Color.Blue;
                        lnkSearch.ForeColor = System.Drawing.Color.Blue;
                        lnkSumByCamps.ForeColor = System.Drawing.Color.Blue;
                        lnkSumByStatus.ForeColor = System.Drawing.Color.Blue;
                        lnkAdmin.ForeColor = System.Drawing.Color.Blue;
                        lnkCreateUsr.ForeColor = System.Drawing.Color.Blue;
                        lnkManageUsr.ForeColor = System.Drawing.Color.Maroon;
                        lnkChangePwd.ForeColor = System.Drawing.Color.Blue;
                        lnkLogOut.ForeColor = System.Drawing.Color.Blue;
                    }
                    break;

                case ("~/Administration/CreateUser.aspx"): //if Work Create User link is clicked
                    {
                        lnkWrkQ.ForeColor = System.Drawing.Color.Blue;
                        lnkSearch.ForeColor = System.Drawing.Color.Blue;
                        lnkSumByCamps.ForeColor = System.Drawing.Color.Blue;
                        lnkSumByStatus.ForeColor = System.Drawing.Color.Blue;
                        lnkAdmin.ForeColor = System.Drawing.Color.Blue;
                        lnkCreateUsr.ForeColor = System.Drawing.Color.Maroon;
                        lnkManageUsr.ForeColor = System.Drawing.Color.Blue;
                        lnkChangePwd.ForeColor = System.Drawing.Color.Blue;
                        lnkLogOut.ForeColor = System.Drawing.Color.Blue;
                    }
                    break;

                case ("~/Administration/ChangePwd.aspx"): //if Work Change Password link is clicked
                    {
                        lnkWrkQ.ForeColor = System.Drawing.Color.Blue;
                        lnkSearch.ForeColor = System.Drawing.Color.Blue;
                        lnkSumByCamps.ForeColor = System.Drawing.Color.Blue;
                        lnkSumByStatus.ForeColor = System.Drawing.Color.Blue;
                        lnkAdmin.ForeColor = System.Drawing.Color.Blue;
                        lnkCreateUsr.ForeColor = System.Drawing.Color.Blue;
                        lnkManageUsr.ForeColor = System.Drawing.Color.Blue;
                        lnkChangePwd.ForeColor = System.Drawing.Color.Maroon;
                        lnkLogOut.ForeColor = System.Drawing.Color.Blue;
                    }
                    break;
            }
        }
    }

    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
        _objCamperDet.UserId = Convert.ToInt16(Session["UsrID"]);
        _objCamperDet.LockUnlockRecord("UnLock");
        Session.Clear();
        Session.RemoveAll();
        Session.Abandon();
        Session["UsrID"] = null;
        Response.CacheControl = "no-cache";
        Response.Expires = -1;
        FormsAuthentication.SignOut();
        //Server.Transfer("~/Default.aspx");
        Response.Redirect("~/Default.aspx");
    }

    protected void lnkWrkQ_Click(object sender, EventArgs e)
    {
        _objCamperDet.UserId = Convert.ToInt16(Session["UsrID"]);
        _objCamperDet.LockUnlockRecord("UnLock");
        Response.Redirect("~/Administration/Search/WorkQueue.aspx");
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        _objCamperDet.UserId = Convert.ToInt16(Session["UsrID"]);
        _objCamperDet.LockUnlockRecord("UnLock");
        //TV: 04/2009 - Task # A-052 - fix Search/Manage user bug - replaced
        //Server.Transfer with Response.Redirect to fix problems with the link
        //thinking the AdminSearch.aspx page is in a different folder than it really is in
        Response.Redirect("~/Administration/Search/AdminSearch.aspx");

    }

    protected void lnkRpts_Click(object sender, EventArgs e)
    {
        _objCamperDet.UserId = Convert.ToInt16(Session["UsrID"]);
        _objCamperDet.LockUnlockRecord("UnLock");
        //Server.Transfer("");
    }

    protected void lnkAdmin_Click(object sender, EventArgs e)
    {
        _objCamperDet.UserId = Convert.ToInt16(Session["UsrID"]);
        _objCamperDet.LockUnlockRecord("UnLock");
        Response.Redirect("~/Administration/ManageUser.aspx");
    }

    protected void lnkCreateUsr_Click(object sender, EventArgs e)
    {
        _objCamperDet.UserId = Convert.ToInt16(Session["UsrID"]);
        _objCamperDet.LockUnlockRecord("UnLock");
        //TV: 04/2009 - Task # A-051 - fix Create User/ Update User bug - the QueryString does not
        //get cleared out properly with Server.Transfer, so use Response.Redirect instead
        Response.Redirect("~/Administration/CreateUser.aspx");
    }

    protected void lnkManageUsr_Click(object sender, EventArgs e)
    {
        _objCamperDet.UserId = Convert.ToInt16(Session["UsrID"]);
        _objCamperDet.LockUnlockRecord("UnLock");
        //TV: 04/2009 - Task # A-052 - fix Search/Manage user bug - replaced
        //Server.Transfer with Response.Redirect to fix problems with the link
        //thinking the AdminSearch.aspx page is in a different folder than it really is in
        Response.Redirect("~/Administration/ManageUser.aspx");
    }

    protected void lnkChangePwd_Click(object sender, EventArgs e)
    {
        _objCamperDet.UserId = Convert.ToInt16(Session["UsrID"]);
        _objCamperDet.LockUnlockRecord("UnLock");
        Response.Redirect("~/Administration/ChangePwd.aspx");
    }

    protected void lnkSumByCamps_Click(object sender, EventArgs e)
    {
        _objCamperDet.UserId = Convert.ToInt16(Session["UsrID"]);
        _objCamperDet.LockUnlockRecord("UnLock");
        Response.Redirect("~/Administration/Reports/Rpt_SummaryReport.aspx?rpt=camps");
    }

    protected void lnkSumByStatus_Click(object sender, EventArgs e)
    {
        _objCamperDet.UserId = Convert.ToInt16(Session["UsrID"]);
        _objCamperDet.LockUnlockRecord("UnLock");
        Response.Redirect("~/Administration/Reports/Rpt_SummaryReport.aspx?rpt=status");
    }
    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        if ((string)Session["RoleID"] == ConfigurationManager.AppSettings["FEDADMIN"].ToString())
        {
            string strAlertScript = "<script language=javascript>AlertMessage(); </script>";
            if (!Page.ClientScript.IsStartupScriptRegistered("clientScript"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strAlertScript);
            }
        }
        else
        {
            Response.Redirect("~/ExcelExport.aspx");
        }
        //Response.Redirect("~/ExcelExport.aspx?prior=0");
    }
    protected void lnkPayment_Click(object sender, EventArgs e)
    {
        _objCamperDet.UserId = Convert.ToInt16(Session["UsrID"]);
        _objCamperDet.LockUnlockRecord("UnLock");
        Response.Redirect("~/Administration/Search/PaymentRequest.aspx");
    }
    protected void lnkAudit_Click(object sender, EventArgs e)
    {
        _objCamperDet.UserId = Convert.ToInt16(Session["UsrID"]);
        _objCamperDet.LockUnlockRecord("UnLock");
        Response.Redirect("~/Administration/Search/AuditReport.aspx");
    }
    protected void lnkSummary_Click(object sender, EventArgs e)
    {
        _objCamperDet.UserId = Convert.ToInt16(Session["UsrID"]);
        _objCamperDet.LockUnlockRecord("UnLock");
        Response.Redirect("~/Administration/Search/ExecSummary.aspx");
    }
    //protected void lnkExcel2_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/ExcelExport.aspx?prior=1");
    //}

    protected void lnkUpload_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administration/Upload.aspx");
    }
    protected void lnkANReprot_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administration/AwardNotificationReqest.aspx");
    }
    protected void lnkPPIReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administration/ProgramProfileInformationReport.aspx");
    }
    protected void lnkStatsReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administration/StatisticsReportGeneration.aspx");
    }

    protected void lnkBulkStatusUpdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administration/BulkStatusUpdate.aspx");
    }
}
