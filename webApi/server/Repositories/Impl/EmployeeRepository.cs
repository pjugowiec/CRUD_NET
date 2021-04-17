using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using server.Domain.Models;
using server.Utils;
using webApi;
using webApi.Domain.Entities;
using Z.EntityFramework.Plus;

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

        public EmployeeModify GetEmployeeById(long id)
        {
            return _entities.Where(s => s.Id == id)
                .Select(emp => new EmployeeModify
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Surname = emp.Surname,
                    DateBirth = emp.DateBirth,
                    Address = new AddressModify
                    {
                        Id = emp.AddressEntity.Id,
                        Street = emp.AddressEntity.Street,
                        Number = emp.AddressEntity.Number,
                        City = emp.AddressEntity.City
                    },
                    User = new UserModify
                    {
                        Id = emp.UserEntity.Id,
                        Email = emp.UserEntity.Email,
                        Login = emp.UserEntity.Login
                    }
                }).SingleOrDefault();
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

        public void DeleteCascadeByEmployeeId(long id)
        {
            EmployeeEntity employeeEntity = _entities.Single(s => s.Id == id);
            _context.Users.Where(s => s.Id == employeeEntity.Id).Delete();
            _entities.Where(s => s.Id == id).Delete();
            _context.SaveChanges();
        }
    }
}
