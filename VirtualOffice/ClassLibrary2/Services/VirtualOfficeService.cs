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

        public IEnumerable<ChildrenByAgentReport> GetChildrenByAgent(int userId)
        {
            var prepaidSummary = _reportRepository.GetChildrenByAgent(userId);

            var result = prepaidSummary.MapTo<IEnumerable<sp_child_list_by_agent_Result>, IEnumerable<ChildrenByAgentReport>>();

            return result;
        }

        public IEnumerable<CommissionByProductReport> ProductsCommission(int userId, bool isMerchant)
        {
            var prepaidSummary = _reportRepository.ProductsCommission(userId, isMerchant);

            var result = prepaidSummary.MapTo<IEnumerable<sp_list_products_related_Result>, IEnumerable<CommissionByProductReport>>();

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
        public IEnumerable<MerchantServices.PortfolioAccountsByType> RunMerchantServicesPortfolioByAccountsType(int agentId, int type = -1)
        {
            try
            {
                var reportResult = new List<sp_report_msv_portfolio_AccountsByType_Result>();
                if (type == -1 || type == 0)
                    reportResult.AddRange(_reportRepository.RunMerchantServicesPortfolioByAccountsType(agentId, 0));
                if (type == -1 || type == 1)
                    reportResult.AddRange(_reportRepository.RunMerchantServicesPortfolioByAccountsType(agentId, 1));
                if (type == -1 || type == 2)
                    reportResult.AddRange(_reportRepository.RunMerchantServicesPortfolioByAccountsType(agentId, 2));

                var result = reportResult.MapTo<IEnumerable<sp_report_msv_portfolio_AccountsByType_Result>, IEnumerable<MerchantServices.PortfolioAccountsByType>>();

                return result;
            }
            catch (Exception exception)
            {
                return new List<MerchantServices.PortfolioAccountsByType>();
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

        
        public VirtualOfficeUser GetUser(string userId)
        {
            try
            {
                var user = _userRepository.GetUser(int.Parse(userId));

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

                var itemsCounts = runReports ? GetItemsCount(agentId) : null;

                dashboardItems.ForEach(
                dashboardConfig =>
                {
                    var result = GetDashboardConfigItems(dashboardConfig, agentId, itemsCounts);
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

        private sp_report_portfolio_summary_totals_Result GetItemsCount(int agentId)
        {
            var result = _reportRepository.ReportPortfolioSummaryTotals(agentId, new DateTime(2015, 10, 1), new DateTime(2015, 10, 31));

            return result;
        }

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

        private ItemValueUrl GetDashboardConfigItems(DashboardItem dashboardConfig, int agentId, sp_report_portfolio_summary_totals_Result itemsCounts)
        {
            try
            {
                var function = GetType().GetMethod(dashboardConfig.ItemsFunction);

                var parameters = GetMethodParametersValues(function, agentId, itemsCounts, dashboardConfig.Remark);

                var items = function.Invoke(this, parameters) as ItemValueUrl;

                return items;
            }
            catch (Exception exception)
            {
                return new ItemValueUrl();
            }
        }

        #region Prepaid Accounts


        public ItemValueUrl GetPrepaidAccounts(int agentId, sp_report_portfolio_summary_totals_Result itemsCounts)
        {
            
                var prepaidActives = itemsCounts != null ? itemsCounts.PrepaidAccounts_Actives : 0;
                var prepaidInactive = itemsCounts != null ? itemsCounts.PrepaidAccounts_inactives : 0;

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

        public ItemValueUrl GetPrepaidSalesSummary(int agentId, sp_report_portfolio_summary_totals_Result itemsCounts, DateTime startDate, DateTime endDate)
        {
            
                var prepaidSales = itemsCounts != null ? itemsCounts.GrSalesTOT : 0;
                var ippTransactions = itemsCounts != null ? itemsCounts.BillPayment : 0;
                var commission = itemsCounts != null ? itemsCounts.Running_Commission : 0;

                var beginDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                

                var result = new Dictionary<string, string>
                {
                    {"Total Prepaid", prepaidSales.ToString("C")},
                    {"Total BillPayment", ippTransactions.ToString("C")},
                    {"Running Commission", commission.ToString("C")}
                };
                var resultUrls = new Dictionary<string, string>
                {
                    {"Total Prepaid", "PrepaidReports/SalesSummary?startDate="+ startDate.ToString("d") +"&endDate=" + endDate.Date.ToString("d")},
                    {"Total BillPayment", "PrepaidReports/IppBrowser?startDate="+ startDate.ToString("d") +"&endDate=" + endDate.Date.ToString("d")},
                    {"Running Commission", "PrepaidReports/ReportAgentSummary?startDate=" + startDate.ToString("d") +"&endDate=" + endDate.Date.ToString("d")}
                };

                return new ItemValueUrl(result, resultUrls);
        }

        public ItemValueUrl GetTodayTransactions(int agentId, sp_report_portfolio_summary_totals_Result itemsCounts)
        {
          
                var todayTransactions = itemsCounts != null ? itemsCounts.TodayTransactions : 0;

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

        public ItemValueUrl GetAccountsWithAlerts(int agentId, sp_report_portfolio_summary_totals_Result itemsCounts)
        {
           
                var accountsInCompliance = itemsCounts != null ? itemsCounts.AccountsInAlert_incompliance : 0;
                var suspendedAccounts = itemsCounts != null ? itemsCounts.AccountsInAlert_suspended: 0;
                var closedAccountsWithBalance = itemsCounts != null ? itemsCounts.AccountsInAlert_closedwithbalance : 0;

                var result = new Dictionary<string, string>
                {
                    {"In Compliance", accountsInCompliance.ToString()},
                    {"Suspended", suspendedAccounts.ToString()},
                    {"Closed with Balance", closedAccountsWithBalance.ToString()}
                };
                var resultUrls = new Dictionary<string, string>
                {
                    {"In Compliance", "/PrepaidReports/PortfolioSummary?alertsMode=1&status=4"},
                    {"Suspended", "/PrepaidReports/PortfolioSummary?alertsMode=1&status=2"},
                    {"Closed with Balance", "/PrepaidReports/PortfolioSummary?alertsMode=1&status=3"}
                };

                return new ItemValueUrl(result, resultUrls);
        
        }

        #endregion

        #region M.S Accounts

        public ItemValueUrl GetMerchantServicesAccounts(int agentId, sp_report_portfolio_summary_totals_Result itemsCounts)
        {
            var prepaidActives = itemsCounts != null ? itemsCounts.MSAccounts_Actives : 0;
            var prepaidInactive = itemsCounts != null ? itemsCounts.MSAccounts_inactives : 0;

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

        public ItemValueUrl GetMerchantServicesSalesSummary(int agentId, sp_report_portfolio_summary_totals_Result itemsCounts, DateTime startDate, DateTime endDate)
        {
            var commissionsVM = itemsCounts != null ? itemsCounts.MSCommissionsVISAMCAME : 0;
            var commissionsOthers = itemsCounts != null ? itemsCounts.MSCommissionsOthers : 0;
            var commissionsTotals = itemsCounts != null ? itemsCounts.MSCommissionsTotal : 0;

            var result = new Dictionary<string, string>
            {
                {"Visa/ MC/ Amex", commissionsVM.ToString("C")},
                {"Others", commissionsOthers.ToString("C")},
                {"Total", commissionsTotals.ToString("C")}
            };

            endDate = DateTime.Today.Date;

            var resultUrls = new Dictionary<string, string>
            {
                {"Visa/ MC/ Amex", "/MerchantServicesReports/MsComissionSummaryForVisaMasterCard?agentId="+ agentId +"&startDate="+startDate.ToString("MM/dd/yyyy")+"&endDate=" + endDate.ToString("MM/dd/yyyy")},
                
                {"Others", "/MerchantServicesReports/MsComissionSummaryForOthers?agentId="+ agentId +"&startDate="+startDate.ToString("MM/dd/yyyy")+"&endDate=" + endDate.ToString("MM/dd/yyyy")},
                {"Total", "/MerchantServicesReports/MsComissionSummaryTotal?agentId="+ agentId +"&startDate="+startDate.ToString("MM/dd/yyyy")+"&endDate=" + endDate.ToString("MM/dd/yyyy")}
            };

            return new ItemValueUrl(result, resultUrls);
        }

        public ItemValueUrl GetMerchantServicesApplicationStatus(int agentId, sp_report_portfolio_summary_totals_Result itemsCounts)
        {
            var approvedAccounts = itemsCounts != null ? itemsCounts.MSApplicationsApproved : 0;
            var pendingAccounts = itemsCounts != null ? itemsCounts.MSApplicationsPending : 0;
            var cancelledAccounts = itemsCounts != null ? itemsCounts.MSApplicationsCanceled : 0;

            var result = new Dictionary<string, string>
            {
                {"Approved", approvedAccounts.ToString()},
                {"Pending", pendingAccounts.ToString()},
                {"Cancelled", cancelledAccounts.ToString()}
            };
            var resultUrls = new Dictionary<string, string>
            {
                {"Approved", "MerchantServicesReports/MsAccountStatus?status=0"},
                {"Pending", "MerchantServicesReports/MsAccountStatus?status=1"},
                {"Cancelled", "MerchantServicesReports/MsAccountStatus?status=2"}
            };

            return new ItemValueUrl(result, resultUrls);
        }

        #endregion

        private object[] GetMethodParametersValues(MethodInfo function, int agentId, sp_report_portfolio_summary_totals_Result itemsCounts, string remark)
        {
            var functionParameters = function.GetParameters();

            var paramsResult = new ArrayList();

            if(functionParameters.Any(p=> p.ParameterType == typeof(int)))
                paramsResult.Add(agentId);

            paramsResult.Add(itemsCounts);

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

        public bool UpdateUserCommision(int parentId, int childId, int productCode, double commission)
        {
            var user = _userRepository.GetUser(childId);

            var isMerchant = user.usertype == 0;

            var prepaidSummary = _reportRepository.UpdateUserCommision(parentId, childId, isMerchant, productCode, commission);

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

        public bool CreatePosPendingMerchants(string businessName, string businessPhone, string businessFax, string dba, string emailAddress, string cellularNumber, string businessStreet, string businessCity, string businessState, string businessZip, string merchant_MainContactPhone, string merchant_MainContact, int merchant_RepId, string repName)
        {
            var edited = _userRepository.CreatePosPendingMerchants(businessName, businessPhone, businessFax, dba, emailAddress, cellularNumber, businessStreet, businessCity, businessState, businessZip, merchant_MainContactPhone, merchant_MainContact, merchant_RepId, repName);

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
