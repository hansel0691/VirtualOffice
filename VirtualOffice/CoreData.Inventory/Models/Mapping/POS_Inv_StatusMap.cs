using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_StatusMap : EntityTypeConfiguration<POS_Inv_Status>
    {
        public POS_Inv_StatusMap()
        {
            // Primary Key
            this.HasKey(t => t.statusID);

            // Properties
            this.Property(t => t.staCategory)
                .HasMaxLength(50);

            this.Property(t => t.staDescription)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Status");
            this.Property(t => t.statusID).HasColumnName("statusID");
            this.Property(t => t.staCategory).HasColumnName("staCategory");
            this.Property(t => t.staDescription).HasColumnName("staDescription");
            this.Property(t => t.staValue).HasColumnName("staValue");
        }
    }
}
