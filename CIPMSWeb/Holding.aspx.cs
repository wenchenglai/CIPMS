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

public partial class Holding : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string FJCID = Session["FJCID"].ToString();
        CamperApplication CamperAppl;
        CamperAppl = new CamperApplication();
        int affected = CamperAppl.InsertHoldingCamper(FJCID);
    }
}
