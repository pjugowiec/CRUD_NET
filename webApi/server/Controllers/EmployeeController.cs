using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using server.Domain.Models;
using server.Services;
using webApi.Domain.Entities;
using webApi.Repositories;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        { 
            _employeeService = employeeService;
        }

        [HttpGet(Name = "GetEmployees")]
        public IEnumerable<Employee> GetAll()
        {
            return _employeeService.getEmployees();
        }

        //[HttpGet("{id}", Name = "FindEmployeeById")]
        //public void GetById([FromQuery] long id)
        //{
        //    _employeeRepo.Get(id);
        //}

        [HttpPost(Name = "CreateEmployee")]
        public void Create([FromBody] EmployeeCreate employee)
        {
            _employeeService.createEmployee(employee);
        }

        //[HttpPut("{id}", Name = "UpdateEmployee")]
        //public void Update([FromQuery] long id, [FromBody] EmployeeEntity employee)
        //{
        //    _employeeRepo.Update(employee, id);
        //}

        //[HttpDelete("{id}", Name = "DeleteEmployeeById")]
        //public void DeleteById([FromQuery] long id)
        //{
        //    _employeeRepo.Delete(id);
        //}
    }
}
