using System;
using System.Collections.Generic;
using Domain.Models;

namespace Domain.Infrastructure.Repositories
{
    public interface IPindataLeadRepository
    {
        IEnumerable<Lead> GetOpenLeads(int agentId, DateTime startDate, DateTime endDate);
    }
}