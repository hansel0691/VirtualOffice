using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlTypes;
using System.Dynamic;
using System.Net;
using System.Reflection;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI.WebControls;
using ApiRestClient.Models;
using ClassLibrary2.Domain;
using Domain.Infrastructure.Services;
using Domain.Models;
using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;
using Microsoft.Data.Edm.Expressions;
using RestSharp;
using VirtualOffice.Web.Models;
using VirtualOffice.Web.Models.NewReports;
using UrlHelper = System.Web.Http.Routing.UrlHelper;

namespace VirtualOffice.Web.Infrastructure
{
    public static class Utils
    {

        #region Common Values

        public static int MaximunReportCount { get { return 10000; } }
        public static string FullCargaUrl { get { return "http://virtual.fcusa.us/"; } }

        public static string ArgumentsKey { get { return "ArgumentsKey"; } }

        public static string DateRangeKey { get { return "DateRangeKey"; } }

        public static string Closed { get { return "Closed"; } }

        public static string ClosedIncident { get { return "Closed Incident"; } }

        public static string ReportIdsKey { get { return "ReportIdsKey"; } }

        public static string NumericColumnsKey { get { return "NumericColumnsKey"; } }

        public static string DateTimeType { get { return "datetime"; } }

        public static string StartDateSubstring { get { return "@ini_date"; } }

        public static string EndDateSubstring { get { return "@end_date"; } }

        public static string LoggedUserKey { get { return "User"; } }

        public static string Portfolio { get { return "Portfolio"; } }

        public static string Sales { get { return "Sales"; } }

        public static string LeadInterestedIn { get { return "INTERESTEDINxx"; } }

        public static string LeadHear { get { return "Hear"; } }

        public static string LeadHearX { get { return "Hearxx"; } }

        public static string UserKey { get { return "User"; } }

        public static string AgentForms { get { return "Agent Forms"; } }

        public static string DistributorForms { get { return "Distributor Forms"; } }

        public static string AppsAgreements { get { return "Applications and Agreements"; } }

        public static string VirtualOfficeLink { get { return "virtualofficeDocumentsLink"; } }
     
        public static string NewVirtualOfficeLink { get { return "NewVirtualofficeDocumentsLink"; } }
        
        public static string CloudsWereRefreshed { get { return "CloudsWereRefreshed"; } }

        //public static DateTime DefaultStartDate { get { return GetFirst_LastDayInLastMonths(3).StartDate; } }
        public static DateTime DefaultStartDate { get { return DateTime.Today.AddMonths(-3); } }

        //public static DateTime DefaultEndDate { get { return GetFirst_LastDayInLastMonths(1).EndDate; } }
        public static DateTime DefaultEndDate { get { return DateTime.Today; } }

        public static string MarketingPosters { get { return "Poster"; } }

        public static string MarketingStickers { get { return "Sticker"; } }

        public static string MarketingBanners { get { return "Banner"; } }

        public static string Success { get { return "Success"; } }

        public static string Updated { get { return "Updated"; } }

        public static string Error { get { return "Erros"; } }

        public static string ExternalLoginIdentifier { get { return "Token"; } }

        public static string VoDocumentsPhisicalLocation { get { return @"//virtualoffice.blackstoneonline.com/Documents/"; } }

        #endregion

        #region Helpers

        public static bool IsLike(this string str, string strOther)
        {
            const int fairDistance = 2;

            return str.IsLike(strOther, fairDistance);
        }

        public static string MostAlike(this string str, List<string> others)
        {
            others.Sort((a, b) =>
            {
                var strA = Distance(str, a);
                var strB = Distance(str, b);

                return strA.CompareTo(strB);
            });

            return others.FirstOrDefault();
        }


         public static bool IsLike(this string str, string strOther, int level)
          {
              var distance = Distance(str, strOther);

              return distance <= level;
          }

         

        public static bool IsNull(this object t)
        {
            return t == null;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> data)
        {
            return data.IsNull() || !data.Any();
        }

        public static RequestInfo GetRequestInfo(Method requestMethod, string requestUrl)
        {
            var requestInfo = new RequestInfo
            {
                AuthUrl = ApiUrls.AUHT_URL,
                Method = requestMethod,
                RequestUrl = ApiUrls.HOST_URL + requestUrl
            };

            return requestInfo;
        }

