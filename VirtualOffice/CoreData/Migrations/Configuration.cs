using Domain.Models;

namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CoreData.Contexts.VirtualOfficeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CoreData.Contexts.VirtualOfficeContext context)
        {
              //This method will be called after migrating to the latest version.

              //You can use the DbSet<T>.AddOrUpdate() helper extension method 
              //to avoid creating duplicate seed data. E.g.

            context.UserTypes.AddOrUpdate(type => type.TypeName,
                new UserType {TypeName = "Agent"},
                new UserType {TypeName = "Merchant"}
                );
            //
        }
    }
}
