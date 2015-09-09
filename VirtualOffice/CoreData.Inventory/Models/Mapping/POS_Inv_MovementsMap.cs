using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_MovementsMap : EntityTypeConfiguration<POS_Inv_Movements>
    {
        public POS_Inv_MovementsMap()
        {
            // Primary Key
            this.HasKey(t => t.movementID);

            // Properties
            // Table & Column Mappings
            this.ToTable("POS_Inv_Movements");
            this.Property(t => t.movementID).HasColumnName("movementID");
            this.Property(t => t.itemID).HasColumnName("itemID");
            this.Property(t => t.mvDate).HasColumnName("mvDate");
            this.Property(t => t.mvType).HasColumnName("mvType");
            this.Property(t => t.reasonID).HasColumnName("reasonID");
            this.Property(t => t.userID).HasColumnName("userID");
            this.Property(t => t.mvGroup).HasColumnName("mvGroup");

            // Relationships
            this.HasOptional(t => t.POS_Inv_Items)
                .WithMany(t => t.POS_Inv_Movements)
                .HasForeignKey(d => d.itemID);
            this.HasOptional(t => t.POS_Inv_Reasons)
                .WithMany(t => t.POS_Inv_Movements)
                .HasForeignKey(d => d.reasonID);

        }
    }
}
