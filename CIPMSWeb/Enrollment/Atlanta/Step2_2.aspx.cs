using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using CIPMSBC;
using CIPMSBC.ApplicationQuestions;
using CIPMSBC.Eligibility;
using System.Web;

public partial class HartfordPage2 : System.Web.UI.Page
{
	private CamperApplication CamperAppl;
	private General objGeneral;
	private Boolean bPerformUpdate;

	#region "Page events"
	protected void Page_Init(object sender, EventArgs e)
	{
        if (PageUtility.RedirectToNL((int)FederationEnum.Atlanta, Session["isGrantAvailable"] != null, Master.isAdminUser))
        {
            Response.Redirect("~/NLIntermediate.aspx");
        }

        btnNext.Click += new EventHandler(btnNext_Click);
		btnPrevious.Click += new EventHandler(btnPrevious_Click);
		btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
		btnReturnAdmin.Click+=new EventHandler(btnReturnAdmin_Click);
		CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
		CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		CamperAppl = new CamperApplication();
		objGeneral = new General();
		if (!Page.IsPostBack)
		{
			//to fill the grades in the dropdown
			getGrades();

			// 2012-09-13 Colorado needs Syangogue and JCC list now
			getSynagogues();
			getJCCList(Master.CampYear);

			//to get the FJCID which is stored in session
			if (Session["FJCID"] != null)
			{
				hdnFJCIDStep2_2.Value = (string)Session["FJCID"];
				PopulateAnswers();
			}
		}
		if (chkSynagogue.Checked == false) ddlSynagogue.Enabled = txtOtherSynagogue.Enabled = false;
		if (chkJCC.Checked == false) ddlJCC.Enabled  = txtOtherJCC.Enabled = false;
	}
	#endregion

	#region "Data Bindings"
	private void getGrades()
	{
		DataTable dtGrade;
		dtGrade = objGeneral.getGrades(Session["FedId"].ToString(), Master.CampYear);
		ddlGrade.DataSource = dtGrade;
		ddlGrade.DataTextField = "EligibleGrade";
		ddlGrade.DataValueField = "EligibleGrade";
		ddlGrade.DataBind();
		ddlGrade.Items.Insert(0, new ListItem("-- Select --", "0"));
	}

	private void getSynagogues()
	{
		DataSet dsSynagogue;
		DataView dvSynagogue = new DataView();
		int FedID;
		FedID = Convert.ToInt32(Session["FedId"].ToString());
		dsSynagogue = objGeneral.GetSynagogueListByFederation(FedID, Master.CampYear);

		ddlSynagogue.DataSource = dsSynagogue.Tables[0];
		ddlSynagogue.DataTextField = "Name";
		ddlSynagogue.DataValueField = "ID";
		ddlSynagogue.DataBind();
		ddlSynagogue.Items.Insert(0, new ListItem("-- Select --", "0"));
		ListItem otherListItem = new ListItem();
		foreach (ListItem item in ddlSynagogue.Items)
		{
			item.Attributes.Add("title", item.Text);
			if (item.Text.ToLower().Contains("other (please specify)") && ddlSynagogue.Items.IndexOf(item) < ddlSynagogue.Items.Count)
			{
				otherListItem = item;
			}
		}
		if (otherListItem != null && otherListItem.Text != string.Empty)
		{
			ddlSynagogue.Items.Remove(otherListItem);
			ddlSynagogue.Items.Insert(ddlSynagogue.Items.Count, otherListItem);
		}
	}

