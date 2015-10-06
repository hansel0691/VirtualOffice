using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualOffice.Data.EFModels;
using VirtualOffice.Data.External;

namespace VirtualOffice.Data.Repositories
{
    public class ReportRepository : BaseRepository
    {
        #region Prepaid Reports

        /// <summary>
        /// Prepaid Portfolio Summary
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IEnumerable<sp_report_portfolio_summary_Result> RunPrepaidPortfolioSummary(int agentId)
        {
            var reportResult = VirtualOfficeContext.sp_report_portfolio_summary(agentId, 0);

            return reportResult;
        }

        public IEnumerable<sp_report_prepaid_portfolio_inAlert_Result> RunPrepaidPortfolioInAlert(int agentId)
        {
            var reportResult = VirtualOfficeContext.sp_report_prepaid_portfolio_inAlert(agentId, 0);

            return reportResult;
        }

        /// <summary>
        /// General Sales Summary
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IEnumerable<sp_report_general_sales_summary_Result> RunSalesSummary(int agentId, DateTime startDate, DateTime endDate)
        {
            var reportResult = VirtualOfficeContext.sp_report_general_sales_summary(agentId, startDate, endDate, false);

            return reportResult;
        }

        /// <summary>
        /// Merchant Balance Report Details
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public IEnumerable<sp_report_balance_details_Result> RunMerchantBalanceReport(int mid)
        {
            var reportResult = VirtualOfficeContext.sp_report_balance_details(mid, 0);

            return reportResult;
        }

        public IEnumerable<sp_report_invoice_details_Result> RunInvoiceDetails(int invoiceId)
        {
            var reportResult = VirtualOfficeContext.sp_report_invoice_details(invoiceId, 0);

            return reportResult;
        }

        /// <summary>
        /// Sales Details By Merchant
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IEnumerable<sp_report_sales_details_Result> RunMerchantSalesDetails(int mid, DateTime startDate, DateTime endDate)
        {
            var reportResult = VirtualOfficeContext.sp_report_sales_details(mid, startDate, endDate, 0);

            return reportResult;
        }

        public IEnumerable<GetTodayTransactions_New_Result> RunTodayTransactions(int agentId, int? merchantId)
        {

            var reportResult = merchantId != 0 ? VirtualOfficeContext.GetTodayTransactions_New(agentId, merchantId, null, null, null, null, null, null) :
                                               VirtualOfficeContext.GetTodayTransactions_New(agentId, null, null, null, null, null, null, null);
            return reportResult;
        }

        public IEnumerable<SP_ShowAccountRegister_Result> RunAccountRegister(int userType, int agentId, string startDate, string endDate)
        {
            var reportResult = VirtualOfficeContext.SP_ShowAccountRegister(userType, agentId, startDate, endDate);

            return reportResult;
        }

        public IEnumerable<AccountsInCollection_Result> RunAccountsInCollection(int agentId)
        {
            var reportResult = VirtualOfficeContext.AccountsInCollection(agentId, null);

            return reportResult;
        }

        public IEnumerable<GetMerchantCreditLimits_Result> GetMerchantCreditLimits(int? agentId, int? merchantId)
        {
            var reportResult = VirtualOfficeContext.GetMerchantCreditLimits(agentId, merchantId, null);

            return reportResult;
        }

        public IEnumerable<sp_GetMerchantCommissionsProfile_Result> GetMerchantComissions(int agentId, int? merchantId)
        {
            var result = VirtualOfficeContext.sp_GetMerchantCommissionsProfile(merchantId, agentId, null);

            return result;
        }

        public IEnumerable<Sp_GetMerchantStatement_Result> GetMerchantStatements(int merchantId, string startDate, string endDate)
        {
            var result = VirtualOfficeContext.Sp_GetMerchantStatement(merchantId.ToString(), startDate, endDate);

            return result;
        }

        public IEnumerable<Sp_TransactionsSummary_new_Result> GetTransactionSummary(int agentId, bool isMerchant, DateTime startDate, DateTime endDate)
        {
            var result = VirtualOfficeContext.Sp_TransactionsSummary_new(startDate, endDate, agentId, isMerchant ? 1 : 0);

            return result;
        }

        public IEnumerable<SP_Fullcarga_Statetement_Result> GetFullCargaStatement(int userId, DateTime startDate, DateTime endDate)
        {
            var result = VirtualOfficeContext.SP_Fullcarga_Statetement(startDate, endDate, userId);

            return result;
        }

        public IEnumerable<SP_Fullcarga_PrepaidSalesSummary_Result> GetFullcargaPrepaidSummary(int userId, bool isMerchant, DateTime startDate, DateTime endDate)
        {
            var result = VirtualOfficeContext.SP_Fullcarga_PrepaidSalesSummary(startDate, endDate, userId, isMerchant ? 1 : 0);

            return result;
        }

        public IEnumerable<SP_Fullcarga_DetailInvoice_with_hrf_Result> GetFullcargaInvoiceDetail(int invoiceId, int userId)
        {
            var result = VirtualOfficeContext.SP_Fullcarga_DetailInvoice_with_hrf(invoiceId, userId);

            return result;
        }

