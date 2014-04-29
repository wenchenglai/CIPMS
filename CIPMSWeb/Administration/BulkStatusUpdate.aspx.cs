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
            lblMsg.Text = "";
            var campYearId = (int)Application["CampYearID"];
            var fedId = (string)Session["FedID"];

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

            //var objGen = new General();
            //DataSet dsFed = objGen.get_AllFederations();
            //ddlFed.DataSource = dsFed;
            //ddlFed.DataTextField = "Federation";
            //ddlFed.DataValueField = "ID";
            //ddlFed.DataBind();
            //if ((ddlFed.Items.Count != 0))
            //    ddlFed.Items.Insert(0, new ListItem("--Select--", "-1"));            
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e) 
    {
        var campId = ddlCamp.SelectedValue;
        lblMsg.Text = "Status changed for all Campers from " + ddlCamp.SelectedItem.Text;

    }
    protected void ddlFed_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}