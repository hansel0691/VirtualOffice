using System.Collections.Generic;
using Domain.Models;

namespace Domain.Infrastructure.Services
{
    public interface IQueryExecutor
    {
        IEnumerable<Dictionary<string, object>> RunQuery(string query, IEnumerable<Argument> parameters);
    }
}