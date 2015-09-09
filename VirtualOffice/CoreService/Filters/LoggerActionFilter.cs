using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Domain.Infrastructure.Log;

namespace CoreService.Filters
{
    public class LoggerActionFilter : ActionFilterAttribute
    {
        private ILogger _logger;

        public LoggerActionFilter()
        {
            _logger = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILogger)) as ILogger;

            if (_logger == null)
            {
                throw new InvalidOperationException("Logger could not be resolved on LoggerActionFilter");
            }
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                var controllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
                var actionName = actionContext.ActionDescriptor.ActionName;

                _logger.Debug(string.Format("Starting operation: {0} / {1}", controllerName, actionName));
            }
            finally
            {
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            try
            {
                var controllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
                var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;

                _logger.Debug(string.Format("Ending operation: {0} / {1}", controllerName, actionName));

                _logger.Info("=========================================================================================================");
                _logger.Info("=========================================================================================================");
                _logger.Info("=========================================================================================================");
            }
            finally
            {
            }
        }
    }
}