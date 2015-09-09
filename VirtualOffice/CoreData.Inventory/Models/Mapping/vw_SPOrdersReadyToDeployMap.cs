using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_SPOrdersReadyToDeployMap : EntityTypeConfiguration<vw_SPOrdersReadyToDeploy>
    {
        public vw_SPOrdersReadyToDeployMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderID);

            // Properties
            this.Property(t => t.Code)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("vw_SPOrdersReadyToDeploy");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.Code).HasColumnName("Code");
        }
    }
}
