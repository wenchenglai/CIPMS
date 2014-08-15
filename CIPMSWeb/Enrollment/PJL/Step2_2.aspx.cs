using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using CIPMSBC;
using CIPMSBC.Eligibility;

public partial class Step2_PJL_2 : System.Web.UI.Page
{
    private CamperApplication CamperAppl;
    private General objGeneral = new General();
    private Boolean bPerformUpdate;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!ConfigurationManager.AppSettings["OpenFederations"].Split(',').Any(id => id == ((int) FederationEnum.PJL).ToString()))
            Response.Redirect("~/NLIntermediate.aspx");

        btnNext.Click += new EventHandler(btnNext_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click+=new EventHandler(btnReturnAdmin_Click);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        RadioButtionQ5.SelectedIndexChanged += new EventHandler(RadioButtionQ5_SelectedIndexChanged);
    }

	protected void Page_Load(object sender, EventArgs e)
	{
		CamperAppl = new CamperApplication();

		if (!IsPostBack)
		{
			getGrades();

			//to get the FJCID which is stored in session
			if (Session["FJCID"] != null)
			{
				hdnFJCIDStep2_2.Value = (string)Session["FJCID"];
				getCamperAnswers();

				//CheckDaySchoolTrigger();
			}
		}

		int validate = CamperAppl.validateIsUsedPJLDSCode(Session["FJCID"].ToString());
		if (validate == 1)
		{
			hdnValid.Value = "1";
		}
		else
		{
			hdnValid.Value = "0";
		}

		// 2012-09-23 Disable this day school click event for now
		// When day school quota is running out, uncomment the code below
		//foreach (ListItem li in RadioButtionQ5.Items)
		//{
		//  li.Attributes.Add("OnClick", "JavaScript:popupCall(this,'PJLJewishDaySchoolMessage','Message',false,'step1');");
		//}
	}

    void btnNext_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;

        bool isReadOnly = objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_2.Value, Master.CamperUserId);

        if (!isReadOnly)
        {
            ProcessCamperAnswers();
        }

        //Modified by id taken from the Master Id
        string strModifiedBy = Master.UserId;
        string strFJCID = hdnFJCIDStep2_2.Value;
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
                EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.PJL);
                objEligibility.checkEligibilityforStep2(strFJCID, out iStatus);

                //// when user is from day school, if they have the special day school code, we let them pass
                //if (RadioButtionQ5.SelectedValue == "4")
                //{
                //    var oCA = new CamperApplication();
                //    var FJCID = Session["FJCID"].ToString();

                //    string currentCode = Session["SpecialCodeValue"].ToString();
                //    int validate = oCA.validatePJLDSCode(currentCode);
                //    if (validate == 0 || validate == 2)
                //    {
                //        oCA.updatePJLDSCode(currentCode, FJCID);
                //        iStatus = (int)StatusInfo.SystemEligible;
                //    }
                //    else
                //    {
                //        // 2014-02-07 now, the Direct Pass PJL code also allows day school by default
                //        bool isDirectPass = SpecialCodeManager.IsValidDirectPassCode(Convert.ToInt32(Application["CampYearID"]), FederationEnum.PJL, currentCode);
                //        if (isDirectPass)
                //        {
                //            iStatus = (int)StatusInfo.SystemEligible;
                //        }
                //        else
                //        {
                //            // 2014-02-19 now, a multi-use regular PJLCode code could allow day school
                //            bool allowDaySchool = SpecialCodeManager.IsValidPJLPassCodeAllowDaySchool(Convert.ToInt32(Application["CampYearID"]), currentCode);
                //            if (allowDaySchool)
                //            {
                //                iStatus = (int)StatusInfo.SystemEligible;
                //            }
                //        }
                //    }
                //}
            }

            // 2014-07-28 Starting for Year 2015, PJL has lottery system that campers failed through other community program could land this page with PendingPJLottery status
            if (Session["STATUS"] != null)
            {
                var checkStatus = (StatusInfo)Convert.ToInt32(Session["STATUS"]);
                if (checkStatus == StatusInfo.PendingPJLottery || checkStatus == StatusInfo.SystemInEligible)
                    iStatus = (int)checkStatus;
            }

            Session["STATUS"] = iStatus.ToString();
        }
        Session["FJCID"] = hdnFJCIDStep2_2.Value;
        Response.Redirect("Step2_3.aspx");
    }

	// 2012-10-27 This code is to implement automatic trigger once day school camper reaches threshold value
	// check Config table for the config value
	private void CheckDaySchoolTrigger()
	{
		// 2012-11-19 For Fed Admin, we should never bloack the Next Button
		if (Session["RoleID"] != null)
		{
			btnNext.Visible = true;
			lblDaySchoolMsg.Visible = false;
			return;
		}

		// when user is from day school, if they have the special day school code, we let them pass
		// if user has no special day school code, then we have to see total day school camper is over threshold
		if (RadioButtionQ5.SelectedValue == "4")
		{
			CamperApplication oCA = new CamperApplication();
		    string FJCID = Session["FJCID"].ToString();
            int validate = oCA.validateIsUsedPJLDSCode(FJCID);
			if (validate == 1)
			{
				btnNext.Enabled = true;
				lblDaySchoolMsg.Visible = false;
			}
			else
			{
				SQLDBAccess db = new SQLDBAccess("CIPConnectionString");
				DataTable dt = db.FillDataTable("usp_GetPJDaySchoolCount");
				int count = Int32.Parse(dt.Rows[0]["Count"].ToString());
				bool isTriggered = dt.Rows[0]["isTrigger"].ToString() == "Yes" ? true : false;
				int threshold = Int32.Parse(dt.Rows[0]["Threshold"].ToString());
				if (count >= threshold || isTriggered)
				{
					if (!isTriggered)
					{
						db.ExecuteNonQuery("usp_UpdatePJDaySchoolTrigger");
					}
					btnNext.Visible = false;
					lblDaySchoolMsg.Visible = true;
				}
				else
				{
					btnNext.Visible = true;
					lblDaySchoolMsg.Visible = false;
				}
			}
		}
		else
		{
			btnNext.Visible = true;
			lblDaySchoolMsg.Visible = false;
		}
	}

    void RadioButtionQ5_SelectedIndexChanged(object sender, EventArgs e)
    {
        setTextBoxStatus();
		CheckDaySchoolTrigger();
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
        if (RadioButtionQ5.SelectedValue == "3")   //Home school is selected
        {
            PnlQ6.Enabled = false;
            txtCamperSchool.Text = "";
            lblQ6.Enabled = false;
            lblQ6star.Enabled = false;
        }
        else
        {
            PnlQ6.Enabled = true;
            lblQ6.Enabled = true;
            lblQ6star.Enabled = true;            
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
            dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "3", "1021", "N");
            if (dsAnswers.Tables[0].Rows.Count > 0) //if there are records for the current FJCID
            {
                dv = dsAnswers.Tables[0].DefaultView;
                //to display answers for the QuestionId 3,6,7 and 8 for step 2_2_Midsex
                for (int i = 3; i <= 1021; i++)
                {
                    strFilter = "QuestionId = '" + i.ToString() + "'";

                    switch (i)
                    {
                        case 3:  //assigning the answer for question 3
                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["OptionID"].Equals(DBNull.Value))
                                {
                                    rb = (RadioButton)Panel2.FindControl("RadioBtnQ3" + dr["OptionID"].ToString());
                                    rb.Checked = true;
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
                                    RadioButtionQ5.SelectedValue = dr["OptionID"].ToString();
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
                            
                        case 1021:

                            foreach (DataRow dr in dv.Table.Select(strFilter))
                            {
                                if (!dr["OptionID"].Equals(DBNull.Value))
                                {
                                    if (dr["OptionID"].ToString()== "1")
                                    {
                                        txtFirstName1.Text = dr["Answer"].ToString();
                                    }
                                    if (dr["OptionID"].ToString() == "2")
                                    {
                                        txtLastName1.Text = dr["Answer"].ToString();
                                    }
                                    
                                }
                            }
                            break;


                       
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

        //for question 3
        strQuestionId = hdnQ3Id.Value;
        strTablevalues += strQuestionId + strFSeparator + Convert.ToString(RadioBtnQ31.Checked ? "1" : RadioBtnQ32.Checked ? "2" : "") + strFSeparator + strQSeparator;

        //for question 4
        strQuestionId = hdnQ4Id.Value;
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strGrade + strQSeparator;

        //for question 5
        strQuestionId = hdnQ5Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioButtionQ5.SelectedValue + strFSeparator + strQSeparator;

        //for question 6
        strQuestionId = hdnQ6Id.Value;
        strTablevalues += strQuestionId + strFSeparator + strFSeparator + strSchool + strQSeparator;

        //for question 1
        strQuestionId = hdnQ1021Id.Value;
        strTablevalues += strQuestionId + strFSeparator + "1" + strFSeparator + txtFirstName1.Text + strQSeparator;
        
        strQuestionId = hdnQ1021Id.Value;
        strTablevalues += strQuestionId + strFSeparator + "2" + strFSeparator + txtLastName1.Text;

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


    protected void btnNext_Click1(object sender, EventArgs e)
    {

    }
}
