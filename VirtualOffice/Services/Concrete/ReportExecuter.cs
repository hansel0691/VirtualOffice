using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Infrastructure;
using Domain.Infrastructure.Repositories;
using Domain.Infrastructure.Services;
using Domain.Models;
using Domain.Models.Exceptions;

namespace Services.Concrete
{
    public class ReportExecuter : IReportExecuter
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly IRepository<UserReport> _userReportRepository;
        private IOutputParser _outputParser;

        public ReportExecuter(IQueryExecutor queryExecutor, IOutputParser outputParser, IUnitOfWork unitOfWork)
        {
            _queryExecutor = queryExecutor;
            _userReportRepository = unitOfWork.Get<UserReport>(); //userReportRepository;
            _outputParser = outputParser;
        }

        public IEnumerable<Dictionary<string, object>> ExecuteRaw(string query, params Argument[] args)
        {
            var result = ExecuteQuery(query, args);

            return result;
        }

        public IEnumerable<Dictionary<string, object>> ExecuteRaw(ReportModel report, IEnumerable<Argument> args)
        {
            var query = report.Query; 
            var result = ExecuteRaw(query, args.ToArray());

            return result;
        }

        public IEnumerable<Dictionary<string, object>> Execute(ReportModel report, IEnumerable<Argument> args)
        {
            var reportResult = ExecuteRaw(report, args);
            var projectedResult = Project(reportResult, _outputParser.Parse(report.Output));

            return projectedResult;
        }

        public IEnumerable<Dictionary<string, object>> Execute(UserReport userReport, IEnumerable<Argument> args)
        {
            var reportResult = Execute(userReport.Report, args);
//            var projectedResult = Project(reportResult, _outputParser.Parse(userReport.Output));

            //return projectedResult;

            return reportResult;
        }

        public IEnumerable<Dictionary<string, object>> Execute(int userId, int reportId, IEnumerable<Argument> args)
        {
            UserReport userReport = _userReportRepository.GetByID(new {userId, reportId});

            if (userReport == null)
            {
                throw new ReportExecuterException("Report not found");
            }

            ReportModel report = userReport.Report;

            var reportResult = Execute(report, args);
            var projectedResult = Project(reportResult, _outputParser.Parse(userReport.Output));

            return projectedResult;
        }

        private IEnumerable<Dictionary<string, object>> Project(IEnumerable<Dictionary<string, object>> reportResult, IEnumerable<string> colunmNames)
        {
            foreach (var row in reportResult)
            {
                Dictionary<string, object> projectedRow = new Dictionary<string, object>();

                foreach (var colunmName in colunmNames)
                {
                    if (row.ContainsKey(colunmName))
                    {
                        projectedRow.Add(colunmName, row[colunmName]);
                    }
                }

                yield return projectedRow;
            }
        }

        private IEnumerable<Dictionary<string, object>> ExecuteQuery(string query, IEnumerable<Argument> parameters)
        {
            try
            {
                var queryResult = _queryExecutor.RunQuery(query, parameters);

                return queryResult;
            }
            catch (Exception e)
            {
                throw new ReportExecuterException(string.Format("Error executing query: {0}", query), e);
            }
        }
    }
}
