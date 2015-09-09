using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CoreData.Contexts;
using Domain.Infrastructure.Log;
using Domain.Infrastructure.Services;
using Domain.Models;
using Domain.Models.Exceptions;

namespace CoreData.Concrete
{
    public class SqlQueryExecutor : IQueryExecutor
    {
        private readonly VirtualOfficeContext _context;

        public SqlQueryExecutor(ILogger logger, VirtualOfficeContext context)
        {
            _context = context;
        }

        public IEnumerable<Dictionary<string, object>> RunQuery(string query, IEnumerable<Argument> parameters)
        {
            try
            {
                var cmd = SetUpCommand(query, parameters.Where(IsValidParam), _context);

                var reader = cmd.ExecuteReader(CommandBehavior.Default);
                var result = GetResult(reader);

                reader.Close();

                return result;

            }
            catch (Exception e)
            {
                throw new ReportExecuterException("See inner exception", e);
            }
        }

        private bool IsValidParam(Argument argument)
        {
            return argument.Value != null && !string.IsNullOrEmpty(argument.Value.ToString());
        }

        private SqlCommand SetUpCommand(string query, IEnumerable<Argument> parameters, VirtualOfficeContext context)
        {
            using (SqlCommand cmd = (SqlCommand)context.Database.Connection.CreateCommand())
            {

                context.Database.Connection.Open();

                cmd.CommandText = query;
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (Argument arg in parameters)
                {
                    cmd.Parameters.AddWithValue(arg.Param.Name, arg.Value);
                }

                return cmd;
            }
        }

        private IEnumerable<Dictionary<string, object>> GetResult(SqlDataReader reader)
        {
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();

            if (reader.HasRows)
            {
                foreach (var row in reader)
                {
                    Dictionary<string, object> rowResult = new Dictionary<string, object>();

                    IDataRecord record = (IDataRecord)row;

                    for (int i = 0; i < record.FieldCount; i++)
                    {
                        rowResult.Add(record.GetName(i), record[i]);
                    }

                    result.Add(rowResult);
                }
            }

            return result;
        }
    }
}
