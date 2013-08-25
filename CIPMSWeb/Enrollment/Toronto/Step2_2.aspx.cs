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
using CIPMSBC.Eligibility;
using CIPMSBC.BLL;

public partial class Step2_URJ_2 : System.Web.UI.Page
{
	private CamperApplication CamperAppl;
	private General objGeneral;
	private Boolean bPerformUpdate;

    #region "The enums represent question options used in this page ONLY"
    enum SynagogueMemberDropdown
    {
        IDoNotRember = 2,
        Other = 3
    }

    enum SynagogueJCCOther
    {
        Synagogue = 1,
        Other = 2,
        JCC = 3
    }
    #endregion

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
		if (!IsPostBack)
		{
			PopulateDataControls();

			//to get the FJCID which is stored in session
			if (Session["FJCID"] != null)
			{
				hdnFJCIDStep2_2.Value = (string)Session["FJCID"];
                getCamperAnswersFromDB();
			}
		}
	}

	void Page_Unload(object sender, EventArgs e)
	{
		CamperAppl = null;
		objGeneral = null;
	}
    #endregion

    #region "Data Bindings"
    private void PopulateDataControls()
	{
		getGrades();
		getSynagogues();
		PopulateWhoIsInSynagogue();
		getJCCList(Master.CampYear);
	}

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
		ddlWho.DataSource = SynagogueManager.GetWhoIsInSynagogue(FederationEnum.Toronto);
		ddlWho.DataBind();
		ddlWho.Items.Insert(0, new ListItem("-- Select --", "0"));
	}

	private void getSynagogues()
	{
		DataSet dsSynagogue;
		DataView dvSynagogue = new DataView();
		int FedID;
		FedID = Convert.ToInt32(Session["FEDID"].ToString());
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
		FedID = Convert.ToInt32(Session["FEDID"].ToString());
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
			//tdDDLJCC.Visible = true;
			txtJCC.Width = Unit.Pixel(160);
			txtJCC.Enabled = true;
		}
		else
		{
			//tdDDLJCC.Visible = false;
			txtJCC.Width = Unit.Pixel(240); ;
			txtJCC.Enabled = true;
			//tdJCCOther.Attributes.Remove("align");
		}
	}
    #endregion

    #region "Controls Events"

	void btnReturnAdmin_Click(object sender, EventArgs e)
	{
		string strRedirURL;

		strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"].ToString();
		ProcessCamperAnswers();
		Response.Redirect(strRedirURL);
	}

	void btnSaveandExit_Click(object sender, EventArgs e)
	{
		string strRedirURL;

		strRedirURL = Master.SaveandExitURL;
		if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_2.Value, Master.CamperUserId))
		{
			ProcessCamperAnswers();
		}
			  
		if (Master.CheckCamperUser == "Yes")
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

	void btnNext_Click(object sender, EventArgs e)
	{
		int iStatus;
		string strModifiedBy, strFJCID;
		EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.SanFrancisco);

		if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_2.Value, Master.CamperUserId))
		{
			ProcessCamperAnswers();
		}

		bool isReadOnly = objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_2.Value, Master.CamperUserId);
		//Modified by id taken from the Master Id
		strModifiedBy = Master.UserId;
		strFJCID = hdnFJCIDStep2_2.Value;
		if (strFJCID != "" && strModifiedBy != "")
		{
			if (isReadOnly)
			{
				DataSet dsApp = CamperAppl.getCamperApplication(strFJCID);
				iStatus = Convert.ToInt16(dsApp.Tables[0].Rows[0]["Status"]);
			}
			else
			{
				//to check whether the camper is eligible 
				objEligibility.checkEligibilityforStep2(strFJCID, out iStatus);
			}
			Session["STATUS"] = iStatus.ToString();
		}
		Session["FJCID"] = hdnFJCIDStep2_2.Value;
		Response.Redirect("Step2_3.aspx");
	}

    void CusValComments_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string strCamperAnswers, strUserId, strCamperUserId, strComments, strFJCID;
        Boolean bArgsValid, bPerform;
        strUserId = Master.UserId;
        strCamperUserId = Master.CamperUserId;
        strComments = txtComments.Text.Trim();
        strFJCID = hdnFJCIDStep2_2.Value;
        strCamperAnswers = ConstructCamperAnswersString();
        CamperAppl.CamperAnswersServerValidation(strCamperAnswers, strComments, strFJCID, strUserId, (Convert.ToInt32(Redirection_Logic.PageNames.Step2_2)).ToString(), strCamperUserId, out bArgsValid, out bPerform);
        args.IsValid = bArgsValid;
        bPerformUpdate = bPerform;
    }    
    #endregion

    #region "Private functions"
    private void ProcessCamperAnswers()
	{
		InsertCamperAnswersIntoDB();

        string strModifiedBy = Master.UserId;
		string strFJCID = hdnFJCIDStep2_2.Value;
		
		if (strFJCID != "" && strModifiedBy != "" && bPerformUpdate)
		{
            int iRowsAffected = CamperAppl.updateGrade(strFJCID, Int32.Parse(ddlGrade.SelectedValue), txtComments.Text, Convert.ToInt16(strModifiedBy));
		}
	}

	protected void InsertCamperAnswersIntoDB()
	{
		string strFJCID, strComments;
		int RowsAffected;
		string strModifiedBy, strCamperAnswers; //-1 for Camper (User id will be passed for Admin user)
		
		strFJCID = hdnFJCIDStep2_2.Value;
		
		//to get the comments text (used only by the Admin user)
		strComments = txtComments.Text.Trim();

		//Modified by id taken from the common.master
		strModifiedBy = Master.UserId;

		strCamperAnswers = ConstructCamperAnswersString();

		if (strFJCID != "" && strCamperAnswers != "" && strModifiedBy != "" && bPerformUpdate)
			RowsAffected = CamperAppl.InsertCamperAnswers(strFJCID, strCamperAnswers, strModifiedBy, strComments);
		
		CamperAppl = new CamperApplication();
		CamperAppl.UpdateTimeInCampInApplication(strFJCID);
	}

    void getCamperAnswersFromDB()
	{
		DataSet dsAnswers = CamperAppl.getCamperAnswers(hdnFJCIDStep2_2.Value, "", "", "3,6,7,8,30,31,1040,1041,1042,1043,1044,1045");

        foreach (DataRow dr in dsAnswers.Tables[0].Rows)
		{
            int qID = Convert.ToInt32(dr["QuestionId"]);

            if (qID == 3) // Is this your first time to attend a Non-profit Jewish overnight camp, for 3 weeks or longer:
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                if (dr["OptionID"].ToString() == "1")
                    rdoFirstTimerYes.Checked = true;
                else
                    rdoFirstTimerNo.Checked = true;
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
					case SynagogueJCCOther.Other:
						chkNoneOfAboveSynJcc.Checked = true;
                        pnlSynagogue.Enabled = pnlJCC.Enabled = false;
						break;

					case SynagogueJCCOther.Synagogue:
						chkSynagogue.Checked = true;
                        pnlSynagogue.Enabled = true;
                        divReferBy.Style["display"] = "block";
						break;

					case SynagogueJCCOther.JCC:
                        chkJCC.Checked = pnlJCC.Enabled = true;
						break;

					default: 
						chkNoneOfAboveSynJcc.Checked = false; 
						break;
				}
			}
            else if (qID == 31) // Please select your synagogue or JCC
			{
                if (dr["OptionID"].Equals(DBNull.Value) || dr["Answer"].Equals(DBNull.Value))
                    continue;

				if (dr["OptionID"].ToString() == "1")
				{
				    ddlSynagogue.SelectedValue = dr["Answer"].ToString();
				}
				else if (dr["OptionID"].ToString() == "2")
				{
					txtOtherSynagogue.Text = dr["Answer"].ToString();
				}
				else if (dr["OptionID"].ToString().Equals("3"))
				{
					ddlJCC.SelectedValue = dr["Answer"].ToString();
				}
				else if (dr["OptionID"].ToString().Equals("4"))
				{
					txtJCC.Text = dr["Answer"].ToString();
				}
			}
            else if (qID == 1040)
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                if (dr["OptionID"].ToString() == "1")
                {
                    rdoMemberOfYouthYes.Checked = true;
                    if (!dr["Answer"].Equals(DBNull.Value))
                        txtMemberOfYouth.Text = dr["Answer"].ToString();
                }
                else
                    rdoMemberOfYouthNo.Checked = true;

            }
            else if (qID == 1041)
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                rdolistParticipateMarchLiving.SelectedValue = dr["OptionID"].ToString();
            }
            else if (qID == 1042)
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                rdolistParticipateTaglit.SelectedValue = dr["OptionID"].ToString();
            }
            else if (qID == 1043)
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                if (dr["OptionID"].ToString() == "1")
                {
                    rdoBeenToIsraelYes.Checked = true;
                    if (!dr["Answer"].Equals(DBNull.Value))
                        txtBeenToIsrael.Text = dr["Answer"].ToString();
                }
                else
                    rdoBeenToIsraelNo.Checked = true;
            }
            else if (qID == 1044) // Who, if anyone, from your synagogue, did you speak to about Jewish overnight camp?
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                var optionID = dr["OptionID"].ToString();
                if (optionID == "1")
                {
                    rdoCongregant.Checked = true;
                    divWhoInSynagogue.Style["display"] = "block";
                }
                else
                    rdoNoOne.Checked = true;
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
            }
		}
	}

	private string ConstructCamperAnswersString()
	{
		string strQID = "", strTablevalues = "", strFSeparator, strQSeparator, strGrade, strSchool;

		//to get the Question separator from Web.config
		strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
		//to get the Field separator from Web.config
		strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();
		
		strGrade = ddlGrade.SelectedValue;
        strSchool = txtSchoolName.Text.Trim();

		//for question FirstTimerOrNot
		strQID = hdnQ3IdIsFirtTimer.Value;
		strTablevalues += strQID + strFSeparator + Convert.ToString(rdoFirstTimerYes.Checked ? "1" : rdoFirstTimerNo.Checked ? "2" : "") + strFSeparator + strQSeparator;

		//for question Grade
		strQID = hdnQ6IdGrade.Value;
		strTablevalues += strQID + strFSeparator + strFSeparator + strGrade + strQSeparator;

		//for question School Type
		strQID = hdnQ7IdKindofSchool.Value;
		strTablevalues += strQID + strFSeparator + rdoSchoolType.SelectedValue + strFSeparator + rdoSchoolType.SelectedItem.Text + strQSeparator;

		//for question School Name
		strQID = hdnQ8IdSchoolName.Value;
		strTablevalues += strQID + strFSeparator + strFSeparator + strSchool + strQSeparator;

		// 2012-09-13 Synagogue/JCC question
		if (chkNoneOfAboveSynJcc.Checked)
		{
			// Non of Above is selected, so no JCC nor Synagogue
			strQID = hdnQ30IdWereYouReferredBySynOrJcc.Value;
			strTablevalues += strQID + strFSeparator + chkNoneOfAboveSynJcc.Value + strFSeparator + chkNoneOfAboveSynJcc.Value + strQSeparator;

			strQID = hdnQ31SelectSynaJccId.Value;
			strTablevalues += strQID + strFSeparator + "" + strFSeparator + "" + strQSeparator;
		}
		else
		{
			// at least Synagogue or JCC is selected
			if (chkSynagogue.Checked)
			{
				strQID = hdnQ30IdWereYouReferredBySynOrJcc.Value;
				strTablevalues += strQID + strFSeparator + chkSynagogue.Value + strFSeparator + chkSynagogue.Value + strQSeparator;
			}


			if (chkJCC.Checked)
			{
				strQID = hdnQ30IdWereYouReferredBySynOrJcc.Value;
				strTablevalues += strQID + strFSeparator + chkJCC.Value + strFSeparator + chkJCC.Value + strQSeparator;
			}


			//Insert Syna and JCC dropdowns and text boxes (if others is specified)
			strQID = hdnQ31SelectSynaJccId.Value;
			if (chkSynagogue.Checked)
			{
				if (ddlSynagogue.SelectedValue != "0")
				{
					strTablevalues += strQID + strFSeparator + "1" + strFSeparator + ddlSynagogue.SelectedValue + strQSeparator;
					if (txtOtherSynagogue.Text.Trim() != String.Empty)
						strTablevalues += strQID + strFSeparator + "2" + strFSeparator + txtOtherSynagogue.Text.Trim() + strQSeparator;
					
					if (txtOtherSynagogue.Text.Trim() != String.Empty)
					{
						strTablevalues += hdnQ1002SynagogueName.Value + strFSeparator + strFSeparator + txtOtherSynagogue.Text.Trim() + strQSeparator;
					}
					else
					{
						strTablevalues += hdnQ1002SynagogueName.Value + strFSeparator + strFSeparator + ddlSynagogue.SelectedItem.Text + strQSeparator;
					}

					// 2013-08-23 New Synagogue questions
					// Who, if anyone, from your synagogue, did you speak to about Jewish overnight camp?
					// If ¡®a professional or fellow congregant¡¯ selected, offer this list as a check all that apply
					if (rdoCongregant.Checked)
					{
						// A professional or fellow congregant radio button is checked
						strTablevalues += hdnQ1044ReferByType.Value + strFSeparator + "1" + strFSeparator + rdoCongregant.Text + strQSeparator;
					}
					else
					{
						// No one from my synagogue radio button is checked
						strTablevalues += hdnQ1044ReferByType.Value + strFSeparator + "2" + strFSeparator + rdoNoOne.Text + strQSeparator;
					}

					if (txtWhoInSynagogue.Text.Trim() != String.Empty)
					{
						strTablevalues += hdnQ1045ReferBy.Value + strFSeparator + ddlWho.SelectedItem.Value + strFSeparator + txtWhoInSynagogue.Text.Trim() + strQSeparator;
					}
					else
					{
						strTablevalues += hdnQ1045ReferBy.Value + strFSeparator + ddlWho.SelectedItem.Value + strFSeparator + ddlWho.SelectedItem.Text + strQSeparator;
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
						if (txtJCC.Text.Trim() != String.Empty)
							strTablevalues += strQID + strFSeparator + "4" + strFSeparator + txtJCC.Text.Trim() + strQSeparator;
					}
				}
				else
					strTablevalues += strQID + strFSeparator + "4" + strFSeparator + txtJCC.Text.Trim() + strQSeparator;
			}
			else
			{
				strTablevalues += strQID + strFSeparator + "3" + strFSeparator + "" + strQSeparator;
				strTablevalues += strQID + strFSeparator + "4" + strFSeparator + "" + strQSeparator;
			}
		}

		// 2013-08-19 New Questions for Toronto
		// Q1040 Are any members of your family members or alumni of a youth movement? If Yes, which one?
		strQID = hdnQ1040MemberOfYouth.Value;
		strTablevalues += strQID + strFSeparator + (rdoMemberOfYouthYes.Checked ? "1" : "2") + strFSeparator + txtMemberOfYouth.Text + strQSeparator;

		// Has anyone in your family participated in March of the Living? 
		strQID = hdnQ1041ParticipateMarchLiving.Value;
		strTablevalues += strQID + strFSeparator + rdolistParticipateMarchLiving.SelectedValue + strFSeparator + rdolistParticipateMarchLiving.SelectedItem.Text + strQSeparator;

		// Has anyone in your family participated in Taglit-Birthright Israel? 
		strQID = hdnQ1042ParticipateTaglit.Value;
		strTablevalues += strQID + strFSeparator + rdolistParticipateTaglit.SelectedValue + strFSeparator + rdolistParticipateTaglit.SelectedItem.Text + strQSeparator;

		// Has anyone in your family been to Israel? If yes, how many time?
		strQID = hdnQ1043BeenToIsrael.Value;
		strTablevalues += strQID + strFSeparator + (rdoBeenToIsraelYes.Checked ? "1" : "2") + strFSeparator + txtBeenToIsrael.Text + strQSeparator;

		//to remove the extra character at the end of the string, if any
		char[] chartoRemove = { Convert.ToChar(strQSeparator) };
		strTablevalues = strTablevalues.TrimEnd(chartoRemove);

		return strTablevalues;
    }
    #endregion
}
