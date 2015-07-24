using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_ProgramContact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnlData.Visible = false;
            lblMsg.Text = "";
        }
        else
        {
            if (lblMsg.Text == "Data Saved Successfully")
            {

            }
        }
    }

    protected void ddlFed_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        var selectedId = Int32.Parse(ddlFed.SelectedValue);

        if (selectedId > 0)
        {
            pnlData.Visible = true;
            var fed = FederationsDA.GetFederationByIdOrZipCode("", Int32.Parse(ddlFed.SelectedValue));

            lblName.Text = fed["Contact"];
            lblEmail.Text = fed["Email"];
            lblPhone.Text = fed["Phone"];

            txtName.Text = fed["Contact"];
            txtEmail.Text = fed["Email"];
            txtPhone.Text = fed["Phone"];
        }
        else
        {
            pnlData.Visible = false;
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        FederationsDA.SaveFederationContact(Int32.Parse(ddlFed.SelectedValue), txtName.Text, txtPhone.Text, txtEmail.Text);
        ddlFed_SelectedIndexChanged(null, null);
        lblMsg.Text = "Data Saved Successfully";
    }
}