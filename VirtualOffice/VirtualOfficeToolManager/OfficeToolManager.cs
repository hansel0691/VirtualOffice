using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using ApiRestClient.Infrastructure;
using ApiRestClient.Models;
using ApiRestClient.Services;
using Domain.Models;
using Newtonsoft.Json;
using RestSharp;
using Services.Concrete;
using VirtualOfficeToolManager.Data;
using VirtualOfficeToolManager.Domain;
using VirtualOfficeToolManager.Helpers;
using JsonSerializer = RestSharp.Serializers.JsonSerializer;
using PredefinedFilter = VirtualOfficeToolManager.Domain.PredefinedFilter;
using ReportPredefinedFilterRel = VirtualOfficeToolManager.Data.ReportPredefinedFilterRel;
using ReportToReportRel = VirtualOfficeToolManager.Data.ReportToReportRel;
using UserFilter = VirtualOfficeToolManager.Domain.UserFilter;
using WebClient = System.Net.WebClient;
using Parameter= Domain.Models.Parameter;

namespace VirtualOfficeToolManager
{
    public class OfficeToolManager
    {
        #region Fields

        private readonly VirtualOfficeEntities _virtualOfficeEntities;

        private IWebClient _webClient;

        private const string AuthorizationUrl = "/api/Token/POSTTOKEN";

        private const string HostUrl = "http://virtualofficeservice.pinserve.com";

        private const string ProductionHostUrl = "http://virtualofficeservice.pinserve.com";

        private const string ApiKey = "abc";

        private const string ApiSecret = "asdfasdfadfa";
     
        public OfficeToolManager()
        {
            _virtualOfficeEntities = new VirtualOfficeEntities();
           _webClient = new ApiRestClient.Services.WebClient(new AuthService(), new HmacHashProvider());
        }
        #endregion

        #region User Filters
        //public IEnumerable<UserFilter> GetUserFilters()
        //{
        //    var userFilters = _virtualOfficeEntities.UserFilters;

        //    var userFiltersResult = userFilters.MapTo<IEnumerable<Data.UserFilter>, IEnumerable<UserFilter>>();

        //    return userFiltersResult;
        //}

        //public void AddNewUserFilter(UserFilter userFilter)
        //{
        //    var userFilterEntity = userFilter.MapTo<Domain.UserFilter, Data.UserFilter>();

        //    _virtualOfficeEntities.UserFilters.Add(userFilterEntity);

        //    _virtualOfficeEntities.SaveChanges();
        //}

        //public void UpdateUserFilter(UserFilter userFilter)
        //{
        //    var userFilterEntity = userFilter.MapTo<Domain.UserFilter, Data.UserFilter>();

        //    _virtualOfficeEntities.UserFilters.AddOrUpdate(userFilterEntity);

        //    _virtualOfficeEntities.SaveChanges();

        //}

        //public void RemoveUserFilter(int id)
        //{
        //    var userFilterEntity = _virtualOfficeEntities.UserFilters.Find(id);

        //    _virtualOfficeEntities.UserFilters.Remove(userFilterEntity);

        //    _virtualOfficeEntities.SaveChanges();
        //}
        #endregion

        #region Predefined Filters

        public IEnumerable<PredefinedFilter> GetPredefinedFilters()
        {
            var userFilters = _virtualOfficeEntities.PredefinedFilters;

            var userFiltersResult = userFilters.MapTo<IEnumerable<Data.PredefinedFilter>, IEnumerable<PredefinedFilter>>();

            return userFiltersResult;
        }

        public void AddNewPredefinedFilter(PredefinedFilter userFilter)
        {
            var userFilterEntity = userFilter.MapTo<Domain.PredefinedFilter, Data.PredefinedFilter>();

            _virtualOfficeEntities.PredefinedFilters.Add(userFilterEntity);

            _virtualOfficeEntities.SaveChanges();
        }

        public void UpdatePredefinedFilter(PredefinedFilter userFilter)
        {
            var userFilterEntity = userFilter.MapTo<Domain.PredefinedFilter, Data.PredefinedFilter>();

            _virtualOfficeEntities.PredefinedFilters.AddOrUpdate(userFilterEntity);

            _virtualOfficeEntities.SaveChanges();
        }

        public void RemovePredefinedFilter(int id)
        {
            var userFilterEntity = _virtualOfficeEntities.PredefinedFilters.Find(id);

            _virtualOfficeEntities.PredefinedFilters.Remove(userFilterEntity);

            _virtualOfficeEntities.SaveChanges();

        }

        #endregion

        #region Reports
        public IEnumerable<Domain.Report> GetReports()
        {
            var reports = _virtualOfficeEntities.Reports;

            var reportsResult = reports.MapTo<IEnumerable<Data.Report>, IEnumerable<Domain.Report>>();

            return reportsResult;
        }

