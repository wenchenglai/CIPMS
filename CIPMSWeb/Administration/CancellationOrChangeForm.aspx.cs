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
using CIPMSBC;

public partial class Administration_CancellationOrChangeForm : System.Web.UI.Page
{
    CamperApplication objCamperApplication;
    General objGeneral;
    DataSet dsCamperApplication;
    
    private int iUserRole = 0;
    private int iUserID = 0;
    private string FJCAdminUserRole = ConfigurationManager.AppSettings["FJCADMIN"].ToString();
    private string FEDAdminUserRole = ConfigurationManager.AppSettings["FEDADMIN"].ToString();
    string sessionModifiedPenFJCApprovalStatus = ConfigurationManager.AppSettings["Session Modified Pending FJC approval"];
    string sessionModifiedCreditPending = ConfigurationManager.AppSettings["Session Modified Credit Pending"];
    string secApprovalStatus = ConfigurationManager.AppSettings["Second Approval"];
    string cancellationPendingApprovalStatus = ConfigurationManager.AppSettings["Payment Cancellation Pending FJC approval"];
    string cancellationPaymentCreditPending = ConfigurationManager.AppSettings["Payment Cancellation Credit Pending"];
    private string strFJCID = string.Empty;
    public string CampStartDate = string.Empty;
    public string CampEndDate = string.Empty;
    private string strScript = string.Empty;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        objCamperApplication = new CamperApplication();
        structChangeDetails changeDetails = new structChangeDetails();
        string campYearId = null;
        valobj.InnerHtml = string.Empty;
        pnlUpdateStatus.Visible = pnlNewRequest.Visible = false;
        bool error= false;
        if (Session["UsrID"] != null)
        {            
            if (Session["FJCID"] != null)
            {
                strFJCID = Session["FJCID"].ToString();
                 if (!IsPostBack)
                {
                    ExisitingDetailsDataBind(strFJCID, changeDetails, false);
                    changeDetails = new structChangeDetails();
                    DataSet dsChangeDetails = objCamperApplication.GetChangeRequestDetails(strFJCID);
                    if (dsChangeDetails.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsChangeDetails.Tables[0].Rows)
                        {
                            changeDetails = objCamperApplication.SetChangeDetailsFromDataRow(dr);
                            hdnRequestID.Value = changeDetails.RequestID.ToString();
                            SetControlValues(changeDetails);
                            hdnRequestStatus.Value = changeDetails.RequestStatus.ToString();
                            if (changeDetails.RequestStatus == 3 || changeDetails.RequestStatus == 2)
                                lnkBtnNewRequest.Visible = true;
                            else
                                lnkBtnNewRequest.Visible = false;
                        }
                    }
                    
                    
                }

                GetRequestUserDetails(Session["UsrID"].ToString());

                imgbtnCalStartDt.Attributes.Add("onclick", "return ShowCalendar('" + txtNewStartDate.ClientID + "');");
                imgbtnCalEndDt.Attributes.Add("onclick", "return ShowCalendar('" + txtNewEndDate.ClientID + "');");

                if (hdnRequestStatus.Value != "0" && !String.IsNullOrEmpty(hdnRequestStatus.Value))
                {
                    pnlForm.Enabled = false;
                }
                else
                {
                    pnlForm.Enabled = true;
                }

                if (iUserRole.ToString() == FJCAdminUserRole && hdnRequestStatus.Value == "1")
                {
                    pnlUpdateStatus.Visible = ddlRequestStatus.Enabled = btnUpdateStatus.Enabled = pnlUpdateStatus.Enabled = true;
                }
                if (iUserRole.ToString() == FEDAdminUserRole && hdnNewRequest.Value != "1" && (hdnRequestStatus.Value == "2" ||hdnRequestStatus.Value == "3"))
                {
                    pnlNewRequest.Visible = lnkBtnNewRequest.Enabled = true;
                }

                pnlComments.Visible = false;
                rfvComments.Enabled = false;
                //added by sreevani to display calender according to session year.
                campYearId = objCamperApplication.getCampYearId(strFJCID);
                string campyear = Application["CampYear"].ToString();

                CampStartDate = ConfigurationManager.AppSettings["CampSessionStartMonth"] + "/01/" + campyear;
                hdnCampSessionStartDate.Value = DateTime.Parse(CampStartDate).AddDays(-1.0).ToShortDateString();
                CampEndDate = ConfigurationManager.AppSettings["CampSessionEndMonth"] + "/01/" + campyear;
                hdnCampSessionEndDate.Value = DateTime.Parse(CampEndDate).AddMonths(1).ToShortDateString();
                hdncampSeasonErrorMessage.Value = "Choose camp session between " + DateTime.Parse(CampStartDate).ToShortDateString() + " and " + DateTime.Parse(CampEndDate).AddMonths(1).AddDays(-1.0).ToShortDateString();
            }
            else
            {
                error = true;
            }
        }
        else
		{
            error = true;
        }

        if (error)
        {
            strScript = "<script language=javascript>alert('Error occured please try again!'); window.opener.location.href = window.opener.location.href;" +
                             "if (window.opener.progressWindow)" +
                             "{    window.opener.progressWindow.close()" +
                             "}    window.close();</script>";
            if (!ClientScript.IsStartupScriptRegistered("clientScript"))
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strScript);
            }
        }
        if (pnlForm.Enabled)
        {
            btnSaveExit.Attributes.Add("onclick", "JavaScript:return ValidateForm(0);false;");
            btnSubmit.Attributes.Add("onclick", "JavaScript:return ValidateForm(1);false;");
        }
    }

    protected void lnkBtnNewRequest_OnClick(object sender, EventArgs e)
    {
        structChangeDetails changeDetails = new structChangeDetails();
        ExisitingDetailsDataBind(strFJCID, changeDetails,true);
        hdnRequestStatus.Value = "0";
        hdnNewRequest.Value = "1";
        pnlForm.Enabled = true;
        lnkBtnNewRequest.Visible = false;
        lblAdjustmentType.Visible = false;
        rdBtnLstAdjustmentType.Visible = true;
        btnSaveExit.Attributes.Add("onclick", "JavaScript:return ValidateForm(0);false;");
        btnSubmit.Attributes.Add("onclick", "JavaScript:return ValidateForm(1);false;");
    }

    /// <summary>
    /// This GetRequestUserDetails gets details of the user
    /// </summary>
    /// <param name="strUserID">UserID</param>
    private void GetRequestUserDetails(string strUserID)
    {
        Administration objAdmin = new Administration();
        DataSet dsUserDetails = objAdmin.GetUserDetails(strUserID);
        if (dsUserDetails.Tables[0].Rows.Count > 0)
        {
            DataRow drUserDetail = dsUserDetails.Tables[0].Rows[0];
            lblEmail.Text = drUserDetail["Email"].ToString();
            lblPhone.Text = drUserDetail["PhoneNumber"].ToString();
            lblAdminUserName.Text = drUserDetail["FirstName"].ToString() + " " + drUserDetail["LastName"].ToString();
            iUserRole = Int32.TryParse(drUserDetail["UserRole"].ToString(), out iUserRole) ? Int32.Parse(drUserDetail["UserRole"].ToString()) : 0;
            iUserID = Int32.TryParse(strUserID, out iUserID) ? Int32.Parse(strUserID) : 0;
        }
    }    

    /// <summary>
    /// This method gets camperinfo and binds it to the lables
    /// </summary>
    /// <param name="strFJCID"></param>
    private void ExisitingDetailsDataBind(string strFJCID, structChangeDetails changeDetails, bool newReq)
    {
        if (!String.IsNullOrEmpty(strFJCID))
        {
            dsCamperApplication = objCamperApplication.GetCamperInfo(strFJCID);
            if (dsCamperApplication.Tables[0].Rows.Count > 0)
            {
                DataRow drCamperInfo = dsCamperApplication.Tables[0].Rows[0];
                lblCamperFirstName.Text = drCamperInfo["FirstName"].ToString();
                lblCamperLastName.Text = drCamperInfo["LastName"].ToString();
                lblFJCID.Text = drCamperInfo["FJCID"].ToString();
                lblFederationName.Text = drCamperInfo["Program"].ToString();
                lblCamp.Text = drCamperInfo["Camp"].ToString();
                lblFirstSecondTime.Text = drCamperInfo["TimeInCamp"].ToString();
                lblGrant.Text = "$" + drCamperInfo["GrantAmount"].ToString();
                lblStartDate.Text = drCamperInfo["StartDate"].ToString();
                lblEndDate.Text = drCamperInfo["EndDate"].ToString();
                lblSession.Text = drCamperInfo["OldSession"].ToString();
                if (changeDetails.RequestType == 2)
                {
                    lblGrant.Text = "$" + changeDetails.OldGrantAmount.ToString();
                    lblStartDate.Text = changeDetails.OldSession_StartDate.ToString();
                    lblEndDate.Text = changeDetails.OldSession_EndDate.ToString();
                }
                lblDays.Text = drCamperInfo["Days"].ToString();
                lblAdjustmentType.Text = drCamperInfo["RequestType"].ToString();
                lblCampID.Text = drCamperInfo["CampID"].ToString();
                lblCurrStatus.Text = drCamperInfo["CurrStatus"].ToString();
                lblFJCMatch.Text = drCamperInfo["FJCMatch"].ToString();
                if (newReq)
                {
                    rdBtnLstAdjustmentType.Visible = true;
                    lblAdjustmentType.Visible = false;
                    if (rdBtnLstAdjustmentType != null)
                    { rdBtnLstAdjustmentType.SelectedIndex = -1; SetControlValues(changeDetails); }
                }
                else
                {
                    rdBtnLstAdjustmentType.Visible = false;
                    lblAdjustmentType.Visible = true;
                    string reqType = String.IsNullOrEmpty(lblAdjustmentType.Text) ? (Request.QueryString["RequestType"] != null ? Request.QueryString["RequestType"].ToString() : "0") : lblAdjustmentType.Text;
                    SetRequestType(reqType);
                }
            }
        }
    }

    private void SetRequestType(string reqType)
    {
        if (rdBtnLstAdjustmentType != null)
        {
          if (!reqType.Equals("0") && !String.IsNullOrEmpty(reqType))
            {
                rdBtnLstAdjustmentType.SelectedValue = reqType;
                lblAdjustmentType.Text = rdBtnLstAdjustmentType.SelectedItem.Text;
            }
        }
        pnlCancellation.Visible = reqType.Equals("1") ? true : false;
        pnlSessionChange.Visible = reqType.Equals("2") ? true : false;
        if (reqType.Equals("2"))
        {
            GetCampSessionsForCamp(lblCampID.Text);
        }
    }

    protected void rdBtnLstAdjustmentType_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        pnlCancellation.Visible = rdBtnLstAdjustmentType.SelectedValue.Equals("1") ? true : false;
        pnlSessionChange.Visible = rdBtnLstAdjustmentType.SelectedValue.Equals("2") ? true : false;
        txtCancelComments.Text = txtNewEndDate.Text = txtNewStartDate.Text = txtCampSession.Text = lblSysNewStartDate.Text = lblSysNewEndDate.Text = lblNewNoOfDays.Text = string.Empty;
        ddlCampSession.SelectedIndex = -1; lblNewNoOfDays.Text = "";
        lblNewGrant.Text = txtCampSession.Text = string.Empty;
        valobj.InnerText = "";
        if (rdBtnLstAdjustmentType.SelectedValue.Equals("2"))
        {
            if (ddlCampSession.Items.Count == 0) GetCampSessionsForCamp(lblCampID.Text);
        }
        
    }

    protected void btnUpdateStatus_OnClick(object sender, EventArgs e)
    {
        DataSet dsChangeDetails = objCamperApplication.GetChangeRequestDetails(strFJCID);
        structChangeDetails ChangeDetails = new structChangeDetails();
        string strReason = txtareaUpdateComments.Text;
        if (!string.IsNullOrEmpty(strReason))
        {

            if (dsChangeDetails.Tables[0].Rows.Count > 0)
            {
                ChangeDetails = objCamperApplication.SetChangeDetailsFromDataRow(dsChangeDetails.Tables[0].Rows[0]);
            }
            if (ddlRequestStatus.SelectedValue == Enum.Format(typeof(RequestStatus), RequestStatus.ClosedOrApproved, "D"))
            {
                if (sessionModifiedPenFJCApprovalStatus == ChangeDetails.Current_Status.ToString())
                {
                    string strNewFJCID = string.Empty;
                    string answers = ConstructCamperAnswers(ChangeDetails.NewSession, ChangeDetails.NewSession_StartDate, ChangeDetails.NewSession_EndDate);
                    objCamperApplication.CopyCamperApplicationForSessionChange(strFJCID, out strNewFJCID, Int32.Parse(secApprovalStatus), Convert.ToInt32(sessionModifiedCreditPending));
                    Session["FJCID"] = strNewFJCID;
                    objCamperApplication.InsertCamperAnswers(strNewFJCID, answers, iUserID.ToString(), strReason);
                    objCamperApplication.UpdateDetailsOnRequestType(strFJCID, strNewFJCID, ChangeDetails.RequestID, "", "Old application cancelled and new application created with second approval status", iUserID, null, null, Int32.Parse(Enum.Format(typeof(RequestStatus), RequestStatus.ClosedOrApproved, "D")));
                }
                else if(cancellationPendingApprovalStatus == ChangeDetails.Current_Status.ToString())
                {
                    string strNewFJCID = string.Empty;
                    objCamperApplication.UpdateStatus(strFJCID, Int32.Parse(cancellationPaymentCreditPending), strReason, iUserID);
                    objCamperApplication.UpdateDetailsOnRequestType(strFJCID, string.Empty, ChangeDetails.RequestID, "", "Cancellation request approved and the payment will be applied for credit.", iUserID, null, null, Int32.Parse(Enum.Format(typeof(RequestStatus), RequestStatus.ClosedOrApproved, "D")));
                }
            }
            else if (ddlRequestStatus.SelectedValue == Enum.Format(typeof(RequestStatus), RequestStatus.Rejected, "D"))
            {
                string strCamperAnswers = string.Empty;
                    if(ChangeDetails.RequestType == 2) strCamperAnswers = ConstructCamperAnswers(ChangeDetails.OldSession, ChangeDetails.OldSession_StartDate, ChangeDetails.OldSession_EndDate);
                
                objCamperApplication.UpdateDetailsOnRequestType(strFJCID, string.Empty, ChangeDetails.RequestID, strCamperAnswers, string.Empty, iUserID, null, null, Int32.Parse(Enum.Format(typeof(RequestStatus), RequestStatus.Rejected, "D")));
            }
            valobj.InnerHtml = "";
            spnComments.Visible = false;
            string strMessage = ddlRequestStatus.SelectedValue == "3" ? "Request has been approved." : "Request has been rejected.";
            strScript = "<script language=javascript>" + (strMessage != string.Empty ? "alert('" + strMessage + "');" : string.Empty) + "window.opener.location.href = window.opener.location.href;" +
                        "if (window.opener.progressWindow)" +
                        "{    window.opener.progressWindow.close()" +
                        "}    window.close();</script>";
            if (!ClientScript.IsStartupScriptRegistered("clientScript"))
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strScript);
            } 
        }
        else
        {
            valobj.InnerHtml = "<ul><li>Please enter comments</li></ul>";
            spnComments.Visible = true;
        }
    }

    /// <summary>
    /// GetCampSessionsForCamp method gets session information for the camp
    /// </summary>
    /// <param name="strCampID">CampID</param>
    private void GetCampSessionsForCamp(string strCampID)
    {
        if (!strCampID.Equals(string.Empty) && !strCampID.Equals("-1"))
        {
            //added by sandhya

            pnlManualSessionDates.Visible = true; btnCalculateDaysGrant.Visible = true;
            pnlSystemSessionDates.Visible = false;

            //commented by sandhya

            //objGeneral = new General();
            //try
            //{
            //    DataSet dsCampSessionsForCamp = objGeneral.GetCampSessionsForCamp(Int32.Parse(strCampID));
            //    if (dsCampSessionsForCamp.Tables[0].Rows.Count > 0)
            //    {
            //        ddlCampSession.DataSource = dsCampSessionsForCamp.Tables[0];
            //        ddlCampSession.DataTextField = "Name";
            //        ddlCampSession.DataValueField = "ID";
            //        ddlCampSession.DataBind();
            //        ddlCampSession.Items.Insert(0, new ListItem("Select", "0"));
            //        pnlManualSessionDates.Visible = false; btnCalculateDaysGrant.Visible = false;
            //        pnlSystemSessionDates.Visible = true;
            //        GetDaysAndGrant();
            //    }
            //    else
            //    {
            //        pnlManualSessionDates.Visible = true; pnlSystemSessionDates.Visible = false;
            //    }
            //    pnlSessionChange.Visible = true;
            //    valobj.InnerText = "";
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        else
        {
            pnlSessionChange.Visible = false;
            valobj.InnerHtml = "<ul><li>No Camp info, please select camp then try requesting for change.</li></ul>";
            btnClear.Enabled = btnSaveExit.Enabled = btnSubmit.Enabled = false;
        }
    }

    protected void ddlCampSession_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCampSession.SelectedIndex != -1)
        {
            if (ddlCampSession.SelectedValue == "0")
            {
                lblSysNewStartDate.Text = lblSysNewEndDate.Text = "";
                lblNewNoOfDays.Text = "";
                lblNewGrant.Text = "";
            }
            else
            {
                GetCampSessionDetails(ddlCampSession.SelectedValue);
                GetDaysAndGrant();
            }
        }        
    }

    /// <summary>
    /// This GetCampSessionDetails gets session details startdate and end date for the session
    /// </summary>
    /// <param name="strCampSessionID">SessionID</param>
    private void GetCampSessionDetails(string strCampSessionID)
    {
        objGeneral = new General();
        try
        {
            DataSet dsCampSessionDetails = objGeneral.GetCampSessionDetail(Int32.Parse(strCampSessionID));
            if (dsCampSessionDetails.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dsCampSessionDetails.Tables[0].Rows[0];
                lblSysNewStartDate.Text = DateTime.Parse(dr["StartDate"].ToString()).ToShortDateString();
                lblSysNewEndDate.Text = DateTime.Parse(dr["EndDate"].ToString()).ToShortDateString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GetDaysAndGrant()
    {
        DateTime dtStartDate, dtEndDate;
        dtStartDate = dtEndDate = DateTime.MinValue;
        TimeSpan ts = new TimeSpan();
        lblNewNoOfDays.Text = string.Empty;
        if (ddlCampSession.Items.Count > 1)
        {
            if (lblSysNewStartDate.Text != string.Empty && lblSysNewEndDate.Text != string.Empty)
            {
                dtEndDate = DateTime.Parse(lblSysNewEndDate.Text);
                dtStartDate = DateTime.Parse(lblSysNewStartDate.Text);
            }
        }
        else
        {
            if (txtNewEndDate.Text != string.Empty && txtNewStartDate.Text != string.Empty)
            {
                dtEndDate = DateTime.Parse(txtNewEndDate.Text);
                dtStartDate = DateTime.Parse(txtNewStartDate.Text);
            }
        }

        if (dtEndDate != DateTime.MinValue && dtStartDate != DateTime.MinValue)
        {
            if (dtEndDate > dtStartDate)
            {
                ts = dtEndDate.Subtract(dtStartDate);
                lblNewNoOfDays.Text = (ts.Days + 1).ToString();
            }
        }

        if (lblNewNoOfDays.Text != string.Empty)
        {
            objCamperApplication = new CamperApplication();
            lblNewGrant.Text = "$" + objCamperApplication.GetGrantFromDaysCamp(lblFJCID.Text, lblNewNoOfDays.Text, lblCampID.Text, lblFirstSecondTime.Text).ToString();
        }
    }

    protected void btnCalculateDaysGrant_Click(object sender, EventArgs e)
    {
        GetDaysAndGrant();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        if (!strFJCID.Equals(string.Empty))
        {
            DataSet dsChangeRequestDetails = objCamperApplication.GetChangeRequestDetails(strFJCID);
            structChangeDetails changeDetails = new structChangeDetails();
            if (dsChangeRequestDetails.Tables[0].Rows.Count > 0 && String.IsNullOrEmpty(hdnNewRequest.Value))
            {
                foreach (DataRow dr in dsChangeRequestDetails.Tables[0].Rows)
                {
                    changeDetails = objCamperApplication.SetChangeDetailsFromDataRow(dr);
                }                
            }
            else
            {
                txtCancelComments.Text = lblNewNoOfDays.Text = lblSysNewEndDate.Text = lblSysNewStartDate.Text = txtNewStartDate.Text = txtNewEndDate.Text = txtCampSession.Text = string.Empty;
                lblNewGrant.Text = "";
                rdBtnLstAdjustmentType.SelectedIndex = ddlCampSession.SelectedIndex = -1;
                changeDetails.RequestType = 0;
                changeDetails.RequestStatus = -1;
                if (Request.QueryString["RequestType"] != null)
                    changeDetails.RequestType = Int32.Parse(Request.QueryString["RequestType"].ToString());
            }
            SetControlValues(changeDetails);
        }        
    }

    private void SetControlValues(structChangeDetails changeDetails)
    {
        string errorMessage = string.Empty;
        if (String.IsNullOrEmpty(changeDetails.RequestStatus.ToString()) || changeDetails.RequestStatus == -1)
            lblRequestStatus.Text = "No_Request_Submitted";
        else
            lblRequestStatus.Text = Enum.Format(typeof(RequestStatus), changeDetails.RequestStatus, "G");
            
        if (changeDetails.RequestType == 2)
        {
            DateTime dt_NewEndDate = new DateTime();
            DateTime dt_NewStartDate = new DateTime();
            if (DateTime.TryParse(changeDetails.NewSession_EndDate, out dt_NewEndDate) && DateTime.TryParse(changeDetails.NewSession_StartDate, out dt_NewStartDate))
            {
                lblNewNoOfDays.Text = (dt_NewEndDate.Subtract(dt_NewStartDate).Days + 1).ToString();
            }           
            
            ddlRequestStatus.SelectedItem.Value = changeDetails.RequestStatus.ToString();
            rdBtnLstAdjustmentType.SelectedValue = changeDetails.RequestType.ToString();    
            lblAdjustmentType.Text = rdBtnLstAdjustmentType.SelectedItem.Text;
            

            lblNewGrant.Text = "$" + changeDetails.NewGrantAmount.ToString();
            lblSysNewStartDate.Text = txtNewStartDate.Text = changeDetails.NewSession_StartDate;
            lblSysNewEndDate.Text = txtNewEndDate.Text = changeDetails.NewSession_EndDate;
            int campSessionID=0;
            if (pnlSystemSessionDates.Visible)
                if (Int32.TryParse(changeDetails.NewSession, out campSessionID))
                    ddlCampSession.SelectedValue = campSessionID.ToString();

            if (pnlManualSessionDates.Visible)
                if (!String.IsNullOrEmpty(changeDetails.NewSession))
                    txtCampSession.Text = changeDetails.NewSession.ToString();

            if (lblCampID.Text == string.Empty)
            {
                valobj.InnerHtml = "<ul><li>No Camp info, please select camp then try requesting for change.</li></ul>";
                btnClear.Enabled = btnSaveExit.Enabled = btnSubmit.Enabled = false;
            }
            pnlCancellation.Visible = false;
            pnlSessionChange.Visible = true;
        }
        else if (changeDetails.RequestType == 1)
        {
            ddlRequestStatus.SelectedItem.Value = changeDetails.RequestStatus.ToString();
            rdBtnLstAdjustmentType.SelectedValue = changeDetails.RequestType.ToString();
            txtCancelComments.Text = changeDetails.Cancellation_Reason;
            pnlCancellation.Visible = true;
            pnlSessionChange.Visible = false;
            valobj.InnerText = "";
        }
        else
        {
            pnlCancellation.Visible = false;
            pnlSessionChange.Visible = false;
        }
		//if ((changeDetails.RequestStatus == 1 || changeDetails.RequestStatus == 2 || changeDetails.RequestStatus == 3))
		//{
		//    btnClear.Enabled = btnSaveExit.Enabled = btnSubmit.Enabled = false;
		//}
		//else
		//{
		//    btnClear.Enabled = btnSaveExit.Enabled = btnSubmit.Enabled = true;
		//}
    }

    protected void btnSaveExit_Click1(object sender, EventArgs e)
    {
        string strMessage = string.Empty;
        bool isSaved = SaveChangeDetails(false, out strMessage);
        strScript = "<script language=javascript>"+(strMessage!=string.Empty?"alert('"+strMessage+"');":string.Empty)+"window.top.close();</script>";
        if (!ClientScript.IsStartupScriptRegistered("clientScript") && isSaved)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strScript);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool isValid = true;
        strScript = string.Empty;
        string strMessage = string.Empty;
        if (isValid)
        {
            bool isSaved = SaveChangeDetails(true, out strMessage);
            strScript = "<script language=javascript>"+(strMessage!=string.Empty?"alert('"+strMessage+"');":string.Empty)+"window.opener.location.href = window.opener.location.href;"+
                        "if (window.opener.progressWindow)"+
		                "{    window.opener.progressWindow.close()"+
                        "}    window.close();</script>";
            if (!ClientScript.IsStartupScriptRegistered("clientScript") && isSaved)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strScript);
            }           
        }
    }

    private bool SaveChangeDetails(bool isSubmit, out string strMessage)
    {
        char[] ch = new char[1];
        ch[0] = Convert.ToChar("$");
        CamperApplication objCamperApplication = new CamperApplication();
        structChangeDetails ChangeDetails = new structChangeDetails();
        string oldGrant, newGrant, oldSession, newSession, reqComments, strCamperAnswers;
        bool bGrantChange, bFJCAmountPaid, sameAsExistingSession;
        int requestID = 0;

        sameAsExistingSession = bGrantChange = bFJCAmountPaid = false;
        strCamperAnswers = oldGrant = newGrant = oldSession = newSession = reqComments = string.Empty;

        ChangeDetails.FJCID = long.Parse(strFJCID);
        ChangeDetails.RequestType = rdBtnLstAdjustmentType.SelectedItem != null ? Int32.Parse(rdBtnLstAdjustmentType.SelectedValue) : 0;

        ChangeDetails.Current_Status = UpdateStatus(out bGrantChange, out bFJCAmountPaid);
        ChangeDetails.Original_Status = Int32.TryParse(lblCurrStatus.Text, out ChangeDetails.Original_Status) ? Int32.Parse(lblCurrStatus.Text) : 0;
        //added by sreevani to get campyear id based on fjcid from database.        
        string campYearId = objCamperApplication.getCampYearId(strFJCID);
        ChangeDetails.CampYearID = Convert.ToInt32(campYearId);
        

        if (ChangeDetails.RequestType == 1) //Cancellation request
        {
            ChangeDetails.Cancellation_Reason = txtCancelComments.Text.Trim();
            if (iUserRole.ToString() == FJCAdminUserRole)
                reqComments = txtComments.Text.Trim() != string.Empty ? txtComments.Text.Trim() : txtCancelComments.Text.Trim();
            else if (iUserRole.ToString() == FEDAdminUserRole)
                reqComments = txtCancelComments.Text.Trim();
        }
        else if (ChangeDetails.RequestType == 2) //Session change request
        {
            if (!txtCampSession.Text.Equals(string.Empty))
            {
                ChangeDetails.NewSession = txtCampSession.Text.Trim();
                ChangeDetails.NewSession_StartDate = txtNewStartDate.Text.Trim();
                ChangeDetails.NewSession_EndDate = txtNewEndDate.Text.Trim();
            }
            else if (ddlCampSession.SelectedValue != "0" && ddlCampSession.SelectedIndex != -1)
            {
                ChangeDetails.NewSession = ddlCampSession.SelectedValue;
                ChangeDetails.NewSession_StartDate = lblSysNewStartDate.Text;
                ChangeDetails.NewSession_EndDate = lblSysNewEndDate.Text;
            }

            ChangeDetails.OldSession = lblSession.Text;
            ChangeDetails.OldSession_StartDate = lblStartDate.Text;
            ChangeDetails.OldSession_EndDate = lblEndDate.Text;

            sameAsExistingSession = IsNewSessionDetailsSameAsExisting();
            if (sameAsExistingSession) { valobj.InnerHtml = "<ul><li>Selected existing session details, please verify and submit request.</li></ul>"; strMessage = ""; return false; }
            
            ChangeDetails.NewGrantAmount = lblNewGrant.Text.TrimStart(ch) != string.Empty ? Convert.ToDouble(lblNewGrant.Text.TrimStart(ch)) : 0.0;
            ChangeDetails.OldGrantAmount = lblGrant.Text.TrimStart(ch) != string.Empty ? Convert.ToDouble(lblGrant.Text.TrimStart(ch)) : 0.0;
            
            oldSession = lblStartDate.Text + " - " + lblEndDate.Text;
            newSession = ChangeDetails.NewSession_StartDate + " - " + ChangeDetails.NewSession_EndDate;           
        }

        if (isSubmit && (hdnRequestStatus.Value == "0" || String.IsNullOrEmpty(hdnRequestStatus.Value))) //Request not submitted
            ChangeDetails.SubmittedDate = DateTime.Now.ToString();        

        ChangeDetails.RequestStatus = isSubmit ? int.Parse(Enum.Format(typeof(RequestStatus), RequestStatus.Submitted, "D")):0; //Is submit clicked or save & exit
        ChangeDetails.RequestID = String.IsNullOrEmpty(hdnRequestID.Value) ? 0 : Int32.Parse(hdnRequestID.Value);

        if(hdnRequestStatus.Value == "0" || String.IsNullOrEmpty(hdnRequestStatus.Value))
        {
            if (ChangeDetails.RequestID != 0)
                objCamperApplication.UpdateChangeDetails(ChangeDetails); //update changerequest table
            else
            {
                ChangeDetails.CreatedDate = DateTime.Now.ToString();
                objCamperApplication.InsertChangeDetails(ChangeDetails, out requestID); //insert changerequest table
                hdnRequestID.Value = requestID.ToString();
            }
            if (ChangeDetails.RequestStatus == 1) //if it is submit request
            {
                string strType = ChangeDetails.RequestType == 1 ? "Cancellation Request Submitted" : "Session Change Request Submitted";

                if (ChangeDetails.Current_Status == ChangeDetails.Original_Status)//if the there is no change in status (session change request) then update new session details in tblcamperanswer table
                {
                    if (pnlSystemSessionDates.Visible == true)
                        strCamperAnswers = ConstructCamperAnswers(ddlCampSession.SelectedValue, ChangeDetails.NewSession_StartDate, ChangeDetails.NewSession_EndDate);
                    else if (pnlManualSessionDates.Visible == true)
                        strCamperAnswers = ConstructCamperAnswers(txtCampSession.Text, ChangeDetails.NewSession_StartDate, ChangeDetails.NewSession_EndDate);

                    strCamperAnswers = string.IsNullOrEmpty(strCamperAnswers) ? null : strCamperAnswers;
                }
                objCamperApplication.UpdateDetailsOnRequestType(strFJCID, string.Empty, ChangeDetails.RequestID, strCamperAnswers, strType, iUserID, null, null, ChangeDetails.RequestStatus);
                
                strMessage = "Request has been submitted successfully.";
            }
            else strMessage = "Request has been saved successfully.";
        }
        else strMessage = "Request "+ lblRequestStatus.Text.ToLower()+", cannot do any modifications.";
        hdnNewRequest.Value = string.Empty;
        return true;
    }

    private bool IsNewSessionDetailsSameAsExisting()
    {
        if (pnlSystemSessionDates.Visible)
        {
            if (lblStartDate.Text.Equals(lblSysNewStartDate.Text) && lblEndDate.Text.Equals(lblSysNewEndDate.Text))
                return true;
        }
        else if (pnlManualSessionDates.Visible)
        {
            if (lblStartDate.Text.Equals(txtNewStartDate.Text) && lblEndDate.Text.Equals(txtNewEndDate.Text))
                return true;
        }
        return false;
    }

    public int UpdateStatus(out bool bGrantChange, out bool bFJCAmountPaid)
    {
        char[] ch = new char[1];
        ch[0] = Convert.ToChar("$");
        bGrantChange = bFJCAmountPaid = false;
        objCamperApplication = new CamperApplication();
        int isPaymentDone = objCamperApplication.IsPaymentDone(strFJCID);
        //Cancellation
        if (rdBtnLstAdjustmentType.SelectedValue == "1")
        {
            //Cancellation Payment not done 
            if (isPaymentDone == 0)
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["Camper Declined to go Camp"]);
            }  //Cancellation Payment done 
            else if(isPaymentDone == 1)
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["Payment Cancellation Pending FJC approval"]);
            }
        }
        //Session Change 
        if (rdBtnLstAdjustmentType.SelectedValue == "2")
        {
            if (Convert.ToInt32(lblGrant.Text.TrimStart(ch)) == Convert.ToInt32(lblNewGrant.Text.TrimStart(ch)))
            {
                return Convert.ToInt32(lblCurrStatus.Text);                
            }
            else if ((Convert.ToInt32(lblGrant.Text.TrimStart(ch)) != Convert.ToInt32(lblNewGrant.Text.TrimStart(ch))) && (isPaymentDone == 0))
            {
                bGrantChange = true;
                return Convert.ToInt32(lblCurrStatus.Text);
            }
            //Session Change Payment done & Grant change
            else if ((Convert.ToInt32(lblGrant.Text.TrimStart(ch)) != Convert.ToInt32(lblNewGrant.Text.TrimStart(ch))) && (isPaymentDone == 1))
            {
                bGrantChange = bFJCAmountPaid = true;
                return Convert.ToInt32(sessionModifiedPenFJCApprovalStatus);
            }
        }
        return 0;
    }

    // Added by Rajesh For Handling Equal Grant Amount and New Session scenario
    private string ConstructCamperAnswers(string NewSession, String StartDate, String EndDate)
    {
        string strTablevalues = "";
        string strFSeparator;
        string strQSeparator;

        //to get the Question separator from Web.config
        strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
        //to get the Field separator from Web.config
        strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();

        if (pnlSystemSessionDates.Visible == true)
            strTablevalues += "11" + strFSeparator + NewSession + strFSeparator + "" + strQSeparator;
        else if (pnlManualSessionDates.Visible == true)
            strTablevalues += "11" + strFSeparator + "" + strFSeparator + NewSession + strQSeparator;

        strTablevalues += "12" + strFSeparator + "1" + strFSeparator + StartDate + strQSeparator;
        strTablevalues += "12" + strFSeparator + "2" + strFSeparator + EndDate + strQSeparator;

        //to remove the extra character at the end of the string, if any
        char[] chartoRemove = { Convert.ToChar(strQSeparator) };
        strTablevalues = strTablevalues.TrimEnd(chartoRemove);

        return strTablevalues;
    }    
}

