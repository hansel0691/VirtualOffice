using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_UsersMap : EntityTypeConfiguration<POS_Inv_Users>
    {
        public POS_Inv_UsersMap()
        {
            // Primary Key
            this.HasKey(t => t.userID);

            // Properties
            this.Property(t => t.userID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.usFirstName)
                .HasMaxLength(40);

            this.Property(t => t.usLastName)
                .HasMaxLength(30);

            this.Property(t => t.usNick)
                .HasMaxLength(15);

            this.Property(t => t.usCreatedBy)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Users");
            this.Property(t => t.userID).HasColumnName("userID");
            this.Property(t => t.usFirstName).HasColumnName("usFirstName");
            this.Property(t => t.usLastName).HasColumnName("usLastName");
            this.Property(t => t.usNick).HasColumnName("usNick");
            this.Property(t => t.usCreatedBy).HasColumnName("usCreatedBy");
            this.Property(t => t.usPrivilege).HasColumnName("usPrivilege");
        }
    }
}
