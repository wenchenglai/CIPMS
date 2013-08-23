using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CIPMSBC
{
    public class SrchCamperDetails
    {
        #region "Private Variables"

        private string _FirstName;
        private string _LastName;
        private string _EmailId;
        private string _FJCID;
        private string _FederationID;
        private string _Camplist;
        private int _Age;
        private int _Grade;
        private int _ModifiedBy;
        private string _Status;
        private string _ZipCode;
        private string _ZipCodeFrom;
        private string _ZipCodeTo;
        private string _dtCreatedFrom;
        private string _dtCreatedTo;
        private string _dtSubmittedFrom;
        private string _dtSubmittedTo;
        private string _dtUpdatedFrom;
        private string _dtUpdatedTo;
        private bool _blnSortFlag;
        private string _strSortColumn;
        private string _strSortOrder;
        private int _iUserId;
        private bool _blnWorkQueue;
        private int _CampYearGrant;
        private string _StartDate;
        private string _EndDate;
        private string _HomePhone;
        private string _CampYear;
        #endregion

        #region "Properties"

        //Property FirstName
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }

        //Property LastName
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        //Property EmailId
        public string EmailId
        {
            get
            {
                return _EmailId;
            }
            set
            {
                _EmailId = value;
            }
        }

        //Property FJCID
        public string FJCID
        {
            get
            {
                return _FJCID;
            }
            set
            {
                _FJCID = value;
            }
        }

        //Property FederationID
        public string FederationID
        {
            get
            {
                return _FederationID;
            }
            set
            {
                _FederationID = value;
            }
        }

        //Property Camplist
        public string Camplist
        {
            get
            {
                return _Camplist;
            }
            set
            {
                _Camplist = value;
            }
        }

        //Property Age
        public int Age
        {
            get
            {
                return _Age;
            }
            set
            {
                _Age = value;
            }
        }

        //Property Grade
        public int Grade
        {
            get
            {
                return _Grade;
            }
            set
            {
                _Grade = value;
            }
        }

        //Property ModifiedBy
        public int ModifiedBy
        {
            get
            {
                return _ModifiedBy;
            }
            set
            {
                _ModifiedBy = value;
            }
        }

        //Property Status
        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }

        //Property ZipCode
        public string ZipCode
        {
            get
            {
                return _ZipCode;
            }
            set
            {
                _ZipCode = value;
            }
        }

        //Property ZipCodeFrom
        public string ZipCodeFrom
        {
            get
            {
                return _ZipCodeFrom;
            }
            set
            {
                _ZipCodeFrom = value;
            }
        }

        //Property ZipCodeTo
        public string ZipCodeTo
        {
            get
            {
                return _ZipCodeTo;
            }
            set
            {
                _ZipCodeTo = value;
            }
        }

        //Property DateCreatedFrom
        public string DateCreatedFrom
        {
            get
            {
                return _dtCreatedFrom;
            }
            set
            {
                _dtCreatedFrom = value;
            }
        }

        //Property DateCreatedTo
        public string DateCreatedTo
        {
            get
            {
                return _dtCreatedTo;
            }
            set
            {
                _dtCreatedTo = value;
            }
        }

        //Property DateSubmittedFrom
        public string DateSubmittedFrom
        {
            get
            {
                return _dtSubmittedFrom;
            }
            set
            {
                _dtSubmittedFrom = value;
            }
        }

        //Property DateSubmittedTo
        public string DateSubmittedTo
        {
            get
            {
                return _dtSubmittedTo;
            }
            set
            {
                _dtSubmittedTo = value;
            }
        }

        //Property DateUpdatedFrom
        public string DateUpdatedFrom
        {
            get
            {
                return _dtUpdatedFrom;
            }
            set
            {
                _dtUpdatedFrom = value;
            }
        }

        //Property DateUpdatedTo
        public string DateUpdatedTo
        {
            get
            {
                return _dtUpdatedTo;
            }
            set
            {
                _dtUpdatedTo = value;
            }
        }

        //Property SortFlag
        public bool SortFlag
        {
            get
            {
                return _blnSortFlag;
            }
            set
            {
                _blnSortFlag = value;
            }
        }

        //Property SortColumn
        public string SortColumn
        {
            get
            {
                return _strSortColumn;
            }
            set
            {
                _strSortColumn = value;
            }
        }

        //Property SortOrder
        public string SortOrder
        {
            get
            {
                return _strSortOrder;
            }
            set
            {
                _strSortOrder = value;
            }
        }

        //Property UserId 
        public int UserId
        {
            get
            {
                return _iUserId;
            }
            set
            {
                _iUserId = value;
            }
        }

        //Property WorkQueue
        public bool WorkQueue 
        {
            get
            {
                return _blnWorkQueue;
            }
            set
            {
                _blnWorkQueue = value;
            }
        }
        //Property CampYearGrant
        public int CampYearGrant
        {
            get
            {
                return _CampYearGrant;
            }
            set
            {
                _CampYearGrant = value;
            }
        }
        //Property DateUpdatedFrom
        public string StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
            }
        }
        //Property DateUpdatedFrom
        public string EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
            }
        }
        //Property HomePhone
        public string HomePhone
        {
            get
            {
                return _HomePhone;
            }
            set
            {
                _HomePhone = value;
            }
        }

        public string CampYear
        {
            get
            {
                return _CampYear;
            }
            set
            {
                _CampYear = value;
            }
        }

        #endregion
   
        //to fill the grid for camper details
        public DataSet SearchCamperDetails()
        {
            SqlParameter[] sparams = new SqlParameter[28];

            sparams[0] = new SqlParameter("@CamperName", (FirstName == string.Empty ? null : FirstName));
            sparams[1] = new SqlParameter("@CamperLastName", (LastName == string.Empty ? null : LastName));
            sparams[2] = new SqlParameter("@CamperEmailId", (EmailId == string.Empty ? null : EmailId));
            sparams[3] = new SqlParameter("@FJCID", (FJCID == string.Empty ? null : FJCID));
            sparams[4] = new SqlParameter("@FederationID", (FederationID == "-1" ? null : FederationID));
            sparams[5] = new SqlParameter("@CamplISt", (Camplist == string.Empty ? null : Camplist));
            sparams[6] = new SqlParameter("@Age", (Age == 0 ? -1 : Age));
            sparams[7] = new SqlParameter("@Grade", (Grade == 0 ? -1 : Grade));
            sparams[8] = new SqlParameter("@ModIFiedBy", (ModifiedBy == 0 ? -1 : ModifiedBy));
            sparams[9] = new SqlParameter("@Status", (Status == string.Empty ? null : Status));
            sparams[10] = new SqlParameter("@ZipCode", (ZipCode == string.Empty ? "-1" : ZipCode));
            sparams[11] = new SqlParameter("@ZipCodeFROM", (ZipCodeFrom == string.Empty ? "-1" : ZipCodeFrom));
            sparams[12] = new SqlParameter("@ZipCodeTo", (ZipCodeTo == string.Empty ? "-1" : ZipCodeTo));
            sparams[13] = new SqlParameter("@DateCreatedFROM", (DateCreatedFrom == string.Empty ? null : DateCreatedFrom));
            sparams[14] = new SqlParameter("@DateCreatedTo", (DateCreatedTo == string.Empty ? null : DateCreatedTo));
            sparams[15] = new SqlParameter("@DateSubmittedFROM", (DateSubmittedFrom == string.Empty ? null : DateSubmittedFrom));
            sparams[16] = new SqlParameter("@DateSubmittedTo", (DateSubmittedTo == string.Empty ? null : DateSubmittedTo));
            sparams[17] = new SqlParameter("@LastUpdatedFROM", (DateUpdatedFrom == string.Empty ? null : DateUpdatedFrom));
            sparams[18] = new SqlParameter("@LastUpdatedTo", (DateUpdatedTo == string.Empty ? null : DateUpdatedTo));
            sparams[19] = new SqlParameter("@SortFlag", (SortFlag == true ? "Y" : "N"));
            sparams[20] = new SqlParameter("@SortColumn", (SortColumn == "-1" ? "FJCID" : SortColumn));
            sparams[21] = new SqlParameter("@SortOrder", (SortOrder == "-1" ? "Asc" : SortOrder));
            sparams[22] = new SqlParameter("@WorkQueue", (WorkQueue == true ? "Y" : "N"));
            sparams[23] = new SqlParameter("@CampYearGrant", (CampYearGrant == 0 ? -1 : CampYearGrant));
            sparams[24] = new SqlParameter("@StartDate", (StartDate == string.Empty ? null : StartDate));
            sparams[25] = new SqlParameter("@EndDate", (EndDate == string.Empty ? null : EndDate));
            sparams[26] = new SqlParameter("@CamperHomePhone", (HomePhone == string.Empty ? null : HomePhone));
            sparams[27] = new SqlParameter("@CampYear", (CampYear == string.Empty ? "0" : CampYear));
            CIPDataAccess dal = new CIPDataAccess();
            DataSet dsCamperDetails;
            try
            {
                dsCamperDetails = dal.getDataset("usp_SearchCamperApplication", sparams);
                return dsCamperDetails;
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

        public DataSet GetCamperDetails(int iCamperId)
        {
            SqlParameter[] sparams = new SqlParameter[1];
            sparams[0] = new SqlParameter("@CamperId", iCamperId);
            
            CIPDataAccess dal = new CIPDataAccess();
            DataSet dsCamperDetails;
            try
            {
                dsCamperDetails = dal.getDataset("[usp_GetCamperDetails]", sparams);
                return dsCamperDetails;
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

        //Lock or Unlock the record for the user
        public void LockUnlockRecord(string strMode)
        {
            SqlParameter[] sparams = new SqlParameter[3];
            sparams[0] = new SqlParameter("@Mode ", strMode);
            sparams[1] = new SqlParameter("@UserId", UserId);
            sparams[2] = new SqlParameter("@FJCID", FJCID);

            CIPDataAccess objdal = new CIPDataAccess();
            try
            {
                objdal.ExecuteNonQuery("[usp_LockUnlockRecords]", sparams);
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

        //to fill the grid for camper details
        public DataSet SearchCamperDetails(string strUserRole)
        {
            SortColumn = "-1";
            SortOrder = "-1";

            SqlParameter[] sparams = new SqlParameter[25];

            sparams[0] = new SqlParameter("@CamperName", (FirstName == string.Empty ? null : FirstName));
            sparams[1] = new SqlParameter("@CamperLastName", (LastName == string.Empty ? null : LastName));
            sparams[2] = new SqlParameter("@CamperEmailId", (EmailId == string.Empty ? null : EmailId));
            sparams[3] = new SqlParameter("@FJCID", (FJCID == string.Empty ? null : FJCID));
            sparams[4] = new SqlParameter("@FederationID", (FederationID == "-1" ? null : FederationID));
            sparams[5] = new SqlParameter("@CamplISt", (Camplist == string.Empty ? null : Camplist));
            sparams[6] = new SqlParameter("@Age", (Age == 0 ? -1 : Age));
            sparams[7] = new SqlParameter("@Grade", (Grade == 0 ? -1 : Grade));
            sparams[8] = new SqlParameter("@ModIFiedBy", (ModifiedBy == 0 ? -1 : ModifiedBy));
            sparams[9] = new SqlParameter("@Status", (Status == string.Empty ? null : Status));
            sparams[10] = new SqlParameter("@ZipCode", (ZipCode == string.Empty ? "-1" : ZipCode));
            sparams[11] = new SqlParameter("@ZipCodeFROM", (ZipCodeFrom == string.Empty ? "-1" : ZipCodeFrom));
            sparams[12] = new SqlParameter("@ZipCodeTo", (ZipCodeTo == string.Empty ? "-1" : ZipCodeTo));
            sparams[13] = new SqlParameter("@DateCreatedFROM", (DateCreatedFrom == string.Empty ? null : DateCreatedFrom));
            sparams[14] = new SqlParameter("@DateCreatedTo", (DateCreatedTo == string.Empty ? null : DateCreatedTo));
            sparams[15] = new SqlParameter("@DateSubmittedFROM", (DateSubmittedFrom == string.Empty ? null : DateSubmittedFrom));
            sparams[16] = new SqlParameter("@DateSubmittedTo", (DateSubmittedTo == string.Empty ? null : DateSubmittedTo));
            sparams[17] = new SqlParameter("@LastUpdatedFROM", (DateUpdatedFrom == string.Empty ? null : DateUpdatedFrom));
            sparams[18] = new SqlParameter("@LastUpdatedTo", (DateUpdatedTo == string.Empty ? null : DateUpdatedTo));
            sparams[19] = new SqlParameter("@SortFlag", (SortFlag == true ? "Y" : "N"));
            sparams[20] = new SqlParameter("@SortColumn", (SortColumn == "-1" ? "FJCID" : SortColumn)); //     sparams[20] = new SqlParameter("@SortColumn", (SortColumn == "-1" ? "FJCID" : SortColumn));
            sparams[21] = new SqlParameter("@SortOrder", (SortOrder == "-1" ? "Asc" : SortOrder));
            sparams[22] = new SqlParameter("@WorkQueue", (WorkQueue == true ? "Y" : "N"));
            sparams[23] = new SqlParameter("@UserRole", (strUserRole == string.Empty ? "0" : strUserRole));
            sparams[24] = new SqlParameter("@CampYear", (CampYear == string.Empty ? "0" : CampYear));

            CIPDataAccess dal = new CIPDataAccess();
            DataSet dsCamperDetails;
            try
            {
                dsCamperDetails = dal.getDataset("usp_SearchCamperApplicationForFJCAdmin", sparams);
                return dsCamperDetails;
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

        public DataSet SearchCamperDetails(string FJCID,string CY)
        {
            SortColumn = "-1";
            SortOrder = "-1";

            SqlParameter[] sparams = new SqlParameter[25];

            sparams[0] = new SqlParameter("@CamperName", (FirstName == string.Empty ? null : FirstName));
            sparams[1] = new SqlParameter("@CamperLastName", (LastName == string.Empty ? null : LastName));
            sparams[2] = new SqlParameter("@CamperEmailId", (EmailId == string.Empty ? null : EmailId));
            sparams[3] = new SqlParameter("@FJCID", (FJCID ==string.Empty? null : FJCID));
            sparams[4] = new SqlParameter("@FederationID", (FederationID == "-1" ? null : FederationID));
            sparams[5] = new SqlParameter("@CamplISt", (Camplist == string.Empty ? null : Camplist));
            sparams[6] = new SqlParameter("@Age", (Age == 0 ? -1 : Age));
            sparams[7] = new SqlParameter("@Grade", (Grade == 0 ? -1 : Grade));
            sparams[8] = new SqlParameter("@ModIFiedBy", (ModifiedBy == 0 ? -1 : ModifiedBy));
            sparams[9] = new SqlParameter("@Status", (Status == string.Empty ? null : Status));
            sparams[10] = new SqlParameter("@ZipCode", (ZipCode == string.Empty ? "-1" : ZipCode));
            sparams[11] = new SqlParameter("@ZipCodeFROM", (ZipCodeFrom == string.Empty ? "-1" : ZipCodeFrom));
            sparams[12] = new SqlParameter("@ZipCodeTo", (ZipCodeTo == string.Empty ? "-1" : ZipCodeTo));
            sparams[13] = new SqlParameter("@DateCreatedFROM", (DateCreatedFrom == string.Empty ? null : DateCreatedFrom));
            sparams[14] = new SqlParameter("@DateCreatedTo", (DateCreatedTo == string.Empty ? null : DateCreatedTo));
            sparams[15] = new SqlParameter("@DateSubmittedFROM", (DateSubmittedFrom == string.Empty ? null : DateSubmittedFrom));
            sparams[16] = new SqlParameter("@DateSubmittedTo", (DateSubmittedTo == string.Empty ? null : DateSubmittedTo));
            sparams[17] = new SqlParameter("@LastUpdatedFROM", (DateUpdatedFrom == string.Empty ? null : DateUpdatedFrom));
            sparams[18] = new SqlParameter("@LastUpdatedTo", (DateUpdatedTo == string.Empty ? null : DateUpdatedTo));
            sparams[19] = new SqlParameter("@SortFlag", (SortFlag == true ? "Y" : "N"));
            sparams[20] = new SqlParameter("@SortColumn", (SortColumn == "-1" ? "FJCID" : SortColumn)); //     sparams[20] = new SqlParameter("@SortColumn", (SortColumn == "-1" ? "FJCID" : SortColumn));
            sparams[21] = new SqlParameter("@SortOrder", (SortOrder == "-1" ? "Asc" : SortOrder));
            sparams[22] = new SqlParameter("@WorkQueue", (WorkQueue == true ? "Y" : "N"));
            sparams[23] = new SqlParameter("@UserRole", (UserId == 0 ? -1 : UserId));
            sparams[24] = new SqlParameter("@CampYear", (CampYear == string.Empty ? "0" : CampYear));

            CIPDataAccess dal = new CIPDataAccess();
            DataSet dsCamperDetails;
            try
            {
                dsCamperDetails = dal.getDataset("usp_SearchCamperApplicationForFJCAdmin", sparams);
                return dsCamperDetails;
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
        public DataSet getReturningCamperDetails(string fName,string lName, string Dob)
        {
            SqlParameter[] sparams = new SqlParameter[3];

            sparams[0] = new SqlParameter("@FirstName", (fName == string.Empty ? null : fName));
            sparams[1] = new SqlParameter("@LastName", (lName == string.Empty ? null : lName));
            sparams[2] = new SqlParameter("@DOB", (Dob == string.Empty ? null : Dob));
            //sparams[3] = new SqlParameter("@FederationId", (strFederationId == string.Empty ? null : strFederationId));
            
            CIPDataAccess dal = new CIPDataAccess();
            DataSet dsCamperDetails;
            try
            {
                dsCamperDetails = dal.getDataset("[usp_getReturningCamperDetails]", sparams);
                return dsCamperDetails;
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
        public DataSet getAllReturningCamperDetails(string fName, string lName, string Dob)
        {
            SqlParameter[] sparams = new SqlParameter[2];

           // sparams[0] = new SqlParameter("@FirstName", (fName == string.Empty ? null : fName));
            sparams[0] = new SqlParameter("@LastName", (lName == string.Empty ? null : lName));
            sparams[1] = new SqlParameter("@DOB", (Dob == string.Empty ? null : Dob));
            //sparams[3] = new SqlParameter("@FederationId", (strFederationId == string.Empty ? null : strFederationId));

            CIPDataAccess dal = new CIPDataAccess();
            DataSet dsCamperDetails;
            try
            {
                dsCamperDetails = dal.getDataset("[usp_getAllReturningCamperDetails]", sparams);
                return dsCamperDetails;
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
        public DataSet getManualReturningCamperDetails(string fName, string lName, string Dob)
        {
            SqlParameter[] sparams = new SqlParameter[3];

            sparams[0] = new SqlParameter("@FirstName", (fName == string.Empty ? null : fName));
            sparams[1] = new SqlParameter("@LastName", (lName == string.Empty ? null : lName));
            sparams[2] = new SqlParameter("@DOB", (Dob == string.Empty ? null : Dob));
            //sparams[3] = new SqlParameter("@FederationId", (strFederationId == string.Empty ? null : strFederationId));

            CIPDataAccess dal = new CIPDataAccess();
            DataSet dsCamperDetails;
            try
            {
                dsCamperDetails = dal.getDataset("[usp_getManualReturningCamperDetails]", sparams);
                return dsCamperDetails;
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