using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_ThingsByOrderMap : EntityTypeConfiguration<POS_Inv_ThingsByOrder>
    {
        public POS_Inv_ThingsByOrderMap()
        {
            // Primary Key
            this.HasKey(t => new { t.orderID, t.thingID });

            // Properties
            this.Property(t => t.orderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.thingID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("POS_Inv_ThingsByOrder");
            this.Property(t => t.orderID).HasColumnName("orderID");
            this.Property(t => t.thingID).HasColumnName("thingID");
            this.Property(t => t.otQty).HasColumnName("otQty");
            this.Property(t => t.otPrice).HasColumnName("otPrice");
            this.Property(t => t.otDiscount).HasColumnName("otDiscount");
            this.Property(t => t.otTax).HasColumnName("otTax");
            this.Property(t => t.otUnit).HasColumnName("otUnit");

            // Relationships
            this.HasRequired(t => t.POS_Inv_Things)
                .WithMany(t => t.POS_Inv_ThingsByOrder)
                .HasForeignKey(d => d.thingID);

        }
    }
}
