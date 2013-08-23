using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CIPMSBC;

public partial class Enrollment_Judaea_Summary : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        btnReturnAdmin.Click += new EventHandler(btnReturnAdmin_Click);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string strFedId, strCampId;
        DataSet dsCampContactInfo=new DataSet();
        General objGeneral = new General();
        int resultCampId = 0;
        if (!Page.IsPostBack)
        {
            // 2012-04-01 Two possible scenarios - either the regular summary page, or then camp is full, show the close message
            int FedID = Convert.ToInt32(FederationEnum.Judea);
            string FED_ID = FedID.ToString();
            bool isDisabled = false;
            string[] FedIDs = ConfigurationManager.AppSettings["DisableOnSummaryPageFederations"].Split(',');
            for (int i = 0; i < FedIDs.Length; i++)
            {
                if (FedIDs[i] == FED_ID)
                {
                    isDisabled = true;
                    break;
                }
            }

            if (isDisabled)
            {
                tblDisable.Visible = true;
                tblRegular.Visible = false;
            }
            else
            {
                tblDisable.Visible = false;
                tblRegular.Visible = true;
            }

            if (tblRegular.Visible)
            {
                try
                {
                    strFedId = strCampId = string.Empty;
                    //to set the FedId from the session variable if it is not null
                    //session variable will be set from the camper summary page
                    if (string.IsNullOrEmpty(strFedId) && Session["FEDID"] != null)
                        strFedId = Session["FEDID"].ToString();

                    //Added by Ram
                    /*if (Session["CampID"] != null)
                        strCampId = Session["CampID"].ToString();*/
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
                }
                finally
                {
                    objGeneral = null;
                }
            }
        }
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Step1_NL.aspx");
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (tblRegular.Visible)
            Response.Redirect("Step2_2.aspx");
        else
        {
            Response.Redirect("../Step1_NL.aspx");
        }

    }

    protected void btnReturnAdmin_Click(object sender, EventArgs e)
    {
        string strRedirURL;
        try
        {
            strRedirURL = ConfigurationManager.AppSettings["AdminRedirURL"].ToString();
            Response.Redirect(strRedirURL);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void rptCampContact_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblContactName = (Label)e.Item.FindControl("lblContactName");
            Label lblFederationName = (Label)e.Item.FindControl("lblFederationName");
            HyperLink hprLnkContactEmail = (HyperLink)e.Item.FindControl("hprLnkContactEmail");
            Label lblContactNo = (Label)e.Item.FindControl("lblContactNo");

            DataRowView drView = e.Item.DataItem != null ? (DataRowView)e.Item.DataItem : null;
            if (drView != null)
            {
                if (lblContactName != null)
                    lblContactName.Text = drView.Row["Contact"].ToString();
                if (lblFederationName != null)
                    lblFederationName.Text = drView.Row["Name"].ToString();
                if (hprLnkContactEmail != null)
                {
                    hprLnkContactEmail.NavigateUrl = "mailto:" + drView.Row["Email"].ToString();
                    hprLnkContactEmail.Text = drView.Row["Email"].ToString() + ".";
                }
                if (lblContactNo != null)
                    lblContactNo.Text = drView.Row["Phone"].ToString();
            }
        }
    }
}
