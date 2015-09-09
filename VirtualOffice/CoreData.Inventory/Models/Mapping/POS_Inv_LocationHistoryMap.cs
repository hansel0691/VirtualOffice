using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_LocationHistoryMap : EntityTypeConfiguration<POS_Inv_LocationHistory>
    {
        public POS_Inv_LocationHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.locationhistoryID);

            // Properties
            // Table & Column Mappings
            this.ToTable("POS_Inv_LocationHistory");
            this.Property(t => t.locationhistoryID).HasColumnName("locationhistoryID");
            this.Property(t => t.lhdate).HasColumnName("lhdate");
            this.Property(t => t.locationID).HasColumnName("locationID");

            // Relationships
            this.HasRequired(t => t.POS_Inv_Locations)
                .WithMany(t => t.POS_Inv_LocationHistory)
                .HasForeignKey(d => d.locationID);

        }
    }
}