	private void getJCCList(string CampYear)
	{
		DataSet dsJCC;
		DataView dvJCC = new DataView();
		int FedID;
		FedID = Convert.ToInt32(Session["FedId"].ToString());
		dsJCC = objGeneral.GetJCCListByFederation(FedID, CampYear);
		if (dsJCC.Tables[0].Rows.Count > 0)
		{

			ddlJCC.DataSource = dsJCC.Tables[0];
			ddlJCC.DataTextField = "Name";
			ddlJCC.DataValueField = "ID";
			ddlJCC.DataBind();
			ddlJCC.Items.Insert(0, new ListItem("-- Select --", "0"));
			ddlJCC.SelectedValue = "0";
			ListItem otherListItem = new ListItem();
			foreach (ListItem item in ddlJCC.Items)
			{
				item.Attributes.Add("title", item.Text);
				if (item.Text.ToLower().Contains("other (please specify)") && ddlJCC.Items.IndexOf(item) < ddlJCC.Items.Count)
				{
					otherListItem = item;
				}
			}
			if (otherListItem != null && otherListItem.Text != string.Empty)
			{
				ddlJCC.Items.Remove(otherListItem);
				ddlJCC.Items.Insert(ddlJCC.Items.Count, otherListItem);
			}
			txtOtherJCC.Width = Unit.Pixel(160);
			txtOtherJCC.Enabled = true;
		}
		else
		{
			divOtherJCC.Style["width"] = "450px";
			divDDLJCC.Visible = false;
			txtOtherJCC.Width = Unit.Pixel(240); ;
			txtOtherJCC.Enabled = true;
		}
	}
	#endregion

	#region "Controls Events"
	void btnNext_Click(object sender, EventArgs e)
	{
		bool isReadOnly = objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_2.Value, Master.CamperUserId);
		if (!isReadOnly)
		{
			ProcessCamperAnswers();
		}

		//Modified by id taken from the Master Id
		string strModifiedBy = Master.UserId;
		string strFJCID = hdnFJCIDStep2_2.Value;
		int iStatus = Convert.ToInt32(StatusInfo.SystemInEligible);
		if (strFJCID != "" && strModifiedBy != "")
		{
			if (isReadOnly)
			{
				DataSet dsApp = CamperAppl.getCamperApplication(strFJCID);
				iStatus = Convert.ToInt32(dsApp.Tables[0].Rows[0]["Status"]);
			}
			else
			{
				var objEligibility = EligibilityFactory.GetEligibility(FederationEnum.Atlanta);
                EligibilityBase.EligibilityResult result = objEligibility.checkEligibilityforStep2(strFJCID, out iStatus, SessionSpecialCode.GetPJLotterySpecialCode());

                if (result.SchoolType == StatusInfo.EligiblePJLottery)
                    iStatus = (int)StatusInfo.EligiblePJLottery;
                else if (result.CurrentUserStatusFromDB == StatusInfo.SystemInEligible ||
                    result.Grade == StatusInfo.SystemInEligible ||
                    result.SchoolType == StatusInfo.SystemInEligible ||
                    result.TimeInCamp == StatusInfo.SystemInEligible)
                {
                    iStatus = (int)StatusInfo.SystemInEligible;
                }
                //else if (rdoNo160.Checked)
                //{
                //    // 2015-01-07 If Income is not less thant $160K, we make them ineligible.
                //    iStatus = (int)StatusInfo.SystemInEligible;
                //}
                //else
                //{
                //    iStatus = (int) StatusInfo.SystemEligible;
                //}

                if (rdoFirstTimerNo.Checked || rdoFirstTimerNo11days.Checked)
                {
                    iStatus = (int)StatusInfo.SystemInEligible;
                }

                //if (iStatus == (int)StatusInfo.SystemEligible)
                //{
                //    if (rdoFirstTimerNo.Checked)
                //    {
                //        if (rdoLastYearNo.Checked)
                //            iStatus = (int)StatusInfo.SystemInEligible;
                //        else if (rdoLastYearYes.Checked)
                //        {
                //            if (rdoNo160.Checked)
                //                iStatus = (int)StatusInfo.SystemInEligible;
                //        }
                //    }
                //}
            }
			Session["STATUS"] = iStatus.ToString();
		}
		Session["FJCID"] = hdnFJCIDStep2_2.Value;

