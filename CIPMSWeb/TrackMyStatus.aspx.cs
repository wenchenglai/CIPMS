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
using System.Text;
using CIPMSBC;

public partial class TrackMyStatus : System.Web.UI.Page
{
    private General objGeneral;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Check whether camper has logged in
        
        HttpCookie authCookie = null;
        if (Session["CamperLoginID"] == null)
            authCookie = Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            //authCookie = FormsAuthentication.GetAuthCookie(FormsAuthentication.FormsCookieName, false);
         if(authCookie != null)
         {
             FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            Session["CamperLoginID"] = ticket.Name;
         }
         else if (Session["CamperLoginID"] == null)
         {
             string redirectURL = "~/Home.aspx" + "?RedirectURL=TrackMyStatus.aspx";
             Response.Redirect(redirectURL);
         }

        string strFJCID = string.Empty;

        if (!IsPostBack)
        {     
            if(!string.IsNullOrEmpty(Request.QueryString["FJCID"]))
            {
                strFJCID = (string)Request.QueryString["FJCID"];
            }
            if(string.IsNullOrEmpty(strFJCID))
            {
                if(Session["FJCID"] != null)
                    strFJCID = (string)Session["FJCID"];
            }
            //strFJCID = "200912290003";
            objGeneral = new General();
            DataSet dsCamperTrackdetails = new DataSet();
            if (!string.IsNullOrEmpty(strFJCID))
            {
                dsCamperTrackdetails = objGeneral.get_CamperStatusDetils(strFJCID);
                if (dsCamperTrackdetails.Tables.Count > 0)
                {
                    if (dsCamperTrackdetails.Tables[0].Rows.Count > 0)
                    {
                        lblFJCID.Text = dsCamperTrackdetails.Tables[0].Rows[0]["FJCID"].ToString();
                        lblCamperName.Text = dsCamperTrackdetails.Tables[0].Rows[0]["CamperName"].ToString();
                        lblCamp.Text = dsCamperTrackdetails.Tables[0].Rows[0]["CampName"].ToString();
                        lblGrnatAmount.Text = string.Format("{0:C}", dsCamperTrackdetails.Tables[0].Rows[0]["GrantAmount"]);

                        var status = (StatusInfo)dsCamperTrackdetails.Tables[0].Rows[0]["StatusID"];
                        switch (status)
                        {
                            case StatusInfo.EligiblePJLottery:
                            case StatusInfo.WinnerPJLottery:
                            case StatusInfo.PendingPJLottery:
                                lblGrnatAmount.Text = "Pending";
                                break;
                            case StatusInfo.IneligiblePJLottery:
                                lblGrnatAmount.Text = "N/A";
                                break;
                        }

                        lblAppicationStatus.Text = dsCamperTrackdetails.Tables[0].Rows[0]["TarckingNote"].ToString();
                        if (Convert.ToBoolean(dsCamperTrackdetails.Tables[0].Rows[0]["IsJWest"]) == false)
                        {
                            lblContactInfo.Text = dsCamperTrackdetails.Tables[0].Rows[0]["ContactName"].ToString();
                            lnkcamper.Visible = false;
                            if (dsCamperTrackdetails.Tables[0].Rows[0]["ContactName"].ToString() == "campgrants@jewishcamp.org")
                            {
                                lblPhone.Visible = false;
                                lblEmail.Visible = false;
                            }
                            else
                            {
                                
                                lblPhone.Text = dsCamperTrackdetails.Tables[0].Rows[0]["Phone"].ToString();
                                lblEmail.Text = dsCamperTrackdetails.Tables[0].Rows[0]["Email"].ToString();
                                lblPhone.Visible = true;
                                lblEmail.Visible = true;
                            }
                        }
                        else
                        {
                            lblPhone.Visible = false;
                            lblEmail.Visible = false;
                            lblContactInfo.Text = dsCamperTrackdetails.Tables[0].Rows[0]["ContactName"].ToString();
                            if (dsCamperTrackdetails.Tables[0].Rows[0]["ContactName"].ToString() == "JWest@jewishcamp.org")
                                lnkcamper.Visible = false;
                            else
                                lnkcamper.Visible = true;
                        }
                    }
                }
            }
            objGeneral = new General();
            DataSet dsFedDetails;
            DataRow drFedDetails;

            dsFedDetails = objGeneral.GetFedDetailsForFJCID(strFJCID);
            if (dsFedDetails.Tables[0].Rows.Count > 0)
            {
                drFedDetails = dsFedDetails.Tables[0].Rows[0];
                Session["FedId"] = drFedDetails["FederationID"].ToString();
            }
            
        }
    }
    protected void btnSaveandExit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                string strRedirURL;
                strRedirURL = Master.SaveandExitURL;
                //Session.Abandon();
                FormsAuthentication.SignOut();
                //Response.Redirect(strRedirURL);
                Response.Redirect(strRedirURL);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/CamperOptions.aspx");
    }
    protected void btnViewapplication_Click(object sender, EventArgs e)
    {
        string strRedirURL = "";
        if (Session["FJCID"] != null)
        {
            DataSet dsCamperApplication;
            DataRow drCA;
            CamperApplication oCA = new CamperApplication();
            dsCamperApplication = oCA.getCamperApplication((string)Session["FJCID"]);
            drCA = dsCamperApplication.Tables[0].Rows[0];
            if (!string.IsNullOrEmpty(drCA["AppType"].ToString()))
            {
                if (drCA["AppType"].ToString() == "D")
                {
                    strRedirURL = "DeleteMessage.aspx";
                }
                else
                    strRedirURL = ConfigurationManager.AppSettings["CamperBasicInfo"].ToString();
            }
            else
            {
                strRedirURL = ConfigurationManager.AppSettings["CamperBasicInfo"].ToString();
            }

            Response.Redirect(strRedirURL);
        }
    }
}
