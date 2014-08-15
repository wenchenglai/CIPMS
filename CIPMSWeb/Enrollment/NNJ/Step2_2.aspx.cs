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

public partial class Step2_NNJ_2 : System.Web.UI.Page
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
        RadioButtonQ5.SelectedIndexChanged += new EventHandler(RadioButtonQ5_SelectedIndexChanged);
    }

    void RadioButtonQ5_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SetControlStatus();            
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
                    getCamperAnswers();
                }
                if (chkSynagogue.Checked == false) ddlSynagogue.Enabled = lblOtherSynogogueQues.Enabled = txtOtherSynagogue.Enabled = false;
                if (chkJCC.Checked == false) ddlJCC.Enabled = lblJCC.Enabled = txtJCC.Enabled = false; 
            }
            if (ddlJCC.Visible == false) tdJCCOther.Attributes.Remove("align");
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
            //dvJCC.Sort = "Name ASC";
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
                //Session["FJCID"] = null;
                //Session["ZIPCODE"] = null;
                //Session.Abandon();
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
        EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.NNJ);
        
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
                        // Session["Step2EligibleCheck"] = "yes";
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
        dtGrade = objGeneral.getGrades(Session["FedId"].ToString(), Master.CampYear);
        ddlGrade.DataSource = dtGrade;
        ddlGrade.DataTextField = "EligibleGrade";
        ddlGrade.DataValueField = "EligibleGrade";
        ddlGrade.DataBind();
        ddlGrade.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    //to set the school text box status to enable / disable based on the school type selected
    private void SetControlStatus()
    {
        if (RadioButtonQ5.SelectedValue == "3")   //Home school is selected
        {
            //TV: 01/28/2009 - as per new requiredments, need to also disable asterisk and question number control
            lblAsteriskForQ6.Enabled = false;
            lblNumberForQ6.Enabled = false;

            PnlQ6.Enabled = false;
            txtCamperSchool.Text = "";
        }
        else
        {
            lblAsteriskForQ6.Enabled = true;
            lblNumberForQ6.Enabled = true;
            PnlQ6.Enabled = true;
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

    //to get the camper answers from the database
    void getCamperAnswers()
    {
        string strFJCID;
        DataSet dsAnswers;
        DataView dv;
        DataRow[] drows;
        string strFilter;
        
        strFJCID = hdnFJCIDStep2_2.Value;
        if (!strFJCID.Equals(string.Empty))
        {
            dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "3", "31", "N");
            if (dsAnswers.Tables[0].Rows.Count > 0) //if there are records for the current FJCID
            {
                dv = dsAnswers.Tables[0].DefaultView;
                //to display answers for the QuestionId 3,6,7,8, 30 and 31 for step 2_2_Columbus
                for (int i = 0; i < dsAnswers.Tables[0].Rows.Count; i++)
                {
                    string qID = dsAnswers.Tables[0].Rows[i]["QuestionId"].ToString();
                    strFilter = "QuestionId = '" + qID + "'";

                    switch (qID)
                    {
                        case "3":  //assigning the answer for question 3
                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["OptionID"].Equals(DBNull.Value))
                                {
                                    rdnBtnList1.SelectedValue = dr["OptionID"].ToString();
                                }
                            }
                            
                            break;
                        case "6": // assigning the answer for question 6

                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["Answer"].Equals(DBNull.Value))
                                {
                                    ddlGrade.SelectedValue = dr["Answer"].ToString();
                                }
                            }
                            break;

                        case "7":// assigning the answer for question 7
                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["OptionID"].Equals(DBNull.Value))
                                {
                                    RadioButtonQ5.SelectedValue = dr["OptionID"].ToString();
                                }
                            }
                            break;

                        case "8": // assigning the answer for question 8

                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["Answer"].Equals(DBNull.Value))
                                {
                                    txtCamperSchool.Text = dr["Answer"].ToString();
                                }
                            }
                            break;
                        case "30": // assigning the answer for question 30
                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["OptionID"].Equals(DBNull.Value))
                                {
                                    //rdnBtnList2.SelectedValue = dr["OptionID"].ToString();
                                    int value = Convert.ToInt32(dr["OptionID"].ToString());
                                    //if (value > 0)
                                    //    chklistQ8.Items[(value - 1)].Selected = true;
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
                        case "31": // assigning the answer for question 31                            
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
                                foreach (DataRow dr in drows)
                                {
                                    if (!dr["OptionID"].Equals(DBNull.Value))
                                    {
                                        if (dr["OptionID"].ToString().Equals("3"))
                                        {
                                            if (!dr["Answer"].Equals(DBNull.Value))
                                                ddlJCC.SelectedValue = dr["Answer"].ToString();
                                        }
                                    }
                                    if (!dr["OptionID"].Equals(DBNull.Value))
                                    {
                                        if (dr["OptionID"].ToString().Equals("4"))
                                        {
                                            if (!dr["Answer"].Equals(DBNull.Value))
                                                txtJCC.Text = dr["Answer"].ToString();

                                        }
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            //to set the school text box to enable / disable based on the school type selected
            SetControlStatus();
        } //end if for null check of fjcid
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

        //for question 2
        strQuestionId = hdnQ2Id.Value;
        strTablevalues += strQuestionId + strFSeparator + rdnBtnList1.SelectedValue + strFSeparator + strQSeparator;

        //for question 3
        strQuestionId = hdnQ3Id.Value;
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strGrade + strQSeparator;
               
        //for question 4
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
                        strTablevalues += hdnQ12Id.Value + strFSeparator + strFSeparator + txtOtherSynagogue.Text.Trim() + strQSeparator;
                    }
                    else
                    {
                        strTablevalues += hdnQ12Id.Value + strFSeparator + strFSeparator + ddlSynagogue.SelectedItem.Text + strQSeparator;
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

        
        //for question 6
        strQuestionId = hdnQ6Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioButtonQ5.SelectedValue + strFSeparator + strQSeparator;

        //for question 7
        strQuestionId = hdnQ7Id.Value;
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strSchool;

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
