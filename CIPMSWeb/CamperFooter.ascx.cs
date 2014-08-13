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
using System.IO;

public partial class CamperFooter : System.Web.UI.UserControl
{
    private string _sNextURL;
    private string _sPreviousURL;
    private string strZipCode;
    private string strFedId;

    //Added by Ram
    private string strCampId;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
                SetFooterforFederation();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }


    //to set the Footer text based on the zip code entered in step1.aspx
    public void SetFooterforFederation()
    {
        DataSet dsFooterInfo;
        DataRow dr;
        int iCount,resultCampId;
        string strPath;
        General objGeneral = new General();
        string[] PagestobeAllowed = new string[] { "STEP2_1.ASPX", "STEP2_2.ASPX", 
                                                    "STEP2_3.ASPX", "SUMMARY.ASPX", 
                                                    "STEP3_PARENTINFORMATION.ASPX", 
                                                    "STEP3_OTHERINFORMATION.ASPX",
            "THANKYOU.ASPX","CAMPMESSAGE.ASPX","PJLDEFPOPUP.ASPX","TRACKMYSTATUS.ASPX",
            "CAMPEROPTIONS.ASPX","CAMPSEARCH_NEW.ASPX","ACADAMYSUMMARY.ASPX","ACADAMYSTEP2_2.ASPX", 
            "ACADAMYSTEP2_3.ASPX","CLOSEDFEDREDIRECTION.ASPX","NLINTERMEDIATE.ASPX","NYCAMPREDIRECT.ASPX","STEP2_COUPON.ASPX", "STEP2_2_ROUTE_INFO.ASPX", "ENTERLOTTERYINFO.ASPX"};
        resultCampId = 0;

        try
        {
            //to set the FedId from the session variable if it is not null
            //session variable will be set from the camper summary page
            if (string.IsNullOrEmpty(strFedId) && Session["FedId"] != null)
                strFedId = Session["FedId"].ToString();

            if (Request.Path == "/Enrollment/PJL/Step2_2_route_info.aspx" || Request.Path == "/Enrollment/PJL/EnterLotteryInfo.aspx")
                strFedId = ((int)FederationEnum.PJL).ToString();

            //Added by Ram
            if (Session["CampID"] != null)
            {
                Int32.TryParse(Session["CampID"].ToString(), out resultCampId);
            }
            else if (Session["FJCID"] != null)
            {
                DataSet ds = new CamperApplication().getCamperAnswers(Session["FJCID"].ToString(), "10", "10", "N");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow drRow = ds.Tables[0].Rows[0];
                    Int32.TryParse(drRow["Answer"].ToString(), out resultCampId);
                }
            }
            strCampId = resultCampId.ToString();

            if (!string.IsNullOrEmpty(strFedId))
            {
                strPath = Path.GetFileName(Request.Path.ToUpper());

                //to check and implement only for step 2 of the Questionnaire strFedId=="24" || 
                if ( Array.IndexOf(PagestobeAllowed, strPath) >= 0 && Path.GetDirectoryName(Request.Path.ToUpper()).IndexOf("NATIONAL") < 0)
                {
                    //Added by Ram
                    if (string.IsNullOrEmpty(strCampId) || strCampId == "0")
                        dsFooterInfo = objGeneral.GetFederationDetails(strFedId);
                    else
                        dsFooterInfo = objGeneral.GetFederationCampContactDetails(strFedId, strCampId);

                    iCount = dsFooterInfo.Tables[0].Rows.Count;
                    if (iCount > 0)
                    {
                        lblContactText.Visible = true;
                        lblContact.Visible = true;
                        dr = dsFooterInfo.Tables[0].Rows[0];
                        lblFederationName.Text = dr["Name"].ToString();
                        lblContact.Text = dr["Contact"].ToString();
                        lblPhone.Text = dr["Phone"].ToString();
                        lblEmail.Text = dr["Email"].ToString();
                        _sNextURL = dr["NavigationURL"].ToString();
                        lblRedirUrl.Text = _sNextURL;
                        _sPreviousURL = dr["ParentInfoPreviousClickURL"].ToString();
                        lblParentInfoPreviousURL.Text = _sPreviousURL;
                        //Making footer invisible for Federation HGF - Rajesh
                        if (strFedId == "90")
                        {
                            lblContactText.Visible = false;
                            lblContact.Visible = false;
                            Label3.Visible = false;
                            Label4.Visible = false;
                            lblPhone.Visible = false;
                            lblEmail.Visible = false;
                            lblFederationName.Visible = false;
                        }
                        // 2013-09-10 MetroWest name is too long
                        if (strFedId == "10")
                        {
                            // The Partnership for Jewish Learning and Life (Greater MetroWest NJ)
                            lblFederationName.Text = "The Partnership for Jewish Learning <br /> and Life (Greater MetroWest NJ)";
                        }
                    }
                    else
                    {
                        _sNextURL = "";
                        _sPreviousURL = "";
                    }
                }
                else
                {
                    lblContactText.Visible = false;
                    lblContact.Visible = false;
                }
            }
            else
            {
                lblContactText.Visible = false;
                lblContact.Visible = false;
            }
        }
        finally
        {
            objGeneral = null;
            
        }        
    }
    
    //to set the zip code from STep1 of the questionnaire
    public string ZipCode
    {
        get { return strZipCode; }
        set { strZipCode = value; }
    }

    //to set the zip code from STep1 of the questionnaire
    public string FederationId
    {
        get { return strFedId; }
        set { strFedId = value; }
    }

    //to get the btnNext url FOR step 1
    public string NextURL
    {
        get { return _sNextURL; }
    }

    //to get the btnPrevious url FOR Parent Info page
    public string PreviousURL
    {
        get { return _sPreviousURL; }
    }

}
