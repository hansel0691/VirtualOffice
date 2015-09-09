using CoreData.Concrete;
using CoreData.Contexts;
using Domain.Infrastructure;
using Domain.Infrastructure.Repositories;
using Domain.Infrastructure.Services;
using Domain.Models;
using Domain.Models.Orders;
using Ninject.Modules;

namespace CoreData.DataModule
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<PindataContext>().ToSelf();
            Bind<VirtualOfficeContext>().ToSelf();

            Bind<IQueryExecutor>().To<SqlQueryExecutor>();
            Bind<IReportInfoRepository>().To<SqlReportInfoRepository>();

            Bind<IUserRepository>().To<SqlUserRepository>();
            Bind<ITokenRepository>().To<SqlTokenRepository>();

            Bind<IRepository<AuthToken>>().To<SqlTokenRepository>();
            Bind<IRepository<Lead>>().To<SqlPindataLeadRepository>();
            Bind<IPindataLeadRepository>().To<SqlPindataLeadRepository>();
            Bind<IConsignmentLeadRepository>().To<SqlConsignmentLeadRepository>();

            Bind<IRepository<Incident>>().To<SqlIncidentRepository>();
            Bind<IIncidentsRepository>().To<SqlIncidentRepository>();

            Bind<IInventoryRepository>().To<SqlInventoryRepository>();
            Bind<IRepository<InventoryItem>>().To<SqlInventoryRepository>();

            Bind(typeof (IRepository<>)).To(typeof (Repository<>));

            Bind(typeof (IUnitOfWork)).To(typeof (UnitOfWork));
        }
    }
}
