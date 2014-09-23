using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_ProgramFinder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        if (txtZipCode.Text.Trim() == "")
        {
            lblError.Text = "Zip Code cannot be empty";
            return;
        }

        pnlResult.Visible = true;

        lblError.Text = "";
        lblProgram.Text = "";
        lblContact.Text = "";
        lblEmail.Text = "";
        lblPhone.Text = "";

        Dictionary<string, string> fed = FederationsDA.GetFederationByZipCode(txtZipCode.Text);

        if (fed.Count == 0)
            lblProgram.Text = "None";
        else
        {
            lblProgram.Text = fed["Name"];
            lblContact.Text = fed["Contact"];
            lblEmail.Text = fed["Email"];
            lblPhone.Text = fed["Phone"];
        }
    }
}