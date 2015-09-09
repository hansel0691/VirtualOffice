using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_ReplacementsMap : EntityTypeConfiguration<POS_Inv_Replacements>
    {
        public POS_Inv_ReplacementsMap()
        {
            // Primary Key
            this.HasKey(t => t.movementID);

            // Properties
            this.Property(t => t.movementID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Replacements");
            this.Property(t => t.movementID).HasColumnName("movementID");
            this.Property(t => t.repItemID).HasColumnName("repItemID");
            this.Property(t => t.merchantID).HasColumnName("merchantID");
            this.Property(t => t.TargetLocID).HasColumnName("TargetLocID");

            // Relationships
            this.HasOptional(t => t.POS_Inv_Items)
                .WithMany(t => t.POS_Inv_Replacements)
                .HasForeignKey(d => d.repItemID);
            this.HasOptional(t => t.POS_Inv_Locations)
                .WithMany(t => t.POS_Inv_Replacements)
                .HasForeignKey(d => d.TargetLocID);
            this.HasRequired(t => t.POS_Inv_Movements)
                .WithOptional(t => t.POS_Inv_Replacements);

        }
    }
}
