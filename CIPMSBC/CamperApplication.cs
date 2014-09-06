using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;

namespace CIPMSBC
{
    public class CamperApplication
    {
        //AG 1/27/2009
        //to fill genders values to the dropdown
        public DataSet get_Genders()
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsGenders;
                dsGenders = dal.getDataset("USP_GetAllGenders", null);
                return dsGenders;
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

        //to fill the state values depending on the Federation
        public DataSet get_FederationStates(int FederationID)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsStates;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FederationID", FederationID);
                dsStates = dal.getDataset("usp_GetFederationStates", param);
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

        //to fill the state values to the dropdown
        public DataSet get_CountryStates(int countryID)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Country", countryID);
                DataSet dsStates;
                dsStates = dal.getDataset("usp_GetCountryStates", param);
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

        //to Insert the parent info (step 3 of camper application)
        public int InsertCamperInfo(UserDetails UserInfo, out string OutValue)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[17];
                param[0] = new SqlParameter("@First_Name", UserInfo.FirstName);
                param[1] = new SqlParameter("@Last_Name", UserInfo.LastName);
                param[2] = new SqlParameter("@Street_Address", UserInfo.Address);
                param[3] = new SqlParameter("@City", UserInfo.City);
                param[4] = new SqlParameter("@State", UserInfo.State);
                param[5] = new SqlParameter("@Country", UserInfo.Country);
                param[6] = new SqlParameter("@Zip_Code", UserInfo.ZipCode);
                param[7] = new SqlParameter("@Home_Phone", UserInfo.HomePhone);
                param[8] = new SqlParameter("@Email", UserInfo.PersonalEmail);
                param[9] = new SqlParameter("@DAte_Of_Birth", UserInfo.DateofBirth);
                param[10] = new SqlParameter("@Age", UserInfo.Age);
                param[11] = new SqlParameter("@OFJCID", SqlDbType.NVarChar, 50);
                param[11].Direction = ParameterDirection.Output;
                param[12] = new SqlParameter("@Gender", UserInfo.Gender);
                param[13] = new SqlParameter("@IsJewish", UserInfo.IsJewish);
                param[14] = new SqlParameter("@CMART_MiiP_ReferalCode", UserInfo.CMART_MiiP_ReferalCode);
                param[15] = new SqlParameter("@PJLCode", UserInfo.PJLCode);
                param[16] = new SqlParameter("@NLCode", UserInfo.NLCode);

                rowsaffected = dal.ExecuteNonQuery("[USP_InsertCamperApplication]", out OutValue, param);
                //rowsaffected = 0;
                return rowsaffected;
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

