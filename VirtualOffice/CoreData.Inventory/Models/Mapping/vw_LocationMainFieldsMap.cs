using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_LocationMainFieldsMap : EntityTypeConfiguration<vw_LocationMainFields>
    {
        public vw_LocationMainFieldsMap()
        {
            // Primary Key
            this.HasKey(t => t.locationID);

            // Properties
            this.Property(t => t.lcDescription)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_LocationMainFields");
            this.Property(t => t.locationID).HasColumnName("locationID");
            this.Property(t => t.lcDescription).HasColumnName("lcDescription");
        }
    }
}
