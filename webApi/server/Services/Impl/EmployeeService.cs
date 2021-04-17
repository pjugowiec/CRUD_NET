using System;
using System.Collections.Generic;
using server.Domain.Annotations;
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

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeRepo.getEmployees();
        }

        [Transactional]
        public void CreateEmployee(EmployeeModify employee)
        {
            EmployeeEntity employeeEntity = _employeeMapper.EmployeeModifyToEmployeeEntity(employee);
            _genericRepo.Insert(employeeEntity);
        }

        public EmployeeModify GetEmployeeById(long id)
        {
            return _employeeRepo.GetEmployeeById(id);
        }

        [Transactional]
        public void UpdateEmployee(EmployeeModify employee, long id)
        {
            EmployeeEntity employeeEntity = _employeeRepo.GetEmployeeByIdWithRelations(id);
            EmployeeEntity updatedEntity =
                _employeeMapper.UpdateEmployeeEntityByEmployeeModify(employee, employeeEntity);
            _genericRepo.Update(updatedEntity);

        }

        public void DeleteEmployeeById(long id)
        {
            _employeeRepo.DeleteCascadeByEmployeeId(id);
        }
    }
}
