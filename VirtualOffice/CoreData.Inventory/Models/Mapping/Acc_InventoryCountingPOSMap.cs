using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class Acc_InventoryCountingPOSMap : EntityTypeConfiguration<Acc_InventoryCountingPOS>
    {
        public Acc_InventoryCountingPOSMap()
        {
            // Primary Key
            this.HasKey(t => t.cnt_id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Acc_InventoryCountingPOS");
            this.Property(t => t.cnt_id).HasColumnName("cnt_id");
            this.Property(t => t.cnt_locationid).HasColumnName("cnt_locationid");
            this.Property(t => t.cnt_productid).HasColumnName("cnt_productid");
            this.Property(t => t.cnt_date).HasColumnName("cnt_date");
            this.Property(t => t.cnt_week).HasColumnName("cnt_week");
            this.Property(t => t.cnt_year).HasColumnName("cnt_year");
            this.Property(t => t.cnt_qty_system).HasColumnName("cnt_qty_system");
            this.Property(t => t.cnt_qty_counted).HasColumnName("cnt_qty_counted");
            this.Property(t => t.cnt_timestamp).HasColumnName("cnt_timestamp");
            this.Property(t => t.cnt_usrid).HasColumnName("cnt_usrid");
        }
    }
}
