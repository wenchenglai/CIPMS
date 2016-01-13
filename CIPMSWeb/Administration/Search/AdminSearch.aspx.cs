using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using CIPMSBC;

public partial class AdminSearch : System.Web.UI.Page
{
    private SrchCamperDetails _objCamperDet = new SrchCamperDetails();
    private General _objGen;
    private string _strUsrID;
    private string _strRoleID;
    private string _strFedID;
    private string _strFedName;
    private string _strUsrNm;
    private string _strFJCAdmin;
    private string _strFedAdmin;
    private string _strCampDir;
    private string _strFed_CampAdmin;
    private string _strMovementAdmin;
    private string _strApprover;
    private string _CampYear;
    private string _strJWestFed = ConfigurationManager.AppSettings["JWest"];
    private string _strJWestLAFed = ConfigurationManager.AppSettings["JWestLA"];
    private string _strLACIPFed = ConfigurationManager.AppSettings["LACIP"];
    private string _strOrangeFed = ConfigurationManager.AppSettings["Orange"];

    protected void Page_Load(object sender, EventArgs e)
    {
        //Set Page Heading
        Label lbl = (Label)this.Master.FindControl("lblPageHeading");
        lbl.Text = "Search Camper Applications";

        //Get the values from the session
        _strUsrID = (string)Session["UsrID"];
        _strRoleID = (string)Session["RoleID"];
        _strFedID = (string)Session["FedId"];
        _strFedName = (string)Session["FedName"];
        _strUsrNm = (string)Session["LastName"] + ", " + (string)Session["FirstName"];
        //_CampYear = (string)Master.CampYear;
        //Get roles from config
        _strFJCAdmin = ConfigurationManager.AppSettings["FJCADMIN"].ToString();
        _strFedAdmin = ConfigurationManager.AppSettings["FEDADMIN"].ToString();
        _strCampDir = ConfigurationManager.AppSettings["CAMPDIRECTOR"].ToString();
        _strFed_CampAdmin = ConfigurationManager.AppSettings["FED_CAMPADMIN"].ToString();
        _strApprover = ConfigurationManager.AppSettings["APPROVER"].ToString();
        _strMovementAdmin = "6";
        
        revZip.Enabled = false;
        revZipFRM.Enabled = false;
        revZipTO.Enabled = false;        
        if (IsPostBack != true)
        {
            string strPage = Request.QueryString["page"];
            PopulateSrchControls();
            MaintainSearch();
            
        }

       
        dvZipCd.Style.Add("display", "none");
        dvZipRange.Style.Add("display", "none");

        //if (rbZipCode.Checked)
        if (!rbZipRange.Checked)
        {
            rbZipCode.Checked = true;
            dvZipCd.Style.Add("display", "block");
            txtZipFrom.Text = string.Empty;
            txtZipTo.Text = string.Empty;
            dvZipRange.Style.Add("display", "none");
        }
        else if (rbZipRange.Checked)
        {
            dvZipRange.Style.Add("display", "block");
            txtZip.Text = string.Empty;
            dvZipCd.Style.Add("display", "none");
        }

        rbZipCode.Attributes.Add("onClick", "javascript:ShowZip();");
        rbZipRange.Attributes.Add("onClick", "javascript:ShowZip();");
        btnSearch.Attributes.Add("onClick", "javascript:ValidateRange();");
        chkSort.Attributes.Add("onClick", "javascript:EnableDisableSort();");
        HtmlGenericControl pageBody = (HtmlGenericControl)this.Master.FindControl("objMasterBody");
        pageBody.Attributes.Add("onLoad", "javascript:EnableDisableSort();");

        // Removing Status which are currently not required -- Rajesh
        if ((lstStatus.Items.Count != 0))
        {
            lstStatus.Items.Remove(lstStatus.Items.FindByValue("16"));
            lstStatus.Items.Remove(lstStatus.Items.FindByValue("22"));
            lstStatus.Items.Remove(lstStatus.Items.FindByValue("4"));
            lstStatus.Items.Remove(lstStatus.Items.FindByValue("19"));
            lstStatus.Items.Remove(lstStatus.Items.FindByValue("11"));
            lstStatus.Items.Remove(lstStatus.Items.FindByValue("13"));
        }

    }

