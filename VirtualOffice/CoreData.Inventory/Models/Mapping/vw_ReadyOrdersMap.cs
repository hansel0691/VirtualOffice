using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_ReadyOrdersMap : EntityTypeConfiguration<vw_ReadyOrders>
    {
        public vw_ReadyOrdersMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.Merchant });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Code)
                .HasMaxLength(20);

            this.Property(t => t.DeployMethod)
                .HasMaxLength(50);

            this.Property(t => t.Merchant)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Application)
                .HasMaxLength(50);

            this.Property(t => t.Incident_UserName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_ReadyOrders");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.QueuedDate).HasColumnName("QueuedDate");
            this.Property(t => t.Priority).HasColumnName("Priority");
            this.Property(t => t.OrderType).HasColumnName("OrderType");
            this.Property(t => t.Incident).HasColumnName("Incident");
            this.Property(t => t.DeployMethod).HasColumnName("DeployMethod");
            this.Property(t => t.Merchant).HasColumnName("Merchant");
            this.Property(t => t.Application).HasColumnName("Application");
            this.Property(t => t.TID).HasColumnName("TID");
            this.Property(t => t.Incident_UserName).HasColumnName("Incident_UserName");
        }
    }
}
