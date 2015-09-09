using System;
using System.Linq;
using Domain.Infrastructure.Log;
using Ninject.Extensions.Interception;

namespace CoreService.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        private readonly ILogger _logger;

        public LoggingInterceptor(ILogger logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Request.Method.Name;
            try
            {
                var parameterNames = invocation.Request.Method.GetParameters().Select(p => p.Name).ToList();
                var parameterValues = invocation.Request.Arguments;

                var message = string.Format("Method {0} called with parameters:\n", methodName);
                for (int index = 0; index < parameterNames.Count; index++)
                {
                    var name = parameterNames[index];
                    var value = parameterValues[index];
                    message += string.Format("{0}: <{1}>\n", name, value);
                }

                //log method called
                LogMessage(message + "\n");

                //run the intercepted method
                invocation.Proceed();

                //log method return value
                if (invocation.Request.Method.ReturnType != typeof(void))
                {
                    LogMessage(string.Format("Method: {0} returned: \n{1}\n", methodName, invocation.ReturnValue));
                }
                else
                {
                    LogMessage(string.Format("Method: {0} returned: \n{1}\n", methodName, "void"));
                }
            }
            catch (Exception ex)
            {
                var message = string.Format("Method {0} EXCEPTION occured:\n{1}\n", methodName, ex);
                LogMessage(message);
                throw;
            }
        }

        private void LogMessage(string message)
        {
            foreach (var line in message.Split('\n'))
            {
                _logger.Debug(line);
            }
        }

    }
}