using System.Collections.Generic;

namespace Domain.Blackstone
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
    }
}