using System;
using server.Domain.Models;
using webApi.Domain.Entities;

namespace server.Mappers
{
    public interface IEmployeeMapper
    {
        public EmployeeEntity EmployeeCreateToEmployeeEntity(EmployeeCreate employee);
        public EmployeeEntity UpdateEmployeeEntityByEmployeeCreate(EmployeeCreate employee, EmployeeEntity employeeEntity);
    }
}
