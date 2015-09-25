using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ApiRestClient.Infrastructure;
using Domain.Models;
using Domain.Models.Exceptions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RestSharp;
using VirtualOffice.Web.Infrastructure;
using VirtualOffice.Web.Models;

namespace VirtualOffice.Web.Controllers
{
    [Authorize(Roles = "User")]
    public class MyProfileController: VirtualOfficeController
    {
        public MyProfileController(IWebClient webClient) : base(webClient)
        {
        }


        public ActionResult PersonalInfo()
        {
            return View();
        }



        public ActionResult ChangePassword()
        {

            ViewBag.Reports = GetUserReports(GetLoggedUserId()).Where(rep => rep.IsStandAlone);

            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            try
            {
                 ViewBag.Reports = GetUserReports(GetLoggedUserId()).Where(rep => rep.IsStandAlone);

                changePasswordModel.UserName = GetLoggedUserId();

                SetNewPassword(changePasswordModel);

                return Json(new {Result = "Success", Message = "Your password was successfully updated."});
            }
            catch (Exception exception)
            {
                if (exception is NotFoundException)
                {
                    return Json(new { Result = "Errors", Message = "Old Password is Incorrect." });
                }

                return Json(new { Result = "Success", Message = "There were errors while proccesing your request.Try again later please." });
            }
        }

        public ActionResult OpenLeads()
        {

            ViewBag.Reports = GetUserReports(GetLoggedUserId());

            return View();
        }

        public ActionResult HistoricLeads()
        {

            ViewBag.Reports = GetUserReports(GetLoggedUserId());

            return View();
        }

