using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CIPMSBC
{
	public class SpecialCodeManager
	{
		/// <summary>
		/// If this code is still valid for this specific year/fed
		/// </summary>
		/// <param name="CampYearID"></param>
		/// <param name="FedID"></param>
		/// <param name="Code"></param>
		/// <returns></returns>
		public static bool IsValidCode(int CampYearID, int FedID, string Code)
		{
			var codes = GetAvailableCodes(CampYearID, FedID);

			bool isValid = false;
			foreach (string code in codes)
			{
				if (code == Code)
				{
					isValid = true;
					break;
				}
			}

			return isValid;
		}

        // Direct Pass Code for PJL would allow user to go to PJL Summary page immediately no matter what
        public static bool IsValidPJLDirectPassCode(int CampYearID, string Code)
        {
            List<string> codes = new List<string>();
            SQLDBAccess db = new SQLDBAccess("CIPConnectionString");

            db.AddParameter("@Action", "IsPJLDirectPass");
            db.AddParameter("@CampYearID", CampYearID);
            db.AddParameter("@Code", Code);

            SqlDataReader dr = db.ExecuteReader("usprsSpecialCodes_Select");

            bool res = false;

            if (dr.Read())
            {
                res =  Convert.ToBoolean(dr[0]);
            }

            return res;
        }

		public static List<string> GetAvailableCodes(int CampYearID, int FedID)
		{
            return GetAvailableCodesPerCamp(CampYearID, FedID, -1);
		}

        public static List<string> GetAvailableCodesPerCamp(int CampYearID, int FedID, int CampID)
        {
            List<string> codes = new List<string>();
            SQLDBAccess db = new SQLDBAccess("CIPConnectionString");

            db.AddParameter("@Action", "GetAvailableCodes");
            db.AddParameter("@CampYearID", CampYearID);
            db.AddParameter("@FedID", FedID);
            if (CampID > 0)
                db.AddParameter("@CampID", CampID);

            SqlDataReader dr = db.ExecuteReader("usprsSpecialCodes_Select");

            while (dr.Read())
            {
                codes.Add(dr[0].ToString());
            }

            return codes;
        }

		// This will increment 1 to tblSpecialCodes' Uses column
		public static bool UseCode(int CampYearID, int FedID, string Code, string FJCID)
		{
			SQLDBAccess db = new SQLDBAccess("CIPConnectionString");

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
