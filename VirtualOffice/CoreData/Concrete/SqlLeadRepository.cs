using System;
using System.Collections.Generic;
using CoreData.Contexts;
using Domain.Infrastructure.Repositories;
using Domain.Models;

namespace CoreData.Concrete
{
    public class SqlPindataLeadRepository : Repository<Lead>, IPindataLeadRepository
    {
        public SqlPindataLeadRepository(PindataContext context) 
            : base(context.Set<Lead>())
        {
        }

        public IEnumerable<Lead> GetOpenLeads(int agentId, DateTime startDate, DateTime endDate)
        {
            var openLeads = Get(lead => lead.AgentId == agentId &&
                                        lead.Entered >= startDate &&
                                        lead.Entered <= endDate);

            return openLeads;
        }
    }
}