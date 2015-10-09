using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.WebPages;
using ClassLibrary2.Domain;
using Domain.Models;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.Ajax.Utilities;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using VirtualOffice.Service.Services;
using VirtualOffice.Web.Infrastructure;
using VirtualOffice.Web.Models;
using ApiRestClient.Infrastructure;
using RestSharp;
using FilterType = Domain.Models.FilterType;
using Incident = ClassLibrary2.Domain.Others.Incident;
using Lead = ClassLibrary2.Domain.Others.Lead;

namespace VirtualOffice.Web.Controllers
{
    [Authorize(Roles = "User")]
    public class ReportsController : VirtualOfficeController
    {
        private readonly IWebClient _webClient;
        #region Core Operations

        public ReportsController(IWebClient webClient) : base(webClient)
        {
        }

        public ActionResult Index()
        {

            var user = GetCurrentUser();

            var userCategory = GetUserCategory();

            if (userCategory == Category.Merchant)
                return RedirectToAction("TodayTransactions", "PrepaidReports");
            
            if (user.IsFullcarga)
                return RedirectToAction("PortfolioSummary", "PrepaidReports");

            //Dash Only Available for Agents/Distributor and ISO's
            var clouds = GetDashboardItems(false);
            var openLeads = GetOpenLeadsForDashBoard();
            var openIncidents = GetOpenedIncidentesForDashboard();
            var reports = GetStandAloneUserReports(GetLoggedUserId());
            var marketingMaterials = GetMarketingMaterials();
            
            ViewBag.Reports = reports;
            ViewBag.Clouds = clouds;
            ViewBag.OpenLeads = openLeads.Count();
            ViewBag.OpenIncidents = openIncidents.Count();
            ViewBag.MarketingMaterials = marketingMaterials.Count();
            return View();
        }

        [HttpPost]
        public JsonResult GetDashboardItems()
        {
            var clouds = GetDashboardItems(true);

            var pairsResult = GetCloudsIdValuePairs(clouds);

            var result = pairsResult.Select(pair => new {pair.Key, pair.Value});

            return Json(result);
        }

        private Dictionary<string, string> GetCloudsIdValuePairs(IEnumerable<DashboardItem> clouds)
        {

            var result = new Dictionary<string, string>();

            foreach (var cloud in clouds)
            {
                var i = 0;

                //Forming a Key-Value composed by: (DashboadItem ID + continuos index, DashboardValue)
                foreach (var cloudItem in cloud.Items.Keys)
                {
                    var key = cloud.Id + i.ToString(); 
                    result.Add(key, cloud.Items[cloudItem]);
                    i++;
                }
            }

            return result;
        } 

        public ActionResult ExecuteReport(int reportId)
        {
            var report = GetUserReportWithData(reportId, GetLoggedUserId());

            ViewBag.Reports = GetStandAloneUserReports(GetLoggedUserId());

            if (report.IsNull() || report.Data.IsNullOrEmpty() || report.FiltersData.IsNullOrEmpty())
                return View("Error", new HandleErrorInfo(new Exception("There is no data in the report that you want to execute"), "Reports", "ExecuteReport"));
                
            //Getting last date range saved by the user
            var currentDateRange = GetLastDateRangeInSession();

            if (!currentDateRange.IsNull())
            {
                report.StartDate = currentDateRange.StartDate;
                report.EndDate = currentDateRange.EndDate;
            }

            return View("ReportViewer", report);
        }

        public ActionResult ReadReport([DataSourceRequest] DataSourceRequest request, int reportId, string filters, string outPut, bool saveFilters, bool saveOutPut, string startDate, string endDate)
        {
            try
            {
                var userFilterValues = !String.IsNullOrEmpty(filters) ? new JavaScriptSerializer().Deserialize<IEnumerable<FilterViewModel>>(filters).ToList() : null;

                var outPutResult = !(String.IsNullOrEmpty(outPut)) ? new JavaScriptSerializer().Deserialize<IEnumerable<string>>(outPut) : null;

                if (saveFilters)
                {
                    UpdateUserReportFilterConfiguration(reportId, GetLoggedUserId(), userFilterValues);
                    UpdateUserReportDates(reportId, GetLoggedUserId(), startDate, endDate);
                }

                if (saveOutPut)
                    UpdateUserReportOutPut(reportId, GetLoggedUserId(), outPutResult);

                //Saving last Date Range Used in Session
                SaveLastDateRangeInSession(startDate, endDate);

                //Recovering in-Session Arguments
                var arguments = GetInSesionArguments(reportId);

                //Adding Date Filters
                var dateArgs = GetDateFilterArguments(reportId, startDate, endDate).ToList();
                var argumentsResult = AddOrUpdateDateArguments(dateArgs, arguments);

                var actionResult = GetView(request, reportId, userFilterValues, argumentsResult);

                return actionResult;

            }
            catch (Exception exception)
            {
                return null;
            }

        }

