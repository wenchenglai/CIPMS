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
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

public partial class ExcelExport : System.Web.UI.Page
{
    private SrchCamperDetails _objCamperDet = new SrchCamperDetails();
    private General _objGen = new General();
    string destFile = ConfigurationManager.AppSettings["ExcelDestinationFile"].ToString();
    string excelClientFile = ConfigurationManager.AppSettings["ExcelClientFile"].ToString();

    private byte[] StreamFile(string filename)
    {
        FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
        // Create a byte array of file stream length    
        byte[] ImageData = new byte[fs.Length];
        //Read block of bytes from stream into the byte array    
        fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));
        //Close the File Stream    
        fs.Close();
        return ImageData; //return the byte data
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack) GetAllCampYears();
    }

    private void GetAllCampYears()
    {
        DataSet dsYears = new DataSet();
        dsYears = _objGen.GetAllCampYears();
        ddlCampYear.DataSource = dsYears;
        ddlCampYear.DataValueField = "ID";
        ddlCampYear.DataTextField = "CampYear";
        ddlCampYear.DataBind();
        ddlCampYear.Items.Insert(0, new ListItem("--All Years--", "0"));
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Additional logic for FJC admin
        string FederationID = string.Empty;
        
        try
        {
            FederationID = Session["FedId"].ToString();
        }
        catch { };
        if (FederationID == string.Empty)
        {
            try
            {
                byte[] returnValue;

                string FileName = excelClientFile + (ddlCampYear.SelectedIndex > 0 ? ddlCampYear.SelectedItem.Text + "-" : "") + String.Format("{0:M/d/yyyy}", DateTime.Now) + ".xls";

                if (ddlCampYear.SelectedIndex > 0)
                    destFile = destFile.Replace(excelClientFile.Substring(0,excelClientFile.Length-1),  ddlCampYear.SelectedItem.Text);

                returnValue = StreamFile(destFile);

                if (returnValue.Length < 100000)
                {
                    PopulateGrid();
                    return;
                }

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = "Excel";
                Response.AddHeader("content-disposition", "attachment ; filename=" + FileName);

                Response.BinaryWrite(returnValue);
                Response.Flush();
                Response.End();
            }
            catch (System.Threading.ThreadAbortException)
            {
                //string test = "debug";  // do nothing
            }
            catch (Exception ex)
            {
                PopulateGrid();
            }
        }
        
        else
        {
            PopulateGrid();
        }
    }

    private void PopulateGrid()
    {
        string Federation = "Federations: All";
        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        CIPDataAccess dal = new CIPDataAccess();
        DataSet dsExport;

        string FederationID = string.Empty;
        try
        {
            FederationID = Session["FedId"].ToString();
       
            SqlParameter[] param = new SqlParameter[2];
            if (FederationID.Trim() == string.Empty)
            {            
                param[0] = new SqlParameter("@FederationID", null);            
            }
            else
            {
                Federation = "Federation: " + Session["FedName"].ToString();            
                param[0] = new SqlParameter("@FederationID", FederationID);
            }

            if(ddlCampYear.SelectedIndex == 0)
                param[1] = new SqlParameter("@Year", null);
            else
                param[1] = new SqlParameter("@Year", ddlCampYear.SelectedItem.Text);

            dsExport = dal.getDataset("[usp_GetViewDump]", param);

            string FileName = excelClientFile + (ddlCampYear.SelectedIndex > 0 ? ddlCampYear.SelectedItem.Text + "-" : "") + String.Format("{0:M/d/yyyy}", DateTime.Now) + ".xls";

            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1255");
            Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);  

            if (dsExport.Tables[0].Rows.Count == 0)
            {
                this.Controls.Remove(gvExport);
                Response.Write("No matching records found.");
                Response.End();
            }
            else
            {
            for(int i=0;i<dsExport.Tables[0].Rows.Count;i++)
            {
                dsExport.Tables[0].Rows[i]["Zip"] = "'" + dsExport.Tables[0].Rows[i]["Zip"];
            }

            gvExport.DataSource = dsExport;
            gvExport.DataBind();
            gvExport.Visible = true;
            hw.WriteLine("<table><tr><td><b><font size='3'>" +
               "Campers Data Export" +
               "</font></b></td></tr>");

            hw.WriteLine("<tr><td><font size='2'>" + Federation +
            "</font></td></tr>");

            hw.WriteLine("<tr><td><font size='2'>" +
            "Export Date: " + String.Format("{0:M/d/yyyy hh:mm tt}", DateTime.Now) +
            "</font></td></tr></table>");

            HtmlForm form1 = (HtmlForm) Master.FindControl("form1");
            form1.Controls.Clear();
            form1.Controls.Add(gvExport);
            form1.RenderControl(hw);            

            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();

        }

     }
    catch(Exception ex)
       { 
    
       }
    }
   

    protected void gvWrkQ_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvExport_DataBound(object sender, EventArgs e)
    {
        
    }
    protected void gvExport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label mylabel = e.Row.FindControl("lblFJCID") as Label;
            mylabel.Text = "=TEXT(" + mylabel.Text + ",\"#\")";
            Label lblAmount = e.Row.FindControl("lblAmount") as Label;
            lblAmount.Text = "$" + lblAmount.Text;
            Label lblFJCMatch = e.Row.FindControl("lblFJCMatch") as Label;
            lblFJCMatch.Text = "$" + lblFJCMatch.Text;
            Label lblDateOfBirth = e.Row.FindControl("lblDateOfBirth") as Label;
            lblDateOfBirth.Text = String.IsNullOrEmpty(lblDateOfBirth.Text)?lblDateOfBirth.Text:DateTime.Parse(lblDateOfBirth.Text).ToShortDateString();
            Label lblCreatedDate = e.Row.FindControl("lblCreatedDate") as Label;
            lblCreatedDate.Text = String.IsNullOrEmpty(lblCreatedDate.Text)?lblCreatedDate.Text:DateTime.Parse(lblCreatedDate.Text).ToShortDateString();
            Label lblSubmitDate = e.Row.FindControl("lblSubmitDate") as Label;
            lblSubmitDate.Text = String.IsNullOrEmpty(lblSubmitDate.Text)?lblSubmitDate.Text:DateTime.Parse(lblSubmitDate.Text).ToShortDateString();
        }        
    }

    //This is used to create additional header row on the top spanning multiple columns (Grouping columns)
    protected void GridView_Merge_Header_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //Build custom header.
            GridView oGridView = (GridView)sender;
            GridViewRow oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            //Add Header 1
            TableCell oTableCell = new TableCell();
            oGridViewRow.Cells.Add(CreateTableCellForGridView("Program Information", 11, Color.Black, Color.FromArgb(204, 153, 255)));

            //Add Header 2
            oGridViewRow.Cells.Add(CreateTableCellForGridView("Camp Information", 5, Color.Black, Color.FromArgb(0, 255, 255)));

            //Add Header 3
            oGridViewRow.Cells.Add(CreateTableCellForGridView("Basic Camper Information", 8, Color.Black, Color.FromArgb(255, 153, 204)));

            //Add Header 4
            oGridViewRow.Cells.Add(CreateTableCellForGridView("Camper Contact Information", 5, Color.Black, Color.FromArgb(204, 255, 204)));

            //Add Header 5
            oGridViewRow.Cells.Add(CreateTableCellForGridView("Parent Contact Information", 14, Color.Black, Color.FromArgb(255, 255, 153)));

            //Add Header 6
            oGridViewRow.Cells.Add(CreateTableCellForGridView("Application Information", 3, Color.Black, Color.FromArgb(192, 192, 192)));


            //Add Header 7
             oGridViewRow.Cells.Add(CreateTableCellForGridView("Marketing Source", 8, Color.Black, Color.FromArgb(255, 204, 153)));            

            //Add Header 8
            oGridViewRow.Cells.Add(CreateTableCellForGridView("Demographic Information",16,Color.Black, Color.FromArgb(153,204,255)));            

            oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);
        }
    }

    private TableCell CreateTableCellForGridView(string cellText, int columnSpan, Color foreColor, Color backColor)
    {
        TableCell oTableCell = new TableCell();
        oTableCell.Text = cellText;
        oTableCell.ColumnSpan = columnSpan;
        oTableCell.ForeColor = foreColor;
        oTableCell.BackColor = backColor;
        oTableCell.HorizontalAlign = HorizontalAlign.Center;
        return oTableCell;
    }
}
