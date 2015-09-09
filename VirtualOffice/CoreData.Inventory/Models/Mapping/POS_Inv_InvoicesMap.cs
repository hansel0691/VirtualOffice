using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_InvoicesMap : EntityTypeConfiguration<POS_Inv_Invoices>
    {
        public POS_Inv_InvoicesMap()
        {
            // Primary Key
            this.HasKey(t => t.invoiceID);

            // Properties
            // Table & Column Mappings
            this.ToTable("POS_Inv_Invoices");
            this.Property(t => t.invoiceID).HasColumnName("invoiceID");
            this.Property(t => t.merchant_FK).HasColumnName("merchant_FK");
            this.Property(t => t.ivDate).HasColumnName("ivDate");
            this.Property(t => t.ivStatus).HasColumnName("ivStatus");
            this.Property(t => t.ivType).HasColumnName("ivType");
            this.Property(t => t.orderID).HasColumnName("orderID");
            this.Property(t => t.userID).HasColumnName("userID");
            this.Property(t => t.old_id).HasColumnName("old_id");

            // Relationships
            this.HasOptional(t => t.POS_Inv_Orders1)
                .WithMany(t => t.POS_Inv_Invoices)
                .HasForeignKey(d => d.orderID);

        }
    }
}
