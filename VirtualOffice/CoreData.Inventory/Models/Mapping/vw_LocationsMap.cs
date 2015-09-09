using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_LocationsMap : EntityTypeConfiguration<vw_Locations>
    {
        public vw_LocationsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.AddressLine1)
                .HasMaxLength(50);

            this.Property(t => t.AddressLine2)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(20);

            this.Property(t => t.State)
                .HasMaxLength(30);

            this.Property(t => t.Zip)
                .HasMaxLength(10);

            this.Property(t => t.LocationType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_Locations");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.AddressLine1).HasColumnName("AddressLine1");
            this.Property(t => t.AddressLine2).HasColumnName("AddressLine2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.LocationType).HasColumnName("LocationType");
        }
    }
}
