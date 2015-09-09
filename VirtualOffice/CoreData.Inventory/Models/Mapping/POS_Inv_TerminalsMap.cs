using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_TerminalsMap : EntityTypeConfiguration<POS_Inv_Terminals>
    {
        public POS_Inv_TerminalsMap()
        {
            // Primary Key
            this.HasKey(t => t.itemID);

            // Properties
            this.Property(t => t.itemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.tmID)
                .HasMaxLength(12);

            this.Property(t => t.tmHardwareRev)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Terminals");
            this.Property(t => t.itemID).HasColumnName("itemID");
            this.Property(t => t.tmID).HasColumnName("tmID");
            this.Property(t => t.tmHardwareRev).HasColumnName("tmHardwareRev");

            // Relationships
            this.HasRequired(t => t.POS_Inv_Items)
                .WithOptional(t => t.POS_Inv_Terminals);

        }
    }
}
