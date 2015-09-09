using System;
using System.Collections.Generic;
using Domain.Models;

namespace Domain.Infrastructure.Repositories
{
    public interface IIncidentsRepository
    {
        IEnumerable<Incident> GetIncidents(int agentId, DateTime startDate, DateTime endDate);
    }
}