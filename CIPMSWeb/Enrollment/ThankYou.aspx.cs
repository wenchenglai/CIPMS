using System;
using System.Data;
using CIPMSBC;

public partial class Enrollment_ThankYou : System.Web.UI.Page
{
    protected string strAmt;
    protected string strOrganisation;
    private string strFedId;
    private General objGeneral = new General();
    protected string strRenameOrganisation = string.Empty;
    private int resultCampId;
    private string strCampId = string.Empty;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string Amt = "0";

        if (Session["FJCID"] != null)
        {
            string strFJCID = Session["FJCID"].ToString();
            var CamperAppl = new CamperApplication();
            DataSet dsTerms = CamperAppl.getCamperApplication(strFJCID);
            if (dsTerms.Tables[0].Rows.Count > 0)
            {
                DataRow dr1 = dsTerms.Tables[0].Rows[0];
                if (dr1["Amount"] != null)
                    Amt = dr1["Amount"].ToString();
            }
        }

        strAmt = " in the amount of $" + Amt ;
        StatusInfo strStatus = (StatusInfo)Convert.ToInt32(Session["STATUS"]);
        strFedId = Convert.ToString(Session["FedId"]);

        if (Session["CampID"] != null)
        {
            Int32.TryParse(Session["CampID"].ToString(), out resultCampId);
        }
        else if (Session["FJCID"] != null)
        {
            string strFJCID = Session["FJCID"].ToString();
            DataSet dsCamper = new CamperApplication().getCamperAnswers(strFJCID, "10", "10", "N");
            if (dsCamper.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow drRow in dsCamper.Tables[0].Rows)
                {
                    if (!String.IsNullOrEmpty(drRow["OptionID"].ToString()))
                        if (drRow["OptionID"].ToString() == "2")
							Int32.TryParse(drRow["Answer"].ToString(), out resultCampId);
                }
            }
        }
        strCampId = resultCampId.ToString();

        DataRow dr;
        DataSet dsSelectedCamp = new DataSet();
        DataSet dsContactDetails = new DataSet();
        DataRow drContact;
        string strDesignation = string.Empty;
        DataSet ds = objGeneral.GetFederationDetails(strFedId);
        int iCount = ds.Tables[0].Rows.Count;
        pnlInEligibleNonJewish.Visible = false;
        Redirection_Logic _objRedirectionLogic = new Redirection_Logic();
        if (Session["FJCID"] != null)
        {
            //_objRedirectionLogic.FJCID = Session["FJCID"].ToString();
            _objRedirectionLogic.GetNextFederationDetails(Session["FJCID"].ToString());
        }

        if (strStatus == StatusInfo.SystemEligible || 
            strStatus == StatusInfo.EligibleNoCamp || 
            strStatus == StatusInfo.EligiblePendingSchool || 
            strStatus == StatusInfo.PendingSchoolAndCamp || 
            strStatus == StatusInfo.EligibleByStaff ||
            strStatus == StatusInfo.EligibleCampCoupon)  //20- eligiblenoschoolnocamp
        {
            pnlEligible.Visible = true;
                   
            pnlCommon.Visible = true;
            pnlInEligible.Visible = false;
            pnlRamah.Visible = false;
            if (strStatus == StatusInfo.SystemEligible) //Status 1A (Appears to be eligible and indicated a camp)
            {
                if (strFedId != "3")
                {
                    pnlStatus1A.Visible = true;
                }
                pnlStatus1B.Visible = false;
                pnlStatus1F.Visible = false;
            }
            else if (strStatus == StatusInfo.EligibleNoCamp) //Status 1B (Appears to be eligible, but "No Camp" selected)
            {
                pnlStatus1A.Visible = false;
                pnlStatus1B.Visible = true;
                pnlStatus1F.Visible = false;
            }
            else if (strStatus == StatusInfo.EligiblePendingSchool) //Status 1F (Appears to be eligible, but pending - School Eligibility)
            {
                pnlStatus1A.Visible = false;
                pnlStatus1B.Visible = false;
                pnlStatus1F.Visible = true;
            }
            else if (strStatus == StatusInfo.PendingSchoolAndCamp) //Status 1G (Appears to be eligible, but No School, No Camp)
            {
                pnlStatus1G.Visible = true;
            }
            else if (strStatus == StatusInfo.EligibleCampCoupon)
            {
                lblCouponSub.Text = "a Camp Coupon";
                lblCouponText.Visible = true;
            }
                      
            if (iCount > 0)
            {               
                dr = ds.Tables[0].Rows[0];
              
                // 2014-03-03 Chicago Elibigle-coupon status has special contact info
                if (strFedId == "9")
                {
                    lblFed1.Text = "JUF CHICAGO";
                    lblContactPerson1.Text = "Lyndsey Yeary";
                    lblPhone1.Text = "312-357-4798";
                    lblEmail1.Text = "LyndseyYeary@juf.org";
                    Email.HRef = "mailto:" + lblEmail1.Text;
                }
                else if (strFedId == "60" || strFedId == "7" || strFedId == "26" || strFedId == "62" || strFedId =="66")
                {
                    dsContactDetails = objGeneral.GetFederationCampContactDetails(strFedId, strCampId);
                    drContact = dsContactDetails.Tables[0].Rows[0];
                    strOrganisation = drContact["Name"].ToString();
                    strOrganisation = strOrganisation.Trim();
                    lblFed1.Text = drContact["Name"].ToString(); 
                    lblContactPerson1.Text = drContact["Contact"].ToString();
                    lblPhone1.Text = drContact["Phone"].ToString();
                    lblEmail1.Text = drContact["Email"].ToString();
                    Email.HRef = "mailto:" + lblEmail1.Text;
                }
                else
                {
                     lblContactPerson1.Text = dr["Contact"].ToString();
                    //lblFed1.Text = dr["Name"].ToString();
                    strOrganisation = dr["Name"].ToString();
                    strOrganisation = strOrganisation.Trim();
                    lblFed1.Text = strOrganisation.Trim();
                    lblPhone1.Text = dr["Phone"].ToString();
                    lblEmail1.Text = dr["Email"].ToString();
                    Email.HRef = "mailto:"+lblEmail1.Text;

                    if ((strCampId == "1138") && ((Convert.ToInt32(Session["SynagogueID"])) == 1221))
                    {
                        pTempleIsrael.Visible = true;
                    }
                }

            }

            if (lblFed1.Text.Trim().ToLower() == "national ramah commission")
            {
                pnlCommon.Visible = false;
                pnlRamah.Visible = true;
                strRenameOrganisation = strOrganisation.Replace("National", string.Empty).Replace("Commission", "camp").Trim();
                dsSelectedCamp = objGeneral.GetFederationCampContactDetails(strFedId, strCampId);
                if (dsSelectedCamp.Tables[0].Rows.Count > 0)
                {
                    lblFedSelected.Text = dsSelectedCamp.Tables[0].Rows[0]["Name"].ToString();
                    lblContacrPersionSelected.Text = dsSelectedCamp.Tables[0].Rows[0]["Contact"].ToString();
                    lblPhoneSelected.Text = dsSelectedCamp.Tables[0].Rows[0]["Phone"].ToString();
                    lblEmail1Selected.Text = dsSelectedCamp.Tables[0].Rows[0]["Email"].ToString();
                    Email1Selected.HRef = "mailto:" + lblEmail1Selected.Text;
                    if (!string.IsNullOrEmpty(strDesignation))
                    lblDesignationSelected.Text = ", " + strDesignation;
                }
            }
        }
        else if (((strStatus == StatusInfo.SystemInEligible || strStatus == StatusInfo.CamperDeclinedToGoToCamp)) && !_objRedirectionLogic.BeenToPJL)
        {
            pnlEligible.Visible = false;
            pnlInEligible.Visible = true;
            if (iCount > 0)
            {
                dr = ds.Tables[0].Rows[0];

                if (strFedId == "60" || strFedId == "7" || strFedId == "26" || strFedId == "62" || strFedId =="66")
                {
                    dsContactDetails = objGeneral.GetFederationCampContactDetails(strFedId, strCampId);
                    drContact = dsContactDetails.Tables[0].Rows[0];
                    lblFed2.Text = drContact["Name"].ToString(); 
                    lblContactPerson2.Text = drContact["Contact"].ToString();
                    lblPhone2.Text = drContact["Phone"].ToString();
                    lblEmail2.Text = drContact["Email"].ToString();
                    Email2.HRef = "mailto:" + lblEmail2.Text;
                }
                else
                {
                    lblContactPerson2.Text = dr["Contact"].ToString();
                    lblFed2.Text = dr["Name"].ToString();
                    strDesignation = dr["Designation"].ToString();
                    if (!string.IsNullOrEmpty(strDesignation))
                        lblDesignation2.Text = ", " + strDesignation;
                    else
                        lblDesignation2.Text = strDesignation;
                    lblPhone2.Text = dr["Phone"].ToString();
                    lblEmail2.Text = dr["Email"].ToString();
                    Email2.HRef = "mailto:" + lblEmail2.Text;
                }
            }
            if (lblFed2.Text.Trim().ToLower() == "national ramah commission")
            {
                dsSelectedCamp = objGeneral.GetFederationCampContactDetails(strFedId, strCampId);
                if (dsSelectedCamp.Tables[0].Rows.Count > 0)
                {
                    lblFed2.Text = dsSelectedCamp.Tables[0].Rows[0]["Name"].ToString();
                    lblContactPerson2.Text = dsSelectedCamp.Tables[0].Rows[0]["Contact"].ToString();
                    lblPhone2.Text = dsSelectedCamp.Tables[0].Rows[0]["Phone"].ToString();
                    lblEmail2.Text = dsSelectedCamp.Tables[0].Rows[0]["Email"].ToString();
                    Email2.HRef = "mailto:" + lblEmail2.Text;
                    if (!string.IsNullOrEmpty(strDesignation))
                        lblDesignation2.Text = ", " + strDesignation;
                }
            }
        }
        else if (strStatus == StatusInfo.NonJewish)
        {
            pnlEligible.Visible = false;
            pnlInEligible.Visible = false;
            pnlInEligibleNonJewish.Visible = true;
        }
        else if ((strStatus == StatusInfo.SystemInEligible) && _objRedirectionLogic.BeenToPJL)//(Session["LastFed"].ToString() == "PJL"))
        {
            pnlEligible.Visible = false;
            pnlInEligible.Visible = false;
            PanelInEligiblePJL.Visible = true;

            dsContactDetails = objGeneral.GetFederationCampContactDetails(strFedId, strCampId);
            drContact = dsContactDetails.Tables[0].Rows[0];
            Label9.Text = drContact["Name"].ToString();
            Label10.Text = drContact["Contact"].ToString();
            Label11.Text = drContact["Phone"].ToString();
            Label12.Text = drContact["Email"].ToString();
        }
        else if ((strStatus == StatusInfo.PendingValidation) && _objRedirectionLogic.BeenToPJL)//(Session["LastFed"].ToString().Contains("PJL")))
        {
            pnlStatus1A.Visible = false;
            pnlStatus1B.Visible = false;
            pnlStatus1F.Visible = false;
            pnlStatus1G.Visible = false;
            PnlPJL.Visible = true;
            pnlEligible.Visible = true;
            pnlCommon.Visible = false;
        }
        else if (strStatus == StatusInfo.EligiblePendingNumberOfDays)
        {
            pnlEligiblePendingNumberOfDays.Visible = true;

            if (iCount <= 0) return;

            dr = ds.Tables[0].Rows[0];

            if (strFedId == "60" ||
                strFedId == "7" ||
                strFedId == "26" ||
                strFedId == "62" ||
                strFedId == "66")
            {
                dsContactDetails = objGeneral.GetFederationCampContactDetails(strFedId, strCampId);
                drContact = dsContactDetails.Tables[0].Rows[0];
                strOrganisation = drContact["Name"].ToString();
                strOrganisation = strOrganisation.Trim();
                lblFed3.Text = drContact["Name"].ToString();
                lblContactPerson3.Text = drContact["Contact"].ToString();
                lblPhone3.Text = drContact["Phone"].ToString();
                lblEmail3.Text = drContact["Email"].ToString();
                Email3.HRef = "mailto:" + lblEmail1.Text;
            }
            else
            {
                lblContactPerson3.Text = dr["Contact"].ToString();
                strOrganisation = dr["Name"].ToString();
                strOrganisation = strOrganisation.Trim();
                lblFed3.Text = strOrganisation.Trim();
                lblPhone3.Text = dr["Phone"].ToString();
                lblEmail3.Text = dr["Email"].ToString();
                Email3.HRef = "mailto:" + lblEmail1.Text;
            }
        }
    }

    protected void lnkCopyApp_Click(object sender, EventArgs e)
    {
        var camperAppl = new CamperApplication();
        
        var redirectionLogic = new Redirection_Logic();

        string newFJCID;
        camperAppl.CopyCamperApplication(Session["FJCID"].ToString(), out newFJCID);
        redirectionLogic.PageName = (int)Redirection_Logic.PageNames.ThankYou;// Added this flag to avoid confusion of setting federation id if new app is created and set the newfederationid =0
        redirectionLogic.GetNextFederationDetails(Session["FJCID"].ToString());
        int nextFederationId = redirectionLogic.NextFederationId;

        if ((nextFederationId == 72 || nextFederationId == 93) && !String.IsNullOrEmpty(newFJCID))
            camperAppl.DeleteCamperAnswerUsingFJCID(newFJCID);

        if (nextFederationId == 0)
            Session["FEDID"] = null;
        else
            Session["FEDID"] = nextFederationId.ToString();
            
        Session["FJCID"] = newFJCID;
        Session["STATUS"] = 5;

        camperAppl.UpdateFederationId(Session["FJCID"].ToString(), nextFederationId.ToString());

        // 2013-10-31 we must delete the codeValue Session variable 
        if (redirectionLogic.BeenToPJL)
            Session["codeValue"] = null;

        Response.Redirect(redirectionLogic.NextFederationURL);
    }
}
