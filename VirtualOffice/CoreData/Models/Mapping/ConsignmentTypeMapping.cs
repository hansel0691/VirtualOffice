using System.Data.Entity.ModelConfiguration;
using Domain.Models;

namespace CoreData.Models.Mapping
{
    public class ConsignmentTypeMapping : EntityTypeConfiguration<ConsignmentType>
    {
        public ConsignmentTypeMapping()
        {
            this.Ignore(type => type.RowVersion);
            this.Ignore(type => type.TimeSpan);

            this.Property(type => type.Id)
                .HasColumnName("typ_Id");

            this.Property(type => type.Type)
                .HasColumnName("typ_Type");

            this.Property(type => type.Description)
                .HasColumnName("typ_Description");

            this.Property(type => type.Order)
                .HasColumnName("typ_order");

            this.ToTable("Types");
        }
    }
}