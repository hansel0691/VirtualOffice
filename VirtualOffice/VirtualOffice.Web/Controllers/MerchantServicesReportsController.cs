using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using ApiRestClient.Infrastructure;
using ClassLibrary2.Domain;
using ClassLibrary2.Domain.Equality_Comparers;
using ClassLibrary2.Domain.MerchantServices;
using ClassLibrary2.Domain.Prepaid;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using VirtualOffice.Service.Domain;
using VirtualOffice.Service.Services;
using VirtualOffice.Web.Infrastructure;
using VirtualOffice.Web.Models;
using VirtualOffice.Web.Models.NewReports;
using VirtualOffice.Web.Models.NewReports.MerchantServices;
using WebMatrix.WebData;

namespace VirtualOffice.Web.Controllers
{
    [Authorize(Roles = "User")]
    public class MerchantServicesReportsController : VirtualOfficeController
    {

        #region Report Entry Points

        public MerchantServicesReportsController(IWebClient webClient) : base(webClient)
        {
        }

        public ActionResult PortfolioSummary()
        {
            var columnsConfig = GetUserReportColumnsConfig(GetLoggedUserId(), "sp_report_msv_portfolio_summary");

            const string printLink = "/MerchantServicesReports/PrintMsPortfolioSummary";

            var model = GetReportModel(columnsConfig, printLink, "sp_report_msv_portfolio_summary");

            return View(model);
        }

        public ActionResult SalesSummary()
        {
            var columnsConfig = GetUserReportColumnsConfig(GetLoggedUserId(), "sp_report_msv_commission_summary",
                                                           typeof(MsComissionSummaryResultViewModel));

            AddLinksToColumnConfig(columnsConfig);

            const string printLink = "/MerchantServicesReports/PrintCommissionSummary";

            var model = GetReportModel(columnsConfig, printLink, "sp_report_msv_commission_summary");

            return View(model);
        }

        public ActionResult MsComissionSummaryForAmex(int agentId, string startDate, string endDate)
        {
            var columnsConfig = GetUserReportColumnsConfig(GetLoggedUserId(), "sp_report_msv_commission_details_from_amex", typeof(MsComissionSummaryForAmexViewModel));

            const string printLink = "/MerchantServicesReports/PrintCommissionSummaryAmex";

            var model = GetReportModel(columnsConfig, printLink, "sp_report_msv_commission_details_from_amex");

            model.DateRange = GetDateRange(startDate, endDate);

            ViewBag.AgentId = agentId;

            return View(model);
        }

        public ActionResult MsComissionSummaryForVisaMasterCard(int agentId, string startDate, string endDate)
        {
            var columnsConfig = GetUserReportColumnsConfig(GetLoggedUserId(), "sp_report_msv_commission_details_from_visamc",
                                typeof(MsCommissionSummaryForVmCViewModel));

            const string printLink = "/MerchantServicesReports/PrintCommissionSummaryVmc";

            var model = GetReportModel(columnsConfig, printLink, "sp_report_msv_commission_details_from_visamc");

            model.DateRange = GetDateRange(startDate, endDate);

            ViewBag.AgentId = agentId;

            return View(model);
        }

        public ActionResult MsComissionSummaryForOthers(int agentId, string startDate, string endDate)
        {
            var columnsConfig = GetUserReportColumnsConfig(GetLoggedUserId(), "sp_report_msv_commission_details_from_other",
                                typeof(MsCommissionSummaryForOthersViewModel));

            const string printLink = "/MerchantServicesReports/PrintCommissionSummaryOther";

            var model = GetReportModel(columnsConfig, printLink, "sp_report_msv_commission_details_from_other");

            model.DateRange = GetDateRange(startDate, endDate);

            ViewBag.AgentId = agentId;

            return View(model);
        }

        public ActionResult MsComissionSummaryTotal(int agentId, string startDate, string endDate)
        {
            var columnsConfig = GetUserReportColumnsConfig(GetLoggedUserId(), "sp_report_msv_commission_details_by_totals",
                                                           typeof(MsCommissionSummaryByTotalsViewModel));

            const string printLink = "/MerchantServicesReports/PrintCommissionSummaryByTotals";

            var model = GetReportModel(columnsConfig, printLink, "sp_report_msv_commission_details_by_totals");

            model.DateRange = GetDateRange(startDate, endDate);

            ViewBag.AgentId = agentId;

            return View(model);
        }

        #endregion

        #region Data Manipulation
        [HttpPost]
        public ActionResult RunPortfolioSummary([DataSourceRequest] DataSourceRequest request,string outPut, bool saveOutPut)
        {
            if (saveOutPut)
            {
                var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "sp_report_msv_portfolio_summary", outPutDeserialized.GetCommaSeparatedTokens());
            }

            var userId = Roles.IsUserInRole(RolesEnum.Master.ToString())? 0: GetLoggedUserId();

