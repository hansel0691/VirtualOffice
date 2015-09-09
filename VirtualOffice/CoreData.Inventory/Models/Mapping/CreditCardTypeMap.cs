using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class CreditCardTypeMap : EntityTypeConfiguration<CreditCardType>
    {
        public CreditCardTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CCcheck)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.name)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("CreditCardTypes");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.CCcheck).HasColumnName("CCcheck");
            this.Property(t => t.name).HasColumnName("name");
        }
    }
}
