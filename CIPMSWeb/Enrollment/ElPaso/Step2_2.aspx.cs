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
using CIPMSBC.Eligibility;

public partial class Step2_URJ_2 : System.Web.UI.Page
{
    private CamperApplication CamperAppl;
    private General objGeneral;
    private Boolean bPerformUpdate;

    protected void Page_Init(object sender, EventArgs e)
    {
        bool isClosed = (from id in ConfigurationManager.AppSettings["OpenFederations"].Split(',')
                         where id == ((int)FederationEnum.ElPaso).ToString()
                         select id).Count() < 1;

        if (isClosed)
        {
            Response.Redirect("~/NLIntermediate.aspx");
        }

        btnNext.Click += new EventHandler(btnNext_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click+=new EventHandler(btnReturnAdmin_Click);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        RadioButtionQ5.SelectedIndexChanged += new EventHandler(RadioButtionQ5_SelectedIndexChanged);
    }

	protected void Page_Load(object sender, EventArgs e)
	{
		CamperAppl = new CamperApplication();
		objGeneral = new General();
		if (!Page.IsPostBack)
		{
			//to fill the grades in the dropdown
			getGrades();

			// Syangogue and JCC list
			getSynagogues();
			getJCCList(Master.CampYear);

			//to get the FJCID which is stored in session
			if (Session["FJCID"] != null)
			{
				hdnFJCIDStep2_2.Value = (string)Session["FJCID"];
				getCamperAnswers();
			}
		}
		if (chkSynagogue.Checked == false) ddlSynagogue.Enabled = lblOtherSynogogueQues.Enabled = txtOtherSynagogue.Enabled = false;
		if (chkJCC.Checked == false) ddlJCC.Enabled = lblJCC.Enabled = txtJCC.Enabled = false;
		if (ddlJCC.Visible == false) tdJCCOther.Attributes.Remove("align");
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

    void RadioButtionQ5_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            setTextBoxStatus();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
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
   
    //page unload
    void Page_Unload(object sender, EventArgs e)
    {
        CamperAppl = null;
        objGeneral = null;
    }

    void btnSaveandExit_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        try
        {
            if (Page.IsValid)
            {
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
                if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_2.Value, Master.CamperUserId))
                {
                    ProcessCamperAnswers();
                }
                Session["FJCID"] = hdnFJCIDStep2_2.Value;
                
                Response.Redirect("Summary.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    void btnNext_Click(object sender, EventArgs e)
    {
        int iStatus;
        string strModifiedBy, strFJCID;
        EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.ElPaso);

        try
        {
            if (Page.IsValid)
            {
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
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
       
    }

    private void ProcessCamperAnswers()
    {
        string strFJCID;
        string strComments;
        int iGrade, iResult;
        int iRowsAffected;
        string strModifiedBy, strGrade;

        //Modified by id taken from the common.master
        strModifiedBy = Master.UserId;

        InsertCamperAnswers();

        //to update the grade to the database - to be used by the search
        strFJCID = hdnFJCIDStep2_2.Value;
        //used only by the Admin user
        strComments = txtComments.Text.Trim();
        if (strFJCID != "" && strModifiedBy!="" && bPerformUpdate)
        {
            strGrade = ddlGrade.SelectedValue;
            int.TryParse(strGrade,out iResult);
            if (iResult==0 || strGrade.Equals(string.Empty))
                iGrade=0;
            else
                iGrade = iResult;

            iRowsAffected = CamperAppl.updateGrade(strFJCID, iGrade, strComments, Convert.ToInt16(strModifiedBy));
        }
    }

    protected void InsertCamperAnswers()
    {
        string strFJCID, strComments;
        int RowsAffected;
        string strModifiedBy, strCamperAnswers; //-1 for Camper (User id will be passed for Admin user)
        
        strFJCID = hdnFJCIDStep2_2.Value;
        
        //to get the comments text (used only by the Admin user)
        strComments = txtComments.Text.Trim();

        //Modified by id taken from the common.master
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
        dtGrade = objGeneral.getGrades(Session["FedId"].ToString(),Master.CampYear);
        ddlGrade.DataSource = dtGrade;
        ddlGrade.DataTextField = "EligibleGrade";
        ddlGrade.DataValueField = "EligibleGrade";
        ddlGrade.DataBind();
        ddlGrade.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    //to set the school text box status to enable / disable based on the school type selected
    private void setTextBoxStatus()
    {
        if (RadioButtionQ5.SelectedValue == "3")   //Home school is selected
        {
            PnlQ6.Enabled = false;
            txtCamperSchool.Text = "";
        }
        else
        {
            PnlQ6.Enabled = true;
        }
    }

    //to get the camper answers from the database
    void getCamperAnswers()
    {
        string strFJCID;
        DataSet dsAnswers;
        DataView dv;
        RadioButton rb;
        string strFilter;
        
        strFJCID = hdnFJCIDStep2_2.Value;
        if (!strFJCID.Equals(string.Empty))
        {
            dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "3", "8", "N");
            if (dsAnswers.Tables[0].Rows.Count > 0) //if there are records for the current FJCID
            {
                dv = dsAnswers.Tables[0].DefaultView;
                //to display answers for the QuestionId 3,6,7 and 8 for step 2_2_Midsex
                for (int i = 3; i <= 8; i++)
                {
                    strFilter = "QuestionId = '" + i.ToString() + "'";

                    switch (i)
                    {
                        case 3:  //assigning the answer for question 3
                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["OptionID"].Equals(DBNull.Value))
                                {
                                    rb = (RadioButton)Panel2.FindControl("RadioBtnQ3" + dr["OptionID"].ToString());
                                    rb.Checked = true;
                                }
                            }
                            
                            break;
                        case 6: // assigning the answer for question 6

                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["Answer"].Equals(DBNull.Value))
                                {
                                    ddlGrade.SelectedValue = dr["Answer"].ToString();
                                }
                            }
                            break;

                        case 7:// assigning the answer for question 7
                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["OptionID"].Equals(DBNull.Value))
                                {
                                    RadioButtionQ5.SelectedValue = dr["OptionID"].ToString();
                                }
                            }
                            break;

                        case 8: // assigning the answer for question 8
                            int intSchool;
                            DataSet dsSchool = new DataSet();
                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["OptionID"].Equals(DBNull.Value))
                                {
                                    if (!dr["Answer"].Equals(DBNull.Value))
                                    {
                                        Int32.TryParse(dr["Answer"].ToString(), out intSchool);
                                        if (intSchool > 0)
                                        {
                                            dsSchool = CamperAppl.GetSchool(intSchool);
                                            txtCamperSchool.Text = dsSchool.Tables[0].Rows[0]["Answer"].ToString();
                                        }
                                        else
                                        {
                                            txtCamperSchool.Text = dr["Answer"].ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    if (!dr["Answer"].Equals(DBNull.Value))
                                    {
                                        txtCamperSchool.Text = dr["Answer"].ToString();
                                    }
                                }
                            }
                            break;
						default:
							getSynagogueAnswers();
							break;
                    }
                }
            }
            //to set the school text box to enable / disable based on the school type selected
            setTextBoxStatus();
        } //end if for null check of fjcid
    }

	void getSynagogueAnswers()
	{
		string strFJCID;
		DataSet dsAnswers;
		DataView dv;
		string strFilter;

		strFJCID = hdnFJCIDStep2_2.Value;
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

    private string ConstructCamperAnswers()
    {
        string strQuestionId = "";
        string strTablevalues = "";
        string strFSeparator;
        string strQSeparator;
        string strGrade, strSchool;

        //to get the Question separator from Web.config
        strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
        //to get the Field separator from Web.config
        strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();
        
        strGrade = ddlGrade.SelectedValue;
        strSchool = txtCamperSchool.Text.Trim();

        //for question FirstTimerOrNot
		strQuestionId = hdnQ3IdIsFirtTimer.Value;
        strTablevalues += strQuestionId + strFSeparator + Convert.ToString(RadioBtnQ31.Checked ? "1" : RadioBtnQ32.Checked ? "2" : "") + strFSeparator + strQSeparator;

        //for question Grade
        strQuestionId = hdnQ6IdGrade.Value;
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strGrade + strQSeparator;

        //for question 5
		strQuestionId = hdnQ7IdKindofSchool.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioButtionQ5.SelectedValue + strFSeparator + strQSeparator;

        //for question 6
		strQuestionId = hdnQ8IdSchoolName.Value;
		strTablevalues += strQuestionId + strFSeparator + strFSeparator + strSchool + strQSeparator;

		// 2012-09-13 Synagogue/JCC question
		if (chkNoneOfAboveSynJcc.Checked)
		{
			// Non of Above is selected, so no JCC nor Synagogue
			strQuestionId = hdnQ30IdWereYouReferredBySynOrJcc.Value;
			strTablevalues += strQuestionId + strFSeparator + chkNoneOfAboveSynJcc.Value + strFSeparator + chkNoneOfAboveSynJcc.Value + strQSeparator;

			strQuestionId = hdnQ31SelectSynaJccId.Value;
			strTablevalues += strQuestionId + strFSeparator + "" + strFSeparator + "" + strQSeparator;
		}
		else
		{
			// at least Synagogue or JCC is selected
			if (chkSynagogue.Checked)
			{
				strQuestionId = hdnQ30IdWereYouReferredBySynOrJcc.Value;
				strTablevalues += strQuestionId + strFSeparator + chkSynagogue.Value + strFSeparator + chkSynagogue.Value + strQSeparator;
			}


			if (chkJCC.Checked)
			{
				strQuestionId = hdnQ30IdWereYouReferredBySynOrJcc.Value;
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

    void CusValComments_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
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
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }


}
