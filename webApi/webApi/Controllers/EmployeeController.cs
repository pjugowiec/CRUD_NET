using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using webApi.Domain.Entities;
using webApi.Repositories;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<EmployeeEntity> _employeeRepo;

        public EmployeeController(IRepository<EmployeeEntity> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet(Name = "Get employees")]
        public IEnumerable<EmployeeEntity> GetEmployees()
        {
            return _employeeRepo.GetAll();
        }

        [HttpGet("{id}", Name = "Find by Id")]
        public void GetEmployeeById([FromQuery] long id)
        {
            _employeeRepo.Get(id);
        }

        [HttpPost(Name = "Create Employee")]
        public void CreateEmployee([FromBody] EmployeeEntity employee)
        {
            _employeeRepo.Insert(employee);
        }

        [HttpPut("{id}", Name = "Update Employee")]
        public void UpdateEmployee([FromQuery] long id, [FromBody] EmployeeEntity employee)
        {
            _employeeRepo.Update(employee, id);
        }

        [HttpDelete("{id}", Name = "Delete employee by id")]
        public void DeleteEmployeeById([FromQuery] long id)
        {
            _employeeRepo.Delete(id);
        }
    }
}
