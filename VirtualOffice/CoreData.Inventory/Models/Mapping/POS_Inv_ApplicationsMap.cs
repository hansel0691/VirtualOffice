using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_ApplicationsMap : EntityTypeConfiguration<POS_Inv_Applications>
    {
        public POS_Inv_ApplicationsMap()
        {
            // Primary Key
            this.HasKey(t => t.applicationID);

            // Properties
            this.Property(t => t.apName)
                .HasMaxLength(50);

            this.Property(t => t.AppCode_F)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Applications");
            this.Property(t => t.applicationID).HasColumnName("applicationID");
            this.Property(t => t.apName).HasColumnName("apName");
            this.Property(t => t.AppCode_F).HasColumnName("AppCode_F");

            // Relationships
            this.HasMany(t => t.POS_Inv_Equipment)
                .WithMany(t => t.POS_Inv_Applications)
                .Map(m =>
                    {
                        m.ToTable("POS_Inv_EquipmentByApp");
                        m.MapLeftKey("applicationID");
                        m.MapRightKey("equipmentID");
                    });


        }
    }
}
