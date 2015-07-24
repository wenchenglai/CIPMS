using System.Data;
using System.Windows.Forms;

/// <summary>
/// Summary description for ZipCodeDA
/// </summary>
public class ZipCodeDA
{
    public static DataTable GetZipCodes(int fedId)
    {
        var db = new SQLDBAccess("CIPConnectionString");
        db.AddParameter("@Action", "AllByFedId");
        db.AddParameter("@FedID", fedId);
        return db.FillDataTable("usp_FedZipCodes_Select");
    }

    public static DataTable GetZipCodes(string zipCode)
    {
        var db = new SQLDBAccess("CIPConnectionString");
        db.AddParameter("@Action", "ByZipCode");
        db.AddParameter("@ZipCode", zipCode);
        return db.FillDataTable("usp_FedZipCodes_Select");
    }

    public static void DeleteZipCode(int ID)
    {
        if (ID > 0)
        {
            var db = new SQLDBAccess("CIPConnectionString");
            db.AddParameter("@Action", "ByZipCodeID");
            db.AddParameter("@ZipCodeID", ID);
            db.ExecuteNonQuery("usp_FedZipCodes_Delete");            
        }
    }

    public static bool InsertZipCode(int fedId, string zipCode)
    {
        if (fedId > 0 && zipCode != "")
        {
            var dt = GetZipCodes(zipCode);

            if (dt.Rows.Count > 0)
                return false;

            var db = new SQLDBAccess("CIPConnectionString");
            db.AddParameter("@Action", "Single");
            db.AddParameter("@FedID", fedId);
            db.AddParameter("@ZipCode", zipCode);
            db.ExecuteNonQuery("usp_FedZipCodes_Insert");
            return true;
        }
        return true;
    }
}