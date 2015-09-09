using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_ReasonsMap : EntityTypeConfiguration<POS_Inv_Reasons>
    {
        public POS_Inv_ReasonsMap()
        {
            // Primary Key
            this.HasKey(t => t.reasonID);

            // Properties
            this.Property(t => t.reasonID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Reason)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Reasons");
            this.Property(t => t.reasonID).HasColumnName("reasonID");
            this.Property(t => t.Reason).HasColumnName("Reason");
        }
    }
}
