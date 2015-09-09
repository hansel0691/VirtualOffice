using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class GEO_StatesMap : EntityTypeConfiguration<GEO_States>
    {
        public GEO_StatesMap()
        {
            // Primary Key
            this.HasKey(t => t.stateID);

            // Properties
            this.Property(t => t.stateID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.stTwoLetters)
                .HasMaxLength(2);

            this.Property(t => t.stName)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("GEO_States");
            this.Property(t => t.stateID).HasColumnName("stateID");
            this.Property(t => t.stTwoLetters).HasColumnName("stTwoLetters");
            this.Property(t => t.stName).HasColumnName("stName");
        }
    }
}
