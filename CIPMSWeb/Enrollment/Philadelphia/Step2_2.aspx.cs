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



public partial class Step2_NY_2 : System.Web.UI.Page
{

    private CamperApplication CamperAppl;
    private General objGeneral;
    private Boolean bPerformUpdate;

    protected void Page_Init(object sender, EventArgs e)
    {
        btnNext.Click += new EventHandler(btnNext_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
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

            // to fill the Synagogues names in the dropdown.
            getSynagogues();
            getJCCList(Master.CampYear);
            //to get the FJCID which is stored in session
            if (Session["FJCID"] != null)
            {
                hdnFJCID.Value = (string)Session["FJCID"]; ;
                PopulateAnswers();
            }                
        }
        if (ddlJCC.Visible == false) tdJCCOther.Attributes.Remove("align");
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
                var objEligibility = EligibilityFactory.GetEligibility(FederationEnum.Philadelphia);
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
        Session["FJCID"] = hdnFJCID.Value;

        var status = (StatusInfo)iStatus;
        Response.Redirect(AppRouteManager.GetNextRouteBasedOnStatus(status, HttpContext.Current.Request.Url.AbsolutePath));
    }

    private void PopulateWhoIsInSynagogue()
    {
        ddlWho.DataSource = SynagogueManager.GetWhoIsInSynagogue(FederationEnum.Philadelphia);
        ddlWho.DataBind();
        ddlWho.Items.Insert(0, new ListItem("-- Select --", "0"));
    }


