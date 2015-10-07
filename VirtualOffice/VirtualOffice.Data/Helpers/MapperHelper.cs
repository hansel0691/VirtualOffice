using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VirtualOffice.Data.EFModels;


namespace VirtualOffice.Data.Helpers
{
    public static class MapperHelper
    {
        static MapperHelper()
        {
            InitializeMaps();
        }

        private static void InitializeMaps()
        {
            Mapper.CreateMap<IDataReader, sp_get_transactions_Result>()
               .ForMember(p => p.merchant_pk, k => k.MapFrom(r => r["merchant_pk"] is DBNull ? 0 : r["merchant_pk"] as int?))
               .ForMember(p => p.mer_name, k => k.MapFrom(m => m["mer_name"] is DBNull ? null : m["mer_name"].ToString()))
               .ForMember(p => p.datestamp, k => k.MapFrom(m => m["amex_amount"] is DBNull ? null : m["datestamp"] as string))
               .ForMember(p => p.vmc_amount, k => k.MapFrom(m => m["vmc_amount"] is DBNull ? null : m["vmc_amount"].ToString()))
               .ForMember(p => p.amex_amount, k => k.MapFrom(m => m["amex_amount"] is DBNull ? null : m["amex_amount"].ToString()))
               .ForMember(p => p.dscv_amount, k => k.MapFrom(m => m["dscv_amount"] is DBNull ? null : m["dscv_amount"].ToString()))
               .ForMember(p => p.ebt_amount, k => k.MapFrom(m => m["ebt_amount"] is DBNull ? null : m["ebt_amount"].ToString()))
               .ForMember(p => p.oth_amount, k => k.MapFrom(m => m["oth_amount"] is DBNull ? null : m["oth_amount"].ToString()))
               .ForMember(p => p.tran_amt, k => k.MapFrom(m => m["tran_amt"] is DBNull ? null : m["tran_amt"].ToString()));

            Mapper.CreateMap<IDataReader, sp_getTransactions_details>()
               .ForMember(p => p.date_time, k => k.MapFrom(r => r["transdatetime"] is DBNull ? null : r["transdatetime"]))
               .ForMember(p => p.merchant, k => k.MapFrom(m => m["mer_name"] is DBNull ? null : m["mer_name"]))
               .ForMember(p => p.card_type, k => k.MapFrom(m => m["cardtype"] is DBNull ? null : m["cardtype"]))
               .ForMember(p => p.card_number, k => k.MapFrom(m => m["cardholdernumber"] is DBNull ? null : m["cardholdernumber"]))
               .ForMember(p => p.trans_type, k => k.MapFrom(m => m["trn_type"] is DBNull ? null : m["trn_type"]))
               .ForMember(p => p.category, k => k.MapFrom(m => m["trn_category"] is DBNull ? null : m["trn_category"]))
               .ForMember(p => p.amount, k => k.MapFrom(m => m["transamount"] is DBNull ? null : m["transamount"]));


            Mapper.CreateMap<IDataReader, SP_Pos_GetSalesAgentMerchantSales_WithACHNew_2>()
                .ForMember(p => p.Merchant_Pk, k => k.MapFrom(r => r["Merchant_Pk"] is DBNull ? 0 : r["Merchant_Pk"]))
                .ForMember(p => p.Mer_Name, k => k.MapFrom(r => r["Mer_Name"] is DBNull ? null : r["Mer_Name"]))
                .ForMember(p => p.Merchant_dba, k => k.MapFrom(r => r["Merchant_dba"] is DBNull ? null : r["Merchant_dba"]))
                .ForMember(p => p.PrepaidTotal, k => k.MapFrom(r => r["PrepaidTotal"] is DBNull ? 0 : r["PrepaidTotal"]))
                .ForMember(p => p.CellularTotal, k => k.MapFrom(r => r["CellularTotal"] is DBNull ? 0 : r["CellularTotal"]))
                .ForMember(p => p.DialToneTotal, k => k.MapFrom(r => r["DialToneTotal"] is DBNull ? 0 : r["DialToneTotal"]))
                .ForMember(p => p.PINLessTotal, k => k.MapFrom(r => r["PINLessTotal"] is DBNull ? 0 : r["PINLessTotal"]))
                .ForMember(p => p.GiftCardTotal, k => k.MapFrom(r => r["GiftCardTotal"] is DBNull ? 0 : r["GiftCardTotal"]))
                .ForMember(p => p.PrepaidCellPhoneTotal, k => k.MapFrom(r => r["PrepaidCellPhoneTotal"] is DBNull ? 0 : r["PrepaidCellPhoneTotal"]))
                .ForMember(p => p.PostpaidCellPhoneTotal, k => k.MapFrom(r => r["PostpaidCellPhoneTotal"] is DBNull ? 0 : r["PostpaidCellPhoneTotal"]))
                .ForMember(p => p.TrafficSchoolTotal, k => k.MapFrom(r => r["TrafficSchoolTotal"] is DBNull ? 0 : r["TrafficSchoolTotal"]))
                .ForMember(p => p.CreditTotal, k => k.MapFrom(r => r["CreditTotal"] is DBNull ? 0 : r["CreditTotal"]))
                .ForMember(p => p.DebitTotal, k => k.MapFrom(r => r["DebitTotal"] is DBNull ? 0 : r["DebitTotal"]))
                .ForMember(p => p.discount, k => k.MapFrom(r => r["discount"] is DBNull ? 0 : r["discount"]))
                .ForMember(p => p.Celldiscount, k => k.MapFrom(r => r["Celldiscount"] is DBNull ? 0 : r["Celldiscount"]))
                .ForMember(p => p.DialTonediscount, k => k.MapFrom(r => r["DialTonediscount"] is DBNull ? 0 : r["DialTonediscount"]))
                .ForMember(p => p.PINLessDiscount, k => k.MapFrom(r => r["PINLessDiscount"] is DBNull ? 0 : r["PINLessDiscount"]))
                .ForMember(p => p.GiftCardDiscount, k => k.MapFrom(r => r["GiftCardDiscount"] is DBNull ? 0 : r["GiftCardDiscount"]))
                .ForMember(p => p.PrepaidCellPhoneDiscount, k => k.MapFrom(r => r["PrepaidCellPhoneDiscount"] is DBNull ? 0 : r["PrepaidCellPhoneDiscount"]))
                .ForMember(p => p.PostpaidCellPhoneDiscount, k => k.MapFrom(r => r["PostpaidCellPhoneDiscount"] is DBNull ? 0 : r["PostpaidCellPhoneDiscount"]))
                .ForMember(p => p.TrafficSchoolDiscount, k => k.MapFrom(r => r["TrafficSchoolDiscount"] is DBNull ? 0 : r["TrafficSchoolDiscount"]))
                .ForMember(p => p.subtotal, k => k.MapFrom(r => r["subtotal"] is DBNull ? 0 : r["subtotal"]))
                .ForMember(p => p.Cellsubtotal, k => k.MapFrom(r => r["Cellsubtotal"] is DBNull ? 0 : r["Cellsubtotal"]))
                .ForMember(p => p.DialTonesubtotal, k => k.MapFrom(r => r["DialTonesubtotal"] is DBNull ? 0 : r["DialTonesubtotal"]))
                .ForMember(p => p.PINLessSubTotal, k => k.MapFrom(r => r["PINLessSubTotal"] is DBNull ? 0 : r["PINLessSubTotal"]))
                .ForMember(p => p.GiftCardSubTotal, k => k.MapFrom(r => r["GiftCardSubTotal"] is DBNull ? 0 : r["GiftCardSubTotal"]))
                .ForMember(p => p.PrepaidCellPhoneSubTotal, k => k.MapFrom(r => r["PrepaidCellPhoneSubTotal"] is DBNull ? 0 : r["PrepaidCellPhoneSubTotal"]))
                .ForMember(p => p.PostpaidCellPhoneSubTotal, k => k.MapFrom(r => r["PostpaidCellPhoneSubTotal"] is DBNull ? 0 : r["PostpaidCellPhoneSubTotal"]))
                .ForMember(p => p.TrafficSchoolSubTotal, k => k.MapFrom(r => r["TrafficSchoolSubTotal"] is DBNull ? 0 : r["TrafficSchoolSubTotal"]))
                .ForMember(p => p.FeesDebitCreditSales, k => k.MapFrom(r => r["FeesDebitCreditSales"] is DBNull ? 0 : r["FeesDebitCreditSales"]))
                .ForMember(p => p.AgentDiscount, k => k.MapFrom(r => r["AgentDiscount"] is DBNull ? 0 : r["AgentDiscount"]))
                .ForMember(p => p.SRPRemainingOtherProducts, k => k.MapFrom(r => r["SRPRemainingOtherProducts"] is DBNull ? 0 : r["SRPRemainingOtherProducts"]))
                .ForMember(p => p.DiscountRemainingOtherProducts, k => k.MapFrom(r => r["DiscountRemainingOtherProducts"] is DBNull ? 0 : r["DiscountRemainingOtherProducts"]))
                .ForMember(p => p.GrossSaleRemainingOtherProducts, k => k.MapFrom(r => r["GrossSaleRemainingOtherProducts"] is DBNull ? 0 : r["GrossSaleRemainingOtherProducts"]))
                .ForMember(p => p.GeneralTotal, k => k.MapFrom(r => r["GeneralTotal"] is DBNull ? 0 : r["GeneralTotal"]))
                .ForMember(p => p.ProcTransTotal, k => k.MapFrom(r => r["ProcTransTotal"] is DBNull ? 0 : r["ProcTransTotal"]))
                .ForMember(p => p.GeneralDiscount, k => k.MapFrom(r => r["GeneralDiscount"] is DBNull ? 0 : r["GeneralDiscount"]))
                .ForMember(p => p.GeneralNet, k => k.MapFrom(r => r["GeneralNet"] is DBNull ? 0 : r["GeneralNet"]))
                .ForMember(p => p.ACHTotal, k => k.MapFrom(r => r["ACHTotal"] is DBNull ? 0 : r["ACHTotal"]))
                .ForMember(p => p.AmountSentNotPaid, k => k.MapFrom(r => r["AmountSentNotPaid"] is DBNull ? 0 : r["AmountSentNotPaid"]))
                .ForMember(p => p.ACHPaid, k => k.MapFrom(r => r["ACHPaid"] is DBNull ? 0 : r["ACHPaid"]))
                .ForMember(p => p.TotalOtherProducts, k => k.MapFrom(r => r["TotalOtherProducts"] is DBNull ? 0 : r["TotalOtherProducts"]))
                .ForMember(p => p.DiscountOtherProducts, k => k.MapFrom(r => r["DiscountOtherProducts"] is DBNull ? 0 : r["DiscountOtherProducts"]))
                .ForMember(p => p.NetOtherProducts, k => k.MapFrom(r => r["NetOtherProducts"] is DBNull ? 0 : r["NetOtherProducts"]))
                .ForMember(p => p.MerType, k => k.MapFrom(r => r["MerType"] is DBNull ? 0 : r["MerType"]))
                .ForMember(p => p.CurrentBalance, k => k.MapFrom(r => r["CurrentBalance"] is DBNull ? 0 : r["CurrentBalance"]))
                .ForMember(p => p.IsClosed, k => k.MapFrom(r => r["IsClosed"] is DBNull ? false : r["IsClosed"]))
                .ForMember(p => p.LastInvoicedSale, k => k.MapFrom(r => r["LastInvoicedSale"] is DBNull ? new DateTime() : r["LastInvoicedSale"]))
                .ForMember(p => p.DaysSinceLastSale, k => k.MapFrom(r => r["DaysSinceLastSale"] is DBNull ? 0 : r["DaysSinceLastSale"]))
                .ForMember(p => p.compliance, k => k.MapFrom(r => r["compliance"] is DBNull ? false : r["compliance"]))
                .ForMember(p => p.suspended, k => k.MapFrom(r => r["suspended"] is DBNull ? false : r["suspended"]))
                .ForMember(p => p.isCollection, k => k.MapFrom(r => r["isCollection"] is DBNull ? false : r["isCollection"]))
                .ForMember(p => p.City, k => k.MapFrom(r => r["City"] is DBNull ? null : r["City"]))
                .ForMember(p => p.State, k => k.MapFrom(r => r["State"] is DBNull ? null : r["State"]))
                .ForMember(p => p.ZIP, k => k.MapFrom(r => r["ZIP"] is DBNull ? null : r["ZIP"]))
                .ForMember(p => p.AgentCommission, k => k.MapFrom(r => r["AgentCommission"] is DBNull ? 0 : r["AgentCommission"]))
                .ForMember(p => p.isPrepaidMerchant, k => k.MapFrom(r => r["isPrepaidMerchant"] is DBNull ? 0 : double.Parse(r["isPrepaidMerchant"].ToString())))
                .ForMember(p => p.prepaidBalance, k => k.MapFrom(r => r["prepaidBalance"] is DBNull ? 0 : r["prepaidBalance"]))
                .ForMember(p => p.merchantBalance, k => k.MapFrom(r => r["merchantBalance"] is DBNull ? 0 : r["merchantBalance"]))
                .ForMember(p => p.merchant_BusAddress, k => k.MapFrom(r => r["merchant_BusAddress"] is DBNull ? null : r["merchant_BusAddress"]))
                .ForMember(p => p.merchant_AddressCityID, k => k.MapFrom(r => r["merchant_AddressCityID"] is DBNull ? null : r["merchant_AddressCityID"]))
                .ForMember(p => p.merchant_AddressStateID, k => k.MapFrom(r => r["merchant_AddressStateID"] is DBNull ? null : r["merchant_AddressStateID"]))
                .ForMember(p => p.merchant_AddressZIP, k => k.MapFrom(r => r["merchant_AddressZIP"] is DBNull ? null : r["merchant_AddressZIP"]))
                ;

        }



        public static K MapTo<T, K>(this T aModelSource)
        {
            var modelResult = Mapper.Map<T, K>(aModelSource);

            return modelResult;
        }
    }
}
