using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_KitsMap : EntityTypeConfiguration<POS_Inv_Kits>
    {
        public POS_Inv_KitsMap()
        {
            // Primary Key
            this.HasKey(t => t.KitID);

            // Properties
            this.Property(t => t.KitName)
                .HasMaxLength(250);

            this.Property(t => t.KitDescription)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Kits");
            this.Property(t => t.KitID).HasColumnName("KitID");
            this.Property(t => t.KitName).HasColumnName("KitName");
            this.Property(t => t.KitDescription).HasColumnName("KitDescription");
            this.Property(t => t.maxQtyShipFree).HasColumnName("maxQtyShipFree");
            this.Property(t => t.KitPrice).HasColumnName("KitPrice");
            this.Property(t => t.KitType).HasColumnName("KitType");
            this.Property(t => t.amount_measureID).HasColumnName("amount_measureID");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
