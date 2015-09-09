using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Infrastructure.Repositories;
using Domain.Infrastructure.Services;
using Domain.Models;

namespace Services.Concrete
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentsRepository _incidentsRepository;

        public IncidentService(IIncidentsRepository incidentsRepository)
        {
            if (incidentsRepository == null)
            {
                throw new ArgumentNullException("incidentsRepository");
            }

            _incidentsRepository = incidentsRepository;
        }

        public IEnumerable<Incident> GetIncidents(int agentId, DateTime startDate, DateTime endDate)
        {
            var incidents = _incidentsRepository.GetIncidents(agentId, startDate, endDate);
                
            return incidents;
        }
    }
}