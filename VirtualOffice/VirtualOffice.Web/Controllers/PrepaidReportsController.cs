using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using ApiRestClient.Infrastructure;
using ClassLibrary2.Domain;
using ClassLibrary2.Domain.Prepaid;
using Domain.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using VirtualOffice.Service.Domain;
using VirtualOffice.Service.Services;
using VirtualOffice.Web.Infrastructure;
using VirtualOffice.Web.Models;
using VirtualOffice.Web.Models.NewReports;
using WebGrease.Css.Extensions;

namespace VirtualOffice.Web.Controllers
{

    [Authorize(Roles = "User")]
    public class PrepaidReportsController : VirtualOfficeController
    {

        #region Report Entry Points

        public PrepaidReportsController(IWebClient webClient)
            : base(webClient)
        {
        }

        private VirtualOfficeReportModel GetReportModel(string storeProcedureName, Type viewModelType, string printLink, Action<Dictionary<string, ColumnConfig>> columnConfigAction = null)
        {
            var columnsConfig = GetUserReportColumnsConfig(GetLoggedUserId(), storeProcedureName, viewModelType);

            if (columnConfigAction != null)
                columnConfigAction(columnsConfig);

            var model = GetReportModel(columnsConfig, printLink, storeProcedureName);

            return model;
        }

        public ActionResult PortfolioSummary(int? alertsMode, int status = -1)
        {
            var printLink = "/PrepaidReports/PrintPortfolioSummary";

            if (!alertsMode.HasValue || alertsMode == 0)
                printLink += "?alertsMode=1";

            var model = GetReportModel("sp_report_portfolio_summary", typeof(PrepaidPortfolioSummaryResultViewModel), printLink, a => MarkColumnsAsGroupable(a, "DistName"));

            ViewBag.AlertsMode = alertsMode;
            ViewBag.StatusView = status;
            ViewData["categories"] = new[] { new { Value = "ACTIVE", Text = "ACTIVE" }, new { Value = "SUSPENDED", Text = "SUSPENDED" }, new { Value = "CLOSED", Text = "CLOSED" } };

            return View(model);
        }

        public ActionResult SalesSummary(DateTime? startDate = null, DateTime? endDate = null)
        {
            var model = GetReportModel("sp_report_general_sales_summary", typeof(PrepaidSalesSummaryResultViewModel), "/PrepaidReports/PrintSalesSummary", AddLinksToPrepaidSalesColumnConfig);

            if (startDate != null) model.DateRange.StartDate = (DateTime)startDate;
            if (endDate != null) model.DateRange.EndDate = (DateTime)endDate;

            return View(model);
        }

        public ActionResult AccountRegister()
        {
            var model = GetReportModel("SP_ShowAccountRegister", typeof(PrepaidAccountRegisterViewModel), "/PrepaidReports/PrintAccountRegister", AddLinksToPrepaidSalesColumnConfig);

            return View(model);
        }

        public ActionResult SalesDetails(int merchantId)
        {
            var model = GetReportModel("sp_report_sales_details", typeof(PrepaidSalesDetailsResultViewModel), "/PrepaidReports/PrintSalesDetails", AddLinksToPrepaidInvoiceColumnConfig);

            ViewBag.MerchantId = merchantId;

            return View(model);
        }

        public ActionResult InvoiceDetails(int invoiceId)
        {
            var model = GetReportModel("sp_report_invoice_details", typeof(PrepaidInvoiceDetailsResultViewModel), "/PrepaidReports/PrintInvoiceDetails", AddLinksToPrepaidInvoiceColumnConfig);

            ViewBag.InvoiceId = invoiceId;

            return View(model);
        }

        public ActionResult TodayTransactions()
        {
            var model = GetReportModel("Sp_get_Today_Transactions", typeof(PrepaidTodayTransactionsViewModel), "/PrepaidReports/PrintTodayTransactions", a => MarkColumnsAsGroupable(a, "Cashier_ID"));

            return View(model);
        }

        public ActionResult AccountsInCollection()
        {
            var model = GetReportModel("SP_accountsInCollection", typeof(PrepaidAccountsInCollectionViewModel), "/PrepaidReports/PrintAccountInCollection", a => MarkColumnsAsGroupable(a, "Cashier_ID"));

            return View(model);
        }

        public ActionResult IppBrowser(DateTime? startDate = null, DateTime? endDate = null)
        {
            var model = GetReportModel("SP_ippBrowser", typeof(IppBrowserResultViewModel), "/PrepaidReports/PrintIppBrowser");
            
            if (startDate != null) model.DateRange.StartDate = (DateTime)startDate;
            if (endDate != null) model.DateRange.EndDate = (DateTime)endDate;

            return View(model);
        }

