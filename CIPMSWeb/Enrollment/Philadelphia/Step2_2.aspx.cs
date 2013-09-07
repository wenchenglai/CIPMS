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
        RadioBtnQ3.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        RadioBtnQ4.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        RadioBtnQ5.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        RadioBtnQ9.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
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
                getCamperAnswers();
            }                
        }
        if (ddlJCC.Visible == false) tdJCCOther.Attributes.Remove("align");
    }

    private void PopulateWhoIsInSynagogue()
    {
        ddlWho.DataSource = SynagogueManager.GetWhoIsInSynagogue(FederationEnum.Cleveland);
        ddlWho.DataBind();
        ddlWho.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    //page unload
    void Page_Unload(object sender, EventArgs e)
    {
        CamperAppl = null;
        objGeneral = null;
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

    void RadioBtn_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            setPanelStatus(true);
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

    void btnNext_Click(object sender, EventArgs e)
    {
        int iStatus;
        string strModifiedBy, strFJCID;
        EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.Philadelphia);
        
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
        //DataRow dr;
        DataRow[] drows;
        HiddenField hdnval;
        DropDownList ddl;
        TextBox tb;
        strFJCID = hdnFJCID.Value;
        strModifiedBy = Master.UserId;
        if (!strFJCID.Equals(string.Empty))
        {
            dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "3", "32", "N");
            if (dsAnswers.Tables[0].Rows.Count > 0) //if there are records for the current FJCID
            {
                dv = dsAnswers.Tables[0].DefaultView;
                //to display answers for the Questions 3 -11
                for (int i = 3; i <= 11; i++)
                {
                    //to get the QuestionId for the Questions
                    hdnval = (HiddenField)this.Master.FindControl("Content").FindControl("hdnQ" + i.ToString() + "Id");
                    strFilter = "QuestionId = '" + hdnval.Value + "'";
                    tb = null;
                    ddl = null;
                    rb = null;

                    switch (i)
                    {
                        case 3:  //assigning the answer for question 3
                            rb = (RadioButtonList)this.Master.FindControl("Content").FindControl("RadioBtnQ" + i.ToString());
                            goto default;
                        case 4:// assigning the answer for question 4
                            rb = (RadioButtonList)this.Master.FindControl("Content").FindControl("RadioBtnQ" + i.ToString());
                            goto default;
                        case 5:// assigning the answer for question 5
                            rb = (RadioButtonList)this.Master.FindControl("Content").FindControl("RadioBtnQ" + i.ToString());
                            goto default;
                        case 6: // assigning the answer for question 6
                            ddl = ddlGrade;
                            goto default;
                        //case 7:// assigning the answer for question 7
                        //    rb = (RadioButtonList)Panel2.FindControl("RadioBtnQ" + i.ToString());
                        //    goto default;
                        //case 8: // assigning the answer for question 8
                        //    ddl = ddlSynagogue;
                        //    tb = txtOtherSynagogue;
                        //    goto default;
                        case 9: // assigning the answer for question 11
                            //tb = txtSynagogueReferral;
                            goto default;
                        case 10: // assigning the answer for question 9
                            rb = (RadioButtonList)this.Master.FindControl("Content").FindControl("RadioBtnQ9");
                            goto default;
                        case 11: // assigning the answer for question 11
                            tb = txtCamperSchool;
                            goto default;
                        default:  //to implement the common logic
                            drows = dv.Table.Select(strFilter);
                            if (drows.Length > 0) //if there are rows for the filter
                            {
                                foreach (DataRow dr in drows)
                                //dr = (DataRow)drows.GetValue(0);
                                {
                                    //for dropdownlist
                                    if (ddl != null)
                                    {
                                        if (ddl == ddlGrade)  //for the grade question the value is stored in "Answer"
                                        {
                                            if (!dr["Answer"].Equals(DBNull.Value))
                                                ddl.SelectedValue = dr["Answer"].ToString();
                                        }
                                        else if (ddl == ddlSynagogue)
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
                                            }
                                        }
                                        else
                                            if (!dr["OptionID"].Equals(DBNull.Value))
                                                ddl.SelectedValue = dr["OptionID"].ToString();

                                    }
                                    //for text box
                                    if (tb != null)
                                    {
                                        if (dr["OptionID"].ToString() == "2")
                                        {
                                            if (!dr["Answer"].Equals(DBNull.Value))
                                            {
                                                txtOtherSynagogue.Text = dr["Answer"].ToString();
                                            }
                                        }
                                        else
                                        {
                                            if (!dr["Answer"].Equals(DBNull.Value) && tb.ClientID != "txtOtherSynagogue")
                                            {
                                                tb.Text = dr["Answer"].ToString();
                                            }
                                        }
                                    }
                                    //for radio buttonlist
                                    if (rb != null)
                                    {
                                        if (!dr["OptionID"].Equals(DBNull.Value))
                                            rb.SelectedValue = dr["OptionID"].ToString();
                                    }
                                }
                            }
                            if (RadioBtnQ3.SelectedIndex == 0 || RadioBtnQ4.SelectedIndex == 0)
                                getSynagogueAnswers();
                            break;
                           
                    }
                }
            }
            //to set the status of the panel based on the radio button selected
            setPanelStatus(false);
        } //end if for null check of fjcid

    }

    //protected void RadioBtn_CheckedChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        setPanelStatus();
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);
    //    }
    //}


    //to set the panels and controls to be disabled based on the radio button selected
    //void setPanelStatus()
    //{
    //    //for Question 3 & 4
    //    if (RadioBtnQ3.SelectedIndex.Equals(0))   //yes is selected
    //    {
    //        PnlQ4.Enabled = false;
    //        RadioBtnQ4.SelectedIndex = -1;
    //        PnlQ5.Enabled = false;
    //        RadioBtnQ5.SelectedIndex = -1;
    //    }
    //    else if (RadioBtnQ3.SelectedIndex.Equals(1)) //No is selected
    //    {
    //        if (RadioBtnQ4.SelectedIndex.Equals(0))  //Yes is selected
    //        {
    //            PnlQ5.Enabled = true;
    //            //PnlQ7.Enabled = true;
    //        }
    //        else if (RadioBtnQ4.SelectedIndex.Equals(1)) //No is selected
    //        {
    //            PnlQ5.Enabled = false;
    //            RadioBtnQ5.SelectedIndex = -1;
    //        }
    //        else //nothing is selected for Q4
    //        {
    //            PnlQ4.Enabled = true;
    //        }
    //    }
    //    //synagogue panel 
    //    if (RadioBtnQ4.SelectedIndex.Equals(1))
    //    {
    //        PnlQ7.Enabled = false;
    //        //Pnl8a.Enabled = false;
    //        Label3.Enabled = false;
    //        Label12.Enabled = false;
    //        //txtOtherSynagogue.Enabled = false;
    //        //ddlSynagogue.SelectedIndex = 0;
    //        //txtOtherSynagogue.Text = "";
    //        RadioBtnQ7.SelectedIndex = -1;
    //    }
    //    else
    //    {
    //        PnlQ7.Enabled = true;
    //        Label3.Enabled = true;
    //        Label12.Enabled = true;
    //        //txtOtherSynagogue.Enabled = true;
    //    }

    //    if (RadioBtnQ9.SelectedIndex == 2)
    //    {
    //        PnlCamperSchool.Enabled = false;
    //        Label15.Enabled = false;
    //        txtCamperSchool.Text = "";
    //    }
    //    else
    //    {
    //        PnlCamperSchool.Enabled = true;
    //        Label15.Enabled = true;
    //    }

    //    if (RadioBtnQ5.SelectedIndex.Equals(1) || RadioBtnQ5.SelectedIndex.Equals(-1))
    //    {
    //        if (RadioBtnQ3.SelectedIndex.Equals(0) || RadioBtnQ3.SelectedIndex.Equals(-1))
    //        {
    //            PnlQ7.Enabled = true;
    //            //Pnl8a.Enabled = true;
    //            Label3.Enabled = true;
    //            Label12.Enabled = true;
    //            //txtOtherSynagogue.Enabled = true;
    //        }
    //        else
    //        {
    //            PnlQ7.Enabled = false;
    //            //Pnl8a.Enabled = false;
    //            Label3.Enabled = false;
    //            Label12.Enabled = false;
    //            //ddlSynagogue.SelectedIndex = 0;
    //            //txtOtherSynagogue.Text = "";
    //            RadioBtnQ7.SelectedIndex = -1;
    //            //txtOtherSynagogue.Enabled = false;
    //        }
    //    }
    //    else
    //    {
    //        PnlQ7.Enabled = true;
    //        //Pnl8a.Enabled = true;            
    //        Label3.Enabled = true;
    //        Label12.Enabled = true;
    //        //ddlSynagogue.Enabled = false;            
    //        //txtOtherSynagogue.Enabled = true;
    //    }
    //    if (RadioBtnQ7.SelectedIndex == 1 || RadioBtnQ7.SelectedIndex == -1)//No - For Synagogue
    //    {
    //        Pnl8a.Enabled = false;
    //        ddlSynagogue.SelectedIndex = 0;
    //        txtOtherSynagogue.Text = string.Empty;
    //        txtOtherSynagogue.Enabled = false;
    //    }
    //    else
    //    {
    //        Pnl8a.Enabled = true;
    //        //txtOtherSynagogue.Enabled = true;
    //    }
    //}

    void setPanelStatus(bool reset)
    {
        //for Question 3 & 4
        if (RadioBtnQ3.SelectedIndex.Equals(0))   //yes is selected
        {
            PnlQ4.Enabled = false;
            RadioBtnQ4.SelectedIndex = -1;
            PnlQ5.Enabled = false;
            RadioBtnQ5.SelectedIndex = -1;
            SetSynagogueJCCControls(true);
        }
        else if (RadioBtnQ3.SelectedIndex.Equals(1)) //No is selected
        {
            if (RadioBtnQ4.SelectedIndex.Equals(0))  //Yes is selected
            {
                PnlQ5.Enabled = true;
                SetSynagogueJCCControls(true);
            }
            else if (RadioBtnQ4.SelectedIndex.Equals(1)) //No is selected
            {
                PnlQ5.Enabled = false;
                RadioBtnQ5.SelectedIndex = -1;
                SetSynagogueJCCControls(true);
            }
            else //nothing is selected for Q4
            {
                PnlQ4.Enabled = true;
            }
        }
        if (RadioBtnQ5.SelectedIndex.Equals(1))
        {
            SetSynagogueJCCControls(true);
        }
        else if (RadioBtnQ5.SelectedIndex.Equals(0))
        {
            SetSynagogueJCCControls(true);
        }      

        if (RadioBtnQ9.SelectedIndex == 2)
        {
            PnlCamperSchool.Enabled = false;
            txtCamperSchool.Text = "";
        }
        else
        {
            PnlCamperSchool.Enabled = true;
        }

        ddlSynagogue.Enabled = chkSynagogue.Checked;
        txtOtherJCC.Enabled = false;
        ddlJCC.Enabled = false;
        if (chkJCC.Checked)
        {
            ddlJCC.Enabled = true;
            if (ddlJCC.Items.Count <= 0) txtOtherJCC.Enabled = true;
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
        else
        {
            txtOtherJCC.Text = string.Empty;
            txtOtherJCC.Enabled = false;
        }
        if (chkNo.Checked)
        {
            Pnl9a.Enabled = Pnl10a.Enabled = !chkNo.Checked;
            chkSynagogue.Checked = chkJCC.Checked = !chkNo.Checked;
            chkSynagogue.Disabled = chkJCC.Disabled = chkNo.Checked;
        }

        //for Question 9_a
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
        if (ddlJCC.Items.Count > 0)
        {
            if (ddlJCC.SelectedItem.Text.ToLower().IndexOf("other (please specify)") != -1)
            {
                lblJCC.Enabled = true;
                txtOtherJCC.Enabled = true;
            }
            else
            {
                txtOtherJCC.Enabled = false;
                txtOtherJCC.Text = string.Empty;
            }
        }
        else if (ddlJCC.Visible == false && chkJCC.Checked)
        {
            txtOtherJCC.Enabled = true;
        }
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

    private string ConstructCamperAnswers()
    {
        string strQuestionId = "";
        string strTablevalues = "";
        string strFSeparator;
        string strQSeparator;
        string strQ4Value = string.Empty;
        string strGrade, strSchool;

        //to get the Question separator from Web.config
        strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
        //to get the Field separator from Web.config
        strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();

        //for question 3
        strQuestionId = hdnQ3Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ3.SelectedValue + strFSeparator + strQSeparator;

        //for question 4
        strQuestionId = hdnQ4Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ4.SelectedValue + strFSeparator + strQSeparator;

        //for question 5
        strQuestionId = hdnQ5Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ5.SelectedValue + strFSeparator + strQSeparator;

        //for grade question 
        strQuestionId = hdnQ6Id.Value;
        strGrade = ddlGrade.SelectedValue;
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strGrade + strQSeparator;

        //for question 7
        if (chkNo.Checked)
        {
            strQuestionId = hdnQ7Id.Value;
            strTablevalues += strQuestionId + strFSeparator + chkNo.Value + strFSeparator + chkNo.Value + strQSeparator;
            strQuestionId = hdnQ8Id.Value;
            strTablevalues += strQuestionId + strFSeparator + "" + strFSeparator + "" + strQSeparator;
        }
        else
        {
            if (chkSynagogue.Checked)
            {
                strQuestionId = hdnQ7Id.Value;
                strTablevalues += strQuestionId + strFSeparator + chkSynagogue.Value + strFSeparator + chkSynagogue.Value + strQSeparator;
            }
            if (chkJCC.Checked)
            {
                strQuestionId = hdnQ7Id.Value;
                strTablevalues += strQuestionId + strFSeparator + chkJCC.Value + strFSeparator + chkJCC.Value + strQSeparator;
            }

            //This redundant condition is used to insert records in questionid sequence
            strQuestionId = hdnQ8Id.Value;
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
        
        //for question School option
        strQuestionId = hdnQ10Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ9.SelectedValue + strFSeparator + strQSeparator;

        //for question Referral code
        //strQuestionId = hdnQ9Id.Value;
        //strTablevalues += strQuestionId + strFSeparator + strFSeparator + txtSynagogueReferral.Text.Trim() + strQSeparator;

        //for question school name
        strQuestionId = hdnQ11Id.Value;
        strSchool = txtCamperSchool.Text.Trim();
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strSchool + strQSeparator;

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

    protected void RadioBtnQ5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioBtnQ5.SelectedIndex.Equals(1))
        {
            SetSynagogueJCCControls(false);
        }
        else
        {
            SetSynagogueJCCControls(true);
        }        
    }
    //to fill the grade values to the grade dropdown
    private void getSynagogues()
    {
        DataSet dsSynagogue;
        DataView dvSynagogue = new DataView();
        int FedID;
        FedID = Convert.ToInt32(Session["FEDID"].ToString());
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
        FedID = Convert.ToInt32(Session["FEDID"].ToString());
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

