using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using ApiRestClient.Infrastructure;
using ClassLibrary2.Domain;
using ClassLibrary2.Domain.Others;
using Domain.Models;
using Microsoft.Ajax.Utilities;
using VirtualOffice.Service.Services;
using VirtualOffice.Web.Infrastructure;
using VirtualOffice.Web.Models;
using VirtualOffice.Web.Models.NewReports;
using DateRange = VirtualOffice.Web.Models.DateRange;
using Document = ClassLibrary2.Domain.Others.Document;

namespace VirtualOffice.Web.Controllers
{
    [Authorize(Roles= "User")]
    public class VirtualOfficeController : Controller
    {
        protected readonly IWebClient _webClient;

        // GET: VirtualOffice
        protected readonly VirtualOfficeService _virtualOfficeService;

        public VirtualOfficeController(IWebClient webClient)
        {
            _webClient = webClient;
            
            _virtualOfficeService = new VirtualOfficeService();
        }

        protected Dictionary<string, ColumnConfig> GetUserReportColumnsConfig(int userId, string storeProcedureName, Type type = null)
        {
            var userReport = _virtualOfficeService.GetUserReportConfig(userId, storeProcedureName);

            var userReportOutput = userReport.Output.Split(',');

            var columnsConfig = new JavaScriptSerializer().Deserialize<List<ReportColumn>>(userReport.OutputConfiguration);

            var currentUserLevel = GetUserLevel();

            var result = columnsConfig.Where(c=> c.Level <= currentUserLevel).ToDictionary(column => column.Name, column => new ColumnConfig
            {
                Index = column.Index,
                Hidden = !userReportOutput.Contains(column.Name),
                Width = column.Width,
                Level = column.Level,
                Label = column.Label ?? _virtualOfficeService.GetColumnLabel(storeProcedureName, column.Name),
                IsNumeric = type!= null && type.IsNumericColumn(column.Name),
                IsDate = type!= null && type.IsDateColumn(column.Name)
            });

            return result;
        }

        protected void SaveLastDateRangeInSession(DateTime startDate, DateTime endDate)
        {
            var dateRange = new DateRange
            {
                StartDate = startDate,
                EndDate = endDate
            };

            var currentRange = System.Web.HttpContext.Current.Session[Utils.DateRangeKey] as DateRange;

            if (currentRange.IsNull())
                System.Web.HttpContext.Current.Session.Add(Utils.DateRangeKey, dateRange);
            else
                System.Web.HttpContext.Current.Session[Utils.DateRangeKey] = dateRange;
        }

        protected DateRange GetLastDateRangeInSession()
        {
            var currentDateRange = System.Web.HttpContext.Current.Session[Utils.DateRangeKey] as DateRange;

            var result = currentDateRange ?? new DateRange
            {
                StartDate = Utils.DefaultStartDate,
                EndDate = Utils.DefaultEndDate
            } ;

            return result;
        }

        protected DateRange GetDateRange(string startDate, string endDate)
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

