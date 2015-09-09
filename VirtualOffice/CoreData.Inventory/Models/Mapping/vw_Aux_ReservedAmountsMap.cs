using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_Aux_ReservedAmountsMap : EntityTypeConfiguration<vw_Aux_ReservedAmounts>
    {
        public vw_Aux_ReservedAmountsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.orderID, t.thingID });

            // Properties
            this.Property(t => t.orderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.thingID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.thDescription)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("vw_Aux_ReservedAmounts");
            this.Property(t => t.orderID).HasColumnName("orderID");
            this.Property(t => t.orType).HasColumnName("orType");
            this.Property(t => t.orStatus).HasColumnName("orStatus");
            this.Property(t => t.thingID).HasColumnName("thingID");
            this.Property(t => t.thDescription).HasColumnName("thDescription");
            this.Property(t => t.thReservedAmount).HasColumnName("thReservedAmount");
            this.Property(t => t.RealReserved).HasColumnName("RealReserved");
        }
    }
}
