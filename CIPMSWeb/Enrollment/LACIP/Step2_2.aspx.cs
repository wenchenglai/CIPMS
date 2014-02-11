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


public partial class Step2_LACIP_2 : System.Web.UI.Page
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
        RadioBtnQ3.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        //RadioBtnQ4.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        //RadioBtnQ5.SelectedIndexChanged += new EventHandler(RadioBtn_SelectedIndexChanged);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
    }
   

    protected void Page_Load(object sender, EventArgs e)
    {
        objGeneral = new General();
        CamperAppl = new CamperApplication();
        if (!IsPostBack)
        {
            getGrades();

            if (Session["FJCID"] != null)
            {
                hdnFJCID.Value = (string)Session["FJCID"];
                getCamperAnswers();
				getCamperAnswers2();
            }

        }
    }

    //page unload
    void Page_Unload(object sender, EventArgs e)
    {
        objGeneral = null;
        CamperAppl = null;
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
                //Session["FJCID"] = null;
                //Session["ZIPCODE"] = null;
                Response.Redirect(strRedirURL,false);
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
                //Session["FJCID"] = null;
                //Session["ZIPCODE"] = null;
               // Session.Abandon();
               // Response.Redirect(strRedirURL,false);
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
        EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.LACIP);
        
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
                Response.Redirect("Step2_3.aspx",false);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    private void ProcessCamperAnswers()
    {
        InsertCamperAnswers();
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

	void getCamperAnswers2()
	{
		string strFJCID;
		DataSet dsAnswers;
		DataView dv;
		//RadioButton rb;
		string strFilter;

		strFJCID = hdnFJCID.Value;
		if (!strFJCID.Equals(string.Empty))
		{
			dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "6", "8", "N");
			if (dsAnswers.Tables[0].Rows.Count > 0) //if there are records for the current FJCID
			{
				dv = dsAnswers.Tables[0].DefaultView;
				//to display answers for the QuestionId 6,7 and 8 for step 2_2_Midsex
				for (int i = 6; i <= 8; i++)
				{
					strFilter = "QuestionId = '" + i.ToString() + "'";

					switch (i)
					{
						case 6: // assigning the answer for question 1

							foreach (DataRow dr in dv.Table.Select(strFilter))
							{
								if (!dr["Answer"].Equals(DBNull.Value))
								{
									ddlGrade.SelectedValue = dr["Answer"].ToString();
								}
							}
							break;

						case 7:// assigning the answer for question 2
							foreach (DataRow dr in dv.Table.Select(strFilter))
							{
								if (!dr["OptionID"].Equals(DBNull.Value))
								{
									RadioBtnQ2.SelectedValue = dr["OptionID"].ToString();
								}
							}
							break;

						case 8: // assigning the answer for question 3
							foreach (DataRow dr in dv.Table.Select(strFilter))
							{
								if (!dr["OptionID"].Equals(DBNull.Value))
								{
									switch (dr["OptionID"].ToString())
									{
										case "1":  //for school dropdown
											ddlCamperSchool.SelectedValue = dr["Answer"].Equals(DBNull.Value) ? "" : dr["Answer"].ToString();
											if (ddlCamperSchool.SelectedValue.Equals("-1"))  //if 'OTHERS' is selected then enable school text box
												txtCamperSchoolOthers.Enabled = true;
											break;
										case "2": //for other school text box
											txtCamperSchoolOthers.Text = dr["Answer"].Equals(DBNull.Value) ? "" : dr["Answer"].ToString();
											break;
									}
								}
								else
								{
									if (!dr["Answer"].Equals(DBNull.Value))
									{
										ddlCamperSchool.SelectedIndex = ddlCamperSchool.Items.IndexOf(ddlCamperSchool.Items.FindByText(dr["Answer"].ToString()));
										if (ddlCamperSchool.SelectedValue.Equals(""))
										{
											ddlCamperSchool.SelectedValue = "-1";
											txtCamperSchoolOthers.Enabled = true;
											txtCamperSchoolOthers.Text = dr["Answer"].ToString();
										}
									}
								}
							}
							break;
					}
				}
				//if (PnlQ1b.Visible == true)
				//SetFirstTimeCamper();
			}
		} //end if for null check of fjcid
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
        
        strFJCID = hdnFJCID.Value;
        strModifiedBy = Master.UserId;
        if (!strFJCID.Equals(string.Empty))
        {
            dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "21", "24", "N");
            if (dsAnswers.Tables[0].Rows.Count > 0) //if there are records for the current FJCID
            {
                dv = dsAnswers.Tables[0].DefaultView;
                //to display answers for the Questions 3 -6
                for (int i = 3; i <= 6; i++)
                {
                    //to get the QuestionId for the Questions
                    hdnval = (HiddenField)PnlHidden.FindControl("hdnQ" + i.ToString() + "Id");
                    strFilter = "QuestionId = '" + hdnval.Value + "'";
                    rb = null;

                    switch (i)
                    {
                        case 3:  //assigning the answer for question 3
                            rb = RadioBtnQ3;
                            goto default;
						//case 4:// assigning the answer for question 4
						//    rb = RadioBtnQ4;
						//    goto default;
						//case 5:// assigning the answer for question 5
						//    rb = RadioBtnQ5;
						//    goto default;
                        case 6:// assigning the answer for question 6
                            //rb = RadioBtnQ6;
                            //goto default;
                        default:  //to implement the common logic
                            drows = dv.Table.Select(strFilter);
                            if (drows.Length > 0) //if there are rows for the filter
                            {
                                dr = (DataRow)drows.GetValue(0);
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
		//if (RadioBtnQ3.SelectedIndex.Equals(0))   //yes is selected
		//{
		//    PnlQ4.Enabled = false;
		//    RadioBtnQ4.SelectedIndex=-1;
		//    PnlQ5.Enabled = false;
		//    RadioBtnQ5.SelectedIndex = -1;
		//    //PnlQ6.Enabled = true;
		//}
		//else if (RadioBtnQ3.SelectedIndex.Equals(1)) //No is selected
		//{
		//    if (RadioBtnQ4.SelectedIndex.Equals(0))  //"Yes" is selected
		//    {
		//        PnlQ5.Enabled = true;
		//        //PnlQ6.Enabled = false;
		//        //RadioBtnQ6.SelectedIndex = -1;
		//        //if (RadioBtnQ5.SelectedIndex.Equals(0)) //"Yes" is selected
		//        //{
		//        //    PnlQ6.Enabled = true;
		//        //    //RadioBtnQ6.SelectedIndex = -1;
		//        //}
		//        //else if (RadioBtnQ5.SelectedIndex.Equals(1)) //"No" is selected
		//        //{
		//        //    PnlQ6.Enabled = false;
		//        //    RadioBtnQ6.SelectedIndex = -1;
		//        //}
		//        //else
		//        //{
		//        //    PnlQ6.Enabled = true;
		//        //}
		//    }
		//    else if (RadioBtnQ4.SelectedIndex.Equals(1)) //No is selected
		//    {
		//        PnlQ5.Enabled = false;
		//        RadioBtnQ5.SelectedIndex = -1;
		//        //PnlQ6.Enabled = false;
		//        //RadioBtnQ6.SelectedIndex = -1;
		//    }
		//    else
		//    {
		//        PnlQ4.Enabled = true;
		//        //RadioBtnQ4.SelectedIndex = -1;
		//        PnlQ5.Enabled = true;
		//        //RadioBtnQ5.SelectedIndex = -1;
		//        //PnlQ6.Enabled = false;
		//        //RadioBtnQ6.SelectedIndex = -1;
		//    }
		//}
     }

    private string ConstructCamperAnswers()
    {
        string strQuestionId = "";
        string strTablevalues = "";
        string strFSeparator;
        string strQSeparator;
        string strQ4Value = string.Empty;
        
        //to get the Question separator from Web.config
        strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
        //to get the Field separator from Web.config
        strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();

        //for question 3
        strQuestionId = hdnQ3Id.Value;
        strTablevalues += strQuestionId + strFSeparator + RadioBtnQ3.SelectedValue + strFSeparator + strQSeparator;

		////for question 4
		//strQuestionId = hdnQ4Id.Value;
		//strTablevalues += strQuestionId + strFSeparator + RadioBtnQ4.SelectedValue + strFSeparator + strQSeparator;

		////for question 5
		//strQuestionId = hdnQ5Id.Value;
		//strTablevalues += strQuestionId + strFSeparator + RadioBtnQ5.SelectedValue + strFSeparator + strQSeparator;

        //for question 6
        //strQuestionId = hdnQ6Id.Value;
        //strTablevalues += strQuestionId + strFSeparator + RadioBtnQ6.SelectedValue + strFSeparator + strQSeparator;

		//for question Grade
		string strGrade = ddlGrade.SelectedValue.ToString();
		strQuestionId = hdnGradeId.Value;
		strTablevalues += strQuestionId + strFSeparator + strFSeparator + strGrade + strQSeparator;

		//for question Schoo Type
		strQuestionId = hdnSchoolTypeId.Value;
		strTablevalues += strQuestionId + strFSeparator + RadioBtnQ2.SelectedValue + strFSeparator + strQSeparator;

		//for question School
		string strSchoolOthers = txtCamperSchoolOthers.Text.Trim();
		strQuestionId = hdnSchoolNameId.Value;
		strTablevalues += strQuestionId + strFSeparator + strFSeparator + strSchoolOthers + strQSeparator;

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
}
