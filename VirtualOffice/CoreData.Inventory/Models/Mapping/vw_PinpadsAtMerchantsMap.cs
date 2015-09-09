using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_PinpadsAtMerchantsMap : EntityTypeConfiguration<vw_PinpadsAtMerchants>
    {
        public vw_PinpadsAtMerchantsMap()
        {
            // Primary Key
            this.HasKey(t => t.itemID);

            // Properties
            this.Property(t => t.itemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SerialNumber)
                .HasMaxLength(20);

            this.Property(t => t.HardwareRev)
                .HasMaxLength(12);

            this.Property(t => t.AssociatedTerminal)
                .HasMaxLength(20);

            this.Property(t => t.LocMerch)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_PinpadsAtMerchants");
            this.Property(t => t.itemID).HasColumnName("itemID");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.InventoryDate).HasColumnName("InventoryDate");
            this.Property(t => t.SoldDate).HasColumnName("SoldDate");
            this.Property(t => t.HardwareRev).HasColumnName("HardwareRev");
            this.Property(t => t.AssociatedTerminal).HasColumnName("AssociatedTerminal");
            this.Property(t => t.LocMerch).HasColumnName("LocMerch");
        }
    }
}
