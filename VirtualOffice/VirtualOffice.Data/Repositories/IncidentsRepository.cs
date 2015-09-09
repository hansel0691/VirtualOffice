using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualOffice.Data.EFModels;

namespace VirtualOffice.Data.Repositories
{
    public class IncidentsRepository: BaseRepository
    {
        public IEnumerable<sp_retrieve_incidents_Result> GetAllIncidents(int agentId, DateTime? startDate, DateTime? endDate)
        {
            var incidents = VirtualOfficeContext.sp_retrieve_incidents(agentId, startDate, endDate);

            return incidents;
        }
    }
}
