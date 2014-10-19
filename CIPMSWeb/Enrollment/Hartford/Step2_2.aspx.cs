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
using CIPMSBC.ApplicationQuestions;
using CIPMSBC.BLL;
using CIPMSBC.Eligibility;

public partial class HartfordPage2 : System.Web.UI.Page
{
	private CamperApplication CamperAppl;
	private General objGeneral;
	private Boolean bPerformUpdate;

	#region "Page events"
	protected void Page_Init(object sender, EventArgs e)
	{
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
			PopulateWhoIsInSynagogue();
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

	private void PopulateWhoIsInSynagogue()
	{
		ddlWho.DataSource = SynagogueManager.GetWhoIsInSynagogue(FederationEnum.Hartford);
		ddlWho.DataBind();
		ddlWho.Items.Insert(0, new ListItem("-- Select --", "0"));
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
				iStatus = Convert.ToInt16(dsApp.Tables[0].Rows[0]["Status"]);
			}
			else
			{
				var objEligibility = EligibilityFactory.GetEligibility(FederationEnum.Hartford);
                EligibilityBase.EligibilityResult result = objEligibility.checkEligibilityforStep2(strFJCID, out iStatus, SessionSpecialCode.GetPJLotterySpecialCode());

                if (result.SchoolType == StatusInfo.PendingPJLottery)
                    iStatus = (int)StatusInfo.PendingPJLottery;
                else if (result.CurrentUserStatusFromDB == StatusInfo.SystemInEligible ||
                    result.Grade == StatusInfo.SystemInEligible ||
                    result.SchoolType == StatusInfo.SystemInEligible ||
                    result.TimeInCamp == StatusInfo.SystemInEligible)
                {
                    iStatus = (int)StatusInfo.SystemInEligible;
                }
                else
                {
                    iStatus = (int)StatusInfo.SystemEligible;
                }
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

			int iRowsAffected = CamperAppl.updateGrade(strFJCID, iGrade, strComments, Convert.ToInt16(strModifiedBy));
		}
	}

	protected void InsertCamperAnswers(string strFJCID, string strModifiedBy, string strComments)
	{        
		string strCamperAnswers = ConstructCamperAnswers();

		if (strFJCID != "" && strCamperAnswers != "" && strModifiedBy != "" && bPerformUpdate)
		{
			int RowsAffected = CamperAppl.InsertCamperAnswers(strFJCID, strCamperAnswers, strModifiedBy, strComments);
		}
		
		CamperAppl = new CamperApplication();
		CamperAppl.UpdateTimeInCampInApplication(strFJCID);
	}

