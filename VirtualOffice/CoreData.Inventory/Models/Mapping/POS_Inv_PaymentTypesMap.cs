using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_PaymentTypesMap : EntityTypeConfiguration<POS_Inv_PaymentTypes>
    {
        public POS_Inv_PaymentTypesMap()
        {
            // Primary Key
            this.HasKey(t => t.paymenttypeID);

            // Properties
            this.Property(t => t.paymenttypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ptDescription)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("POS_Inv_PaymentTypes");
            this.Property(t => t.paymenttypeID).HasColumnName("paymenttypeID");
            this.Property(t => t.ptDescription).HasColumnName("ptDescription");
            this.Property(t => t.ptType).HasColumnName("ptType");
        }
    }
}
