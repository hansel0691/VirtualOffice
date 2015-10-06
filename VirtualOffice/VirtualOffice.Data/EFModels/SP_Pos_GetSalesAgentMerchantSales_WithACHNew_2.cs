using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualOffice.Data.EFModels
{
    public class SP_Pos_GetSalesAgentMerchantSales_WithACHNew_2
    {
        public int Merchant_Pk { get; set; }
        public string Mer_Name { get; set; }
        public string Merchant_dba { get; set; }
        public double PrepaidTotal { get; set; }
        public double CellularTotal { get; set; }
        public int DialToneTotal { get; set; }
        public double PINLessTotal { get; set; }
        public int GiftCardTotal { get; set; }
        public int PrepaidCellPhoneTotal { get; set; }
        public int PostpaidCellPhoneTotal { get; set; }
        public int TrafficSchoolTotal { get; set; }
        public int CreditTotal { get; set; }
        public int DebitTotal { get; set; }
        public double discount { get; set; }
        public double Celldiscount { get; set; }
        public int DialTonediscount { get; set; }
        public double PINLessDiscount { get; set; }
        public int GiftCardDiscount { get; set; }
        public int PrepaidCellPhoneDiscount { get; set; }
        public int PostpaidCellPhoneDiscount { get; set; }
        public int TrafficSchoolDiscount { get; set; }
        public double subtotal { get; set; }
        public double Cellsubtotal { get; set; }
        public int DialTonesubtotal { get; set; }
        public double PINLessSubTotal { get; set; }
        public int GiftCardSubTotal { get; set; }
        public int PrepaidCellPhoneSubTotal { get; set; }
        public int PostpaidCellPhoneSubTotal { get; set; }
        public int TrafficSchoolSubTotal { get; set; }
        public double FeesDebitCreditSales { get; set; }
        public int AgentDiscount { get; set; }
        public double SRPRemainingOtherProducts { get; set; }
        public double DiscountRemainingOtherProducts { get; set; }
        public double GrossSaleRemainingOtherProducts { get; set; }
        public double GeneralTotal { get; set; }
        public int ProcTransTotal { get; set; }
        public int GeneralDiscount { get; set; }
        public double GeneralNet { get; set; }
        public int ACHTotal { get; set; }
        public int AmountSentNotPaid { get; set; }
        public int ACHPaid { get; set; }
        public double TotalOtherProducts { get; set; }
        public double DiscountOtherProducts { get; set; }
        public double NetOtherProducts { get; set; }
        public int MerType { get; set; }
        public double CurrentBalance { get; set; }
        public bool IsClosed { get; set; }
        public string LastInvoicedSale { get; set; }
        public string DaysSinceLastSale { get; set; }
        public int compliance { get; set; }
        public bool suspended { get; set; }
        public bool isCollection { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIP { get; set; }
        public int AgentCommission { get; set; }
        public bool isPrepaidMerchant { get; set; }
        public double prepaidBalance { get; set; }
        public double merchantBalance { get; set; }
        public string merchant_BusAddress { get; set; }
        public string merchant_AddressCityID { get; set; }
        public string merchant_AddressStateID { get; set; }
        public string merchant_AddressZIP { get; set; }

    }
}
