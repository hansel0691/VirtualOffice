using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_ThingsbyKitMap : EntityTypeConfiguration<POS_Inv_ThingsbyKit>
    {
        public POS_Inv_ThingsbyKitMap()
        {
            // Primary Key
            this.HasKey(t => new { t.KitID, t.thingID });

            // Properties
            this.Property(t => t.KitID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.thingID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("POS_Inv_ThingsbyKit");
            this.Property(t => t.KitID).HasColumnName("KitID");
            this.Property(t => t.thingID).HasColumnName("thingID");
            this.Property(t => t.tkQuantity).HasColumnName("tkQuantity");
        }
    }
}
