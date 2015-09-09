using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_PackagesMap : EntityTypeConfiguration<POS_Inv_Packages>
    {
        public POS_Inv_PackagesMap()
        {
            // Primary Key
            this.HasKey(t => t.packageID);

            // Properties
            this.Property(t => t.pkDescription)
                .HasMaxLength(50);

            this.Property(t => t.product_sbt)
                .HasMaxLength(6);

            this.Property(t => t.filename)
                .HasMaxLength(50);

            this.Property(t => t.lastupload_by)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Packages");
            this.Property(t => t.packageID).HasColumnName("packageID");
            this.Property(t => t.thingID).HasColumnName("thingID");
            this.Property(t => t.pkQuantity).HasColumnName("pkQuantity");
            this.Property(t => t.pkDescription).HasColumnName("pkDescription");
            this.Property(t => t.maxQtyShipFree).HasColumnName("maxQtyShipFree");
            this.Property(t => t.pkPrice).HasColumnName("pkPrice");
            this.Property(t => t.pkType).HasColumnName("pkType");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.sort_asc).HasColumnName("sort_asc");
            this.Property(t => t.prd_showrma).HasColumnName("prd_showrma");
            this.Property(t => t.rma_replaceable).HasColumnName("rma_replaceable");
            this.Property(t => t.dist_discount).HasColumnName("dist_discount");
            this.Property(t => t.product_sbt).HasColumnName("product_sbt");
            this.Property(t => t.filename).HasColumnName("filename");
            this.Property(t => t.lastupload_by).HasColumnName("lastupload_by");
            this.Property(t => t.lastupload_date).HasColumnName("lastupload_date");
        }
    }
}
