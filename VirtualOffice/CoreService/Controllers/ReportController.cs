using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using CoreService.Binder;
using CoreService.Filters;
using CoreService.Models;
using Domain.Infrastructure.Log;
using Domain.Infrastructure.Services;
using Domain.Models;
using Domain.Models.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using Parameter = Domain.Models.Parameter;

namespace CoreService.Controllers
{
#if !DEBUG
   //  [AuthorizationFilter]
#endif
    public class ReportController : BaseApiController
    {
        private IReportService _reportService;
        private readonly IApiUserService _apiUserService;

        public ReportController(IReportService reportService, ILogger logger, IApiUserService apiUserService) 
            : base(logger)
        {
            _reportService = reportService;
            _apiUserService = apiUserService;
        }

        [HttpPost]
        public IHttpActionResult RunReport([ModelBinder(typeof(DataBinder))]  ReportInfoModel reportInfoModel)
        {
            try
            {
                if (reportInfoModel == null)
                {
                    _logger.Debug("NULL reportInfoModel");
                    
                    return BadRequest();
                }

                var reportResult = _reportService.Run(reportInfoModel.ReportId, reportInfoModel.Args);

                return Ok(reportResult.ToArray());
            }
            catch (ReportExecuterException e)
            {
                LogException(e);

                return NotFound();
            }
        }
       
        [HttpPost]
        public IHttpActionResult RunUserReport([ModelBinder(typeof (DataBinder))]  UserReportInfoModel userReportInfo)
        {
            try
            {
                var resportResult = _reportService.Run(userReportInfo.UserId, userReportInfo.ReportId, userReportInfo.Args);

                return Ok(resportResult);
            }
            catch (ReportExecuterException e)
            {
                LogException(e);

                return InternalServerError(e);
            }
        }

        [HttpGet]
        public IHttpActionResult TestRunUserReport()
        {
            var p = new UserReportInfoModel
            {
                UserId = 2272,
                ReportId = 40,
                Args = new List<Argument>()
            };

            var x=  RunUserReport(p);

            return x;
        }

        [HttpGet]
        public IHttpActionResult TestRunReport()
        {
            var p = new ReportInfoModel
            {
                ReportId = 41,
                Args = new List<Argument>(
                    
                    new[]
                    {
                        new Argument
                        {
                            Param = new Parameter{Name = "@mid"},
                            Value = 79272
                        },
                       
                    })
            };


            return RunReport(p);

        }
    }
}
