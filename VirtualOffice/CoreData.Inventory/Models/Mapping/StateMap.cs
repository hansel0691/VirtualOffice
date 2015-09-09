using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class StateMap : EntityTypeConfiguration<State>
    {
        public StateMap()
        {
            // Primary Key
            this.HasKey(t => t.short_name);

            // Properties
            this.Property(t => t.short_name)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.long_name)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("States");
            this.Property(t => t.short_name).HasColumnName("short_name");
            this.Property(t => t.long_name).HasColumnName("long_name");
        }
    }
}
