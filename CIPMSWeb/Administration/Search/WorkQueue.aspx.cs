using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CIPMSBC;

public partial class Administration_Search_WorkQueue : System.Web.UI.Page
{
    private SrchCamperDetails _objCamperDet = new SrchCamperDetails();
    private General _objGen = new General();
    string isSorted;
    DataSet dsCamper = new DataSet();
    
    //int itemSelected ;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Set Page Heading
        var lbl = (Label)this.Master.FindControl("lblPageHeading");

        lbl.Text = "";
        gvWrkQ.Visible = true;
        lblWrkQueueMsg.Visible = false;

        DataSet dsCampYear = _objGen.GetCurrentYear();
        if (dsCampYear.Tables[0].Rows.Count > 0)
        {
            Session["CampYear"] = dsCampYear.Tables[0].Rows[0]["CampYear"].ToString();
        }
        else
        {
            Session["CampYear"] = Application["CampYear"].ToString();
            //Session["CampYear"] = DateTime.Now.Year;
        }
        //Populate DataGrid
        if (IsPostBack != true)
        {
            Session["CurrentPageIndex"] = 0;
            Session["selectedIndex"] = 0;
            PopulateGrid();
            PopulateCampList();   
        }
    }

    private void PopulateGrid()
    {
        SetVals();
        
        string strUserRole = string.Empty;

        if(Session["RoleID"] != null)
            strUserRole = Session["RoleID"].ToString();

        if (!String.IsNullOrEmpty(strUserRole) && strUserRole == ConfigurationManager.AppSettings["FJCADMIN"])
            dsCamper = _objCamperDet.SearchCamperDetails(strUserRole);
        else if (String.IsNullOrEmpty(strUserRole) || strUserRole != ConfigurationManager.AppSettings["FJCADMIN"])
            dsCamper = _objCamperDet.SearchCamperDetails();


        var dv = new DataView();
        dv.Table = dsCamper.Tables[0];
        //added newly for sroting by given statuses
        DataView Sorteddv = SortByStatus(dv);
       
        Sorteddv.Sort = "StatusOrder Asc";
        gvWrkQ.DataSource = Sorteddv;
        
        if (Session["CurrentPageIndex"]!=null) 
			gvWrkQ.PageIndex = Convert.ToInt32(Session["CurrentPageIndex"]);
        gvWrkQ.DataBind();
        //PopulateCampList();
    }

    private void SetVals()
    {      
        var strRole = (string)Session["RoleID"];
        var userId = Convert.ToInt32(Session["UsrID"]);

        if (strRole == ConfigurationManager.AppSettings["CAMPDIRECTOR"])
        {
            //If logged in role is Camp Director show records for his camp(s) with status Elligible by Staff
            var strUserCamps = string.Empty;
            DataSet dsUserCamps = _objGen.GetUserCamps(userId, Convert.ToInt32(Session["CampYear"].ToString()));
            for (int i = 0; i <= dsUserCamps.Tables[0].Rows.Count - 1; i++)
            {
                if (strUserCamps == string.Empty)
                    strUserCamps = dsUserCamps.Tables[0].Rows[i]["CampId"].ToString();
                else
                    strUserCamps = strUserCamps + "," + dsUserCamps.Tables[0].Rows[i]["CampId"].ToString();
            }

            _objCamperDet.Camplist = strUserCamps;
            _objCamperDet.FederationID = (string)ConfigurationManager.AppSettings["JWest"] + "," + (string)ConfigurationManager.AppSettings["JWestLA"];
            _objCamperDet.Status = "7,10";
        }
        else if (strRole == ConfigurationManager.AppSettings["FEDADMIN"])
        {
            //If logged in role is Federation Admin, show records for his federation with status - 
            //Elligible, Pending School Eligibility, Not Registered, Being Researched, Camp Full, Payment Review
            _objCamperDet.FederationID = (string)Session["FedId"];
            _objCamperDet.Status = "1,2,6,7,9,12,14,20,21,42,43,45";
            if (_objCamperDet.FederationID == ((int)FederationEnum.PJL).ToString())
                _objCamperDet.Status += ",46,47,48,49";
        }
        else if (strRole == ConfigurationManager.AppSettings["FJCADMIN"])
        {
            //If logged in role is FJC Admin, show records for his federation with status - 
            //Elligible, Pending School Eligibility, Not Registered, Being Researched, Camp Full, Payment Review
            _objCamperDet.FederationID = (string)ConfigurationManager.AppSettings["JWest"] + "," + (string)ConfigurationManager.AppSettings["JWestLA"];
            _objCamperDet.Status = "1,2,6,9,12,14,20,21,27,43,45";
        }
        else if (strRole == ConfigurationManager.AppSettings["APPROVER"])
        {
            //if logged in role is Approver, show records with status - Second Approval
            _objCamperDet.Status = "15,16";
        }
        else if (strRole == "6") // Movement Camp Admin is 6
        {
            DataTable dt = MovementDAL.GetMovementFedIDsByUserID(userId);
            var result = (from myRow in dt.AsEnumerable()
                select myRow.ItemArray[0].ToString()).ToArray();
            string fedIds = string.Join(",", result);

            _objCamperDet.FederationID = fedIds;
            _objCamperDet.Status = "1,2,6,7,9,12,14,20,21,42,43,45";
        }

        //Show only items with WorkQueue Flag as true
        _objCamperDet.WorkQueue = true;
    }

    protected void gvWrkQ_OnSort(object sender, GridViewSortEventArgs e)
    {
        SetVals();
        DataSet ds = new DataSet();
        DataView filteredSortedDv = new DataView();
        string strUserRole = string.Empty;
        if (Session["RoleID"] != null)
            strUserRole = Session["RoleID"].ToString();
        if (String.IsNullOrEmpty(strUserRole) || strUserRole != ConfigurationManager.AppSettings["FJCADMIN"])
            ds = _objCamperDet.SearchCamperDetails();
        if (!String.IsNullOrEmpty(strUserRole) && strUserRole == ConfigurationManager.AppSettings["FJCADMIN"])
            ds = _objCamperDet.SearchCamperDetails(strUserRole);

        gvWrkQ.DataSource = ds.Tables[0].Select("", e.SortExpression);
        ds.Tables[0].DefaultView.Sort = e.SortExpression;
        gvWrkQ.DataSource = ds.Tables[0].DefaultView;
        gvWrkQ.DataBind();
        PopulateCampList();
        if (((DropDownList)gvWrkQ.HeaderRow.FindControl("lnkCampList")).SelectedIndex != 0)
        {
            string campName = ((DropDownList)gvWrkQ.HeaderRow.FindControl("lnkCampList")).SelectedItem.Text;
           filteredSortedDv = PopulateGrid(campName, ds);
           filteredSortedDv.Sort = e.SortExpression;
           gvWrkQ.DataSource = filteredSortedDv;
           gvWrkQ.DataBind();
            PopulateCampList();
        }
        Session["sortfield"] = e.SortExpression;
    }
    protected void gvWrkQ_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "FJCID")
        {
            string strFEDFJCID = e.CommandArgument.ToString();
            Array arrTemp = strFEDFJCID.Split(',');
            Session["FedId"] = ((string[])(arrTemp))[0];
            Session["FJCID"] = ((string[])(arrTemp))[1];
            Session["STATUS"] = ((string[])(arrTemp))[2];
            //Session["CampYear"] = Session["FJCID"].ToString().Substring(0, 4);
            _objCamperDet.UserId = Convert.ToInt32(Session["UsrID"]);
            _objCamperDet.FJCID = (string)Session["FJCID"];
            _objCamperDet.LockUnlockRecord("Lock");
            Server.Transfer("~/Administration/Search/CamperSummary.aspx?page=wrkq");
        }
    }

    protected void gvWrkQ_PageIndexChange(object sender, GridViewPageEventArgs e)
    {
        
        SetVals();
        DataSet ds = new DataSet();
        string strUserRole = string.Empty;
        if (Session["RoleID"] != null)
            strUserRole = Session["RoleID"].ToString();
        if (String.IsNullOrEmpty(strUserRole) || strUserRole != ConfigurationManager.AppSettings["FJCADMIN"])
            ds = _objCamperDet.SearchCamperDetails();
        if (!String.IsNullOrEmpty(strUserRole) && strUserRole == ConfigurationManager.AppSettings["FJCADMIN"])
            ds = _objCamperDet.SearchCamperDetails(strUserRole);

        //if (Session["sortfield"] != null)
        //{
        //    ds.Tables[0].DefaultView.Sort = Session["sortfield"].ToString();
        //    gvWrkQ.DataSource = ds.Tables[0].DefaultView;
        //}
        //else
        //{
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
           /*added for the sake of sorting in the given statuses order*/
            DataView Sorteddv = SortByStatus(dv);
            Sorteddv.Sort = "StatusOrder Asc";
            
            gvWrkQ.DataSource = Sorteddv;//dv was there in the place of Sorteddv
        //}
           
        gvWrkQ.PageIndex = e.NewPageIndex;
        Session["CurrentPageIndex"] = e.NewPageIndex;        
        gvWrkQ.DataBind();
        PopulateCampList();
        if (((DropDownList)gvWrkQ.HeaderRow.FindControl("lnkCampList")).SelectedIndex != 0)
        {
            string campName = ((DropDownList)gvWrkQ.HeaderRow.FindControl("lnkCampList")).SelectedItem.Text;
            PopulateGrid(campName,ds);
            //gvWrkQ.DataSource = filteredDv;
            //gvWrkQ.DataBind();
            PopulateCampList();
        }
    }

    protected void gvWrkQ_RowDataBound(object sender, GridViewRowEventArgs e)
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


    /* added for sorting the workqueue in given statuses order*/

    private DataView SortByStatus(DataView dv)
    {
        DataTable dt = dv.ToTable();

        dt.Columns.Add("StatusOrder", typeof(int));
        foreach (DataRow dr in dt.Rows)
        {
            if (Convert.ToInt32(dr["StatusId"]) == 1)
            {
                dr["StatusOrder"] = 1;
            }
            else if(Convert.ToInt32(dr["StatusId"])==6)
            {
                dr["StatusOrder"]=2;
            }
            else if(Convert.ToInt32(dr["StatusId"])==20)
                dr["StatusOrder"] = 3;
            else if (Convert.ToInt32(dr["StatusId"]) == 9)
                dr["StatusOrder"] = 4;
            else if (Convert.ToInt32(dr["StatusId"]) == 21)
                dr["StatusOrder"] = 5;
            else if (Convert.ToInt32(dr["StatusId"]) == 14)
                dr["StatusOrder"] = 6;
            else 
                dr["StatusOrder"] = 10;

        }

        DataView Sorteddv = new DataView(dt);
        return Sorteddv;
    }

    private void PopulateCampList()
    {
        DataSet dsCamps = new DataSet();
        dsCamps = _objGen.get_AllCamps(Session["CampYear"].ToString());
       DropDownList ddlCamp;
       try
       {
           if (gvWrkQ.HeaderRow != null)
           {
               ddlCamp = (DropDownList)gvWrkQ.HeaderRow.FindControl("lnkCampList");
               ddlCamp.DataSource = dsCamps;
               ddlCamp.DataTextField = "Camp";
               ddlCamp.DataValueField = "ID";
               ddlCamp.DataBind();
               ddlCamp.Items.Insert(0, new ListItem("-- All--", "0"));
               if (Session["selectedIndex"] != null)
                   ddlCamp.SelectedIndex = Convert.ToInt32(Session["selectedIndex"].ToString());
               else
               {
                   ddlCamp.SelectedIndex = 0;
                   Session["selectedIndex"] = 0;

               }
           }
       }
       catch (Exception ex)
       {
           Response.Write(ex.Message);
       }



    }

    protected void lnkCampList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string campName = ((DropDownList)sender).SelectedItem.Text;
              
        PopulateGrid();
        
        PopulateGrid(campName,dsCamper);
        Session["selectedIndex"] = ((DropDownList)sender).SelectedIndex;
        //Session["itemSelected"] = 1;
        PopulateCampList();  
    }
    protected DataView PopulateGrid(string campName,DataSet dsCamper)
    {
        DataView filteredDv = new DataView();
        
        if (!campName.Equals("-- All--"))
        {
            
            filteredDv.Table = dsCamper.Tables[0];
            if(campName.Contains("'"))
            campName = campName.Replace("'", "''");
            filteredDv.RowFilter = "Camp LIKE '" + campName + "'";

            DataView Sorteddv = SortByStatus(filteredDv);
            Sorteddv.Sort = "StatusOrder Asc";
            if (Sorteddv.Table.Rows.Count <= 0)
                lblWrkQueueMsg.Visible = true;
            gvWrkQ.DataSource = Sorteddv;

            if (Session["CurrentPageIndex"] != null) gvWrkQ.PageIndex = Convert.ToInt32(Session["CurrentPageIndex"]);
            gvWrkQ.DataBind();
            //PopulateCampList();
            return filteredDv;
        }
        else
            PopulateGrid();
        return filteredDv;
    }
    
    /*
    private DataTable SortByStatus(DataView dv)
    {
        DataTable dt = new DataTable();
        DataView EPSdv = new DataView();
        DataView PSCdv = new DataView();
        DataView URdv = new DataView();
        DataView PRdv = new DataView();
        DataView CAdv = new DataView();
        DataView Othersdv = new DataView();

        EPSdv.Table = dv.Table;
        PSCdv.Table = dv.Table;
        URdv.Table = dv.Table;
        PRdv.Table = dv.Table;
        CAdv.Table = dv.Table;
        Othersdv.Table = dv.Table;

        EPSdv.RowFilter = "Status LIKE 'Eligible Pending School'";
        PSCdv.RowFilter = "Status LIKE 'Pending School%'";
        URdv.RowFilter = "Status LIKE 'Under Review'";
        PRdv.RowFilter = "Status LIKE 'Payment Review'";
        CAdv.RowFilter = "Status LIKE 'Campership approved%'";
        Othersdv.RowFilter = "Status NOT IN ('Eligible Pending School', 'Pending School and Camp','Under Review', 'Payment Review', 'Campership approved; payment pending')";

        dt = EPSdv.ToTable();
        DataTable dt1 = new DataTable();
        dt1 = PSCdv.ToTable();

            foreach (DataRow dr in dt1.Rows)
                dt.ImportRow(dr);
            dt1 = PSCdv.ToTable();
            foreach (DataRow dr in dt1.Rows)
                dt.ImportRow(dr);
            dt1 = URdv.ToTable();
            foreach (DataRow dr in dt1.Rows)
                dt.ImportRow(dr);
            dt1 = PRdv.ToTable();
            foreach (DataRow dr in dt1.Rows)
                dt.ImportRow(dr);
            dt1 = CAdv.ToTable();
            foreach (DataRow dr in dt1.Rows)
                dt.ImportRow(dr);
            dt1 = Othersdv.ToTable();
            foreach (DataRow dr in dt1.Rows)
                dt.ImportRow(dr);

        return dt;
    }
      */

    protected void lnkWhatToDO_Click(object sender, EventArgs e)
    {
        gvWrkQ.Visible = false;
    }
    protected void btnWrkQueue_Click(object sender, EventArgs e)
    {
        Response.Redirect("WorkQueue.aspx");
    }
}
