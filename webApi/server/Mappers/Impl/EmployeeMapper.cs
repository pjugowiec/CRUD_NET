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

        public EmployeeEntity EmployeeCreateToEmployeeEntity(EmployeeCreate employee)
        {
            return new EmployeeEntity()
            {
                Name = employee.Name,
                Surname = employee.Surname,
                DateBirth = employee.DateBirth,
                AddressEntity = _addressService.GetAddressEntityByDto(employee.address),
                UserEntity = _userMapper.UserCreateToUserEntity(employee.user)

            };
        }

        public EmployeeEntity UpdateEmployeeEntityByEmployeeCreate(EmployeeCreate employee, EmployeeEntity employeeEntity)
        {
            employeeEntity.Name = employee.Name == employeeEntity.Name ? employeeEntity.Name : employee.Name;
            employeeEntity.Surname = employee.Surname == employeeEntity.Surname ? employeeEntity.Surname : employee.Surname;
            employeeEntity.DateBirth = employee.DateBirth == employeeEntity.DateBirth ? employeeEntity.DateBirth : employee.DateBirth;
            employeeEntity.AddressEntity = _addressService.GetAddressEntityByDto(employee.address);
            employeeEntity.UserEntity = _userMapper.UpdateUserEntityByUserCreate(employee.user, employeeEntity.UserEntity);

            return employeeEntity;
        }


    }
}
