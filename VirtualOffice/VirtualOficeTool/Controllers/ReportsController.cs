using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;
using Microsoft.Data.Edm.Expressions;
using Newtonsoft.Json;
using VirtualOfficeToolManager;
using VirtualOfficeToolManager.Domain;
using VirtualOficeTool.Infrastructure;
using VirtualOficeTool.Models;
using WebGrease.Css.Extensions;
using ConverterHelper = VirtualOfficeToolManager.Helpers.ConverterHelper;

namespace VirtualOficeTool.Controllers
{
    public class ReportsController : Controller
    {
        private readonly OfficeToolManager _virtualOfficeToolManager;

        public ReportsController()
        {
            _virtualOfficeToolManager = new OfficeToolManager();
        }

        #region Main Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetReports(DataSourceRequest request)
        {
            try
            {
                var userFilters = _virtualOfficeToolManager.GetReports();

                return Json(userFilters.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult CreateReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateReport(ReportViewModel reportViewModel)
        {
            try
            {
                var newReport = reportViewModel.MapTo<ReportViewModel, Report>();

                //Checking consistency between column Name and Labels
                CheckColumnsConfig(reportViewModel.Query, reportViewModel.ColumnLabels, reportViewModel.OutPut);

                newReport.ColumnLabels = AdjustColumnLabels(reportViewModel).GetCommaSeparatedTokens();
                newReport.SubReports = ParseSubReports(reportViewModel.SubReportIds, reportViewModel.SubReportColumns, reportViewModel.IndexParamNames);

                _virtualOfficeToolManager.AddReport(newReport);

                return RedirectToAction("Index");

            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", string.Format("Errors while trying to add a new Report. Please, try again! More details:{0}", exception.Message));

                return View("CreateReport", reportViewModel);
            }
        }

        [HttpPost]
        public ActionResult ExecuteEditReport(ReportViewModel reportViewModel)
        {
            try
            {
                ////Removing the Parsing on Column Names
                //reportViewModel.OutPut = UnParseColumnName(reportViewModel.OutPut);
                //reportViewModel.UserFilters = UnParseColumnName(reportViewModel.UserFilters);

                var newReport = reportViewModel.MapTo<ReportViewModel, Report>();

                //Checking consistency between column Name and Labels
                CheckColumnsConfig(reportViewModel.Query, reportViewModel.ColumnLabels, reportViewModel.OutPut);

                newReport.ColumnLabels = AdjustColumnLabels(reportViewModel).GetCommaSeparatedTokens();
                newReport.SubReports = ParseSubReports(reportViewModel.SubReportIds, reportViewModel.SubReportColumns, reportViewModel.IndexParamNames);

                //If the columns are completely empty it's because they were not modified so the old one is kept
                if (string.IsNullOrEmpty(newReport.OutPut))
                {
                    var report = _virtualOfficeToolManager.GetReport(newReport.Id);

                    newReport.OutPut = report.OutPut;
                }

                _virtualOfficeToolManager.UpdateReport(newReport);

                return RedirectToAction("Index");

            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", string.Format("Errors while trying to add a new Report. Please, try again! More details:{0}", exception.Message));

                return View("EditReport", reportViewModel);
            }
        }

        public ActionResult RemoveReport(ReportViewModel reportViewModel)
        {
            try
            {
                _virtualOfficeToolManager.RemoveReport(reportViewModel.Id);

                return RedirectToAction("Index");

            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public ActionResult EditReport(int reportId)
        {
            try
            {
                var report = _virtualOfficeToolManager.GetReport(reportId);

                var reportViewModel = report.MapTo<Report, ReportViewModel>();

                return View(reportViewModel);
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult GetColumnNames(DataSourceRequest request, string query, string parameters, int? reportId)
        {
            try
            {
                var columns = _virtualOfficeToolManager.GetReportColumnNamesExt(query).ToList();

                if (!ValidColumnNamesResponse(columns))
                    return null;

                var repId = reportId.IsNull() ? -1 : reportId.Value;

                var reportIndex = _virtualOfficeToolManager.GetReportIndex(repId);

                var reportColumnNames = _virtualOfficeToolManager.GetReportColumns(repId);

                var reportUserFilters = _virtualOfficeToolManager.GetReportUserFilters(repId);

                var columnsResult = columns.Select(col => new Models.ReportColumn
                {
                    Name = ParseColumnName(col), 
                    Selected = !reportColumnNames.IsNull() && reportColumnNames.Contains(col),
                    Filterable = !reportUserFilters.IsNull() && reportUserFilters.Contains(col),
                    IsIndex = col == reportIndex,
                    Label = _virtualOfficeToolManager.GetColumnLabel(reportId, col),
                    Level = _virtualOfficeToolManager.GetColumnLevel(reportId, col)
                });

                var result = columnsResult.ToList();
             
                return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public ActionResult GetReportParameters(DataSourceRequest request, string spName)
        {
            try
            {
                var parameters = _virtualOfficeToolManager.GetReportParameters(spName);

                return Json(parameters.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public ActionResult GetSubReports(DataSourceRequest request,int? reportId, int? mode)
        {
            try
            {
                var subReports = _virtualOfficeToolManager.GetSubReports(reportId);

                var subReportsResult = subReports.MapTo<IEnumerable<Report>, IEnumerable<SubReportViewModel>>().ToList();

                switch (mode)
                {
                    case (int)Mode.Creation:
                        {
                            //no filters to be applied
                            break;
                        }
                    case (int)Mode.Edition:
                        {
                            //Definiing wether the report is related to the other report or it is not
                            subReportsResult.ForEach(report =>
                            {
                                var subReport = _virtualOfficeToolManager.GetSubReportProyection(reportId, report.Id);

                                if (!subReport.IsNull())
                                {
                                    report.Selected = true;
                                    report.ColumnName = subReport.ColumnName;
                                    report.IndexParamName = subReport.IndexParamName;
                                }
                            });
                            break;
                        }
                }

                return Json(subReportsResult.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }
        }

        //public ActionResult GetUserFilters(DataSourceRequest request,int? reportId, int? mode)
        //{
        //    try
        //    {
        //        var userFilters = _virtualOfficeToolManager.GetUserFilters();

        //        var userFiltersResult = userFilters.MapTo<IEnumerable<UserFilter>, IEnumerable<UserFilterViewModel>>().ToList();

        //        switch (mode)
        //        {
        //            case (int)Mode.Creation:
        //            {
        //                //no filters to be applied
        //                break;
        //            }
        //            case (int)Mode.Edition:
        //            {
        //                //Definiing wether the filter is related to the report or it is not
        //                userFiltersResult.ForEach(filter =>
        //                {
        //                    var filterSelected = _virtualOfficeToolManager.IsUserFilterSelected(reportId, filter.Id);

        //                    filter.Selected = filterSelected;
        //                });
        //             break;   
        //            }
        //        }

        //        return Json(userFiltersResult.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        //    }
        //    catch (Exception exception)
        //    {
        //        return null;
        //    }
        //}

        public ActionResult GetPredefinedFilters(DataSourceRequest request, int? reportId, int? mode)
        {
            try
            {
                var predefinedFilters = _virtualOfficeToolManager.GetPredefinedFilters();

                var userFiltersResult = predefinedFilters.MapTo<IEnumerable<PredefinedFilter>, IEnumerable<PredefinedFilterViewModel>>().ToList();

                switch (mode)
                {
                    case (int)Mode.Creation:
                        {
                            //no filters to be applied
                            break;
                        }
                    case (int)Mode.Edition:
                        {
                            //Defining wether the filter is related to the report or it is not
                            userFiltersResult.ForEach(filter =>
                            {
                                var filterSelected = _virtualOfficeToolManager.IsPredefinedFilterSelected(reportId, filter.Id);

                                filter.Selected = filterSelected;
                            });
                            break;
                        }
                }

                return Json(userFiltersResult.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public ActionResult GetStoredProcedureNames(DataSourceRequest request)
        {
            try
            {
                var spNames = _virtualOfficeToolManager.GetStoredProcedureNames().ToList();

                return Json(spNames, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public ActionResult ChangeReportStatus(DataSourceRequest request,int reportId)
        {
            try
            {
                _virtualOfficeToolManager.ChangeReportStatus(reportId);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Errors while trying to change the status of the Report. Please, try again later! :)");

                return View("Index");
            }
        }
        #endregion 

        #region Quick Reports Version

        #endregion

        #region Aux Ops
        private static List<SubReport> ParseSubReports(IEnumerable<int> subReportIds, IList<string> subReportColumns, IList<string> indexParamNames)
        {
            try
            {
                if (subReportIds.IsNull() || subReportColumns.IsNull())
                    return new List<SubReport>();

                subReportColumns = subReportColumns.Where(sub => sub != string.Empty).ToList();

                return subReportIds.Select((t, i) => new SubReport
                {
                    Id = t,
                    ColumnName = subReportColumns[i],
                    IndexParamName = indexParamNames[i]
                }).ToList();
            }
            catch (Exception)
            {
                
                throw new Exception("There is a SubReport Configuration Inconsistency.Check it out in order to configure the report please");
            }
         
        }

        private  void CheckColumnsConfig(string query, List<string> columnLabels, List<string> output)
        {
            //TODO-> it might have more rules

            var spColumns = _virtualOfficeToolManager.GetReportColumnNamesExt(query).ToList();

            for (int i = 0; i < spColumns.Count(); i++)
            {
                if (string.IsNullOrEmpty(columnLabels[i]) && output.Contains(spColumns[i]))
                    throw new Exception("There is a Column Label Configuration Inconsistency. It might be produced because there is a column selected which associated label is empty. Check it out in order to configure the report please.");
            }

            ////All columns have to have a label associated=> this quantity relation
            //if(columnLabels.Count < output.Count)
            //    throw new Exception("There is a Column Label Configuration Inconsistency. It might be produced because there is a column selected which associated label is empty. Check it out in order to configure the report please.");
        }

        private static string ParseColumnName(string columnName)
        {
            var partial = columnName.Split(' ');

            var result = partial.Aggregate(string.Empty, (current, s) => current + (s + "_")).TrimEnd('_');

            return result;
        }

        private static List<string> UnParseColumnName(IEnumerable<string> outPut)
        {
            return outPut.Select(token => token.Replace('_', ' ')).ToList();
        }

        //Determines if a column Name Response is an actual StoreProcedure Name(Validation Approach)
        private static bool ValidColumnNamesResponse(IEnumerable<string> columns)
        {
            return !columns.IsNull() && (columns.Count() > 1 || columns.First().Length <= 50);
        }

        private IEnumerable<string> AdjustColumnLabels(ReportViewModel report)
        {
            var originalOutPut = _virtualOfficeToolManager.GetReportColumnNamesExt(report.Query).ToList();
            
            var outPut = report.OutPut;

            var columnLabels = report.ColumnLabels;

            return from column in outPut select originalOutPut.FindIndex(col => col == column) into index where index >= 0 select columnLabels[index];
        }
        #endregion



    }
}
