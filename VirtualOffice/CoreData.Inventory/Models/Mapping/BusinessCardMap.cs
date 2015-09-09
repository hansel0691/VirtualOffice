using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class BusinessCardMap : EntityTypeConfiguration<BusinessCard>
    {
        public BusinessCardMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.title)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.address1)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.address2)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.telephone)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.fax)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.email)
                .IsFixedLength()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("BusinessCard");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.agent_id).HasColumnName("agent_id");
            this.Property(t => t.merchant_pk).HasColumnName("merchant_pk");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.address1).HasColumnName("address1");
            this.Property(t => t.address2).HasColumnName("address2");
            this.Property(t => t.telephone).HasColumnName("telephone");
            this.Property(t => t.fax).HasColumnName("fax");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.date_created).HasColumnName("date_created");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.cartID).HasColumnName("cartID");
            this.Property(t => t.orderID).HasColumnName("orderID");
        }
    }
}
