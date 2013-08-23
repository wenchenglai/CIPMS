using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CIPMSBC;


public partial class Administration_StatisticsReportGeneration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			Populate2012Table();
		}
    }

	void Populate2011Table()
	{
		CamperApplication oCA = new CamperApplication();
		structJWestReportInfo ReportInfo;
		ReportInfo = oCA.GetJWestReportInfo(2011);
		lblTotalCampers.Text = Convert.ToString(ReportInfo.NoOf2010Campers);
		lblBelow17.Text = Convert.ToString(ReportInfo.NoOf201012Campers);
		lblAbove18.Text = Convert.ToString(ReportInfo.Noof201018Campers);
		//lblNotreturning.Text = Convert.ToString(ReportInfo.NoOf2010notreturnedCampers);
		//lblNxtyrTotCampers.Text = Convert.ToString(ReportInfo.NoOf2011Campers);
		lblNxtyrTotCampers.Text = Convert.ToString(ReportInfo.NoOf2010returnedCampers);
		lblReturned201112to12.Text = Convert.ToString(ReportInfo.NoOf201012returned201112Campers);
		lblReturned201112to18.Text = Convert.ToString(ReportInfo.NoOf201012returned201118Campers);
		lblReturned201118to12.Text = Convert.ToString(ReportInfo.NoOf201018returned201112Campers);
		lblReturned201118to18.Text = Convert.ToString(ReportInfo.NoOf201018returned201118Campers);	
	}

	void Populate2012Table()
	{
		CamperApplication oCA = new CamperApplication();
		structJWestReportInfo ReportInfo;
		ReportInfo = oCA.GetJWestReportInfo(2012);
		lbl1.Text = Convert.ToString(ReportInfo.NoOf2010Campers);
		lbl2.Text = Convert.ToString(ReportInfo.NoOf201012Campers);
		lbl3.Text = Convert.ToString(ReportInfo.Noof201018Campers);
		//lblNotreturning.Text = Convert.ToString(ReportInfo.NoOf2010notreturnedCampers);
		//lblNxtyrTotCampers.Text = Convert.ToString(ReportInfo.NoOf2011Campers);
		lbl4.Text = Convert.ToString(ReportInfo.NoOf2010returnedCampers);
		lbl5.Text = Convert.ToString(ReportInfo.NoOf201012returned201112Campers);
		lbl7.Text = Convert.ToString(ReportInfo.NoOf201012returned201118Campers);
		lbl6.Text = Convert.ToString(ReportInfo.NoOf201018returned201112Campers);
		lbl8.Text = Convert.ToString(ReportInfo.NoOf201018returned201118Campers);
	}

	protected void chk2011_CheckedChanged(object sender, EventArgs e)
	{
		if (chk2011.Checked)
		{
			div2011.Visible = true;
			Populate2011Table();
		}
		else
			div2011.Visible = false;
	}
}
