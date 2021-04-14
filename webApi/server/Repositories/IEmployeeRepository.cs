using System;
using System.Collections.Generic;
using server.Domain.Models;

namespace server.Repositories
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> getEmployees();
    }
}
