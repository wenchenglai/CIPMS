using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Odbc;
using System.IO;
using CIPMSBC;

public partial class Enrollment_Upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public DataTable GetDataTable(string filePath, string fileName, string columns)
    {
        OdbcConnection conn;
        
        DataTable dt = new DataTable();
        OdbcDataAdapter da;
        string connectionString;
        connectionString = @"Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + filePath + ";";
        conn = new OdbcConnection(connectionString); //we only pass it the folder.  The csv file import is in the query which follows 
        conn.Open();
        try
        {            
            da = new OdbcDataAdapter("select "+columns+" from [" + fileName + "]", conn);
            da.Fill(dt);
            return dt;
        }

        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            conn.Close();
            conn = null; da = null; dt = null;
        }
    }

    public DataTable GetExcelDataTable(string filePath, string fileName, string columns)
    {
        OleDbConnection conn;
        DataTable dt = new DataTable();
        OleDbDataAdapter da;
        string connectionString;
        connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + fileName + ";Extended Properties=Excel 8.0";
        conn = new OleDbConnection(connectionString); //we only pass it the folder.  The csv file import is in the query which follows 
        conn.Open();
        try
        {
            da = new OleDbDataAdapter("select [reason/description],FJCID from [Import-May-21-2010_CIPMS-ANRepo$]", conn);
            da.Fill(dt);
            return dt;
        }

        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            conn.Close();
            conn = null; da = null; dt = null;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Upload file to the database
        string strFolder = string.Empty;
        strFolder = ConfigurationManager.AppSettings["UploadFilePath"].ToString();
        try
        {
            if (this.fileUpload.HasFile != false)
            {
                String tmpExt = GetExtension(this.fileUpload.FileName);
                if (tmpExt.ToLower() == ".csv" || tmpExt.ToLower() == ".xls") //Check to make sure it is the correct file type
                {
                    if (Directory.Exists(strFolder))
                    {
                        ProcessFile(strFolder);
                    }
                    else
                    {
                        Directory.CreateDirectory(strFolder);
                        ProcessFile(strFolder);
                    }
                }
                else
                {
                    //This is error label on the page that would be set if there was a problem.
                    this.ErrorText.Text = "Sorry, you can only upload .csv files.  Please select a different file";
                    ErrorText.Visible = true;
                    lblConfirmationText.Visible = false;
                }
            }
            else
            {
                this.ErrorText.Text = "Sorry, you haven't seleced any file to upload. Please use the browse button to select the file and try again.";
                ErrorText.Visible = true;
                lblConfirmationText.Visible = false;
                grdviewUploadeData.Visible = false;
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("Too few parameters. Expected 1"))
                this.ErrorText.Text = "Sorry, uploaded .csv file doesnt have all the columns required.  Please verify the file and try again.";
            else
                this.ErrorText.Text = "Sorry, there was an error uploading your file.  Please select a different file or try again.";
            ErrorText.Visible = true;
            lblConfirmationText.Visible = false;
        }
        finally
        {
            if(File.Exists(strFolder + this.fileUpload.FileName))
            {
                File.Delete(strFolder + this.fileUpload.FileName);
            }
        }
    }

    private void ProcessFile(string strFolder)
    {
        string[] FJCIDList = null;
        string[] FJCIDList1 = null;
        DataTable dt=null;
        fileUpload.SaveAs(strFolder + Server.UrlEncode(fileUpload.FileName));

        if (CheckColumnExisiting() == false)
        {
            this.ErrorText.Text = "Sorry, uploaded .csv file doesnt have all the columns required.  Please verify the file and try again";
            ErrorText.Visible = true;
            lblConfirmationText.Visible = false;
            grdviewUploadeData.Width = Unit.Percentage(500);
            grdviewUploadeData.DataSource = GetDataTable(strFolder, fileUpload.FileName, "*");
            grdviewUploadeData.DataBind();
            grdviewUploadeData.Visible = true;
        }
        else
        {
            if (ddlUploadType.SelectedValue == "1")
            {
                dt = GetDataTable(strFolder, fileUpload.FileName, "CamperFJCID, IsPJLValid");
                DataRow[] drArray = dt.Select("IsPJLValid='yes'");
                FJCIDList = new string[drArray.Length];
                Char ch = '\'';
                for (int i = 0; i < drArray.Length; i++)
                {
                    FJCIDList[i] = drArray[i].ItemArray[0].ToString();
                    FJCIDList[i] = FJCIDList[i].ToString().TrimStart(ch);
                    FJCIDList[i] = FJCIDList[i].ToString().TrimEnd(ch);
                }
            }
            else if (ddlUploadType.SelectedValue == "2")
            {
                dt = GetDataTable(strFolder, fileUpload.FileName, "FJCID,EmailDeliveryStatus");
                DataRow[] drArray = dt.Select("EmailDeliveryStatus='yes'");
                FJCIDList = new string[drArray.Length];
                Char ch = '\'';
                for (int i = 0; i < drArray.Length; i++)
                {
                    FJCIDList[i] = drArray[i].ItemArray[0].ToString();
                    FJCIDList[i] = FJCIDList[i].ToString().TrimStart(ch);
                    FJCIDList[i] = FJCIDList[i].ToString().TrimEnd(ch);
                }

                DataRow[] drArray1 = dt.Select("EmailDeliveryStatus='no'");
                FJCIDList1 = new string[drArray1.Length];
                ch = '\'';
                for (int i = 0; i < drArray1.Length; i++)
                {
                    FJCIDList1[i] = drArray1[i].ItemArray[0].ToString();
                    FJCIDList1[i] = FJCIDList1[i].ToString().TrimStart(ch);
                    FJCIDList1[i] = FJCIDList1[i].ToString().TrimEnd(ch);
                }

            }
            else if (ddlUploadType.SelectedValue == "3")
            {
                dt = GetExcelDataTable(strFolder, fileUpload.FileName, "reason/description,FJCID");
                DataRow[] drArray = dt.Select("[reason/description]='email address not unique'");
                FJCIDList = new string[drArray.Length];
                Char ch = '\'';
                for (int i = 0; i < drArray.Length; i++)
                {
                    FJCIDList[i] = drArray[i].ItemArray[1].ToString();
                    FJCIDList[i] = FJCIDList[i].ToString().TrimStart(ch);
                    FJCIDList[i] = FJCIDList[i].ToString().TrimEnd(ch);
                }

            }

                if (FJCIDList.Length > 0)
                {
                    if (ddlUploadType.SelectedValue == "1")
                    {
                        int rowsAffected = UpdatePJLCamperStatus(FJCIDList);
                        if (rowsAffected > 0)
                        {
                            lblConfirmationText.Text = "No of RowsAffected: " + rowsAffected + ". File uploaded successfully, please see the data uploaded (below)";
                        }
                        else
                        {
                            lblConfirmationText.Text = "No records updated, these records might already been updated before. Please verify the data (below) and try again";
                        }
                    }
                    else if (ddlUploadType.SelectedValue == "2")
                    {
                        int rowsAffected = UpdateANCamperStatus(FJCIDList);
                        int rowsAffected1 = UpdateNODANCamperStatus(FJCIDList1);
                        if (rowsAffected > 0)
                        {
                            lblConfirmationText.Text = "No of RowsAffected: " + (rowsAffected + rowsAffected1) + ". File uploaded successfully, please see the data uploaded (below)";
                        }
                        else
                        {
                            lblConfirmationText.Text = "No records updated, these records might already been updated before. Please verify the data (below) and try again";
                        }
                    }
                    else
                    {
                        int rowsAffected = ResetANStatus(FJCIDList);
                        if (rowsAffected > 0)
                        {
                            lblConfirmationText.Text = "No of RowsAffected: " + (rowsAffected) + ". File uploaded successfully, please see the data uploaded (below)";
                        }
                        else
                        {
                            lblConfirmationText.Text = "No records updated, these records might already been updated before. Please verify the data (below) and try again";
                        }
                    }
                }
                else
                    lblConfirmationText.Text = "No records available to update from the file uploaded. Please verify the data (below) and try again.";
                grdviewUploadeData.DataSource = dt;
                grdviewUploadeData.DataBind();
                grdviewUploadeData.Visible = true;
                grdviewUploadeData.Width = Unit.Percentage(70.0);
                lblConfirmationText.Visible = true;
                ErrorText.Visible = false;
            }
        
    }

    private int UpdatePJLCamperStatus(String[] strFJCIDArray)
    {
        CamperApplication objCA = new CamperApplication();
        string FJCIDs = String.Join(",", strFJCIDArray);
        return objCA.UpdatePJLCamperStatus(FJCIDs, 1);
    }

    private int UpdateANCamperStatus(String[] strFJCIDArray)
    {
        CamperApplication objCA = new CamperApplication();
        string FJCIDs = String.Join(",", strFJCIDArray);
        return objCA.UpdateANStatus(FJCIDs,1);
    }

    private int UpdateNODANCamperStatus(String[] strFJCIDArray)
    {
        CamperApplication objCA = new CamperApplication();
        string FJCIDs = String.Join(",", strFJCIDArray);
        return objCA.UpdateANStatus(FJCIDs, 0);
    }

    private int ResetANStatus(String[] strFJCIDArray)
    {
        CamperApplication objCA = new CamperApplication();
        string FJCIDs = String.Join(",", strFJCIDArray);
        return objCA.ResetANStatus(FJCIDs);
    }

    private bool CheckColumnExisiting()
    {
        DataTable dt=null;

        try
        {
            if (ddlUploadType.SelectedValue == "1")
            {
               dt = GetDataTable(ConfigurationManager.AppSettings["UploadFilePath"].ToString(), fileUpload.FileName, "CamperFJCID,IsPJLValid");
            }
            else if (ddlUploadType.SelectedValue == "2")
            {
                dt = GetDataTable(ConfigurationManager.AppSettings["UploadFilePath"].ToString(), fileUpload.FileName, "FJCID,EmailDeliveryStatus");
            }
            else if (ddlUploadType.SelectedValue == "3")
            {
                dt = GetExcelDataTable(ConfigurationManager.AppSettings["UploadFilePath"].ToString(), fileUpload.FileName, "FJCID,reason/description");
            }
            
            if (dt.Columns.Count >= 2)
                return true;
        }
        catch (Exception ex)
        {
            return false;
        }
        return false;
    }

    private string GetExtension(string fileName)
    {
        return fileName.Substring(fileName.LastIndexOf('.'));
    }

   
}
