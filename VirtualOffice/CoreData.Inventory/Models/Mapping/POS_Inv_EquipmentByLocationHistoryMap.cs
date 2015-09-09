using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_EquipmentByLocationHistoryMap : EntityTypeConfiguration<POS_Inv_EquipmentByLocationHistory>
    {
        public POS_Inv_EquipmentByLocationHistoryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.locationhistoryID, t.equipmentID });

            // Properties
            this.Property(t => t.locationhistoryID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.equipmentID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("POS_Inv_EquipmentByLocationHistory");
            this.Property(t => t.locationhistoryID).HasColumnName("locationhistoryID");
            this.Property(t => t.equipmentID).HasColumnName("equipmentID");
            this.Property(t => t.leAmount).HasColumnName("leAmount");

            // Relationships
            this.HasRequired(t => t.POS_Inv_Equipment)
                .WithMany(t => t.POS_Inv_EquipmentByLocationHistory)
                .HasForeignKey(d => d.equipmentID);
            this.HasRequired(t => t.POS_Inv_LocationHistory)
                .WithMany(t => t.POS_Inv_EquipmentByLocationHistory)
                .HasForeignKey(d => d.locationhistoryID);

        }
    }
}
