using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_CodeGenTestTableMap : EntityTypeConfiguration<POS_Inv_CodeGenTestTable>
    {
        public POS_Inv_CodeGenTestTableMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.code)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("POS_Inv_CodeGenTestTable");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.code).HasColumnName("code");
        }
    }
}
