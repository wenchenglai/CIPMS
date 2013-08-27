using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CIPMSBC.DAL;

namespace CIPMSBC.BLL
{
    public static class SynagogueManager
    {
        public static DataTable GetWhoIsInSynagogue(FederationEnum fed)
        {
            DataTable dt = SynagogueDA.GetWhoIsInSynagogue(fed);

            //var row = dt.NewRow();
            //row["ID"] = "-1";
            //row["Name"] = "I don’t remember";
            //dt.Rows.Add(row);

            //row = dt.NewRow();
            //row["ID"] = "-2";
            //row["Name"] = "Other";
            //dt.Rows.Add(row);
            
            //row = dt.NewRow();
            //row["ID"] = "0";
            //row["Name"] = "Rabbi or Cantor";
            //dt.Rows.InsertAt(row, 0);

            return dt;
        }
    }
}
