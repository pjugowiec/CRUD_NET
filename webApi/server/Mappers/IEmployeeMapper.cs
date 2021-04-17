using System;
using server.Domain.Models;
using webApi.Domain.Entities;

namespace server.Mappers
{
    public interface IEmployeeMapper
    {
        public EmployeeEntity EmployeeModifyToEmployeeEntity(EmployeeModify employee);
        public EmployeeEntity UpdateEmployeeEntityByEmployeeModify(EmployeeModify employee, EmployeeEntity employeeEntity);
    }
}
