using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_ThingsMap : EntityTypeConfiguration<vw_Things>
    {
        public vw_ThingsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Code)
                .HasMaxLength(15);

            this.Property(t => t.Description)
                .HasMaxLength(100);

            this.Property(t => t.Measure)
                .HasMaxLength(6);

            // Table & Column Mappings
            this.ToTable("vw_Things");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.StockAmount).HasColumnName("StockAmount");
            this.Property(t => t.ReservedAmount).HasColumnName("ReservedAmount");
            this.Property(t => t.MinimumAmount).HasColumnName("MinimumAmount");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Measure).HasColumnName("Measure");
        }
    }
}