            var reportData = _virtualOfficeService.RunMsPortfolioSummary(userId).ToList();

            var activeAccounts = reportData.Where(r => r.Status.HasValue && r.Status == 1);

            var mappedResult = activeAccounts.MapTo<IEnumerable<MsPortfolioResult>, IEnumerable<MsPortfolioResultViewModel>>().ToList();

            var result = mappedResult.ToDataSourceResult(request);

            _virtualOfficeService.LogReportResult(GetLoggedUserId().ToString(), "MS Portfolio Summary", mappedResult.Count(), Utils.MaximunReportCount);

            return Json(result);
        }

        [HttpPost]
        public ActionResult RunSalesSummary([DataSourceRequest] DataSourceRequest request, DateTime startDate, DateTime endDate, string outPut, bool saveOutPut)
        {
            if (saveOutPut)
            {
                var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "sp_report_msv_commission_summary", outPutDeserialized.GetCommaSeparatedTokens());
            }

            SaveLastDateRangeInSession(startDate, endDate);

            var reportData = _virtualOfficeService.RunMsComissionSummary(GetLoggedUserId(), startDate, endDate);

            var mappedResult = reportData.MapTo<IEnumerable<MsComissionSummaryResult>, IEnumerable<MsComissionSummaryResultViewModel>>();

            var result = mappedResult.ToDataSourceResult(request);

