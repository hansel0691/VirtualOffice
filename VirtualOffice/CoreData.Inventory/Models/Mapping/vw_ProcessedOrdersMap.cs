using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_ProcessedOrdersMap : EntityTypeConfiguration<vw_ProcessedOrders>
    {
        public vw_ProcessedOrdersMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.Merchant });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Code)
                .HasMaxLength(20);

            this.Property(t => t.TrackingNumber)
                .HasMaxLength(20);

            this.Property(t => t.DeployMethod)
                .HasMaxLength(50);

            this.Property(t => t.Merchant)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_ProcessedOrders");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.QueuedDate).HasColumnName("QueuedDate");
            this.Property(t => t.ProcessedDate).HasColumnName("ProcessedDate");
            this.Property(t => t.OrderType).HasColumnName("OrderType");
            this.Property(t => t.Incident).HasColumnName("Incident");
            this.Property(t => t.TrackingNumber).HasColumnName("TrackingNumber");
            this.Property(t => t.DeployMethod).HasColumnName("DeployMethod");
            this.Property(t => t.Merchant).HasColumnName("Merchant");
        }
    }
}
