using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPMSBC.DAL
{
    public static class SynagogueDA
    {
        public static DataTable GetWhoIsInSynagogue(FederationEnum fed)
        {
            SQLDBAccess db = new SQLDBAccess("CIPConnectionString");
            db.AddParameter("@Action", "GetWhoIsInSynagogue");
            db.AddParameter("@FedID", (int)fed);

            return db.FillDataTable("uspSynagogueMember_Select");
        }
    }
}
