using System.Collections.Generic;
using Domain.Models;

namespace Domain.Infrastructure.Services
{
    public interface IReportExecuter
    {
        IEnumerable<Dictionary<string, object>> ExecuteRaw(string query, params Argument[] args);

        IEnumerable<Dictionary<string, object>> ExecuteRaw(ReportModel report, IEnumerable<Argument> args);

        IEnumerable<Dictionary<string, object>> Execute(ReportModel report, IEnumerable<Argument> args);

        IEnumerable<Dictionary<string, object>> Execute(UserReport userReport, IEnumerable<Argument> args);

        IEnumerable<Dictionary<string, object>> Execute(int userId, int reportId, IEnumerable<Argument> args);
    }
}
