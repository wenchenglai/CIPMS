using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using CIPMSBC;
using CIPMSBC.Eligibility;
using CIPMSBC.ApplicationQuestions;


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
        rdolistSiblingAttended.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        rdoSchoolType.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
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
            ddlJewishDaySchool_SelectedIndexChanged(null, null);
        }
		SetSyangogueJCCEnableDisable();
    }

	void btnNext_Click(object sender, EventArgs e)
	{
        bool isReadOnly = objGeneral.IsApplicationReadOnly(hdnFJCID.Value, Master.CamperUserId);
		if (!isReadOnly)
		{
			ProcessCamperAnswers();
		}

		//Modified by id taken from the Master Id
		string strModifiedBy = Master.UserId;
		string strFJCID = hdnFJCID.Value;
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
                EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.Chicago);
				objEligibility.checkEligibilityforStep2(strFJCID, out iStatus);
			}

			Session["STATUS"] = iStatus.ToString();
		}
		Session["FJCID"] = hdnFJCID.Value;

        // Chicago coupon for JewishCampers - Other option, then we route to Chicago Coupon page
        if (ddlJewishDaySchool.SelectedValue == "3")
        {
            Response.Redirect("Step2_coupon.aspx");
        }
        else
		    Response.Redirect("Step2_3.aspx");
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

        if (Page.IsValid)
        {
            strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"].ToString();
            ProcessCamperAnswers();
            Response.Redirect(strRedirURL);
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
            txtOtherJCC.Width = Unit.Pixel(160);
            txtOtherJCC.Enabled = true;
		}
		else
		{
			tdDDLJCC.Visible = false;
			lblJCC.Visible = false;
            txtOtherJCC.Width = Unit.Pixel(240); ;
            txtOtherJCC.Enabled = true;
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
        DataSet dsAnswers = CamperAppl.getCamperAnswers(hdnFJCID.Value, "", "", "3,6,7,8,13,17,30,31,1032,1033,1034");

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
            else if (qID == 6) // Grade
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                {
                    ddlGrade.SelectedValue = dr["Answer"].ToString();
                }
            }
            else if (qID == 7) //What kind of the school the camper go to
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
            else if (qID == 17) // Select the Jewish day school
            {
                if (!dr["OptionID"].Equals(DBNull.Value))
                {
                    ddlJewishDaySchool.SelectedValue = dr["OptionID"].ToString();
                    if (ddlJewishDaySchool.SelectedValue == "3" && !dr["Answer"].Equals(DBNull.Value))
                        txtJewishSchool.Text = dr["Answer"].ToString();
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
                        Pnl9a.Enabled = true;
                        break;

                    case SynagogueJCCOther.JCC:
                        chkJCC.Checked = true;
                        Pnl10a.Enabled = true;
                        break;

                    case SynagogueJCCOther.Other:
                        chkNo.Checked = true;
                        Pnl9a.Enabled = Pnl10a.Enabled = false;
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
            else if (qID == 1032) // Did the camper’s sibling  previously receive an incentive grant through the Chicago One Happy Camper Program?
            {
                if (!dr["OptionID"].Equals(DBNull.Value))
                    rdolistSiblingAttended.SelectedValue = dr["OptionID"].ToString();
            }
            else if (qID == 1033) // First Name of Sibling
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                    txtSiblingFirstName.Text = dr["Answer"].ToString();
            }
            else if (qID == 1034) // Last Name of Sibling
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                    txtSiblingLastName.Text = dr["Answer"].ToString();
            }
        }

        //to set the status of the panel based on the radio button selected
        setPanelStatus();
    }

    protected void RadioBtn_CheckedChanged(object sender, EventArgs e)
    {
        setPanelStatus();
    }

    //to set the panels and controls to be disabled based on the radio button selected
    void setPanelStatus()
    {
        //for Question 9
        if (rdoSchoolType.SelectedIndex == 3) //Jewish school is selected
        {
			PnlQ10.Enabled = true;
			pnlJewishSchool.Enabled = true;
			pnlCamperSchool.Enabled = false;
            txtSchoolName.Text = "";
		}
        else if (rdoSchoolType.SelectedIndex != -1)  //for the rest of the options disable it
        {
            PnlQ10.Enabled = false;
            pnlJewishSchool.Enabled = false;
            if (rdoSchoolType.SelectedIndex == 2)
            {
                pnlCamperSchool.Enabled = false;
                txtSchoolName.Text = "";
            }
            else
            {
                pnlCamperSchool.Enabled = true;
            }

            ddlJewishDaySchool.SelectedIndex = 0;
            txtJewishSchool.Text = "";
            btnNext.Visible = true;
        }

        if (ddlJewishDaySchool.SelectedValue == "3")
        {
            pnlJewishSchool.Enabled = true;
        }
        else
        {
            pnlJewishSchool.Enabled = false;
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
            ddlJCC.Enabled = lblJCC.Enabled = txtOtherJCC.Enabled = false;
		else
            ddlJCC.Enabled = lblJCC.Enabled = txtOtherJCC.Enabled = true;
		
		if (ddlJCC.Visible == false) 
			tdJCCOther.Attributes.Remove("align");
	}

    private string ConstructCamperAnswers()
    {
        string strQID = "";
        string strTablevalues = "";
        string strQ4Value = string.Empty;
        string strGrade, strSchool, strJewishSchool;
        
        //to get the Question separator from Web.config
        string strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
        //to get the Field separator from Web.config
        string strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();

        //for question FirstTimerOrNot
        strQID = ((int)Questions.Q0003IsFirtTimer).ToString();
        strTablevalues += strQID + strFSeparator + (rdoFirstTimerYes.Checked ? "1" : rdoFirstTimerNo.Checked ? "2" : "") + strFSeparator + strQSeparator;

		//Did sibling attend before?
		strQID = hdnQ1032Id.Value;
        strTablevalues += strQID + strFSeparator + rdolistSiblingAttended.SelectedValue + strFSeparator + strQSeparator;

		//Sibling First Name
		strQID = hdnQFirstNameOfSibling.Value;
		strTablevalues += strQID + strFSeparator + strFSeparator + txtSiblingFirstName.Text + strQSeparator;

		//Sibling Last Name
		strQID = hdnQLastNameOfSibling.Value;
		strTablevalues += strQID + strFSeparator + strFSeparator + txtSiblingLastName.Text + strQSeparator;

        //Grade
        strQID = hdnQ6Id.Value;
        strGrade = ddlGrade.SelectedValue;
        strTablevalues += strQID + strFSeparator + strFSeparator + strGrade + strQSeparator;

        //School Type
        strQID = hdnQ7Id.Value;
        strTablevalues += strQID + strFSeparator + rdoSchoolType.SelectedValue + strFSeparator + strQSeparator;

        // Jewish Day School
        strQID = hdnQ8Id.Value;
        strJewishSchool = txtJewishSchool.Text.Trim();
        if (ddlJewishDaySchool.SelectedValue != "3")
            strJewishSchool = ddlJewishDaySchool.SelectedItem.Text;
        strTablevalues += strQID + strFSeparator + ddlJewishDaySchool.SelectedValue + strFSeparator + strJewishSchool + strQSeparator;

        // Regular school name
        strQID = hdnQ9Id.Value;
        strSchool = txtSchoolName.Text.Trim();
        strTablevalues += strQID + strFSeparator + strFSeparator + strSchool + strQSeparator;

		// 2012-09-25 Synagogue/JCC question
        if (chkNo.Checked)
		{
			// Non of Above is selected, so no JCC nor Synagogue
			strQID = hdnQ30WereYouReferredBySynOrJccId.Value;
            strTablevalues += strQID + strFSeparator + chkNo.Value + strFSeparator + chkNo.Value + strQSeparator;

			strQID = hdnQ31SelectSynaJccId.Value;
			strTablevalues += strQID + strFSeparator + "" + strFSeparator + "" + strQSeparator;
		}
		else
		{
			// at least Synagogue or JCC is selected
			if (chkSynagogue.Checked)
			{
				strQID = hdnQ30WereYouReferredBySynOrJccId.Value;
				strTablevalues += strQID + strFSeparator + chkSynagogue.Value + strFSeparator + chkSynagogue.Value + strQSeparator;
			}


			if (chkJCC.Checked)
			{
				strQID = hdnQ30WereYouReferredBySynOrJccId.Value;
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

    //to validate the comments field for Admin
    void CusValComments_ServerValidate(object source, ServerValidateEventArgs args)
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

    protected void ddlJewishDaySchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJewishDaySchool.SelectedValue == "3") // Other
        {
            pnlJewishSchool.Enabled = true;
        }
        else
        {
			btnNext.Visible = true;
            if (rdoSchoolType.SelectedIndex == 4)
            {
                pnlCamperSchool.Enabled = true;
            }
            else
            {
                //pnlCamperSchool.Enabled = false;
                //txtCamperSchool.Text = "";
            }

            pnlJewishSchool.Enabled = false;
            txtJewishSchool.Text = "";
        }
    }
}
