﻿using System;
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
        public void CreateEmployee(EmployeeCreate employee)
        {
            EmployeeEntity employeeEntity = _employeeMapper.EmployeeCreateToEmployeeEntity(employee);
            _genericRepo.Insert(employeeEntity);
        }

        public EmployeeEntity GetEmployeeById(long id)
        {
            return _genericRepo.GetById(id);
        }

        [Transactional]
        public void UpdateEmployee(EmployeeCreate employee, long id)
        {
            EmployeeEntity employeeEntity = _employeeRepo.GetEmployeeByIdWithRelations(id);
            EmployeeEntity updatedEntity =
                _employeeMapper.UpdateEmployeeEntityByEmployeeCreate(employee, employeeEntity);
            _genericRepo.Update(updatedEntity);

        }

        public void DeleteEmployeeById(long id)
        {
            _genericRepo.DeleteById(id);
        }
    }
}
