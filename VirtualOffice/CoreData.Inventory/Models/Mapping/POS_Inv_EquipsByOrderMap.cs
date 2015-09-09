using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_EquipsByOrderMap : EntityTypeConfiguration<POS_Inv_EquipsByOrder>
    {
        public POS_Inv_EquipsByOrderMap()
        {
            // Primary Key
            this.HasKey(t => t.equipsbyorderID);

            // Properties
            this.Property(t => t.TerminalID)
                .HasMaxLength(12);

            // Table & Column Mappings
            this.ToTable("POS_Inv_EquipsByOrder");
            this.Property(t => t.equipsbyorderID).HasColumnName("equipsbyorderID");
            this.Property(t => t.orderID).HasColumnName("orderID");
            this.Property(t => t.equipmentID).HasColumnName("equipmentID");
            this.Property(t => t.itemID).HasColumnName("itemID");
            this.Property(t => t.TerminalID).HasColumnName("TerminalID");
            this.Property(t => t.oeCost).HasColumnName("oeCost");
            this.Property(t => t.oePrice).HasColumnName("oePrice");

            // Relationships
            this.HasRequired(t => t.POS_Inv_Equipment)
                .WithMany(t => t.POS_Inv_EquipsByOrder)
                .HasForeignKey(d => d.equipmentID);
            this.HasOptional(t => t.POS_Inv_Items)
                .WithMany(t => t.POS_Inv_EquipsByOrder)
                .HasForeignKey(d => d.itemID);

        }
    }
}
