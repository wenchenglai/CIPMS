using System;

public partial class Enrollment_RegisterControls : System.Web.UI.UserControl
{
    public bool isPJL { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            trPJOption.Visible = isPJL;
        }
    }
}
