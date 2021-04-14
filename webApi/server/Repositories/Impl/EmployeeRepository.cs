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
        private readonly AppDbContext _context;
        private DbSet<EmployeeEntity> _entities;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
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

        public EmployeeEntity GetEmployeeByIdWithRelations(long id)
        {
            EmployeeEntity employeeEntity = _entities.Single(s => s.Id == id);
            employeeEntity.UserEntity = GetUserEntityByJoining(id);
            return employeeEntity;
       }

        private UserEntity GetUserEntityByJoining(long id)
        {
            return _entities
                .Where(s => s.Id == id)
                .Join(
                _context.Users,
                emp => emp.UserEntity.Id,
                usr => usr.Id,
                (emp, usr) => new UserEntity
                {
                    Id = usr.Id,
                    Email = usr.Email,
                    IsActive = usr.IsActive,
                    Login = usr.Login,
                    Password = usr.Password
                }).FirstOrDefault();
        }
    }
}