        public ActionResult MerchantCreditLimits()
        {
            var model = GetReportModel("sp_GetMerchantCreditLimits", typeof(MerchantCreditLimitResultViewModel), "/PrepaidReports/PrintMerchantCreditLimits");
            
            return View(model);
        }

        public ActionResult MerchantCommissions()
        {
            var model = GetReportModel("sp_GetMerchantCommissionsProfile", typeof(MerchantCommissionsResultViewModel), "/PrepaidReports/PrintMerchantComissions");
            
            ViewBag.Merchants = GetMerchants().ToList();

            return View(model);
        }

        public ActionResult MerchantStatements()
        {
            var model = GetReportModel("Sp_GetMerchantStatement", typeof(MerchantStatementResult), "/PrepaidReports/PrintMerchantStatements");
            
            ViewBag.Merchants = GetMerchants().ToList();

            return View(model);
        }

        public ActionResult TransactionsSummary()
        {
            var model = GetReportModel("Sp_TransactionsSummary", typeof(TransactionSummaryViewModel), "/PrepaidReports/PrintTransactionsSummary", a => MarkColumnsAsGroupable(a, "Store", "Store_Name", "Product", "Type", "Cahier_id"));
            return View(model);
        }

        public ActionResult FullcargaStatements()
        {
            var model = GetReportModel("SP_Fullcarga_Statetement", typeof(FullcargaStatementsViewModel), "/PrepaidReports/PrintFullcargaStatement", a =>
            {
                MarkColumnsAsGroupable(a, "Billed_Name");
                AddLinksToFullCargaInvoiceColumnConfig(a);
            });

            return View(model);

        }

        public ActionResult FullcargaInvoiceDetails(int invoiceId)
        {
            var model = GetReportModel("SP_Fullcarga_DetailInvoice", typeof(FullcargaInvoiceDetailViewModel), "/PrepaidReports/PrintInvoiceDetails");
            
            ViewBag.InvoiceId = invoiceId;

            return View(model);
        }

        public ActionResult FullcargaPrepaidSummary()
        {
            var model = GetReportModel("SP_Fullcarga_PrepaidSalesSummary", typeof(FullcargaPrepaidSummaryViewModel), "/PrepaidReports/PrintFullcargaPrepaidSummary", a => MarkColumnsAsGroupable(a, "Store_Name", "Type"));
            return View(model);
        }

        private VirtualOfficeReportModel ReportAgentSummary()
        {
            var model = GetReportModel("SP_Pos_GetSalesAgentMerchantSales_WithACHNew_2", typeof(SalesAgentMerchantSalesResultViewModel), "/PrepaidReports/PrintReportAgentSummary", AddLinksToReportAgentSummaryColumnConfig);
            return model;
        }

        public ActionResult MerchantBilling()
        {
            var model = GetReportModel("SP_Send_AgentToBillMerchants", typeof(AgentToBillMerchantsViewModel), "/PrepaidReports/PrintMerchantBilling");
            
            return View(model);
        }

        public ActionResult SendCommissionReport()
        {
            var model = GetReportModel("SP_Send_CommissionReport", typeof(CommissionReportViewModel), "/PrepaidReports/PrintCommissionReport");

            return View(model);
        }

        #endregion

        #region Data Manipulation
        [HttpPost]
        public ActionResult RunPortfolioSummary([DataSourceRequest] DataSourceRequest request, string outPut, bool saveOutPut, int? alertsMode, int status = -1)
        {
            try
            {
                if (saveOutPut)
                {
                    var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                    _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "sp_report_portfolio_summary", outPutDeserialized.GetCommaSeparatedTokens());
                }

                var reportData = _virtualOfficeService.RunPrepaidPortfolioSummary(GetLoggedUserId());


                switch (status)
                {
                    case 1:
                        reportData = reportData.Where(c => c.UserStatus == UserStatus.Active);
                        break;
                    case 0:
                        reportData = reportData.Where(c => c.UserStatus == UserStatus.Suspended || c.UserStatus == UserStatus.Close);
                        break;
                }



                if (alertsMode.HasValue && alertsMode.Value != 0)//Filters just accounts with Alerts
                {
                    reportData =
                        reportData.Where(
                            c =>
                                c.UserStatus == UserStatus.Suspended || (c.UserStatus == UserStatus.Close && decimal.Parse(c.Balance, NumberStyles.Currency) > 0) ||
                                c.compliance.HasValue && c.compliance.Value);
                }

                var mappedResult = reportData.MapTo<IEnumerable<PrepaidPortfolioResult>, IEnumerable<PrepaidPortfolioSummaryResultViewModel>>().ToList();

                var result = mappedResult.ToDataSourceResult(request);

                _virtualOfficeService.LogReportResult(GetLoggedUserId().ToString(), "Prepaid Portfolio Summary", mappedResult.Count(), Utils.MaximunReportCount);

                return Json(result);
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult RunSalesSummary([DataSourceRequest] DataSourceRequest request, DateTime startDate, DateTime endDate, string outPut, bool saveOutPut)
        {
            if (saveOutPut)
            {
                var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "sp_report_general_sales_summary", outPutDeserialized.GetCommaSeparatedTokens());
            }

            var reportData = _virtualOfficeService.RunPrepaidSalesSummary(GetLoggedUserId(), startDate, endDate);

            var mappedResult = reportData.MapTo<IEnumerable<PrepaidSalesSummaryResult>, IEnumerable<PrepaidSalesSummaryResultViewModel>>();

            var result = mappedResult.ToDataSourceResult(request);

            return Json(result);
        }

