using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiRestClient.Infrastructure;
using Domain.Models;
using VirtualOffice.Data.EFModels;

namespace VirtualOffice.Data.Repositories
{
    public class LeadRepository : BaseRepository
    {
        public IEnumerable<sp_retrieve_leads_Result> GetLeads(int agentId, DateTime? startDate, DateTime? endDate)
        {
            var leads = VirtualOfficeContext.sp_retrieve_leads(agentId, startDate, endDate);

            return leads;

        }
    }
}
