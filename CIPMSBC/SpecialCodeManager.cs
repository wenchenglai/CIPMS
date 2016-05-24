using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CIPMSBC
{
	public class SpecialCodeManager
	{
		/// <summary>
		/// If this code is still valid for this specific year/fed
		/// </summary>
		/// <param name="CampYearID"></param>
		/// <param name="FedID">FedID = 0 means </param>
		/// <param name="Code"></param>
		/// <returns></returns>
		public static bool IsValidCode(int CampYearID, int FedID, string Code, string FJCID = "")
		{
			var codes = GetAvailableCodes(CampYearID, FedID);

            bool ret = false;

		    ret = codes.Any(code => code.ToLower() == Code.ToLower());

            // if the camper is also the one uses the code, we return true
            if (!ret && FJCID != "")
            {
                ret = IsUsedByFJCID(FJCID, Code);
            }

            return ret;
		}

        // Direct Pass Code for PJL would allow user to go to PJL Summary page immediately no matter what
        public static bool IsValidDirectPassCode(int CampYearID, FederationEnum Fed, string Code)
        {
            var db = new SQLDBAccess("CIPConnectionString");

            int FedID = Convert.ToInt32(Fed);
            string storeProcName = "IsDirectPass";
            if (Fed == FederationEnum.PJL)
                storeProcName = "IsPJLDirectPass";

            db.AddParameter("@Action", storeProcName);
            db.AddParameter("@CampYearID", CampYearID);
            db.AddParameter("@FedID", FedID);
            db.AddParameter("@Code", Code);

            SqlDataReader dr = db.ExecuteReader("usprsSpecialCodes_Select");

            bool res = false;

            if (dr.Read())
            {
                res =  Convert.ToBoolean(dr[0]);
            }

            return res;
        }

        public static bool IsValidPJLPassCodeAllowDaySchool(int CampYearID, string Code)
        {
            var db = new SQLDBAccess("CIPConnectionString");

            db.AddParameter("@Action", "IsValidPJLPassCodeAllowDaySchool");
            db.AddParameter("@CampYearID", CampYearID);
            db.AddParameter("@Code", Code);

            SqlDataReader dr = db.ExecuteReader("usprsSpecialCodes_Select");

            bool res = false;

            if (dr.Read())
            {
                res = Convert.ToBoolean(dr[0]);
            }

            return res;
        }

		public static List<string> GetAvailableCodes(int CampYearID, int FedID)
		{
            return GetAvailableCodesPerCamp(CampYearID, FedID, -1);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campYearId"></param>
        /// <param name="fedId">-1 means we don't concern about fed</param>
        /// <param name="campId"></param>
        /// <returns></returns>
        public static List<string> GetAvailableCodesPerCamp(int campYearId, int fedId, int campId)
        {
            var codes = new List<string>();
            var db = new SQLDBAccess("CIPConnectionString");

            db.AddParameter("@Action", "GetAvailableCodes");
            db.AddParameter("@CampYearID", campYearId);
            if (fedId != -1)
                db.AddParameter("@FedID", fedId);
            if (campId > 0)
                db.AddParameter("@CampID", campId);

            var dr = db.ExecuteReader("usprsSpecialCodes_Select");

            while (dr.Read())
            {
                codes.Add(dr[0].ToString());
            }

            return codes;
        }

        public static bool IsUsedByFJCID(string FJCID, string code)
        {
            var db = new SQLDBAccess("CIPConnectionString");

            db.AddParameter("@Action", "IsUsedByFJCID");
            db.AddParameter("@FJCID", FJCID);
            db.AddParameter("@Code", code);


            var dr = db.ExecuteReader("usprsSpecialCodes_Select");

            bool output = false;
            if (dr.Read())
            {
                output = true;
            }

            dr.Close();

            return output;
        }

        // This will increment 1 to tblSpecialCodes' Uses column
        public static bool UseCode(int CampYearID, int FedID, string Code, string FJCID)
		{
			var db = new SQLDBAccess("CIPConnectionString");

			db.AddParameter("@CampYearID", CampYearID);
			db.AddParameter("@FedID", FedID);
			db.AddParameter("@FJCID", FJCID);
			db.AddParameter("@Code", Code);

			int ret = db.ExecuteNonQuery("usp_UpdateSpecialCode");

			return true;
		}

		// 2012-11-17 starting 2013, JWest/JWestLA shared the same special codes, initially there are 20 of them.  The all should expire in cmap year 2014
		public static List<string> GetAvailableJWestJWestLACodes(int CampYearID)
		{
			List<string> codes = new List<string>();
			SQLDBAccess db = new SQLDBAccess("CIPConnectionString");

			db.AddParameter("@Action", "GetAvailableJWestJWestLACodes");
			db.AddParameter("@CampYearID", CampYearID);

			SqlDataReader dr = db.ExecuteReader("usprsSpecialCodes_Select");

			while (dr.Read())
			{
				codes.Add(dr[0].ToString());
			}

			return codes;
		}
	}
}
