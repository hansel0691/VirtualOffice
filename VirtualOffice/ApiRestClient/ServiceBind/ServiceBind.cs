using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using ApiRestClient.Infrastructure;
using ApiRestClient.Services;

namespace ApiRestClient.ServiceBind
{
    public class ServiceBind : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthService>().To<AuthService>();
            Bind<IWebClient>().To<WebClient>();
        }
    }
}
