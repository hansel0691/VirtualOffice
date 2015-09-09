using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure.Repositories;
using Domain.Models;
using Domain.Models.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Infrastructure.Services
{
    public interface IReportConfigurator 
    {
        IEnumerable<string> GetReportSchema(string query, params Argument[] args);

        IEnumerable<Parameter> GetReportParameters(string reportName);
        
        IEnumerable<UserReport> GetUserReports(int userId);

        IEnumerable<ReportModel> GetAll();

        void UpdateFilterToUserReport(UserReport userReport, IEnumerable<KeyValuePair<string, string>> filters);

        void UpdateUserReportOutput(UserReport userReport, string output, string outputConfiguration);
        
        void UpdateReportDates(UserReport userReport, DateTime startDate, DateTime endDate);
    }
}
