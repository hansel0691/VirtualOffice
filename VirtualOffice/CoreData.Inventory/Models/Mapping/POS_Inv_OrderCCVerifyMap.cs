using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_OrderCCVerifyMap : EntityTypeConfiguration<POS_Inv_OrderCCVerify>
    {
        public POS_Inv_OrderCCVerifyMap()
        {
            // Primary Key
            this.HasKey(t => t.orderID);

            // Properties
            this.Property(t => t.orderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.cc_cvv2)
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("POS_Inv_OrderCCVerify");
            this.Property(t => t.orderID).HasColumnName("orderID");
            this.Property(t => t.cc_cvv2).HasColumnName("cc_cvv2");
        }
    }
}
