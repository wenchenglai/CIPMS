<%@ Application Language="C#" %>
<%@ Import Namespace = "System.IO" %>

<script runat="server">


	CIPMSBC.SrchCamperDetails _objCamperDet = new CIPMSBC.SrchCamperDetails();
		
	void Application_Start(object sender, EventArgs e) 
	{
		// Code that runs on application startup
        int year = 0;
        CIPMSBC.General _objGen = new CIPMSBC.General();        
        System.Data.DataSet dsCampYear = _objGen.GetCurrentYear();
        if (dsCampYear.Tables[0].Rows.Count > 0)
        {
            year = Convert.ToInt32(dsCampYear.Tables[0].Rows[0]["CampYear"]);
        }
        else
        {
            // Error
            year = DateTime.Now.Year;
        }
                
		Application["CampYearID"] = year - 2008;
		Application["CampYear"] = year;
	}
	
	void Application_End(object sender, EventArgs e) 
	{
		//  Code that runs on application shutdown

	}
		
	void Application_Error(object sender, EventArgs e) 
	{
		// Get current exception 
		Exception CurrentException;
		CurrentException = Server.GetLastError();

		// Write error to text file
		try
		{
		   // string LogFilePath = Server.MapPath("ErrorLog.txt");
			string FileName = "ErrorLog" + DateTime.Now.Day +DateTime.Now.Month+DateTime.Now.Year+".txt";
			string LogFilePath = ConfigurationManager.AppSettings["LogFilePath"] + FileName;
			StreamWriter sw = new StreamWriter(LogFilePath,true);
			// Write error to text file
			if (_objCamperDet.FJCID == null)
			{
				string errordata = "No FJCID" + "," + _objCamperDet.UserId + "," + CurrentException.StackTrace.ToString();
				sw.WriteLine();                                
				sw.WriteLine(errordata);
			}
			else
			{
				string errordata = "No FJCID" + "," + _objCamperDet.UserId + "," + CurrentException.StackTrace.ToString();
				sw.WriteLine();
				sw.WriteLine(errordata);
			}
			
			sw.Close();
		}
		catch (Exception ex)
		{
			// There could be a problem when writing to text file
		}
	}

	void Session_Start(object sender, EventArgs e) 
	{
		// Code that runs when a new session is started
	}
   
	
	void Session_End(object sender, EventArgs e) 
	{
		_objCamperDet.UserId = Convert.ToInt32(Session["UsrID"]);
		_objCamperDet.LockUnlockRecord("UnLock");
	}
	   
</script>