        public ActionResult GetUserFilterOptions([DataSourceRequest] DataSourceRequest request, int reportId, string columnName)
        {
            try
            {
                var reportData = GetReportData(reportId, null);

                var distinctElements = Utils.GetDistinctElements(reportData, columnName.Replace(' ', '_'));

                return Json(distinctElements, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult UpdateUserReportFilterConfig(int reportId, string filters)
        {
            try
            {
                var userFilterValues = !String.IsNullOrEmpty(filters) ? new JavaScriptSerializer().Deserialize<IEnumerable<FilterViewModel>>(filters).ToList() : null;

                return UpdateUserReportFilterConfiguration(reportId, GetLoggedUserId(), userFilterValues);

            }
            catch (Exception)
            {

                return null;
            }
        }

        [HttpPost]
        public ActionResult FilterReport(int? reportId, List<string> userFilters)
        {
            return null;
        }

        public ActionResult ExecuteSubReport(SubReportParams  subReportParams)
        {
            var subReport = GetUserReport(subReportParams.SubReportId, GetLoggedUserId());

            var arguments = GetSubReportArguments(subReport, subReportParams);

            subReport.ExtraArguments = arguments;

            //Updating the last applied range date in case it comes from a SubReport Column Values 
            SaveLastDateRangeInSession(subReportParams.BeginDate, subReportParams.EndDate);

            //Saving the reportID and args associated with it so they can be retrieved further on
            SaveObjectInSession(subReportParams.SubReportId, arguments);

            ViewBag.Reports = GetStandAloneUserReports(GetLoggedUserId());

            IEnumerable<ExpandoObject> data;

            subReport.FiltersData = GetFiltersData(subReportParams.SubReportId, out data, arguments);

            subReport.Data = data;

            //Defining numeric columns
            var numericColumns = GetNumericColumnsForReport(subReportParams.SubReportId);

            subReport.Columns.ForEach(col => col.IsNumeric = numericColumns.Contains(col.Name));

            //Saving last date range saved by the user
            var currentDateRange = GetLastDateRangeInSession();
          
            if (!currentDateRange.IsNull())
            {
                subReport.StartDate = currentDateRange.StartDate;
                subReport.EndDate = currentDateRange.EndDate;
            }

            return View("ReportViewer", subReport);
        }

        [HttpPost]
        public ActionResult UpdateColumnWidth(int reportId, string columnName, int width)
        {
            try
            {
                var userReport = GetUserReport(reportId, GetLoggedUserId());

                var outputConfig = new JavaScriptSerializer().Deserialize<List<ReportColumn>>(userReport.OutputConfiguration);

                var column = outputConfig.FirstOrDefault(col => col.Name == columnName);

                if (!column.IsNull())
                {
                    column.Width = width;

                    var updatedOutputConfig = new JavaScriptSerializer().Serialize(outputConfig);

                    UpdateUserReportOutPutConfig(reportId, GetLoggedUserId(), updatedOutputConfig);
                }

                return Json(true);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        public JsonResult RefreshCloud(int reportId, int lastRowCount)
        {
            try
            {
                var reportCounts = RunUserReports(reportId);

                var rowCount = reportCounts.First();

                return Json(new { RowCount = rowCount });
            }
            catch (Exception exception)
            {
                return Json(new { RowCount = lastRowCount });
            }
        }

        [HttpPost]
        public ActionResult UpdateColumnOrder(int reportId, string columnName, int oldIndex, int newIndex)
        {
            try
            {
                var userReport = GetUserReport(reportId, GetLoggedUserId());

                var currentOutput = userReport.Output;

                var outputConfig = new JavaScriptSerializer().Deserialize<List<ReportColumn>>(userReport.OutputConfiguration);

                var column = outputConfig.FirstOrDefault(col => col.Name == columnName);

                if (!column.IsNull())
                {
                    //Right offset
                    if (newIndex > oldIndex)
                    {
                        foreach (var col in outputConfig.Where(colum => colum.Index <= newIndex && colum.Index > oldIndex))
                            col.Index--;
                    }
                    else
                    {
                        //Left offset
                        foreach (var col in outputConfig.Where(colum => colum.Index >= newIndex && colum.Index < oldIndex))
                            col.Index++;
                    }

                    column.Index = newIndex;

                    var updatedOutputConfig = new JavaScriptSerializer().Serialize(outputConfig);

                    UpdateUserReportOutPutConfig(reportId, GetLoggedUserId(), updatedOutputConfig);
                }

                return Json(true);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult UpdateReportConfiguration(int reportId, bool saveOnDesktop)
        {
            var updateResponse = UpdateReportConfiguration(reportId, GetLoggedUserId(), saveOnDesktop);
            var result = updateResponse ? Utils.Success : Utils.Error;
            var message = updateResponse ? Utils.Updated : Utils.Error;

            return Json(new { Result = result, Message = message });
        }

        public ActionResult ExportReportsToExcel(int reportId, string startDate = "", string endDate = "")
        {
            try
            {
                //Recovering in-Session Arguments
                var arguments = GetInSesionArguments(reportId);

                //Adding Date Filters
                var dateArgs = GetDateFilterArguments(reportId, startDate, endDate);

                (arguments).AddRange(dateArgs);

                var reportData = GetReportData(reportId, arguments);

                var reportMetadata = GetUserReport(reportId, GetLoggedUserId());

                var filteredData = FilterData(reportData, reportMetadata.UserFiltersConfig);

                reportMetadata.Data = filteredData;

                //getting the GridView ready to be exported
                var gridResult = reportMetadata.ExportToExcel(Session[Utils.NumericColumnsKey] as Dictionary<int, SortedSet<string>>);

                var fileName = String.Format("Report_{0}_{1}_{2}.xls", DateTime.Now.Day, DateTime.Now.Minute, DateTime.Now.Second);

                //Exporting the File to Excel
                return new ReportFileActionResult(gridResult, fileName);

            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public ActionResult PrintReport(int reportId, string startDate, string endDate)
        {
            //Recovering in-Session Arguments
            var arguments = GetInSesionArguments(reportId);

            //Adding Date Filters
            var dateArgs = GetDateFilterArguments(reportId, startDate, endDate);

            (arguments).AddRange(dateArgs);

            var reportData = GetReportData(reportId, arguments);

            var reportMetadata = GetUserReport(reportId, GetLoggedUserId());

            var filteredData = FilterData(reportData, reportMetadata.UserFiltersConfig);

            reportMetadata.Data = filteredData;

            return View(reportMetadata);
        }
        #endregion

        #region Aux Operations

        private List<Argument> AddOrUpdateDateArguments(List<Argument> currentDateArgs, List<Argument> argumentsInSession)
        {
            try
            {
                //currentDateArgs.ForEach(arg =>
                //{
                //    var searchArg = argumentsInSession.FirstOrDefault(a => a.Param.Name == arg.Param.Name);
                //    if (!searchArg.IsNull())
                //        arg.Value = searchArg.Value;
                //});

                //Adding date Arguments or overriding the values of the Arguments Named Equally
                argumentsInSession.ForEach(argument =>
                {
                    var dateArginArguments = currentDateArgs.FirstOrDefault(arg => arg.Param.Name == argument.Param.Name);

                    if (dateArginArguments.IsNull())
                        currentDateArgs.Add(argument);
                });

                return currentDateArgs;
            }
            catch (Exception exception)
            {
                return currentDateArgs;
            }
        }

        private List<Argument> GetSubReportArguments(UserReportViewModel subReport, SubReportParams subReportParams)
        {
            var predefinedFilters = subReport.PredefinedFilters;

            var argsResult = predefinedFilters.Where(pref => pref.Type == FilterType.Value).Select(predefinedFilter => new Argument(predefinedFilter.ParameterName, predefinedFilter.Value)).ToList();

            var indexArg = new Argument(subReportParams.IndexParamName, subReportParams.IndexParamValue);

            var columnNameFilter = predefinedFilters.FirstOrDefault(filter => filter.ColumnName == subReportParams.ColumnName);

            var columnNameArg = !columnNameFilter.IsNull() ? new Argument(columnNameFilter.ParameterName, subReportParams.ColumnValue) : null;

            argsResult.AddRange(new List<Argument> { indexArg, columnNameArg });

            return argsResult;
        }

        private List<Argument> GetDateFilterArguments(int reportId, DateTime startDate, DateTime endDate)
        {
            return GetDateFilterArguments(reportId, startDate.ToString(), endDate.ToString()).ToList();
        }

        private IEnumerable<Argument> GetDateFilterArguments(int reportId, string startDate, string endDate)
        {
            try
            {
                var report = GetReport(reportId);

                var reportParameters = report.Parameters;

                var startDateParameter = Utils.StartDateSubstring.MostAlike(reportParameters.Select(param => param.Name).ToList());

                var starDateArgument = new Argument(startDateParameter, startDate);

                var endDateParameter = Utils.EndDateSubstring.MostAlike(reportParameters.Select(param=> param.Name).ToList());

                var endDateArgument = new Argument(endDateParameter, endDate);

                return new List<Argument> { starDateArgument, endDateArgument };
            }
            catch (Exception)
            {

                return new List<Argument>();
            }
        }

        private IEnumerable<Argument> GetDateFilterArguments(int reportId,DateRange range)
        {
            return GetDateFilterArguments(reportId, range.StartDate.ToString(), range.EndDate.ToString());
        }

        private UserReportInfoModel GetUserReportParameters(UserReportViewModel userReportConfig, List<Argument> arguments = null)
        {
            try
            {
                if (!arguments.IsNull())
                    arguments = arguments.Where(arg => !arg.IsNull()).ToList();

                var reportParameters = userReportConfig.Parameters.ToList();

                //Recovering default parameters from ReportConfig
                var defaultParams = userReportConfig.ParamsDefaultConfiguration.Split(',');

                var argsResult = new List<Argument>();

                for (var i = 0; i < reportParameters.Count; i++)
                {
                    var reportParameter = reportParameters[i];


                    if (!arguments.IsNull() && arguments.Any(x => !x.IsNull()))
                    {
                        var argument = arguments.FirstOrDefault(arg => !arg.Param.IsNull() && arg.Param.Name == reportParameter.Name);

                        Argument newArg;

                        if (!argument.IsNull() && !argument.Value.IsNull())
                            newArg = argument;
                  
                        //Check if the parameter is ID type and there is no other parameter with the same name in the Args 
                        else if (reportParameter.Name.IsIdParameter())
                        {
                            var argumentId = arguments.FirstOrDefault(arg => !arg.Param.IsNull() && arg.Param.Name.IsIdParameter());

                            newArg = new Argument
                            {
                                Param = reportParameters[i],
                                Value = !argumentId.IsNull() && !argumentId.Value.IsNull() ? argumentId.Value : GetLoggedUserId()
                            };
                        }
                        else
                        {
                            newArg = new Argument
                            {
                                Param = reportParameter,
                                Value = defaultParams.TryGetValue(i)
                            };
                        }
                        argsResult.Add(newArg);
                    }
                    //Check if the parameter is ID type and there is no other parameter with the same name in the Args 
                    else if (reportParameter.Name.IsIdParameter())
                    {
                        argsResult.Add(new Argument
                        {
                            Param = reportParameters[i],
                            Value = GetLoggedUserId()
                        });
                    }
                    else
                    {
                        argsResult.Add(new Argument
                        {
                            Param = reportParameter,
                            Value = defaultParams.TryGetValue(i)
                        });
                    }
                }
                return new UserReportInfoModel
                {
                    Args = argsResult,
                    ReportId = userReportConfig.ReportId,
                    UserId = userReportConfig.UserId
                };
            }
            catch (Exception exception)
            {

                return null;
            }
        }

        private ActionResult GetView(DataSourceRequest request, int reportId, IEnumerable<FilterViewModel> userFilterValues, List<Argument> arguments)
        {
            var data = GetReportData(reportId, arguments);

            var filteredData = FilterData(data, userFilterValues);

            var dsres = filteredData.ToMyDataSourceResult(request);

            //var dataResult = MappingDataSourceResults(reportId, dsres);

            var serializer = new JavaScriptSerializer();

            serializer.RegisterConverters(new JavaScriptConverter[] { new ExpandoJsonConverter(), });

            var json = serializer.Serialize(dsres);

            return new MyJsonResult(json);
        }

        private IEnumerable<ExpandoObject> GetReportData(int reportId, List<Argument> arguments)
        {
            var report = GetUserReport(reportId, GetLoggedUserId());

            var executeReportRequestInfo = Utils.GetRequestInfo(Method.POST, "/api/Report/RunUserReport");

            var parameters = GetUserReportParameters(report, arguments);

            //Saving the args associated with this reportID
            SaveObjectInSession(reportId, arguments);

            var executionResponse = _webClient.Execute<List<Dictionary<string, object>>>(new JsonSerializer().Serialize(parameters), ApiUrls.API_KEY, ApiUrls.API_SECRET, executeReportRequestInfo);

            var table = GetTable(reportId, executionResponse);

            return table;

        }

        private IEnumerable<ExpandoObject> GetTable(int reportId, IEnumerable<Dictionary<string, object>> reportData)
        {
            var tableResult = new List<ExpandoObject>();
            foreach (var row in reportData)
            {
                dynamic newRow = new ExpandoObject();

                foreach (var rowProperties in row)
                {
                    var propertyName = rowProperties.Key.Replace(' ', '_');
                    var propertyValue = rowProperties.Value;

                    //Trying to parse the value if it is numeric 
                    double numericValueIfAny = 0;
                    var parsingResult = propertyValue.ToString().Contains('$') && Double.TryParse(propertyValue.ToString().GetPlaneFormat(), out numericValueIfAny);

                    if (parsingResult)
                        SaveNumericColumnInfoInSession(reportId, propertyName);

                    ((IDictionary<string, object>)newRow)[propertyName] = parsingResult ? numericValueIfAny : propertyValue;
                }

                tableResult.Add(newRow);
            }

            return tableResult;
        }

        private IEnumerable<int> RunUserReports(params int[] reportIds)
        {
            try
            {
                var rowCountsResult = reportIds.Select(rep => GetReportData(rep, GetDateFilterArguments(rep, Utils.DefaultStartDate, Utils.DefaultEndDate)).Count());

                return rowCountsResult;
            }
            catch (Exception exception)
            {
                return new List<int>();
            }
        }

        private void UpdateCloudsInfo(IEnumerable<UserReportViewModel> reports)
        {
            var cloudRefreshenerFlag = Session[Utils.CloudsWereRefreshed];

            if (cloudRefreshenerFlag.IsNull())
                Session.Add(Utils.CloudsWereRefreshed, false);

            var cloudsFlagValue = (bool)Session[Utils.CloudsWereRefreshed];

            if (!cloudsFlagValue)
            {
                RunUserReports(reports.Select(rep => rep.ReportId).ToArray());
                Session[Utils.CloudsWereRefreshed] = true;
            }

        }

        private IEnumerable<ReportConfigViewModel> GetReports()
        {
            try
            {
                var getReportsRequestInfo = Utils.GetRequestInfo(Method.GET, "/api/ReportConfiguration/GetReports");

                var reportsMetadata = _webClient.Execute<List<ReportConfigViewModel>>(ApiUrls.API_KEY, ApiUrls.API_SECRET, getReportsRequestInfo);

                return reportsMetadata;

            }
            catch (Exception exception)
            {
                return null;
            }
        }

        private ReportConfigViewModel GetReport(int reportId)
        {
            var reports = GetReports();

            var reportResult = reports.FirstOrDefault(rep => rep.Id == reportId);

            return reportResult;
        }

        private UserReportViewModel GetUserReport(int reportId, int userId)
        {
            try
            {
                var allUserReports = GetUserReports(userId);

                var report = allUserReports.FirstOrDefault(rep => rep.ReportId == reportId);

                //Defining columns definition
                report.Columns = GetReportColumns(report);

                return report;

            }
            catch (Exception exception)
            {
                return null;
            }
        }

        private UserReportViewModel GetUserReportWithData(int reportId, int userId)
        {
            try
            {
                var report = GetUserReport(reportId, userId);

                IEnumerable<ExpandoObject> data;

                var filterData = GetFiltersData(reportId, out data);

                report.Data = data;
                report.FiltersData = filterData;

                //Defining numeric columns
                var numericColumns = GetNumericColumnsForReport(reportId);

                report.Columns.ForEach(col => col.IsNumeric = numericColumns.Contains(col.Name));

                return report;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        private IEnumerable<UserReportViewModel> GetStandAloneUserReports(int userId)
        {
            try
            {
                var userReports = GetUserReports(userId);

                var results = userReports.Where(rep => rep.IsStandAlone).Distinct(new UserReportComparer());

                return results;

            }
            catch (Exception exception)
            {
                return new List<UserReportViewModel>();
            }
        }

        private IEnumerable<UserReportViewModel> GetUserReports(int userId)
        {
            try
            {
                var getReportsRequestInfo = Utils.GetRequestInfo(Method.GET, "/api/ReportConfiguration/GetUserReports");

                var reportsMetadata = _webClient.Execute<List<UserReportViewModel>>(new { userId = userId }, ApiUrls.API_KEY, ApiUrls.API_SECRET, getReportsRequestInfo);

                return reportsMetadata;

            }
            catch (Exception exception)
            {
                return new List<UserReportViewModel>();
            }

        }

        private IEnumerable<ExpandoObject> FilterData(IEnumerable<ExpandoObject> data, IEnumerable<FilterViewModel> filterValues)
        {
            if (filterValues.IsNull())
                return data;

            //just the filters which has some data to be filtered
            filterValues = filterValues.Where(filter => filter.Value.Any());

            return data.Where(row => filterValues.All(
                filter => filter.Value.Contains((row as IDictionary<string, object>)[filter.Options].ToString())));
        }

        private IEnumerable<ExpandoObject> FilterData(IEnumerable<ExpandoObject> data, IEnumerable<MyKeyValuePair> filterValues)
        {
            if (filterValues.IsNull())
                return data;

            var userFiltersViewModel = filterValues.GroupBy(pair => pair.Key).Select(group => new FilterViewModel
            {
                Options = group.Key,
                Value = group.Where(a => !(String.IsNullOrEmpty(a.Value.ToString()))).Select(p => p.Value.ToString()).ToList()
            });

            return FilterData(data, userFiltersViewModel);
        }

        private List<ReportColumn> GetReportColumns(UserReportViewModel userReport)
        {
            try
            {
                var userLogged = Session[Utils.UserKey] as UserModel;

                var userLevel = Utils.GetUserLevel(userLogged.UserCategory);

                var userReportOutPut = userReport.Output.Split(',').ToList();

                var reportDefaultOutput = userReport.DefaultOuput.Split(',').ToList();

                var userReportFilterableColumns = userReport.UserFilters.Split(',');

                var columnsConfig = new JavaScriptSerializer().Deserialize<List<ReportColumn>>(userReport.OutputConfiguration);

                var result = (from column in reportDefaultOutput
                    let columnConfig = columnsConfig.FirstOrDefault(col => col.Name == column)
                    select new ReportColumn
                    {
                        Name = column,
                        Level = columnConfig.IsNull() ? 0 : columnConfig.Level,
                        Selected = userReportOutPut.Contains(column) && userLevel >= (columnConfig.IsNull() ? 0 : columnConfig.Level),
                        Filterable = userReportFilterableColumns.Contains(column),
                        Width = columnConfig.IsNull() ? 120 : columnConfig.Width, 
                        Index = columnConfig.IsNull() ? 0 : columnConfig.Index, 
                        Label = Utils.GetColumnLabel(userReport.Labels, column)
                    }).ToList();

                result.Sort((a, b) => a.Index.CompareTo(b.Index));

                return result;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        private ActionResult UpdateUserReportFilterConfiguration(int reportId, int userId, IEnumerable<FilterViewModel> filtersConfiguration)
        {
            try
            {
                var a = 2;
                var filtersConfigResult = new List<UserReportFilterModel>();

                foreach (var filterViewModel in filtersConfiguration)
                {
                    if (!filterViewModel.Value.Any())
                    {
                        filtersConfigResult.Add(new UserReportFilterModel
                        {
                            ColumnName = filterViewModel.Options,
                            Value = String.Empty
                        });
                    }
                    else
                    {
                        filtersConfigResult.AddRange(filterViewModel.Value.Select(value => new UserReportFilterModel
                        {
                            ColumnName = filterViewModel.Options,
                            Value = value
                        }));
                    }
                }

                var userReportFilterConfig = new UserReportFilterConfiguration()
                {
                    Filters = filtersConfigResult,
                    UserReportInfo = new UserReportInfoModel
                    {
                        UserId = userId,
                        ReportId = reportId
                    }
                };

                var updateFiltersRequestInfo = Utils.GetRequestInfo(Method.POST, "/api/UserFilterConfigurator/UpdateFilterForUserReport");

                var updateFiltersResponse = _webClient.Execute<bool>(new JavaScriptSerializer().Serialize(userReportFilterConfig), ApiUrls.API_KEY, ApiUrls.API_SECRET, updateFiltersRequestInfo);


                return Json(updateFiltersResponse);

            }
            catch (Exception)
            {

                return null;
            }
        }

        private void UpdateUserReportOutPut(int reportId, int userId, IEnumerable<string> outPut)
        {
            var userReport = GetUserReport(reportId, userId);

            //The same Output Config is kept
            var currentOutputConfig = userReport.OutputConfiguration;

            var updateOutputRequest = Utils.GetRequestInfo(Method.POST, "/api/ReportConfiguration/UpdateUserReportOutput");

            var updateOutputParmams = new UserReportOutputModel
            {
                Output = outPut.GetCommaSeparatedTokens(),
                OutputConfiguration = currentOutputConfig,
                UserId = userId,
                ReportId = reportId
            };

           _webClient.Execute<bool>(updateOutputParmams, ApiUrls.API_KEY, ApiUrls.API_SECRET, updateOutputRequest);
        }

        private void UpdateUserReportOutPutConfig(int reportId, int userId, string outputConfiguration)
        {
            var userReport = GetUserReport(reportId, userId);

            //The same output is kept
            var currentOutput = userReport.Output;

            var updateOutputRequest = Utils.GetRequestInfo(Method.POST, "/api/ReportConfiguration/UpdateUserReportOutput");

            var updateOutputParmams = new UserReportOutputModel
            {
                Output = currentOutput,
                OutputConfiguration = outputConfiguration,
                UserId = userId,
                ReportId = reportId
            };

            _webClient.Execute<bool>(updateOutputParmams, ApiUrls.API_KEY, ApiUrls.API_SECRET, updateOutputRequest);
        }

        private IEnumerable<string> GetReportOutput(int reportId, ICollection<string> output, IEnumerable<ColumnSwap> columnsSwapHistory)
        {
            var userReport = GetUserReport(reportId, GetLoggedUserId());

            var lastOutput = userReport.Output.Split(',').ToList();

            var defaultOutput = userReport.DefaultOuput.Split(',').ToList();

            defaultOutput.Sort((a, b) =>
            {
                var posA = lastOutput.IndexOf(a);
                var posB = lastOutput.IndexOf(b);

                if (posA == -1 && posB != -1)
                    return 1;
                if (posB == -1 && posA != -1)
                    return -1;
                return posA.CompareTo(posB);
            });

            foreach (var columnSwap in columnsSwapHistory)
            {
                var itemToMove = defaultOutput[columnSwap.OldIndex];

                defaultOutput.Remove(itemToMove);

                defaultOutput.Insert(columnSwap.NewIndex, itemToMove);
            }

            return defaultOutput.Where(output.Contains);

        }

        private string GetReportOutputConfiguration(int reportId, int userId, IEnumerable<ReportColumn> columnsSwapHistory, IEnumerable<ReportColumn> columnsWidthHistory)
        {
            var userReport = GetUserReport(reportId, userId);

            var columnsConfig = new JavaScriptSerializer().Deserialize<List<ReportColumn>>(userReport.OutputConfiguration);

            columnsConfig.ForEach(reportConfig =>
            {
                var lastIndex = columnsSwapHistory.LastOrDefault(columnSwap => columnSwap.Name == reportConfig.Name);

                //There was an index change so an offset has to be performed
                if (!lastIndex.IsNull())
                {
                    //Right offset
                    if (lastIndex.Index > reportConfig.Index)
                    {
                        foreach (var column in columnsConfig.Where(colum => colum.Index <= lastIndex.Index && colum.Index > reportConfig.Index))
                            column.Index--;
                    }
                    else
                    {
                        //Left offset
                        foreach (var column in columnsConfig.Where(colum => colum.Index >= lastIndex.Index && colum.Index < reportConfig.Index))
                            column.Index++;
                    }

                    reportConfig.Index = lastIndex.Index;
                }

                var lastWidth = columnsWidthHistory.LastOrDefault(columnWidth => columnWidth.Name == reportConfig.Name);

                if (!lastWidth.IsNull())
                    reportConfig.Width = lastWidth.Width;
            });

            var jsonResult = new JsonSerializer().Serialize(columnsConfig);

            return jsonResult;
        }

        private IDictionary<string, IEnumerable<string>> GetFiltersData(int reportId, out IEnumerable<ExpandoObject> dataResult, List<Argument> arguments = null)
        {
            try
            {
                var dictionaryResult = new Dictionary<string, IEnumerable<string>>();

                var reportData = GetReportData(reportId, arguments);

                var row = reportData.FirstOrDefault();

                var columnNames = (row as IDictionary<string, object>).Keys;

                foreach (var columnName in columnNames)
                {
                    var distinctElements = Utils.GetDistinctElements(reportData, columnName.Replace(' ', '_'));

                    dictionaryResult.Add(columnName, distinctElements);
                }

                dataResult = reportData;

                return dictionaryResult;
            }
            catch (Exception exception)
            {
                dataResult = new List<ExpandoObject>();

                return new Dictionary<string, IEnumerable<string>>();
            }
        }

        private List<Argument> GetInSesionArguments(int reportId)
        {
            try
            {
                var argsResult = new List<Argument>();

                var argumentsInSession = System.Web.HttpContext.Current.Session[Utils.ArgumentsKey] as Dictionary<int, List<Argument>>;

                var argsRange = argumentsInSession[reportId];

                argsResult.AddArguments(argsRange);

                return argsResult;

            }
            catch (Exception)
            {

                return new List<Argument>();
            }
        }

        private void SaveObjectInSession(int reportId, IEnumerable<Argument> reportArguments)
        {
            try
            {
                if (reportArguments.IsNull() || !reportArguments.Any())
                    return;

                var sessionArguments = System.Web.HttpContext.Current.Session[Utils.ArgumentsKey] as Dictionary<int, List<Argument>>;

                if (sessionArguments.IsNull())
                {
                    System.Web.HttpContext.Current.Session.Add(Utils.ArgumentsKey,
                       new Dictionary<int, List<Argument>>
                       {
                            {reportId, new List<Argument>(reportArguments.Where(rep=> !rep.IsNull()))}
                        });
                }

                else
                {
                    if (!sessionArguments.ContainsKey(reportId))
                        sessionArguments.Add(reportId, new List<Argument>());

                    sessionArguments[reportId].AddArguments(reportArguments);
                    System.Web.HttpContext.Current.Session[Utils.ArgumentsKey] = sessionArguments;

                }
            }
            catch (Exception exception)
            {
                return;
            }
        }

        private void SaveLastDateRangeInSession(string startDate, string endDate)
        {
            var dateRange = GetDateRange(startDate, endDate);

            if (dateRange.IsNull())
                return;

            var currentRange = System.Web.HttpContext.Current.Session[Utils.DateRangeKey] as DateRange;

            if (currentRange.IsNull())
                System.Web.HttpContext.Current.Session.Add(Utils.DateRangeKey, dateRange);
            else
                System.Web.HttpContext.Current.Session[Utils.DateRangeKey] = dateRange;
        }

        private DateRange GetLastDateRangeInSession()
        {
            var currentDateRange = System.Web.HttpContext.Current.Session[Utils.DateRangeKey] as DateRange;

            return currentDateRange;
        }

        private DateRange GetDateRange(string startDate, string endDate)
        {
            try
            {
                var startDateParsed = DateTime.Parse(startDate);

                var endDateParsed = DateTime.Parse(endDate);

                return new DateRange
                {
                    StartDate = startDateParsed,
                    EndDate = endDateParsed
                };
            }
            catch (Exception exception)
            {
                return default(DateRange);
            }
        }

        private IEnumerable<CloudInfoModel> GetCloudsInfo()
        {

            var reports = GetStandAloneUserReports(GetLoggedUserId());

            var minValue = (!reports.IsNull() && reports.Any()) ? reports.Min(rep => rep.ExecutionCount) : 0;

            var maxValue = (!reports.IsNull() && reports.Any()) ? reports.Max(rep => rep.ExecutionCount) : 0;

            var mainColor = Color.CadetBlue;

            var clouds = reports.Where(rep => rep.ShouldBeShownAtDesktop).Select(rep => new CloudInfoModel
            {
                Title = rep.Name,
                Id = rep.ReportId,
                Category = rep.Category,
                Items = rep.RowCount,
                Color = ChangeColorBrightness(mainColor, 0),
                Width = 250,
                Height = 150,
                //Width = 300 GetMappingRange(rep.ExecutionCount, maxValue, minValue, 100, 300),
                //Height = GetMappingRange(rep.ExecutionCount, maxValue, minValue, 72, 210),
                Url = String.Format("Reports/ExecuteReport?reportId={0}", rep.ReportId)
            });

            return clouds;
        }

        private IEnumerable<DashboardItem> GetDashboardItems(bool runReports)
        {
            var items = _virtualOfficeService.GetDashboardItems(GetLoggedUserId(), runReports);

            return items;
        }

        private int GetMappingRange(int value, int oldMax, int oldMin, int newMin, int newMax)
        {
            try
            {
                return newMin + (newMax - newMin) * (value - oldMax) / (oldMin - oldMax);

            }
            catch (Exception)
            {
                return 0;
            }
        }

        private static string ChangeColorBrightness(Color color, float correctionFactor)
        {
            try
            {
                float red = color.R;
                float green = color.G;
                float blue = color.B;

                if (correctionFactor < 0)
                {
                    correctionFactor = 1 + correctionFactor;
                    red *= correctionFactor;
                    green *= correctionFactor;
                    blue *= correctionFactor;
                }
                else
                {
                    red = (255 - red) * correctionFactor + red;
                    green = (255 - green) * correctionFactor + green;
                    blue = (255 - blue) * correctionFactor + blue;
                }

                return String.Format("rgb({0},{1},{2})", (int)red, (int)green, (int)blue);
            }
            catch (Exception exception)
            {

                return String.Format("rgb({0},{1},{2})", (int)color.R, (int)color.G, (int)color.B);
            }

        }

        private bool UpdateReportConfiguration(int reportId, int userId, bool saveReportOnDesktop)
        {
            try
            {
                var requestInfo = Utils.GetRequestInfo(Method.POST, "/api/ReportConfiguration/UpdateUserReportConfiguration");

                var requestParams = new { ReportId = reportId, UserId = userId, ShowReportOnDesktop = saveReportOnDesktop };

                var updateResult = _webClient.Execute<UpdateReportConfigResponse>(requestParams, ApiUrls.API_KEY, ApiUrls.API_SECRET, requestInfo);

                return saveReportOnDesktop == updateResult.ShouldBeShownAtDesktop;
            }
            catch (Exception exception)
            {
                return false;
            }

        }

        private void UpdateUserReportDates(int reportId, int userId, string startDate, string endDate)
        {
            try
            {
                DateTime startDateParam, endDateParam;

                if (!DateTime.TryParse(startDate, out startDateParam) || !DateTime.TryParse(endDate, out endDateParam))
                    return;

                var requestInfo = Utils.GetRequestInfo(Method.POST, "/api/ReportConfiguration/UpdateUserReportDates");

                var requestParams = new { ReportId = reportId, UserId = userId, StartDate = startDateParam, EndDate = endDateParam };

                var updateResult = _webClient.Execute<bool>(requestParams, ApiUrls.API_KEY, ApiUrls.API_SECRET, requestInfo);

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void SaveNumericColumnInfoInSession(int reportId, string columnName)
        {
            var numericColumnsInSession = Session[Utils.NumericColumnsKey];

            //First time accessed
            if (numericColumnsInSession.IsNull())
            {
                numericColumnsInSession = new Dictionary<int, SortedSet<string>>
                {
                    {reportId, new SortedSet<string>{columnName}}
                };
                Session.Add(Utils.NumericColumnsKey, numericColumnsInSession);
            }
            else
            {
                var numericColumnsDictionary = ((Dictionary<int, SortedSet<string>>)numericColumnsInSession);

                if (numericColumnsDictionary.ContainsKey(reportId))
                    numericColumnsDictionary[reportId].Add(columnName);
                else
                    numericColumnsDictionary.Add(reportId, new SortedSet<string> { columnName });

                Session[Utils.NumericColumnsKey] = numericColumnsInSession;
            }
        }

        private IEnumerable<string> GetNumericColumnsForReport(int reportId)
        {
            try
            {
                var numericColumnsDictionary = Session[Utils.NumericColumnsKey] as Dictionary<int, SortedSet<string>>;

                var numericColumnsSet = numericColumnsDictionary[reportId];

                return numericColumnsSet;

            }
            catch (Exception)
            {

                return new List<string>();
            }
        }

        private MyDataSourceResult MappingDataSourceResults(int reportId, DataSourceResult dataSourceResult)
        {
            var numericColumns = GetNumericColumnsForReport(reportId).ToList();

            var myAggregateResults = dataSourceResult.AggregateResults.IsNull() ? null : dataSourceResult.AggregateResults.Select((aggregate, i) => 
            new MyAggregateResult
            {
                Value = aggregate.Value,
                FormattedValue = aggregate.FormattedValue,
                AggregateMethodName = aggregate.AggregateMethodName,
                FunctionName = aggregate.FunctionName,
                Member = numericColumns[i],
                ItemCount = aggregate.ItemCount,
                Caption = aggregate.Caption
            });

            var dataSource = new MyDataSourceResult
            {
                Total = dataSourceResult.Total,
                Data = dataSourceResult.Data,
                Errors = dataSourceResult.Errors,
                AggregateResults = myAggregateResults
            };

            return dataSource;
        }

        #endregion

        #region Aditional Reports  (Out of the Standard Reports Logic)

        #region Summary Report
        public ActionResult SummarySalesReport()
        {
            ViewBag.Reports = GetStandAloneUserReports(GetLoggedUserId());

            return View();
        }

        public ActionResult GetSalesSummaryData([DataSourceRequest] DataSourceRequest request, string option)
        {
            var enumOption = GetOption(option);

            var summary = GetSalesSummary(enumOption);

            var result = summary.ToDataSourceResult(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExecuteSummaryReport(int reportId, string range)
        {
            var summaryRange = GetSummaryFromRange(range);

            var dateRange = Utils.GetFirst_LastDayRange(summaryRange);

            //Saving last Date Range Used in Session
            SaveLastDateRangeInSession(dateRange.StartDate.ToString(), dateRange.EndDate.ToString());

            return RedirectToAction("ExecuteReport", "Reports", new { reportId });
        }

        private IEnumerable<SummaryRange> GetSummaryRanges(SummaryRangeOption option)
        {
            var months = (int) option;

            for (var i = 0; i <= months; i++)
            {
                var newDate = DateTime.Now.AddMonths(i*(-1));

               yield return new SummaryRange
               {
                   Month = newDate.Month,
                   Year = newDate.Year
               };
            }

        }

        private IEnumerable<SalesSummary> GetSalesSummary(SummaryRangeOption option)
        {
            var summaryRanges = GetSummaryRanges(option);

            var result = new List<SalesSummary>();

            var merchantServicesData = GetMerchantServicesSalesSummaryTotalByMonth(summaryRanges.Last(), summaryRanges.First());

     
            var prepaidData = GetPrepaidSalesSummaryTotalByMonth(summaryRanges.Last(), summaryRanges.First());

            foreach (var summaryRange in summaryRanges)
            {
                var dateRange = Utils.GetFirst_LastDayRange(summaryRange);
                var prepaidTotal = prepaidData.ContainsKey(dateRange.StartDate.Month)? prepaidData[dateRange.StartDate.Month]: 0;
                var merchantServices = merchantServicesData.ContainsKey(dateRange.StartDate.Month)? merchantServicesData[dateRange.StartDate.Month]: 0;
                var range = GetRangeForSummary(summaryRange);

                var salesSummary = new SalesSummary
                {
                    Month = range,
                    MerchantServicesSalesSummary = merchantServices,
                    PrepaidSalesSummary = prepaidTotal,
                };

               result.Add(salesSummary);
            }

            return result;
        }

        private IEnumerable<Argument> GetSalesSummaryArguments(int reportId, DateRange range)
        {
            var argumentsResult = new List<Argument>();

            var report = GetUserReport(reportId, GetLoggedUserId());

            var idParameter = report.Parameters.FirstOrDefault(p => p.Name.IsIdParameter());

            if (!idParameter.IsNull())
                argumentsResult.Add(new Argument(idParameter.Name, GetLoggedUserId()));

            var dateArguments = GetDateFilterArguments(reportId, range);

            argumentsResult.AddRange(dateArguments);

            return argumentsResult;
        }

        private UserReportInfoModel GetUserReportInfoModelForSalesSummary(int reportId, DateRange range)
        {
            var args = GetSalesSummaryArguments(reportId, range);

            var userReportInfoModel = new UserReportInfoModel
            {
                Args = args,
                ReportId = reportId,
                UserId = GetLoggedUserId()
            };

            return userReportInfoModel;
        }

        private IEnumerable<Dictionary<string, object>> GetSalesSummaryData(int reportId,DateRange range)
        {
            var executeReportRequestInfo = Utils.GetRequestInfo(Method.POST, "/api/Report/RunUserReport");
            
            var parameters = GetUserReportInfoModelForSalesSummary(reportId, range);
            
            var executionResponse = _webClient.Execute<List<Dictionary<string, object>>>(new JsonSerializer().Serialize(parameters), ApiUrls.API_KEY, ApiUrls.API_SECRET, executeReportRequestInfo);

            return executionResponse;
        }

        private double GetSalesSummaryTotal(IEnumerable<Dictionary<string, object>> data, string columnName)
        {
            try
            {
                var total = data.Sum(row => double.Parse(row[columnName].GetPlaneFormat()));

                var totalRounded = Math.Round(total, 2);

                return totalRounded;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        private double GetPrepaidSalesSummaryTotal(DateRange range)
        {
            const int reportId = 43;
            const string columnName = "GrSalesTOT";

            var data =  GetSalesSummaryData(reportId, range);

            return GetSalesSummaryTotal(data, columnName);
        }
        private double GetMerchantServicesSalesSummaryTotal(DateRange range)
        {
            const int reportId = 49;
            const string columnName = "tot_commission";

            var data =  GetSalesSummaryData(reportId, range);

            return GetSalesSummaryTotal(data, columnName);
        }

        private Dictionary<int, double> GetMerchantServicesSalesSummaryTotalByMonth(SummaryRange startRange, SummaryRange lastRange)
        {
            const int reportId = 49;
            const string columnName = "tot_commission";

            var totalsByMonth = new Dictionary<int, double>();

            var startDate = Utils.GetFirst_LastDayRange(startRange).StartDate;
            var endDate = Utils.GetFirst_LastDayRange(lastRange).EndDate;
            
            var range = new DateRange
            {
                StartDate = startDate,
                EndDate = endDate
            };

            var data =  GetSalesSummaryData(reportId, range).ToList();

            var months = GetMonthInits(range).ToList();

            for (int i = 0; i < Math.Min(data.Count(),months.Count()); i++)
            {
                var currentData = new List<Dictionary<string, object>> { data[i] };

                var total = GetSalesSummaryTotal(currentData, columnName);

                totalsByMonth.Add(months[i].Month, total);
            }
            return totalsByMonth;
        }

        private Dictionary<int, double> GetPrepaidSalesSummaryTotalByMonth(SummaryRange startRange, SummaryRange lastRange)
        {
            const int reportId = 64;
            const string columnName = "GrSalesTOT";
            const string dateColumName = "date";
            var totalsByMonth = new Dictionary<int, double>();

            var startDate = Utils.GetFirst_LastDayRange(startRange).StartDate;
            var endDate = Utils.GetFirst_LastDayRange(lastRange).EndDate;

            var range = new DateRange
            {
                StartDate = startDate,
                EndDate = endDate
            };

            var data = GetSalesSummaryData(reportId, range).ToList();

            var months = GetMonthInits(range).ToList();

            foreach(var month in months)
            {
                var currentData = data.Where(row => DateTime.Parse(row[dateColumName].ToString()).IsBetween(month));

                var total = GetSalesSummaryTotal(currentData, columnName);

                totalsByMonth.Add(month.Month, total);
            }
            return totalsByMonth;
        }

        private IEnumerable<DateTime> GetMonthInits(DateRange range)
        {
            var currentDate = range.StartDate;

            while (currentDate < range.EndDate)
            {
                yield return currentDate;

                currentDate = currentDate.AddMonths(1);
            }
        }

        private string GetRangeForSummary(SummaryRange range)
        {
            var monthIndex = range.Month -1 ;

            var month = Enum.IsDefined(typeof (Month),monthIndex) ? ((Month)monthIndex).ToString() : string.Empty;

            return month + "/" + range.Year;
        }

        private SummaryRange GetSummaryFromRange(string range)
        {
            try
            {
                var tokens = range.Split('/');

                var monthEnum = Enum.Parse(typeof(Month),tokens[0]);

                var year = int.Parse(tokens[1]);

                return new SummaryRange
                {
                    Month = (int) monthEnum + 1,
                    Year = year
                };
            }
            catch (Exception exception)
            {
                return default(SummaryRange);
            }
           
        }

        private SummaryRangeOption GetOption(string option)
        {
            var index = int.Parse(option);

            return Enum.IsDefined(typeof(SummaryRangeOption), index) ? ((SummaryRangeOption)index) : default(SummaryRangeOption);
        }

        #endregion

        #endregion

        #region New Version Aux Ops

        /// <summary>
        /// Creates a relation Query of the Report => Visibility determined by its level
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, bool> GetLinksVisibility()
        {
            var reports = _virtualOfficeService.GetAllReports().ToList();

            var userLevel = GetUserLevel();

            var result = reports.ToDictionary(r => r.Query,r => r.Level <= userLevel);

            return result;
        }

        #endregion



    }
}