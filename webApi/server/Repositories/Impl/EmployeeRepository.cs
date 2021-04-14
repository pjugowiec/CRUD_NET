using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using server.Domain.Models;
using server.Utils;
using webApi;
using webApi.Domain.Entities;

namespace server.Repositories.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private DbSet<EmployeeEntity> _entities;

        public EmployeeRepository(AppDbContext context)
        {
            _entities = context.Set<EmployeeEntity>();
        }

        public IEnumerable<Employee> getEmployees()
        {
            return _entities.Select(emp => new Employee
            {
                Id = emp.Id,
                Name = emp.Name,
                Surname = emp.Surname,
                Age = CommonUtils.CalculateAge(emp.DateBirth),
                Username = emp.UserEntity.Login,
                IsActive = emp.UserEntity.IsActive,
                CountOfProjects = emp.EmployeeProjects.Count
            }).ToList();
        }
    }
}