	void PopulateAnswers()
	{
		DataSet dsAnswers = CamperAppl.getCamperAnswers(hdnFJCIDStep2_2.Value, "", "", "3,6,7,8,30,31,1044,1045,1063");

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
			else if (qID == 30) //Were you referred to this application through a synagogue or JCC liaison?
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
			else if (qID == 1044) // Who, if anyone, from your synagogue, did you speak to about Jewish overnight camp?
			{
				if (dr["OptionID"].Equals(DBNull.Value))
					continue;

				var optionID = dr["OptionID"].ToString();
				if (optionID == "1")
				{
					rdoCongregant.Checked = true;
					divWhoInSynagogue.Style.Remove("disabled");
				}
				else
				{
					rdoNoOne.Checked = true;
					txtWhoInSynagogue.Enabled = false;
					ddlWho.Enabled = false;
				}
			}
			else if (qID == 1045) // If a professional or fellow congregant is selected, offer this list as a check all that apply
			{
				if (dr["OptionID"].Equals(DBNull.Value))
					continue;

				string optionID = dr["OptionID"].ToString();
				ddlWho.SelectedValue = optionID;
				if (Int32.Parse(optionID) == (int)SynagogueMemberDropdown.Other)
				{
					txtWhoInSynagogue.Text = dr["Answer"].ToString();
				}
				else
					txtWhoInSynagogue.Enabled = false;
			}
			else if (qID == (int)QuestionId.GrandfatherPolicySessionLength) // If a professional or fellow congregant is selected, offer this list as a check all that apply
			{
				if (dr["OptionID"].Equals(DBNull.Value))
					continue;

				if (dr["OptionID"].ToString() == "1")
					rdoDays12.Checked = true;
				else
					rdoDays19.Checked = true;
			}
		}
	}

	private string ConstructCamperAnswers()
	{
		string strQId = "";
		string strTablevalues = "";

		string strQSeparator = QuestionsDelimiters.QuestionSeparator; 
		string strFSeparator = QuestionsDelimiters.FieldSeparator;

		//for question FirstTimerOrNot
		strQId = ((int)QuestionId.FirstTime).ToString();
		strTablevalues += strQId + strFSeparator + Convert.ToString(rdoFirstTimerYes.Checked ? "1" : rdoFirstTimerNo.Checked ? "2" : "") + strFSeparator + strQSeparator;

		//Grandfaother question
		strQId = ((int)QuestionId.GrandfatherPolicySessionLength).ToString();
		strTablevalues += strQId + strFSeparator + (rdoDays12.Checked ? "1" : rdoDays19.Checked ? "2" : "") + strFSeparator + strQSeparator;

		//for question Grade
		strQId = ((int)QuestionId.Grade).ToString();
		strTablevalues += strQId + strFSeparator + strFSeparator + ddlGrade.SelectedValue + strQSeparator;

		//for question School Type
		if (rdoSchoolType.SelectedValue != "")
		{
			strQId = ((int)QuestionId.SchoolType).ToString();
			strTablevalues += strQId + strFSeparator + rdoSchoolType.SelectedValue + strFSeparator + rdoSchoolType.SelectedItem.Text + strQSeparator;
		}

		//for question School Name
		strQId = ((int)QuestionId.SchoolName).ToString();
		strTablevalues += strQId + strFSeparator + strFSeparator + txtSchoolName.Text + strQSeparator;

		// 2012-09-13 Synagogue/JCC question
		if (chkNo.Checked)
		{
			strQId = ((int)QuestionId.Q30_ReferredBySynagogueOrJCC).ToString();
			strTablevalues += strQId + strFSeparator + chkNo.Value + strFSeparator + chkNo.Value + strQSeparator;
			strQId = ((int)QuestionId.Q31_SelectYourSynagogueOrJCC).ToString();
			strTablevalues += strQId + strFSeparator + "" + strFSeparator + "" + strQSeparator;
		}
		else
		{
			if (chkSynagogue.Checked)
			{
				strQId = ((int)QuestionId.Q30_ReferredBySynagogueOrJCC).ToString();
				strTablevalues += strQId + strFSeparator + chkSynagogue.Value + strFSeparator + chkSynagogue.Value + strQSeparator;
			}

			if (chkJCC.Checked)
			{
				strQId = ((int)QuestionId.Q30_ReferredBySynagogueOrJCC).ToString();
				strTablevalues += strQId + strFSeparator + chkJCC.Value + strFSeparator + chkJCC.Value + strQSeparator;
			}

			//This redundant condition is used to insert records in questionid sequence
			strQId = ((int)QuestionId.Q31_SelectYourSynagogueOrJCC).ToString();
			if (chkSynagogue.Checked)
			{
				if (ddlSynagogue.SelectedValue != "0")
				{
					strTablevalues += strQId + strFSeparator + "1" + strFSeparator + ddlSynagogue.SelectedValue + strQSeparator;
					if (txtOtherSynagogue.Text.Trim() != String.Empty)
						strTablevalues += strQId + strFSeparator + "2" + strFSeparator + txtOtherSynagogue.Text.Trim() + strQSeparator;
					if (txtOtherSynagogue.Text.Trim() != String.Empty)
					{
						strTablevalues += hdnQ2Id.Value + strFSeparator + strFSeparator + txtOtherSynagogue.Text.Trim() + strQSeparator;
					}
					else
					{
						strTablevalues += hdnQ2Id.Value + strFSeparator + strFSeparator + ddlSynagogue.SelectedItem.Text + strQSeparator;
					}

					// 2013-08-23 New Synagogue questions
					// Who, if anyone, from your synagogue, did you speak to about Jewish overnight camp?
					// If professional or fellow congregant selected, offer this list as a check all that apply
					if (rdoCongregant.Checked)
					{
						// A professional or fellow congregant radio button is checked
						strTablevalues += ((int)Questions.Q1044ReferByType).ToString() + strFSeparator + "1" + strFSeparator + rdoCongregant.Text + strQSeparator;
					}
					else
					{
						// No one from my synagogue radio button is checked
						strTablevalues += ((int)Questions.Q1044ReferByType).ToString() + strFSeparator + "2" + strFSeparator + rdoNoOne.Text + strQSeparator;
					}

					if (txtWhoInSynagogue.Text.Trim() != String.Empty)
					{
						strTablevalues += ((int)Questions.Q1045ReferBy).ToString() + strFSeparator + ddlWho.SelectedItem.Value + strFSeparator + txtWhoInSynagogue.Text.Trim() + strQSeparator;
					}
					else
					{
						strTablevalues += ((int)Questions.Q1045ReferBy).ToString() + strFSeparator + ddlWho.SelectedItem.Value + strFSeparator + ddlWho.SelectedItem.Text + strQSeparator;
					}
				}
			}
			else
			{
				strTablevalues += strQId + strFSeparator + "1" + strFSeparator + "" + strQSeparator;
				strTablevalues += strQId + strFSeparator + "2" + strFSeparator + "" + strQSeparator;
			}

			if (chkJCC.Checked)
			{
				if (ddlJCC.Items.Count > 0)
				{
					if (ddlJCC.SelectedValue != "0")
					{
						strTablevalues += strQId + strFSeparator + "3" + strFSeparator + ddlJCC.SelectedValue + strQSeparator;
						if (txtOtherJCC.Text.Trim() != String.Empty)
							strTablevalues += strQId + strFSeparator + "4" + strFSeparator + txtOtherJCC.Text.Trim() + strQSeparator;
					}
				}
				else
					strTablevalues += strQId + strFSeparator + "4" + strFSeparator + txtOtherJCC.Text.Trim() + strQSeparator;
			}
			else
			{
				strTablevalues += strQId + strFSeparator + "3" + strFSeparator + "" + strQSeparator;
				strTablevalues += strQId + strFSeparator + "4" + strFSeparator + "" + strQSeparator;
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
