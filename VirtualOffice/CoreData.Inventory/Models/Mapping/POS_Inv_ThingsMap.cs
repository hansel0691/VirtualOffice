using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_ThingsMap : EntityTypeConfiguration<POS_Inv_Things>
    {
        public POS_Inv_ThingsMap()
        {
            // Primary Key
            this.HasKey(t => t.thingID);

            // Properties
            this.Property(t => t.thCode)
                .HasMaxLength(15);

            this.Property(t => t.thDescription)
                .HasMaxLength(100);

            this.Property(t => t.item_fk)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Things");
            this.Property(t => t.thingID).HasColumnName("thingID");
            this.Property(t => t.thCode).HasColumnName("thCode");
            this.Property(t => t.thDescription).HasColumnName("thDescription");
            this.Property(t => t.thStockAmount).HasColumnName("thStockAmount");
            this.Property(t => t.thReservedAmount).HasColumnName("thReservedAmount");
            this.Property(t => t.thMinimumAmount).HasColumnName("thMinimumAmount");
            this.Property(t => t.Amount_measureID).HasColumnName("Amount_measureID");
            this.Property(t => t.thCost).HasColumnName("thCost");
            this.Property(t => t.thPrice).HasColumnName("thPrice");
            this.Property(t => t.thStatus).HasColumnName("thStatus");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.Weight_measureID).HasColumnName("Weight_measureID");
            this.Property(t => t.Length).HasColumnName("Length");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Dimension_measureID).HasColumnName("Dimension_measureID");
            this.Property(t => t.item_fk).HasColumnName("item_fk");
            this.Property(t => t.thType).HasColumnName("thType");
            this.Property(t => t.thDiscount).HasColumnName("thDiscount");
            this.Property(t => t.thAgentComm).HasColumnName("thAgentComm");
            this.Property(t => t.thDistComm).HasColumnName("thDistComm");
            this.Property(t => t.thMDistComm).HasColumnName("thMDistComm");

            // Relationships
            this.HasOptional(t => t.POS_Inv_Measures)
                .WithMany(t => t.POS_Inv_Things)
                .HasForeignKey(d => d.Amount_measureID);
            this.HasOptional(t => t.POS_Inv_Measures1)
                .WithMany(t => t.POS_Inv_Things1)
                .HasForeignKey(d => d.Weight_measureID);
            this.HasOptional(t => t.POS_Inv_Measures2)
                .WithMany(t => t.POS_Inv_Things2)
                .HasForeignKey(d => d.Dimension_measureID);

        }
    }
}
