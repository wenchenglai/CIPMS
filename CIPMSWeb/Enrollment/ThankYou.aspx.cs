using System;
using System.Data;
using CIPMSBC;

public partial class Enrollment_ThankYou : System.Web.UI.Page
{
    protected string strAmt;
    protected string strOrganisation;
    private General objGeneral = new General();
    protected string strRenameOrganisation = string.Empty;
    private int resultCampId;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            strAmt = " in the amount of $" + GetGrantAmount();
            var strStatus = (StatusInfo) Convert.ToInt32(Session["STATUS"]);
            var strFedId = Session["FedId"].ToString();
            var strCampId = GetCampID();

            DataRow dr;
            DataSet dsSelectedCamp = new DataSet();
            DataSet dsContactDetails = new DataSet();
            DataRow drContact;
            string strDesignation = string.Empty;
            DataSet ds = objGeneral.GetFederationDetails(strFedId);
            int iCount = ds.Tables[0].Rows.Count;
            pnlInEligibleNonJewish.Visible = false;
            var objRedirectionLogic = new Redirection_Logic();

            if (Session["FJCID"] != null)
            {
                objRedirectionLogic.GetNextFederationDetails(Session["FJCID"].ToString());
            }

            if (strStatus == StatusInfo.SystemEligible ||
                strStatus == StatusInfo.EligibleNoCamp ||
                strStatus == StatusInfo.EligiblePendingSchool ||
                strStatus == StatusInfo.PendingSchoolAndCamp ||
                strStatus == StatusInfo.EligibleByStaff ||
                strStatus == StatusInfo.EligibleCampCoupon) //20- eligiblenoschoolnocamp
            {
                MarkSpecialCodeUsed(Int32.Parse(strFedId));
                EligibleHandler(strStatus, strFedId, strCampId, ds);
            }
            else if (strStatus == StatusInfo.EligiblePendingNumberOfDays)
            {
                MarkSpecialCodeUsed(Int32.Parse(strFedId));
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
            else if (((strStatus == StatusInfo.SystemInEligible || strStatus == StatusInfo.CamperDeclinedToGoToCamp)) &&
                     !objRedirectionLogic.BeenToPJL)
            {
                pnlEligible.Visible = false;
                pnlInEligible.Visible = true;
                if (iCount > 0)
                {
                    dr = ds.Tables[0].Rows[0];

                    if (strFedId == "60" || strFedId == "7" || strFedId == "26" || strFedId == "62" ||
                        strFedId == "66")
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
            else if ((strStatus == StatusInfo.SystemInEligible) && objRedirectionLogic.BeenToPJL)
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
            else if ((strStatus == StatusInfo.PendingValidation) && objRedirectionLogic.BeenToPJL)
            {
                pnlStatus1A.Visible = false;
                pnlStatus1B.Visible = false;
                pnlStatus1F.Visible = false;
                pnlStatus1G.Visible = false;
                PnlPJL.Visible = true;
                pnlEligible.Visible = true;
                pnlCommon.Visible = false;
            }
        }
    }

    private string GetGrantAmount()
    {
        var amount = "";
        if (Session["FJCID"] != null)
        {
            var CamperAppl = new CamperApplication();
            DataSet dsTerms = CamperAppl.getCamperApplication(Session["FJCID"].ToString());
            if (dsTerms.Tables[0].Rows.Count > 0)
            {
                DataRow dr1 = dsTerms.Tables[0].Rows[0];
                if (dr1["Amount"] != null)
                    amount = dr1["Amount"].ToString();
            }
        }
        return amount;
    }

    private string GetCampID()
    {
        string campId = "";
        if (Session["CampID"] != null)
        {
            campId = Session["CampID"].ToString();
        }
        else if (Session["FJCID"] != null)
        {
            var dsCamper = new CamperApplication().getCamperAnswers(Session["FJCID"].ToString(), "10", "10", "N");
            if (dsCamper.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow drRow in dsCamper.Tables[0].Rows)
                {
                    if (!String.IsNullOrEmpty(drRow["OptionID"].ToString()))
                        if (drRow["OptionID"].ToString() == "2")
                            campId = drRow["Answer"].ToString();
                }
            }
        }
        return campId;
    }

