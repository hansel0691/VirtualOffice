using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using CoreService.Models;
using Domain.Infrastructure.Log;
using Domain.Infrastructure.Services;
using Domain.Models;

namespace CoreService.Controllers
{
    public class IncidentController : BaseApiController
    {
        private IIncidentService _incidentService;

        public IncidentController(ILogger logger, IIncidentService incidentService) 
            : base(logger)
        {
            _incidentService = incidentService;
        }

        [HttpPost]
        public IHttpActionResult GetIncidents([FromBody]AgentTimeFilter filter)
        {
            if (!filter.StartDate.HasValue)
            {
                filter.StartDate = DateTime.MinValue;
            }

            if (!filter.EndDate.HasValue)
            {
                filter.EndDate = DateTime.Now;
            }

            var incidents = _incidentService.GetIncidents(filter.AgentId, filter.StartDate.Value, filter.EndDate.Value);

            return Ok(incidents);
        }

        [HttpGet]
        public IHttpActionResult TestGetIncidents()
        {
            return GetIncidents(new AgentTimeFilter {AgentId = 2272});
        }
    }
}
