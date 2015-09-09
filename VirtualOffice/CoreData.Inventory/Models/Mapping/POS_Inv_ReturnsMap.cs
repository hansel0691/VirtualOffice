using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_ReturnsMap : EntityTypeConfiguration<POS_Inv_Returns>
    {
        public POS_Inv_ReturnsMap()
        {
            // Primary Key
            this.HasKey(t => t.movementID);

            // Properties
            this.Property(t => t.movementID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Returns");
            this.Property(t => t.movementID).HasColumnName("movementID");
            this.Property(t => t.locationID).HasColumnName("locationID");
            this.Property(t => t.merchant_FK).HasColumnName("merchant_FK");

            // Relationships
            this.HasOptional(t => t.POS_Inv_Locations)
                .WithMany(t => t.POS_Inv_Returns)
                .HasForeignKey(d => d.locationID);
            this.HasRequired(t => t.POS_Inv_Movements)
                .WithOptional(t => t.POS_Inv_Returns);

        }
    }
}
