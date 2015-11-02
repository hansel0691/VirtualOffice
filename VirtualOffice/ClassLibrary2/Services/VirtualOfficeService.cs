using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using ClassLibrary2.Domain;
using MerchantServices = ClassLibrary2.Domain.MerchantServices;
using ClassLibrary2.Domain.Others;
using ClassLibrary2.Domain.Prepaid;
using VirtualOffice.Data.EFModels;
using VirtualOffice.Data.Repositories;
using VirtualOffice.Service.Domain;
using VirtualOffice.Service.Domain.Infrastructure;
using ReportLog = ClassLibrary2.Domain.ReportLog;

namespace VirtualOffice.Service.Services
{
    public class VirtualOfficeService
    {
        private readonly ReportRepository _reportRepository;
        private readonly UserReportRepository _userReportRepository;
        private readonly UserRepository _userRepository;
        private readonly DashboardConfigsRepository _dashboardConfigsRepository;
        private readonly ReportLabelsRepository _reportLabelsRepository;
        private readonly LeadRepository _leadRepository;
        private readonly IncidentsRepository _incidentsRepository;
        private readonly InventoryRepository _inventoryRepository;
        private readonly DocumentsRepository _documentsRepository;
        private readonly UserHashRepository _userHashRepository;
        private readonly ReportLogsRepository _reportLogsRepository;
       
        public VirtualOfficeService()
        {
            _dashboardConfigsRepository = new DashboardConfigsRepository();
            _userReportRepository = new UserReportRepository();
            _reportRepository = new ReportRepository();
            _userRepository = new UserRepository();
            _reportLabelsRepository = new ReportLabelsRepository();
            _leadRepository = new LeadRepository();
            _incidentsRepository = new IncidentsRepository();
            _inventoryRepository = new InventoryRepository();
            _documentsRepository = new DocumentsRepository();
            _userHashRepository = new UserHashRepository();
            _reportLogsRepository = new ReportLogsRepository();
        }

        #region Prepaid Reports
        public IEnumerable<PrepaidPortfolioResult> RunPrepaidPortfolioSummary(int agentId)
        {
            try
            {
                var reportResult = _reportRepository.RunPrepaidPortfolioSummary(agentId);

                var result = reportResult.MapTo<IEnumerable<sp_report_portfolio_summary_Result>, IEnumerable<PrepaidPortfolioResult>>();

                return result;
            }
            catch (Exception exception)
            {
                return new List<PrepaidPortfolioResult>();
            }
        }

        public IEnumerable<PrepaidPortfolioResult> RunPrepaidPortfolioInAlert(int agentId)
        {
            try
            {
                var reportResult = _reportRepository.RunPrepaidPortfolioInAlert(agentId);

                var result = reportResult.MapTo<IEnumerable<sp_report_prepaid_portfolio_inAlert_Result>, IEnumerable<PrepaidPortfolioResult>>();

                return result;
            }
            catch (Exception exception)
            {
               return new List<PrepaidPortfolioResult>();
            }
            
        }

        public IEnumerable<PrepaidSalesSummaryResult> RunPrepaidSalesSummary(int agentId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var reportResult = _reportRepository.RunSalesSummary(agentId, startDate, endDate);

                var result = reportResult.MapTo<IEnumerable<sp_report_general_sales_summary_Result>, IEnumerable<PrepaidSalesSummaryResult>>();

                return result;
            }
            catch (Exception exception)
            {
                return new List<PrepaidSalesSummaryResult>();
            }
        }