    private void MaintainSearch()
    {
        try
        {

            txtCamperNm.Text = (string)Session["SearchedFirstName"];
            txtCamperLNm.Text = (string)Session["SearchedLastName"];
            txtEmail.Text = (string)Session["SearchedEmail"];
            txtFJCID.Text = (string)Session["SearchedFJCID"];
            //***********
            //TV: 02/2009 - Issue # 4-002: changed Federation from DropDownList to multi-select ListBox
            //ddlFederation.SelectedValue = (string)Session["SearchedFed"];

            txtHidFederations.Text = (string)Session["SearchedFed"];
            //***********
            txtAge.Text = (string)Session["SearchedAge"];
            txtGrade.Text = (string)Session["SearchedGrade"];
            rbZipCode.Checked = Convert.ToBoolean(Session["SearchedZipCdRadio"]);
            rbZipRange.Checked = Convert.ToBoolean(Session["SearchedZipCdRangeRadio"]);
            txtZip.Text = (string)Session["SearchedZipCd"];
            txtZipFrom.Text = (string)Session["SearchedZipCdFROM"];
            txtZipTo.Text = (string)Session["SearchedZipCdTO"];
            txtCreatedFrom.Text = (string)Session["SearchedCreatedDtFROM"];
            txtCreatedTo.Text = (string)Session["SearchedCreatedDtTO"];
            txtSubmittedFrom.Text = (string)Session["SearchedSubmittedDtFROM"];
            txtSubmittedTo.Text = (string)Session["SearchedSubmittedTO"];
            txtUpdatedFrom.Text = (string)Session["SearchedUpdatedDtFROM"];
            txtUpdatedTo.Text = (string)Session["SearchedUpdatedDtTO"];
            ddlModifiedBy.SelectedValue = (string)Session["SearchedModifiedBy"];
            txtHidStatus.Text = (string)Session["SearchedStatusLst"];
            txtHidCamps.Text = (string)Session["SearchedCampLst"];
            chkSort.Checked = Convert.ToBoolean(Session["SearchedOrderBy"]);
            ddlColums.SelectedValue = (string)Session["SearchedColName"];
            ddlSortOrder.SelectedValue = (string)Session["SearchedSortOrder"];

            //Restore federations selections
            string strFederationsLst = txtHidFederations.Text;
            RestoreListSelections(strFederationsLst, lstFederations);

            //Restore statuses selections
            RestoreListSelections(txtHidStatus.Text, lstStatus);

            //Restore camps selections
            string strCampsLst = txtHidCamps.Text;
            RestoreListSelections(strCampsLst, lstCamps);

            SetValues();

            //TV: 02/2009 - Issue # 4-002: changed Federation from DropDownList to multi-select ListBox, so changed reference
            //below to use the strFederationsLst variable - similar to the approach used by strCampsLst

            if ((strCampsLst != string.Empty) || (txtCamperNm.Text != string.Empty) ||
                (txtCamperLNm.Text != string.Empty) || (txtEmail.Text != string.Empty) ||
                (txtFJCID.Text != string.Empty) || (txtZip.Text != string.Empty) ||
                (txtZipFrom.Text != string.Empty) || (txtZipTo.Text != string.Empty) ||
                (txtCreatedFrom.Text != string.Empty) || (txtCreatedTo.Text != string.Empty) ||
                (txtSubmittedFrom.Text != string.Empty) || (txtSubmittedTo.Text != string.Empty) ||
                (txtUpdatedFrom.Text != string.Empty) || (txtUpdatedTo.Text != string.Empty) ||
                (txtHidStatus.Text != string.Empty) || (txtHidCamps.Text != string.Empty) ||
                (strFederationsLst != string.Empty) || (Convert.ToInt32(ddlModifiedBy.SelectedValue) != -1))
            {
                PopulateGrid();
            }

        }
        catch { }
    }

    private void RestoreListSelections(string sSelected, ListBox lstBox)
    {
        if (sSelected != string.Empty)
        {
            Array arrSelected = sSelected.Split(',');
            //loop through status list
            foreach (string sSelection in arrSelected)
            {
                if (!sSelection.Equals("-1"))
                {
                    for(int i = 0; i < lstBox.Items.Count; i++)
                    {
                        if (lstBox.Items[i].Value == sSelection)
                        {
                            lstBox.Items[i].Selected = true;
                        }
                    }
                }
            }
        }
    }

