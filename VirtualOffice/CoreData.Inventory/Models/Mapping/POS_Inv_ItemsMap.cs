using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_ItemsMap : EntityTypeConfiguration<POS_Inv_Items>
    {
        public POS_Inv_ItemsMap()
        {
            // Primary Key
            this.HasKey(t => t.itemID);

            // Properties
            this.Property(t => t.itSerialNumber)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Items");
            this.Property(t => t.itemID).HasColumnName("itemID");
            this.Property(t => t.itSerialNumber).HasColumnName("itSerialNumber");
            this.Property(t => t.itInventoryDate).HasColumnName("itInventoryDate");
            this.Property(t => t.locationID).HasColumnName("locationID");
            this.Property(t => t.Merchant_FK).HasColumnName("Merchant_FK");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.itStatus).HasColumnName("itStatus");
            this.Property(t => t.itSoldDate).HasColumnName("itSoldDate");
            this.Property(t => t.itKind).HasColumnName("itKind");
            this.Property(t => t.itEmcrpypted).HasColumnName("itEmcrpypted");
            this.Property(t => t.rma).HasColumnName("rma");

            // Relationships
            this.HasOptional(t => t.POS_Inv_Locations)
                .WithMany(t => t.POS_Inv_Items)
                .HasForeignKey(d => d.locationID);

        }
    }
}
