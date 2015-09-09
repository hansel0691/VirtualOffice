using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_MovementGroupCountersMap : EntityTypeConfiguration<POS_Inv_MovementGroupCounters>
    {
        public POS_Inv_MovementGroupCountersMap()
        {
            // Primary Key
            this.HasKey(t => t.mov_Type);

            // Properties
            this.Property(t => t.mov_Type)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("POS_Inv_MovementGroupCounters");
            this.Property(t => t.mov_Type).HasColumnName("mov_Type");
            this.Property(t => t.mov_NextGroupID).HasColumnName("mov_NextGroupID");
        }
    }
}