        public void AddReport(Domain.Report report)
        {
            var reportEntity = report.MapTo<Domain.Report, Data.Report>();

            reportEntity.IsEnable = true;

            var reportResult = _virtualOfficeEntities.Reports.Add(reportEntity);

            _virtualOfficeEntities.SaveChanges();

            report.Id = reportResult.Id;

            AddColumnLabels(report);

            AddOrUpdateReportsRelations(report);
        }

        public void UpdateReport(Domain.Report report)
        {
            var reportEntity = report.MapTo<Domain.Report, Data.Report>();

            _virtualOfficeEntities.Reports.AddOrUpdate(reportEntity);

            _virtualOfficeEntities.SaveChanges();

            UpdateColumnLabels(report);

            AddOrUpdateReportsRelations(report);
        }

        public void ChangeReportStatus(int id)
        {
            var reportEntity = _virtualOfficeEntities.Reports.Find(id);

            reportEntity.IsEnable = !reportEntity.IsEnable;

            _virtualOfficeEntities.SaveChanges();
        }

        public Domain.Report GetReport(int reportId)
        {
            var reportEntity = _virtualOfficeEntities.Reports.Find(reportId);

            var reportResult = reportEntity.MapTo<Data.Report, Domain.Report>();

            return reportResult;
        }

        private void AddOrUpdateReportsRelations(Domain.Report report)
        {
            #region Removing Relations if Any

            //var reports_userFilters = _virtualOfficeEntities.ReportUserFilterRels.Where(rel => rel.ReportId == report.Id);
            //foreach (var reportUserFilterRel in reports_userFilters)
            //    _virtualOfficeEntities.ReportUserFilterRels.Remove(reportUserFilterRel);

            var reports_predefinedFilters = _virtualOfficeEntities.ReportPredefinedFilterRels.Where(rel => rel.ReportId == report.Id);
            foreach (var reportUserFilterRel in reports_predefinedFilters)
                _virtualOfficeEntities.ReportPredefinedFilterRels.Remove(reportUserFilterRel);

            var reports_reports = _virtualOfficeEntities.ReportToReportRels.Where(rel => rel.FromId == report.Id);
            foreach (var reportUserFilterRel in reports_reports)
                _virtualOfficeEntities.ReportToReportRels.Remove(reportUserFilterRel);

            var reports_users = _virtualOfficeEntities.UserReports.Where(rel => rel.ReportId == report.Id);
            foreach (var reportUser in reports_users)
                _virtualOfficeEntities.UserReports.Remove(reportUser);

            #endregion

            #region Adding New Relations

            //Inserting tuples in the relational table Reports-PredefinedFilters
            foreach (int predefinedFilter in report.PredefinedFilters)
            {
                _virtualOfficeEntities.ReportPredefinedFilterRels.Add(new ReportPredefinedFilterRel
                {
                    FilterId = predefinedFilter,
                    ReportId = report.Id,
                    TimeSpan = DateTime.Now,
                    RowVersion = ConverterHelper.GetVersionRow()
                });
            }

            //Inserting tuples in the relational table Reports-Reports
            foreach (var subReport in report.SubReports)
            {
                _virtualOfficeEntities.ReportToReportRels.Add(new ReportToReportRel
                {
                    FromId = report.Id,
                    ToId = subReport.Id,
                    DependencyProperty = subReport.ColumnName,
                    IndexParamName = subReport.IndexParamName,
                    TimeSpan = DateTime.Now,
                    RowVersion = ConverterHelper.GetVersionRow()
                });
            }

            //Inserting tuples in the relational table Reports-Users
            foreach (var user in _virtualOfficeEntities.Users)
            {
                _virtualOfficeEntities.UserReports.Add(new Data.UserReport()
                {
                ReportId = report.Id,
                UserId = user.Id,
                Output = report.OutPut,
                OutputConfiguration = !string.IsNullOrEmpty(report.OutPutConfiguration) ? UpdateReportLevels(report.OutPutConfiguration, report.Levels): GetJsonDefaultOutPutConfig(report.OutPut),
                TimeSpan = DateTime.Now,
                RowVersion = ConverterHelper.GetVersionRow()
                });
            }

            _virtualOfficeEntities.SaveChanges();

            #endregion
        }

        #endregion

        #region Reports-Relations
        //public bool IsUserFilterSelected(int? reportId, int filterId)
        //{
        //    var userFilter = _virtualOfficeEntities.ReportUserFilterRels.FirstOrDefault(rel => rel.FilterId == filterId && rel.ReportId == reportId);

        //    return !userFilter.IsNull();
        //}

        public bool IsPredefinedFilterSelected(int? reportId, int filterId)
        {
            var userFilter = _virtualOfficeEntities.ReportPredefinedFilterRels.FirstOrDefault(rel => rel.FilterId == filterId && rel.ReportId == reportId);

            return !userFilter.IsNull();
        }

