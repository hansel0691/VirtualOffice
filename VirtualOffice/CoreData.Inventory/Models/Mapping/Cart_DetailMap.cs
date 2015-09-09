using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class Cart_DetailMap : EntityTypeConfiguration<Cart_Detail>
    {
        public Cart_DetailMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.thType)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.description)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.unit)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Cart_Detail");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.cart_id).HasColumnName("cart_id");
            this.Property(t => t.thType).HasColumnName("thType");
            this.Property(t => t.thingID).HasColumnName("thingID");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.qty).HasColumnName("qty");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.extended).HasColumnName("extended");
            this.Property(t => t.discount).HasColumnName("discount");
            this.Property(t => t.tax).HasColumnName("tax");
            this.Property(t => t.order_id).HasColumnName("order_id");
            this.Property(t => t.unit).HasColumnName("unit");
            this.Property(t => t.weight).HasColumnName("weight");
            this.Property(t => t.weight_measureID).HasColumnName("weight_measureID");
        }
    }
}
