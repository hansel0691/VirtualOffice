using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualOffice.Data.EFModels;
using VirtualOffice.Data.Helpers;

namespace VirtualOffice.Data.External
{
    public static class OldConector
    {
        public static IEnumerable<sp_get_transactions_Result> sp_get_transactions(Nullable<int> agentID, DateTime ini_date, DateTime end_date)
        {
            var result = new List<sp_get_transactions_Result>();
            using (var connection = new SqlConnection("data source=PSSQLWAREHOUSE;initial catalog=Merchant_sign_up;user id=webuser;password=dog33156"))
            {

                var command = new SqlCommand("sp_getTransactions", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@agentid", agentID);
                command.Parameters.AddWithValue("@dateinit", ini_date.ToString("MM-dd-yyyy"));
                command.Parameters.AddWithValue("@dateend", end_date.ToString("MM-dd-yyyy"));

                connection.Open();

                using (var reader = command.ExecuteReader())
                    result.AddRange(reader.Select(r => r.MapTo<IDataReader, sp_get_transactions_Result>()));

                connection.Close();
            }
            return result;
        }
    }
}
