using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_EquipmentMap : EntityTypeConfiguration<POS_Inv_Equipment>
    {
        public POS_Inv_EquipmentMap()
        {
            // Primary Key
            this.HasKey(t => t.equipmentID);

            // Properties
            this.Property(t => t.equipmentID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.eqName)
                .HasMaxLength(50);

            this.Property(t => t.Item_FK)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Equipment");
            this.Property(t => t.equipmentID).HasColumnName("equipmentID");
            this.Property(t => t.eqName).HasColumnName("eqName");
            this.Property(t => t.eqKind).HasColumnName("eqKind");
            this.Property(t => t.eqSerialNumLen).HasColumnName("eqSerialNumLen");
            this.Property(t => t.eqLeadingZeroes).HasColumnName("eqLeadingZeroes");
            this.Property(t => t.eqWeight).HasColumnName("eqWeight");
            this.Property(t => t.eqCost).HasColumnName("eqCost");
            this.Property(t => t.eqPrice).HasColumnName("eqPrice");
            this.Property(t => t.Item_FK).HasColumnName("Item_FK");
            this.Property(t => t.eqSerialNumberHasLetters).HasColumnName("eqSerialNumberHasLetters");
        }
    }
}
