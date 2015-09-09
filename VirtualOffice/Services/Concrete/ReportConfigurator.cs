using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Infrastructure;
using Domain.Infrastructure.Log;
using Domain.Infrastructure.Repositories;
using Domain.Infrastructure.Services;
using Domain.Models;

namespace Services.Concrete
{
    public class ReportConfigurator : IReportConfigurator
    {
        private readonly IReportExecuter _reportExecuter;
        private readonly IReportInfoRepository _reportInfoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private IRepository<ReportModel> _reportRepository;
        private IRepository<UserReport> _userReportRepository;

        public ReportConfigurator(IReportExecuter reportExecuter, IUnitOfWork unitOfWork
            ,ILogger logger)
        {
            _reportExecuter = reportExecuter;
            _reportInfoRepository = unitOfWork.GetRepository<IReportInfoRepository>(); //reportInfoRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;

            _reportRepository = unitOfWork.Get<ReportModel>();
            _userReportRepository = _unitOfWork.Get<UserReport>();
        }

        public IEnumerable<string> GetReportSchema(string query, params Argument[] args)
        {
            var queryToExecute = query; 
            var reportResult = _reportExecuter.ExecuteRaw(queryToExecute, args);

            return GetSchemaFromReport(reportResult);
        }

        public IEnumerable<Parameter> GetReportParameters(string reportName)
        {
            var parameters = _reportInfoRepository.GetReportParams(reportName);

            return parameters;
        }

        public IEnumerable<UserReport> GetUserReports(int userId)
        {
            var userReports = _reportInfoRepository.GetUserReports(userId);

            return userReports;
        }

        public IEnumerable<ReportModel> GetAll()
        {
            var reports = _reportRepository.Get(null, models => models.OrderBy(model => model.Id));

            return reports;
        }

        public void UpdateFilterToUserReport(UserReport userReport, IEnumerable<KeyValuePair<string, string>> filters)
        {
            RemoveFilter(userReport);

            var groups = filters.GroupBy(pair => pair.Key);

            UpdateFilters(userReport, groups);

            _unitOfWork.Commit();
        }

       

        public void UpdateUserReportOutput(UserReport userReport, string output, string outputConfiguration)
        {
            userReport.Output = output;
            userReport.OutputConfiguration = outputConfiguration;

            _userReportRepository.Update(userReport);
            _unitOfWork.Commit();
        }

        public void UpdateReportDates(UserReport userReport, DateTime startDate, DateTime endDate)
        {
            userReport.StartDate = startDate;
            userReport.EndDate = endDate;

            _userReportRepository.Update(userReport);
            _unitOfWork.Commit();
        }

        private void RemoveFilter(UserReport userReport)
        {
            var userFilterValueRepository = _unitOfWork.Get<UserReportFilterValue>();

            var valuesToDelete = new List<UserReportFilterValue>();

            foreach (var value in userReport.Filters.SelectMany(f => f.Values))
            {
                valuesToDelete.Add(value);
            }

            valuesToDelete.ForEach(entity=>userFilterValueRepository.Delete(entity.Id));


            var userFilterRepository = _unitOfWork.Get<UserReportFilter>();

            userReport.Filters.ToList().ForEach(entity=>userFilterRepository.Delete(entity.Id));
        }

        private void UpdateFilters(UserReport userReport, IEnumerable<IGrouping<string, KeyValuePair<string, string>>> groups)
        {
            foreach (var item in groups)
            {
                userReport.Filters.Add(
                    new UserReportFilter
                    {
                        ColunmName = item.Key,
                        Values = new List<UserReportFilterValue>(item.Select(x => new UserReportFilterValue {Value = x.Value}))
                    });
            }

            _userReportRepository.Update(userReport);
        }

        private IEnumerable<string> GetSchemaFromReport(IEnumerable<Dictionary<string, object>> reportResult)
        {

            foreach (var dic in reportResult)
            {
                foreach (var pair in dic)
                {
                    yield return pair.Value.ToString();
                }
            }
            

            //var row = reportResult.FirstOrDefault();

            //if (row == null)
            //{
            //    throw new DataAccessException("Impossible to load report's schema");
            //}



            //foreach (string key in row.Keys)
            //{
            //    yield return key;
            //}
        }
    }
}
