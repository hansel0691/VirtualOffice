using System.Collections;
using System.Collections.Generic;
using Domain.Models;

namespace Domain.Infrastructure.Services
{
    public interface IReportService
    {
        IEnumerable<Dictionary<string, object>> Run(int reportId, IEnumerable<Argument> args);
        
        IEnumerable<Dictionary<string, object>> Run(int userId, int reportId, IEnumerable<Argument> args);

        IEnumerable<Dictionary<string, object>> Run(UserReport userReport, IEnumerable<Argument> args);
    }
}