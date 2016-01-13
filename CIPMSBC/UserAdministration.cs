using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CIPMSBC
{
    public class UserAdministration
    {
        #region "Private Variables"
        
        private string _strFirstName;
        private string _strLastName;
        private string _strEmail;
        private int _iFederationID;
        private int _iCampID;
        private string _strPswd;
        private string _strPhoneNo;
        private string _strCamps;
        private int _iRoleId;
        private bool _blnSuperAdmin = false;
        private CIPDataAccess _objDAL;
        private int _iUsrId;
        private string _strOldPwd;
        public int MovementID { get; set; }

        #endregion

        #region "Public Properies"

        //Property FirstName
        public string FirstName
        {
            get
            {
                return _strFirstName;
            }
            set
            {
                _strFirstName = value;
            }
        }

        //Property LastName
        public string LastName
        {
            get
            {
                return _strLastName;
            }
            set
            {
                _strLastName = value;
            }
        }

        //Property Email
        public string Email
        {
            get
            {
                return _strEmail;
            }
            set
            {
                _strEmail = value;
            }
        }

        //Property FederationID
        public int FederationID
        {
            get
            {
                return _iFederationID;
            }
            set
            {
                _iFederationID = value;
            }
        }

        //Property CampID
        public int CampID
        {
            get
            {
                return _iCampID;
            }
            set
            {
                _iCampID = value;
            }
        }

        //Property Password
        public string Password
        {
            get
            {
                return _strPswd;
            }
            set
            {
                _strPswd = value;
            }
        }

        //Property PhoneNumber
        public string PhoneNumber
        {
            get
            {
                return _strPhoneNo;
            }
            set
            {
                _strPhoneNo = value;
            }
        }

        //Property CampList
        public string CampList
        {
            get
            {
                return _strCamps;
            }
            set
            {
                _strCamps = value;
            }
        }

        //Property RoleId
        public int RoleId
        {
            get
            {
                return _iRoleId;
            }
            set
            {
                _iRoleId = value;
            }
        }

        //Property IsSuperAdmin
        public bool IsSuperAdmin
        {
            get
            {
                return _blnSuperAdmin;
            }
            set
            {
                _blnSuperAdmin = value;
            }
        }

        //Property UserId
        public int UserId
        {
            get
            {
                return _iUsrId;
            }
            set
            {
                _iUsrId = value;
            }
        }

        //Property OldPassword
        public string OldPassword
        {
            get
            {
                return _strOldPwd;
            }
            set
            {
                _strOldPwd = value;
            }
        }

        #endregion
        
        //Gets user details based on FirstName, LastName, Email, Federation and/or Camp
        public DataSet GetUserDetails()
        {
            SqlParameter[] sparams = new SqlParameter[6];

            sparams[0] = new SqlParameter("@FirstName", (FirstName == string.Empty ? null : FirstName));
            sparams[1] = new SqlParameter("@LastName", (LastName == string.Empty ? null : LastName));
            sparams[2] = new SqlParameter("@Email", (Email == string.Empty ? null : Email));            
            sparams[3] = new SqlParameter("@Federation", (FederationID == 0 ? -1 : FederationID));
            sparams[4] = new SqlParameter("@CampID", (CampID == 0 ? -1 : CampID));
            sparams[5] = new SqlParameter("@MovementID", (MovementID == 0 ? -1 : MovementID));

            _objDAL = new CIPDataAccess();
            DataSet dsUsrDetails;
            try
            {
                dsUsrDetails = _objDAL.getDataset("usp_SearchUsers", sparams);
                return dsUsrDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _objDAL = null;
            }
        }

        //Gets user details by UserId
        public DataSet GetUserById(int iUsrId)
        {
            SqlParameter[] sparams = new SqlParameter[1];
            sparams[0] = new SqlParameter("@UsrId", iUsrId);

            _objDAL = new CIPDataAccess();
            DataSet dsUsrDetails;
            try
            {
                dsUsrDetails = _objDAL.getDataset("[usp_GetUserById]", sparams);
                return dsUsrDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _objDAL = null;
            }
        }

        //Deletes a user
        public void DeleteUser(int iUsrId)
        {
            SqlParameter[] sparams = new SqlParameter[1];
            sparams[0] = new SqlParameter("@userId", iUsrId);

            _objDAL = new CIPDataAccess();
            try
            {
                _objDAL.ExecuteNonQuery("usp_DeleteAdminUser", sparams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _objDAL = null;
            }
        }

        //Creates a user
        public int CreateUser()
        {
            SqlParameter[] sparams = new SqlParameter[11];

            sparams[0] = new SqlParameter("@Password", Password);
            sparams[1] = new SqlParameter("@FirstName", FirstName);
            sparams[2] = new SqlParameter("@LastName", LastName);
            sparams[3] = new SqlParameter("@PhoneNUmber", PhoneNumber);
            sparams[4] = new SqlParameter("@Email", Email);
            sparams[5] = new SqlParameter("@MovementID", MovementID);
            sparams[6] = new SqlParameter("@FederationID", FederationID);
            sparams[7] = new SqlParameter("@RoleID", RoleId);
            sparams[8] = new SqlParameter("@superAdmin", null);
            sparams[9] = new SqlParameter("@camps", CampList);
            sparams[10] = new SqlParameter("@UsrId", SqlDbType.Int);
            sparams[10].Direction = ParameterDirection.Output;

            _objDAL = new CIPDataAccess();
            int iUsrId;
            try
            {
                _objDAL.ExecuteNonQuery("[usp_InsertAdminUser]", sparams);
                iUsrId = Convert.ToInt32(sparams[10].Value);
                return iUsrId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _objDAL = null;
            }
        }

        //Update a user
        public void UpdateUser()
        {
            SqlParameter[] sparams = new SqlParameter[11];

            sparams[0] = new SqlParameter("@UserId", UserId);
            sparams[1] = new SqlParameter("@Password", Password);
            sparams[2] = new SqlParameter("@FirstName", FirstName);
            sparams[3] = new SqlParameter("@LastName", LastName);
            sparams[4] = new SqlParameter("@PhoneNUmber", PhoneNumber);
            sparams[5] = new SqlParameter("@Email", Email);
            sparams[6] = new SqlParameter("@MovementID", MovementID);
            sparams[7] = new SqlParameter("@FederationID", FederationID);
            sparams[8] = new SqlParameter("@RoleID", RoleId);
            sparams[9] = new SqlParameter("@superAdmin", null);
            sparams[10] = new SqlParameter("@camps", CampList);

            _objDAL = new CIPDataAccess();
            try
            {
                _objDAL.ExecuteNonQuery("[usp_UpdateAdminUser]", sparams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _objDAL = null;
            }
        }

        //Change user password
        public string ChangePassword()
        {
            CIPDataAccess objdal = new CIPDataAccess();
            string strMsg;

            try
            {
                SqlParameter[] sparams = new SqlParameter[4];

                sparams[0] = new SqlParameter("@UserId", UserId);
                sparams[1] = new SqlParameter("@OldPwd", OldPassword);
                sparams[2] = new SqlParameter("@NewPwd", Password);
                sparams[3] = new SqlParameter("@Msg", SqlDbType.VarChar, 50);
                sparams[3].Direction = ParameterDirection.Output;

                objdal.ExecuteNonQuery("[usp_ChangePassword]", sparams);
                strMsg = sparams[3].Value.ToString();

                return strMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
            }
        }
    }
}
