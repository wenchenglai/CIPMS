using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPMSBC.DAL
{
    public class SchedulerDA
    {
        public static int GetPaymentAccessFedID(DateTime myDate)
        {
            var db = new SQLDBAccess("CIPConnectionString");
            db.AddParameter("@Action", "GetFedIDByDate");
            db.AddParameter("@MyDate", myDate);

            var dr = db.ExecuteReader("usp_PaymentDate_Select");

            int ret = 0;

            if (dr.Read())
                ret = (int)dr[0];

            return ret;
        }
    }
}