        [HttpPost]
        public ActionResult RunSalesDetails([DataSourceRequest] DataSourceRequest request, DateTime startDate, DateTime endDate, string outPut, bool saveOutPut, int merchantId = 0)
        {
            if (saveOutPut)
            {
                var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "sp_report_sales_details", outPutDeserialized.GetCommaSeparatedTokens());
            }

            var reportData = _virtualOfficeService.RunPrepaidSalesDetails(merchantId, startDate, endDate);

            var mappedResult = reportData.MapTo<IEnumerable<PrepaidSalesDetailsResult>, IEnumerable<PrepaidSalesDetailsResultViewModel>>();

            var result = mappedResult.ToDataSourceResult(request);

            return Json(result);
        }

        [HttpPost]
        public ActionResult RunFullcargaPrepaidSummary([DataSourceRequest] DataSourceRequest request, DateTime startDate, DateTime endDate, string outPut, bool saveOutPut)
        {
            if (saveOutPut)
            {
                var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "SP_Fullcarga_PrepaidSalesSummary", outPutDeserialized.GetCommaSeparatedTokens());
            }

            var userIsMerchant = GetUserCategory() == Category.Merchant;

            var reportData = _virtualOfficeService.GetFullcargaPrepaidSummary(GetLoggedUserId(), userIsMerchant, startDate, endDate);

            var mappedResult = reportData.MapTo<IEnumerable<FullcargaPrepaidSummary>, IEnumerable<FullcargaPrepaidSummaryViewModel>>();

            var result = mappedResult.ToDataSourceResult(request);

