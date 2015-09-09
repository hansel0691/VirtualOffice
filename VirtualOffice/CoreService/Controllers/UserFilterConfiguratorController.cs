using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using CoreService.Binder;
using CoreService.Filters;
using CoreService.Models;
using Domain.Infrastructure.Services;
using RestSharp;

namespace CoreService.Controllers
{
#if !DEBUG
  //  [AuthorizationFilter]
#endif
    public class UserFilterConfiguratorController : ApiController
    {
        private readonly IReportConfigurator _reportConfigurator;

        public UserFilterConfiguratorController(IReportConfigurator reportConfigurator)
        {
            _reportConfigurator = reportConfigurator;
        }

        [HttpPost]
        public IHttpActionResult UpdateFilterForUserReport([ModelBinder(typeof(DataBinder))] UserReportFilterConfiguration configuration)
        {
            var userReport = _reportConfigurator.GetUserReports(configuration.UserReportInfo.UserId)
                .FirstOrDefault(report => report.ReportId == configuration.UserReportInfo.ReportId);

            if (userReport == null)
            {
                return NotFound();
            }

            _reportConfigurator.UpdateFilterToUserReport(userReport, configuration.Filters.Select(f => new KeyValuePair<string, string>(f.ColumnName, f.Value)));

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Test()
        {
            return UpdateFilterForUserReport(new UserReportFilterConfiguration
            {
                UserReportInfo = new UserReportInfoModel
                {
                    UserId = 2272,
                    ReportId = 40
                },
                Filters = new List<UserReportFilterModel>(new []{
                    new UserReportFilterModel{ColumnName = "Agent Id", Value = "209"}, 
                    new UserReportFilterModel{ColumnName = "Agent name", Value = "Rafael Beraza"}
                })
            });
        }
    }
}