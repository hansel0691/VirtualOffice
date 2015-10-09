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

                var command = new SqlCommand("sp_getTransactions", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@agentid", agentID);
                command.Parameters.AddWithValue("@dateinit", ini_date.ToString("MM-dd-yyyy"));
                command.Parameters.AddWithValue("@dateend", end_date.ToString("MM-dd-yyyy"));

                connection.Open();

                using (var reader = command.ExecuteReader())
                    result.AddRange(reader.Select(r => r.MapTo<IDataReader, sp_get_transactions_Result>()));

                result.ForEach(r => { r.begindate = ini_date.ToUniversalTime().ToString("d"); r.enddate = end_date.ToUniversalTime().ToString("d"); });
                connection.Close();
            }
            return result;
        }

        public static IEnumerable<sp_getTransactions_details> sp_getTransactions_details(int agentId, DateTime startDate, DateTime endDate, string columnName)
        {
            var result = new List<sp_getTransactions_details>();
            using (var connection = new SqlConnection("data source=PSSQLWAREHOUSE;initial catalog=Merchant_sign_up;user id=webuser;password=dog33156"))
            {

                var command = new SqlCommand("sp_getTransactions_details", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@merchant_pk", agentId);
                command.Parameters.AddWithValue("@data_column", GetColumnId(columnName) );
                command.Parameters.AddWithValue("@dateinit", startDate.ToString("d"));
                command.Parameters.AddWithValue("@dateend", endDate.ToString("d"));

                connection.Open();

                using (var reader = command.ExecuteReader())
                    result.AddRange(reader.Select(r => r.MapTo<IDataReader, sp_getTransactions_details>()));

                connection.Close();
            }
            return result;
        }


        /// <summary>
        /// Excecute a stored procedure from PSSQLWAREHOUSE
        /// </summary>
        /// <typeparam name="TResult">result of the store procedure type.</typeparam>
        /// <param name="name">name of the stored procedure in the db.</param>
        /// <param name="parameters">tuple with the name of the parameters for the stored procedure and the values.</param>
        /// <returns></returns>
        public static IEnumerable<TResult> CallStoreProcedure<TResult>(string name, string catalog, params Tuple<string, object>[] parameters )
        {
            var result = new List<TResult>();
            using (var connection = new SqlConnection("data source=PSSQLWAREHOUSE;initial catalog=" + catalog + ";user id=webuser;password=dog33156"))
            {

                var command = new SqlCommand(name, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                foreach (var tuple in parameters)
                    command.Parameters.AddWithValue(tuple.Item1, tuple.Item2);

                connection.Open();
                using (var reader = command.ExecuteReader())
                    result.AddRange(reader.Select(r => r.MapTo<IDataReader, TResult>()));

                connection.Close();
            }
            return result;
        }


        /*
            0: mer_name link
            1: vmc_amount link
            2: amex_amount link
            3: dscv_amount link
            4: ebt_amount link
            5: oth_amount link
            6: tran_amt link
        */
        private static int GetColumnId(string columnName)
        {
            switch (columnName)
            {
                case "mer_name":
                    return 0;
                case "vmc_amount":
                    return 1;
                case "amex_amount":
                    return 2;
                case "dscv_amount":
                    return 3;
                case "ebt_amount":
                    return 4;
                case "oth_amount":
                    return 5;
                default:
                    return 6;
            }
        }
    }
}
