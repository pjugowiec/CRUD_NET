using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Domain.Models;
using server.Services;
using webApi.Domain.Entities;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<Employee> GetAll()
        {
            return _employeeService.GetEmployees();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}", Name = "FindEmployeeById")]
        public EmployeeModify GetById(long id)
        {
            return _employeeService.GetEmployeeById(id);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost(Name = "CreateEmployee")]
        public void Create([FromBody] EmployeeModify employee)
        {
            _employeeService.CreateEmployee(employee);
        }

        [HttpPut("{id}", Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Update(long id, [FromBody] EmployeeModify employee)
        {
            _employeeService.UpdateEmployee(employee, id);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}", Name = "DeleteEmployeeById")]
        public void DeleteById(long id)
        {
            _employeeService.DeleteEmployeeById(id);
        }
    }
}
