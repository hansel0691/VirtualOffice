using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using CoreService.Filters;
using CoreService.Models;
using Domain.Infrastructure.Log;
using Domain.Infrastructure.Services;
using Domain.Models;

namespace CoreService.Controllers
{
#if !DEBUG
   // [AuthorizationFilter]
#endif
    public class LeadController : BaseApiController
    {
        private readonly IQueryLeadService _queryLeadService;
        private readonly ICommandLeadService _commandLeadService;

        public LeadController(ILogger logger, IQueryLeadService queryLeadService, ICommandLeadService commandLeadService) 
            : base(logger)
        {
            if (queryLeadService == null)
            {
                throw new ArgumentNullException("queryLeadService");
            }

            _queryLeadService = queryLeadService;
            _commandLeadService = commandLeadService;
        }

        [HttpGet]
        public IHttpActionResult GetTypes()
        {
            var types = _queryLeadService.Types();

            return Ok(types);
        }

        [HttpPost]
        public IHttpActionResult GetLeads([FromBody]AgentTimeFilter leadRequest)
        {
            if (!leadRequest.StartDate.HasValue)
            {
                leadRequest.StartDate = DateTime.MinValue;
            }

            if (!leadRequest.EndDate.HasValue)
            {
                leadRequest.EndDate = DateTime.Now;
            }

            var openLeads = _queryLeadService.GetOpenLeads(leadRequest.AgentId, leadRequest.StartDate.Value, leadRequest.EndDate.Value);

            return Ok(openLeads);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] NewLead lead)
        {
            int leadId = _commandLeadService.Add(lead);

            return Ok(new {LeadId = leadId});
        }

        [HttpGet]
        public IHttpActionResult TestGetLeads()
        {
            return GetLeads(new AgentTimeFilter {AgentId = 2272});
        }
    }
}