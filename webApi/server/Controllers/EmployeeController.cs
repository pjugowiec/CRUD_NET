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

        [HttpGet(Name = "GetEmployees")]
        public IEnumerable<EmployeeEntity> GetAll()
        {
            return _employeeRepo.GetAll();
        }

        [HttpGet("{id}", Name = "FindEmployeeById")]
        public void GetById([FromQuery] long id)
        {
            _employeeRepo.Get(id);
        }

        [HttpPost(Name = "CreateEmployee")]
        public void Create([FromBody] EmployeeEntity employee)
        {
            _employeeRepo.Insert(employee);
        }

        [HttpPut("{id}", Name = "UpdateEmployee")]
        public void Update([FromQuery] long id, [FromBody] EmployeeEntity employee)
        {
            _employeeRepo.Update(employee, id);
        }

        [HttpDelete("{id}", Name = "DeleteEmployeeById")]
        public void DeleteById([FromQuery] long id)
        {
            _employeeRepo.Delete(id);
        }
    }
}
