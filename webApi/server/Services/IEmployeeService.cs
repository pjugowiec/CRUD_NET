using System;
using System.Collections.Generic;
using server.Domain.Models;

namespace server.Services
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> getEmployees();
        public void createEmployee(EmployeeCreate employee);
    }
}