		var status = (StatusInfo)iStatus;
		Response.Redirect(AppRouteManager.GetNextRouteBasedOnStatus(status, HttpContext.Current.Request.Url.AbsolutePath));
	}

	void btnReturnAdmin_Click(object sender, EventArgs e)
	{
		string strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"].ToString();
		ProcessCamperAnswers();
		Response.Redirect(strRedirURL);
	}

	void btnSaveandExit_Click(object sender, EventArgs e)
	{
		string strRedirURL = Master.SaveandExitURL;
		if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_2.Value, Master.CamperUserId))
		{
			ProcessCamperAnswers();
		}
			  
		if (Master.IsCamperUser == "Yes")
		{
			string strScript = "<script language=javascript>openThis(); window.location='" + strRedirURL + "';</script>";
			if (!ClientScript.IsStartupScriptRegistered("clientScript"))
			{
				ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strScript);
			}
		}
		else
		{
			Response.Redirect(strRedirURL);
		}
	}

	void btnPrevious_Click(object sender, EventArgs e)
	{
		if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_2.Value, Master.CamperUserId))
		{
			ProcessCamperAnswers();
		}
		Session["FJCID"] = hdnFJCIDStep2_2.Value;
				
		Response.Redirect("Summary.aspx");
	}
	#endregion

	#region "Private functions"
	private void ProcessCamperAnswers()
	{
		string strModifiedBy = Master.UserId;
		string strFJCID = hdnFJCIDStep2_2.Value;
		string strComments = txtComments.Text.Trim();

		InsertCamperAnswers(strFJCID, strModifiedBy, strComments);

		if (strFJCID != "" && strModifiedBy!="" && bPerformUpdate)
		{
			int iGrade, iResult;
			string strGrade = ddlGrade.SelectedValue;
			int.TryParse(strGrade, out iResult);

			if (iResult==0 || strGrade.Equals(string.Empty))
				iGrade=0;
			else
				iGrade = iResult;

			CamperAppl.updateGrade(strFJCID, iGrade, strComments, Convert.ToInt32(strModifiedBy));
		}
	}

	protected void InsertCamperAnswers(string strFJCID, string strModifiedBy, string strComments)
	{        
		string strCamperAnswers = ConstructCamperAnswers();

		if (strFJCID != "" && strCamperAnswers != "" && strModifiedBy != "" && bPerformUpdate)
		{
			CamperAppl.InsertCamperAnswers(strFJCID, strCamperAnswers, strModifiedBy, strComments);
		}
		
        //CamperAppl = new CamperApplication();
        //CamperAppl.UpdateTimeInCampInApplication(strFJCID);
	}

	void PopulateAnswers()
	{
		DataSet dsAnswers = CamperAppl.getCamperAnswers(hdnFJCIDStep2_2.Value, "", "", "3,6,7,8,30,31,1044,1045,1063,1066,1067");

		foreach (DataRow dr in dsAnswers.Tables[0].Rows)
		{
			int qID = Convert.ToInt32(dr["QuestionId"]);

			if (qID == 3) // Is this your first time to attend a Non-profit Jewish overnight camp, for 3 weeks or longer:
			{
				if (dr["OptionID"].Equals(DBNull.Value))
					continue;

				if (dr["OptionID"].ToString() == "1")
				{
					rdoFirstTimerYes.Checked = true;
				}
                else if (dr["OptionID"].ToString() == "3")
                {
                    rdoFirstTimerNo11days.Checked = true;
                }
                else
				{
					rdoFirstTimerNo.Checked = true;
				}
			}
			else if (qID == 6) // Grade (Mention the grade of the camper after he/she attends the camp session):
			{
				if (!dr["Answer"].Equals(DBNull.Value))
				{
					ddlGrade.SelectedValue = dr["Answer"].ToString();
				}
			}
			else if (qID == 7) // What kind of the school the camper go to
			{
				if (dr["OptionID"].Equals(DBNull.Value))
					continue;

				rdoSchoolType.SelectedValue = dr["OptionID"].ToString();
				if (dr["OptionID"].ToString() == "3")
					txtSchoolName.Enabled = false;
			}
			else if (qID == 8) // Name of the school Camper attends:
			{
				if (!dr["Answer"].Equals(DBNull.Value))
				{
					txtSchoolName.Text = dr["Answer"].ToString();
				}
			}
			if (qID == 30) //Were you referred to this application through a synagogue or JCC liaison?
			{
				if (dr["OptionID"].Equals(DBNull.Value))
					continue;

				SynagogueJCCOther value = (SynagogueJCCOther)Convert.ToInt32(dr["OptionID"]);
				switch (value)
				{
					case SynagogueJCCOther.Synagogue:
						chkSynagogue.Checked = true;
						break;

					case SynagogueJCCOther.JCC:
						chkJCC.Checked = true;
						break;

					case SynagogueJCCOther.Other:
						chkNo.Checked = true;
						break;

					default:
						chkNo.Checked = false;
						break;
				}
			}
			else if (qID == 31) // Please select your synagogue or JCC
			{
				if (dr["OptionID"].Equals(DBNull.Value) || dr["Answer"].Equals(DBNull.Value))
					continue;

				if (dr["OptionID"].ToString() == "1")
				{
					chkSynagogue.Checked = true;
					ddlSynagogue.SelectedValue = dr["Answer"].ToString();
					if (ddlSynagogue.SelectedItem.Text != "Other (please specify)")
						txtOtherSynagogue.Enabled = false;
				}
				else if (dr["OptionID"].ToString() == "2")
				{
					txtOtherSynagogue.Text = dr["Answer"].ToString();
				}
				else if (dr["OptionID"].ToString().Equals("3"))
				{
					chkJCC.Checked = true;
					ddlJCC.SelectedValue = dr["Answer"].ToString();
					if (ddlJCC.SelectedItem.Text != "Other (please specify)")
						ddlJCC.Enabled = false;
				}
				else if (dr["OptionID"].ToString().Equals("4"))
				{
					txtOtherJCC.Text = dr["Answer"].ToString();
				}
			}
			else if (qID == 1066) // Did your camper receive a One Happy Camper last year through the Jewish Federation of Greater Atlanta?
			{
				if (dr["OptionID"].Equals(DBNull.Value))
					continue;

				if (dr["OptionID"].ToString() == "1")
					rdoLastYearYes.Checked = true;
				else
					rdoLastYearNo.Checked = true;
			}
			else if (qID == 1067) // Is your combined gross household income $160,000 or less?
			{
				if (dr["OptionID"].Equals(DBNull.Value))
					continue;

				if (dr["OptionID"].ToString() == "1")
					rdoYes160.Checked = true;
				else
					rdoNo160.Checked = true;
			}
		}
	}

	private string ConstructCamperAnswers()
	{
		string strQID = "";
		string strTablevalues = "";

		string strQSeparator = QuestionsDelimiters.QuestionSeparator; 
		string strFSeparator = QuestionsDelimiters.FieldSeparator;

		//for question 3
		strQID = hdnQ3Id.Value;
		strTablevalues += strQID + strFSeparator + (rdoFirstTimerYes.Checked ? "1" : rdoFirstTimerNo.Checked ? "2" : rdoFirstTimerNo11days.Checked ? "3" : "") + strFSeparator + strQSeparator;

		//2nd Year Grant question
		strQID = "1066";
		strTablevalues += strQID + strFSeparator + (rdoLastYearYes.Checked ? "1" : rdoLastYearNo.Checked ? "2" : "") + strFSeparator + strQSeparator;

		//2nd Year Grant Income question
		strQID = "1067";
		strTablevalues += strQID + strFSeparator + (rdoYes160.Checked ? "1" : rdoNo160.Checked ? "2" : "") + strFSeparator + strQSeparator;

		//for question 4
		strQID = hdnQ4Id.Value;
		strTablevalues += strQID + strFSeparator + strFSeparator + ddlGrade.SelectedValue + strQSeparator;

		//for question 5
		strQID = hdnQ5Id.Value;
		strTablevalues += strQID + strFSeparator + rdoSchoolType.SelectedValue + strFSeparator + strQSeparator;

		//for question 6
		strQID = hdnQ6Id.Value;
		strTablevalues += strQID + strFSeparator + strFSeparator + txtSchoolName.Text.Trim() + strQSeparator;

		// 2012-09-13 Synagogue/JCC question
		if (chkNo.Checked)
		{
			strQID = hdnQ25Id.Value;
			strTablevalues += strQID + strFSeparator + chkNo.Value + strFSeparator + chkNo.Value + strQSeparator;
			strQID = hdnQ26Id.Value;
			strTablevalues += strQID + strFSeparator + "" + strFSeparator + "" + strQSeparator;
		}
		else
		{
			if (chkSynagogue.Checked)
			{
				strQID = hdnQ25Id.Value;
				strTablevalues += strQID + strFSeparator + chkSynagogue.Value + strFSeparator + chkSynagogue.Value + strQSeparator;
			}

			if (chkJCC.Checked)
			{
				strQID = hdnQ25Id.Value;
				strTablevalues += strQID + strFSeparator + chkJCC.Value + strFSeparator + chkJCC.Value + strQSeparator;
			}

			//This redundant condition is used to insert records in questionid sequence
			strQID = hdnQ26Id.Value;
			if (chkSynagogue.Checked)
			{
				if (ddlSynagogue.SelectedValue != "0")
				{
					strTablevalues += strQID + strFSeparator + "1" + strFSeparator + ddlSynagogue.SelectedValue + strQSeparator;
					if (txtOtherSynagogue.Text.Trim() != String.Empty)
						strTablevalues += strQID + strFSeparator + "2" + strFSeparator + txtOtherSynagogue.Text.Trim() + strQSeparator;
					if (txtOtherSynagogue.Text.Trim() != String.Empty)
					{
						strTablevalues += hdnQ2Id.Value + strFSeparator + strFSeparator + txtOtherSynagogue.Text.Trim() + strQSeparator;
					}
					else
					{
						strTablevalues += hdnQ2Id.Value + strFSeparator + strFSeparator + ddlSynagogue.SelectedItem.Text + strQSeparator;
					}
				}
			}
			else
			{
				strTablevalues += strQID + strFSeparator + "1" + strFSeparator + "" + strQSeparator;
				strTablevalues += strQID + strFSeparator + "2" + strFSeparator + "" + strQSeparator;
			}

			if (chkJCC.Checked)
			{
				if (ddlJCC.Items.Count > 0)
				{
					if (ddlJCC.SelectedValue != "0")
					{
						strTablevalues += strQID + strFSeparator + "3" + strFSeparator + ddlJCC.SelectedValue + strQSeparator;
						if (txtOtherJCC.Text.Trim() != String.Empty)
							strTablevalues += strQID + strFSeparator + "4" + strFSeparator + txtOtherJCC.Text.Trim() + strQSeparator;
					}
				}
				else
					strTablevalues += strQID + strFSeparator + "4" + strFSeparator + txtOtherJCC.Text.Trim() + strQSeparator;
			}
			else
			{
				strTablevalues += strQID + strFSeparator + "3" + strFSeparator + "" + strQSeparator;
				strTablevalues += strQID + strFSeparator + "4" + strFSeparator + "" + strQSeparator;
			}
		}

		//to remove the extra character at the end of the string, if any
		char[] chartoRemove = { Convert.ToChar(strQSeparator) };
		strTablevalues = strTablevalues.TrimEnd(chartoRemove);

		return strTablevalues;
	}

	void CusValComments_ServerValidate(object source, ServerValidateEventArgs args)
	{
		string strCamperAnswers, strUserId, strCamperUserId, strComments, strFJCID;
		Boolean bArgsValid, bPerform;
		strUserId = Master.UserId;
		strCamperUserId = Master.CamperUserId;
		strComments = txtComments.Text.Trim();
		strFJCID = hdnFJCIDStep2_2.Value;
		strCamperAnswers = ConstructCamperAnswers();
		CamperAppl.CamperAnswersServerValidation(strCamperAnswers, strComments, strFJCID, strUserId, (Convert.ToInt32(Redirection_Logic.PageNames.Step2_2)).ToString(), strCamperUserId, out bArgsValid, out bPerform);
		args.IsValid = bArgsValid;
		bPerformUpdate = bPerform;
	}
	#endregion 
}
