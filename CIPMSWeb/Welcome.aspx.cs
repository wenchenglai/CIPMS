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
using System.Data.SqlClient;

public partial class Welcome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        comformationInfo.Visible = true;
        submitemail.Visible = false;
        string sEmail = email.Text.Trim();
        CIPDataAccess dal = new CIPDataAccess();
        int rowsaffected;
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@email", sEmail);

            rowsaffected = dal.ExecuteNonQuery("[usp_InsertRegistrationEmail]", param);
        }
        catch { }
    }
}
