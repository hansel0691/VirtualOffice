using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using CoreService.Binder;
using CoreService.Filters;
using CoreService.Models;
using Domain.Infrastructure;
using Domain.Infrastructure.Log;
using Domain.Infrastructure.Services;
using Domain.Models;
using System.Web.Http.ModelBinding;
using Newtonsoft.Json;
using RestSharp;
using Parameter = Domain.Models.Parameter;

namespace CoreService.Controllers
{
#if !DEBUG
  //  [AuthorizationFilter]
#endif


    public class ReportConfigurationController : BaseApiController
    {
        private IReportConfigurator _reportConfigurator;
        private readonly IUnitOfWork _unitOfWork;

        public ReportConfigurationController(IReportConfigurator reportConfigurator, IUnitOfWork unitOfWork, ILogger logger) : base(logger)
        {
            _reportConfigurator = reportConfigurator;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IHttpActionResult GetReportParameter(string reportName)
        {
            if (string.IsNullOrEmpty(reportName))
            {
                return BadRequest("reportName cannot be empty");
            }

            IEnumerable<Parameter> parameters = _reportConfigurator.GetReportParameters(reportName);

            return Ok(parameters);
        }

        [HttpGet]
        public IHttpActionResult GetUserReports(int userId)
        {
            IEnumerable<UserReport> reports = _reportConfigurator.GetUserReports(userId); 

            return Ok(GetUserReportViewModels(reports));
        }

        [HttpGet]
        public IHttpActionResult GetReports()
        {
            var reports = _reportConfigurator.GetAll().ToList();

            List<ReportConfigViewModel> result = new List<ReportConfigViewModel>();

            foreach (ReportModel report in reports)
            {
                var parameters = _reportConfigurator.GetReportParameters(report.Query);

                AddReportToResponse(result, report, parameters);
            }

            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult GetReportSchema([ModelBinder(typeof (DataBinder))] ReportConfigModel reportConfigView)
        {
            var schema = GetReportSchemaAsync(reportConfigView.ReportName, reportConfigView.Args).Result;

            return Ok(schema);
        }

        [HttpPost]
        public IHttpActionResult UpdateUserReportOutput([FromBody] UserReportOutputModel userReportOutputModel)
        {
            var userReport = _reportConfigurator.GetUserReports(userReportOutputModel.UserId)
                .FirstOrDefault(report => report.ReportId == userReportOutputModel.ReportId);

            if (userReport == null)
            {
                return NotFound();
            }

            _reportConfigurator.UpdateUserReportOutput(userReport, userReportOutputModel.Output, userReportOutputModel.OutputConfiguration);

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UpdateUserReportConfiguration([FromBody] UserReportConfigurationModel configurationModel)
        {

            base._logger.Debug("ShowReportOnDesktop: " + configurationModel.ShowReportOnDesktop);


            var report = _reportConfigurator.GetUserReports(configurationModel.UserId)
                .FirstOrDefault(userReport => userReport.ReportId == configurationModel.ReportId);

            if (report == null)
            {
                return NotFound();
            }

            report.ShouldBeShownAtDesktop = configurationModel.ShowReportOnDesktop;
            _unitOfWork.Commit();

            return Ok(new { ShouldBeShownAtDesktop = report.ShouldBeShownAtDesktop });
        }

        [HttpPost]
        public IHttpActionResult UpdateUserReportDates([FromBody] UserReportDates dates)
        {
            var userReport = _reportConfigurator.GetUserReports(dates.UserId)
                 .FirstOrDefault(report => report.ReportId == dates.ReportId);

            _reportConfigurator.UpdateReportDates(userReport, dates.StartDate, dates.EndDate);

            return Ok();
        }

        private Task<IEnumerable<string>> GetReportSchemaAsync(string reportName, IEnumerable<Argument> args)
        {
            return new TaskFactory<IEnumerable<string>>().StartNew(() =>
                {
                    return _reportConfigurator.GetReportSchema("sp_retrieve_storedprocedure_columns", new Argument {Value = reportName, Param = new Parameter {Name = "@spname"}});
                });
        }

        private UserReportViewModel GetUserReportViewModel(UserReport userReport)
        {
            var parameters = _reportConfigurator.GetReportParameters(userReport.Report.Query);

            var userFiltersConfig = userReport.Filters.SelectMany(f => f.Values.Select(v => new KeyValuePair<string, string>(f.ColunmName, v.Value)));

            var reportLabels = userReport.Report.Labels.Select(label => new LabelViewModel {ColumnName = label.ColumnName, Label = label.Label});

            return new UserReportViewModel
            {
                UserId = userReport.User.RefId,
                ReportId = userReport.ReportId,

                DefaultOuput = userReport.Report.Output,
                Output = userReport.Output,
                Name = userReport.Report.Name,
                ParamsDefaultConfiguration = userReport.Report.ParamsDefaultConfiguration,
                Parameters = parameters.ToArray(),

                StartDate = userReport.StartDate,
                EndDate = userReport.EndDate,

                UserFilters = userReport.Report.UserFilters,
                UserFiltersConfig = userFiltersConfig,
                PredefinedFilters = userReport.Report.PredefinedFilters.Where(f => f.ReportId == userReport.Report.Id).Select(x => GetPredefinedFilterViewModel(x.Filter)).ToArray(),

                SubReport = userReport.Report.SubReports
                    .Where(r => r.FromId == userReport.Report.Id).Select(x =>
                        new SubReportConfigModel
                        {
                            SubReportId = x.ToId,
                            DependencyProperty = x.DependencyProperty,
                            IndexParamName = x.IndexParamName
                        }),

                IndexColumnName = userReport.Report.IndexColumnName,

                ParentReportIds = userReport.Report.ParentReports.Where(r => r.ToId == userReport.Report.Id).Select(x => x.FromId),
                IsStandAlone = userReport.Report.IsStandAlone,

                Labels = reportLabels,
                OutputConfiguration = userReport.OutputConfiguration,
                Category = userReport.Report.Category,
                RowCount = userReport.RowCount,
                ShouldBeShownAtDesktop = userReport.ShouldBeShownAtDesktop,
                ExecutionCount = userReport.ExecutionCount
            };
        }

        private IEnumerable<UserReportViewModel> GetUserReportViewModels(IEnumerable<UserReport> reports)
        {
            foreach (UserReport userReport in reports)
            {
                yield return GetUserReportViewModel(userReport);
            }
        }

        private PredefinedFilterViewModel GetPredefinedFilterViewModel(PredefinedFilter filter)
        {

            return new PredefinedFilterViewModel
            {
                Id = filter.Id,
                Name = filter.Value,
                Value = filter.Value,
                Type = filter.Type,
                ParameterName = filter.ParameterName,
                ColumnName = filter.ColumnName
            };
        }

        private void AddReportToResponse(List<ReportConfigViewModel> result, ReportModel report, IEnumerable<Parameter> parameters)
        {
            result.Add(new ReportConfigViewModel
            {
                Id = report.Id,
                Name = report.Name,
                Output = report.Output,
                ParamsDefaultConfiguration = report.ParamsDefaultConfiguration,
                Parameters = parameters.ToArray(),
                UserFilters = report.UserFilters, //report.UserFilters.Where(f => f.ReportId == report.Id).Select(x => GetUserFilterViewModel(x.Filter)).ToArray(),
                PredefinedFilters = report.PredefinedFilters.Where(f => f.ReportId == report.Id).Select(x => GetPredefinedFilterViewModel(x.Filter)).ToArray(),
                SubReport = report.SubReports
                    .Where(r => r.FromId == report.Id).Select(x =>
                        new SubReportConfigModel
                        {
                            SubReportId = x.ToId,
                            DependencyProperty = x.DependencyProperty,
                            IndexParamName = x.IndexParamName
                        }),
                IndexColumnName = report.IndexColumnName,
                ReportName = report.Name,
                ParentReportIds = report.ParentReports.Where(r => r.ToId == report.Id).Select(x => x.FromId),
                IsStandAlone = report.IsStandAlone,
                Labels = report.Labels.Select(label => new LabelViewModel { ColumnName = label.ColumnName, Label = label.Label }),
                Category = report.Category
            });
        }

        [HttpGet]
        public IHttpActionResult TestGetSchema(string spname)
        {

            return GetReportSchema(new ReportConfigModel {ReportName = "sp_report_portfolio_summary"});
        }

        [HttpGet]
        public IHttpActionResult TestUpdateConfig()
        {
            string s = "%5B%7B%22Name%22%3A%22MID%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A122%2C%22Index%22%3A1%7D%2C%7B%22Name%22%3A%22Alert%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A42%2C%22Index%22%3A0%7D%2C%7B%22Name%22%3A%22business_name%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A240%2C%22Index%22%3A2%7D%2C%7B%22Name%22%3A%22business_address%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A120%2C%22Index%22%3A3%7D%2C%7B%22Name%22%3A%22City%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A70%2C%22Index%22%3A4%7D%2C%7B%22Name%22%3A%22State%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A62%2C%22Index%22%3A5%7D%2C%7B%22Name%22%3A%22Zip%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A69%2C%22Index%22%3A6%7D%2C%7B%22Name%22%3A%22Phone%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A120%2C%22Index%22%3A7%7D%2C%7B%22Name%22%3A%22Opened%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A120%2C%22Index%22%3A8%7D%2C%7B%22Name%22%3A%22acc_type%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A120%2C%22Index%22%3A9%7D%2C%7B%22Name%22%3A%22p_plan%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A120%2C%22Index%22%3A10%7D%2C%7B%22Name%22%3A%22weekly_credit_limit%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A120%2C%22Index%22%3A11%7D%2C%7B%22Name%22%3A%22daily_credit_limit%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A120%2C%22Index%22%3A12%7D%2C%7B%22Name%22%3A%22Balance%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A120%2C%22Index%22%3A13%7D%2C%7B%22Name%22%3A%22Status%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A120%2C%22Index%22%3A14%7D%2C%7B%22Name%22%3A%22connection_type%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A120%2C%22Index%22%3A15%7D%2C%7B%22Name%22%3A%22last_sale%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A120%2C%22Index%22%3A16%7D%2C%7B%22Name%22%3A%22last_month_sales%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A120%2C%22Index%22%3A17%7D%2C%7B%22Name%22%3A%22this_month_sales%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A120%2C%22Index%22%3A18%7D%2C%7B%22Name%22%3A%22seven_day_sales%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A120%2C%22Index%22%3A19%7D%2C%7B%22Name%22%3A%22today_sales%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A120%2C%22Index%22%3A20%7D%2C%7B%22Name%22%3A%22software_version%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A120%2C%22Index%22%3A21%7D%2C%7B%22Name%22%3A%22top_selling_product%22%2C%22Selected%22%3Afalse%2C%22Filterable%22%3Afalse%2C%22Width%22%3A120%2C%22Index%22%3A22%7D%5D";

            s = HttpUtility.UrlDecode(s);

            UserReportOutputModel configuration = new UserReportOutputModel
            {
                UserId = 2272,
                ReportId = 40,
                Output = "Alert,MID,business_name,business_address,City,State,Zip,Phone,Opened,acc_type,p_plan,weekly_credit_limit,daily_credit_limit,Balance,Status,connection_type,last_sale,last_month_sales,this_month_sales,seven_day_sales,today_sales,software_version,top_selling_product",
                OutputConfiguration = s
            };

            return UpdateUserReportOutput(configuration);
        }

        [HttpGet]
        public IHttpActionResult TestUpdateUserReportConfiguration()
        {
            return UpdateUserReportConfiguration(new UserReportConfigurationModel
            {
                ReportId = 40,
                UserId = 2272,
                ShowReportOnDesktop = false
            });
        }
    }
}
