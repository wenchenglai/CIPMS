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


public partial class Step2_JCC_2 : System.Web.UI.Page
{
    private CamperApplication CamperAppl;
    private General objGeneral;
    private Boolean bPerformUpdate;

    protected void Page_Init(object sender, EventArgs e)
    {
        bool isClosed = (from id in ConfigurationManager.AppSettings["OpenFederations"].Split(',')
                         where id == ((int)FederationEnum.MountainChai).ToString()
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
        //RadioBtnQ2.SelectedIndexChanged += new EventHandler(RadioBtnQ2_SelectedIndexChanged);
        //RadioBtnQ3.SelectedIndexChanged += new EventHandler(RadioBtnQ3_SelectedIndexChanged);
        RadioButtionQ6.SelectedIndexChanged += new EventHandler(RadioButtionQ6_SelectedIndexChanged);
    }

    //protected void RadioBtnQ2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SetRadioButtonPanels();
    //}

    //protected void RadioBtnQ3_SelectedIndexChanged(object sender, EventArgs e)
    //{        
    //    SetRadioButtonPanels();
    //}

    //void SetRadioButtonPanels()
    //{
    //    if (RadioBtnQ2.SelectedValue != "2")
    //    {
    //        PnlQ3.Enabled = false;
    //        PnlQ4.Enabled = false;
    //        RadioBtnQ3.SelectedIndex = -1;
    //        RadioBtnQ4.SelectedIndex = -1;
    //    }
    //    else { PnlQ3.Enabled = true; }
        
    //    if (RadioBtnQ3.SelectedValue == "1")
    //    {
    //        PnlQ4.Enabled = true;
    //    }
    //    else
    //    {
    //        PnlQ4.Enabled = false;
    //        RadioBtnQ4.SelectedIndex = -1;
    //    }
    //}

    void RadioButtionQ6_SelectedIndexChanged(object sender, EventArgs e)
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
                //to get the FJCID which is stored in session
                if (Session["FJCID"] != null)
                {
                    hdnFJCIDStep2_2.Value = (string)Session["FJCID"];
                    getCamperAnswers();
                }
                //SetRadioButtonPanels();
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
                //Session.Abandon();
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
        EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.MountainChai);
        
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
        dtGrade = objGeneral.getGrades(Session["FedId"].ToString(), Master.CampYear);
        ddlGrade.DataSource = dtGrade;
        ddlGrade.DataTextField = "EligibleGrade";
        ddlGrade.DataValueField = "EligibleGrade";
        ddlGrade.DataBind();
        ddlGrade.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    //to set the school text box status to enable / disable based on the school type selected
    private void setTextBoxStatus()
    {
        if (RadioButtionQ6.SelectedValue == "3")   //Home school is selected
        {
            PnlQ7.Enabled = false;
            txtCamperSchool.Text = "";
        }
        else
        {
            PnlQ7.Enabled = true;
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
            dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "3", "40", "N");
            if (dsAnswers.Tables[0].Rows.Count > 0) //if there are records for the current FJCID
            {
                dv = dsAnswers.Tables[0].DefaultView;
                //to display answers for the QuestionId 3,6,7 and 8 for step 2_2_Midsex
                for (int i = 3; i <= 40; i++)
                {
                    strFilter = "QuestionId = '" + i.ToString() + "'";

                    switch (i)
                    {
                        case 3:  //assigning the answer for question 3
                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["OptionID"].Equals(DBNull.Value))
                                {
                                    RadioBtnQ2.SelectedValue = dr["OptionID"].ToString();
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
                                    RadioButtionQ6.SelectedValue = dr["OptionID"].ToString();
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
                        //case 13: // assigning the answer for question 13

                        //    foreach (DataRow dr in dv.Table.Select(strFilter))
                        //    {
                        //        if (!dr["OptionID"].Equals(DBNull.Value))
                        //        {
                        //            RadioBtnQ3.SelectedValue = dr["OptionID"].ToString();
                        //        }
                        //    }
                        //    break;
                        //case 40: // assigning the answer for question 40

                        //    foreach (DataRow dr in dv.Table.Select(strFilter))
                        //    {
                        //        if (!dr["OptionID"].Equals(DBNull.Value))
                        //        {
                        //            RadioBtnQ4.SelectedValue = dr["OptionID"].ToString();
                        //        }
                        //    }
                        //    break;
                    }
                }
            }
            //to set the school text box to enable / disable based on the school type selected
            setTextBoxStatus();
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
        strTablevalues += strQuestionId + strFSeparator + (RadioBtnQ2.SelectedIndex>-1 ? RadioBtnQ2.SelectedValue : "") + strFSeparator + strQSeparator;

        //for question 3
        //if (RadioBtnQ3.SelectedIndex > -1)
        //{
        //    strQuestionId = hdnQ3Id.Value;
        //    strTablevalues += strQuestionId + strFSeparator + (RadioBtnQ3.SelectedIndex > -1 ? RadioBtnQ3.SelectedValue : "") + strFSeparator + strQSeparator;
        //}
        //for question 4
        //if (RadioBtnQ4.SelectedIndex > -1)
        //{
        //    strQuestionId = hdnQ4Id.Value;
        //    strTablevalues += strQuestionId + strFSeparator + (RadioBtnQ4.SelectedIndex > -1 ? RadioBtnQ4.SelectedValue : "") + strFSeparator + strQSeparator;
        //}
        //for question 5
        strQuestionId = hdnQ5Id.Value;
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strGrade + strQSeparator;

        //for question 6
        strQuestionId = hdnQ6Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioButtionQ6.SelectedValue + strFSeparator + strQSeparator;

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
