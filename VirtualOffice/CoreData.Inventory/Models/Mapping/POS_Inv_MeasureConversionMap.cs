using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_MeasureConversionMap : EntityTypeConfiguration<POS_Inv_MeasureConversion>
    {
        public POS_Inv_MeasureConversionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Source_measureId, t.Target_MeasureId });

            // Properties
            this.Property(t => t.Source_measureId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Target_MeasureId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("POS_Inv_MeasureConversion");
            this.Property(t => t.Source_measureId).HasColumnName("Source_measureId");
            this.Property(t => t.Target_MeasureId).HasColumnName("Target_MeasureId");
            this.Property(t => t.ConversionFactor).HasColumnName("ConversionFactor");
        }
    }
}
