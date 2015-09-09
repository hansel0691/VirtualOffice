using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_TypesMap : EntityTypeConfiguration<POS_Inv_Types>
    {
        public POS_Inv_TypesMap()
        {
            // Primary Key
            this.HasKey(t => t.typeID);

            // Properties
            this.Property(t => t.typCategory)
                .HasMaxLength(50);

            this.Property(t => t.typDescription)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Types");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.typCategory).HasColumnName("typCategory");
            this.Property(t => t.typDescription).HasColumnName("typDescription");
            this.Property(t => t.typValue).HasColumnName("typValue");
        }
    }
}
