using System;
using System.Collections.Generic;
using server.Domain.Models;
using webApi.Domain.Entities;

namespace server.Services
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> GetEmployees();
        public void CreateEmployee(EmployeeModify employee);
        public EmployeeModify GetEmployeeById(long id);
        public void UpdateEmployee(EmployeeModify employee, long id);
        public void DeleteEmployeeById(long id);
    }
}