            return Json(result);
        }

        [HttpPost]
        public ActionResult RunInvoiceDetails([DataSourceRequest] DataSourceRequest request, string outPut, bool saveOutPut, int invoiceId = 0)
        {
            if (saveOutPut)
            {
                var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "sp_report_invoice_details", outPutDeserialized.GetCommaSeparatedTokens());
            }

            var reportData = _virtualOfficeService.RunPrepaidInvoiceDetails(invoiceId);

            var mappedResult = reportData.MapTo<IEnumerable<PrepaidInvoiceDetailsResult>, IEnumerable<PrepaidInvoiceDetailsResultViewModel>>();

            var result = mappedResult.ToDataSourceResult(request);

            return Json(result);
        }

        [HttpPost]
        public ActionResult RunTodayTransactions([DataSourceRequest] DataSourceRequest request, string outPut, bool saveOutPut)
        {
            try
            {
                if (saveOutPut)
                {
                    var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                    _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "GetTodayTransactions", outPutDeserialized.GetCommaSeparatedTokens());
                }

                var userLevel = GetUserLevel();

                var agentId = userLevel != 0 ? GetLoggedUserId() : 0;
                var merchantId = userLevel == 0 ? GetLoggedUserId() : 0;

                var reportData = _virtualOfficeService.RunTodayTransactions(agentId, merchantId);

                var mappedResult = reportData.MapTo<IEnumerable<PrepaidTodayTransactionsResult>, IEnumerable<PrepaidTodayTransactionsViewModel>>();

                var result = mappedResult.ToDataSourceResult(request);

                return Json(result);
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        [HttpPost]
        public ActionResult RunAccountsInCollection([DataSourceRequest] DataSourceRequest request, string outPut, bool saveOutPut)
        {
            try
            {
                if (saveOutPut)
                {
                    var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                    _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "AccountsInCollection", outPutDeserialized.GetCommaSeparatedTokens());
                }

                var reportData = _virtualOfficeService.GetAccountsInCollection(GetLoggedUserId());

                var mappedResult = reportData.MapTo<IEnumerable<AccountsInCollectionResult>, IEnumerable<PrepaidAccountsInCollectionViewModel>>();

                var result = mappedResult.ToDataSourceResult(request);

                return Json(result);
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        [HttpPost]
        public ActionResult RunMerchantCreditLimits([DataSourceRequest] DataSourceRequest request, string outPut, bool saveOutPut)
        {
            try
            {
                if (saveOutPut)
                {
                    var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                    _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "GetMerchantCreditLimits", outPutDeserialized.GetCommaSeparatedTokens());
                }

                var userCategory = GetUserCategory();

                var reportData = userCategory == Category.Merchant ? _virtualOfficeService.GetMerchantCreditLimits(null, GetLoggedUserId()) :
                                                                   _virtualOfficeService.GetMerchantCreditLimits(GetLoggedUserId(), null);

                var mappedResult = reportData.MapTo<IEnumerable<GetMerchantCreditLimitsResult>, IEnumerable<MerchantCreditLimitResultViewModel>>();

                var result = mappedResult.ToDataSourceResult(request);

                return Json(result);
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        [HttpPost]
        public ActionResult RunIppBrowser([DataSourceRequest] DataSourceRequest request, DateTime startDate, DateTime endDate, string outPut, bool saveOutPut)
        {
            try
            {
                if (saveOutPut)
                {
                    var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                    _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "SP_ippBrowser", outPutDeserialized.GetCommaSeparatedTokens());
                }

                var userLevel = GetUserLevel();
                var agentId = userLevel != 0 ? GetLoggedUserId() : 0;
                var merchantId = userLevel == 0 ? GetLoggedUserId() : 0;

                var reportData = _virtualOfficeService.RunIppBrowser(agentId, merchantId, startDate, endDate);

                var mappedResult = reportData.MapTo<IEnumerable<IppBrowserResult>, IEnumerable<IppBrowserResultViewModel>>();

                var result = mappedResult.ToDataSourceResult(request);

                return Json(result);
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        [HttpPost]
        public ActionResult RunAccountRegister([DataSourceRequest] DataSourceRequest request, string startDate, string endDate, string outPut, bool saveOutPut)
        {
            try
            {
                if (saveOutPut)
                {
                    var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                    _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "SP_ShowAccountRegister", outPutDeserialized.GetCommaSeparatedTokens());
                }

                var agentType = GetLoggedAgentType();

                var reportData = _virtualOfficeService.RunAccountRegister(agentType, GetLoggedUserId(), startDate, endDate);

                var mappedResult = reportData.MapTo<IEnumerable<AccountRegisterResult>, IEnumerable<PrepaidAccountRegisterViewModel>>();

                var result = mappedResult.ToDataSourceResult(request);

                return Json(result);
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        [HttpPost]
        public ActionResult RunMerchantCommissions([DataSourceRequest] DataSourceRequest request, int? merchantId, string outPut, bool saveOutPut)
        {
            try
            {
                if (saveOutPut)
                {
                    var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                    _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "sp_GetttCommissionsProfile", outPutDeserialized.GetCommaSeparatedTokens());
                }

                var userLevel = GetUserLevel();
                var agentId = userLevel != 0 ? GetLoggedUserId() : 0;

                var reportData = _virtualOfficeService.GetMerchantComissions(agentId, merchantId);

                var mappedResult = reportData.MapTo<IEnumerable<MerchantComissionResult>, IEnumerable<MerchantCommissionsResultViewModel>>();

                var result = mappedResult.ToDataSourceResult(request);

                return Json(result);
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        [HttpPost]
        public ActionResult RunMerchantStatements([DataSourceRequest] DataSourceRequest request, string startDate, string endDate, int merchantId, string outPut, bool saveOutPut)
        {
            try
            {
                if (saveOutPut)
                {
                    var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                    _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "Sp_GetMerchantStatement", outPutDeserialized.GetCommaSeparatedTokens());
                }

                var reportData = _virtualOfficeService.GetMerchantStatements(merchantId, startDate, endDate);

                var mappedResult = reportData.MapTo<IEnumerable<MerchantStatementResult>, IEnumerable<MerchantStatementResultViewModel>>();

                var result = mappedResult.ToDataSourceResult(request);

                return Json(result);
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        [HttpPost]
        public ActionResult RunTransactionsSummary([DataSourceRequest] DataSourceRequest request, string startDate, string endDate, string outPut, bool saveOutPut)
        {
            try
            {
                if (saveOutPut)
                {
                    var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                    _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "Sp_TransactionsSummary", outPutDeserialized.GetCommaSeparatedTokens());
                }

                var dateRange = GetDateRange(startDate, endDate);

                var userIsMerchant = GetUserCategory() == Category.Merchant;

                var reportData = _virtualOfficeService.GetTransactionsSummary(GetLoggedUserId(), userIsMerchant, dateRange.StartDate, dateRange.EndDate);

                var mappedResult = reportData.MapTo<IEnumerable<TransactionSummaryResult>, IEnumerable<TransactionSummaryViewModel>>();

                var result = mappedResult.ToDataSourceResult(request);

                return Json(result);
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        [HttpPost]
        public ActionResult RunFullcargaStatement([DataSourceRequest] DataSourceRequest request, string startDate, string endDate, string outPut, bool saveOutPut)
        {
            try
            {
                if (saveOutPut)
                {
                    var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                    _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "SP_Fullcarga_Statetement", outPutDeserialized.GetCommaSeparatedTokens());
                }

                var dateRange = GetDateRange(startDate, endDate);

                var reportData = _virtualOfficeService.GetFullCargaStatements(GetLoggedUserId(), dateRange.StartDate, dateRange.EndDate);

                var mappedResult = reportData.MapTo<IEnumerable<FullCargaStatement>, IEnumerable<FullcargaStatementsViewModel>>();

                var result = mappedResult.ToDataSourceResult(request);

                return Json(result);
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        [HttpPost]
        public ActionResult RunFullcargaInvoiceDetails([DataSourceRequest] DataSourceRequest request, string outPut, bool saveOutPut, int invoiceId = 0)
        {
            if (saveOutPut)
            {
                var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "SP_Fullcarga_DetailInvoice", outPutDeserialized.GetCommaSeparatedTokens());
            }

            var userLevel = GetUserLevel();
            var userId = userLevel != 0 ? GetLoggedUserId() : 0;

            var reportData = _virtualOfficeService.GetFullcargarInvoiceDetail(invoiceId, userId);

            var mappedResult = reportData.MapTo<IEnumerable<FullcargaInvoiceDetail>, IEnumerable<FullcargaInvoiceDetailViewModel>>();

            var result = mappedResult.ToDataSourceResult(request);

            return Json(result);
        }


        [HttpPost]
        public ActionResult RunMerchantBilling([DataSourceRequest] DataSourceRequest request, string startDate, string endDate, string outPut, bool saveOutPut)
        {
            try
            {
                if (saveOutPut)
                {
                    var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                    _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "SP_Send_AgentToBillMerchants", outPutDeserialized.GetCommaSeparatedTokens());
                }

                var dateRange = GetDateRange(startDate, endDate);

                var reportData = _virtualOfficeService.GetMerchantBilling(GetLoggedUserId(), dateRange.StartDate, dateRange.EndDate);

                var mappedResult = reportData.MapTo<IEnumerable<AgentToBillMerchants>, IEnumerable<AgentToBillMerchantsViewModel>>();

                var result = mappedResult.ToDataSourceResult(request);

                return Json(result);
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        [HttpPost]
        public ActionResult RunSendCommitionReport([DataSourceRequest] DataSourceRequest request, string startDate, string endDate, string outPut, bool saveOutPut)
        {
            try
            {
                if (saveOutPut)
                {
                    var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                    _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "SP_Send_CommissionReport", outPutDeserialized.GetCommaSeparatedTokens());
                }

                var dateRange = GetDateRange(startDate, endDate);

                var reportData = _virtualOfficeService.SendCommitionReport(GetLoggedUserId(), dateRange.StartDate, dateRange.EndDate, GetUserCategory() == Category.Merchant);

                var mappedResult = reportData.MapTo<IEnumerable<CommissionReport>, IEnumerable<CommissionReportViewModel>>();

                var result = mappedResult.ToDataSourceResult(request);

                return Json(result);
            }
            catch (Exception exception)
            {
                return null;
            }

        }


        #endregion

        #region Print/Export Section
        public ActionResult PrintPortfolioSummary(bool exportMode, int? alertsMode)
        {
            var objParams = new object[] { GetLoggedUserId() };

            var procedureName = !alertsMode.HasValue || alertsMode == 0 ? "sp_report_portfolio_summary" :
                                                                          "sp_report_prepaid_portfolio_inAlert";
            var methodName = !alertsMode.HasValue || alertsMode == 0 ? "RunPrepaidPortfolioSummary" :
                                                                       "RunPrepaidPortfolioInAlert";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);

        }

        public ActionResult PrintSalesSummary(string startDate, string endDate, bool exportMode)
        {
            var dateRange = GetDateRange(startDate, endDate);

            var objParams = new object[] { GetLoggedUserId(), dateRange.StartDate, dateRange.EndDate };

            const string procedureName = "sp_report_general_sales_summary", methodName = "RunPrepaidSalesSummary";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);

        }

        public ActionResult PrintSalesDetails(int merchantId, bool exportMode)
        {
            var dateRange = GetLastDateRangeInSession();

            var objParams = new object[] { merchantId, dateRange.StartDate, dateRange.EndDate };

            const string procedureName = "sp_report_sales_details", methodName = "RunPrepaidSalesDetails";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);

        }

        public ActionResult PrintInvoiceDetails(int invoiceId, bool exportMode)
        {
            var objParams = new object[] { invoiceId };

            const string procedureName = "sp_report_invoice_details", methodName = "RunPrepaidInvoiceDetails";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);

        }

        public ActionResult PrintTodayTransactions(bool exportMode)
        {
            var objParams = new object[] { GetLoggedUserId() };

            const string procedureName = "GetTodayTransactions", methodName = "RunTodayTransactions";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);
        }

        public ActionResult PrintMerchantCreditLimits(bool exportMode)
        {
            var objParams = new object[] { GetLoggedUserId() };

            const string procedureName = "GetMerchantCreditLimits", methodName = "GetMerchantCreditLimits";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);
        }

        public ActionResult PrintIppBrowser(string startDate, string endDate, bool exportMode)
        {
            var dateRange = GetDateRange(startDate, endDate);

            var objParams = new object[] { GetLoggedUserId(), dateRange.StartDate, dateRange.EndDate };

            const string procedureName = "SP_ippBrowser", methodName = "RunIppBrowser";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);
        }

        public ActionResult PrintAccountInCollection(bool exportMode)
        {
            var objParams = new object[] { GetLoggedUserId() };

            const string procedureName = "AccountsInCollection", methodName = "GetAccountsInCollection";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);

        }
        public ActionResult PrintAccountRegister(string startDate, string endDate, bool exportMode)
        {
            var agentType = GetLoggedAgentType();

            var objParams = new object[] { agentType, GetLoggedUserId(), startDate, endDate };

            const string procedureName = "SP_ShowAccountRegister", methodName = "RunAccountRegister";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);
        }

        public ActionResult PrintMerchantComissions(int merchantId, bool exportMode)
        {
            var objParams = new object[] { GetLoggedUserId(), merchantId };

            const string procedureName = "sp_GetMerchantCommissionsProfile", methodName = "GetMerchantComissions";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);
        }

        public ActionResult PrintMerchantStatements(int merchantId, string startDate, string endDate, bool exportMode)
        {
            var objParams = new object[] { merchantId, startDate, endDate };

            const string procedureName = "Sp_GetMerchantStatement", methodName = "GetMerchantStatements";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);
        }

        public ActionResult PrintTransactionsSummary(string startDate, string endDate, bool exportMode)
        {
            var dateRange = GetDateRange(startDate, endDate);

            var objParams = new object[] { GetLoggedUserId(), dateRange.StartDate, dateRange.EndDate };

            const string procedureName = "Sp_TransactionsSummary", methodName = "GetTransactionsSummary";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);
        }

        public ActionResult PrintFullcargaStatement(string startDate, string endDate, bool exportMode)
        {
            var dateRange = GetDateRange(startDate, endDate);

            var objParams = new object[] { GetLoggedUserId(), dateRange.StartDate, dateRange.EndDate };

            const string procedureName = "SP_Fullcarga_Statetement", methodName = "GetFullCargaStatements";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);
        }

        public ActionResult PrintFullcargaPrepaidSummary(string startDate, string endDate, bool exportMode)
        {
            var dateRange = GetDateRange(startDate, endDate);

            var userIsMerchant = GetUserCategory() == Category.Merchant;

            var objParams = new object[] { GetLoggedUserId(), userIsMerchant, dateRange.StartDate, dateRange.EndDate };

            const string procedureName = "SP_Fullcarga_PrepaidSalesSummary", methodName = "GetFullcargaPrepaidSummary";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);
        }

        public ActionResult PrintReportAgentSummary(string startDate, string endDate, bool exportMode)
        {
            var dateRange = GetDateRange(startDate, endDate);

            var objParams = new object[] { GetLoggedUserId(), dateRange.StartDate, dateRange.EndDate };

            const string procedureName = "SP_Pos_GetSalesAgentMerchantSales_WithACHNew_2", methodName = "RunReportAgentSummary";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);
        }

        public ActionResult PrintFullcargaInvoiceDetails(int invoiceId, bool exportMode)
        {
            var userLevel = GetUserLevel();
            var userId = userLevel != 0 ? GetLoggedUserId() : 0;

            var objParams = new object[] { invoiceId, userId };

            const string procedureName = "SP_Fullcarga_DetailInvoice", methodName = "GetFullcargarInvoiceDetail";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);

        }

        public ActionResult PrintMerchantBilling(string startDate, string endDate, bool exportMode)
        {
            var dateRange = GetDateRange(startDate, endDate);

            var objParams = new object[] { GetLoggedUserId(), dateRange.StartDate, dateRange.EndDate };

            const string procedureName = "SP_Send_AgentToBillMerchants", methodName = "GetMerchantBilling";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);
        }

        public ActionResult PrintCommissionReport(string startDate, string endDate, bool exportMode)
        {
            var dateRange = GetDateRange(startDate, endDate);

            var objParams = new object[] { GetLoggedUserId(), dateRange.StartDate, dateRange.EndDate , GetUserCategory() == Category.Merchant };

            const string procedureName = "SP_Send_CommissionReport", methodName = "SendCommitionReport";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);
        }


        #endregion

        #region Aux Ops
        private void AddLinksToPrepaidSalesColumnConfig(Dictionary<string, ColumnConfig> columnsConfig)
        {
            var salesDetailsLink = GetPrepaidSalesLink("SalesDetails", "GrSalesTOT");

            Utils.AddLinkToColumnsConfig(columnsConfig, "GrSalesTOT", salesDetailsLink);
        }

        private string GetPrepaidSalesLink(string url, string columnName, bool isNumeric = false)
        {
            var numericPrefix = isNumeric ? "$" : string.Empty;

            var mainPath = "/PrepaidReports/" + url;

            var dataTemplate = "<a href='" + mainPath + string.Format("?merchantId=#=mid#") + "'>" + numericPrefix + "#=" + columnName + "#" + "</a>";

            return dataTemplate;
        }

        private void AddLinksToPrepaidInvoiceColumnConfig(Dictionary<string, ColumnConfig> columnsConfig)
        {
            var invoiceDetailsLink = GetPrepaidInvoiceLink("InvoiceDetails", "inv_id");

            Utils.AddLinkToColumnsConfig(columnsConfig, "inv_id", invoiceDetailsLink);
        }

        private void AddLinksToReportAgentSummaryColumnConfig(Dictionary<string, ColumnConfig> columnsConfig)
        {
            /*implement*/   
        }

        private void AddLinksToFullCargaInvoiceColumnConfig(Dictionary<string, ColumnConfig> columnsConfig)
        {
            var invoiceDetailsLink = GetFullcargaInvoiceLink("FullcargaInvoiceDetails", "Invoice");

            Utils.AddLinkToColumnsConfig(columnsConfig, "Invoice", invoiceDetailsLink);
        }

        private string GetFullcargaInvoiceLink(string url, string columnName, bool isNumeric = false)
        {
            var numericPrefix = isNumeric ? "$" : string.Empty;

            var mainPath = "/PrepaidReports/" + url;

            var dataTemplate = "<a href='" + mainPath + string.Format("?invoiceId=#=Invoice#") + "'>" + numericPrefix + "#=" + columnName + "#" + "</a>";

            return dataTemplate;
        }

        private string GetPrepaidInvoiceLink(string url, string columnName, bool isNumeric = false)
        {
            var numericPrefix = isNumeric ? "$" : string.Empty;

            var mainPath = "/PrepaidReports/" + url;

            var dataTemplate = "<a href='" + mainPath + string.Format("?invoiceId=#=inv_id#") + "'>" + numericPrefix + "#=" + columnName + "#" + "</a>";

            return dataTemplate;
        }

        private IEnumerable<SelectListItem> GetMerchants()
        {
            var userCategory = GetUserCategory();

            var result = userCategory == Category.Merchant ? GetSelfUser() : GetOptionsForUser();

            return result;
        }

        private IEnumerable<SelectListItem> GetOptionsForUser()
        {
            var result = new List<SelectListItem>();

            var prepaidAccounts = _virtualOfficeService.RunPrepaidPortfolioSummary(GetLoggedUserId()).ToList();

            if (prepaidAccounts.Any())
            {
                var prepaids = prepaidAccounts.Select(p => new SelectListItem
                {
                    Text = p.business_name,
                    Value = p.MID.ToString()
                });

                result.AddRange(prepaids);

                return result;
            }

            return result;
        }

        private IEnumerable<SelectListItem> GetSelfUser()
        {
            var user = GetCurrentUser();

            return new List<SelectListItem>
             {
                 new SelectListItem
                 {
                     Text = user.Name,
                     Value = user.UserId.ToString()
                 }
             };
        }

        private void MarkColumnsAsGroupable(Dictionary<string, ColumnConfig> columnConfig, params string[] columns)
        {
            foreach (var column in columns)
            {
                if (columnConfig.ContainsKey(column))
                {
                    columnConfig[column].Groupable = true;
                }
            }
        }

        private Dictionary<string, Dictionary<string, List<SalesAgentMerchantSalesResultViewModel>>> GetReportAgentSummaryData(IEnumerable<SalesAgentMerchantSalesResultViewModel> source)
        {
            var activeAccounts = source.Where(a => !a.IsClosed && !a.compliance && !a.suspended && !a.isCollection).OrderBy(m => m.Mer_Name);
            var closedAccounts = source.Where(a => a.IsClosed).OrderBy(m => m.Mer_Name);
            var complianceAccounts = source.Where(a => !a.IsClosed && a.compliance  && !a.isCollection || (!a.IsClosed && a.suspended)).OrderBy(m => m.Mer_Name);
            var collectionAccounts = source.Where(a => !a.IsClosed && a.isCollection).OrderBy(m => m.Mer_Name);
            var total = new Dictionary<string, List<SalesAgentMerchantSalesResultViewModel>> {
                { "TOTALS" , new List<SalesAgentMerchantSalesResultViewModel> { new SalesAgentMerchantSalesResultViewModel {
                    PrepaidTotal = source.Sum(p => p.PrepaidTotal),
                    CellularTotal = source.Sum(p => p.CellularTotal),
                    TotalOtherProducts = source.Sum(p => p.TotalOtherProducts),
                    GeneralTotal = source.Sum(p => p.GeneralTotal),
                    GeneralDiscount = source.Sum(p => p.GeneralDiscount),
                    FeesDebitCreditSales = source.Sum(p => p.FeesDebitCreditSales),
                    GeneralNet = source.Sum(p => p.GeneralNet),
                    AgentDiscount = source.Sum(p => p.AgentDiscount),
                    CurrentBalance = source.Sum(p => p.CurrentBalance),
                }  } }
            };

            var activeSubsections = new Dictionary<string, List<SalesAgentMerchantSalesResultViewModel>>()
            {
                { "POS", activeAccounts.Where(m => m.MerType == 0).ToList() },
                { "TnB", activeAccounts.Where(m => m.MerType == 3).ToList() },
                { "Portal", activeAccounts.Where(m => m.MerType == 1).ToList() },
                { "TnB.com", activeAccounts.Where(m => m.MerType == 4).ToList() },
                { "OK Pinless", activeAccounts.Where(m => m.MerType == 6).ToList() }
            };
            var closeSubsections = new Dictionary<string, List<SalesAgentMerchantSalesResultViewModel>>()
            {
                { "POS", closedAccounts.Where(m => m.MerType == 0).ToList() },
                { "TnB", closedAccounts.Where(m => m.MerType == 3).ToList() },
                { "Portal", closedAccounts.Where(m => m.MerType == 1).ToList() },
                { "TnB.com", closedAccounts.Where(m => m.MerType == 4).ToList() },
            };
            var complianceSubsections = new Dictionary<string, List<SalesAgentMerchantSalesResultViewModel>>()
            {
                { "POS", complianceAccounts.Where(m => m.MerType == 0).ToList() },
                { "TnB", complianceAccounts.Where(m => m.MerType == 3).ToList() },
                { "Portal", complianceAccounts.Where(m => m.MerType == 1).ToList() },
                { "TnB.com", complianceAccounts.Where(m => m.MerType == 4).ToList() },
            };
            var collectionSubsections = new Dictionary<string, List<SalesAgentMerchantSalesResultViewModel>>()
            {
                { "POS", collectionAccounts.Where(m => m.MerType == 0).ToList() },
                { "TnB", collectionAccounts.Where(m => m.MerType == 3).ToList() },
                { "Portal", collectionAccounts.Where(m => m.MerType == 1).ToList() },
                { "TnB.com", collectionAccounts.Where(m => m.MerType == 4).ToList() },
            };
            var sections = new Dictionary<string, Dictionary<string, List<SalesAgentMerchantSalesResultViewModel>>>()
            {
                { "ACTIVE ACCOUNTS" , activeSubsections },
                { "CLOSED ACCOUNTS" , closeSubsections },
                { "COMPLIANCE ACCOUNTS" , complianceSubsections },
                { "COLLECTION  ACCOUNTS" , collectionSubsections },
                { "" , total },
            };

            return sections;
        }

        #endregion

        [HttpPost]
        public ActionResult UpdateCreditLimit([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<MerchantCreditLimitResultViewModel> creditLimits)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = creditLimits.Aggregate(true, (current, credit) => current && _virtualOfficeService.UpdateCreditLimit(credit.merchant_pk, credit.dailylimit_max, credit.creditlimit_max));
                    return Json(new { Success = result });
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                return Json(new { Success = false }); ;
            }
        }

        [HttpPost]
        public ActionResult UpdatePrepaidAcountStatus([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<PrepaidPortfolioSummaryResultViewModel> prepaidAccounts)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = prepaidAccounts.Aggregate(true, (current, account) => current && _virtualOfficeService.UpdatePrepaidAcountStatus(account.MID, account.Status == "ACTIVE" ? 1 : account.Status == "CLOSED" ? 2 : 0));
                    return Json(new { Success = result });
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                return Json(new { Success = false }); ;
            }
        }

        public ActionResult ReportAgentSummary(DateTime? startDate, DateTime? endDate)
        {
            var initDte = startDate == null ? new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1) : (DateTime)startDate;
            var endDte = endDate == null ? DateTime.Today : (DateTime)endDate;
            SaveLastDateRangeInSession(initDte, endDte);

            var reportData = _virtualOfficeService.RunReportAgentSummary(GetLoggedUserId(), initDte, endDte);

            var mappedResult = reportData.MapTo<IEnumerable<SalesAgentMerchantSalesResult>, IEnumerable<SalesAgentMerchantSalesResultViewModel>>();

            var model = ReportAgentSummary();

            ViewBag.Data = GetReportAgentSummaryData(mappedResult);

            return View(model);
        }

    }
}