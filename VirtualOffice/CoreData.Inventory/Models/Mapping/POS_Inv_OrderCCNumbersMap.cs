using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_OrderCCNumbersMap : EntityTypeConfiguration<POS_Inv_OrderCCNumbers>
    {
        public POS_Inv_OrderCCNumbersMap()
        {
            // Primary Key
            this.HasKey(t => t.orderID);

            // Properties
            this.Property(t => t.orderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.cc_number)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("POS_Inv_OrderCCNumbers");
            this.Property(t => t.orderID).HasColumnName("orderID");
            this.Property(t => t.cc_number).HasColumnName("cc_number");
        }
    }
}
