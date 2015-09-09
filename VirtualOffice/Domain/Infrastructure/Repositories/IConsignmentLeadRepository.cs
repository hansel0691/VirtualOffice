using System.Collections.Generic;
using Domain.Models;

namespace Domain.Infrastructure.Repositories
{
    public interface IConsignmentLeadRepository
    {
        int Add(NewLead lead);
        
        IEnumerable<ConsignmentType> GetTypes();
    }
}