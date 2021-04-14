using System;
using System.Collections.Generic;
using server.Domain.Models;
using webApi.Domain.Entities;

namespace server.Services
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> GetEmployees();
        public void CreateEmployee(EmployeeCreate employee);
        public EmployeeEntity GetEmployeeById(long id);
        public void UpdateEmployee(EmployeeCreate employee, long id);
        public void DeleteEmployeeById(long id);
    }
}
