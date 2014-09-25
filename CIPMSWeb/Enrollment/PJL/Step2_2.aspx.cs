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
				PopulateAnswers();

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
				//EligibilityBase objEligibility = EligibilityFactory.GetEligibility(FederationEnum.PJL);
				var pjl = new EligibilityPJL(FederationEnum.PJL);
				pjl.checkEligibilityforStep2(strFJCID, out iStatus, (StatusInfo)Convert.ToInt32(Session["STATUS"]));
			}

			// 2014-07-28 Starting for Year 2015, PJL has lottery system that campers failed through other community program could land this page with PendingPJLottery status
			if (Session["STATUS"] != null)
			{
				var checkStatus = (StatusInfo)Convert.ToInt32(Session["STATUS"]);

				// if this page's iStatus is ineligible, we don't even allow it to have PendingLottery
				if ((checkStatus == StatusInfo.PendingPJLottery || checkStatus == StatusInfo.SystemInEligible) && (StatusInfo)iStatus != StatusInfo.SystemInEligible )
					iStatus = (int)checkStatus;
			}

			Session["STATUS"] = iStatus.ToString();
		}
		Session["FJCID"] = hdnFJCIDStep2_2.Value;

        var nextUrl = "Step2_3.aspx";

        if (Request.QueryString["prev"] != null)
        {
            nextUrl += "?prev=" + Request.QueryString["prev"];

            if (Request.QueryString["prevfedid"] != null)
            {
                nextUrl += "&prevfedid=" + Request.QueryString["prevfedid"];
            }
        }

        Response.Redirect(nextUrl);
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
				if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_2.Value, Master.CamperUserId))
				{
					ProcessCamperAnswers();
				}

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
		    var nextUrl = "summary.aspx";

            if (Request.QueryString["prev"] != null)
            {
                nextUrl = "Step2_2_route_info.aspx";
                nextUrl += "?prev=" + Request.QueryString["prev"];

                if (Request.QueryString["prevfedid"] != null)
                {
                    nextUrl += "&prevfedid=" + Request.QueryString["prevfedid"];
                }
            }



            Response.Redirect(nextUrl);
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

	void PopulateAnswers()
	{
		DataSet dsAnswers = CamperAppl.getCamperAnswers(hdnFJCIDStep2_2.Value, "", "", "3,6,7,8,1021,1063");

		foreach (DataRow dr in dsAnswers.Tables[0].Rows)
		{
			var qID = (QuestionId)dr["QuestionId"];

			if (qID == QuestionId.FirstTime) // Is this your first time to attend a Non-profit Jewish overnight camp, for 3 weeks or longer:
			{
				if (dr["OptionID"].Equals(DBNull.Value))
					continue;

				if (dr["OptionID"].ToString() == "1")
				{
					rdoFirstTimerYes.Checked = true;
				}
                else if (dr["OptionID"].ToString() == "2")
				{
					rdoFirstTimerNo.Checked = true;
				}
			}
			else if (qID == QuestionId.Grade) // Grade (Mention the grade of the camper after he/she attends the camp session):
			{
				if (!dr["Answer"].Equals(DBNull.Value))
				{
					ddlGrade.SelectedValue = dr["Answer"].ToString();
				}
			}
			else if (qID == QuestionId.SchoolType) // What kind of the school the camper go to
			{
				if (dr["OptionID"].Equals(DBNull.Value))
					continue;

				rdoSchoolType.SelectedValue = dr["OptionID"].ToString();
				if (dr["OptionID"].ToString() == "3")
					txtSchoolName.Enabled = false;
			}
			else if (qID == QuestionId.SchoolName) // Name of the school Camper attends:
			{
				if (!dr["Answer"].Equals(DBNull.Value))
				{
					txtSchoolName.Text = dr["Answer"].ToString();
				}
			}
			else if (qID == QuestionId.Q1021_PJLNames)
			{
				if (dr["OptionID"].Equals(DBNull.Value))
					continue;
				
				if (dr["OptionID"].ToString() == "1")
				{
					txtFirstName.Text = dr["Answer"].ToString();
				}
				else if (dr["OptionID"].ToString() == "2")
				{
					txtLastName.Text = dr["Answer"].ToString();
				}
			}
			else if (qID == QuestionId.GrandfatherPolicySessionLength) // If a professional or fellow congregant is selected, offer this list as a check all that apply
			{
				if (dr["OptionID"].Equals(DBNull.Value))
					continue;

				if (dr["OptionID"].ToString() == "1")
					rdoDays12.Checked = true;
				else
					rdoDays19.Checked = true;
			}
		}
	}

	private string ConstructCamperAnswers()
	{
		var strQId = "";
		string strTablevalues = "";

		//to get the Question separator from Web.config
		var strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"];
		//to get the Field separator from Web.config
		var strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"];

		//for question FirstTimerOrNot
		strQId = ((int)QuestionId.FirstTime).ToString();
		strTablevalues += strQId + strFSeparator + Convert.ToString(rdoFirstTimerYes.Checked ? "1" : rdoFirstTimerNo.Checked ? "2" : "") + strFSeparator + strQSeparator;

		//Grandfaother question
		strQId = ((int)QuestionId.GrandfatherPolicySessionLength).ToString();
		strTablevalues += strQId + strFSeparator + (rdoDays12.Checked ? "1" : rdoDays19.Checked ? "2" : "") + strFSeparator + strQSeparator;

		// First name and Last Name
		strQId = hdnQ1021Id.Value;
		strTablevalues += strQId + strFSeparator + "1" + strFSeparator + txtFirstName.Text + strQSeparator;

		strQId = hdnQ1021Id.Value;
		strTablevalues += strQId + strFSeparator + "2" + strFSeparator + txtLastName.Text + strQSeparator;

		//for question Grade
		strQId = ((int)QuestionId.Grade).ToString();
		strTablevalues += strQId + strFSeparator + strFSeparator + ddlGrade.SelectedValue + strQSeparator;

		//for question School Type
		if (rdoSchoolType.SelectedValue != "")
		{
			strQId = ((int)QuestionId.SchoolType).ToString();
			strTablevalues += strQId + strFSeparator + rdoSchoolType.SelectedValue + strFSeparator + rdoSchoolType.SelectedItem.Text + strQSeparator;
		}

		//for question School Name
		strQId = ((int)QuestionId.SchoolName).ToString();
		strTablevalues += strQId + strFSeparator + strFSeparator + txtSchoolName.Text + strQSeparator;

		//to remove the extra character at the end of the string, if any
		char[] chartoRemove = { Convert.ToChar(strQSeparator) };
		strTablevalues = strTablevalues.TrimEnd(chartoRemove);

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
