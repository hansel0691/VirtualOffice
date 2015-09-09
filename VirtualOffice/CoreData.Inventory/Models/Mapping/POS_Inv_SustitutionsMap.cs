using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_SustitutionsMap : EntityTypeConfiguration<POS_Inv_Sustitutions>
    {
        public POS_Inv_SustitutionsMap()
        {
            // Primary Key
            this.HasKey(t => t.movementID);

            // Properties
            this.Property(t => t.movementID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Sustitutions");
            this.Property(t => t.movementID).HasColumnName("movementID");
            this.Property(t => t.SourceLocID).HasColumnName("SourceLocID");
            this.Property(t => t.TargetMerchID).HasColumnName("TargetMerchID");

            // Relationships
            this.HasOptional(t => t.POS_Inv_Locations)
                .WithMany(t => t.POS_Inv_Sustitutions)
                .HasForeignKey(d => d.SourceLocID);
            this.HasRequired(t => t.POS_Inv_Movements)
                .WithOptional(t => t.POS_Inv_Sustitutions);

        }
    }
}
