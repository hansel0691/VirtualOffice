using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_PrintersMap : EntityTypeConfiguration<POS_Inv_Printers>
    {
        public POS_Inv_PrintersMap()
        {
            // Primary Key
            this.HasKey(t => t.itemID);

            // Properties
            this.Property(t => t.itemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.prHardwareRev)
                .HasMaxLength(12);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Printers");
            this.Property(t => t.itemID).HasColumnName("itemID");
            this.Property(t => t.prHardwareRev).HasColumnName("prHardwareRev");
            this.Property(t => t.prTerminalID).HasColumnName("prTerminalID");

            // Relationships
            this.HasRequired(t => t.POS_Inv_Items)
                .WithOptional(t => t.POS_Inv_Printers);
            this.HasOptional(t => t.POS_Inv_Items1)
                .WithMany(t => t.POS_Inv_Printers1)
                .HasForeignKey(d => d.prTerminalID);

        }
    }
}
