using System;
using server.Domain.Models;
using server.Repositories;
using server.Services;
using webApi.Domain.Entities;

namespace server.Mappers.Impl
{
    public class EmployeeMapper : IEmployeeMapper
    {

        private readonly IAddressService _addressService;
        private readonly IUserMapper _userMapper;

        public EmployeeMapper(IAddressService addressService,
            IUserMapper userMapper)
        {
            _addressService = addressService;
            _userMapper = userMapper;
        }

        public EmployeeEntity EmployeeModifyToEmployeeEntity(EmployeeModify employee)
        {
            return new EmployeeEntity()
            {
                Name = employee.Name,
                Surname = employee.Surname,
                DateBirth = employee.DateBirth,
                AddressEntity = _addressService.GetAddressEntityByDto(employee.Address),
                UserEntity = _userMapper.UserModifyToUserEntity(employee.User)
            };
        }

        public EmployeeEntity UpdateEmployeeEntityByEmployeeModify(EmployeeModify employee, EmployeeEntity employeeEntity)
        {
            employeeEntity.Name = employee.Name == employeeEntity.Name ? employeeEntity.Name : employee.Name;
            employeeEntity.Surname = employee.Surname == employeeEntity.Surname ? employeeEntity.Surname : employee.Surname;
            employeeEntity.DateBirth = employee.DateBirth == employeeEntity.DateBirth ? employeeEntity.DateBirth : employee.DateBirth;
            employeeEntity.AddressEntity = _addressService.GetAddressEntityByDto(employee.Address);
            employeeEntity.UserEntity = _userMapper.UpdateUserEntityByUserModify(employee.User, employeeEntity.UserEntity);

            return employeeEntity;
        }
    }
}
