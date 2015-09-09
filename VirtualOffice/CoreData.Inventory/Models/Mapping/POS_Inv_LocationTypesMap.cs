using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_LocationTypesMap : EntityTypeConfiguration<POS_Inv_LocationTypes>
    {
        public POS_Inv_LocationTypesMap()
        {
            // Primary Key
            this.HasKey(t => t.locationtypeID);

            // Properties
            this.Property(t => t.ltDescription)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("POS_Inv_LocationTypes");
            this.Property(t => t.locationtypeID).HasColumnName("locationtypeID");
            this.Property(t => t.ltDescription).HasColumnName("ltDescription");
            this.Property(t => t.ltLocGroup).HasColumnName("ltLocGroup");
        }
    }
}