        public ActionResult GetLeads([DataSourceRequest] DataSourceRequest dataSourceRequest, int? leadType)
        {
            try
            {
                var leads = GetAllLeads();

                var leadsResult = (leadType == (int)LeadType.Closed)
                    ? leads.Where(lead => String.Equals(lead.Status, Utils.Closed, StringComparison.CurrentCultureIgnoreCase))
                    : leads.Where(l => !String.Equals(l.Status, Utils.Closed, StringComparison.CurrentCultureIgnoreCase));

                var result = leadsResult.ToDataSourceResult(dataSourceRequest);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public ActionResult NewLead()
        {

            var leadsFor = GetLeadsPropose();

            var leadsHearing = GetHearingTypes();
            
            ViewBag.LeadsFor = leadsFor;
            ViewBag.LeadsHearing = leadsHearing;
            ViewBag.Reports = GetUserReports(GetLoggedUserId()).Where(rep => rep.IsStandAlone);

            return View();
        }

        [HttpPost ]
        public ActionResult AddNewLead(NewLeadViewModel newLeadViewModel)
        {
            try
            {
               SetUpNewLead(newLeadViewModel);
                
                var insertNewLeadResponse = AddLead(newLeadViewModel);

                var result = insertNewLeadResponse < 0 ? "Error" : "Success";

                var message = insertNewLeadResponse< 0? "There were errors while trying to add the new lead.":"New Lead Successfully Added";

                return Json(new { Result = result, Message = message });
            }
            catch (Exception e)
            {
                return Json(new {Result = "Error", Message = "There were errors while trying to add the new lead."});
            }
        }

        public ActionResult Incidents(int? type)
        {
            ViewBag.Reports = GetUserReports(GetLoggedUserId());
            ViewBag.IncidentType = type.HasValue ? type.Value : 0;
            
            return View("OpenIncidents");
        }

        public ActionResult HistoricIncidents()
        {
            ViewBag.Reports = GetUserReports(GetLoggedUserId());

            return View("HistoricIncidents");
        }

        public ActionResult GetIncidents([DataSourceRequest] DataSourceRequest dataSourceRequest, int? incidentType)
        {
            try
            {
                var incidents = GetAllIncidents();

                var incidentsResult = (incidentType == (int)LeadType.Closed)
                    ? incidents.Where(lead => String.Equals(lead.Incident_Status, Utils.ClosedIncident, StringComparison.CurrentCultureIgnoreCase))
                    : incidents.Where(l => !String.Equals(l.Incident_Status, Utils.ClosedIncident, StringComparison.CurrentCultureIgnoreCase));

                var result = incidentsResult.ToDataSourceResult(dataSourceRequest);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return null;
            }
        }

        private IEnumerable<UserReportViewModel> GetUserReports(int userId)
        {
            try
            {
                var getReportsRequestInfo = Utils.GetRequestInfo(Method.GET, "/api/ReportConfiguration/GetUserReports");

                var reportsMetadata = _webClient.Execute<List<UserReportViewModel>>(new { userId = userId }, ApiUrls.API_KEY, ApiUrls.API_SECRET, getReportsRequestInfo);

                var results = reportsMetadata.Where(rep => rep.IsStandAlone);

                return results;

            }
            catch (Exception exception)
            {
                return new List<UserReportViewModel>();
            }
        }

        private IEnumerable<ConsignmentType> GetLeadsPropose()
        {
            try
            {
                var consignmentTypes = GetConsignmentTypes();

                var leadsProposeResult = consignmentTypes.Where(a => String.Equals(a.Type, Utils.LeadInterestedIn, StringComparison.InvariantCultureIgnoreCase));

                return leadsProposeResult;
            }
            catch (Exception exception)
            {
                return new List<ConsignmentType>();
            }
      
        }

        private IEnumerable<ConsignmentType> GetHearingTypes()
        {
            try
            {
              var consignmentTypes = GetConsignmentTypes();

              var leadsProposeResult = consignmentTypes.Where(a => String.Equals(a.Type, Utils.LeadHear, StringComparison.CurrentCultureIgnoreCase) || String.Equals(a.Type, Utils.LeadHearX, StringComparison.CurrentCultureIgnoreCase));

              return leadsProposeResult;
            }
            catch (Exception e)
            {
                return new List<ConsignmentType>();
            }
     
        }

        private IEnumerable<ConsignmentType> GetConsignmentTypes()
        {
            try
            {
            var getConsignmentsRequestInfo = Utils.GetRequestInfo(Method.GET, "/api/Lead/GetTypes");

            var types = _webClient.Execute<List<ConsignmentType>>(ApiUrls.API_KEY, ApiUrls.API_SECRET, getConsignmentsRequestInfo);

            return types;
            }
            catch (Exception)
            {
                return null;
            }
  
        }

        private int AddLead(NewLeadViewModel newLeadViewModel)
        {
            var getAddNewLeadRequestInfo = Utils.GetRequestInfo(Method.POST, "/api/Lead/Add");

            var insertLeadResponse = _webClient.Execute<AddNewLeadResponse>(newLeadViewModel, ApiUrls.API_KEY, ApiUrls.API_SECRET, getAddNewLeadRequestInfo);

            return insertLeadResponse.LeadId;
        }

        private void SetNewPassword(ChangePasswordModel changePasswordModel)
        {
           var getChangePasswordRequestInfo = Utils.GetRequestInfo(Method.POST, "/api/User/ChangePassword");

           var changePasswordResponse = _webClient.Execute<UserModel>(changePasswordModel, ApiUrls.API_KEY, ApiUrls.API_SECRET, getChangePasswordRequestInfo);

        }

        private void SetUpNewLead(NewLeadViewModel newLeadViewModel)
        {

            var userInSession = HttpContext.Session[Utils.UserKey] as UserModel;

            if (!userInSession.IsNull())
            {
                //It means the user logged is an agentID
                if (userInSession.EmployeeId > 0)
                    newLeadViewModel.UserAdder_empId = userInSession.EmployeeId;
                    //Otherwise it's a Merchant and it's passed in the MID parameter
                else
                    newLeadViewModel.MID = GetLoggedUserId();
            }

            //Defining the next visit(To be changed)
            newLeadViewModel.Source = "Virtual Office Web Site";
            newLeadViewModel.status_id = 10;
            newLeadViewModel.nextVisit = DateTime.Today.AddMonths(1);

        }

       

        private int GetLoggedUserId()
        {
            var userModel = HttpContext.Session[Utils.UserKey] as UserModel;

            return userModel.IsNull() ? 0 : userModel.UserId;
        }
    }
}