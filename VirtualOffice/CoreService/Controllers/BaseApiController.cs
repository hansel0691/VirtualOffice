using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Domain.Infrastructure.Log;

namespace CoreService.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        protected readonly ILogger _logger;

        protected BaseApiController(ILogger logger)
        {
            _logger = logger;
        }

        protected virtual void LogException(Exception exception)
        {
            _logger.Error(exception, "Error");
        }
    }
}