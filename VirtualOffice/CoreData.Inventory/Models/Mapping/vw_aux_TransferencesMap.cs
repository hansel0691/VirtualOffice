using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_aux_TransferencesMap : EntityTypeConfiguration<vw_aux_Transferences>
    {
        public vw_aux_TransferencesMap()
        {
            // Primary Key
            this.HasKey(t => t.Move);

            // Properties
            this.Property(t => t.Move)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SerialNumber)
                .HasMaxLength(20);

            this.Property(t => t.Reason)
                .HasMaxLength(50);

            this.Property(t => t.UserNick)
                .HasMaxLength(15);

            this.Property(t => t.Source)
                .HasMaxLength(50);

            this.Property(t => t.Target)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_aux_Transferences");
            this.Property(t => t.Move).HasColumnName("Move");
            this.Property(t => t.Item).HasColumnName("Item");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.MoveDate).HasColumnName("MoveDate");
            this.Property(t => t.MoveType).HasColumnName("MoveType");
            this.Property(t => t.Reason).HasColumnName("Reason");
            this.Property(t => t.UserNick).HasColumnName("UserNick");
            this.Property(t => t.Source).HasColumnName("Source");
            this.Property(t => t.Target).HasColumnName("Target");
        }
    }
}
