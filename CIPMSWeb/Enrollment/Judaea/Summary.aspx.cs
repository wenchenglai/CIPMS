using System;
using System.Data;
using System.Configuration;
using System.Linq;
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

        var objGeneral = new General();
 
        if (!IsPostBack)
        {
            // 2012-04-01 Two possible scenarios - either the regular summary page, or then camp is full, show the close message
            int FedID = Convert.ToInt32(FederationEnum.Judea);
            string FED_ID = FedID.ToString();
            bool isDisabled = ConfigurationManager.AppSettings["DisableOnSummaryPageFederations"].Split(',').Any(x => x == FED_ID);

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

            //if (tblRegular.Visible)
            //{
            //    try
            //    {
            //        strFedId = strCampId = string.Empty;
            //        //to set the FedId from the session variable if it is not null
            //        //session variable will be set from the camper summary page
            //        if (string.IsNullOrEmpty(strFedId) && Session["FEDID"] != null)
            //            strFedId = Session["FEDID"].ToString();

            //        //Added by Ram
            //        /*if (Session["CampID"] != null)
            //            strCampId = Session["CampID"].ToString();*/
            //        if (Session["CampID"] != null)
            //        {
            //            Int32.TryParse(Session["CampID"].ToString(), out resultCampId);
            //        }
            //        else if (Session["FJCID"] != null)
            //        {
            //            DataSet ds = new CamperApplication().getCamperAnswers(Session["FJCID"].ToString(), "10", "10", "N");
            //            if (ds.Tables[0].Rows.Count > 0)
            //            {
            //                DataRow drRow = ds.Tables[0].Rows[0];
            //                Int32.TryParse(drRow["Answer"].ToString(), out resultCampId);
            //            }
            //        }
            //        strCampId = resultCampId.ToString();
            //    }
            //    finally
            //    {
            //        objGeneral = null;
            //    }
            //}

            //int resultCampId = 0;
            //Int32.TryParse(Session["CampID"].ToString(), out resultCampId);

            string campID = Session["CampID"].ToString();
            string last3Digits = campID.Substring(campID.Length - 3);
            // Disable camps will overwrite above code
            switch (last3Digits)
            {
                case "107":
                    lblDisable.Text = "The Young Judaea-Texas One Happy Camper application is now closed for the summer of 2014. For information about a waiting list, please contact the camp professional listed at the bottom of the screen.";
                    tblDisable.Visible = true;
                    tblRegular.Visible = false;

                    if (Session["UsedCode"] != null)
                    {
                        string currentCode = Session["UsedCode"].ToString();
                        int CampYearID = Convert.ToInt32(Application["CampYearID"]);

                        if (SpecialCodeManager.GetAvailableCodesPerCamp(CampYearID, FedID, Int32.Parse(campID)).Any(x => x == currentCode))
                        {
                            tblDisable.Visible = false;
                            tblRegular.Visible = true;
                        }
                    }

                    break;
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
