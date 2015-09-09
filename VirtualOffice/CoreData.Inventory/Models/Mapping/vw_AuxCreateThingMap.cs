using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_AuxCreateThingMap : EntityTypeConfiguration<vw_AuxCreateThing>
    {
        public vw_AuxCreateThingMap()
        {
            // Primary Key
            this.HasKey(t => t.SBTCode);

            // Properties
            this.Property(t => t.POSCode)
                .HasMaxLength(15);

            this.Property(t => t.Description)
                .HasMaxLength(100);

            this.Property(t => t.Item_FK)
                .HasMaxLength(50);

            this.Property(t => t.SBTCode)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(6);

            this.Property(t => t.UserName)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("vw_AuxCreateThing");
            this.Property(t => t.POSCode).HasColumnName("POSCode");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Amount_MeasureID).HasColumnName("Amount_MeasureID");
            this.Property(t => t.Weight_MeasureID).HasColumnName("Weight_MeasureID");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.Item_FK).HasColumnName("Item_FK");
            this.Property(t => t.SBTCode).HasColumnName("SBTCode");
            this.Property(t => t.UserName).HasColumnName("UserName");
        }
    }
}
