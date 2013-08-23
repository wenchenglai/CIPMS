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
		string strStatus;
        string Amt = Convert.ToString(Session["Amount"]);
		if (Amt == "")
			Amt = "0";

        strAmt = " in the amount of $" + Amt ;
        strStatus = Convert.ToString(Session["STATUS"]);
        strFedId = Convert.ToString(Session["FedId"]);

        if (Session["CampID"] != null)
        {
            Int32.TryParse(Session["CampID"].ToString(), out resultCampId);
        }
        else if (Session["FJCID"] != null)
        {
            DataSet dsCamper = new CamperApplication().getCamperAnswers(Session["FJCID"].ToString(), "10", "10", "N");
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

        int iCount;
        DataRow dr;
        DataSet ds = new DataSet();
        DataSet dsSelectedCamp = new DataSet();
        DataSet dsContactDetails = new DataSet();
        DataRow drContact;
        string strDesignation = string.Empty;
        ds = objGeneral.GetFederationDetails(strFedId);
        iCount = ds.Tables[0].Rows.Count;
        pnlInEligibleNonJewish.Visible = false;
        Redirection_Logic _objRedirectionLogic = new Redirection_Logic();
        if (Session["FJCID"] != null)
        {
            //_objRedirectionLogic.FJCID = Session["FJCID"].ToString();
            _objRedirectionLogic.GetNextFederationDetails(Session["FJCID"].ToString());
        }
        if (strStatus == "1" || strStatus == "2" || strStatus == "6" || strStatus=="20" || strStatus == "7")  //20- eligiblenoschoolnocamp
        {
            pnlEligible.Visible = true;
                   
            pnlCommon.Visible = true;
            pnlInEligible.Visible = false;
            pnlRamah.Visible = false;
            if (strStatus == "1") //Status 1A (Appears to be eligible and indicated a camp)
            {
                if (strFedId != "3")
                {
                    pnlStatus1A.Visible = true;
                }
                pnlStatus1B.Visible = false;
                pnlStatus1F.Visible = false;
            }
            if (strStatus == "2") //Status 1B (Appears to be eligible, but "No Camp" selected)
            {
                pnlStatus1A.Visible = false;
                pnlStatus1B.Visible = true;
                pnlStatus1F.Visible = false;
            }
            if (strStatus == "6") //Status 1F (Appears to be eligible, but pending - School Eligibility)
            {
                pnlStatus1A.Visible = false;
                pnlStatus1B.Visible = false;
                pnlStatus1F.Visible = true;
            }

            if (strStatus == "20") //Status 1G (Appears to be eligible, but No School, No Camp)
            {
                //pnlStatus1A.Visible = false;
                //pnlStatus1B.Visible = false;
                //pnlStatus1F.Visible = true;
                pnlStatus1G.Visible = true;
            }
                      
            if (iCount > 0)
            {               
                dr = ds.Tables[0].Rows[0];
              
                if (strFedId == "60" || strFedId == "7" || strFedId == "26" || strFedId == "62" || strFedId =="66")
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

            if (lblFed1.Text.ToString().Trim().ToLower() == "national ramah commission")
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
                    //lblFedSelected.Visible = false;
                    //lblContacrPersionSelected.Visible = false;
                    //lblPhoneSelected.Visible = false;
                    //lblEmail1Selected.Visible = false;
                    //lblDesignationSelected.Visible = false;
                }
            }
        }
        else if (((strStatus == "3" || strStatus == "17")) && !_objRedirectionLogic.BeenToPJL)//(Session["LastFed"].ToString() != "PJL")) //Status 1C (InEligible) OR Status 4D (Camper declined to go to camp)
        {
            pnlEligible.Visible = false;
            pnlInEligible.Visible = true;
            if (iCount > 0)
            {
                dr = ds.Tables[0].Rows[0];
                //if (strFedId == "7")
                //{
                //    lblContactPerson2.Text = "Lisa David";
                //    lblFed2.Text = dr["Name"].ToString();
                //    strDesignation = "Associate Director of Camping";
                //    if (!string.IsNullOrEmpty(strDesignation))
                //        lblDesignation2.Text = ", " + strDesignation;
                //    else
                //        lblDesignation2.Text = strDesignation;
                //    lblPhone2.Text = "212-650-4078";
                //    lblEmail2.Text = "Ldavid@urj.org";
                //}
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
            if (lblFed2.Text.ToString().Trim().ToLower() == "national ramah commission")
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
                    //lblDesignation2.Text = strDesignation;
                    //lblFed2.Visible = false;
                    //lblDesignation2.Visible = false;
                    //lblEmail2.Visible = false;
                    //lblPhone2.Visible = false;
                    //lblContactPerson2.Visible = false;
                }
            }
        }
        else if (strStatus == "3nonjewish")
        {
            pnlEligible.Visible = false;
            pnlInEligible.Visible = false;
            pnlInEligibleNonJewish.Visible = true;
        }
        else if ((strStatus == "3") && _objRedirectionLogic.BeenToPJL)//(Session["LastFed"].ToString() == "PJL"))
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
            //Email2.HRef = "mailto:" + Label12.Text;

            //Label9.Text = "Rachel Kaplan";
            //strDesignation = "UJA Federation of New York, Campership Coordinator";
            //if (!string.IsNullOrEmpty(strDesignation))
            //    Label10.Text =strDesignation;
            //else
            //    Label10.Text = strDesignation;
            //Label11.Text = "212-836-1291";
            //Label12.Text = "campership@ujafedny.org";
        }
        else if ((strStatus == "36") && _objRedirectionLogic.BeenToPJL)//(Session["LastFed"].ToString().Contains("PJL")))
        {
            pnlStatus1A.Visible = false;
            pnlStatus1B.Visible = false;
            pnlStatus1F.Visible = false;
            pnlStatus1G.Visible = false;
            PnlPJL.Visible = true;
            pnlEligible.Visible = true;
            pnlCommon.Visible = false;

            //Label15.Text = "Kirstin Gadiel";
            //Label16.Text = "(413)-439-1968";
            //Label17.Text = "kirstin@hgf.org";
            strStatus = "36";

        }
    }

    protected void lnkCopyApp_Click(object sender, EventArgs e)
    {
        CamperApplication CamperAppl = new CamperApplication();
        string newFJCID;
        int nextFederationId;
        int retVal;
        char ch = ',';
        string[] UrlData = new string[3];
        string nxtUrlVal = string.Empty;

        //Ram -- New redirection logic
        if (Session["FJCID"] != null)
        {
            Redirection_Logic _objRedirectionLogic = new Redirection_Logic();
            //_objRedirectionLogic.FJCID = Session["FJCID"].ToString();
            
            //usp_DeleteCamperAnswerUsingFJCID
            CamperAppl.CopyCamperApplication(Session["FJCID"].ToString(), out newFJCID);
            _objRedirectionLogic.PageName = (int)Redirection_Logic.PageNames.ThankYou;// Added this flag to avoid confusion of setting federation id if new app is created and set the newfederationid =0
            _objRedirectionLogic.GetNextFederationDetails(Session["FJCID"].ToString());
            nextFederationId = _objRedirectionLogic.NextFederationId;

            if ((nextFederationId == 72 || nextFederationId == 93) && !String.IsNullOrEmpty(newFJCID))
                CamperAppl.DeleteCamperAnswerUsingFJCID(newFJCID);

            if (nextFederationId == 0)
                Session["FEDID"] = null;
            else
                Session["FEDID"] = nextFederationId.ToString();
            
            Session["FJCID"] = newFJCID;
            Session["STATUS"] = 5;

            Session["Amount"] = null;
            CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), nextFederationId.ToString());

            Response.Redirect(_objRedirectionLogic.NextFederationURL);
        }
        

        //Existing redirection logic
        //if (Session["LastFed"] != null && Session["LastFed"].ToString() == "JWest")           
        //    retVal = CamperAppl.CopyCamperApplicationWithoutCamperAnswers(Session["FJCID"].ToString(), out newFJCID);
        //else
        //    retVal = CamperAppl.CopyCamperApplication(Session["FJCID"].ToString(), out newFJCID);

        //nxtUrlVal = CamperAppl.CheckEligibility(newFJCID, Session["LastFed"].ToString(),Session["CampYear"].ToString());
        //// reset the session values -- new values will set again in national landing page
        //UrlData = nxtUrlVal.Split(ch);
        //if (UrlData[1].ToString() == "")
        //    Session["FEDID"] = null;
        //else
        //    Session["FEDID"] = UrlData[1].ToString();

        //if (Session["FEDID"] != null)
        //    strFedId = Session["FEDID"].ToString();
        //else
        //    strFedId = null;
        
        //Session["FJCID"] = newFJCID;
        //Session["STATUS"] = 5;

        //Session["Amount"] = null;
        
        //if(UrlData[0].ToString().Contains("MIIP"))  Session["LastFed"]=Session["LastFed"]+"MidWest";
        //if (UrlData[0].ToString().Contains("PJL")) Session["LastFed"] = Session["LastFed"] + "PJL";

        //CamperAppl.UpdateFederationId(Session["FJCID"].ToString(), strFedId);

        //// Redirect to nation landing page
        //Response.Redirect(UrlData[0].ToString());

    }
}
