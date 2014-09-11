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


public partial class Step2_MetroWest_2 : System.Web.UI.Page
{
    private CamperApplication CamperAppl;
    private General objGeneral;
    private Boolean bPerformUpdate;

    protected void Page_Init(object sender, EventArgs e)
    {
        btnNext.Click += new EventHandler(btnNext_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click+=new EventHandler(btnReturnAdmin_Click);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);    
    }

    void RadioBtn_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            setPanelStatus(false);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
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
                //Session["FJCID"] = null;
                //Session["ZIPCODE"] = null;
                Response.Redirect(strRedirURL);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
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
            getSynagogueList(Master.CampYear);
            getJCCList(Master.CampYear);
            //to get the FJCID which is stored in session
            if (Session["FJCID"] != null)
            {
                hdnFJCIDStep2_2.Value = (string)Session["FJCID"];
                PopulateAnswers();
            }
        }
        if (ddlJCC.Visible == false) tdJCCOther.Attributes.Remove("align");
    }

    private void PopulateWhoIsInSynagogue()
    {
        ddlWho.DataSource = SynagogueManager.GetWhoIsInSynagogue(FederationEnum.MetroWest);
        ddlWho.DataBind();
        ddlWho.Items.Insert(0, new ListItem("-- Select --", "0"));
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
                //strRedirURL = ConfigurationManager.AppSettings["SaveExitRedirURL"].ToString();
                strRedirURL = Master.SaveandExitURL;
                if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_2.Value, Master.CamperUserId))
                {
                    ProcessCamperAnswers();
                }
               // Session.Abandon();
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
        EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.MetroWest);
        
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

    //to set the panels and controls to be disabled based on the radio button selected
    void setPanelStatus(bool reset)
    {
        //for Question 3 & 4
        //if (RadioBtnQ3.SelectedIndex.Equals(0)) //Yes is selected
        //{
            Pnl9a.Enabled = Pnl10a.Enabled = pnl11Q.Enabled = true;
            
            if (reset)//As the same function used (to differentiate whether it is called by radio button change event or getcamperanswer function
            {
                ddlJCC.SelectedIndex = -1;
                txtOtherSynagogue.Text = string.Empty;
                txtOtherJCC.Text = string.Empty;
                ddlSynagogue.SelectedIndex = -1;
                chkSynagogue.Checked = chkJCC.Checked = chkNo.Checked = false;
                chkSynagogue.Disabled = chkJCC.Disabled = chkNo.Disabled = false;
            }
            else
            {
                if (chkNo.Checked)
                {
                    chkSynagogue.Checked = chkJCC.Checked = !chkNo.Checked;
                    chkSynagogue.Disabled = chkJCC.Disabled = chkNo.Checked;
                }
                else
                {
                    chkSynagogue.Disabled = chkJCC.Disabled = false;
                }
            }
            ddlSynagogue.Enabled = chkSynagogue.Checked;
            ddlJCC.Enabled = chkJCC.Checked;

        //}
        //else
        //{
        //    Pnl9a.Enabled = Pnl10a.Enabled = pnl11Q.Enabled = false;
        //    ddlSynagogue.SelectedIndex = -1;
        //    ddlJCC.SelectedIndex = -1;
        //    txtOtherSynagogue.Text = string.Empty;
        //    txtOtherJCC.Text = string.Empty;
        //    chkSynagogue.Checked = chkJCC.Checked = chkNo.Checked = false;
        //    chkSynagogue.Disabled = chkJCC.Disabled = chkNo.Disabled = true;
        //}
        
        if (ddlSynagogue.SelectedItem.Text.ToLower().IndexOf("other (please specify)") != -1)
        {
            lblOtherSynogogueQues.Enabled = true;
            txtOtherSynagogue.Enabled = true;
        }
        else
        {
            txtOtherSynagogue.Enabled = false;
            txtOtherSynagogue.Text = string.Empty;
        }
        //if (ddlJCC.Items.Count > 0)
        //{
        //    if (ddlJCC.SelectedItem.Text.ToLower().IndexOf("other") != -1)
        //    {
        //        lblJCC.Enabled = true;
        //        txtOtherJCC.Enabled = true;
        //    }
        //    else
        //    {
        //        txtOtherJCC.Enabled = false;
        //        txtOtherJCC.Text = string.Empty;
        //    }
        //}
        if (chkJCC.Checked == false)
        {
            txtOtherJCC.Enabled = false;
            txtOtherJCC.Text = string.Empty;
        }
        else
        {
            if (ddlJCC.SelectedItem != null)
            {
                if (ddlJCC.SelectedItem.Text.ToLower().IndexOf("other (please specify)") != -1)
                {
                    lblJCC.Enabled = true;
                    txtOtherJCC.Enabled = true;
                }
            }
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
        dtGrade = objGeneral.getGrades(Session["FedId"].ToString(), Master.CampYear);
        ddlGrade.DataSource = dtGrade;
        ddlGrade.DataTextField = "EligibleGrade";
        ddlGrade.DataValueField = "EligibleGrade";
        ddlGrade.DataBind();
        ddlGrade.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    void PopulateAnswers()
    {
        DataSet dsAnswers = CamperAppl.getCamperAnswers(hdnFJCIDStep2_2.Value, "", "", "3,6,7,8,30,31,1044,1045,1063");

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
            else if (qID == QuestionId.GrandfatherPolicySessionLength) // If a professional or fellow congregant is selected, offer this list as a check all that apply
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                if (dr["OptionID"].ToString() == "1")
                    rdoDays12.Checked = true;
                else
                    rdoDays19.Checked = true;
            }
            else if (qID == QuestionId.Q30_ReferredBySynagogueOrJCC) //Were you referred to this application through a synagogue or JCC liaison?
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                var value = (SynagogueJCCOther)Convert.ToInt32(dr["OptionID"]);
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
            else if (qID == QuestionId.WhoYouSpeakToInSynagogue) // Who, if anyone, from your synagogue, did you speak to about Jewish overnight camp?
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
            else if (qID == QuestionId.ProfessionalOrCongregate) // If a professional or fellow congregant is selected, offer this list as a check all that apply
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

    private string ConstructCamperAnswers()
    {
        var strQId = "";
        string strQuestionId = "";
        string strTablevalues = "";

        //to get the Question separator from Web.config
        var strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"];
        //to get the Field separator from Web.config
        var strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"];
        
        //for question FirstTimerOrNot
        strQId = ((int)QuestionId.FirstTime).ToString();
        strTablevalues += strQId + strFSeparator + Convert.ToString(rdoFirstTimerYes.Checked ? "1" : rdoFirstTimerNo.Checked ? "2" : "") + strFSeparator + strQSeparator;

        //Grandfaother question
        strQId = ((int)QuestionId.GrandfatherPolicySessionLength).ToString();
        strTablevalues += strQId + strFSeparator + (rdoDays12.Checked ? "1" : rdoDays19.Checked ? "2" : "") + strFSeparator + strQSeparator;

        if (chkNo.Checked)
        {
            strQuestionId = hdnQ4Id.Value;
            strTablevalues += strQuestionId + strFSeparator + chkNo.Value + strFSeparator + chkNo.Value + strQSeparator;
            strQuestionId = hdnQ5Id.Value;
            strTablevalues += strQuestionId + strFSeparator + "" + strFSeparator + "" + strQSeparator;
        }
        else
        {
            if (chkSynagogue.Checked)
            {
                strQuestionId = hdnQ4Id.Value;
                strTablevalues += strQuestionId + strFSeparator + chkSynagogue.Value + strFSeparator + chkSynagogue.Value + strQSeparator;
            }
            if (chkJCC.Checked)
            {
                strQuestionId = hdnQ4Id.Value;
                strTablevalues += strQuestionId + strFSeparator + chkJCC.Value + strFSeparator + chkJCC.Value + strQSeparator;
            }

            //This redundant condition is used to insert records in questionid sequence
            strQuestionId = hdnQ5Id.Value;
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
                        if (txtOtherJCC.Text.Trim() != String.Empty)
                            strTablevalues += strQuestionId + strFSeparator + "4" + strFSeparator + txtOtherJCC.Text.Trim() + strQSeparator;
                    }
                }
                else
                    strTablevalues += strQuestionId + strFSeparator + "4" + strFSeparator + txtOtherJCC.Text.Trim() + strQSeparator;
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
    private void getSynagogueList(string CampYear)
    {
        DataSet dsSynagogue;
        DataView dvSynagogue = new DataView();
        int FedID;
        FedID = Convert.ToInt32(Session["FedId"].ToString());
        dsSynagogue = objGeneral.GetSynagogueListByFederation(FedID, CampYear);        
        //dvSynagogue = dsSynagogue.Tables[0].DefaultView;
        //dvSynagogue.Sort = "Name ASC";
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
            ddlJCC.DataSource = dsJCC.Tables[0];
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
            txtOtherJCC.Width = Unit.Pixel(240);;
            txtOtherJCC.Enabled = true;
            tdJCCOther.Attributes.Remove("align");
        }
    }
}
