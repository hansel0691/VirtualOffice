using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_rpt_OrderItemsDetailsMap : EntityTypeConfiguration<vw_rpt_OrderItemsDetails>
    {
        public vw_rpt_OrderItemsDetailsMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderID);

            // Properties
            this.Property(t => t.OrderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EquipmentName)
                .HasMaxLength(50);

            this.Property(t => t.ItemSerialNumber)
                .HasMaxLength(20);

            this.Property(t => t.TerminalID)
                .HasMaxLength(12);

            // Table & Column Mappings
            this.ToTable("vw_rpt_OrderItemsDetails");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.EquipmentName).HasColumnName("EquipmentName");
            this.Property(t => t.ItemSerialNumber).HasColumnName("ItemSerialNumber");
            this.Property(t => t.TerminalID).HasColumnName("TerminalID");
        }
    }
}