    private void SetSessionVariables()
    {
        Session["SearchedFirstName"] = txtCamperNm.Text;
        Session["SearchedLastName"] = txtCamperLNm.Text;
        Session["SearchedEmail"] = txtEmail.Text;
        Session["SearchedFJCID"] = txtFJCID.Text;

        //***********
        //TV: 02/2009 - Issue # 4-002: changed Federation from DropDownList to multi-select ListBox
        //Session["SearchedFed"] = ddlFederation.SelectedValue;
        //***********

        Session["SearchedAge"] = txtAge.Text;
        Session["SearchedGrade"] = txtGrade.Text;
        Session["SearchedZipCdRadio"] = Convert.ToString(rbZipCode.Checked);
        Session["SearchedZipCdRangeRadio"] = Convert.ToString(rbZipRange.Checked);
        Session["SearchedZipCd"] = txtZip.Text;
        Session["SearchedZipCdFROM"] = txtZipFrom.Text;
        Session["SearchedZipCdTO"] = txtZipTo.Text;
        Session["SearchedCreatedDtFROM"] = txtCreatedFrom.Text;
        Session["SearchedCreatedDtTO"] = txtCreatedTo.Text;
        Session["SearchedSubmittedDtFROM"] = txtSubmittedFrom.Text;
        Session["SearchedSubmittedTO"] = txtSubmittedTo.Text;
        Session["SearchedUpdatedDtFROM"] = txtUpdatedFrom.Text;
        Session["SearchedUpdatedDtTO"] = txtUpdatedTo.Text;
        Session["SearchedModifiedBy"] = ddlModifiedBy.SelectedValue;
        Session["SearchedOrderBy"] = Convert.ToString(chkSort.Checked);
        Session["SearchedColName"] = ddlColums.SelectedValue;
        Session["SearchedSortOrder"] = ddlSortOrder.SelectedValue;

        //***********
        //TV: 02/2009 - Issue # 4-002: changed Federation from DropDownList to multi-select ListBox
        GetFederations();

        //since the prior approach seemed to alway ensure that the very least a -1 would be the result of using the 
        //DropDownList control, (one of the stored procedures - used in several screens in the application - will
        //not like a value of "") - then this code will assign a -1 as the value
        if (txtHidFederations.Text.Length == 0)
        {
            Session["SearchedFed"] = "-1";
        }
        else
        {
            Session["SearchedFed"] = txtHidFederations.Text;
        }
        //***********
        GetCamps();
        GetStatus();
        Session["SearchedCampLst"] = txtHidCamps.Text;
        Session["SearchedStatusLst"] = txtHidStatus.Text;
        Session["CampYear"] = ddlCampYear.SelectedItem.Text;
    }

    //*********************************************************************************************
    // Name:            GetFederations    // Description:     Will capture list of Federations selected in a comma delimited list and
    //                  stored in a TextBox for later usage. (used the GetCamps function as a 
    //                  model for this function to keep things consistent in approach)
    //
    // Parameters:      None.
    // Returns:         None.
    // History:         02/2009 - TV: Initial coding.
    //*********************************************************************************************
    private void GetFederations()
    {
        txtHidFederations.Text = string.Empty;

        //loop through list of Federations
        for (int i = 0; i <= lstFederations.Items.Count - 1; i++)
        {
            //if the Federation has been selected by the user, then capture the 
            //value in a comman delimited list in a TextBox for later usage
            if (lstFederations.Items[i].Selected == true)
            {
                if (txtHidFederations.Text == string.Empty)
                {
                    if (lstFederations.Items[i].Value != "-1")
                    {
                        txtHidFederations.Text = lstFederations.Items[i].Value;
                    }
                }
                else
                {
                    if (lstFederations.Items[i].Value != "-1")
                    {
                        txtHidFederations.Text = txtHidFederations.Text + "," + lstFederations.Items[i].Value;
                    }
                }
            }
        }
    }

    private void GetCamps()
    {
        txtHidCamps.Text = string.Empty;
        for (int i = 0; i <= lstCamps.Items.Count - 1; i++)
        {
            if (lstCamps.Items[i].Selected == true)
            {
                if (txtHidCamps.Text == string.Empty)
                {
                    if (lstCamps.Items[i].Value != "-1")
                        txtHidCamps.Text = lstCamps.Items[i].Value;
                }
                else
                {
                    if (lstCamps.Items[i].Value != "-1")
                        txtHidCamps.Text = txtHidCamps.Text + "," + lstCamps.Items[i].Value;
                }
            }
        }
    }

    private void GetStatus()
    {
        txtHidStatus.Text = string.Empty;
        for (int i = 0; i <= lstStatus.Items.Count - 1; i++)
        {
            if (lstStatus.Items[i].Selected == true)
            {
                if (txtHidStatus.Text == string.Empty)
                {
                    if (lstStatus.Items[i].Value != "-1")
                        txtHidStatus.Text = lstStatus.Items[i].Value;
                }
                else
                {
                    if (lstStatus.Items[i].Value != "-1")
                        txtHidStatus.Text = txtHidStatus.Text + "," + lstStatus.Items[i].Value;
                }
            }
        }
    }

    private void ResetSessionVariables()
    {
        Session["SearchedFirstName"] = "";
        Session["SearchedLastName"] = "";
        Session["SearchedEmail"] = "";
        Session["SearchedFJCID"] = "";
        Session["SearchedFed"] = "";
        Session["SearchedAge"] = "";
        Session["SearchedGrade"] = "";
        Session["SearchedZipCdRadio"] = "";
        Session["SearchedZipCdRangeRadio"] = "";
        Session["SearchedZipCd"] = "";
        Session["SearchedZipCdFROM"] = "";
        Session["SearchedZipCdTO"] = "";
        Session["SearchedCreatedDtFROM"] = "";
        Session["SearchedCreatedDtTO"] = "";
        Session["SearchedSubmittedDtFROM"] = "";
        Session["SearchedSubmittedTO"] = "";
        Session["SearchedUpdatedDtFROM"] = "";
        Session["SearchedUpdatedDtTO"] = "";
        Session["SearchedModifiedBy"] = "";
        Session["SearchedStatusLst"] = "";
        Session["SearchedCampLst"] = "";
        Session["SearchedOrderBy"] = "";
        Session["SearchedColName"] = "";
        Session["SearchedSortOrder"] = "";
    }

