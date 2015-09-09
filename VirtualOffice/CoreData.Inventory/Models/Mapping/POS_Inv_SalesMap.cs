using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_SalesMap : EntityTypeConfiguration<POS_Inv_Sales>
    {
        public POS_Inv_SalesMap()
        {
            // Primary Key
            this.HasKey(t => t.movementID);

            // Properties
            this.Property(t => t.movementID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Sales");
            this.Property(t => t.movementID).HasColumnName("movementID");
            this.Property(t => t.locationID).HasColumnName("locationID");
            this.Property(t => t.merchantID).HasColumnName("merchantID");

            // Relationships
            this.HasOptional(t => t.POS_Inv_Locations)
                .WithMany(t => t.POS_Inv_Sales)
                .HasForeignKey(d => d.locationID);
            this.HasRequired(t => t.POS_Inv_Movements)
                .WithOptional(t => t.POS_Inv_Sales);

        }
    }
}
