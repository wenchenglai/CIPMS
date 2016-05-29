using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using CIPMSBC;

public partial class Administration_ProgramFinder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateFederations();
        }
    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        int fedId = 0;
        string zipCode = "";
        if (ddlFeds.SelectedIndex <= 0)
        {
            if (txtZipCode.Text.Trim() == "")
            {
                lblError.Text = "Please select a program or enter a zip code.";
                return;
            }
            else
            {
                zipCode = txtZipCode.Text.Trim();
            }
        }
        else
        {
            fedId = Int32.Parse(ddlFeds.SelectedValue);
        }

        PopulateFedData(fedId, zipCode);
        PopulateEligibility(fedId);


    }

    private void PopulateFederations()
    {
        General _objGen = new General();
        System.Data.DataSet dsFed = _objGen.get_AllFederations();

        ddlFeds.DataSource = dsFed;
        ddlFeds.DataTextField = "Federation";
        ddlFeds.DataValueField = "ID";

        ddlFeds.DataBind();
        if ((ddlFeds.Items.Count != 0))
            ddlFeds.Items.Insert(0, new ListItem("--Select--", "-1"));

    }

    private void PopulateFedData(int fedId, string zipCode)
    {
        pnlResult.Visible = true;

        lblError.Text = "";
        lblProgram.Text = "";
        lblContact.Text = "";
        lblEmail.Text = "";
        lblPhone.Text = "";
        lblStatus.Text = "";
        lblAvail.Text = "";
        lblGeneralProcessing.Text = "";
        lblJDS.Text = "";
        lblJDSProcessing.Text = "";

        Dictionary<string, string> fed;

        if (fedId == 0)
        {
            // there is no fed selected, so we use zip code
            if (txtZipCode.Text.Trim().Length == 7)
            {
                var gen = new General();
                var canadaFedId = gen.GetCanadianZipCode(txtZipCode.Text);
                if (canadaFedId == "Duplicate")
                {
                    pnlResult.Visible = false;
                    lblError.Text = "Duplicates programs found for this zip code.  Please contact the FJC admin immediately";
                    return;
                }

                if (canadaFedId != "")
                {
                    fed = FederationsDA.GetFederationByIdOrZipCode("", Int32.Parse(canadaFedId));
                }
                else
                {
                    fed = new Dictionary<string, string>();
                }
            }
            else
            {
                fed = FederationsDA.GetFederationByIdOrZipCode(txtZipCode.Text, 0);
            }
        }
        else
        {
            fed = FederationsDA.GetFederationByIdOrZipCode("", fedId);
        }



        if (fed.Count == 0)
        {
            lblProgram.Text = "None";
            return;
        }

        // show real data here
        if (fed.ContainsKey("Error"))
        {
            if (fed["Error"] == "Duplicate")
            {
                pnlResult.Visible = false;
                lblError.Text = string.Format("Duplicates programs found for this zip code.  Please contact the FJC admin immediately.  The programs are {0} and {1}.", fed["Name"], fed["NameForSecondProgram"]);
                return;
            }
        }

        lblProgram.Text = fed["Name"];
        lblContact.Text = fed["Contact"];
        lblEmail.Text = fed["Email"];
        lblPhone.Text = fed["Phone"];

        var isActive = fed["isActive"];
        if (isActive == "True")
        {
            lblStatus.Text = "Active";
            if (Convert.ToBoolean(fed["is19DaysOnly"]))
            {
                lbl19Only.Visible = true;
            }
            else
            {
                lbl19Only.Visible = false;
            }
        }
        else if (isActive == "False")
        {
            lblStatus.Text = "Inactive";
            lblProgram.Text = "";
            lblContact.Text = "";
            lblEmail.Text = "";
            lblPhone.Text = "";
        }
        else if (isActive == "")
            lblStatus.Text = "No Program";

        var isGrantAvailable = fed["isGrantAvailable"];
        if (isGrantAvailable == "True")
            lblAvail.Text = "Grants Available";
        else if (isGrantAvailable == "False")
        {
            lblAvail.Text = "Sold Out";

            if (isActive == "False")
                lblAvail.Text = "N/A";
        }
        else if (isGrantAvailable == "")
            lblAvail.Text = "Offline, contact community directly";

        var isOnlineProcessing = fed["isOnlineProcessing"];
        if (isOnlineProcessing == "True")
            lblGeneralProcessing.Text = "Reg System";
        else if (isOnlineProcessing == "False")
            lblGeneralProcessing.Text = "Offline, contact community directly";
        else if (isOnlineProcessing == "")
            lblGeneralProcessing.Text = "N/A";

        var isJDSAvailable = fed["isJDSAvailable"];
        if (isJDSAvailable == "True")
        {
            lblJDS.Text = "Available";

            if (fed["ID"] == "9")
            {
                lblJDS.Text = "Yes ";
                lblJDS.Text += "(Provide PJ Code ONLY IF school NOT listed below.  If school listed below send to Reg System for processing.)";
                //lblJDS.Text += "(Send all to Reg System)";
                lblJDS.Text += "<br />Bernard Zell Anshe Emet Day School";
                lblJDS.Text += "<br />Akiba Schechter Jewish Day School";
                lblJDS.Text += "<br />Chicago Jewish Day School";
                lblJDS.Text += "<br />Chicagoland Jewish High School";
                lblJDS.Text += "<br />Solomon Schechter Jewish Day School";
            }
        }
        else if (isJDSAvailable == "False")
            lblJDS.Text = "Not Available";
        else if (isJDSAvailable == "")
            lblJDS.Text = "Not Available";

        var isJDSOnline = fed["isJDSOnline"];
        if (isJDSOnline == "True")
            lblJDSProcessing.Text = "Reg System";
        else if (isJDSOnline == "False")
            lblJDSProcessing.Text = "Offline, contact community directly";
        else if (isJDSOnline == "")
            lblJDSProcessing.Text = "N/A";
    }

    private void PopulateEligibility(int fedId)
    {
        gvEli.DataSource = FedCampGrantDA.GetAllByFedID(Int32.Parse(Session["CampYear"].ToString()), fedId);
        gvEli.DataBind();
    }

}