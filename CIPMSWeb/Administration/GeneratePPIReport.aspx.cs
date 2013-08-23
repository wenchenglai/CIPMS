using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Administration_GeneratePPIReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
			DirectoryInfo di = new DirectoryInfo(getPPRPath());
            int i = 0;
            foreach (FileInfo fi in di.GetFiles())
            {
                HyperLink HL = new HyperLink();
                HL.ID = "HyperLink" + i++;
                HL.Text = fi.Name;
                HL.NavigateUrl = "GeneratePPIReport.aspx?file=" + fi.Name;
                divLinks.Controls.Add(HL);
                divLinks.Controls.Add(new LiteralControl("<br/>"));
             }
        }

        if (Request["file"] != null)
        {
            string filename;
            filename = Request["file"].ToString();

            string filepath = Request.Params["file"].ToString();
            filename = Path.GetFileName(filepath);
            Response.ContentType = "text/.docx";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
			Response.TransmitFile(getPPRPath() + filename);
            Response.End();
        }
    }

	private string getPPRPath()
	{
		return HttpContext.Current.Request.MapPath(HttpContext.Current.Request.ApplicationPath + ConfigurationManager.AppSettings["ProgramProfileReportPath"]);
	}

    public void lnkbtn_Click(Object sender, EventArgs e)
    {
        string filename;

        if (Request["file"] != null)
        {
            filename = Request["file"].ToString();

            string filepath = Request.Params["file"].ToString();
            filename = Path.GetFileName(filepath);



            Response.ContentType = "text/.docx";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
			Response.TransmitFile(getPPRPath() + filename);
            Response.End();

        }


    }



  
}
