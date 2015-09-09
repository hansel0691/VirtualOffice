using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_CodesMap : EntityTypeConfiguration<POS_Inv_Codes>
    {
        public POS_Inv_CodesMap()
        {
            // Primary Key
            this.HasKey(t => t.codeID);

            // Properties
            this.Property(t => t.codeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.cdDescription)
                .HasMaxLength(50);

            this.Property(t => t.cdFormat)
                .HasMaxLength(50);

            this.Property(t => t.cdLastLexema)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Codes");
            this.Property(t => t.codeID).HasColumnName("codeID");
            this.Property(t => t.cdDescription).HasColumnName("cdDescription");
            this.Property(t => t.cdFormat).HasColumnName("cdFormat");
            this.Property(t => t.cdLastLexema).HasColumnName("cdLastLexema");
            this.Property(t => t.cdCount).HasColumnName("cdCount");
            this.Property(t => t.cdCounterLen).HasColumnName("cdCounterLen");
        }
    }
}
