using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using CIPMSBC;
using DocumentFormat.OpenXml.Math;

public partial class Administration_BulkStatusUpdate : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var msg = Request.QueryString["result"];

            if (msg != "")
                lblMsg.Text = msg;
            else
                lblMsg.Text = "";

            var campYearId = (int)Application["CampYearID"];
            var fedId = (string)Session["FedId"];

            if (fedId != "") {
                lblMsg.Text = "This feature is still under development.";
                btnUpdate.Visible = false;
                return;
            }

            using (var ctx = new CIPMSEntities())
            {
                var data = ctx.tblCampYears.Select(x => new { id = x.ID, text = x.CampYear });
                ddlCampYear.DataSource = data.ToList();
                ddlCampYear.SelectedValue = Application["CampYearID"].ToString();
                ddlCampYear.DataBind();
            }     
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e) 
    {
        if (!chkboxYes.Checked)
        {
            lblMsg.Text = "You must check the confirmation box before you can proceed";
            return;
        }

        if (txtInitials.Text == "")
        {
            lblMsg.Text = "You must enter your initials before you can proceed";
            return;
        }

        bool e_flag = true;
        string campIdList = "";
        //2014-05-12 current from status is always 
        var fromStatusId = -1;
        var toStatusId = -1;
        if (ddlStatusTransition.SelectedValue == "25")
        {
            foreach (ListItem li in chklistCamp.Items)
            {
                if (li.Selected)
                    e_flag = false;

            }

            if (e_flag)
            {
                lblMsg.Text = "You must select at least one camp";
                return;
            }
            else
            {
                fromStatusId = 25;
                toStatusId = 28;
                foreach (ListItem li in chklistCamp.Items)
                {
                    if (li.Selected)
                    {
                        if (campIdList == "")
                            campIdList = li.Value;
                        else
                            campIdList += ", " + li.Value;
                    }
                }                
            }
        } 
        else if (ddlStatusTransition.SelectedValue == "7")
        {
            foreach (ListItem li in rdolistCamp.Items)
            {
                if (li.Selected)
                    e_flag = false;

            }

            if (e_flag)
            {
                lblMsg.Text = "You must select at least one camp";
                return;
            }
            else
            {
                fromStatusId = 7;
                toStatusId = 14;
                foreach (ListItem li in rdolistCamp.Items)
                {
                    if (li.Selected)
                    {
                        if (campIdList == "")
                            campIdList = li.Value;
                        else
                            campIdList += ", " + li.Value;
                    }
                }                
            }
        }
        else
        {
            return;
        }


        int campYearId = int.Parse(ddlCampYear.SelectedValue);
        int fedId = int.Parse(ddlFed.SelectedValue);
        int userId = int.Parse(Session["UsrID"].ToString());

        bool ret = CamperAppDA.BulkUpdateStatus(campYearId, fedId, campIdList, userId, fromStatusId, toStatusId);
        string result = "";
        result = ret ? "Status updated successfully" : "Status updated failed.";
        Response.Redirect("~/Administration/BulkStatusUpdate.aspx?result=" + result);
    }
    protected void ddlFed_SelectedIndexChanged(object sender, EventArgs e)
    {
        gv.Visible = false;
    }
    protected void chklistCamp_DataBound(object sender, EventArgs e)
    {
        if (chklistCamp.Items.Count == 0)
        {
            if (lblMsg.Text == "")
                lblMsg.Text = "The federation has no camp that has the status of Payment Requested";
            chkAllCamps.Enabled = false;
            btnUpdate.Enabled = false;
        }
        else
        {
            lblMsg.Text = "";
            chkAllCamps.Enabled = true;
            btnUpdate.Enabled = true;
        }
    }

    protected void chkrdoCamp_DataBound(object sender, EventArgs e)
    {
        if (rdolistCamp.Items.Count == 0)
        {
            if (lblMsg.Text == "")
                lblMsg.Text = "The federation has no camp that has the status of Payment Requested";
            chkAllCamps.Enabled = false;
            btnUpdate.Enabled = false;
        }
        else
        {
            lblMsg.Text = "";
            chkAllCamps.Enabled = true;
            btnUpdate.Enabled = true;
        }
    }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAllCamps.Checked)
            foreach (ListItem li in chklistCamp.Items)
            {
                li.Selected = true;
            }
        else
            foreach (ListItem li in chklistCamp.Items)
            {
                li.Selected = false;
            }
    }
    protected void ddlStatusTransition_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStatusTransition.SelectedValue == "25")
        {
            pnllistCamps.Visible = true;
            pnlrdoCamps.Visible = false;
            chkboxYes.Text = "Yes, I have cancelled all applications for the selected camps that are no longer eligible for the grant.";
        }
        else
        {
            pnllistCamps.Visible = false;
            pnlrdoCamps.Visible = true;
            chkboxYes.Text = "Yes, I understand that consequence of changing the status from Eligible by Staff to Campership Approved; Payment Pending";
        }
    }
}