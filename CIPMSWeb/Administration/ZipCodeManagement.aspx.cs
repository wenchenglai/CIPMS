using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_ZipCodeManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ddlFed_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedId = Int32.Parse(ddlFed.SelectedValue);

        if (selectedId > 0)
        {
            gv.DataSourceID = "odsZipCodes";
            gv.DataBind();
            pnlAddNew.Visible = true;
        }
        else
        {
            pnlAddNew.Visible = false;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var selectedId = Int32.Parse(ddlFed.SelectedValue);
        if (txtNewZipCode.Text != "")
        {
            if (ZipCodeDA.InsertZipCode(selectedId, txtNewZipCode.Text))
            {
                lblMsg.Text = "New zip code added successfully";
                ddlFed_SelectedIndexChanged(null, null);
            }
            else
            {
                lblMsg.Text = "Duplicate zip code found.  There is no zip code added.";
            }
        }
        else
        {
            lblMsg.Text = "Zip code box cannot be empty";
        }
    }
}