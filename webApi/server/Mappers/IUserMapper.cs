using System;
using server.Domain.Models;
using webApi.Domain.Entities;

namespace server.Mappers
{
    public interface IUserMapper
    {
        public UserEntity UserCreateToUserEntity(UserCreate user);
    }
}
