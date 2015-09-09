using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using CoreService.Models;
using Domain.Infrastructure.Log;
using Domain.Models;

namespace CoreService.Filters
{
    public class SystemErrorExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            ILogger logger = GetLogger();

            try
            {
                var controllerName = actionExecutedContext.ActionContext.ControllerContext.Controller.GetType().Name;
                var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;


                if (logger != null)
                {
                    logger.DebugException(string.Format("An exception has been thrown by: {0} in action: {1}", controllerName, actionName),
                        actionExecutedContext.Exception);
                }

                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new
                    {
                        ErrorObject = actionExecutedContext.Exception,
                        Message = "An exception has been thrown, please report this: " + actionExecutedContext.Exception.InnerException.Message
                    });
            }
            catch (Exception e)
            {
                logger.DebugException("ERROR", e);
            }
        }

        private ILogger GetLogger()
        {
            ILogger result = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILogger)) as ILogger;

            return result;
        }
    }
}