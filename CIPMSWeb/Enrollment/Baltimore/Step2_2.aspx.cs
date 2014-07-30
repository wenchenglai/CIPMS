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

public partial class Step2_Dallas_2 : System.Web.UI.Page
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
        RadioBtnQ2.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        RadioBtnQ3.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        RadioBtnQ6.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        RadioBtnQ10.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
       
        ddlSynagogueQ11.SelectedIndexChanged += new EventHandler(ddlSynagogue_OnSelectedIndexChanged);        
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
                getSynagogueList(Master.CampYear);
                getJCCList(Master.CampYear);
                //to get the FJCID which is stored in session
                if (Session["FJCID"] != null)
                {
                    hdnFJCID.Value = (string)Session["FJCID"]; ;
                    getCamperAnswers();
                }
            }
            if (chkSynagogue.Checked == false) ddlSynagogue.Enabled = lblOtherSynogogueQues.Enabled = txtOtherSynagogue.Enabled = false;
            if (chkJCC.Checked == false) ddlJCC.Enabled = lblJCC.Enabled = txtJCC.Enabled = false;
            if (ddlJCC.Visible == false) tdJCCOther.Attributes.Remove("align");
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

   
    void RadioBtn_SelectedIndexChanged(object sender, EventArgs e)
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

    void btnNext_Click(object sender, EventArgs e)
    {
        int iStatus;
        string strModifiedBy, strFJCID;
        EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.Baltimore);
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
            dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "3", "1020", "N");
            if (dsAnswers.Tables[0].Rows.Count > 0) //if there are records for the current FJCID
            {
                dv = dsAnswers.Tables[0].DefaultView;
                //to display answers for the Questions 3 -11
                for (int i = 2; i <= 11; i++)
                {
                    //to get the QuestionId for the Questions
                    hdnval = (HiddenField)PnlHidden.FindControl("hdnQ" + i.ToString() + "Id");
                    strFilter = "QuestionId = '" + hdnval.Value + "'";
                    tb = null;
                    ddl = null;
                    rb = null;

                    switch (i)
                    {
                        case 2:  //assigning the answer for question 2
                            rb = (RadioButtonList)Panel2.FindControl("RadioBtnQ" + i.ToString());
                            goto default;
                        case 3:// assigning the answer for question 3
                            rb = (RadioButtonList)Panel2.FindControl("RadioBtnQ" + i.ToString());
                            goto default;
                        case 4:// assigning the answer for question 4
                            rb = (RadioButtonList)Panel2.FindControl("RadioBtnQ" + i.ToString());
                            goto default;
                        case 5: // assigning the answer for question 5
                            ddl = ddlGrade;
                            goto default;
                        case 6: // assigning the answer for question 6
                            rb = (RadioButtonList)Panel2.FindControl("RadioBtnQ6");
                            goto default;
                      
                        case 7: // assigning the answer for question 7
                            tb = txtCamperSchool;
                            goto default;
                        case 8: // assigning the answer for question 8
                           
                            foreach (DataRow dr1 in dv.Table.Select(strFilter))
                            {
                                if (!dr1["OptionID"].Equals(DBNull.Value))
                                {
                                    int value = Convert.ToInt32(dr1["OptionID"].ToString());
                                   
                                    switch (value)
                                    {
                                        case 2:
                                            {
                                                chkNo.Checked = true;
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
                                        default: chkNo.Checked = false; break;
                                    }
                                }
                            }
                            break;

                        case 9: // assigning the answer for question 9
                            ddl = ddlSynagogue;
                            tb = txtOtherSynagogue;
                            drows = dv.Table.Select(strFilter);
                            if (drows.Length > 0) //if there are rows for the filter
                            {
                                foreach (DataRow dr in drows)
                                {
                                    if (!dr["OptionID"].Equals(DBNull.Value))
                                    {                                        
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
                            }
                            goto default;
                        case 10: // assigning the answer for question 10
                            rb = (RadioButtonList)Panel2.FindControl("RadioBtnQ10");
                            goto default;
                        case 11: // assigning the answer for question 11
                            ddl = ddlSynagogueQ11;
                            tb = txtOtherSynagogueQ11;
                            goto default;

                        default:  //to implement the common logic
                            drows = dv.Table.Select(strFilter);
                            if (drows.Length > 0) //if there are rows for the filter
                            {
                                
                                foreach (DataRow dr in drows)
                                {
                                    //for dropdownlist
                                    if (ddl != null)
                                    {
                                        if (ddl == ddlGrade)  //for the grade question the value is stored in "Answer"
                                        {
                                            if (!dr["Answer"].Equals(DBNull.Value))
                                                ddl.SelectedValue = dr["Answer"].ToString();
                                        }
                                        else
                                        {
                                            if (!dr["OptionID"].Equals(DBNull.Value))
                                            {
                                                if (dr["OptionID"].ToString().Equals("1"))
                                                {
                                                    if (!dr["Answer"].Equals(DBNull.Value))
                                                        ddl.SelectedValue = dr["Answer"].ToString();
                                                }
                                                if (dr["OptionID"].ToString().Equals("3"))
                                                {
                                                    if (!dr["Answer"].Equals(DBNull.Value))
                                                        ddl.SelectedValue = dr["Answer"].ToString();
                                                }
                                            }
                                        }

                                    }
                                    //for text box
                                    if (tb != null)
                                    {
                                        if (tb == txtOtherSynagogue || tb == txtOtherSynagogueQ11)
                                        {
                                            if (!dr["OptionID"].Equals(DBNull.Value))
                                            {
                                                if (dr["OptionID"].ToString().Equals("2"))
                                                {
                                                    if (!dr["Answer"].Equals(DBNull.Value))
                                                        tb.Text = dr["Answer"].ToString();
                                                }
                                            }
                                        }
                                        
                                        else
                                        {
                                            if (!dr["Answer"].Equals(DBNull.Value))
                                                tb.Text = dr["Answer"].ToString();
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
                            break;
                    }
                }
            }
            //to set the status of the panel based on the radio button selected
            setPanelStatus();
        } //end if for null check of fjcid

    }
    //to set the panels and controls to be disabled based on the radio button selected
    void setPanelStatus()
    {
        if (RadioBtnQ2.SelectedValue == "1" || RadioBtnQ2.SelectedIndex == -1)   //yes is selected
        {
            PnlQ3.Enabled = false;
            RadioBtnQ3.SelectedIndex = -1;
            PnlQ4.Enabled = false;
        }
        else
        {
            PnlQ3.Enabled = PnlQ4.Enabled = true;
        }
        if (RadioBtnQ3.SelectedValue == "1") //No is selected
        {
            PnlQ4.Enabled = true;
        }
        else
        {
            PnlQ4.Enabled = false;
            RadioBtnQ4.SelectedIndex = -1;
        }
            
        
        //for Question 6
        if (RadioBtnQ6.SelectedIndex == 2) //Home school is selected
        {
            pnlCamperSchool.Enabled = false;
            txtCamperSchool.Text = "";
            Label15.Enabled = false;
        }
        else if (RadioBtnQ6.SelectedIndex != -1)  //for the rest of the options disable it
        {
            pnlCamperSchool.Enabled = true;
            Label15.Enabled = true;     
        }

        chkJCC.Disabled = chkSynagogue.Disabled = chkNo.Disabled = false;
        if (chkSynagogue.Checked)
            if (ddlSynagogue.Items.Count > 0) { chkSynagogue.Disabled = false; ddlSynagogue.Enabled = Pnl9a.Enabled = true; }

        if (chkJCC.Checked)
        {
            Pnl10a.Enabled = true;
            chkJCC.Disabled = false;
            if (ddlJCC.Items.Count > 0) ddlJCC.Enabled = true;
            else txtJCC.Enabled = true;
        }

        if (chkNo.Checked)
        { Pnl9a.Enabled = Pnl10a.Enabled = false; chkJCC.Disabled = chkSynagogue.Disabled = true; ddlSynagogue.SelectedIndex = ddlJCC.SelectedIndex = -1; txtOtherSynagogue.Text = txtJCC.Text = string.Empty; }

        //for Question 9_a
        if (ddlSynagogue.SelectedItem.Text.ToLower().IndexOf("other (please specify)")!= -1)
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
                txtJCC.Enabled = true;
            }
            else
            {
                txtJCC.Enabled = false;
                txtJCC.Text = string.Empty;
            }
        }


        //for Question 10   religious school association
        if (RadioBtnQ10.SelectedValue == "2" || RadioBtnQ10.SelectedIndex == -1)
        {
            Pnl11a.Enabled = Pnl11b.Enabled = false;
            ddlSynagogueQ11.SelectedIndex = -1;
            txtOtherSynagogueQ11.Text = string.Empty;
        }
        else
        {
            Pnl11a.Enabled = true;
        }

        //for Question 11_a
        if (ddlSynagogueQ11.SelectedItem.Text.ToLower().IndexOf("other") != -1)
        {
            Pnl11b.Enabled = true;
            lblOtherSynogogueQuesQ11.Enabled = true;
            txtOtherSynagogueQ11.Enabled = true;
        }
        else
        {
            Pnl11b.Enabled = false;
            txtOtherSynagogueQ11.Enabled = false;
            txtOtherSynagogueQ11.Text = string.Empty;
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

        //for question 2
        strQuestionId = hdnQ2Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ2.SelectedValue + strFSeparator + strQSeparator;

        //for question 3
        strQuestionId = hdnQ3Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ3.SelectedValue + strFSeparator + strQSeparator;

        //for question 4
        strQuestionId = hdnQ4Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ4.SelectedValue + strFSeparator + strQSeparator;
        
        //for question 5
        strQuestionId = hdnQ5Id.Value;
        strGrade = ddlGrade.SelectedValue;
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strGrade + strQSeparator;

        //for question 6
        strQuestionId = hdnQ6Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ6.SelectedValue + strFSeparator + strQSeparator;

        //for question 7
        strQuestionId = hdnQ7Id.Value;
        strSchool = txtCamperSchool.Text.Trim();
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strSchool + strQSeparator;

        //for question 8 commented by sandhya

        if (chkNo.Checked)
        {
            strQuestionId = hdnQ8Id.Value;
            strTablevalues += strQuestionId + strFSeparator + chkNo.Value + strFSeparator + chkNo.Value + strQSeparator;
            strQuestionId = hdnQ9Id.Value;
            strTablevalues += strQuestionId + strFSeparator + "" + strFSeparator + "" + strQSeparator;
        }
        else
        {
            if (chkSynagogue.Checked)
            {
                strQuestionId = hdnQ8Id.Value;
                strTablevalues += strQuestionId + strFSeparator + chkSynagogue.Value + strFSeparator + chkSynagogue.Value + strQSeparator;
            }
            if (chkJCC.Checked)
            {
                strQuestionId = hdnQ8Id.Value;
                strTablevalues += strQuestionId + strFSeparator + chkJCC.Value + strFSeparator + chkJCC.Value + strQSeparator;
            }

            //This redundant condition is used to insert records in questionid sequence
            if (chkSynagogue.Checked)
            {
                if (ddlSynagogue.SelectedValue != "0")
                {
                    strQuestionId = hdnQ9Id.Value;
                    strTablevalues += strQuestionId + strFSeparator + "1" + strFSeparator + ddlSynagogue.SelectedValue + strQSeparator;
                    if (txtOtherSynagogue.Text.Trim() != String.Empty)
                        strTablevalues += strQuestionId + strFSeparator + "2" + strFSeparator + txtOtherSynagogue.Text.Trim() + strQSeparator;
                    if (txtOtherSynagogue.Text.Trim() != String.Empty)
                    {
                        strTablevalues += hdnQ12Id.Value + strFSeparator + strFSeparator + txtOtherSynagogue.Text.Trim() + strQSeparator;
                    }
                    else
                    {
                        strTablevalues += hdnQ12Id.Value + strFSeparator + strFSeparator + ddlSynagogue.SelectedItem.Text + strQSeparator;
                    }
                }
            }
            if (chkJCC.Checked)
            {
                strQuestionId = hdnQ9Id.Value;
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
        }
      

        //for question 10
        strQuestionId = hdnQ10Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ10.SelectedValue + strFSeparator + strQSeparator;

        //for question 11
        if (RadioBtnQ10.SelectedValue == "1" && ddlSynagogueQ11.SelectedValue != "0")
        {
            strQuestionId = hdnQ11Id.Value;
            strTablevalues += strQuestionId + strFSeparator + "1" + strFSeparator + ddlSynagogueQ11.SelectedValue + strQSeparator;
            strTablevalues += strQuestionId + strFSeparator + "2" + strFSeparator + txtOtherSynagogueQ11.Text.Trim() + strQSeparator;
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

    private void ddlSynagogue_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        setPanelStatus();
    }    
    private void getSynagogueList(string CampYear)
    {
        DataSet dsSynagogue;
        DataView dvSynagogue = new DataView();
        int FedID;
        FedID = Convert.ToInt32(Session["FedId"].ToString());
        dsSynagogue = objGeneral.GetSynagogueListByFederation(FedID,CampYear);
       
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
        ddlSynagogueQ11.DataSource = dsSynagogue.Tables[0];
        ddlSynagogueQ11.DataTextField = "Name";
        ddlSynagogueQ11.DataValueField = "ID";
        ddlSynagogueQ11.DataBind();
        ddlSynagogueQ11.Items.Insert(0, new ListItem("-- Select --", "0"));
        otherListItem = new ListItem();
        foreach (ListItem item in ddlSynagogueQ11.Items)
        {
            item.Attributes.Add("title", item.Text);
            if (item.Text.ToLower().Contains("other (please specify)") && ddlSynagogueQ11.Items.IndexOf(item) < ddlSynagogueQ11.Items.Count)
            {
                otherListItem = item;
            }
        }
        if (otherListItem != null && otherListItem.Text != string.Empty)
        {
            ddlSynagogueQ11.Items.Remove(otherListItem);
            ddlSynagogueQ11.Items.Insert(ddlSynagogueQ11.Items.Count, otherListItem);
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
            txtJCC.Width = Unit.Pixel(240);;
            txtJCC.Enabled = true;
            tdJCCOther.Attributes.Remove("align");
        }
    }
   
}
