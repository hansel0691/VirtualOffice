using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_PackageByOrderMap : EntityTypeConfiguration<POS_Inv_PackageByOrder>
    {
        public POS_Inv_PackageByOrderMap()
        {
            // Primary Key
            this.HasKey(t => new { t.orderID, t.packageID });

            // Properties
            this.Property(t => t.orderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.packageID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.product_sbt)
                .HasMaxLength(6);

            // Table & Column Mappings
            this.ToTable("POS_Inv_PackageByOrder");
            this.Property(t => t.orderID).HasColumnName("orderID");
            this.Property(t => t.packageID).HasColumnName("packageID");
            this.Property(t => t.opQuantity).HasColumnName("opQuantity");
            this.Property(t => t.opPrice).HasColumnName("opPrice");
            this.Property(t => t.opDiscount).HasColumnName("opDiscount");
            this.Property(t => t.opTax).HasColumnName("opTax");
            this.Property(t => t.measureID).HasColumnName("measureID");
            this.Property(t => t.opCost).HasColumnName("opCost");
            this.Property(t => t.product_sbt).HasColumnName("product_sbt");

            // Relationships
            this.HasOptional(t => t.POS_Inv_Measures)
                .WithMany(t => t.POS_Inv_PackageByOrder)
                .HasForeignKey(d => d.measureID);
            this.HasRequired(t => t.POS_Inv_Packages)
                .WithMany(t => t.POS_Inv_PackageByOrder)
                .HasForeignKey(d => d.packageID);

        }
    }
}