    void enableSynagogueQues()
    {
        if (chkNo.Checked)
        {
            ddlSynagogue.SelectedIndex = -1;
            //Pnl9a.Enabled = Pnl10a.Enabled = false;
        }
        if (chkJCC.Checked)
        {
            chkJCC.Disabled = false;
        }
        if (chkSynagogue.Checked)
        {
            chkSynagogue.Disabled = false;
        }
        if (ddlSynagogue.SelectedItem.Value != "0")
        {
            ddlSynagogue.Enabled = true;
        }
        if (ddlJCC.Items.Count > 0)
        {
            if (ddlJCC.SelectedItem.Value != "0")
            {
                ddlJCC.Enabled = true;
            }
        }
        if (txtOtherSynagogue.Text != "")
        {
            txtOtherSynagogue.Enabled = true;
        }
        if (txtOtherJCC.Text != "")
        {
            txtOtherJCC.Enabled = true;
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

    void btnSaveandExit_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        try
        {
            if (Page.IsValid)
            {
                //strRedirURL = ConfigurationManager.AppSettings["SaveExitRedirURL"].ToString();
                strRedirURL = Master.SaveandExitURL;
                if (!objGeneral.IsApplicationReadOnly(hdnFJCID.Value, Master.CamperUserId))
                {
                    ProcessCamperAnswers();
                }
              //  Session.Abandon();
               // Response.Redirect(strRedirURL);
                if (Master.IsCamperUser == "Yes")
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
        if (strFJCID != "" & strModifiedBy != "" && bPerformUpdate)
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

    private void SetSynagogueJCCControls(bool enableControls)
    {
        if (enableControls)
        {
            Pnl9a.Enabled = Pnl10a.Enabled = pnl11Q.Enabled = true;
            chkSynagogue.Disabled = chkJCC.Disabled = chkNo.Disabled = false;

        }
        else
        {
            Pnl9a.Enabled = Pnl10a.Enabled = pnl11Q.Enabled = false;
            ddlSynagogue.SelectedIndex = -1;
            txtOtherSynagogue.Text = string.Empty;
            ddlJCC.SelectedIndex = -1;
            txtOtherJCC.Text = string.Empty;
            chkSynagogue.Checked = chkJCC.Checked = chkNo.Checked = false;
            chkSynagogue.Disabled = chkJCC.Disabled = chkNo.Disabled = true;
        }
    }

    void PopulateAnswers()
    {
        DataSet dsAnswers = CamperAppl.getCamperAnswers(hdnFJCID.Value, "", "", "3,6,7,8,13,30,31,33,1044,1045");

        foreach (DataRow dr in dsAnswers.Tables[0].Rows)
        {
            var qID = (QuestionId)dr["QuestionId"];

            switch (qID)
            {
                case QuestionId.FirstTime:
                    if (dr["OptionID"].Equals(DBNull.Value))
                        continue;
                    if (dr["OptionID"].ToString() == "1")
                    {
                        rdoFirstTimerYes.Checked = true;
                    }
                    else if (dr["OptionID"].ToString() == "2")
                    {
                        rdoFirstTimerNo.Checked = true;
                    }
                    break;

                case QuestionId.Q13_SecondTime:
                    if (dr["OptionID"].Equals(DBNull.Value))
                        continue;
                    if (dr["OptionID"].ToString() == "1")
                    {
                        rdoSecondTimerYes.Checked = true;
                    }
                    else if (dr["OptionID"].ToString() == "2")
                    {
                        rdoSecondTimerNo.Checked = true;
                    }
                    break;

                case QuestionId.Q33_ReceivedGrant:
                    if (dr["OptionID"].Equals(DBNull.Value))
                        continue;
                    if (dr["OptionID"].ToString() == "1")
                    {
                        rdoReceivedGrantYes.Checked = true;
                    }
                    else if (dr["OptionID"].ToString() == "2")
                    {
                        rdoReceivedGrantNo.Checked = true;
                    }
                    break;

                case QuestionId.Grade:
                    if (!dr["Answer"].Equals(DBNull.Value))
                    {
                        ddlGrade.SelectedValue = dr["Answer"].ToString();
                    }
                    break;
                case QuestionId.SchoolType:
                    if (dr["OptionID"].Equals(DBNull.Value))
                        continue;
                    rdoSchoolType.SelectedValue = dr["OptionID"].ToString();
                    if (dr["OptionID"].ToString() == "3")
                        txtSchoolName.Enabled = false;
                    break;
                case QuestionId.SchoolName:
                    if (!dr["Answer"].Equals(DBNull.Value))
                    {
                        txtSchoolName.Text = dr["Answer"].ToString();
                    }
                    break;

			    case QuestionId.Q30_ReferredBySynagogueOrJCC: //Were you referred to this application through a synagogue or JCC liaison?
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
                    break;

			    case QuestionId.Q31_SelectYourSynagogueOrJCC:
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
                    break;

                case QuestionId.Q1044_WhoYouSpeakToInSynagogue: // Who, if anyone, from your synagogue, did you speak to about Jewish overnight camp?
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
                    break;

                case QuestionId.Q1045_ProfessionalOrCongregate:// If a professional or fellow congregant is selected, offer this list as a check all that apply
                    {
                        if (dr["OptionID"].Equals(DBNull.Value))
                            continue;

                        var optionID = dr["OptionID"].ToString();
                        ddlWho.SelectedValue = optionID;
                        if (Int32.Parse(optionID) == (int)SynagogueMemberDropdown.Other)
                        {
                            txtWhoInSynagogue.Text = dr["Answer"].ToString();
                        }
                        else
                            txtWhoInSynagogue.Enabled = false;
                    }
                    break;
            }
        }
    }

    private string ConstructCamperAnswers()
    {
        var strQId = "";
        string strTablevalues = "";

        //to get the Question separator from Web.config
        var strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"];
        //to get the Field separator from Web.config
        var strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"];

        //for question FirstTimerOrNot
        strQId = ((int)QuestionId.FirstTime).ToString();
        strTablevalues += strQId + strFSeparator + Convert.ToString(rdoFirstTimerYes.Checked ? "1" : rdoFirstTimerNo.Checked ? "2" : "") + strFSeparator + strQSeparator;

        //for question Second Timer or not
        strQId = ((int)QuestionId.Q13_SecondTime).ToString();
        strTablevalues += strQId + strFSeparator + Convert.ToString(rdoSecondTimerYes.Checked ? "1" : rdoSecondTimerNo.Checked ? "2" : "") + strFSeparator + strQSeparator;

        //for question Received Grant or not
        strQId = ((int)QuestionId.Q33_ReceivedGrant).ToString();
        strTablevalues += strQId + strFSeparator + Convert.ToString(rdoReceivedGrantYes.Checked ? "1" : rdoReceivedGrantNo.Checked ? "2" : "") + strFSeparator + strQSeparator;

        if (chkNo.Checked)
        {
            strQId = hdnQ7Id.Value;
            strTablevalues += strQId + strFSeparator + chkNo.Value + strFSeparator + chkNo.Value + strQSeparator;
            strQId = hdnQ8Id.Value;
            strTablevalues += strQId + strFSeparator + "" + strFSeparator + "" + strQSeparator;
        }
        else
        {
            if (chkSynagogue.Checked)
            {
                strQId = hdnQ7Id.Value;
                strTablevalues += strQId + strFSeparator + chkSynagogue.Value + strFSeparator + chkSynagogue.Value + strQSeparator;
            }
            if (chkJCC.Checked)
            {
                strQId = hdnQ7Id.Value;
                strTablevalues += strQId + strFSeparator + chkJCC.Value + strFSeparator + chkJCC.Value + strQSeparator;
            }

            //This redundant condition is used to insert records in questionid sequence
            strQId = hdnQ8Id.Value;
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

    private void getSynagogues()
    {
        DataSet dsSynagogue;
        DataView dvSynagogue = new DataView();
        int FedID;
        FedID = Convert.ToInt32(Session["FedId"].ToString());
        dsSynagogue = objGeneral.GetSynagogueListByFederation(FedID, Master.CampYear);
        //dvSynagogue = dsSynagogue.Tables[0].DefaultView;
        //dvSynagogue.Sort = "ID ASC";
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
            //dvJCC = dsJCC.Tables[0].DefaultView;
            //dvJCC.Sort = "ID ASC";
            ddlJCC.DataSource = dsJCC;
            ddlJCC.DataTextField = "Name";
            ddlJCC.DataValueField = "ID";
            ddlJCC.DataBind();
            ddlJCC.Items.Insert(0, new ListItem("-- Select --", "0"));

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

            ddlJCC.SelectedValue = "0";
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
    
    void getSynagogueAnswers()
    {
        DataSet dsAnswers = CamperAppl.getCamperAnswers(hdnFJCID.Value, "", "", "30,31,1044,1045");

        foreach (DataRow dr in dsAnswers.Tables[0].Rows)
        {
            int qID = Convert.ToInt32(dr["QuestionId"]);

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
        }
    }
}

