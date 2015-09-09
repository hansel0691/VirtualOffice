using Domain.Models;

namespace CoreData.Models.Mapping
{
    public class PredefinedFilterMapping : BaseMapping<PredefinedFilter>
    {
        public PredefinedFilterMapping()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.ColumnName)
                .IsRequired();

            this.Property(t => t.ParameterName)
                .IsRequired();

            this.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired(); //make index
        }
    }
}