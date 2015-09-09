using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class GEO_CountiesMap : EntityTypeConfiguration<GEO_Counties>
    {
        public GEO_CountiesMap()
        {
            // Primary Key
            this.HasKey(t => t.countyID);

            // Properties
            this.Property(t => t.countyID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ctName)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("GEO_Counties");
            this.Property(t => t.countyID).HasColumnName("countyID");
            this.Property(t => t.stateID).HasColumnName("stateID");
            this.Property(t => t.ctName).HasColumnName("ctName");

            // Relationships
            this.HasOptional(t => t.GEO_States)
                .WithMany(t => t.GEO_Counties)
                .HasForeignKey(d => d.stateID);

        }
    }
}
