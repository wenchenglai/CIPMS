using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CIPMSBC;
using CIPMSBC.Eligibility;
using CIPMSBC.Global;

public partial class Administration_Search_CamperSummary : System.Web.UI.Page
{
    private General _objGen;
    private CamperApplication _objCamperApp;
    private string _strFedId;
    private string _strJWestFed = ConfigurationManager.AppSettings["JWest"];
    private string _strJWestLAFed = ConfigurationManager.AppSettings["JWestLA"];
    private string _strLACIPFed = ConfigurationManager.AppSettings["LACIP"];
    private string _strOrangeFed = ConfigurationManager.AppSettings["Orange"];
    string strFJCAdmin = ConfigurationManager.AppSettings["FJCADMIN"];
    string strFedAdmin = ConfigurationManager.AppSettings["FEDADMIN"];
    string strCampDir = ConfigurationManager.AppSettings["CAMPDIRECTOR"];
    string strApprover = ConfigurationManager.AppSettings["APPROVER"];
    public string isPaymentDone = string.Empty;
    string fedcampyear;
    int iFedID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Set Page Heading
        Label lbl = (Label)this.Master.FindControl("lblPageHeading");
        lbl.Text = "Camper Summary";

        _strFedId = Session["FedId"].ToString();
        string strMaxAmt = ConfigurationManager.AppSettings["MaxAmt"];
        rgvAmt.ErrorMessage = "Amount can not be greater than " + strMaxAmt;
        rgvAmt.MaximumValue = strMaxAmt;

        string strRole = (string)Session["RoleID"];

        int iCurrentStatus = 0;
        DataSet dsCamprDetails = new DataSet();

        CamperApplication objCamperApplication = new CamperApplication();

        if (Session["FJCID"] != null)
            isPaymentDone = objCamperApplication.IsPaymentDone((string)Session["FJCID"]).ToString();

        
        //Only Camp Director can change no. of Days, but he/she cannot change the camp
        if (strRole == strCampDir)
        {
            //Disable camp combo for Camp Director
            ddlCamp.Enabled = false;
            btnCancelChangeRequest.Visible = ddlAdjustmentType.Visible = btnViewCancelChangeRequest.Visible = false;
        }
        //Approver cannot change the camp; but Only Approver can change the Amt
        else if (strRole == strApprover)
        {

            ddlCamp.Enabled = false;
            txtAmt.Enabled = true;            
        }
        //Added by Ram (18 Feb 2010) Change/Cancel Request
        //Fed Admin can raise request for cancel application and change camp, federation & session
        else if (strRole == strFedAdmin)
        {
            //           
        } 
     
        //Added by Ram on 14th Apr 2010 on Ariel's request to allow FJC Admin's to update days for JWest and JWestLA campers
        if (strRole == strFJCAdmin || strRole == strApprover)
        {
            if(_strFedId == "3" || _strFedId == "4")
            txtDays.Enabled = true; //FJC Admin and Approver can change the days for JWest and JwestLA campers
        }
        if (strRole != strApprover)
        {
            ddlCampYear.Enabled = false;
        }
        if (!IsPostBack)
        {
            dsCamprDetails = GetValues();

            // 2013-11-12 After 2013, Camps can contact campers directly 
            if (Convert.ToInt32(Application["CampYear"]) >= 2014)
            {
                lblPermissionNA.Visible = true;
            }
            else
            {
                lblPermissionMsgNo.Visible = true;
                lblPermissionMsgYes.Visible = false;
                if (dsCamprDetails.Tables[0].Rows[0]["PermissionToContact"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(dsCamprDetails.Tables[0].Rows[0]["PermissionToContact"]))
                    {
                        lblPermissionMsgNo.Visible = false;
                        lblPermissionMsgYes.Visible = true;
                    }
                }                
            }

            iCurrentStatus = Convert.ToInt16(dsCamprDetails.Tables[0].Rows[0]["StatusID"]);
            
            if (dsCamprDetails.Tables[0].Rows[0]["FedID"] != DBNull.Value)
            {
                iFedID = Convert.ToInt16(dsCamprDetails.Tables[0].Rows[0]["FedID"]);
            }

            string strCurrentStatus = dsCamprDetails.Tables[0].Rows[0]["Status"].ToString();
            
            PopulateDropdowns(iCurrentStatus, strCurrentStatus, iFedID);
            
            DataSet dsCampyear = new DataSet();
            CamperApplication objCamperAppl = new CamperApplication();
            DataRow dr;
            dsCampyear = objCamperAppl.CheckSecondQuestion(iFedID);
            int iCount = dsCampyear.Tables[0].Rows.Count;
            
            if (iCount > 0)
            {
                dr = dsCampyear.Tables[0].Rows[0];

                hdnMaxTimeInCamp4Fed.Value = dr["question"].ToString();
            }
            SetValues(dsCamprDetails);

            if (_strFedId == "0") 
                lnkFedQuestionnaire.Enabled = false;


            if (strRole == strCampDir)
            {
              lnkFedQuestionnaire.Enabled =true;
            }
            if (lnkFedQuestionnaire.Enabled)
                lnkFedQuestionnaire.Enabled = Convert.ToBoolean( dsCamprDetails.Tables[0].Rows[0]["CurrentYear"].ToString());
           //added by sreevani to enable view application link of 2011 applications also
            if (strRole == strFJCAdmin)
            {
                if (dsCamprDetails.Tables[0].Rows[0]["campyearid"].ToString() == "3")
                    lnkFedQuestionnaire.Enabled = true;
            }
        }

