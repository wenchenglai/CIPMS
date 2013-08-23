using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CIPMSBC;
public partial class GenerateDoc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Charset = "";
        HttpContext.Current.Response.ContentType = "application/msword";

        string strFileName = "GenerateDocument" + ".doc";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);

        StringBuilder strHTMLContent = new StringBuilder();

        strHTMLContent.Append("<h1 title='Heading' align='Center'style='font-family: verdana; font -size: 80 % ;color: black'><u>Document Heading</u> <  / h1 > ".ToString());

        strHTMLContent.Append("<br>".ToString()); strHTMLContent.Append(
          "<table align='Center'>".ToString());

        // Row with Column headers
        strHTMLContent.Append("<tr>".ToString()); strHTMLContent.Append("<td style='width:100px; background:# 99CC00'><b>Column1 <  / b >  <  / td >".ToString());
        strHTMLContent.Append("<td style='width:100px;background:# 99CC00'><b>Column2 <  / b >  <  / td >".ToString());
        strHTMLContent.Append("<tdstyle='width:100px; background:# 99CC00'><b>Column 3</b><  / td >".ToString()); strHTMLContent.Append(" <  / tr > ".ToString());

        // First Row Data
        strHTMLContent.Append("<tr>".ToString()); strHTMLContent.Append(
          "<td style='width:100px'>a</td>".ToString()); strHTMLContent.Append(
         "<td style='width:100px'>b</td>".ToString()); strHTMLContent.Append(
        "<td style='width:100px'>c</td>".ToString()); strHTMLContent.Append("</tr>"
        .ToString());

        // Second Row Data
        strHTMLContent.Append("<tr>".ToString()); strHTMLContent.Append(
          "<td style='width:100px'>d</td>".ToString()); strHTMLContent.Append(
         "<td style='width:100px'>e</td>".ToString()); strHTMLContent.Append(
        "<td style='width:100px'>f</td>".ToString()); strHTMLContent.Append("</tr>"
       .ToString());
        strHTMLContent.Append("</table>".ToString());
        strHTMLContent.Append("<br><br>".ToString()); strHTMLContent.Append(
          "<p align='Center'> Note : This is adynamically generated word document  <  / p > ".ToString());
        HttpContext.Current.Response.Write(strHTMLContent);
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Flush();
    }

    public void GenerateWordDoc(DataTable dt)
    { 
    
    
    }
}
