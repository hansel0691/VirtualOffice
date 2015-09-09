using System.Collections.Generic;
using System.Linq;
using Domain.Infrastructure.Services;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using Services.Concrete;

namespace Services.ServiceModule
{
    public class ServiceModule : NinjectModule
    {
        private readonly IInterceptor _interceptor;

        public ServiceModule(IInterceptor interceptors = null)
        {
            _interceptor = interceptors;
        }

        public override void Load()
        {
            if (_interceptor == null)
            {
                Bind();
            }
            else
            {
                BindWithInterceptors(_interceptor);
            }
        }

        private void Bind()
        {
            Bind<IReportConfigurator>().To<ReportConfigurator>();
            Bind<IReportExecuter>().To<ReportExecuter>();
            Bind<IOutputParser>().To<ReportOutputParser>();
            Bind<IHashProvider>().To<HmacHashProvider>();
            Bind<ITokenService>().To<TokenService>();
            Bind<IApiUserService>().To<ApiUserService>();
            Bind<IUserService>().To<UserService>();
            Bind<IReportService>().To<ReportService>();
            Bind<IQueryLeadService>().To<LeadService>();
            Bind<ICommandLeadService>().To<LeadService>();
            Bind<IIncidentService>().To<IncidentService>();
            Bind<IInventoryService>().To<InventoryService>();
            Bind<IOrderService>().To<OrderService>();
        }

        private void BindWithInterceptors(IInterceptor interceptor)
        {
            Bind<IIncidentService>().To<IncidentService>().Intercept().With(interceptor);
            Bind<IReportConfigurator>().To<ReportConfigurator>().Intercept().With(interceptor);
            Bind<IReportExecuter>().To<ReportExecuter>().Intercept().With(interceptor);
            Bind<IOutputParser>().To<ReportOutputParser>().Intercept().With(interceptor);
            Bind<IHashProvider>().To<HmacHashProvider>().Intercept().With(interceptor);
            Bind<ITokenService>().To<TokenService>().Intercept().With(interceptor);
            Bind<IApiUserService>().To<ApiUserService>().Intercept().With(interceptor);
            Bind<IUserService>().To<UserService>().Intercept().With(interceptor);
            Bind<IReportService>().To<ReportService>().Intercept().With(interceptor);
            Bind<IQueryLeadService>().To<LeadService>().Intercept().With(interceptor);
            Bind<ICommandLeadService>().To<LeadService>().Intercept().With(interceptor);
            Bind<IInventoryService>().To<InventoryService>().Intercept().With(interceptor);
            Bind<IOrderService>().To<OrderService>().Intercept().With(interceptor);
        }
    }
}