        public IEnumerable<PrepaidSalesDetailsResult> RunPrepaidSalesDetails(int agentId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var reportResult = _reportRepository.RunMerchantSalesDetails(agentId, startDate, endDate);

                var result = reportResult.MapTo<IEnumerable<sp_report_sales_details_Result>, IEnumerable<PrepaidSalesDetailsResult>>();

                return result;
            }
            catch (Exception exception)
            {
                return new List<PrepaidSalesDetailsResult>();
            }
        }

        public IEnumerable<PrepaidInvoiceDetailsResult> RunPrepaidInvoiceDetails(int invoiceId)
        {
            try
            {
                var reportResult = _reportRepository.RunInvoiceDetails(invoiceId);

                var result = reportResult.MapTo<IEnumerable<sp_report_invoice_details_Result>, IEnumerable<PrepaidInvoiceDetailsResult>>();

                return result;
            }
            catch (Exception exception)
            {
               return new List<PrepaidInvoiceDetailsResult>();
            }
        }

        public IEnumerable<AccountRegisterResult> RunAccountRegister(int agentType, int agentId, string startDate, string endDate)
        {
            try
            {
                var reportResult = _reportRepository.RunAccountRegister(agentType, agentId, startDate, endDate);

                var result = reportResult.MapTo<IEnumerable<SP_ShowAccountRegister_Result>, IEnumerable<AccountRegisterResult>>();

                return result;
            }
            catch (Exception exception)
            {
               return new List<AccountRegisterResult>();
            }
        }

        public IEnumerable<PrepaidTodayTransactionsResult> RunTodayTransactions(int agentId, int? merchantId)
        {
            try
            {
                var reportResult = _reportRepository.RunTodayTransactions(agentId, merchantId);

                var result = reportResult.MapTo<IEnumerable<GetTodayTransactions_New_Result>, IEnumerable<PrepaidTodayTransactionsResult>>();

                return result;
            }
            catch (Exception exception)
            {
                return new List<PrepaidTodayTransactionsResult>();
            }
        }

        public IEnumerable<AccountsInCollectionResult> GetAccountsInCollection(int agentId)
        {
            try
            {
                var reportResult = _reportRepository.RunAccountsInCollection(agentId);

                var result = reportResult.MapTo<IEnumerable<AccountsInCollection_Result>, IEnumerable<AccountsInCollectionResult>>();

                return result;
            }
            catch (Exception exception)
            {
               return new List<AccountsInCollectionResult>();
            }
        }

        public IEnumerable<IppBrowserResult> RunIppBrowser(int agentId,int merchantId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var reportResult = _reportRepository.RunIppTransactions(agentId, merchantId, startDate, endDate);

                var result = reportResult.MapTo<IEnumerable<SP_ippBrowser_Result>, IEnumerable<IppBrowserResult>>();

                return result;
            }
            catch (Exception exception)
            {
                return new List<IppBrowserResult>();
            }
        }

        public IEnumerable<GetMerchantCreditLimitsResult> GetMerchantCreditLimits(int? agentId, int? merchantId)
        {
            try
            {
                var reportResult = _reportRepository.GetMerchantCreditLimits(agentId, merchantId);

                var result = reportResult.MapTo<IEnumerable<GetMerchantCreditLimits_Result>, IEnumerable<GetMerchantCreditLimitsResult>>();

                return result;
            }
            catch (Exception exception)
            {
                return new List<GetMerchantCreditLimitsResult>();
            }
        }

        public IEnumerable<MerchantComissionResult> GetMerchantComissions(int agentId, int? merchantId)
        {
            try
            {
                var reportResult = _reportRepository.GetMerchantComissions(agentId, merchantId);

                var result = reportResult.MapTo<IEnumerable<sp_GetMerchantCommissionsProfile_Result>, IEnumerable<MerchantComissionResult>>();

                return result;
            }
            catch (Exception exception)
            {
                return new List<MerchantComissionResult>();
            }
        }
        
        public IEnumerable<MerchantStatementResult> GetMerchantStatements(int merchantId, string startDate, string endDate)
        {
            var merchantStatements = _reportRepository.GetMerchantStatements(merchantId, startDate, endDate);

            var result = merchantStatements.MapTo<IEnumerable<Sp_GetMerchantStatement_Result>, IEnumerable<MerchantStatementResult>>();

            return result;
        }

        public IEnumerable<TransactionSummaryResult> GetTransactionsSummary(int agentId, bool isMerchant, DateTime startDate, DateTime endDate)
        {
            var transactionsSummary = _reportRepository.GetTransactionSummary(agentId, isMerchant, startDate, endDate);

            var result = transactionsSummary.MapTo<IEnumerable<Sp_TransactionsSummary_new_Result>, IEnumerable<TransactionSummaryResult>>();

            return result;
        }

        public IEnumerable<FullCargaStatement> GetFullCargaStatements(int userId, DateTime startDate, DateTime endDate)
        {
            var fullcargaStatements = _reportRepository.GetFullCargaStatement(userId, startDate, endDate);

            var result = fullcargaStatements.MapTo<IEnumerable<SP_Fullcarga_Statetement_Result>, IEnumerable<FullCargaStatement>>();

            return result;
        }

        public IEnumerable<FullcargaInvoiceDetail> GetFullcargarInvoiceDetail(int invoiceId, int userId)
        {
            var invoices = _reportRepository.GetFullcargaInvoiceDetail(invoiceId, userId);

            var result = invoices.MapTo<IEnumerable<SP_Fullcarga_DetailInvoice_with_hrf_Result>, IEnumerable<FullcargaInvoiceDetail>>();

            return result;
        }

        public IEnumerable<FullcargaPrepaidSummary> GetFullcargaPrepaidSummary(int userId, bool isMerchant, DateTime startDate, DateTime endDate)
        {
            var prepaidSummary = _reportRepository.GetFullcargaPrepaidSummary(userId, isMerchant, startDate, endDate);

            var result = prepaidSummary.MapTo<IEnumerable<SP_Fullcarga_PrepaidSalesSummary_Result>, IEnumerable<FullcargaPrepaidSummary>>();

            return result;
        }


        public IEnumerable<AgentToBillMerchants> GetMerchantBilling(int userId, DateTime startDate, DateTime endDate)
        {
            var prepaidSummary = _reportRepository.GetMerchantBilling(userId, startDate, endDate);

            var result = prepaidSummary.MapTo<IEnumerable<SP_Send_AgentToBillMerchants_Result>, IEnumerable<AgentToBillMerchants>>();

            return result;
        }

        public IEnumerable<CommissionReport> SendCommitionReport(int userId, DateTime startDate, DateTime endDate, bool isMerchant)
        {
            var prepaidSummary = _reportRepository.SendCommitionReport(userId, startDate, endDate, isMerchant);

            var result = prepaidSummary.MapTo<IEnumerable<SP_Send_CommissionReport_Result>, IEnumerable<CommissionReport>>();

            return result;
        }


        #endregion

        #region MS Reports
        public IEnumerable<MerchantServices.MsPortfolioResult> RunMsPortfolioSummary(int agentId)
        {
            try
            {
                var reportResult = _reportRepository.RunMerchantServicesPortfolioSummary(agentId);

                var result = reportResult.MapTo<IEnumerable<sp_report_msv_portfolio_summary_Result>, IEnumerable<MerchantServices.MsPortfolioResult>>();

                return result;
            }
            catch (Exception exception)
            {
                return new List<MerchantServices.MsPortfolioResult>();
            }
        }
        public IEnumerable<MerchantServices.MsComissionSummaryResult> RunMsComissionSummary(int agentId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var reportResult = _reportRepository.RunMerchantServicesComissionSummary(agentId, startDate, endDate);

                var result = reportResult.MapTo<IEnumerable<sp_report_msv_commission_summary_Result>, IEnumerable<MerchantServices.MsComissionSummaryResult>>();

                return result;
            }
            catch (Exception exception)
            {
               return new List<MerchantServices.MsComissionSummaryResult>();
            }
        }
        public IEnumerable<MerchantServices.MsTransactionSummaryResult> RunTransactionSummary(int agentId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var reportResult = _reportRepository.RunMerchantServicesTransactions(agentId, startDate, endDate);

                var result = reportResult.MapTo<IEnumerable<sp_get_transactions_Result>, IEnumerable<MerchantServices.MsTransactionSummaryResult>>();

                return result;
            }
            catch (Exception exception)
            {
                return new List<MerchantServices.MsTransactionSummaryResult>();
            }
        }

        public IEnumerable<SalesAgentMerchantSalesResult> RunReportAgentSummary(int agentId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var reportResult = _reportRepository.RunReportAgentSummary(agentId, startDate, endDate);

                var result = reportResult.MapTo<IEnumerable<SP_Pos_GetSalesAgentMerchantSales_WithACHNew_2>, IEnumerable<SalesAgentMerchantSalesResult>>();

                return result;

            }
            catch (Exception exception)
            {
                return new List<SalesAgentMerchantSalesResult>();
            }
        }

        public IEnumerable<MerchantServices.MsTransactionDetailsResult> RunTransactionsDetails(int? agentId, DateTime startDate, DateTime endDate, string columnName)
        {
            try
            {
                if (agentId == null)throw new Exception("agent id cant be null");
                var reportResult = _reportRepository.RunTransactionsDetails((int)agentId, startDate, endDate, columnName);

                var result = reportResult.MapTo<IEnumerable<sp_getTransactions_details>, IEnumerable<MerchantServices.MsTransactionDetailsResult>>();

                return result;
            }
            catch (Exception exception)
            {
                return new List<MerchantServices.MsTransactionDetailsResult>();
            }
        }

        public IEnumerable<MerchantServices.MsComissionSummaryForAmex> RunMsComissionDetailsForAmex(int agentId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var reportResult = _reportRepository.RunProccessingCommissionAmexDetails(agentId, startDate, endDate);

                var result = reportResult.MapTo<IEnumerable<sp_report_msv_commission_details_from_amex_Result>, IEnumerable<MerchantServices.MsComissionSummaryForAmex>>();

                return result;
            }
            catch (Exception exception) 
            {
               return new List<MerchantServices.MsComissionSummaryForAmex>();
            }
        }
        public IEnumerable<MerchantServices.MsCommssionSummaryForVmC> RunMsComissionDetailsForVmC(int agentId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var reportResult = _reportRepository.RunProccessingCommissionVisa_MasterCardDetails(agentId, startDate, endDate);

                var result = reportResult.MapTo<IEnumerable<sp_report_msv_commission_details_from_visamc_Result>, IEnumerable<MerchantServices.MsCommssionSummaryForVmC>>();

                return result;
            }
            catch (Exception exception)
            {
               return new List<MerchantServices.MsCommssionSummaryForVmC>();
            }
        }
        public IEnumerable<MerchantServices.MsCommsissionSummaryForOthers> RunMsComissionDetailsForOthers(int agentId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var reportResult = _reportRepository.RunProccessingCommissionOtherDetails(agentId, startDate, endDate);

                var result = reportResult.MapTo<IEnumerable<sp_report_msv_commission_details_from_other_Result>, IEnumerable<MerchantServices.MsCommsissionSummaryForOthers>>();

                return result;
            }
            catch (Exception exception)
            {
               return new List<MerchantServices.MsCommsissionSummaryForOthers>();
            }
        }
        public IEnumerable<MerchantServices.MsCommissionSummaryByTotals> RunMsComissionDetailsByTotals(int agentId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var reportResult = _reportRepository.RunProccessingCommissionTotalDetails(agentId, startDate, endDate);

                var result = reportResult.MapTo<IEnumerable<sp_report_msv_commission_details_by_totals_Result>, IEnumerable<MerchantServices.MsCommissionSummaryByTotals>>();

                return result;
            }
            catch (Exception exception)
            {
                return new List<MerchantServices.MsCommissionSummaryByTotals>();
            }
        }

        #endregion

        #region Config & Features Ops


        public Domain.UserReport GetUserReportConfig(int userId, string storeProcedureName)
        {
            try
            {
                var userReportResult = _userReportRepository.GetUserReport(userId, storeProcedureName);

                var result = userReportResult.MapTo<Data.EFModels.UserReport, Domain.UserReport>();

                return result;
            }
            catch (Exception exception)
            {
               return new Domain.UserReport();
            }
        }

        public VirtualOfficeUser GetUser(string userId, string password)
        {
            try
            {
                var user = _userRepository.GetUser(userId, password);

                var userResult = user.MapTo<get_user_Result, VirtualOfficeUser>();

                if (userResult != null) // Adding the user role (Luis's request for a Master User)
                    userResult.Role = _userRepository.GetUserRole(userResult.userid);

                return userResult;
            }
            catch (Exception exception)
            {
               return new VirtualOfficeUser();
            }
        }

        public string GetUserRole(int userId)
        {
            try
            {
                var role = _userRepository.GetUserRole(userId);
                return role;
            }
            catch (Exception exception)
            {
                return string.Empty;
            }
        }

        public ClassLibrary2.Domain.Others.Report GetReport(string storeProcedureName)
        {
            try
            {
                var report = _reportRepository.GetReport(storeProcedureName);

                var result = report.MapTo<Data.EFModels.Report, ClassLibrary2.Domain.Others.Report>();

                  return result;
            }
            catch (Exception exception)
            {
                return new ClassLibrary2.Domain.Others.Report();
            }
        }

        public IEnumerable<ClassLibrary2.Domain.Others.Report> GetAllReports()
        {
            try
            {
                var reports = _reportRepository.GetAllReports();

                var result = reports.MapTo<IEnumerable<Data.EFModels.Report>, IEnumerable<ClassLibrary2.Domain.Others.Report>>();

                return result;
            }
            catch (Exception exception)
            {
                return new List<ClassLibrary2.Domain.Others.Report>();
            }
        }

        public void UpdateUserReportOutPut(int agentId, string storeProcedureName, string userReportOutput)
        {
            try
            {
                _userReportRepository.UpdateUserReportOutPut(agentId, storeProcedureName, userReportOutput);
            }
            catch (Exception exception)
            {
                return;
            }
        }

        public void UpdateUserReportOutPutConfig(int agentId, string storeProcedureName, string outputConfig)
        {
            try
            {
                _userReportRepository.UpdateUserReportOutPutConfig(agentId, storeProcedureName, outputConfig);
            }
            catch (Exception exception)
            {
                return;
            }
        }

        public IEnumerable<DashboardItem> GetDashboardItems(int agentId, bool runReports)
        {
            try
            {
                var dashBoardConfigs = _dashboardConfigsRepository.GetDashboardConfigs();

                var dashboardItems = dashBoardConfigs.MapTo<IEnumerable<DashboardConfig>, IEnumerable<DashboardItem>>().ToList();

                dashboardItems.ForEach(
                dashboardConfig =>
                {
                    var result = GetDashboardConfigItems(dashboardConfig, agentId, runReports);
                    dashboardConfig.Items = result.Items;
                    dashboardConfig.ItemsUrl = result.UrlLinks;
                });

                return dashboardItems;
            }
            catch (Exception exception)
            {
               return new List<DashboardItem>();
            }
        }
        #endregion

        #region Tools 

        public IEnumerable<Lead> GetAllLeads(int agentId, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var leads = _leadRepository.GetLeads(agentId, startDate, endDate);

                var leadsResult = leads.MapTo<IEnumerable<sp_retrieve_leads_Result>, IEnumerable<Lead>>();

                return leadsResult;
            }
            catch (Exception exception)
            {
               return new List<Lead>();
            }
        }

        public IEnumerable<Incident> GetAllIncidents(int agentId, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var incidents = _incidentsRepository.GetAllIncidents(agentId, startDate, endDate);

                var incidentsResult = incidents.MapTo<IEnumerable<sp_retrieve_incidents_Result>, IEnumerable<Incident>>();

                return incidentsResult;
            }
            catch (Exception exception)
            {
                return new List<Incident>();
            }
        }

        public IEnumerable<MarketingMaterial> GetMarketingMaterials()
        {
            try
            {
                var materials = _inventoryRepository.GetMarketingMaterials();

                var marketingMaterialsResult = materials.MapTo<IEnumerable<sp_get_marketing_materials_Result>, IEnumerable<MarketingMaterial>>();

                return marketingMaterialsResult;
            }
            catch (Exception exception)
            {
               return new List<MarketingMaterial>();
            }
        }

        #endregion

        #region Aux Ops

        private ItemValueUrl GetDashboardConfigItems(DashboardItem dashboardConfig, int agentId, bool runReports)
        {
            try
            {
                var function = GetType().GetMethod(dashboardConfig.ItemsFunction);

                var parameters = GetMethodParametersValues(function, agentId,runReports, dashboardConfig.Remark);

                var items = function.Invoke(this, parameters) as ItemValueUrl;

                return items;
            }
            catch (Exception exception)
            {
                return new ItemValueUrl();
            }
        }

        #region Prepaid Accounts

        #region Dashboard Items

        public ItemValueUrl GetPrepaidAccounts(int agentId, bool runReports)
        {
            
                var prepaidActives = runReports? PrepaidAccountsActive(agentId): 0;
                var prepaidInactive = runReports? PrepaidAccountsInactive(agentId): 0;

                var result = new Dictionary<string, string>
                {
                    {"Actives", prepaidActives.ToString()},
                    {"Inactives", prepaidInactive.ToString()}
                };
                var resultUrls = new Dictionary<string, string>
                {
                    {"Actives", "PrepaidReports/PortfolioSummary?status=1"},
                    {"Inactives", "PrepaidReports/PortfolioSummary?status=0"}
                };

                return new ItemValueUrl(result, resultUrls);
        
            
        }

        public ItemValueUrl GetPrepaidSalesSummary(int agentId, bool runReports, DateTime startDate, DateTime endDate)
        {
            
                var prepaidSales = runReports? PrepaidSalesSummary(agentId, startDate, endDate): 0;
                var ippTransactions = runReports? PrepaidBillPaymentSales(agentId,0,startDate, endDate): 0;
                var commission = runReports? GetUserRunningComission(agentId): 0;

                var beginDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                

                var result = new Dictionary<string, string>
                {
                    {"Total Prepaid", prepaidSales.ToString("C")},
                    {"Total BillPayment", ippTransactions.ToString("C")},
                    {"Running Commission", commission.HasValue? commission.Value.ToString("C"): "0"}
                };
                var resultUrls = new Dictionary<string, string>
                {
                    {"Total Prepaid", "PrepaidReports/SalesSummary?startDate="+ startDate.ToString("d") +"&endDate=" + endDate.Date.ToString("d")},
                    {"Total BillPayment", "PrepaidReports/IppBrowser?startDate="+ startDate.ToString("d") +"&endDate=" + endDate.Date.ToString("d")},
                    {"Running Commission", "PrepaidReports/ReportAgentSummary?startDate=" + startDate.ToString("d") +"&endDate=" + endDate.Date.ToString("d")}
                };

                return new ItemValueUrl(result, resultUrls);
        }

        public ItemValueUrl GetTodayTransactions(int agentId, bool runReports)
        {
          
                var todayTransactions = runReports? TodayTransactions(agentId): 0;

                var result = new Dictionary<string, string>
                {
                    {"All Merchants", todayTransactions.ToString("C")}
                };
                var resultUrls = new Dictionary<string, string>
                {
                    {"All Merchants", "/PrepaidReports/TodayTransactions"}
                };

                return new ItemValueUrl(result, resultUrls);
  
        }

        public ItemValueUrl GetAccountsWithAlerts(int agentId, bool runReports)
        {
           
                var allAccounts = runReports? _reportRepository.RunPrepaidPortfolioSummary(agentId).ToList(): new List<sp_report_portfolio_summary_Result>();

                var accountsInCompliance = allAccounts.Count(c => (c.compliance.HasValue && c.compliance.Value) && (c.closed == 0 && c.compliance == true || (c.closed == 0 && c.suspended)));
                var suspendedAccounts = allAccounts.Count(c => c.closed == 0 && c.suspended);
                var closedAccountsWithBalance = allAccounts.Count(c => c.closed == 1 && decimal.Parse(c.Balance, NumberStyles.Currency) > 0);

                var result = new Dictionary<string, string>
                {
                    {"In Compliance", accountsInCompliance.ToString()},
                    {"Suspended", suspendedAccounts.ToString()},
                    {"Closed with Balance", closedAccountsWithBalance.ToString()}
                };
                var resultUrls = new Dictionary<string, string>
                {
                    {"In Compliance", ""},
                    {"Suspended", ""},
                    {"Closed with Balance", ""}
                };

                return new ItemValueUrl(result, resultUrls);
        
        }

        #endregion

        #region Dashboard Data
        private int PrepaidAccountsActive(int agentId)
        {
            try
            {
                var allAccounts = _reportRepository.RunPrepaidPortfolioSummary(agentId);

                var result = allAccounts.Count(a => a.Status.ToLower().Equals("active"));

                return result;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        private int PrepaidAccountsInactive(int agentId)
        {
            try
            {
                var allAccounts = _reportRepository.RunPrepaidPortfolioSummary(agentId);

                var result = allAccounts.Count(a => !a.Status.ToLower().Equals("active"));

                return result;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        private decimal PrepaidSalesSummary(int agentId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var prepaidSalesSummary = RunPrepaidSalesSummary(agentId, startDate, endDate);

                var total = prepaidSalesSummary.Sum(s => decimal.Parse(s.GrSalesTOT, NumberStyles.Currency));

                return total;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        private decimal? GetUserRunningComission(int agentId)
        {
            try
            {
                var agents = agentId == 0
               ? _userRepository.GetAllAgentUsers()
               : new List<get_user_Result> { _userRepository.GetUser(agentId) };

                var total = agents.Sum(a => a.comission);

                return total;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        private decimal PrepaidBillPaymentSales(int agentId, int merchantId,  DateTime startDate, DateTime endDate)
        {
            try
            {
                var billPaymentSales = RunIppBrowser(agentId, merchantId, startDate, endDate);

                var total = billPaymentSales.Sum(s => s.amount);

                return total;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        private decimal TodayTransactions(int agentId, int? merchantId = null)
        {
            try
            {
                var transactions = RunTodayTransactions(agentId, merchantId);

                var total = transactions.Sum(s => decimal.Parse(s.amount, NumberStyles.Currency));

                return total;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        #endregion
        #endregion

        #region M.S Accounts

        #region Dashboard Items

        public ItemValueUrl GetMerchantServicesAccounts(int agentId, bool runReports)
        {
            var prepaidActives = runReports? MerchantServicesAccountsActive(agentId): 0;
            var prepaidInactive = runReports? MerchantServicesAccountsInactive(agentId): 0;

            var result = new Dictionary<string, string>
            {
                {"Actives", prepaidActives.ToString()},
                {"Inactives", prepaidInactive.ToString()}
            };
            var resultUrls = new Dictionary<string, string>
            {
                {"Actives", "/MerchantServicesReports/PortfolioSummary"},
                {"Inactives", "/MerchantServicesReports/PortfolioSummary?status=0" }
            };

            return new ItemValueUrl(result, resultUrls);
        }

        public ItemValueUrl GetMerchantServicesSalesSummary(int agentId, bool runReports, DateTime startDate, DateTime endDate)
        {
            var salesSummary = runReports? RunMsComissionSummary(agentId, startDate, endDate): new List<MerchantServices.MsComissionSummaryResult>();

            var commissionsVM = salesSummary.Sum(c => decimal.Parse(c.vmc_commission, NumberStyles.Currency));
            var commissionsOthers = salesSummary.Sum(c => decimal.Parse(c.oth_commission, NumberStyles.Currency));
            var commissionsTotals = salesSummary.Sum(c => decimal.Parse(c.tot_commission, NumberStyles.Currency));

            var result = new Dictionary<string, string>
            {
                {"Visa/ MC/ Amex", commissionsVM.ToString("C")},
                {"Others", commissionsOthers.ToString("C")},
                {"Total", commissionsTotals.ToString("C")}
            };
            var resultUrls = new Dictionary<string, string>
            {
                {"Visa/ MC/ Amex", "/MerchantServicesReports/MsComissionSummaryForVisaMasterCard?agentId="+ agentId +"&startDate="+startDate.ToString("MM/dd/yyyy")+"&endDate=" + endDate.ToString("MM/dd/yyyy")},
                
                {"Others", "/MerchantServicesReports/MsComissionSummaryForOthers?agentId="+ agentId +"&startDate="+startDate.ToString("MM/dd/yyyy")+"&endDate=" + endDate.ToString("MM/dd/yyyy")},
                {"Total", "/MerchantServicesReports/MsComissionSummaryTotal?agentId="+ agentId +"&startDate="+startDate.ToString("MM/dd/yyyy")+"&endDate=" + endDate.ToString("MM/dd/yyyy")}
            };

            return new ItemValueUrl(result, resultUrls);
        }

        public ItemValueUrl GetMerchantServicesApplicationStatus(int agentId, bool runReports)
        {
            var approvedAccounts = runReports? _reportRepository.RunMerchantServicesPortfolioByAccountsType(agentId, 0).Count(): 0;
            var pendingAccounts = runReports? _reportRepository.RunMerchantServicesPortfolioByAccountsType(agentId, 1).Count(): 0;
            var cancelledAccounts = runReports? _reportRepository.RunMerchantServicesPortfolioByAccountsType(agentId, 2).Count(): 0;

            var result = new Dictionary<string, string>
            {
                {"Approved", approvedAccounts.ToString()},
                {"Pending", pendingAccounts.ToString()},
                {"Cancelled", cancelledAccounts.ToString()}
            };
            var resultUrls = new Dictionary<string, string>
            {
                {"Approved", ""},
                {"Pending", ""},
                {"Cancelled", ""}
            };

            return new ItemValueUrl(result, resultUrls);
        }

        #endregion

        #region Dashboard Data
        private int MerchantServicesAccountsActive(int agentId)
        {
            try
            {
                var allAccounts = _reportRepository.RunMerchantServicesPortfolioSummary(agentId);

                var result = allAccounts.Count(a => a.Status == "1");

                return result;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        private int MerchantServicesAccountsInactive(int agentId)
        {
            try
            {
                var allAccounts = _reportRepository.RunMerchantServicesPortfolioSummary(agentId);

                var result = allAccounts.Count(a => a.Status != "1");

                return result;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        private decimal MSCommissionVisaMc(int agentId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var msCommissionVM = RunMsComissionSummary(agentId, startDate, endDate);

                var total = msCommissionVM.Sum(s => decimal.Parse(s.vmc_commission, NumberStyles.Currency));

                return total;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        private decimal MSCommissionAmex(int agentId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var msCommissionVM = RunMsComissionSummary(agentId, startDate, endDate);

                var total = msCommissionVM.Sum(s => decimal.Parse(s.amex_commission, NumberStyles.Currency));

                return total;

            }
            catch (Exception exception)
            {
                return 0;
            }
        }
        private decimal MSCommissionOthers(int agentId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var msCommissionVM = RunMsComissionSummary(agentId, startDate, endDate);

                var total = msCommissionVM.Sum(s => decimal.Parse(s.oth_commission, NumberStyles.Currency));

                return total;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        private decimal MSCommissionTotals(int agentId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var msCommissionVM = RunMsComissionSummary(agentId, startDate, endDate);

                var total = msCommissionVM.Sum(s => decimal.Parse(s.tot_commission, NumberStyles.Currency));

                return total;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        #endregion
        #endregion

        private object[] GetMethodParametersValues(MethodInfo function, int agentId, bool runReports, string remark)
        {
            var functionParameters = function.GetParameters();

            var paramsResult = new ArrayList();

            if(functionParameters.Any(p=> p.ParameterType == typeof(int)))
                paramsResult.Add(agentId);

            paramsResult.Add(runReports);

            if (functionParameters.Any(p => p.ParameterType == typeof (DateTime)))
            {
                 var dateRange = Helper.GetFirst_LastDayRange(remark);

                    if (dateRange != null)
                        paramsResult.AddRange(new ArrayList { dateRange.StartDate, dateRange.EndDate });
            }

            return paramsResult.ToArray();
        }

        private User GetUserById(int agentId)
        {
            var user = _userRepository.GetUserByAgentId(agentId);

            return user;
        }

        #endregion

        #region Reports Logs

        public void LogReportResult(string agentId, string reportName, int reportCount, int maxReportCount)
        {
            try
            {
                var errorMessage = reportCount > maxReportCount ? "Too many items in Report" : string.Empty;

                var reportLog = new Data.EFModels.ReportLog
                {
                    AgentId = agentId,
                    ReportCount = reportCount, 
                    ReportName = reportName,
                    ErrorMessage = errorMessage,
                    TimeSpan = DateTime.Now
                };

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    var textErrorMessage =
                        string.Format("{0} are too many items for agentId:{1} running report: {2} on {3}", reportCount,
                            agentId, reportName, DateTime.Now);

                    NotifyFailureBySms(textErrorMessage, DateTime.Now.ToString());
                }

                _reportLogsRepository.LogReportResult(reportLog);
            }
            catch (Exception exception)
            {
                
            }
        }

        #endregion

        #region Others

        public string GetColumnLabel(string storeProcedureName, string columnName)
        {
            try
            {
                var reportLabels = _reportLabelsRepository.GetReportLabels(storeProcedureName);

                var label = reportLabels.FirstOrDefault(l => l.ColumnName == columnName);

                return label.Label;
            }
            catch (Exception exception)
            {
                var words = columnName.Split(new[] {'.', '_'}, StringSplitOptions.RemoveEmptyEntries);
                var label = words.Aggregate("", (current, word) => current + word + " ");

                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                label = textInfo.ToTitleCase(label);

                return label;
            }
        }


        public IEnumerable<Document> GetAllDocuments()
        {
            var documents = _documentsRepository.GetAllDocuments();

            var result = documents.MapTo<IEnumerable<sp_retrieve_documents_Result>, IEnumerable<Document>>();

            return result;
        }

        public ExternalLoginResponse GetUserExternalToken(string userId, string password)
        {
            var user = GetUser(userId, password);

            if (user == null)
                return null;

            var localUser = GetUserById(user.userid);

            var userHashResponse = _userHashRepository.AddHashKey(new HashKey
            {
                User = localUser,
                Hash = Guid.NewGuid().ToString(),


            });

            return new ExternalLoginResponse
            {
                Token = userHashResponse.Hash,
                UserCategory = userHashResponse.User.Category.ToString()
            };
        }
        #endregion

        #region Utils
        private  static string NotifyFailureBySms(string text, string dateTime)
        {
            //Carlos R Garcia
            var phone = "3055041073";

            //building up the message proccessed by the WebService
            var password = Md5Hash(phone + dateTime);

            var webServiceUrl = string.Format("https://services.bstonecorp.com/sms/SendSMS/send?password={0}&phone={1}&text={2}&dateTime={3}", password, phone, text, dateTime);

            var myRequest = (HttpWebRequest)WebRequest.Create(webServiceUrl);

            var response = (HttpWebResponse)myRequest.GetResponse();

            return response.CharacterSet;
        }

        private static string Md5Hash(string text)
        {

            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(Encoding.ASCII.GetBytes(text));

            byte[] result = md5.Hash;

            var strBuilder = new StringBuilder();

            foreach (byte t in result)
            {
                strBuilder.Append(t.ToString("x2"));
            }

            return strBuilder.ToString();
        }

        #endregion

        public bool UpdateCreditLimit(int? merchantId, decimal? generalLimit, decimal? dailyLimit)
        {
            var prepaidSummary = _reportRepository.UpdateCreditLimit(merchantId, generalLimit, dailyLimit);

            //var result = prepaidSummary.MapTo<IEnumerable<SP_Fullcarga_PrepaidSalesSummary_Result>, IEnumerable<FullcargaPrepaidSummary>>();

            return prepaidSummary;
        }

        public bool UpdatePrepaidAcountStatus(int? merchantId, int status)
        {
            var prepaidSummary = _reportRepository.UpdatePrepaidAcountStatus(merchantId, status);

            //var result = prepaidSummary.MapTo<IEnumerable<SP_Fullcarga_PrepaidSalesSummary_Result>, IEnumerable<FullcargaPrepaidSummary>>();

            return prepaidSummary > 0;
        }

        public bool UpdatePersonalInfo(int id, string email, string phone, bool isMerchant)
        {
            var edited = _userRepository.UpdatePersonalInfo(id, email, phone, isMerchant);

            return edited;
        }

    }

    public class ItemValueUrl
    {
        public ItemValueUrl()
        {
            this.Items = new Dictionary<string, string>();
            this.UrlLinks = new Dictionary<string, string>();
        }

        public ItemValueUrl(Dictionary<string, string> items, Dictionary<string, string> urlLinks )
        {
            this.Items = items;
            this.UrlLinks = urlLinks;
        }


        public Dictionary<string, string> Items { get; set; }
        public Dictionary<string, string> UrlLinks { get; set; }

    }


}
