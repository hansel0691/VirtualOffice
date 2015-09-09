using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_ReasonsMap : EntityTypeConfiguration<vw_Reasons>
    {
        public vw_ReasonsMap()
        {
            // Primary Key
            this.HasKey(t => t.reasonID);

            // Properties
            this.Property(t => t.reasonID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Reason)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_Reasons");
            this.Property(t => t.reasonID).HasColumnName("reasonID");
            this.Property(t => t.Reason).HasColumnName("Reason");
        }
    }
}
