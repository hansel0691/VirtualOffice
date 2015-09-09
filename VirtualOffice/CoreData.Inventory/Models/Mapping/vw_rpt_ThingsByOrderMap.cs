using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_rpt_ThingsByOrderMap : EntityTypeConfiguration<vw_rpt_ThingsByOrder>
    {
        public vw_rpt_ThingsByOrderMap()
        {
            // Primary Key
            this.HasKey(t => new { t.OrderID, t.ID });

            // Properties
            this.Property(t => t.OrderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Code)
                .HasMaxLength(15);

            this.Property(t => t.Description)
                .HasMaxLength(100);

            this.Property(t => t.Unit)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("vw_rpt_ThingsByOrder");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.Tax).HasColumnName("Tax");
            this.Property(t => t.Discoun).HasColumnName("Discoun");
        }
    }
}
