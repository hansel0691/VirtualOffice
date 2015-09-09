using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace CoreData.Models.Mapping
{
    public class TokenMapping: EntityTypeConfiguration<AuthToken>
    {
        public TokenMapping()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Value)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Tokens");
            this.Property(t => t.Id).HasColumnName("id");
            this.Property(t => t.Value).HasColumnName("value");
            this.Property(t => t.ApiUserId).HasColumnName("ApiUserId");
            this.Property(t => t.Expiration).HasColumnName("ExpirationDate");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.ApiUser)
                .WithMany(t => t.Tokens)
                .HasForeignKey(d => d.ApiUserId);
        }
    }
}
