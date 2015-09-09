using System;
using System.Collections.Generic;
using Domain.Infrastructure.Repositories;
using Domain.Infrastructure.Services;
using Domain.Models;

namespace Services.Concrete
{
    public class LeadService : IQueryLeadService, ICommandLeadService
    {

        private IPindataLeadRepository _leadRepository;
        private readonly IConsignmentLeadRepository _consignmentLeadRepository;

        public LeadService(IPindataLeadRepository leadRepository, IConsignmentLeadRepository consignmentLeadRepository)
        {
            _leadRepository = leadRepository;
            _consignmentLeadRepository = consignmentLeadRepository;
        }

        public IEnumerable<Lead> GetOpenLeads(int agentId, DateTime startDate, DateTime endDate)
        {
            return _leadRepository.GetOpenLeads(agentId, startDate, endDate);
        }

        public IEnumerable<ConsignmentType> Types()
        {
            var types = _consignmentLeadRepository.GetTypes();

            return types;
        }

        public int Add(NewLead lead)
        {
            int leadId = _consignmentLeadRepository.Add(lead);

            return leadId;
        }
    }
}
