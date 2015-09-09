using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Services.ServiceModule;
using ApiRestClient.ServiceBind;
using System.Web.Mvc;

namespace VirtualOffice.Web.Resolver
{
    public class ResolverServices : IDependencyResolver
    {
        private IKernel _kernel;

        public ResolverServices()
        {
            Bind();
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

        private void Bind()
        {
            _kernel = new StandardKernel();
            _kernel.Load(new ServiceModule(), new ServiceBind());
        }
    }
}