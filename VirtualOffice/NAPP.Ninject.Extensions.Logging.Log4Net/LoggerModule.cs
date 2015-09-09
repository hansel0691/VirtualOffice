using Domain.Infrastructure.Log;
using log4net;
using Ninject.Activation;
using Ninject.Modules;

namespace NAPP.Ninject.Extensions.Logging.Log4Net
{
    public class LoggerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().ToMethod(GetLogger);
            Bind<ILogger>().To<Log4NetLogger>();
        }

        private ILog GetLogger(IContext context)
        {
            try
            {
                ILog result = LogManager.GetLogger(context.Request.ParentContext.Request.ParentContext.Request.Service.FullName);
                return result;
            }
            catch
            {
                return LogManager.GetLogger("Generic Logger");
            }
        }
    }
}