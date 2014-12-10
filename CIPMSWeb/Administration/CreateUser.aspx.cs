using System;
using System.Collections.Generic;
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
using DocumentFormat.OpenXml.Office2010.ExcelAc;

public partial class Administration_CreateUser : System.Web.UI.Page
{
    private UserAdministration _objUsrAdmin = new UserAdministration();
    private General _objGen;
    private string _strFJCAdmin;
    private string _strFedAdmin;
    private string _strCampDir;
    private string _strFed_CampAdmin;
    private Label _lbl;
    private string _strApprover;

    protected void Page_Load(object sender, EventArgs e)
    {
        _lbl = (Label)this.Master.FindControl("lblPageHeading");
        lblMsg.Text = "";

        //Get roles from config
        _strFJCAdmin = ConfigurationManager.AppSettings["FJCADMIN"].ToString();
        _strFedAdmin = ConfigurationManager.AppSettings["FEDADMIN"].ToString();
        _strCampDir = ConfigurationManager.AppSettings["CAMPDIRECTOR"].ToString();
        _strFed_CampAdmin = ConfigurationManager.AppSettings["FED_CAMPADMIN"].ToString();
        _strApprover = ConfigurationManager.AppSettings["APPROVER"].ToString();

        if (!IsPostBack)
        {
            //Fill the listboxes and dropdowns
            FillControls();
            if (string.IsNullOrEmpty(Request.QueryString["UsrId"]))
            {
                Session["Mode"] = "I"; //Insert Mode
                _lbl.Text = "Create User";
                btnSubmit.Text = "Create";
            }
            else
            {
                Session["User"] = Convert.ToInt16(Request.QueryString["UsrId"]);
                Session["Mode"] = "U"; //Update Mode
                PopulateCtrls();
                _lbl.Text = "Update User";
                btnSubmit.Text = "Update";
            }
        }

        HtmlGenericControl pageBody = (HtmlGenericControl)this.Master.FindControl("objMasterBody");
        pageBody.Attributes.Add("onLoad", "javascript:ValidateControls();");
        ddlRole.Attributes.Add("onChange", "javascript:ValidateControls();");
    }

    //Fill the dropdowns & lists with values
    private void FillControls()
    {
        //Populate Role dropdown with all Roles
        DataSet dsRole;
        _objGen = new General();
        dsRole = _objGen.get_AllRoles();
        ddlRole.DataSource = dsRole;
        ddlRole.DataTextField = "UserRole";
        ddlRole.DataValueField = "ID";
        ddlRole.DataBind();
        if ((ddlRole.Items.Count != 0))
            ddlRole.Items.Insert(0, new ListItem("--Select--", "-1"));

        //Populate Federation List with all Federations
        DataSet dsFed;
        _objGen = new General();
        dsFed = _objGen.get_AllFederations();
        lstFed.DataSource = dsFed;
        lstFed.DataTextField = "Federation";
        lstFed.DataValueField = "ID";
        lstFed.DataBind();

        //Populate Camp List with all the Camps
        //DataSet dsCamps;
        //_objGen = new General();
        //dsCamps = _objGen.get_AllCamps(Master.CampYear);
        //lstCamps.DataSource = dsCamps;
        //lstCamps.DataTextField = "Camp";
        //lstCamps.DataValueField = "ID";
        //lstCamps.DataBind();

        // 
        var list = new List<string>()
        {
            "Habonim Dror",
            "Ramah"
        };
        lstMovements.DataSource = list;
        lstMovements.DataBind();
    }

