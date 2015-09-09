using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_ThingsByProviderMap : EntityTypeConfiguration<POS_Inv_ThingsByProvider>
    {
        public POS_Inv_ThingsByProviderMap()
        {
            // Primary Key
            this.HasKey(t => new { t.providerID, t.thingID });

            // Properties
            this.Property(t => t.providerID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.thingID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("POS_Inv_ThingsByProvider");
            this.Property(t => t.providerID).HasColumnName("providerID");
            this.Property(t => t.thingID).HasColumnName("thingID");
            this.Property(t => t.ptLastPrice).HasColumnName("ptLastPrice");
            this.Property(t => t.ptLastPurchaseDate).HasColumnName("ptLastPurchaseDate");

            // Relationships
            this.HasRequired(t => t.POS_Inv_Providers)
                .WithMany(t => t.POS_Inv_ThingsByProvider)
                .HasForeignKey(d => d.providerID);
            this.HasRequired(t => t.POS_Inv_Things)
                .WithMany(t => t.POS_Inv_ThingsByProvider)
                .HasForeignKey(d => d.thingID);

        }
    }
}