        #endregion

        #region MS Reports
        /// <summary>
        /// MS Portfolio Summary
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IEnumerable<sp_report_msv_portfolio_summary_Result> RunMerchantServicesPortfolioSummary(int agentId)
        {
            var reportResult = VirtualOfficeContext.sp_report_msv_portfolio_summary(agentId, false);

            return reportResult;
        }
        /// <summary>
        /// MS Commission Summary 
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IEnumerable<sp_report_msv_commission_summary_Result> RunMerchantServicesComissionSummary(int agentId, DateTime startDate, DateTime endDate)
        {
            var reportResult = VirtualOfficeContext.sp_report_msv_commission_summary(agentId, startDate, endDate, false);

            return reportResult;
        }
        /// <summary>
        /// MS Commission Summary 
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IEnumerable<sp_get_transactions_Result> RunMerchantServicesTransactions(int agentId, DateTime startDate, DateTime endDate)
        {
            var reportResult = OldConector.sp_get_transactions(agentId, startDate, endDate);

            return reportResult;
        }
        public IEnumerable<sp_getTransactions_details> RunTransactionsDetails(int agentId, DateTime startDate, DateTime endDate, string columnName)
        {
            var reportResult = OldConector.sp_getTransactions_details(agentId, startDate, endDate, columnName);

            return reportResult;
        }


        public IEnumerable<SP_Pos_GetSalesAgentMerchantSales_WithACHNew_2> RunReportAgentSummary(int agentId, DateTime startDate, DateTime endDate)
        {
            var reportResult = OldConector.CallStoreProcedure<SP_Pos_GetSalesAgentMerchantSales_WithACHNew_2>("SP_Pos_GetSalesAgentMerchantSales_WithACHNew_2", "Pin_Data", new Tuple<string, object>[] 
                        {
                            new Tuple<string, object> ("@AgentId", agentId),
                            new Tuple<string, object> ("@dtmInit", startDate.ToString("d")),
                            new Tuple<string, object> ("@dtmEnd", endDate.ToString("d"))
                        });

            return reportResult;
        }


        /// <summary>
        /// Processing Commission Amex Details
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IEnumerable<sp_report_msv_commission_details_from_amex_Result> RunProccessingCommissionAmexDetails(int agentId, DateTime startDate, DateTime endDate)
        {
            var reportResult = VirtualOfficeContext.sp_report_msv_commission_details_from_amex(agentId, startDate, endDate, 0, false);

            return reportResult;
        }
        /// <summary>
        ///Processing Commission VISA/MC Details
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IEnumerable<sp_report_msv_commission_details_from_visamc_Result> RunProccessingCommissionVisa_MasterCardDetails(int agentId, DateTime startDate, DateTime endDate)
        {
            var reportResult = VirtualOfficeContext.sp_report_msv_commission_details_from_visamc(agentId, startDate, endDate, 0, false);

            return reportResult;
        }
        /// <summary>
        ///Proccessing Commission Other Details
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IEnumerable<sp_report_msv_commission_details_from_other_Result> RunProccessingCommissionOtherDetails(int agentId, DateTime startDate, DateTime endDate)
        {
            var reportResult = VirtualOfficeContext.sp_report_msv_commission_details_from_other(agentId, startDate, endDate, 0, false);

            return reportResult;
        }
        /// <summary>
        ///Processing Commission Total Details
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IEnumerable<sp_report_msv_commission_details_by_totals_Result> RunProccessingCommissionTotalDetails(int agentId, DateTime startDate, DateTime endDate)
        {
            var reportResult = VirtualOfficeContext.sp_report_msv_commission_details_by_totals(agentId, startDate, endDate, 0, false);

            return reportResult;
        }

        public IEnumerable<sp_report_msv_portfolio_AccountsByType_Result> RunMerchantServicesPortfolioByAccountsType(int agentId, int type)
        {
            var reportResult = VirtualOfficeContext.sp_report_msv_portfolio_AccountsByType(agentId, type);

            return reportResult;
        }

        #endregion

        #region Others

        public IEnumerable<SP_ippBrowser_Result> RunIppTransactions(int agentId, int merchantId, DateTime startDate, DateTime endDate)
        {
            var reportResult = VirtualOfficeContext.SP_ippBrowser(agentId, merchantId, startDate, endDate, false);

            return reportResult;
        }

        public Report GetReport(string storeProcedureName)
        {
            var report = VirtualOfficeContext.Reports.FirstOrDefault(rep => rep.Query.Equals(storeProcedureName));

            return report;
        }

        public IEnumerable<Report> GetAllReports()
        {
            var result = VirtualOfficeContext.Reports;

            return result;
        }

        #endregion


        public dynamic UpdateCreditLimit(int? merchantId, decimal? generalLimit, decimal? dailyLimit)
        {
            var result = VirtualOfficeContext.sp_FullCarga_change_credit_limit(merchantId, generalLimit, dailyLimit);
            return result;
        }

        public dynamic UpdatePrepaidAcountStatus(int? merchantId, int status)
        {
            var result = VirtualOfficeContext.sp_FullCarga_change_status(merchantId, status);
            return result;
        }
    }
}