            return Json(result);
        }

        [HttpPost]
        public ActionResult RunComissionSummaryForAmex([DataSourceRequest] DataSourceRequest request, int? agentId, DateTime startDate, DateTime endDate, string outPut, bool saveOutPut)
        {
            try
            {
                if (saveOutPut)
                {
                    var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                    _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "sp_report_msv_commission_details_from_amex", outPutDeserialized.GetCommaSeparatedTokens());
                }

                SaveLastDateRangeInSession(startDate, endDate);

                var agent = agentId.HasValue && agentId != 0 ? agentId.Value : GetLoggedUserId();

                var reportData = _virtualOfficeService.RunMsComissionDetailsForAmex(agent,startDate, endDate);

                var mappedResult = reportData.MapTo<IEnumerable<MsComissionSummaryForAmex>, IEnumerable<MsComissionSummaryForAmexViewModel>>();

                var result = mappedResult.ToDataSourceResult(request);

                return Json(result);
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        [HttpPost]
        public ActionResult RunComissionSummaryForVmC([DataSourceRequest] DataSourceRequest request, int? agentId, DateTime startDate, DateTime endDate, string outPut, bool saveOutPut)
        {
            try
            {
                if (saveOutPut)
                {
                    var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                    _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "sp_report_msv_commission_details_from_visamc", outPutDeserialized.GetCommaSeparatedTokens());
                }

                SaveLastDateRangeInSession(startDate, endDate);

                var agent = agentId.HasValue && agentId != 0 ? agentId.Value : GetLoggedUserId();

                var reportData = _virtualOfficeService.RunMsComissionDetailsForVmC(agent, startDate, endDate);

                var mappedResult = reportData.MapTo<IEnumerable<MsCommssionSummaryForVmC>, IEnumerable<MsCommissionSummaryForVmCViewModel>>();

                var result = mappedResult.ToDataSourceResult(request);

                return Json(result);
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        [HttpPost]
        public ActionResult RunComissionSummaryForOthers([DataSourceRequest] DataSourceRequest request, int? agentId,  DateTime startDate, DateTime endDate, string outPut, bool saveOutPut)
        {
            try
            {
                if (saveOutPut)
                {
                    var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                    _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "sp_report_msv_commission_details_from_other", outPutDeserialized.GetCommaSeparatedTokens());
                }

                SaveLastDateRangeInSession(startDate, endDate);

                var agent = agentId.HasValue && agentId != 0 ? agentId.Value : GetLoggedUserId();

                var reportData = _virtualOfficeService.RunMsComissionDetailsForOthers(agent, startDate, endDate);

                var mappedResult = reportData.MapTo<IEnumerable<MsCommsissionSummaryForOthers>, IEnumerable<MsCommissionSummaryForOthersViewModel>>();

                var result = mappedResult.ToDataSourceResult(request);

                return Json(result);
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        [HttpPost]
        public ActionResult RunComissionSummaryTotal([DataSourceRequest] DataSourceRequest request, int? agentId, DateTime startDate, DateTime endDate, string outPut, bool saveOutPut)
        {
            try
            {
                if (saveOutPut)
                {
                    var outPutDeserialized = new JavaScriptSerializer().Deserialize<List<string>>(outPut);

                    _virtualOfficeService.UpdateUserReportOutPut(GetLoggedUserId(), "sp_report_msv_commission_details_by_totals", outPutDeserialized.GetCommaSeparatedTokens());
                }

                SaveLastDateRangeInSession(startDate, endDate);

                var agent = agentId.HasValue && agentId != 0 ? agentId.Value : GetLoggedUserId();

                var reportData = _virtualOfficeService.RunMsComissionDetailsByTotals(agent, startDate, endDate).Distinct(new MsComissionSummaryByTotalsComparer());

                var mappedResult = reportData.MapTo<IEnumerable<MsCommissionSummaryByTotals>, IEnumerable<MsCommissionSummaryByTotalsViewModel>>();

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
        #endregion

        #region Aux Ops

        #region Link Definitions

        private void AddLinksToColumnConfig(Dictionary<string, ColumnConfig> columnsConfig)
        {
            var amexLink = GetMsComissionSummaryLink("MsComissionSummaryForAmex", "amex_commission", true);
            var visaMasterCardLink = GetMsComissionSummaryLink("MsComissionSummaryForVisaMasterCard", "vmc_commission", true);
            var othersLink = GetMsComissionSummaryLink("MsComissionSummaryForOthers", "oth_commission", true);
            var totalsLink = GetMsComissionSummaryLink("MsComissionSummaryTotal", "tot_commission", true);

            Utils.AddLinkToColumnsConfig(columnsConfig, "amex_commission", amexLink);
            Utils.AddLinkToColumnsConfig(columnsConfig, "vmc_commission", visaMasterCardLink);
            Utils.AddLinkToColumnsConfig(columnsConfig, "oth_commission", othersLink);
            Utils.AddLinkToColumnsConfig(columnsConfig, "tot_commission", totalsLink);
        }

        private string GetMsComissionSummaryLink(string url, string columnName, bool isNumeric= false)
        {
            var numericPrefix = isNumeric ? "$" : string.Empty;

            var mainPath = "/MerchantServicesReports/" + url;

            var dataTemplate = "<a href='" + mainPath + string.Format("?agentId=#=code#&startDate=#=begindate#&endDate=#=enddate#") + "'>" + numericPrefix + "#=" + columnName +"#" +"</a>";

            return dataTemplate;   
        }

       

        #endregion

        #endregion

        #region Print Section

        public ActionResult PrintMsPortfolioSummary(bool exportMode)
        {
            var objParams = new object[] {GetLoggedUserId()};

            const string procedureName = "sp_report_msv_portfolio_summary", methodName = "RunMsPortfolioSummary";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);
            
        }
        public ActionResult PrintCommissionSummary(string startDate, string endDate, bool exportMode)
        {
            var dateRange = GetDateRange(startDate, endDate);

            var objParams = new object[] {GetLoggedUserId(), dateRange.StartDate, dateRange.EndDate};

            const string procedureName = "sp_report_msv_commission_summary", methodName = "RunMsComissionSummary";

            return exportMode? ExportReportsToExcel(procedureName,methodName, objParams):
                               PrintReport(procedureName, methodName, objParams);
        }
        public ActionResult PrintCommissionSummaryAmex(string startDate, string endDate, bool exportMode)
        {
            var dateRange = GetDateRange(startDate, endDate);

            var objParams = new object[] { GetLoggedUserId(), dateRange.StartDate, dateRange.EndDate };

            const string procedureName = "sp_report_msv_commission_details_from_amex", methodName = "RunMsComissionDetailsForAmex";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                                PrintReport(procedureName, methodName, objParams);
        }
        public ActionResult PrintCommissionSummaryVmc(string startDate, string endDate, bool exportMode)
        {
            var dateRange = GetDateRange(startDate, endDate);

            var objParams = new object[] { GetLoggedUserId(), dateRange.StartDate, dateRange.EndDate };

            const string procedureName = "sp_report_msv_commission_details_from_visamc", methodName = "RunMsComissionDetailsForVmC";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                              PrintReport(procedureName, methodName, objParams);
        }
        public ActionResult PrintCommissionSummaryOther(string startDate, string endDate, bool exportMode)
        {
            var dateRange = GetDateRange(startDate, endDate);

            var objParams = new object[] { GetLoggedUserId(), dateRange.StartDate, dateRange.EndDate };

            const string procedureName = "sp_report_msv_commission_details_from_other", methodName = "RunMsComissionDetailsForOthers";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                              PrintReport(procedureName, methodName, objParams);
        }
        public ActionResult PrintCommissionSummaryByTotals(string startDate, string endDate, bool exportMode)
        {
            var dateRange = GetDateRange(startDate, endDate);

            var objParams = new object[] { GetLoggedUserId(), dateRange.StartDate, dateRange.EndDate };

            const string procedureName = "sp_report_msv_commission_details_by_totals", methodName = "RunMsComissionDetailsByTotals";

            return exportMode ? ExportReportsToExcel(procedureName, methodName, objParams) :
                              PrintReport(procedureName, methodName, objParams);
        }

        #endregion

        #region Config
     
        #endregion
    }
}