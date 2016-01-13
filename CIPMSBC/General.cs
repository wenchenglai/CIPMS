using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.ComponentModel;
using System.Configuration;
using CIPMSOfficeObjects;
using System.Reflection;
namespace CIPMSBC
{
    public class General
    {
        //to fill the grid for camper details
        public DataSet get_AllFederations()
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsFederations;
                var param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "All");
                dsFederations = dal.getDataset("usp_GetAllFederations", param);
                return dsFederations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public DataSet get_AllFederationsFJCFunding()
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsFederations;
                var param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "FJCFunding");
                dsFederations = dal.getDataset("usp_GetAllFederations", param);
                return dsFederations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to fill the country dropdown  -added by sandhya
        public DataSet get_AllCountries()
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsCountries;
                dsCountries = dal.getDataset("usp_GetAllContries", null);

                return dsCountries;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to fill the Camps dropdown
        public DataSet get_AllCamps(string CampYear, int fedID = -1)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                DataSet dsCamps;
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@CampYear", CampYear);
                param[1] = new SqlParameter("@FedID", fedID);
                dsCamps = dal.getDataset("usp_GetAllCamps", param);

                return dsCamps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to fill the Camps dropdown
        public DataSet get_AllCampsBackend(string CampYear)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                DataSet dsCamps;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CampYear", CampYear);
                dsCamps = dal.getDataset("usp_GetAllCamps", param);
                for (int i = 0; i < dsCamps.Tables[0].Rows.Count; i++)
                {
                    if (dsCamps.Tables[0].Rows[i]["Camp"].ToString().ToLower() == "camp menorah")
                        dsCamps.Tables[0].Rows.RemoveAt(i);
                }
                return dsCamps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to fill the admin search camps list
        public DataSet get_AllCampsList(string CampYear)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                DataSet dsCamps;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CampYear", CampYear);
                dsCamps = dal.getDataset("usp_GetAllCampsList", param);
                for (int i = 0; i < dsCamps.Tables[0].Rows.Count; i++)
                {
                    if (dsCamps.Tables[0].Rows[i]["Camp"].ToString().ToLower() == "camp menorah")
                        dsCamps.Tables[0].Rows.RemoveAt(i);
                }
                return dsCamps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }
        
		//to fill the Status dorpdown/list
        public DataSet get_AllStatus()
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsStatus;
                dsStatus = dal.getDataset("usp_GetAllStatus", null);
                return dsStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to fill the list of users
        public DataSet get_Users()
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsUsers;
                dsUsers = dal.getDataset("usp_GetAllUsers", null);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to fill the state values to the dropdown
        public DataSet get_States()
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsStates;
                dsStates = dal.getDataset("USP_GetAllStates", null);
                return dsStates;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to get all the cities based on the state selected
        public DataSet get_Cities(string stateId)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@State", stateId);
                DataSet dsCities;
                dsCities = dal.getDataset("[USP_GetCities]", param);
                return dsCities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to get all the cities based on the state selected
        public DataSet get_CityState(string ZipCode, string CountryCode)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ZipCode", ZipCode);
                param[1] = new SqlParameter("@CountryCode", CountryCode);
                DataSet dsCityState;
                dsCityState = dal.getDataset("[usp_GetCityState]", param);
                return dsCityState;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to get all the cities based on the state selected
        public DataSet get_ApplicationChangeHistory(string FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FJCID", FJCID);
                DataSet dsApplicationHistory;
                dsApplicationHistory = dal.getDataset("[usp_getApplicationChangeHistory]", param);
                return dsApplicationHistory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to get all the Camps based on FederationID
        //TV: 02/2009 - changed function into an overloaded function, and removed most
        //of the logic from this function into the version that accepts a string paramter
        //to keep all of the logic in one place - the overloaded function will provide the
        //same functionality as this function, plus allow the ability to handle a comma
        //delimited list of FederationIDs
        public DataSet GetFedCamps(int FedID,string CampYear,bool isJDS = false)
        {
            return GetFedCamps(FedID.ToString(),CampYear, isJDS);
        }

        //*********************************************************************************************
        // Name:            GetFedCamps
        // Description:     Will get all the Camps associated with the list of Federations in the
        //                  input parameter. (Overloaded method)
        //
        // Parameters:      sFedIDs - a comma delimited list of Federations IDs
        // Returns:         DataSet - will contain the list of Camp records
        // History:         02/2009 - TV: Initial coding. Originally added for Issue # 4-002
        //*********************************************************************************************
        public DataSet GetFedCamps(string sFedIDs,string CampYear, bool isJDS = false)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                string sProcName = "";
                string sParamName = "";

                if (sFedIDs.Contains(",") == true)
                {
                    //note the difference in proc name - DOES contain
                    //an "s" after the word "Federation"
                    sProcName = "[usp_GetFederationsCamps]";
                    sParamName = "@FedIDs";
                }
                else
                {
                    //note the difference in proc name - it DOES NOT 
                    //contains an "s" after the word "Federation"
                    sProcName = "[usp_GetFederationCamps]";
                    sParamName = "@FedID";
                }

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter(sParamName, sFedIDs);
                param[1] = new SqlParameter("@CampYear", CampYear);
                param[2] = new SqlParameter("@isJDS", isJDS);
                DataSet dsFederationsCamps;

                dsFederationsCamps = dal.getDataset(sProcName, param);
                for (int i = 0; i < dsFederationsCamps.Tables[0].Rows.Count; i++)
                {
                    if (dsFederationsCamps.Tables[0].Rows[i]["Camp"].ToString().ToLower() == "camp menorah")
                        dsFederationsCamps.Tables[0].Rows.RemoveAt(i);
                }
                return dsFederationsCamps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to get all the Camps based on UserID
        public DataSet GetUserCamps(int UserID,int CampYear)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@UsrID", UserID);
                param[1] = new SqlParameter("@CampYear", CampYear);
                DataSet dsUsrCamps;
                dsUsrCamps = dal.getDataset("[usp_GetUserCamps]", param);
                return dsUsrCamps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to get all the camps for a given state.
        public DataSet get_CampsForState(string stateId)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@State", stateId);
                DataSet dsCamps;
                dsCamps = dal.getDataset("[usp_GetCampsByState]", param);
                for (int i = 0; i < dsCamps.Tables[0].Rows.Count; i++)
                {
                    if (dsCamps.Tables[0].Rows[i]["Camp"].ToString().ToLower() == "camp menorah")
                        dsCamps.Tables[0].Rows.RemoveAt(i);
                }
                return dsCamps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to get all the camps for a given state.   
        public DataSet get_CampsForFederationState(int FederationID, string stateId)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FederationID", FederationID);
                param[1] = new SqlParameter("@State", stateId);
                DataSet dsCamps;
                dsCamps = dal.getDataset("[usp_GetCampsByFederationState]", param);
                for (int i = 0; i < dsCamps.Tables[0].Rows.Count; i++)
                {
                    if (dsCamps.Tables[0].Rows[i]["Camp"].ToString().ToLower() == "camp menorah")
                        dsCamps.Tables[0].Rows.RemoveAt(i);
                }
                return dsCamps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to get all the users for a given federation.
        public DataSet GetUsersByFederation(string strFedID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FedID", strFedID);
                DataSet dsCamps;
                dsCamps = dal.getDataset("[usp_GetUsersByFederation]", param);
                return dsCamps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to get all the details like fedferation name and URL etc for a given federation.
        //TV: 02/2009 - Issue # 4-002: added new stored proc to handle more than one
        //Federation listed via a comma delimted list
        public DataSet GetFederationDetails(string strFedID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                //***********
                //TV: 02/2009 - Issue # 4-002:
                string sProcName = "";
                string sParamName = "";

                if (strFedID.Contains(",") == true)
                {
                    //note the difference in proc name - DOES contain
                    //an "s" after the word "Federation"
                    sProcName = "[usp_GetFederationsDetails]";
                    sParamName = "@FedIDs";
                }
                else
                {
                    //note the difference in proc name - it DOES NOT 
                    //contains an "s" after the word "Federation"
                    sProcName = "[usp_GetFederationDetails]";
                    sParamName = "@FederationID";
                }
                //***********

                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter(sParamName, strFedID);
                DataSet dsFedDetails;

                dsFedDetails = dal.getDataset(sProcName, param);
                return dsFedDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to fill the Roles dropdown
        public DataSet get_AllRoles()
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsRoles;
                dsRoles = dal.getDataset("usp_GetAllUserRoles", null);
                return dsRoles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to get the federation details assosiated to the zipcode.
        public DataSet GetFederationForZipCode(string strZipcode)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                // in clase if the zip code is Canadian
                if (strZipcode.Length > 6 && !strZipcode.StartsWith("T"))
                    strZipcode = strZipcode.Substring(0, 3);

                param[0] = new SqlParameter("@Zipcode", strZipcode);
                DataSet dsFedDetails;
                dsFedDetails = dal.getDataset("[usp_GetFederationForZipCode]", param);
                return dsFedDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to get all the Camp Sessions for a Camp
        public DataSet GetCampSessionsForCamp(int CampID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CampID", CampID);
                DataSet dsCampSessions;
                dsCampSessions = dal.getDataset("[usp_GetCampSessionsByCamp]", param);
                return dsCampSessions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to get all the Camp Session details
        public DataSet GetCampSessionDetail(int CampSessionID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CampSessionID", CampSessionID);
                DataSet dsCampSessionDetail;
                dsCampSessionDetail = dal.getDataset("[usp_GetCampSessionDetail]", param);
                return dsCampSessionDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //Get Next possible status for a given role and current status
        public DataSet GetNextPossibleStatus(int RoleID, int CurrentStatus, int FederationID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Role", RoleID);
                param[1] = new SqlParameter("@CurrentStatus", CurrentStatus);
                param[2] = new SqlParameter("FederationID", FederationID);
                DataSet dsStatus;
                dsStatus = dal.getDataset("[usp_GetNextPossibleStatus]", param);
                return dsStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to fill the School values to the dropdown
        public DataSet GetAllSchoolList(string CampYear)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsSchools;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CampYear", CampYear);
                dsSchools = dal.getDataset("usp_GetAllSchoolList",param);
                return dsSchools;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to get all the Camp Session details
        public DataSet GetSchoolListByFederation(int FederationID,string CampYear)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FederationID", FederationID);
                param[1] = new SqlParameter("@CampYear", CampYear);
                DataSet dsSchoolListByFederation;
                dsSchoolListByFederation = dal.getDataset("[usp_GetSchoolListByFederation]", param);
                return dsSchoolListByFederation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to check whether the given expression is a date
        public Boolean IsDate(string Date)
        {
            DateTime convertdate;
            if (DateTime.TryParse(Date, out convertdate))
            {
                return true;
            }
            else
                return false;
        }

        //to get the Grade values to be displayed in the Questionnaire
        public DataTable getGrades(string fedId, string campYear)
        {
            var dtGrades = new DataTable();
            dtGrades.Columns.Add(new DataColumn("EligibleGrade"));

            for (int i = 1; i <= 12; i++)
            {
                DataRow dr = dtGrades.NewRow();
                dr["EligibleGrade"] = i.ToString();
                dtGrades.Rows.Add(dr);
            }
            return dtGrades;
        }

        //to get the Synagogue list.
        public DataSet GetSynagogueListByFederation(int FederationID,string CampYear)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FederationID", FederationID);
                param[1] = new SqlParameter("@CampYear", CampYear);
                DataSet dsSynagogueListByFederation;
                dsSynagogueListByFederation = dal.getDataset("[usp_GetSynagogueListByFederation]", param);
                return dsSynagogueListByFederation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }
        
		//to get the JCC list.
        public DataSet GetJCCListByFederation(int FederationID, string CampYear)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FederationID", FederationID);
                param[1] = new SqlParameter("@CampYear", CampYear);
                DataSet dsJCCListByFederation;
                dsJCCListByFederation = dal.getDataset("[usp_GetJCCListByFederation]", param);
                return dsJCCListByFederation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public DataSet GetAllSchoolTypes()
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsCamps;
                SqlParameter[] param = new SqlParameter[1];
                dsCamps = dal.getDataset("usp_SchoolTypeSelect", null);
                return dsCamps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }
        
		//to fill the Camps dropdown
        public DataSet GetNationalCamps(string CampYear)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsCamps;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CampYear", CampYear);
                dsCamps = dal.getDataset("usp_GetNationalCamps", param);
                return dsCamps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to get national program for camp
        public DataSet GetNationalProgram(int CampID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CampID", CampID);
                DataSet dsNationalPrograms;
                dsNationalPrograms = dal.getDataset("[usp_GetNationalProgram]", param);
                return dsNationalPrograms;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to get the LA Federation
        public DataSet GetLAFederationForCamper(string strFirstName, string strLastName,string strDateOfBirth)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                DateTime dtDateOfBirth = Convert.ToDateTime(strDateOfBirth);
                strDateOfBirth=dtDateOfBirth.Month+"/"+dtDateOfBirth.Day+"/"+dtDateOfBirth.Year;
                param[0] = new SqlParameter("@FirstName", strFirstName);
                param[1] = new SqlParameter("@LastName", strLastName);
                param[2] = new SqlParameter("@DateOfBirth", dtDateOfBirth.ToString()); 
                DataSet dsFedDetails;
                dsFedDetails = dal.getDataset("[usp_GetLAFederationForCamper]", param);
                return dsFedDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to get the OC Federation
        public DataSet GetOCFederationForCamper(string strFirstName, string strLastName)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FirstName", strFirstName);
                param[1] = new SqlParameter("@LastName", strLastName);
                DataSet dsFedDetails;
                dsFedDetails = dal.getDataset("[usp_GetOCFederationForCamper]", param);
                return dsFedDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //*********************************************************************************************
        // Name:            GetConfigValue
        // Description:     Will get the Configuration value (ConfigValue) from the Config table 
        //                  (tblConfig) for the given ConfigName.
        //
        // Parameters:      sConfigName - the name of the Configuration setting whose value is being 
        //                                requested
        // Returns:         DataSet - will contain the ConfigValue for the given ConfigName
        // History:         03/2009 - TV: Initial coding. Originally added for Issue # A-016
        //*********************************************************************************************
        public DataSet GetConfigValue(string sConfigName)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ConfigName", sConfigName);
                DataSet dsConfigValue;
                dsConfigValue = dal.getDataset("[usp_GetConfigValue]", param);
                return dsConfigValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to get the state for a Camp
        public DataSet GetCampState(int CampID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CampID", CampID);
                DataSet dsCampState;
                dsCampState = dal.getDataset("[usp_GetCampState]", param);
                return dsCampState;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //*********************************************************************************************
        // Name:            IsApplicationReadOnly
        // Description:     Will determin if the camper application for the given FJCID is a 
        //                  "read-only" application or not. To make it read only, the application
        //                  needs to have been submitted or modified by an Admin user.
        //                  (most of this code was copied from another location in the CIMPS project in
        //                  an attempt to cetralize this logic in one place)
        //
        // Parameters:      sFJCID        - the FCJID for the application in question
        //                  sCamperIserID - the CamperUserID for the application
        // Returns:         bool    - true  - the application is a read only type of application
        //                            false - the application is NOT a read only type of application
        // History:         03/2009 - TV: Initial coding.
        //*********************************************************************************************
        public bool IsApplicationReadOnly(string sFJCID, string sCamperUserID)
        {
            bool bReturnCode = false;

            bool isAdminUserEmpty = string.IsNullOrEmpty(Convert.ToString(System.Web.HttpContext.Current.Session["UsrID"]));

            string sSubmittedDate = string.Empty;
            DataSet dsApplSubmitInfo = new DataSet();
            CamperApplication oCamperAppl = new CamperApplication();
            DataRow dr;

            int iModifiedBy = Convert.ToInt32(sCamperUserID);

            dsApplSubmitInfo = oCamperAppl.GetApplicationSubmittedInfo(sFJCID);
            int iCount = dsApplSubmitInfo.Tables[0].Rows.Count;
            if (isAdminUserEmpty && (iCount > 0))
            {
                dr = dsApplSubmitInfo.Tables[0].Rows[0];
                //to get the submitted date
				if (!dr["SubmittedDate"].Equals(DBNull.Value))
                {
					sSubmittedDate = dr["SubmittedDate"].ToString();
                }

                //to get the modified by user6
				if (!dr["ModifiedUser"].Equals(DBNull.Value))
                {
					iModifiedBy = Convert.ToInt32(dr["ModifiedUser"]);
                }

                var currentStatus = (StatusInfo)dr["Status"];
				if (currentStatus != StatusInfo.EligibleContactParentsAagain)
					if (!string.IsNullOrEmpty(sSubmittedDate) || (iModifiedBy != Convert.ToInt32(sCamperUserID) && iModifiedBy > 0 && currentStatus != StatusInfo.WinnerPJLottery))
					{
						//Camper Application has been submitted (or) the Application has been modified by a Admin
						bReturnCode = true;
					}
            }

            return bReturnCode;
        }

        // to get the federation details for given fjcid
        public DataSet GetFedDetailsForFJCID(string FJCID)
        {
            var dal = new CIPDataAccess();
            try
            {
                var param = new SqlParameter[1];
                param[0] = new SqlParameter("@FJCID", FJCID);

                DataSet dsFedDetails;
                dsFedDetails = dal.getDataset("[usp_GetFedDetailsForFJCID]", param);
                return dsFedDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        // to get the aplication submitted status
        public bool IsApplicationSubmitted(string sFJCID)
        {
            bool bReturnCode = false;

            string sSubmittedDate = string.Empty;
            DataSet dsApplSubmitInfo = new DataSet();
            CamperApplication oCamperAppl = new CamperApplication();
            DataRow dr;

            int iModifiedBy = 0;

            dsApplSubmitInfo = oCamperAppl.GetApplicationSubmittedInfo(sFJCID);
            int iCount = dsApplSubmitInfo.Tables[0].Rows.Count;
            if (iCount > 0)
            {
                dr = dsApplSubmitInfo.Tables[0].Rows[0];
                //to get the submitted date
                if (!dr["SUBMITTEDDATE"].Equals(DBNull.Value))
                {
                    sSubmittedDate = dr["SUBMITTEDDATE"].ToString();
                }

                //Camper Application has been submitted (or) the Application has been modified by a Admin
                if (!string.IsNullOrEmpty(sSubmittedDate))
                {
                    bReturnCode = true;
                }
            }

            return bReturnCode;
        }

        /// <summary>
        /// To get all the details like fedferation name and URL etc for a given federation and camp.
        /// </summary>
        /// <param name="strFedID">FederationID (list comma seperated or single id</param>
        /// <param name="strCampID">CampID</param>
        /// <returns></returns>
        public DataSet GetFederationCampContactDetails(string strFedID, string strCampID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@FederationID", strFedID);
                param[1] = new SqlParameter("@CampID", strCampID);
                DataSet dsFedDetails;

                dsFedDetails = dal.getDataset("[usp_GetFederationCampContactDetails]", param);
                return dsFedDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public DataSet GetMiiPReferalCode(string referalCode,string strCampYear)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@ReferalCode", referalCode);
                param[1] = new SqlParameter("@CampYear", strCampYear);
                DataSet dsMiiPReferalCodes = dal.getDataset("[usp_GetMiiPReferalCodes]", param);
                return dsMiiPReferalCodes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        ///to retrieve the Camp on CampID
        public DataSet GetCampByCampID(string strCampID)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsCamps;
                SqlParameter param = new SqlParameter("@CampID", strCampID);
                dsCamps = dal.getDataset("usp_GetCampByCampID", param);
                return dsCamps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        /// <summary>
        /// To retrieve referral code on camp and federationids
        /// </summary>
        /// <param name="strCampID">CampID</param>
        /// <param name="strFederationID">FederationID</param>
        /// <returns></returns>
        public DataSet GetCampReferralCodesByCampIDFederationID(string strCampID, string strFederationID)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsReferralCodes;
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@CampID", strCampID);
                parameters[1] = new SqlParameter("@FederationID", strFederationID);
                dsReferralCodes = dal.getDataset("usp_GetCampReferralCodesByCampIDFederationID", parameters);
                return dsReferralCodes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }
        
		public DataSet GetEmailNotification(string FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                DataSet dsEmailNotification;
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@FJCID", FJCID);
                dsEmailNotification = dal.getDataset("usp_GetEmailNotificationDetails", parameters);
                return dsEmailNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public DataSet GetPJLNotification(string FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                DataSet dsPJLNotification;
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@FJCID", FJCID);
                dsPJLNotification = dal.getDataset("usp_getPJLData", parameters);
                return dsPJLNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public DataSet get_CamperStatusDetils(string strFJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet dsCamperStatusDetails;
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@FJCID", strFJCID);
                dsCamperStatusDetails = dal.getDataset("usp_GetCamperTrackingDetails", parameters);
                return dsCamperStatusDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public void ProduceCSV(DataTable dt, System.IO.StreamWriter file, bool WriteHeader, int colNumberToAddQuotes)
        {
            if (WriteHeader)
            {
                string[] arr = new String[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    arr[i] = dt.Columns[i].ColumnName;
                    arr[i] = GetWriteableValue(arr[i]);
                }
                file.WriteLine(string.Join(",", arr));
            }
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                string[] dataArr = new String[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                     object o ;
                    if (i == colNumberToAddQuotes)
                    {
                       o = "'" + dt.Rows[j][i];
                    }
                    else
                    {
                        o = CheckForDataConsistency(dt.Rows[j][i].ToString());
                    }
                    dataArr[i] = GetWriteableValue(o);
                }
                file.WriteLine(string.Join(",", dataArr));
            }
            file.Close();
        }

        private string CheckForDataConsistency(string value)
        {
            if (String.Equals(value, String.Empty))
            {
                value = "\"\"";
            }
            else if (value.Contains(","))
            {
                value = string.Concat("\"", value, "\"");
            }
            else if (value.Contains("\r"))
            {
                value = value.Replace("\r", " ");
            }
            else if (value.Contains("\n"))
            {
                value = value.Replace("\n", " ");
            }
            else if (value.Contains("\'"))
                value = value.Replace("\'", "\"\'\"");

            return value;
        }

        public void ProduceCSV(DataTable dt, System.IO.StreamWriter file, bool WriteHeader)
        {
            if (WriteHeader)
            {
                string[] arr = new String[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    arr[i] = dt.Columns[i].ColumnName;
                    arr[i] = GetWriteableValue(arr[i]);
                }
                file.WriteLine(string.Join(",", arr));
            }
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                string[] dataArr = new String[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    object o;
                    if (dt.Columns[i].ColumnName == "FJCID" || dt.Columns[i].ColumnName == "Camper FJCID")
                    {
                        o = "'" + dt.Rows[j][i];
                    }
                    else
                    {
                        o = dt.Rows[j][i];
                    }
                    dataArr[i] = GetWriteableValue(o);
                }
                file.WriteLine(string.Join(",", dataArr));
            }
            file.Close();
        }

        public string GetWriteableValue(object o)
        {
            if (o == null || o == Convert.DBNull)
                return "";
            else if (o.ToString().IndexOf(",") == -1)
                return o.ToString();
            else
                return "\"" + o.ToString() + "\"";
        }

        public void ProduceTabDelimitedFile(DataTable dt, System.IO.StreamWriter file, bool WriteHeader, int colNumberToAddQuotes)
        {            
            if (WriteHeader)
            {
                StringBuilder sb = new StringBuilder();
                string[] arr = new String[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    //arr[i] = dt.Columns[i].ColumnName;
                    //arr[i] = GetWriteableValue(arr[i]);
                    if (i < dt.Columns.Count - 1)
                        sb.AppendFormat("{0}\t", GetWriteableValue(dt.Columns[i].ColumnName));
                    else if(i == dt.Columns.Count - 1)
                        sb.AppendFormat("{0}\n",GetWriteableValue(dt.Columns[i].ColumnName));
                }
                //file.WriteLine(string.Join(",",arr);                
                file.WriteLine(sb.ToString());
            }

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                //string[] dataArr = new String[dt.Columns.Count];
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    object o;                    
                    o = dt.Rows[j][i].ToString();
                    
                    if (i < dt.Columns.Count - 1)
                        sb.AppendFormat("{0}\t", GetWriteableValue(o));
                    else if (i == dt.Columns.Count - 1)
                        sb.AppendFormat("{0}\n", GetWriteableValue(o));
                    //dataArr[i] = GetWriteableValue(o);
                }
                //file.WriteLine(string.Join(",", dataArr));                
                file.WriteLine(sb.ToString());
            }
            file.Close();
        }

        public DataSet GetFederationAndQuestionnaireDetails(string strFederationIds, int campYearId)
        {
            var dal = new CIPDataAccess();
            try
            {
                var parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@FederationIds", strFederationIds);
                parameters[1] = new SqlParameter("@CampYearID", campYearId);
                return dal.getDataset("usp_GetFederationAndQuestionnaireDetails", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public void CreateWord(DataTable dt)
        {
            CustomWord objCustomWord = new CustomWord();
           
            
            objCustomWord.CreateWord(dt);
           
        }

        public string GetEligiblityForGrades(string FJCID,string grade)
        {
           
            DataTable dtGrades;
            DataRow dr;
            int i;
            try
            {
                CIPDataAccess dal = new CIPDataAccess();
                DataSet dsFederationGrades=new DataSet();
 
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@FJCID", FJCID);
                parameters[1] = new SqlParameter("@grade", grade);

                dsFederationGrades = dal.getDataset("usp_GetEligiblityForGrades", parameters);
                return dsFederationGrades.Tables[0].Rows[0][0].ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //dal = null;
            }
        }

        public static String GetEnumDescription(Enum e)
        {
            FieldInfo fieldInfo = e.GetType().GetField(e.ToString());

			if (fieldInfo == null)
				return "false";

            DescriptionAttribute[] enumAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (enumAttributes.Length > 0)
            {
                return enumAttributes[0].Description;
            }
            return e.ToString();
        }

        public Boolean ValidateZipCode(string ZipCode,string DisabledFed)
        {
            DataSet dsFederation = new DataSet();
            DataRow dr;

            dsFederation = GetFederationForZipCode(ZipCode);
            if (dsFederation.Tables[0].Rows.Count > 0)
            {
                dr = dsFederation.Tables[0].Rows[0];
                string strFedId = dr["Federation"].ToString();
                string[] DisabledFeds = DisabledFed.Split(',');
                for (int i = 0; i < DisabledFeds.Length; i++)
                {
                    if (DisabledFeds[i] == strFedId)
                    {
                        return true;

                    }
                }
            }
            else
            {
                return true;
            }

            return false;
        }

        public DataSet GetTimeInCampForFederation(int FederationID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet dsTimeInCamp;
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@FederationId", FederationID);
                dsTimeInCamp = dal.getDataset("usp_GetTimeInCampForFederation", parameters);
                return dsTimeInCamp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }        
        }

        public DataSet GetAllCampYears()
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet dsCampYears;
            try
            {
                dsCampYears = dal.getDataset("GetAllCampYears");
                return dsCampYears;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public DataSet GetSchoolType()
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet dsSchoolType;
            try
            {
                dsSchoolType = dal.getDataset("usp_SchoolTypeSelect");
                return dsSchoolType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public DataSet GetPJLCodes(string strCampYear)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsPJLCodes;
                SqlParameter param = new SqlParameter("@CampYear", strCampYear);
                dsPJLCodes = dal.getDataset("[usp_GetPJLCodesCodes]",param);
                return dsPJLCodes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public DataSet GetCurrentYear()
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsCurrentYear;
                dsCurrentYear = dal.getDataset("[usp_GetCurrentYear]");
                return dsCurrentYear;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public DataSet GetJCCByID(string strJccID)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsJcc;
                SqlParameter param = new SqlParameter("@JccID", strJccID);
                dsJcc = dal.getDataset("usp_GetJCCByID", param);
                return dsJcc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public DataSet GetSynagogueByID(string strSynID, int FederationID)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsSyn;
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@ID", strSynID);
                param[1] = new SqlParameter("@FederationID", FederationID);               
                dsSyn = dal.getDataset("usp_GetSynagogueByID", param);
                return dsSyn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public string GetCanadianZipCode(string strZip)
        {
            string CJA = ConfigurationManager.AppSettings["CanadaCJAZipCodes"];
            string Montreal = ConfigurationManager.AppSettings["CanadaMontrealZipCodes"];
            string Toronto = ConfigurationManager.AppSettings["CanadaTorontoZipCodes"];
            //string CJA = "A,B,C,E", Montreal = "G, H, J", Toronto = "L, M, N", 
            string FedId = "";

            if (CJA.IndexOf(strZip.Substring(0, 1)) >= 0)
            {
                // A, B, C, E
                // 2015-11-11 temporarily disable the code below, so AJC zip codes won't be used since it's still using special case zip codes, not fedZipCodes table like Toronto.
                //FedId = "65";
            }
            else if (Montreal.IndexOf(strZip.Substring(0, 1)) >= 0)
            {
                FedId = "69";
            }
            else if (Toronto.IndexOf(strZip.Substring(0, 1)) >= 0)
            {
                FedId = "";
                //2015-05-17 Toronto has its own zip codes list now
                DataSet dsFed = this.GetFederationForZipCode(strZip.Substring(0, 3));
                if (dsFed.Tables.Count > 0)
                {
                    if (dsFed.Tables[0].Rows.Count == 1)
                    {
                        FedId = dsFed.Tables[0].Rows[0][0].ToString();
                    }
                    else if (dsFed.Tables[0].Rows.Count > 1)
                    {
                        FedId = "Duplicate";
                    }
                }
            }
            else if (strZip.Substring(0, 1) == "T")
                FedId = "59";

            return FedId;
        }

        public DataSet GetFederationDetailsUsingCampID(string strFedID, string strCampID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {                
                string sProcName = "";
                sProcName = "[usp_GetFederationDetails]";

                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@FederationID", strFedID);
                param[1] = new SqlParameter("@CampID", strCampID);
                DataSet dsFedDetails;

                dsFedDetails = dal.getDataset(sProcName, param);
                return dsFedDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        //to fill the School values to the dropdown
        public string GetSchoolName(string FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsSchools;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FJCID", FJCID);
                dsSchools = dal.getDataset("usp_GetSchoolName", param);
                return dsSchools.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public DataSet getJWestGrant(string FJCID)
        {
            CIPMSBC.SrchCamperDetails S = new SrchCamperDetails();
            SrchCamperDetails srch = new SrchCamperDetails();
            DataSet dsCamper = srch.SearchCamperDetails(FJCID,"Test");
            return dsCamper;
        }

        public string GetPreviousFJCID(string FJCID,string strFederationId)
        {
            General g = new General();
            DataSet dsCamperDetails = g.getJWestGrant(FJCID);
            
            SrchCamperDetails Srch = new SrchCamperDetails();
            if (dsCamperDetails.Tables[0].Rows.Count > 0)
            {
                DateTime DOB = Convert.ToDateTime(dsCamperDetails.Tables[0].Rows[0][20]);
                DataSet ds = Srch.getReturningCamperDetails(dsCamperDetails.Tables[0].Rows[0][6].ToString(), dsCamperDetails.Tables[0].Rows[0][7].ToString(), DOB.Date.ToString());
                DataRow [] dsExistingCampers = ds.Tables[0].Select("campyearid=2");

                if (dsExistingCampers.Length > 0)
                {
                    return dsExistingCampers[0].ItemArray[0].ToString();
                }
           }
            return string.Empty;
        }
        
		//added by sandhya to get returning camper previous fjcids
        public DataSet GetPreviousFJCIDs(string FJCID)
        {
            General g = new General();
            DataSet dsCamperDetails = g.getJWestGrant(FJCID);
            SrchCamperDetails Srch = new SrchCamperDetails();
            DateTime DOB = Convert.ToDateTime(dsCamperDetails.Tables[0].Rows[0][20]);
            DataSet ds = Srch.getAllReturningCamperDetails(dsCamperDetails.Tables[0].Rows[0][6].ToString(), dsCamperDetails.Tables[0].Rows[0][7].ToString(), DOB.Date.ToString());
            return ds;
        }
        public DataSet GetPreviousManualCamperDetails(string FJCID)
        {
           General g = new General();
            DataSet dsCamperDetails = g.getJWestGrant(FJCID);
            SrchCamperDetails Srch = new SrchCamperDetails();
            DateTime DOB = Convert.ToDateTime(dsCamperDetails.Tables[0].Rows[0][20]);
            DataSet ds = Srch.getManualReturningCamperDetails(dsCamperDetails.Tables[0].Rows[0][6].ToString(), dsCamperDetails.Tables[0].Rows[0][7].ToString(), DOB.Date.ToString());
            return ds;  
        }
        public int ValidateNYZipCode(string ZipCode)
        {
            DataSet dsZipCodeCount;
            CIPDataAccess dal = new CIPDataAccess();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ZipCode", ZipCode);
            dsZipCodeCount = dal.getDataset("usp_ValidateNYZipCode", param);
            return Convert.ToInt32(dsZipCodeCount.Tables[0].Rows[0][0]); 
        }
        //To get the grade range for PPIR
        public string GetGradeEligibilityRange(int FederationID)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsGrades;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FederationID", FederationID);
                dsGrades = dal.getDataset("usp_GetGradeDescription", param);
                return dsGrades.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

    }
}


