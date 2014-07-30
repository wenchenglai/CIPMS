using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CIPMSBC;
using CIPMSBC.BLL;
using CIPMSBC.Eligibility;
using CIPMSBC.ApplicationQuestions;

public partial class TorontoPage2 : System.Web.UI.Page
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
            txtOtherJCC.Width = Unit.Pixel(240); ;
            txtOtherJCC.Enabled = true;
		}
	}
    #endregion

    #region "Controls Events"

    void btnNext_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;

        bool isReadOnly = objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_2.Value, Master.CamperUserId);
        if (!isReadOnly)
        {
            ProcessCamperAnswers();
        }

        //Modified by id taken from the Master Id
        string strModifiedBy = Master.UserId;
        string strFJCID = hdnFJCIDStep2_2.Value;
        if (strFJCID != "" && strModifiedBy != "")
        {
            int iStatus;
            if (isReadOnly)
            {
                DataSet dsApp = CamperAppl.getCamperApplication(strFJCID);
                iStatus = Convert.ToInt16(dsApp.Tables[0].Rows[0]["Status"]);
            }
            else
            {
                //to check whether the camper is eligible
                EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.Toronto);
                objEligibility.checkEligibilityforStep2(strFJCID, out iStatus);
            }
            Session["STATUS"] = iStatus;
        }
        Session["FJCID"] = hdnFJCIDStep2_2.Value;
        Response.Redirect("Step2_3.aspx");
    }

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

	private void InsertCamperAnswersIntoDB()
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

    private void getCamperAnswersFromDB()
	{
		DataSet dsAnswers = CamperAppl.getCamperAnswers(hdnFJCIDStep2_2.Value, "", "", "3,6,7,8,30,31,1040,1041,1042,1043,1044,1045,1046");

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
                    rdoTasteOfCampNo.Enabled = false;
                    rdoTasteOfCampYes.Enabled = false;
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
            else if (qID == 1040) // Are any members of your family members or alumni of a youth movement? If Yes, which one?
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
                {
                    rdoMemberOfYouthNo.Checked = true;
                    txtMemberOfYouth.Enabled = false;
                }

            }
            else if (qID == 1041) // Has anyone in your family participated in March of the Living?
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                var control = rdolistParticipateMarchLiving.Items.FindByValue(dr["OptionID"].ToString());
                control.Selected = true;
                //control.Attributes.Remove("disabled");
            }
            else if (qID == 1042) // Has anyone in your family participated in Taglit-Birthright Israel?
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                var control = rdolistParticipateTaglit.Items.FindByValue(dr["OptionID"].ToString());
                control.Selected = true;
                //control.Attributes.Remove("disabled");
            }
            else if (qID == 1043) // Has anyone in your family been to Israel? If yes, how many time?
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
                {
                    rdoBeenToIsraelNo.Checked = true;
                    txtBeenToIsrael.Enabled = false;
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
            else if (qID == 1046) // Is the first-time camper attending a Taste of Camp session?
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                if (dr["OptionID"].ToString() == "1")
                {
                    rdoTasteOfCampYes.Checked = true;
                }
                else
                {
                    rdoTasteOfCampNo.Checked = true;
                }
            }
		}
	}

	private string ConstructCamperAnswersString()
	{
		string strQID = "", strTablevalues = "";

		//to get the Question separator from Web.config
		string strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
		//to get the Field separator from Web.config
		string strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();

		//for question FirstTimerOrNot
        strQID = ((int)Questions.Q0003IsFirtTimer).ToString();
		strTablevalues += strQID + strFSeparator + (rdoFirstTimerYes.Checked ? "1" : rdoFirstTimerNo.Checked ? "2" : "") + strFSeparator + strQSeparator;

        // Q1046 Taste of Camp
        strQID = ((int)Questions.Q1046TasteOfCamp).ToString();
        strTablevalues += strQID + strFSeparator + (rdoTasteOfCampYes.Checked ? "1" : rdoTasteOfCampNo.Checked ? "2" : "") + strFSeparator + (rdoTasteOfCampYes.Checked ? "Attended Taste of Camp" : rdoTasteOfCampNo.Checked ? "Did not attend Taste of Camp" : "") + strQSeparator;        

		//for question Grade
        strQID = ((int)Questions.Q0006Grade).ToString();
        strTablevalues += strQID + strFSeparator + strFSeparator + ddlGrade.SelectedValue +strQSeparator;

		//for question School Type
        if (rdoSchoolType.SelectedValue != "")
        {
            strQID = ((int)Questions.Q0007KindofSchool).ToString();
            strTablevalues += strQID + strFSeparator + rdoSchoolType.SelectedValue + strFSeparator + rdoSchoolType.SelectedItem.Text + strQSeparator;
        }

		//for question School Name
        strQID = ((int)Questions.Q0008SchoolName).ToString();
        strTablevalues += strQID + strFSeparator + strFSeparator + txtSchoolName.Text + strQSeparator;

		// 2012-09-13 Synagogue/JCC question
        if (chkNo.Checked)
		{
			// Non of Above is selected, so no JCC nor Synagogue
            strQID = ((int)Questions.Q0030WereYouReferredBySynOrJcc).ToString();
            strTablevalues += strQID + strFSeparator + chkNo.Value + strFSeparator + chkNo.Value + strQSeparator;

            strQID = ((int)Questions.Q0031SelectSynaJcc).ToString();
			strTablevalues += strQID + strFSeparator + "5" + strFSeparator + "NonOfAbove" + strQSeparator;
		}
		else
		{
            if (chkSynagogue.Checked)
            {
                strQID = ((int)Questions.Q0030WereYouReferredBySynOrJcc).ToString();
                strTablevalues += strQID + strFSeparator + chkSynagogue.Value + strFSeparator + chkSynagogue.Value + strQSeparator;
            }

            if (chkJCC.Checked)
            {
                strQID = ((int)Questions.Q0030WereYouReferredBySynOrJcc).ToString();
                strTablevalues += strQID + strFSeparator + chkJCC.Value + strFSeparator + chkJCC.Value + strQSeparator;
            }

			//Insert Syna and JCC dropdowns and text boxes (if others is specified)
            strQID = ((int)Questions.Q0031SelectSynaJcc).ToString();
			if (chkSynagogue.Checked)
			{
				if (ddlSynagogue.SelectedValue != "0")
				{
					strTablevalues += strQID + strFSeparator + "1" + strFSeparator + ddlSynagogue.SelectedValue + strQSeparator;
					if (txtOtherSynagogue.Text.Trim() != String.Empty)
						strTablevalues += strQID + strFSeparator + "2" + strFSeparator + txtOtherSynagogue.Text.Trim() + strQSeparator;
					
					if (txtOtherSynagogue.Text.Trim() != String.Empty)
					{
                        strTablevalues += ((int)Questions.Q1002SynagogueName).ToString() + strFSeparator + strFSeparator + txtOtherSynagogue.Text.Trim() + strQSeparator;
					}
					else
					{
						strTablevalues += ((int)Questions.Q1002SynagogueName).ToString() + strFSeparator + strFSeparator + ddlSynagogue.SelectedItem.Text + strQSeparator;
					}

					// 2013-08-23 New Synagogue questions
					// Who, if anyone, from your synagogue, did you speak to about Jewish overnight camp?
					// If ¡®a professional or fellow congregant¡¯ selected, offer this list as a check all that apply
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
                        if (txtOtherJCC.Text != String.Empty)
                            strTablevalues += strQID + strFSeparator + "4" + strFSeparator + txtOtherJCC.Text + strQSeparator;
					}
				}
				else
                    strTablevalues += strQID + strFSeparator + "4" + strFSeparator + txtOtherJCC.Text + strQSeparator;
			}
			else
			{
				strTablevalues += strQID + strFSeparator + "3" + strFSeparator + "" + strQSeparator;
				strTablevalues += strQID + strFSeparator + "4" + strFSeparator + "" + strQSeparator;
			}
		}

		// 2013-08-19 New Questions for Toronto
		// Q1040 Are any members of your family members or alumni of a youth movement? If Yes, which one?
        if (rdoMemberOfYouthYes.Checked || rdoMemberOfYouthNo.Checked)
        {
            strQID = ((int)Questions.Q1040MemberOfYouth).ToString();
            strTablevalues += strQID + strFSeparator + (rdoMemberOfYouthYes.Checked ? "1" : rdoMemberOfYouthNo.Checked ? "2" : "") + strFSeparator + txtMemberOfYouth.Text + strQSeparator;
        }
		
        // Has anyone in your family participated in March of the Living? 
        if (rdolistParticipateMarchLiving.SelectedValue != "")
        {
            strQID = ((int)Questions.Q1041ParticipateMarchLiving).ToString();
            for (int i = 0; i < 4; i++)
            {
                int k = i + 1;
                if (rdolistParticipateMarchLiving.Items[i].Selected == true)
                    strTablevalues += strQID + strFSeparator + k.ToString() + strFSeparator + rdolistParticipateMarchLiving.Items[i].Text + strQSeparator;

            }
        }

		// Has anyone in your family participated in Taglit-Birthright Israel? 
        if (rdolistParticipateTaglit.SelectedValue != "")
        {
            strQID = ((int)Questions.Q1042ParticipateTaglit).ToString();
            for (int i = 0; i < 4; i++)
            {
                int k = i + 1;
                if (rdolistParticipateTaglit.Items[i].Selected == true)
                    strTablevalues += strQID + strFSeparator + k.ToString() + strFSeparator + rdolistParticipateTaglit.Items[i].Text + strQSeparator;

            }
        }
		// Has anyone in your family been to Israel? If yes, how many time?
        if (rdoBeenToIsraelYes.Checked || rdoBeenToIsraelNo.Checked)
        {
            strQID = ((int)Questions.Q1043BeenToIsrael).ToString();
            strTablevalues += strQID + strFSeparator + (rdoBeenToIsraelYes.Checked ? "1" : rdoBeenToIsraelNo.Checked ? "2" : "") + strFSeparator + txtBeenToIsrael.Text + strQSeparator;
        }
		//to remove the extra character at the end of the string, if any
		char[] chartoRemove = { Convert.ToChar(strQSeparator) };
		strTablevalues = strTablevalues.TrimEnd(chartoRemove);

		return strTablevalues;
    }
    #endregion
}
