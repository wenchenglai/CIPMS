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

public partial class Calendar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int iDisplayYear = 0;
            int iDisplayMonth = 1;
            /*int iDisplayMonth = 6;//June
            //pnlCalStartDt.Style.Add("position", "absolute");
            //pnlCalStartDt.Style.Add("top", "420px");
            //pnlCalStartDt.Style.Add("left", "400px");
            //pnlCalStartDt.Visible = true;

            if (DateTime.Now.Month > iDisplayMonth) //if it is July
                iDisplayYear = DateTime.Now.Year + 1;
            else
                iDisplayYear = DateTime.Now.Year;*/
            string campSessionStartMonth = ConfigurationManager.AppSettings["CampSessionStartMonth"];
            string campSessionEndMonth = ConfigurationManager.AppSettings["CampSessionEndMonth"];

            string campSessionStartYear = ConfigurationManager.AppSettings["CampSessionStartYear"];
            string campSessionEndYear = ConfigurationManager.AppSettings["CampSessionEndYear"];
            int startYear, endYear, startMonth, endMonth = 0;

            int.TryParse(campSessionStartYear, out startYear);
            int.TryParse(campSessionEndYear, out endYear);
            int.TryParse(campSessionStartMonth, out startMonth);
            int.TryParse(campSessionEndMonth, out endMonth);

            if (campSessionStartYear == "*" || campSessionEndYear == "*" || campSessionStartMonth == "*" || campSessionEndMonth == "*" || startYear > endYear)
            { iDisplayMonth = DateTime.Now.Month; iDisplayYear = DateTime.Now.Year; }
            else
            {
                iDisplayMonth = Int32.Parse(ConfigurationManager.AppSettings["CampSessionStartMonth"]);
                iDisplayYear = startYear;
            }

            //new CIPMSBC.CamperApplication().

            calStartDt.VisibleDate = new DateTime(iDisplayYear, iDisplayMonth, 1);
            calStartDt.PrevMonthText = string.Empty;
        }
    }

    protected void calStartDt_SelectionChanged(object sender, EventArgs e)
    {
        string strScript;
        string strDateValue = calStartDt.SelectedDate.ToString("MM/dd/yyyy");
        string strTxtObj = Request.QueryString["txtBox"].ToString();
        ltlJavascript.Text = "<script language=\"javascript\" > \n";
        ltlJavascript.Text = ltlJavascript.Text + "window.opener.document.getElementById('" + strTxtObj + "').value='" + strDateValue + "'; \n";
        ltlJavascript.Text = ltlJavascript.Text + "self.close();\n ";
        ltlJavascript.Text = ltlJavascript.Text + "</script>";
    }

    protected void OnCalendar_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        string campSessionStartMonth = ConfigurationManager.AppSettings["CampSessionStartMonth"];
        string campSessionEndMonth = ConfigurationManager.AppSettings["CampSessionEndMonth"];

        string campSessionStartYear = ConfigurationManager.AppSettings["CampSessionStartYear"];
        string campSessionEndYear = ConfigurationManager.AppSettings["CampSessionEndYear"];
        int startYear, endYear, startMonth, endMonth = 0;

        int.TryParse(campSessionStartYear, out startYear);
        int.TryParse(campSessionEndYear, out endYear);
        int.TryParse(campSessionStartMonth, out startMonth);
        int.TryParse(campSessionEndMonth, out endMonth);

        //if any of these values are marked as * or start year is greater than end year in both the case the calendar allows camper to navigate to any month
        if (campSessionStartYear == "*" || campSessionEndYear == "*" || campSessionStartMonth == "*" || campSessionEndMonth == "*" || startYear > endYear)
        { }

        else if (startYear == endYear)
        {
            if (startMonth <= endMonth)
            {
                if (e.NewDate.Month <= startMonth) calStartDt.PrevMonthText = ""; else { if (calStartDt.PrevMonthText.Equals(string.Empty)) calStartDt.PrevMonthText = "<"; }
                if (e.NewDate.Month >= endMonth) calStartDt.NextMonthText = ""; else { if (calStartDt.NextMonthText.Equals(string.Empty)) calStartDt.NextMonthText = ">"; }
            }
        }
        else if (startYear < endYear)
        {
            if (startYear == e.NewDate.Year)
            {
                if (e.NewDate.Month <= startMonth) calStartDt.PrevMonthText = "";
                else { if (calStartDt.PrevMonthText.Equals(string.Empty)) calStartDt.PrevMonthText = "<"; }
            }
            if (endYear == e.NewDate.Year)
            {
                if (e.NewDate.Month >= endMonth) calStartDt.NextMonthText = "";
                else { if (calStartDt.NextMonthText.Equals(string.Empty)) calStartDt.NextMonthText = ">"; }
            }
        }
        else { if (calStartDt.PrevMonthText.Equals(string.Empty)) calStartDt.PrevMonthText = "<"; if (calStartDt.NextMonthText.Equals(string.Empty)) calStartDt.NextMonthText = ">"; }        
    }
}
