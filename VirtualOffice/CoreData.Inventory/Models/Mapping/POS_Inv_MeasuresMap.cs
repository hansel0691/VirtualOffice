using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_MeasuresMap : EntityTypeConfiguration<POS_Inv_Measures>
    {
        public POS_Inv_MeasuresMap()
        {
            // Primary Key
            this.HasKey(t => t.measureID);

            // Properties
            this.Property(t => t.measureID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.msName)
                .HasMaxLength(20);

            this.Property(t => t.msSymbol)
                .HasMaxLength(6);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Measures");
            this.Property(t => t.measureID).HasColumnName("measureID");
            this.Property(t => t.msName).HasColumnName("msName");
            this.Property(t => t.msSymbol).HasColumnName("msSymbol");
        }
    }
}
