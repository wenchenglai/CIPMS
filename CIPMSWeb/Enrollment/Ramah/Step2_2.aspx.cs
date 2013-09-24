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
using System.Data.SqlClient;
using CIPMSBC.Eligibility;



public partial class Step2_Ramah_2 : System.Web.UI.Page
{

    private CamperApplication CamperAppl;
    private General objGeneral;
    private Boolean bPerformUpdate;
    private int Qincrement = 0;
    private string campID = string.Empty;
    
    protected void Page_Init(object sender, EventArgs e)
    {
        btnNext.Click += new EventHandler(btnNext_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click+=new EventHandler(btnReturnAdmin_Click);
        RadioBtnQ3.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        RadioBtnQ4.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        //RadioBtnQ7.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        RadioBtnQ9.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CamperAppl = new CamperApplication();
        objGeneral = new General();
        if (Session["CampID"] != null)
        {
            campID = Session["CampID"].ToString();
        }
        else if (Session["FJCID"] != null)
        {
            DataSet dsCamperDetails = CamperAppl.getCamperAnswers(Session["FJCID"].ToString(), "10", "10", "N");
            if (dsCamperDetails.Tables[0].Rows.Count > 0)
                foreach (DataRow dr in dsCamperDetails.Tables[0].Rows)
                {
                    if (!dr["QuestionID"].Equals(DBNull.Value) && dr["QuestionID"].ToString() == "10")
                        if (!dr["OptionID"].Equals(DBNull.Value) && dr["OptionID"].ToString() == "2")
                            if (!dr["Answer"].Equals(DBNull.Value))
                                campID = dr["Answer"].ToString();
                }
        }

		// 2012-11-20 Temporary message to show the campers.  This should be deleted after it's not used.
		if (campID == "4082")
		{
			trMsg.Visible = true;
		}
		else
		{
			trMsg.Visible = false;
		}

        if (!Page.IsPostBack)
        {
            DataSet dsCamps = objGeneral.GetCampByCampID(campID);            
            if (dsCamps.Tables[0].Rows.Count > 0)
                for (int i = 0; i < dsCamps.Tables[0].Rows.Count; i++)
                {
                    if (dsCamps.Tables[0].Rows[i]["Camp"].ToString().IndexOf("California") != -1)
                    {
                        Qincrement = 1;
                        hdnQNoIncrement.Value = Qincrement.ToString();
                    }
                }

            //2012-01-12 Add popup box warning that second time grant is no longer available
            //foreach (ListItem li in RadioBtnQ5.Items)
            //{
            //    li.Attributes.Add("OnClick", "JavaScript:popupCall(this,'RamahDoromSecondTimerWarning','Message',false,'step1');");
            //}

            //increment question nos by 1 if the camp selected is california
			Qincrement = 0;
            if (Qincrement != 0)
            {
                Label4.Text = Convert.ToString(Int32.Parse(Label4.Text) + Qincrement);
                Label6.Text = Convert.ToString(Int32.Parse(Label6.Text) + Qincrement);
                Label35.Text = Convert.ToString(Int32.Parse(Label35.Text) + Qincrement);
                Label8.Text = Convert.ToString(Int32.Parse(Label8.Text) + Qincrement);
                Label10.Text = Convert.ToString(Int32.Parse(Label10.Text) + Qincrement);
                Label14.Text = Convert.ToString(Int32.Parse(Label14.Text) + Qincrement);
            }
            //to fill the grades in the dropdown
            getGrades();
            //to get the FJCID which is stored in session
            int resultCampId = 0; //long resultFedID;
            if (Session["FJCID"] != null)
            {
                hdnFJCID.Value = (string)Session["FJCID"]; 
                getCamperAnswers();
            }
            if (Session["CampID"] != null)
            {
                Int32.TryParse(Session["CampID"].ToString(), out resultCampId);
            }
            else if (Session["FJCID"] != null)
            {
                DataSet ds = new CamperApplication().getCamperAnswers(Session["FJCID"].ToString(), "10", "10", "N");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    Int32.TryParse(dr["Answer"].ToString(), out resultCampId);
                }
            }

            string campIDLast3Digits = resultCampId.ToString().Substring(resultCampId.ToString().Length - 3);
            if (campIDLast3Digits == "150" || campIDLast3Digits == "079")
            {
                lblMinimunDays1.Text = "12";
                lblMinimunDays2.Text = "12";
            }
            else
            {
                lblMinimunDays1.Text = "19";
                lblMinimunDays2.Text = "19";
            }
            hdnCampId.Value = resultCampId.ToString();
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
        EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.Ramah);
        
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
        DataSet dsSchool = new DataSet();
        strFJCID = hdnFJCID.Value;
        strModifiedBy = Master.UserId;
        if (!strFJCID.Equals(string.Empty))
        {
            dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "3", "33", "N");
            if (dsAnswers.Tables[0].Rows.Count > 0) //if there are records for the current FJCID
            {
                dv = dsAnswers.Tables[0].DefaultView;
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
                            //ddl = ddlQ10;
                            //tb = txtJewishSchool;
                            goto default;
                        case 9: // assigning the answer for question 11
                            tb = txtCamperSchool;
                            goto default;
                        default:  //to implement the common logic
                            drows = dv.Table.Select(strFilter);
                            int intSchool;
                            if (drows.Length > 0) //if there are rows for the filter
                            {
                                dr = (DataRow)drows.GetValue(0);
                                if (!dr["OptionID"].Equals(DBNull.Value))
                                {
                                    if (!dr["Answer"].Equals(DBNull.Value))
                                    {
                                        Int32.TryParse(dr["Answer"].ToString(), out intSchool);
                                        if (intSchool > 0)
                                        {
                                            dsSchool = CamperAppl.GetSchool(intSchool);
                                            dr = (DataRow)dsSchool.Tables[0].Rows[0];
                                        }
                                        else if (intSchool == -1)
                                        {
                                            if (drows.Length > 1)
                                            {
                                                dr = (DataRow)drows.GetValue(1);
                                            }
                                        }
                                    }
                                }
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
                            break;
                    }
                }
            }
            //to set the status of the panel based on the radio button selected
            setPanelStatus();
        } //end if for null check of fjcid
       
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
        //for Question 3 & 4
        if (RadioBtnQ3.SelectedIndex.Equals(0))   //yes is selected
        {
            PnlQ4.Enabled = false;
            RadioBtnQ4.SelectedIndex=-1;
            PnlQ5.Enabled = false;
            RadioBtnQ5.SelectedIndex=-1;
        }
        else if (RadioBtnQ3.SelectedIndex.Equals(1)) //No is selected
        {
            if (RadioBtnQ4.SelectedIndex.Equals(0))  //Yes is selected
            {
                PnlQ5.Enabled = true;
            }
            else if (RadioBtnQ4.SelectedIndex.Equals(1)) //No is selected
            {
                PnlQ5.Enabled = false;
                RadioBtnQ5.SelectedIndex=-1;
            }
            else //nothing is selected for Q4
            {
                PnlQ4.Enabled = true;
            }
        }        
        //for Question 9
        //if (RadioBtnQ9.SelectedIndex == 3) //Jewish school is selected
        //{
        //    PnlQ10.Enabled = true;
        //    pnlJewishSchool.Enabled = true;
        //    pnlCamperSchool.Enabled = false;
        //    Label23.Enabled = false;
        //    Label14.Enabled = false;
        //    txtCamperSchool.Text = "";
        //    Label15.Enabled = false;
        //}
        if (RadioBtnQ9.SelectedIndex != -1)  //for the rest of the options disable it
        {
            //PnlQ10.Enabled = false;
            //pnlJewishSchool.Enabled = false;
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
            
            //ddlQ10.SelectedIndex = 0;
           //txtJewishSchool.Text = "";
        }

        //if (ddlQ10.SelectedValue == "3")
        //{
        //    pnlJewishSchool.Enabled = true;
        //}
        //else
        //{
        //    pnlJewishSchool.Enabled = false;
        //}

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
        strQuestionId = hdnQ4Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ4.SelectedValue + strFSeparator + strQSeparator;

        //for question 5
        strQuestionId = hdnQ5Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ5.SelectedValue + strFSeparator + strQSeparator;

        //for question 6
        strQuestionId = hdnQ6Id.Value;
        strGrade = ddlGrade.SelectedValue;
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strGrade + strQSeparator;

        //for question 9
        strQuestionId = hdnQ7Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ9.SelectedValue + strFSeparator + strQSeparator;

        //for question 10
        //strQuestionId = hdnQ8Id.Value;
        //strJewishSchool = txtJewishSchool.Text.Trim();
        //strTablevalues += strQuestionId + strFSeparator + ddlQ10.SelectedValue + strFSeparator + strJewishSchool + strQSeparator;

        //for question 11
        strQuestionId = hdnQ9Id.Value;
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

    //protected void ddlQ10_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    if (ddlQ10.SelectedValue == "3")
    //    {
    //        pnlJewishSchool.Enabled = true;
    //    }
    //    else
    //    {
    //        if (RadioBtnQ9.SelectedIndex == 4)
    //        {
    //            pnlCamperSchool.Enabled = true;
    //            Label23.Enabled = true;
    //            Label14.Enabled = true;
    //            Label15.Enabled = true;
    //        }
    //        else
    //        {
    //            pnlCamperSchool.Enabled = false;
    //            Label23.Enabled = false;
    //            Label14.Enabled = false;
    //            Label15.Enabled = false;
    //            txtCamperSchool.Text = "";
    //        }

    //        pnlJewishSchool.Enabled = false;
    //        txtJewishSchool.Text = "";
    //    }
    //}
}
