using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Infrastructure.Services
{
    public interface IIncidentService
    {
        IEnumerable<Incident> GetIncidents(int agentId, DateTime startDate, DateTime endDate);
    }
}
