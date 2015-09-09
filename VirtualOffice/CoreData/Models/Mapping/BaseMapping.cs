using System.Data.Entity.ModelConfiguration;
using Domain.Models;

namespace CoreData.Models.Mapping
{
    public abstract class BaseMapping<T> : EntityTypeConfiguration<T> where T : BaseUModel
    {
        protected BaseMapping()
        {
            this.Property(t => t.RowVersion).IsConcurrencyToken();
            this.Property(t => t.TimeSpan).IsRequired();
        }
    }
}