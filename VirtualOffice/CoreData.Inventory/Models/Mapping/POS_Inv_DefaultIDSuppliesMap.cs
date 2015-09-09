using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_DefaultIDSuppliesMap : EntityTypeConfiguration<POS_Inv_DefaultIDSupplies>
    {
        public POS_Inv_DefaultIDSuppliesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.applicationID, t.packageID });

            // Properties
            this.Property(t => t.applicationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.packageID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("POS_Inv_DefaultIDSupplies");
            this.Property(t => t.applicationID).HasColumnName("applicationID");
            this.Property(t => t.packageID).HasColumnName("packageID");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
        }
    }
}
