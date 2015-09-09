using System.Collections.Generic;
using CoreData.BlackstoneDb.Context;
using Domain.Blackstone;

namespace CoreData.BlackstoneDb
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly BlackstoneDbContext _context;

        public EmployeeRepository(BlackstoneDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees;
        }
    }
}