    private void SetValues()
    {
        //***********
        //TV: 02/2009 - Issue # 4-002: changed Federation from DropDownList to multi-select ListBox
        GetFederations();
        //***********

        GetCamps();
        GetStatus();

        int iAge;
        if (txtAge.Text.Trim() == string.Empty)
            iAge = 0;
        else
            iAge = Convert.ToInt32(txtAge.Text.Trim());

        int iGrade;
        if (txtGrade.Text.Trim() == string.Empty)
            iGrade = 0;
        else
            iGrade = Convert.ToInt32(txtGrade.Text.Trim());

        //Set properties/parameters for the stored procedure
        string strFNm = txtCamperNm.Text.Trim();
        string strLNm = txtCamperLNm.Text.Trim();

        _objCamperDet.FirstName = strFNm.Replace("'", "''");
        _objCamperDet.LastName = strLNm.Replace("'", "''");
        _objCamperDet.EmailId = txtEmail.Text.Trim();
        _objCamperDet.FJCID = txtFJCID.Text.Trim();       
        _objCamperDet.Camplist = txtHidCamps.Text;
        _objCamperDet.Age = iAge;
        _objCamperDet.Grade = iGrade;
        _objCamperDet.ModifiedBy = Convert.ToInt32(ddlModifiedBy.SelectedValue);
        _objCamperDet.Status = txtHidStatus.Text;
        _objCamperDet.CampYear = ddlCampYear.SelectedItem.Text;
        if ((string)Session["RoleID"] == ConfigurationManager.AppSettings["CAMPDIRECTOR"].ToString())
        {
            _objCamperDet.FederationID = ConfigurationManager.AppSettings["JWest"].ToString() + "," + ConfigurationManager.AppSettings["JWestLA"].ToString();
        
            //AG: 6/4/2009 
            //limit camp list
            if (_objCamperDet.Camplist == "")
            {
                string strUserCamps = "";
                DataSet dsUsrCamps;
                _objGen = new General();
                dsUsrCamps = _objGen.GetUserCamps(Convert.ToInt32(_strUsrID), Convert.ToInt32(Session["CampYear"]));

                for (int i = 0; i <= dsUsrCamps.Tables[0].Rows.Count - 1; i++)
                {
                    if (strUserCamps == string.Empty)
                        strUserCamps = dsUsrCamps.Tables[0].Rows[i]["CampId"].ToString();
                    else
                        strUserCamps = strUserCamps + "," + dsUsrCamps.Tables[0].Rows[i]["CampId"].ToString();
                }
                _objCamperDet.Camplist = strUserCamps;
            
            }
        
        }
        else
        {
            //***********
            //TV: 02/2009 - Issue # 4-002: changed Federation from DropDownList to multi-select ListBox

            //since the prior approach seemed to alway ensure that the very least a -1 would be the result of using the 
            //DropDownList control, then this code will assign a -1 as the value (one of the stored procedures - 
            //used in several screens in the application - will not like a value of "")
            if (txtHidFederations.Text.Length == 0)
            {
                _objCamperDet.FederationID = "-1";
            }
            else
            {
                _objCamperDet.FederationID = txtHidFederations.Text;
            }
            //***********
        }

        if (rbZipCode.Checked == true)
        {
            txtZipFrom.Text = "";
            txtZipTo.Text = "";
            if (txtZip.Text.Trim() == string.Empty)
                _objCamperDet.ZipCode = string.Empty;
            else
                _objCamperDet.ZipCode = txtZip.Text.Trim();
        }
        else
        {
            txtZip.Text = "";
            _objCamperDet.ZipCode = string.Empty;
            if (txtZipFrom.Text.Trim() == string.Empty)
                _objCamperDet.ZipCodeFrom = string.Empty;
            else
                _objCamperDet.ZipCodeFrom = txtZipFrom.Text.Trim();

            if (txtZipTo.Text.Trim() == string.Empty)
                _objCamperDet.ZipCodeTo = string.Empty;
            else
                _objCamperDet.ZipCodeTo = txtZipTo.Text.Trim();
        }
        _objCamperDet.DateCreatedFrom = txtCreatedFrom.Text.Trim();
        _objCamperDet.DateCreatedTo = txtCreatedTo.Text.Trim();
        _objCamperDet.DateSubmittedFrom = txtSubmittedFrom.Text.Trim();
        _objCamperDet.DateSubmittedTo = txtSubmittedTo.Text.Trim();
        _objCamperDet.SortFlag = chkSort.Checked;
        _objCamperDet.SortColumn = ddlColums.SelectedValue;
        _objCamperDet.SortOrder = ddlSortOrder.SelectedValue;
    }

    private void PopulateGrid()
    {
        DataSet dsCamper;
        if (!((lstCamps.Items.Count == 0) && (_strRoleID == "3")))
        {
            dsCamper = _objCamperDet.SearchCamperDetails();
            gvCamperDetails.DataSource = dsCamper;
            gvCamperDetails.DataBind();
        }
    }

