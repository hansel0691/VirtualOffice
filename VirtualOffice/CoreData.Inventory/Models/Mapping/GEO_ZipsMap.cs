using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class GEO_ZipsMap : EntityTypeConfiguration<GEO_Zips>
    {
        public GEO_ZipsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.cityID, t.ZipCode });

            // Properties
            this.Property(t => t.cityID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ZipCode)
                .IsRequired()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("GEO_Zips");
            this.Property(t => t.cityID).HasColumnName("cityID");
            this.Property(t => t.ZipCode).HasColumnName("ZipCode");

            // Relationships
            this.HasRequired(t => t.GEO_Cities)
                .WithMany(t => t.GEO_Zips)
                .HasForeignKey(d => d.cityID);

        }
    }
}
