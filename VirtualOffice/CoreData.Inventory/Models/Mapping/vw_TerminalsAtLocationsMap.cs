using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_TerminalsAtLocationsMap : EntityTypeConfiguration<vw_TerminalsAtLocations>
    {
        public vw_TerminalsAtLocationsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.SerialNumber)
                .HasMaxLength(20);

            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.HardwareRev)
                .HasMaxLength(15);

            this.Property(t => t.TerminalID)
                .HasMaxLength(12);

            this.Property(t => t.LocMerch)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_TerminalsAtLocations");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.InventoryDate).HasColumnName("InventoryDate");
            this.Property(t => t.SoldDate).HasColumnName("SoldDate");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.HardwareRev).HasColumnName("HardwareRev");
            this.Property(t => t.TerminalID).HasColumnName("TerminalID");
            this.Property(t => t.LocMerch).HasColumnName("LocMerch");
        }
    }
}
