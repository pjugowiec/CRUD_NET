using System;
using System.Collections.Generic;
using server.Domain.Models;
using webApi.Domain.Entities;

namespace server.Services
{
    public interface IEmployeeService
    {
        // <summary>Get all employees</summary>
        // <returns>Collection of objects that represents employees</returns>
        public IEnumerable<Employee> GetEmployees();

        // <summary>Add new employee to database</summary>
        // <param name="employee">Object containing data to add a user</param>
        public void CreateEmployee(EmployeeModify employee);

        // <summary>Get a single user by his ID</summary>
        // <param name="id">User ID that we want to get from the database</param>
        // <returns>Object that represents the employee</returns>
        public EmployeeModify GetEmployeeById(long id);

        // <summary>Update an employee by his ID</summary>
        // <param name="employee">Object containing the user's updated data</param>
        // <param name="id">User ID that we want to update</param>
        public void UpdateEmployee(EmployeeModify employee, long id);

        // <summary>Delete a single user by his ID</summary>
        // <param name="id">User ID that we want to delete from the database</param>
        public void DeleteEmployeeById(long id);
    }
}
