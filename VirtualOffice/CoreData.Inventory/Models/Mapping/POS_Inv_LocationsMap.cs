using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_LocationsMap : EntityTypeConfiguration<POS_Inv_Locations>
    {
        public POS_Inv_LocationsMap()
        {
            // Primary Key
            this.HasKey(t => t.locationID);

            // Properties
            this.Property(t => t.lcDescription)
                .HasMaxLength(50);

            this.Property(t => t.lcAddressFirstLine)
                .HasMaxLength(50);

            this.Property(t => t.lcAddressSecondLine)
                .HasMaxLength(50);

            this.Property(t => t.lcCity)
                .HasMaxLength(20);

            this.Property(t => t.lcState)
                .HasMaxLength(30);

            this.Property(t => t.lcZip)
                .HasMaxLength(10);

            this.Property(t => t.lcPhone)
                .HasMaxLength(16);

            this.Property(t => t.lcFax)
                .HasMaxLength(16);

            this.Property(t => t.lcContact)
                .HasMaxLength(50);

            this.Property(t => t.lcEMail)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Locations");
            this.Property(t => t.locationID).HasColumnName("locationID");
            this.Property(t => t.lcDescription).HasColumnName("lcDescription");
            this.Property(t => t.lcAddressFirstLine).HasColumnName("lcAddressFirstLine");
            this.Property(t => t.lcAddressSecondLine).HasColumnName("lcAddressSecondLine");
            this.Property(t => t.lcCity).HasColumnName("lcCity");
            this.Property(t => t.lcState).HasColumnName("lcState");
            this.Property(t => t.lcZip).HasColumnName("lcZip");
            this.Property(t => t.lcPhone).HasColumnName("lcPhone");
            this.Property(t => t.lcFax).HasColumnName("lcFax");
            this.Property(t => t.lcContact).HasColumnName("lcContact");
            this.Property(t => t.lcEMail).HasColumnName("lcEMail");
            this.Property(t => t.lcType).HasColumnName("lcType");
            this.Property(t => t.lcStatus).HasColumnName("lcStatus");
        }
    }
}
