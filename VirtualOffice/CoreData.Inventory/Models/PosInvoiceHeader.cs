using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class PosInvoiceHeader
    {
        public int inv_id { get; set; }
        public Nullable<System.DateTime> inv_date { get; set; }
        public Nullable<int> merchant_fk { get; set; }
        public Nullable<int> merchant_StoreNo { get; set; }
        public string merchant_businessname { get; set; }
        public string merchant_busphone { get; set; }
        public string merchant_busaddress { get; set; }
        public string merchant_addressCityID { get; set; }
        public string merchant_addressStateID { get; set; }
        public string merchant_addressZIP { get; set; }
        public string merchant_addressCountryID { get; set; }
        public Nullable<int> ach_status { get; set; }
        public Nullable<System.DateTime> ach_sentdate { get; set; }
        public Nullable<int> ach_id { get; set; }
        public Nullable<int> RepCommission_fk { get; set; }
        public Nullable<bool> Posted { get; set; }
        public Nullable<System.DateTime> Posted_date { get; set; }
        public Nullable<int> Printed { get; set; }
        public Nullable<int> PrintedMonth { get; set; }
        public Nullable<int> PrintedYear { get; set; }
        public Nullable<System.DateTime> PrintedDate { get; set; }
        public Nullable<System.DateTime> PaidDate { get; set; }
        public Nullable<int> HoldNotesId { get; set; }
        public Nullable<bool> Hold { get; set; }
        public Nullable<int> Inv_Related { get; set; }
        public Nullable<System.DateTime> approx_PaidDate { get; set; }
        public Nullable<bool> GroupPrinted { get; set; }
        public Nullable<System.DateTime> GroupPrintedDate { get; set; }
        public int ComInvoice_fk { get; set; }
        public Nullable<int> ConfirmPaid { get; set; }
        public Nullable<System.DateTime> ConfirmPaidDate { get; set; }
        public Nullable<int> PaymentStatus { get; set; }
        public Nullable<decimal> Payments { get; set; }
        public string UserPaid { get; set; }
        public Nullable<int> DownInvoice { get; set; }
        public Nullable<int> ClubId { get; set; }
        public Nullable<System.DateTime> SpecialDate { get; set; }
        public Nullable<int> SpecialBilling { get; set; }
        public Nullable<int> SpecialActBilling { get; set; }
    }
}
