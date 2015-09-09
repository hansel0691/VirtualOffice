using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_PurchasesMap : EntityTypeConfiguration<POS_Inv_Purchases>
    {
        public POS_Inv_PurchasesMap()
        {
            // Primary Key
            this.HasKey(t => t.purchaseID);

            // Properties
            // Table & Column Mappings
            this.ToTable("POS_Inv_Purchases");
            this.Property(t => t.purchaseID).HasColumnName("purchaseID");
            this.Property(t => t.thingID).HasColumnName("thingID");
            this.Property(t => t.providerID).HasColumnName("providerID");
            this.Property(t => t.userID).HasColumnName("userID");
            this.Property(t => t.psAmount).HasColumnName("psAmount");
            this.Property(t => t.psCost).HasColumnName("psCost");
            this.Property(t => t.psDate).HasColumnName("psDate");

            // Relationships
            this.HasOptional(t => t.POS_Inv_Providers)
                .WithMany(t => t.POS_Inv_Purchases)
                .HasForeignKey(d => d.providerID);
            this.HasOptional(t => t.POS_Inv_Things)
                .WithMany(t => t.POS_Inv_Purchases)
                .HasForeignKey(d => d.thingID);

        }
    }
}
