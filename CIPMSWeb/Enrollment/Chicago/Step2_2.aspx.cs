using System;
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
using CIPMSBC.Eligibility;


public partial class Step2_Chicago_2 : System.Web.UI.Page
{
	private CamperApplication CamperAppl = new CamperApplication();
	private General objGeneral = new General();
    private Boolean bPerformUpdate;
    
    protected void Page_Init(object sender, EventArgs e)
    {
        btnNext.Click += new EventHandler(btnNext_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click+=new EventHandler(btnReturnAdmin_Click);
        RadioBtnQ3.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
		RadioBtnQ4.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
       
        RadioBtnQ9.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //to fill the grades in the dropdown
            getGrades();

			getSynagogues();

			getJCCList(Master.CampYear);

            //to get the FJCID which is stored in session
            if (Session["FJCID"] != null)
            {
                hdnFJCID.Value = (string)Session["FJCID"]; ;
                getCamperAnswers();
            }

			//foreach (ListItem li in RadioBtnQ4.Items)
			//{
			//    li.Attributes.Add("OnClick", "JavaScript:popupCall(this,'ChicagoSiblingNotSure','Message',false,'step1');");
			//}

			ddlQ10_SelectedIndexChanged(null, null);
        }
		SetSyangogueJCCEnableDisable();
    }

	void btnNext_Click(object sender, EventArgs e)
	{
		int iStatus;
		string strModifiedBy, strFJCID;
		EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.Chicago);

