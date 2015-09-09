using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports
{
    public class MerchantStatementResultViewModel
    {
        public string InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal LongDistanceSales { get; set; }
        public decimal LongDistanceDiscount { get; set; }
        public decimal LongDistanceNet { get; set; }
        public decimal CellularRechargeSales { get; set; }
        public decimal CellularRechargeDiscount { get; set; }
        public decimal CellularRechargeNet { get; set; }
        public int DialtoneSales { get; set; }
        public int DialtoneDiscount { get; set; }
        public int DialtoneNet { get; set; }
        public decimal PINLessSales { get; set; }
        public decimal PINLessDiscount { get; set; }
        public decimal PINLessNet { get; set; }
        public int GiftCardSales { get; set; }
        public int GiftCardDiscount { get; set; }
        public int GiftCardNet { get; set; }
        public int PrepaidCellularSales { get; set; }
        public int PrepaidCellularDiscount { get; set; }
        public int PrepaidCellularNet { get; set; }
        public int PostpaidCellularSales { get; set; }
        public int PostpaidCellularDiscount { get; set; }
        public int PostpaidCellularNet { get; set; }
        public int TrafficSchoolSales { get; set; }
        public int TrafficSchoolDiscount { get; set; }
        public int TrafficSchoolNet { get; set; }
        public decimal FeesDebitCreditSales { get; set; }
        public int FeesDebitCreditDiscount { get; set; }
        public decimal FeesDebitCreditNet { get; set; }
        public decimal? GeneralTotalSales { get; set; }
        public decimal? GeneralTotalDiscount { get; set; }
        public decimal? GeneralTotalNet { get; set; }
        public int LoneStarTotal { get; set; }
        public int SpeakEZTotal { get; set; }
        public decimal? AgentDiscount { get; set; }
        public decimal? TotalOtherProducts { get; set; }
        public decimal? DiscountOtherProducts { get; set; }
        public decimal? NetOtherProducts { get; set; }
        public decimal? DistCommission { get; set; }
        public decimal? MDistCommission { get; set; }
        public decimal? SalesTaxAmt { get; set; }
    }
}