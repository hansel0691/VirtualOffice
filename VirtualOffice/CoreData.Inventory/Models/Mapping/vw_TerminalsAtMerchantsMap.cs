using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_TerminalsAtMerchantsMap : EntityTypeConfiguration<vw_TerminalsAtMerchants>
    {
        public vw_TerminalsAtMerchantsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.MID, t.LocMerch });

            // Properties
            this.Property(t => t.SerialNumber)
                .HasMaxLength(20);

            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.HardwareRev)
                .HasMaxLength(15);

            this.Property(t => t.TerminalID)
                .HasMaxLength(12);

            this.Property(t => t.MID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LocMerch)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_TerminalsAtMerchants");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.InventoryDate).HasColumnName("InventoryDate");
            this.Property(t => t.SoldDate).HasColumnName("SoldDate");
            this.Property(t => t.HardwareRev).HasColumnName("HardwareRev");
            this.Property(t => t.TerminalID).HasColumnName("TerminalID");
            this.Property(t => t.MID).HasColumnName("MID");
            this.Property(t => t.LocMerch).HasColumnName("LocMerch");
        }
    }
}
