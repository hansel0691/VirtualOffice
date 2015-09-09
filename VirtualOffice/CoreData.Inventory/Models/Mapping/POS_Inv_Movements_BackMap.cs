using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_Movements_BackMap : EntityTypeConfiguration<POS_Inv_Movements_Back>
    {
        public POS_Inv_Movements_BackMap()
        {
            // Primary Key
            this.HasKey(t => t.movementID);

            // Properties
            // Table & Column Mappings
            this.ToTable("POS_Inv_Movements_Back");
            this.Property(t => t.movementID).HasColumnName("movementID");
            this.Property(t => t.itemID).HasColumnName("itemID");
            this.Property(t => t.mvDate).HasColumnName("mvDate");
            this.Property(t => t.mvType).HasColumnName("mvType");
            this.Property(t => t.reasonID).HasColumnName("reasonID");
            this.Property(t => t.userID).HasColumnName("userID");
            this.Property(t => t.mvGroup).HasColumnName("mvGroup");
        }
    }
}
