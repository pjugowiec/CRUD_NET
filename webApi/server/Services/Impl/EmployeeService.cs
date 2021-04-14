using System;
using System.Collections.Generic;
using server.Domain.Models;
using server.Mappers;
using server.Repositories;
using webApi.Domain.Entities;
using webApi.Repositories;

namespace server.Services.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<EmployeeEntity> _genericRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IEmployeeMapper _employeeMapper;

        public EmployeeService(IRepository<EmployeeEntity> genericRepo,
            IEmployeeRepository employeeRepo,
            IEmployeeMapper employeeMapper)
        {
            _genericRepo = genericRepo;
            _employeeRepo = employeeRepo;
            _employeeMapper = employeeMapper;
        }

        public IEnumerable<Employee> getEmployees()
        {
            return _employeeRepo.getEmployees();
        }

        public void createEmployee(EmployeeCreate employee)
        {
            EmployeeEntity employeeEntity = _employeeMapper.EmployeeCreateToEmployeeEntity(employee);
            _genericRepo.Insert(employeeEntity);
        }
    }
}
