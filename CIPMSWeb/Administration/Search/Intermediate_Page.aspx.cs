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

public partial class Administration_Search_Intermediate_Page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strFEDFJCID = "";
        if (Request.QueryString["FEDFJCID"] != null)
        {
            strFEDFJCID = Request.QueryString["FEDFJCID"].ToString();
            Array arrTemp = strFEDFJCID.Split(',');
            Session["FedId"] = ((string[])(arrTemp))[0];
            Session["FJCID"] = ((string[])(arrTemp))[1];
            Session["STATUS"] = ((string[])(arrTemp))[2];
            Response.Redirect("~/Administration/Search/CamperSummary.aspx?page=wrkq", true);
        }
    }
}
