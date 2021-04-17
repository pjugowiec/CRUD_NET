using System;
using System.Collections.Generic;
using server.Domain.Models;
using webApi.Domain.Entities;

namespace server.Repositories
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> getEmployees();
        public EmployeeEntity GetEmployeeByIdWithRelations(long id);
        public EmployeeModify GetEmployeeById(long id);
        public void DeleteCascadeByEmployeeId(long id);
    }
}