        public bool IsSubReportSelected(int? fromReportId, int toReportId)
        {
            var userFilter = _virtualOfficeEntities.ReportToReportRels.FirstOrDefault(rel => rel.FromId == fromReportId && rel.ToId == toReportId);

            return !userFilter.IsNull();
        }

        #endregion

        public SubReport GetSubReportProyection(int? fromReportId, int toReportId)
        {
            var subReport = _virtualOfficeEntities.ReportToReportRels.FirstOrDefault(rel => rel.FromId == fromReportId && rel.ToId == toReportId);

            return !subReport.IsNull()
                ? new SubReport
                {
                    ColumnName = subReport.DependencyProperty,
                    IndexParamName = subReport.IndexParamName
                }
                : null;
        }

        public IEnumerable<string> GetReportColumns(int reportId)
        {
            try
            {
                var report = GetReport(reportId);

                return report.OutPut.Split(',');
            }
            catch (Exception exception)
            {
                return null;
            }
   
        }

        public IEnumerable<string> GetReportUserFilters(int reportId)
        {
            try
            {
                var report = GetReport(reportId);

                return report.UserFilters.Split(',');
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        public IEnumerable<Domain.Report> GetSubReports(int? reportId)
        {
            //All active reports not equal to the one that is being edited
            var reports = GetReports().Where(report => report.IsEnable && report.Id != reportId);

            return reports;
        }

        public void RemoveReport(int id)
        {
            //Removing first the item in the relational tables so there is no contraint violation
            _virtualOfficeEntities.ReportToReportRels.Where(report => report.FromId == id || report.ToId == id).ToList().ForEach(rep => _virtualOfficeEntities.ReportToReportRels.Remove(rep));
            _virtualOfficeEntities.UserReports.Where(report => report.ReportId == id).ToList().ForEach(rep => _virtualOfficeEntities.UserReports.Remove(rep));
            //_virtualOfficeEntities.ReportUserFilterRels.Where(report => report.ReportId == id).ToList().ForEach(rep => _virtualOfficeEntities.ReportUserFilterRels.Remove(rep));
            _virtualOfficeEntities.ReportPredefinedFilterRels.Where(report => report.ReportId == id).ToList().ForEach(rep => _virtualOfficeEntities.ReportPredefinedFilterRels.Remove(rep));

            var reportResult = _virtualOfficeEntities.Reports.Find(id);

            _virtualOfficeEntities.Reports.Remove(reportResult);

            _virtualOfficeEntities.SaveChanges();
        }

        public IEnumerable<string> GetReportColumnNames(string spName, List<string> parametersValues)
        {
            try
            {
                var reportParameters = GetReportParameters(spName);

                const string authorizationUrl = HostUrl + AuthorizationUrl;

                var reportArgs = parametersValues.Select((t, i) => new Argument
                {
                    Param = new Parameter
                    {
                        Name = reportParameters[i].Name,
                        Type = reportParameters[i].Type
                    },
                    Value = t
                });

                var reportConfigModel = new ReportConfigModel
                {
                   ReportName = spName,
                   Args = reportArgs
                };

                var serviceResponse = _webClient.Execute<List<string>>(new JsonSerializer().Serialize(reportConfigModel), ApiKey, ApiSecret, new RequestInfo
                {
                    AuthUrl = authorizationUrl,
                    Method = Method.POST,
                    RequestUrl =  HostUrl + "/api/ReportConfiguration/GetReportSchema"
                });

                return serviceResponse;
            }

            catch (Exception exception)
            {
                return null;
            }
        }

        public IEnumerable<string> GetReportColumnNamesExt(string spName)
        {
            try
            {
                var columns = _virtualOfficeEntities.sp_retrieve_storedprocedure_columns(spName);

                return columns;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public List<Domain.Parameter> GetReportParameters(string spName)
        {
            try
            {
                const string authorizationUrl = HostUrl + AuthorizationUrl;

                var serviceResponse = _webClient.Execute<List<Domain.Parameter>>(new { reportName = spName }, ApiKey, ApiSecret, new RequestInfo
                {
                    AuthUrl = authorizationUrl,
                    Method = Method.GET,
                    RequestUrl = HostUrl + "/api/ReportConfiguration/GetReportParameter"
                });

                serviceResponse.ForEach(parameter=> parameter.Type = GetHtmlTypeName(parameter.Type));

                return serviceResponse;
            }

            catch (Exception exception)
            {
                return null;
            }
        }

        public string GetHtmlTypeName(string sqlTypeName)
        {
            var htmlTypeName = _virtualOfficeEntities.Sql_HtmlTypeNameMappings.FirstOrDefault(typeName=> typeName.SqlTypeName==sqlTypeName);

            return htmlTypeName.IsNull() ? "text" : htmlTypeName.HtmlTypeName;
        }

        public bool IsReportNameAvailable(string name)
        {
            var reportName = _virtualOfficeEntities.Reports.FirstOrDefault(report => report.Name == name);

            return reportName.IsNull();
        }

        public string GetColumnLabel(int? reportId, string columnName)
        {
                if (reportId.IsNull())
                    return columnName;

                var columnLabel = _virtualOfficeEntities.ReportLabels.FirstOrDefault(rep => rep.ReportId == reportId.Value && columnName == rep.ColumnName);

                return columnLabel.IsNull() ? columnName : columnLabel.Label;
        }

        //public bool IsFilterNameAvailable(string name)
        //{
        //    var userFilter = _virtualOfficeEntities.UserFilters.FirstOrDefault(report => report.Name == name);

        //    var predefinedFilter = _virtualOfficeEntities.PredefinedFilters.FirstOrDefault(report => report.Name == name);

        //    return userFilter.IsNull() && predefinedFilter.IsNull();
        //}

        public IEnumerable<string> GetStoredProcedureNames()
        {
            var spNames = _virtualOfficeEntities.sp_retrieve_spNames();

            return spNames;
        }

        public string GetReportIndex(int repId)
        {
            var report = GetReport(repId);

            return !report.IsNull() ? report.IndexColumnName : null;
        }

        private void AddColumnLabels(Domain.Report report)
        {
            var output = report.OutPut.Split(',');

            var columnLabels = report.ColumnLabels.Split(',');

            for (int i = 0; i < output.Length; i++)
            {
                var columnLabel = new Data.ReportLabel
                { 
                    ColumnName = output[i],
                    ReportId = report.Id,
                    Label = string.Format("\"{0}\"", columnLabels[i]),
                    TimeSpan = DateTime.Now,
                    RowVersion = ConverterHelper.GetVersionRow()
                };

                _virtualOfficeEntities.ReportLabels.Add(columnLabel);
            }

            _virtualOfficeEntities.SaveChanges();
        }

        private void UpdateColumnLabels(Domain.Report report)
        {
            var output = report.OutPut.Split(',');

            var columnLabels = report.ColumnLabels.Split(',');

            for (int i = 0; i < output.Length; i++)
            {
                var columnName = output[i];

                var currentColumnLabel = _virtualOfficeEntities.ReportLabels.FirstOrDefault(rep => rep.ReportId == report.Id && rep.ColumnName == columnName);

                if (!currentColumnLabel.IsNull())
                {
                    currentColumnLabel.Label = string.Format("\"{0}\"", columnLabels[i]);

                    _virtualOfficeEntities.ReportLabels.AddOrUpdate(currentColumnLabel);
                }
                else
                {
                    var columnLabel = new Data.ReportLabel
                    {
                        ColumnName = output[i],
                        ReportId = report.Id,
                        Label = string.Format("\"{0}\"", columnLabels[i]),
                        TimeSpan = DateTime.Now,
                        RowVersion = ConverterHelper.GetVersionRow()
                    };
                    _virtualOfficeEntities.ReportLabels.Add(columnLabel);
                }
            }

            _virtualOfficeEntities.SaveChanges();
        }

        private string UpdateReportLevels(string reportOutputConfiguration, string reportLevels)
        {

            var reportLevelsByTokens = reportLevels.Split(',');

            var columnsConfig = JsonConvert.DeserializeObject<IEnumerable<ReportColumn>>(reportOutputConfiguration);

            var columnsConfigResult = columnsConfig.Select((a, i) => new ReportColumn
            {
                Name = a.Name,
                Width = a.Width,
                Index = a.Index,
                Label = a.Label,
                Level = int.Parse(reportLevelsByTokens[i])
            });

            var columnsConfigSerialized = JsonConvert.SerializeObject(columnsConfigResult);

            return columnsConfigSerialized;
        }

        private string GetJsonDefaultOutPutConfig(string reportOutPut)
        {
            var columnsConfig = reportOutPut.Split(',').Select((a,i) => new ReportColumn()
            {
                Name = a,
                Width = 120,
                Index = i,
                Level=0
            });

            var columnsConfigSerialized = JsonConvert.SerializeObject(columnsConfig);

            return columnsConfigSerialized;
        }

        public int GetColumnLevel(int? reportId, string columnName)
        {
            try
            {
                var userReportConfig = _virtualOfficeEntities.UserReports.FirstOrDefault(rep => rep.ReportId == reportId);

                var userReportOutPutConfig = userReportConfig.OutputConfiguration;

                var reportColumn = JsonConvert.DeserializeObject<IEnumerable<ReportColumn>>(userReportOutPutConfig);

                var column = reportColumn.FirstOrDefault(col => col.Name == columnName);

                return column.Level;
            }
            catch (Exception)
            {

                return 0;
            }
        }
    }


}
