using System.Data;

public class MovementDAL
{
    public static DataTable GetAllMovement()
    {
        var db = new SQLDBAccess("CIPConnectionString");
        db.AddParameter("@Action", "All");
        return db.FillDataTable("usp_Movement_Select");
    }

    public static DataTable GetMovementFedIDsByUserID(int userId)
    {
        var db = new SQLDBAccess("CIPConnectionString");
        db.AddParameter("@Action", "GetMovementFedIDsByUserID");
        db.AddParameter("@UserID", userId);
        return db.FillDataTable("usp_Movement_Select");
    }
}