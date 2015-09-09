using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class Cart_HeaderMap : EntityTypeConfiguration<Cart_Header>
    {
        public Cart_HeaderMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.dateadded, t.merchant_fk });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.merchant_fk)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.orShipTo)
                .HasMaxLength(50);

            this.Property(t => t.orShipAddress1)
                .HasMaxLength(50);

            this.Property(t => t.orShipAddress2)
                .HasMaxLength(30);

            this.Property(t => t.orShipCity)
                .HasMaxLength(50);

            this.Property(t => t.orShipState)
                .HasMaxLength(50);

            this.Property(t => t.orShipZipCode)
                .HasMaxLength(15);

            this.Property(t => t.orShipCountry)
                .HasMaxLength(50);

            this.Property(t => t.orShipPhone)
                .HasMaxLength(25);

            this.Property(t => t.orRefNotes)
                .HasMaxLength(50);

            this.Property(t => t.orComment)
                .HasMaxLength(500);

            this.Property(t => t.orShipEmail)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Cart_Header");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.dateadded).HasColumnName("dateadded");
            this.Property(t => t.merchant_fk).HasColumnName("merchant_fk");
            this.Property(t => t.order_total).HasColumnName("order_total");
            this.Property(t => t.order_tax).HasColumnName("order_tax");
            this.Property(t => t.order_discount).HasColumnName("order_discount");
            this.Property(t => t.order_net).HasColumnName("order_net");
            this.Property(t => t.orShipTo).HasColumnName("orShipTo");
            this.Property(t => t.orShipAddress1).HasColumnName("orShipAddress1");
            this.Property(t => t.orShipAddress2).HasColumnName("orShipAddress2");
            this.Property(t => t.orShipCity).HasColumnName("orShipCity");
            this.Property(t => t.orShipState).HasColumnName("orShipState");
            this.Property(t => t.orShipZipCode).HasColumnName("orShipZipCode");
            this.Property(t => t.orShipCountry).HasColumnName("orShipCountry");
            this.Property(t => t.orShipPhone).HasColumnName("orShipPhone");
            this.Property(t => t.orRefNotes).HasColumnName("orRefNotes");
            this.Property(t => t.orTotalWeight).HasColumnName("orTotalWeight");
            this.Property(t => t.orWeight_measureID).HasColumnName("orWeight_measureID");
            this.Property(t => t.deploymethID).HasColumnName("deploymethID");
            this.Property(t => t.FedExHomeDelivery).HasColumnName("FedExHomeDelivery");
            this.Property(t => t.FedExSaturdayDelivery).HasColumnName("FedExSaturdayDelivery");
            this.Property(t => t.orShipType).HasColumnName("orShipType");
            this.Property(t => t.pmt_method).HasColumnName("pmt_method");
            this.Property(t => t.orShipCost).HasColumnName("orShipCost");
            this.Property(t => t.orComment).HasColumnName("orComment");
            this.Property(t => t.agentID).HasColumnName("agentID");
            this.Property(t => t.orShipEmail).HasColumnName("orShipEmail");
        }
    }
}
