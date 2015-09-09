using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreData.BlackstoneDb.Context;
using Domain.Blackstone;
using Ninject.Modules;

namespace CoreData.BlackstoneDb.BlackstonDbModule
{
    public class BlackstoneDbModule : NinjectModule
    {
        public override void Load()
        {
            Bind<BlackstoneDbContext>().ToSelf();
            Bind<IEmployeeRepository>().To<EmployeeRepository>();
        }
    }
}
