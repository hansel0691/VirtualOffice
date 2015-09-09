using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_KitsbyOrderMap : EntityTypeConfiguration<POS_Inv_KitsbyOrder>
    {
        public POS_Inv_KitsbyOrderMap()
        {
            // Primary Key
            this.HasKey(t => new { t.OrderID, t.KitId });

            // Properties
            this.Property(t => t.OrderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.KitId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("POS_Inv_KitsbyOrder");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.KitId).HasColumnName("KitId");
            this.Property(t => t.okQuantity).HasColumnName("okQuantity");
            this.Property(t => t.okPrice).HasColumnName("okPrice");
            this.Property(t => t.okDiscount).HasColumnName("okDiscount");
            this.Property(t => t.okTax).HasColumnName("okTax");
            this.Property(t => t.measureID).HasColumnName("measureID");
            this.Property(t => t.okCost).HasColumnName("okCost");
        }
    }
}
