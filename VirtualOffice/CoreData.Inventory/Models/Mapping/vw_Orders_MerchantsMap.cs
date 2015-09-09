using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_Orders_MerchantsMap : EntityTypeConfiguration<vw_Orders_Merchants>
    {
        public vw_Orders_MerchantsMap()
        {
            // Primary Key
            this.HasKey(t => t.orderID);

            // Properties
            this.Property(t => t.orderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.MerchantAndDate)
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("vw_Orders_Merchants");
            this.Property(t => t.orderID).HasColumnName("orderID");
            this.Property(t => t.MerchantAndDate).HasColumnName("MerchantAndDate");
        }
    }
}