        //to Insert the parent info (step 3 of camper application)
        public int UpdateFederationId(string FJCID, string FEDID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@FederationID", FEDID);

                rowsaffected = dal.ExecuteNonQuery("[usp_UpdateFederationID]", param);
                //rowsaffected = 0;
                return rowsaffected;
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

        //to Insert the parent info (step 3 of camper application)
        public int UpdateCamperInfo(UserDetails CamperInfo)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[19];
                param[0] = new SqlParameter("@First_Name", CamperInfo.FirstName);
                param[1] = new SqlParameter("@Last_Name", CamperInfo.LastName);
                param[2] = new SqlParameter("@Street_Address", CamperInfo.Address);
                param[3] = new SqlParameter("@City", CamperInfo.City);
                param[4] = new SqlParameter("@State", CamperInfo.State);
                param[5] = new SqlParameter("@Country", CamperInfo.Country);
                param[6] = new SqlParameter("@Zip_Code", CamperInfo.ZipCode);
                param[7] = new SqlParameter("@Home_Phone", CamperInfo.HomePhone);
                param[8] = new SqlParameter("@Personal_Email", CamperInfo.PersonalEmail);
                param[9] = new SqlParameter("@DAte_Of_Birth", CamperInfo.DateofBirth);
                param[10] = new SqlParameter("@Age", CamperInfo.Age);
                param[11] = new SqlParameter("@FJCID", CamperInfo.FJCID);
                param[12] = new SqlParameter("@User", CamperInfo.ModifiedBy);
                param[13] = new SqlParameter("@Comment", CamperInfo.Comments);
                param[14] = new SqlParameter("@Gender", CamperInfo.Gender);
                param[15] = new SqlParameter("@IsJewish", CamperInfo.IsJewish);
                param[16] = new SqlParameter("@CMART_MiiP_ReferalCode", CamperInfo.CMART_MiiP_ReferalCode);
                param[17] = new SqlParameter("@PJLCode", CamperInfo.PJLCode);
                param[18] = new SqlParameter("@NLCode", CamperInfo.NLCode);
               

                rowsaffected = dal.ExecuteNonQuery("[usp_UpadteCamperApplication]", param);
                //rowsaffected = 0;
                return rowsaffected;
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

        //to get the Camper Info from the database (step 1 of camper application)
        public UserDetails getCamperInfo(string FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            UserDetails UserInfo = new UserDetails();
            DataSet dsUserInfo = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            DataRow dr;

            try
            {
                param[0] = new SqlParameter("@FJCID", FJCID);
                dsUserInfo = dal.getDataset("usp_GetCamperApplication", param);

                if (dsUserInfo.Tables[0].Rows.Count > 0)
                {
                    dr = dsUserInfo.Tables[0].Rows[0];
                    UserInfo.FirstName = dr["FirstName"].ToString();
                    UserInfo.LastName = dr["LastName"].ToString();
                    UserInfo.ZipCode = dr["Zip"].ToString();
                    UserInfo.Address = dr["Street"].ToString();
                    UserInfo.Country = dr["Country"].ToString();
                    UserInfo.State = dr["State"].ToString();
                    UserInfo.City = dr["City"].ToString();
                    UserInfo.PersonalEmail = dr["PersonalEmail"].ToString();
                    UserInfo.DateofBirth = dr["DateOfBirth"].ToString();
                    UserInfo.Age = dr["Age"].ToString();
                    UserInfo.FJCID = dr["FJCID"].ToString();
                    UserInfo.Gender = dr["Gender"].ToString();
                    UserInfo.HomePhone = dr["HomePhone"].ToString();
                    UserInfo.IsJewish = dr["IsJewish"].ToString();
                    UserInfo.CMART_MiiP_ReferalCode = dr["CMART_MiiP_ReferalCode"].ToString();
                    UserInfo.PJLCode= dr["PJLCode"].ToString();
                    UserInfo.NLCode = dr["NLCode"].ToString();
                }
                return UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
                dsUserInfo.Dispose();
                dsUserInfo = null;
                param = null;
            }
        }

        //to get the Parent Info from the database (step 3 of camper application)
        public UserDetails getParentInfo(string FJCID, string IsParentInfo1)
        {
            CIPDataAccess dal = new CIPDataAccess();
            UserDetails ParentInfo = new UserDetails();
            DataSet dsParentInfo = new DataSet();
            SqlParameter[] param = new SqlParameter[2];
            DataRow dr;

            try
            {
                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@Flag", IsParentInfo1);
                dsParentInfo = dal.getDataset("[usp_GetParentInfo]", param);

                if (dsParentInfo.Tables[0].Rows.Count > 0)
                {
                    dr = dsParentInfo.Tables[0].Rows[0];
                    ParentInfo.FirstName = dr["FirstName"].ToString();
                    ParentInfo.LastName = dr["LastName"].ToString();
                    ParentInfo.ZipCode = dr["Zip"].ToString();
                    ParentInfo.Address = dr["Street"].ToString();
                    ParentInfo.Country = dr["Country"].ToString();
                    ParentInfo.State = dr["State"].ToString();
                    ParentInfo.City = dr["City"].ToString();
                    ParentInfo.PersonalEmail = dr["PersonalEmail"].ToString();
                    ParentInfo.WorkEmail = dr["WorkEmail"].ToString();
                    ParentInfo.HomePhone = dr["HomePhone"].ToString();
                    ParentInfo.WorkPhone = dr["WorkPhone"].ToString();
                    if (IsParentInfo1 == "Y")
                        ParentInfo.Parent1Id = dr["ID"].ToString();
                    else
                        ParentInfo.Parent2Id = dr["ID"].ToString();
                }
                return ParentInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
                dsParentInfo.Dispose();
                dsParentInfo = null;
                param = null;
            }
        }

        //to Insert the parent info (step 3 of camper application)
        public int InsertParentInfo(UserDetails UserInfo)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[13];
                param[0] = new SqlParameter("@FJCID", UserInfo.FJCID);
                param[1] = new SqlParameter("@First_Name", UserInfo.FirstName);
                param[2] = new SqlParameter("@Last_Name", UserInfo.LastName);
                param[3] = new SqlParameter("@Street_Address", UserInfo.Address);
                param[4] = new SqlParameter("@City", UserInfo.City);
                param[5] = new SqlParameter("@State", UserInfo.State);
                param[6] = new SqlParameter("@Country", UserInfo.Country);
                param[7] = new SqlParameter("@Zip_Code", UserInfo.ZipCode);
                param[8] = new SqlParameter("@Home_Phone", UserInfo.HomePhone);
                param[9] = new SqlParameter("@Personal_Email", UserInfo.PersonalEmail);
                param[10] = new SqlParameter("@Work_Phone", UserInfo.WorkPhone);
                param[11] = new SqlParameter("@Work_Email", UserInfo.WorkEmail);
                param[12] = new SqlParameter("@Flag", UserInfo.IsParentInfo1);

                rowsaffected = dal.ExecuteNonQuery("USP_InsertParentInfo", param);
                return rowsaffected;
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
        //added by sandhya
        public int validateNLCode(string NLCode)
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet ds=new DataSet();
            DataRow dr;
            int rowsaffected=-1;
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@NLCode", NLCode);

                ds= dal.getDataset("[usp_ValidateNLCode]", param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //dr = ds.Tables[0].Rows[0];
                    string valid = ds.Tables[0].Rows[0][0].ToString();
                    rowsaffected = Convert.ToInt32(valid);
                   
                }
                return rowsaffected;
                
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

        public void updateNLCode(string NLCode)
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet ds = new DataSet();
            DataRow dr;
            int rowsaffected = -1;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@NLCode", NLCode);
                dal.ExecuteNonQuery("[usp_UpdateNLCode]", param);
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


        public string CheckEligibility(string FJCID,string LastFed,string strCampYear)
        {

            DataSet dsPersonal = new DataSet();
            DataSet dsMiiPReferalCodeDetails = new DataSet();
            UserDetails Info = getCamperInfo(FJCID);
            General objGeneral=new General();
            string strFedId = string.Empty, strNextURL = string.Empty,strCampId=string.Empty;

            if (Info.CMART_MiiP_ReferalCode != string.Empty)
                dsMiiPReferalCodeDetails = objGeneral.GetMiiPReferalCode(Info.CMART_MiiP_ReferalCode, strCampYear);

            DataSet dsFed = objGeneral.GetFederationForZipCode(Info.ZipCode);

            if (dsFed.Tables.Count > 0)
            {
                if (dsFed.Tables[0].Rows.Count > 0)
                {
                    strFedId = dsFed.Tables[0].Rows[0][0].ToString();
                }
            }
            
            if (LastFed == "JWest" && strFedId == "72")
            {                
                strNextURL = "~/Enrollment/SanDiego/Summary.aspx" + "," + "72" + "," + strCampId; 
                return strNextURL;
            }
            else if ((dsMiiPReferalCodeDetails.Tables.Count > 0) && (Info.CMART_MiiP_ReferalCode != string.Empty) && (!LastFed.Contains("MidWest")))
            {
                if (dsMiiPReferalCodeDetails.Tables[0].Rows.Count > 0)
                {
                    DataRow drMiiP = dsMiiPReferalCodeDetails.Tables[0].Rows[0];
                    strFedId = drMiiP["FederationID"].ToString();

                    strNextURL = drMiiP["NavigationURL"].ToString();
                    strCampId = drMiiP["CampID"].ToString();
                    if (drMiiP["CampID"].ToString() == "1146")
                    {
                        if (strNextURL.ToUpper().Contains("URJ/"))
                            strNextURL = strNextURL.Replace("URJ/", "URJ/Acadamy");
                        strNextURL = strNextURL + "," + strFedId + "," + strCampId;
                        LastFed = "MidWest";
                        return strNextURL;
                    }
                    LastFed = "MidWest";
                    strNextURL = strNextURL + "," + "48" + "," + "";
                }
                else if ((Info.PJLCode != string.Empty) && (!LastFed.Contains("PJL")))
                {
                    char ch = ',';
                    //string[] PJLCode = ConfigurationManager.AppSettings["PJLCode"].ToString().Split(ch);
                    DataTable dtCampYearPJLCodes = objGeneral.GetPJLCodes(strCampYear).Tables[0];
                    string[] PJLCode = new string[dtCampYearPJLCodes.Rows.Count];
                    //dtCampYearPJLCodes.Rows.CopyTo(PJLCode, 0);
                    for (int i = 0; i < dtCampYearPJLCodes.Rows.Count; i++)
                    {
                        PJLCode[i] = dtCampYearPJLCodes.Rows[i][0].ToString();
                    }
                    for (int i = 0; i < PJLCode.Length; i++)
                    {
                        if (Info.PJLCode.Trim().ToUpper() == PJLCode[i].ToUpper())
                        {
                            strNextURL = "~/Enrollment/PJL/Summary.aspx";
                            strNextURL = strNextURL + "," + ConfigurationManager.AppSettings["PJL"].ToString() + "," + "";
                            LastFed = "PJL";
                            strFedId = ConfigurationManager.AppSettings["PJL"].ToString();
                            return strNextURL;                            
                        }
                    }


                }
                else //if ((LastFed.Contains("NL")))
                {
                    strNextURL = "Step1_NL.aspx" + "," + "" + "," + "";  //to be redirected to National Landing page
                }
            }
            else if ((Info.PJLCode != string.Empty) && (!LastFed.Contains("PJL")))
            {
                char ch = ',';
                //string[] PJLCode = ConfigurationManager.AppSettings["PJLCode"].ToString().Split(ch);
                DataTable dtCampYearPJLCodes = objGeneral.GetPJLCodes(strCampYear).Tables[0];
                string[] PJLCode = new string[dtCampYearPJLCodes.Rows.Count];
                for (int i = 0; i < dtCampYearPJLCodes.Rows.Count; i++)
                {
                    PJLCode[i] = dtCampYearPJLCodes.Rows[i][0].ToString();
                }
                //dtCampYearPJLCodes.Rows.CopyTo(PJLCode, 0);
                for (int i = 0; i < PJLCode.Length; i++)
                {
                    if (Info.PJLCode.Trim().ToUpper() == PJLCode[i].ToUpper())
                    {
                        strNextURL = "~/Enrollment/PJL/Summary.aspx";
                        strNextURL = strNextURL + "," + ConfigurationManager.AppSettings["PJL"].ToString() + "," + "";
                        LastFed = "PJL";
                        strFedId = ConfigurationManager.AppSettings["PJL"].ToString();
                        return strNextURL;                        
                    }
                }
            }

            else //if ((LastFed.Contains("NL")))
            {
                strNextURL = "Step1_NL.aspx" + "," + "" + "," + "";  //to be redirected to National Landing page
            }
            return strNextURL;
        }

    
        //to Update the parent info (step 3 of camper application)
        public int UpdateParentInfo(UserDetails ParentInfo)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[15];
                param[0] = new SqlParameter("@FJCID", ParentInfo.FJCID);
                param[1] = new SqlParameter("@First_Name", ParentInfo.FirstName);
                param[2] = new SqlParameter("@Last_Name", ParentInfo.LastName);
                param[3] = new SqlParameter("@Street_Address", ParentInfo.Address);
                param[4] = new SqlParameter("@City", ParentInfo.City);
                param[5] = new SqlParameter("@State", ParentInfo.State);
                param[6] = new SqlParameter("@Country", ParentInfo.Country);
                param[7] = new SqlParameter("@Zip_Code", ParentInfo.ZipCode);
                param[8] = new SqlParameter("@Home_Phone", ParentInfo.HomePhone);
                param[9] = new SqlParameter("@Personal_Email", ParentInfo.PersonalEmail);
                param[10] = new SqlParameter("@Work_Phone", ParentInfo.WorkPhone);
                param[11] = new SqlParameter("@Work_Email", ParentInfo.WorkEmail);
                param[12] = new SqlParameter("@Flag", ParentInfo.IsParentInfo1);
                param[13] = new SqlParameter("@User", ParentInfo.ModifiedBy);
                param[14] = new SqlParameter("@Comment", ParentInfo.Comments);

                rowsaffected = dal.ExecuteNonQuery("[usp_UpdateParentInfo]", param);
                return rowsaffected;
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

        //to Insert the Camper Answers (step 2 and 4)
        public int InsertCamperAnswers(string FJCID, string Answers, string ModifiedBy, string Comments)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@Answers", Answers);
                param[2] = new SqlParameter("@userID", ModifiedBy);
                param[3] = new SqlParameter("@Comment", Comments);
                param[4] = new SqlParameter("@originalValue", DBNull.Value.ToString());
                param[5] = new SqlParameter("@changedValue", DBNull.Value.ToString());
                rowsaffected = dal.ExecuteNonQuery("[USP_InsertCamperAnswers]", param);
                return rowsaffected;
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


        public int InsertHoldingCamper(string FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FJCID", FJCID);
                rowsaffected = dal.ExecuteNonQuery("[usp_InsertHoldingCamper]", param);
                return rowsaffected;
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

        
        //to get the Camper Answers (step 2 and 4)
        public DataSet getCamperAnswers(string FJCID, string FromQuestionId, string ToQuestionId, string IsAllQuestions)
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet dsCamperAnswers;

            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@FromQ", FromQuestionId);
                param[2] = new SqlParameter("@ToQ", ToQuestionId);
                param[3] = new SqlParameter("@ALL", IsAllQuestions);

                dsCamperAnswers = dal.getDataset("[usp_GetCamperAnswers]", param);
                return dsCamperAnswers;
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
        public DataSet getCamperApplication(string FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FJCID", FJCID);
                DataSet dsCamperApplications;
                dsCamperApplications = dal.getDataset("[usp_GetCamperApplication]", param);
                return dsCamperApplications;
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
        public DataSet getCamperGrantInfo(string FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FJCID", FJCID);
                DataSet dsCamperGrant;
                dsCamperGrant = dal.getDataset("[usp_GetCamperGrantInfo]", param);
                return dsCamperGrant;
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

        public int getDaysInCamp(string FJCID)
        {
            int days = 0;
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FJCID", FJCID);

                DataSet dsDaysInCamp;
                dsDaysInCamp = dal.getDataset("[usp_GetDaysInCamp]", param);

                if (dsDaysInCamp.Tables[0].Rows.Count > 0)
                {
                    if (!Convert.IsDBNull(dsDaysInCamp.Tables[0].Rows[0]["Days"]))
                        days = Convert.ToInt16(dsDaysInCamp.Tables[0].Rows[0]["Days"]);
                }
                return days;
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

        public int getTimeInCamp(string FJCID)
        {
            int timeInCamp = 0;
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FJCID", FJCID);

                DataSet dsTimeInCamp;
                dsTimeInCamp = dal.getDataset("[usp_GetTimeInCamp]", param);

                if (dsTimeInCamp.Tables[0].Rows.Count > 0)
                {
                    if (!Convert.IsDBNull(dsTimeInCamp.Tables[0].Rows[0]["TimeInCamp"]))
                        timeInCamp = Convert.ToInt16(dsTimeInCamp.Tables[0].Rows[0]["TimeInCamp"]);
                }
                return timeInCamp;
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

        public decimal getCamperGrantForDays(string FJCID, int Days)
        {
            decimal StandardGrant = 0;
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@Days", Days);
                DataSet dsCamperGrant;
                dsCamperGrant = dal.getDataset("[usp_GetCamperGrantForDays]", param);

                if (dsCamperGrant.Tables[0].Rows.Count > 0)
                {
                    if (!Convert.IsDBNull(dsCamperGrant.Tables[0].Rows[0]["StandardGrant"]))
                        StandardGrant = Convert.ToDecimal(dsCamperGrant.Tables[0].Rows[0]["StandardGrant"]);
                }
                return StandardGrant;
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

        public decimal getCamperGrantForTimeInCamp(string FJCID, int Days, int TimeInCamp)
        {
            decimal StandardGrant = 0;
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@Days", Days);
                param[2] = new SqlParameter("@TimeInCamp", TimeInCamp);
                DataSet dsCamperGrant;
                dsCamperGrant = dal.getDataset("[usp_GetCamperGrantForTimeInCamp]", param);

                if (dsCamperGrant.Tables[0].Rows.Count > 0)
                {
                    if (!Convert.IsDBNull(dsCamperGrant.Tables[0].Rows[0]["StandardGrant"]))
                        StandardGrant = Convert.ToDecimal(dsCamperGrant.Tables[0].Rows[0]["StandardGrant"]);
                }
                return StandardGrant;
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
        
		public decimal getCamperDefaultAmount(string FJCID, int Days)
        {
            decimal StandardGrant = 0;
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@Days", Days);
                DataSet dsCamperGrant;
                dsCamperGrant = dal.getDataset("[usp_GetCamperDefaultGrantAmount]", param);

                if (dsCamperGrant.Tables[0].Rows.Count > 0)
                {
                    if (!Convert.IsDBNull(dsCamperGrant.Tables[0].Rows[0]["StandardGrant"]))
                        StandardGrant = Convert.ToDecimal(dsCamperGrant.Tables[0].Rows[0]["StandardGrant"]);
                }
                return StandardGrant;
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
        public structThresholdInfo GetFedThresholdInfo(int FederationID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            structThresholdInfo structThresholdInfo = new structThresholdInfo();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FederationID", FederationID);
                DataSet dsThresholdInfo;
                dsThresholdInfo = dal.getDataset("[usp_GetFedThresholdInfo]", param);

                if (!Convert.IsDBNull(dsThresholdInfo.Tables[0].Rows[0]["NbrOfPmtRequested1"]))
                    structThresholdInfo.NbrOfPmtRequested1 = Convert.ToInt16(dsThresholdInfo.Tables[0].Rows[0]["NbrOfPmtRequested1"]);

                if (!Convert.IsDBNull(dsThresholdInfo.Tables[0].Rows[0]["NbrOfPmtRequested2"]))
                    structThresholdInfo.NbrOfPmtRequested2 = Convert.ToInt16(dsThresholdInfo.Tables[0].Rows[0]["NbrOfPmtRequested2"]);

                if (!Convert.IsDBNull(dsThresholdInfo.Tables[0].Rows[0]["ThresholdType"]))
                    structThresholdInfo.ThresholdType = Convert.ToString(dsThresholdInfo.Tables[0].Rows[0]["ThresholdType"]);

                if (!Convert.IsDBNull(dsThresholdInfo.Tables[0].Rows[0]["ThresholdTypeDescription"]))
                    structThresholdInfo.ThresholdTypeDescription = Convert.ToString(dsThresholdInfo.Tables[0].Rows[0]["ThresholdTypeDescription"]);

                if (!Convert.IsDBNull(dsThresholdInfo.Tables[0].Rows[0]["Threshold1"]))
                    structThresholdInfo.Threshold1 = Convert.ToInt16(dsThresholdInfo.Tables[0].Rows[0]["Threshold1"]);

                if (!Convert.IsDBNull(dsThresholdInfo.Tables[0].Rows[0]["Threshold2"]))
                    structThresholdInfo.Threshold2 = Convert.ToInt16(dsThresholdInfo.Tables[0].Rows[0]["Threshold2"]);
                
                return structThresholdInfo;
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

        //to Update the parent info (step 3 of camper application)
        public int submitCamperApplication(String FJCID, String Comment,int ModifiedBy, int Status)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@Comment", Comment);
                param[2] = new SqlParameter("@User", ModifiedBy);
                param[3] = new SqlParameter("@Status", Status);

                rowsaffected = dal.ExecuteNonQuery("[usp_SubmitCamperApplication]", param);
                return rowsaffected;
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

        //to update the status of the Camper Application.
        public int UpdateStatus(String FJCID, int Status, String Comment, int ModifiedBy)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@Status", Status);
                param[2] = new SqlParameter("@Reason", Comment);
                param[3] = new SqlParameter("@User", ModifiedBy);

                rowsaffected = dal.ExecuteNonQuery("[usp_UpdateStatus]", param);
                return rowsaffected;
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
        //added by sandhya
        public int updtaeCampYear(String FJCID, int CampYear, String Comment, int ModifiedBy)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@CampYear", CampYear);
                param[2] = new SqlParameter("@Reason", Comment);
                param[3] = new SqlParameter("@User", ModifiedBy);

                rowsaffected = dal.ExecuteNonQuery("[usp_UpdateCampYear]", param);
                return rowsaffected;
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
        
        //inserts record into tblApplicationChangeHistory table
        //none parameters are nullable
        public int InsertApplicationChangeHistory( string FJCID,
		                                            string OriginalValue,
		                                            string ChangedValue,
		                                            string Comment,
		                                            string Type,
		                                            int ModifiedBy)
        { 
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@OriginalValue", OriginalValue);
                param[2] = new SqlParameter("@changedValue", ChangedValue);
                param[3] = new SqlParameter("@comment", Comment);
                param[4] = new SqlParameter("@Type", Type);
                param[5] = new SqlParameter("@ModifiedBy", ModifiedBy);

                rowsaffected = dal.ExecuteNonQuery("[usp_InsertApplicationChangeHistory]", param);
                return rowsaffected;
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

        //to update the status of the Camper Application.
        public int updateCamp(String FJCID, int Camp, String Reason, int ModifiedBy)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@Camp", Camp);
                param[2] = new SqlParameter("@Reason", Reason);
                param[3] = new SqlParameter("@User", ModifiedBy);

                rowsaffected = dal.ExecuteNonQuery("[usp_UpdateCamp]", param);
                return rowsaffected;
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


        public void UpdateTimeInCampInApplication(string FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FJCID", FJCID);

                dal.ExecuteNonQuery("[usp_UpdateTimeInCampInApplication]", param);
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

        //to update amount for the Camper Application
        public void UpdateTimeInCamp(int FederationID)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FederationID", FederationID);

                dal.ExecuteNonQuery("[usp_UpdateTimeInCamp]", param);
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

        public void UpdateTimeInCamp_PaymentReport(int FederationID, int campYear)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FederationID", FederationID);
                param[1] = new SqlParameter("@CampYear", campYear);

                dal.ExecuteNonQuery("[usp_UpdateTimeInCamp_PaymentReport]", param);
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

        //to update amount for the Camper Application
        public void UpdateAmount(string strFJCID, double Amt, int iUser, string strReason)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@FJCID", strFJCID);
                param[1] = new SqlParameter("@Amt", Amt);
                param[2] = new SqlParameter("@User", iUser);
                param[3] = new SqlParameter("@Reason", strReason);

                dal.ExecuteNonQuery("[usp_UpdateAmount]", param);
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

        //to update No. of Days for the Camper Application
        public void UpdateDays(string strFJCID, int iDays, int iUser, string strReason)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@FJCID", strFJCID);
                param[1] = new SqlParameter("@Days", iDays);
                param[2] = new SqlParameter("@User", iUser);
                param[3] = new SqlParameter("@Reason", strReason);

                dal.ExecuteNonQuery("[usp_UpdateDays]", param);
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

        //Sets the SecondApproval flag to true
        public void SetSecondApproval(string strFJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FJCID", strFJCID);

                dal.ExecuteNonQuery("[usp_AdminUpdateStatus]", param);
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


        //Sets the SecondApproval flag to true
        public void ReverceSecondApprovalFlag(string strFJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FJCID", strFJCID);

                dal.ExecuteNonQuery("[usp_ReverceSecondApprovalFlag]", param);
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

        //to update WorkQueue flag for Camper Application
        public void UpdateWorkQueueFlag(string strFJCID, bool blnWrkQueueFlag)
        {

            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FJCID", strFJCID);
                param[1] = new SqlParameter("@WorkQueue", (blnWrkQueueFlag == true ? "Y" : "N"));

                dal.ExecuteNonQuery("[usp_UpdateWorkQueue]", param);
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

        //to update the Grade of the Camper Application.
        public int updateGrade(String FJCID, int Grade, String Reason, int ModifiedBy)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@Grade", Grade);
                param[2] = new SqlParameter("@Reason", Reason);
                param[3] = new SqlParameter("@User", ModifiedBy);

                rowsaffected = dal.ExecuteNonQuery("[usp_UpdateGrade]", param);
                return rowsaffected;
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

        //to check whether any basic camper infomation is changed
        public int IsCamperBasicInfoUpdated(UserDetails UserInfo, out string OutValue)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[18];
                param[0] = new SqlParameter("@First_Name", UserInfo.FirstName);
                param[1] = new SqlParameter("@Last_Name", UserInfo.LastName);
                param[2] = new SqlParameter("@Street_Address", UserInfo.Address);
                param[3] = new SqlParameter("@City", UserInfo.City);
                param[4] = new SqlParameter("@State", UserInfo.State);
                param[5] = new SqlParameter("@Country", UserInfo.Country);
                param[6] = new SqlParameter("@Zip_Code", UserInfo.ZipCode);
                param[7] = new SqlParameter("@Home_Phone", UserInfo.HomePhone);
                param[8] = new SqlParameter("@Personal_Email", UserInfo.PersonalEmail);
                param[9] = new SqlParameter("@Date_Of_Birth", UserInfo.DateofBirth);
                param[10] = new SqlParameter("@Age", UserInfo.Age);
                param[11] = new SqlParameter("@FJCID", UserInfo.FJCID);
                param[12] = new SqlParameter("@IsChanged", SqlDbType.NVarChar, 1);
                param[12].Direction = ParameterDirection.Output;
                param[13] = new SqlParameter("@Gender", UserInfo.Gender);
                param[14] = new SqlParameter("@IsJewish", UserInfo.IsJewish);
                param[15] = new SqlParameter("@CMART_MiiP_ReferalCode", UserInfo.CMART_MiiP_ReferalCode);
                param[16] = new SqlParameter("@PJLCode", UserInfo.PJLCode);
                param[17] = new SqlParameter("@NLCode", UserInfo.NLCode);
                rowsaffected = dal.ExecuteNonQuery("[usp_IsCamperApplicationUpdated]", out OutValue, param);
                //rowsaffected = 0;
                return rowsaffected;
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

        //to check whether anything related to  camper parents infomation is changed
        public int IsParentInfoUpdated(UserDetails UserInfo, out string OutValue)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[14];
                param[0] = new SqlParameter("@First_Name", UserInfo.FirstName);
                param[1] = new SqlParameter("@Last_Name", UserInfo.LastName);
                param[2] = new SqlParameter("@Street_Address", UserInfo.Address);
                param[3] = new SqlParameter("@City", UserInfo.City);
                param[4] = new SqlParameter("@State", UserInfo.State);
                param[5] = new SqlParameter("@Country", UserInfo.Country);
                param[6] = new SqlParameter("@Zip_Code", UserInfo.ZipCode);
                param[7] = new SqlParameter("@Home_Phone", UserInfo.HomePhone);
                param[8] = new SqlParameter("@Personal_Email", UserInfo.PersonalEmail);
                param[9] = new SqlParameter("@Work_Phone", UserInfo.WorkPhone);
                param[10] = new SqlParameter("@Work_Email", UserInfo.WorkEmail);
                param[11] = new SqlParameter("@FJCID", UserInfo.FJCID);
                param[12] = new SqlParameter("@Flag", UserInfo.IsParentInfo1);
                param[13] = new SqlParameter("@IsChanged", SqlDbType.NVarChar, 1);
                param[13].Direction = ParameterDirection.Output;

                rowsaffected = dal.ExecuteNonQuery("[usp_IsParentInfoUpdated]", out OutValue, param);
                //rowsaffected = 0;
                return rowsaffected;
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


        //to check whether camper's applications could be cloned
        public bool CouldApplcationsBeCloned(string CamperId)
        {

            return false;

            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            string OutValue;
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@CamperId", CamperId);
                param[1] = new SqlParameter("@CouldBeCloned", SqlDbType.NVarChar, 1);
                param[1].Direction = ParameterDirection.Output;

                rowsaffected = dal.ExecuteNonQuery("[usp_CouldBeCloned]", out OutValue, param);

                return OutValue == "1";
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

        //to check whether anything changes to camper answers
        public int IsCamperAnswersUpdated(string FJCID, string Answers, string ModifiedBy,string PageId, out string OutValue)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@Answers", Answers);
                param[2] = new SqlParameter("@userID", ModifiedBy);
                param[3] = new SqlParameter("@PageID", PageId);
                param[4] = new SqlParameter("@IsChanged", SqlDbType.NVarChar, 1);
                param[4].Direction = ParameterDirection.Output;

                rowsaffected = dal.ExecuteNonQuery("[usp_IsCamperAnswersUpdated]", out OutValue, param);
                //rowsaffected = 0;
                return rowsaffected;
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


        public void CamperAnswersServerValidation(string CamperAnswers, string Comments, string FJCID, string ModifiedBy,string PageId, string CamperUserId, out Boolean bArgsValid, out Boolean bPerformUpdate)
        {
            string strRetVal;
            Boolean bArgs = false, bPerform = false;
            IsCamperAnswersUpdated(FJCID, CamperAnswers, ModifiedBy,PageId,  out strRetVal);
            if (ModifiedBy != CamperUserId) //then the user is admin user
            {
                switch (strRetVal)
                {
                    case "0": //data has been modified
                        if (Comments == "")
                        {
                            bArgs = false;
                            bPerform = false;
                        }
                        else
                        {
                            bArgs = true;
                            bPerform = true;
                        }
                        break;
                    case "1": //data is not modified
                        bArgs = true;
                        bPerform = false;
                        break;
                }
            }
            else //the user is camper
            {
                switch (strRetVal)
                {
                    case "0": //data has been modified
                        bPerform = true;
                        break;
                    case "1": //data is not modified
                        bPerform = false;
                        break;
                }
                bArgs = true;
            }

            bArgsValid = bArgs;
            bPerformUpdate = bPerform;
        }

        //Sets the ConfirmAcceptance flag
        public void ConfirmAcceptance(string strFJCID, bool blnAcceptedFlag)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FJCID", strFJCID);
                param[1] = new SqlParameter("@AcceptedFlag", (blnAcceptedFlag == true ? "Y" : "N"));

                dal.ExecuteNonQuery("[usp_ConfirmAcceptance]", param);
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


        //Sets the ConfirmAcceptance flag
        public void SetTermsandConditionsAcceptance(string strFJCID, Boolean AcceptOption1, Boolean AcceptOption2, Boolean AcceptOption3 )
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@FJCID", strFJCID);
                param[1] = new SqlParameter("@AcceptOption1", AcceptOption1);
                param[2] = new SqlParameter("@AcceptOption2", AcceptOption2);
                param[3] = new SqlParameter("@AcceptOption3", AcceptOption3);

                dal.ExecuteNonQuery("[usp_SetTermsandConditionsAcceptance]", param);
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


        //Sets the ConfirmAcceptance flag
        public void SetAcknowledgeFlag(string strFJCID, Boolean AcknowledgeFlag)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FJCID", strFJCID);
                param[1] = new SqlParameter("@Flag", AcknowledgeFlag);
                dal.ExecuteNonQuery("[usp_SetAcknowledgementFlag]", param);
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

        //to get all the School Details
        public DataSet GetSchool(int SchoolID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SchoolID", SchoolID);
                DataSet dsSchool;
                dsSchool = dal.getDataset("[usp_GetSchool]", param);
                return dsSchool;
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

        //to get the Application submitted info for a particular FJCID (SubmittedDate and ModifiedByUser)
        //and making the questionnaire readonly 
        public DataSet GetApplicationSubmittedInfo(string FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            SqlParameter[] param = new SqlParameter[1];
            DataSet ds;
            try
            {
                param[0] = new SqlParameter("@FJCID", FJCID);
                ds = dal.getDataset("[usp_GetApplicationSubmittedInfo]", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
                param = null;
            }
        }

        //to copy the camper application - to start new application (National landing) when camper ineligible.
        public int CopyCamperApplication(string FJCID, out string OutValue)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@oldFJCID", FJCID);
                param[1] = new SqlParameter("@OFJCID", SqlDbType.NVarChar, 50);
                param[1].Direction = ParameterDirection.Output;

                rowsaffected = dal.ExecuteNonQuery("[usp_CopyCamperApplication]", out OutValue, param);
                //rowsaffected = 0;
                return rowsaffected;
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


        //to copy the camper application - to start new application (National landing) when camper ineligible.
        public int CloneCamperApplication(string FJCID, out string OutValue)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@oldFJCID", FJCID);
                param[1] = new SqlParameter("@OFJCID", SqlDbType.NVarChar, 50);
                param[1].Direction = ParameterDirection.Output;
                param[2] = new SqlParameter("@checkToDel", "1");

                rowsaffected = dal.ExecuteNonQuery("[usp_CloneCamperApplication]", out OutValue, param);
                //rowsaffected = 0;
                return rowsaffected;
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

        
        public bool CamperStatusDetectived(string FJCID, int StatusValue)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            string OutValue;
            try
            {
                SqlParameter[] param = new SqlParameter[3];

                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@StatusID", StatusValue);
                param[2] = new SqlParameter("@Detected", SqlDbType.NVarChar, 1);
                param[2].Direction = ParameterDirection.Output;

                rowsaffected = dal.ExecuteNonQuery("[usp_CamperStatusDetective]", out OutValue, param);
                if (OutValue.Equals("1"))
                    return true;
                else
                    return false;
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

        //Added By Ram (10/13/2009)
        /// <summary>
        /// Verifies if the options (marketing section) has been changed
        /// </summary>
        /// <param name="presentSetOfSelectedAnswers"></param>
        /// <param name="previousSetOfSelectedOptions"></param>
        /// <returns>returns true if changed else false</returns>        
        public bool VerifyCamperAnswersSelectionHasChanged(string presentSetOfSelectedAnswers, string previousSetOfSelectedOptions)
        {            
            if(!presentSetOfSelectedAnswers.Equals(previousSetOfSelectedOptions))
                return true;
            return false;
        }


        public static string KEY = "N!u8#m2a";
        // Encrypt a Querystring
        public string EncryptQueryString(string stringToEncrypt)
        {
            byte[] key = { };
            byte[] IV = { 0x01, 0x12, 0x23, 0x34, 0x45, 0x56, 0x67, 0x78 };
            try
            {
                key = Encoding.UTF8.GetBytes(KEY);
                using (DESCryptoServiceProvider oDESCrypto = new DESCryptoServiceProvider())
                {
                    byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                    MemoryStream oMemoryStream = new MemoryStream();
                    CryptoStream oCryptoStream = new CryptoStream(oMemoryStream,
                    oDESCrypto.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                    oCryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                    oCryptoStream.FlushFinalBlock();
                    return Convert.ToBase64String(oMemoryStream.ToArray());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // Decrypt a Querystring
        public string DecryptQueryString(string stringToDecrypt)
        {
            byte[] key = { };
            byte[] IV = { 0x01, 0x12, 0x23, 0x34, 0x45, 0x56, 0x67, 0x78 };
            stringToDecrypt = stringToDecrypt.Replace(" ", "+");
            byte[] inputByteArray = new byte[stringToDecrypt.Length];


            try
            {
                key = Encoding.UTF8.GetBytes(KEY);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetCamperInfo(string FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FJCID", FJCID);
                return dal.getDataset("usp_GetCamperInfo", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetGrantFromDaysCamp(string FJCID, string days, string campID, string timeInCamp)
        {
            decimal grantAmount = 0;
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@Days", days);
                param[2] = new SqlParameter("@CampID", campID);
                param[3] = new SqlParameter("@TimeInCamp", timeInCamp);
                DataSet dsCamperGrant;
                dsCamperGrant = dal.getDataset("usp_GetGrantFromDaysCamp", param);

                if (dsCamperGrant.Tables[0].Rows.Count > 0)
                {
                    if (!Convert.IsDBNull(dsCamperGrant.Tables[0].Rows[0]["GrantAmount"]))
                        grantAmount = Convert.ToDecimal(dsCamperGrant.Tables[0].Rows[0]["GrantAmount"]);
                }
                return grantAmount;
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

        public void UpdateChangeDetails(structChangeDetails ChangeInfo)
        {
            CIPDataAccess dal = new CIPDataAccess();
            SqlParameter[] param = new SqlParameter[21];
            int rowsaffected;

            param[0] = new SqlParameter("@FJCID", ChangeInfo.FJCID);
            param[1] = new SqlParameter("@RequestType", ChangeInfo.RequestType);
            param[2] = new SqlParameter("@Cancellation_Reason", ChangeInfo.Cancellation_Reason);
            param[3] = new SqlParameter("@OldSession", ChangeInfo.OldSession);
            param[4] = new SqlParameter("@OldSession_StartDate", ChangeInfo.OldSession_StartDate);
            param[5] = new SqlParameter("@OldSession_EndDate", ChangeInfo.OldSession_EndDate);
            param[6] = new SqlParameter("@NewSession", ChangeInfo.NewSession);
            param[7] = new SqlParameter("@NewSession_StartDate", ChangeInfo.NewSession_StartDate);
            param[8] = new SqlParameter("@NewSession_EndDate", ChangeInfo.NewSession_EndDate);
            param[9] = new SqlParameter("@Original_Status", ChangeInfo.Original_Status);
            param[10] = new SqlParameter("@Current_Status", ChangeInfo.Current_Status);
            param[11] = new SqlParameter("@OldGrantAmount", ChangeInfo.OldGrantAmount);
            param[12] = new SqlParameter("@NewGrantAmount", ChangeInfo.NewGrantAmount);
            param[13] = new SqlParameter("@NewFJCID", ChangeInfo.NewFJCID == 0 ? DBNull.Value.ToString() : ChangeInfo.NewFJCID.ToString());
            param[14] = new SqlParameter("@CampYearID", ChangeInfo.CampYearID);
            param[15] = new SqlParameter("@CreatedDate", ChangeInfo.CreatedDate);
            param[16] = new SqlParameter("@SubmittedDate", ChangeInfo.SubmittedDate);
            param[17] = new SqlParameter("@ModifiedDate", ChangeInfo.ModifiedDate);
            param[18] = new SqlParameter("@ModifiedBy", ChangeInfo.ModifiedBy);
            param[19] = new SqlParameter("@RequestStatus", ChangeInfo.RequestStatus);
            param[20] = new SqlParameter("@RequestID", ChangeInfo.RequestID);

            rowsaffected = dal.ExecuteNonQuery("[usp_UpdateChangeRequestDetails]", param);
            //rowsaffected = 0;
        }

        public DataSet GetChangeRequestDetails(string strFJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet dsChangeDetails = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@FJCID", strFJCID);
            dsChangeDetails = dal.getDataset("[usp_getChangeRequestDetails]", param);
            return dsChangeDetails;
        }

        public void InsertChangeDetails(structChangeDetails ChangeInfo, out int requestID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            SqlParameter[] param = new SqlParameter[21];
            requestID = 0;
            int rowsaffected;
            param[0] = new SqlParameter("@FJCID", ChangeInfo.FJCID);
            param[1] = new SqlParameter("@RequestType", ChangeInfo.RequestType);
            param[2] = new SqlParameter("@Cancellation_Reason", ChangeInfo.Cancellation_Reason);
            param[3] = new SqlParameter("@OldSession", ChangeInfo.OldSession);
            param[4] = new SqlParameter("@OldSession_StartDate", ChangeInfo.OldSession_StartDate);
            param[5] = new SqlParameter("@OldSession_EndDate", ChangeInfo.OldSession_EndDate);
            param[6] = new SqlParameter("@NewSession", ChangeInfo.NewSession);
            param[7] = new SqlParameter("@NewSession_StartDate", ChangeInfo.NewSession_StartDate);
            param[8] = new SqlParameter("@NewSession_EndDate", ChangeInfo.NewSession_EndDate);
            param[9] = new SqlParameter("@Original_Status", ChangeInfo.Original_Status);
            param[10] = new SqlParameter("@Current_Status", ChangeInfo.Current_Status);
            param[11] = new SqlParameter("@OldGrantAmount", ChangeInfo.OldGrantAmount);
            param[12] = new SqlParameter("@NewGrantAmount", ChangeInfo.NewGrantAmount);
            param[13] = new SqlParameter("@NewFJCID", ChangeInfo.NewFJCID == 0 ? DBNull.Value.ToString() : ChangeInfo.NewFJCID.ToString());
            param[14] = new SqlParameter("@CampYearID", ChangeInfo.CampYearID);
            param[15] = new SqlParameter("@CreatedDate", ChangeInfo.CreatedDate);
            param[16] = new SqlParameter("@SubmittedDate", ChangeInfo.SubmittedDate);
            param[17] = new SqlParameter("@ModifiedDate", ChangeInfo.ModifiedDate);
            param[18] = new SqlParameter("@ModifiedBy", ChangeInfo.ModifiedBy);
            param[19] = new SqlParameter("@RequestStatus", ChangeInfo.RequestStatus);
            param[20] = new SqlParameter("@RequestID", requestID);
            param[20].Direction = ParameterDirection.Output;
            
            rowsaffected = dal.ExecuteNonQuery("[usp_InsertChangeRequestDetails]", param);
            //rowsaffected = 0;
        }

        public structChangeDetails SetChangeDetailsFromDataRow(DataRow drChangeDetails)
        {
            structChangeDetails structChangeDetails = new structChangeDetails();
            structChangeDetails.RequestID = drChangeDetails["RequestID"]!= null?Int32.Parse(drChangeDetails["RequestID"].ToString()):0;
            structChangeDetails.FJCID = long.Parse(drChangeDetails["FJCID"].ToString());
            structChangeDetails.RequestType = Int32.Parse(drChangeDetails["RequestType"].ToString());
            structChangeDetails.Cancellation_Reason = drChangeDetails["Cancellation_Reason"].ToString();
            structChangeDetails.OldSession = drChangeDetails["OldSession"].ToString();
            structChangeDetails.OldSession_StartDate = drChangeDetails["OldSession_StartDate"].ToString();
            structChangeDetails.OldSession_EndDate = drChangeDetails["OldSession_EndDate"].ToString();
            structChangeDetails.NewSession = drChangeDetails["NewSession"].ToString();
            structChangeDetails.NewSession_StartDate = drChangeDetails["NewSession_StartDate"].ToString();
            structChangeDetails.NewSession_EndDate = drChangeDetails["NewSession_EndDate"].ToString();
            structChangeDetails.Original_Status = Int32.Parse(drChangeDetails["Original_Status"].ToString());
            structChangeDetails.Current_Status = Int32.Parse(drChangeDetails["Current_Status"].ToString());
            structChangeDetails.OldGrantAmount = double.TryParse(drChangeDetails["OldGrantAmount"].ToString(), out structChangeDetails.OldGrantAmount) ? double.Parse(drChangeDetails["OldGrantAmount"].ToString()) : 0.0;
            structChangeDetails.NewGrantAmount = double.TryParse(drChangeDetails["NewGrantAmount"].ToString(), out structChangeDetails.NewGrantAmount) ? double.Parse(drChangeDetails["NewGrantAmount"].ToString()) : 0.0;
            structChangeDetails.NewFJCID = long.TryParse(drChangeDetails["NewFJCID"].ToString(), out structChangeDetails.NewFJCID) ? long.Parse(drChangeDetails["NewFJCID"].ToString()) : 0;
            structChangeDetails.CampYearID = Int32.Parse(drChangeDetails["CampYearID"].ToString());
            structChangeDetails.CreatedDate = drChangeDetails["CreatedDate"].ToString();
            structChangeDetails.SubmittedDate = drChangeDetails["SubmittedDate"].ToString();
            structChangeDetails.ModifiedDate = drChangeDetails["ModifiedDate"].ToString();
            structChangeDetails.ModifiedBy = long.TryParse(drChangeDetails["ModifiedBy"].ToString(), out structChangeDetails.ModifiedBy) ? long.Parse(drChangeDetails["ModifiedBy"].ToString()) : 0;
            structChangeDetails.RequestStatus = Int32.TryParse(drChangeDetails["RequestStatus"].ToString(), out structChangeDetails.RequestStatus) ? Int32.Parse(drChangeDetails["RequestStatus"].ToString()) : 0;
            return structChangeDetails;
        }

        //to copy the camper application - to start new application (National landing) when camper ineligible.
        public int CopyCamperApplicationForSessionChange(string FJCID, out string OutValue, int newAppStatus, int setOriginalAppStatus)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@oldFJCID", FJCID);
                param[1] = new SqlParameter("@OFJCID", SqlDbType.NVarChar, 50);
                param[2] = new SqlParameter("@NewStatus", SqlDbType.Int,newAppStatus);
                param[3] = new SqlParameter("@OldApplicationStatus", SqlDbType.Int,setOriginalAppStatus);
                param[1].Direction = ParameterDirection.Output;

                rowsaffected = dal.ExecuteNonQuery("[usp_CopyCamperApplicationForSessionChange]", out OutValue, param);
                //rowsaffected = 0;
                return rowsaffected;
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

        public int InsertCamperAnswers_RequestedForChange(string FJCID, string Answers, string ModifiedBy, string Comments, string originalValue, string changedValue)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@Answers", Answers);
                param[2] = new SqlParameter("@userID", ModifiedBy);
                param[3] = new SqlParameter("@Comment", Comments);
                param[4] = new SqlParameter("@originalValue", originalValue);
                param[5] = new SqlParameter("@changedValue", changedValue);
                rowsaffected = dal.ExecuteNonQuery("[USP_InsertCamperAnswers]", param);
                return rowsaffected;
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

        public bool UpdateDetailsOnRequestType(string FJCID, string strNewFJCID, int iRequestID, string strAnswers, string Comments, int iUserID, string strOriginalValue, string strChangedValue, int iRequestStatus)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@FJCID", FJCID);
                param[1] = new SqlParameter("@RequestID", iRequestID);
                param[2] = new SqlParameter("@Answers", strAnswers);
                param[3] = new SqlParameter("@Comments", Comments);
                param[4] = new SqlParameter("@userID", iUserID);                
                param[5] = new SqlParameter("@originalValue", strOriginalValue);
                param[6] = new SqlParameter("@changedValue", strChangedValue);
                param[7] = new SqlParameter("@RequestStatus", iRequestStatus);
                param[8] = new SqlParameter("@NewFJCID", strNewFJCID);
                rowsaffected = dal.ExecuteNonQuery("[usp_AlterChangeRequestDetails]", param);
                return rowsaffected > 1 ?true:false;
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

        public int IsPaymentDone(String FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet ds = new DataSet();
            int rowsAffected;
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@FJCID", FJCID);
            ds = dal.getDataset("usp_IsPaymentDone", param);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            
        }

        public string SetNextUrl(string strFJCID,string strCampYear)
        {
            UserDetails Info = new UserDetails();
            Info = getCamperInfo(strFJCID);
            string strFedID = "0";
            string strNextURL=string.Empty;
            DataSet dsMiiPReferalCodeDetails = new DataSet();
            General objGeneral = new General();
            if (Info.CMART_MiiP_ReferalCode != string.Empty)
               dsMiiPReferalCodeDetails = objGeneral.GetMiiPReferalCode(Info.CMART_MiiP_ReferalCode, strCampYear);

            if ((dsMiiPReferalCodeDetails.Tables.Count > 0) && (Info.CMART_MiiP_ReferalCode != string.Empty))
            {
                if (dsMiiPReferalCodeDetails.Tables[0].Rows.Count > 0)
                {
                    DataRow drMiiP = dsMiiPReferalCodeDetails.Tables[0].Rows[0];
                    strNextURL = drMiiP["NavigationURL"].ToString();
                    if (drMiiP["CampID"].ToString() == "1146")
                    {
                        if (strNextURL.ToUpper().Contains("URJ/"))
                            strNextURL = strNextURL.Replace("URJ/", "URJ/Acadamy");
                    }
                    strFedID = ConfigurationManager.AppSettings["CMART"].ToString();
                }
            }
            else if (Info.PJLCode != string.Empty)
            {
                char ch = ',';
                //string[] PJLCode = ConfigurationManager.AppSettings["PJLCode"].ToString().Split(ch);
                DataTable dtCampYearPJLCodes = objGeneral.GetPJLCodes(strCampYear).Tables[0];
                string[] PJLCode = new string[dtCampYearPJLCodes.Rows.Count];
                //dtCampYearPJLCodes.Rows.CopyTo(PJLCode, 0);
                for (int i = 0; i < dtCampYearPJLCodes.Rows.Count; i++)
                {
                    PJLCode[i] = dtCampYearPJLCodes.Rows[i][0].ToString();
                }

                for (int i = 0; i < PJLCode.Length; i++)
                {
                    if (Info.PJLCode.ToUpper() == PJLCode[i].ToUpper())
                    {
                        strNextURL = "~/Enrollment/PJL/Summary.aspx";
                        strFedID = ConfigurationManager.AppSettings["PJL"].ToString();
                        break;
                    }
                }
            }
            
            if(strNextURL=="")
            {
                strNextURL = "~/Enrollment/Step1_NL.aspx"; 
            }

            return strNextURL;
        }

        public int UpdatePJLCamperStatus(string FJCIDs, int status)
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet ds = new DataSet();            
            int rowsAffected = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FJCIDs", FJCIDs);
                param[1] = new SqlParameter("@Status", status);
                ds = dal.getDataset("UpdatePJLCamperStatus", param);
                if (ds.Tables.Count > 0)
                    if (ds.Tables[0].Rows.Count > 0)
                        return Int32.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
                ds = null;
            }
        }

        public int IsNationalLandingCamp(string FederationId)
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet ds = new DataSet();
            int rowsAffected = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FederationId", FederationId);
                return Convert.ToInt32(dal.getDataset("usp_IsNationalLandingCamp", param).Tables[0].Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
                ds = null;
            }
        }


        public int UpdateANStatus(String FJCIDs, int Status)
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet ds = new DataSet();
            int rowsAffected = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FJCIDs", FJCIDs);
                param[1] = new SqlParameter("@Status", Status);
                return dal.ExecuteNonQuery("usp_UpdateANStatus", param);
                //if (ds.Tables.Count > 0)
                //    if (ds.Tables[0].Rows.Count > 0)
                //        return Int32.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
                //return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
                ds = null;
            }
        
        }

        public int ResetANStatus(String FJCIDs)
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet ds = new DataSet();
            int rowsAffected = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FJCIDs", FJCIDs);
                return dal.ExecuteNonQuery("ResetANStatus", param);
                //if (ds.Tables.Count > 0)
                //    if (ds.Tables[0].Rows.Count > 0)
                //        return Int32.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
                //return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
                ds = null;
            }
        }


        public DataSet getSurveyCode(string FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet ds = new DataSet();
            SqlParameter [] param = new SqlParameter[1];

            param[0] = new SqlParameter("@FJCID", FJCID);
            ds = dal.getDataset("usp_getSurveyCode", param);

            return ds;
        }

        public DataSet usp_GetANReport(int recCount, string campyear, int ANReportID, string type)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RecCount", recCount);
                param[1] = new SqlParameter("@ANReportID", ANReportID);
                param[2] = new SqlParameter("@CampYear", campyear);
                param[3] = new SqlParameter("@Type", type);
                return dal.getDataset("[usp_GetANReport]", param);
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

        public int GetExistingCountOfANPremilinaryRecords(string campyear)
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CampYear", campyear);
                ds = dal.getDataset("[usp_GetExistingCountOfANPremilinaryRecords]", param);
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
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

        public DataSet RunFinalMode(string campyear, string type)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@CampYear", campyear);
                param[1] = new SqlParameter("@Type", type);
                return dal.getDataset("[usp_RunFinalMode]", param);
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
        public DataSet GetANFinalModeCampersOnReportID(string campyear, string ANReportID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@CampYear", campyear);
                param[1] = new SqlParameter("@ANReportID", ANReportID);
                return dal.getDataset("[usp_GetANFinalModeCampersOnReportID]", param);
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

        //Added by sandhya
        //to get the status based on the FJCID
        public DataSet getStatus(string FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@FJCID", FJCID);
                ds = dal.getDataset("usp_GetStatus", param);

                return ds;
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

        public int GetJWestFirsttimersCountBasedonStatus()
        {
            CIPDataAccess dal = new CIPDataAccess();
            int jwestcount = 0;
            try
            {
                DataSet ds = new DataSet();
                //SqlParameter[] param = new SqlParameter[1];

                //param[0] = new SqlParameter("@Status", status);
                //param[1] = new SqlParameter("@FJCID", fjcid);
                ds = dal.getDataset("JWestFirsttimersCountBasedonStatus", null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["jwestcount"]))
                        jwestcount = Convert.ToInt16(ds.Tables[0].Rows[0]["jwestcount"]);
                }
                return jwestcount;               
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
        public structJWestReportInfo GetJWestReportInfo(int CampYear)
        {
            CIPDataAccess dal = new CIPDataAccess();
            structJWestReportInfo structJWestReportInfo = new structJWestReportInfo();
            try
            {             
                DataSet dsJWestReportInfo;
				string sp = "";
				if (CampYear == 2011)
					sp = "[usp_GetReportCounts]";
				else if (CampYear == 2012)
					sp = "[usp_GetReportCounts2012]";

                dsJWestReportInfo = dal.getDataset(sp, null);

                if (!Convert.IsDBNull(dsJWestReportInfo.Tables[0].Rows[0]["NoOf2010Campers"]))
                    structJWestReportInfo.NoOf2010Campers = Convert.ToInt16(dsJWestReportInfo.Tables[0].Rows[0]["NoOf2010Campers"]);

                if (!Convert.IsDBNull(dsJWestReportInfo.Tables[0].Rows[0]["NoOf201012Campers"]))
                    structJWestReportInfo.NoOf201012Campers = Convert.ToInt16(dsJWestReportInfo.Tables[0].Rows[0]["NoOf201012Campers"]);

                if (!Convert.IsDBNull(dsJWestReportInfo.Tables[0].Rows[0]["Noof201018Campers"]))
                    structJWestReportInfo.Noof201018Campers = Convert.ToInt16(dsJWestReportInfo.Tables[0].Rows[0]["Noof201018Campers"]);

                if (!Convert.IsDBNull(dsJWestReportInfo.Tables[0].Rows[0]["NoOf2011Campers"]))
                    structJWestReportInfo.NoOf2011Campers = Convert.ToInt16(dsJWestReportInfo.Tables[0].Rows[0]["NoOf2011Campers"]);

                if (!Convert.IsDBNull(dsJWestReportInfo.Tables[0].Rows[0]["NoOf2010notreturnedCampers"]))
                    structJWestReportInfo.NoOf2010notreturnedCampers = Convert.ToInt16(dsJWestReportInfo.Tables[0].Rows[0]["NoOf2010notreturnedCampers"]);

                if (!Convert.IsDBNull(dsJWestReportInfo.Tables[0].Rows[0]["NoOf201012returned201112Campers"]))
                    structJWestReportInfo.NoOf201012returned201112Campers = Convert.ToInt16(dsJWestReportInfo.Tables[0].Rows[0]["NoOf201012returned201112Campers"]);

                if (!Convert.IsDBNull(dsJWestReportInfo.Tables[0].Rows[0]["NoOf201012returned201118Campers"]))
                    structJWestReportInfo.NoOf201012returned201118Campers = Convert.ToInt16(dsJWestReportInfo.Tables[0].Rows[0]["NoOf201012returned201118Campers"]);

                if (!Convert.IsDBNull(dsJWestReportInfo.Tables[0].Rows[0]["NoOf201018returned201112Campers"]))
                    structJWestReportInfo.NoOf201018returned201112Campers = Convert.ToInt16(dsJWestReportInfo.Tables[0].Rows[0]["NoOf201018returned201112Campers"]);

                if (!Convert.IsDBNull(dsJWestReportInfo.Tables[0].Rows[0]["NoOf201018returned201118Campers"]))
                    structJWestReportInfo.NoOf201018returned201118Campers = Convert.ToInt16(dsJWestReportInfo.Tables[0].Rows[0]["NoOf201018returned201118Campers"]);

                if (!Convert.IsDBNull(dsJWestReportInfo.Tables[0].Rows[0]["NoOf2010returnedCampers"]))
                    structJWestReportInfo.NoOf2010returnedCampers = Convert.ToInt16(dsJWestReportInfo.Tables[0].Rows[0]["NoOf2010returnedCampers"]);

                return structJWestReportInfo;
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

        public DataSet CheckSecondQuestion(int FederationId)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@FederationID", FederationId);
                ds = dal.getDataset("CheckQuestion2", param);

                return ds;
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
        //added by sandhya 
        //to insert the camper holding details
        public void InsertCamperHoldingDetails(string Firstname, string Lastname, string Email, string Zipcode, string FedName, string CampName, bool isPJL, int SchoolTypeID)
        {
            CIPDataAccess dal = new CIPDataAccess();
         
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@FirstName", Firstname);
                param[1] = new SqlParameter("@LastName", Lastname);
                param[2] = new SqlParameter("@EmailAddress", Email);
                param[3] = new SqlParameter("@ZipCode", Zipcode);
				param[4] = new SqlParameter("@FedName", FedName);
                param[5] = new SqlParameter("@CampName", CampName);
                param[6] = new SqlParameter("@isPJL", isPJL);
                param[7] = new SqlParameter("@SchoolTypeID", SchoolTypeID);

                dal.ExecuteNonQuery("[usp_InsertCamperHoldingDetails]", param);
               
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

        internal DataSet GetCamperTimeInCampWithOutCamp(string FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FJCID", FJCID);

                return dal.getDataset("[usp_GetCamperTimeInCampWithOutCamp]", param);
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

        //to copy the camper application but not the camperanswers- to start new application (Sandiego) when camper ineligible .
        public int CopyCamperApplicationWithoutCamperAnswers(string FJCID, out string OutValue)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@oldFJCID", FJCID);
                param[1] = new SqlParameter("@OFJCID", SqlDbType.NVarChar, 50);
                param[1].Direction = ParameterDirection.Output;

                rowsaffected = dal.ExecuteNonQuery("[usp_CopyCamperApplicationWithoutCamperAnswers]", out OutValue, param);
                //rowsaffected = 0;
                return rowsaffected;
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
        public DataSet GetCamperApplicationsFromCamperID(string camperID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CamperID", camperID);
                DataSet dsCamperApplications;
                dsCamperApplications = dal.getDataset("[usp_GetCamperApplicationsFromCamperID]", param);
                return dsCamperApplications;
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

        public void DeleteCamperAnswerUsingFJCID(string FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FJCID", FJCID);
                dal.ExecuteNonQuery("[usp_DeleteCamperAnswerUsingFJCID]", param);                
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

        public int validateIsUsedPJLDSCode(string FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet ds = new DataSet();
            DataRow dr;
            int rowsaffected = -1;
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@FJCID", FJCID);

                ds = dal.getDataset("[usp_ValidateIsUsedPJLDSCode]", param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string valid = ds.Tables[0].Rows[0][0].ToString();
                    rowsaffected = Convert.ToInt32(valid);

                }
                return rowsaffected;

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
        //added by sreevani for pjl day school codes validation and updation
        public int validatePJLDSCode(string PJLDSCode)
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet ds = new DataSet();
            DataRow dr;
            int rowsaffected = -1;
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@PJLDSCode", PJLDSCode);

                ds = dal.getDataset("[usp_ValidatePJLDSCode]", param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //dr = ds.Tables[0].Rows[0];
                    string valid = ds.Tables[0].Rows[0][0].ToString();
                    rowsaffected = Convert.ToInt32(valid);

                }
                return rowsaffected;

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

        public void updatePJLDSCode(string PJLDSCode, string fjcid)
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet ds = new DataSet();
            DataRow dr;
            int rowsaffected = -1;
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PJLDSCode", PJLDSCode);
                param[1] = new SqlParameter("@fjcid", fjcid);
                dal.ExecuteNonQuery("[usp_UpdatePJLDSCode]", param);
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

        public string validateFJCID(string fjcid)
        {



            CIPDataAccess dal = new CIPDataAccess();
            DataSet ds = new DataSet();
            DataRow dr;
            string dallasCode = null;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@fjcid", fjcid);
                ds = dal.getDataset("[usp_getDallasCode]", param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //dr = ds.Tables[0].Rows[0];
                    dallasCode = ds.Tables[0].Rows[0][0].ToString();

                }
                return dallasCode;
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
        //end of addition for dallas code validation

        //added by sreevani to get campyearid based on fjcid
		public string getCampYearId(string fjcid)
        {
            CIPDataAccess dal = new CIPDataAccess();
            DataSet ds = new DataSet();
            DataRow dr;
            string campYearId = null;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Fjcid", fjcid);
                ds = dal.getDataset("[usp_GetCampYearId]", param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //dr = ds.Tables[0].Rows[0];
                    campYearId = ds.Tables[0].Rows[0][0].ToString();
                }
                return campYearId;
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
        
    public struct structChangeDetails
    {
        public int RequestID;
        public long FJCID;
        public int RequestType;
        public string Cancellation_Reason;
        public string OldSession;
        public string OldSession_StartDate;
        public string OldSession_EndDate;
        public string NewSession;
        public string NewSession_StartDate;
        public string NewSession_EndDate;
        public int Original_Status;
        public int Current_Status;
        public double OldGrantAmount;
        public double NewGrantAmount;
        public long NewFJCID;
        public int CampYearID;
        public string CreatedDate;
        public string SubmittedDate;
        public string ModifiedDate;
        public long ModifiedBy;
        public int RequestStatus;

        public bool Equals(structChangeDetails obj)
        {
            //if (this.FJCID == obj.FJCID && this.RequestType == obj.RequestType && this.Cancellation_Reason == obj.Cancellation_Reason && this.NewSession == obj.NewSession && this.NewSession_StartDate == obj.NewSession_StartDate && this.NewSession_EndDate == obj.NewSession_EndDate && this.Original_Status == obj.Original_Status && this.NewGrantAmount == obj.NewGrantAmount && this.CampYearID == obj.CampYearID && this.IsSubmitted == obj.IsSubmitted)
            if (this.FJCID == obj.FJCID && this.RequestType == obj.RequestType && this.Cancellation_Reason == obj.Cancellation_Reason && this.NewSession == obj.NewSession && this.NewSession_StartDate == obj.NewSession_StartDate && this.NewSession_EndDate == obj.NewSession_EndDate && this.NewGrantAmount == obj.NewGrantAmount && this.CampYearID == obj.CampYearID)
                return true;
            else
                return false;
        }
    }
    
    //struct which is being used for Camper Info, Parent Info
    public struct structThresholdInfo
    {
        public int NbrOfPmtRequested1;
        public int NbrOfPmtRequested2;
        public string ThresholdType;
        public string ThresholdTypeDescription;
        public int Threshold1;
        public int Threshold2;
     }
    public struct structJWestReportInfo
    {
        public int NoOf2010Campers;
        public int NoOf201012Campers;
        public int Noof201018Campers;
        public int NoOf2011Campers;
        public int NoOf2010notreturnedCampers;
        public int NoOf201012returned201112Campers;
        public int NoOf201012returned201118Campers;
        public int NoOf201018returned201112Campers;
        public int NoOf201018returned201118Campers;
        public int NoOf2010returnedCampers;
    }
    public enum RequestStatus
    {
        Saved = 0,
        Submitted = 1,
        Rejected = 2,
        ClosedOrApproved = 3
    }

}
