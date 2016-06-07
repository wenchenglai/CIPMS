using System.Data;

/// <summary>
/// Summary description for FedCampGrantDA
/// </summary>
public class FedCampGrantDA
{
    public static DataTable GetAllByFedID(int CampYearID, int FedID)
    {
        var db = new SQLDBAccess("CIPConnectionString");
        db.AddParameter("@Action", "ByFedIdAndYearId");
        db.AddParameter("@CampYearID", CampYearID);
        db.AddParameter("@FedID", FedID);
        return db.FillDataTable("usp_FedCampGrant");
    }
}