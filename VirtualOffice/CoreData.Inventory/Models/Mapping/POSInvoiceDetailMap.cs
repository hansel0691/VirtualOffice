using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POSInvoiceDetailMap : EntityTypeConfiguration<POSInvoiceDetail>
    {
        public POSInvoiceDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.det_id);

            // Properties
            this.Property(t => t.inv_car_name)
                .HasMaxLength(50);

            this.Property(t => t.product_sbt)
                .IsFixedLength()
                .HasMaxLength(6);

            this.Property(t => t.item_fk)
                .HasMaxLength(50);

            this.Property(t => t.pro_description)
                .HasMaxLength(100);

            this.Property(t => t.inv_TransactionType)
                .HasMaxLength(50);

            this.Property(t => t.inv_Cashier)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("POSInvoiceDetail");
            this.Property(t => t.det_id).HasColumnName("det_id");
            this.Property(t => t.inv_id).HasColumnName("inv_id");
            this.Property(t => t.inv_carrier_fk).HasColumnName("inv_carrier_fk");
            this.Property(t => t.inv_car_name).HasColumnName("inv_car_name");
            this.Property(t => t.inv_pin_fk).HasColumnName("inv_pin_fk");
            this.Property(t => t.inv_pin_controlno).HasColumnName("inv_pin_controlno");
            this.Property(t => t.inv_det_date).HasColumnName("inv_det_date");
            this.Property(t => t.product_sbt).HasColumnName("product_sbt");
            this.Property(t => t.item_fk).HasColumnName("item_fk");
            this.Property(t => t.pro_description).HasColumnName("pro_description");
            this.Property(t => t.terminal_fk).HasColumnName("terminal_fk");
            this.Property(t => t.trn_quantity).HasColumnName("trn_quantity");
            this.Property(t => t.pro_denomination).HasColumnName("pro_denomination");
            this.Property(t => t.inv_Discount).HasColumnName("inv_Discount");
            this.Property(t => t.inv_subtotal).HasColumnName("inv_subtotal");
            this.Property(t => t.inv_transaction_fk).HasColumnName("inv_transaction_fk");
            this.Property(t => t.inv_Product_Isforeign).HasColumnName("inv_Product_Isforeign");
            this.Property(t => t.inv_TransactionType).HasColumnName("inv_TransactionType");
            this.Property(t => t.inv_Cashier).HasColumnName("inv_Cashier");
            this.Property(t => t.AccountingId).HasColumnName("AccountingId");
            this.Property(t => t.ProductCost).HasColumnName("ProductCost");
            this.Property(t => t.AgentCommission).HasColumnName("AgentCommission");
            this.Property(t => t.MDistCommission).HasColumnName("MDistCommission");
            this.Property(t => t.DistCommission).HasColumnName("DistCommission");
            this.Property(t => t.AgentId).HasColumnName("AgentId");
            this.Property(t => t.MDistId).HasColumnName("MDistId");
            this.Property(t => t.DistId).HasColumnName("DistId");
            this.Property(t => t.CommissionPaidDate).HasColumnName("CommissionPaidDate");
            this.Property(t => t.ProcessedInDirectBilling).HasColumnName("ProcessedInDirectBilling");
        }
    }
}
