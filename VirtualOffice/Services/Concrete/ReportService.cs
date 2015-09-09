using System.Collections.Generic;
using System.Linq;
using Domain.Infrastructure;
using Domain.Infrastructure.Repositories;
using Domain.Infrastructure.Services;
using Domain.Models;
using Domain.Models.Exceptions;

namespace Services.Concrete
{
    public class ReportService : IReportService
    {
        private IReportExecuter _reportExecuter;
        private readonly IUnitOfWork _unitOfWork;
        private IRepository<ReportModel> _reportRepository;
        private readonly IRepository<UserReport> _userReportRepository;
        private IUserRepository _userRepository;

        public ReportService(IReportExecuter reportExecuter, IUnitOfWork unitOfWork)
        {
            _reportExecuter = reportExecuter;
            _unitOfWork = unitOfWork;
            _reportRepository = unitOfWork.Get<ReportModel>();
            _userReportRepository = unitOfWork.Get<UserReport>();
            _userRepository = unitOfWork.GetRepository<IUserRepository>();
        }

        public IEnumerable<Dictionary<string, object>> Run(int reportId, IEnumerable<Argument> args)
        {
            try
            {
                ReportModel report = _reportRepository.GetByID(reportId);

                if (report == null)
                {
                    throw new ReportExecuterException("Report not found");
                }

                var result = _reportExecuter.Execute(report, args);

                return result;
            }
            catch (DataAccessException e)
            {
                throw new ReportExecuterException("See inner exception", e);
            }
        }

        public IEnumerable<Dictionary<string, object>> Run(int userId, int reportId, IEnumerable<Argument> args)
        {
            try
            {
                User user = _userRepository.GetByID(userId);

                if (user == null)
                {
                    throw new ReportExecuterException(string.Format("User {0} not found", userId));
                }

                var userReport = _userReportRepository.GetByID(user.Id, reportId);

                if (userReport == null)
                {
                    throw new ReportExecuterException("Report not found");
                }

                var result = Run(userReport, args);

                UpdateReportStatistics(userReport, result.Count());

                return result;
            }
            catch (DataAccessException e)
            {
                throw new ReportExecuterException("See inner exception", e);
            }
        }

        public IEnumerable<Dictionary<string, object>> Run(UserReport userReport, IEnumerable<Argument> args)
        {
            try
            {
                var result = _reportExecuter.Execute(userReport, args);

                return result;
            }
            catch (DataAccessException e)
            {
                throw new ReportExecuterException("See inner exception", e);
            }
        }

        private void UpdateReportStatistics(UserReport userReport, int rowCount)
        {
            userReport.ExecutionCount++;
            userReport.RowCount = rowCount;
            _unitOfWork.Commit();
        }
    }
}