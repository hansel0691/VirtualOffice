using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class vw_MerchantsMap : EntityTypeConfiguration<vw_Merchants>
    {
        public vw_MerchantsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.MerchantName, t.MerchantDBA, t.City, t.StateLetters });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.MerchantName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MerchantDBA)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.StateLetters)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.StateName)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("vw_Merchants");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.MerchantName).HasColumnName("MerchantName");
            this.Property(t => t.MerchantDBA).HasColumnName("MerchantDBA");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.StateLetters).HasColumnName("StateLetters");
            this.Property(t => t.StateName).HasColumnName("StateName");
        }
    }
}