		try
		{
			if (Page.IsValid)
			{
				if (!objGeneral.IsApplicationReadOnly(hdnFJCID.Value, Master.CamperUserId))
				{
					ProcessCamperAnswers();
				}
				bool isReadOnly = objGeneral.IsApplicationReadOnly(hdnFJCID.Value, Master.CamperUserId);
				//Modified by id taken from the Master Id
				strModifiedBy = Master.UserId;
				strFJCID = hdnFJCID.Value;
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
				Session["FJCID"] = hdnFJCID.Value;
				Response.Redirect("Step2_3.aspx");
			}
		}
		catch (Exception ex)
		{
			Response.Write(ex.Message);
		}
	}

    void Page_Unload(object sender, EventArgs e)
    {
        CamperAppl = null;
        objGeneral = null;
    }

    void RadioBtn_SelectedIndexChanged(object sender, EventArgs e)
    {
		setPanelStatus();
    }

    void btnReturnAdmin_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        try
        {
            if (Page.IsValid)
            {
                strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"].ToString();
                ProcessCamperAnswers();
                Response.Redirect(strRedirURL);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    void btnSaveandExit_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        try
        {
            if (Page.IsValid)
            {
                
                strRedirURL = Master.SaveandExitURL;
                if (!objGeneral.IsApplicationReadOnly(hdnFJCID.Value, Master.CamperUserId))
                {
                    ProcessCamperAnswers();
                }
                
                if (Master.CheckCamperUser == "Yes")
                {

                    General oGen = new General();
                    if (oGen.IsApplicationSubmitted(Session["FJCID"].ToString()))
                    {
                        Response.Redirect(strRedirURL);
                    }
                    else
                    {
                        string strScript = "<script language=javascript>openThis(); window.location='" + strRedirURL + "';</script>";
                        if (!ClientScript.IsStartupScriptRegistered("clientScript"))
                        {
                            ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strScript);
                        }
                    }
                }
                else
                {
                    Response.Redirect(strRedirURL);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    void btnPrevious_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                if (!objGeneral.IsApplicationReadOnly(hdnFJCID.Value, Master.CamperUserId))
                {
                    ProcessCamperAnswers();
                }
                Session["FJCID"] = hdnFJCID.Value;
                Response.Redirect("Summary.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
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
			tdDDLJCC.Visible = true;
			lblJCC.Visible = true;
			txtJCC.Width = Unit.Pixel(160);
			txtJCC.Enabled = true;
		}
		else
		{
			tdDDLJCC.Visible = false;
			lblJCC.Visible = false;
			txtJCC.Width = Unit.Pixel(240); ;
			txtJCC.Enabled = true;
			tdJCCOther.Attributes.Remove("align");
		}
	}

    private void ProcessCamperAnswers()
    {
        string strComments, strFJCID, strModifiedBy;
        int iGrade, iResult;
        int iRowsAffected;
        string strGrade;

        InsertCamperAnswers();

        ////to update the grade to the database - to be used by the search
        
        strComments = "";
        strFJCID = hdnFJCID.Value;
        strModifiedBy = Master.UserId;
        if (strFJCID != "" & strModifiedBy!="" && bPerformUpdate)
        {
            strGrade = ddlGrade.SelectedValue;
            int.TryParse(strGrade, out iResult);
            if (iResult == 0 || strGrade.Equals(string.Empty))
                iGrade = 0;
            else
                iGrade = iResult;

            iRowsAffected = CamperAppl.updateGrade(strFJCID, iGrade, strComments, Convert.ToInt16(strModifiedBy));
        }
    }

    protected void InsertCamperAnswers()
    {
        string strFJCID, strModifiedBy, strComments, strCamperAnswers;
        int RowsAffected;
        
        //to get the Comments text (used by the Admin user)
        strComments = txtComments.Text.Trim();

        strFJCID = hdnFJCID.Value;
        strModifiedBy = Master.UserId;
        strCamperAnswers = ConstructCamperAnswers();

        if (strFJCID != "" && strCamperAnswers != "" && strModifiedBy != "" && bPerformUpdate)
            RowsAffected = CamperAppl.InsertCamperAnswers(strFJCID, strCamperAnswers, strModifiedBy, strComments);
        CamperAppl = new CamperApplication();
       CamperAppl.UpdateTimeInCampInApplication(strFJCID);
    }

    //to fill the grade values to the grade dropdown
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

    //to get the camper answers from the database
    void getCamperAnswers()
    {
        string strFilter, strFJCID, strModifiedBy;
        DataSet dsAnswers;
        DataView dv;
        RadioButtonList rb;
        DataRow dr;
        DataRow[] drows;
        HiddenField hdnval;
        DropDownList ddl;
        TextBox tb;
        strFJCID = hdnFJCID.Value;
        strModifiedBy = Master.UserId;
        if (!strFJCID.Equals(string.Empty))
        {
            dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "3", "33", "Y");
            if (dsAnswers.Tables[0].Rows.Count > 0) //if there are records for the current FJCID
            {
                dv = dsAnswers.Tables[0].DefaultView;

				//2012-09-16 Chicago has two nwely added question 1032, 1033, 1034
				drows = dv.Table.Select("QuestionId = 1032");
				if (drows.Length > 0) //if there are rows for the filter
				{
					dr = (DataRow)drows.GetValue(0);

					if (!dr["OptionID"].Equals(DBNull.Value))
						RadioBtnQ4.SelectedValue = dr["OptionID"].ToString();
				}

				drows = dv.Table.Select("QuestionId = 1033");
				if (drows.Length > 0) //if there are rows for the filter
				{
					dr = (DataRow)drows.GetValue(0);

					if (!dr["Answer"].Equals(DBNull.Value))
						txtSiblingFirstName.Text = dr["Answer"].ToString();
				}

				drows = dv.Table.Select("QuestionId = 1034");
				if (drows.Length > 0) //if there are rows for the filter
				{
					dr = (DataRow)drows.GetValue(0);

					if (!dr["Answer"].Equals(DBNull.Value))
						txtSiblingLastName.Text = dr["Answer"].ToString();
				}

                //to display answers for the Questions 3 -11
                for (int i = 3; i <= 9; i++)
                {
                    //to get the QuestionId for the Questions
                    hdnval = (HiddenField)PnlHidden.FindControl("hdnQ" + i.ToString() + "Id");
                    strFilter = "QuestionId = '" + hdnval.Value + "'";
                    tb = null;
                    ddl = null;
                    rb = null;

                    switch (i)
                    {
                        case 3:  //assigning the answer for question 3
                            rb = (RadioButtonList)Panel2.FindControl("RadioBtnQ" + i.ToString());
                            goto default;
                        case 4:// assigning the answer for question 4
                            rb = (RadioButtonList)Panel2.FindControl("RadioBtnQ" + i.ToString());
                            goto default;
                        case 5:// assigning the answer for question 5
                            rb = (RadioButtonList)Panel2.FindControl("RadioBtnQ" + i.ToString());
                            goto default;
                        case 6: // assigning the answer for question 6
                            ddl = ddlGrade;
                            goto default;
                        case 7: // assigning the answer for question 9
                            rb = (RadioButtonList)Panel2.FindControl("RadioBtnQ9");
                            goto default;
                        case 8: // assigning the answer for question 10
                            ddl = ddlQ10;
                            tb = txtJewishSchool;
                            goto default;
                        case 9: // assigning the answer for question 11
                            tb = txtCamperSchool;
                            goto default;
                        default:  //to implement the common logic
                            drows = dv.Table.Select(strFilter);
                            if (drows.Length > 0) //if there are rows for the filter
                            {
                                dr = (DataRow)drows.GetValue(0);
                                //for dropdownlist
                                if (ddl != null)
                                {
                                    if (ddl == ddlGrade)  //for the grade question the value is stored in "Answer"
                                    {
                                        if (!dr["Answer"].Equals(DBNull.Value))
                                            ddl.SelectedValue = dr["Answer"].ToString();
                                    }
                                    else
                                        if (!dr["OptionID"].Equals(DBNull.Value))
                                            ddl.SelectedValue = dr["OptionID"].ToString();
                                    
                                }
                                //for text box
                                if (tb != null)
                                {
                                    if (!dr["Answer"].Equals(DBNull.Value))
                                        tb.Text = dr["Answer"].ToString();
                                }
                                //for radio buttonlist
                                if (rb != null)
                                {
                                    if (!dr["OptionID"].Equals(DBNull.Value))
                                        rb.SelectedValue = dr["OptionID"].ToString();
                                }
                            }

							getSynagogueAnswers();
                            break;
                    }
                }
            }
            //to set the status of the panel based on the radio button selected
            setPanelStatus();
        } //end if for null check of fjcid
       
    }

	void getSynagogueAnswers()
	{
		string strFJCID;
		DataSet dsAnswers;
		DataView dv;
		string strFilter;

		strFJCID = hdnFJCID.Value;
		if (!strFJCID.Equals(string.Empty))
		{
			dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "25", "31", "N");
			if (dsAnswers.Tables[0].Rows.Count > 0) //if there are records for the current FJCID
			{
				dv = dsAnswers.Tables[0].DefaultView;
				//to display answers for the QuestionId 3,6,7 and 8 for step 2_2_Midsex
				for (int i = 0; i < dsAnswers.Tables[0].Rows.Count; i++)
				{
					DataRow drRow = dsAnswers.Tables[0].Rows[i];
					strFilter = "QuestionId = '" + drRow["QuestionId"].ToString() + "'";
					switch (Int32.Parse(drRow["QuestionId"].ToString()))
					{
						case 30:  //assigning the answer for question 3
							foreach (DataRow dr in dv.Table.Select(strFilter))
							{
								if (!dr["OptionID"].Equals(DBNull.Value))
								{
									int value = Convert.ToInt32(dr["OptionID"].ToString());
									switch (value)
									{
										case 2:
											{
												chkNoneOfAboveSynJcc.Checked = true;
												Pnl9a.Enabled = Pnl10a.Enabled = false;
												break;
											}
										case 1:
											{
												chkSynagogue.Checked = true;
												Pnl9a.Enabled = true;
												break;
											}
										case 3:
											{
												chkJCC.Checked = Pnl10a.Enabled = true;
												break;
											}
										default: chkNoneOfAboveSynJcc.Checked = false; break;
									}
								}
							}
							break;
						case 31: // assigning the answer for question 6

							foreach (DataRow dr in dv.Table.Select(strFilter))
							{
								if (!dr["OptionID"].Equals(DBNull.Value))
								{
									if (dr["OptionID"].ToString() == "1")
									{
										if (!dr["Answer"].Equals(DBNull.Value))
										{
											ddlSynagogue.SelectedValue = dr["Answer"].ToString();
										}
									}
									else if (dr["OptionID"].ToString() == "2")
										if (!dr["Answer"].Equals(DBNull.Value))
										{
											txtOtherSynagogue.Text = dr["Answer"].ToString();
										}
									if (dr["OptionID"].ToString().Equals("3"))
									{
										if (!dr["Answer"].Equals(DBNull.Value))
											ddlJCC.SelectedValue = dr["Answer"].ToString();
									}


									if (dr["OptionID"].ToString().Equals("4"))
									{
										if (!dr["Answer"].Equals(DBNull.Value))
											txtJCC.Text = dr["Answer"].ToString();

									}
								}
							}

							break;
					}
				}
			}
		}
	}

    protected void RadioBtn_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            setPanelStatus();
        }
        catch (Exception ex) 
        {
            Response.Write(ex.Message);
        }
    }

    //to set the panels and controls to be disabled based on the radio button selected
    void setPanelStatus()
    {
		if (RadioBtnQ4.SelectedIndex.Equals(0))  //Yes is selected
		{
			PnlQ5.Enabled = true;
		}
		else if (RadioBtnQ4.SelectedIndex.Equals(1) || RadioBtnQ4.SelectedIndex.Equals(2)) //No is selected
		{
			PnlQ5.Enabled = false;
		}

        //for Question 9
		lblJewishDaySchool.Text = "";
        if (RadioBtnQ9.SelectedIndex == 3) //Jewish school is selected
        {
			PnlQ10.Enabled = true;
			pnlJewishSchool.Enabled = true;
			pnlCamperSchool.Enabled = false;
			Label23.Enabled = false;
			Label14.Enabled = false;
			txtCamperSchool.Text = "";
			Label15.Enabled = false;

			lblJewishDaySchool.Text = "If your Jewish day school is not listed in the drop down below, please contact Hallie Shapiro Devir at JewishCamp@juf.org or 312-357-4995 to learn more about grants and scholarships opportunities.";
		}
        else if (RadioBtnQ9.SelectedIndex != -1)  //for the rest of the options disable it
        {
            PnlQ10.Enabled = false;
            pnlJewishSchool.Enabled = false;
            if (RadioBtnQ9.SelectedIndex == 2)
            {
                pnlCamperSchool.Enabled = false;
                Label23.Enabled = false;
                Label14.Enabled = false;
                Label23.Enabled = false;                
                Label15.Enabled = false;
                txtCamperSchool.Text = "";
            }
            else
            {
                pnlCamperSchool.Enabled = true;
                Label23.Enabled = true;
                Label14.Enabled = true;
                Label15.Enabled = true;
            }
            
            ddlQ10.SelectedIndex = 0;
            txtJewishSchool.Text = "";
        }

        if (ddlQ10.SelectedValue == "3")
        {
            pnlJewishSchool.Enabled = true;
        }
        else
        {
            pnlJewishSchool.Enabled = false;
        }

		if (RadioBtnQ4.SelectedValue == "3")
		{
			lblNotSureSibling.Text = "Please contact Hallie Shapiro Devir at <a href='mailto:JewishCamp@juf.org'>JewishCamp@juf.org</a> or 312-357-4995. <br />Siblings of first-time campers who previously received a $1,000 grant are eligible <br />to receive $500 when they attend camp for the first time for at least 19 consecutive days.";
		}
		else
		{
			lblNotSureSibling.Text = "";
		}

		SetSyangogueJCCEnableDisable();
	}

	private void SetSyangogueJCCEnableDisable()
	{
		if (chkSynagogue.Checked == false) 
			ddlSynagogue.Enabled = lblOtherSynogogueQues.Enabled = txtOtherSynagogue.Enabled = false;
		else
			ddlSynagogue.Enabled = lblOtherSynogogueQues.Enabled = txtOtherSynagogue.Enabled = true;
		if (chkJCC.Checked == false) 
			ddlJCC.Enabled = lblJCC.Enabled = txtJCC.Enabled = false;
		else
			ddlJCC.Enabled = lblJCC.Enabled = txtJCC.Enabled = true;
		
		if (ddlJCC.Visible == false) 
			tdJCCOther.Attributes.Remove("align");
	}

    private string ConstructCamperAnswers()
    {
        string strQuestionId = "";
        string strTablevalues = "";
        string strFSeparator;
        string strQSeparator;
        string strQ4Value = string.Empty;
        string strGrade, strSchool, strJewishSchool;
        
        //to get the Question separator from Web.config
        strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
        //to get the Field separator from Web.config
        strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();

        //for question 3
        strQuestionId = hdnQ3Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ3.SelectedValue + strFSeparator + strQSeparator;

		//for question 4
		strQuestionId = hdnQ1032Id.Value;
		strTablevalues += strQuestionId + strFSeparator + RadioBtnQ4.SelectedValue + strFSeparator + strQSeparator;

		//for question 5
		strQuestionId = hdnQFirstNameOfSibling.Value;
		strTablevalues += strQuestionId + strFSeparator + strFSeparator + txtSiblingFirstName.Text + strQSeparator;

		//for question 5
		strQuestionId = hdnQLastNameOfSibling.Value;
		strTablevalues += strQuestionId + strFSeparator + strFSeparator + txtSiblingLastName.Text + strQSeparator;

        //for question 6
        strQuestionId = hdnQ6Id.Value;
        strGrade = ddlGrade.SelectedValue;
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strGrade + strQSeparator;

        //for question 9
        strQuestionId = hdnQ7Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ9.SelectedValue + strFSeparator + strQSeparator;

        //for question 10
        strQuestionId = hdnQ8Id.Value;
        strJewishSchool = txtJewishSchool.Text.Trim();
        strTablevalues += strQuestionId + strFSeparator + ddlQ10.SelectedValue + strFSeparator + strJewishSchool + strQSeparator;

        //for question 11
        strQuestionId = hdnQ9Id.Value;
        strSchool = txtCamperSchool.Text.Trim();
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strSchool + strQSeparator;

		// 2012-09-25 Synagogue/JCC question
		if (chkNoneOfAboveSynJcc.Checked)
		{
			// Non of Above is selected, so no JCC nor Synagogue
			strQuestionId = hdnQ30WereYouReferredBySynOrJccId.Value;
			strTablevalues += strQuestionId + strFSeparator + chkNoneOfAboveSynJcc.Value + strFSeparator + chkNoneOfAboveSynJcc.Value + strQSeparator;

			strQuestionId = hdnQ31SelectSynaJccId.Value;
			strTablevalues += strQuestionId + strFSeparator + "" + strFSeparator + "" + strQSeparator;
		}
		else
		{
			// at least Synagogue or JCC is selected
			if (chkSynagogue.Checked)
			{
				strQuestionId = hdnQ30WereYouReferredBySynOrJccId.Value;
				strTablevalues += strQuestionId + strFSeparator + chkSynagogue.Value + strFSeparator + chkSynagogue.Value + strQSeparator;
			}


			if (chkJCC.Checked)
			{
				strQuestionId = hdnQ30WereYouReferredBySynOrJccId.Value;
				strTablevalues += strQuestionId + strFSeparator + chkJCC.Value + strFSeparator + chkJCC.Value + strQSeparator;
			}


			//Insert Syna and JCC dropdowns and text boxes (if others is specified)
			strQuestionId = hdnQ31SelectSynaJccId.Value;
			if (chkSynagogue.Checked)
			{
				if (ddlSynagogue.SelectedValue != "0")
				{
					strTablevalues += strQuestionId + strFSeparator + "1" + strFSeparator + ddlSynagogue.SelectedValue + strQSeparator;
					if (txtOtherSynagogue.Text.Trim() != String.Empty)
						strTablevalues += strQuestionId + strFSeparator + "2" + strFSeparator + txtOtherSynagogue.Text.Trim() + strQSeparator;
					if (txtOtherSynagogue.Text.Trim() != String.Empty)
					{
						strTablevalues += hdnQ1002NameOfSynagogueId.Value + strFSeparator + strFSeparator + txtOtherSynagogue.Text.Trim() + strQSeparator;
					}
					else
					{
						strTablevalues += hdnQ1002NameOfSynagogueId.Value + strFSeparator + strFSeparator + ddlSynagogue.SelectedItem.Text + strQSeparator;
					}
				}
			}
			else
			{
				strTablevalues += strQuestionId + strFSeparator + "1" + strFSeparator + "" + strQSeparator;
				strTablevalues += strQuestionId + strFSeparator + "2" + strFSeparator + "" + strQSeparator;
			}

			if (chkJCC.Checked)
			{
				if (ddlJCC.Items.Count > 0)
				{
					if (ddlJCC.SelectedValue != "0")
					{
						strTablevalues += strQuestionId + strFSeparator + "3" + strFSeparator + ddlJCC.SelectedValue + strQSeparator;
						if (txtJCC.Text.Trim() != String.Empty)
							strTablevalues += strQuestionId + strFSeparator + "4" + strFSeparator + txtJCC.Text.Trim() + strQSeparator;
					}
				}
				else
					strTablevalues += strQuestionId + strFSeparator + "4" + strFSeparator + txtJCC.Text.Trim() + strQSeparator;
			}
			else
			{
				strTablevalues += strQuestionId + strFSeparator + "3" + strFSeparator + "" + strQSeparator;
				strTablevalues += strQuestionId + strFSeparator + "4" + strFSeparator + "" + strQSeparator;
			}
		}

        //to remove the extra character at the end of the string, if any
        char[] chartoRemove = { Convert.ToChar(strQSeparator) };
        strTablevalues = strTablevalues.TrimEnd(chartoRemove);

        return strTablevalues;
    }

    //to validate the comments field for Admin
    void CusValComments_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            string strCamperAnswers, strUserId, strCamperUserId, strComments, strFJCID;
            Boolean bArgsValid, bPerform;
            strUserId = Master.UserId;
            strCamperUserId = Master.CamperUserId;
            strComments = txtComments.Text.Trim();
            strFJCID = hdnFJCID.Value;
            strCamperAnswers = ConstructCamperAnswers();
            CamperAppl.CamperAnswersServerValidation(strCamperAnswers, strComments, strFJCID, strUserId, (Convert.ToInt32(Redirection_Logic.PageNames.Step2_2)).ToString(), strCamperUserId, out bArgsValid, out bPerform);
            args.IsValid = bArgsValid;
            bPerformUpdate = bPerform;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

	private bool hasValidCode()
	{
		int CampYearID = Convert.ToInt32(Application["CampYearID"]);
		int FedID = Convert.ToInt32(FederationEnum.Chicago);
		List<string> specialCodes = SpecialCodeManager.GetAvailableCodes(CampYearID, FedID);

		if (Session["UsedCode"] != null)
		{
			string currentCode = Session["UsedCode"].ToString();
			foreach (string code in specialCodes)
			{
				if (code == currentCode)
				{
					SpecialCodeManager.UseCode(CampYearID, FedID, code, Session["FJCID"].ToString());
					return true;
				}
			}
		}
		return false;
	}

	private bool hasValidCodeOld()
	{
		if (Session["UsedCode"] != null)
		{
			Dictionary<string, string> codes = new Dictionary<string, string>();
			codes.Add("CHI2553", "CHI2553");
			codes.Add("CHI3228", "CHI3228");
			codes.Add("CHI1239", "CHI1239");
			codes.Add("CHI4613", "CHI4613");
			codes.Add("CHI4710", "CHI4710");
			codes.Add("CHI3929", "CHI3929");
			codes.Add("CHI3279", "CHI3279");
			codes.Add("CHI1210", "CHI1210");
			codes.Add("CHI2271", "CHI2271");
			codes.Add("CHI3129", "CHI3129");
			codes.Add("CHI3485", "CHI3485");
			codes.Add("CHI3444", "CHI3444");
			codes.Add("CHI1220", "CHI1220");
			codes.Add("CHI3865", "CHI3865");
			codes.Add("CHI4041", "CHI4041");
			codes.Add("CHI3854", "CHI3854");
			codes.Add("CHI4749", "CHI4749");
			codes.Add("CHI1964", "CHI1964");
			codes.Add("CHI2760", "CHI2760");
			codes.Add("CHI3877", "CHI3877");
			codes.Add("CHI4503", "CHI4503");
			codes.Add("CHI3861", "CHI3861");
			codes.Add("CHI2785", "CHI2785");
			codes.Add("CHI4498", "CHI4498");
			codes.Add("CHI4100", "CHI4100");
			codes.Add("CHI3479", "CHI3479");
			codes.Add("CHI2137", "CHI2137");
			codes.Add("CHI1712", "CHI1712");
			codes.Add("CHI2915", "CHI2915");
			codes.Add("CHI1434", "CHI1434");
			codes.Add("CHI1888", "CHI1888");
			codes.Add("CHI1112", "CHI1112");
			codes.Add("CHI3807", "CHI3807");
			codes.Add("CHI1672", "CHI1672");
			codes.Add("CHI3528", "CHI3528");
			codes.Add("CHI1935", "CHI1935");
			codes.Add("CHI4699", "CHI4699");
			codes.Add("CHI3724", "CHI3724");
			codes.Add("CHI1053", "CHI1053");
			codes.Add("CHI2559", "CHI2559");
			codes.Add("CHI3863", "CHI3863");
			codes.Add("CHI3491", "CHI3491");
			codes.Add("CHI1091", "CHI1091");
			codes.Add("CHI2991", "CHI2991");
			codes.Add("CHI3060", "CHI3060");
			codes.Add("CHI2025", "CHI2025");
			codes.Add("CHI1163", "CHI1163");
			codes.Add("CHI4426", "CHI4426");
			codes.Add("CHI3201", "CHI3201");
			codes.Add("CHI3165", "CHI3165");

			return codes.ContainsKey(Session["UsedCode"].ToString());
		}
		return false;
	}

    protected void ddlQ10_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlQ10.SelectedValue == "3")
        {
            pnlJewishSchool.Enabled = true;

			if (!hasValidCode())
			{
				btnNext.Visible = false;
			}
			else
			{
				lblJewishDaySchool.Text = "";
				btnNext.Visible = true;
			}
        }
        else
        {
			btnNext.Visible = true;
            if (RadioBtnQ9.SelectedIndex == 4)
            {
                pnlCamperSchool.Enabled = true;
                Label23.Enabled = true;
                Label14.Enabled = true;
                Label15.Enabled = true;
            }
            else
            {
                pnlCamperSchool.Enabled = false;
                Label23.Enabled = false;
                Label14.Enabled = false;
                Label15.Enabled = false;
                txtCamperSchool.Text = "";
            }

            pnlJewishSchool.Enabled = false;
            txtJewishSchool.Text = "";
        }
    }
}
