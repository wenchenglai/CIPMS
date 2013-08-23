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

public partial class Administration_ChangePwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Set Page Heading
            Label lbl = (Label)this.Master.FindControl("lblPageHeading");
            lbl.Text = "Change Password";
            lblMsg.Text = "";        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        UserAdministration objUsrAdmin = new UserAdministration();
        objUsrAdmin.UserId = Convert.ToUInt16(Session["UsrID"]);
        objUsrAdmin.OldPassword = txtOldPwd.Text;
        objUsrAdmin.Password = txtNewPwd.Text;
        try
        {
            string strMsg;
            strMsg = objUsrAdmin.ChangePassword();
           lblMsg.Text = strMsg;           
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objUsrAdmin = null;
        }
    }
}
