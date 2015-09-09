using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http.Dependencies;
using CoreData.BlackstoneDb.BlackstonDbModule;
using CoreData.Contexts;
using CoreData.DataModule;
using CoreData.Inventory;
using CoreService.Controllers;
using CoreService.Interceptors;
using Domain.Blackstone;
using Domain.Infrastructure;
using Domain.Infrastructure.Repositories;
using Domain.Models;
using NAPP.Ninject.Extensions.Logging.Log4Net;
using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Web.Common;
using Services.ServiceModule;
using WebGrease.Css.Extensions;

namespace CoreService.Resolver
{
    public class VistualOfficeResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public VistualOfficeResolver()
        {
            Bind();
        }

        private void Bind()
        {
            var settings = new NinjectSettings { LoadExtensions = true };

            _kernel = new StandardKernel(settings);

            _kernel.Bind<IInterceptor>().To<LoggingInterceptor>();

            _kernel.Load(new DataModule(), new LoggerModule(), new BlackstoneDbModule(), new InventoryModule());
            _kernel.Load(new ServiceModule(GetLoggingInterceptor()));



            //_kernel.Get<OrdersController>();
        }

        private IInterceptor GetLoggingInterceptor()
        {
            return _kernel.Get<IInterceptor>();
        }


        public void Dispose()
        {
           
        }

        public object GetService(Type serviceType)
        {
            object result = _kernel.TryGet(serviceType);

            return result;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IEnumerable<object> result = _kernel.GetAll(serviceType);

            return result;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}