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

public partial class Step2_1 : System.Web.UI.Page
{
	private CamperApplication CamperAppl = new CamperApplication();
	private General objGeneral = new General();
    private Boolean bPerformUpdate;
    private string federationFolderURL = string.Empty;

    protected void Page_Init(object sender, EventArgs e)
    {
        btnNext.Click += new EventHandler(btnNext_Click);
        btnPrevious.Click += new EventHandler(btnPrevious_Click);
        btnSaveandExit.Click += new EventHandler(btnSaveandExit_Click);
        btnReturnAdmin.Click+=new EventHandler(btnReturnAdmin_Click);
        CusValComments.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);
        CusValComments1.ServerValidate += new ServerValidateEventHandler(CusValComments_ServerValidate);

        if (Session["FedID"] != null)
        {
            General objGeneral = new General();
            CamperApplication objCamperApplication = new CamperApplication();
            string navigationUrl = string.Empty;
            string campID = string.Empty;
            if (Session["CampID"] != null) campID = Session["CampID"].ToString();
            else if (Session["FJCID"] != null)
            {
                DataSet dsCamperApplication = objCamperApplication.getCamperApplication(Session["FJCID"].ToString());
                campID = dsCamperApplication.Tables[0].Rows.Count > 0?dsCamperApplication.Tables[0].Rows[0]["Camp"].ToString():string.Empty;
            }
            DataSet dsFederationDetails = new DataSet();
            if (campID != string.Empty)
            {
                dsFederationDetails = objGeneral.GetFederationDetailsUsingCampID(Session["FedID"].ToString(),campID);
            }
            else
            {
                dsFederationDetails = objGeneral.GetFederationDetails(Session["FedID"].ToString());
            }
            if (dsFederationDetails.Tables[0].Rows.Count > 0)
            {
                navigationUrl = dsFederationDetails.Tables[0].Rows[0]["NavigationURL"].ToString();
            }
            //if ((Request.UrlReferrer.AbsolutePath.Contains("URJ/Acadamy") || (campID== "1146")) && (navigationUrl.Contains("URJ")))3146
            if ((campID == "1146" || campID == "2146" || campID == "3146") && (Session["FedID"].ToString() == "7"))
                federationFolderURL = navigationUrl.Remove(navigationUrl.IndexOf("Summary.aspx")) + "/Acadamy";
            else
                federationFolderURL = navigationUrl.Remove(navigationUrl.IndexOf("Summary.aspx")) + "/";
        }
        else
        {
            federationFolderURL = "";
        }        
    }

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			if (Session["FJCID"] != null)
			{
				hdnFJCIDStep2_1.Value = (string)Session["FJCID"];
				getCamperAnswers();
			}
			//to validate the option for Question 1 on Step 2- Page 1
			int i;
			TextBox tb;

			//TV: 10/2009 - increased size of loop by 1 (from 5 to 6)
			//Ram: 3/2010 - increased size of loop by 1 (from 6 to 7)
			for (i = 0; i <= 8; i++)
			{
				tb = (TextBox)Panel1.FindControl("txt" + Convert.ToString(i + 1));
				if (tb != null)
				{
					tb.Attributes.Add("onBlur", "javascript:SetHelpText('" + i.ToString() + "', this);");
					tb.Attributes.Add("onFocus", "javascript:ClearHelpText('" + i.ToString() + "', this);");
				}
			}
			if (Session["FedID"] != null)
			{
				if (Session["FedID"].ToString() == "5" || Session["FedID"].ToString() == "72")
				{
					pnlHanukkah.Visible = true;
				}
				else
				{
					pnlHanukkah.Visible = false;
				}

			}

            // 2013-08-25 Synagogue refer by person - the answer from previous question can affect the selection of question on this page
            DataSet dsAnswers = CamperAppl.getCamperAnswers(hdnFJCIDStep2_1.Value, "", "", "1044");
            foreach (DataRow dr in dsAnswers.Tables[0].Rows)
            {
                int qID = Convert.ToInt32(dr["QuestionId"]);
                if (qID == 1044) // Who, if anyone, from your synagogue, did you speak to about Jewish overnight camp?
                {
                    if (dr["OptionID"].Equals(DBNull.Value))
                        continue;

                    var optionID = dr["OptionID"].ToString();
                    if (optionID == "1")
                    {
                        chk16.Checked = true;
                        chk16.Enabled = false;
                    }
                }
            }
		}
	}

	protected void btnNext_Click(object sender, EventArgs e)
	{
		try
		{
			if (Page.IsValid)
			{
				if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_1.Value, Master.CamperUserId))
				{
					InsertCamperAnswers();
				}
				Session["FJCID"] = hdnFJCIDStep2_1.Value;
				if (federationFolderURL != string.Empty)
					//Response.Redirect(federationFolderURL + "Step2_2.aspx");
					Response.Redirect("Step3_Parentinformation.aspx");
				else
					Response.Redirect("~/Error.aspx?app=camper");
			}
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
                InsertCamperAnswers();
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
                if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_1.Value, Master.CamperUserId))
                {
                    InsertCamperAnswers();
                }
                //Session.Abandon();
                //Response.Redirect(strRedirURL);
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
                if (!objGeneral.IsApplicationReadOnly(hdnFJCIDStep2_1.Value, Master.CamperUserId))
                {
                    InsertCamperAnswers();
                }
                Session["FJCID"] = hdnFJCIDStep2_1.Value;
                if (federationFolderURL != string.Empty)
                   //Response.Redirect(federationFolderURL + "Summary.aspx");
                    Response.Redirect(federationFolderURL + "Step2_3.aspx");
                else
                    Response.Redirect("~/Error.aspx?app=camper");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void InsertCamperAnswers()
    {
        string strFJCID, strComments;
        int RowsAffected;
        string strCamperAnswers, strModifiedBy; //-1 for Camper (User id will be passed for Admin user)
        
        strFJCID = hdnFJCIDStep2_1.Value;

        //Modified by id taken from the common.master
        strModifiedBy = Master.UserId;

        //to get the comments (used by the Admin user)
        strComments = txtComments.Text.Trim();

        strCamperAnswers = ConstructCamperAnswers();
        //to check if Campers/Admin have changed the options in marketing section -- Ram
		//#region
		//string strFSeparator;
		//string strQSeparator;
		//string strTablevalues = "";
		//DataSet dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "1", "2", "N");

		////to get the Question separator from Web.config
		//strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
		////to get the Field separator from Web.config
		//strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();
		//for (int i = 0; i < dsAnswers.Tables[0].Rows.Count; i++)
		//{
		//    DataRow dtRow = dsAnswers.Tables[0].Rows[i];
		//    strTablevalues += hdnQ1Id.Value + strFSeparator + dtRow["OptionId"].ToString() + strFSeparator + dtRow["Answer"].ToString() + strQSeparator;
		//}
		////to remove the extra character at the end of the string, if any
		//char[] chartoRemove = { Convert.ToChar(strQSeparator) };
		//strTablevalues = strTablevalues.TrimEnd(chartoRemove);

		//bool bOptionsUpdated = CamperAppl.VerifyCamperAnswersSelectionHasChanged(strCamperAnswers, strTablevalues);
		//#endregion

		//if (strCamperAnswers != "" && strFJCID != "" && strModifiedBy != "" && (bPerformUpdate || bOptionsUpdated))
		//{
		//    RowsAffected = CamperAppl.InsertCamperAnswers(strFJCID, strCamperAnswers, strModifiedBy, strComments);
		//}

        if (strFJCID != "" && strCamperAnswers != "" && strModifiedBy != "" )
            RowsAffected = CamperAppl.InsertCamperAnswers(strFJCID, strCamperAnswers, strModifiedBy, strComments);
    }

    void getCamperAnswers()
    {
        string strFJCID;
        DataSet dsAnswers;
        DataView dv;
        CheckBox cb;
        TextBox tb;
        string strFilter;

        strFJCID = hdnFJCIDStep2_1.Value;
        if (strFJCID.Equals(string.Empty))
        {
			return;
		}

        dsAnswers = CamperAppl.getCamperAnswers(strFJCID, "1035", "1039", "N");
        if (dsAnswers.Tables[0].Rows.Count > 0) //if there are records for the current FJCID
        {
            dv = dsAnswers.Tables[0].DefaultView;

			DataRow[] drs = dv.Table.Select("QuestionID = 1035");
			if (drs.Length == 1)
				ddlWhatYear.Items.FindByValue(drs[0]["OptionID"].ToString()).Selected = true;

			drs = dv.Table.Select("QuestionID = 1036");
			if (drs.Length == 1)
				ddlResearch.Items.FindByValue(drs[0]["OptionID"].ToString()).Selected = true;

			//Question 3
			drs = dv.Table.Select("QuestionID = 1037");
			foreach (DataRow dr in drs)
			{
				if (dr["OptionID"].ToString() == "1")
					chkStaff1.Checked = true;
				if (dr["OptionID"].ToString() == "2")
					chkStaff2.Checked = true;
				if (dr["OptionID"].ToString() == "3")
					chkStaff3.Checked = true;
				if (dr["OptionID"].ToString() == "4")
					chk16.Checked = true;
				if (dr["OptionID"].ToString() == "5")
					chk17.Checked = true;
				if (dr["OptionID"].ToString() == "6")
					chk18.Checked = true;
				if (dr["OptionID"].ToString() == "7")
					chk19.Checked = true;
				if (dr["OptionID"].ToString() == "8")
					chk20.Checked = true;
				if (dr["OptionID"].ToString() == "9")
					chkHearFromAd.Checked = true;
				if (dr["OptionID"].ToString() == "10")
					chk21.Checked = true;
			}

			//Question 3a
			drs = dv.Table.Select("QuestionID = 1038");
			if (drs.Length == 1)
			{
				ToggleTrNames();
				string selectedValue = drs[0]["OptionID"].ToString();
				ddlStaffNames.Items.FindByValue(selectedValue).Selected = true;

				if (selectedValue == "12")
				{
					txtOtherName.Visible = true;
					txtOtherName.Text = drs[0]["Answer"].ToString();
				}
			}

			//Question 3b
			drs = dv.Table.Select("QuestionID = 1039");
			foreach (DataRow dr in drs)
			{
				chkHearFromAd_CheckedChanged(null, null);
				if (dr["OptionID"].ToString() == "1")
					chk22.Checked = true;
				if (dr["OptionID"].ToString() == "2")
					chk23.Checked = true;
				if (dr["OptionID"].ToString() == "3")
					chk24.Checked = true;
				if (dr["OptionID"].ToString() == "4")
					chk25.Checked = true;
				if (dr["OptionID"].ToString() == "5")
					chk26.Checked = true;
				if (dr["OptionID"].ToString() == "6")
					chk27.Checked = true;
				if (dr["OptionID"].ToString() == "7")
					chk28.Checked = true;
			}
        }
    }

    private string ConstructCamperAnswers()
    {
        string strQuestionId = "";
        string strTablevalues = "";
        string strFSeparator;
        string strQSeparator;

        //to get the Question separator from Web.config
        strQSeparator = ConfigurationManager.AppSettings["QuestionSeparator"].ToString();
        //to get the Field separator from Web.config
        strFSeparator = ConfigurationManager.AppSettings["FieldSeparator"].ToString();
        
		//for question 1
		strQuestionId = hdnQ1035WhenToConsider.Value;
		strTablevalues += strQuestionId + strFSeparator + ddlWhatYear.SelectedValue + strFSeparator + ddlWhatYear.SelectedItem.Text + strQSeparator;

		//for question 2
		strQuestionId = hdnQ1036Research.Value;
		strTablevalues += strQuestionId + strFSeparator + ddlResearch.SelectedValue + strFSeparator + ddlResearch.SelectedItem.Text + strQSeparator;

        //for question 3
		strQuestionId = hdnQ1037HowDidYouHearUs.Value;

		if (chkStaff1.Checked)
		{
			strTablevalues += strQuestionId + strFSeparator + "1" + strFSeparator + "Jewish Federation/agency staff member or communication (i.e. e-mail)" + strQSeparator;
		}

		if (chkStaff2.Checked)
		{
			strTablevalues += strQuestionId + strFSeparator + "2" + strFSeparator + "Jewish camp recruiter" + strQSeparator;
		}

		if (chkStaff3.Checked)
		{
			strTablevalues += strQuestionId + strFSeparator + "3" + strFSeparator + "Jewish Community Center (JCC) staff member" + strQSeparator;
		}

        if (chk16.Checked)
        {
			strTablevalues += strQuestionId + strFSeparator + "4" + strFSeparator + "Someone within your temple/synagogue" + strQSeparator;
        }

		if (chk17.Checked)
		{
			strTablevalues += strQuestionId + strFSeparator + "5" + strFSeparator + "PJ Library" + strQSeparator;
		}

		if (chk18.Checked)
		{
			strTablevalues += strQuestionId + strFSeparator + "6" + strFSeparator + "Another child in our family previously received a grant" + strQSeparator;
		}

		if (chk19.Checked)
		{
			strTablevalues += strQuestionId + strFSeparator + "7" + strFSeparator + "Friend or family" + strQSeparator;
		}

		if (chk20.Checked)
		{
			strTablevalues += strQuestionId + strFSeparator + "8" + strFSeparator + "Directly from a camp" + strQSeparator;
		}

		if (chkHearFromAd.Checked)
		{
			strTablevalues += strQuestionId + strFSeparator + "9" + strFSeparator + "Directly from an ad, news article, media, or Facebook" + strQSeparator;
		}

		if (chk21.Checked)
		{
			strTablevalues += strQuestionId + strFSeparator + "10" + strFSeparator + "Other/Don't remember" + strQSeparator;
		}

		// Question 3a
		if (chkStaff1.Checked || chkStaff2.Checked || chkStaff3.Checked)
		{
			strQuestionId = hdnQ1038HowDidYouHearUSA.Value;

			if (ddlStaffNames.SelectedItem.Text == "Other")
			{
				strTablevalues += strQuestionId + strFSeparator + ddlStaffNames.SelectedValue + strFSeparator + txtOtherName.Text + strQSeparator;
			}
			else
			{
				strTablevalues += strQuestionId + strFSeparator + ddlStaffNames.SelectedValue + strFSeparator + ddlStaffNames.SelectedItem.Text + strQSeparator;
			}
		}

		//Question 3b
		if (chkHearFromAd.Checked)
		{
			strQuestionId = hdnQ1038HowDidYouHearUSB.Value;

			if (chk22.Checked)
				strTablevalues += strQuestionId + strFSeparator + "1" + strFSeparator + "A Jewish publication" + strQSeparator;

			if (chk23.Checked)
				strTablevalues += strQuestionId + strFSeparator + "2" + strFSeparator + "A parenting publication" + strQSeparator;

			if (chk24.Checked)
				strTablevalues += strQuestionId + strFSeparator + "3" + strFSeparator + "Your local newspapers" + strQSeparator;

			if (chk25.Checked)
				strTablevalues += strQuestionId + strFSeparator + "4" + strFSeparator + "Facebook ad" + strQSeparator;

			if (chk26.Checked)
				strTablevalues += strQuestionId + strFSeparator + "5" + strFSeparator + "Online ad (not Facebook)" + strQSeparator;

			if (chk27.Checked)
				strTablevalues += strQuestionId + strFSeparator + "6" + strFSeparator + "Poster in public space (e.g. coffee shop, grocery store)" + strQSeparator;

			if (chk28.Checked)
				strTablevalues += strQuestionId + strFSeparator + "7" + strFSeparator + "Other" + strQSeparator;
		}

        if (strTablevalues == "")  //if Q1 is not answered
            strTablevalues += strQuestionId + strFSeparator + strFSeparator + strQSeparator;       

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
            strFJCID = hdnFJCIDStep2_1.Value;
            strCamperAnswers = ConstructCamperAnswers();
            CamperAppl.CamperAnswersServerValidation(strCamperAnswers, strComments, strFJCID, strUserId, (Convert.ToInt32(Redirection_Logic.PageNames.Step2_1)).ToString(), strCamperUserId, out bArgsValid, out bPerform);
            args.IsValid = bArgsValid;
            bPerformUpdate = bPerform;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

	protected void chkStaff_CheckedChanged(object sender, EventArgs e)
	{
		ToggleTrNames();
	}

	private void ToggleTrNames()
	{
		if (chkStaff1.Checked || chkStaff2.Checked || chkStaff3.Checked)
			trNames.Visible = true;
		else
			trNames.Visible = false;
	}

	protected void chkHearFromAd_CheckedChanged(object sender, EventArgs e)
	{
		if (chkHearFromAd.Checked)
		{
			trAds.Visible = true;
		}
		else
		{
			trAds.Visible = false;
		}
	}

	protected void ddlStaffNames_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ddlStaffNames.SelectedItem.Text == "Other")
			txtOtherName.Visible = true;
		else
			txtOtherName.Visible = false;
	}
}
