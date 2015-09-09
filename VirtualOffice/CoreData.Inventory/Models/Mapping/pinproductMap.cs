using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class pinproductMap : EntityTypeConfiguration<pinproduct>
    {
        public pinproductMap()
        {
            // Primary Key
            this.HasKey(t => t.product_sbt);

            // Properties
            this.Property(t => t.product_sbt)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(6);

            this.Property(t => t.item_fk)
                .HasMaxLength(50);

            this.Property(t => t.pro_productlineID)
                .HasMaxLength(20);

            this.Property(t => t.pro_productcode)
                .HasMaxLength(20);

            this.Property(t => t.pro_productname)
                .HasMaxLength(50);

            this.Property(t => t.pro_description)
                .HasMaxLength(50);

            this.Property(t => t.pro_customerphone)
                .HasMaxLength(20);

            this.Property(t => t.pro_expiretype)
                .HasMaxLength(50);

            this.Property(t => t.pro_useradder)
                .HasMaxLength(20);

            this.Property(t => t.pro_usereditor)
                .HasMaxLength(20);

            this.Property(t => t.instantpin)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.mailorder)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.Product_MainCode)
                .HasMaxLength(6);

            // Table & Column Mappings
            this.ToTable("pinproducts");
            this.Property(t => t.product_sbt).HasColumnName("product_sbt");
            this.Property(t => t.item_fk).HasColumnName("item_fk");
            this.Property(t => t.carrier_fk).HasColumnName("carrier_fk");
            this.Property(t => t.PosProductline_fk).HasColumnName("PosProductline_fk");
            this.Property(t => t.pro_productlineID).HasColumnName("pro_productlineID");
            this.Property(t => t.pro_productcode).HasColumnName("pro_productcode");
            this.Property(t => t.pro_productname).HasColumnName("pro_productname");
            this.Property(t => t.pro_description).HasColumnName("pro_description");
            this.Property(t => t.pro_denomination).HasColumnName("pro_denomination");
            this.Property(t => t.pro_customerphone).HasColumnName("pro_customerphone");
            this.Property(t => t.pro_expiretype).HasColumnName("pro_expiretype");
            this.Property(t => t.pro_expiredays).HasColumnName("pro_expiredays");
            this.Property(t => t.pro_timestamp).HasColumnName("pro_timestamp");
            this.Property(t => t.pro_useradder).HasColumnName("pro_useradder");
            this.Property(t => t.pro_dateadded).HasColumnName("pro_dateadded");
            this.Property(t => t.pro_usereditor).HasColumnName("pro_usereditor");
            this.Property(t => t.pro_dateeditor).HasColumnName("pro_dateeditor");
            this.Property(t => t.instantpin).HasColumnName("instantpin");
            this.Property(t => t.mailorder).HasColumnName("mailorder");
            this.Property(t => t.pos).HasColumnName("pos");
            this.Property(t => t.pos_reorder).HasColumnName("pos_reorder");
            this.Property(t => t.eCommerce).HasColumnName("eCommerce");
            this.Property(t => t.eComm_reorder).HasColumnName("eComm_reorder");
            this.Property(t => t.SalesAgentCommission).HasColumnName("SalesAgentCommission");
            this.Property(t => t.Isforeign).HasColumnName("Isforeign");
            this.Property(t => t.pmg_fk).HasColumnName("pmg_fk");
            this.Property(t => t.POSCategoryID).HasColumnName("POSCategoryID");
            this.Property(t => t.PosBillingCode).HasColumnName("PosBillingCode");
            this.Property(t => t.Product_MainCode).HasColumnName("Product_MainCode");
        }
    }
}
