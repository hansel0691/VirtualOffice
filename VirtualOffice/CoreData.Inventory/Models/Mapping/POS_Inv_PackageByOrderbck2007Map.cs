using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_PackageByOrderbck2007Map : EntityTypeConfiguration<POS_Inv_PackageByOrderbck2007>
    {
        public POS_Inv_PackageByOrderbck2007Map()
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
            this.ToTable("POS_Inv_PackageByOrderbck2007");
            this.Property(t => t.orderID).HasColumnName("orderID");
            this.Property(t => t.packageID).HasColumnName("packageID");
            this.Property(t => t.opQuantity).HasColumnName("opQuantity");
            this.Property(t => t.opPrice).HasColumnName("opPrice");
            this.Property(t => t.opDiscount).HasColumnName("opDiscount");
            this.Property(t => t.opTax).HasColumnName("opTax");
            this.Property(t => t.measureID).HasColumnName("measureID");
            this.Property(t => t.opCost).HasColumnName("opCost");
            this.Property(t => t.product_sbt).HasColumnName("product_sbt");
        }
    }
}