        EnableChangeCancelRequestButton(strRole);

        
        PopulateChangeHistory();
        ddlStatus.Attributes.Add("onChange", "javascript:ValidateDays(" + strRole + ","+ddlStatus.SelectedValue+");");
        btnUpdate.Attributes.Add("onClick", "javascript:return ConfirmUpdateAmt(" + strRole + "," + strApprover + "," + hdnMaxTimeInCamp4Fed.Value + ");");
    }

	private DataSet GetValues()
	{
		SrchCamperDetails _objCamprDet = new SrchCamperDetails();
		_objCamprDet.FJCID = (string)Session["FJCID"];
		DataSet dsCamprDetails = _objCamprDet.SearchCamperDetails();
		return dsCamprDetails;
	}

    private void EnableChangeCancelRequestButton(string strRole)
    {
        DataSet dsCamprDetails = GetValues();
        _objCamperApp = new CamperApplication();
		int requestType = -1;
		int requestStatus = -1;

        if (dsCamprDetails.Tables[0].Rows.Count> 0)
        {
			DataSet dsChangeRequestDetail = _objCamperApp.GetChangeRequestDetails(dsCamprDetails.Tables[0].Rows[0]["FJCID"].ToString());
			if (dsChangeRequestDetail.Tables[0].Rows.Count > 0)
			{
				DataRow dr = dsChangeRequestDetail.Tables[0].Rows[0];

				int requestTypeFromDB = Int32.Parse(dr["RequestType"].ToString());
				int requestStatusFromDB = Int32.Parse(dr["RequestStatus"].ToString());
				requestType = Int32.TryParse(dr["RequestType"].ToString(), out requestType) ? requestTypeFromDB : -1;
				requestStatus = Int32.TryParse(dr["RequestStatus"].ToString(), out requestStatus) ? requestStatusFromDB : -1;

				if (requestType != -1 && (requestStatus != (int)RequestStatus.Rejected && requestStatus != (int)RequestStatus.ClosedOrApproved))
					ddlAdjustmentType.SelectedValue = requestType.ToString();
			}

            if ((strRole == strFedAdmin)||(strRole == strCampDir)||(strRole == strFJCAdmin))
            {
                if (requestStatus == (int)RequestStatus.Submitted)
                {
                    btnViewCancelChangeRequest.Visible = true;
                    btnViewCancelChangeRequest.Value = "View " + (requestType == 2 ? "Change" : "Cancel") + " Request";
                    btnCancelChangeRequest.Visible = false;
                    ddlAdjustmentType.Visible = false;
                }
                else
                {
					if (ddlStatus.SelectedValue == CamperAppStatus.CamperDeclinedToGoToCamp.ToString())
					{
						btnViewCancelChangeRequest.Visible = true;
						btnCancelChangeRequest.Visible = false;
						ddlAdjustmentType.Visible = false;
					}
					else
					{
						btnViewCancelChangeRequest.Visible = false;
						btnCancelChangeRequest.Visible = true;
						ddlAdjustmentType.Visible = true;
					}
                }
            }
            else if ((requestStatus != -1) && (strRole == strFJCAdmin) && (requestStatus > 0))
            {
                btnViewCancelChangeRequest.Visible = true;
                btnViewCancelChangeRequest.Value = "View " + (requestType == 2 ? "Change" : "Cancel") + " Request";
                btnCancelChangeRequest.Visible = false;
                ddlAdjustmentType.Visible = false;
            }
        }
        else
        {
            btnCancelChangeRequest.Visible = false;
            btnViewCancelChangeRequest.Visible = false;
            ddlAdjustmentType.Visible = false;
        }
    }

    private void PopulateDropdowns(int iCurrentStatus, string strCurrentStatus, int iFedID)
    {
        //Populate Camps dropdown
        DataSet dsCamps;
        _objGen = new General();
        _objCamperApp = new CamperApplication();
        string _campYear = string.Empty;
        if (Session["FJCID"] != null)
        {
            DataSet dsCamperApplication = _objCamperApp.getCamperApplication(Session["FJCID"].ToString());
            if(dsCamperApplication.Tables.Count > 0 && dsCamperApplication.Tables[0].Rows.Count > 0)
            _campYear = dsCamperApplication.Tables[0].Rows[0]["CampYear"].ToString();
        }
        if(_campYear == string.Empty)
        {
            _campYear = Master.CampYear;
        }
        dsCamps = _objGen.get_AllCampsBackend(_campYear);
        ddlCamp.DataSource = dsCamps;
        ddlCamp.DataTextField = "Camp";
        ddlCamp.DataValueField = "ID";
      
        ddlCamp.DataBind(); 
        if ((ddlCamp.Items.Count != 0))
            ddlCamp.Items.Insert(0, new ListItem("--Select--", "-1"));

        int iRoleId = Convert.ToInt16(Session["RoleID"]);

        //Populate Status dropdown
        DataSet dsStatus;
        _objGen = new General();
        dsStatus = _objGen.GetNextPossibleStatus(iRoleId, iCurrentStatus, iFedID);
        ddlStatus.DataSource = dsStatus;
        ddlStatus.DataTextField = "Status";
        ddlStatus.DataValueField = "StatusId";
        ddlStatus.DataBind();
        ddlStatus.Items.Remove(ddlStatus.Items.FindByValue("17"));
        ListItem li = new ListItem(strCurrentStatus, iCurrentStatus.ToString());
        ddlStatus.Items.Add(li);
    }

    //Sets values for page labels & hidden controls
    private void SetValues(DataSet dsCamprDetails)
    {
        hdnCamp.Value = dsCamprDetails.Tables[0].Rows[0]["CampID"].ToString();
        if (hdnCamp.Value == "")
            hdnCamp.Value = "-1";
        hdnStatus.Value = dsCamprDetails.Tables[0].Rows[0]["StatusID"].ToString();
        if (hdnStatus.Value == "")
            hdnStatus.Value = "-1";
        hdnAmt.Value = dsCamprDetails.Tables[0].Rows[0]["Amount"].ToString();
        hdnDays.Value = dsCamprDetails.Tables[0].Rows[0]["Days"].ToString();
        hdnWrkQ.Value = dsCamprDetails.Tables[0].Rows[0]["RemoveFromWorkQueue"].ToString();

        string strFed = dsCamprDetails.Tables[0].Rows[0]["Federation"].ToString();
        if (string.IsNullOrEmpty(strFed))
            strFed = "-";

        string strGrade = dsCamprDetails.Tables[0].Rows[0]["GRADE"].ToString();
        if (string.IsNullOrEmpty(strGrade))
            strGrade = "-";

        lblFJCID.Text = dsCamprDetails.Tables[0].Rows[0]["FJCID"].ToString();
        lblSchoolName.Text = _objGen.GetSchoolName(dsCamprDetails.Tables[0].Rows[0]["FJCID"].ToString());
        lblCamperNm.Text = dsCamprDetails.Tables[0].Rows[0]["CamperName"].ToString();
        lblParentName.Text = dsCamprDetails.Tables[0].Rows[0]["ParentName"].ToString(); 
        lblGrade.Text = strGrade;
        lblEmail.Text = dsCamprDetails.Tables[0].Rows[0]["PersonalEmail1"].ToString();
        lblZip.Text = dsCamprDetails.Tables[0].Rows[0]["Zip"].ToString();
        lblDoB.Text = dsCamprDetails.Tables[0].Rows[0]["DateOfBirth"].ToString();
        lblFed.Text = strFed;
        ddlCamp.SelectedValue = hdnCamp.Value;
        ddlStatus.SelectedValue = hdnStatus.Value;

		if (hdnStatus.Value != "29" && hdnStatus.Value != "33" && hdnStatus.Value != "30" && hdnStatus.Value != "34")
		{
			ddlStatus.SelectedValue = hdnStatus.Value;
		}
		else
		{
			ddlStatus.SelectedValue = hdnStatus.Value;
			ddlStatus.Enabled = false;
		}

        txtAmt.Text = hdnAmt.Value;
        txtDays.Text = hdnDays.Value;
        chkRemoveFrmWrkQ.Checked = (hdnWrkQ.Value == "true" ? true : false);
        lblLogin.Text = dsCamprDetails.Tables[0].Rows[0]["LoginEmail"].ToString();
        string emailDelivered = dsCamprDetails.Tables[0].Rows[0]["EmailDelivered"].ToString();
        if (emailDelivered == "-1")
        {
            lblEmailDelivered.Text = "Pending";
        }
        else if (emailDelivered == "1")
        {
            lblEmailDelivered.Text = "Yes";
        }        
        else if (emailDelivered == "0")
        {
            lblEmailDelivered.Text = "No";
        }
        else if (String.IsNullOrEmpty(emailDelivered))
        {
            lblEmailDelivered.Text = "N/A";
        }
        else
        {
            lblEmailDelivered.Text = "N/A";
        }
        hdnCampYear.Value = dsCamprDetails.Tables[0].Rows[0]["CampYearGrant"].ToString();
        if (hdnCampYear.Value == "")
        {
            int timeInCamp = new CamperApplication().getTimeInCamp(Session["FJCID"].ToString());
            hdnCampYear.Value = Convert.ToString(timeInCamp);
        }

        if (hdnCampYear.Value == "" || hdnCampYear.Value == "0")
            hdnCampYear.Value = "-1";
        ddlCampYear.Items.FindByValue(hdnCampYear.Value).Selected = true;

        if (dsCamprDetails.Tables[0].Rows[0]["StartDate"].ToString() != "" && dsCamprDetails.Tables[0].Rows[0]["EndDate"].ToString() != "")
        {
            txtSessionDateRange.Text = dsCamprDetails.Tables[0].Rows[0]["StartDate"].ToString() + "-" + dsCamprDetails.Tables[0].Rows[0]["EndDate"].ToString();

            int days = 0;
            days = new CamperApplication().getDaysInCamp(Session["FJCID"].ToString());
            lblNoofDays.Text = Convert.ToString(days);

        }
        lblCamperPhoneNumber.Text = dsCamprDetails.Tables[0].Rows[0]["HomePhone"].ToString();
        string schooltype=dsCamprDetails.Tables[0].Rows[0]["Schooltype"].ToString();
        if (schooltype == "1")
        {
            lblSchoolType.Text = "Private (secular) School";
        }
        else if (schooltype == "2")
        {
            lblSchoolType.Text = "Public";
        }
        else if (schooltype == "3")
        {
            lblSchoolType.Text = "Home School";
        }
        else if (schooltype == "4")
        {
            lblSchoolType.Text = "Jewish day School";
        }
        if (dsCamprDetails.Tables[1].Rows.Count > 0)
        {
            lblSchoolName.Text = dsCamprDetails.Tables[1].Rows[0]["schoolname"].ToString();
        }
    }

    private void PopulateChangeHistory()
    {
        _objGen = new General();
        DataSet dsAppChangeHistory;
        dsAppChangeHistory = _objGen.get_ApplicationChangeHistory((string)Session["FJCID"]);
        gvAppChangeHistroy.DataSource = dsAppChangeHistory.Tables[0];
        gvAppChangeHistroy.DataBind();
    }

	protected void ddlCampYear_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ddlCampYear.SelectedItem.Value != "-1")
		{
			lblErr.Text = "";
			double grant = 0;
			CamperApplication oCA = new CamperApplication();
			grant = (double)oCA.getCamperGrantForTimeInCamp((string)Session["FJCID"], Convert.ToInt32(lblNoofDays.Text), Convert.ToInt32(ddlCampYear.SelectedValue));
			txtAmt.Text = Convert.ToString(grant);
		}
		else
		{
			ddlCampYear.ClearSelection();
			ddlCampYear.SelectedValue = hdnCampYear.Value;
			lblErr.Font.Bold = true;
			lblErr.Text = "You cannot change the Yr of Grant value to N/A option.";
		}
	}

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        _objCamperApp = new CamperApplication();
        string strRole = (string)Session["RoleID"];
        string strFJCAdmin = ConfigurationManager.AppSettings["FJCADMIN"];
        string strFedAdmin = ConfigurationManager.AppSettings["FEDADMIN"];
        string strCampDir = ConfigurationManager.AppSettings["CAMPDIRECTOR"];
        string strApprover = ConfigurationManager.AppSettings["APPROVER"];
        int iStatus;
        bool blnCampUpdated = false;
        bool blnStatusUpdated = false;
        bool blnDaysUpdated = false;
        bool blnAmtUpdated = false;
        bool blnWorkQueue = false;
        bool blnCampYearUpdated = false;

        ///A-057 - When an FJC admin or a Federation admin tries to select the status "Eligible by Staff" in the camnper summary, 
        ///the system should check to see whether or not a camp and session start/end dates have been selected. 
        ///If all of this data has been selected, the system should allow the state transition. 
        ///If any of this data is missing, the system should display a msg indicating that this data must first be supplied, 
        ///and the transistion should be state rejected returned back to the previous state)
        if ( Convert.ToInt16(ddlStatus.SelectedItem.Value) == 7)
            if (!CampDaysExist())
            {
                lblErr.Font.Bold = true;
                lblErr.Text = "Please open the camper application (Federation Questionnaire) and make sure that a camp" + 
                    " has been selected and that the session start and end dates have been provided before selecting" + 
                    " the Eligible by Staff status. You will not be able to change the status to Eligible by Staff if the camper application" + 
                    " lacks camp and session date selections. You can also select the Under Review status if you are not prepared to supply" + 
                    " the required information at this time.";

                try
                {
                    ddlStatus.SelectedValue = hdnStatus.Value;
                }
                catch { }

                return;
            }
            else
            {
                lblErr.Text = "";
            }



        //If Role is Camp Director, update Status and/or Days
        if (strRole == strCampDir)
        {
            //blnDaysUpdated = UpdateDays();
            iStatus = Convert.ToInt16(ddlStatus.SelectedItem.Value);
            blnStatusUpdated = UpdateStatus(iStatus);

        }
        
        //If Role is Fed Admin or FJC Admin, update Status and/or Camp and/or Amount
        else if (strRole == strFedAdmin)
        {
            iStatus = Convert.ToInt16(ddlStatus.SelectedItem.Value);
            blnStatusUpdated = UpdateStatus(iStatus);
            blnCampUpdated = UpdateCamp();
            blnAmtUpdated = UpdateAmount();
   
        }
        else if (strRole == strFJCAdmin)
        {
            iStatus = Convert.ToInt16(ddlStatus.SelectedItem.Value);
            blnStatusUpdated = UpdateStatus(iStatus);
            blnCampUpdated = UpdateCamp();
           
            blnDaysUpdated = UpdateDays();
            if (strRole == strFJCAdmin)
            {

                blnAmtUpdated = UpdateAmount();
            }


        }
        if (strRole == strApprover)
        {
            if (hdnConfirm.Value == "true")
            {
				iStatus = Convert.ToInt16(ddlStatus.SelectedItem.Value);
				blnStatusUpdated = UpdateStatus(iStatus);

				blnCampUpdated = UpdateCamp();
				blnDaysUpdated = UpdateDays();

				int iCampyear = Convert.ToInt16(ddlCampYear.SelectedItem.Value);
				blnCampYearUpdated = UpdateCampYear(iCampyear);

				blnAmtUpdated = UpdateAmount();
				//string strCheckScript = "ConfirmUpdateAmt(); ";
				//if (!ClientScript.IsStartupScriptRegistered("clientScript"))
				//{
				//    ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strCheckScript, true);

				//}
				//ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", strCheckScript, true);
            }
            
        }
        //AG: 4-013
        //If a camper is "under review" you cannot update notes and keep them as "under review".

        //AG: A-048
        //Not only for Under Review - allow It universally.
        //if (!blnStatusUpdated && !blnCampUpdated && !blnAmtUpdated && Convert.ToInt16(ddlStatus.SelectedItem.Value) == Convert.ToInt16(StatusInfo.BeingResearched))
        //{ 
            string FJCID = (string)Session["FJCID"];
		    string OriginalValue = "";
		    string ChangedValue = "";
		    string Comment = txtReason.Text.Trim();
		    string Type = "Review Comments";
		    int ModifiedBy = Convert.ToInt16(Session["UsrID"]);
            if (Comment.Length > 0)
            {
                _objCamperApp.InsertApplicationChangeHistory(FJCID, OriginalValue, ChangedValue, Comment, Type, ModifiedBy);
                blnWorkQueue = true;
            }
        //}
            if (ddlAdjustmentType.SelectedItem.Value == "1")
            {
                //SaveChangeRequest();
            }
            else
            {
                if (blnStatusUpdated || blnCampUpdated || (blnAmtUpdated && txtReason.Text.Trim() != "") || blnDaysUpdated || blnWorkQueue || blnCampYearUpdated)
                {
                    string strPrevPage = Request.QueryString["page"];
                    if (strPrevPage == "wrkq")
                        Server.Transfer("~/Administration/Search/WorkQueue.aspx");
                    else if (strPrevPage == "srch")
                        Server.Transfer("~/Administration/Search/AdminSearch.aspx?page=cs");
                }
            }
    }
  
    private bool CampDaysExist()
    {
        string FJCID = (string)Session["FJCID"];
        CamperApplication oCA = new CamperApplication();
        int CampID = 0;
        int Days = 0;

        CampID = EligibilityBase.getCampID(FJCID);
        if (CampID <= 0)
            return false;

        Days = EligibilityBase.getDaysInCamp(FJCID);

        return Days > 0;
    }
    private bool UpdateCampYear(int iCampyear)
    {
        if (ddlCampYear.SelectedValue != hdnCampYear.Value)
        {
            string strReason = txtReason.Text.Trim();
            string strFJCID = (string)Session["FJCID"];
            int iUserId = Convert.ToInt16(Session["UsrID"]);
            if (strReason == string.Empty)
            {
                lblErr.Font.Bold = true;
                lblErr.Text = "Please enter Reason(s) for change";
                return false;
            }
            else
            {
                lblErr.Text = "";
                _objCamperApp.updtaeCampYear(strFJCID, iCampyear, strReason, iUserId);
                return true;
            }
        }
        else
            return false;

    }
    private bool UpdateStatus(int iStatus)
    {
        //Check if the Status value is changed, if yes then update the same
        if (ddlStatus.SelectedValue != hdnStatus.Value)
        {
            string strReason = txtReason.Text.Trim();
            string strFJCID = (string)Session["FJCID"];
            int iUserId = Convert.ToInt16(Session["UsrID"]);

            if (strReason == string.Empty && (iStatus == 15 || iStatus == 9))//only ask for comments when the status is changed to second approval, under review
            {
                lblErr.Text = "Please enter Reason(s) for change";
                return false;
            }
            else
            {
                //*****[11/20/2008]Comments are not mandatory for change of status*****
                //Commented by Ram on 23 Feb 2010
                lblErr.Text = "";
                _objCamperApp.updateStatus(strFJCID, iStatus, strReason, iUserId);
                return true;
            }
        }
        else
            return false;
    }

    private bool UpdateCamp()
    {
        //Check if the Camp value is changed, if yes then update the same
        if (ddlCamp.SelectedValue != hdnCamp.Value)
        {
            string strReason = txtReason.Text.Trim();
            string strFJCID = (string)Session["FJCID"];
            int iUserId = Convert.ToInt16(Session["UsrID"]);
            int iCamp = Convert.ToInt16(ddlCamp.SelectedItem.Value);

            if (strReason == string.Empty)
            {
                lblErr.Font.Bold = true;
                lblErr.Text = "Please enter Reason(s) for change";
                return false;
            }
            else
            {
                lblErr.Text = "";
                _objCamperApp.updateCamp(strFJCID, iCamp, strReason, iUserId);
                return true;
            }
        }
        else
            return false;
    }

    private bool UpdateDays()
    {
        int iStatus;
        string strReason = txtReason.Text.Trim();
        //Check if the Days value is changed, if yes then update the same
        if (txtDays.Text.Trim() != hdnDays.Value)
        {
            
            string strFJCID = (string)Session["FJCID"];
            int iUserId = Convert.ToInt16(Session["UsrID"]);

            //AG: A-028
            //The system should not ask for reason if the user changes the status 
            //from Eligible by staff to Register in camp
            if (strReason == string.Empty && hdnDays.Value != string.Empty)
            {
                lblErr.Font.Bold = true;
                lblErr.Text = "Please enter Reason(s) for change";
                return false;
            }
            else
            {
                lblErr.Text = "";
                int iDays;

                if (txtDays.Text.Trim() != "")
                {
                    iDays = Convert.ToInt16(txtDays.Text.Trim());
                    _objCamperApp.UpdateDays(strFJCID, iDays, iUserId, strReason);
                    EligibilityBase.checkEligibilityDays2(strFJCID, iDays, out iStatus);
                    if (iStatus == 15)
                    {
                        ReverceSecondApprovalFlag(strFJCID);
                    }
                    UpdateStatus(iStatus);
                }
                else
                {
                    iDays = -1;
                    iStatus = Convert.ToInt16(ddlStatus.SelectedItem.Value);
                    UpdateStatus(iStatus);
                }


                return true;
            }
        }
        else
        {
            if (strReason == string.Empty )
            {
                lblErr.Font.Bold = true;
                lblErr.Text = "Please enter Reason(s) for change";
                return false;
            }
            else
            {
                if (txtDays.Text.Trim() != "" && ddlStatus.SelectedItem.Value == "11")
                {
                    //This is the case when a camper director updates
                    //the status from the eligible by staff to
                    //the status Registered in camp
                    //after beeing approved by approver (this is why days exist and equal 
                    //to the previous value in the hidden field).
                    //The system sets the status of Campership approved.
                    //This is the fix of the issue A-034

                    iStatus = 14;
                }
                else
                {
                    iStatus = Convert.ToInt16(ddlStatus.SelectedItem.Value);
                }
                UpdateStatus(iStatus);
                return true;
            }
        }
            
    }

    private void ReverceSecondApprovalFlag(string strFJCID)
    {
        CamperApplication CamperAppl;
        CamperAppl = new CamperApplication();
        CamperAppl.ReverceSecondApprovalFlag(strFJCID);
    }

    private bool UpdateAmount()
    {
        //Check if the Amount value is changed, if yes then update the same
        if (txtAmt.Text.Trim() != hdnAmt.Value)
        {
            string strReason = txtReason.Text.Trim();
            string strFJCID = (string)Session["FJCID"];
            int iUserId = Convert.ToInt16(Session["UsrID"]);

            if (strReason == string.Empty)
            {
                lblErr.Font.Bold = true;
                lblErr.Text = "Please enter Reason(s) for change";
                return false;
            }
            else
            {
                lblErr.Text = "";

                double dAmt;
                if (txtAmt.Text.Trim() != "")
                    dAmt = Convert.ToDouble(txtAmt.Text.Trim());
                else
                    dAmt = -1;

                _objCamperApp.UpdateAmount(strFJCID, dAmt, iUserId, strReason);
                return true;
            }
        }
        else
            return false;
    }

    private bool UpdateWorkQueueFlag()
    {
        bool blnIsChecked = false;

        if (hdnWrkQ.Value == "true")
            blnIsChecked = true;
        else if (hdnWrkQ.Value == "false")
            blnIsChecked = false;

        //Check if the Amount value is changed, if yes then update the same
        if (chkRemoveFrmWrkQ.Checked != blnIsChecked)
        {
            string strReason = txtReason.Text.Trim();
            string strFJCID = (string)Session["FJCID"];
            int iUserId = Convert.ToInt16(Session["UsrID"]);

            if (strReason == string.Empty)
            {
                lblErr.Font.Bold = true;
                lblErr.Text = "Please enter Reason(s) for change";
                return false;
            }
            else
            {
                lblErr.Text = "";
                _objCamperApp.UpdateWorkQueueFlag(strFJCID, chkRemoveFrmWrkQ.Checked);
                return true;
            }
        }
        else
            return false;
    }

    protected void lnkFedQuestionnaire_Click(object sender, EventArgs e)
    {
       Response.Redirect("~/Enrollment/Step1.aspx?a=a");
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlStatus.SelectedItem.Value) == 15)
        {
            lblErr.Font.Bold = false;
            lblErr.Text = " You must include the following information in your reason for explaining why this camper " +
                            "is second approval: the grant amount, the reason you are making an exception for this camper, " +
                            "and the NAME of the FJC staff person you spoke with to get first approval for this camper. " +
                            "<b><u>Without this information, the camper's application will NOT be approved by the second approver.<u/><b/>";
        }
        else {
            lblErr.Text = "";
        }
    }

    private string ConstructCamperAnswers(string NewSession, String StartDate, String EndDate)
    {
        string strTablevalues = "";
        string strFSeparator;
        string strQSeparator;
        int iNewSession = 0;

        //to get the Question separator from Web.config
        strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
        //to get the Field separator from Web.config
        strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();

        if (Int32.TryParse(NewSession, out iNewSession))
            strTablevalues += "11" + strFSeparator + iNewSession + strFSeparator + strQSeparator;
        else if (!NewSession.Equals(string.Empty))
            strTablevalues += "11" + strFSeparator + strFSeparator + NewSession + strQSeparator;

        strTablevalues += "12" + strFSeparator + "1" + strFSeparator + StartDate + strQSeparator;
        strTablevalues += "12" + strFSeparator + "2" + strFSeparator + EndDate + strQSeparator;

        //to remove the extra character at the end of the string, if any
        char[] chartoRemove = { Convert.ToChar(strQSeparator) };
        strTablevalues = strTablevalues.TrimEnd(chartoRemove);

        return strTablevalues;
    }
   
    protected void btnCancelChangeRequest_ServerClick(object sender, EventArgs e)
    {
		// 2012-06-02 This server side cancellation click function will be called ONLY for campers who have NOT yet been paid (pre-payment_requested status)
		SaveChangeRequest();
	}

    private void SaveChangeRequest()
    {
		if (isPaymentDone == "0")
        {
            if (txtReason.Text.Trim() != string.Empty)
            {
				CamperApplication objCamperApplication = new CamperApplication();
                structChangeDetails ChangeDetails = new structChangeDetails();
                int requestID = 0;
                string strFJCID = Session["FJCID"].ToString();
                int iUserId = Convert.ToInt16(Session["UsrID"]);
                ChangeDetails.FJCID = long.Parse(strFJCID);
                ChangeDetails.RequestType = ddlAdjustmentType.SelectedItem != null ? Int32.Parse(ddlAdjustmentType.SelectedValue) : 0;

                if (ChangeDetails.RequestType == 1) //Cancellation request
                {
                    ChangeDetails.Current_Status = Convert.ToInt32(ConfigurationManager.AppSettings["Camper Declined to go Camp"]);
                    ChangeDetails.Original_Status = Int32.Parse(ddlStatus.SelectedValue);
                    ChangeDetails.CampYearID = (int)Application["CampYear"] - 2008;
                    ChangeDetails.Cancellation_Reason = txtReason.Text.Trim() != string.Empty ? txtReason.Text.Trim() : "";


                    ChangeDetails.SubmittedDate = DateTime.Now.ToString();
                    ChangeDetails.RequestStatus = int.Parse(Enum.Format(typeof(RequestStatus), RequestStatus.Submitted, "D")); //Is submit clicked or save & exit
                    ChangeDetails.RequestID = 0;

                    ChangeDetails.CreatedDate = DateTime.Now.ToString();
                    objCamperApplication.InsertChangeDetails(ChangeDetails, out requestID); //insert changerequest table
                    ChangeDetails.RequestID = requestID;

                    string strType = ChangeDetails.RequestType == 1 ? "Cancellation Request Submitted" : "Session Change Request Submitted";
                    objCamperApplication.UpdateDetailsOnRequestType(strFJCID, string.Empty, ChangeDetails.RequestID, "", strType, iUserId, null, null, ChangeDetails.RequestStatus);
                    string url = Request.Url.GetLeftPart(UriPartial.Authority);
                    url = url + ConfigurationManager.AppSettings["WorkQueueURL"].ToString();
                    string strScript = "<script language=javascript> alert('Application has been cancelled.For any details contact FJC');window.location='" + url + "';</script>";
                    if (!ClientScript.IsStartupScriptRegistered("clientScript"))
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strScript);
                    }
                }
            }
            else
            {
                lblErr.Text = "Please enter reason for cancellation. If you do <u>not</u> want to cancel this application, click “Work Queue?to abort this action.";
            }
        }
    }

	protected void ddlStatus_DataBound(object sender, EventArgs e)
	{
		foreach (ListItem item in ddlStatus.Items)
		{
			if (item.Value == "7")
			{
				item.Attributes.Add("style", "color: green");
			}
			else if (item.Value == "8")
			{
				item.Attributes.Add("style", "color: red");
			}
		}
	}
}