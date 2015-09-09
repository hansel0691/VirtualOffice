using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_PartsMap : EntityTypeConfiguration<POS_Inv_Parts>
    {
        public POS_Inv_PartsMap()
        {
            // Primary Key
            this.HasKey(t => t.partID);

            // Properties
            this.Property(t => t.partID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ptDescription)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Parts");
            this.Property(t => t.partID).HasColumnName("partID");
            this.Property(t => t.ptDescription).HasColumnName("ptDescription");
            this.Property(t => t.equipmentID).HasColumnName("equipmentID");

            // Relationships
            this.HasOptional(t => t.POS_Inv_Equipment)
                .WithMany(t => t.POS_Inv_Parts)
                .HasForeignKey(d => d.equipmentID);

        }
    }
}
