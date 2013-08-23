using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace CIPMSBC
{
    public class Administration
    {
        //to fill the grid for camper details
        public Boolean validate_Login(string EmailID, string Password, out DataSet dsRetLogin)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsLogin;
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@EmailID", EmailID);
                param[1] = new SqlParameter("@Password", Password);

                dsLogin = dal.getDataset("usp_ValidateLogin", param);
                dsRetLogin = dsLogin;

                if (dsLogin.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

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

        //Validating Camper 
        public Boolean ValidateCamper(string strEmail, string strPassword, out DataSet dsRetLogin)
        {
            CIPDataAccess dal = new CIPDataAccess();

            try
            {
                DataSet dsLogin;
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Email", strEmail);
                param[1] = new SqlParameter("@Password", strPassword);

                dsLogin = dal.getDataset("[usp_ValidateCamper]", param);
                dsRetLogin = dsLogin;

                if (dsLogin.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

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

        public int UserRegistration(string strEmail, string strPwd,out string CamperLoginID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;

            try
            {

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Email", strEmail);
                param[1] = new SqlParameter("@Password", strPwd);
                param[2] = new SqlParameter("@oCamperLoginID", SqlDbType.NVarChar,10);
                param[2].Direction = ParameterDirection.Output;

                rowsaffected = dal.ExecuteNonQuery("[usp_InsertUserRegistration]", out CamperLoginID, param);
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

        public int LinkFJCIDsCamper(int CamperLoginID, string FJCID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            int rowsaffected;
            try
            {
  
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@CamperLoginID", CamperLoginID);
                param[1] = new SqlParameter("@FJCID", FJCID);

                rowsaffected = dal.ExecuteNonQuery("[usp_LinkFJCIDsToCamper]", param);
                
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

        //to get the camper details..like password based on his emailID
        public DataSet GetCamperCredentials(string strEmail)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Email", strEmail);
                DataSet dsCities;
                dsCities = dal.getDataset("[usp_GetCamperCredentials]", param);
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

        public DataSet GetAdminUserDetails(string strUserID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@UserID", strUserID);
                return dal.getDataset("[usp_GetAdminUserDetails]", param);                
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

        public DataSet GetUserDetails(string strUserID)
        {
            CIPDataAccess dal = new CIPDataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@UserID", strUserID);
                DataSet dsUserDetails;
                return dal.getDataset("[usp_GetUserDetails]", param);
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

		//public DataSet GetANReport(int NoOfRecs, int RepID, int Status)
		//{
		//    CIPDataAccess dal = new CIPDataAccess();
		//    try
		//    {
		//        SqlParameter[] param = new SqlParameter[3];
		//        param[0] = new SqlParameter("@NoOfRecs", NoOfRecs);
		//        param[1] = new SqlParameter("@RepID", RepID);
		//        param[2] = new SqlParameter("@Status", Status);
		//        DataSet dsANReport = dal.getDataset("[usp_GetANReport]", param);
		//        return dsANReport;
		//    }
		//    catch (Exception ex)
		//    {
		//        throw ex;
		//    }
		//    finally
		//    {
		//        dal = null;
		//    }
		//}
    }
}
