using System.Collections.Generic;
using Domain.Models;

namespace Domain.Infrastructure.Repositories
{
    public interface IReportInfoRepository
    {
        IEnumerable<Parameter> GetReportParams(string query);
        
        IEnumerable<UserReport> GetUserReports(int userId);
    }
}