        public static IEnumerable<Argument> GetReportArguments(string agentId, ReportConfigViewModel reportConfig)
        {
            try
            {
                var idParamater = GetArgument("agent_id", agentId);

                return new List<Argument> { idParamater };
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public static string GetFormattedAddress(string address1, string address2, string city, string state, string zipCode, string country)
        {
            try
            {
                var address = string.Format("{0} {1},{2},{3} {4}, {5}", address1, address2, city, state, zipCode,
                    country);

                return address;
            }
            catch (Exception exception)
            {
                return string.Empty;
            }
        }

        public static IEnumerable<string> GetReportOutPut(IEnumerable<ExpandoObject> data)
        {
            try
            {
                if (data == null || !data.Any())
                    return null;

                var firstRow = data.First();

                return (firstRow as IDictionary<string, object>).Keys;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public static IEnumerable<string> GetDistinctElements(IEnumerable<ExpandoObject> reportData, string columnName)
        {
            try
            {
                var distinctElements = reportData.Select(row => row as IDictionary<string, object>).Select(rowContent => rowContent[columnName].ToString()).Distinct();

                return distinctElements;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DataTable GetDataTable(IEnumerable<IDictionary<string, object>> reportData)
        {
            var tableResult = new DataTable();

            var firstRow = reportData.First();

            foreach (var columnName in firstRow.Keys)
                tableResult.Columns.Add(columnName);

            foreach (var row in reportData)
            {
                var dataRow = tableResult.NewRow();

                foreach (var rowContent in row)
                    dataRow[rowContent.Key] = rowContent.Value;

                tableResult.Rows.Add(dataRow);
            }

            return tableResult;
        }

        public static IEnumerable<string> GetSelectedItemsForFilters(IEnumerable<string> elementsUniverse, UserReportViewModel report, string columnName)
        {
            try
            {
                var userFilterValues = report.UserFiltersConfig.Where(filter => filter.Key == columnName).Select(a => a.Value).ToList();

                var listResult = elementsUniverse.Where(userFilterValues.Contains);

                return listResult;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string GetCommaSeparatedTokens(this IEnumerable<string> tokens)
        {
            if (tokens.IsNull() || !tokens.Any())
                return string.Empty;

            var result = tokens.Aggregate(string.Empty, (current, token) => current + (token + ","));

            return result.Remove(result.Length - 1);
        }

        public static string GetClientTemplate(string mainPath, UserReportViewModel userReportViewModel, SubReportConfigModel subReport, bool isColumnNumeric)
        {
            var numericSymbolForColumn = isColumnNumeric ? "$" : "";

            var indexColumn = !string.IsNullOrEmpty(userReportViewModel.IndexColumnName) ? "&indexParamName=" + userReportViewModel.IndexColumnName + "&indexParamValue=" + "#=" + userReportViewModel.IndexColumnName.Replace(' ', '_') + "#" : string.Empty;

            var rangeDateParams = GetRangeDateParams(userReportViewModel.Output);

            try
            {
                var dataTemplate = "<a href='" + mainPath + "?reportId=" + userReportViewModel.ReportId + "&subReportId=" + subReport.SubReportId + indexColumn + rangeDateParams + "&columnName=" + subReport.DependencyProperty + "&columnValue=" + "#=" + subReport.DependencyProperty + "#" + "'>" + numericSymbolForColumn + "#=" + subReport.DependencyProperty + "#" + "</a>";

                return dataTemplate;
            }
            catch (Exception exception)
            {
                return string.Empty;
            }


        }

        private static string GetRangeDateParams(string outputConfig)
        {
            var columnNames = GetReportColumnNames(outputConfig);

            var beginDate = columnNames.FirstOrDefault(IsBeginDateColumn);

            var beginDateParam = string.IsNullOrEmpty(beginDate)? string.Empty: string.Format("&beginDate=#={0}#", beginDate);

            var endDate = columnNames.FirstOrDefault(IsEndDateColumn);

            var endDateParam = string.IsNullOrEmpty(endDate) ? string.Empty : string.Format("&endDate=#={0}#", endDate);

            return beginDateParam + endDateParam;

        }

        public static bool IsIdParameter(this string parameterName)
        {
            return parameterName.ToLower().IsLike("agentid") || parameterName.ToLower().IsLike("mid");
        }

        public static void AddArguments(this List<Argument> args, IEnumerable<Argument> extraArgs)
        {
            //Adds all non-null and distinct arguments to the current collection (it could be performed with some "set structure" and a custom equality definition for Argument)
            foreach (var argument in extraArgs)
            {
                if (argument.IsNull())
                    continue;
                var existentArg = args.FirstOrDefault(arg => arg.Param.CompareTo(argument.Param) == 0);

                if (!existentArg.IsNull())
                    args.Remove(existentArg);

                args.Add(argument);
            }
        }

        public static T TryGetValue<T>(this IList<T> list, int index)
        {
            try
            {
                var value = list[index];

                return value;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public static string RemoveQuotationMarks(this string str)
        {
            str = str.Trim('"');

            return str;
        }

        public static bool IsBeginDateColumn(string columnName)
        {
            return columnName == "begindate";
        }

        public static bool IsEndDateColumn(string columnName)
        {
            return columnName == "enddate";
        }

        /// Created By:Carlos Garcia
        /// <summary>
        /// Method used to create a Grid ready to be exported to excel upon some data collection
        /// </summary>
        /// <returns></returns>
        /// 
        public static GridView ExportToExcel(this UserReportViewModel userReport, IDictionary<int, SortedSet<string>> numericColumnDict)
        {

            var table = new DataTable();

            //Adding Headers
            foreach (var column in userReport.Columns.Where(col => col.Selected))
            {
                var col = table.Columns.Add(column.Name, typeof(string));
                col.Caption = GetColumnLabel(userReport.Labels, column.Name);
            }

            //Copying Data to the Table
            foreach (var t in userReport.Data)
            {
                var row = table.NewRow();

                var tableRow = t as IDictionary<string, object>;

                foreach (var column in userReport.Columns.Where(col => col.Selected))
                {
                    row[column.Name] = tableRow[column.Name];
                }

                table.Rows.Add(row);
            }

            if (!numericColumnDict.IsNull() && numericColumnDict.ContainsKey(userReport.ReportId))
            {
                var numericColumnNames = numericColumnDict[userReport.ReportId];

                //Summary Row
                var lastRow = table.NewRow();

                foreach (var t in numericColumnNames)
                    lastRow[t] = GetColumnSum(table, t).ToString("C");

                table.Rows.Add(lastRow);
            }

            var gridResult = new GridView
            {
                DataSource = table
            };

            gridResult.DataBind();

            return gridResult;
        }

        

        public static string GetColumnLabel(IEnumerable<LabelViewModel> labels, string columnName)
        {
            var label = labels.FirstOrDefault(lab => lab.ColumnName == columnName);

            return !label.IsNull() ? label.Label.RemoveQuotationMarks() : columnName;
        }

        public static MyDataSourceResult ToMyDataSourceResult(this IEnumerable<ExpandoObject> reportData, DataSourceRequest request)
        {
            var aggregateResults = GetAggregateResults(reportData, request);

            var dataSourceResult = new MyDataSourceResult
            {
                AggregateResults = aggregateResults,
                Data = reportData,
                Total = reportData.Count()
            };

            return dataSourceResult;
        }

        public static string GetFooterTemplate(IEnumerable<ExpandoObject> reportData, string columnName)
        {
            try
            {
                var numericColumns = NumericColumnNames(reportData.FirstOrDefault());

                if (!numericColumns.Contains(columnName))
                    return string.Empty;

                var dataTable = GetDataTable(reportData);

                var columnSum = GetColumnSum(dataTable, columnName);

                return columnSum.ToString("C");
            }
            catch (Exception)
            {

                return string.Empty;
            }
        }

        public static string GetListItemClassByUrl(string requestedUrl, params string[] urls)
        {
            const string domainPrefix = "http://virtualoffice.pinserve.com";

            var navigationsUrls = urls.Select(url => domainPrefix + url);

            return navigationsUrls.Contains(requestedUrl) ? "active" : string.Empty;
        }

        public static string GetListItemClassByController(string url, string requestedUrl)
        {

            var urlControllerName = GetControllerName(url);

            var requestControllerName = GetControllerName(requestedUrl);

            return urlControllerName == requestControllerName ? "active" : string.Empty;
        }

        public static IEnumerable<SelectListItem> GetAllStates()
        {
            var statesDic = GetStatesStaticDictionary();

            var statesResult = statesDic.Keys.Select(k => new SelectListItem { Text = k, Value = statesDic[k] });

            return statesResult;
        }

        public static IEnumerable<SelectListItem> GetAllLanguages()
        {
            return new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "English",
                    Value = "1"
                },
                new SelectListItem
                {
                    Text = "Spanish",
                    Value = "2"
                },
                new SelectListItem
                {
                    Text = "French",
                    Value = "3"
                }
            };
        }

        public static T GetInstance<T>(Dictionary<string, object> objectBag) where T : new()
        {
            var objectInstance = (T)Activator.CreateInstance(typeof(T));

            var objectType = typeof(T);

            foreach (var propertyInfo in objectType.GetProperties())
            {
                propertyInfo.SetValue(objectInstance, objectBag[propertyInfo.Name]);
            }

            return objectInstance;
        }

        public static IEnumerable<T> GetInstanceCollection<T>(IEnumerable<Dictionary<string, object>> objectsBag) where T : new()
        {
            return !objectsBag.Any() ? new List<T>() : objectsBag.Select(GetInstance<T>);
        }

        public static bool IsUserAgent(string userCategory)
        {
            var userLevel = GetUserLevel(userCategory);

            return userLevel > 0;
        }

        public static IEnumerable<AdditionalReport> GetAdditionalSalesReport(WebViewPage helper)
        {
            return new List<AdditionalReport>
            {
                new AdditionalReport
                {
                    ReportLink = helper.Url.Action("SummarySalesReport", "Reports"),
                    ReportName = "Summary Sales Report"
                }
            };
        }

        public static IEnumerable<SelectListItem> GetSummarySalesOptions()
        {
         return new List<SelectListItem>
         {
             new SelectListItem
             {
                 Text = SummaryRangeOption.Last12Months.ToString(),
                 Value = ((int)SummaryRangeOption.Last12Months).ToString(),
                 Selected = true
             },
                new SelectListItem
             {
                 Text = SummaryRangeOption.Last9Months.ToString(),
                 Value = ((int)SummaryRangeOption.Last9Months).ToString(),
             },
                new SelectListItem
             {
                 Text = SummaryRangeOption.Last6Months.ToString(),
                 Value = ((int)SummaryRangeOption.Last6Months).ToString(),
             }
         };
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

        public static bool IsBetween(this DateTime date, DateTime monthStartDate)
        {
            var endDate = monthStartDate.AddMonths(1).AddDays(-1);

            return date >= monthStartDate && date <= endDate;
        }

        public static DateRange GetFirst_LastDayRange(int month, int year)
        {
            return GetFirst_LastDayRange(new SummaryRange
            {
                Month = month,
                Year = year
            });
        }

        public static DateRange GetFirst_LastDayInLastMonths(int months)
        {
            var pastDate = DateTime.Now.AddMonths((-1)*months);

            var first_lastDate = GetFirst_LastDayRange(pastDate.Month, pastDate.Year);

            return new DateRange
            {
                StartDate = first_lastDate.StartDate,
                EndDate = first_lastDate.EndDate
            };
        }

        #endregion

        #region Aux Functions
        private static Argument GetArgument(string paramName, object value, string paramType = "")
        {
            return new Argument
            {
                Param = new Domain.Models.Parameter
                {
                    Name = paramName,
                    Type = paramType
                },
                Value = value
            };
        }

        private static IEnumerable<MyAggregateResult> GetAggregateResults(IEnumerable<ExpandoObject> reportData, DataSourceRequest request)
        {
            try
            {
                var aggregateResults = new List<MyAggregateResult>();

                var dataTable = GetDataTable(reportData);

                foreach (var column in request.Aggregates)
                {
                    var totalValue = GetColumnSum(dataTable, column.Member);

                    var aggregateFunction = new SumFunction();

                    var newAggregate = new AggregateResult(totalValue.ToString("C"), aggregateFunction);

                    var newMyAggregateResult = new MyAggregateResult
                    {
                        Value = newAggregate.Value,
                        FormattedValue = newAggregate.FormattedValue,
                        AggregateMethodName = newAggregate.AggregateMethodName,
                        FunctionName = newAggregate.FunctionName,
                        Member = column.Member,
                        ItemCount = newAggregate.ItemCount,
                        Caption = newAggregate.Caption
                    };

                    aggregateResults.Add(newMyAggregateResult);
                }

                return aggregateResults;

            }
            catch (Exception)
            {

                return null;
            }
        }

        private static string GetControllerName(string url)
        {
            try
            {
                var controllerName = string.Empty;

                var separatorLastIndex = url.LastIndexOf('/');

                for (var i = separatorLastIndex - 1; i >= 0 && url[i] != '/'; i--)
                {
                    controllerName += url[i];
                }

                controllerName.Reverse();

                return controllerName;
            }
            catch (Exception)
            {

                return string.Empty;
            }
        }

        private static Type GetNullableType(this Type t)
        {
            var returnType = t;
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                returnType = Nullable.GetUnderlyingType(t);
            }
            return returnType;
        }

        private static double GetColumnSum(DataTable table, string columnsName)
        {
            var rows = table.AsEnumerable();

            double total = 0;

            foreach (var row in rows)
            {
                var rowValue = Convert.ToDouble(row[columnsName].ToString().GetPlaneFormat());

                total += rowValue;
            }

            return total;

            //return table.AsEnumerable().Sum(dataRow => Convert.ToDouble(dataRow[columnsName].ToString().GetPlaneFormat()));
        }

        private static IEnumerable<string> NumericColumnNames(ExpandoObject tableRow)
        {
            try
            {
                var row = tableRow as IDictionary<string, object>;

                return row.Keys.Where(columnName => row[columnName].ToString().Contains("$"));
            }
            catch (Exception)
            {

                return null;
            }

        }

        public static string GetPlaneFormat(this object dataValue)
        {
            try
            {
                var str = dataValue.ToString();

                var stringResult = str.Where(charValue => charValue != '$' && charValue != ' ').Aggregate(string.Empty, (current, charValue) => current + charValue);

                return stringResult;
            }
            catch (Exception exception)
            {

                return dataValue.ToString();
            }
        }

        private static bool IsNullableType(this Type type)
        {
            return (type == typeof(string) ||
                    type.IsArray ||
                    (type.IsGenericType &&
                     type.GetGenericTypeDefinition() == typeof(Nullable<>)));
        }

        private static IEnumerable<string> GetReportColumnNames(string outputConfig)
        {
            var result = outputConfig.Split(',');

            return result;
        }


        public static int GetUserLevel(string userCategory)
        {
            try
            {
                var category = GetUserCategory(userCategory);

                return (int)category;

            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        public static Category GetUserCategory(string userCategory)
        {
            try
            {
                var numericUserCategory = int.Parse(userCategory);

                var categories = Enum.GetValues(typeof(Category));

                foreach (var category in categories)
                {
                    if ((int)category == numericUserCategory)
                        return (Category)category;
                }

                return default(Category);
            }
            catch (Exception exception)
            {
                return default(Category);
            }
        }

        //This horrible implementation was because of Nicolas' Perez fault. :)
        private static Dictionary<string, string> GetStatesStaticDictionary()
        {
            var dictionary = new Dictionary<string, string>
            {
                {"AA","Armed Forces - AA"},{"AE","Armed Forces - AE"},{"AK","Alaska"},{"AL","Alabama"},
                {"AP","Armed Forces - AP"},{"AR","Arkansas"},{"AS","American Samoa"},{"AZ","Arizona"},
                {"CA","California"},{"CO","Colorado"},{"CT","Conneticut"},{"DC","Washington DC"},
                {"DE","Delaware"},{"FL","Florida"}, {"FM","Federated States of Micronesia"},  {"GA","Georgia"},
                {"GU","Guam"}, {"HI","Hawaii"},{"IA","Iowa"},  {"ID","Idaho"},  {"IL","Illinois"},  {"IN","Indiana"},
                {"KS","Kansas"}, {"KY","Kentucky"},{"LA","Louisiana"},{"MA","Massachusetts"},{"MD","Maryland"},
                {"ME","Maine"},{"MH","Marshall Islands"},{"MI","Michigan"},{"MN","Minnesota"},{"MO","Missouri"},
                {"MP","Northern Mariana Islands"},{"MS","Mississippi"},{"MT","Montana"},{"NC","North Carolina"},
                {"ND","North Dakota"},{"NE","Nebraska"},{"NH","New Hampshire"},{"NJ","New Jersey"},
                {"NM","New Mexico"},{"NV","Nevada"},{"NY","New York"},
                {"OH","Ohio"},{"OK","Oklahoma"},  {"OR","Oregon"},{"PA","Pennsylvania"},     {"PR","Puerto Rico "},
                {"PW","Palau"},{"RI","Rhode Island"}, {"SC","South Carolina"},
                {"SD","South Dakota"},{"TN","Tennessee"},{"TX","Texas"},{"UT","Utah"},{"VA","Virginia"},{"VI","Virgin Islands"},
                {"VT","Vermont"},{"WA","Washington"}, {"WI","Wisconsin"},{"WV","West Virginia"},{"WY","Wyoming"}

            };
            return dictionary;
        }

        private static int Distance(string a, string b)
        {
            int num3;
            int num = a.Length + 1;
            int num2 = b.Length + 1;
            int[,] numArray = new int[num, num2];
            for (num3 = 0; num3 < num; num3++)
            {
                numArray[num3, 0] = num3;
            }
            for (num3 = 0; num3 < num2; num3++)
            {
                numArray[0, num3] = num3;
            }
            for (num3 = 1; num3 < num; num3++)
            {
                for (int i = 1; i < num2; i++)
                {
                    numArray[num3, i] = (a[num3 - 1] == b[i - 1]) ? numArray[num3 - 1, i - 1] : Math.Min(numArray[num3 - 1, i] + 1, Math.Min((int)(numArray[num3, i - 1] + 1), (int)(numArray[num3 - 1, i - 1] + 1)));
                }
            }
            return numArray[num - 1, num2 - 1];
        }

        #endregion

        #region New Version

        public static Dictionary<string, ColumnConfig> AddLinkToColumnsConfig(Dictionary<string, ColumnConfig> columnsConfig , string columnName, string linkTemplate)
        {
            if (!columnsConfig.ContainsKey(columnName))
                return columnsConfig;

            var column = columnsConfig[columnName];

            column.Link = linkTemplate;

            return columnsConfig;
        }

        public static bool IsNumericColumn(this Type type, string memberName)
        {
            var member = type.GetProperties().FirstOrDefault(m => m.Name == memberName);

            return member != null && (member.PropertyType == typeof(double) || member.PropertyType == typeof(double?) || member.PropertyType == typeof(decimal) || member.PropertyType == typeof(decimal?));
        }

        public static bool IsDateColumn(this Type type, string memberName)
        {
            var member = type.GetProperties().FirstOrDefault(m => m.Name == memberName);

            return member != null && (member.PropertyType == typeof(DateTime) || member.PropertyType == typeof(DateTime?));
        }

        #endregion

        public static DateRange GetDateRangeForReport(VirtualOfficeReportModel model)
        {
            var startDate = DefaultStartDate;
            var endDate = DefaultEndDate;

            if (model != null && model.DateRange != null)
            {
                startDate = model.DateRange.StartDate;
                endDate = model.DateRange.EndDate;
            }

            return new DateRange
            {
                StartDate = startDate,
                EndDate = endDate
            };
        }

        /// <summary>
        /// It counts the reports of the Badges (It must be updated each time a Report is Created because of its logic)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static Dictionary<DashboardItemType, int> GetReportsCountByUser(UserModel user)
        {
            var result = new Dictionary<DashboardItemType, int>
            {
            {DashboardItemType.Prepaid,0},
            {DashboardItemType.MerchantServices,0}
            };

            if (user.IsFullcarga)
            {
                result[DashboardItemType.Prepaid] = 7;
                return result;
            }

            try
            {
                var userCategory = GetUserCategory(user.UserCategory);

                switch (userCategory)
                {
                    case Category.Merchant:
                    {
                        result[DashboardItemType.Prepaid] = 8;
                        break;
                    }
                    default:
                    {
                        result[DashboardItemType.Prepaid] = 10;
                        result[DashboardItemType.MerchantServices] = 3;
                        break;
                    }
                }

                return result;
            }
            catch (Exception exception)
            {
                return result;
            }
        }

        public static bool IsNumeric(object member)
        {
            double output;
            return member != null && double.TryParse(member.ToString(), out output);
        }
    }
}