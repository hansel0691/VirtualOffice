using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class table1Map : EntityTypeConfiguration<table1>
    {
        public table1Map()
        {
            // Primary Key
            this.HasKey(t => t.field1);

            // Properties
            this.Property(t => t.field1)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("table1");
            this.Property(t => t.field1).HasColumnName("field1");
        }
    }
}