    private void PopulateSrchControls()
    {
        DataSet dsYears;
        _objGen = new General();
        if (ddlCampYear.Items.Count <= 0)
        {
            dsYears = _objGen.GetAllCampYears();
            ddlCampYear.Items.Clear();
            ddlCampYear.DataSource = dsYears;
            ddlCampYear.DataTextField = "CampYear";
            ddlCampYear.DataValueField = "ID";
            ddlCampYear.DataBind();

            if (_CampYear != "")
            {
                ddlCampYear.SelectedIndex = (int)Application["CampYear"] - 2008 - 1;
            }
        }
        

        if (_strRoleID == _strFJCAdmin || _strRoleID == _strApprover) //FJC Admin
         {
            //Populate Federation dropdown with all Federations
            DataSet dsFed;
           
            dsFed = _objGen.get_AllFederations();
            
            //***********
            //TV: 02/2009 - Issue # 4-002: changed Federation from DropDownList to multi-select ListBox
            
            lstFederations.Items.Clear();
            lstFederations.DataSource = dsFed;
            lstFederations.DataTextField = "Federation";
            lstFederations.DataValueField = "ID";
            lstFederations.DataBind();
            if ((lstFederations.Items.Count != 0))
                lstFederations.Items.Insert(0, new ListItem("--Select--", "-1"));
            //***********

            //Populate Camp List with all the Camps
            DataSet dsCamps;
            _objGen = new General();
            dsCamps = _objGen.get_AllCampsList(ddlCampYear.SelectedItem.Text);
            lstCamps.Items.Clear();
            lstCamps.DataSource = dsCamps;
            lstCamps.DataTextField = "Camp";
            lstCamps.DataValueField = "ID";
            lstCamps.DataBind();
            if ((lstCamps.Items.Count != 0))
                lstCamps.Items.Insert(0, new ListItem("--Select--", "-1"));

            //DataSet dsYears;
            //dsYears = _objGen.GetAllCampYears();
            //ddlCampYear.DataSource = dsYears;
            //ddlCampYear.DataTextField = "CampYear";
            //ddlCampYear.DataValueField = "ID";
            //ddlCampYear.DataBind();
            
            //if (_CampYear != "")
            //{
            //    ddlCampYear.SelectedIndex = ddlCampYear.Items.Count - 1;
            //}

            //Populate Users dropdown with all users
            DataSet dsModifiedBy;
            _objGen = new General();
            dsModifiedBy = _objGen.get_Users();
            ddlModifiedBy.DataSource = dsModifiedBy;
            ddlModifiedBy.DataTextField = "Name";
            ddlModifiedBy.DataValueField = "ID";
            ddlModifiedBy.DataBind();
            if ((ddlModifiedBy.Items.Count != 0))
                ddlModifiedBy.Items.Insert(0, new ListItem("--Select--", "-1"));
        }

        else if (_strRoleID == _strFedAdmin || _strRoleID == _strFed_CampAdmin) //Federation Admin OR Fed/Camp Admin
        {
            //***********
            //TV: 02/2009 - Issue # 4-002: changed Federation from DropDownList to multi-select ListBox

            //Populate Federation dropdown with the Federation of user and  disable it
            DataSet dsFedDetails = new DataSet();
            lstFederations.Items.Clear();
            if (_strFedID != "")
            {
                if (_strFedName != null)
                {
                    
                    lstFederations.Items.Insert(0, new ListItem(_strFedName, _strFedID));
                }
                else
                {
                    dsFedDetails = _objGen.GetFederationDetails(_strFedID);
                    if (dsFedDetails != null)
                    {
                        lstFederations.Items.Insert(0, new ListItem(dsFedDetails.Tables[0].Rows[0]["Name"].ToString(), _strFedID));
                    }
                }
                txtHidFederations.Text = _strFedID;
                lstFederations.SelectedValue = _strFedID;
            }
            else
                lstFederations.Items.Insert(0, new ListItem("--Select--", "-1"));

            

            lstFederations.Enabled = false;
            //***********

            //Populate Camp List with Camps associated with the Federation
            DataSet dsFedCamps;
            _objGen = new General();
            if (IsFederationHasAllCamps())
            {
                dsFedCamps = _objGen.get_AllCampsList(ddlCampYear.SelectedItem.Text);
                lstCamps.DataSource = dsFedCamps;
                lstCamps.DataTextField = "Camp";
                lstCamps.DataValueField = "ID";
            }
            else
            {
                //***********
                //TV: 02/2009 - Issue # 4-002: changed Federation from DropDownList to multi-select ListBox,
                //call new overloaded method in the General class which accepts a comma delimted list of FedIDs

                //dsFedCamps = _objGen.GetFedCamps(Convert.ToInt32(_strFedID));
                dsFedCamps = _objGen.GetFedCamps(_strFedID, ddlCampYear.SelectedItem.Text);
                //***********

                lstCamps.DataSource = dsFedCamps;
                lstCamps.DataTextField = "Camp";
                lstCamps.DataValueField = "CampID";
            }
 
            lstCamps.DataBind();
            if ((lstCamps.Items.Count != 0))
                lstCamps.Items.Insert(0, new ListItem("--Select--", "-1"));

            //Populate Users dropdown with users associated with the Federation
            DataSet dsModifiedBy;
            _objGen = new General();
            dsModifiedBy = _objGen.GetUsersByFederation(_strFedID);
            ddlModifiedBy.DataSource = dsModifiedBy;
            ddlModifiedBy.DataTextField = "Name";
            ddlModifiedBy.DataValueField = "ID";
            ddlModifiedBy.DataBind();
            if ((ddlModifiedBy.Items.Count != 0))
                ddlModifiedBy.Items.Insert(0, new ListItem("--Select--", "-1"));
        }

        else if (_strRoleID == _strCampDir) //Camp Director
        {
            //***********
            //TV: 02/2009 - Issue # 4-002: changed Federation from DropDownList to multi-select ListBox

            //Set Federation dropdown to nothin and disable it
            lstFederations.Items.Clear();
            lstFederations.Items.Insert(0, new ListItem("--Select--", "-1"));
            lstFederations.Enabled = false;
            //***********

            //Populate Camp List with Camps associated with the Camp Director
            DataSet dsUsrCamps;
            _objGen = new General();
            dsUsrCamps = _objGen.GetUserCamps(Convert.ToInt32(_strUsrID),Convert.ToInt32(Session["CampYear"]));
            lstCamps.Items.Clear();
            lstCamps.DataSource = dsUsrCamps;
            lstCamps.DataTextField = "Camp";
            lstCamps.DataValueField = "CampID";
            lstCamps.DataBind();
            if ((lstCamps.Items.Count != 0))
                lstCamps.Items.Insert(0, new ListItem("--Select--", "-1"));

            //Set Users dropdown to nothin and disable it
            ddlModifiedBy.Items.Insert(0, new ListItem("--Select--", "-1"));
            ddlModifiedBy.Enabled = false;
        }
        else if (_strRoleID == _strMovementAdmin) //Movement Camps admin
        {
            var dt = MovementDAL.GetMovementFedIDsByUserID(Convert.ToInt32(Session["UsrID"]));
            lstFederations.Items.Clear();
            lstFederations.DataSource = dt;
            lstFederations.DataTextField = "Federation";
            lstFederations.DataValueField = "ID";
            lstFederations.DataBind();
            if ((lstFederations.Items.Count != 0))
                lstFederations.Items.Insert(0, new ListItem("--Select--", "-1"));

            var result = (from myRow in dt.AsEnumerable()
                          select myRow.ItemArray[0].ToString()).ToArray();
            string fedIds = string.Join(",", result);

            var dsFedCamps = _objGen.GetFedCamps(fedIds, ddlCampYear.SelectedItem.Text);
            lstCamps.DataSource = dsFedCamps;
            lstCamps.DataTextField = "Camp";
            lstCamps.DataValueField = "CampID";

            lstCamps.DataBind();
            if ((lstCamps.Items.Count != 0))
                lstCamps.Items.Insert(0, new ListItem("--Select--", "-1"));

            //Populate Users dropdown with users associated with the Federation
            _objGen = new General();
            var dsModifiedBy = _objGen.GetUsersByFederation(_strFedID);
            ddlModifiedBy.DataSource = dsModifiedBy;
            ddlModifiedBy.DataTextField = "Name";
            ddlModifiedBy.DataValueField = "ID";
            ddlModifiedBy.DataBind();
            if ((ddlModifiedBy.Items.Count != 0))
                ddlModifiedBy.Items.Insert(0, new ListItem("--Select--", "-1"));
        }

        //Populate Status List
        DataSet dsStatus;
        _objGen = new General();
        dsStatus = _objGen.get_AllStatus();
        lstStatus.DataSource = dsStatus;
        lstStatus.DataTextField = "Status";
        lstStatus.DataValueField = "ID";
        lstStatus.DataBind();
        if ((lstStatus.Items.Count != 0))
            lstStatus.Items.Insert(0, new ListItem("--Select--", "-1"));

        //Populate Sort Column Names Dropdown
        ddlColums.Items.Insert(0, new ListItem("--Select--", "-1"));
        ddlColums.Items.Add(new ListItem("First Name", "FirstName"));
        ddlColums.Items.Add(new ListItem("Last Name", "LastName"));
        ddlColums.Items.Add(new ListItem("Email ID", "PersonalEmail"));
        ddlColums.Items.Add(new ListItem("FJCID", "FJCID"));
        ddlColums.Items.Add(new ListItem("Federation", "Federation"));
        ddlColums.Items.Add(new ListItem("Age", "Age"));
        ddlColums.Items.Add(new ListItem("Grade", "Grade"));
        ddlColums.Items.Add(new ListItem("Zip", "Zip"));
        ddlColums.Items.Add(new ListItem("Date Created", "CreatedDate"));
        ddlColums.Items.Add(new ListItem("Date Submitted", "SubmittedDate"));
        ddlColums.Items.Add(new ListItem("Last Updated Date", "ModifiedDate"));
        ddlColums.Items.Add(new ListItem("Modified By", "Admin"));
        ddlColums.Items.Add(new ListItem("Status", "Status"));

        //Populate Sort Order Dropdown
        ddlSortOrder.Items.Insert(0, new ListItem("--Select--", "-1"));
        ddlSortOrder.Items.Add(new ListItem("Ascending", "Asc"));
        ddlSortOrder.Items.Add(new ListItem("Descending", "Desc"));
    }

