using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_TransferencesMap : EntityTypeConfiguration<POS_Inv_Transferences>
    {
        public POS_Inv_TransferencesMap()
        {
            // Primary Key
            this.HasKey(t => t.movementID);

            // Properties
            this.Property(t => t.movementID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Transferences");
            this.Property(t => t.movementID).HasColumnName("movementID");
            this.Property(t => t.SourceMerchID).HasColumnName("SourceMerchID");
            this.Property(t => t.TargetMerchID).HasColumnName("TargetMerchID");

            // Relationships
            this.HasRequired(t => t.POS_Inv_Movements)
                .WithOptional(t => t.POS_Inv_Transferences);

        }
    }
}
