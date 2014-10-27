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

public partial class Administration_ManageUser : System.Web.UI.Page
{
    private General _objGen;
    private UserAdministration _objUsrAdmin = new UserAdministration();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Set Page Heading
        Label lbl = (Label)this.Master.FindControl("lblPageHeading");
        lbl.Text = "Manage User";

        //TV: 04/2009 - added message Label to display informative (non-error) messages to the user
        lblMsg.Text = "";

        if (IsPostBack != true)
        {
            //Populate Federation dropdown
            DataSet dsFed;
            _objGen = new General();
            dsFed = _objGen.get_AllFederations();
            ddlFed.DataSource = dsFed;
            ddlFed.DataTextField = "Federation";
            ddlFed.DataValueField = "ID";
            ddlFed.DataBind();
            if ((ddlFed.Items.Count != 0))
                ddlFed.Items.Insert(0, new ListItem("--Select--", "-1"));
            //ddlFed.SelectedIndex = 13;

        }
        else
        {
            //TV: 04/2009 - Task # A-046 - check to see if was saved in a prior screen
            if (Session["objUsrAdmin"] != null)
            {
                _objUsrAdmin = (UserAdministration)Session["objUsrAdmin"];
            }
        }
    }

    protected void btnNewUsr_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/Administration/CreateUser.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {   
        SetValues();

        //TV: 04/2009 - Task # A-046 - save the current search criteria for future usage
        Session["objUsrAdmin"] = _objUsrAdmin;
        
        PopulateGrid();
        if (gvUsrDetails.Rows.Count == 0)
            lblErrMsg.Text = "No matching records found";
        else
            lblErrMsg.Text = "";
    }

    private void SetValues()
    {
        //Set properties/parameters for the stored procedure
        _objUsrAdmin.FirstName = txtFirstNm.Text.Trim();
        _objUsrAdmin.LastName = txtLastNm.Text.Trim();
        _objUsrAdmin.Email = txtEmail.Text.Trim();
        _objUsrAdmin.FederationID = Convert.ToInt16(ddlFed.SelectedValue);

        if (ddlCamps.SelectedValue != "")
            _objUsrAdmin.CampID = Convert.ToInt16(ddlCamps.SelectedValue);
    }

    private void PopulateGrid()
    {
        DataSet dsUsrDetails;
        dsUsrDetails = _objUsrAdmin.GetUserDetails();
        gvUsrDetails.DataSource = dsUsrDetails;
        gvUsrDetails.DataBind();
    }

    protected void gvUsrDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string strUsrId = e.CommandArgument.ToString();

        if (e.CommandName == "Edit")
            Server.Transfer("~/Administration/CreateUser.aspx?UsrId=" + strUsrId);

        if (e.CommandName == "Delete")
        {
            _objUsrAdmin.DeleteUser(Convert.ToInt16(strUsrId));

            //************
            //TV: 04/2009 - double check that the user was deleted (which means the Active flag was set to false)
            string sDeleteMsg = "";
            string sErrMsg = "There may have been a problem with the Delete action. Please check with your system administrator for the user whose ID number is: " + strUsrId;

            //get user details
            DataSet dsUsrDetails = _objUsrAdmin.GetUserById(Convert.ToInt16(strUsrId));
            if (dsUsrDetails != null && dsUsrDetails.Tables[0] != null && dsUsrDetails.Tables[0].Rows.Count > 0)
            {
                //check the value of the Active flag - if it is false, then the user was deleted ("logically deleted")
                if (DBNull.Value.Equals(dsUsrDetails.Tables[0].Rows[0]["Active"]) == false)
                {
                    bool bActiveFlag = (bool)dsUsrDetails.Tables[0].Rows[0]["Active"];
                    if (bActiveFlag == false)
                    {
                        sDeleteMsg = "User deleted successfully";
                    }
                }
            }
            //show appropriate message to user and clear out any prior messages that may exist
            if (sDeleteMsg.Length > 0)
            {
                lblErrMsg.Text = "";
                lblMsg.Text = sDeleteMsg; 
            }
            else
            {
                lblMsg.Text = "";
                lblErrMsg.Text = sErrMsg;
            }
            //************

            PopulateGrid();
        }
    }

    protected void gvUsrDetails_DeleteCommand(object sender, GridViewDeleteEventArgs e)
    {
    }
}
