﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ClassLibrary2.Domain;
using ClassLibrary2.Domain.MerchantServices;
using ClassLibrary2.Domain.Others;
using ClassLibrary2.Domain.Prepaid;
using VirtualOffice.Data.EFModels;

namespace VirtualOffice.Service.Domain.Infrastructure
{
    public static class Helper
    {
        static Helper()
        {
            InitializeMaps();
        }

        private static void InitializeMaps()
        {
            #region Prepaid Mapping
            Mapper.CreateMap<sp_report_sales_details_Result, PrepaidSalesDetailsResult>();
            Mapper.CreateMap<sp_report_invoice_details_Result, PrepaidInvoiceDetailsResult>();
            Mapper.CreateMap<sp_report_portfolio_summary_Result, PrepaidPortfolioResult>();
            Mapper.CreateMap<sp_report_prepaid_portfolio_inAlert_Result, PrepaidPortfolioResult>();
            Mapper.CreateMap<sp_report_general_sales_summary_Result, PrepaidSalesSummaryResult>();
            Mapper.CreateMap<GetTodayTransactions_New_Result, PrepaidTodayTransactionsResult>()
                .ForMember(p => p.id, k => k.MapFrom(m => int.Parse(string.IsNullOrEmpty(m.id) ? "0" : m.id)))
                .ForMember(p => p.date, k => k.MapFrom(m => m.date.ToString()))
                .ForMember(p => p.amount, k => k.MapFrom(m => m.amount == null ? "0" : m.amount.ToString()));

            Mapper.CreateMap<AccountsInCollection_Result, AccountsInCollectionResult>();
            Mapper.CreateMap<SP_ippBrowser_Result, IppBrowserResult>();
            Mapper.CreateMap<GetMerchantCreditLimits_Result, GetMerchantCreditLimitsResult>();
            Mapper.CreateMap<SP_ShowAccountRegister_Result, AccountRegisterResult>();
            Mapper.CreateMap<sp_GetMerchantCommissionsProfile_Result, MerchantComissionResult>();
            Mapper.CreateMap<Sp_GetMerchantStatement_Result, MerchantStatementResult>();
            Mapper.CreateMap<Sp_TransactionsSummary_new_Result, ClassLibrary2.Domain.Prepaid.TransactionSummaryResult>();
            Mapper.CreateMap<SP_Fullcarga_Statetement_Result, FullCargaStatement>();
            Mapper.CreateMap<SP_Fullcarga_DetailInvoice_with_hrf_Result, FullcargaInvoiceDetail>()
                .ForMember(p => p.Id, k => k.MapFrom(m => int.Parse(m.id)));
            Mapper.CreateMap<SP_Fullcarga_PrepaidSalesSummary_Result, FullcargaPrepaidSummary>();
            Mapper.CreateMap<SP_Pos_GetSalesAgentMerchantSales_WithACHNew_2, SalesAgentMerchantSalesResult>();

            Mapper.CreateMap<SP_Send_AgentToBillMerchants_Result, AgentToBillMerchants>();
            Mapper.CreateMap<SP_Send_CommissionReport_Result, CommissionReport>();


            Mapper.CreateMap<sp_child_list_by_agent_Result, ChildrenByAgentReport>()
                .ForMember(p => p.Name, k => k.MapFrom(m => m.name))
                .ForMember(p => p.Code, k => k.MapFrom(m => m.child.ToString()))
                .ForMember(p => p.Type, k => k.MapFrom(m => m.LEVEL))
                ;

            Mapper.CreateMap<sp_list_products_related_Result, CommissionByProductReport>();


            #endregion

            #region MS Mapping

            Mapper.CreateMap<sp_report_msv_portfolio_summary_Result, MsPortfolioResult>()
                .ForMember(p => p.Status, k => k.MapFrom(m => m.Status == null ? -1 : m.Status == "1" ? 1 : m.Status == "2" ? 2 : 0));
            Mapper.CreateMap<sp_report_msv_commission_summary_Result, MsComissionSummaryResult>();

            Mapper.CreateMap<sp_get_transactions_Result, MsTransactionSummaryResult>();
            Mapper.CreateMap<sp_getTransactions_details, MsTransactionDetailsResult>();

            Mapper.CreateMap<sp_report_msv_commission_details_from_amex_Result, MsComissionSummaryForAmex>();
            Mapper.CreateMap<sp_report_msv_commission_details_from_visamc_Result, MsCommssionSummaryForVmC>();
            Mapper.CreateMap<sp_report_msv_commission_details_from_other_Result, MsCommsissionSummaryForOthers>();
            Mapper.CreateMap<sp_report_msv_commission_details_by_totals_Result, MsCommissionSummaryByTotals>();
            Mapper.CreateMap<sp_report_msv_portfolio_AccountsByType_Result, PortfolioAccountsByType>();
            #endregion

            #region General
            Mapper.CreateMap<Data.EFModels.UserReport, UserReport>();
            Mapper.CreateMap<Data.EFModels.Report, ClassLibrary2.Domain.Others.Report>();
            Mapper.CreateMap<DashboardConfig, DashboardItem>();
            Mapper.CreateMap<get_user_Result, VirtualOfficeUser>();
            Mapper.CreateMap<sp_retrieve_leads_Result, Lead>();
            Mapper.CreateMap<sp_retrieve_incidents_Result, Incident>();
            Mapper.CreateMap<sp_get_marketing_materials_Result, MarketingMaterial>();
            Mapper.CreateMap<sp_retrieve_documents_Result, Document>();


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
        public static TK MapTo<T, TK>(this T aEntity)
        {
            var modelResult = Mapper.Map<T, TK>(aEntity);

            return modelResult;
        }


        ///Created By: Carlos Raul (03102014)
        /// <summary>
        /// Extension Method to determine if a IEnumerable is Empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ienumerable"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IEnumerable<T> ienumerable)
        {
            return !ienumerable.Any();
        }

        private static bool IsNumericColumn<T>(this T obj)
        {
            double numericValueIfAny;

            return obj.ToString().Contains('$') && Double.TryParse(obj.ToString(), out numericValueIfAny);
        }

        public static DateRange GetFirst_LastDayInLastMonths(int months)
        {
            var pastDate = DateTime.Now.AddMonths((-1) * months);

            var first_lastDate = GetFirst_LastDayRange(pastDate.Month, pastDate.Year);

            return new DateRange
            {
                StartDate = first_lastDate.StartDate,
                EndDate = first_lastDate.EndDate
            };
        }


        public static DateRange GetFirst_LastDayRange(int month, int year)
        {
            return GetFirst_LastDayRange(new SummaryRange
            {
                Month = month,
                Year = year
            });
        }

        public static DateRange GetFirst_LastDayRange(SummaryRange range)
        {
            var firstDayOfMonth = new DateTime(range.Year, range.Month, 1);

            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            return new DateRange
            {
                StartDate = firstDayOfMonth,
                EndDate = lastDayOfMonth
            };
        }

        public static DateRange GetFirst_LastDayRange(string summaryRemark)
        {
            if (string.IsNullOrEmpty(summaryRemark))
                return null;

            var firstDigit = summaryRemark.FirstOrDefault(char.IsDigit);

            int months;

            if (int.TryParse(firstDigit.ToString(), out months))
                return GetFirst_LastDayInLastMonths(months);

            return GetFirst_LastDayInLastMonths(1);

        }
    }
}
