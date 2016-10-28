using System;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using CIPMSBC;
using CIPMSBC.ApplicationQuestions;
using CIPMSBC.Eligibility;
using System.Web;

public partial class Step2_Chi_2 : System.Web.UI.Page
{
    private CamperApplication CamperAppl;
    private General objGeneral;
    private Boolean bPerformUpdate;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (PageUtility.RedirectToNL((int)FederationEnum.Broward, Session["isGrantAvailable"] != null, Master.isAdminUser))
        {
            Response.Redirect("~/NLIntermediate.aspx");
        }

        btnNext.Click += new EventHandler(btnNext_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CamperAppl = new CamperApplication();
            objGeneral = new General();
            if (!Page.IsPostBack)
            {
                //to fill the grades in the dropdown
                getGrades();
                getSynagogues();
                getJCCList(Master.CampYear);
                //to get the FJCID which is stored in session
                if (Session["FJCID"] != null)
                {
                    hdnFJCIDStep2_2.Value = (string)Session["FJCID"];
                    PopulateAnswers();
                }
            }
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
                var objEligibility = EligibilityFactory.GetEligibility(FederationEnum.Broward);
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
                if (Master.IsCamperUser == "Yes")
                {

                    var oGen = new General();
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
        if (strFJCID != "" && strModifiedBy != "" && bPerformUpdate)
        {
            strGrade = ddlGrade.SelectedValue;
            int.TryParse(strGrade, out iResult);
            if (iResult == 0 || strGrade.Equals(string.Empty))
                iGrade = 0;
            else
                iGrade = iResult;

            iRowsAffected = CamperAppl.updateGrade(strFJCID, iGrade, strComments, Convert.ToInt32(strModifiedBy));
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

    void PopulateAnswers()
    {
        DataSet dsAnswers = CamperAppl.getCamperAnswers(hdnFJCIDStep2_2.Value, "", "", "3,6,7,8,30,31,1063");

        foreach (DataRow dr in dsAnswers.Tables[0].Rows)
        {
            var qID = (QuestionId)dr["QuestionId"];

            if (qID == QuestionId.FirstTime) // Is this your first time to attend a Non-profit Jewish overnight camp, for 3 weeks or longer:
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
            else if (qID == QuestionId.Grade) // Grade (Mention the grade of the camper after he/she attends the camp session):
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                {
                    ddlGrade.SelectedValue = dr["Answer"].ToString();
                }
            }
            else if (qID == QuestionId.SchoolType) // What kind of the school the camper go to
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                rdoSchoolType.SelectedValue = dr["OptionID"].ToString();
                if (dr["OptionID"].ToString() == "3")
                    txtSchoolName.Enabled = false;
            }
            else if (qID == QuestionId.SchoolName) // Name of the school Camper attends:
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                {
                    txtSchoolName.Text = dr["Answer"].ToString();
                }
            }
            if (qID == QuestionId.Q30_ReferredBySynagogueOrJCC) //Were you referred to this application through a synagogue or JCC liaison?
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
            else if (qID == QuestionId.Q31_SelectYourSynagogueOrJCC) // Please select your synagogue or JCC
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
            //else if (qID == QuestionId.GrandfatherPolicySessionLength) // If a professional or fellow congregant is selected, offer this list as a check all that apply
            //{
            //    if (dr["OptionID"].Equals(DBNull.Value))
            //        continue;

            //    if (dr["OptionID"].ToString() == "1")
            //        rdoDays12.Checked = true;
            //    else
            //        rdoDays19.Checked = true;
            //}


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

        //Grandfaother question
        //strQId = ((int)QuestionId.GrandfatherPolicySessionLength).ToString();
        //strTablevalues += strQId + strFSeparator + (rdoDays12.Checked ? "1" : rdoDays19.Checked ? "2" : "") + strFSeparator + strQSeparator;

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
            strQId = hdnQ25Id.Value;
            strTablevalues += strQId + strFSeparator + chkNo.Value + strFSeparator + chkNo.Value + strQSeparator;
            strQId = hdnQ26Id.Value;
            strTablevalues += strQId + strFSeparator + "" + strFSeparator + "" + strQSeparator;
        }
        else
        {
            if (chkSynagogue.Checked)
            {
                strQId = hdnQ25Id.Value;
                strTablevalues += strQId + strFSeparator + chkSynagogue.Value + strFSeparator + chkSynagogue.Value + strQSeparator;
            }

            if (chkJCC.Checked)
            {
                strQId = hdnQ25Id.Value;
                strTablevalues += strQId + strFSeparator + chkJCC.Value + strFSeparator + chkJCC.Value + strQSeparator;
            }

            //This redundant condition is used to insert records in questionid sequence
            strQId = hdnQ26Id.Value;
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
