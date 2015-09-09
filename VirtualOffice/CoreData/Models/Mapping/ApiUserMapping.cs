using System.Data.Entity.ModelConfiguration;
using Domain.Models;

namespace CoreData.Models.Mapping
{
    public class ApiUserMapping : EntityTypeConfiguration<ApiUser>
    {
        public ApiUserMapping()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ApiKey)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Secret)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ApiUsers");
            this.Property(t => t.Id).HasColumnName("id");
            this.Property(t => t.ApiKey).HasColumnName("ApiKey");
            this.Property(t => t.Secret).HasColumnName("Secret");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
        }
    }
}