    // 2014-07-28 We only mark the special code as used ONLY when an application is completed successfully
    // Once it's used successfully, nobody else can use it, including the original owner.
    private void MarkSpecialCodeUsed(int fedId)
    {
        if (Session["UsedCode"] != null)
        {
            string currentCode = Session["UsedCode"].ToString();
            int campYearId = Convert.ToInt32(Application["CampYearID"]);
            SpecialCodeManager.UseCode(campYearId, fedId, currentCode, Session["FJCID"].ToString());
        }        
    }

    private void EligibleHandler(StatusInfo status, string fedId, string campId, DataSet dsFedDetails)
    {
        pnlEligible.Visible = true;
        pnlCommon.Visible = true;
        pnlInEligible.Visible = false;
        pnlRamah.Visible = false;

        if (status == StatusInfo.SystemEligible) //Status 1A (Appears to be eligible and indicated a camp)
        {
            if (fedId != "3")
            {
                pnlStatus1A.Visible = true;
            }
            pnlStatus1B.Visible = false;
            pnlStatus1F.Visible = false;
        }
        else if (status == StatusInfo.EligibleNoCamp)
        //Status 1B (Appears to be eligible, but "No Camp" selected)
        {
            pnlStatus1A.Visible = false;
            pnlStatus1B.Visible = true;
            pnlStatus1F.Visible = false;
        }
        else if (status == StatusInfo.EligiblePendingSchool)
        //Status 1F (Appears to be eligible, but pending - School Eligibility)
        {
            pnlStatus1A.Visible = false;
            pnlStatus1B.Visible = false;
            pnlStatus1F.Visible = true;
        }
        else if (status == StatusInfo.PendingSchoolAndCamp)
        //Status 1G (Appears to be eligible, but No School, No Camp)
        {
            pnlStatus1G.Visible = true;
        }
        else if (status == StatusInfo.EligibleCampCoupon)
        {
            lblCouponSub.Text = "a Camp Coupon";
            lblCouponText.Visible = true;
        }

        int iCount = dsFedDetails.Tables[0].Rows.Count;
        if (iCount > 0)
        {
            var dr = dsFedDetails.Tables[0].Rows[0];

            // 2014-03-03 Chicago Elibigle-coupon status has special contact info
            if (fedId == "9" && status == StatusInfo.EligibleCampCoupon)
            {
                lblFed1.Text = "JUF CHICAGO";
                lblContactPerson1.Text = "Lyndsey Yeary";
                lblPhone1.Text = "312-357-4798";
                lblEmail1.Text = "LyndseyYeary@juf.org";
                Email.HRef = "mailto:" + lblEmail1.Text;
            }
            else if (fedId == "60" || fedId == "7" || fedId == "26" || fedId == "62" || fedId == "66")
            {
                var dsContactDetails = objGeneral.GetFederationCampContactDetails(fedId, campId);
                DataRow drContact = dsContactDetails.Tables[0].Rows[0];
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
                strOrganisation = dr["Name"].ToString();
                strOrganisation = strOrganisation.Trim();
                lblFed1.Text = strOrganisation.Trim();
                lblPhone1.Text = dr["Phone"].ToString();
                lblEmail1.Text = dr["Email"].ToString();
                Email.HRef = "mailto:" + lblEmail1.Text;
            }

        }

        if (lblFed1.Text.Trim().ToLower() == "national ramah commission")
        {
            pnlCommon.Visible = false;
            pnlRamah.Visible = true;
            strRenameOrganisation =
                strOrganisation.Replace("National", string.Empty).Replace("Commission", "camp").Trim();
            DataSet dsSelectedCamp = objGeneral.GetFederationCampContactDetails(fedId, campId);
            if (dsSelectedCamp.Tables[0].Rows.Count > 0)
            {
                lblFedSelected.Text = dsSelectedCamp.Tables[0].Rows[0]["Name"].ToString();
                lblContacrPersionSelected.Text = dsSelectedCamp.Tables[0].Rows[0]["Contact"].ToString();
                lblPhoneSelected.Text = dsSelectedCamp.Tables[0].Rows[0]["Phone"].ToString();
                lblEmail1Selected.Text = dsSelectedCamp.Tables[0].Rows[0]["Email"].ToString();
                Email1Selected.HRef = "mailto:" + lblEmail1Selected.Text;
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
