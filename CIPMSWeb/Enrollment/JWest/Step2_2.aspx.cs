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



public partial class Step2_JWest_2 : System.Web.UI.Page
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
                //Session["FJCID"] = "200810130000";
                //to get the FJCID which is stored in session
                if (Session["FJCID"] != null)
                {
                    hdnFJCID.Value = (string)Session["FJCID"]; ;
                    //Session["FJCID"] = null;
                    getCamperAnswers();
                }

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
        EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.JWest);
        
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

					if (RadioBtnQ4.SelectedIndex == 1 && RadioBtnQ3.SelectedIndex == 1)
					{
						iStatus = Convert.ToInt32(StatusInfo.SystemInEligible);
					}

					if (iStatus != Convert.ToInt32(StatusInfo.SystemEligible))
					{
						if (Convert.ToInt32(Session["codeValue"]) == 1)// PJL Day School codes validation
						{
							if (Session["SpecialCodeValue"] != null)
							{
								CamperApplication oCA = new CamperApplication();
								int validate = oCA.validatePJLDSCode(Session["SpecialCodeValue"].ToString());
								if (validate == 0 || validate == 2)
								{
									oCA.updatePJLDSCode(Session["SpecialCodeValue"].ToString(), hdnFJCID.Value);
									Session["FJCID"] = hdnFJCID.Value;
									Session["FedId"] = ConfigurationManager.AppSettings["PJL"].ToString();
									CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), "63");
									Response.Redirect("~/Enrollment/PJL/Summary.aspx");
								}
							}
						}
						else
						{
							Response.Redirect("~/Enrollment/Step1_NL.aspx");
						}
					}
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
            dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "3", "19", "N");
            if (dsAnswers.Tables[0].Rows.Count > 0) //if there are records for the current FJCID
            {
                dv = dsAnswers.Tables[0].DefaultView;
                //to display answers for the Questions 3 -5
                for (int i = 3; i <= 5; i++)
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
                        case 4:// assigning the answer for question 4
                            rb = RadioBtnQ4;
                            goto default;
                        /////////////////////////////////////////////////////////////
                        //QUESTION NO 5 WILL BE IN A DISABLED STATE//////////////////
                        /////////////////////////////////////////////////////////////

                        //case 5:// assigning the answer for question 5
                        //    foreach (DataRow dr1 in dv.Table.Select(strFilter))
                        //    {
                        //        if (!dr1["OptionID"].Equals(DBNull.Value))
                        //        {
                        //            switch (dr1["OptionID"].ToString())
                        //            {
                        //                case "1":  //for Year
                        //                    txtYear.Text= dr1["Answer"].Equals(DBNull.Value) ? "" : dr1["Answer"].ToString();
                        //                    break;
                        //                case "2": //for Noof Days
                        //                    txtNoofDays.Text = dr1["Answer"].Equals(DBNull.Value) ? "" : dr1["Answer"].ToString();
                        //                    break;
                        //            }
                        //        }
                        //    }
                        //    break;
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
        //for 9th grade issue;
        string strGrade = "";
        strGrade = GetGrade();

        if ((strGrade == "9") && RadioBtnQ3.SelectedValue == "2")
        {
            pnl9grade.Enabled = false;
            RadioBtnQ3.ControlStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#848284");
            Label5.ControlStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#848284");
            ListItemCollection Q4Options;
            ListItem Option3;
            Q4Options = RadioBtnQ4.Items;
            Option3 = Q4Options.FindByValue("3");
            Option3.Enabled = false;

        }
        else
        {
            pnl9grade.Enabled = true;
            RadioBtnQ3.ControlStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0");
            Label5.ControlStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0");
            ListItemCollection Q4Options;
            ListItem Option3;
            Q4Options = RadioBtnQ4.Items;
            Option3 = Q4Options.FindByValue("3");
            Option3.Enabled = true;
        }

        //for Question 3 & 4
        if (RadioBtnQ3.SelectedIndex.Equals(0))   //yes is selected
        {
            PnlQ4.Enabled = false;
            RadioBtnQ4.SelectedIndex=-1;

            //pnlq5 will always be disabled
            //PnlQ5.Enabled = false;
            //txtYear.Text = "";
            //txtNoofDays.Text = "";

            //added logic to force disabled color for Firefox:  LMU...11/21/2008
            //remove the following code if Q5 ever becomes active
            //PnlQ5.ControlStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#848284");
            
        }
        else if (RadioBtnQ3.SelectedIndex.Equals(1)) //No is selected
        {
            if (RadioBtnQ4.SelectedIndex.Equals(2))  //"I did not receive an incentive" is selected
            {
                //PnlQ5.Enabled = true;
                //txtYear.Focus();
            }
            else if (RadioBtnQ4.SelectedIndex.Equals(1) || RadioBtnQ4.SelectedIndex.Equals(0)) //Option 1 or 2 is selected
            {
                PnlQ4.Enabled = true;
                //PnlQ5.Enabled = false;
                //txtYear.Text = "";
                //txtNoofDays.Text = "";
            }
            else  //radiobtnq4 is not selected
            {
                PnlQ4.Enabled = true;
                //PnlQ5.Enabled = true;
                //txtYear.Text = "";
                //txtNoofDays.Text = "";
            }
        }

        //added logic to force disabled color for Firefox:  LMU...11/21/2008
        if (PnlQ4.Enabled)
        {
            RadioBtnQ4.ControlStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0");
            lblQ4.ControlStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0");
        }
        else
        {
            RadioBtnQ4.ControlStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#848284");
            lblQ4.ControlStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#848284");
        }
     }

    private string ConstructCamperAnswers()
    {
        string strQuestionId = "";
        string strTablevalues = "";
        string strFSeparator;
        string strQSeparator;
        string strQ4Value = string.Empty;
        string strYear=string.Empty, strNoofDays = string.Empty;
        
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
        if (RadioBtnQ4.SelectedValue == "3")
        {
            strYear = DateTime.Now.Year.ToString();
            strNoofDays = "7";
        }
        strQuestionId = hdnQ5Id.Value;
        strTablevalues += strQuestionId + strFSeparator + "1" + strFSeparator + strYear + strQSeparator;
        strTablevalues += strQuestionId + strFSeparator + "2" + strFSeparator + strNoofDays + strQSeparator;

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
    string GetGrade()
    {
            string Grade = "";
            CamperApplication oCA = new CamperApplication();
            string strFJCID;
            strFJCID = hdnFJCID.Value;
            DataSet dsGrade;
            dsGrade = oCA.getCamperAnswers(strFJCID, "6", "6", "N");
            DataRow drGrade;

            if (dsGrade.Tables[0].Rows.Count > 0)
            {
                drGrade = dsGrade.Tables[0].Rows[0];
                Grade = drGrade["Answer"].ToString();
            }
            return Grade;
   
    }
  
    
}
