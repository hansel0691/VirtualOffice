using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Threading;
using Domain.Models;

namespace CoreData.Models.Mapping
{
    public class UserMapping : BaseMapping<User>
    {
        public UserMapping()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.RefId)
                .IsRequired();

            this.Property(t => t.Category)
                .IsRequired();

            this.Ignore(user => user.Address1);
            this.Ignore(user => user.Address2);
            this.Ignore(user => user.BusinessName);
            this.Ignore(user => user.City);
            this.Ignore(user => user.Comission);
            this.Ignore(user => user.Email);
            this.Ignore(user => user.Name);
            this.Ignore(user => user.Phone);
            this.Ignore(user => user.State);
            this.Ignore(user => user.ZipCode);
        }
    }
}