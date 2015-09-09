using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_EntriesMap : EntityTypeConfiguration<POS_Inv_Entries>
    {
        public POS_Inv_EntriesMap()
        {
            // Primary Key
            this.HasKey(t => t.movementID);

            // Properties
            this.Property(t => t.movementID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Entries");
            this.Property(t => t.movementID).HasColumnName("movementID");
            this.Property(t => t.TargetLocID).HasColumnName("TargetLocID");

            // Relationships
            this.HasOptional(t => t.POS_Inv_Locations)
                .WithMany(t => t.POS_Inv_Entries)
                .HasForeignKey(d => d.TargetLocID);
            this.HasRequired(t => t.POS_Inv_Movements)
                .WithOptional(t => t.POS_Inv_Entries);

        }
    }
}
