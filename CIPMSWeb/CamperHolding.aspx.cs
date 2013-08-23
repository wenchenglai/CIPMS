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

public partial class CamperHolding : System.Web.UI.Page
{
    private CamperApplication _objCamperApp;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            General objGeneral = new General();
            DataSet dsCamps = objGeneral.get_AllCamps(Application["CampYear"].ToString());
            ddlCamp.DataSource = dsCamps;
            ddlCamp.DataTextField = "Camp";
            ddlCamp.DataValueField = "ID";
            ddlCamp.DataBind();
            ddlCamp.Items.Insert(0, new ListItem("-- Select --", "0"));

            DataSet schoolTypes = objGeneral.GetSchoolType();
            ddlSchoolType.DataSource = schoolTypes;
            ddlSchoolType.DataBind();
            ddlSchoolType.Items.Insert(0, new ListItem("-- Select --", "0"));

            txtCamp.Enabled = false;
            ddlCamp.Enabled = true;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
		// 2012-10 It's possible that the potential campers want to register Jwest/JwestLA, but since JWest/JWestLA share zipcodes with other community programs, so the default
		// way of getting federation name column in tblCamperHolding is not workable.  On the app, when user tris to register JWest/JWestLA when they are still closed, a
		// query string variable "fed" will be appended, so this page load can handle it.  The store procedure to store the camper holding data will determine if FedName here is
		// empty or not
        if (ddlSchoolType.SelectedIndex == 0)
        {
            lblMsg.Text = "You must specify the school type";
            return;
        }

        if (ddlCamp.SelectedIndex == 0 && txtCamp.Text == "")
        {
            lblMsg.Text = "You must specifiy a camp name";
            return;
        }

        string campName = txtCamp.Text;
        if (!chkNoCamp.Checked)
            campName = ddlCamp.SelectedItem.Text;

		string FedName = "";
		
		if (Request["fed"] != null)
		{
			FedName = Request["fed"].ToString();
		}
        
		_objCamperApp = new CamperApplication();
        _objCamperApp.InsertCamperHoldingDetails(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtZipCode.Text, FedName, campName, chkPJL.Checked, ddlSchoolType.SelectedIndex);

        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtEmail.Text = "";
        txtZipCode.Text = "";
        lblThankYou.Visible = true;
     }
    protected void chkNoCamp_CheckedChanged(object sender, EventArgs e)
    {
        if (chkNoCamp.Checked)
        {
            txtCamp.Enabled = true;
            ddlCamp.Enabled = false;
        }
        else
        {
            ddlCamp.Enabled = true;
            txtCamp.Enabled = false;
        }
    }
}