    //Populate controls for update mode
    private void PopulateCtrls()
    {
        string strUsrId = Request.QueryString["UsrId"];
        DataSet dsUsrDetails;
        dsUsrDetails = _objUsrAdmin.GetUserById(Convert.ToInt16(strUsrId));

        txtFirstNm.Text = dsUsrDetails.Tables[0].Rows[0]["FirstName"].ToString();
        txtLastNm.Text = dsUsrDetails.Tables[0].Rows[0]["LastName"].ToString();
        txtEmail.Text = dsUsrDetails.Tables[0].Rows[0]["Email"].ToString();
        txtPhNo.Text = dsUsrDetails.Tables[0].Rows[0]["PhoneNumber"].ToString();
        txtPwd.Text = dsUsrDetails.Tables[0].Rows[0]["Password"].ToString();
        ddlRole.SelectedValue = dsUsrDetails.Tables[0].Rows[0]["UserRole"].ToString();
        lstFed.SelectedValue = dsUsrDetails.Tables[0].Rows[0]["Federation"].ToString();

        string strCamps;
        strCamps = dsUsrDetails.Tables[0].Rows[0]["Camps"].ToString();
        if (strCamps != string.Empty)
        {
            Array arrCamps = strCamps.Split(',');

            for (int i = 0; i <= arrCamps.Length - 1; i++)
            {
                int idx;
                idx = Convert.ToInt16(((string[])(arrCamps))[i]);
                lstCamps.Items.FindByValue(idx.ToString()).Selected = true;
            }
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SetVals();
        if ((string)Session["Mode"] == "I")
        {
            
            try
            {
                Session["User"] = _objUsrAdmin.CreateUser();
              
                Session["Mode"] = "U";
                _lbl.Text = "Update User";
                btnSubmit.Text = "Update";
                lblMsg.Text = "User created successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        else if ((string)Session["Mode"] == "U")
        {
            _objUsrAdmin.UserId = Convert.ToInt16(Session["User"]);
            try
            {
                _objUsrAdmin.UpdateUser();
                lblMsg.Text = "User updated successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    //Set properties for save/update
    private void SetVals()
    {
        int iRoleId = -1;
        int iFedId = -1;

        if (ddlRole.SelectedValue == _strFJCAdmin) //if FJC Admin , Federation & Camp not reqd, set it to -1
        {
            iRoleId = Convert.ToInt16(_strFJCAdmin);
            iFedId = -1;
            txtHidCamps.Text = string.Empty;
        }

        else if (ddlRole.SelectedValue == _strApprover) //if Approver, Federation & Camp not reqd, set it to -1
        {
            iRoleId = Convert.ToInt16(_strApprover);
            iFedId = -1;
            txtHidCamps.Text = string.Empty;
        }

        else if (ddlRole.SelectedValue == _strFedAdmin) //if Federation Admin, Camp not reqd, set it to -1
        {
            iRoleId = Convert.ToInt16(_strFedAdmin);
            iFedId = Convert.ToInt16(lstFed.SelectedValue);
            txtHidCamps.Text = string.Empty;
        }
        else if (ddlRole.SelectedValue == _strCampDir) //if Camp Director, Federation not reqd, set it to -1
        {
            iRoleId = Convert.ToInt16(_strCampDir);
            iFedId = -1;
            txtHidCamps.Text = string.Empty;
            GetCamps();
        }
        else if (ddlRole.SelectedValue == _strFed_CampAdmin) //if Federation/Camp Admin, pass both Federation and Camps
        {
            iRoleId = Convert.ToInt16(_strFed_CampAdmin);
            iFedId = Convert.ToInt16(lstFed.SelectedValue); ;
            txtHidCamps.Text = string.Empty;
            GetCamps();
        }
        //}

        _objUsrAdmin.Password = txtPwd.Text.Trim();
        _objUsrAdmin.FirstName = txtFirstNm.Text.Trim();
        _objUsrAdmin.LastName = txtLastNm.Text.Trim();
        _objUsrAdmin.PhoneNumber = txtPhNo.Text.Trim();
        _objUsrAdmin.Email = txtEmail.Text.Trim();
        _objUsrAdmin.FederationID = iFedId;
        _objUsrAdmin.RoleId = iRoleId;
        _objUsrAdmin.CampList = txtHidCamps.Text;
    }

    //Get a comma separated list of selected Camps
    private void GetCamps()
    {
        for (int i = 0; i <= lstCamps.Items.Count - 1; i++)
        {
            if (lstCamps.Items[i].Selected == true)
            {
                if (txtHidCamps.Text == string.Empty)
                    txtHidCamps.Text = lstCamps.Items[i].Value;
                else
                    txtHidCamps.Text = txtHidCamps.Text + "," + lstCamps.Items[i].Value;
            }
        }
    }
}
