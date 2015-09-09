using System;
using System.Collections.Generic;
using System.Linq;
using CoreData.Contexts;
using Domain.Infrastructure.Repositories;
using Domain.Models;
using Domain.Models.Exceptions;

namespace CoreData.Concrete
{
    public class SqlConsignmentLeadRepository : IConsignmentLeadRepository
    {
        private readonly ConsignmentContext _context;

        public SqlConsignmentLeadRepository(ConsignmentContext context)
        {
            _context = context;
        }

        public int Add(NewLead lead)
        {
            try
            {
                int id = _context.Add(lead);

                return id;
            }
            catch (Exception e)
            {
                throw new DataAccessException("Impossible to insert new lead", e);
            }
        }

        public IEnumerable<ConsignmentType> GetTypes()
        {
            try
            {
                var result = _context.Types.ToArray();

                return result;
            }
            catch (Exception e)
            {
                throw new DataAccessException("Impossible to access to Consignment Db", e);
            }
        }
    }
}