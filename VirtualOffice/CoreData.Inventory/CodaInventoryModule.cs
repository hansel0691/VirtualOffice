using Domain.Inventory;
using Ninject.Modules;

namespace CoreData.Inventory
{
    public class InventoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IInventoryRepository>().To<InventoryRepository>();
        }
    }
}