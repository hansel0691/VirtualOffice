using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_ProvidersMap : EntityTypeConfiguration<POS_Inv_Providers>
    {
        public POS_Inv_ProvidersMap()
        {
            // Primary Key
            this.HasKey(t => t.providerID);

            // Properties
            this.Property(t => t.pdName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Providers");
            this.Property(t => t.providerID).HasColumnName("providerID");
            this.Property(t => t.pdName).HasColumnName("pdName");
        }
    }
}
