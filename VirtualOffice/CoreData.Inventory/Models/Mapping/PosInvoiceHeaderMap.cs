using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class PosInvoiceHeaderMap : EntityTypeConfiguration<PosInvoiceHeader>
    {
        public PosInvoiceHeaderMap()
        {
            // Primary Key
            this.HasKey(t => t.inv_id);

            // Properties
            this.Property(t => t.merchant_businessname)
                .HasMaxLength(50);

            this.Property(t => t.merchant_busphone)
                .HasMaxLength(25);

            this.Property(t => t.merchant_busaddress)
                .HasMaxLength(50);

            this.Property(t => t.merchant_addressCityID)
                .HasMaxLength(25);

            this.Property(t => t.merchant_addressStateID)
                .HasMaxLength(25);

            this.Property(t => t.merchant_addressZIP)
                .HasMaxLength(15);

            this.Property(t => t.merchant_addressCountryID)
                .HasMaxLength(25);

            this.Property(t => t.UserPaid)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PosInvoiceHeader");
            this.Property(t => t.inv_id).HasColumnName("inv_id");
            this.Property(t => t.inv_date).HasColumnName("inv_date");
            this.Property(t => t.merchant_fk).HasColumnName("merchant_fk");
            this.Property(t => t.merchant_StoreNo).HasColumnName("merchant_StoreNo");
            this.Property(t => t.merchant_businessname).HasColumnName("merchant_businessname");
            this.Property(t => t.merchant_busphone).HasColumnName("merchant_busphone");
            this.Property(t => t.merchant_busaddress).HasColumnName("merchant_busaddress");
            this.Property(t => t.merchant_addressCityID).HasColumnName("merchant_addressCityID");
            this.Property(t => t.merchant_addressStateID).HasColumnName("merchant_addressStateID");
            this.Property(t => t.merchant_addressZIP).HasColumnName("merchant_addressZIP");
            this.Property(t => t.merchant_addressCountryID).HasColumnName("merchant_addressCountryID");
            this.Property(t => t.ach_status).HasColumnName("ach_status");
            this.Property(t => t.ach_sentdate).HasColumnName("ach_sentdate");
            this.Property(t => t.ach_id).HasColumnName("ach_id");
            this.Property(t => t.RepCommission_fk).HasColumnName("RepCommission_fk");
            this.Property(t => t.Posted).HasColumnName("Posted");
            this.Property(t => t.Posted_date).HasColumnName("Posted_date");
            this.Property(t => t.Printed).HasColumnName("Printed");
            this.Property(t => t.PrintedMonth).HasColumnName("PrintedMonth");
            this.Property(t => t.PrintedYear).HasColumnName("PrintedYear");
            this.Property(t => t.PrintedDate).HasColumnName("PrintedDate");
            this.Property(t => t.PaidDate).HasColumnName("PaidDate");
            this.Property(t => t.HoldNotesId).HasColumnName("HoldNotesId");
            this.Property(t => t.Hold).HasColumnName("Hold");
            this.Property(t => t.Inv_Related).HasColumnName("Inv_Related");
            this.Property(t => t.approx_PaidDate).HasColumnName("approx_PaidDate");
            this.Property(t => t.GroupPrinted).HasColumnName("GroupPrinted");
            this.Property(t => t.GroupPrintedDate).HasColumnName("GroupPrintedDate");
            this.Property(t => t.ComInvoice_fk).HasColumnName("ComInvoice_fk");
            this.Property(t => t.ConfirmPaid).HasColumnName("ConfirmPaid");
            this.Property(t => t.ConfirmPaidDate).HasColumnName("ConfirmPaidDate");
            this.Property(t => t.PaymentStatus).HasColumnName("PaymentStatus");
            this.Property(t => t.Payments).HasColumnName("Payments");
            this.Property(t => t.UserPaid).HasColumnName("UserPaid");
            this.Property(t => t.DownInvoice).HasColumnName("DownInvoice");
            this.Property(t => t.ClubId).HasColumnName("ClubId");
            this.Property(t => t.SpecialDate).HasColumnName("SpecialDate");
            this.Property(t => t.SpecialBilling).HasColumnName("SpecialBilling");
            this.Property(t => t.SpecialActBilling).HasColumnName("SpecialActBilling");
        }
    }
}
