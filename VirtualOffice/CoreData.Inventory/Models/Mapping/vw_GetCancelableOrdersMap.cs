using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_GetCancelableOrdersMap : EntityTypeConfiguration<vw_GetCancelableOrders>
    {
        public vw_GetCancelableOrdersMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Code)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("vw_GetCancelableOrders");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Code).HasColumnName("Code");
        }
    }
}
