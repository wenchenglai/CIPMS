using System.Data;

/// <summary>
/// Summary description for BulkStatusUpdateRecordDA
/// </summary>
public class BulkStatusUpdateRecordDA
{
    public static DataTable GetAll(int CampYearID, int FedID)
    {
        var db = new SQLDBAccess("CIPConnectionString");
        db.AddParameter("@Action", "ByFedID");
        db.AddParameter("@CampYearID", CampYearID);
        db.AddParameter("@FedID", FedID);
        return db.FillDataTable("usp_BulkStatusUpdateRecord_Select");
    }
}