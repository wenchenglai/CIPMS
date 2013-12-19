using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using CIPMSBC;
using CIPMSBC.Eligibility;
using CIPMSBC.ApplicationQuestions;


public partial class Step2_Chicago_2_coupon : System.Web.UI.Page
{
	private CamperApplication CamperAppl = new CamperApplication();
	private General objGeneral = new General();
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //to get the FJCID which is stored in session
            if (Session["FJCID"] != null)
            {
                hdnFJCID.Value = (string)Session["FJCID"]; ;
                getCamperAnswers();
            }
        }
    }

	void btnNext_Click(object sender, EventArgs e)
	{
        bool isReadOnly = objGeneral.IsApplicationReadOnly(hdnFJCID.Value, Master.CamperUserId);
		if (!isReadOnly)
		{
			ProcessCamperAnswers();
		}

		//Modified by id taken from the Master Id
		string strModifiedBy = Master.UserId;
		string strFJCID = hdnFJCID.Value;
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
                EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.Chicago);
				objEligibility.checkEligibilityforStep2(strFJCID, out iStatus);
			}

			Session["STATUS"] = iStatus.ToString();
		}
		Session["FJCID"] = hdnFJCID.Value;
		Response.Redirect("Step2_3.aspx");
	}

    void btnReturnAdmin_Click(object sender, EventArgs e)
    {
        string strRedirURL;

        if (Page.IsValid)
        {
            strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"].ToString();
            ProcessCamperAnswers();
            Response.Redirect(strRedirURL);
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
                Response.Redirect("Step2_2.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    private void ProcessCamperAnswers()
    {
        string strComments = txtComments.Text.Trim();
        string strFJCID = hdnFJCID.Value;
        string strModifiedBy = Master.UserId;
        string strCamperAnswers = ConstructCamperAnswers();

        if (strFJCID != "" && strCamperAnswers != "" && strModifiedBy != "" && bPerformUpdate)
            CamperAppl.InsertCamperAnswers(strFJCID, strCamperAnswers, strModifiedBy, strComments);
    }

    //to get the camper answers from the database
    void getCamperAnswers()
    {
        DataSet dsAnswers = CamperAppl.getCamperAnswers(hdnFJCID.Value, "1047", "1054", "N");

        foreach (DataRow dr in dsAnswers.Tables[0].Rows)
        {
            int qID = Convert.ToInt32(dr["QuestionId"]);

            if (qID == 1047) // Did the camper attend a Jewish preschool?
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                if (dr["OptionID"].ToString() == "1")
                    rdoYes1.Checked = true;
                else
                    rdoNo1.Checked = true;                
            }
            else if (qID == 1048) 
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                {
                    txtCampName1.Text = dr["Answer"].ToString();
                }
            }
            else if (qID == 1049) 
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                {
                    txtAddress1.Text = dr["Answer"].ToString();
                }
            }
            else if (qID == 1050) 
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                {
                    txtYearAttended1.Text = dr["Answer"].ToString();
                }
            }
            else if (qID == 1051) // Did the camper attend a Jewish day camp?
            {
                if (dr["OptionID"].Equals(DBNull.Value))
                    continue;

                if (dr["OptionID"].ToString() == "1")
                    rdoYes2.Checked = true;
                else
                    rdoNo2.Checked = true;   
            }
            else if (qID == 1052) 
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                {
                    txtCampName2.Text = dr["Answer"].ToString();
                }
            }
            else if (qID == 1053) 
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                {
                    txtAddress2.Text = dr["Answer"].ToString();
                }
            }
            else if (qID == 1054)
            {
                if (!dr["Answer"].Equals(DBNull.Value))
                {
                    txtYearAttended2.Text = dr["Answer"].ToString();
                }
            }
        }
    }

    private string ConstructCamperAnswers()
    {      
        //to get the Question separator from Web.config
        string strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
        //to get the Field separator from Web.config
        string strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();

        string strTablevalues = "1047" + strFSeparator + (rdoYes1.Checked ? "1" : rdoNo1.Checked ? "2" : "") + strFSeparator + strQSeparator;
        strTablevalues += "1048" + strFSeparator + strFSeparator + txtCampName1.Text + strQSeparator;
        strTablevalues += "1049" + strFSeparator + strFSeparator + txtAddress1.Text + strQSeparator;
        strTablevalues += "1050" + strFSeparator + strFSeparator + txtYearAttended1.Text + strQSeparator;

        strTablevalues += "1051" + strFSeparator + (rdoYes2.Checked ? "1" : rdoNo2.Checked ? "2" : "") + strFSeparator + strQSeparator;
        strTablevalues += "1052" + strFSeparator + strFSeparator + txtCampName2.Text + strQSeparator;
        strTablevalues += "1053" + strFSeparator + strFSeparator + txtAddress2.Text + strQSeparator;
        strTablevalues += "1054" + strFSeparator + strFSeparator + txtYearAttended2.Text + strQSeparator;

        //to remove the extra character at the end of the string, if any
        char[] chartoRemove = { Convert.ToChar(strQSeparator) };
        strTablevalues = strTablevalues.TrimEnd(chartoRemove);

        return strTablevalues;
    }

    //to validate the comments field for Admin
    void CusValComments_ServerValidate(object source, ServerValidateEventArgs args)
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
}
