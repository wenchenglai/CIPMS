using System.Data;

/// <summary>
/// Summary description for FedCampGrantDA
/// </summary>
public class FedCampGrantDA
{
    public static DataSet GetAllByFedID(int CampYearID, int FedID)
    {
        var db = new SQLDBAccess("CIPConnectionString");
        db.AddParameter("@Action", "ByFedIdAndYearId");
        db.AddParameter("@CampYearID", CampYearID);
        db.AddParameter("@FedID", FedID);
        return db.FillDataSet("usp_FedCampGrant");
    }
}