    protected void gvCamperDetails_OnSort(object sender, GridViewSortEventArgs e)
    {
        DataSet ds;
        ds = _objCamperDet.SearchCamperDetails();
        gvCamperDetails.DataSource = ds.Tables[0].Select("", e.SortExpression);
        ds.Tables[0].DefaultView.Sort = e.SortExpression;
        gvCamperDetails.DataSource = ds.Tables[0].DefaultView;
        gvCamperDetails.DataBind();
    }

    protected void gvCamperDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Check if a user other than the current user locked the record for edit
            //If Yes then disable the FJCID link
            string strUser = DataBinder.Eval(e.Row.DataItem, "IsLockedForEdit").ToString();
            if (strUser != string.Empty && (string)Session["UsrID"] != strUser)
                ((LinkButton)e.Row.FindControl("lnkFJCID")).Enabled = false;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["CampYear"] = ddlCampYear.SelectedItem.Text.Trim();
        SetSessionVariables();
        SetValues();
        PopulateGrid();
        if (gvCamperDetails.Rows.Count == 0)
            lblErrMsg.Text = "No matching records found";
        else
            lblErrMsg.Text = "";
    }

    protected void gvCamperDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "FJCID")
        {
            string strFEDFJCID = e.CommandArgument.ToString();
            Array arrTemp = strFEDFJCID.Split(',');
            Session["FedId"] = ((string[])(arrTemp))[0];
            Session["FJCID"] = ((string[])(arrTemp))[1];
            Session["STATUS"] = ((string[])(arrTemp))[2];
            _objCamperDet.UserId = Convert.ToInt32(Session["UsrID"]);
            _objCamperDet.FJCID = (string)Session["FJCID"];
            _objCamperDet.LockUnlockRecord("Lock");
           
         Response.Redirect("~/Administration/Search/CamperSummary.aspx?page=srch");
            //***********
        }
    }

    protected void gvCamperDetails_PageIndexChange(object sender, GridViewPageEventArgs e)
    {
        SetValues();
        DataSet ds;
        ds = _objCamperDet.SearchCamperDetails();
        gvCamperDetails.DataSource = ds.Tables[0];
        gvCamperDetails.PageIndex = e.NewPageIndex;
        gvCamperDetails.DataBind();
    }

    private Boolean IsFederationHasAllCamps()
    {
        _objGen = new General();
        DataSet dsFederation;
        //DataRow drFederation;
        
        //***********
        //TV: 02/2009 - Issue # 4-002: changed Federation from DropDownList to multi-select ListBox,
        //so this boolean initial value is changed to false, because the new logic of this function 
        //needs to loop through more than one Federation (instead of just one Federation) to see if
        //any of the Federations has the "AllCamps" flag marked as true. So assume false until one
        //Federation is found to be marked as true.
        Boolean AllCamps = false;
        

        dsFederation = _objGen.GetFederationDetails(_strFedID);

        //***********
        //TV: 02/2009 - Issue # 4-002: changed Federation from DropDownList to multi-select ListBox,
        //so may need to loop through more than one Federation record and see if any of the Federations
        //has "AllCamps"

        //if (dsFederation.Tables[0].Rows.Count > 0)
        foreach(DataRow drFederation in dsFederation.Tables[0].Rows)
        {
            //drFederation = dsFederation.Tables[0].Rows[0];
            if (!drFederation["AllCamps"].Equals(DBNull.Value))
            {
                AllCamps = (Boolean)drFederation["AllCamps"];
                if(AllCamps == true)
                {
                    //no need to continue since at least one Federation was found with the "AllCamps"
                    //flag marked as true
                    break;
                }
            }
        }
        //***********

        return AllCamps;

    }

    //*********************************************************************************************
    // Name:            lstFederations_SelectedIndexChanged
    // Description:     Will refresh the list of camps in the Camp ListBox based on the values
    //                  selected in the Federations ListBox.
    //                  (much of this code copied from ddlFederation_SelectedIndexChanged when 
    //                  list of Federations used to be in a DropDownList control)
    //
    // Parameters:      sender, e - standard Microsoft event parameters
    // Returns:         None.
    // History:         02/2009 - TV: Initial coding.
    //*********************************************************************************************
    protected void lstFederations_SelectedIndexChanged(object sender, EventArgs e)
    {
        _objGen = new General();
        DataSet dsFedCamps = new DataSet();
        GetFederations();
        _strFedID = txtHidFederations.Text;

        //If Federation is JWest OR JWestLA OR LACIP, populate Camp List with Camps associated with the Federation
        //else get all camps

        //***********
        bool bGetFedCamps = true;

        //TV: 02/2009 - Issue # 4-002: if more than one Federation is specified (if there is a comma delimited list of Federations),
        //then see if they are part of the "GetFedCamps" group or not
        if (_strFedID.Contains(",") == true)
        {
            //get an array of the all the Federations selected
            string[] sFedIdArr = _strFedID.Split(',');
            //loop through Federation list until a non "GetFedCamp" Federation is found
            for (int i = 0; i < sFedIdArr.Length; i++)
            {
                if (sFedIdArr[i] != _strJWestFed && sFedIdArr[i] != _strJWestLAFed && sFedIdArr[i] != _strLACIPFed)
                {
                    bGetFedCamps = false;
                    //there is a Federation that is not a part of the "GetFedCamps" group of Federations, namely
                    //(as of this coding) JWest, JWestLA and LACIP
                    break;
                }
            }
        }
        else
        {
            bGetFedCamps = false;
        }

        //***********
        //TV: 02/2009 - Issue # 4-002: added bGetFedCamps to "if" check to handle the possibility that more than one
        //Federation may be selected. The the value for bGetFedCamps is calculated in the above code
        if (_strFedID == _strJWestFed || _strFedID == _strJWestLAFed || _strFedID == _strLACIPFed || bGetFedCamps == true)
        {
            //***********
            //TV: 02/2009 - Issue # 4-002: changed Federation from DropDownList to multi-select ListBox,
            //call new overloaded method in the General class which accepts a comma delimted list of FedIDs

            //dsFedCamps = _objGen.GetFedCamps(Convert.ToInt32(_strFedID));
            //dsFedCamps = _objGen.GetFedCamps(_strFedID, ddlCampYear.SelectedItem.Text);
            //lstCamps.DataSource = dsFedCamps;
            //lstCamps.DataTextField = "Camp";
            //lstCamps.DataValueField = "CampID";
            dsFedCamps = _objGen.get_AllCampsList(ddlCampYear.SelectedItem.Text);
            lstCamps.DataSource = dsFedCamps;
            lstCamps.DataTextField = "Camp";
            lstCamps.DataValueField = "ID";
        }
        else
        {
            dsFedCamps = _objGen.get_AllCampsList(ddlCampYear.SelectedItem.Text);
            lstCamps.DataSource = dsFedCamps;
            lstCamps.DataTextField = "Camp";
            lstCamps.DataValueField = "ID";
        }
        //***********

        lstCamps.DataBind();

        //make sure the first item in the list box contains the standard "--Select--" option
        if ((lstCamps.Items.Count != 0))
        {
            lstCamps.Items.Insert(0, new ListItem("--Select--", "-1"));
        }

    }

    protected void ddlCampYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateCampsToListBox();
        Session["CampYear"] = ddlCampYear.SelectedItem.Text;
    }

    private void PopulateCampsToListBox()
    {
        _objGen = new General();
        DataSet dsCamps = new DataSet();

        if (_strRoleID == _strFJCAdmin || _strRoleID == _strApprover) //FJC Admin
        {
            dsCamps = _objGen.get_AllCampsList(ddlCampYear.SelectedItem.Text);
            lstCamps.DataSource = dsCamps;
            lstCamps.DataTextField = "Camp";
            lstCamps.DataValueField = "ID";
        }

        if (_strRoleID == _strFedAdmin || _strRoleID == _strFed_CampAdmin) //Federation Admin OR Fed/Camp Admin
        if (IsFederationHasAllCamps())
        {
            dsCamps = _objGen.get_AllCampsList(ddlCampYear.SelectedItem.Text);
            lstCamps.DataSource = dsCamps;
            lstCamps.DataTextField = "Camp";
            lstCamps.DataValueField = "ID";
        }
        else
        {
            dsCamps = _objGen.GetFedCamps(_strFedID, ddlCampYear.SelectedItem.Text);
            lstCamps.DataSource = dsCamps;
            lstCamps.DataTextField = "Camp";
            lstCamps.DataValueField = "CampID";
        }        

        if (_strRoleID == _strCampDir)
        {
            dsCamps = _objGen.GetUserCamps(Convert.ToInt32(_strUsrID), Convert.ToInt32(ddlCampYear.SelectedItem.Text));
            lstCamps.DataSource = dsCamps;
            lstCamps.DataTextField = "Camp";
            lstCamps.DataValueField = "ID";
        }
        
        lstCamps.DataBind();

        if ((lstCamps.Items.Count != 0))
        {
            lstCamps.Items.Insert(0, new ListItem("--Select--", "-1"));
        }
    }
}