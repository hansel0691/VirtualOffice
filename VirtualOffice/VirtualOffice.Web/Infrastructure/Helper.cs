using System;
using AutoMapper;
using ClassLibrary2.Domain.MerchantServices;
using ClassLibrary2.Domain.Others;
using ClassLibrary2.Domain.Prepaid;
using VirtualOffice.Web.Models;
using VirtualOffice.Web.Models.NewReports;
using VirtualOffice.Web.Models.NewReports.MerchantServices;

namespace VirtualOffice.Web.Infrastructure
{
    public static class MapperHelper
    {
        static MapperHelper()
        {
            InitializeMaps();
        }

        private static void InitializeMaps()
        {

            #region Prepaid

            Mapper.CreateMap<PrepaidPortfolioResult, PrepaidPortfolioSummaryResultViewModel>()
                .ForMember(p => p.last_month_sales,
                    k => k.MapFrom(m => double.Parse(m.last_month_sales.GetPlaneFormat())))
                .ForMember(p => p.this_month_sales,
                    k => k.MapFrom(m => double.Parse(m.this_month_sales.GetPlaneFormat())))
                .ForMember(p => p.seven_day_sales, k => k.MapFrom(m => double.Parse(m.seven_day_sales.GetPlaneFormat())))
                .ForMember(p => p.today_sales, k => k.MapFrom(m => double.Parse(m.today_sales.GetPlaneFormat())))
                .ForMember(p => p.Status, k => k.MapFrom(m => m.closed == 1 ? "CLOSED" : m.suspended ? "SUSPENDED" : "ACTIVE"));
           
            Mapper.CreateMap<PrepaidSalesSummaryResult, PrepaidSalesSummaryResultViewModel>()
            .ForMember(p => p.grSalesLD, k => k.MapFrom(m => double.Parse(m.grSalesLD.GetPlaneFormat())))
            .ForMember(p => p.grSalesCEL, k => k.MapFrom(m => double.Parse(m.grSalesCEL.GetPlaneFormat())))
            .ForMember(p => p.grSalesOTH, k => k.MapFrom(m => double.Parse(m.grSalesOTH.GetPlaneFormat())))
            .ForMember(p => p.GrSalesTOT, k => k.MapFrom(m => double.Parse(m.GrSalesTOT.GetPlaneFormat())))
            .ForMember(p => p.mchCommission, k => k.MapFrom(m => double.Parse(m.mchCommission.GetPlaneFormat())))
            .ForMember(p => p.feesANDcredits, k => k.MapFrom(m => double.Parse(m.feesANDcredits.GetPlaneFormat())))
            .ForMember(p => p.netSales, k => k.MapFrom(m => double.Parse(m.netSales.GetPlaneFormat())))
            .ForMember(p => p.agtCommission, k => k.MapFrom(m => double.Parse(m.agtCommission.GetPlaneFormat())))
            .ForMember(p => p.dstCommission, k => k.MapFrom(m => double.Parse(m.dstCommission.GetPlaneFormat())))
            .ForMember(p => p.isoCommission, k => k.MapFrom(m => double.Parse(m.isoCommission.GetPlaneFormat())))
            .ForMember(p => p.accBalance, k => k.MapFrom(m => double.Parse(m.accBalance.GetPlaneFormat())));

            Mapper.CreateMap<PrepaidSalesDetailsResult, PrepaidSalesDetailsResultViewModel>()
              .ForMember(p => p.ld_sales, k => k.MapFrom(m => double.Parse(m.ld_sales.GetPlaneFormat())))
              .ForMember(p => p.pinless_sales, k => k.MapFrom(m => double.Parse(m.pinless_sales.GetPlaneFormat())))
              .ForMember(p => p.wireless_sales, k => k.MapFrom(m => double.Parse(m.wireless_sales.GetPlaneFormat())))
              .ForMember(p => p.international_sales, k => k.MapFrom(m => double.Parse(m.international_sales.GetPlaneFormat())))
              .ForMember(p => p.other_sales, k => k.MapFrom(m => double.Parse(m.other_sales.GetPlaneFormat())))
              .ForMember(p => p.debits, k => k.MapFrom(m => double.Parse(m.debits.GetPlaneFormat())))
              .ForMember(p => p.credits, k => k.MapFrom(m => double.Parse(m.credits.GetPlaneFormat())))
              .ForMember(p => p.total_sales, k => k.MapFrom(m => double.Parse(m.total_sales.GetPlaneFormat())))
              .ForMember(p => p.mrch_commission, k => k.MapFrom(m => double.Parse(m.mrch_commission.GetPlaneFormat())))
              .ForMember(p => p.net_sales, k => k.MapFrom(m => double.Parse(m.net_sales.GetPlaneFormat())))
              .ForMember(p => p.agt_commission, k => k.MapFrom(m => double.Parse(m.agt_commission.GetPlaneFormat())))
              .ForMember(p => p.dst_commission, k => k.MapFrom(m => double.Parse(m.dst_commission.GetPlaneFormat())))
              .ForMember(p => p.iso_commission, k => k.MapFrom(m => double.Parse(m.iso_commission.GetPlaneFormat())));

            Mapper.CreateMap<PrepaidInvoiceDetailsResult, PrepaidInvoiceDetailsResultViewModel>()
            .ForMember(p => p.pro_denomination, k => k.MapFrom(m => double.Parse(m.pro_denomination.GetPlaneFormat())))
            .ForMember(p => p.inv_discount, k => k.MapFrom(m => double.Parse(m.inv_discount.GetPlaneFormat())))
            .ForMember(p => p.inv_subtotal, k => k.MapFrom(m => double.Parse(m.inv_subtotal.GetPlaneFormat())))
            .ForMember(p => p.agentcommission, k => k.MapFrom(m => double.Parse(m.agentcommission.GetPlaneFormat())))
            .ForMember(p => p.distcommission, k => k.MapFrom(m => double.Parse(m.distcommission.GetPlaneFormat())))
            .ForMember(p => p.mdistcommission, k => k.MapFrom(m => double.Parse(m.mdistcommission.GetPlaneFormat())))
            ;
        
            Mapper.CreateMap<PrepaidTodayTransactionsResult, PrepaidTodayTransactionsViewModel>()
            .ForMember(p => p.amount, k => k.MapFrom(m => double.Parse(m.amount.GetPlaneFormat())));

            Mapper.CreateMap<IppBrowserResult, IppBrowserResultViewModel>()
            .ForMember(p => p.amount, k => k.MapFrom(m => double.Parse(m.amount.GetPlaneFormat())))
            .ForMember(p => p.amount, k => k.MapFrom(m => double.Parse(m.merchantFeeShare.HasValue?m.merchantFeeShare.Value.GetPlaneFormat():"0")))
            .ForMember(p => p.amount, k => k.MapFrom(m => double.Parse(m.fee.GetPlaneFormat())));

            Mapper.CreateMap<AccountsInCollectionResult, PrepaidAccountsInCollectionViewModel>();
            
            Mapper.CreateMap<GetMerchantCreditLimitsResult, MerchantCreditLimitResultViewModel>();
            
            Mapper.CreateMap<AccountRegisterResult, PrepaidAccountRegisterViewModel>()
            .ForMember(p => p.accBalance, k => k.MapFrom(m => double.Parse(m.accBalance.GetPlaneFormat())))
            .ForMember(p => p.debit, k => k.MapFrom(m => double.Parse(m.debit.GetPlaneFormat())))
            .ForMember(p => p.credit, k => k.MapFrom(m => double.Parse(m.credit.GetPlaneFormat())));

            Mapper.CreateMap<MerchantComissionResult, MerchantCommissionsResultViewModel>();

            Mapper.CreateMap<MerchantStatementResult, MerchantStatementResultViewModel>();

            Mapper.CreateMap<ClassLibrary2.Domain.Prepaid.TransactionSummaryResult, TransactionSummaryViewModel>();
            Mapper.CreateMap<TransactionSummaryViewModel, ClassLibrary2.Domain.Prepaid.TransactionSummaryResult>();

            Mapper.CreateMap<FullCargaStatement, FullcargaStatementsViewModel>();
            Mapper.CreateMap<FullcargaStatementsViewModel, FullCargaStatement>();
            
            Mapper.CreateMap<FullcargaInvoiceDetail, FullcargaInvoiceDetailViewModel>();
            Mapper.CreateMap<FullcargaInvoiceDetailViewModel, FullcargaInvoiceDetail>();

            Mapper.CreateMap<FullcargaPrepaidSummary, FullcargaPrepaidSummaryViewModel>();
            Mapper.CreateMap<FullcargaPrepaidSummaryViewModel, FullcargaPrepaidSummary>();

            #endregion

            #region Merchant Services
            Mapper.CreateMap<MsPortfolioResult, MsPortfolioResultViewModel>();

            Mapper.CreateMap<MsComissionSummaryResult, MsComissionSummaryResultViewModel>()
                .ForMember(p => p.amt_returns, k => k.MapFrom(m => double.Parse(m.amt_returns.GetPlaneFormat())))
                .ForMember(p => p.amt_sales, k => k.MapFrom(m => double.Parse(m.amt_sales.GetPlaneFormat())))
                .ForMember(p => p.avg_ticket, k => k.MapFrom(m => double.Parse(m.avg_ticket.GetPlaneFormat())))
                .ForMember(p => p.amex_commission, k => k.MapFrom(m => double.Parse(m.amex_commission.GetPlaneFormat())))
                .ForMember(p => p.vmc_commission, k => k.MapFrom(m => double.Parse(m.vmc_commission.GetPlaneFormat())))
                .ForMember(p => p.tot_commission, k => k.MapFrom(m => double.Parse(m.tot_commission.GetPlaneFormat())))
                .ForMember(p => p.oth_commission, k => k.MapFrom(m => double.Parse(m.oth_commission.GetPlaneFormat())));


            Mapper.CreateMap<MsComissionSummaryForAmex, MsComissionSummaryForAmexViewModel>()
                 .ForMember(p => p.amt_sales, k => k.MapFrom(m => double.Parse(m.amt_sales.GetPlaneFormat())))
                .ForMember(p => p.avg_ticket, k => k.MapFrom(m => double.Parse(m.avg_ticket.GetPlaneFormat())))
                .ForMember(p => p.commission, k => k.MapFrom(m => double.Parse(m.commission.GetPlaneFormat())))
                .ForMember(p => p.income, k => k.MapFrom(m => double.Parse(m.income.GetPlaneFormat())))
                .ForMember(p => p.expenses, k => k.MapFrom(m => double.Parse(m.expenses.GetPlaneFormat())))
                .ForMember(p => p.netincome, k => k.MapFrom(m => double.Parse(m.netincome.GetPlaneFormat())))
                .ForMember(p => p.adjustments, k => k.MapFrom(m => double.Parse(m.adjustments.GetPlaneFormat())));

            Mapper.CreateMap<MsCommssionSummaryForVmC, MsCommissionSummaryForVmCViewModel>()
                .ForMember(p => p.amt_sales, k => k.MapFrom(m => double.Parse(m.amt_sales.GetPlaneFormat())))
                .ForMember(p => p.avg_ticket, k => k.MapFrom(m => double.Parse(m.avg_ticket.GetPlaneFormat())))
                .ForMember(p => p.commisison, k => k.MapFrom(m => double.Parse(m.commisison.GetPlaneFormat())))
                .ForMember(p => p.income, k => k.MapFrom(m => double.Parse(m.income.GetPlaneFormat())))
                .ForMember(p => p.expenses, k => k.MapFrom(m => double.Parse(m.expenses.GetPlaneFormat())))
                .ForMember(p => p.netincome, k => k.MapFrom(m => double.Parse(m.netincome.GetPlaneFormat())))
                .ForMember(p => p.adjustments, k => k.MapFrom(m => double.Parse(m.adjustments.GetPlaneFormat())));

            Mapper.CreateMap<MsCommissionSummaryByTotals, MsCommissionSummaryByTotalsViewModel>()
            .ForMember(p => p.amt_sales, k => k.MapFrom(m => double.Parse(m.amt_sales.GetPlaneFormat())))
                .ForMember(p => p.avg_ticket, k => k.MapFrom(m => double.Parse(m.avg_ticket.GetPlaneFormat())))
                .ForMember(p => p.commission, k => k.MapFrom(m => double.Parse(m.commission.GetPlaneFormat())))
                .ForMember(p => p.income, k => k.MapFrom(m => double.Parse(m.income.GetPlaneFormat())))
                .ForMember(p => p.expenses, k => k.MapFrom(m => double.Parse(m.expenses.GetPlaneFormat())))
                .ForMember(p => p.netincome, k => k.MapFrom(m => double.Parse(m.netincome.GetPlaneFormat())))
                .ForMember(p => p.adjustments, k => k.MapFrom(m => double.Parse(m.adjustments.GetPlaneFormat())));

            Mapper.CreateMap<MsCommsissionSummaryForOthers, MsCommissionSummaryForOthersViewModel>()
                .ForMember(p => p.amt_sales, k => k.MapFrom(m => double.Parse(m.amt_sales.GetPlaneFormat())))
                .ForMember(p => p.avg_ticket, k => k.MapFrom(m => double.Parse(m.avg_ticket.GetPlaneFormat())))
                .ForMember(p => p.commission, k => k.MapFrom(m => double.Parse(m.commission.GetPlaneFormat())))
                .ForMember(p => p.income, k => k.MapFrom(m => double.Parse(m.income.GetPlaneFormat())))
                .ForMember(p => p.expenses, k => k.MapFrom(m => double.Parse(m.expenses.GetPlaneFormat())))
                .ForMember(p => p.netincome, k => k.MapFrom(m => double.Parse(m.netincome.GetPlaneFormat())))
                .ForMember(p => p.adjustments, k => k.MapFrom(m => double.Parse(m.adjustments.GetPlaneFormat())));

            Mapper.CreateMap<MsTransactionSummaryResult, MsTransactionSummaryViewModel>()
               .ForMember(p => p.vmc_amount, k => k.MapFrom(m => double.Parse(m.vmc_amount.GetPlaneFormat())))
               .ForMember(p => p.amex_amount, k => k.MapFrom(m => double.Parse(m.amex_amount.GetPlaneFormat())))
               .ForMember(p => p.dscv_amount, k => k.MapFrom(m => double.Parse(m.dscv_amount.GetPlaneFormat())))
               .ForMember(p => p.ebt_amount, k => k.MapFrom(m => double.Parse(m.ebt_amount.GetPlaneFormat())))
               .ForMember(p => p.oth_amount, k => k.MapFrom(m => double.Parse(m.oth_amount.GetPlaneFormat())))
               .ForMember(p => p.tran_amt, k => k.MapFrom(m => double.Parse(m.tran_amt.GetPlaneFormat())))
               .ForMember(p => p.datestamp, k => k.MapFrom(m => m.datestamp == null ? new DateTime() : DateTime.Parse(m.datestamp)));

            Mapper.CreateMap<MsTransactionDetailsResult, MsTransactionDetailsViewModel>()
                .ForMember(p => p.date_time, k => k.MapFrom(m => m.date_time == null ? "" : m.date_time.ToString("g")));

            #endregion

            #region Others

            Mapper.CreateMap<VirtualOfficeUser, UserModel>()
            .ForMember(p => p.Address1, k => k.MapFrom(m => m.address1))
            .ForMember(p => p.Address2, k => k.MapFrom(m => m.address2))
            .ForMember(p => p.BusinessName, k => k.MapFrom(m => m.businessName))
            .ForMember(p => p.City, k => k.MapFrom(m => m.city))
            .ForMember(p => p.Comission, k => k.MapFrom(m => m.comission))
            .ForMember(p => p.Email, k => k.MapFrom(m => m.email))
            .ForMember(p => p.Phone, k => k.MapFrom(m => m.phone))
            .ForMember(p => p.State, k => k.MapFrom(m => m.state))
            .ForMember(p => p.UserId, k => k.MapFrom(m => m.userid))
            .ForMember(p => p.Name, k => k.MapFrom(m => m.username))
            .ForMember(p => p.UserCategory, k => k.MapFrom(m => m.usertype.ToString()))
            .ForMember(p => p.IsFullcarga, k => k.MapFrom(m => m.isFullcarga == 1))
            .ForMember(p => p.ZipCode, k => k.MapFrom(m => m.zipCode));


            Mapper.CreateMap<MarketingMaterial, MarketingProduct>()
                .ForMember(p => p.Id, k => k.MapFrom(m => m.packageid));


            #endregion
        }


        /// Created By: Carlos Raul (02262014)
        ///  <summary>
        ///  Extension Method to perform a mapping between to objects with a previous well-defined Mapping
        ///  </summary>
        ///  <typeparam name="T"></typeparam>
        /// <typeparam name="TK"></typeparam>
        /// <param name="aEntity"></param>
        /// <returns></returns>
        public static TK MapTo<T,TK>(this T aEntity)
        {
           
            var modelResult = Mapper.Map<T,TK>(aEntity);

            return modelResult;
        }
    }
}