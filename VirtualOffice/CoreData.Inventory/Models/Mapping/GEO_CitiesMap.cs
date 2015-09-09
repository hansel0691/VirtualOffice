using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class GEO_CitiesMap : EntityTypeConfiguration<GEO_Cities>
    {
        public GEO_CitiesMap()
        {
            // Primary Key
            this.HasKey(t => t.cityID);

            // Properties
            this.Property(t => t.cityID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ctyName)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("GEO_Cities");
            this.Property(t => t.cityID).HasColumnName("cityID");
            this.Property(t => t.countyID).HasColumnName("countyID");
            this.Property(t => t.ctyName).HasColumnName("ctyName");

            // Relationships
            this.HasOptional(t => t.GEO_Counties)
                .WithMany(t => t.GEO_Cities)
                .HasForeignKey(d => d.countyID);

        }
    }
}
