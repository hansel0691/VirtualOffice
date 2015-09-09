using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_DeployMethodsMap : EntityTypeConfiguration<POS_Inv_DeployMethods>
    {
        public POS_Inv_DeployMethodsMap()
        {
            // Primary Key
            this.HasKey(t => t.deploymethID);

            // Properties
            this.Property(t => t.deploymethID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dmDescription)
                .HasMaxLength(50);

            this.Property(t => t.dmFedexCode)
                .HasMaxLength(3);

            this.Property(t => t.dmTransitTime)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("POS_Inv_DeployMethods");
            this.Property(t => t.deploymethID).HasColumnName("deploymethID");
            this.Property(t => t.dmDescription).HasColumnName("dmDescription");
            this.Property(t => t.dmFedexCode).HasColumnName("dmFedexCode");
            this.Property(t => t.dmTransitTime).HasColumnName("dmTransitTime");
            this.Property(t => t.POS_deploymethod_fk).HasColumnName("POS_deploymethod_fk");
            this.Property(t => t.dmTransitTimeDays).HasColumnName("dmTransitTimeDays");
            this.Property(t => t.dmTransitTimeBusinessDays).HasColumnName("dmTransitTimeBusinessDays");
        }
    }
}
