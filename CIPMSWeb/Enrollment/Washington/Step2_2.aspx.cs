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



public partial class Step2_Washington_2 : System.Web.UI.Page
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
        RadioBtnQ9.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        RadioBtnQ12.SelectedIndexChanged += new EventHandler(RadioBtnQ10_SelectedIndexChanged);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
    }

   protected void RadioBtnQ10_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioBtnQ12.SelectedIndex == 1)
        {
            lblDayCamp.Enabled = false;
            txtDayCamp.Enabled = false;
            txtDayCamp.Text = "";
        }
        else
        {
            lblDayCamp.Enabled = true;
            txtDayCamp.Enabled = true;
            
        }
        enableSynagogueQues();
       
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
        if (txtJCC.Text != "")
        {
            txtJCC.Enabled = true;
        }
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
                //strRedirURL = ConfigurationManager.AppSettings["SaveExitRedirURL"].ToString();
                strRedirURL = Master.SaveandExitURL;
                if (!objGeneral.IsApplicationReadOnly(hdnFJCID.Value, Master.CamperUserId))
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
                if (!objGeneral.IsApplicationReadOnly(hdnFJCID.Value, Master.CamperUserId))
                {
                    ProcessCamperAnswers();
                }
                Session["FJCID"] = hdnFJCID.Value;
                //Response.Redirect("../Step2_1.aspx");
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
        EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.WashingtonDC);
        
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
        DataSet dsSchool = new DataSet();
        strFJCID = hdnFJCID.Value;
        strModifiedBy = Master.UserId;
        if (!strFJCID.Equals(string.Empty))
        {
            dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "3", "1017", "N");
            if (dsAnswers.Tables[0].Rows.Count > 0) //if there are records for the current FJCID
            {
                dv = dsAnswers.Tables[0].DefaultView;
                //to display answers for the Questions 3 -11
                for (int i = 3; i <= 13; i++)
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
                        case 7:// assigning the answer for question 7
                            //rb = (RadioButtonList)Panel2.FindControl("RadioBtnQ" + i.ToString());
                            // goto default;
                            foreach (DataRow dr1 in dv.Table.Select(strFilter))
                            {
                                if (!dr1["OptionID"].Equals(DBNull.Value))
                                {
                                    int value = Convert.ToInt32(dr1["OptionID"].ToString());
                                    //if (value > 0)
                                    //    chklistQ8.Items[(value - 1)].Selected = true;
                                    //chkQ9.SelectedValue = dr1["OptionID"].ToString();
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
                        case 8: // assigning the answer for question 8
                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["OptionID"].Equals(DBNull.Value))
                                {

                                    if (dr["OptionID"].ToString().Equals("1"))
                                        ddlSynagogue.SelectedValue = dr["Answer"] != DBNull.Value ? dr["Answer"].ToString() : "0";
                                    else if (dr["OptionID"].ToString().Equals("2"))
                                        txtOtherSynagogue.Text = dr["Answer"] != DBNull.Value ? dr["Answer"].ToString() : string.Empty;

                                }

                            }
                            drows = dv.Table.Select(strFilter);
                            if (drows.Length > 0) //if there are rows for the filter
                            {
                                //dr = (DataRow)drows.GetValue(0);
                                foreach (DataRow dr1 in drows)
                                {
                                    if (!dr1["OptionID"].Equals(DBNull.Value))
                                    {

                                        if (dr1["OptionID"].ToString().Equals("3"))
                                        {
                                            if (!dr1["Answer"].Equals(DBNull.Value))
                                                ddlJCC.SelectedValue = dr1["Answer"].ToString();
                                        }

                                    }
                                    if (!dr1["OptionID"].Equals(DBNull.Value))
                                    {
                                        if (dr1["OptionID"].ToString().Equals("4"))
                                        {
                                            if (!dr1["Answer"].Equals(DBNull.Value))
                                                txtJCC.Text = dr1["Answer"].ToString();

                                        }
                                    }
                                }
                            }
                            goto default;
                        case 9: // assigning the answer for question 11
                            //tb = txtSynagogueReferral;
                            goto default;
                        case 10: // assigning the answer for question 9
                            rb = (RadioButtonList)Panel2.FindControl("RadioBtnQ9");
                            goto default;
                        case 11: // assigning the answer for question 11
                            tb = txtCamperSchool;
                            goto default;
                        case 12: // assing answer for question day camp
                            rb = (RadioButtonList)Panel2.FindControl("RadioBtnQ" + i.ToString());
                            goto default;
                        case 13:// assigning answer for day camp
                            tb = txtDayCamp;
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

                                        else
                                            if (!dr["OptionID"].Equals(DBNull.Value))
                                                ddl.SelectedValue = dr["OptionID"].ToString();

                                    }
                                    //for text box                                    
                                    if (tb != null)
                                    {
                                        if (!dr["Answer"].Equals(DBNull.Value) && tb.ClientID != "txtOtherSynagogue")
                                        {
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
        if (RadioBtnQ9.SelectedIndex == 2)
        {
            PnlCamperSchool.Enabled = false;
            Label15.Enabled = false;
            txtCamperSchool.Text = "";
        }
        else
        {
            PnlCamperSchool.Enabled = true;
            Label15.Enabled = true;
        }
        if (RadioBtnQ12.SelectedIndex == 2)
        {
            lblDayCamp.Enabled = false;
            txtDayCamp.Enabled = false;
            txtDayCamp.Text = "";
        }
        else
        {
            lblDayCamp.Enabled = true;
            txtDayCamp.Enabled = true;
        }
        ddlSynagogue.Enabled = chkSynagogue.Checked;
        if (chkJCC.Checked)
        {
            ddlJCC.Enabled = true;
            if (ddlJCC.Items.Count <= 0) txtJCC.Enabled = true;
            else
            {
                if (ddlJCC.SelectedItem != null)
                {
                    if (ddlJCC.SelectedItem.Text.ToLower().IndexOf("other (please specify)") != -1)
                    {
                        lblJCC.Enabled = true;
                        txtJCC.Enabled = true;
                    }
                }
            }
        }
        else
        {
            txtJCC.Enabled = false;
            txtJCC.Text = string.Empty;
        }
        if (chkNo.Checked)
        {
            Pnl9a.Enabled = Pnl10a.Enabled = !chkNo.Checked;
            chkSynagogue.Checked = chkJCC.Checked = !chkNo.Checked;
            chkSynagogue.Disabled = chkJCC.Disabled = chkNo.Checked;
        }
        else
        {
            Pnl9a.Enabled = Pnl10a.Enabled = true;
            chkSynagogue.Disabled = chkJCC.Disabled = false;
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
                txtJCC.Enabled = true;
            }
            else
            {
                txtJCC.Enabled = false;
                txtJCC.Text = string.Empty;
            }
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

        //for grade question 
        strQuestionId = hdnQ6Id.Value;
        strGrade = ddlGrade.SelectedValue;
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strGrade + strQSeparator;

        //for question 7
        //strQuestionId = hdnQ7Id.Value;
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
                    //step3_otherinformation page synagogue update to match the both synagogue names same even after updated here
                    if (txtOtherSynagogue.Enabled == true)
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
        //strTablevalues += strQuestionId + strFSeparator + RadioBtnQ7.SelectedValue + strFSeparator + strQSeparator;
        //for (int i = 0; i < 3; i++)
        //{
        //    int k = i + 1;
        //    if (chklistQ8.Items[i].Selected == true)
        //        strTablevalues += strQuestionId + strFSeparator + k.ToString() + strFSeparator + chklistQ8.SelectedValue + strQSeparator;

        //}
        ////for Synagogue question 
        //strQuestionId = hdnQ8Id.Value;
        //if (chklistQ8.Items[1].Selected == true && ddlSynagogue.SelectedValue != "0")
        //{
        //   // strQuestionId = hdnQ9Id.Value;
        //    strTablevalues += strQuestionId + strFSeparator + "1" + strFSeparator + ddlSynagogue.SelectedValue + strQSeparator;
        //    strTablevalues += strQuestionId + strFSeparator + "2" + strFSeparator + txtOtherSynagogue.Text.Trim() + strQSeparator;
        //}
        //if (chklistQ8.Items[2].Selected == true)
        //{

        //    //strQuestionId = hdnQ9Id.Value;
        //    if (ddlJCC.Items.Count > 0)
        //    {
        //        if (ddlJCC.SelectedValue != "0")
        //        {
        //            strTablevalues += strQuestionId + strFSeparator + "3" + strFSeparator + ddlJCC.SelectedValue + strQSeparator;
        //            strTablevalues += strQuestionId + strFSeparator + "4" + strFSeparator + txtJCC.Text.Trim() + strQSeparator;
        //        }
        //    }
        //    else
        //        strTablevalues += strQuestionId + strFSeparator + "4" + strFSeparator + txtJCC.Text.Trim() + strQSeparator;

        //}
        //strSynagogue = txtSynagogue.Text.Trim();
        //strTablevalues += strQuestionId + strFSeparator + "1" + strFSeparator + ddlSynagogue.SelectedValue + strQSeparator;

        //if (RadioBtnQ7.SelectedValue == "1")
        //{
        //    //for question 5a
        //    if (ddlSynagogue.SelectedItem.Text.ToLower() != "other")
        //    {
        //        strQuestionId = hdnQ8Id.Value;
        //        //strSynagogue = txtSynagogue.Text.Trim();
        //        strTablevalues += strQuestionId + strFSeparator + ddlSynagogue.SelectedValue + strFSeparator + strQSeparator;
        //    }
        //    else
        //    {
        //        //strQuestionId = hdnQ8Id.Value;
        //        //strTablevalues += strQuestionId + strFSeparator + ddlSynagogue.SelectedValue + strFSeparator + txtOtherSynagogue.Text.Trim() + strQSeparator;
        //    }
            
        //}

        //for question DayCamp
        strQuestionId = hdnQ12Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ12.SelectedValue + strFSeparator + strQSeparator;

        //for question DayCamp
        strQuestionId = hdnQ13Id.Value;
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + txtDayCamp.Text.Trim() + strQSeparator;

        //for question School option
        strQuestionId = hdnQ10Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ9.SelectedValue + strFSeparator + strQSeparator;

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
    
    //to fill the grade values to the grade dropdown
    private void getSynagogues()
    {
        DataSet dsSynagogue;
        DataView dvSynagogue = new DataView();
        int FedID;
        FedID = Convert.ToInt32(Session["FedId"].ToString());
        dsSynagogue = objGeneral.GetSynagogueListByFederation(FedID, Master.CampYear);
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

