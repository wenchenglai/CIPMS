using System.Collections.Generic;
using Microsoft.Office.Interop.Word;
using DataTable = System.Data.DataTable;

/// <summary>
/// Summary description for FederationsDA
/// </summary>
public class FederationsDA
{
    public static DataTable GetAllFederations(int CampYearID)
    {
        SQLDBAccess db = new SQLDBAccess("CIPConnectionString");
        db.AddParameter("@Action", "All");
        db.AddParameter("@CampYearID", CampYearID);
        return db.FillDataTable("usprsFederations_Select");
    }

    public static DataTable GetAllFederationsByUserRole(int CampYearID, Role UserRole, int FedID)
    {
        SQLDBAccess db = new SQLDBAccess("CIPConnectionString");
        db.AddParameter("@Action", "All");
        db.AddParameter("@CampYearID", CampYearID);
        if (UserRole != Role.FJCAdmin)
            db.AddParameter("@FedID", FedID);
        return db.FillDataTable("usprsFederations_Select");
    }

    public static DataTable GetAllFederationsByMultipleCampYearsAndUserRole(string CampYearID_String, Role UserRole, int FedID)
    {
        SQLDBAccess db = new SQLDBAccess("CIPConnectionString");
        db.AddParameter("@Action", "ByMultipleYears");
        db.AddParameter("@CampYearID_String", CampYearID_String);
        if (UserRole != Role.FJCAdmin)
            db.AddParameter("@FedID", FedID);
        return db.FillDataTable("usprsFederations_Select");
    }

    public static Dictionary<string, string> GetFederationByZipCode(string zipCode, int fedId)
    {
        var db = new SQLDBAccess("CIPConnectionString");
        db.AddParameter("@Action", "GetFedByZipCode");
        if (fedId == 0)
            db.AddParameter("@ZipCode", zipCode);
        else
            db.AddParameter("@FedID", fedId);

        var dr = db.ExecuteReader("usprsFederations_Select");

        var ret = new Dictionary<string, string>();

        if (dr.Read())
        {
            ret.Add("ID", dr["ID"].ToString());
            ret.Add("Name", dr["Name"].ToString());
            ret.Add("Contact", dr["Contact"].ToString());
            ret.Add("Phone", dr["Phone"].ToString());
            ret.Add("Email", dr["Email"].ToString());
            ret.Add("isActive", dr["isActive"].ToString());
            ret.Add("isGrantAvailable", dr["isGrantAvailable"].ToString());
            ret.Add("isOnlineProcessing", dr["isOnlineProcessing"].ToString());
            ret.Add("isJDSAvailable", dr["isJDSAvailable"].ToString());
            ret.Add("isJDSOnline", dr["isJDSOnline"].ToString());
        }
        return ret;
    }
}
