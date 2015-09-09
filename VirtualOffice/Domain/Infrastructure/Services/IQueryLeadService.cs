using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Domain.Models;

namespace Domain.Infrastructure.Services
{
    public interface IQueryLeadService
    {
        IEnumerable<Lead> GetOpenLeads(int agentId, DateTime startDate, DateTime endDate);

        IEnumerable<ConsignmentType> Types();
    }

    public interface ICommandLeadService
    {
        int Add(NewLead lead);
    }
}