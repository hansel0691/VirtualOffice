using System;
using System.Collections.Generic;
using CoreData.Contexts;
using Domain.Infrastructure.Repositories;
using Domain.Models;

namespace CoreData.Concrete
{
    public class SqlIncidentRepository : Repository<Incident>, IIncidentsRepository
    {
        public SqlIncidentRepository(PindataContext context) 
            : base(context.Set<Incident>())
        {
        }

        public IEnumerable<Incident> GetIncidents(int agentId, DateTime startDate, DateTime endDate)
        {
            var incidents = Get(incident => incident.AgentId == agentId &&
                                            incident.DateOpened >= startDate &&
                                            incident.DateClosed <= endDate);

            return incidents;
        }
    }
}