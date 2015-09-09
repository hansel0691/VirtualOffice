using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_AllProcessedOrdersMap : EntityTypeConfiguration<vw_AllProcessedOrders>
    {
        public vw_AllProcessedOrdersMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderID);

            // Properties
            this.Property(t => t.Code)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("vw_AllProcessedOrders");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.Code).HasColumnName("Code");
        }
    }
}
