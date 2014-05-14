using System.Data;

public class CamperAppDA
{
    public static bool BulkUpdateStatus(int campYearId, int fedId, string campIdList, int userId, int fromStatusId, int toStatusId)
    {
        var db = new SQLDBAccess("CIPConnectionString");
        db.AddParameter("@Action", "BulkUpdateStatus");
        db.AddParameter("@CampYearID", campYearId);
        db.AddParameter("@FedID", fedId);
        db.AddParameter("@CampIds", campIdList);
        db.AddParameter("@UserID", userId);
        db.AddParameter("@FromStatusID", fromStatusId);
        db.AddParameter("@ToStatusID", toStatusId);
        int ret = db.ExecuteNonQuery("usp_CamperApplication_Update");
        return true;
    }
}