        protected DateRange GetDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                return new DateRange
                {
                    StartDate = startDate,
                    EndDate = endDate
                };
            }
            catch (Exception exception)
            {
                return default(DateRange);
            }
        }

        protected VirtualOfficeReportModel GetReportModel(Dictionary<string, ColumnConfig> columnsConfig, string printLink = null, string storeProcedureName = null)
        {
            var dateRange = GetLastDateRangeInSession();

            var model = new VirtualOfficeReportModel
            {
                ColumnsConfig = columnsConfig,
                DateRange = dateRange,
                PrintLink = printLink,
                StoreProcedureName = storeProcedureName
            };

            return model;
        }

        #region Features and Config
        
        [HttpPost]
        public virtual ActionResult UpdateColumnWidth(string storeProcedureName, string columnName, int width)
        {
            try
            {
                var userReport = _virtualOfficeService.GetUserReportConfig(GetLoggedUserId(), storeProcedureName);

                var outputConfig = new JavaScriptSerializer().Deserialize<List<ReportColumn>>(userReport.OutputConfiguration);

                var column = outputConfig.FirstOrDefault(col => col.Name == columnName);

                if (column != null)
                {
                    column.Width = width;

                    var updatedOutputConfig = new JavaScriptSerializer().Serialize(outputConfig);

                    _virtualOfficeService.UpdateUserReportOutPutConfig(GetLoggedUserId(), storeProcedureName, updatedOutputConfig);
                }

                return Json(true);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Printing

        protected ActionResult PrintReport(string storeProcedureName, string methodName, params object[] methodParams)
        {
            try
            {
                var columnsConfig = GetUserReportColumnsConfig(GetLoggedUserId(), storeProcedureName);

                var method = _virtualOfficeService.GetType().GetMethod(methodName);

                var data = method.Invoke(_virtualOfficeService, methodParams) as IEnumerable<object>;

                var result = GetReportData(data);

                var reportModel = new VirtualOfficeReportModel
                {
                    ColumnsConfig = columnsConfig,
                    Data = result
                };

                return View("PrintReport", reportModel);
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        protected IEnumerable<Dictionary<string, object>> GetReportData<T>(IEnumerable<T> data)
        {
            return data.Select(GetRowData);
        }

        private Dictionary<string, object> GetRowData<T>(T data)
        {
            var dictResult = new Dictionary<string, object>();

            var objProperties = data.GetType().GetProperties();

            foreach (var propertyInfo in objProperties)
            {
                var propertyName = propertyInfo.Name;
                var propertyValue = propertyInfo.GetValue(data);

                dictResult.Add(propertyName, propertyValue);
            }
            return dictResult;
        }

        #endregion

        #region Exporting to Excel

        public ActionResult ExportReportsToExcel(string storeProcedureName, string methodName, params object[] methodParams)
        {
            try
            {
                var columnsConfig = GetUserReportColumnsConfig(GetLoggedUserId(), storeProcedureName);

                var method = _virtualOfficeService.GetType().GetMethod(methodName);

                var data = method.Invoke(_virtualOfficeService, methodParams) as IEnumerable<object>;

                var gridResult = ExportToExcel(data, columnsConfig);

                var fileName = String.Format("Report_{0}_{1}_{2}.xls", DateTime.Now.Day, DateTime.Now.Minute, DateTime.Now.Second);

                //Exporting the File to Excel
                return new ReportFileActionResult(gridResult, fileName);
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        protected GridView ExportToExcel<T>(IEnumerable<T> data, Dictionary<string, ColumnConfig> columnsConfig)
        {

            var table = new DataTable();

            var projectedColumns = columnsConfig.Where(col => ! col.Value.Hidden).Select(x => x.Key).ToList();

            //Adding Headers
            foreach (var column in projectedColumns)
               table.Columns.Add(column, typeof(string));

            //Copying Data to the Table
            foreach (var t in data)
            {
                var row = table.NewRow();

                var tableRow = GetRowData(t);

                foreach (var column in projectedColumns)
                {
                    row[column] = tableRow.ContainsKey(column)?tableRow[column]:
                                  string.Empty;
                }

                table.Rows.Add(row);
            }

            var gridResult = new GridView
            {
                DataSource = table
            };

            gridResult.DataBind();

            return gridResult;
        }
        #endregion

        #region Aux Ops
        protected int GetLoggedUserId()
        {
            var userModel = HttpContext.Session[Utils.UserKey] as UserModel;

            return userModel == null || userModel.Role.Equals(RolesEnum.Master.ToString()) ? 0 : userModel.UserId;
        }

        protected Category GetUserCategory()
        {
            var userModel = HttpContext.Session[Utils.UserKey] as UserModel;

            return userModel != null ? (Category)int.Parse(userModel.UserCategory) : default(Category);
            
        }

        protected int GetLoggedAgentType()
        {
            var userCategory = GetUserCategory();

            var agentType = userCategory == Category.Distributor || userCategory == Category.AgentISO ? 0 : userCategory == Category.Agent ? 1 : 2;

            return agentType;
        }

        #endregion

        #region Application Level Ops

        protected AgentTimeFilter GetAgentDateParameters(string startDate, string endDate)
        {
            var startDateTime = DateTime.MinValue;

            var endDateTime = DateTime.Today;

            //If at least one of the 2 is not empty
            if (!string.IsNullOrEmpty(startDate + endDate))
            {
                DateTime.TryParse(startDate, out startDateTime);

                DateTime.TryParse(endDate, out endDateTime);
            }

            return new AgentTimeFilter
            {
                AgentId = GetLoggedUserId(),
                StartDate = startDateTime,
                EndDate = endDateTime
            };
        }

        protected int GetUserLevel()
        {
            try
            {
                var currentUser = GetCurrentUser();

                var userLevel = currentUser != null ? int.Parse(currentUser.UserCategory) : 0;

                return userLevel;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        protected UserModel GetCurrentUser()
        {
            try
            {
                var userModel = Session[Utils.UserKey] as UserModel;

                return userModel;
            }
            catch (Exception exception)
            {
                return null ;
            }
        }

        protected bool UserIsMerchant()
        {
            return GetUserLevel() == 0;
        }

        #region Leads
        protected IEnumerable<ClassLibrary2.Domain.Others.Lead> GetAllLeads(DateTime? startDate = null, DateTime? endDate= null)
        {
            //var getLeadsRequestInfo = Utils.GetRequestInfo(Method.POST, "/api/Lead/GetLeads");

            //var parameters = GetAgentDateParameters(startDate, endDate);

            //var leads = _webClient.Execute<List<Lead>>(parameters, ApiUrls.API_KEY, ApiUrls.API_SECRET, getLeadsRequestInfo);

            var leads = _virtualOfficeService.GetAllLeads(GetLoggedUserId(),startDate, endDate);

            return leads;
        }

        protected IEnumerable<ClassLibrary2.Domain.Others.Lead> GetOpenLeads(DateTime? startDate, DateTime? endDate)
        {
            var allLeads = GetAllLeads(startDate, endDate);

            var result =
                allLeads.Where(l => !String.Equals(l.Status, Utils.Closed, StringComparison.CurrentCultureIgnoreCase));

            return result;
        }

        protected IEnumerable<ClassLibrary2.Domain.Others.Lead> GetOpenLeadsForDashBoard()
        {
            return GetOpenLeads(null, null);
        }
        #endregion

        #region Incidents

        protected IEnumerable<ClassLibrary2.Domain.Others.Incident> GetAllIncidents(DateTime? startDate = null, DateTime? endDate = null)
        {
            //var getIncidentsRequestInfo = Utils.GetRequestInfo(Method.POST, "/api/Incident/GetIncidents");

            //var parameters = GetAgentDateParameters(startDate, endDate);

            //var incidents = _webClient.Execute<List<Incident>>(parameters, ApiUrls.API_KEY, ApiUrls.API_SECRET, getIncidentsRequestInfo);

            var incidents = _virtualOfficeService.GetAllIncidents(GetLoggedUserId(), startDate, endDate);

            return incidents;
        }

        protected IEnumerable<ClassLibrary2.Domain.Others.Incident> GetOpenIncidents(DateTime startDate, DateTime endDate)
        {
            var allIncidents = GetAllIncidents(startDate, endDate);
            var result =
                allIncidents.Where(
                    lead => String.Equals(lead.Incident_Status, Utils.ClosedIncident, StringComparison.CurrentCultureIgnoreCase));
            return result;
        }

        protected IEnumerable<ClassLibrary2.Domain.Others.Incident> GetOpenedIncidentesForDashboard()
        {
            return GetOpenIncidents(DateTime.Now.AddMonths(-3), DateTime.Now);
        }
        #endregion

        #region Marketing Material
        protected IEnumerable<MarketingProduct> GetMarketingMaterials()
        {
            try
            {
               // var requestInfo = Utils.GetRequestInfo(Method.GET, "/api/Inventory/GetItems");

               //var marketingItems = _webClient.Execute<List<InventoryItem>>(ApiUrls.API_KEY, ApiUrls.API_SECRET, requestInfo);

                var marketingItems = _virtualOfficeService.GetMarketingMaterials().ToList();

              //  var 

                //To be changed by dynamic categories
                var categories = new[] { Utils.MarketingBanners, Utils.MarketingPosters, Utils.MarketingStickers };

                var freeItems = marketingItems.Where(item => item.Price == 0 && categories.Any(cat => item.Name.Contains(cat))).ToList();

                freeItems.ForEach(a=> a.Category = GetItemCategory(a.Name));

                var marketingMaterials = freeItems.MapTo<IEnumerable<MarketingMaterial>, IEnumerable<MarketingProduct>>();

                return marketingMaterials;
            }
            catch (Exception exception)
            {
                return new List<MarketingProduct>();
            }
        }

        private string GetItemCategory(string itemDescription)
        {
            //To be changed by dynamic categories
            var categories = new[] { Utils.MarketingBanners, Utils.MarketingPosters, Utils.MarketingStickers };

            var category = categories.FirstOrDefault(itemDescription.Contains);

            return category;
        }
        #endregion

        #region Forms and Applications

        protected IEnumerable<Document> GetDocuments()
        {
            var documents = _virtualOfficeService.GetAllDocuments();

            return documents;
        }
        #endregion

        #endregion

    }
}